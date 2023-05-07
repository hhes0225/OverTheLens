using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum EventState
{
    Normal,
    GlassesEvent
}

public class TimerGlassesEventController : MonoBehaviour
{
    //private Image filledArea;
    Slider timerSlider;

    [SerializeField]
    private List<float> fSliderBarTime = new List<float>() { 10.0f, 15.0f, 20.0f, 25.0f, 30.0f, 35.0f, 40.0f };
    
    int randomIndex;

    bool check;

    [SerializeField]
    private GlassesEventTrigger glassesEventTrigger;

    [SerializeField]
    private GameObject buttonActionObj;

    EventState nowState = EventState.Normal;

    public AudioClip effectSound;

void Start()
    {
        check = false;
        //filledArea = GetComponent<Image>();
        timerSlider = this.GetComponent<Slider>();
        glassesEventTrigger.GetComponent<GlassesEventTrigger>();
        Debug.Log(buttonActionObj.name + " วาด็ตส");

        ResetTimer();
    }

     void Update()
    {

        if (nowState == EventState.Normal) { 
            if (timerSlider.value < fSliderBarTime[randomIndex])
            {
                timerSlider.value += Time.deltaTime;
            }
            else
            {
                Debug.Log("count end");
                StartCoroutine("GlassesEvent");
            }
        }
        else//nowState==EventState.
        {
            if (buttonActionObj.activeSelf == false)
            {
                StopCoroutine("GlassesEvent");
                check = true;
                StartCoroutine("ExitEvent");
            }
        }
    }

    void ResetTimer()
    {
        timerSlider.value = 0.0f;

        //Debug.Log("List count:"+fSliderBarTime.Count);
        randomIndex = Random.Range(0, fSliderBarTime.Count);//from zero to fSliderBarTime.Count - 1(Last value is exclusive)

        timerSlider.maxValue = fSliderBarTime[randomIndex];
        //Debug.Log("random timer count index: "+randomIndex);
        Debug.Log("random timer count second: " + fSliderBarTime[randomIndex]);
    }

    //Glasses Event Coroutine
    IEnumerator GlassesEvent()
    {
        //Debug.Log(MusicManager.instance);
        MusicManager.instance.SFXPlay("glassesEventTrigger", effectSound);
        nowState = EventState.GlassesEvent;
        check=glassesEventTrigger.GlassesEvent();
        buttonActionObj.SetActive(true);

        yield return null;
    }

    IEnumerator EscapeEvent()
    {
        //escape button action event
        yield return null;
    }
    IEnumerator ExitEvent()
    {
        if (check)
        {
            check = false;
            ResetTimer();
        }

        nowState = EventState.Normal;
        glassesEventTrigger.RemoveEvents();

        yield return null;
    }


    //change timer value(in case making some item regarding timer)
}
