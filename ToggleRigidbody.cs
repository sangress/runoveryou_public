using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRigidbody : MonoBehaviour {
	public Rigidbody[] rbs;
	public Transform hips;
	[Header("Debug")]
	public bool isRigidbody;

	private Animator anim;

	void Start() {
		anim = GetComponent<Animator>();
		for (int i = 0; i < rbs.Length; i++) {
			rbs[i].isKinematic = true;
			// rbs[i].collisionDetectionMode = CollisionDetectionMode.Continuous;
		}
	}

	void FixedUpdate() {
		if (isRigidbody) {
			if (anim != null) {
				anim.enabled = false;
			}
			for (int i = 0; i < rbs.Length; i++) {
				rbs[i].isKinematic = false;
			}
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player" || col.tag == "RoadEnd" || col.tag == "EndGame" || col.tag.Contains("wall")) {
			if (anim != null) {
				anim.enabled = false;
			}
			for (int i = 0; i < rbs.Length; i++) {
				rbs[i].collisionDetectionMode = CollisionDetectionMode.Continuous;
				rbs[i].isKinematic = false;
			}
			// TODO: FIXME: reset when using pool!
			// isRigidbody = true;
		}
	}
}
