using UnityEngine;
using System.Collections;

public class StalkerSpawnActivator : MonoBehaviour {

	public GameObject reaper;

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			SpawnStalker (new Vector3(transform.position.x + ((GameObject.FindWithTag("Player").transform.position.x > transform.position.x)? (1f):(-1f)) , 0 , transform.position.z));
			GetComponent<Collider2D>().enabled = false;
		}
	}

	void SpawnStalker(Vector3 pos) {
		Instantiate (reaper, pos, new Quaternion(0,0,0,0));
	}
}
