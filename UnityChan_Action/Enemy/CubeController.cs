using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    Vector3 boxPos;
    Transform mytransform;
    [SerializeField]private float T; 
    // Start is called before the first frame update
    void Start()
    {
        mytransform = this.transform;
        boxPos = mytransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        BoxMoveHorizontal();
    }

    private void BoxMoveHorizontal()
    {
        boxPos = new Vector3(boxPos.x, 2.6f + Mathf.Sin(2 * Mathf.PI * (1 / T) * Time.time) * 2, boxPos.z);
        mytransform.position = boxPos;
    }

}
