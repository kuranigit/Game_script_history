using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    //小惑星のプレハブ変数をつくる
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private GameObject blackAteroidPrefab;
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
    private int sumObstacleGenerate;//いくつの敵を生成したか
    private float span; //オブジェクトが降るスパンを設定
    private float currentTime;//スパンに達するまでの秒数カウンタを設定

    void Start()
    {
        sumObstacleGenerate = 0;//生成した敵の数を初期化
        currentTime = 0f;//ゲームが開始したらカウント開始
        span = 0.2f;
    }

    void Update()
    {
        StageGenerate();
    }

    void StageGenerate()//ステージ中の小惑星を生成管理する関数
    {
        currentTime += GManager.ObjectSpeed * Time.deltaTime;

        //span秒おきに小惑星を降らせる
        if (currentTime > span)
        {
            if (sumObstacleGenerate <= 60)
            {
                SetSpan(0.5f);
                GenerateAsteroid();
            }
            else if(sumObstacleGenerate <= 100)
            {
                SetSpan(0.25f);
                GenerateAsteroid();
            }
            else if (sumObstacleGenerate <= 200)
            {
                SetSpan(0.15f);
                if (Random.Range(1, 5) == 1) GenerateBlackAsteroid();
                else GenerateAsteroid();
            }
            else if (sumObstacleGenerate <= 300)
            {
                SetSpan(0.09f);
                if (Random.Range(1, 3) == 1) GenerateBlackAsteroid(); 
                else GenerateAsteroid();
            }
            else if (sumObstacleGenerate < 410)
            {
                SetSpan(0.15f);
                if (Random.Range(1, 4) == 1) GenerateBlackAsteroid();
                else GenerateAsteroid();
            }
            else if(sumObstacleGenerate == 410){
                SetSpan(0.8f);
                GenerateAsteroid();
            }
            else if (sumObstacleGenerate == 411)
            {
                GoalGenerate();
            }
            sumObstacleGenerate++;
            currentTime = 0f;
        }
    }

    void GenerateAsteroid()
    {
        //x座標をランダムに設定
        asteroidPrefabPos = new Vector2(Random.Range(-8f, 8f), 6f);
        //プレハブ生成
        Instantiate(asteroidPrefab, asteroidPrefabPos, Quaternion.identity);
    }

    void GenerateBlackAsteroid()
    {
        //x座標をランダムに設定
        asteroidPrefabPos = new Vector2(Random.Range(-8f, 8f), 6f);
        //プレハブ生成
        Instantiate(blackAteroidPrefab, asteroidPrefabPos, Quaternion.identity);
    }

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

    public float GetSumObstacleGenerate()
    {
        return sumObstacleGenerate;
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
