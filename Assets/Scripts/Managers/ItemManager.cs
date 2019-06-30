using System.Linq;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    RocketItem[] _items;

    RocketItem _equipped;

    public void OnGameStart()
    {
        _items = new RocketItem[transform.childCount];
        for (int i = 0; i < _items.Length; i++)
        {
            _items[i] = transform.GetChild(i).GetComponent<RocketItem>();
            _items[i].OnItemInactive += ItemInactive;
        }
    }

    public void EquipItem(ItemData data)
    {
        if (_equipped != null) return;
        _equipped = _items.First(i => i.Data.Id == data.Id);
        _equipped.gameObject.SetActive(true);
    }

    private void ItemInactive(RocketItem inactiveItem)
    {
        if (_equipped.Data.Id == inactiveItem.Data.Id)
            _equipped = null;
    }

}