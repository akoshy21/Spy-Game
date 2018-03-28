using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SignInButton : MonoBehaviour {
	void Start () {
		Button btn = this.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick () {
		SceneManager.LoadScene ("MainGame", LoadSceneMode.Single);
	}
}
