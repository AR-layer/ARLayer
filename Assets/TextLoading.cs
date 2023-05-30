using UnityEngine;
using UnityEngine.UI;

public class TextLoading : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Text _outputText1;
    [SerializeField] private Text _outputText2;
    [SerializeField] private Text _outputText3;

    [Header("Settings")]
    [SerializeField] private string _resourceFilePath1;
    [SerializeField] private string _resourceFilePath2;
    [SerializeField] private string _resourceFilePath3;

    public void LoadFile1()
    {
        var content = Resources.Load<TextAsset>(_resourceFilePath1);
        _outputText1.text = content.text;
    }

    public void LoadFile2()
    {
        var content = Resources.Load<TextAsset>(_resourceFilePath2);
        _outputText2.text = content.text;
    }

    public void LoadFile3()
    {
        var content = Resources.Load<TextAsset>(_resourceFilePath3);
        _outputText3.text = content.text;
    }
}
