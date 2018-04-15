using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCameraController : MonoBehaviour {

    public Camera mainCamera;

    private void OnEnable()
    {
        mainCamera.enabled = false;
    }

    private void OnDisable()
    {
        mainCamera.enabled = true;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
