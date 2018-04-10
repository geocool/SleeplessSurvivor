using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour {

	public GameObject holdingGem;
	private GameObject gemDirectory;

	private EnemyHealth enemyHealth;

	void Start () {
		enemyHealth = GetComponent<EnemyHealth> ();
		enemyHealth.enemyDiedEvent += dropGem;
		gemDirectory = GameObject.Find ("Gems");
	}

	void dropGem () {
		Vector3 position = transform.position;
		position.y = 0;
		GameObject newGem = Instantiate (holdingGem, position, Quaternion.identity);
		newGem.transform.parent = gemDirectory.transform;
	}
}
