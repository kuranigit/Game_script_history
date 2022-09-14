using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public Transform Player;
    public float speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if ((this.transform.position.z - Player.position.z) < 30)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Player.position - transform.position), 0.3f);
            transform.position += transform.forward * this.speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Weapon")
        {
            Destroy(gameObject);
        }
    }
}
