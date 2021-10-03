using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
	public Text BlueTeam;
	public Text RedTeam;

	public int blueScore;
	public int redScore;

	Text myText;
	public int currentScore;
	public bool readScore = false;

	BallManager ball;

	//Read Score Event
	public delegate void ScoreSignature(string team);
	public static event ScoreSignature ReadScoreEvent;

	public static void ReadScoreFunction(string team)
	{
		ReadScoreEvent?.Invoke(team);
	}

	void Start()
	{
		//myText = this.GetComponent<Text>();
		//currentScore = 0;
		//currentScore = PlayerPrefs.GetInt("currentScore");
		//myText.text = ("HIGHSCORE: " + highscore);

		blueScore = 0;
		redScore = 0;

		ball = FindObjectOfType<BallManager>();
	}

	void Update()
    {
		//myText.text = ("Score: " + currentScore);
		BlueTeam.text = ("Score: " + blueScore);
		RedTeam.text = ("Score: " + redScore);
	}

	void OnEnable()
	{
		Goal.GoalScoredEvent += Score;
		Goal.OwnGoalScoredEvent += TeamGoal;
	}


	void Score(string team)
	{
		if(team == "Red")
        {
			Debug.Log("Red Scores");
			redScore++;
		}
		else
        {
			Debug.Log("Blue Scores");
			blueScore++;
		}

		ReadScoreFunction(team);

		/*
		if(ball.GetComponent<Team>.myTeam == "Blue")
        {
			if(this.name == "BlueScore")
            {
				currentScore++;
			}
        }


		if (ball.GetComponent<Team>.myTeam == "Red")
		*/
		//currentScore++;
		//ReadScoreFunction();
		//PlayerPrefs.SetInt("currentScore", currentScore);
	}


	void TeamGoal(Team.TeamNames team)
    {
		if(team == Team.TeamNames.Red)
        {
			blueScore++;
			ReadScoreFunction("RedHomeGoal");
        }
		else
        {
			redScore++;
			ReadScoreFunction("BlueHomeGoal");
        }
    }
}
