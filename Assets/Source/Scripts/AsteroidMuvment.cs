using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMuvment : MonoBehaviour
{
    [SerializeField] private float asterodSpeed;
    [SerializeField] private Vector3 dir;
    

    void FixedUpdate()
    {
        transform.Translate(asterodSpeed * dir,Space.World);
    }

    
  
}
