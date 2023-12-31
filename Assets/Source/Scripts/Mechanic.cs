using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    [SerializeField] private GameObject alarm;

    [SerializeField] private Slider sliderElectricity;
    [SerializeField] private Slider sliderOxigen;
    [SerializeField] private Slider sliderIce;

    private float energy;
    private float oxigen;
    private float ice;
    private float timeCoefficient = 0.01f;

    [SerializeField] private float timer = 10;


    



    public static bool IsRegenOxigen = false;
    public static bool IsRegenEnergy = false;

    private bool IsCollision = false;
    private bool shut = false;
    [SerializeField] private int asteroidsCount;


    public static bool IsShildOn = false;
    public static bool IsFire = false;
    public static bool IsAlarm = false;

        
    
    void Start()
    {
        energy = startEnergy;
        oxigen = startOxigen;
        ice = startIce;
        
        _energyText.text = "Energy: " + energy;
        _oxigenText.text = "Oxigen: " + oxigen;
        _iceText.text = "Ice: " + ice;
        
    }

   
    private void FixedUpdate()
    {
        //TextUpadate();
        SpendByTime();
        RegenOxigen();
        RegenEnergy();
        Timer();
        SpawnAsteroids();
        OnSheld();
        //Shot();
        IsDie();
        Alarm();
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
        energy -= spendEnergyInTime * timeCoefficient + asteroidsCount;
        oxigen -= spendOxigenInTime * timeCoefficient + asteroidsCount;

        sliderElectricity.value = energy;
        sliderOxigen.value = oxigen;
        sliderIce.value = ice;

    }

    void RegenOxigen()
    {
        if (IsRegenOxigen && ice > 0 && oxigen < maxOxigen && !IsRegenEnergy)
        {
            oxigen += speedOxigenRegen * timeCoefficient;
            ice    -= spendIceInTime * timeCoefficient;
            energy -= speedEnergyToOxigen * timeCoefficient;
        }
        
    }

    void RegenEnergy()
    {
        if (IsRegenEnergy && energy < maxEnergy && !IsRegenOxigen)
        {
            energy += speedEnergyRegen * timeCoefficient;
            alarm.GetComponent<Animator>().SetBool("IsAlarm", false);
        }
        
        
    }

    void Alarm()
    {
        if (IsRegenEnergy && IsRegenOxigen)
        {
            
            alarm.GetComponent<Animator>().SetBool("IsAlarm", true);
        }
        else
        {
            alarm.GetComponent<Animator>().SetBool("IsAlarm", false);
        }
    }

    void IsDie()
        {
            if (oxigen <= 0 || energy <= 0)
            {
                GameOver();
            }
        }

    


        void OnSheld()
        {
            if (energy >= costShild && IsCollision && IsShildOn)
            {
                asteroidsCount++;
                energy -= costShild;
                IsCollision = false;
            }
            else if (energy <= costShild && IsCollision)
            {
                Debug.Log("Игра закрылась");
                IsCollision = false;
                GameOver();
            }

        }

        // void Shot()
        // {
        //     if (IsFire && IsCollision && energy >= costShot)
        //     {
        //         Debug.Log("Выстрел");
        //         shut = true;
        //         ice += iseByAsteroid;
        //         asteroidsCount++;
        //         energy -= costShot;
        //     }
        //     else if (energy <= costShot && IsCollision)
        //     {
        //         Debug.Log("Конец игры");
        //         GameOver();
        //     }
        // }


        void Shot()
        {
            if (energy >= costShot && !IsShildOn)
            {
                
            }
            else
            {
                //alarm.GetComponent<Animator>().SetBool("IsAlarm", true);
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

                timer += Random.Range(15, 25);
            }
        }

        
        void GameOver()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Menu");
        }

    
}
