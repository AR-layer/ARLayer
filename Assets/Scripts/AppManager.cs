using TMPro;
using UnityEngine;
using System;

public class AppManager : MonoBehaviour
{
    [SerializeField] private AppConfig appConfig;
    [SerializeField] private GameObject id;
    [SerializeField] private GameObject author;
    [SerializeField] private GameObject text;

    public void LoadResources(string className)
    {
        int number = GetClassNumber(className);
        appConfig = Resources.Load<AppConfig>("Data/AppConfig1");
        var idText = id.GetComponent<TextMeshProUGUI>();
        var authorName = author.GetComponent<TextMeshProUGUI>();
        var textCont = text.GetComponent<TextMeshProUGUI>();
        idText.text = appConfig.content[number].id;
        authorName.text = appConfig.content[number].person;
        textCont.text = appConfig.content[number].textContent;
    }

    private int GetClassNumber(string className)
    {
        int number = Convert.ToInt32(className.Substring(className.IndexOf("-") + 1));
        return number;
    }

    public void LoadResourcesButton()
    {
        string s = "it-6";
        int number = Convert.ToInt32(s.Substring(s.IndexOf("-") + 1));
        appConfig = Resources.Load<AppConfig>("Data/AppConfig1");
        var text = id.GetComponent<TextMeshProUGUI>();
        text.text = appConfig.content[number-4].person;
    }
}

