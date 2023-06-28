using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
[CustomEditor(typeof(Waypoint))]
public class WaypointEditor : Editor
{
    Waypoint WaypointTarget => target as Waypoint;
    private void OnSceneGUI() {
        Handles.color= Color.red;
        if(WaypointTarget.Puntos==null){
            return;
        }
        for (int i = 0; i < WaypointTarget.Puntos.Length; i++)
        {
            EditorGUI.BeginChangeCheck();
            //Crear Handle
            Vector3 puntoActual =WaypointTarget.PosicionActual + WaypointTarget.Puntos[i];
            Vector3 nuevoPunto = Handles.FreeMoveHandle(puntoActual,Quaternion.identity,0.7f, new Vector3(0.3f,0.3f, 0.3f), Handles.SphereHandleCap);
            //Crear Texto
            GUIStyle texto = new GUIStyle();
            texto.fontStyle = FontStyle.Bold;
            texto.fontSize= 16;
            texto.normal.textColor= Color.black;
            Vector3 alineamiento= Vector3.down * 0.3f + Vector3.right * 0.3f;
            Handles.Label(WaypointTarget.PosicionActual + WaypointTarget.Puntos[i]+ alineamiento, $"{i+1}",texto);
            if(EditorGUI.EndChangeCheck()){
                Undo.RecordObject(WaypointTarget,  "Free Move Handle");
                WaypointTarget.Puntos[i] = nuevoPunto - WaypointTarget.PosicionActual;
            }
        }
    }

}
