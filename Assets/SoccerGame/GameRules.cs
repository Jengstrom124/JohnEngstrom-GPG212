using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameRules : MonoBehaviour
{
    public bool newRound = false;
    public bool resetInProgress = false;

    public GameObject gameUI;
    Text[] onScreenText;

    private void Start()
    {
        //Store the 2 Text components in an array
        onScreenText = gameUI.GetComponentsInChildren<Text>();
    }

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
        StartCoroutine(ResetAfterGoal(team));
    }
    void NewRound2(Team.TeamNames team)
    {
        //resetInProgress = true;
        StartCoroutine(ResetAfterHomeGoal(team));
    }

    //Fire Event to reset the level
    IEnumerator ResetAfterGoal(string team)
    {
        //Debug.Log("Resetting Level...");
        resetInProgress = true;

        if(team == "Red")
        {
            onScreenText[0].text = (team + " TEAM SCORED");
            onScreenText[1].text = ("YOU SCORED!!");
        }
        else
        {
            onScreenText[1].text = (team + " TEAM SCORED");
            onScreenText[0].text = ("YOU SCORED!!");
        }

        gameUI.SetActive(true);

        yield return new WaitForSeconds(3f);

        //newRound = true;
        RespawnEventFunction();
        resetInProgress = false;
        gameUI.SetActive(false);

        //yield return new WaitForSeconds(0.5f);

        //resetInProgress = false;
        //newRound = false;
        //SceneManager.LoadScene(1);
    }

    IEnumerator ResetAfterHomeGoal(Team.TeamNames team)
    {
        //Debug.Log("Resetting Level...");
        resetInProgress = true;

        if (team == Team.TeamNames.Red)
        {
            onScreenText[0].text = (team + " TEAM SCORED A HOME GOAL");
            onScreenText[1].text = ("OWN GOAL SCORED");
        }
        else
        {
            onScreenText[1].text = (team + " TEAM SCORED A HOME GOAL");
            onScreenText[0].text = ("OWN GOAL SCORED");
        }

        gameUI.SetActive(true);

        yield return new WaitForSeconds(3f);

        //newRound = true;
        RespawnEventFunction();
        resetInProgress = false;
        gameUI.SetActive(false);

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

        onScreenText[1].text = ("OUT OF BOUNDS");
        onScreenText[0].text = ("OUT OF BOUNDS");

        gameUI.SetActive(true);

        yield return new WaitForSeconds(3f);

        RespawnEventFunction();
        resetInProgress = false;
        gameUI.SetActive(false);
    }
}
