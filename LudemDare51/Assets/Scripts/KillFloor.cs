using UnityEngine;
using UnityEngine.Events;

public class KillFloor : MonoBehaviour
{
    public UnityEvent HitKillFloor;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            HitKillFloor.Invoke();
        }
    }
}
