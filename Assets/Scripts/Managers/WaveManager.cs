using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

	public GameObject waves;
	private int wavesCount;
	public static int waveIndex = 0;
	float waveEnabledTimestamp = 0;
	private WaveController currentWaveController;
	bool runningWave = false;


	// Use this for initialization
	void Start () {
		wavesCount = waves.transform.childCount;
		initializeWaves ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= waveEnabledTimestamp + currentWaveController.lifeTime) {
			disableCurrentWave ();
			enableNextWave ();
		}
	}

	void initializeWaves () {
		Transform wave = waves.transform.GetChild (waveIndex);
		wave.gameObject.SetActive (true);
		currentWaveController = wave.GetComponent<WaveController> ();
		waveEnabledTimestamp = Time.time;
		runningWave = true;
	}

	void disableCurrentWave() {
		if (runningWave) {
			Transform wave = waves.transform.GetChild (waveIndex);
			wave.gameObject.SetActive (false);
			runningWave = false;
		}
	}

	void enableNextWave() {
		waveIndex++;
		if (waveIndex < wavesCount) {
			Transform wave = waves.transform.GetChild (waveIndex);
			wave.gameObject.SetActive (true);
			currentWaveController = wave.GetComponent<WaveController> ();
			waveEnabledTimestamp = Time.time;
			runningWave = true;
		} else {
			Debug.Log ("End Of Waves");
		}
	}
}
