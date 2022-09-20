using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GeneradorAbstractoDungeon), true)]
public class RandomDungeonGeneratorEditor : Editor
{
    GeneradorAbstractoDungeon generator;

    private void Awake()
    {
        generator = (GeneradorAbstractoDungeon)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Create Dungeon")) 
        {
            generator.GenerateDungeon();
        }
    }
}
