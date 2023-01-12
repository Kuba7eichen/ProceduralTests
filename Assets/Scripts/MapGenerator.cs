using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private int _subdivisions;
    [SerializeField] private float _scale;
    private List<GameObject> _chunks = new List<GameObject>();
    [HideInInspector] public GameObject _currentChunk;
    public Vector2 _chunkSize;


    public enum Direction
    {
        NORTH,
        SOUTH,
        EAST,
        WEST,
        NONE
    }

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
        GameObject chunk = MeshGenerator.GenerateMesh(_currentChunk, _subdivisions, _chunkSize, _scale, Vector2.zero, _material);
        chunk.transform.position = Vector3.zero;
        _chunks.Add(chunk);
        return chunk;
    }
    public  GameObject GenerateChunk(Direction dir) // a new chunk is generated or reused if already in the _chunks list
    {
        Vector3 position;
        if (_currentChunk != null)
            position = _currentChunk.transform.position;
        else
            position = Vector3.zero;
        Vector2 offset;
        switch(dir)
        {
            case Direction.NORTH:
                position += Vector3.forward * _chunkSize.y;
                offset = Vector2.up * _chunkSize.y;
                break;
            case Direction.SOUTH:
                position += Vector3.back * _chunkSize.y;
                offset = Vector2.down * _chunkSize.y;
                break;
            case Direction.EAST:
                position += Vector3.right * _chunkSize.x;
                offset = Vector2.right * _chunkSize.x;
                break;
             default: // used in place of case WEST so that  the compiler sees that the position is always  assigned
                position += Vector3.left * _chunkSize.x;
                offset = Vector2.left * _chunkSize.x;
                break;
        }
        GameObject[] foundChunks = _chunks.Where(chunk => chunk.transform.position == position).ToArray<GameObject>();
        GameObject chunk;
        if (foundChunks.Length != 0)
        {
            chunk = foundChunks[0];

            if (chunk.activeSelf == false)
            {
                chunk.SetActive(true);
            }
        }
        else
        {
            chunk = MeshGenerator.GenerateMesh(_currentChunk, _subdivisions, _chunkSize, _scale, offset, _material);
            chunk.transform.position = position;
            chunk.AddComponent<MeshCollider>();

            _chunks.Add(chunk);
        }
        _currentChunk = chunk;

        CleanupMap(_currentChunk.transform.position); // each time a new chunk is created some old ones could be set inactive

        return chunk;
    }

    public void CleanupMap(Vector3 currentChunkPosition)
    {
        foreach(var chunk in _chunks)
        {
            if(Vector3.Distance(chunk.transform.position, currentChunkPosition) > _chunkSize.x * 2)
            {
                chunk.SetActive(false);
            }
        }
    }
}
