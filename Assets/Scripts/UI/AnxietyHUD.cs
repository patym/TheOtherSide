using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnxietyHUD : MonoBehaviour {

	public static AnxietyHUD Instance;

	public int startingAnxiety = 0;
    public static float IdleSpeed;
    public static float currentAnxiety;
	public Slider anxietySlider;
	public Image blur;
	public float blurSpeed = 5f;
	public Color blurOpacity = new Color(0f, 0f, 0f, 0.1f);

	public int countNPC;

	public GameObject[] npcCounter;

	bool anxiety;

	void Start () {
        npcCounter = GameObject.FindGameObjectsWithTag("NPC");
		countNPC = npcCounter.Length;
		if (countNPC > 0) {
			TakeAnxiety (countNPC);
            IdleSpeed = 2f;
        }
        else{
            IdleSpeed = 0f;
        }
	}

	void Awake () {
		Instance = this;
		currentAnxiety = startingAnxiety;
	}

	void Update () {
		if (anxiety) {
			var ChangeAlpha = blur.color;
			ChangeAlpha.a = countNPC / 10f;
			blur.color = ChangeAlpha;
		}
		if(currentAnxiety == 0){
			anxiety = false;
		}
	}

	public void TakeAnxiety (int amount) {
		anxiety = true; 

		currentAnxiety += amount;

		anxietySlider.value = currentAnxiety;
	}
}