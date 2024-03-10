using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DBUpdate : MonoBehaviour
{
    // �f�[�^�x�[�X�ɏ��𑗐M���邽�߂�URL
    private string sendURL = "";

    public IEnumerator SendTime(string name,float score)
    {
        WWWForm form = new WWWForm();

        form.AddField("user_name", name);
        form.AddField("score", score.ToString("f3"));

        UnityWebRequest request = UnityWebRequest.Post(sendURL,form);

        yield return request.SendWebRequest();  // ���N�G�X�g�𑗐M���A���X�|���X��҂�

        if (request.result == UnityWebRequest.Result.Success) // ���X�|���X�̌��ʂ��`�F�b�N
        {
            Debug.Log("����");
        }
        else
        {
            Debug.Log("WebAPI Error: " + request.error);
        }
    }
}
