using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 場景控制
/// 指定要前往哪個場景
/// 離開整個遊戲
/// </summary>
public class SceneController : MonoBehaviour
{
    /// <summary>
    /// 載入指定場景
    /// </summary>
    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
