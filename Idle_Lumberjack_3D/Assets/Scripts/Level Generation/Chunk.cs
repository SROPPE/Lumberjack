using System;
using UnityEngine;
using UnityEngine.UI;

//Need refactoring
public class Chunk : MonoBehaviour
{
    public int level;
    public Transform chunkEndPoint;
    public Transform chunkBasePoint;
    [SerializeField] TriggerRegion nextZoneSpawnerTrigger;
    [SerializeField] TriggerRegion replaceBaseTrigger;
    [SerializeField] GameObject transitionUIPrefab;
    [SerializeField] Transform UIParent;
    [SerializeField] IntReference currentChunkLevel;

    private LevelGenerator _levelGenerator;

    private GameObject _spawnedUI;

    private void Start()
    {
        UIParent = GameObject.FindWithTag("Canvas").transform;
        _levelGenerator = LevelGenerator.instance;
    }
    private void OnEnable()
    {
        level = currentChunkLevel.Value;
        nextZoneSpawnerTrigger.EnterZone += GenerateNextZone;
        replaceBaseTrigger.EnterZone += AskForReplaceBase;
        replaceBaseTrigger.LeaveZone += (GameObject) => { Destroy(_spawnedUI); };
    }
    private void OnDisable()
    {
        replaceBaseTrigger.EnterZone -= AskForReplaceBase;
        replaceBaseTrigger.LeaveZone -= (GameObject) => { Destroy(_spawnedUI); };
    }
    private void OnEvented(Action<GameObject> action)
    {
        nextZoneSpawnerTrigger.EnterZone -= action;
    }
    private void AskForReplaceBase(GameObject gameObject)
    {
        if (level != 1)
        {
            _spawnedUI = Instantiate(transitionUIPrefab, UIParent);
            _spawnedUI.GetComponentInChildren<Button>().onClick.AddListener(ReplaceBase);
        }

    }
    private void ReplaceBase()
    {
        _levelGenerator.ReplaceBase(chunkBasePoint.position, level);
        Destroy(_spawnedUI);
        Destroy(replaceBaseTrigger.gameObject);
        OnEvented(AskForReplaceBase);
    }


    private void GenerateNextZone(GameObject gameObject)
    {
        _levelGenerator.SpawnNextChunk(chunkEndPoint.position);
        OnEvented(GenerateNextZone);
    }

}
