using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {
	private GameObject ball; 
	private bool shouldMoveUp;
	private bool shouldMoveDown;
	private Vector3 paddleLoc;
	private Vector3 speed;


	// Use this for initialization
	void Start () {
		ball = GameObject.Find ("ball");
		//the 'y' unit is the speed of the paddle
		speed = new Vector3(0, 3.6f, 0);
		paddleLoc = new Vector3 (-8, 0, -1);
		//if the paddle is touching the top or bottom walls the bool expression changes accordingly
		shouldMoveUp = true;
		shouldMoveDown = true;

	}

	// Update is called once per frame
	void Update () {

		if (shouldMoveUp && transform.position.y < ball.transform.position.y) {
			paddleLoc.y += speed.y * Time.deltaTime;
			transform.position = paddleLoc;
		} else if (shouldMoveDown && transform.position.y > ball.transform.position.y) {
			paddleLoc.y -= speed.y * Time.deltaTime;
			transform.position = paddleLoc;
		} 
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.name == "topWall") {
			shouldMoveUp = false;
		} else if (collision.gameObject.name == "bottomWall") {
			shouldMoveDown = false;
		}
	}
	void OnCollisionExit2D(){
		shouldMoveUp = true;
		shouldMoveDown = true;
	}
}
