using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: make generic
public class PlayVFXOnCollide : MonoBehaviour {
	public string vfxName;
	public Vector3 offset = new Vector3(6f, 0f, 10f);

	void onCollide(string tag) {
		if (tag == "Player" && GameManager.instance.isPlay()) {
			GameObject go = ObjectsPool.instance.get(vfxName, 2f);
			if (go != null) {
				go.transform.position = new Vector3(transform.position.x + offset.x, transform.position.y, transform.position.z + offset.z);
			}
		}
	}

	void OnTriggerEnter(Collider col) {
		onCollide(col.tag);
	}

	void OnCollisionEnter(Collision col) {
		onCollide(col.transform.tag);
	}
}
