using UnityEngine;
using UnityEngine.Video;

public class ThirdPersonController : MonoBehaviour
{
    #region  ��� Field
    //�x�s�C����ơA�Ҧp:���ʳt�סB���D���׵���...
    //�`�Υ|�j����:��� int�B�B�I�� float�B�r�� string�B���L�� bool
    //���y�k:�׹��� ������� ���W�� (���w �w�]��) ����
    //�׹���:
    //1.���} public - ���\��L���O�s�� - ��ܦb�ݩʭ��O - �ݭn�վ㪺��Ƴ]�����}
    //2.�p�H private - �T���L���O�s�� - ���æb�ݩʭ��O - �w�]��
    //Unity�H���O�ݩʬ��D
    //��_�{���w�]�ȽЫ�...>Reset
    //����ݩ� Attribute : ���U�����
    //����ݩʻy�k:[�ݩʦW��(�ݩʭ�)]
    //Header ���D
    //Tooltip ���� : �ƹ����d�b���W�٤W�|��ܼu�X����
    //Range �d��:�i�ϥΦb�ƭ�������ƤW�A�Ҧp: int, float
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

    private AudioSource aud;
    private Rigidbody rig;
    private Animator ani;

    #region Unity �������
    /**�m�� Unity �������
    // �C�� Color
    public Color color;
    public Color white = Color.white;             //�����C��
    public Color yellow = Color.yellow;
    public Color color1 = new Color(0.5f, 0.5f, 0);          //�ۭq�C�� RGB
    public Color color2 = new Color(0, 0.5f, 0.5f, 0.5f);         //�ۭq�C�� RGBA

    // �y�� Vector 2 - 4
    public Vector2 v2;
    public Vector2 v2Right = Vector2.right;
    public Vector2 v2Up = Vector2.up;
    public Vector2 v2One = Vector2.one;
    public Vector2 v2Custom = new Vector2(7.5f, 100.9f);
    public Vector3 v3Forward = new Vector3(1, 2, 3);
    public Vector4 v4 = new Vector4(1, 2, 3, 4);

    //���� �C�|��� enum
    public KeyCode key;
    public KeyCode move = KeyCode.W;
    public KeyCode jump = KeyCode.Space;

    //�C���������:������w�w�]��
    //�s�� Project �M�פ������
    public AudioClip sound;    //���� mp3, ogg, wav
    public VideoClip video;   //�v�� MP4
    public Sprite sprite;     //�Ϥ� png, jepg - ���䴩 gif
    public Texture2D texture2D;   //2D �Ϥ� png, jpeg
    public Material material;    //����y

    //���� Componemt:�ݩʭ��O�W�i���|��
    public Transform tra;
    public Animator aniNew;
    public Animation ainOld;
    public Light lig;
    public Camera cam;
    
    //���L�C
    //1.��ĳ���n�ϥΦ��W��
    //2.�ϥιL�ɪ� API
    */
    #endregion

    #endregion

    #region  �ݩ� Property
    /* �ݩʽm��
    //�ݩʤ��|��ܦb���O�W
    //�x�s��ơA�P���ۦP
    //�t���b��:�i�H�]�w�s���v�� Get Set
    //�ݩʻy�k:�׹��� ������� �ݩʦW�� { ��; �s;}
    public int readAndWrite { get; set; }
    //��Ū�ݩ�:�u����o get
    public int read { get; }
    //��Ū�ݩ�:�z�L get �]�w�w�]��,����r return���Ǧ^��
    public int readValue
    {
        get
        {
            return 77;
        }

    }
    //�߼g�ݩ�:�T��A�����n�� get
    //public int write {set; }
    //value �����O���w����
    private int _hp;
    public int hp
    {
        get { return _hp; }
        set { _hp = value; }
    }
    */


    public KeyCode keyJump { get; }

    #endregion

