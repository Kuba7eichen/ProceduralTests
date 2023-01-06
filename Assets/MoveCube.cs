using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    [SerializeField] private Material _material;

    // Start is called before the first frame update
    void Start()
    {
        Vector3[] vertices = new Vector3[8];
        Vector2[] uv = new Vector2[8];
        int[] triangles = new int[36];

        vertices[0] = new Vector3(0, 1);
        vertices[1] = new Vector3(1, 1);
        vertices[2] = new Vector3(0, 0);
        vertices[3] = new Vector3(1, 0);
        vertices[4] = new Vector3(0, 1, 1);
        vertices[5] = new Vector3(1, 1, 1);
        vertices[6] = new Vector3(0, 0 , 1);
        vertices[7] = new Vector3(1, 0, 1);

        uv[0] = new Vector2(0,0);
        uv[1] = new Vector2(0,1);
        uv[2] = new Vector2(1,1);
        uv[3] = new Vector2(1,0);
        uv[4] = new Vector2(0, 0);
        uv[5] = new Vector2(0, 1);
        uv[6] = new Vector2(1, 1);
        uv[7] = new Vector2(1, 0);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        triangles[3] = 2;
        triangles[4] = 1;
        triangles[5] = 3;
        
        triangles[6] = 0;
        triangles[7] = 4;
        triangles[8] = 1;
        
        triangles[9] = 1;
        triangles[10] = 4;
        triangles[11] = 5;

        triangles[12] = 3;
        triangles[13] = 1;
        triangles[14] = 7;

        triangles[15] = 7;
        triangles[16] = 1;
        triangles[17] = 5;

        triangles[18] = 4;
        triangles[19] = 0;
        triangles[20] = 6;

        triangles[21] = 6;
        triangles[22] = 0;
        triangles[23] = 2;

        triangles[24] = 2;
        triangles[25] = 3;
        triangles[26] = 6;

        triangles[27] = 6;
        triangles[28] = 3;
        triangles[29] = 7;

        triangles[30] = 5;
        triangles[31] = 4;
        triangles[32] = 7;

        triangles[33] = 7;
        triangles[34] = 4;
        triangles[35] = 6;

        Mesh testMesh = new Mesh();
        testMesh.vertices = vertices;
        testMesh.uv = uv;
        testMesh.triangles = triangles;
        GameObject gm = new GameObject();
        MeshFilter mf = gm.AddComponent<MeshFilter>();
        MeshRenderer mr = gm.AddComponent<MeshRenderer>();
        testMesh.RecalculateNormals();
        mf.mesh = testMesh;
        mr.material = _material;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
