using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Health : MonoBehaviour
{

    public Slider HealthBar;
    public float MaxHealth;
    public float CurrentHealth;

    public Slider ArmorBar;
    public float MaxArmor;
    public float CurrentArmor;
   

    public CameraShake cameraShake;

    public GameObject menuContainer;


    // Use this for initialization
    void Start()
    {
        
       

        CurrentHealth = MaxHealth;
        CurrentArmor = MaxArmor;

        HealthBar.value = CalculatedHealth();
        ArmorBar.value = CalculatedArmor();

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    DealDamage(6);
        //}
    }
    public void getHealth()
    {
        Debug.Log("CurrentHealth "+ CurrentHealth);
    }

    public void SetHealth(float health)
    {
        if (CurrentHealth < MaxHealth)
        {
            CurrentHealth = CurrentHealth + health;

            HealthBar.value = CalculatedHealth();
        }
      
    }
    public void SetArmor(float armor)
    {
        if(CurrentArmor<MaxArmor)
        {
            CurrentArmor = CurrentArmor + armor;
            ArmorBar.value = CalculatedArmor();
        }
    }
    public void DealDamage(float damage)
    {
        if(CurrentArmor>0)
        {
            CurrentArmor = CurrentArmor - damage;
            StartCoroutine(cameraShake.Shake(.10f, .4f));
            ArmorBar.value = CalculatedArmor();
        }
        else if (CurrentHealth > 0)
        {
            CurrentHealth = CurrentHealth - damage;
            StartCoroutine(cameraShake.Shake(.10f, .4f));
            HealthBar.value = CalculatedHealth();
        }
        else
        {
            
            //player is dead
            gameObject.SetActive(false);
            //GAME OVER SCREEN
            menuContainer.SetActive(true);
            
        }

    }

    public float CalculatedHealth()
    {
        return CurrentHealth / MaxHealth;
    }
    public float CalculatedArmor()
    {
        return CurrentArmor / MaxArmor;
    }

    
}


