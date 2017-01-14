using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCol : MonoBehaviour {
private GameObject CurrentTarget;
private GameObject[] CurrentTargets;
private Rigidbody2D TargetRig;
public bool DealsDamage = false;
[HideInInspector]
public float SwordDamage = 1f, VelocityDamageX, VelocityDamageY;

	void OnTriggerEnter2D (Collider2D Col)
	{
		// fill the GameObject CurrentTarget with a colliding object
		CurrentTarget = Col.gameObject;

		if (DealsDamage == true && CurrentTarget.CompareTag("Enemy")) {
			TargetRig = CurrentTarget.GetComponent<Rigidbody2D>();
			Health health = CurrentTarget.GetComponent<Health> ();
			if (health) {
				health.DealDamage(SwordDamage);
		// take in the Velocity that is on the health script of the enemy
				TargetRig.velocity = new Vector2 (VelocityDamageX, VelocityDamageY);

			return;
			}		

		}
	}
}