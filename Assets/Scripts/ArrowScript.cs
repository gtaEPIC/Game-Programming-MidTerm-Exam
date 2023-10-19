using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    private Transform _transform;
    private bool _toTop;
    private float _timePassed = 0f;
    private float _topY;
    
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distance = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        _topY = _transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        _timePassed += Time.deltaTime;
        if (_timePassed >= speed)
        {
            _toTop = !_toTop;
            _timePassed = 0f;
        }
        if (_toTop)
        {
            _transform.position = new Vector2(_transform.position.x, _topY + (distance * _timePassed / speed));
        }
        else
        {
            _transform.position = new Vector2(_transform.position.x, _topY + distance - (distance * _timePassed / speed));
        }
    }
}
