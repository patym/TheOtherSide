using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour {

	//public Texture2D cursorTexture;
	//public bool ccEnable = false;

	Ray ray;
	RaycastHit hit;

	private SpriteRenderer rend;
	public Sprite handCursor;
	public Sprite normalCursor;
	public Sprite GetCursor;

	public GameObject clickEffect;
	public GameObject trailEffect;
	public float timeBtwSpawn = 0.1f;

	private Vector2 theScale;

	void Start () {
		//Invoke("SetCustomCursor", 0.0f);
		Cursor.visible = false;
		rend = GetComponent<SpriteRenderer> ();
		rend.sprite = normalCursor;
	}
	
	/*void OnDisable() {
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
		this.ccEnable = false;
	}

	void SetCustomCursor() {
		Cursor.SetCursor (this.cursorTexture, Vector2.zero, CursorMode.Auto);
		Debug.Log ("Custom cursor has been set.");
		this.ccEnable = true;
	}*/

	void Update () {
		Vector2 cursorPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		this.transform.position = cursorPos;

		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit)) {
			if (hit.collider.tag == "collectable_items") {
				rend.sprite = handCursor;
			}
		} else {
			rend.sprite = normalCursor;
		}

		if (Input.GetMouseButtonDown (1)) {
			rend.sprite = GetCursor;
			Instantiate (clickEffect, transform.position, Quaternion.identity);
		} else if (Input.GetMouseButtonUp (1)) {
			rend.sprite = normalCursor;
		}

		theScale = transform.localScale;

		if (cursorPos.x < Player.target.x) {
			theScale.x = -1;
			transform.localScale = theScale;
		}
		else {
			theScale.x = 1;
			transform.localScale = theScale;
		}

		/*if (timeBtwSpawn <= 0) {
			Instantiate (trailEffect, cursorPos, Quaternion.identity);
			timeBtwSpawn = 0.1f;
		} else {
			timeBtwSpawn -= Time.deltaTime;
		}*/
	}
}