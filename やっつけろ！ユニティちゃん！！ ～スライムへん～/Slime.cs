using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public Transform target;
    public float speed = 0.01f;
    public int _hp = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), 0.3f);

        transform.position += transform.forward *this.speed;

        if(_hp <= 0 || transform.position.y < -300.0f)
        {
            Destroy(gameObject);
        }
    }
}
