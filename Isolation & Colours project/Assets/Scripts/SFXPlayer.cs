﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{

    public AudioClip menuClick;
//    public AudioClip shipShooting;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuClick()
    {
        audioSource.PlayOneShot(menuClick, 0.1F);
    }

//    public void ShipShooting()
//    {
//       audioSource.PlayOneShot(shipShooting, 0.1F);
 //   }
}
