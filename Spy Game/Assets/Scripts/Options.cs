using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options {

	public string optionOne;
	public string optionTwo;
	public string optionThree;

	// 1 = positive, 0 = neutral, -1 = negative
	int effectOne;
	int effectTwo;
	int effectThree;

	public Options(string one, string two, string three, int eOne, int eTwo, int eThree)
	{
		optionOne = one;
		optionTwo = two;
		optionThree = three;

		effectOne = eOne;
		effectTwo = eTwo;
		effectThree = eThree;
	}
}