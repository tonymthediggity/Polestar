using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int playerHealth;
    CharacterStats playersStats;
    GameObject player;

    public Slider healthSlider;
    public EnemyShoot shooter;
    public GameObject hasGun;

    public int playerTP;
    public Slider tpSlider;
    public Gunfire usesTP;
    public int tpCost;

   public int playerMoney;
    GameObject moneyPrefab;

    int damageResistance;

    public CameraShake cameraShake;

    


    // Use this for initialization
    void Start()
    {

        

        moneyPrefab = GameObject.FindGameObjectWithTag("Money");

        


        player = GameObject.FindGameObjectWithTag("Player");

        playersStats = GetComponentInParent<CharacterStats>();

        playerHealth = playersStats.maxHealth;

        playerTP = playersStats.maxTP;

        
        

        
        Debug.Log("Player Health:" + playerHealth);

        healthSlider.value = playerHealth;

        
        Debug.Log("Player TP:" + playerTP);

        hasGun = GameObject.FindGameObjectWithTag("enemy");

        if (hasGun != null)
        {
            shooter = hasGun.GetComponent<EnemyShoot>();
        }

        

        


    }

    // Update is called once per frame
    void Update()
    {

       


        

        
           damageResistance = playersStats.damageResist.GetValue();
        
       
            healthSlider.value = playerHealth;
        tpSlider.value = playerTP;
         

        if (playerHealth < 1)
        {

            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 0;
        }

        

        
    }




    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemybullet"))
        {
            StartCoroutine(cameraShake.Shake(.15f, .4f));
            playerHealth = playerHealth - (shooter.damage - damageResistance);
        }
    }
}
