using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendCol : MonoBehaviour {
private GameObject CurrentTarget;
public bool isDefending = false;

	// Use this for initialization
	void OnTriggerStay2D (Collider2D Col)
	{
		CurrentTarget = Col.gameObject;
		
		if (isDefending == true && CurrentTarget.CompareTag("Enemy")){
			EnemyTest enemy = CurrentTarget.GetComponent<EnemyTest>();
			enemy.IsParalyzed = true;
		}
	}
}