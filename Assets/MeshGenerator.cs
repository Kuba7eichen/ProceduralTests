using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    [SerializeField] Vector2 _sizes, _offset;
    [SerializeField] int _subdivisions;
    [SerializeField] float _scale;
    [SerializeField] private Material _material;
    private int[] triangles;
    private Vector3[] vertices;
    MeshFilter mf;
    MeshRenderer mr;

    // Start is called before the first frame update
    void Start()
    {
        //vertices = GenerateVertices(_subdivisions, _sizes);
        //triangles = GenerateTriangles(vertices);
        //vertices = ApplyNoise(vertices, _scale, _offset);

        //Mesh testMesh = new Mesh();
        //testMesh.vertices = vertices;
        //testMesh.triangles = triangles;
        //GameObject gm = new GameObject();
        //mf = gm.AddComponent<MeshFilter>();
        //mr = gm.AddComponent<MeshRenderer>();
        //testMesh.RecalculateNormals();
        //mf.mesh = testMesh;
        //mr.material = _material;

    }



    private static Vector3[] GenerateVertices(int subdivisions, Vector2 size)
    {
        float nbVerticesInARow = subdivisions + 2;
        Vector3[] vertices = new Vector3[(int)((nbVerticesInARow + 1) * (nbVerticesInARow + 1))];


        for (int i = 0, y = 0; y <= nbVerticesInARow; y++)
        {
            for (int x = 0; x <= nbVerticesInARow; x++, i++)
            {
                vertices[i] = new Vector3((x/nbVerticesInARow * size.x) - size.x / 2, 0, (y / nbVerticesInARow * size.y) - size.y / 2); // substracting size / 2 to keep the pivot point centered
            }
        }
        return vertices;

    }

    private static int[] GenerateTriangles(Vector3[] vertices)
    {
        int verticesInRow = (int)Mathf.Sqrt(vertices.Length);
        int[] triangles = new int[(int)(verticesInRow-1)*(verticesInRow-1)*6]; // *2 for two triangles by quad and *3 for 3 points each triangle

        for (int ti = 0, vi = 0, y = 0; y < verticesInRow-1; y++, vi++)
        {
            for (int x = 0; x < verticesInRow-1; x++, ti += 6, vi++)
            {
                
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + verticesInRow;
                triangles[ti + 5] = vi + verticesInRow + 1;

            }
        }
        return triangles;
    }

    private static Vector3[] ApplyNoise(Vector3[] vertices, float scale, Vector2 offset)
    {
        float[,] noiseMap = NoiseGenerator.Generate((int)Mathf.Sqrt(vertices.Length), (int)Mathf.Sqrt(vertices.Length), scale, offset);

        for(int i = 0; i < Mathf.Sqrt(vertices.Length); i++)
        {
            for(int j = 0; j < Mathf.Sqrt(vertices.Length); j++)
            {
                vertices[j + i * (int)Mathf.Sqrt(vertices.Length)] += Vector3.up * noiseMap[j, i];
            }
        }
        return vertices;
    }

    public void RecalculateMesh(int subdivisions)
    {
        vertices = GenerateVertices(subdivisions, _sizes);
        triangles = GenerateTriangles(vertices);
        vertices = ApplyNoise(vertices, _scale, _offset);

        Mesh testMesh = new Mesh();
        testMesh.vertices = vertices;
        testMesh.triangles = triangles;
        testMesh.RecalculateNormals();
        mf.mesh = testMesh;
        mr.material = _material;
    }

    public static GameObject GenerateMesh(int subdivisions, Vector2 sizes, float scale, Vector2 offset, Material material)
    {

        Vector3[] vertices = GenerateVertices(subdivisions, sizes);
        int[] triangles = GenerateTriangles(vertices);
        vertices = ApplyNoise(vertices, scale, offset);

        Mesh testMesh = new Mesh();
        testMesh.vertices = vertices;
        testMesh.triangles = triangles;
        GameObject gm = new GameObject();
        MeshFilter mf = gm.AddComponent<MeshFilter>();
        MeshRenderer mr = gm.AddComponent<MeshRenderer>();
        testMesh.RecalculateNormals();
        mf.mesh = testMesh;
        mr.material = material;

        return gm;
    }

}
