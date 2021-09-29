using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour
{
	ParticleSystem myParticle;

	void Start()
	{
		myParticle = this.GetComponentInChildren<ParticleSystem>();
	}

	//when event is triggered Eruption() function will be subscribed to BridgeRiseEvent
	void OnEnable()
	{
		Goal.GoalScoredEvent += PlayFireworks;
	}

	//Function to play the particle animation
	void PlayFireworks(string team)
	{
		myParticle.Play();
		//EventManager.BridgeRiseEvent -= Eruption;
	}
}
