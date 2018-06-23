using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOverEffect : MonoBehaviour {

    public Text theText, theText2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PointerEnter() {
        theText.color = Color.white; //Or however you do your color
        theText2.color = Color.white; //Or however you do your color
    }
    public void PointerExit() {
        theText.color = Color.black; //Or however you do your color
        theText2.color = Color.black; //Or however you do your color
    }
}
