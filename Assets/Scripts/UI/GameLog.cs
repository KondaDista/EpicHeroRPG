using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameLog : MonoBehaviour
{ 
    public static GameLog Instance { get; private set; }

    [SerializeField] private TMP_Text _logText;
    
    [SerializeField] private Button _closeButton;
    
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private float step;
    [SerializeField] private float progress;

    private void Awake()
    {
        Instance = this;
        _logText.text = string.Empty;
    }

    public void OpenClosePanel()
    {
        StartCoroutine(transform.localPosition == startPosition
            ? MovePanel(startPosition, endPosition)
            : MovePanel(endPosition, startPosition));
    }

    private IEnumerator MovePanel(Vector3 startPos, Vector3 endPos)
    {
        while (transform.localPosition != endPos)
        {
            transform.localPosition = Vector3.Lerp(startPos, endPos, progress);
            progress += step;
            yield return new WaitForSeconds(0.005f);
        }

        progress = 0;
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