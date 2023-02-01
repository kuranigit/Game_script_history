using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    [SerializeField] AudioClip explosionSound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //audioComponent‚ðŽæ“¾
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(explosionSound,0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EndExplosion()
    {
        Destroy(this.gameObject);
    }
}
