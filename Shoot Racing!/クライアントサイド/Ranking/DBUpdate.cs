using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DBUpdate : MonoBehaviour
{
    // データベースに情報を送信するためのURL
    private string sendURL = "";

    public IEnumerator SendTime(string name,float score)
    {
        WWWForm form = new WWWForm();

        form.AddField("user_name", name);
        form.AddField("score", score.ToString("f3"));

        UnityWebRequest request = UnityWebRequest.Post(sendURL,form);

        yield return request.SendWebRequest();  // リクエストを送信し、レスポンスを待つ

        if (request.result == UnityWebRequest.Result.Success) // レスポンスの結果をチェック
        {
            Debug.Log("成功");
        }
        else
        {
            Debug.Log("WebAPI Error: " + request.error);
        }
    }
}
