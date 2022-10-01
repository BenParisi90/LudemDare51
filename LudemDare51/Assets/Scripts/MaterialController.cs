using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Material _environmentMaterial;

    void Start()
    {
        _environmentMaterial.SetFloat("_TotalTime", _timer.TotalLevelTime);
    }

    // Update is called once per frame
    void Update()
    {
        _environmentMaterial.SetFloat("_RemainingTime", _timer.RemainingLevelTime);
    }
}
