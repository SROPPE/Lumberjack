using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class ChunkFiller : MonoBehaviour
{
    [System.Serializable]
    public class SpawningObjectConfig
    {
        public BoxCollider bounds;
        public GameObject spawningPrefab;
        public int spawnAmount;
        public int currentLevelOffset;
    }
    public List<SpawningObjectConfig> zoneBounds;
  

    [Header("Randomization parameters")]
    [SerializeField][Range(0.5f, 1.5f)] float randomSizeUpperBound;
    [SerializeField][Range(0.5f, 1.5f)] float randomSizeLowerBound;
    [SerializeField] Vector3 randomRotationUpperBound;
    private void OnGUI()
    {
      
        if(GUILayout.Button("Fill"))
        {
            SpawnObjectsInZone();
        }
    }
    public void SpawnObjectsInZone()
    {
        foreach (var bounds in zoneBounds)
        {
            Spawn(bounds);
        }
    }
    void Spawn(SpawningObjectConfig objectConfig)
    {
        int i = 0;
      
        while (i < objectConfig.spawnAmount)
        {
            
            i++;
            GameObject obj = Instantiate(objectConfig.spawningPrefab, Vector3.zero, Quaternion.Euler(0f,Random.Range(0f,180f),0f), objectConfig.bounds.transform);
            
            float x_dim;
            float z_dim;
            x_dim = objectConfig.bounds.size.x/2;
            z_dim = objectConfig.bounds.size.z/2;
            var x_rand = Random.Range(-x_dim, x_dim);
            var z_rand = Random.Range(-z_dim, z_dim);
      
            obj.transform.localPosition = new Vector3(x_rand, 0, z_rand);
            obj.GetComponent<Tree>().levelOffset = objectConfig.currentLevelOffset;
        
            Vector3 randomSize = new Vector3(Random.Range(randomSizeLowerBound, randomSizeUpperBound),
               Random.Range(randomSizeLowerBound, randomSizeUpperBound),
               Random.Range(randomSizeLowerBound, randomSizeUpperBound));
            Vector3 randomRotation = new Vector3(Random.Range(0f, randomRotationUpperBound.x),
                Random.Range(0f, randomRotationUpperBound.y),
                Random.Range(0f, randomRotationUpperBound.z));
            obj.transform.localScale = randomSize;
            obj.transform.localRotation =Quaternion.Euler(randomRotation);

     
        }
    
    }
}
