using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public State state;
    void Start()
    {

    }

    // Update is called once per frame
    public void StateUpdate()
    {
        if (state != null)
        {
            state.Do();

            if (state.complete)
            {
                SetNextState();
            }
        }
        
    }

    public void StateFixedUpdate()
    {
        if (state != null)
        {
            state.FixedDo();

            if (state.complete)
            {
                SetNextState();
            }
        }
        
    }

    public void Set(State newState, bool overRide = false)
    {
        if (state != null && newState != state || overRide)
        {
            state.Exit();
            state = newState;
            state.Enter();
        }
        else if (state == null)
        {
            state = newState;
            state.Enter();
        }
    }

    public virtual void SetNextState() { }
}
