using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

private Animator anim;
private Vector3 playerOriginPos; // the transform of the playerPos GameObject;
public float MovementSpeed = 2f;
private Rigidbody2D PlayerRig;
public static bool CanDealDamage = false;

	void Awake () {

		anim = GetComponent<Animator>();
		PlayerRig = GetComponentInChildren<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		MovementSpeed = MovementSpeed * Time.deltaTime;
		transform.Translate (Vector2.right * MovementSpeed);

		if (Input.GetKeyDown(KeyCode.Space)) {
			anim.Play("TestSword");
		}

		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			anim.Play("TestUp");
		}

		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			anim.Play("TestMoveLeft");
		}
		
	}

// by moving the player with velocity rather than animation, the player can break out of a certain move without breaking the movement in all directions
	public void AddVelocity (float VelocityY) {
		PlayerRig.velocity = new Vector2 (0f, VelocityY);
	}
}
