using UnityEngine;
using UnityEngine.Video;


namespace KID
{
    public class ThirdPersonController : MonoBehaviour
    {
        #region  欄位 Field

        [Header("移動速度"), Tooltip("用來調整角色移動速度"), Range(1, 500)]
        public float speed = 10.5f;
        [Header("跳躍高度"), Range(0, 1000)]
        public int jump = 100;
        [Header("檢查地面資料")]
        [Tooltip("用來檢查角色是否在地面上")]
        public bool isGrounded;
        public Vector3 v3CheckGroundOffset;
        [Range(0, 3)]
        public float checkGroundRadius = 0.2f;
        [Header("音效檔案")]
        public AudioClip soundJump;
        public AudioClip soundGround;
        [Header("動畫參數")]
        public string animatorParWalk = "走路開關";
        public string animatorParRun = "跑步開關";
        public string animatorParHurt = "受傷觸發";
        public string animatorParDead = "死亡開關";
        public string animatorParJump = "跳躍觸發";
        public string animatorParIsGrounded = "是否在地板上";

        private AudioSource aud;
        private Rigidbody rig;
        private Animator ani;

        /// <summary>
        /// 攝影機類別
        /// </summary>
        private ThirdPersonCamera thirdPersonCamera;

        #region Unity 資料類型

        public Animation ainOld;
        public Light lig;
        public Camera cam;

        #endregion

        #endregion

        #region  屬性 Property
        //跳躍按鍵
        private bool keyJump { get => Input.GetKeyDown(KeyCode.Space); }
        //屬性音量
        private float volumeRandom { get => Random.Range(0.7f, 1.2f); }
        #endregion

        #region  方法 Method
        /// <summary>
        /// 移動
        /// </summary>
        /// <param name="speedMove">移動速度</param>
        private void Move(float speedMove)
        {
            rig.velocity =
                transform.forward * MoveInput("Vertical") * speedMove +
                transform.right * MoveInput("Horizontal") * speedMove +
                Vector3.up * rig.velocity.y;
        }

        private float MoveInput(string axisName)
        {
            return Input.GetAxis(axisName);
        }

        private void Test()
        {
            print("我是自訂方法~");
        }

        private int ReturnJump()
        {
            return 999;
        }

        private void Skill(int damage, string effect = "灰塵特效", string sound = "嘎嘎嘎")
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

        #endregion

        public GameObject playerObject;

        /// <summary>
        /// 檢查地板
        /// </summary>
        private bool CheckGround()
        {
            // 物理.覆蓋球體(中心點.半徑.圖層)
            Collider[] hits = Physics.OverlapSphere(
                transform.position +
                transform.right * v3CheckGroundOffset.x +
                transform.up * v3CheckGroundOffset.y +
                transform.forward * v3CheckGroundOffset.z,
                checkGroundRadius, 1 << 3);

            //print("球體碰到的第一個物件:" + hits[0].name);
            //如果 尚未落地 並且 落地碰撞陣列大於 0 就 撥放一次音效
            if (!isGrounded && hits.Length > 0) aud.PlayOneShot(soundGround, volumeRandom);
            isGrounded = hits.Length > 0;

            //傳回 碰撞陣列數量 > 0 - 只要碰到指定圖層物件就代表在地面上
            return hits.Length > 0;

        }

        // <summary>
        /// 跳躍
        /// </summary>
        private void Jump()
        {
            //print("是否在地面上:" + CheckGround());

            // 並且 &&
            // 如果 在地面上 並且 按下空白建 就 跳躍
            if (CheckGround() && Input.GetKeyDown(KeyCode.Space))
            {
                //剛體.添加推力(此物件的上方 * 跳躍);
                //宜修翻譯:(給予方向 * 力道(jump已 public int 在欄位))
                rig.AddForce(transform.up * jump);
                aud.PlayOneShot(soundJump, Random.Range(0.7f, 1.5f));
            }
        }

