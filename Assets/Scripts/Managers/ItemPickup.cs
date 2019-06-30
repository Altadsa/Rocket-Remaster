using UnityEngine;

public class ItemPickup : MonoBehaviour
{ 
    [SerializeField] ItemData _data;
    [SerializeField] SpriteRenderer _renderer;
    static ItemManager _itemManager;


    private void Awake()
    {
        if (!_itemManager) _itemManager = FindObjectOfType<ItemManager>();
        _renderer.sprite = _data.Icon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _itemManager.EquipItem(_data);
            gameObject.SetActive(false);
        }
    }

}