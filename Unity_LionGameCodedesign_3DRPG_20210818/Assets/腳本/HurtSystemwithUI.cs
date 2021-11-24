using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �]�t���������˨t��
/// �i�H�B�̦����s
/// </summary>
public class HurtSystemwithUI : HurtSystem
{
    [Header("�n��s�����")]
    public Image imgHp;

    /// <summary>
    /// ����ĪG�M�Ϊ�����e��q
    /// </summary>
    private float hpEffectOriginal;

    // �Ƽg�����O���� override
    public override void Hurt(float damage)
    {
        // �Ӧ����������O�� �����O�������e
        base.Hurt(damage);

        StartCoroutine(HpBarEffect());
        //imgHp.fillAmount = hp / hpMax;
    }

    /// <summary>
    /// ����ĪG
    /// </summary>
    /// <returns></returns>
    private IEnumerator HpBarEffect()
    {
        while (hpEffectOriginal != hp)                      // �� ����e��q�������q
        {
            hpEffectOriginal --;                            // ����
            imgHp.fillAmount = hpEffectOriginal / hpMax;    // ��s���
            yield return new WaitForSeconds(0.01f);         // ����
        }
    }
}
