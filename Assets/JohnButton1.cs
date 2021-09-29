using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnButton1 : MonoBehaviour
{
    public void ChangeSize()
	{
		//Debug.Log("Test");
		transform.localScale = new Vector3 (2,2,2);
	}

	public void ChangeColour()
    {
		Debug.Log("Change Colour");
    }
}
