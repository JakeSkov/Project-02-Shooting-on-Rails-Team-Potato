using UnityEngine;
using System.Collections;
using UnityEditor;

public enum MovementType
{ 
    BEZIERCURVE,
    STRAIGHTLINE,
    LOOKRETURN,
    LOOKCHAIN
}

[CustomEditor(typeof(ScriptMovementMasterClass))]
public class ScriptMovementMasterClass : Editor 
{
    public GameObject[] waypoints;
    int waypointNum = 0;

    Transform startPos;
    Transform endPos;

    public GameObject playerObj;

    bool bezier;
    bool straight;
    bool lReturn;
    bool lChain;

    public override void OnInspectorGUI()
    {

        GUILayout.Label("Movement Types");
        //Straight Line
        straight = EditorGUILayout.Foldout(straight, "Straight Line");
        if(straight)
        {
            EditorGUILayout.BeginVertical();
            startPos = EditorGUILayout.ObjectField("Start Postiton", startPos, );
            endPos = EditorGUILayout.ObjectField("End Postion", endPos, );
            EditorGUILayout.EndVertical();
        }

        //Bezier Curve
        bezier = EditorGUILayout.Foldout(bezier ,"Bezier Curve");
        if (bezier)
        {
            EditorGUILayout.BeginVertical();
            startPos = EditorGUILayout.ObjectField("Start Postiton", startPos, );
            endPos = EditorGUILayout.ObjectField("End Postion", endPos, );
            EditorGUILayout.EndVertical();
        }

        //Look Return
        lReturn = EditorGUILayout.Foldout(lReturn, "Look Return");
        if (lReturn)
        {
            EditorGUILayout.BeginVertical();
            startPos = EditorGUILayout.ObjectField("Start Postiton", startPos, );
            endPos = EditorGUILayout.ObjectField("End Postion", endPos, );
            EditorGUILayout.EndVertical();
        }

        //Look Chain
        lChain = EditorGUILayout.Foldout(lChain, "Look Chain");
        if (lChain)
        {
            EditorGUILayout.BeginVertical();
            startPos = EditorGUILayout.ObjectField("Start Postiton", startPos, );
            endPos = EditorGUILayout.ObjectField("End Postion", endPos, );
            EditorGUILayout.EndVertical();
        }
    }

    public void OnDrawGizmos()
    {
        foreach (GameObject wp in waypoints)
        {
            switch (wp.type)
            { 
                case MovementType.STRAIGHTLINE:
                    Gizmos.DrawLine(startPos, endPos);
                    break;

                case MovementType.BEZIERCURVE:
                    Gizmos.color = Color.green;
                    Vector3 lineStarting = GetPoint();
                    for(int i = 1; i<= 1; i++)
                    {
                        Vector3 lineEnd = GetPoint(startPos, endPos, wp.bezierCurve.position, i/10f);
                        Gizmos.DrawLine(lineStarting, lineEnd);
                        lineStarting = lineEnd;
                    }
                    break;

                case MovementType.LOOKRETURN:
                    break;

                case MovementType.LOOKCHAIN:
                    break;
            }
        }
    }

    public Vector3 GetPoint(Vector3 start, Vector3 end, Vector3 curve, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return oneMinusT * oneMinusT * start + 2f * oneMinusT * t * curve + t * t * end;
    }
}
