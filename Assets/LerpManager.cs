using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpManager : MonoBehaviour
{
    public float height = 0;
    public int target;
    public float speed;
    float moveChance;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveCube());
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.Space))
        //{

        //}

        float lerp = Mathf.Lerp(transform.position.y, target, speed);
        transform.position = new Vector3(transform.position.x, lerp, 0);
    }

    /*
    void FixedUpdate()
    {
        if(Random.Range(0,100) == 0)
        {
            target = Random.Range(-3, 3);
            speed = Random.Range(0.001f, 0.05f);
        }
    }
    */

    IEnumerator MoveCube()
    {
        target = Random.Range(-3, 3);
        speed = Random.Range(0.001f, 0.05f);

        yield return new WaitForSeconds(1.5f);

        StartCoroutine(MoveCube());
    }

}