    #region  ��k Method
    // �P�| ctrl + M O
    // �i�} ctrl + M L
    /// <summary>
    /// ����
    /// </summary>
    /// <param name="speedMove">���ʳt��</param>
    private void Move(float speedMove)
    {
        // �Ш��� Animator �ݩ� Apply Root Motion:�Ŀ�ɨϥΰʵe�첾��T
        // ���骺�[�t�� = �T���V�q - �[�t�ץΨӱ������T�Ӷb�V���B�ʳt��
        // �e�� * ��J�� * ���ʳt��
        //�ϥΫe�ᥪ�k�b�V�B�ʨëO���쥻���a�ߤޤO
        rig.velocity = 
            Vector3.forward * MoveInput("Vertical") * speedMove+
            Vector3.right * MoveInput("Horizontal") * speedMove+
            Vector3.up * rig.velocity.y;
    }

    private float MoveInput(string axisName)
    {
        return Input.GetAxis(axisName);
    }


    //�w�q�P��@�������{�����϶��A�\��
    //��k�y�k:�׹��� �Ǧ^������� ��k�W�� (�Ѽ�1....�Ѽ�N) { �{���϶� }
    //�`�Φ^������ : �L�Ǧ^ void - ����k�S���Ǧ^���
    //�榡�� : Ctrl + K + D (�i��z�ƪ�)
    //�ۭq��k:
    //�ۭq��k�ݭn�Q�I�s�~�|�����k�����{��
    //�W���C�⬰�H���� - �S���Q�I�s
    //�W���C�⬰�G���� - ���Q�I�s
    private  void Test()
    {
        print("�ڬO�ۭq��k~");
    }

    private int ReturnJump()
    {
        return 999;
    }

    //�Ѽƻy�k : ������� �ѼƦW��
    //���w�]�Ȫ��Ѽƥi�H����J�޼�,��񦡰Ѽ�
    //����񦡰Ѽƥu���b()�k��
    private void Skill (int damage, string effect = "�ǹЯS��", string sound = "�ǹǹ�")
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
    // �� �D���n���ܭ��n
    //BMI = �魫 / ���� * ���� (����)
    /// <summary>
    /// �p�� BMI ��k
    /// </summary>
    /// <param name="weight">�魫 ��쬰����</param>
    /// <param name="height">���� ��쬰����</param>
    /// <param name="name">�W�� ���ժ̦W��</param>
    /// <returns>BMI ���G</returns>
    private float BMI(float weight, float height, string name = "����")
    {
        print(name + "�� BMI");
        return weight / (height * height);
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

        //�Ǧ^ �I���}�C�ƶq > 0 - �u�n�I����w�ϼh����N�N��b�a���W
        return hits.Length > 0;
    
    }

    // <summary>
    /// ���D
    /// </summary>
    private void Jump()
    {
        print("�O�_�b�a���W:" + CheckGround());
    }


    #region  �ƥ� Event
    //�S�w�ɶ��I�|���檺��k�A�{�����J�f Start ���� Console Main
    //�}�l�ƥ�:�C���}�l�ɰ���@��_�B�ت�l�ơA������Ƶ���
    private void Start()
    {
        print(BMI(61, 1.75f, "Rocky"));

        Skill100();
        Skill200();
        //�I�s���ѼƤ�k�� . ������J���������޼�
        Skill(300);
        Skill(999,"�z���S��");
        //�ݨD:�ˮ`�� 500 ,�S�ĥιw�]�� ,���ĥ� ������
        //���h�ӿ�񦡰ѼƮɥi�ϥΫ��W�Ѽƻy�k:�ѼƦW��:��
        Skill(500, sound: "������");

        #region ��X ��k
        /*
        print("���o�A�U�w~");

        Debug.Log("�@��T��");
        Debug.LogWarning("ĵ�i�T��");
        Debug.LogError("���~�T��");
       */
        #endregion

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
    }

    //��s�ƥ�:�@������� 60 ��. 60 FPS_Frame Per Second
    //�B�z����ʹB�ʡB���ʪ���B��ť���a��J����
    private void Update()
    {
        CheckGround();
        Jump();
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
