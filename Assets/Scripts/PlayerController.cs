﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	public float moveSpeed = 5f;
	Vector2 moveVector = new Vector2 (0f, 0f);
	Rigidbody2D myRigidbody;

	void Start ()
	{
		myRigidbody = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update ()
	{
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		moveVector = new Vector2 (horizontal, vertical);
		if (moveVector.magnitude > 1f) {
			moveVector = moveVector.normalized; // better way of normalization
		}
			
		Vector3 cursorPositionInWorld = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		cursorPositionInWorld.z = 0;
		Vector3 point = transform.position - cursorPositionInWorld;
		transform.up = point * Time.deltaTime;

	}

	// FixedUpdate is when Physics runs
	void FixedUpdate ()
	{
		myRigidbody.velocity = moveVector * moveSpeed;
	}



}
