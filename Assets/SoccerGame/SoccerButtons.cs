using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerButtons : MonoBehaviour
{
	public void ScoreBlueGoal()
	{
		Goal.GoalScoredFunction("Blue");
	}

	public void ScoreRedGoal()
	{
		Goal.GoalScoredFunction("Red");
	}
}
