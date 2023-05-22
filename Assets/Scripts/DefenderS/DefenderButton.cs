using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender _defenderPrefab;

    private void Start() 
    {
        LabelButtonWithCost();    
    }

    private void LabelButtonWithCost()
    {
        TextMeshProUGUI costText = GetComponentInChildren<TextMeshProUGUI>();
        if(!costText) 
        {
            //Debug.Log(name + "has no cost text!");
        }
        else
        {
            costText.text = _defenderPrefab.GetStarCost().ToString();
        }
    }

    private void OnMouseDown() 
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(_defenderPrefab);
    }
}
