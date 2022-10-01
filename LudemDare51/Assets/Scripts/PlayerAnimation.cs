using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    void Start()
    {
        GameManager.WinLevel += WinAnim;
        GameManager.FailLevel += FailAnim;
    }

    private void WinAnim()
    {
        _animator.Play("WinLevel");
    }

    private void FailAnim()
    {
        _animator.Play("FailLevel");
    }
}
