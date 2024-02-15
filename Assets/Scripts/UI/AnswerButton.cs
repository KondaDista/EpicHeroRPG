using System;
using System.Linq;
using GameConfiguration;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
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
            _mainButton.onClick.AddListener(() =>
            {
                GameLog.Instance.Log($"Выбран выриант: {variant.text}");
                Game.Instance.GoToDialog(variant.to);
            });
            foreach (var action in variant.actions)
            {
                object[] objArray = action.parameters.Cast<object>().ToArray();
                _mainButton.onClick.AddListener(() =>
                {
                    MethodFromStringExecuter.Instance.InvokeMethod(action.name, objArray);
                });
                 // Привязать выполнение actions описанных в MethodFromStringExecuter к событию по нажатию кнопки ответа (с 25 по 28 строки) 
            }
        }

        private void OnDestroy()
        {
            _mainButton.onClick.RemoveAllListeners();
        }

        public void Click() =>
            _mainButton.onClick.Invoke();
    }
}