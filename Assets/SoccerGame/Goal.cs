using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool scoreTest = false;
    Team goalTeam;

    void Start()
    {
        goalTeam = this.GetComponent<Team>();
    }

    //Goal Scored Event
    public delegate void GoalSignature(string team);
    public static event GoalSignature GoalScoredEvent;

    //Test Button
    public static void GoalScoredFunction(string team)
    {
        if(team == "Red")
        {
            GoalScoredEvent?.Invoke("Red");
        }
        else
        {
            GoalScoredEvent?.Invoke("Blue");
        }
    }


    //Own Goal Event
    public delegate void OwnGoalSignature(Team.TeamNames myTeam);
    public static event OwnGoalSignature OwnGoalScoredEvent;


    //Call Event When Ball Passes Through Goal
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            if (other.GetComponent<Team>().myTeam == goalTeam.myTeam)
            {
                OwnGoalScoredEvent?.Invoke(goalTeam.myTeam);
            }
            else if (other.GetComponent<Team>().myTeam == Team.TeamNames.Red)
            {
                GoalScoredEvent?.Invoke("Red");
            }
            else
            {
                GoalScoredEvent?.Invoke("Blue");
            }
        }
    }

    /*
    void TestGoalScored()
    {
        if(scoreTest)
        {
            GoalScored?.Invoke();
            scoreTest = false;
        }
    }
    */
}
