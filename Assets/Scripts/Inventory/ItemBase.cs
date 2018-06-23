/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemBase : MonoBehaviour {

	public string nameItem;
	public Sprite key;
	public bool isStacklabe;
	protected int amount = 1; 
	private bool canTakeItem;

	public void AddItem(int amountToAdd = 1) {
		amount += amountToAdd;	
	}

	public int GetAmount(){
		return amount;
	}

	private void Update () {
		
		if (Input.GetMouseButtonDown (1) && canTakeItem) {
			InventoryController.instance.AddItemToInventory (this);
		}
	}

	public void OnTriggerStay(Collider otherObj) {
		
		if (otherObj.gameObject.CompareTag ("Player")) {
			canTakeItem = true;
		UIController.instance.ShowMessageTakeItem ();
		}
	}

	public void OnTriggerExit(Collider otherObj) {
		
		if (otherObj.gameObject.CompareTag ("Player")) {
			canTakeItem = false;
		}
	}
}
*/