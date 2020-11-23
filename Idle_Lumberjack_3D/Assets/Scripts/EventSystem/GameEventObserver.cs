﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventObserver : MonoBehaviour
{
    [SerializeField] GameEvent GameEvent;
    public UnityEvent Response;
    private void OnEnable()
    {
        GameEvent.AddListener(this);
    }
    private void OnDisable()
    {
        GameEvent.RemoveListener(this);
    }
    public void OnRaised()
    {
        Response?.Invoke();
    }
}
