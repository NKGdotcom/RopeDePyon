using UnityEngine;

/// <summary>
/// 範囲外(赤い部分)に何かが触れた場合
/// </summary>
public class OutOfRange : MonoBehaviour
{
    private CharacterHP characterHP;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent(out BeingPulledCharacter character)) //キャラクターであった場合ダメージを食らう
        {
            if(characterHP == null)
            {
                characterHP = other.gameObject.GetComponent<CharacterHP>();
            }
            characterHP.TakeDamage();
        }
        else if(other.gameObject.TryGetComponent(out ThrowRope throwRope)) //ロープであった場合やり直し
        {
            Destroy(other.gameObject);
            ChangeClickState.Instance.SetIsGeneratingRope();
        }
    }
}
