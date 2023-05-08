using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    Animator animator;
    public Button[] buttons;

    private void Start()
    {
        animator = GetComponent<Animator>();
        foreach (Button b in buttons)
        {
            b.interactable = false;
        }

        //Time.timeScale = 0f;
    }

    void ChangeAnimation()
    {
        animator.SetInteger("Change", animator.GetInteger("Change") + 1);
    }

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            ChangeAnimation();
        }
    }
}
