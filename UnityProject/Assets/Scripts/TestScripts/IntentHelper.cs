using TMPro;
using UnityEngine;

public class IntentHelper : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textComponent;

    public void ShowIntent(string key, string value)
    {
        textComponent.text = "Key : " + key + " ------ Value : " + value;
    }
}
