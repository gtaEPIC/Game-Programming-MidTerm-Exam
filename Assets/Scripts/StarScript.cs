using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    private float _timePassed = 0f;
    [SerializeField] private float lifeTime = 5f;
    
    // Update is called once per frame
    void Update()
    {
        _timePassed += Time.deltaTime;
        if (_timePassed >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
