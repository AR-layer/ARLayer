using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AppManager : MonoBehaviour
{
    [SerializeField] private AppConfig appConfig;
    [SerializeField] private GameObject id;
    [SerializeField] private GameObject author;
    [SerializeField] private GameObject text;

    public void LoadResources(string className)
    {
        int number = Convert.ToInt32(className.Substring(className.IndexOf("-") + 1));
        appConfig = Resources.Load<AppConfig>("Data/AppConfig1");
        var text = id.GetComponent<TextMeshProUGUI>();
        text.text = appConfig.content[number].id;
        Debug.Log(text.text);
    }

    public void LoadResourcesButton()
    {
        string s = "it-6";
        int number = Convert.ToInt32(s.Substring(s.IndexOf("-") + 1));
        appConfig = Resources.Load<AppConfig>("Data/AppConfig1");
        var text = id.GetComponent<TextMeshProUGUI>();
        text.text = appConfig.content[1].id;
        Debug.Log(text.text);
    }
}

