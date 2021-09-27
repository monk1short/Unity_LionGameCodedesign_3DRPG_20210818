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
    [Header("移動速度"), Tooltip("用來調整角色移動速度"), Range(1, 500)]
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
    /* 屬性練習
    //屬性不會顯示在面板上
    //儲存資料，與欄位相同
    //差異在於:可以設定存取權限 Get Set
    //屬性語法:修飾詞 資料類型 屬性名稱 { 取; 存;}
    public int readAndWrite { get; set; }
    //唯讀屬性:只能取得 get
    public int read { get; }
    //唯讀屬性:透過 get 設定預設值,關鍵字 return為傳回值
    public int readValue
    {
        get
        {
            return 77;
        }

    }
    //唯寫屬性:禁止，必須要有 get
    //public int write {set; }
    //value 指的是指定的值
    private int _hp;
    public int hp
    {
        get { return _hp; }
        set { _hp = value; }
    }
    */


    public KeyCode keyJump { get; }

    #endregion

    #region  方法 Method
    //定義與實作較複雜程式的區塊，功能
    //方法語法:修飾詞 傳回資料類型 方法名稱 (參數1....參數N) { 程式區塊 }
    //常用回傳類型 : 無傳回 void - 此方法沒有傳回資料
    //格式化 : Ctrl + K + D (可整理排版)
    //自訂方法:
    //自訂方法需要被呼叫才會執行方法內的程式
    //名稱顏色為淡黃色 - 沒有被呼叫
    //名稱顏色為亮黃色 - 有被呼叫
    private  void Test()
    {
        print("我是自訂方法~");
    }

    private int ReturnJump()
    {
        return 999;
    }

    //參數語法 : 資料類型 參數名稱
    //有預設值的參數可以不輸入引數,選填式參數
    //※選填式參數只能放在()右邊
    private void Skill (int damage, string effect = "灰塵特效", string sound = "嘎嘎嘎")
    {
        print("參數版本 - 傷害值:" + damage);
        print("參數版本 - 技能特效:" + effect);
        print("參數版本 - 音效:" + sound);
    }

    /*錯誤:選填式參數沒有在()右邊
     * private void ErrorSkill(string effect = "灰塵特效", int damage)
     * {
     * }
    */

    //對照組:不使用參數
    //降低維護與擴充性
    private void Skill100()
    {
        print("傷害值:" + 100);
        print("技能特效");
    }

    private void Skill150()
    {
        print("傷害值:" + 150);
        print("技能特效");
    }

    private void Skill200()
    {
        print("傷害值:" + 200);
        print("技能特效");
    }
    // ※ 非必要但很重要
    //BMI = 體重 / 身高 * 身高 (公尺)
    /// <summary>
    /// 計算 BMI 方法
    /// </summary>
    /// <param name="weight">體重 單位為公斤</param>
    /// <param name="height">身高 單位為公尺</param>
    /// <param name="name">名稱 測試者名稱</param>
    /// <returns>BMI 結果</returns>
    private float BMI(float weight, float height, string name = "測試")
    {
        print(name + "的 BMI");
        return weight / (height * height);
    }
    #endregion

    public GameObject playerObject;

    #region  事件 Event
    //特定時間點會執行的方法，程式的入口 Start 等於 Console Main
    //開始事件:遊戲開始時執行一次_處裏初始化，取的資料等等
    private void Start()
    {
        print(BMI(61, 1.75f, "Rocky"));

        Skill100();
        Skill200();
        //呼叫有參數方法時 . 必須輸入有對應的引數
        Skill(300);
        Skill(999,"爆炸特效");
        //需求:傷害值 500 ,特效用預設值 ,音效用 咻咻咻
        //有多個選填式參數時可使用指名參數語法:參數名稱:值
        Skill(500, sound: "咻咻咻");

        #region 輸出 方法
        /*
        print("哈囉，沃德~");

        Debug.Log("一般訊息");
        Debug.LogWarning("警告訊息");
        Debug.LogError("錯誤訊息");
       */
        #endregion

        #region 屬性練習
        /*
        print("欄位資料 - 移動速度:" +speed);
        print("屬性資料 - 讀寫屬性:" + readAndWrite );
        speed = 20.5f;
        readAndWrite = 90;
        print("修改後的資料");
        print("欄位資料 - 移動速度:" + speed);
        print("屬性資料 - 讀寫屬性:" + readAndWrite);
        //唯讀屬性
        //read = 7;  //唯讀屬性不能設定set
        print("唯讀屬性:" + read);
        print("唯讀屬性.有預設值:" + readValue);

        //屬性存取練習
        print("HP:" + hp);
        hp = 100;
        print("HP:" + hp);
        */
        #endregion

        //呼叫自訂方法語法 : 方法名稱();
        Test();
        Test();
        //呼叫有傳回值的方法
        //1.區域變數指定傳回值 - 區域變數只能在此結構 (大括號) 內存取
        int j = ReturnJump();
        print("跳躍值:" + j);
        //2.將傳回方法當成值使用
        print("跳躍值,當值使用:" + (ReturnJump() + 1));

        //要取得腳本的遊戲物件可以使用關鍵字 gameObject

        //取得元件的方式
        //1. 物件欄位名稱.
        aud = playerObject.GetComponent(typeof(AudioSource)) as AudioSource;
        //2. 此腳本遊戲物件.取得元件<泛型>();
        rig = gameObject.GetComponent<Rigidbody>();
        //3. 取得元件<泛型>();
        //類別可以使用繼承列別(父類別)的成員，公開或保護 欄位、屬性與方法
        ani = GetComponent<Animation>();
    }

    //更新事件:一秒約執行 60 次. 60 FPS_Frame Per Second
    //處理持續性運動、移動物件、監聽玩家輸入按鍵
    private void Update()
    {
        
    }

    #endregion 
}
