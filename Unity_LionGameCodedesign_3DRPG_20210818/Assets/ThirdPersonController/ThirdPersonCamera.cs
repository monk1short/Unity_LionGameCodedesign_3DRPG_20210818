using UnityEngine;

namespace KID
{
    /// <summary>
    /// 第三人稱攝影機系統
    /// 追蹤指定目標
    /// 並且可以左右、上下旋轉 (限制)
    /// </summary>

    public class ThirdPersonCamera : MonoBehaviour
    {
        #region 欄位
        [Header("目標物件")]
        public Transform target;
        [Header("追蹤速度"), Range(0, 100)]
        public float speedTrack = 1.5f;
        [Header("旋轉左右速度"), Range(0, 100)]
        public float speedTurnHorizontal = 5;
        [Header("旋轉上下速度"), Range(0, 100)]
        public float speedTurnVertical = 5;
        [Header("x 軸上下旋轉機制:最小與最大值")]
        public Vector2 limitAngleX = new Vector2(-0.2f, 0.2f);
        [Header("攝影機在角色前方下旋轉機制:最小與最大值")]
        public Vector2 limitAngleFromTarget = new Vector2(-0.2f, 0.2f);

        /// <summary>
        /// 攝影機前方座標
        /// </summary>
        private Vector3 _posForward;
        /// <summary>
        /// 前方的長度
        /// </summary>
        private float lengthForward = 1;
        #endregion

        #region 屬性
        /// <summary>
        /// 取得滑鼠水平座標
        /// </summary>
        private float inputMouseX { get => Input.GetAxis("Mouse X"); }
        /// <summary>
        /// 取得滑鼠垂直座標
        /// </summary>
        private float inputMouseY { get => Input.GetAxis("Mouse Y"); }

        /// <summary>
        /// 攝影機前方座標
        /// </summary>
        public Vector3 posForward
        {
            get
            {
                _posForward = transform.position + transform.forward * lengthForward;
                _posForward.y = target.position.y;
                return _posForward;
            }
        }
        #endregion

        #region 事件
        private void Update()
        {
            TurnCamera();
            
            FreezeAngleZ();
        }
        // 在 Update 後執行，處裡攝影機追蹤行為
        private void LateUpdate()
        {
            TrackTarget();
        }

        //在執行檔不會執行的事件
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.2f, 0, 1, 0.3f);
            //前方座標 = 此物件座標 + 此物件前方 * 長度
            _posForward = transform.position + transform.forward * lengthForward;
            //前方座標.y = 目標.座標.y (讓前方座標的高度與座標相同)
            _posForward.y = target.position.y;
            Gizmos.DrawSphere(_posForward, 0.15f); 
        }
        #endregion

        #region 方法
        /// <summary>
        /// 追蹤目標
        /// </summary>
        private void TrackTarget()
        {
            Vector3 posTarget = target.position;           // 取得 目標 座標
            Vector3 posCamera = transform.position;        // 取得 攝影機 座標

            // 攝影機座標 = 差值 (速度 * 一禎的時間)
            posCamera = Vector3.Lerp(posCamera, posTarget, speedTrack * Time.deltaTime);

            transform.position = posCamera;                // 此物件的座標 = 攝影機座標
        }

        /// <summary>
        /// 旋轉攝影機
        /// </summary>
        private void TurnCamera()
        {
            transform.Rotate(
                inputMouseY * Time.deltaTime * speedTurnVertical, 
                inputMouseX * Time.deltaTime * speedTurnHorizontal, 0);

            print(transform.rotation);
        }

        private void LimitAngleXAndZFromTarget()
        {
            //print("攝影機的角度資訊 :" + transform.rotation);
            Quaternion angle = transform.rotation;
            angle.x = Mathf.Clamp(angle.x, limitAngleX.x, limitAngleX.y);
            angle.z = Mathf.Clamp(angle.z, limitAngleFromTarget.x, limitAngleFromTarget.y);
            transform.rotation = angle;
        }
        
        /// <summary>
        /// 凍結角度 Z 軸為零
        /// </summary>
        private void FreezeAngleZ()
        {
            Vector3 angle = transform.eulerAngles;
            angle.z = 0;
            transform.eulerAngles = angle;
        }
        #endregion
    }
}
