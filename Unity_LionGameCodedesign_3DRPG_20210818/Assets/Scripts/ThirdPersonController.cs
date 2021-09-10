using UnityEngine;
using UnityEngine.Video;

public class ThirdPersonController : MonoBehaviour
{
    #region  欄位 Field
    //儲存遊戲資料，例如:移動速度、跳躍高度等等...
    //常用四大類型:整數 int、浮點數 float、字串 string、布林值 bool
    //欄位語法:修飾詞 資料類型 欄位名稱 (指定 預設值) 結尾
    //修飾詞:
    //1.公開 public - 允許其他類別存取 - 顯示在屬性面板 - 需要調整的資料設為公開
    //2.私人 private - 禁止其他類別存取 - 隱藏在屬性面板 - 預設值
    //Unity以面板屬性為主
    //恢復程式預設值請按...>Reset
    //欄位屬性 Attribute : 輔助欄位資料
    //欄位屬性語法:[屬性名稱(屬性值)]
    //Header 標題
    //Tooltip 提示 : 滑鼠停留在欄位名稱上會顯示彈出視窗
    //Range 範圍:可使用在數值類型資料上，例如: int, float
    [Header ("移動速度"), Tooltip("用來調整角色移動速度"),Range (1,500)]
    public float speed = 10.5f;
    #region Unity 資料類型
    /**練習 Unity 資料類型
    // 顏色 Color
    public Color color;
    public Color white = Color.white;             //內建顏色
    public Color yellow = Color.yellow;
    public Color color1 = new Color(0.5f, 0.5f, 0);          //自訂顏色 RGB
    public Color color2 = new Color(0, 0.5f, 0.5f, 0.5f);         //自訂顏色 RGBA

    // 座標 Vector 2 - 4
    public Vector2 v2;
    public Vector2 v2Right = Vector2.right;
    public Vector2 v2Up = Vector2.up;
    public Vector2 v2One = Vector2.one;
    public Vector2 v2Custom = new Vector2(7.5f, 100.9f);
    public Vector3 v3Forward = new Vector3(1, 2, 3);
    public Vector4 v4 = new Vector4(1, 2, 3, 4);

    //按鍵 列舉資料 enum
    public KeyCode key;
    public KeyCode move = KeyCode.W;
    public KeyCode jump = KeyCode.Space;

    //遊戲資料類型:不能指定預設值
    //存放 Project 專案內的資料
    public AudioClip sound;    //音效 mp3, ogg, wav
    public VideoClip video;   //影片 MP4
    public Sprite sprite;     //圖片 png, jepg - 不支援 gif
    public Texture2D texture2D;   //2D 圖片 png, jpeg
    public Material material;    //材質球

    //元件 Componemt:屬性面板上可折疊的
    public Transform tra;
    public Animator aniNew;
    public Animation ainOld;
    public Light lig;
    public Camera cam;
    
    //綠色蚯蚓
    //1.建議不要使用此名稱
    //2.使用過時的 API
    */
    #endregion

    #endregion

    #region  屬性 Property

    #endregion

    #region  方法 Method

    #endregion

    #region  事件 Event
    //特定時間點會執行的方法，程式的入口 Start 等於 Console Main
    #endregion 
}
