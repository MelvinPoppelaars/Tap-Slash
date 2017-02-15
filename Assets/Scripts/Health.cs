using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
public float health;
private bool HitEnabled = true;
private SpriteRenderer Sprite;
private Color color;
public GameObject UIcanvas;
private Slider Healthbar;

	
	void Awake() {
		Sprite = GetComponentInChildren<SpriteRenderer>();
		color = Sprite.color;
		Healthbar = UIcanvas.GetComponentInChildren<Slider>();
		UIcanvas.SetActive(false);

	}

	void Start() {

		HitEnabled = true;
		Healthbar.minValue = 0f;
		Healthbar.maxValue = health;
		Healthbar.value = health;

	}

	public void DealDamage (float damage)
	{
		if (HitEnabled == true) {
			UIcanvas.SetActive(true);
			health -= damage;
			Healthbar.value = health;

			StartCoroutine (TargetHit());
		}

		Debug.Log (health + name);
		
		if (health <= 0) {
			Destroy (gameObject);
		}
	}

	IEnumerator TargetHit() {
		HitEnabled = false;
		Sprite.color = Color.red;
		yield return new WaitForSeconds (0.25f);
		Sprite.color = color;
		HitEnabled = true;

	}

}	
