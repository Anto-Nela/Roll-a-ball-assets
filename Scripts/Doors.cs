using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private Animator animator;
    private bool doorOpen;
    private PlayerController plcontroller;

    void Start()
    {
        doorOpen = false;
        animator = GetComponent<Animator>();
        plcontroller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (plcontroller.winText.text== "You Win!") { 
        if (col.gameObject.tag == "Player") {
            doorOpen = true;
            doorControl("Open");
        }
        }
        
    }

    private void OnTriggerExit(Collider col)
    {
        if (doorOpen) {
            doorOpen = false;
            doorControl("Close");
        }
    }

    void doorControl(string direction) {

        animator.SetTrigger(direction);
    }
}
