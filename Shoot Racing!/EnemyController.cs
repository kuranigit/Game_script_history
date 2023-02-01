using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector2 enemyPos;
    private Transform enemyTransform;

    void Start()
    {
        //�v���C���[��transform���i�[����
        enemyTransform = this.transform;
        //�v���C���[�̍��W���i�[����ϐ��Ƃ���pos��p��
        enemyPos = transform.position;
    }

    void Update()
    {
        EnemyContoroller();
    }

    void EnemyContoroller()
    {
        //�������ړ�������
        enemyPos -= new Vector2(1 * Time.deltaTime * 10, 1 * Time.deltaTime * 10);
        enemyTransform.position = enemyPos;
    }
}
