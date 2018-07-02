using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    int moneyDropChance;

    public int enemyHealth;
    public Slider healthSlider;

   // public Gunfire hurt;
    public GameObject hasGun;
    public Gunfire shooter;
    bool isColliding;
    public GameObject moneyPrefab;
    GameObject moneyClone;
    
    
    



    // Use this for initialization
    void Start()
    {
        
        
        hasGun = GameObject.FindGameObjectWithTag("Player");

        if(hasGun != null)
        {
            shooter = hasGun.GetComponent<Gunfire>();
            
        }

        
        
        

        enemyHealth = 100;
        Debug.Log("Enemy Health Set");

       

        
        
        




    }

    private void Awake()
    {
        moneyDropChance = Random.Range(1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = enemyHealth;
        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
            if(moneyDropChance >= 6)
            {
                Instantiate(moneyPrefab, transform.position, Quaternion.identity);
            }
        }

        isColliding = false;

    }

    private void OnTriggerEnter(Collider other)
    {

        
        isColliding = true;

        if(other.gameObject.tag == "bullet" && isColliding)
        {
            TakeDamage();
        }

        if(other.gameObject.tag == "powerbullet" && isColliding)
        {
            TakePowerDamage();
        }
    }




    void TakeDamage()
    {
        Debug.Log(shooter.damage + "damage");


        enemyHealth = enemyHealth - shooter.damage;
       
    }

    void TakePowerDamage()
    {
        Debug.Log(shooter.powerDamage + "damage");

        enemyHealth = enemyHealth - shooter.powerDamage;
    }


}
