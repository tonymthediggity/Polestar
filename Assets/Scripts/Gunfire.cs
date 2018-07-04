//Attach this script to your Camera
//This draws a line in the scene view going through a point 200 pixels from the lower-left corner of the screen
//To see this, enter Play Mode and switch to the Scene tab. Zoom into your Camera's position.
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gunfire : MonoBehaviour
{
    Camera cam;
    public Texture2D crossHair;
    public GameObject bulletPrefab;
    GameObject bulletClone;
    public GameObject firePoint;
    RaycastHit hit;
    public float speed;
    public int damage;
    public int powerDamage;
    public int powerSpeed;

    public GameObject powerBulletPrefab;
    GameObject powerBulletClone;

    public int maxCombo;
    public int comboCount;
    public float coolDown;
    public float coolDownTimer;
    public Text coolDownText;
    public float coolDownRestTimer;

    public Text counter;
    public PlayerHealth usesTp;
    public Text tpError;
    public float tpErrorTimer = 0;

    CharacterStats statsDamage;
    GameObject player;










    void Start()
    {


        player = GameObject.FindGameObjectWithTag("Player");
        statsDamage = GetComponentInParent<CharacterStats>();
        
        
       

        cam = FindObjectOfType <Camera>();
        firePoint = GameObject.FindGameObjectWithTag("PFP");
        hit = new RaycastHit();

        coolDownTimer = 0;
        coolDownRestTimer = 0;

        usesTp = GetComponentInParent<PlayerHealth>();
       

        

       

       

        

    }

    void Update()
    {
        //  Ray ray = cam.ScreenPointToRay(new Vector3(200, 200, 0));



        damage = statsDamage.damage.GetValue();
        powerDamage = statsDamage.powerDamage.GetValue();





        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
            
        }

        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }

        if(coolDownRestTimer > 3)
        {
            comboCount = 0;
            coolDownRestTimer = 0;
        }

        counter.text = comboCount.ToString ();

        coolDownText.text = coolDownTimer.ToString("N1");

        




        // Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

        if (Input.GetButtonDown("Fire1") && coolDownTimer == 0)
        {
            Ray ray = GetComponentInChildren<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) { 

            bulletClone = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity) as GameObject;
            bulletClone.GetComponent<Rigidbody>().velocity = (hit.point - transform.position).normalized * speed;

            Destroy(bulletClone, 3);

                comboCount++;
                
                
            }



        }

        

        if(comboCount > 0)
        {
            coolDownRestTimer = coolDownRestTimer + Time.deltaTime;
        }

        if (comboCount >= maxCombo)
        {
            coolDownTimer = coolDown;
        }

        if(coolDownTimer != 0 && comboCount >= maxCombo)
        {
            comboCount = 0;
        }

       

        if (Input.GetButtonDown("Fire2") && coolDownTimer == 0 && usesTp.playerTP >= usesTp.tpCost)
        {
            PowerAttack();

        }

        if(Input.GetButtonDown("Fire2") && usesTp.playerTP <= 0){

            tpError.enabled = true;
            




        }

        if (tpErrorTimer >= 0.5)
        {
            tpError.enabled = false;
            tpErrorTimer = 0;
        }

        if (tpError.enabled == true)
        {
            tpErrorTimer = tpErrorTimer + Time.deltaTime;
        }







    }
    private void OnGUI()
    {
        float xMin = Screen.width - (Screen.width - Input.mousePosition.x) - (crossHair.width / 2);
        float yMin = (Screen.height - Input.mousePosition.y) - (crossHair.height / 2);
        GUI.DrawTexture(new Rect(xMin, yMin, crossHair.width, crossHair.height), crossHair);

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Player"))
        {

        }
    }

    void PowerAttack() {

         Ray ray = GetComponentInChildren<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {

                powerBulletClone = Instantiate(powerBulletPrefab, firePoint.transform.position, Quaternion.identity) as GameObject;
                powerBulletClone.GetComponent<Rigidbody>().velocity = (hit.point - transform.position).normalized * powerSpeed;

                Destroy(powerBulletClone, 3);

                comboCount++;
            usesTp.playerTP = usesTp.playerTP - usesTp.tpCost;
                
            }

        }

    

    }
