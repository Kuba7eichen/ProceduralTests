using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseGenerator : MonoBehaviour
{
    public static float[,] Generate(int width, int heigh, float scale = 0.15f)
    {
        float[,] noiseMap = new float[width, heigh];

        for(int x = 0; x< width; x++)
        {
            for(int y=0; y<heigh; y++)
            {
                float sampleX = (float)x * scale;
                float sampleY = (float)y * scale;
                noiseMap[x, y] = Mathf.PerlinNoise(sampleX, sampleY);
                print(Mathf.PerlinNoise(sampleX, sampleY));
            }
        }
        return noiseMap;
    }
}
