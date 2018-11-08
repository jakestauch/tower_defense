using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {

    [SerializeField] Collider collisionMesh;
    [SerializeField] int healthPoints = 20;
    [SerializeField] int hitPoints = 1;

    // Use this for initialization
    void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (healthPoints < 0)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        healthPoints = healthPoints - hitPoints;
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }

}
