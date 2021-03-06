using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 受傷系統
/// 處裡血量、受傷與死亡
/// </summary>
public class HurtSystem : MonoBehaviour
{
    #region 欄位:公開
    [Header("血量"), Range(0, 5000)]
    public float hp = 100;
    [Header("受傷事件")]
    public UnityEvent onHurt;
    [Header("死亡事件")]
    public UnityEvent onDead;
    [Header("動畫參數:受傷與死亡")]
    public string parameterHurt = "受傷觸發";
    public string parameterDead = "死亡開關";
    #endregion

    #region 欄位:私人與保護
    private Animator ani;

    // private   私人 不允許在子類別存取
    // public    公開 允許所有類別存取
    // protected 保護 僅限子類別存取
    protected float hpMax;
    #endregion

    #region 事件
    private void Awake()
    {
        ani = GetComponent<Animator>();
        hpMax = hp;
    }
    #endregion

    #region 方法:公開
    /// <summary>
    /// 受傷
    /// </summary>
    /// 成員要被子類別複寫必須加上 virtual 虛擬
    public virtual bool Hurt(float damage)
    {
        if (ani.GetBool(parameterDead)) return true;     // 如果 死亡參數已經勾選 就跳出
        
        hp -= damage;
        ani.SetTrigger(parameterHurt);
        onHurt.Invoke();
        if (hp <= 0)
        {
            Dead();
            return true;
        }
        else return false;
    }
    #endregion

    #region 方法:私人
    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {
        ani.SetBool(parameterDead, true);
        onDead.Invoke();
    }
    #endregion 
}
