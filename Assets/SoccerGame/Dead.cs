using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    GameRules gr;

    void Start()
    {
        gr = FindObjectOfType<GameRules>();
    }

    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Ball" || other.gameObject.tag == "Player") && !gr.resetInProgress)
        {
            //gr.resetInProgress = true;
            StartCoroutine(gr.ResetAfterDead());
            //Invoke("Reset", 1f);
        }
    }



    /*
    void Reset()
    {
        gr.resetInProgress = false;
    }
    */
}
