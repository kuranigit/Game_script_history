using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    //弾のプレハブ変数をつくる
    [SerializeField] private GameObject bulletPrefab;
    //弾変数の座標格納変数を用意
    private Vector2 bulletPrefabPos;
    //プレイヤーの情報を取得
    [SerializeField] private GameObject player;
    private float interval = 0.4f; // 弾を生成する間隔
    private float timer = 0.0f; //弾を生成する間隔の時間カウント用のタイマー
    [SerializeField]private AudioClip shotSound;
    AudioSource audioSource;

    void Start()
    {
        //audioComponentを取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Xボタンがおされ、タイマー変数が0以下の時弾を発射
        if (Input.GetKey(KeyCode.Z) && timer <= 0.0f)
        {
            BulletGenerate();
        }

        // タイマーの値を減らす
        if (timer > 0.0f)
        {
            ReduceTimer();
        }
    }

    private void BulletGenerate()
    {
        //x座標をプレイヤーのいる座標に設定
        bulletPrefabPos = player.transform.position;
        //プレハブ生成
        Instantiate(bulletPrefab, bulletPrefabPos, Quaternion.identity);
        //タイマーを初期化
        timer = interval;
        //弾発射の音を鳴らす
        audioSource.PlayOneShot(shotSound,0.08f);
    }

    private void ReduceTimer()
    {
        timer -= Time.deltaTime;
    }

    
}
