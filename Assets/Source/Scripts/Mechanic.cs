using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class Mechanic : MonoBehaviour
{
    [SerializeField] private int maxEnergy;
    [SerializeField] private int startEnergy;
    [SerializeField] private int spendEnergyInTime;
    [SerializeField] private int speedEnergyRegen;
    [SerializeField] private int speedEnergyToOxigen;
    
    
    [SerializeField] private int maxOxigen;
    [SerializeField] private int startOxigen;
    [SerializeField] private int spendOxigenInTime;
    [SerializeField] private float speedOxigenRegen;
    
    [SerializeField] private int maxIce;
    [SerializeField] private int startIce;
    [SerializeField] private float spendIceInTime;
    [SerializeField] private float iseByAsteroid;
    

    [SerializeField] private TMP_Text _energyText;
    [SerializeField] private TMP_Text _oxigenText;
    [SerializeField] private TMP_Text _iceText;
    
    
    [SerializeField] private int costShild;
    [SerializeField] private int costShot;
    
    [SerializeField] private GameObject point1;
    [SerializeField] private GameObject point2;
    [SerializeField] private GameObject asteroid;

    private float energy;
    private float oxigen;
    private float ice;
    private float timeCoefficient = 0.01f;

    [SerializeField] private float timer = 10;


    

    //private float spendIce;


    public static bool IsRegenOxigen = false;
    public static bool IsRegenEnergy = false;

    private bool IsCollision = false;
    private bool shut = false;
    [SerializeField] private int asteroidsCount;


    public static bool IsShildOn = false;
    public static bool IsFire = false;

        
    
    void Start()
    {
        energy = startEnergy;
        oxigen = startOxigen;
        ice = startIce;
        
        _energyText.text = "Energy: " + energy;
        _oxigenText.text = "Oxigen: " + oxigen;
        _iceText.text = "Ice: " + ice;
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        TextUpadate();
        SpendByTime();
        RegenOxigen();
        RegenEnergy();
        Timer();
        SpawnAsteroids();
        OnSheld();
        Shot();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            Destroy(other.gameObject);
            IsCollision = true;
        }
    }
    

    void Timer()
    {
        timer -= 1 * timeCoefficient;
    }
    

    void TextUpadate()
    {
        _energyText.text = "Energy: "+ energy;
        _oxigenText.text = "Oxigen: " + oxigen;
        _iceText.text = "Ice: " + ice;
    }

    void SpendByTime()
    {
        energy -= spendEnergyInTime * timeCoefficient;
        oxigen -= spendOxigenInTime * timeCoefficient;
        
    }

    void RegenOxigen()
    {
        if (IsRegenOxigen && ice > 0 && oxigen < maxOxigen && !IsRegenEnergy)
        {
            oxigen += speedOxigenRegen * timeCoefficient;
            ice    -= spendIceInTime * timeCoefficient;
            energy -= speedEnergyToOxigen * timeCoefficient;
        }
        else if (IsRegenOxigen || IsRegenEnergy)
        {
            //Error
        }
    }

    void RegenEnergy()
    {
        if (IsRegenEnergy && energy < maxEnergy && !IsRegenOxigen)
        {
            energy += speedEnergyRegen * timeCoefficient;
        }
        else if (IsRegenEnergy)
        {
            //Error
        }
    }

    
    
    
    void OnSheld()
    {
        if (energy >= costShild && IsCollision && IsShildOn)
        {
            asteroidsCount++;
            energy -= costShild;
        }
        else if (energy <= costShild && IsCollision)
        {
            Debug.Log("Игра закрылась");
            //Конец
            
        }
        IsCollision = false;
    }

    void Shot()
    {
        if (IsFire && IsCollision && energy >= costShot)
        {
            Debug.Log("Выстрел");
            shut = true;
            ice += iseByAsteroid;
            asteroidsCount++;
            energy -= costShot;
        }
        else if (energy <= costShot && IsCollision)
        {
            Debug.Log("Конец игры");
        }
    }

    void SpawnAsteroids()
    {
        if (timer <= 0)
        {
            GameObject newAsteroid = Instantiate(asteroid, point1.transform.position, Quaternion.identity);
            
            if (shut)
            {
                Destroy(newAsteroid);
                shut = false;
            }
            timer += Random.Range(5, 15);
        }
        
        
    }
    
    
}
