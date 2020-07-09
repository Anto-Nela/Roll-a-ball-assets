using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLvl : MonoBehaviour
{
    private GameObject[] pickup2=new GameObject[1];

    void Start()
    {
        pickup2 = GameObject.FindGameObjectsWithTag("Pick Up2");
        pickup2[0].SetActive(false);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            pickup2[0].SetActive(true);
        }

        else{
            pickup2[0].SetActive(false);
        }
    }

        
}
