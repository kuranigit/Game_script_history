using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    private Vector2 starPos;
    private Transform starTransform;

    void Start()
    {
        //星屑のtransformを格納する
        starTransform = this.transform;
        //星屑の座標を格納する変数としてposを用意
        starPos = transform.position;
    }

    void Update()
    {
        //星屑を移動させる
        starPos -= new Vector2(0, GManager.instance.GetSetStarSpeed * Time.deltaTime * 10);
        starTransform.position = starPos;

        //画面外にでたら削除
        if (starPos.y < -6f)
            Destroy(this.gameObject);
    }

}
