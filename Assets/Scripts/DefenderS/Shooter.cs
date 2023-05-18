using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;

    AttackerSpawner _myLaneSpawner;
    Animator _animator;
    
    private void Start() 
    {
        SetLaneSpawner();

        _animator = GetComponent<Animator>();
    }

    private void Update() 
    {
        if(IsAttackerInLane())
        {
            _animator.SetBool("IsAttacking", true);
        }
        else
        {
            _animator.SetBool("IsAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if(IsCloseEnough)
            {
                _myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if(_myLaneSpawner.transform.childCount <= 0)
            return false;
        else
            return true;
    }

    public void Fire()
    {
        Instantiate(_projectile, transform.position, transform.rotation);
    }
}
