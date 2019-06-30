using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    const int MAX_STATIC_OBSTACLES = 7;
    const float STATIC_WEIGHT = 50;

    const int MAX_MOVING_OBSTACLES = 3;
    const float MOVING_WEIGHT = 25;

    const int MAX_ITEMS = 1;
    const float ITEM_WEIGHT = 5;

    const int MAX_STAR_SHARDS = 3;
    const float STAR_WEIGHT = 15;

    const int MAX_OBJECTS = 10;

    GameObject[] _objectPool;

    private void Awake()
    {
        _objectPool = new GameObject[transform.childCount];
        for (int i = 0; i < _objectPool.Length; i++)
        {
            _objectPool[i] = transform.GetChild(i).gameObject;
            _objectPool[i].SetActive(false);
        }
    }

    public GameObject[] AreaObjects()
    {
        List<GameObject> newObjects = new List<GameObject>();
        while (newObjects.Count < MAX_OBJECTS)
        {

        }

        return newObjects;
    }

}