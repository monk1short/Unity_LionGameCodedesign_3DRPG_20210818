using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ��������
/// ���w�n�e�����ӳ���
/// ���}��ӹC��
/// </summary>
public class SceneController : MonoBehaviour
{
    /// <summary>
    /// ���J���w����
    /// </summary>
    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    /// <summary>
    /// ���}�C��
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
