using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{

    static SceneLoader m_instance;

    public void LoadScene(string p_sceneName,Action callback = null)
    {
    }
    public event Action<string> OnSceneLoaded;

    //This script is from the company, and cannot be displayed due to
}
