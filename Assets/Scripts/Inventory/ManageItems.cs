using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageItems : MonoBehaviour {

	public static ManageItems Instance;

	public int ItemID = 0;

	void Awake(){
		Instance = this;
	}

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("PlayerItemID" + 1) == ItemID) {
            Destroy(this.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(1) && AnxietyHUD.currentAnxiety < 9.9f){
			Destroy (this.gameObject);
			GetItens.CheckItemStatus (ItemID);
		}
	}
}
