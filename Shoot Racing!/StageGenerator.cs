using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    //小惑星のプレハブ変数をつくる
    [SerializeField] private GameObject asteroidPrefab;
    //プレハブ変数の座標格納変数を用意
    private Vector2 asteroidPrefabPos;
    //プレイヤーの情報を取得
    [SerializeField] private GameObject player;
    /*private int[] plusMinus = {1, -1};
    private int plusMinusCount = 0;
    private float[] spanArray = { 0.2f,1.5f};
    private int spanCount = 0;*/
    //ゴールのプレハブ変数をつくる
    [SerializeField] private GameObject goalPrefab;
    //プレハブ変数の座標格納変数を用意
    private Vector2 goalPrefabPos;
    private int sumEnemyGenerate;//いくつの敵を生成したか
    private float span; //オブジェクトが降るスパンを設定
    private float currentTime;//スパンに達するまでの秒数カウンタを設定

    void Start()
    {
        sumEnemyGenerate = 0;//生成した敵の数を初期化
        currentTime = 0f;//ゲームが開始したらカウント開始
        span = 0.2f;
    }

    void Update()
    {
        StageGenerate();
    }

    void StageGenerate()//ステージ中のオブジェクトの生成を管理する関数
    {
        currentTime += GManager.GetSetStarSpeed * Time.deltaTime;

        //span秒おきに小惑星を降らせる
        if (currentTime > span)
        {
            if (sumEnemyGenerate <= 60)
            {
                SetSpan(0.5f);
                Asteroid1_400();
            }
            else if(sumEnemyGenerate <= 100)
            {
                SetSpan(0.25f);
                Asteroid1_400();
            }
            else if (sumEnemyGenerate <= 200)
            {
                SetSpan(0.15f);
                Asteroid1_400();
            }
            else if (sumEnemyGenerate <= 300)
            {
                SetSpan(0.09f);
                Asteroid1_400();
            }
            else if (sumEnemyGenerate < 410)
            {
                SetSpan(0.15f);
                Asteroid1_400();
            }
            else if(sumEnemyGenerate == 410){
                SetSpan(0.8f);
                Asteroid1_400();
            }
            else if (sumEnemyGenerate == 411)
            {
                GoalGenerate();
            }
            sumEnemyGenerate++;
            currentTime = 0f;
            Debug.Log(sumEnemyGenerate);
        }
    }

    void Asteroid1_400()
    {
        //x座標をランダムに設定
        asteroidPrefabPos = new Vector2(Random.Range(-8f,8f), 6f);
        //プレハブ生成
        Instantiate(asteroidPrefab, asteroidPrefabPos, Quaternion.identity);
    }

    /*void Asteroid5_8()
    {
        if (spanCount == 0) spanCount++;
        for (int asPos = 1; asPos <= 8; asPos++)
        {
            //x座標を設定
            asteroidPrefabPos = new Vector2(asPos * plusMinus[plusMinusCount], 6f);
            //プレハブ生成
            Instantiate(asteroidPrefab, asteroidPrefabPos, Quaternion.identity);
        }
        if (plusMinusCount == 0) plusMinusCount++;
        else plusMinusCount--;
    }*/

    void GoalGenerate()//ゴールの生成を管理する関数
    {
        Debug.Log("タイムは" + currentTime);

        if (currentTime > span)
        {
            Debug.Log("ゴールを生成します");
            for (int asPos = -8; asPos <= 8; asPos++)
            {
                //x座標をプレイヤーの移動先に設定
                goalPrefabPos = new Vector2(asPos, 6f);
                //プレハブ生成
                Instantiate(goalPrefab, goalPrefabPos, Quaternion.identity);
            }
        }

    }

    public float GetSumEnemyGenerate()
    {
        return sumEnemyGenerate;
    }

    void SetSpan(float span)
    {
        this.span = span;
    }

    public float GetSpan()
    {
        return span;
    }
}
