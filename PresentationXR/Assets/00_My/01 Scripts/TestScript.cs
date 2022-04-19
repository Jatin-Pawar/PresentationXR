using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public Animator currentAnimator;
    public AnimationClip animClip;
    AnimatorClipInfo[] m_CurrentClipInfo;
    AnimatorStateInfo currentState;
    public GameObject[] infoPannels;

    // Start is called before the first frame update
    void Start()
    {
        currentState = currentAnimator.GetCurrentAnimatorStateInfo(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAnimator.GetCurrentAnimatorStateInfo(0).IsName("Play Animation"))
        {
            m_CurrentClipInfo = currentAnimator.GetCurrentAnimatorClipInfo(0);
            currentState = currentAnimator.GetCurrentAnimatorStateInfo(0);
        }


        if (Input.GetKeyUp(KeyCode.P))
        {
            Play();
        }
        if (Input.GetKey(KeyCode.O))
        {
            PauseAnimation();
        }
    }

    public void Play()
    {
        if (!currentAnimator.GetCurrentAnimatorStateInfo(0).IsName("Play Animation"))
        {
            currentAnimator.Play("Play Animation");
        }
        currentAnimator.speed = 1;
        currentState = currentAnimator.GetCurrentAnimatorStateInfo(0);
    }

    public void PauseIt()
    {
        currentAnimator.speed = 0;

    }

    public void PauseAnim()
    {
        //currentAnimator.speed = 0;
        StartCoroutine(PauseAnimation());
    }

    public void ShowInfoPannel(int pannelId)
    {
        infoPannels[pannelId].transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.70f);
    }

    public void HideInfoPannel(int pannelId)
    {
        infoPannels[pannelId].transform.DOScale(Vector3.zero, 0.35f);
    }

    IEnumerator PauseAnimation()
    {
        currentAnimator.speed = 0;
        yield return new WaitForSeconds(3);
        Play();
    }
}
