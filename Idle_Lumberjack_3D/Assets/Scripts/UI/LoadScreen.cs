using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class LoadScreen : MonoBehaviour
{

    CanvasGroup canvasGroup;
    Coroutine currentRoutine;
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        DontDestroyOnLoad(this);
    }
    public void ShowImmediate()
    {
        canvasGroup.alpha = 1;
    }
    public IEnumerator Show(float time)
    {
        return Load(time, 1);
    }
    public IEnumerator Hide(float time)
    {
        return Load(time, 0);
    }
    private IEnumerator Load(float time, float to)
    {
        if (currentRoutine != null)
        {
            StopCoroutine(currentRoutine);
        }
        currentRoutine = StartCoroutine(LoadRoutine(time, to));
        yield return currentRoutine;
    }
    private IEnumerator LoadRoutine(float time, float to)
    {
        while (!Mathf.Approximately(canvasGroup.alpha, to))
        {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, to, Time.deltaTime / time);
            yield return null;
        }
    }
}
