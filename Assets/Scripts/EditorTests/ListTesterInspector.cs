#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(ListTester))]
public class ListTesterInspector : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorList.Show(serializedObject.FindProperty("integers"),EditorListOption.ListSize);
        EditorList.Show(serializedObject.FindProperty("vectors"));
        EditorList.Show(serializedObject.FindProperty("colorPoints"),EditorListOption.None);
        EditorList.Show(serializedObject.FindProperty("objects"),EditorListOption.ListLabel);
        serializedObject.ApplyModifiedProperties();
    }
}
#endif
