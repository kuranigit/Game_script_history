using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DBGetRanking : MonoBehaviour
{
    // �f�[�^�x�[�X��������擾���邽�߂�URL
    private string getURL = "";

    public IEnumerator GetRankingData()
    {
        UnityWebRequest request = UnityWebRequest.Get(getURL);

        yield return request.SendWebRequest();  // ���N�G�X�g�𑗐M���A���X�|���X��҂�

        if (request.result == UnityWebRequest.Result.Success) // ���X�|���X�̌��ʂ��`�F�b�N
        {
            string returnData = request.downloadHandler.text;
            string[] datas = returnData.Split(',');

            for(int i = 0;i < datas.Length / 2; i++)
            {
                GManager.Ranking.Add(new RankingData(datas[2 * i], float.Parse(datas[2 * i + 1])));
            }
            Debug.Log("����");
        }
        else
        {
            Debug.Log("WebAPI Error: " + request.error);

            GManager.Ranking.Add(new RankingData("error",-1f));
        }
    }
}
