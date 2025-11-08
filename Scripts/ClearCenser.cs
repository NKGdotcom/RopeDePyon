using UnityEngine;

public class ClearCenser : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BeingPulledCharacter character))
        {
            SetGameResult.Instance.GameClear();
            SoundManager.Instance.PlaySE(SESource.GameClear);
        }
    }
}
