using UnityEngine;
using System.Collections;

public class Terrain : MonoBehaviour {

	Transform player;
	Transform m_transform;
	// Use this for initialization
	void Start () {
		m_transform=this.transform;
		player=GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update () {
		//地形向上移动
		m_transform.Translate(new Vector3(0,GameManager.speed*Time.deltaTime,0));

		if(m_transform.position.y>=5.59863f){

			float x,y;
			//大小
			x=Random.Range(0.3f,1f);
			m_transform.localScale=new Vector3(x,m_transform.localScale.y,0);
			
			//位置
			x=Random.Range(-6.5f,8);
			y=-6;
			m_transform.position=new Vector3(x,y,0);
			this.collider2D.enabled=true;
		}
	}

	void FixedUpdate(){
		if(player.position.y-0.5f<=m_transform.position.y){
			this.collider2D.enabled=false;
		}
	}

	 
}
