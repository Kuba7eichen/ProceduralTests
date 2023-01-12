using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseGenerator : MonoBehaviour
{
    public static float[,] Generate(int width, int heigh, float scale, Vector2 offset)
    {
        float[,] noiseMap = new float[width, heigh];

        for(int x = 0; x< width; x++)
        {
            for(int y=0; y<heigh; y++)
            {
                float sampleX = (float)x * scale + offset.x;
                float sampleY = (float)y * scale + offset.y;
                noiseMap[x, y] = Mathf.PerlinNoise(sampleX, sampleY);
                
            }
        }
        return noiseMap;
    }

    public static Vector3[] Test(GameObject currentChunk, Vector3[] vertices, float scale)
    {
        for (var i = 0; i < vertices.Length; i++)
        {

            Vector3 worldPosition = currentChunk.transform.TransformPoint(vertices[i]);

            vertices[i].y += Mathf.PerlinNoise(worldPosition.x, worldPosition.z) * scale;
        }

        return vertices;
    }
}
