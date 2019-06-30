using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class ObjectArea : MonoBehaviour
{
    const int AREA_ROWS = 7;
    const int AREA_COLUMNS = 5;
    [SerializeField] float _travelSpeed;

    ObjectPool _objectPool;

    Transform[,] _points = new Transform[0,0];
    bool[,] _occupiedPoints = new bool[0,0];

    public event Action<ObjectArea> BecomingInactive;
    public event Action<ObjectArea> IsInactive;

    bool _isBecomingInactive = false;

    private void Awake()
    {
        _objectPool = FindObjectOfType<ObjectPool>();
        _points = new Transform[AREA_ROWS, AREA_COLUMNS];
        _occupiedPoints = new bool[AREA_ROWS, AREA_COLUMNS];
        for (int i = 0; i < AREA_ROWS; i++)
        {
            for (int j = 0; j < AREA_COLUMNS; j++)
            {
                _points[i,j] = transform.GetChild(i * AREA_COLUMNS + j);
                _occupiedPoints[i,j] = false;
            }

        }
    }

    private void OnEnable()
    {
        var newObjects = _objectPool.AreaObjects();
        for (int i = 0; i < newObjects.Length; i++)
        {
            AddObjectToArea(newObjects[i]);
        }
    }

    private void AddObjectToArea(GameObject go)
    {
        var newPosition = GetRandomSpace(go.GetComponent<MovingObstacle>());
        go.transform.parent = newPosition;
        go.transform.position = newPosition.position;
        go.SetActive(true);
    }

    private Transform GetRandomSpace(bool needsRow)
    {
        int rJ = Random.Range(0, AREA_COLUMNS);
        int rI = Random.Range(0, AREA_ROWS);
        if (!_occupiedPoints[rI, rJ])
        {
            if (needsRow)
            {
                for (int i = 0; i < AREA_COLUMNS; i++)
                {
                    _occupiedPoints[rI,i] = true;
                }
                return _points[rI, rJ];
            }

            _occupiedPoints[rI, rJ] = true;
            return _points[rI, rJ];
        }

        return GetRandomSpace(needsRow);
    }

    private void OnDisable()
    {
        if (!_objectPool) return;
        _isBecomingInactive = false;
        IsInactive?.Invoke(this);
        for (int i = 0; i < AREA_ROWS; i++)
        {
            for (int j = 0; j < AREA_COLUMNS; j++)
            {
                if (_points[i,j].childCount > 0)
                {
                    var go = _points[i,j].GetChild(0);
                    go.transform.parent = _objectPool.transform;
                    go.gameObject.SetActive(false);
                    _occupiedPoints[i,j] = false;
                }
                if (_occupiedPoints[i,j]) _occupiedPoints[i,j] = false;
            }

        }
    }

    private void Update()
    {
        transform.position += Vector3.down * _travelSpeed * Time.deltaTime;
        if (transform.position.y < 0 && !_isBecomingInactive)
        {
            BecomingInactive?.Invoke(this);
            _isBecomingInactive = true;
        }

        if (transform.position.y < -11)
        {

            gameObject.SetActive(false);
        }
    }
}