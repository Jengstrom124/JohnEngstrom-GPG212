using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRules : MonoBehaviour
{
    public bool newRound = false;
    public bool resetInProgress = false;

    //RESPAWN EVENT
    public delegate void RespawnSignature();
    public static event RespawnSignature RespawnEvent;

    public static void RespawnEventFunction()
    {
        RespawnEvent?.Invoke();
    }

    void OnEnable()
    {
        Goal.GoalScoredEvent += NewRound;
        Goal.OwnGoalScoredEvent += NewRound2;
    }

    //Had to create a new function here because of the parameters set in the events (ideally I would update the parameter in the first event to use the same function
    //but for showing progress I am leaving both in to show how I leart better syntax for the event)
    void NewRound(string team)
    {
        //resetInProgress = true;
        StartCoroutine(ResetAfterGoal());
    }
    void NewRound2(Team.TeamNames team)
    {
        //resetInProgress = true;
        StartCoroutine(ResetAfterGoal());
    }

    //Fire Event to reset the level
    IEnumerator ResetAfterGoal()
    {
        Debug.Log("Resetting Level...");
        resetInProgress = true;

        yield return new WaitForSeconds(3f);

        //newRound = true;
        RespawnEventFunction();
        resetInProgress = false;

        //yield return new WaitForSeconds(0.5f);

        //resetInProgress = false;
        //newRound = false;
        //SceneManager.LoadScene(1);
    }

    //Fire event to reset the level if the ball or player go out of bounds
    public IEnumerator ResetAfterDead()
    {
        Debug.Log("DEAD!! Resetting Level");
        resetInProgress = true;

        yield return new WaitForSeconds(3f);

        RespawnEventFunction();
        resetInProgress = false;
    }
}
