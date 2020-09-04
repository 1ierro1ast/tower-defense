using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveScript : MonoBehaviour
{
    public int currentWave;
    public int maxWave;
    public Vector3 firstSpawnerPosition;
    public Vector3 secondSpawnerPosition;
    public GameObject mobSpawnerPrefab;
    public Text waveText;
    public Transform[] targets;
    public GameObject gold;
    public GameObject canvas;

	int prevWave;

	void CreateSpawner(Vector3 spawnPosition, int WaveSize, float StartSpawnTime, float EnemyInterval){
		GameObject spawner = GameObject.Instantiate(mobSpawnerPrefab, spawnPosition, Quaternion.identity) as GameObject;
        spawner.GetComponent<Spawner>().WaveSize = WaveSize;
        spawner.GetComponent<Spawner>().StartWave(StartSpawnTime,EnemyInterval);
        spawner.GetComponent<Spawner>().targets = targets;
        spawner.GetComponent<Spawner>().gold = gold;
        spawner.GetComponent<Spawner>().canvas = canvas;
        spawner.GetComponent<Spawner>().wave = this;
	}

    void Update()
    {
    	waveText.text = "Wave: " + currentWave.ToString();
        Debug.Log(prevWave);
        if (currentWave == 0){
    		currentWave += 1;
    	}
    	Debug.Log(currentWave);
        if (currentWave == prevWave + 1){
        	Debug.Log("New Wave!");
            prevWave = currentWave;
            switch (currentWave){
                case 1:
                	CreateSpawner(firstSpawnerPosition, 10, 5f, 3f);
                    break;
                case 2:
                    CreateSpawner(firstSpawnerPosition, 8, 5f, 3f);
                    CreateSpawner(secondSpawnerPosition, 8, 7f, 3f);
                    break;
                case 3:
                	CreateSpawner(firstSpawnerPosition, 10, 5f, 1f);
                	CreateSpawner(secondSpawnerPosition, 10, 7f, 2f);
                    break;
                default:
                    break;
            }
        }
    }
}
