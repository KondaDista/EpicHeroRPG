using GameConfiguration;
using TMPro;
using UnityEngine;

namespace UI
{
    public class DialogPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private AnswersPanel _answersPanel;
        
        public void Init(DialogNode dialog)
        {
            text.text = dialog.text; // Назначить текст
            _answersPanel.Init(dialog.variants); // Инициализируем панель с ответами
        }
    }
}