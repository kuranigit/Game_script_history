using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDestroy : MonoBehaviour
{
    public GameObject particleObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 position = new Vector3(this.transform.position.x,this.transform.position.y+2.5f,this.transform.position.z);
        Debug.Log("’¹‚ª‚â‚ç‚ê‚½");
        if (other.tag == "Weapon")
        {
            Instantiate(particleObject, position, Quaternion.identity);
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
