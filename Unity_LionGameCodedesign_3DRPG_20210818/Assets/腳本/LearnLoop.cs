using UnityEngine;

/// <summary>
/// �{�Ѱj��
/// while, do while, for, foreach
/// </summary>
public class LearnLoop : MonoBehaviour
{
    
    private void Start()
    {
        // �j�� Loop
        // ���ư���{�����e
        // �ݨD:��X�Ʀr 1~5

        // while �j��
        // �y�k: if (���L��) {�{�����e}      - ���L�Ȭ� true ����@��
        // �y�k: while (���L��) {�{�����e}   - ���L�Ȭ� true ������� 

        int a = 1;
        while (a < 6)
        {
            print("�j�� while : " + a);
            a++;
        }
    }


    
}
