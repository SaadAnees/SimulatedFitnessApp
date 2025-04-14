using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FitnessUIManager : MonoBehaviour
{
    public Transform contentParent;
    public GameObject dayCardPrefab;
    public TextMeshProUGUI summaryText;

    public void DisplayData()
    {
        Debug.Log("DisplayData");

        foreach (Transform child in contentParent)
            Destroy(child.gameObject);

        int totalSteps = 0;
        float totalDistance = 0;

        foreach (var entry in FitnessManager.Instance.fitnessDataList.dataList)
        {
            totalSteps += entry.stepCount;
            totalDistance += entry.distanceKm;

            GameObject card = Instantiate(dayCardPrefab, contentParent);
            card.GetComponent<FitnessDataUI>().dateText.text = $"Date: {entry.date}";
            card.GetComponent<FitnessDataUI>().stepText.text = $"Steps: {entry.stepCount}";
            card.GetComponent<FitnessDataUI>().distanceText.text = $"Distance: {entry.distanceKm:F2} km";
            card.GetComponent<FitnessDataUI>().caloriesText.text = $"Kcal: {entry.calories:F1}";
        }

        int count = FitnessManager.Instance.fitnessDataList.dataList.Count;
        summaryText.text = $"Total Steps: {totalSteps}\nAverage Distance: {(count > 0 ? totalDistance / count : 0f):F2} km";
    }
}
