using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour {

	public Text endText;
	public bool extraText = false;
	public AudioClip beep;

	// Use this for initialization
	void Start () {
		if (GameManager.manager.end == 0) {
			if (GameManager.manager.personality < -15) {
				GameManager.manager.end = 2;
				Debug.Log ("burned");
			} else if (GameManager.manager.personality >= -15 && GameManager.manager.personality <= 15) {
				GameManager.manager.end = 3;
				endText.text = "Connection ended.\n\nAgent " + GameManager.manager.playerName + " status: discharged.\n\nCritical mission failure. Reassessment of agent skill has deemed them unfit for service.";
				Debug.Log ("failed");
			} else if (GameManager.manager.personality > 15) {
				GameManager.manager.end = 4;
				endText.text = "Connection ended.\n\nAgent " + GameManager.manager.playerName + " status: activated.\n\nPlease remain in contact. Handler Nineteen will contact you again shortly.";
				Debug.Log ("woot");
			}
		}

		endText.text = ending ();
	}

	// Update is called once per frame
	void Update () {
		StartCoroutine(delay ());
		if (Input.GetKey (KeyCode.R)) {
			Restart ();
		}
	}

	public string ending()
	{
		int endNum = GameManager.manager.end;

		switch(endNum)
		{
		case 1:
			return "Connection terminated.\n\nOperator " + GameManager.manager.playerName + " status: arrested.\n\nCritical mission failure following the destruction of ROSE Unit 21. Operator has been taken into custody and is currently under investigation.";
		case 2:
			return "Connection terminated.\n\nOperator " + GameManager.manager.playerName + " status: discharged.\n\nCritical mission failure following the arrest of ROSE Unit 21 as she walked into the office with her weapon fully exposed.";
		case 3:
			return "Connection terminated.\n\nOperator " + GameManager.manager.playerName + " status: captured.\n\nCritical mission failure following the capture of both the ROSE Unit and the Operator by enemy forces after the ROSE Unit was instructed to go to the security headquarters for no apparent reason. Potential reason to suspect Operator as enemy infiltrator.";
		case 4:
			return "Connection terminated.\n\nOperator " + GameManager.manager.playerName + " status: discharged.\n\nCritical mission failure following the capture of ROSE Unit 21 after being caught tampering with enemy surveillence equipment.";
		case 5:
			return "Connection terminated.\n\nOperator " + GameManager.manager.playerName + " status: discharged.\n\nCritical mission failure following the destruction of ROSE Unit 21 by 'GIDEON' upon entry to the target's office. Operator has been absolved of responsibility following analysis of tape and understanding that the target was simply too attentive to the front of the room.";
		case 6:
			return "Connection terminated.\n\nOperator " + GameManager.manager.playerName + " status: discharged.\n\nCritical mission failure following the discovery of ROSE Unit attempting to hide in target's office. ROSE Unit was returned with severe damage.";
		case 7:
			return "Connection terminated.\n\nOperator " + GameManager.manager.playerName + " status: discharged.\n\nMission success. Operator was able to successfully assist unit with decisions pertaining to the mission. Target was killed semi-steathily, however unit self destructed afterwards, costing the agency the asset.";
		case 8:
			return "Connection terminated.\n\nOperator " + GameManager.manager.playerName + " status: recruited.\n\nMission success. Operator was able to successfully assist unit with decisions pertaining to the mission. Target was killed quietly, and Operator was able to kill several guards through their use of the unit.";
		case 9:
			return "Connection terminated.\n\nOperator " + GameManager.manager.playerName + " status: discharged.\n\nMission success. Operator was able to successfully assist unit with decisions pertaining to the mission, however the lack of stealth alerted guards and the unit was destroyed.";
		case 10:
			return "Connection terminated.\n\nOperator " + GameManager.manager.playerName + " status: captured.\n\nMission partial success. Operator was able to successfully take out target, however, unit was captured by security, and the Operator was captured soon after that.";
		case 11:
			return "Connection terminated.\n\nOperator " + GameManager.manager.playerName + " status: recruited.\n\nMission success. Operator was able to successfully assist unit with decisions pertaining to the mission. Target was eliminated and unit slipped out undetected.";
		case 12:
			return "Connection terminated.\n\nOperator " + GameManager.manager.playerName + " status: discharged.\n\nMission failure. Operator discharged for subordination and attitude problems by Handler Nineteen.";
		default:
			return null;
		}
	}
		
	public void Quit ()
	{
		Application.Quit ();
	}

	IEnumerator delay()
	{
		if(extraText == false)
		{
			extraText = true;
			yield return new WaitForSeconds(1.0f);
			endText.text += "\n\n\n To try again, press 'R'";
			GameManager.manager.GetComponent<AudioSource> ().PlayOneShot (beep, 0.4F);
		}
	}

	public void Restart()
	{
		Destroy (GameObject.FindGameObjectWithTag ("GameController"));
		SceneManager.LoadScene ("StartScreen", LoadSceneMode.Single);
	}
}