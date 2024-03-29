using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    private Vector2 goalPos;
    private Transform goalTransform;

    void Start()
    {
        //ゴールのtransformを格納する
       　goalTransform = this.transform;
        //ゴールの座標を格納する変数としてgoalPosを用意
        goalPos = transform.position;
    }

    void Update()
    {
        GoalMove();
    }

    void GoalMove()//ゴールの動きを管理する関数
    {
        //ゴールを移動させる
        goalPos -= new Vector2(0, GManager.ObjectSpeed * Time.deltaTime * 7);
        goalTransform.position = goalPos;
    }
}
