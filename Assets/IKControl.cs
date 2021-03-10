using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool _useIK;
    [SerializeField] Transform _rightHandGoal;
    [SerializeField] float _rightHandWeight;
    [SerializeField] Transform _lookGoal;
    [SerializeField] float _lookDistance = 2;
    
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex) {
        if (_animator)
        {
            if (_useIK)
            {
                if (_rightHandGoal)
                {
                    _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, _rightHandWeight);
                    //_animator.SetIKRotationWeight(AvatarIKGoal.RightHand, _rightHandWeight);
                    _animator.SetIKPosition(AvatarIKGoal.RightHand, _rightHandGoal.position);
                    //_animator.SetIKRotation(AvatarIKGoal.RightHand, _rightHandGoal.rotation);
                }

                if (_lookGoal)
                {
                    LookAt();
                }
            }
            else
            {
                ResetIK();
            }
        }
    }

    private void LookAt()
    {
        float distance = Vector3.SqrMagnitude(gameObject.transform.position - _lookGoal.transform.position);
        if (distance <= _lookDistance *_lookDistance)
        {
            _animator.SetLookAtWeight(1);
            _animator.SetLookAtPosition(_lookGoal.position);
        }
        else
        {
            ResetIK("Head");
        }    
    }

    private void ResetIK(string nameIK = "All") 
    {
        if (nameIK == "All" || nameIK == "Head")
        {   
            _animator.SetLookAtWeight(0);
        }

        if (nameIK == "All" || nameIK == "RightHand")
        {   
            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
        }
    }
}
