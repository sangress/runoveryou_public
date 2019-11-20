using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForce : MonoBehaviour {
	private Rigidbody rb;

	public float speed = 1f;
	public float multiplier = 0.001f;
	public float minMultiplier = 1.5f;
	public bool isRigidbody;

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
		// rb.AddForce(Vector3.forward * speed * Time.deltaTime);
		// TODO: increase multiplier
		bool isMove = GameManager.instance.isPlay() || GameManager.instance.isEnd();
		if (GameManager.instance != null &&  isMove/* || GameManager.instance.isMenuActive()*/) {
			if (!isRigidbody) {
				if (isMove) {
					multiplierVal += multiplier;
					lastMultiplier = multiplierVal;
				} else {
					multiplierVal = 1f;
				}
				transform.Translate(Vector3.forward * speed * (Time.deltaTime * multiplierVal));
				// transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 10f), 3f * Time.deltaTime);
			} else {
				rb.AddForce(Vector3.forward * speed * Time.deltaTime);
			}
		}
	}
}
