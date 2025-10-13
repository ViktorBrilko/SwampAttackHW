using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CelebrationState : State
{
    [SerializeField] private Animator _itemAnimator;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play("Celebration");

        if (_itemAnimator != null)
            _itemAnimator.Play("Celebration");
    }

    private void OnDisable()
    {
        _animator.StopPlayback();

        if (_itemAnimator != null)
            _itemAnimator.StopPlayback();
    }
}