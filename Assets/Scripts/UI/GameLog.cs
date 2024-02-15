using System.Text;
using TMPro;
using UnityEngine;

public class GameLog : MonoBehaviour
{ 
    public static GameLog Instance { get; private set; }

    [SerializeField] private TMP_Text _logText;

    private void Awake()
    {
        Instance = this;
        _logText.text = string.Empty;
    }


    public void Log(string text)
    {
        StringBuilder stringBuilder = new StringBuilder($"-> {text} \n");
        stringBuilder.Append(_logText.text);
        _logText.text = stringBuilder.ToString();
    }
}