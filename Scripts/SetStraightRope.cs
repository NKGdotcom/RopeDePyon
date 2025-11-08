using UnityEngine;

public class SetStraightRope : MonoBehaviour
{
    public static SetStraightRope Instance;
    [SerializeField] private GameObject straightRope;
    [SerializeField] private GameObject charactorObj;
    private SpriteRenderer spriteRenderer;
    private Vector3 charactorPos;
    private Vector3 loopRopePos;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        charactorPos = charactorObj.transform.position;
        spriteRenderer = straightRope.GetComponent<SpriteRenderer>();
    }
    /// <summary>
    /// ロープを伸ばす
    /// </summary>
    public void ConnectRopeCharactor()
    {
        charactorPos = charactorObj.transform.position;
        loopRopePos = PreservationOfRope.Instance.RopePos;

        Vector3 _centerPos = (charactorPos + loopRopePos) / 2;
        straightRope.SetActive(true);
        straightRope.transform.position = _centerPos;

        Vector3 _dir = loopRopePos - charactorPos; //輪っかのロープ-キャラクター
        float _angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
        straightRope.transform.rotation = Quaternion.Euler(0, 0, _angle + 90f);

        float _distance = _dir.magnitude;

        Vector3 _newScale = straightRope.transform.localScale;
        _newScale.y = _distance / spriteRenderer.size.y;
        straightRope.transform.localScale = _newScale;
    }
    /// <summary>
    /// ロープを消す
    /// </summary>
    public void DisplayStraightRope()
    {
        straightRope.SetActive(false);
    }
}
