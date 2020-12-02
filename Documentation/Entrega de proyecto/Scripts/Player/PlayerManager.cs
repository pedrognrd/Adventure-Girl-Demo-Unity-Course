using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private string playerName;
    [SerializeField]
    private int activeIconWeapon = 0;
    [SerializeField]
    private int activeWeapon = 0;
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private GameObject doorInside;
    private GameObject gameMenu;
    [SerializeField]
    private int health;
    [SerializeField]
    GameObject healthBar;
    [SerializeField]
    private GameObject[] IconWeapons;    
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private AudioClip openTheDoor;
    [SerializeField]
    GameObject endPanel;
    [SerializeField]
    GameObject panelMenu;
    [SerializeField]
    public int score;
    [SerializeField]
    private bool shield;     
    [SerializeField]
    public Text textChargers;
    [SerializeField]
    private GameObject[] weapons;
    private static PlayerManager _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        health = maxHealth;
        //doorInside = GameObject.Find("DoorInsideCollider");
        //doorInside.SetActive(false);
        ActivateWeapon(activeWeapon);
    }

    private void Update()
    {
        ChooseWeapon();
        Shoot();
        Recharge();
        door = GameObject.Find("Door");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Charger"))
        {
            int nc = other.gameObject.GetComponentInParent<GenericCharger>().numberChargers;
            weapons[activeWeapon].GetComponent<Weapon>().AddChargers(nc);
            Destroy(other.gameObject);
            GameObject.Find("SuitcaseCharger").GetComponent<GenericCharger>().PlayChargerTaken();
        }

        if (other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            GameObject.Find("ImageKey").GetComponent<Image>().color = Color.yellow;
            GameManager.hasKey = true;
            GameObject.Find("Door").GetComponent<Animator>().enabled = true;
            door.GetComponent<AudioSource>().PlayOneShot(openTheDoor);
            doorInside.SetActive(true);
            GameObject.Find("Key").GetComponent<Key>().PlayKeyTaken();
        }
        if (other.gameObject.CompareTag("Necronomicon"))
        {
            endPanel.SetActive(true);
            GameManager.hasNecronomicon = true;
        }
    }

    public void ActivateWeapon(int idArma)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == idArma)
            {
                weapons[i].SetActive(true);
                IconWeapons[i].SetActive(true);
                activeWeapon = i;
                activeIconWeapon = i;

                int chargers = weapons[i].GetComponent<Weapon>().chargers;
                int bullets = weapons[i].GetComponent<Weapon>().ammo;

                textChargers.text = "x" + chargers.ToString();
                //TextAmmo.text = bullets.ToString();
            }
            else
            {
                weapons[i].SetActive(false);
                IconWeapons[i].SetActive(false);
            }
        }
    }

    public void ChooseWeapon() {
        for (int i = 0; i <= weapons.Length; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                ActivateWeapon(i - 1);
            }
        }
    }

    public void DamageReceived(int danno)
    {
        health = health - danno;
        UpdateHealthBarAndBloodCanvas();
        if (health <= 0) { Dying(); }
    }

    public void Dying()
    {
        panelMenu.SetActive(true);
        GameObject.Find("GameManager").GetComponent<GameManager>().DoGameOver();
    }

    public bool HealthAtMax()
    {
        if (health >= maxHealth)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool HealthAtMin()
    {
        if (health >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void HealthRecovery(int incHealth)
    {
        health += incHealth;
        // Con esto controlamos que la salud no crezca por encima de maxHealth
        health = Mathf.Min(health, maxHealth);
        UpdateHealthBarAndBloodCanvas();
    }

    public void HealthReduction(int decHealth)
    {
        health -= decHealth;
        UpdateHealthBarAndBloodCanvas();
        if (health <= 0) { Dying(); }
    }

    public void Recharge()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            weapons[activeWeapon].GetComponent<Weapon>().Reload();
        }
    }
    
    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            weapons[activeWeapon].GetComponent<Weapon>().TryShoot();
        }
    }

    
    private void UpdateHealthBarAndBloodCanvas()
    {
        healthBar.GetComponent<Image>().fillAmount = health / ((float)maxHealth);
    }   
}
