using UnityEngine;

/// <summary>
/// 
/// </summary>
public class APIStatic : MonoBehaviour
{
    private void Start()
    {
        int Cam = Camera .allCamerasCount ;
        print("���o�۾��ƶq:" + Cam);

        Vector2 Phy2D = Physics2D.gravity;
        print("2D�����O�j�p:" + Phy2D);

        float PI = Mathf.PI;
        print("��P�v:" + PI);

        Physics2D.gravity = new Vector2 (0, -20);

        Time.timeScale = 0.5f;

        Mathf.Floor(9.999f);

        float dist = Vector3.Distance(new Vector3(1, 1, 1), new Vector3(22, 22, 22));

       // Application.OpenURL("https://unity.com/");

    }

    private void Update()
    {
        float Gametime = Time.time ;
        print("�C���g�L�ɶ�:" + Gametime);

        bool Inp= Input.anyKey ;
        print("�O�_��J���N��:" + Inp);

        bool Space = Input.GetKeyDown(KeyCode.Space);
        print("�O�_��J�ť���:" + Space);




    }
}