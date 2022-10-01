using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private Vector3 _prevPosition;

    void Start()
    {
        GameManager.WinLevel += WinAnim;
        GameManager.FailLevel += FailAnim;
    }

    void Update()
    {
        _animator.SetBool("Running", transform.position != _prevPosition);
        Vector3 movementDirection = transform.position - _prevPosition;
        _animator.transform.rotation = Quaternion.LookRotation(movementDirection);

        _prevPosition = transform.position;
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
