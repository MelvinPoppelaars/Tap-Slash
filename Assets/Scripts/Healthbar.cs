using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Healthbar : MonoBehaviour {

private Image healthbar;
private Health health;
	
	void Awake() {
	health = GetComponentInParent<Health>();
	healthbar = GetComponent<Image>();
	
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		healthbar.fillAmount = health.health; 		

	}
}
