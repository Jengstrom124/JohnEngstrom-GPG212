using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject Cube;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<10; i++)
        {
            //Spawn evenly across the x-axis
            Instantiate(Cube, new Vector3(i*2f, 0, 0), Quaternion.identity);
            //Instantiate(Cube, new Vector3(i * 2f, 0, 0), Quaternion.Euler(-90, 0, 0));

            //Spawn randomly
            //Instantiate(Cube, new Vector3(Random.Range(-1, 25), 0, Random.Range(0, 16)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
