using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FitnessEntryForm : MonoBehaviour
{
    public TMP_InputField dateField;
    public TMP_InputField stepsField;
    public TMP_InputField distanceField;
    public TMP_InputField caloriesField;
    public FitnessUIManager uiManager;

    public void AddEntry()
    {
        FitnessData newEntry = new FitnessData
        {
            date = dateField.text,
            stepCount = int.Parse(stepsField.text),
            distanceKm = float.Parse(distanceField.text),
            calories = float.Parse(caloriesField.text)
        };

        FitnessManager.Instance.AddNewEntry(newEntry);
        uiManager.DisplayData();
        ClearForm();
    }

    void ClearForm()
    {
        dateField.text = "";
        stepsField.text = "";
        distanceField.text = "";
        caloriesField.text = "";
    }
}
