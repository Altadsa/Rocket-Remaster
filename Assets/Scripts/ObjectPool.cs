using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    const int MAX_STATIC_OBSTACLES = 7;
    const int MAX_MOVING_OBSTACLES = 3;
    const int MAX_ITEMS = 1;
    const int MAX_STAR_SHARDS = 3;

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
        GameObject[] newObjects = new GameObject[10];
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
            else
            {
                newObjects[i] = _objectPool.FirstOrDefault(o => o.GetComponent<StaticObstacle>() && !newObjects.Contains(o) && !o.activeInHierarchy);
            }
        }

        return newObjects;
    }
}