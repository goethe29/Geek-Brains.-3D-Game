using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollControl : MonoBehaviour
{
    [SerializeField] private Rigidbody _parentBody;
    [SerializeField] private Rigidbody[] _rbs;
    [SerializeField] private Collider[] _colliders;
    [SerializeField] private Animator _animator;

    private void Awake() 
    {
        _animator = GetComponent<Animator>();
        _rbs = GetComponentsInChildren<Rigidbody>();
        _colliders = GetComponentsInChildren<Collider>();
        Revive();
        Invoke("Kill", 3.0f);
    }

    private void SetRagdoll(bool active) 
    {
        for (int i = 0; i < _rbs.Length; i++)
        {
            _rbs[i].isKinematic = !active;
        }
        for (int i = 0; i < _colliders.Length; i++)
        {
            _colliders[i].enabled = active;
        }
    }

    private void SetMain(bool active) 
    {
        _animator.enabled = active;
        _rbs[0].isKinematic = !active;
        _colliders[0].enabled = active;
    }

    private void Kill() 
    {
        SetRagdoll(true);
        SetMain(false);
    }

    private void Revive() 
    {
        SetRagdoll(false);
        SetMain(true);
    }
}
