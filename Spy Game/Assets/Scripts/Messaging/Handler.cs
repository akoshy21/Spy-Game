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
		
		GameManager.manager.handlerOptionList.Add (new Options ("Who are you?", "What is this?", "Help with what?", "It doesn't matter right now, but suffice to say there's a large problem", "There's a lot to explain, and not much time.", "I don't have a lot of time to explain.", 0, 0, 0));
		GameManager.manager.handlerOptionList.Add (new Options ("Robots?", "My help?", "What organization?", "Yes. And I'm going to need you to operate one of them.", "Yes. It's very important.", "I'm not at liberty to discuss that right now.", 0, 0, -1, 2));
		GameManager.manager.handlerOptionList.Add (new Options ("Their mission? What's that?", "You control your robots through a messenger application?", "You're crazy.","It's really simple.", "Uh... Yes. It's meant to seem not very spylike.", "I assure you, there is nothing wrong with my mental health.", 0, 0, -1));
		GameManager.manager.handlerOptionList.Add(new Options("You're just giving me control of a robot??", "What am I supposed to do with her?", "No.", "Yes, uh, we don't have much of a choice right now.", "Help her to finish her mission.", "Please. We need your assistance.", 0, 0, 0));
		GameManager.manager.handlerOptionList.Add(new Options("How do I do any of this?", "Are you sure?", "I don't think I'm qualified for this.", "Simply direct her actions with the chat, as you've been doing so far.", "Quite clearly.", "Nonsense. It's quite simple.", 0, 0, 0));
		GameManager.manager.handlerOptionList.Add(new Options("But why on earth would you trust me with this?", "I'm not going to mess with this level of tech.", "First of all, fuck you. Second of all, no.", "We need you.", "It's not that hard...", "That's... that's very rude.", 0, 0, -1));
		GameManager.manager.handlerOptionList.Add(new Options("Safe?", "I just don't think letting a person with zero knowledge work on this is a good idea.", "So you decided pulling a random person into this shit was a good idea?", "Yes. We vetted you and you came back clean.", "It is literally not difficult at all. Talk to her.", "It's the only one we have and can implement at the moment, yes.", 0, 0, 0));
		GameManager.manager.handlerOptionList.Add(new Options("If you're under a time crunch, why are you having a complete stranger operate her?", "No. Why should I?", "Alright, alright - I'll get on it.", "Because we've no choice.", "We'll make it benefit you.", "Good.", 0, 0, 0));
		GameManager.manager.handlerOptionList.Add(new Options("I don't know that I want to do this.", "Get off my ass about this.", "I want out.", "You know what? Fine.", "... Clearly you're not up for this task.", "Fine, go right ahead.", 0, 0, 0, 1));

		Debug.Log ("messages have been initialized.");
	}

	public void InitializeResponses()
	{
		responses = new string[10];

		responses[0] = "To cut a long story short, we are a multi-government organization, operating at a high level of discretion. Our branch deals with remote operations, using android operatives.\nI know it sounds crazy, but we've been waiting for someone to access this computer, and now we need your help.";
		responses[1] = "Essentially, this device you've found is our method of controlling our operatives. You'll need to chat with them in order to help them finish their mission.";
		responses[2] = "Anyway.... The new contact has been unlocked. That's the access for the android you control. Codenamed Rose."; 
		responses [3] = "She's a vital part of our operation. Please be very careful with her.";
		responses [4] = "It's literally just controlling a robot. There's nothing all that difficult to it. Now get to work.";
		responses [5] = "Look, it's just messaging Rose - that's all you need to do. We just need you to do this because the real operative that was meant to manage her disappeared and you're the nearest safe person to her.";
		responses [6] = "Just help her already. We're on a time crunch with this mission.";
		responses [7] = "The original Operator was killed, and we don't have a lot of time. It should be fairly easy to answer her queries. Just do so, and you'll be able to quickly finish this all up.";

	}
}
