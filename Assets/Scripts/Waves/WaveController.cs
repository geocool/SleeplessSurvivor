using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaveController : MonoBehaviour {

	public float lifeTime = 120f;
	public float timeBetweenEnemies = 3f;
	public GameObject spawnPoints;
	private int spawnPointsCount;


	[System.Serializable]
	public class Enemy
	{
		public GameObject prefab;
		[Range(0f,1f)]
		public float spawnRate;
	}

	public GameObject enemiesDirectory;
	public Enemy[] enemies;


	void OnEnable() {
		InvokeRepeating ("spawnEnemy", 3f, timeBetweenEnemies);
		spawnPointsCount = spawnPoints.transform.childCount;
	}

	void OnDisable() {
		CancelInvoke();
	}


	void spawnEnemy () {
		// Select Enemy based on rate
		int randomValue = calculateRandomEnemyMax ();
		int spawnPointIndex = Random.Range (0, spawnPointsCount);
		GameObject enemyPrefab = getRandomEnemyPrefab (randomValue);
		GameObject newEnemy = Instantiate (enemyPrefab, spawnPoints.transform.GetChild(spawnPointIndex).position, spawnPoints.transform.GetChild(spawnPointIndex).rotation);
		newEnemy.transform.parent = enemiesDirectory.transform;
	}
		

	int calculateRandomEnemyMax() {
		int randomMax = 0;
		foreach(Enemy enemy in enemies) {
			randomMax += (int) (enemy.spawnRate * 100);
		}
		return Random.Range(0,randomMax);
	}

	GameObject getRandomEnemyPrefab(int randomValue) {
		int randomValueIndex = 0;
		foreach (Enemy enemy in enemies) {
			if (randomValue <= enemy.spawnRate * 100 + randomValueIndex) {
				return enemy.prefab;
			} else {
				randomValueIndex += (int) (enemy.spawnRate * 100);
			}
		}

		Debug.LogError ("Random enemy process failed");
		return null;
	}
}
