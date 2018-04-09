using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShowLaser : MonoBehaviour {
	
	int shootableMask;
	LineRenderer gunLaser;
	public float range = 100f;
	public Material activeMaterial;
	public Material idleMaterial;

	// Use this for initialization
	void Start () {
		gunLaser = GetComponent<LineRenderer>();
		shootableMask = LayerMask.GetMask ("Shootable");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {
		if (ControlsManager.controllerEnabled) {
			if (Input.GetAxisRaw ("ShowLaser") > 0) {
				showLaser ();
			} else {
				gunLaser.enabled = false;
			}
		}
	}

	void showLaser() {
		gunLaser.enabled = true;
		gunLaser.SetPosition (0, transform.position);
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit castHit;
		if (Physics.Raycast (ray, out castHit, range, shootableMask)) {
			gunLaser.SetPosition (1, castHit.point);
			EnemyHealth enemyHealth = castHit.collider.GetComponent <EnemyHealth> ();
			if (enemyHealth != null)
				gunLaser.material = activeMaterial;
			else
				gunLaser.material = idleMaterial;
		} else {
			gunLaser.SetPosition (1, ray.origin + ray.direction * range);
			gunLaser.material = idleMaterial;
		}
	}
}
