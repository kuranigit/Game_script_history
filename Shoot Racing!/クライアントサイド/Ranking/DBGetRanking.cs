using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DBGetRanking : MonoBehaviour
{
    // データベースから情報を取得するためのURL
    private string getURL = "";

    public IEnumerator GetRankingData()
    {
        UnityWebRequest request = UnityWebRequest.Get(getURL);

        yield return request.SendWebRequest();  // リクエストを送信し、レスポンスを待つ

        if (request.result == UnityWebRequest.Result.Success) // レスポンスの結果をチェック
        {
            string returnData = request.downloadHandler.text;
            string[] datas = returnData.Split(',');

            for(int i = 0;i < datas.Length / 2; i++)
            {
                GManager.Ranking.Add(new RankingData(datas[2 * i], float.Parse(datas[2 * i + 1])));
            }
            Debug.Log("成功");
        }
        else
        {
            Debug.Log("WebAPI Error: " + request.error);

            GManager.Ranking.Add(new RankingData("error",-1f));
        }
    }
}
