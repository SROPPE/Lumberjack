using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Destruction :ScriptableObject
{
    public abstract IEnumerator DestructionSequenceCorutine(MonoBehaviour runner,float destructionAmount);
}
