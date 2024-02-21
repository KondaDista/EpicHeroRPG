using System.Collections.Generic;
using System.Linq;
using GameConfiguration;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }
    
    [SerializeField] private DialogPanel _dialogPanel;
    [SerializeField] private DialogImages _dialogImages;
    [SerializeField] private CharacteristicsPanel _characteristicsPanel;
    [SerializeField] private GameLog _globalLogPanel;
    [SerializeField] private LocationBuilder _locationBuilder;
    
    private List<GameNode> _gameNodes;
    private readonly List<int> _savedAnswersId = new List<int>();
    private GameNode _currenGameNode;
    private DialogNode _currenDialogNode;

    private void Awake()
    {
        Instance = this;
    }

    public void Init(List<GameNode> nodes)
    {
        _gameNodes = nodes;
        StartGame();
    }

    private void StartGame()
    {
        GoToDialog(0);
    }

    public void GoToDialog(int id)
    {
        var gameNode = _gameNodes.FirstOrDefault(n => 
            n.dialogs.FirstOrDefault(d => d.id == id) != null);
        if(gameNode == null) return;
        
        if(gameNode != _currenGameNode)
            GoToLocation(gameNode.id);
        
        _currenDialogNode = _currenGameNode.dialogs.FirstOrDefault(d => d.id == id);
        _dialogPanel.Init(_currenDialogNode);
    }

    private void GoToLocation(int id)
    {
        _currenGameNode = _gameNodes.FirstOrDefault(n => n.id == id);
        _locationBuilder.Build(_currenGameNode.location);
    }

    public void ChangeDialogImage(int id)
    {
        _dialogImages.ChangeImagePartner(id);
    }
    
    public void OpenCloseDialogImagePanel()
    {
        _dialogImages.OpenClosePanel();
    }
    
    public void ChangeActiveCloseButtonsInPanels()
    {
        _characteristicsPanel.ChangeActiveCloseButton();
        _globalLogPanel.ChangeActiveCloseButton();
    }
    
    public void ChangeVisibleCharacter()
    {
        _locationBuilder.ChangeVisibleCharacter();
    }

    public void SaveAnswer(int id)
    {
        _savedAnswersId.Add(id);
    }

    public bool IsAnswered(int id)
    {
        return _savedAnswersId.Contains(id);
    }
        

    public void Win()
    {
        GameLog.Instance.Log("You WIN");
    }

    public void Lose()
    {
        GameLog.Instance.Log("You LOSE");
    }

}