using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private Vector2 asteroidPos;
    private Transform asteroidTransform;

    void Start()
    {
        //小惑星のtransformを格納する
        asteroidTransform = this.transform;
        //小惑星の座標を格納する変数としてposを用意
        asteroidPos = transform.position;
    }

    void Update()
    {
        //小惑星を移動させる
        asteroidPos -= new Vector2(0, GManager.instance.GetSetStarSpeed * Time.deltaTime * 7);
        asteroidTransform.position = asteroidPos;

        //画面外にでたら削除
        if (asteroidPos.y < -6f)
            Destroy(this.gameObject);
    }
}
