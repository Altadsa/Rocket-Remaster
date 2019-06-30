using UnityEngine;

public class StarShard : MonoBehaviour
{
    static StarManager _starManager;

    private void Awake()
    {
        if (!_starManager) _starManager = FindObjectOfType<StarManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _starManager.AddStar();
            gameObject.SetActive(false); 
        }
    }
}
