using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour {

	public SpeakNPC[] speaks = new SpeakNPC[2];

	private bool dialogComplete = false;

	DialogController dialogController; 

	void Start () {
		dialogController = FindObjectOfType<DialogController> ();
	}	

	void Update () {
		
	}

	private void OnMouseOver(){
		if(Input.GetMouseButtonDown(1)){
			if (AnxietyHUD.currentAnxiety < 9.9f) {
				GameObject.Find ("Player").GetComponent<Player> ().maxSpeed = 0;
				if (!dialogComplete) {
					dialogController.NextDialog (speaks [0]);
				} else {
					dialogController.NextDialog (speaks [1]);
				}
				dialogComplete = true;
			} else if(AnxietyHUD.currentAnxiety == 9.9f) {
				dialogController.NextDialog (speaks [2]);
			}
		}
	}

	/*private void OnTriggerEnter2D(Collider2D other) {
		
		if (other.CompareTag ("Player")) {

			other.GetComponent<Player> ().maxSpeed = 0;

			if (!dialogComplete) {
				dialogController.NextDialog (speaks [0]);
			} else {
				dialogController.NextDialog (speaks [1]);
			}

			dialogComplete = true;
			//Remove BoxCollider ao terminar diálogo, permitindo ao player passar pelo NPC
			Destroy(GetComponent<BoxCollider2D>());
		}
	}*/
}
