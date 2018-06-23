using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour {

	public GameObject panelDialog;

	public Text speakNPC;

	public GameObject answer;

	private bool speakActive = false;

	SpeakNPC speaks;

	void Start () {
		
	}

	void Update () {
		if (Input.GetMouseButtonDown (0) && speakActive) {
			if (speaks.answer.Length > 0)
				ViewAnswer ();
			else {
				speakActive = false;
				panelDialog.SetActive (false);
				speakNPC.gameObject.SetActive (false);
				FindObjectOfType<Player> ().maxSpeed = 8;
			}
		}
	}

	void ViewAnswer(){
		speakNPC.gameObject.SetActive (false);
		speakActive = false;

		for (int i = 0; i < speaks.answer.Length; i++) {
			GameObject tempAnswer = Instantiate (answer, panelDialog.transform) as GameObject;
			tempAnswer.GetComponent<Text> ().text = speaks.answer [i].answer;
			tempAnswer.GetComponent<AnswerButton> ().Setup (speaks.answer [i]);
		}
	}

	public void NextDialog(SpeakNPC speak) {

		speaks = speak;

		ClearAnswer ();

		speakActive = true; 
		panelDialog.SetActive (true);
		speakNPC.gameObject.SetActive (true);

		speakNPC.text = speaks.speak;
	}

	void ClearAnswer() {
		AnswerButton[] buttons = FindObjectsOfType<AnswerButton> ();
		foreach (AnswerButton button in buttons) {
			Destroy (button.gameObject);
		}
	}
}
