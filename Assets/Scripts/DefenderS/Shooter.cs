using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;

    private AttackerSpawner _myLaneSpawner;
    private Animator _animator;

    private GameObject _projectileParent;
    private const string PROJECTILE_PARENT_NAME = "Projectiles";
    
    private void Start() 
    {
        SetLaneSpawner();
        CreateProjectileParent();

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

    private void CreateProjectileParent()
    {
        _projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        
        if(!_projectileParent)
        {
            _projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
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
        GameObject newProjectile =  Instantiate(_projectile, transform.position, transform.rotation) as GameObject;
        newProjectile.transform.parent = _projectileParent.transform;
    }
}
