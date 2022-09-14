using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI�g���Ƃ��͖Y�ꂸ�ɁB
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    //�ő�HP�ƌ��݂�HP�B
    int maxHp = 10;
    public int currentHp;
    //Slider������
    public Slider slider;
    public GameDirector gameDirector;
    private bool birdDamageFlag = false;

    void Start()
    {
        //Slider�𖞃^���ɂ���B
        slider.value = 10;
        //���݂�HP���ő�HP�Ɠ����ɁB
        currentHp = maxHp;
        Debug.Log("Start currentHp : " + currentHp);
    }
    public float CurrentHp()
    {
        return currentHp;
    }
    //Collider�I�u�W�F�N�g��IsTrigger�Ƀ`�F�b�N����邱�ƁB
    private void OnCollisionEnter(Collision collider)
    {
        int damage = 0;
        //Enemy�^�O�̃I�u�W�F�N�g�ɐG���Ɣ���
        if (collider.gameObject.tag == "slime")
        {
            //�_���[�W��1�`100�̒��Ń����_���Ɍ��߂�B
            damage = 1;
        }
        else if(collider.gameObject.tag == "bird" && !birdDamageFlag)
        {
            damage = 2;
            birdDamageFlag = true;
        }
        else if(collider.gameObject.tag == "ground")
        {
            birdDamageFlag = false;
        }
        else if(collider.gameObject.tag == "goal")
        {
            gameDirector.GoalText();
        }
        Debug.Log("damage : " + damage);

        //���݂�HP����_���[�W������
        currentHp = currentHp - damage;
        Debug.Log("After currentHp : " + currentHp);

        //�ő�HP�ɂ����錻�݂�HP��Slider�ɔ��f�B
        //int���m�̊���Z�͏����_�ȉ���0�ɂȂ�̂ŁA
        //(float)������float�̕ϐ��Ƃ��ĐU���킹��B
        slider.value = currentHp;
        Debug.Log("slider.value : " + slider.value);
    }
}