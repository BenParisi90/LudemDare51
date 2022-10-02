using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] AudioSource _footstepSound;


    private Vector3 _prevHorzPosition;
    private float _prevVertPos;
    private float _moveDistanceThreshold = 0.01f;
    private bool _footstepSoundPlaying = false;

    void Start()
    {
        GameManager.WinLevel += WinAnim;
        GameManager.FailLevel += FailAnim;

        _prevHorzPosition = transform.position;
        _prevHorzPosition.y = 0;
        _prevVertPos = transform.position.y;
    }

    void FixedUpdate()
    {
        Vector3 horzPos = transform.position;
        horzPos.y = 0;
        float moveDistance = Vector3.Distance(horzPos, _prevHorzPosition);
        bool running = moveDistance >= _moveDistanceThreshold;
        _animator.SetBool("Running", running);
        if(running)
        {
            Vector3 movementDirection = transform.position - _prevHorzPosition;
            movementDirection.y= 0;
            _animator.transform.rotation = Quaternion.LookRotation(movementDirection);
        }
        _prevHorzPosition = transform.position;
        _prevHorzPosition.y = 0;

        bool inAir = !_playerMovement.Grounded;
        _animator.SetBool("InAir", inAir);
        _prevVertPos = transform.position.y;

        if(inAir)
        {
            if(_footstepSoundPlaying)
            {
                _footstepSound.Stop();
                _footstepSoundPlaying = false;
            }
        }
        else
        {
            if(running && !_footstepSoundPlaying)
            {
                _footstepSound.Play();
                _footstepSoundPlaying = true;
            }
            else if(!running && _footstepSoundPlaying)
            {
                _footstepSound.Stop();
                _footstepSoundPlaying = false;
            }
        }
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
