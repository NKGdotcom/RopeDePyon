using UnityEngine;

/// <summary>
/// 白い範囲内の中にマウスが入っているか
/// </summary>
public class CheckMouseInTrigger : MonoBehaviour
{
    [SerializeField] private InstantiateRope instantiateRopeScript;
    private Collider2D col;

    private void Start()
    {
        col = GetComponent<Collider2D>();
        instantiateRopeScript.enabled = false;
    }

    private void Update()
    {
        Vector2 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bool nowInside = col.OverlapPoint(_mousePos); //コライダーの内部にマウスがあるか判断
        if (nowInside)
        {
            OnMouseEnter2D();
        }
        else if (!nowInside)
        {
            OnMouseExit2D();
        }
    }

    private void OnMouseEnter2D()
    {
        instantiateRopeScript.enabled = true;
    }

    private void OnMouseExit2D()
    {
        instantiateRopeScript.enabled = false;
    }
}
