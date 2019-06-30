using System.Linq;
using UnityEngine;

public class ObjectAreaPool : MonoBehaviour
{
    [SerializeField] ObjectArea _objectAreaPrefab;
    const int MAX_AREAS = 3;

    ObjectArea[] _objectAreas = new ObjectArea[MAX_AREAS];

    private void Awake()
    {
        for (int i = 0; i < MAX_AREAS; i++)
        {
            _objectAreas[i] = Instantiate(_objectAreaPrefab, transform.position, Quaternion.identity, transform);
            _objectAreas[i].gameObject.SetActive(false);
            _objectAreas[i].BecomingInactive += NewArea;
            _objectAreas[i].IsInactive += ResetArea;
        }
    }

    private void NewArea(ObjectArea inactiveArea)
    {
        var newArea = _objectAreas.FirstOrDefault(a => a != inactiveArea);
        newArea.gameObject.SetActive(true);
    }

    private void ResetArea(ObjectArea area)
    {
        area.transform.position = transform.position;
    }

    public void OnGameStart()
    {
        _objectAreas[0].gameObject.SetActive(true);
    }

    public void OnGameOver()
    {
        foreach (var objectArea in _objectAreas)
        {
            objectArea.gameObject.SetActive(false);
            objectArea.transform.position = transform.position;
        }
    }

}
