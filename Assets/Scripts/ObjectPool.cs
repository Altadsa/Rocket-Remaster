using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
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
        GameObject[] newObjects = new GameObject[MAX_OBJECTS];
        for (int i = 0; i < newObjects.Length; i++)
        {
            if (i < 3)
            {
                newObjects[i] =
                    _objectPool.FirstOrDefault(o => o.GetComponent<MovingObstacle>() && !newObjects.Contains(o) && !o.activeInHierarchy);
            }
            else if (i < 5)
            {
                newObjects[i] = _objectPool.FirstOrDefault(o =>
                    o.GetComponent<StarShard>() && !newObjects.Contains(o) && !o.activeInHierarchy);
            }
            else if (i < 6)
            {
                newObjects[i] = _objectPool.FirstOrDefault(o =>
                    o.GetComponent<ItemPickup>() && !newObjects.Contains(o) && !o.activeInHierarchy);
            }
            else
            {
                newObjects[i] = _objectPool.FirstOrDefault(o => o.GetComponent<StaticObstacle>() && !newObjects.Contains(o) && !o.activeInHierarchy);
            }
        }

        return newObjects;
    }

}