using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BubbleScript : MonoBehaviour {

	private Text text;
	public static BubbleScript Instance;

	void Awake()
	{
		Instance = this;
		text = GameObject.Find("BubbleText").GetComponent<Text>();
	}

	public void ChangeBubble(string message, float secs)
	{
		text.text = message;
		StartCoroutine(ResetMessage(secs));
	}

	IEnumerator ResetMessage(float secs)
	{
		yield return new WaitForSeconds(secs);
		text.text = "";
	}


	
}
