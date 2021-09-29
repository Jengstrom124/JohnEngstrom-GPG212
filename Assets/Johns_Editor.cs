using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(JohnButton1))]

public class Johns_Editor : Editor
{
    public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		
		if(GUILayout.Button("Change Size"))
		{
			(target as JohnButton1)?.ChangeSize();
		}

		if (GUILayout.Button("Change Colour"))
		{
			(target as JohnButton1)?.ChangeColour();
		}
	}
}
