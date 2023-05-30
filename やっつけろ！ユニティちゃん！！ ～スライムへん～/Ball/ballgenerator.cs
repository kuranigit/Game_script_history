using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballgenerator : MonoBehaviour
{
    public float _generateInterval = 3;//1秒間隔で生成
    private float _timeCount;//インスペクターで操作しないのでprivate
    public GameObject _ball;


    // Update is called once per frame
    void Update()
    {
        _timeCount += Time.deltaTime;//時間をカウント

        if (_timeCount >= _generateInterval)
        {
            GameObject ball = Instantiate(_ball);

            Vector3 pos = new Vector3(0, 0, 80);//x軸だけの乱数で変える
            pos.x = Random.Range(-20f, 15f);//-70～70の間の乱数を生成
            pos.y = Random.Range(-0f, 0f);//-70～70の間の乱数を生成
            pos.z = Random.Range(-20f, 20f);//-70～70の間の乱数を生成
            ball.transform.position = pos;//障害物の位置を指定

            _timeCount = 0;//カウントをリセット
        }
    }
}
