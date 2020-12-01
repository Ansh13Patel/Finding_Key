using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class Game_ManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Player_Data data = new Player_Data(Player.player);
        GameManager gm = (GameManager)target;

        if (GUILayout.Button("Reset Level"))
        {
            data.setlevelunlock(1);
        }
    }
}
