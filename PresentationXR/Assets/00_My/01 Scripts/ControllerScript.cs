using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public Animator currentAnimator;
    public AnimationClip animClip;
    AnimatorClipInfo[] m_CurrentClipInfo;
    AnimatorStateInfo currentState;
    public GameObject[] infoPannels;
    public GameObject[] graphInfoPannels;

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

    // play animation
    public void Play()
    {
        if (!currentAnimator.GetCurrentAnimatorStateInfo(0).IsName("Play Animation"))
        {
            currentAnimator.Play("Play Animation");
        }
        currentAnimator.speed = 1;
        currentState = currentAnimator.GetCurrentAnimatorStateInfo(0);
    }

    // pause animation
    public void PauseIt()
    {
        currentAnimator.speed = 0;

    }

    // pause animation for specified seconds
    public void Pause()
    {
        //currentAnimator.speed = 0;
        StartCoroutine(PauseAnimation());
    }

    IEnumerator PauseAnimation()
    {
        currentAnimator.speed = 0;
        yield return new WaitForSeconds(3);
        Play();
    }

    // show UI pannel in animated way
    public void ShowInfoPannel(int pannelId)
    {
        infoPannels[pannelId].transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.70f);
    }

    // hide UI pannel in animated way
    public void HideInfoPannel(int pannelId)
    {
        infoPannels[pannelId].transform.DOScale(Vector3.zero, 0.35f);
    }

    // setting all the block based UI to hide
    public void HideGraphInfoPannel()
    {
        foreach (GameObject gameObject in graphInfoPannels)
        {
            gameObject.SetActive(false);
        }
    }

    
}
