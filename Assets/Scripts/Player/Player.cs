using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class Player: MonoBehaviour
    {
        public UnityAction<List<int>, int, int ,int> CharacteristicsChanged; // List<int> newCharacteristic, int health, int maxHealth, int exp
        
        public List<int> _characteristics;
        
        public List<int> _quests;

        [SerializeField] private string[] _characteristicNames =
            new[] { "Сила", "Ловкость", "Удача", "Выносливость"};

        private int _maxHealth;
        public int Health { get; private set; }
        public int Exp { get; private set; }

        public void Init(List<int> characteristics)
        {
            _characteristics = characteristics;
            _maxHealth = _characteristics[3] * 20;
            Health = _maxHealth;
            
            OnCharacteristicsUpdate();
            ChangeStartQuestState();
        }

        private void ChangeStartQuestState()
        {
            for (int i = 0; i < 4; i++)
            {
                _quests.Add(0);
            }
        }

        public void ChangeCharacteristic(int idCharacteristic, int valueToChangeCharacteristic)
        {
            switch (idCharacteristic)
            {
                case 4:
                    ChangeHealth(valueToChangeCharacteristic);
                    break;
                case 5:
                    ChangeEXP(valueToChangeCharacteristic);
                    break;
                default:
                    int newValue = _characteristics[idCharacteristic] + valueToChangeCharacteristic;
                    _characteristics[idCharacteristic] = newValue > 0 ? newValue : 0;

                    if (idCharacteristic == 3)
                        _maxHealth = _characteristics[3] * 20;

                    OnCharacteristicsUpdate();
                    break;
            }
        }
        
        public void ChangeHealth( int valueToChangeCharacteristic)
        {
            int newValue = Health + valueToChangeCharacteristic > 0 ? Health + valueToChangeCharacteristic : 0;
            Health = newValue > _maxHealth ? _maxHealth : newValue;
            
            OnCharacteristicsUpdate();
        }
        
        public void ChangeEXP( int valueToChangeCharacteristic)
        {
            int newValue = Exp + valueToChangeCharacteristic;
            Exp = newValue > 0 ? newValue : 0;
            
            OnCharacteristicsUpdate();
        }
        
        public void ChangeQuestState(int id, int stateQuest)
        {
            _quests[id] = stateQuest;
        }
        
        public bool IsStateQuest(int id, int value)
        {
            return _quests[id] == value;
        }

        public bool IsStatMore(int id, int value)
        {
            return _characteristics[id] > value;
        }

        public bool IsStatLess(int id, int value)
        {
            return _characteristics[id] < value;
        }

        public bool IsStatEqual(int id, int value)
        {
            return _characteristics[id] == value;
        }

        private void OnCharacteristicsUpdate()
        {
            CharacteristicsChanged?.Invoke(_characteristics, Health, _maxHealth, Exp);
        }

    }
}