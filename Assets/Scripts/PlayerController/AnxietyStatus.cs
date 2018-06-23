using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxietyStatus : MonoBehaviour {
	public float maxSpeed = 8f;
	private Vector2 target;

	void Start () {
		target = transform.position;
	}

	void Update () {

	}

	void FixedUpdate () {
		var playerObject = GameObject.Find("AnxietyStatus");
		var playerPos = playerObject.transform.position;

		if (Input.GetMouseButtonDown (0)) {
			if (AnxietyHUD.currentAnxiety > 9.9f) {
				target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				target.y = transform.position.y;
			}
		}
		transform.position = Vector2.MoveTowards(transform.position, target, maxSpeed * Time.deltaTime);
	}
}