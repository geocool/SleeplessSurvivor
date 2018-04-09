using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBombing : MonoBehaviour {

	public float timeBetweenBombs = 0.5f;
	public int manaPerBomb = 25;
	float timer = 0;
	PlayerMana playerMana;

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		playerMana = player.GetComponent <PlayerMana> ();


	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;


		if (Input.GetButton("Fire2") && timer >= timeBetweenBombs && playerMana.hasEnoughtMana(manaPerBomb)) {
			dropBomb ();
		}
	}

	void dropBomb(){
		playerMana.useMana (manaPerBomb);
		GameObject bomb = Resources.Load ("GemBomb") as GameObject;
		Vector3 bombPosition = transform.position;// + new Vector3 (0f, 0f, -2f);
		bombPosition.y = 0.4f;
		Instantiate (bomb, bombPosition, Quaternion.identity);
		timer = 0;
	}
}
