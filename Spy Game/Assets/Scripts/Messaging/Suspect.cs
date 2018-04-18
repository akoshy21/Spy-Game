using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suspect : MonoBehaviour {

	public static Suspect suspect;

	void Awake()
	{
		suspect = this;
	}

	public string[] responses;

	public void InitializeOptions()
	{
		GameManager.manager.suspectOptionList.Add (new Options ("Hey Gideon! How's it going?", "Hey there", "Are you doing okay?", "Doing well.", "Oh hey.", "Uh. Yeah. Sorry, it's uh.", 0, 0, -1));
		GameManager.manager.suspectOptionList.Add (new Options ("Oh. Was just thinking of you and thought I'd look you up.", "It was surprisingly hard, but I figured it out in the end. But yeah, just wanted to say hi.", "Thought it would be interesting to talk again.", "Oh. Huh. That's funny. Was thinking about you too.", "Ah. Just saying hi then?", "It would be. It's been a real long while.", 1, -1, 0));
		GameManager.manager.suspectOptionList.Add (new Options ("You're telling me that I'm a spy. I think I'd know if I were a spy.", "What can I even do for you?", "You're crazy.","You would be surprised how many spies don't know they're spies.", "Many things, but right now, your location is of particular use to us.", "I assure you, there is nothing wrong with my mental health.", 0, 0, -1));
		GameManager.manager.suspectOptionList.Add(new Options("Wait Gideon? He'd never commit a crime.", "I knew it.", "No.", "Trust me when I say he's an extremely dangerous person.", "You did? Impressive.", "Then leave.", 0, 0, -1));

		Debug.Log ("messages have been initialized.");
	}

	public void InitializeResponses()
	{
		responses = new string[10];

		responses[0] = "Been a while.... What's up? How'd you even find me - it's been years.";
		responses [1] = "How's life going? Still dating " + GameManager.manager.sigOtherName + "?";
		responses[2] = "RILEE, we need to get to the point. If you notice, there's a new contact there. That's our suspect. We need you to get in close and communicate with them."; 
		responses [3] = "Okay, so if you're still here, I'm assuming you're going to help. We need your assistance to lure him out and apprehend him.";
	}
}
