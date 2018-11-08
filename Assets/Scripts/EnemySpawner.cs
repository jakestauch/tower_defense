using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] float secondsBetweenSpawns = 2.0f;
    [SerializeField] EnemyMovement enemy;
    [SerializeField] int maxEnemies = 5;
    int numberOfEnemies;

	// Use this for initialization
	void Start () 
    {
        numberOfEnemies = 0;
        StartCoroutine(SpawnEnemies());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SpawnEnemies()
    {
        while (numberOfEnemies <= maxEnemies)
        {
            Instantiate(enemy, transform);
            numberOfEnemies = numberOfEnemies + 1;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
