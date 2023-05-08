using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumer : MonoBehaviour
{

    //GameObject[] portions;
    //int currentIndex;
    //float lastChange;
    //float interval = 1f;
    public float rotSpeed = 100f;

    void Start()
    {
        rotSpeed = 100f;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
    }

    //void Consume()
    //{
    //    if (currentIndex != portions.Length)
    //        portions[currentIndex].SetActive(false);
    //    currentIndex++;
    //    if (currentIndex > portions.Length)
    //        currentIndex = 0;
    //    else if (currentIndex == portions.Length)
    //        return;
    //    portions[currentIndex].SetActive(true);
    //}

}
