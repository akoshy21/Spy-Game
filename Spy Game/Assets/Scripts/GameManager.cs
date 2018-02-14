using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager manager;
	// public List<PlayerNotes> no = new List<PlayerNotes>();
	public float maintimes;

	public GameObject[] msgBoxes;
	public List<Messages> msgs = new List<Messages>();

	public bool contactStartup = false;


	// pregabs


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