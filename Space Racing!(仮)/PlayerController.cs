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

    void Start()
    {
        //プレイヤーのtransformを格納する
        myTransform = this.transform;
        //プレイヤーの座標を格納する変数としてposを用意
        pos = transform.position;
    }

    void Update()
    {
        //プレイヤーの移動方向判定
        float move = Input.GetAxisRaw("Horizontal");

        //プレイヤー移動
        pos += new Vector2(move, 0) * Time.deltaTime * 8;
        myTransform.position = pos;

        //障害物衝突時の処理
        if (colObstacle) {
            transform.Rotate(0, 0, this.rotSpeed * Time.deltaTime, Space.World);
            currentTime += Time.deltaTime;
            GManager.instance.GetSetStarSpeed = 0.5f;
        }


        //1回転したら回転終了(衝突処理が重複している場合はその回数分回転してから)
        if (currentTime > period * colObstacleCount)
        {
            this.rotSpeed = 0f;
            currentTime = 0f;
            colObstacle = false;
            myTransform.eulerAngles = Vector3.zero;
            GManager.instance.GetSetStarSpeed = 0.8f;
        }

        if (!colObstacle)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                GManager.instance.GetSetStarSpeed = 1.5f;
            }
            else
            {
                GManager.instance.GetSetStarSpeed = 0.8f;
            }
        }
        Debug.Log(GManager.instance.GetSetStarSpeed);

    }

    //もし障害物に衝突したら
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            /*//衝突処理をしている最中にさらに衝突したら重複としてカウント
            if (colObstacle) colObstacleCount++;*/

            colObstacle = true;
            Destroy(collision.gameObject);
            //period秒で一周する
            this.rotSpeed = 360f / period;
        }
    }
}
