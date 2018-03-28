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

	public Sprite icon;

	private GameObject windowBG = GameObject.FindWithTag ("windowbg");

	public Messages(string sndrName, string msg, Text sndrText, Text msgText, Image msgBox, bool player)
	{
		isPlayer = player;

		senderName = sndrName;
		message = msg;

		sndrText.text = senderName;
		msgText.text = message;
		if (player != true) {
			if (GameManager.manager.reinit == false) {
				AudioClip beep = GameManager.manager.msgSound;
				GameManager.manager.GetComponent<AudioSource> ().PlayOneShot (beep, 0.4F);
			}
			if (GameManager.manager.checkIfLoaded ("Messenger") == true) {
				sndrText.color = GameManager.manager.handlerColor;

				msgBox.transform.GetChild (2).GetComponent<Image> ().sprite = GameManager.manager.handlerIcon;

			} else if (GameManager.manager.checkIfLoaded ("Suspect") == true) {
				sndrText.color = GameManager.manager.suspectColor;

				msgBox.transform.GetChild (2).GetComponent<Image> ().sprite = GameManager.manager.suspectIcon;
			}

			icon = msgBox.transform.GetChild (2).GetComponent<Image> ().sprite;
		} 
		else {
			msgBox.transform.GetChild (2).GetComponent<Image> ().sprite = GameManager.manager.playerIcon;
			icon = msgBox.transform.GetChild (2).GetComponent<Image> ().sprite;

			sndrText.color = new Color (0.31f,0.31f,0.31f);
		}
			
		Object.Instantiate (msgBox, windowBG.transform);
	
	}
}
