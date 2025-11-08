using UnityEngine;

/// <summary>
/// 生成したロープを投げる処理
/// </summary>
public class ThrowRope : MonoBehaviour
{
    [SerializeField] private GameObject arrowPivot;
    [SerializeField] private float throwPower;
    private RopeFetures ropeFeatures;
    private Vector3 clickPos;
    private Vector2 throwDir;
    private Rigidbody2D ropeRb;
    private bool finishThrow = false;

    private void Start()
    {
        arrowPivot.SetActive(true);

        ropeRb = GetComponent<Rigidbody2D>();
        ropeFeatures = GetComponent<RopeFetures>();
        ropeRb.bodyType = RigidbodyType2D.Kinematic;
    }
    private void Update()
    {
        RotateToPullDir();

        if (Input.GetMouseButtonDown(0) && !finishThrow)
        {
            DecideThrowDir();
        }
    }

    /// <summary>
    /// 飛ばす方向を矢印で向かせる
    /// </summary>
    private void RotateToPullDir()
    {
        Vector3 _mousePos = Input.mousePosition;
        Vector3 _worldMousePos = Camera.main.ScreenToWorldPoint(_mousePos);
        _worldMousePos.z = 0f;
        Vector2 _dir = (arrowPivot.transform.position - _worldMousePos).normalized;
        float _angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
        arrowPivot.transform.rotation = Quaternion.Euler(0, 0, _angle);
    }
    /// <summary>
    /// 飛ばす方向を決めて、縄を飛ばす
    /// </summary>
    private void DecideThrowDir()
    {
        finishThrow = true;

        ropeRb.bodyType = RigidbodyType2D.Dynamic;
        clickPos = Input.mousePosition;
        Vector3 _worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        throwDir = (gameObject.transform.position) - (_worldPos); //相手-自分 (マウスの位置-ロープの位置)
        throwDir = throwDir.normalized;
        ropeRb.AddForce(throwDir * throwPower);
        ropeFeatures.enabled = true;
        arrowPivot.gameObject.SetActive(false);
    }
}
