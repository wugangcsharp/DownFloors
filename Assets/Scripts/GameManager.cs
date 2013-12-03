using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static float speed;
	float timer=60;

	float speedControl;
	float score;

	GUIText txt_Score;
	// Use this for initialization
	void Start () {
		speed=1;
		score=0;
		txt_Score=GameObject.Find("txt_Score").GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
		 
		timer-=Time.deltaTime;
		if(timer<=0){
			timer=60f;
			speed+=Time.deltaTime;
		}
		score++;
		speedControl++;
		txt_Score.text="得分"+score.ToString();
		if(speedControl>=500){
			speedControl=0;
			speed+=0.3f;
		}
	}
}
