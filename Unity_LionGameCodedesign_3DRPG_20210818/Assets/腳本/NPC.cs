using UnityEngine;

/// <summary>
/// NPC�t��
/// �����ؼЬO�_�i�J��ܽd��
/// �åB�}�ҹ�ܨt��
/// </summary>
public class NPC : MonoBehaviour
{
    #region ���P�ݩ�
    [Header("��ܸ��")]
    public DataDialogue dataDialogue;
    [Header("������T")]
    [Range(0,10)]
    public float checkPlayerRadius = 3f;
    public GameObject goTip;

    private bool startDialogueKey { get => Input.GetKeyDown(KeyCode.E); }
    
    
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0.2f, 0.3f);
        Gizmos.DrawSphere(transform.position, checkPlayerRadius);
    }

    private void Update()
    {
        goTip.SetActive(CheckPlayer());
    }

    private bool CheckPlayer()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, checkPlayerRadius, 1 << 6);
        return hits.Length > 0;
        //print("�i�J�d�򤺪����� : " + hits[0].name);
    }

    #endregion 


}
