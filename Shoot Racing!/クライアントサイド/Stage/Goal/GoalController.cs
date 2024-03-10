using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    private Vector2 goalPos;
    private Transform goalTransform;

    void Start()
    {
        //ƒS[ƒ‹‚Ìtransform‚ğŠi”[‚·‚é
       @goalTransform = this.transform;
        //ƒS[ƒ‹‚ÌÀ•W‚ğŠi”[‚·‚é•Ï”‚Æ‚µ‚ÄgoalPos‚ğ—pˆÓ
        goalPos = transform.position;
    }

    void Update()
    {
        GoalMove();
    }

    void GoalMove()//ƒS[ƒ‹‚Ì“®‚«‚ğŠÇ—‚·‚éŠÖ”
    {
        //ƒS[ƒ‹‚ğˆÚ“®‚³‚¹‚é
        goalPos -= new Vector2(0, GManager.ObjectSpeed * Time.deltaTime * 7);
        goalTransform.position = goalPos;
    }
}
