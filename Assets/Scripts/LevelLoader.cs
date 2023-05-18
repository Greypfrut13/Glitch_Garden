using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private int _currentSCene;

    private void Start() 
    {
        _currentSCene = SceneManager.GetActiveScene().buildIndex;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(_currentSCene);
        Time.timeScale = 1;
    }
}
