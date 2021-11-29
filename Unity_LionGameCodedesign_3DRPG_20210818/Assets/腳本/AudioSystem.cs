using UnityEngine;

/// <summary>
/// ���Ĩt��
/// ���ѵ��f���n���񪺭��Ī�����
/// </summary>
// ���M�Τ���ɡ� �|�n�D����G�|�۰ʲK�[���w������
// [�n�D����(����(����1)�B����(����2)...)]
[RequireComponent(typeof(AudioSource))]
public class AudioSystem : MonoBehaviour
{
    #region ���
    private AudioSource aud;
    #endregion

    #region �ƥ�
    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }
    #endregion

    #region ��k:���}
    /// <summary>
    /// �H���`���q���񭵮�
    /// </summary>
    public void PlaySound(AudioClip sound)
    {
        aud.PlayOneShot(sound);
    }

    public void PlaySoundRandomValume(AudioClip sound)
    {
        float volume = Random.Range(0.7f, 1.2f);
        aud.PlayOneShot(sound, volume);
    }

    #endregion 
}
