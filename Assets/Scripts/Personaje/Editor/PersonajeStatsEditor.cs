using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PersonajeStats))]
public class PersonajeStatsEditor : Editor
{


    public PersonajeStats StatsTarget => target as PersonajeStats;
    public override void OnInspectorGUI(){
        base.OnInspectorGUI();
        if(GUILayout.Button("Resetear Valores")){
            StatsTarget.ResetearValores();
        }

    }
}
