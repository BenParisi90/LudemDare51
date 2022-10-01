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

    void FixedUpdate()
    {
        bool running = transform.position != _prevPosition;
        Debug.Log(running + " " + transform.position.ToString("f4"));
        _animator.SetBool("Running", running);
        if(running)
        {
            Vector3 movementDirection = transform.position - _prevPosition;
            movementDirection.y= 0;
            _animator.transform.rotation = Quaternion.LookRotation(movementDirection);
        }
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
