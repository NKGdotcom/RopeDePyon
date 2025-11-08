using UnityEngine;

/// <summary>
/// ロープがグレーに触れたかどうか
/// </summary>
public class RopeFetures : MonoBehaviour
{
    private Rigidbody2D ropeRb;
    private CircleCollider2D circleCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ropeRb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //グレーはITrickPointというスクリプトを付けている、グレーのオブジェクトに触れたか
        if (ropeRb != null && collision.gameObject.TryGetComponent(out ITrickPoint itrickPoint))
        {
            HookRope();
        }
        //もし、ロープ自体が白いグレーの範囲内、もしくはキャラクター自身以外のオブジェクトに触れたとき
        //(範囲内でクリックしたら消えてしまうため)
        else if(!collision.gameObject.TryGetComponent(out CheckMouseInTrigger checkMouseInTrigger) 
            && !collision.gameObject.TryGetComponent(out InstantiateRope instantiateRope))
        {
            RetrySetRope();
        }
    }
    /// <summary>
    /// ロープをひっかける
    /// </summary>
    private void HookRope()
    {
        ropeRb.bodyType = RigidbodyType2D.Kinematic;
        ropeRb.linearVelocity = Vector2.zero;
        circleCollider.isTrigger = true;
        ChangeClickState.Instance.SetIsBeingPulled();
        PreservationOfRope.Instance.PresevationRopePos(this.gameObject);
    }
    /// <summary>
    /// もう一度ロープを生成から始める
    /// </summary>
    private void RetrySetRope()
    {
        Destroy(gameObject);
        ChangeClickState.Instance.SetIsGeneratingRope();
    }
}
