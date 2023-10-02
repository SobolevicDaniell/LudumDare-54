using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    StvorkaL,
    StvorkaR,
    Button,
    SwitchShild,
    SwitchEnergy,
    Valve
}


public class Item : MonoBehaviour
{
    public ItemType type;
    private bool i1 = true;
    private bool i2 = true;
    private bool i3 = true;
    private bool i4 = true;
    private bool i5 = true;
    private bool i6 = true;

    public void Interaction()
    {
        if (type == ItemType.StvorkaL)
        {
           
            GetComponentInParent<Animator>().SetBool("IsOpen", i1);
            i1 = !i1;
        }
        if (type == ItemType.StvorkaR)
        {
           
            GetComponentInParent<Animator>().SetBool("IsOpen", i2);
            i2 = !i2;
        }
        if (type == ItemType.Button)
        {
            i3 = true;
            GetComponentInParent<Animator>().SetTrigger("IsPushed");
            
        }
        
        
        if (type == ItemType.SwitchShild)
        {
           
            GetComponentInParent<Animator>().SetBool("IsOpen", i4);
            Mechanic.IsShildOn = i4;
            i4 = !i4;
        }
        if (type == ItemType.SwitchEnergy)
        {
           
            GetComponentInParent<Animator>().SetBool("IsOpen", i5);
            Mechanic.IsRegenEnergy = i5;
            i5 = !i5;
        }
        if (type == ItemType.Valve)
        {
           
            GetComponentInParent<Animator>().SetBool("IsOpen", i6);
            Mechanic.IsRegenOxigen = i6;
            i6 = !i6;
            
        }
        
    }
}
