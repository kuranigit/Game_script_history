using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private Vector2 asteroidPos;
    private Transform asteroidTransform;
    private float asteroidSpeed;

    void Start()
    {
        Init();
    }

    private void Init()
    {
        //���f����transform���i�[����
        asteroidTransform = this.transform;
        //���f���̍��W���i�[����ϐ��Ƃ���pos��p��
        asteroidPos = transform.position;
        //���f�����~��X�s�[�h��������
        asteroidSpeed = 7.0f;
    }

    void Update()
    {
        AsteroidMove();
        AsteroidDestroy();
    }

    void AsteroidMove()//���f���̓������Ǘ�����֐�
    {
        //���f�����ړ�������
        asteroidPos -= new Vector2(0, GManager.ObjectSpeed * Time.deltaTime * asteroidSpeed);
        asteroidTransform.position = asteroidPos;
    }

    void AsteroidDestroy()//���f������ʊO�ɏo�����ɍ폜����֐�
    {
        //��ʊO�ɂł���폜
        if (asteroidPos.y < -6f)
            Destroy(this.gameObject);
    }
}
