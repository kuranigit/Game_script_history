using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField]private float speed = 0.1f;
    [SerializeField]private GameObject player;
    Vector3 birdPosition;
    Vector3 playerPosition;
    [SerializeField]private float dis;
    [SerializeField]private int count = 0;
    [SerializeField]private float disMeasure;
    Animator birdAnimator;
    bool flag = false;
    public GameObject particleObject;
    // Start is called before the first frame update
    void Start()
    {
        birdAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        birdPosition = player.transform.position;
        playerPosition = this.transform.position;
        dis = Vector3.Distance(birdPosition, playerPosition);
        if (dis < disMeasure && count == 0)
        {
            Debug.Log("’¹‚©‚çI");
            birdAnimator.SetBool("is_attacking", true);
            count++;
            flag = true;
        }
        else
        {
            birdAnimator.SetBool("is_attacking", false);
        }
    }

    private void FixedUpdate()
    {
        if (flag)
        {
            BirdMove();
        }
    }

    private void BirdMove()
    {
        transform.position += transform.forward * this.speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("’¹‚ª‚â‚ç‚ê‚½");
        if (other.tag == "Weapon")
        {
            Instantiate(particleObject, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
