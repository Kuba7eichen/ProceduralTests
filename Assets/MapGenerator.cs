using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private Vector2 _chunkSize;
    [SerializeField] private int _subdivisions;
    [SerializeField] private float _scale;
    private GameObject[] _chunks;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject GenerateChunk()
    {
        GameObject chunk = MeshGenerator.GenerateMesh(_subdivisions, _chunkSize, _scale, Vector2.zero, _material);
        return chunk;
    }
}
