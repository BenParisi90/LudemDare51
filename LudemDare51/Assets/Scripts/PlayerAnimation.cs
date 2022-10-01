using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private GameManager _gameManager;

    void Start()
    {
        _gameManager.WinLevel.AddListener(WinAnim);
        _gameManager.FailLevel.AddListener(FailAnim);
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
