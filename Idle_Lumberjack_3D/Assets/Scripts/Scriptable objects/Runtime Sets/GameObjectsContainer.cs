using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GameObjectsContainer", menuName = "Runtimeset/Create GameObjectsContainer")]
public class GameObjectsContainer : RuntimeSet<GameObject>
{
    public List<GameObject> Items
    {
        get
        {
            for (int i = 0; i < items.Count; i++)
            {

                if (items[i] == null)
                {
                    items.RemoveAt(i);
                }
            }
            return items;
        }
        
    }
}
