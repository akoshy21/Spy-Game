using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour {

	public static Handler handler;

	void Awake()
	{
			handler = this;
	}

	public string[] responses;

	public void InitializeOptions()
	{
		GameManager.manager.handlerOptionList.Add (new Options ("Who are you?", "What is this?", "Help with what?", "It doesn't matter right now. We have a problem. We're calling you in. ", "There's a lot to explain, and not much time. For now, just know that we need your help.", "Let me take a moment to explain.", 0, 0, 0));
		GameManager.manager.handlerOptionList.Add (new Options ("Agent? I'm not an agent.", "I think you're mistaken.", "What organization?", "Yes. You are.", "I'm not.", "I'm not at liberty to discuss that right now.", 0, 0, -1));
		GameManager.manager.handlerOptionList.Add (new Options ("You're telling me that I'm a spy. I think I'd know if I were a spy.", "What can I even do for you?", "You're crazy.","You would be surprised how many spies don't know they're spies.", "Many things, but right now, your location is of particular use to us.", "I assure you, there is nothing wrong with my mental health.", 0, 0, -1));
		GameManager.manager.handlerOptionList.Add(new Options("Wait Gideon? He'd never commit a crime.", "I knew it.", "No.", "Trust me when I say he's an extremely dangerous person.", "You did? Impressive.", "Then leave.", 0, 0, -1));
		GameManager.manager.handlerOptionList.Add(new Options("How can I do anything?", "I'm still not really sure about this.", "How am I even going to do that? I don't know where he is.", "It's quite simple actually.", "Understandable.", "That's not a problem.", 1, 0, -1));

		Debug.Log ("messages have been initialized.");
	}

	public void InitializeResponses()
	{
		responses = new string[10];

		responses[0] = "To cut a long story short, you're an agent for our organization; one whose skills we require.";
		responses[1] = "Look, " + GameManager.manager.playerName + ", there's a lot going on right now, and you won't be able to know most of what's going on. But just understand we need you. Of course, if that's too much, feel free to just log off right now.";
		responses[2] = "Moreover, we need to get to the point. If you notice, there's a new contact there. That's our suspect. We need you to get in close and communicate with them."; 
		responses [3] = "Okay, so if you're still here, I'm assuming you're going to help. We need your assistance.";
		responses [4] = "In short, all you need to do is simply message him. Get him to talk about his job, location, etc. Anything that could possibly be important. I'm adding him to your contact list right now. Please note, I'm censoring your messages. Can't have you revealing that you're working for us.";

	}
}
