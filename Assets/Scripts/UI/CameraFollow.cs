using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	
	public Transform player;

	public Transform AnxietyStatus;

	[SerializeField]
	private float maxX16_9 = 0, minX16_9 = 0, minY16_9 = 0, maxY16_9 = 0, maxX4_3 = 0, minX4_3 = 0, minY4_3 = 0, maxY4_3 = 0;

    void awake(){
        /*if (Camera.main.aspect >= 1.7)// 16:9
            
        else if (Camera.main.aspect > 1.6)// 5:3

        else if (Camera.main.aspect == 1.6)// 16:10

        else if (Camera.main.aspect >= 1.5)// 3:2

        else// 4:3*/
    }

	void Start () {
	}	

	void Update () {
		if (AnxietyHUD.currentAnxiety >= 10f) {
			StartCoroutine (Timer());
		}
		if (AnxietyHUD.currentAnxiety > 9.9f) {
            if (Camera.main.aspect >= 1.7) {
                transform.position = new Vector3 (Mathf.Clamp (AnxietyStatus.position.x, minX16_9, maxX16_9), Mathf.Clamp (AnxietyStatus.position.y, minY16_9, maxY16_9), transform.position.z);
            }
            else if (Camera.main.aspect > 1.3){
                transform.position = new Vector3(Mathf.Clamp(AnxietyStatus.position.x, minX4_3, maxX4_3), Mathf.Clamp(AnxietyStatus.position.y, minY4_3, maxY4_3), transform.position.z);
            }
        } else{
            if (Camera.main.aspect >= 1.7){
                transform.position = new Vector3(Mathf.Clamp(player.position.x, minX16_9, maxX16_9), Mathf.Clamp(player.position.y, minY16_9, maxY16_9), transform.position.z);
            }
            else if (Camera.main.aspect > 1.3){
                transform.position = new Vector3(Mathf.Clamp(player.position.x, minX4_3, maxX4_3), Mathf.Clamp(player.position.y, minY4_3, maxY4_3), transform.position.z);
            }

        }
	}

	IEnumerator Timer(){
		yield return new WaitForSeconds (5);
		AnxietyHUD.currentAnxiety = 9.9f;
	}
}
