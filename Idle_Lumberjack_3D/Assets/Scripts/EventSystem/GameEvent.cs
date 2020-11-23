using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Events",menuName = "Events/Create new")]
public class GameEvent : ScriptableObject
{
    [SerializeField]List<GameEventObserver> observers = new List<GameEventObserver>();
    
    public void Raise()
    {       
        for (int i = observers.Count-1; i >= 0; i--)
        {
            observers[i].OnRaised();
        }
    }
    public void AddListener(GameEventObserver observer)
    {       
            observers.Add(observer);  
    }
    public void RemoveListener(GameEventObserver observer)
    {
            observers.Remove(observer);        
    }
}
