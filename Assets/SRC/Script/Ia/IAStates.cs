using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAStates : MonoBehaviour
{
    public IAStateType States;
    public void ChangeToStates(IAStateType state)
    {
        if (States == state) return;
        States = state;
    }

}
