using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetItens : MonoBehaviour {

	public static GetItens Instance;
	public int itemCode;
	public GameObject CollectableItems;

    void Awake(){
		Instance = this;
	}

	void Start () {
        GameObject Item = GameObject.Find("HUDCanvas");
        GameObject Inventory = Item.transform.Find("Inventory").gameObject;
        GameObject ItemSpace = Inventory.transform.Find("Items_space").gameObject;
        if (PlayerPrefs.GetInt("PlayerItemID" + 1) == 1) {
            //GameObject.Find("Key").GetComponent<Renderer>().enabled = true;
            GameObject ActiveItem = ItemSpace.transform.Find("ItemKey").gameObject;
            ActiveItem.SetActive(true);
        } /*else {
			//GameObject.Find("Key").GetComponent<Renderer>().enabled = false;
			//GameObject.Find("Key").SetActive(false);
		}*/
    }

	/*void OnTriggerEnter2D(Collider2D otherObj) {
		if (otherObj.tag == "collectable_items") {
			otherObj.gameObject.SetActive (false);
			itemCode = 1;
			DATA.itemCode = itemCode;
		}
		if (itemCode == 1) {
			//GameObject.Find ("Key").GetComponent<Renderer> ().enabled = true;
			GameObject.Find("Key").SetActive(true);
		} else {
			Debug.Log ("outro item");
		}
	}*/

	public static void CheckItemStatus (int pItemID){
        GameObject Item = GameObject.Find("HUDCanvas");
        GameObject Inventory = Item.transform.Find("Inventory").gameObject;
        GameObject ItemSpace = Inventory.transform.Find("Items_space").gameObject;
        Debug.Log ("Item code: "+pItemID);
        if (pItemID == 1){
            GameObject ActiveItem = ItemSpace.transform.Find("ItemKey").gameObject;
            ActiveItem.SetActive(true);
            LoadScene.StoraItemsList(pItemID);
            //GameObject.Find("Key").SetActive(true);
        }
    }

	void Update () {
		if (Input.GetKeyDown ("s")) {
			PlayerPrefs.SetInt ("itemCode", DATA.itemCode);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject Canvas = GameObject.Find("HUDCanvas");
            GameObject MenuPause = Canvas.transform.Find("MenuPause").gameObject;
            MenuPause.SetActive(true);
        }

        if (Input.GetKeyDown("l")){
            PlayerPrefs.DeleteAll();
            Debug.Log("del");
        }
    }
}