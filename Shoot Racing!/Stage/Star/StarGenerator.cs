using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    //星屑のプレハブ変数をつくる
    [SerializeField] private GameObject starPrefab;
    //プレハブ変数の座標格納変数を用意
    private Vector2 starPrefabPos;
    //星屑が降るスパンを設定
    private float span;
    private float currentTime;

    void Start()
    {

    }

    void Update()
    {
        StarGenerate();
    }

    void StarGenerate()//スターを生成する関数
    {
        //星屑のスピードと反比例して星屑が降るスパンが決定する
        span = 0.1f;
        currentTime += GManager.StarSpeed / GManager.FrameRate;

        //span秒おきに星屑を降らせる
        if (currentTime > span)
        {
            //x座標をランダムな値に設定(画面内)
            float rnd = Random.Range(-8.0f, 8.0f);
            starPrefabPos = new Vector2(rnd, 6f);
            //プレハブ生成
            Instantiate(starPrefab, starPrefabPos, Quaternion.identity);
            currentTime = 0f;
        }
    }
}
