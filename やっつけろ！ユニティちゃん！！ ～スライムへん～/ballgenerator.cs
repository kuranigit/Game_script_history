using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballgenerator : MonoBehaviour
{
    public float _generateInterval = 3;//1�b�Ԋu�Ő���
    private float _timeCount;//�C���X�y�N�^�[�ő��삵�Ȃ��̂�private
    public GameObject _ball;


    // Update is called once per frame
    void Update()
    {
        _timeCount += Time.deltaTime;//���Ԃ��J�E���g

        if (_timeCount >= _generateInterval)
        {
            GameObject ball = Instantiate(_ball);

            Vector3 pos = new Vector3(0, 0, 80);//x�������̗����ŕς���
            pos.x = Random.Range(-20f, 15f);//-70�`70�̊Ԃ̗����𐶐�
            pos.y = Random.Range(-0f, 0f);//-70�`70�̊Ԃ̗����𐶐�
            pos.z = Random.Range(-20f, 20f);//-70�`70�̊Ԃ̗����𐶐�
            ball.transform.position = pos;//��Q���̈ʒu���w��

            _timeCount = 0;//�J�E���g�����Z�b�g
        }
    }
}
