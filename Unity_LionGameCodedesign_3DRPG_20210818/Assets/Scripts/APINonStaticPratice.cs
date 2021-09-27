using UnityEngine;

public class APINonStaticPratice : MonoBehaviour
{
    public Camera cam;
    public SpriteRenderer pho;
    public Camera cam2 ;
    public SpriteRenderer pho2 ;
    public Transform pho3;
    public Rigidbody2D pho4;

    void Start()
    {
        print("攝影機的深度:" + cam.depth);
        print("圖片的顏色:" + pho.color);

        cam2.backgroundColor = Random.ColorHSV();
        pho2.flipY  = true;
    }

    
    void Update()
    {
        pho3.Rotate(0, 0, 3);
        pho4.AddForce(new Vector2(0, 10));
    }
}
