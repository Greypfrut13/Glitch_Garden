using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)]
    [SerializeField] private float _walkSPeed;
    [SerializeField] private float _damage;

    private float _currentSpeed;
    private GameObject _currentTarget;

    private void Awake() 
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void Update() 
    {
        transform.Translate(Vector2.left * _currentSpeed * Time.deltaTime);

        UpdateAnimationState();
    }

    private void OnDestroy() 
    {
        LevelController levelController =  FindObjectOfType<LevelController>();
        if(levelController != null)
        {
            levelController.AttackerKilled();
        }
        
    }

    private void UpdateAnimationState()
    {
        if(!_currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }

    public void SetMovementSpeed()
    {
        _currentSpeed = _walkSPeed;
    }

    public void SetJumpSpeed()
    {
        _currentSpeed = GetComponent<Fox>()._jumpSpeed;
    }

    public void StopMovement()
    {
        _currentSpeed = 0;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        _currentTarget = target;
    }

    public void StrikeCurrentTarget()
    {
        if(!_currentTarget) { return; }

        Health health = _currentTarget.GetComponent<Health>();
        if(health)
        {
            health.DealdDamage(_damage);
        }
    }
}
