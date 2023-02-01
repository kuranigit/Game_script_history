using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector2 enemyPos;
    private Transform enemyTransform;

    void Start()
    {
        //プレイヤーのtransformを格納する
        enemyTransform = this.transform;
        //プレイヤーの座標を格納する変数としてposを用意
        enemyPos = transform.position;
    }

    void Update()
    {
        EnemyContoroller();
    }

    void EnemyContoroller()
    {
        //星屑を移動させる
        enemyPos -= new Vector2(1 * Time.deltaTime * 10, 1 * Time.deltaTime * 10);
        enemyTransform.position = enemyPos;
    }
}
