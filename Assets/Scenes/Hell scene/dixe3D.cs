using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dixe3D : MonoBehaviour
{
    Vector3 v0, v1, v2, v3;
    Vector3[] newVertices;

    int[] newTriangles;

    public Texture Dice;

    Vector2 UV0, UV1, UV2, UV3;
    Vector2[] newUVs;

    void Start()

    {
        v0 = new Vector3(0, 0, 0);
        v1 = new Vector3(0, 1, 0);
        v2 = new Vector3(1, 1, 0);
        v3 = new Vector3(1, 0, 0);

        newVertices = new Vector3[]
        {
            v0,v1,v2,v3
        };

        newTriangles = new int[]
        {
            0,1,2,
            0,2,3

        };

        UV0 = new Vector2(0, 0.333f);
        UV1 = new Vector2(0, 0.666f);
        UV2 = new Vector2(0.25f, 0.666f);
        UV3 = new Vector2(0.25f, 0.333f);

        newUVs = new Vector2[]
        {
            UV0,UV1,UV2,UV3
        };

        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();



        Mesh mesh = new Mesh();

        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = newVertices;
        mesh.triangles = newTriangles;
        mesh.uv = newUVs;



        Shader DefaultShader = Shader.Find("Standard");
        Material DefaultMaterial = new Material(DefaultShader);
        DefaultMaterial.mainTexture = Dice;
        gameObject.GetComponent<Renderer>().material = DefaultMaterial;
    }
}
