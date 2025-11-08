using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterHP : MonoBehaviour
{
    private int characterHP = 3;
    [SerializeField] private PreservationOfCharacter preservationOfCharacter;
    private CharacterHpUI characterHPUI;

    private Transform inputMouseTriggerObj;
    [SerializeField] private ParticleSystem damageParticle;
    private SpriteRenderer characterSpriteRenderer;
    private Rigidbody2D rb2D;

    private float waitParticlePlayTime = 1f;
    private void Start()
    {
        inputMouseTriggerObj = this.transform.GetChild(0);
        characterHPUI = GetComponent<CharacterHpUI>();
        characterSpriteRenderer = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// ダメージを受ける
    /// </summary>
    public void TakeDamage()
    {
        characterHP--;
        SoundManager.Instance.PlaySE(SESource.takeDamage);
        characterHPUI.HiddenHPUI(characterHP);
        damageParticle.gameObject.transform.position = this.gameObject.transform.position;
        damageParticle.Play();
        characterSpriteRenderer.enabled = false;
        inputMouseTriggerObj.gameObject.SetActive(false);
        rb2D.simulated = false;
        if (characterHP > 0)
        {
            StartCoroutine(WaitParticlePlay());
        }
        else if(characterHP <= 0)
        {
            SetGameResult.Instance.GameOver();
        }
    }
    /// <summary>
    /// ダメージを食らってからほんの少し待つ
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitParticlePlay()
    {
        yield return new WaitForSeconds(waitParticlePlayTime);
        characterSpriteRenderer.enabled = true;
        rb2D.simulated = true;
        inputMouseTriggerObj.gameObject.SetActive(true);
        preservationOfCharacter.ReturnFormerPos();
    }
}