        /// <summary>
        /// 更新動畫
        /// </summary>
        private void UpdateAnimation()
        {
            // 預期成果:
            // 按下前或後時 將布林值設為true
            // 沒有按時 將布林值設為 false
            // Input
            // if (選擇條件)
            // != == 比較運算子 (選擇條件)
            #region 宜修試做
            /**if ( Input.GetKey(KeyCode.W )|| Input.GetKey(KeyCode.S ))
           {
               ani.SetBool(animatorParWalk, true);
           }
           else 
           {
               ani.SetBool(animatorParWalk, false );
           }*/
            #endregion
            // 老師示範
            // 當玩家往前或後移時 true
            // 沒有按下前或後時 false
            // 垂直值 不等於 0 就代表 true
            // 垂直值 等於 0 就代表 false

            // 前後不等於 0 或 左右不等於 0 都是走路
            ani.SetBool(animatorParWalk, MoveInput("Vertical") != 0 || MoveInput("Horizontal") != 0);
            //設定是否在地板上 動畫參數
            ani.SetBool(animatorParIsGrounded, isGrounded);
            // 如果 按下 跳躍鍵 就 設定跳躍觸發參數
            // 判斷式 只有一行敘述(只有一個分號)可以省略 大括號
            if (keyJump) ani.SetTrigger(animatorParJump);
        }

        [Header("面向速度"), Range(0, 50)]
        public float speedLookAt = 2;
        /// <summary>
        /// 面向前方:面向攝影機前方位置
        /// </summary>
        private void LookAtForward()
        {
            //垂直軸向 取絕對值 後 大於 0.1 就處理 面向
            if (Mathf.Abs(MoveInput("Vertical")) > 0.1f)
            {
                //取得前方角度 = 四元.面向角度(前方座標 - 本身座標)
                Quaternion angle = Quaternion.LookRotation(thirdPersonCamera.posForward - transform.position);
                //此物件的角度 = 四元.插值
                transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * speedLookAt);
            }
        }
        #region  事件 Event
        //特定時間點會執行的方法，程式的入口 Start 等於 Console Main
        //開始事件:遊戲開始時執行一次_處裏初始化，取的資料等等
        private void Start()
        {

            Skill100();
            Skill200();
            //呼叫有參數方法時 . 必須輸入有對應的引數
            Skill(300);
            Skill(999, "爆炸特效");
            //需求:傷害值 500 ,特效用預設值 ,音效用 咻咻咻
            //有多個選填式參數時可使用指名參數語法:參數名稱:值
            Skill(500, sound: "咻咻咻");


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
            ani = GetComponent<Animator>();

            //攝影機類別 = 透過類型尋找物件<泛型>();
            //
            thirdPersonCamera = FindObjectOfType<ThirdPersonCamera>();
        }

        //更新事件:一秒約執行 60 次. 60 FPS_Frame Per Second
        //處理持續性運動、移動物件、監聽玩家輸入按鍵
        private void Update()
        {
            Jump();
            UpdateAnimation();
            LookAtForward();
        }

        // 固定更新事件:固定 0.02 秒執行一次 - 50 FPS
        // 處理物理行為.例如:Rigidbody API
        private void FixedUpdate()
        {
            Move(speed);
        }

        //繪製圖示事件
        //在Unity Editor 內繪製圖示輔助開發 . 發布後會自動隱藏
        private void OnDrawGizoms()
        {
            // 1. 指定顏色
            // 2. 繪製圖形
            Gizmos.color = new Color(1, 0, 0.2f, 0.3f);

            // transform 與此腳本在同階層的 Transform 元件
            Gizmos.DrawSphere(transform.position +
                transform.right * v3CheckGroundOffset.x +
                transform.up * v3CheckGroundOffset.y +
                transform.forward * v3CheckGroundOffset.z,
                checkGroundRadius);
        }

        #endregion
    }
}
