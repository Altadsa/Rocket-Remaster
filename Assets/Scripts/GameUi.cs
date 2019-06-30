using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameUi : MonoBehaviour
{
    [SerializeField] TMP_Text _score;
    [SerializeField] TMP_Text _stars;
    [SerializeField] TMP_Text _itemIndicator;
    [SerializeField] Image _itemImage;

    StarManager _starManager;
    ScoreManager _scoreManager;
    ItemManager _itemManager;

    private void Awake()
    {
        _starManager = FindObjectOfType<StarManager>();
        _scoreManager = FindObjectOfType<ScoreManager>();
        _itemManager = FindObjectOfType<ItemManager>();
    }

    private void Update()
    {
        UpdateStars();
        UpdateScore();
        if (_itemManager.Equipped)
        {
            _itemIndicator.text = _itemManager.Equipped.ItemRemainder.ToString();
            _itemImage.sprite = _itemManager.Equipped.Data.Icon;
        }
        else
        {
            _itemIndicator.text = "";
            _itemImage.sprite = null;
        }
    }

    private void UpdateStars()
    {
        _stars.text = _starManager.Stars.ToString();
    }

    private void UpdateScore()
    {
        _score.text = ((int)_scoreManager.Score).ToString();
    }

    private void UpdateItem()
    {
        
    }

}