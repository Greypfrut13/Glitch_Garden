using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] private int _stars = 100;
    TextMeshProUGUI _starText;

    private void Start() 
    {
        _starText = GetComponent<TextMeshProUGUI>();    

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        _starText.text = _stars.ToString();
    }

    public bool HaveEnoughStar(int amount)
    {
        return _stars >= amount;
    }

    public void AddStars(int amount)
    {
        _stars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        if(_stars >= amount)
        {
            _stars -= amount;
            UpdateDisplay();
        }
    }
}
