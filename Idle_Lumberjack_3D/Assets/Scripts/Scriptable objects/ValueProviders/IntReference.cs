using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="IntReference",menuName ="References/Create int")]
public class IntReference : ValueProvider<int>
{
    public override int Value 
    { 
        get => value;
        set => this.value = value;
    }
}
