using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionEffect : MonoBehaviour
{
    GameObject EffectPanel; //Fade Effect Panel Object
    Image image;    //Fade Effect Panel Image
    float time = 0f;
    float F_time = 1f;

    void Awake()
    {
        EffectPanel = this.gameObject; //this object is fade in/out effect panel
        image = EffectPanel.GetComponent<Image>(); //panel object's image component
        Color color = image.color;
        color.a = 1f;
        image.color = color;
    }

    private void Start()
    {
        FadeIn();
    }

    //after load scene, fade in called
    public void FadeIn()
    {
        Debug.Log("FadeIN called");
        StartCoroutine(FadeInEffect());
    }

    //before load scene, fade out called, then scene is loaded
    public void FadeOut()
    {
        //Debug.Log(this.gameObject.name);
        this.gameObject.SetActive(true);
        StartCoroutine(FadeOutEffect());
    }


    IEnumerator FadeInEffect()
    {
        time = 0f;
        Color color = image.color;

        while (color.a > 0f)
        {
            time += Time.deltaTime / F_time;
            color.a = Mathf.Lerp(1, 0, time);
            image.color = color;
            yield return null;
        }

        time = 0f;
        yield return new WaitForSeconds(0.5f);
        EffectPanel.SetActive(false);
    }

    IEnumerator FadeOutEffect()
    {
        time = 0f;

        Color color = image.color;

        while (color.a < 1f)
        {
            time += Time.deltaTime / F_time;
            color.a = Mathf.Lerp(0, 1, time);
            image.color = color;
            yield return null;
        }

        time = 0f;
        yield return new WaitForSeconds(0.5f);
    }

    
}
