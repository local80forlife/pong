using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour {
	public GameObject paddle1; //Prefabs
	public GameObject paddle2; //Prefabs
	public GameObject ball; //Prefabs
	public GameObject rightScore; // right Score GUI
	public GameObject leftScore; //left score GUI 

	private Text leftScoreText; //GUI text component
	private Text rightScoreText; //GUI text component
	private int leftScoreInt = 0;
	private int rightScoreInt = 0;

	private bool right_paddle_score; //Imported from Ball Script: if true paddle scored a point
	private bool left_paddle_score; ///Imported from Ball Script: if true paddle scored a point
	private int left_counter;
	private int right_counter;
	private bool singlePlayer = true;

	//if true set the ball on the right paddle, else place the ball on the left paddle
	private bool ballOnRightPaddle = true;

	// Use this for initialization
	void Start () {
		//access the ball script, create a local variable of the bool if one of the paddles scored
		right_paddle_score = ball.GetComponent<Ball>().rightPaddleScore;
		left_paddle_score = ball.GetComponent<Ball> ().leftPaddleScore;
		left_counter = ball.GetComponent<Ball> ().leftCounter;
		right_counter = ball.GetComponent<Ball> ().rightCounter;

		//these variable prints to the GUI score
		leftScoreText = leftScore.GetComponent<Text>();
		rightScoreText = rightScore.GetComponent<Text>();
		leftScoreText.text = "0";
		rightScoreText.text = "0";

		//starts the game on the right paddle
		CreateBall (ballOnRightPaddle);

		//creates the paddles on screen
		Instantiate (paddle1, new Vector3 (8, 0, -1), Quaternion.identity);
		paddle1.tag = "Player1";

		if (singlePlayer) {
			Instantiate (paddle2, new Vector3 (-8, 0, -1), Quaternion.identity);
			paddle2.tag = "Computer";
		} else {
			Instantiate (paddle2, new Vector3 (-8, 0, -1), Quaternion.identity);
			paddle2.tag = "Player2";
		}
	}
	
	// Update is called once per frame
	void Update () {
		//if the paddle scored add a point to the GUI and set the _paddle_score back to false
		if (right_paddle_score) {
			Debug.Log (right_paddle_score);
			rightScoreInt += 1;
			rightScoreText.text = rightScoreInt.ToString ();
			right_paddle_score = false;
			CreateBall (ballOnRightPaddle = false); //create the ball on the left paddle
		} else if (left_paddle_score) {
			Debug.Log (left_paddle_score);
			leftScoreInt += 1;
			leftScoreText.text = leftScoreInt.ToString ();
			left_paddle_score = false;
			CreateBall (ballOnRightPaddle = true);
		}
	}

	//Create the ball on the paddle instead of the generic placement
	void CreateBall(bool ballOnRightSide){
		if (ballOnRightSide) {
			Instantiate (ball, new Vector3 (7.63f, 0, -1), Quaternion.identity);
		} else {
			Instantiate (ball, new Vector3 (-7.63f, 0, -1), Quaternion.identity);
		}
	}
}
