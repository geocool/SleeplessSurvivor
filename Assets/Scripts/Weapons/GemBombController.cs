using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBombController : MonoBehaviour {

	public float timeAlive = 1f;
	public int bombDamage = 80;
	float timer = 0;
	Animator animator;
	AudioSource bombSound;
	bool exploded = false;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();	
		bombSound = GetComponent<AudioSource> ();
	}
		
	void FixedUpdate() {
		timer += Time.deltaTime;

		if (!exploded && timer >= timeAlive) {
			explode ();
		}
	}

	void explode () {
		Debug.Log( "Enabled: " + bombSound.enabled);
		bombSound.Play ();
		animator.SetTrigger ("Explode");
		exploded = true;
		Destroy (gameObject,1f);
	}

	void OnTriggerEnter(Collider other) {
		// if other is enemy big damage
		EnemyHealth enemyHealth = other.GetComponent <EnemyHealth> ();
		if(enemyHealth != null && exploded)
		{
			enemyHealth.TakeDamage (bombDamage, Vector3.zero);
		}
	}
}
