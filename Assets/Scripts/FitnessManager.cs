using UnityEngine;
using System.IO;
using System;

public class FitnessManager : MonoBehaviour
{
    public static FitnessManager Instance;

    [SerializeField] public FitnessDataList fitnessDataList = new FitnessDataList();
    private string filePath;

    [SerializeField] private FitnessUIManager UIManager;

    //public Action OnDataLoaded;
    void Awake()
    {
        Instance = this;
        filePath = Path.Combine(Application.persistentDataPath, "fitness_data.json");
        LoadData();
    }

    public void LoadData()
    {
        bool shouldLoadDefault = true;

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            if (!string.IsNullOrWhiteSpace(json))
            {
                try
                {
                    var tempData = JsonUtility.FromJson<FitnessDataList>(json);
                    if (tempData != null && tempData.dataList != null && tempData.dataList.Count > 0)
                    {
                        fitnessDataList = tempData;
                        shouldLoadDefault = false;
                    }
                }
                catch
                {
                    Debug.LogWarning("Failed to parse fitness_data.json.");
                }
            }
        }

        if (shouldLoadDefault)
        {
            LoadDefaultFromResources();
            SaveData(); // Save fallback default to persistent path
        }
        if (UIManager)
            UIManager.DisplayData();
        //OnDataLoaded?.Invoke();
    }


    void LoadDefaultFromResources()
    {
        TextAsset defaultJson = Resources.Load<TextAsset>("fitness_data"); // No .json extension
        if (defaultJson != null)
        {
            fitnessDataList = JsonUtility.FromJson<FitnessDataList>(defaultJson.text);
        }
        else
        {
            Debug.LogWarning("Default fitness_data.json not found in Resources.");
            fitnessDataList = new FitnessDataList(); // fallback to empty
        }
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(fitnessDataList, true);
        File.WriteAllText(filePath, json);
    }

    public void AddNewEntry(FitnessData data)
    {
        fitnessDataList.dataList.Add(data);
        SaveData();
    }
}
