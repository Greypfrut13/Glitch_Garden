using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private float _waitToLoad;
    [SerializeField] private GameObject _winLabel;
    [SerializeField] private GameObject _loseLabel;

    private int _numberOfAttackers = 0;
    private bool _levelTimerFinished = false;
    private int _currentScene;
    private bool _lost = false;

    private void Start() 
    {
        _winLabel.SetActive(false);
        _loseLabel.SetActive(false);

        _currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void AttackerSpawned()
    {
        _numberOfAttackers ++;
    }

    public void AttackerKilled()
    {
        _numberOfAttackers--;
        if(_numberOfAttackers <= 0 && _levelTimerFinished && !_lost)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        _winLabel.SetActive(true);
        yield return new WaitForSeconds(_waitToLoad);
        SceneManager.LoadScene(_currentScene + 1);
    }

    public void HandleLoseCondition()
    {
        _lost = true;
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
