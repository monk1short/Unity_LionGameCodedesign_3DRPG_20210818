using UnityEngine;

/// <summary>
/// 
/// </summary>
public class APIStatic : MonoBehaviour
{
    private void Start()
    {
        int Cam = Camera .allCamerasCount ;
        print("取得相機數量:" + Cam);

        Vector2 Phy2D = Physics2D.gravity;
        print("2D的重力大小:" + Phy2D);

        float PI = Mathf.PI;
        print("圓周率:" + PI);

        Physics2D.gravity = new Vector2 (0, -20);

        Time.timeScale = 0.5f;

        Mathf.Floor(9.999f);

        float dist = Vector3.Distance(new Vector3(1, 1, 1), new Vector3(22, 22, 22));

       // Application.OpenURL("https://unity.com/");

    }

    private void Update()
    {
        float Gametime = Time.time ;
        print("遊戲經過時間:" + Gametime);

        bool Inp= Input.anyKey ;
        print("是否輸入任意鍵:" + Inp);

        bool Space = Input.GetKeyDown(KeyCode.Space);
        print("是否輸入空白鍵:" + Space);




    }
}