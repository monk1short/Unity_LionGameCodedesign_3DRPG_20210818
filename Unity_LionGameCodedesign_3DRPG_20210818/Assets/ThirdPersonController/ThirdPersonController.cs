using UnityEngine;
using UnityEngine.Video;


namespace KID
{
    public class ThirdPersonController : MonoBehaviour
    {
        #region  ��� Field

        [Header("���ʳt��"), Tooltip("�Ψӽվ㨤�Ⲿ�ʳt��"), Range(1, 500)]
        public float speed = 10.5f;
        [Header("���D����"), Range(0, 1000)]
        public int jump = 100;
        [Header("�ˬd�a�����")]
        [Tooltip("�Ψ��ˬd����O�_�b�a���W")]
        public bool isGrounded;
        public Vector3 v3CheckGroundOffset;
        [Range(0, 3)]
        public float checkGroundRadius = 0.2f;
        [Header("�����ɮ�")]
        public AudioClip soundJump;
        public AudioClip soundGround;
        [Header("�ʵe�Ѽ�")]
        public string animatorParWalk = "�����}��";
        public string animatorParRun = "�]�B�}��";
        public string animatorParHurt = "����Ĳ�o";
        public string animatorParDead = "���`�}��";
        public string animatorParJump = "���DĲ�o";
        public string animatorParIsGrounded = "�O�_�b�a�O�W";

        private AudioSource aud;
        private Rigidbody rig;
        private Animator ani;

        /// <summary>
        /// ��v�����O
        /// </summary>
        private ThirdPersonCamera thirdPersonCamera;

        #region Unity �������

        public Animation ainOld;
        public Light lig;
        public Camera cam;

        #endregion

        #endregion

        #region  �ݩ� Property
        //���D����
        private bool keyJump { get => Input.GetKeyDown(KeyCode.Space); }
        //�ݩʭ��q
        private float volumeRandom { get => Random.Range(0.7f, 1.2f); }
        #endregion

        #region  ��k Method
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="speedMove">���ʳt��</param>
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
            print("�ڬO�ۭq��k~");
        }

        private int ReturnJump()
        {
            return 999;
        }

        private void Skill(int damage, string effect = "�ǹЯS��", string sound = "�ǹǹ�")
        {
            print("�Ѽƪ��� - �ˮ`��:" + damage);
            print("�Ѽƪ��� - �ޯ�S��:" + effect);
            print("�Ѽƪ��� - ����:" + sound);
        }

        /*���~:��񦡰ѼƨS���b()�k��
         * private void ErrorSkill(string effect = "�ǹЯS��", int damage)
         * {
         * }
        */

        //��Ӳ�:���ϥΰѼ�
        //���C���@�P�X�R��
        private void Skill100()
        {
            print("�ˮ`��:" + 100);
            print("�ޯ�S��");
        }

        private void Skill150()
        {
            print("�ˮ`��:" + 150);
            print("�ޯ�S��");
        }

        private void Skill200()
        {
            print("�ˮ`��:" + 200);
            print("�ޯ�S��");
        }

        #endregion

        public GameObject playerObject;

        /// <summary>
        /// �ˬd�a�O
        /// </summary>
        private bool CheckGround()
        {
            // ���z.�л\�y��(�����I.�b�|.�ϼh)
            Collider[] hits = Physics.OverlapSphere(
                transform.position +
                transform.right * v3CheckGroundOffset.x +
                transform.up * v3CheckGroundOffset.y +
                transform.forward * v3CheckGroundOffset.z,
                checkGroundRadius, 1 << 3);

            //print("�y��I�쪺�Ĥ@�Ӫ���:" + hits[0].name);
            //�p�G �|�����a �åB ���a�I���}�C�j�� 0 �N ����@������
            if (!isGrounded && hits.Length > 0) aud.PlayOneShot(soundGround, volumeRandom);
            isGrounded = hits.Length > 0;

            //�Ǧ^ �I���}�C�ƶq > 0 - �u�n�I����w�ϼh����N�N��b�a���W
            return hits.Length > 0;

        }

        // <summary>
        /// ���D
        /// </summary>
        private void Jump()
        {
            //print("�O�_�b�a���W:" + CheckGround());

            // �åB &&
            // �p�G �b�a���W �åB ���U�ťի� �N ���D
            if (CheckGround() && Input.GetKeyDown(KeyCode.Space))
            {
                //����.�K�[���O(�����󪺤W�� * ���D);
                //�y��½Ķ:(������V * �O�D(jump�w public int �b���))
                rig.AddForce(transform.up * jump);
                aud.PlayOneShot(soundJump, Random.Range(0.7f, 1.5f));
            }
        }

