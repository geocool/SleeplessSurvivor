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
		initializeWaveAI ();
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

		updateWaveAI ();
	}

	enum WaveState {Small,Medium,Big,Boss};
	WaveState waveState;
	float waveSpawnRate = 1;
	float timer = 0;
	void initializeWaveAI () {
		changeWaveStateAI(WaveState.Small);

	}

	void updateWaveAI () {
		timer += Time.deltaTime;
		int remainingTime = getTimeUntilEndOfWave ();

		if (remainingTime == 15 && waveState != WaveState.Boss ) {
			changeWaveStateAI (WaveState.Boss);

		} else if (remainingTime > 15 && remainingTime % 15 == 0 && remainingTime != 75 && timer >= 1) {
			timer = 0;
			int randomState = Random.Range (0, 2);
			WaveState newState = 0;

			switch (waveState) {
			case WaveState.Small: 
				newState = randomState == 0 ? WaveState.Medium : WaveState.Big;
				break;
			case WaveState.Medium:
				newState = randomState == 0 ? WaveState.Small : WaveState.Big;
				break;
			case WaveState.Big:
				newState = WaveState.Small;
				break;
			default:
				Debug.LogError ("WaveState out of bounds");
				break;
			}

			changeWaveStateAI (newState);
		}
	}

	void changeWaveStateAI (WaveState state) {
		Debug.Log ("New Wave State: " + state.ToString ());
		waveState = state;

		switch (state) {
		case WaveState.Small: 
			waveSpawnRate = 5f;
			break;
		case WaveState.Medium:
			waveSpawnRate = 2.5f;
				break;
		case WaveState.Big:
			waveSpawnRate = 1.5f;
				break;
		case WaveState.Boss:
			waveSpawnRate = 1.5f;
				break;
			default:
				Debug.LogError ("WaveState out of bounds");
				break;
		}

		// Temporary
		Transform wave = waves.transform.GetChild (waveIndex);
		wave.gameObject.SetActive (true);
		currentWaveController = wave.GetComponent<WaveController> ();
		currentWaveController.changeSpawnTime (waveSpawnRate);
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
