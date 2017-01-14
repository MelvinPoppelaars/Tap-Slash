using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
public GameObject Enemy;
public float SpawnerCooldown = 2f;
	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnEnemies());
	}
	
	// cache the new wait for seconds if the seconds never change. This is cheaper
	
	IEnumerator SpawnEnemies ()
	{
	WaitForSeconds SpawnWait = new WaitForSeconds (SpawnerCooldown);
	// while true makes it loop
		while (true) {
			Instantiate (Enemy, transform.position, Quaternion.identity);
			yield return (SpawnWait);

		}
	}
}
