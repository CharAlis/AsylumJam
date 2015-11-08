using UnityEngine;
using System.Collections;

public class FogMovement : MonoBehaviour {
	public float waitUntilTriggerActivation = 30f;
	public float movementSpeed = 0.05f;
	public float multiplier = 1f;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
		StartCoroutine (ColliderActivation (waitUntilTriggerActivation));
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (multiplier* movementSpeed * Time.deltaTime, 0, 0);
	}

	IEnumerator ColliderActivation(float seconds = 0f) {
		yield return new WaitForSeconds(seconds);
		gameObject.GetComponent<BoxCollider2D>().enabled = true;

	}
}
