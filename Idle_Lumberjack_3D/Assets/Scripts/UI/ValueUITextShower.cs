using UnityEngine;
using UnityEngine.UI;

public class ValueUITextShower : MonoBehaviour
{
    [SerializeField] Text textBox;
    [SerializeField] FloatReference value;

    private void Start()
    {
        OnValueUpdated();
    }
    public void OnValueUpdated()
    {
        textBox.text = value.Value.ToString();
    }
}
