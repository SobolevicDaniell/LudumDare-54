using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

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
    

    [SerializeField] private TMP_Text _energyText;
    [SerializeField] private TMP_Text _oxigenText;
    [SerializeField] private TMP_Text _iceText;
    
    
    [SerializeField] private int costShild;
    

    private float energy;
    private float oxigen;
    private float ice;
    private float timeCoefficient = 0.01f;

    //private float spendIce;


    public static bool IsRegenOxigen = false;
    public static bool IsRegenEnergy = false;
    
    
    public static bool IsShildOn = false;
    
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
        CanShildOn();
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

    void CanShildOn()
    {
        if (energy >= costShild)
        {
            energy -= costShild;
            OnSheld();
        }
    }
    
    
    void OnSheld()
    {
        
    }
}
