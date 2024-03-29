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
        //小惑星のtransformを格納する
        asteroidTransform = this.transform;
        //小惑星の座標を格納する変数としてposを用意
        asteroidPos = transform.position;
        //小惑星が降るスピードを初期化
        asteroidSpeed = 7.0f;
    }

    void Update()
    {
        AsteroidMove();
        AsteroidDestroy();
    }

    void AsteroidMove()//小惑星の動きを管理する関数
    {
        //小惑星を移動させる
        asteroidPos -= new Vector2(0, GManager.ObjectSpeed * Time.deltaTime * asteroidSpeed);
        asteroidTransform.position = asteroidPos;
    }

    void AsteroidDestroy()//小惑星が画面外に出た時に削除する関数
    {
        //画面外にでたら削除
        if (asteroidPos.y < -6f)
            Destroy(this.gameObject);
    }
}
