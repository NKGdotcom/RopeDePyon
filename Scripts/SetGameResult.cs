using System.Collections;
using UnityEngine;

public class SetGameResult : MonoBehaviour
{
    public static SetGameResult Instance {get; private set;}
    [SerializeField] private PreservationOfCharacter preservationOfCharacter;
    [SerializeField] private CharacterHpUI characterHpUI;
    [SerializeField] private GameObject gameClearUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Animator gameOverAnimator;
    [SerializeField] private ParticleSystem goalEffect;
    private int retryNum = 3;
    private float backPosWaitTime = 1.5f;
    private bool isResult;

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
        gameClearUI.SetActive(false);
        gameOverUI.SetActive(false);
    }

    public void GameClear()
    {
        if (!isResult)
        {
            isResult = true;
            gameClearUI.SetActive(true);
            goalEffect.gameObject.SetActive(true);
        }
    }
    public void GameOver()
    {
        if (!isResult)
        {
            isResult= true;
            gameOverUI.SetActive(true);
            gameOverAnimator.enabled = true;
        }
    }
}
