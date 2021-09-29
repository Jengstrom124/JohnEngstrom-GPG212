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

    //public event Action<Team> GoalScoredEvent;

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

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            if (other.GetComponent<Team>().myTeam == Team.TeamNames.Red)
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
