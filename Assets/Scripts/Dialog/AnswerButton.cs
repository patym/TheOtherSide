using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButton : MonoBehaviour {

	Answer answerDate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NextSpeak() {
		FindObjectOfType<DialogController>().NextDialog(answerDate.nextDialog);

	}

	public void Setup(Answer answer) {
		answerDate = answer;
	}
}
