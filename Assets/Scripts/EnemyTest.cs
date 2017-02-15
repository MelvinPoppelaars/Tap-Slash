using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour {
public float movementSpeed = 2f, attackDamage = 10f, TimeParalyzed = 3f;
private float RandomSpeed, CurrentSpeed, Timer = 0;
private GameObject CurrentTarget;
private Rigidbody2D TargetRig;
private SpriteRenderer Sprite;
private Color Origin;

[HideInInspector]
public bool IsParalyzed = false;

	// Use this for initialization
	void Start () {
		IsParalyzed = false;
		RandomSpeed = Random.Range(0.5f,movementSpeed);
		CurrentSpeed = RandomSpeed;
		Sprite = GetComponentInChildren<SpriteRenderer>();
		Origin = Sprite.color;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log (Timer);
	
	//movement of player is determined by normal state (move) and paralyzed state (not moving) 
		if (!IsParalyzed) {
			Normal ();
			return;
		} else {
	
		// the timer starts counting when the enemy IsParalyzed
			Timer += Time.deltaTime;
			Paralyzed ();
			
			if (Timer >= TimeParalyzed) {
		// the timer gets reset when the timer has done its job and returns to the normal state
				Timer = 0f;
				IsParalyzed = false;
				Normal();
			}
		}
	}

	void OnCollisionStay2D (Collision2D col)
	{
		CurrentTarget = col.gameObject;
		Debug.Log (CurrentTarget + name);

		if (CurrentTarget.CompareTag ("Enemy")) {
			// ignores the collision of other enemies
			Physics2D.IgnoreCollision (CurrentTarget.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
		}
		
		//check if the Colliding Object is the Player
		if (CurrentTarget.CompareTag ("Player") && !IsParalyzed) {
			// check if the player has the health component
			TargetRig = CurrentTarget.GetComponent<Rigidbody2D> ();
			Health health = CurrentTarget.GetComponent<Health> ();
		
			if (health) {
				health.DealDamage (attackDamage);
				//adds velocity to the player rigidbody
				TargetRig.velocity = new Vector2 (-5f, -2f);
				
			}
		}
	}
		
	void Normal() {
	Sprite.color = Origin;
	transform.Translate (Vector2.left * (CurrentSpeed * Time.deltaTime));
	}

	void Paralyzed ()
	{
		Sprite.color = Color.green;
	}

}
