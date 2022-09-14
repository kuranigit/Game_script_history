using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI使うときは忘れずに。
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    //最大HPと現在のHP。
    int maxHp = 10;
    public int currentHp;
    //Sliderを入れる
    public Slider slider;
    public GameDirector gameDirector;
    private bool birdDamageFlag = false;

    void Start()
    {
        //Sliderを満タンにする。
        slider.value = 10;
        //現在のHPを最大HPと同じに。
        currentHp = maxHp;
        Debug.Log("Start currentHp : " + currentHp);
    }
    public float CurrentHp()
    {
        return currentHp;
    }
    //ColliderオブジェクトのIsTriggerにチェック入れること。
    private void OnCollisionEnter(Collision collider)
    {
        int damage = 0;
        //Enemyタグのオブジェクトに触れると発動
        if (collider.gameObject.tag == "slime")
        {
            //ダメージは1～100の中でランダムに決める。
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

        //現在のHPからダメージを引く
        currentHp = currentHp - damage;
        Debug.Log("After currentHp : " + currentHp);

        //最大HPにおける現在のHPをSliderに反映。
        //int同士の割り算は小数点以下は0になるので、
        //(float)をつけてfloatの変数として振舞わせる。
        slider.value = currentHp;
        Debug.Log("slider.value : " + slider.value);
    }
}