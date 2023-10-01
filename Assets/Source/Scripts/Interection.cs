using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interection : MonoBehaviour
{
   [SerializeField] private TMP_Text indicator;


   private void Update()
   {
      RaycastHit hit;
      if (Physics.Raycast(transform.position, transform.forward, out hit, 2))
      {
         if (hit.collider.tag == "Item")
         {

            indicator.enabled = true;
            if (Input.GetMouseButtonDown(0))
            {
               hit.collider.GetComponent<Item>().Interaction();
            }
            
         }
         else
         {
            indicator.enabled = false;
         }
      }
      else
      {
         indicator.enabled = false;
      }
   }
}
