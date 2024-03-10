using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Vector2 bulletPos;
    private Transform bulletTransform;
    [SerializeField] private GameObject explosionPrefab;//爆発エフェクトのプレハブ変数をつくる
    private Vector2 explosionPrefabPos;//爆発エフェクト変数の座標格納変数を用意

    void Start()
    {
        //弾のtransformを格納する
        bulletTransform = this.transform;
        //弾の座標を格納する変数としてbulletPosを用意
        bulletPos = transform.position;
    }

    void Update()
    {
        BulletMove();
        BulletDestroy();
    }

    void BulletMove()//弾の動きを管理する関数
    {
        //弾を移動させる
        bulletPos += new Vector2(0,Time.deltaTime * 15);
        bulletTransform.position = bulletPos;
    }

    void BulletDestroy()//弾が画面外に出たら削除する関数
    {
        //画面外にでたら削除
        if (bulletPos.y > 6f)
            Destroy(this.gameObject);
    }

    private void ExplosionGenerate()
    {
        //弾のいる座標に設定
        explosionPrefabPos = bulletPos;
        //爆発エフェクト生成
        Instantiate(explosionPrefab, explosionPrefabPos, Quaternion.identity);
    }


    //もし障害物に衝突したら
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            ExplosionGenerate();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag == "blackObstacle")
        {
            Destroy(this.gameObject);
        }
    }
}
