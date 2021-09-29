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
    }

    void NewRound(string team)
    {
        //resetInProgress = true;
        StartCoroutine(ResetAfterGoal());
    }

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

    public IEnumerator ResetAfterDead()
    {
        Debug.Log("DEAD!! Resetting Level");
        resetInProgress = true;

        yield return new WaitForSeconds(3f);

        RespawnEventFunction();
        resetInProgress = false;
    }
}
