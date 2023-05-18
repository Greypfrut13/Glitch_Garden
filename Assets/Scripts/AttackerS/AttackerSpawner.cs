using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] private Attacker[] _attackerPrefabArray;

    [SerializeField] private float _minSpawnDealy = 1f;
    [SerializeField] private float _maxSpawnDelay = 5f;

    private bool _spawn = true;

    IEnumerator Start() 
    {
        while(_spawn)
        {
            yield return new WaitForSeconds(Random.Range(_minSpawnDealy, _maxSpawnDelay));

            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        _spawn = false;
    }

    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, _attackerPrefabArray.Length);
        Spawn(_attackerPrefabArray[attackerIndex]);
    }

    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate
            (myAttacker, transform.position, transform.rotation)
            as Attacker;
        newAttacker.transform.parent = transform;
    }
}
