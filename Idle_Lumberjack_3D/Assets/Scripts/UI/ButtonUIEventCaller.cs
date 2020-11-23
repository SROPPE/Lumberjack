using UnityEngine;
using UnityEngine.UI;

public class ButtonUIEventCaller : MonoBehaviour
{
    [SerializeField] GameEvent gameEvent;
    [SerializeField] Button button;
    private void OnEnable()
    {
        button.onClick.AddListener(gameEvent.Raise);
    }
    private void OnDisable()
    {
        button.onClick.RemoveListener(gameEvent.Raise);
    }
}
