using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] private int _lives = 5;
    [SerializeField] private int _damage = 1;
    private TextMeshProUGUI _livesText;

    private void Start() 
    {
        _livesText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        _livesText.text = _lives.ToString();
    }

    public void TakeLive()
    {
        _lives -= _damage;
        UpdateDisplay();

        if(_lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
