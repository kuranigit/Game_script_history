using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Vector3 ofset;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindWithTag("Player");
        ofset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + ofset.x, ofset.y, player.transform.position.z + ofset.z);
    }
}
