using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class IntentReceiver : MonoBehaviour
{
    [SerializeField]
    private List<string> keys;

    private Dictionary<string, string> intents;

    private void Awake()
    {
        intents = new Dictionary<string, string>();

        //Enable this region to simulate for android
        intents.Add("Scene", "SceneOne");
        intents.Add("Vin", "0123456789");
        DisplayIntents();

        //Enable this region to simulate for ios
        /*
        SetIntent("Scene", "SceneOne");
        SetIntent("Vin", "0123456789");
        SetIntent("Done", "");
        */
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
#if PLATFORM_ANDROID
            if (getIntentData())
                DisplayIntents();
#endif
        }
    }

    private void DisplayIntents()
    {
        foreach(string key in intents.Keys)
        {
            Debug.Log("Key: " + key + " -------- Value: " + intents[key]);
        }

        string scene = intents["Scene"];
        if(scene == "SceneOne")
        {
            SceneManager.LoadScene(1);
        }else
        {
            SceneManager.LoadScene(2);
        }
    }

    public void SetIntent(string key, string value)
    {
        if(key == "Done")
        {
            DisplayIntents();
            return;
        }
        intents.Add(key, value);
    }

    #region Intent Process
    private bool getIntentData()
    {
#if (!UNITY_EDITOR && UNITY_ANDROID)
        return CreatePushClass (new AndroidJavaClass ("com.unity3d.player.UnityPlayer"));
#endif
        return false;
    }

    public bool CreatePushClass(AndroidJavaClass UnityPlayer)
    {
#if UNITY_ANDROID
        AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject intent = currentActivity.Call<AndroidJavaObject>("getIntent");
        AndroidJavaObject extras = GetExtras(intent);

        if (extras != null)
        {
            foreach(string key in keys)
            {
                string intentVal = GetProperty(extras, key);
                if(!string.IsNullOrEmpty(intentVal))
                {
                    intents.Add(key, intentVal);
                }
            }
            return true;
        }
#endif
        return false;
    }

    private AndroidJavaObject GetExtras(AndroidJavaObject intent)
    {
        AndroidJavaObject extras = null;

        try
        {
            extras = intent.Call<AndroidJavaObject>("getExtras");
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

        return extras;
    }

    private string GetProperty(AndroidJavaObject extras, string name)
    {
        string s = string.Empty;

        try
        {
            s = extras.Call<string>("getString", name);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

        return s;
    }
    #endregion

    public void HomeButton()
    {

#if !PLATFORM_ANDROID
        Application.Unload();

#endif
#if PLATFORM_ANDROID
        LoadAndroidActivity();
#endif
    }

    public void LoadAndroidActivity()
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call("Launch", "Test Data");
    }
}
