using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FitnessDataUI : MonoBehaviour
{
    public TextMeshProUGUI dateText;
    public TextMeshProUGUI stepText;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI caloriesText;

    private void OnEnable()
    {
        Debug.Log("Day Card Enabled");
    }
}
