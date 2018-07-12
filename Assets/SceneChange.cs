using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameObject.FindGameObjectsWithTag("enemy").Length <= 0)
        {
            Debug.Log("Loading " + "SampleCity");
            SceneManager.LoadScene("SampleCity");
        }
    }

  


}
