using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{





    public bool isFacing = false;

    public float fireRate;

    public float movementSpeed;
    public float distanceFromTarget;
    public float distanceToTarget;
    public float maxDistance;
    public float minDistance;
    public float dodgeDir;
    public float dodgeTimer;

    public Rigidbody body;




    public float speed;

    Transform player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        body = GetComponent<Rigidbody>();



    }

    private void Awake()
    {
        dodgeTimer = Random.Range(0.1f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {



        Vector3 distance = player.position - transform.position;
        Vector3 direction = distance.normalized;
        Vector3 velocity = direction * movementSpeed;

        dodgeTimer -= Time.deltaTime;
        if(dodgeTimer <= 0 && isFacing)
        {
            dodgeTimer = Random.Range(0.1f, 3.0f);
            Dodge();
        }

        








        distanceToTarget = distance.sqrMagnitude;


        if (distanceToTarget < distanceFromTarget)
        {

            MoveAt();




        }
        else
        {
            isFacing = false;
        }

        if(distanceToTarget >= distanceFromTarget * 0.5 && isFacing)
        {
            MoveFrom();
        }

        if (isFacing)
        {
            distanceFromTarget = 5000;
        }



















    }

    

    void MoveAt()
    {

        transform.LookAt(player.position);
        isFacing = true;


        body.AddForce(transform.forward * movementSpeed * 2 * Time.deltaTime );

        

    }

    void MoveFrom()
    {
        
        transform.LookAt(player.position);
        body.AddForce(-transform.forward * movementSpeed * Time.deltaTime);

       

    }

   void Dodge()
    {
        dodgeDir = Random.Range(-1, 1);


        if(dodgeDir == -1)
        {
            body.AddForce(Vector3.left * 500);
        }


        if(dodgeDir == 1)
        {
            body.AddForce(Vector3.right * 500);
        }

       /* if(dodgeDir == 0)
        {
            body.AddForce(Vector3.forward * 200);
        }*/
    }
}

       
















    