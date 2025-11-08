using UnityEngine;
/// <summary>
/// ロープの生成
/// </summary>
public class InstantiateRope : MonoBehaviour
{
    [SerializeField] private PreservationOfCharacter preservationOfCharacter;
    [SerializeField] private GameObject ropePrefab;
    private Vector3 clickPos;
    private float cameraOffset = 10.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)
            &&ChangeClickState.Instance.IsGeneratingRope()) 
        {
            ChangeClickState.Instance.SetIsLaunching();
            GenerateRope();
        }
    }
    /// <summary>
    /// ロープ生成
    /// </summary>
    private void GenerateRope()
    {
        preservationOfCharacter.PreservationPos();

        clickPos = Input.mousePosition;
        clickPos.z = cameraOffset;

        Vector3 _worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Instantiate(ropePrefab, _worldPos, ropePrefab.transform.rotation);
    }
}
