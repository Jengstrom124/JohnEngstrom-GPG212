using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SoccerButtons))]

public class Soccer_Editor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		if(GUILayout.Button("Score Blue Goal Test"))
		{
			(target as SoccerButtons)?.ScoreBlueGoal();
		}

		if (GUILayout.Button("Score Red Goal Test"))
		{
			(target as SoccerButtons)?.ScoreRedGoal();
		}
	}
}
