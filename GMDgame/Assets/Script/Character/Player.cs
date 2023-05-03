using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    public static Player Instance { get; set; }
    
    bool isHurt { get; set; } = false;

    [SerializeField]
    public HPbarController hpBar;

    [SerializeField]
    private GameObject fadeEffectPanel;

    void Start()
    {
        hpBar.Initalize(maxHP, maxHP);
        fadeEffectPanel.SetActive(true);
        //Debug.Log(hpBar.thisCurrentValue);
        //Debug.Log(hpBar.thisMaxValue);
    }

    void Update()
    {
        //testing health up/down function
        if (Input.GetKeyDown(KeyCode.I))
        {
            PlayerDamaged(10);
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            PlayerRecovered(10);
        }

        //check game over state
        if (hpBar.thisCurrentValue == 0)
        {
            PlayerDead();
        }
    }

    //player not dead, just damaged
    public void PlayerDamaged(int damage)
    {
        //if (isHurt)
        //    return;
        //isHurt = true;

        Debug.Log("Player Damaged");
        hpBar.thisCurrentValue -= damage;
        if (hpBar.thisCurrentValue < 0)
        {
            hpBar.thisCurrentValue = 0;
        }

        //some damaged effect(animation or coroutine)
        //for example, knock-back
    }

    public void PlayerRecovered(int recovered)
    {
        Debug.Log("Player Recovered");
        hpBar.thisCurrentValue += recovered;
    }

    public void setHealth(float health)
    {
        hpBar.thisCurrentValue = health;
    }

    //player dead(hp is under 0)
    public void PlayerDead()
    {
        Debug.Log("player dead");

        //load gameover scene
        fadeEffectPanel.GetComponent<TransitionEffect>().FadeOut();
        Invoke("nextSceneLoader", 1f);

    }

    void nextSceneLoader()
    {
        SceneManager.LoadScene(3);
    }
}
