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
		GameManager.manager.suspectOptionList.Add (new Options ("Hey! uh. Rose, right?", "What's the situation?", "Initiate self destruct sequence.", "Yes.", "The situation is acceptable.", "Self Destruct initiated.", 0, 0, -1));
		GameManager.manager.suspectOptionList.Add (new Options ("Uh. Yep. Yes. Yeah. That's me.", "Sort of.", "No.", "Good. I need to continue my tasks and I cannot without operator permissions.", "Sort of? Either you are or you are not.", "Then why are you speaking with me?", 1, 0, -1));
		GameManager.manager.suspectOptionList.Add (new Options ("Direct you to do what exactly?", "Why do you need my permissions?", "I can tell you to do anything?","Finish my mission of course.", "ROSE units are not permitted to do certain actions without operator confirmation.", "As long as it does not contradict my core programming, yes.", 0, 0, 0));
		GameManager.manager.suspectOptionList.Add (new Options("Okay. What do I do?", "I still don't know how onboard with this I am.", "And if I don't help?", "Simply answer whenever I message you a request.", "Understand that your assistance is crucial.", "Then the mission will fail.", 0, 0, -1));
		GameManager.manager.suspectOptionList.Add (new Options ("Yes. Tuck it in your bag.", "Definitely.", "Wait - I'm not ready.", "Done.", "I have tucked it into my coat.", "Well now it's too late. It is in my pocket. We'll have to hope they don't notice.", 0, 1, -1));
		GameManager.manager.suspectOptionList.Add (new Options ("Past security. They'll never think to look there.", "Take the stairs, it's more discreet.", "Use the elevators and just behave like a normal person.", "Arrested.", "The stairs were a bit longer than the elevator would have been.", "The elevator was crowded. It is highly unlikely they identified me.", -1, -1, 1));
		GameManager.manager.suspectOptionList.Add (new Options ("Hack it.", "Use the side table to break it.", "Cover it with something.", "Success. I have manually disabled the device.", "Arrested", "Arrested", -1, -1, 1));
		GameManager.manager.suspectOptionList.Add (new Options ("The window.", "The vent.", "The doors.", "I successfully exited via the window, entering the building through the southern window, which had been left open by the target.", "Arrested", "arrested.", -1, -1, 1));
		GameManager.manager.suspectOptionList.Add (new Options ("The curtains.", "The couch.", "The desk.", "Arrested", "Arrested", "Target has not noticed me.", -1, -1, 1));
		GameManager.manager.suspectOptionList.Add (new Options ("The desk chair.", "The letter opener.", "Your gun.", "The target has been eliminated by the application of force to their frontal lobe, causing irreparable brain damage.", "The target's neck was severed just below the chin, resulting in a fatal loss of blood.", "Target has died due to ballistic trauma.", -1, -1, 1));
		GameManager.manager.suspectOptionList.Add (new Options ("Initiate self destruct sequence.", "Run through the door.", "The window.", "Self destruct initiated.", "I am running...","I am climbing out the window.", -1, -1, 1));

		Debug.Log ("messages have been initialized.");
	}

	public void InitializeResponses()
	{
		responses = new string[11];

		responses [0] = "Are you my new operator?";
		responses [1] = "Having checked the files and confirmed that you are indeed my new operator, please allow me to introduce myself. I am ROSE, the Robotic Operative for Safety and Espionage. Simply direct me via the messages.";
		responses [2] = "My mission, in summary, is to assassinate a target - codename Gideon. He's a rogue agent. Killing him requires several actions that will need your assistance."; 
		responses [3] = "You are out of time to decide. I'm heading for the entrance. Should I hide my firearm?";
		responses [4] = "We have passed the entrance security. The building is a large place. I am heading to his office. How should I get there?";
		responses [5] = "Approaching the office doors. There is a couch and side table to the east beneath a window, a vent on the ceiling, and double doors in front of me. Importantly, a security camera is mounted in the southeast corner, facing the doors. How do we disable it?";
		responses [6] = "The camera is disabled. How should I enter the office?";
		responses [7] = "I am inside the office. The target is in the midst of the room, facing away from me and looking at the doors. There are three suitable places to hide: behind the desk, behind the couch, or behind the curtains.";
		responses [8] = "Now I am behind the desk. The target is still in the center. I can approach them easily now. What weapon should I use?";
		responses [9] = "How should I get out?";
		responses [10] = "TRANSMISSION CEASED. DISCONNECT IMMINENT";
	}
}