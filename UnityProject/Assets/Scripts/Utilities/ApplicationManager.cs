using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    public DataManager dataManager;
    public static ApplicationManager Instance;

    public Dictionary<string, string> Intents;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(this.gameObject);
        }

        Intents = new Dictionary<string, string>();
    }
}
