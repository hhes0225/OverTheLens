using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateController : MonoBehaviour
{
    IState currentState;

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();   
    }

    public void ChangeState(IState newState)
    {
        currentState.onExit();
        currentState = newState;
        currentState.onEnter();
    }


}

public interface IState
{
    public void onEnter();
    public void UpdateState();
    public void onGlassesEvent();
    public void onExit();
}
