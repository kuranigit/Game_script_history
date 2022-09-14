using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    private Vector2 starPos;
    private Transform starTransform;

    void Start()
    {
        //¯‹û‚Ìtransform‚ğŠi”[‚·‚é
        starTransform = this.transform;
        //¯‹û‚ÌÀ•W‚ğŠi”[‚·‚é•Ï”‚Æ‚µ‚Äpos‚ğ—pˆÓ
        starPos = transform.position;
    }

    void Update()
    {
        //¯‹û‚ğˆÚ“®‚³‚¹‚é
        starPos -= new Vector2(0, GManager.instance.GetSetStarSpeed * Time.deltaTime * 10);
        starTransform.position = starPos;

        //‰æ–ÊŠO‚É‚Å‚½‚çíœ
        if (starPos.y < -6f)
            Destroy(this.gameObject);
    }

}
