// Upgrade NOTE: upgraded instancing buffer 'Props' to new syntax.

Shader "Custom/Boid" {
	Properties {
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_PositionScale("PositionScale", Range(0, 100000)) = 250
		_TimeMultiplier("Time Scale", Range(-1000, 1000)) = 1
		_Alpha("Alpha", Range(0, 1)) = 0.5
		_Offset("Offset", Range(0, 100000)) = 0
		_CI("CI", Range(0, 10000000)) = 0
		_ColorStart("ColorStart", Range(-10, 10)) = 0
		_ColorEnd("ColorEnd", Range(-10, 10)) = 1
		_ColorWidth("ColorWidth", Range(-10, 10)) = 1
		_ColorShift("ColorShift", Range(-10, 10)) = 1
		
	}
	SubShader {
		Tags {"Queue" = "Transparent" "RenderType"="Transparent" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard alpha:fade
		
		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		#include "UnityCG.cginc"

		sampler2D _MainTex;
		
		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
		};

		float _Glossiness;
		float _Metallic;
		float _Alpha;
		float _Offset;

		float _PositionScale;
		float _TimeMultiplier;
		float _ColorStart;
		float _ColorEnd;
		float _ColorShift;
		float _ColorWidth;
		
		float _CI;

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

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			
			float d = length(IN.worldPos);

			float w = _ColorWidth * 0.5; 
			float cs = 0.5f - w;			
			float ce = 0.5f + w ; // 0.5 + w;

			//cs = clamp(cs, 0, 1);
			//ce = clamp(ce, 0, 1);

			/*if (cs > ce)
			{
				float temp = cs;
				cs = ce;
				ce = temp;
			}
			*/

			
			//float t = _Time * _TimeMultiplier;
			//float hue = (pingpongMap(d + (_Time * _TimeMultiplier * 5.0), 0, _PositionScale, cs, ce));
			
			float t = _Time * _TimeMultiplier * 5.0;
			
			float hue = pingpongMap(d - t, 0, _PositionScale , cs, ce);
			//hue = wrap(hue);
			//hue = _ColorShift;
			//hue += ;
			
			//hue = hue + (_ColorShift / 360.0);
			hue = hue -  floor(hue);
			
			float b = map(d, 0, 200, 1, 0);
			
			float camD = length(_WorldSpaceCameraPos);
			
			float ci = 1 + (_CI *  (1.0 / d));//pow(_CI, 1.0 / d);

			fixed3 c = hsv_to_rgb(float3(hue, 1, ci));

			/*
			fixed4 c1 = fixed4(0,0,0,0);
			c1.r = c.r;
			c1.g = c.g;
			c1.b = c.b;
			c1.a = _Alpha;
			*/

			//float3 shift = float3(_ColorShift, 1, 1);
			//c = shift_col(c, shift);
			//c.a = _Alpha;
			o.Albedo = c;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = _Alpha;
		}
		ENDCG
	}
	FallBack "Diffuse"
}