using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCannon : MonoBehaviour
{
    [SerializeField] GameObject[] _projectiles;

    int _ammo = 10;

    float _fireRate = 1.5f;
    float _timeSinceFire = 0;

    private void OnEnable()
    {
        _ammo = 10;
        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        while (_ammo > 0)
        { 
            if (_timeSinceFire > _fireRate)
            {
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                _timeSinceFire = 0;
                _projectiles[_ammo - 1].transform.position = transform.position;
                _projectiles[_ammo - 1].SetActive(true);
                _ammo--;
            }
            else
            {
                _timeSinceFire += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }

        foreach (var proj in _projectiles)
        {
            proj.transform.position = transform.position;
            proj.SetActive(false);
        }

        gameObject.SetActive(false);
    }

}