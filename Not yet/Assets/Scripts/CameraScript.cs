using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public static CameraScript Instance;
	void Awake()
	{
		Instance = this;
	}

	public void MoveCamera(int direction)
	{
		Camera.main.transform.Translate(Vector3.right * direction * 14.5f);
	}
}
