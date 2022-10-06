using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepState : State
{
    public void ReadyUp() => complete = true;
}
