using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToPlayerPos : MonoBehaviour {
private Vector3 PlayerOriginPos;
private GameObject PlayerPos;
public float MovementSpeed = 2f;
public bool stickToPlayerPos = true;

	void Start() {
		PlayerPos = GameObject.FindGameObjectWithTag("Player");
		stickToPlayerPos = true;
}

	void Update ()
	{	
		if (stickToPlayerPos != false) {
			returnToPlayerPos ();
		}
}

void returnToPlayerPos () {
		//makes the object return to this vector3 (PlayerPos on X and the Y / Z can be ignored so they take the transform of the player object
		PlayerOriginPos = new Vector3 (PlayerPos.transform.position.x, transform.position.y, transform.position.z);
		// if the Origin  is different than the PlayerPos, move the player towards the origin
		if (transform.position != PlayerOriginPos ) {

			transform.position = Vector3.Lerp (transform.position, PlayerOriginPos, MovementSpeed * Time.deltaTime);
		} 
	}
}