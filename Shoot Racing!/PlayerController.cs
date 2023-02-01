using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 pos;
    private Transform myTransform;
    private float rotSpeed = 0f;  //プレイヤーのスピンスピード
    private float period = 0.4f;  //障害物衝突時の回転周期
    private float currentTime = 0f;
    private bool colObstacle = false; //衝突処理をしている状態かどうか(処理中の場合true)
    private int colObstacleCount = 1; //衝突処理の重複回数
    private float minX = -8f;// x軸方向の移動範囲の最小値
    private float maxX = 8f;// x軸方向の移動範囲の最大値
    [SerializeField] private AudioClip colSound;
    AudioSource audioSource;

    void Start()
    {
        //プレイヤーのtransformを格納する
        myTransform = this.transform;
        //プレイヤーの座標を格納する変数としてposを用意
        pos = transform.position;
        //audioComponentを取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        colObstacleProcess();
        PlayerMove();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //もし障害物に衝突したら
        if (collision.gameObject.tag == "obstacle")
        {
            colObstacle = true;
            Destroy(collision.gameObject);
            //period秒で一周する
            this.rotSpeed = 360f / period;
            audioSource.PlayOneShot(colSound,0.5f);
        }

        //もしゴールに衝突したら
        if (collision.gameObject.tag == "goal")
        {
            GManager.GetSetGoalFlag = true;
            Debug.Log("ゴール");
            Destroy(collision.gameObject);
        }
      
    }

    private void PlayerMove()//プレイヤー移動処理をする関数
    {
        //プレイヤーの移動方向判定
        float move = Input.GetAxisRaw("Horizontal");

        //プレイヤー移動
        pos += new Vector2(move, 0) * Time.deltaTime * 6;
        // x軸方向の移動範囲制限
        pos.x = Mathf.Clamp(pos.x,minX,maxX);

        myTransform.position = pos;

        //障害物衝突処理をしていない間はアクセルができる
        if (!colObstacle)
        {
            if (Input.GetKey(KeyCode.X))
            {
                //GManager.instance.GetSetStarSpeed = 1.2f;
                IncreasePlayerSpeed(0.7f,0.3f,1.5f);
            }
            else//何も押されていない場合
            {
                //GManager.instance.GetSetStarSpeed = 0.3f;
                ReducePlayerSpeed(2.0f,0.3f,1.5f);
            }
        }
    }

    private void IncreasePlayerSpeed(float acceleration,float minSpeed,float maxSpeed)
    {
        GManager.GetSetStarSpeed += Time.deltaTime * acceleration;
        GManager.GetSetStarSpeed = Mathf.Clamp(GManager.GetSetStarSpeed,minSpeed,maxSpeed);
    }

    private void ReducePlayerSpeed(float acceleration, float minSpeed, float maxSpeed)
    {
        GManager.GetSetStarSpeed -= Time.deltaTime * acceleration;
        GManager.GetSetStarSpeed = Mathf.Clamp(GManager.GetSetStarSpeed,minSpeed,maxSpeed);
    }

    private void colObstacleProcess()//障害物衝突処理を管理する関数 
    {
        //障害物衝突時の処理
        if (colObstacle)
        {
            transform.Rotate(0, 0, this.rotSpeed * Time.deltaTime, Space.World);
            currentTime += Time.deltaTime;
            ReducePlayerSpeed(2.5f, 0.3f, 1.2f);
        }

        //1回転したら回転終了
        if (currentTime > period * colObstacleCount)
        {
            this.rotSpeed = 0f;
            currentTime = 0f;
            colObstacle = false;
            myTransform.eulerAngles = Vector3.zero;
        }
    }
}
