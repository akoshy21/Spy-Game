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

	public GameObject contactButton;
	public GameObject contactNotif;

	// see if the contact/message app has started up yet.
	public bool contactStartup = false;

	// see if there's a new message
	public bool newMessage = true;

	public string handlerName = "X";

    public int r = 0;

    private IEnumerator coroutine;

	public List<Options> optionList = new List<Options>();
	public int optionIndex = 0;

	public int personality;

	public string playerName;

	public float boxHeight;
	// Use this for initialization

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
		Debug.Log("HI");
		Debug.Log (maintimes);
		maintimes++;
	}

	void Start()
	{

	}

	void Update () {
		if (checkIfLoaded ("MainGame") == true) {
			contactButton = GameObject.FindGameObjectWithTag ("contactbutton");
			contactNotif = GameObject.FindGameObjectWithTag ("msgNotif");

			MessageAlert ();
		}

		Debug.Log (EventSystem.current);
			
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
		playerName = value.ToUpper ();
	}



	public void MessageAlert()
	{
		Debug.Log("HI");
		if (newMessage == true && checkIfLoaded ("Messenger") == false) {
			contactNotif.SetActive (true);
		}
		else
		{
			contactNotif.SetActive (false);
			Debug.Log ("Beep");
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