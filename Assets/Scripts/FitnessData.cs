using System.Collections.Generic;

[System.Serializable]
public class FitnessData
{
    public string date;
    public int stepCount;
    public float distanceKm;
}

[System.Serializable]
public class FitnessDataList
{
    public List<FitnessData> dataList = new List<FitnessData>();
}
