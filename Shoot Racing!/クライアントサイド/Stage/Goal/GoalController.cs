using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    private Vector2 goalPos;
    private Transform goalTransform;

    void Start()
    {
        //�S�[����transform���i�[����
       �@goalTransform = this.transform;
        //�S�[���̍��W���i�[����ϐ��Ƃ���goalPos��p��
        goalPos = transform.position;
    }

    void Update()
    {
        GoalMove();
    }

    void GoalMove()//�S�[���̓������Ǘ�����֐�
    {
        //�S�[�����ړ�������
        goalPos -= new Vector2(0, GManager.ObjectSpeed * Time.deltaTime * 7);
        goalTransform.position = goalPos;
    }
}
