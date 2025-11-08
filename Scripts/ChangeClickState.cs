using UnityEngine;

/// <summary>
/// クリックの状態を変更
/// </summary>
public class ChangeClickState : MonoBehaviour
{
    public static ChangeClickState Instance { get; private set; }
    public enum ClickState {isGeneratingRope, isLaunching, isbeingPulled }
    private ClickState isClickState;
    public Collider2D GetCollider2D { get; set; }
    private void Awake()
    {
        Instance = this;
    }
    /// <summary>
    /// ロープを生み出す状態にする
    /// </summary>
    public void SetIsGeneratingRope()
    {
        SetStraightRope.Instance.DisplayStraightRope();
        isClickState = ClickState.isGeneratingRope;
    }
    /// <summary>
    /// ロープを投げる状態にする
    /// </summary>
    public void SetIsLaunching()
    {
        isClickState = ClickState.isLaunching;
    }
    /// <summary>
    /// ロープが引かれる状態
    /// </summary>
    public void SetIsBeingPulled()
    {
        SetStraightRope.Instance.ConnectRopeCharactor();
        isClickState = ClickState.isbeingPulled;
    }
    /// <summary>
    /// 現在はロープを生み出す状態であるどうか
    /// </summary>
    /// <returns></returns>
    public bool IsGeneratingRope()
    {
        return isClickState == ClickState.isGeneratingRope;
    }
    /// <summary>
    /// 現在はロープを投げる状態であるかどうか
    /// </summary>
    /// <returns></returns>
    public bool IsLaunching()
    {
        return isClickState == ClickState.isLaunching;
    }
    /// <summary>
    /// 現在はロープが引かれる状態であるかどうか
    /// </summary>
    /// <returns></returns>
    public bool IsBeingPulled()
    {
        return isClickState == ClickState.isbeingPulled;
    }
}
