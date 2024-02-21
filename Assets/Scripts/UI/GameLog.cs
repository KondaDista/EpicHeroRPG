using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameLog : MonoBehaviour
{ 
    public static GameLog Instance { get; private set; }

    [SerializeField] private TMP_Text _logText;
    
    [SerializeField] private Button _closeButton;

    private void Awake()
    {
        Instance = this;
        _logText.text = string.Empty;
    }

    public void OpenClosePanel()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
    
    public void ChangeActiveCloseButton()
    {
        _closeButton.interactable = !_closeButton.interactable;
    }
    
    public void Log(string text)
    {
        StringBuilder stringBuilder = new StringBuilder($"-> {text} \n");
        stringBuilder.Append(_logText.text);
        _logText.text = stringBuilder.ToString();
    }
}