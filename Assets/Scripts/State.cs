using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public bool complete;
    // Start is called before the first frame update
    public virtual void Enter()
    {
        complete = false;
    }
    public virtual void Do()
    {

    }
    public virtual void FixedDo()
    {

    }
    public virtual void Exit()
    {

    }

}
