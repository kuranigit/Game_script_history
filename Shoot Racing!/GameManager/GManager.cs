using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour
{
    static private float starSpeed;//星屑のスピードを管理する変数
    static private int frameRate;//フレームレートの値をもつ変数
    static private float timeLimit; //経過時間を管理する変数
    [SerializeField] private Text timeUI; //経過時間を表示するテキスト変数
    static private bool goalFlag;//ゴールしたかをチェックするための変数
    [SerializeField] private Text goalUI; //ゴールしたときにタイムを表示するテキスト変数
    [SerializeField] private Text ranklUI; //ゴールしたときにランクを表示するテキスト変数
    [SerializeField] private Text endUI;
    [SerializeField] private Text goalDistanceUI;
    [SerializeField] private StageGenerator stageGenerator;

    //星屑のスピードのget setを記述
    static public float StarSpeed
    {
        get{ return starSpeed; }
        set{ starSpeed = value; }
    }

    //フレームレート数を取得するget set
    static public int FrameRate
    {
        get { return frameRate; }
        set { frameRate = value; }
    }

    //ゴールしたかをチェックするget set
    static public bool GoalFlag
    {
        get { return goalFlag; }
        set { goalFlag = value; }
    }


    void InitGame()
    {
        frameRate = 50;//フレームレートを50fpsに固定
        starSpeed = 0.8f; //星屑のスピードを0.8に初期化
        timeLimit = 0f;//スタート時の残り時間を30に初期化
        goalFlag = false;//スタート時はfalse
    }
    
    // Start is called before the first frame update
    void Start()
    {
        InitGame();
        Debug.Log("スタートメソッドが呼び出された");
    }

    // Update is called once per frame
    void Update()
    {
        if (!goalFlag)
        {
            IncreaseTimeLimit();
            DisplayTime();
            DisplayDistance();
        }
        if(goalFlag)
        {
            GoalProcess();
        }
    }

    private void IncreaseTimeLimit()//時間がたつにつれ経過時間を増やす関数
    {
        timeLimit += Time.deltaTime;
    }

    private void DisplayTime()//残り時間を表示する関数
    {
        timeUI.text = "Time:" + timeLimit.ToString("f3");
    }

    private void DisplayDistance()//ゴールまでの距離を表示する関数
    {
        goalDistanceUI.text = "Goal～" + ((410f - (stageGenerator.GetSumEnemyGenerate())) + 4f).ToString("f0") + "km";
    }

    private void GoalProcess()//ゴールをしたときの処理
    {
        timeUI.text = "";
        goalDistanceUI.text = "";
        goalUI.text = "Time:" + timeLimit.ToString("f3");
        endUI.text = "Title:Enter Exit:Esc";

        if (timeLimit < 60f)
        {
            ranklUI.text = "You are GOD!!!!!";
        }
        else if(timeLimit < 65f)
        {
            ranklUI.text = "RANK:A";
        }
        else if(timeLimit < 75f)
        {
            ranklUI.text = "RANK:B";
        }
        else if (timeLimit < 85f)
        {
            ranklUI.text = "RANK:C";
        }
        else
        {
            ranklUI.text = "RANK:D";
        }

        if (Input.GetKey(KeyCode.Escape))
        {

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
        }

        if (Input.GetKey(KeyCode.Return))
        {
            InitGame();
            SceneManager.LoadScene("TitleScene");
        }


    }
}
