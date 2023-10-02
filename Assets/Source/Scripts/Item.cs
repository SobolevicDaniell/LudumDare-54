using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    StvorkaL,
    StvorkaR,
    Button
}


public class Item : MonoBehaviour
{
    public ItemType type;
    private bool i1 = true;
    private bool i2 = true;
    private bool i3 = true;

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
            i3 = !i3;
            GetComponentInParent<Animator>().SetBool("IsPushed", i3);
            i3 = !i3;
            GetComponentInParent<Animator>().SetBool("IsPushed", i3);
        }
        
        
    }
}
