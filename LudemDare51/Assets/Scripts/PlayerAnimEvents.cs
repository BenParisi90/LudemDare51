using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAnimEvents : MonoBehaviour
{
    public static UnityAction WinAnimComplete;
    public static UnityAction FailAnimComplete;
    
    public void WinAnimCompleteEvent()
    {
        WinAnimComplete.Invoke();
    }

    public void FailAnimCompleteEvent()
    {
        FailAnimComplete.Invoke();
    }
}
