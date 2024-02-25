using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class Inventory : MonoBehaviour
    {
        public readonly List<int> Items = new List<int>();
        
        public UnityEvent<List<int>> InventoryInited;
        public UnityEvent<int, int> InventoryChanged;
    
        public void Init(List<int> staff)
        {
            staff.ForEach(o => Items.Add(o));
            InventoryInited?.Invoke(Items);
        }

        public void ChangeItemInInventoryAt(int id, int amount)
        {
            Items[id] += amount;
            if (Items[id] < 0)
                Items[id] = 0;
            
            InventoryChanged?.Invoke(id, Items[id]);
        }

        public bool IsObjectsInInventory(int id, int count)
        {
            return Items[id] >= count;
        }
        
        public bool IsObjectsEqualInInventory(int id, int count)
        {
            return Items[id] == count;
        }
    }
}

