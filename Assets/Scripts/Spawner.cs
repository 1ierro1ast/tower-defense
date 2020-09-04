using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public int WaveSize;
	public GameObject EnemyPrefab;
	public Transform spawnPoint;
	public Transform[] targets;
    public GameObject hp;
    public GameObject gold;
    public GameObject canvas;
    public WaveScript wave;

	int enemyCounter = 0;

    void Start(){
        spawnPoint = transform;
    }

    public void StartWave(float StartSpawnTime, float EnemyInterval){
        InvokeRepeating("EnemySpawn", StartSpawnTime, EnemyInterval);
    }

    void EnemySpawn(){
    	enemyCounter++;
    	GameObject enemy = GameObject.Instantiate(EnemyPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
    	enemy.GetComponent<MobScript>().targets = targets;
        GameObject tempHp = GameObject.Instantiate(hp, Vector3.zero, Quaternion.identity) as GameObject;
        tempHp.transform.SetParent(canvas.transform);
        tempHp.GetComponent<Hp>().enemy = enemy;
        enemy.GetComponent<MobScript>().hp = tempHp;
        enemy.GetComponent<MobScript>().gold = gold;
    }

    void Update(){
        
    	if(enemyCounter == WaveSize){
            if (wave.currentWave < wave.maxWave){
                wave.currentWave += 1;
            }
            
    		CancelInvoke("EnemySpawn");
            Destroy(gameObject);
    	}
    }
}
