using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassesEventTrigger : MonoBehaviour
{

    [SerializeField]
    Transform cameraTransform;

    [SerializeField]
    List<GameObject> glassesEffects;

    //[SerializeField]
    //private List<int> fSliderBarTime = new List<int>() { 1, 2, 3 };

    int randomIndex;

    int numOfEvents = 5;

    private void Awake()
    {
        cameraTransform.GetComponent<TransitionEffect>();
    }

    public bool GlassesEvent()
    {
        bool eventEnd = false;
        randomIndex = Random.Range(1, numOfEvents+1);//from zero to fSliderBarTime.Count - 1(Last value is exclusive)

        switch (randomIndex)
        {
            case 1: Event1(); /*eventEnd = true*/; break;
            case 2: Event1(); /*eventEnd = true*/; break;
            case 3: Event1(); /*eventEnd = true*/; break;
            case 4: Event1(); /*eventEnd = true*/; break;
            case 5: Event1(); /*eventEnd = true*/; break;
            default: Debug.Log("nothing triggered"); break;
        }

        return eventEnd;
    }

    void Event1()
    {
        //cameraTransform.rotation = Quaternion.Euler(cameraTransform.rotation.x, cameraTransform.rotation.y, Random.Range(-20, 21));
        cameraTransform.rotation = Quaternion.Euler(0f, 0f, 0f);
        cameraTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        Debug.Log("glasses event1-Rotation is triggered");
    }

    void Event2()
    {
        glassesEffects[0].SetActive(true);
        Debug.Log("glasses event2 is triggered");
    }

    void Event3()
    {
        glassesEffects[1].SetActive(true);
        Debug.Log("glasses event3 is triggered");
    }

    void Event4()
    {
        glassesEffects[2].SetActive(true);
        Debug.Log("glasses event4 is triggered");
    }

    void Event5()
    {
        glassesEffects[3].SetActive(true);
        Debug.Log("glasses event5 is triggered");
    }

    public void RemoveEvents()
    {
        //cameraTransform.rotation = Quaternion.Euler(0f, 0f, 0f);
        glassesEffects[0].SetActive(false);
        glassesEffects[1].SetActive(false);
        glassesEffects[2].SetActive(false);
        glassesEffects[3].SetActive(false);
        glassesEffects[4].SetActive(false);
        Debug.Log("glasses events are removed");
    }

}
