using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private MapGenerator _mapGenerator;
    [SerializeField] private float _renderingDistance;
    private GameObject _currentChunk;
    private GameObject _latestChunk;
    // Start is called before the first frame update
    void Start()
    {
       _currentChunk = _mapGenerator.GenerateChunk();
        _mapGenerator._currentChunk = _currentChunk;
    }

    // Update is called once per frame
    void Update()
    {
        print("pos " + (_player.transform.position.x - _currentChunk.transform.position.x));
        print("test " + (_mapGenerator._chunkSize.x / 2 - _renderingDistance));
        if((_player.transform.position.x - _currentChunk.transform.position.x) > _mapGenerator._chunkSize.x / 2 - _renderingDistance)
        {
            _currentChunk = _mapGenerator.GenerateChunk(MapGenerator.Direction.EAST);
        }

        if ((_player.transform.position.x - _currentChunk.transform.position.x) < _mapGenerator._chunkSize.x / -2 - _renderingDistance)
        {
            _currentChunk = _mapGenerator.GenerateChunk(MapGenerator.Direction.WEST);
        }

        if ((_player.transform.position.z - _currentChunk.transform.position.z) > _mapGenerator._chunkSize.y / 2 - _renderingDistance)
        {
            _currentChunk = _mapGenerator.GenerateChunk(MapGenerator.Direction.NORTH);
        }

        if ((_player.transform.position.z - _currentChunk.transform.position.z) < _mapGenerator._chunkSize.y / -2 - _renderingDistance)
        {
            _currentChunk = _mapGenerator.GenerateChunk(MapGenerator.Direction.SOUTH);
        }

    }
}
