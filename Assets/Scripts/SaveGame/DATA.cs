using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DATA : MonoBehaviour {

	public static int itemCode;
	private GameObject[] Datas;

	void Awake() {
		Datas = GameObject.FindGameObjectsWithTag ("DATA");

		if (Datas.Length >= 2) {
			Destroy (Datas [0]);
		}

		DontDestroyOnLoad (transform.gameObject);
	}

	void Start() {
		if (PlayerPrefs.HasKey ("itemCode")) {
			itemCode = PlayerPrefs.GetInt ("itemCode");
		} else {
			PlayerPrefs.SetInt ("itemCode", itemCode);
		}
	}

	void Update() {

	}
}
