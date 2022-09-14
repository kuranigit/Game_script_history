using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;
    private float starSpeed;
    private int sumEnemyGenerate;//いくつの敵を生成したか

    private void Awake()
    {
        if (instance == null)
        {
            Application.targetFrameRate = 60;
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //星屑のスピードのget setを記述
    public float GetSetStarSpeed
    {
        get{ return starSpeed; }
        set{ starSpeed = value; }
    }

    //生成した敵の数ののget setを記述
    public int GetSetSumEnemyGenerate
    {
        get { return sumEnemyGenerate; }
        set { sumEnemyGenerate = value; }
    }

    void InitGame()
    {
        this.starSpeed = 0.8f; //星屑のスピードを0.8に初期化
        this.sumEnemyGenerate = 0;//生成した敵の数を初期か
    }
    
    // Start is called before the first frame update
    void Start()
    {
        InitGame();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
