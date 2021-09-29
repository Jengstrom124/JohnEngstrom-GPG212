using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Announcer : MonoBehaviour
{
	ScoreBoard sb;

	void Start()
    {
		sb = FindObjectOfType<ScoreBoard>();
	}
	//event subscribe
	void OnEnable()
	{
		ScoreBoard.ReadScoreEvent += AnnounceGoal;
	}

	public void AnnounceGoal(string team)
	{
		if(team == "Red")
        {
			if(sb.redScore <= 1)
            {
				print("ANNOUNCER: The " + team + " team scores their first point of the game!! They now have " + sb.redScore + " point!");

			}
			else
            {
				print("ANNOUNCER: THE " + team + " TEAM SCORED AGAIN! They now have " + sb.redScore + " points!");
			}
        }
		else
        {
			if (sb.blueScore <= 1)
			{
				print("ANNOUNCER: The " + team + " team scores their first point of the game!! They now have " + sb.blueScore + " point!");

			}
			else
			{
				print("ANNOUNCER: THE " + team + " TEAM SCORED AGAIN! They now have " + sb.blueScore + " points!");
			}
		}

		/*
		if (sb.currentScore <= 1)
		{
			print("Anouncer: THEY SCORED THIER FIRST GOAL OF THE GAME! They now have " + sb.currentScore + " point!");
		}
		else
		{
			print("Anouncer: THEY SCORED AGAIN! They now have " + sb.currentScore + " points!");
		}
		*/
	}
}