        /// <summary>
        /// ��s�ʵe
        /// </summary>
        private void UpdateAnimation()
        {
            // �w�����G:
            // ���U�e�Ϋ�� �N���L�ȳ]��true
            // �S������ �N���L�ȳ]�� false
            // Input
            // if (��ܱ���)
            // != == ����B��l (��ܱ���)
            #region �y�׸հ�
            /**if ( Input.GetKey(KeyCode.W )|| Input.GetKey(KeyCode.S ))
           {
               ani.SetBool(animatorParWalk, true);
           }
           else 
           {
               ani.SetBool(animatorParWalk, false );
           }*/
            #endregion
            // �Ѯv�ܽd
            // ���a���e�ΫᲾ�� true
            // �S�����U�e�Ϋ�� false
            // ������ ������ 0 �N�N�� true
            // ������ ���� 0 �N�N�� false

            // �e�ᤣ���� 0 �� ���k������ 0 ���O����
            ani.SetBool(animatorParWalk, MoveInput("Vertical") != 0 || MoveInput("Horizontal") != 0);
            //�]�w�O�_�b�a�O�W �ʵe�Ѽ�
            ani.SetBool(animatorParIsGrounded, isGrounded);
            // �p�G ���U ���D�� �N �]�w���DĲ�o�Ѽ�
            // �P�_�� �u���@��ԭz(�u���@�Ӥ���)�i�H�ٲ� �j�A��
            if (keyJump) ani.SetTrigger(animatorParJump);
        }

        [Header("���V�t��"), Range(0, 50)]
        public float speedLookAt = 2;
        /// <summary>
        /// ���V�e��:���V��v���e���m
        /// </summary>
        private void LookAtForward()
        {
            //�����b�V ������� �� �j�� 0.1 �N�B�z ���V
            if (Mathf.Abs(MoveInput("Vertical")) > 0.1f)
            {
                //���o�e�訤�� = �|��.���V����(�e��y�� - �����y��)
                Quaternion angle = Quaternion.LookRotation(thirdPersonCamera.posForward - transform.position);
                //�����󪺨��� = �|��.����
                transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * speedLookAt);
            }
        }
        #region  �ƥ� Event
        //�S�w�ɶ��I�|���檺��k�A�{�����J�f Start ���� Console Main
        //�}�l�ƥ�:�C���}�l�ɰ���@��_�B�ت�l�ơA������Ƶ���
        private void Start()
        {

            Skill100();
            Skill200();
            //�I�s���ѼƤ�k�� . ������J���������޼�
            Skill(300);
            Skill(999, "�z���S��");
            //�ݨD:�ˮ`�� 500 ,�S�ĥιw�]�� ,���ĥ� ������
            //���h�ӿ�񦡰ѼƮɥi�ϥΫ��W�Ѽƻy�k:�ѼƦW��:��
            Skill(500, sound: "������");


            #region �ݩʽm��
            /*
            print("����� - ���ʳt��:" +speed);
            print("�ݩʸ�� - Ū�g�ݩ�:" + readAndWrite );
            speed = 20.5f;
            readAndWrite = 90;
            print("�ק�᪺���");
            print("����� - ���ʳt��:" + speed);
            print("�ݩʸ�� - Ū�g�ݩ�:" + readAndWrite);
            //��Ū�ݩ�
            //read = 7;  //��Ū�ݩʤ���]�wset
            print("��Ū�ݩ�:" + read);
            print("��Ū�ݩ�.���w�]��:" + readValue);

            //�ݩʦs���m��
            print("HP:" + hp);
            hp = 100;
            print("HP:" + hp);
            */
            #endregion

            //�I�s�ۭq��k�y�k : ��k�W��();
            Test();
            Test();
            //�I�s���Ǧ^�Ȫ���k
            //1.�ϰ��ܼƫ��w�Ǧ^�� - �ϰ��ܼƥu��b�����c (�j�A��) ���s��
            int j = ReturnJump();
            print("���D��:" + j);
            //2.�N�Ǧ^��k���Ȩϥ�
            print("���D��,��Ȩϥ�:" + (ReturnJump() + 1));

            //�n���o�}�����C������i�H�ϥ�����r gameObject

            //���o���󪺤覡
            //1. �������W��.
            aud = playerObject.GetComponent(typeof(AudioSource)) as AudioSource;
            //2. ���}���C������.���o����<�x��>();
            rig = gameObject.GetComponent<Rigidbody>();
            //3. ���o����<�x��>();
            //���O�i�H�ϥ��~�ӦC�O(�����O)�������A���}�ΫO�@ ���B�ݩʻP��k
            ani = GetComponent<Animator>();

            //��v�����O = �z�L�����M�䪫��<�x��>();
            //
            thirdPersonCamera = FindObjectOfType<ThirdPersonCamera>();
        }

        //��s�ƥ�:�@������� 60 ��. 60 FPS_Frame Per Second
        //�B�z����ʹB�ʡB���ʪ���B��ť���a��J����
        private void Update()
        {
            Jump();
            UpdateAnimation();
            LookAtForward();
        }

        // �T�w��s�ƥ�:�T�w 0.02 �����@�� - 50 FPS
        // �B�z���z�欰.�Ҧp:Rigidbody API
        private void FixedUpdate()
        {
            Move(speed);
        }

        //ø�s�ϥܨƥ�
        //�bUnity Editor ��ø�s�ϥܻ��U�}�o . �o����|�۰�����
        private void OnDrawGizoms()
        {
            // 1. ���w�C��
            // 2. ø�s�ϧ�
            Gizmos.color = new Color(1, 0, 0.2f, 0.3f);

            // transform �P���}���b�P���h�� Transform ����
            Gizmos.DrawSphere(transform.position +
                transform.right * v3CheckGroundOffset.x +
                transform.up * v3CheckGroundOffset.y +
                transform.forward * v3CheckGroundOffset.z,
                checkGroundRadius);
        }

        #endregion
    }
}
