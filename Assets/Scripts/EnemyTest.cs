using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour {
public float movementSpeed = 2f, attackDamage = 10f;
private float RandomSpeed;
private GameObject CurrentTarget;
private Rigidbody2D TargetRig;
	// Use this for initialization
	void Start () {
		RandomSpeed = Random.Range(0.5f,movementSpeed) * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.left * RandomSpeed;
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		CurrentTarget = col.gameObject;
		Collider2D target = CurrentTarget.GetComponent<Collider2D> ();
		Collider2D obj = gameObject.GetComponent<Collider2D> ();
		Debug.Log(CurrentTarget + name);

		if (CurrentTarget.CompareTag ("Enemy")) {
			// ignores the collision of other enemies
			Physics2D.IgnoreCollision (target, obj);
		}
// compare tag with damage tags (all objects that damage the enemy) and give force to rigidbody of this object
// the amount of force on the rigidbody should be compared with the amount of damage the enemy has taken in within a combo
		if (CurrentTarget.CompareTag ("Player")) {
			// check if the player has the health component
			TargetRig = CurrentTarget.GetComponent<Rigidbody2D>();
			Health health = CurrentTarget.GetComponent<Health> ();
			if (health) {
				health.DealDamage (attackDamage);
			// adds velocity to the player rigidbody
				TargetRig.velocity = new Vector2 (-5f,-2f);
			}
		}
	}
	// fucntion for later when damage needs to be dealt when the enemy is attacking instead of onCollision
	public void DealDamage() {
	}
		
}
