using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Health : MonoBehaviour
{

    public Slider HealthBar;

    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }


    // Use this for initialization
    void Start()
    {
        MaxHealth = 100f;

        CurrentHealth = MaxHealth;

        HealthBar.value = CalculatedHealth();


    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    DealDamage(6);
        //}
    }

    public void DealDamage(float damage)
    {
        if (CurrentHealth > 0)
        {
            CurrentHealth = CurrentHealth - damage;

            HealthBar.value = CalculatedHealth();
        }

        


    }

    public float CalculatedHealth()
    {
        return CurrentHealth / MaxHealth;
    }

    
}


