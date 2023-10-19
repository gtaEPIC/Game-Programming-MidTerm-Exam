using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    private bool _isOpen = false;
    public bool _playerTouching = false;
    
    [SerializeField] private Sprite openSprite;
    [SerializeField] private GameObject starPrefab;
    
    private float _timePassed = 1f;
    [SerializeField] private float spawnTime = 0.5f;
    
    void Start()
    {
        if (!openSprite) throw new System.Exception("Open sprite not set");
        if (!starPrefab) throw new System.Exception("Star prefab not set");
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isOpen && _playerTouching && Input.GetButtonDown("Interact"))
        {
            _isOpen = true;
            GetComponent<SpriteRenderer>().sprite = openSprite;
        }
        if (_isOpen)
        {
            _timePassed += Time.deltaTime;
            if (_timePassed >= spawnTime)
            {
                _timePassed = 0f;
                Instantiate(starPrefab, transform.position, Quaternion.identity);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerTouching = true;
        }   
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerTouching = false;
        }   
    }
}
