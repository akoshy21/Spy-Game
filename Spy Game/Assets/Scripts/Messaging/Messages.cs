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

	private GameObject windowBG = GameObject.FindWithTag ("windowbg");

	public Messages(string sndrName, string msg, Text sndrText, Text msgText, Image msgBox, bool player)
	{
		isPlayer = player;

		senderName = sndrName;
		message = msg;

		sndrText.text = senderName;
		msgText.text = message;

		Object.Instantiate (msgBox, windowBG.transform);
	
	}
}
