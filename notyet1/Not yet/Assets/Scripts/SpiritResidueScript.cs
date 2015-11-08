using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class SpiritResidueScript : MonoBehaviour {

	private PlatformerCharacter2D player;
	private Scrollbar scrollbar;

	void Awake()
	{
		player = GameObject.Find("Player").GetComponent<PlatformerCharacter2D>();
		scrollbar = GetComponent<Scrollbar>();
	}
	
	void Update () {
		scrollbar.size = player.spiritResidue / 100;
	}
}
