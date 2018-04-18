using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {

	public static GameManager manager;
	// public List<PlayerNotes> no = new List<PlayerNotes>();
	public float maintimes;

	public List<Messages> msgs = new List<Messages>();
	public List<Messages> suspect = new List<Messages> ();

	public GameObject contactButton;
	public GameObject contactNotif;

	public GameObject suspectButton;
	public GameObject suspectNotif;

	// see if the contact/message app has started up yet.
	public bool contactStartup = false;
	public bool suspectStartup = true;

	// see if there's a new message
	public bool newMessageHandler = true;
	public bool newMessageSuspect = false;

	public bool handlerPause = false;
	public bool suspectPause = false;
	public bool reinit = false;

	public string handlerName = "X";
	public string suspectName = "Gid";

    public int handlerR = 0;
	public int suspectR = 0;

    private IEnumerator coroutine;

	public List<Options> handlerOptionList = new List<Options>();
	public int handlerOptionIndex = 0;

	public List<Options> suspectOptionList = new List<Options>();
	public int suspectOptionIndex = 0;

	public int personality;

	public string playerName;
	public string sigOtherName;
	public bool sigFemale;
	public string sigHeShe;
	public string sigHerHis;

	public float boxHeight;
	// Use this for initialization

	public AudioClip msgSound;
	public AudioClip click;

	public Sprite handlerIcon;
	public Sprite suspectIcon;
	public Sprite playerIcon;

	public Color handlerColor = new Color(0.04f, 0.18f, 0.39f);
	public Color suspectColor = new Color(0.99f, 0f, 0.87f);

	void Awake () {
		// set up the game manager
		if (manager == null)
		{
			DontDestroyOnLoad (gameObject);
			manager = this;
		}
		else if (manager != this)
		{
			Destroy (gameObject);
		}
	}

	void OnEnable()
	{
		Load ();
//		Debug.Log("HI");
//		Debug.Log (maintimes);
		maintimes++;

		sigOtherName = SignificantOther ();
		if (sigFemale == true) {
			sigHeShe = "she";
			sigHerHis = "her";
		}
		else if (sigFemale == false) {
			sigHeShe = "he";
			sigHerHis = "his";
		}
		Debug.Log (sigOtherName);

	}

	void Start()
	{

	}

	void Update () {

		CheckForClicks ();

		//Debug.Log (EventSystem.current);
			
	}
		
	void OnDisable()
	{
		Debug.Log ("BYE");
		Save ();
	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		// note to self, changing the playerdata name to a different thing ie. player data 1, 2, 3 could allow for multiple save slots
		FileStream file = File.Create (Application.persistentDataPath + "/playerData.dat");

		GameData data = new GameData (maintimes);

		bf.Serialize (file, data);
		file.Close();
	}

	public void Load()
	{
		if (File.Exists (Application.persistentDataPath + "/playerData.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerData.dat", FileMode.Open);
			GameData data = (GameData)bf.Deserialize (file);
			file.Close ();

			maintimes = data.times;
			// no = data.notes;
		}
	}

	public bool checkIfLoaded(string sceneName) {
		for(int i=0; i< UnityEditor.SceneManagement.EditorSceneManager.sceneCount; ++i) {
			var scene = UnityEditor.SceneManagement.EditorSceneManager.GetSceneAt(i);

			if(scene.name == sceneName) {
				return true; //the scene is already loaded
			}
		}
		//scene not currently loaded
		return false;
	}

	public void OnString_PlayerName(string value)
	{
		playerName = value;
	}



	public void MessageAlert()
	{
		// Debug.Log("HI");
		if (newMessageHandler == true && checkIfLoaded ("Messenger") == false) {
			contactNotif.SetActive (true);
		}
		else if(checkIfLoaded("Messenger"))
		{
			contactNotif.SetActive (false);
			//Debug.Log ("Beep");
		}

		if (newMessageSuspect == true && checkIfLoaded ("Suspect") == false) {
			suspectNotif.SetActive (true);
		}
		else if(checkIfLoaded("Suspect"))
		{
			suspectNotif.SetActive (false);
			//Debug.Log ("Beep");
		}
	}

	public void CheckForClicks()
	{
		if (Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1) || Input.GetMouseButtonDown (2)) {
			AudioSource audiosource = this.GetComponent<AudioSource> ();
			audiosource.PlayOneShot (click);
			// Debug.Log ("BooP");
		}
	}

	public string SignificantOther()
	{
		int sig;
		sig = UnityEngine.Random.Range (0,10);

		switch (sig) {
		case 1:
			sigFemale = true;
			return "Virginia";
		case 2:
			sigFemale = false;
			return "Harold";
		case 3:
			sigFemale = true;
			return "Susan";
		case 4:
			sigFemale = false;
			return "James";
		case 5:
			sigFemale = true;
			return "Louise";
		case 6:
			sigFemale = false;
			return "Lou";
		case 7:
			sigFemale = false;
			return "Bart";
		case 8:
			sigFemale = true;
			return "Jenna";
		case 9:
			sigFemale = false;
			return "Lorenzo";
		default:
			sigFemale = true;
			return "Elsie";
		}
	}
}

[Serializable]
class GameData
{
	public float times;
	//public List<PlayerNotes> notes;

	public GameData (float t)
	{
		times = t;
		// notes = n;
	}

}