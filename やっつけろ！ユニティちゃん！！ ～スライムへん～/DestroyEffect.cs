using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    public float _timeLimit = 2;
    private float _countup = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _countup += Time.deltaTime;
        if (_countup >= _timeLimit)
        {
            Destroy(gameObject);
        }
    }
}
