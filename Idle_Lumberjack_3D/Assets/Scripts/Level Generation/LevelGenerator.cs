using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] ChunksReference chunksPrefabs;
    [SerializeField] ChunksReference spawnedChunks;

    public GameObject playerBase;
    public IntReference currentChunkLevel;
    public static LevelGenerator instance;
    private void Awake()
    {
        currentChunkLevel.Value = 0;
        instance = this;
    }

    private void Start()
    {
        
        spawnedChunks.items.Clear();
        SpawnNextChunk(Vector3.zero);

    }
    public void SpawnNextChunk(Vector3 position)
    {
        currentChunkLevel.Value++;
        int randomChunkIndex = Random.Range(0, chunksPrefabs.items.Count);
        
        var spawnedChunk = Instantiate(chunksPrefabs.items[randomChunkIndex],position,Quaternion.identity,null);
        spawnedChunks.Add(spawnedChunk);
    }
    public void ReplaceBase(Vector3 position,int level)
    {
        var chunks = spawnedChunks.items;
        for (int i = 0; i < chunks.Count; i++)
        {      
            if (chunks[i].level < level)
            {
                Destroy(chunks[i].gameObject);
                spawnedChunks.items.RemoveAt(i);
            }
        }
        playerBase.transform.position = position;
    }
}
