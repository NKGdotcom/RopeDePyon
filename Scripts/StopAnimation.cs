using UnityEngine;

public class StopAnimation : MonoBehaviour
{
    private Animator nowMoveAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nowMoveAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(nowMoveAnimator != null)
        {
            nowMoveAnimator.enabled = false;
        }
    }
}
