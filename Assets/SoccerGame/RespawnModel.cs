using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnModel : MonoBehaviour
{
    Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = this.transform.localPosition;
    }

    void OnEnable()
    {
        GameRules.RespawnEvent += Respawn;
    }

    void Respawn()
    {
        this.transform.localPosition = originalPos;
    }
}
