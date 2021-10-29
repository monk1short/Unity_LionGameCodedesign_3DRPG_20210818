using UnityEngine;

/// <summary>
/// NPC系統
/// 偵測目標是否進入對話範圍
/// 並且開啟對話系統
/// </summary>
public class NPC : MonoBehaviour
{
    #region 欄位與屬性
    [Header("對話資料")]
    public DataDialogue dataDialogue;
    [Header("相關資訊")]
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
        //print("進入範圍內的物件 : " + hits[0].name);
    }

    #endregion 


}
