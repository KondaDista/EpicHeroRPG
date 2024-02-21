using System;
using System.Linq;
using GameConfiguration;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AnswerButton : MonoBehaviour
    {
        [SerializeField] private Button _mainButton;
        [SerializeField] private TMP_Text _text;
        
        private void OnValidate()
        {
            _mainButton = GetComponent<Button>();
        }

        public void Init(int number, DialogVariant variant)
        {
            _text.text = $"[{number}] {variant.text}";
            foreach (var action in variant.actions)
            {
                object[] objArray = action.parameters.Cast<object>().ToArray();
                _mainButton.onClick.AddListener(() =>
                {
                    MethodFromStringExecuter.Instance.InvokeMethod(action.name, objArray);
                    Game.Instance.SaveAnswer(variant.id);
                });
            }
            _mainButton.onClick.AddListener(() =>
            {
                GameLog.Instance.Log($"Выбран вариант: {variant.text}");
                Game.Instance.GoToDialog(variant.to);
            });
        }

        private void OnDestroy()
        {
            _mainButton.onClick.RemoveAllListeners();
        }

        public void Click() =>
            _mainButton.onClick.Invoke();
    }
}