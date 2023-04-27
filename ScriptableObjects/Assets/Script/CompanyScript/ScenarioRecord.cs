using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioRecord : MonoBehaviour
{ 
    public string SceanrioDescriptionKey;
    public FireType FireType;
    public ExtinguisherType ExtinguisherType;
    public float ScenarioScore;
    public string ScenarioResultDescription;
    public int ElapsedTime;

    public string GetBaseScenarioName()
    {
        var stringSplit = SceanrioDescriptionKey.Split('_');
        return stringSplit[0];
    }
}
