using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemManager : MonoBehaviour {

	public static uint gemsCount = 0;
	private GameObject gemPrefab;
	public GameObject gemDirectory;

	// Use this for initialization
	void Start () {
		gemPrefab = Resources.Load("PinkGemHolder", typeof(GameObject)) as GameObject;
	}

	public void createAtPosition(Vector3 position) {
		position.y = 0;
		GameObject newGem = Instantiate (gemPrefab, position, Quaternion.identity);
		newGem.transform.parent = gemDirectory.transform;
	}

	public void collect(GameObject gem) {
		AudioSource collectSound = gem.GetComponent<AudioSource>();
		Animator animator = gem.GetComponent<Animator> ();
		animator.SetTrigger ("Collect");
		collectSound.Play();
		Destroy (gem.transform.parent.gameObject, 0.50f);
		gemsCount++;
	}
}
