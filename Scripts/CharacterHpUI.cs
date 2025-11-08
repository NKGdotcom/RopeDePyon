using UnityEngine;

/// <summary>
/// キャラクターHPUIの表示処理
/// </summary>
public class CharacterHpUI : MonoBehaviour
{
    [SerializeField] private GameObject[] hpUI;

    /// <summary>
    /// 対象のHP画像を非表示
    /// </summary>
    /// <param name="_leftHP"></param>
    /// <param name="_character"></param>
    public void HiddenHPUI(int _leftHP)
    {
        hpUI[_leftHP].SetActive(false);
    }
}
