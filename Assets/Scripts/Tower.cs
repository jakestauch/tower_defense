using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 30f;
    [SerializeField] ParticleSystem bullets;

    Transform targetEnemy;


    // Update is called once per frame
    private void Start()
    {
        bullets = gameObject.GetComponentInChildren<ParticleSystem>();
    }


    void Update () 
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy.transform);
            CheckForDistance();
        }
        else
            Shoot(false);
    }

    private void SetTargetEnemy()
    {
        var enemies = FindObjectsOfType<EnemyMovement>();
        if (enemies.Length == 0) { return; }

        Transform closestEnemy = enemies[0].transform;

        foreach (EnemyMovement testEnemy in enemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
        print(closestEnemy);
    }

    private Transform GetClosest(Transform closestEnemy, Transform testEnemy)
    {
        float distanceToClosestEnemy = Vector3.Distance(closestEnemy.position, gameObject.transform.position);
        float distanceToTestEnemy = Vector3.Distance(testEnemy.position, gameObject.transform.position);
        if (distanceToTestEnemy < distanceToClosestEnemy)
        {
            return testEnemy.transform;
        }
        else
        {
            return closestEnemy;
        }
    }

    private void CheckForDistance()
    {
        float distancetoEnemy = Vector3.Distance(targetEnemy.position, transform.position);

        if (distancetoEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
       
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = bullets.emission;
        emissionModule.enabled = isActive;
    }
}
