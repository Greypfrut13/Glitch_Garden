using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in seconds")]
    [SerializeField] private float _levelTime;

    private bool _triggeredLevelFinished = false;

    private Slider _slider;

    private void Start() 
    {
        _slider = GetComponent<Slider>();
    }

    private void Update() 
    {
        if(_triggeredLevelFinished) { return; }

        _slider.value = Time.timeSinceLevelLoad / _levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= _levelTime);
        if(timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            _triggeredLevelFinished = true;
        }
    }
}
