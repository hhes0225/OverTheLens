using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassesEventTrigger : MonoBehaviour
{

    
    //[SerializeField]
    //private List<int> fSliderBarTime = new List<int>() { 1, 2, 3 };

    int randomIndex;

    int numOfEvents = 5;

    public void GlassesEvent()
    {
        randomIndex = Random.Range(1, numOfEvents+1);//from zero to fSliderBarTime.Count - 1(Last value is exclusive)

        switch (randomIndex)
        {
            case 1: Event1();break;
            case 2: Event2(); break;
            case 3: Event3(); break;
            case 4: Event4(); break;
            case 5: Event5(); break;
            default: Debug.Log("nothing triggered"); break;
        }
    }

    void Event1()
    {
        Debug.Log("glasses event1 is triggered");
    }

    void Event2()
    {
        Debug.Log("glasses event2 is triggered");
    }

    void Event3()
    {
        Debug.Log("glasses event3 is triggered");
    }

    void Event4()
    {
        Debug.Log("glasses event4 is triggered");
    }

    void Event5()
    {
        Debug.Log("glasses event5 is triggered");
    }
}
