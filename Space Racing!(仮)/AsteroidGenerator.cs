using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    //小惑星のプレハブ変数をつくる
    [SerializeField] private GameObject asteroidPrefab;
    //プレハブ変数の座標格納変数を用意
    private Vector2 asteroidPrefabPos;
    //星屑が降るスパンを設定
    private float span;
    private float currentTime = 0f;
    //プレイヤーの情報を取得
    [SerializeField] private GameObject player;
    private int[] plusMinus = {1, -1};
    private int plusMinusCount = 0;
    private float[] spanArray = { 1f,1.5f};
    private int spanCount = 0;


    void Start()
    {
        
    }

    void Update()
    {
        //小惑星の生成スパンを決定
        span = spanArray[spanCount];
        currentTime += GManager.instance.GetSetStarSpeed / 60;

        //span秒おきに星屑を降らせる
        if (currentTime > span)
        {
            if (GManager.instance.GetSetSumEnemyGenerate < 5)
            {
                //x座標をプレイヤーの移動先に設定
                asteroidPrefabPos = new Vector2(player.transform.position.x + Input.GetAxis("Horizontal"), 6f);
                //プレハブ生成
                Instantiate(asteroidPrefab, asteroidPrefabPos, Quaternion.identity);
                GManager.instance.GetSetSumEnemyGenerate++;
            }
            else if (GManager.instance.GetSetSumEnemyGenerate < 8)
            {
                if (spanCount == 0) spanCount++;
                for (int asPos = 1; asPos < 9; asPos++)
                {
                    //x座標を設定
                    asteroidPrefabPos = new Vector2(asPos * plusMinus[plusMinusCount], 6f);
                    //プレハブ生成
                    Instantiate(asteroidPrefab, asteroidPrefabPos, Quaternion.identity);
                }
                GManager.instance.GetSetSumEnemyGenerate++;
                if (plusMinusCount == 0) plusMinusCount++;
                else plusMinusCount--;
            }
            currentTime = 0f;
        }
    }
}
