using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeText : MonoBehaviour
{
    private Animator animator;
    bool textappear;
    private Text thetext;
 
    void Start()
    {
        animator = GetComponent<Animator>();
        thetext = GetComponent<Text>();
        textappear = false;
        animator.SetBool("texti", false);
    
    }

    // Update is called once per frame
    void Update()
    {
        if (thetext.text == "You Win!")
        {
            textappear = true;
        }
        else {
            textappear = false; 
                }

        if (textappear == false)
            animator.SetBool("texti", false);

        if (textappear == true) { 
        animator.SetBool("texti", true);
   
        }
            
    }
}
