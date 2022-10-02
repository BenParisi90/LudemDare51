using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public static ParticleController Instance;

    [SerializeField] ParticleSystem ShatterParticle;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void Shatter(Vector3 position, Quaternion rotation)
    {
        ShatterParticle.transform.position = position;
        ShatterParticle.transform.rotation = rotation;
        ShatterParticle.Play();
    }
}
