﻿using UnityEngine;
using System.Collections;
using UnityEditor;

public class EditorMovement : EditorWindow 
{

    //Bezier Curve Variables
    static bool bezierCurve = false;
    static Vector3 curveStart = Vector3.zero, curveEnd = Vector3.zero;
    static Vector3 tanStart = Vector3.zero, tanEnd = Vector3.zero;
    static Color drawColor = Color.white;
    static Texture2D drawTexture = Texture2D.whiteTexture;
    static float width = 0;

    //Straight Line Variables

    //Look Chain Variables

    //Look Return Variables

    //Menu Items
    [MenuItem("Tools/Movement Node Creator")]

    static void Init()
    {
        EditorMovement window = (EditorMovement)EditorWindow.GetWindow(typeof(EditorMovement));
    }

    void OnGUI()
    {
        //testing
        bezierCurve = true;

        if (bezierCurve == true)
        {
            EditorGUILayout.LabelField("Bezier Curve: ");
            EditorGUILayout.Separator();

            //Position Modifiers
            EditorGUILayout.BeginVertical();
            EditorGUILayout.Vector3Field("Start Position", curveStart);
            EditorGUILayout.Vector3Field("End Position", curveEnd);
            EditorGUILayout.EndVertical();

            EditorGUILayout.Separator();

            //Tangent Modifiers
            EditorGUILayout.BeginVertical();
            EditorGUILayout.Vector3Field("Tangent Start Position", tanStart);
            EditorGUILayout.Vector3Field("Tangent End Position", tanEnd);
            EditorGUILayout.EndVertical();

            EditorGUILayout.Separator();

            //Appearance Modifiers
            EditorGUILayout.BeginVertical();
            EditorGUILayout.ColorField("Draw Color", drawColor);
            drawTexture = Texture2D.whiteTexture;
            EditorGUILayout.FloatField("Width", width);
            EditorGUILayout.EndVertical();

            if(GUILayout.Button("Create"))
            {
                //Handles.DrawBezier(curveStart, curveEnd, tanStart, tanEnd, drawColor, drawTexture, width);
            }
        }
    }
}
