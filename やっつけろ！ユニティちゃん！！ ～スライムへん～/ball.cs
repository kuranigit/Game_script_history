using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    Rigidbody _rbody;
    public float _speed;
    public GameObject characterObject;
    public GameObject _explosion;
    Vector3 forward;
    public float _timeLimit = 5;
    private float _countup = 0;
    public int _attack = 100;
    // Start is called before the first frame update
    void Start()
    {
        forward = characterObject.transform.forward;
        _rbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rbody.velocity = forward * _speed;
        _rbody.AddForce(new Vector3(_speed, 0, 0));
        _countup += Time.deltaTime;
        if(_countup >= _timeLimit)
        {
            Destroy(gameObject);
        }
    }
    public void SetCharacterObject(GameObject characterObject)
    {
        this.characterObject = characterObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            GameObject ex = Instantiate(_explosion);
            ex.transform.position = transform.position;
            other.GetComponent<Slime>()._hp -= _attack;
            Destroy(gameObject);
        }
    }
}
