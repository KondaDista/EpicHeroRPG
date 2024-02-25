using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class StaffElement : MonoBehaviour
    {
        [SerializeField] private TMP_Text _countText;
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;
        [SerializeField] private int _count;

        public Button Button => _button;
        public int CountObject => _count;
        public void Init(Sprite image, Action action = null)
        {
            if(image)
                _image.sprite = image;
        }
        
        public void ChangeCollect(int value)
        {
            _count = value;
            _countText.text = _count.ToString();
            gameObject.SetActive(_count > 0);
        }
    }
}