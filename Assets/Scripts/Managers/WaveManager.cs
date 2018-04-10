using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

	public GameObject waves;
	private int wavesCount;
	private int waveIndex = 0;
	private float waveEnabledTimestamp = 0;
	private WaveController currentWaveController;
	[HideInInspector]
	public bool runningWave = false;
	public bool clearedWave = true;

	public delegate void OnWaveCleared(WaveController waveController);
	public event OnWaveCleared WaveClearedEvent;

	// Use this for initialization
	void Start () {
		wavesCount = waves.transform.childCount;
		initializeWaves ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {
		if (runningWave) {
			// Check if wave time ended
			if (Time.time >= waveEnabledTimestamp + currentWaveController.lifeTime) {
				disableCurrentWave ();
				//enableNextWave ();
			}


		} else if (!clearedWave) {
			
			if (currentWaveController.getRemainingEnemies () == 0) {
				clearedWave = true;
				if (WaveClearedEvent != null)
					WaveClearedEvent (currentWaveController);
			}
		}
	}

	void initializeWaves () {
		Transform wave = waves.transform.GetChild (waveIndex);
		wave.gameObject.SetActive (true);
		currentWaveController = wave.GetComponent<WaveController> ();
		waveEnabledTimestamp = Time.time;
		runningWave = true;
		clearedWave = false;
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
			clearedWave = false;
		} else {
			Debug.Log ("End Of Waves");
		}
	}

	public int getTimeUntilEndOfWave() {
		float secondsRemaining = currentWaveController.lifeTime + waveEnabledTimestamp - Time.time;
		return (int) (secondsRemaining < 0 ? 0 : secondsRemaining);
	}

	public int getWaveNumber () {
		return waveIndex + 1;
	}
}
