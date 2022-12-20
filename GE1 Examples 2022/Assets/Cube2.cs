using UnityEngine;

/*
public class IcosphereCreator : MonoBehaviour
{
    // The radius of the icosphere
    public float radius = 1.0f;

    // The number of subdivisions to perform on the icosphere
    public int subdivisions = 0;

    void Start()
    {
        // Create a new icosphere with the specified radius and number of subdivisions
        Mesh mesh = IcosphereCreator.CreateIcosphere(radius, subdivisions);

        // Attach the newly-created mesh to this game object
        MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        filter.mesh = mesh;

        // Add a MeshRenderer component so that the icosphere will be visible in the scene
        gameObject.AddComponent<MeshRenderer>();
    }

    public static Mesh CreateIcosphere(float radius, int subdivisions)
    {
        // Start with a regular icosahedron
        Mesh mesh = CreateIcosahedron(radius);

        // Perform the specified number of subdivisions
        for (int i = 0; i < subdivisions; i++)
        {
            mesh = Subdivide(mesh);
        }

        return mesh;
    }

}

*/
