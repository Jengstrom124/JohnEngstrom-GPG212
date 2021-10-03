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


	//Unfortunately here is another area where I couldn't make this as modula as I wanted due to how I layed out the previous event using a string parameter
	//Ideally I would want to use a variable for the team name so it could update if the names changed
	void AnnounceGoal(string team)
	{
		if(team == "RedHomeGoal")
        {
			if (sb.blueScore <= 1)
			{
				print("ANNOUNCER: UH OH, looks like the Red team scored a home goal!! Blue team scores their first point, leaving them now at " + sb.blueScore + " point!");
			}
			else
			{
				print("ANNOUNCER: UH OH, looks like the Red team scored a home goal!! Blue team scores, leaving them now at " + sb.blueScore + " points!");
			}
        }
		else if(team == "BlueHomeGoal")
        {
			if (sb.redScore <= 1)
			{
				print("ANNOUNCER: UH OH, looks like the Blue team scored a home goal!! Red team scores their first point, leaving them now at " + sb.redScore + " point!");
			}
			else
			{
				print("ANNOUNCER: UH OH, looks like the Blue team scored a home goal!! Red team scores, leaving them now at " + sb.redScore + " points!");
			}
		}
		else if(team == "Red")
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
