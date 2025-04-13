using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FitnessUIManager : MonoBehaviour
{
    public Transform contentParent;
    public GameObject dayCardPrefab;
    public TextMeshProUGUI summaryText;

    //IEnumerator Start()
    //{
    //    yield return new WaitUntil(() => FitnessManager.Instance != null);
    //    FitnessManager.Instance.OnDataLoaded += DisplayData;
    //}
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
            card.transform.Find("DateText").GetComponent<TextMeshProUGUI>().text = entry.date;
            card.transform.Find("StepsText").GetComponent<TextMeshProUGUI>().text = $"Steps: {entry.stepCount}";
            card.transform.Find("DistanceText").GetComponent<TextMeshProUGUI>().text = $"Distance: {entry.distanceKm:F2} km";
        }

        int count = FitnessManager.Instance.fitnessDataList.dataList.Count;
        summaryText.text = $"Total Steps: {totalSteps}\nAverage Distance: {(count > 0 ? totalDistance / count : 0f):F2} km";
    }
}
