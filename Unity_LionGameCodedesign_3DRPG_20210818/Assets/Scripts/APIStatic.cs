using UnityEngine;

/// <summary>
/// 
/// </summary>
public class APIStatic : MonoBehaviour
{
    private void Start()
    {
        #region �R�A�ݩ�
        // ���o
        // �y�k:
        // ���O�W��.�R�A�ݩ�
        float r = Random.value;
        print("���o�R�A�ݩ�.�H����:" + r);

        // �]�w Set
        // �y�k:
        // ���O�W��.�R�A�ݩ� ���w �� ;
        // ���u�n�ݨ� Read Only �N����]�w
        Cursor.visible = false;
        // Random.value = 99.9f; //�߿W�ݩʤ���]�w
        #endregion

        #region �R�A��k
        //�I�s.�Ѽ�.�Ǧ^
        //ñ��:�Ѽ�.�Ǧ^
        //�y�k:
        //���O��k.�R�A��k(�����޼�)
        float range =  Random.Range(10.5f, 20.9f);
        print("�H���d��10.5 ~ 20.9 : " + range);

        int rangeInt = Random.Range(1, 3);
        print("����H���d�� 1 ~ 3 : " + rangeInt);
        #endregion 
    }

    private void Update()
    {
        #region �R�A�ݩ�
        //print("�g�L�h�[:" + Time.timeSinceLevelLoad);
        #endregion 
    }
}
