using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CharacteristicsPanel : MonoBehaviour
    {
        [SerializeField] private Player.Player _player;
        
        [SerializeField] private Button _closeButton;
        
        [SerializeField] private TMP_Text _forceText;
        [SerializeField] private TMP_Text _dexterityText;
        [SerializeField] private TMP_Text _luckText;
        [SerializeField] private TMP_Text _enduranceText;
        [SerializeField] private TMP_Text _expText;
        [SerializeField] private TMP_Text _healthText;

        [SerializeField] private Vector3 startPosition;
        [SerializeField] private Vector3 endPosition;
        [SerializeField] private float step;
        [SerializeField] private float progress;
        

        private void OnEnable()
        {
            _player.CharacteristicsChanged += UpdateView;
        }

        private void OnDisable()
        {
            _player.CharacteristicsChanged -= UpdateView;
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

        private void UpdateView(List<int> newCharacteristic, int health, int maxHealth, int exp)
        {
            _forceText.text = newCharacteristic[0].ToString();
            _dexterityText.text = newCharacteristic[1].ToString();
            _luckText.text = newCharacteristic[2].ToString();
            _enduranceText.text = newCharacteristic[3].ToString();
            _expText.text = exp.ToString();
            _healthText.text = $"{health} из {maxHealth}";
        }
    }
}