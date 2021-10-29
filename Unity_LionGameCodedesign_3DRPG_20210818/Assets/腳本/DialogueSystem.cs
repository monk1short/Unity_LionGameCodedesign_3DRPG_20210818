using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// ��ܨt��
/// ��ܹ�ܮءB��ܤ��e���r�ĪG
/// </summary>
public class DialogueSystem : MonoBehaviour
{
    [Header("��ܨt�λݭn����������")]
    public CanvasGroup groupDialogue;
    public Text textName;
    public Text textContent;
    public GameObject goTriangle;
    [Header("��ܶ��j"), Range(0, 10)]
    public float dialogueInterval = 0.3f;

    /// <summary>
    /// �}�l���
    /// </summary>
    public void Dialogue()
    {
        StartCoroutine(SwitchDialogueGroup());        //�Ұʨ�P�{��
    }

    private IEnumerator SwitchDialogueGroup()
    {
        for (int i = 0; i <10; i++)                   //�j����w���榸��
        {
            groupDialogue.alpha += 0.1f;              //�s�դ��� �z���� ���W
            yield return new WaitForSeconds(0.03f);   //���ݮɶ�
        }
    }
}
