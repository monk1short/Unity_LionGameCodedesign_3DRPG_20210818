using UnityEngine;


    /// <summary>
    /// ��ܨt�Ϊ����
    /// NPC �n��ܪ��T�Ӷ��q����
    /// �����ȫe�B���ȶi�椤�B��������
    /// </summary>
    //ScriptableObject �~�Ӧ����O�|�ܦ��}���ƪ���
    //�i�N���}����Ʒ�����O�s�b�M�� Project��
    //CreateAssetMenu ���O�ݩ�:�������O�إ߱M�פ����
    //menuName ���W�١A�i��/���h
    //fileName �ɮצW��
    [CreateAssetMenu(menuName = "ROCKY/��ܸ��", fileName = "NPC ��ܸ��")]
    public class DataDialogue : ScriptableObject
    {
        //�}�C:�O�s�ۦP������������c
        //TextArea �r����ݩʡA�i�]�w���
        [Header("���ȫe��ܤ��e"), TextArea(2,7)]
        public string[] beforeMission;
        [Header("���ȶi�椤��ܤ��e"), TextArea(2, 7)]
        public string[] missionning;
        [Header("���ȧ�����ܤ��e"), TextArea(2, 7)]
        public string[] afterMission;
        [Header("���Ȼݲy�ƶq"), Range(0, 100)]
        public int countNeed;
        //�ϥΦC�|
        //�y�k : �׹��� �C�|�W�� �۩w�q���W��;
        [Header("NPC���Ȫ��A")]
        public StateNPCMission stateNPCMission = StateNPCMission.BeforeMission;

}

 
    
   
