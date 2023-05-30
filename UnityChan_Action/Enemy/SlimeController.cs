using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public Transform Player;
    public float speed = 0.01f;
    public GameObject particleObject;
    public GameObject slimePrehab;
    private Vector3 progress;
    Vector3 worldAngles;
    private bool slimePlayerFlag;

    // Start is called before the first frame update
    void Start()
    {
        progress = new Vector3(0f, 0f, -1f);
        worldAngles = transform.eulerAngles;
        worldAngles.y = 180f;
        transform.eulerAngles = worldAngles;
        slimePlayerFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Player.position - transform.position), 0.3f);
        if (Player.position.y < 0.1f && (slimePlayerFlag || Player.position.z > -10f) && Vector3.Distance(this.transform.position, Player.position) < 20f) 
        {
            transform.position += transform.forward * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Weapon")
        {
            Instantiate(particleObject, this.transform.position, Quaternion.identity);
            //Instantiate(slimePrehab, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 20.0f), Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            slimePlayerFlag = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
                slimePlayerFlag = true;
        }
    }
}
