﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public static float speed;
	Transform m_transform;

	Animator m_ani;
	AnimatorStateInfo stateInfo;
	float x;
	// Use this for initialization
	void Start () {
		m_transform=this.transform;
		m_ani=GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		x=Input.GetAxis("Horizontal");

		stateInfo=m_ani.GetCurrentAnimatorStateInfo(0);

		if(stateInfo.nameHash==Animator.StringToHash("Base Layer.idle")&&!m_ani.IsInTransition(0)){
			    m_ani.SetBool("idle",false);
				if(x>0){
					m_ani.SetBool("rightwalk", true);
				}
				else if(x<0){
					m_ani.SetBool("leftwalk", true);
				}
		}
		if(stateInfo.nameHash==Animator.StringToHash("Base Layer.leftwalk")&&!m_ani.IsInTransition(0)){
			m_ani.SetBool("leftwalk",false);
			
			if(x<0){
				m_ani.SetBool("rightwalk", true);
			}
			if(x==0){
				m_ani.SetBool("idle", true);
			}
		}
		if(stateInfo.nameHash==Animator.StringToHash("Base Layer.rightwalk")&&!m_ani.IsInTransition(0)){
			m_ani.SetBool("rightwalk",false);
			 
			if(x<0){
				m_ani.SetBool("leftwalk", true);
			}
			if(x==0){
				m_ani.SetBool("idle", true);
			}
		}
		m_transform.Translate(new Vector3(x*Time.deltaTime*5,0,0));
	}
	void FixedUpdate(){
		m_transform.rigidbody2D.AddForce(new Vector2(0,-400));
	}
}
