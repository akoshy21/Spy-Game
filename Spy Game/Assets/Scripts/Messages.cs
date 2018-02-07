using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Messages {

	public string senderName;
	public string message;

	public Text senderPrefab;
	public Text messagePrefab;
	public Image msgBoxPrefab;
	public bool isPlayer = false;
	public Color boxColor;

	public Vector2 boxPos;

	private Color npcColor = new Color(0.5f, 0.5f, 0.5f);
	private Color playerColor = new Color (1, 1, 1);

	private GameObject windowBG = GameObject.FindWithTag ("windowbg");

	public Messages(string sndrName, string msg, Text sndrText, Text msgText, Image msgBox, bool isPlayer)
	{
		if (isPlayer == true) {
			boxColor = playerColor;
		}
		else
		{
			boxColor = npcColor;
		}

		senderName = sndrName;
		message = msg;

		sndrText.text = senderName;
		msgText.text = message;
		msgBox.color = boxColor;

		Object.Instantiate (msgBox, windowBG.transform);

		boxPos.x = windowBG.transform.position.x;
		boxPos.y = windowBG.transform.position.y;

	}
}
