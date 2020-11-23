using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "FloatReference", menuName = "References/Create float")]
public class FloatReference : ValueProvider<float>
{
    [SerializeField] bool isConstant;
    [SerializeField] float constantValue;
    public override float Value
    {
        get
        {
            if (isConstant)
            {
                return constantValue;
            }
            return value;
        }
        set
        {
            this.value = value;
        }
    }

}
