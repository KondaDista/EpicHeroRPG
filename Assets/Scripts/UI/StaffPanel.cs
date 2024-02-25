using System;
using System.Collections.Generic;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UI
{
    public class StaffPanel : MonoBehaviour
    {
        [SerializeField] private Player.Player _player;
        
        [SerializeField] private Inventory _inventory;
        [SerializeField] private StaffElement _elementPrefab;
        [SerializeField] private Sprite[] _itemsImages;

        private List<StaffElement> _elements;

        private void Awake()
        {
            _inventory.InventoryInited.AddListener(Init);
            _inventory.InventoryChanged.AddListener(OnChangeInventory);
        }

        public void Init(List<int> staffStates)
        {
            _elements = new List<StaffElement>();

            for (int i = 0; i < staffStates.Count; i++)
            {
                var newElement = Instantiate(_elementPrefab, transform);
                _elements.Add(newElement);
                newElement.Init(_itemsImages[_elements.IndexOf(newElement)]);
                newElement.ChangeCollect(staffStates[i]);
            }

            AddMethodOnElement();
        }

        private void OnChangeInventory(int id, int newValue)
        {
            _elements[id].ChangeCollect(newValue);
        }

        private void AddMethodOnElement()
        {
            _elements[0].Button.onClick.AddListener(OnMushroom);
            _elements[1].Button.onClick.AddListener(OnTrap);
            _elements[2].Button.onClick.AddListener(OnRabbitMeat);
            _elements[3].Button.onClick.AddListener(OnBearMeat);
            _elements[4].Button.onClick.AddListener(OnPigMeat);
            _elements[5].Button.onClick.AddListener(OnWolfTail);
            _elements[6].Button.onClick.AddListener(OnFoxTail);
            _elements[7].Button.onClick.AddListener(OnKey);
            _elements[8].Button.onClick.AddListener(OnWeapon);
            _elements[9].Button.onClick.AddListener(OnPirog);
            _elements[10].Button.onClick.AddListener(OnSet);
        }
        
        #region ActionOnClick
    
        private void NoneAction()
        {
            GameLog.Instance.Log("Ничего не происходит");
        }
        
        private void OnTrap()
        {
            GameLog.Instance.Log("Вы смотрите на капкан, опасная штука");
        }
        
        private void OnKey()
        {
            GameLog.Instance.Log("Вы смотрите на ключ, Если есть ключ, значит найдется что им можно открыть");
        }
        
        private void OnWeapon()
        {
            GameLog.Instance.Log("Вы смотрите на дубину, хорошее орудие, будет чем одолеть чудище");
        }
        
        private void OnPirog()
        {
            int count = 5;
            _player.ChangeCharacteristic(0, count);
            _player.ChangeCharacteristic(3, count);
            GameLog.Instance.Log($"Вы съели пирог и ваша сила и выносливость увеличились на {count} единиц");
            _inventory.ChangeItemInInventoryAt(9, -1);
        }
        
        private void OnSet()
        {
            GameLog.Instance.Log("Вы смотрите на сеть, выглядит очень крепкой, можно будет поймать чудише ");
        }
        
        private void OnMushroom()
        {
            int count = Random.Range(-1,2);
            _player.ChangeCharacteristic(2, count);
            GameLog.Instance.Log($"Вы съели грибы и ваша удача изменилась на {count} единиц");
            _inventory.ChangeItemInInventoryAt(0, -1);
        }
        private void OnRabbitMeat()
        {
            int count = 5;
            _player.ChangeHealth(count);
            GameLog.Instance.Log($"Вы съели мясо и ваше здоровье поднялось на {count} единиц");
            _inventory.ChangeItemInInventoryAt(2, -1);
        }
        private void OnBearMeat()
        {
            int count = 1;
            _player.ChangeCharacteristic(0, count);
            GameLog.Instance.Log($"Вы съели мясо и ваша сила поднялась на {count} единиц");
            _inventory.ChangeItemInInventoryAt(3, -1);
        }
        private void OnPigMeat()
        {
            int count = -1;
            _player.ChangeCharacteristic(0, count);
            GameLog.Instance.Log($"Вы съели мясо и ваша сила опустилась на {count} единиц");
            _inventory.ChangeItemInInventoryAt(4, -1);
        }
        private void OnWolfTail()
        {
            int count = -1;
            _player.ChangeCharacteristic(1, count);
            GameLog.Instance.Log($"Вы съели мясо и ваша ловкость опустилась на {count} единиц");
            _inventory.ChangeItemInInventoryAt(5, -1);
        }
        private void OnFoxTail()
        {
            int count = 1;
            _player.ChangeCharacteristic(1, count);
            GameLog.Instance.Log($"Вы съели мясо и ваша ловкость поднялась на {count} единиц");
            _inventory.ChangeItemInInventoryAt(6, -1);
        }
        private void OnGrass()
        {
            int count = Random.Range(-1,2);
            _player.ChangeCharacteristic(3, count);
            GameLog.Instance.Log($"Вы съели траву и ваша выносливость изменилась на {count} единиц");
        }

        #endregion
    }
}