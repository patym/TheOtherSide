using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public static LoadScene Instance;

    bool Move;
	public string SceneLoad;

	string sceneCurrent;

    public static int[] ItemsList;

    public static int count = 0;

    void Awake () {
        Instance = this;
        //Get name of actual scene
		sceneCurrent = SceneManager.GetActiveScene ().name;
        ItemsList = new int[100];
    }

	void Start () {
	}

    public static void StoraItemsList(int pItemID){
        ItemsList[count] = pItemID;
        Debug.Log(ItemsList[count]);
        count++;
    }

    void Update() {
	    if (Move == true && Input.GetKeyDown (KeyCode.E)) {
            //Save player positon in every scene
		    PlayerPrefs.SetFloat("PlayerPos"+sceneCurrent+"X", Player.target.x);
		    PlayerPrefs.SetFloat("PlayerPos"+sceneCurrent+"Y", Player.target.y);

            //Save list of items with Player

            /*
                Items ID Index
                1 - Key Scott Bedroom
                2 - 
                3 - 
                4 - 
                5 - 
            */
            for(int i=0; i < count; i++){
                PlayerPrefs.SetInt("PlayerItemID"+ItemsList[i], ItemsList[i]);
                Debug.Log(PlayerPrefs.GetInt("PlayerItemID" + ItemsList[i]));
            }
            //Load next scene
		    SceneManager.LoadScene (SceneLoad);
	    }
	}

	void OnTriggerEnter2D() {
		Move = true;
	}

	void OnTriggerExit2D() {
		Move = false;
	}

	void OnGUI(){
		if (Move == true) {
			GUIStyle style = new GUIStyle ();
			style.alignment = TextAnchor.MiddleCenter;
			GUI.skin.label.fontSize = 20;
			GUI.Label(new Rect(Screen.width/2 - 50, Screen.height/2 + 50, 200, 30), "Pressione 'E'");
		}
	}
}
