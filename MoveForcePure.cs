using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForcePure : MonoBehaviour {
	private Rigidbody rb;

	public float speed = 1f;
	public float multiplier = 0.001f;
	public float minMultiplier = 1.5f;

	private float multiplierVal = 0f;
	private float lastMultiplier = 0f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		multiplierVal = minMultiplier;
	}

	public void brakeSpeed() {
		multiplierVal = minMultiplier;
	}
	public void releaseBrakeSpeed() {
		multiplierVal = lastMultiplier;
	}

	// Update is called once per frame
	void FixedUpdate () {
		multiplierVal += multiplier;
		lastMultiplier = multiplierVal;
		transform.Translate(Vector3.forward * speed * (Time.deltaTime * multiplierVal));
	}
}
