Shader "Custom/HeightColor"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input {
			float2 uv_MainTex;
			float3 worldPos;
		};

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        float map(float value, float r1, float r2, float m1, float m2)
		{
			float dist = value - r1;
			float range1 = r2 - r1;
			float range2 = m2 - m1;
			return m1 + ((dist / range1) * range2);
		}
		
		float3 hsv_to_rgb(float3 HSV)
		{
			float3 RGB = HSV.z;

			float var_h = HSV.x * 6;
			float var_i = floor(var_h);   // Or ... var_i = floor( var_h )
			float var_1 = HSV.z * (1.0 - HSV.y);
			float var_2 = HSV.z * (1.0 - HSV.y * (var_h - var_i));
			float var_3 = HSV.z * (1.0 - HSV.y * (1 - (var_h - var_i)));
			if (var_i == 0) { RGB = float3(HSV.z, var_3, var_1); }
			else if (var_i == 1) { RGB = float3(var_2, HSV.z, var_1); }
			else if (var_i == 2) { RGB = float3(var_1, HSV.z, var_3); }
			else if (var_i == 3) { RGB = float3(var_1, var_2, HSV.z); }
			else if (var_i == 4) { RGB = float3(var_3, var_1, HSV.z); }
			else { RGB = float3(HSV.z, var_1, var_2); }

			return (RGB);
		}

		float pingpongMap(float a, float b, float c, float d, float e)
		{
			float range1 = c - b;
			float range2 = e-d;
			if (range1 == 0)
			{
				return d;
			}
			
			if (range2 == 0)
			{
				return d;
			}
			
			float howFar = a - b;
			
			float howMany = floor(howFar / range1);
			float fraction = (howFar - (howMany * range1)) / range1;
			//println(a + " howMany" + howMany + " fraction: " + fraction);
			//println(range2 + " " + fraction);
			if (howMany % 2 == 0)
			{
				return d + (fraction * range2);
			}
			else
			{
				//return d + (fraction * range2);
				return e - (fraction * range2);
			}
			
		}

		float3 shift_col(float3 RGB, float3 shift)
		{
			float3 RESULT = float3(RGB);
			float VSU = shift.z*shift.y*cos(shift.x*3.14159265/180);
			float VSW = shift.z*shift.y*sin(shift.x*3.14159265/180);
			
			RESULT.x = (.299*shift.z+.701*VSU+.168*VSW)*RGB.x
			+ (.587*shift.z-.587*VSU+.330*VSW)*RGB.y
			+ (.114*shift.z-.114*VSU-.497*VSW)*RGB.z;
			
			RESULT.y = (.299*shift.z-.299*VSU-.328*VSW)*RGB.x
			+ (.587*shift.z+.413*VSU+.035*VSW)*RGB.y
			+ (.114*shift.z-.114*VSU+.292*VSW)*RGB.z;
			
			RESULT.z = (.299*shift.z-.3*VSU+1.25*VSW)*RGB.x
			+ (.587*shift.z-.588*VSU-1.05*VSW)*RGB.y
			+ (.114*shift.z+.886*VSU-.203*VSW)*RGB.z;
			
			return (RESULT);
		}

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            

			float h = pingpongMap(IN.worldPos.y, 0, 20, 0, 0.5);
			fixed3 c = hsv_to_rgb(float3(h, 1, 1));
			o.Albedo = c;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = 1;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
