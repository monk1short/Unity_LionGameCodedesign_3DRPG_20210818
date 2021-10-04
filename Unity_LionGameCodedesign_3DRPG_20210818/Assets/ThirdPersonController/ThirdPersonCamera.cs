using UnityEngine;

namespace KID
{
    /// <summary>
    /// �ĤT�H����v���t��
    /// �l�ܫ��w�ؼ�
    /// �åB�i�H���k�B�W�U���� (����)
    /// </summary>

    public class ThirdPersonCamera : MonoBehaviour
    {
        #region ���
        [Header("�ؼЪ���")]
        public Transform target;
        [Header("�l�ܳt��"), Range(0, 100)]
        public float speedTrack = 1.5f;
        [Header("���४�k�t��"), Range(0, 100)]
        public float speedTurnHorizontal = 5;
        [Header("����W�U�t��"), Range(0, 100)]
        public float speedTurnVertical = 5;
        [Header("x �b�W�U�������:�̤p�P�̤j��")]
        public Vector2 limitAngleX = new Vector2(-0.2f, 0.2f);
        [Header("��v���b����e��U�������:�̤p�P�̤j��")]
        public Vector2 limitAngleFromTarget = new Vector2(-0.2f, 0.2f);

        /// <summary>
        /// ��v���e��y��
        /// </summary>
        private Vector3 _posForward;
        /// <summary>
        /// �e�誺����
        /// </summary>
        private float lengthForward = 1;
        #endregion

        #region �ݩ�
        /// <summary>
        /// ���o�ƹ������y��
        /// </summary>
        private float inputMouseX { get => Input.GetAxis("Mouse X"); }
        /// <summary>
        /// ���o�ƹ������y��
        /// </summary>
        private float inputMouseY { get => Input.GetAxis("Mouse Y"); }

        /// <summary>
        /// ��v���e��y��
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

        #region �ƥ�
        private void Update()
        {
            TurnCamera();
            
            FreezeAngleZ();
        }
        // �b Update �����A�B����v���l�ܦ欰
        private void LateUpdate()
        {
            TrackTarget();
        }

        //�b�����ɤ��|���檺�ƥ�
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.2f, 0, 1, 0.3f);
            //�e��y�� = ������y�� + ������e�� * ����
            _posForward = transform.position + transform.forward * lengthForward;
            //�e��y��.y = �ؼ�.�y��.y (���e��y�Ъ����׻P�y�ЬۦP)
            _posForward.y = target.position.y;
            Gizmos.DrawSphere(_posForward, 0.15f); 
        }
        #endregion

        #region ��k
        /// <summary>
        /// �l�ܥؼ�
        /// </summary>
        private void TrackTarget()
        {
            Vector3 posTarget = target.position;           // ���o �ؼ� �y��
            Vector3 posCamera = transform.position;        // ���o ��v�� �y��

            // ��v���y�� = �t�� (�t�� * �@�ժ��ɶ�)
            posCamera = Vector3.Lerp(posCamera, posTarget, speedTrack * Time.deltaTime);

            transform.position = posCamera;                // �����󪺮y�� = ��v���y��
        }

        /// <summary>
        /// ������v��
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
            //print("��v�������׸�T :" + transform.rotation);
            Quaternion angle = transform.rotation;
            angle.x = Mathf.Clamp(angle.x, limitAngleX.x, limitAngleX.y);
            angle.z = Mathf.Clamp(angle.z, limitAngleFromTarget.x, limitAngleFromTarget.y);
            transform.rotation = angle;
        }
        
        /// <summary>
        /// �ᵲ���� Z �b���s
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
