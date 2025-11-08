using UnityEngine;
/// <summary>
/// ロープの位置から引かれる
/// </summary>
public class BeingPulledCharacter : MonoBehaviour
{
    [SerializeField] private float pullPowerIdle;
    [SerializeField] private float minDistanceFactor = 0.2f;
    [SerializeField] private float maxDistanceFactor = 2.5f;
    [SerializeField] private float distanceMagnification = 0.3f;
    [SerializeField] private float forwardForcePower = 0.23f;
    private float pullPower;
    private Rigidbody2D characterRb;
    private Vector2 pullDir;
    private Vector2 floatingVec = new Vector2(0.0f, 4f);
    private bool isPull;

    void Start()
    {
        characterRb = GetComponent<Rigidbody2D>();
        pullPower = pullPowerIdle;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ChangeClickState.Instance.IsBeingPulled() && !isPull)
        {
            isPull = true;
            ComputePullDir();
            characterRb.AddForce(pullDir * pullPower, ForceMode2D.Impulse);
        }
    }

    /// <summary>
    /// 引っ張られる方向を定める
    /// </summary>
    private void ComputePullDir()
    {
        pullPower = pullPowerIdle; 
        Vector2 _ropePos = (Vector2)PreservationOfRope.Instance.RopePos;
        Vector2 _myPos = (Vector2)transform.position;
        Vector2 _diff = _ropePos - _myPos; //相手-自分 (ロープの位置-キャラクターの位置)
        float _distance = _diff.magnitude;
        pullDir = _diff + floatingVec;
        pullDir = pullDir.normalized; 
        // 力に距離を反映
        float _distanceFactor = Mathf.Clamp(forwardForcePower + _distance * distanceMagnification, minDistanceFactor, maxDistanceFactor); 
        // 最大値を制限して暴発防止
        pullPower *= _distanceFactor;
        Debug.Log($"距離: {_distance}, 力倍率: {_distanceFactor}");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (isPull)
        {
            PreservationOfRope.Instance.ResetObject();
            ChangeClickState.Instance.SetIsGeneratingRope();
            SetStraightRope.Instance.DisplayStraightRope();
            isPull = false;
        }
    }
}
