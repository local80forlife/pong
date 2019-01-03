using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddlemove : MonoBehaviour {
	private Vector3 move;
	public Vector3 yPosition = new Vector3(0,3,0);
	private bool shouldMoveTop = true;
	private bool shouldMoveBottom = true;

	// Use this for initialization
	void Start () {
		move = new Vector3(8,0,-1);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("up")&&shouldMoveTop) {
			move += (yPosition*Time.deltaTime)*2;
			transform.position = move;
		}
		if (Input.GetKey ("down")&&shouldMoveBottom) {
			move -= (yPosition * Time.deltaTime)*2;
			transform.position = move;
		}
	}

	void OnCollisionStay2D(Collision2D collision){
		if (collision.gameObject.name == "topWall") {
			shouldMoveTop = false;
		} 
		if (collision.gameObject.name == "bottomWall") {
			shouldMoveBottom = false;
		}
	}
	void OnCollisionExit2D(Collision2D collision){
		shouldMoveTop = true;
		shouldMoveBottom = true;
	}
}
