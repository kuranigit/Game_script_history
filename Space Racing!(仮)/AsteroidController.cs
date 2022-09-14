using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private Vector2 asteroidPos;
    private Transform asteroidTransform;

    void Start()
    {
        //���f����transform���i�[����
        asteroidTransform = this.transform;
        //���f���̍��W���i�[����ϐ��Ƃ���pos��p��
        asteroidPos = transform.position;
    }

    void Update()
    {
        //���f�����ړ�������
        asteroidPos -= new Vector2(0, GManager.instance.GetSetStarSpeed * Time.deltaTime * 7);
        asteroidTransform.position = asteroidPos;

        //��ʊO�ɂł���폜
        if (asteroidPos.y < -6f)
            Destroy(this.gameObject);
    }
}
