using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    private Vector2 starPos;
    private Transform starTransform;

    private void Start()
    {
        //������transform���i�[����
        starTransform = this.transform;
        //�����̍��W���i�[����ϐ��Ƃ���pos��p��
        starPos = transform.position;
    }

    void Update()
    {
        StarMove();
        StarDestroy();
    }

    void StarMove()//�X�^�[�̓������Ǘ�����֐�
    {
        //�������ړ�������
        starPos -= new Vector2(0, GManager.ObjectSpeed * Time.deltaTime * 10);
        starTransform.position = starPos;
    }

    void StarDestroy()//�X�^�[����ʊO�ɏo����폜����֐�
    {
        //��ʊO�ɂł���폜
        if (starPos.y < -6f)
            Destroy(this.gameObject);
    }

}
