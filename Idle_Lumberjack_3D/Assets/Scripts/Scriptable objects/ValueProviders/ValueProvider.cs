using UnityEngine;

public abstract class ValueProvider<T> : ScriptableObject
{
    [SerializeField] protected T value;
    public abstract T Value { get; set; }
}
