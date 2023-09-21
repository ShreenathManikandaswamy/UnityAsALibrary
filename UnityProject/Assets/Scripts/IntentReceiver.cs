using System;
using UnityEngine;
using TMPro;

public class IntentReceiver : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI intentText;

    private string intents;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void DisplayIntents()
    {
        intentText.text = intents;
    }

    public void SetBrand(string selectedBrand)
    {
        intentText.text = selectedBrand;
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
            Debug.Log(GetProperty(extras, "Brand"));
            intents = GetProperty(extras, "Brand");
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

    private void OnApplicationFocus(bool focus)
    {
        if(focus)
        {
#if PLATFORM_ANDROID
            if (getIntentData())
                DisplayIntents();

#endif
        }
    }
}
