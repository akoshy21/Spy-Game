using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContactAppManager : MonoBehaviour {

	public string noteText;
	public int contact = 0;

	// prefabs
	public Text senderName;
	public Text message;
	public Image messageBox;

	public GameObject windowbg; 

	public bool newResponse = false;

    public string[] responses;

    public int rNum;

    private IEnumerator coroutine;

    public bool oneMsg = true;
    public bool twoMsg = true;

    //	List<Messages> messages;
    //	GameObject[] boxes;

    /// public Text contactZero;

    // Use this for initialization
    void OnEnable () {

		windowbg = GameObject.FindGameObjectWithTag ("windowbg"); 

		GameManager.manager.newMessage = false;

		InitializeOptions ();
        InitializeResponses();

		// add previous messages
		foreach(Messages ms in GameManager.manager.msgs)
		{
			new Messages (ms.senderName, ms.message, senderName, message, messageBox, ms.isPlayer);
			Debug.Log (ms.isPlayer);
		}

		if (GameManager.manager.contactStartup == false)
		{
			//new Messages (handlerName, "Hello Agent. It's been a while. Welcome to the world.", false);
			GameManager.manager.msgs.Add(new Messages(GameManager.manager.handlerName, "Hello. \nI'm sure this must be a bit confusing, but we need your help, and there isn't much time to explain.", senderName, message, messageBox, false));
			GameManager.manager.contactStartup = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space"))
		{
			GameManager.manager.msgs.Add( new Messages("hi", Time.time.ToString(), senderName, message, messageBox, false));
		}

        Debug.Log(newResponse);

		if (newResponse == true)
		{
			coroutine = AddResponse (rNum);
            StartCoroutine(coroutine);
		}
	}

	void OnDisable()
	{
	}

	public void InitializeOptions()
	{
		GameManager.manager.optionList.Add (new Options ("Who are you?", "What is this?", "Help with what?", "It doesn't matter right now. We have a problem. We're calling you in. ", "There's a lot to explain, and not much time. For now, just know that we need your help.", "Let me take a moment to explain.", 0, 0, 0));
		GameManager.manager.optionList.Add (new Options ("Agent? I'm not an agent.", "I think you're mistaken.", "What organization?", "Yes. You are.", "I'm not.", "I'm not at liberty to discuss that right now.", 0, 0, -1));
		GameManager.manager.optionList.Add (new Options ("You're telling me that I'm a spy. I think I'd know if I were a spy.", "What can I even do for you?", "You're crazy.","You would be surprised how many spy's don't know they're spies.", "Many things, but right now, your location is of particular use to us.", "I assure you, there is nothing wrong with my mental health.", 0, 0, -1));
        GameManager.manager.optionList.Add(new Options("You're telling me that I'm a spy. I think I'd know if I were a spy.", "What can I even do for you?", "You're crazy.", "You would be surprised how many spy's don't know they're spies.", "Many things, but right now, your location is of particular use to us.", "I assure you, there is nothing wrong with my mental health.", 0, 0, -1));

    }

    public void InitializeResponses()
    {
        responses = new string[10];

        responses[0] = "To cut a long story short, you're an agent for our organization; one whose skills we require.";
        responses[1] = "Look, " + GameManager.manager.playerName + ", there's a lot going on right now, and you won't be able to know most of what's going on. But just understand we need you. Of course, if that's too much, feel free to just log off right now.";
        responses[2] = "Look, " + GameManager.manager.playerName + ", there's a lot going on right now, and you won't be able to know most of what's going on. But just understand we need you. Of course, if that's too much, feel free to just log off right now.";

    }

    public IEnumerator AddResponse(int responseNum)
    {
        GameObject[] optionbuttons = GameObject.FindGameObjectsWithTag("option");

        for (int i = 0; i < optionbuttons.Length; i++)
        {
            optionbuttons[i].SetActive(false);
        }

        yield return new WaitForSeconds(1);
        if (oneMsg == true)
        {
            if (responseNum == 1)
            {
                GameManager.manager.msgs.Add(new Messages(GameManager.manager.handlerName, GameManager.manager.optionList[GameManager.manager.optionIndex - 1].responseOne, senderName, message, messageBox, false));
                oneMsg = false;
            }
            else if (responseNum == 2)
            {
                GameManager.manager.msgs.Add(new Messages(GameManager.manager.handlerName, GameManager.manager.optionList[GameManager.manager.optionIndex - 1].responseTwo, senderName, message, messageBox, false));
                oneMsg = false;
            }
            else if (responseNum == 3)
            {
                GameManager.manager.msgs.Add(new Messages(GameManager.manager.handlerName, GameManager.manager.optionList[GameManager.manager.optionIndex - 1].responseThree, senderName, message, messageBox, false));
                oneMsg = false;
            }
        }

        yield return new WaitForSeconds(0.5f);
        if (twoMsg == true)
        {
            GameManager.manager.msgs.Add(new Messages(GameManager.manager.handlerName, responses[GameManager.manager.r], senderName, message, messageBox, false));
            GameManager.manager.r++;
            twoMsg = false;
        }
		yield return new WaitForSeconds (0.5f);
        for (int i = 0; i < optionbuttons.Length; i++)
        {
            optionbuttons[i].SetActive(true);
        }
		newResponse = false;
	}

}
