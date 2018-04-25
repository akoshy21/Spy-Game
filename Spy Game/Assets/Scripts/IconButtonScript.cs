using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class IconButtonScript : MonoBehaviour {

	public string buttonApp;

	public bool open = false;

	// Use this for initialization
	void Start () {
		Button btn = this.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}

	void Update()
	{
		GameManager.manager.CheckForClicks ();
	}

	public void TaskOnClick () {
		if (GameManager.manager.checkIfLoaded(buttonApp) == false) {
			unloadOtherScenes (buttonApp);
			SceneManager.LoadScene (buttonApp, LoadSceneMode.Additive);
			open = true;
		}
		else if (GameManager.manager.checkIfLoaded(buttonApp) == true)
		{
			SceneManager.UnloadSceneAsync (buttonApp);
			open = false;
		}
		EventSystem.current.SetSelectedGameObject (null);
	}

	public void unloadOtherScenes(string app)
	{
		int c = SceneManager.sceneCount;
		for (int i = 0; i < c; i++)
		{
			Scene scene = SceneManager.GetSceneAt (i);

			if (scene.name != "MainGame" && scene.name != app)
			{
				SceneManager.UnloadSceneAsync (scene);
			}
		}
	}
}
