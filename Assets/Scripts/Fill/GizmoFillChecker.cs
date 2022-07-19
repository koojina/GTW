#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FillChecker))]
public class GizmoFillChecker : Editor
{
    private void OnSceneGUI()
    {
        FillChecker fow = (FillChecker)target;

        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.forward, Vector3.right, 360, fow.viewRadius);
    }
}
#endif