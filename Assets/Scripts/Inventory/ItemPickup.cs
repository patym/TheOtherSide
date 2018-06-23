/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable {

	public Item item;

	public override void Interact() {
		base.Interact ();

		ItemPickup ();
	}

	void PickUp () {
		bool wasPickedUp = InventoryController.instance.Add(item);

		if (wasPickedUp) {
			Destroy (GameObject);
		}
	}
}
*/