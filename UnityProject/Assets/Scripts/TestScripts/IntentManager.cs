using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntentManager : MonoBehaviour
{
    [SerializeField]
    private IntentHelper intentPrefab;
    [SerializeField]
    private Transform intentParent;

    private string salesCode;

    private void Start()
    {
        foreach(KeyValuePair<string, string> intent in ApplicationManager.Instance.Intents)
        {
            IntentHelper instance = Instantiate(intentPrefab, intentParent);
            instance.ShowIntent(intent.Key, intent.Value);
        }

        RetrieveSalesCode();
    }

    private void RetrieveSalesCode()
    {
        LocalData localData = ApplicationManager.Instance.dataManager.GetLocalData(
            ApplicationManager.Instance.Intents["Vin"]);

        if (localData == null)
        {
            localData = new LocalData();
            localData.salesCode = GetSalesCode();

            string jsonString = JsonUtility.ToJson(localData);

            ApplicationManager.Instance.dataManager.SetLocalData(
                ApplicationManager.Instance.Intents["Vin"],
                jsonString);
        }
        else
        {
            salesCode = localData.salesCode;
        }
    }

    private string GetSalesCode()
    {
        salesCode = "qwertyuip";
        return salesCode;
    }
}
