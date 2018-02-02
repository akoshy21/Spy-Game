using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IconButtonScript : MonoBehaviour {

	public string buttonApp;

	public bool open = false;

	// Use this for initialization
	void Start () {
		Button btn = this.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick () {
		if (open == false) {
			SceneManager.LoadScene (buttonApp, LoadSceneMode.Additive);
			open = true;
		}
		else if (open == true)
		{
			SceneManager.UnloadSceneAsync (buttonApp);
			open = false;
		}
	}
}
