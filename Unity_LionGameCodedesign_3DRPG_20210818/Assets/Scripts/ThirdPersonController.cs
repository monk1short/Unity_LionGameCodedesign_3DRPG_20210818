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
    [Header ("���ʳt��"), Tooltip("�Ψӽվ㨤�Ⲿ�ʳt��"),Range (1,500)]
    public float speed = 10.5f;
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

    #endregion

    #region  ��k Method

    #endregion

    #region  �ƥ� Event
    //�S�w�ɶ��I�|���檺��k�A�{�����J�f Start ���� Console Main
    #endregion 
}
