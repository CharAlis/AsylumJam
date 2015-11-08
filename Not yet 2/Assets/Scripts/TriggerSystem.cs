using UnityEngine;
using System.Collections;

public class TriggerSystem : MonoBehaviour {


	public enum TriggerEffects
	{
		ChangeScene,
		ChangePartOfScreen,
		PopPrompt,
		TextBubble,
		Stalker
	}

	public TriggerEffects triggerEffect;
	[Range(-1,1)] public int direction = 1;
	public int sceneToChangeTo;
	public string message;
	public float seconds;
	private new Collider2D collider;

	void Awake()
	{
		collider = GetComponent<Collider2D>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			switch (triggerEffect)
			{
				case TriggerEffects.ChangeScene:
					break;
				case TriggerEffects.ChangePartOfScreen:
					col.transform.Translate(Vector3.right * direction * 1);
					CameraScript.Instance.MoveCamera(direction);
					break;
				case TriggerEffects.Stalker:
					break;
				case TriggerEffects.PopPrompt:
					PromptSystem.Instance.PopPrompt(message,seconds);
					collider.enabled = false;
					break;
				case TriggerEffects.TextBubble:
					BubbleScript.Instance.ChangeBubble(message, seconds);
					collider.enabled = false;
					break;
				default:
					break;
			}
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "Player")
		{	if (triggerEffect == TriggerEffects.ChangeScene)
			{
				if (Input.GetKeyDown(KeyCode.W)) Application.LoadLevel(sceneToChangeTo);
			}
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Player" && triggerEffect == TriggerEffects.ChangePartOfScreen)
		{
			direction *= -1;
		}
	}



}
