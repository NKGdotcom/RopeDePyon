using UnityEngine;

//ロープの位置を保存する
public class PreservationOfRope : MonoBehaviour
{
    public static PreservationOfRope Instance;

    [SerializeField] private ParticleSystem hitPoint; //エフェクトの再生
    public Vector3 RopePos { get; private set; }
    private GameObject ropeObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    /// <summary>
    /// ロープの現在位置を保存
    /// </summary>
    /// <param name="_rope"></param>
    public void PresevationRopePos(GameObject _rope)
    {
        ropeObj = _rope;
        RopePos = _rope.transform.position;
        hitPoint.gameObject.transform.position = RopePos;
        hitPoint.Play();
        SoundManager.Instance.PlaySE(SESource.hitRope);
        ChangeClickState.Instance.SetIsBeingPulled();
    }
    /// <summary>
    /// 保存していたロープを削除
    /// </summary>
    public void ResetObject()
    {
        Destroy(ropeObj);
    }
}
