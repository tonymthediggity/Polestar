using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public float timeBtwShots;
    public float startTimeBtwShots;
    GameObject bulletClone;
    public GameObject bulletPrefab;
    public GameObject firePoint;

    public int damage;


    

    private void Start()
    {
        timeBtwShots = startTimeBtwShots;
        
    }

    private void Update()
    {
        if(timeBtwShots <= 0 && (gameObject.GetComponent <EnemyFollow> ().isFacing))
        {
            Shoot();
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
        timeBtwShots = Random.Range(0.5f, 2f);
    }
}

