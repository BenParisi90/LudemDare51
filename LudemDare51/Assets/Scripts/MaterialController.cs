using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    public static MaterialController Instance;
    [SerializeField] private Timer _timer;
    [SerializeField] private Material _environmentMaterial;
    [SerializeField] private Material _gripPadMaterial;
    private float _lastGripTime = -1000;
    private float _gripPadTightness = 50;

    void Start()
    {
        Instance = this;
        _environmentMaterial.SetFloat("_TotalTime", _timer.TotalLevelTime);
        _environmentMaterial.SetFloat("_RemainingTime", _timer.TotalLevelTime);
    }

    // Update is called once per frame
    void Update()
    {
        _environmentMaterial.SetFloat("_RemainingTime", _timer.RemainingLevelTime);
        _gripPadMaterial.SetFloat("_Tightness", Mathf.Min((Time.time - _lastGripTime) * 50, _gripPadTightness));
    }

    public void StartGrip()
    {
        _lastGripTime = Time.time;
    }
}
