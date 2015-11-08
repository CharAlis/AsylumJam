using UnityEngine;
using System.Collections;

public class ReaperBehaviour : MonoBehaviour {
	public float chaseTime = 2.1f; // Represents the time in seconds the reaper will chase the player
	public float maxSpeed = 12.0f; // The maximum speed the reaper will run/float at 
	public float acceleration = 4f; // The acceleration the reaper will have
	public float initialSpeed = 3f;
	public float beginChaseCountdown = 0.3f;

	private bool stopChase = false;
	private float currentSpeed;

	void Awake() {
		currentSpeed = initialSpeed;
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (Chase ());
	}

	IEnumerator Chase() {
		yield return new WaitForSeconds (beginChaseCountdown);
		StartCoroutine (CountDown ());
		float chaseDirection = (GameObject.FindWithTag("Player").transform.position.x > transform.position.x)? (1f):(-1f);
		transform.localScale = new Vector3(chaseDirection * transform.localScale.x, transform.localScale.y, transform.localScale.z);
		while (!stopChase) {
			transform.Translate(chaseDirection * currentSpeed * Time.deltaTime, 0, 0);
			currentSpeed = (currentSpeed + acceleration * Time.deltaTime < maxSpeed)? (currentSpeed + acceleration * Time.deltaTime):(maxSpeed);
			yield return null;
		}
		// Play Death animation
		// Wait until animation finishes
		gameObject.GetComponent<Animator> ().SetBool ("dissolve", true);
		float waitTime = 0.9f;
		while ((waitTime ) > 0) {
			transform.Translate(chaseDirection * currentSpeed * Time.deltaTime, 0, 0);
			waitTime -= Time.deltaTime;
			yield return null;
		}
		gameObject.GetComponent<Collider2D> ().enabled = false;
		Destroy (gameObject);
		yield return null;
	}

	IEnumerator CountDown() {
		yield return new WaitForSeconds(chaseTime);
		stopChase = true;

	}
}
