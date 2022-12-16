using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        GetComponent<PlayerMove>().OnSetIdle += UpdateAnimatorIdle;
        GetComponent<PlayerJump>().OnSetIsGrounded += UpdateAnimatorIsGrounded;
        GetComponent<PlayerClimb>().OnSetIsClimbing += UpdateAnimatorIsClimbing;

        _animator = GetComponent<Animator>();
    }


    private void UpdateAnimatorIdle(bool isIdle)
    {
        _animator.SetBool("IsIdle", isIdle);
    }

    private void UpdateAnimatorIsGrounded(bool isGrounded)
    {
        _animator.SetBool("IsGrounded", isGrounded);
    }

    private void UpdateAnimatorIsClimbing(bool isClimbing)
    {
        _animator.SetBool("IsClimbing", isClimbing);
    }
}
