using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour {

    public int money = 0;
    Transform playerPos;
    public bool canInteract;
    public float radius = 2f;
    GameObject player;
    PlayerHealth hasPlayerMoney;
    public Text moneyText;
    


	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
        hasPlayerMoney = player.GetComponent<PlayerHealth>();

        moneyText = GameObject.FindGameObjectWithTag("UIMoneyText").GetComponent<Text>();
        
        

        

        


        
        

        

        

     
		
	}
	
	// Update is called once per frame
	void Update () {

        

        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        float distance = Vector3.Distance(playerPos.position, transform.position);
        if (distance <= radius)
        {
            canInteract = true;

        }
        else
        {
            canInteract = false;
        }

        if (canInteract && Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }


    }

    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Picking  up " + money);
            hasPlayerMoney.playerMoney= hasPlayerMoney.playerMoney + money;
            moneyText.text = "Money: " + hasPlayerMoney.playerMoney.ToString();
            Destroy(gameObject);
        }
    }
}
