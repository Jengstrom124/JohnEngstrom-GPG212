using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectators : MonoBehaviour
{
	bool crowdJump = false;
	public GameObject spectator;

	Vector3 originalPos;

	void Start()
    {
		originalPos = spectator.transform.position;
    }

	void Update()
    {
		if (crowdJump)
		{
			spectator.transform.localPosition = new Vector3(originalPos.x, Mathf.Sin(Time.time), originalPos.z);
		}
		else
        {
			spectator.transform.localPosition = originalPos;
        }
	}

	//event subscribe
	void OnEnable()
	{
		Goal.GoalScoredEvent += CrowdCheer;
		Goal.OwnGoalScoredEvent += HomeGoalReaction;
	}

	void CrowdCheer(string team)
	{
		if(team == "Red")
        {
			print("RED CROWD: WOOHOO!");
			print("BLUE CROWD: BOOOO!!");
		}
		else
        {
			print("BLUE CROWD: WOOHOO!");
			print("RED CROWD: BOOOO!!");
		}
		StartCoroutine(CrowdJumping());
	}

	IEnumerator CrowdJumping()
    {
		crowdJump = true;

		yield return new WaitForSeconds(2f);

		crowdJump = false;
    }

	void HomeGoalReaction(Team.TeamNames team)
    {
		if(team == Team.TeamNames.Red)
        {
			print("RED CROWD: ....");
			print("BLUE CROWD: HAHA! WOOHOO");
		}
		else
        {
			print("BLUE CROWD: ....");
			print("RED CROWD: HAHA! WOOHOO");
		}
    }
}
