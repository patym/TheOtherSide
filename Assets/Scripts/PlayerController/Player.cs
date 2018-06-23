using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public static Player Instance;

	string sceneCurrent; 
	
	bool facingRight = true;
    public float maxSpeed = 8f;
	Animator anim;

	public static Vector2 target;

	public static Vector2 mouse;

	public static Vector3 playerScreenPoint;

	void Awake(){
		Instance = this;
		sceneCurrent = SceneManager.GetActiveScene ().name;
		if (PlayerPrefs.HasKey ("PlayerPos" + sceneCurrent + "X")) {
			transform.position = new Vector2(PlayerPrefs.GetFloat("PlayerPos"+sceneCurrent+"X"), PlayerPrefs.GetFloat("PlayerPos"+sceneCurrent+"Y"));
		}
	}

	void Start () {
		anim = gameObject.GetComponent<Animator>();
		target = transform.position;

        //Clear All PlayerPrefs
        //PlayerPrefs.DeleteAll();
    }
		
	void Update () {
    }

	void FixedUpdate () {
        anim.SetFloat("IdleSpeed", AnxietyHUD.IdleSpeed);
        var playerObject = GameObject.Find("Player");
		var playerPos = playerObject.transform.position;

		if (Input.GetMouseButtonDown (0)) {
                if (gameObject.tag == "Inventory") { Debug.Log("Open"); }

            if (AnxietyHUD.currentAnxiety > 9.9f) {
			} else {
				target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				target.y = transform.position.y;
				anim.SetFloat ("Speed", Mathf.Abs (target.y));
				mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
				playerScreenPoint = Camera.main.WorldToScreenPoint(playerPos);
				if (mouse.x > playerScreenPoint.x && facingRight == false) {
					Flip ();
				}
				if (mouse.x < playerScreenPoint.x && facingRight == true) {
					Flip ();
				}
			}
		} else {
		}
		transform.position = Vector2.MoveTowards(transform.position, target, maxSpeed * Time.deltaTime);
        if (transform.position == playerPos){
			anim.SetFloat("Speed", 0);
		}
    }

	void Flip () {
		facingRight = !facingRight;
		Vector2 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}