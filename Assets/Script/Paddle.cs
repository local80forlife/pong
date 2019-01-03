using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	private GameObject ball;
	private int playerSpeed;
	private float computerSpeed;
	private Vector3 paddleY;
	private bool moveUp;
	private bool moveDown;

	// Use this for initialization
	void Start () {
		ball = GameObject.Find ("ball(Clone)");

		playerSpeed = 3; //add to paddle location to move
		computerSpeed = 3.5f; //add to paddle location to move 
		paddleY = new Vector3(-8, 0, -1); //player speed * Timedelta then add or subtracted from position

		moveUp = true; //is it touching the top wall
		moveDown = true; //is it touching the bottom wall
	}
	
	// Update is called once per frame
	void Update () {
		if (this.tag == "Player1") {
			if (Input.GetKey ("up") && moveUp) {
				paddleY.x = 8;
				paddleY.y += playerSpeed * Time.deltaTime;
				this.transform.position = paddleY;
			} else if (Input.GetKey ("down") && moveDown) {
				paddleY.x = 8;
				paddleY.y -= playerSpeed * Time.deltaTime;
				this.transform.position = paddleY;
			}
		} else if (this.tag == "Player2") {
			if (Input.GetKey ("w") && moveUp) {
				paddleY.y += playerSpeed * Time.deltaTime;
				this.transform.position = paddleY;
			} else if (Input.GetKey ("s") && moveDown) {
				paddleY.y -= playerSpeed * Time.deltaTime;
				this.transform.position = paddleY;
			}
		} else if (this.tag == "Computer") {
			if (moveUp && transform.position.y < ball.transform.position.y) {
				paddleY.y += computerSpeed * Time.deltaTime;
				this.transform.position = paddleY;
			} else if (moveDown && transform.position.y > ball.transform.position.y) {
				paddleY.y -= computerSpeed * Time.deltaTime;
				this.transform.position = paddleY;
			} 
		}
	}
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.name == "topWall") {
			moveUp = false;
		} else if (collision.gameObject.name == "bottomWall") {
			moveDown = false;
		}
	}
	void OnCollisionExit2D(){
		moveUp = true;
		moveDown = true;
	}
}
