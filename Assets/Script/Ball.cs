using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public bool rightPaddleScore;
	public bool leftPaddleScore;
	public int rightCounter;
	public int leftCounter;
	//private GameObject player;
	//private GameObject computer;
	//private Vector3 paddleToBallPlayer;
	private bool hasStarted = false;
	private Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
		rightCounter = 0;
		leftCounter = 0;

		//paddleToBallPlayer = this.transform.position - player.transform.position;
		rigid = this.GetComponent<Rigidbody2D> ();

		rightPaddleScore = false;
		leftPaddleScore = false;
	}

	void OnCollisionEnter2D(Collision2D collision){
		Vector2 tweak = new Vector2 (Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));

		if (hasStarted) {
			rigid.velocity += tweak;
		}
		if(collision.gameObject.name == "leftScore"){
			rightPaddleScore = true;
			rightCounter++;
			Destroy (this);						//will this destroy GameObject???????? 
		}
		if (collision.gameObject.name == "rightScore") {
			leftPaddleScore = true;
			leftCounter++;
			Destroy (this);									//will this destroy GameObject????????
		}
	}
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			//this.transform.position = player.transform.position + paddleToBallPlayer;

			if (Input.GetMouseButtonDown (0)) {
				hasStarted = true;
				this.rigid.velocity = new Vector2 (-8f, 4f);
			}
		}
	}
}
