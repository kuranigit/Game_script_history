using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingData
{
    private string userName;
    private float score;

    public string UserName
    {
        get { return userName; }
    }

    public float Score
    {
        get { return score; }
    }

    public RankingData(string userName,float score)
    {
        this.userName = userName;
        this.score = score;
    }
}
