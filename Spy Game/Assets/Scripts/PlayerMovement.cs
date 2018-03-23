using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 velocity = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		GetComponent<Rigidbody2D> ().velocity = velocity * speed;
	}
}
