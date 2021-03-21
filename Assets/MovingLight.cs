using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLight : MonoBehaviour
{
    
    [SerializeField] Transform _startT;
    [SerializeField] Transform _endT;
    [SerializeField] float _speed;
    private Vector3 _start;
    private Vector3 _end;
    private Vector3 _target;

    
    // Start is called before the first frame update
    void Start()
    {
        _start = _startT.position;
        _end = _endT.position;
        _target = _end;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direct = _target - gameObject.transform.position;
        if (Vector3.SqrMagnitude(direct) <= 1)
        {
            _target = _target == _end? _start : _end;
        }
        Vector3 move = Vector3.MoveTowards(gameObject.transform.position, _target, _speed*Time.deltaTime);

        //gameObject.transform.Translate(move);
        gameObject.transform.position = move;
    
    }
}
