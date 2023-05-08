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
    //GameObject buttonActionSlider;

    int randomIndex;

    int numOfEvents = 6;

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
            case 2: Event2(); /*eventEnd = true*/; break;
            case 3: Event3(); /*eventEnd = true*/; break;
            case 4: Event4(); /*eventEnd = true*/; break;
            case 5: Event5(); /*eventEnd = true*/; break;
            case 6: Event6(); /*eventEnd = true*/; break;
            default: Debug.Log("nothing triggered"); break;
        }

        return eventEnd;
    }

    void Event1()//Rotation
    {
        //cameraTransform.rotation = Quaternion.Euler(cameraTransform.rotation.x, cameraTransform.rotation.y, Random.Range(-20, 21));
        //cameraTransform.rotation = Quaternion.Euler(0f, 0f, 0f);
        cameraTransform.localRotation = Quaternion.Euler(0f, 0f, Random.Range(-20, 21));
        Debug.Log("glasses event1-Rotation is triggered");
    }

    void Event2()//Blur
    {
        glassesEffects[0].SetActive(true);
        Debug.Log("glasses event2 is triggered");
    }

    void Event3()//Dark
    {
        glassesEffects[1].SetActive(true);
        Debug.Log("glasses event3 is triggered");
    }

    public void Event4()//Distortion
    {
        glassesEffects[2].SetActive(true);
        Debug.Log("glasses event4 is triggered");
    }

    void Event5()//Steam
    {
        glassesEffects[3].SetActive(true);
        Debug.Log("glasses event5 is triggered");
    }

    void Event6()//3D lens
    {
        glassesEffects[4].SetActive(true);
        Debug.Log("glasses event5 is triggered");
    }

    public void RemoveEvents()
    {
        cameraTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        foreach(GameObject i in glassesEffects)
        {
            i.SetActive(false);
        }
        //glassesEffects[0].SetActive(false);
        //glassesEffects[1].SetActive(false);
        //glassesEffects[2].SetActive(false);
        //glassesEffects[3].SetActive(false);
        //glassesEffects[4].SetActive(false);
        Debug.Log("glasses events are removed");
    }

}
