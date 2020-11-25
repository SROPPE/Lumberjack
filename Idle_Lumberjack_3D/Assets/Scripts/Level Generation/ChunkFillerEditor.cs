using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(ChunkFiller))]
public class ChunkFillerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ChunkFiller chunkFiller = (ChunkFiller)target;

        if(GUILayout.Button("Fill chunk"))
        {
            chunkFiller.SpawnObjectsInZone();
        }
    }
}
