using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SettingButton : MonoBehaviour {

	public string buttonApp;

	// Use this for initialization
	void Start () {
		Button btn = this.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick () {
		if (GameManager.manager.checkIfLoaded(buttonApp) == false) {
			SceneManager.LoadScene (buttonApp, LoadSceneMode.Additive);
		}
		else if (GameManager.manager.checkIfLoaded(buttonApp) == true)
		{
			SceneManager.UnloadSceneAsync (buttonApp);
		}
		EventSystem.current.SetSelectedGameObject (null);
	}
