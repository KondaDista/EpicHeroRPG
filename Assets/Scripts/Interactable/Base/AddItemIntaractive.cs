using Player;
using UnityEngine;

namespace Interactable
{
    public class AddItemIntaractive : Interactive
    {
        [SerializeField] private int _itemId, _count, _exp;

        protected override void DoAction()
        {
            MethodFromStringExecuter.Instance.ChangeItemsInInventoryByID(_itemId, _count);
            MethodFromStringExecuter.Instance.ChangeCharacteristic(5, _exp);
            gameObject.SetActive(false);
        }
    }
}