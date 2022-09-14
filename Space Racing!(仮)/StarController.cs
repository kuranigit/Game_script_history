using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    private Vector2 starPos;
    private Transform starTransform;

    void Start()
    {
        //������transform���i�[����
        starTransform = this.transform;
        //�����̍��W���i�[����ϐ��Ƃ���pos��p��
        starPos = transform.position;
    }

    void Update()
    {
        //�������ړ�������
        starPos -= new Vector2(0, GManager.instance.GetSetStarSpeed * Time.deltaTime * 10);
        starTransform.position = starPos;

        //��ʊO�ɂł���폜
        if (starPos.y < -6f)
            Destroy(this.gameObject);
    }

}
