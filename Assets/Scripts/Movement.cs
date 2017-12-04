using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	// Use this for initialization

	public float speed = 2f;

	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidBody;


	void Awake()
	{
		anim = GetComponent<Animator> ();
		playerRigidBody = GetComponent<Rigidbody> ();

	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move (h, v);
		Animating (h, v);

	}

	void Move( float h, float v)
	{
			movement.Set (h, 0f, v);

			movement = movement.normalized * speed * Time.deltaTime;

			playerRigidBody.MovePosition (transform.position + movement);

			if (h == -1) {
				playerRigidBody.transform.rotation = Quaternion.AngleAxis (0, Vector3.up);
			} else if (h == 1) {
				playerRigidBody.transform.rotation = Quaternion.AngleAxis (180, Vector3.up);
			}

	}

	void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;
		bool facingNorth = v != -1f;
		anim.SetBool ("IsWalking", walking);
		if (v != 0) 
		{
			anim.SetBool ("IsFacingNorth", facingNorth);
		}
	}

}
