using Lumberjack.Control;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Teleport : MonoBehaviour
{
    [SerializeField] GameEvent teleportation; 
    [SerializeField] private LoadScreen loadScreen;

    [Header("Load screen")]
    [SerializeField] private float loadScreenDuration = 1f;
    [SerializeField] private float timeIn = 0.2f;
    [SerializeField] private float timeOut = 0.2f;
    
    public void StartTeleportation()
    {
        StartCoroutine(TeleportProcess());
    }

    private IEnumerator TeleportProcess()
    {
        if (loadScreen != null)
        {
            yield return loadScreen.Show(timeIn);

            teleportation.Raise();
            yield return new WaitForSeconds(loadScreenDuration);

            yield return loadScreen.Hide(timeOut);
        }
            yield break;
    }
}
