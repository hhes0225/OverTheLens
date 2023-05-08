using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    public static Player Instance { get; set; }
    
    bool isHurt { get; set; } = false;

    bool isDead=false;

    [SerializeField]
    public HPbarController hpBar;

    [SerializeField]
    private GameObject fadeEffectPanel;

    public List<AudioClip> effectSound;

    void Start()
    {
        hpBar.Initalize(maxHP, maxHP);
        fadeEffectPanel.SetActive(true);
        //Debug.Log(hpBar.thisCurrentValue);
        //Debug.Log(hpBar.thisMaxValue);
    }

    void Update()
    {
        //testing health up/down function. remove before build
        if (Input.GetKeyDown(KeyCode.I))
        {
            PlayerDamaged(10);
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            PlayerRecovered(10);
        }

        //check game over state
        if (hpBar.thisCurrentValue == 0 && isDead==false)
        {
            StartCoroutine("PlayerDead");
        }
    }

    //player not dead, just damaged
    public void PlayerDamaged(int damage)
    {
        //if (isHurt)
        //    return;
        //isHurt = true;

        MusicManager.instance.SFXPlay("playerDamaged", effectSound[0]);
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
        MusicManager.instance.SFXPlay("playerRecovered", effectSound[1]);
        Debug.Log("Player Recovered");
        hpBar.thisCurrentValue += recovered;
    }

    public void setHealth(float health)
    {
        hpBar.thisCurrentValue = health;
    }

    //player dead(hp is under 0)
    //public void PlayerDead()
    //{
    //    Debug.Log("player dead");

    //    StartCoroutine("effectPlay");

    //    //load gameover scene
    //    SubUIManager.instance.GameOverEvent();

    //}

    IEnumerator PlayerDead()
    {
        isDead = true;
        Debug.Log("player dead");

        MusicManager.instance.SFXPlay("gameOver", effectSound[2]);
        yield return new WaitForSeconds(2.0f);

        //load gameover scene
        SubUIManager.instance.GameOverEvent();
        yield return null;
    }

    //IEnumerator effectPlay()
    //{
    //    MusicManager.instance.SFXPlay("gameOver", effectSound[2]);
    //    yield return new WaitForSeconds(6.0f);
    //}
}
