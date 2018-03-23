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

	void TaskOnClick () {
		if (GameManager.manager.checkIfLoaded(buttonApp) == false) {
			unloadOtherScenes ();
			SceneManager.LoadScene (buttonApp, LoadSceneMode.Additive);
			open = true;
			EventSystem.current.SetSelectedGameObject (null);
		}
		else if (GameManager.manager.checkIfLoaded(buttonApp) == true)
		{
			SceneManager.UnloadSceneAsync (buttonApp);
			open = false;
			EventSystem.current.SetSelectedGameObject (null);
		}
	}

	void unloadOtherScenes()
	{
		int c = SceneManager.sceneCount;
		for (int i = 0; i < c; i++)
		{
			Scene scene = SceneManager.GetSceneAt (i);

			if (scene.name != "MainGame" && scene.name != buttonApp)
			{
				SceneManager.UnloadSceneAsync (scene);
			}
		}
	}
}
