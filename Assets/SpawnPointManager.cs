using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour {

    GameObject player;
    GameObject initialSpawnPoint;

	// Use this for initialization
	void Start () {

        initialSpawnPoint = GameObject.FindGameObjectWithTag("InitialSpawnPoint");

        player = GameObject.FindGameObjectWithTag("Player");

        player.transform.position = initialSpawnPoint.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
