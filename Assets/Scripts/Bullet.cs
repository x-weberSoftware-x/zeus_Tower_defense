﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
    private Transform target;

    public float speed = 50f;

    public void AimBullet(Transform _target)
    {
        target = _target;
    }

	void Update () 
	{
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        float distanceTravelled = speed * Time.deltaTime;

        if(dir.magnitude <= distanceTravelled)
        {
            HitEnemy();
        }

        transform.Translate(dir.normalized * distanceTravelled, Space.World);
	}

    void HitEnemy()
    {
        PlayerStats.souls += 10;
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}