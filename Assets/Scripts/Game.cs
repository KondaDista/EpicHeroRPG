using System.Collections.Generic;
using System.Linq;
using GameConfiguration;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }
    
    [SerializeField] private DialogPanel _dialogPanel;
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

    public void StartGame()
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

    public void GoToLocation(int id)
    {
        _currenGameNode = _gameNodes.FirstOrDefault(n => n.id == id);
        _locationBuilder.Build(_currenGameNode.location);
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