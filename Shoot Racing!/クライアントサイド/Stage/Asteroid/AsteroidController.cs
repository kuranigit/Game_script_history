using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private Vector2 asteroidPos;
    private Transform asteroidTransform;
    private float asteroidSpeed;

    void Start()
    {
        Init();
    }

    private void Init()
    {
        //¬˜f¯‚Ìtransform‚ğŠi”[‚·‚é
        asteroidTransform = this.transform;
        //¬˜f¯‚ÌÀ•W‚ğŠi”[‚·‚é•Ï”‚Æ‚µ‚Äpos‚ğ—pˆÓ
        asteroidPos = transform.position;
        //¬˜f¯‚ª~‚éƒXƒs[ƒh‚ğ‰Šú‰»
        asteroidSpeed = 7.0f;
    }

    void Update()
    {
        AsteroidMove();
        AsteroidDestroy();
    }

    void AsteroidMove()//¬˜f¯‚Ì“®‚«‚ğŠÇ—‚·‚éŠÖ”
    {
        //¬˜f¯‚ğˆÚ“®‚³‚¹‚é
        asteroidPos -= new Vector2(0, GManager.ObjectSpeed * Time.deltaTime * asteroidSpeed);
        asteroidTransform.position = asteroidPos;
    }

    void AsteroidDestroy()//¬˜f¯‚ª‰æ–ÊŠO‚Éo‚½‚Éíœ‚·‚éŠÖ”
    {
        //‰æ–ÊŠO‚É‚Å‚½‚çíœ
        if (asteroidPos.y < -6f)
            Destroy(this.gameObject);
    }
}
