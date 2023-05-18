using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private float _waitToLoad;
    [SerializeField] private GameObject _winLabel;
    [SerializeField] private GameObject _loseLabel;

    private int _numberOfAttackers = 0;
    private bool _levelTimerFinished = false;

    private void Start() 
    {
        _winLabel.SetActive(false);
        _loseLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        _numberOfAttackers ++;
    }

    public void AttackerKilled()
    {
        _numberOfAttackers--;
        if(_numberOfAttackers <= 0 && _levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        _winLabel.SetActive(true);
        yield return new WaitForSeconds(_waitToLoad);
        //добавить загрузку следующего уровня
    }

    public void HandleLoseCondition()
    {
        _loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelTimerFinished()
    {
        _levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
