using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
public float health;

	public void DealDamage (float damage)
	{
		health -= damage;
		
		Debug.Log (health + name);
		
		if (health <= 0) {
			Destroy (gameObject);
		}
	}
}	
