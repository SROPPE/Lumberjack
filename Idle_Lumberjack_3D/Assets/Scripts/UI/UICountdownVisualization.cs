using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class UICountdownVisualization : MonoBehaviour
{
    [SerializeField] private Image _sliderOfRemainingTime;
    [SerializeField] private Text _remainingTimeText;

    private float _remainingDuration;
    private float _maxDuration;


    public event Action<string> CountdownIsOver;
    public void AddRemainingDuration(float duration)
    {
        _remainingDuration += duration;
    }


    public IEnumerator StartCountdown(float duration, string text)
    {
        SetStartingValues(duration);

        while (_remainingDuration > 0)
        {
            UpdateUI(text);

            ChangeCounter();

            yield return null;
        }

        CountdownIsOver?.Invoke(text);
        Destroy(gameObject);
        yield break;
    }
    private void SetStartingValues(float duration)
    {
        _remainingDuration = duration;
        _maxDuration = duration;

    }
    private void UpdateUI(string text)
    {
        var normalized = Mathf.Clamp(_remainingDuration / _maxDuration, 0f, 1f);
        _sliderOfRemainingTime.rectTransform.localScale = new Vector3(normalized, 1f, 0f);

        _remainingTimeText.text = $"{text} {(int)_remainingDuration}";
    }

    private void ChangeCounter()
    {
        _remainingDuration -= Time.deltaTime;
    }
}
