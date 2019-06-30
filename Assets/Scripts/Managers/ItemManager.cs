using System.Linq;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    RocketItem[] _items;

    public RocketItem Equipped { get; private set; }

    public void OnGameStart()
    {
        _items = new RocketItem[transform.childCount];
        for (int i = 0; i < _items.Length; i++)
        {
            _items[i] = transform.GetChild(i).GetComponent<RocketItem>();
            _items[i].OnItemInactive += ItemInactive;
        }
    }

    public void OnGameOver()
    {
        if (Equipped)
        {
            Equipped.gameObject.SetActive(false);
            Equipped = null;
        }
    }

    public void EquipItem(ItemData data)
    {
        Equipped = _items.First(i => i.Data.Id == data.Id);
        Equipped.gameObject.SetActive(true);
    }

    private void ItemInactive(RocketItem inactiveItem)
    {
        Equipped = null;
    }

}