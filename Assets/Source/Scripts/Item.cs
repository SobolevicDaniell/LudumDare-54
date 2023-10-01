using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    StvorkaL,
    StvorkaR
}


public class Item : MonoBehaviour
{
    public ItemType type;
    private bool i1 = true;
    private bool i2 = true;

    public void Interaction()
    {
        if (type == ItemType.StvorkaL)
        {
           
            GetComponentInParent<Animator>().SetBool("IsOpen", i1);
            i1 = !i1;
            //GetComponentInParent<Animator>().SetBool("IsClose", i1);
        }
        if (type == ItemType.StvorkaR)
        {
           
            GetComponentInParent<Animator>().SetBool("IsOpen", i2);
            i2 = !i2;
            //GetComponentInParent<Animator>().SetBool("IsClose", i2);
        }
    }
}
