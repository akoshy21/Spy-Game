﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options {

	public string optionOne;
	public string optionTwo;
	public string optionThree;

	// 1 = positive, 0 = neutral, -1 = negative
	public int effectOne;
	public int effectTwo;
	public int effectThree;

	public string responseOne;
	public string responseTwo;
	public string responseThree;

	public int optionSelected;

	public int replies;

	public Options(string one, string two, string three, string repOne, string repTwo, string repThree, int eOne, int eTwo, int eThree, int r = 2, bool p = false)
	{
		optionOne = one;
		optionTwo = two;
		optionThree = three;

		responseOne = repOne;
		responseTwo = repTwo;
		responseThree = repThree;

		effectOne = eOne;
		effectTwo = eTwo;
		effectThree = eThree;

		replies = r;

		if (GameManager.manager.checkIfLoaded ("Messenger")) {
			GameManager.manager.handlerPause = p;
		}
		else if (GameManager.manager.checkIfLoaded ("Suspect")) {
			GameManager.manager.suspectPause = p;
		}
	}
}