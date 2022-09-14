using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private Vector2 asteroidPos;
    private Transform asteroidTransform;

    void Start()
    {
        //¬˜f¯‚Ìtransform‚ğŠi”[‚·‚é
        asteroidTransform = this.transform;
        //¬˜f¯‚ÌÀ•W‚ğŠi”[‚·‚é•Ï”‚Æ‚µ‚Äpos‚ğ—pˆÓ
        asteroidPos = transform.position;
    }

    void Update()
    {
        //¬˜f¯‚ğˆÚ“®‚³‚¹‚é
        asteroidPos -= new Vector2(0, GManager.instance.GetSetStarSpeed * Time.deltaTime * 7);
        asteroidTransform.position = asteroidPos;

        //‰æ–ÊŠO‚É‚Å‚½‚çíœ
        if (asteroidPos.y < -6f)
            Destroy(this.gameObject);
    }
}
