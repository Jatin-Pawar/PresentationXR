using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public GameObject animationGameObj;
    public GameObject ThannkYouPannel;
    public Animator currentAnimator;
    public AnimationClip animClip;
    AnimatorClipInfo[] m_CurrentClipInfo;
    AnimatorStateInfo currentState;
    public GameObject[] infoPannels;
    public GameObject[] graphInfoPannels;
    public GameObject startingInfoPannel;
    public bool isPausedGlobally = false;
    public AudioSource backgroundAudio;

    // Start is called before the first frame update
    void Start()
    {
        currentState = currentAnimator.GetCurrentAnimatorStateInfo(0);
    }

    private void Update()
    {
        //testing
        if (Input.GetKeyDown(KeyCode.O))
        {
            PauseIt();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Play();
        }
    }



    // play animation
    public void Play()
    {

        if (startingInfoPannel.activeSelf)
        {
            startingInfoPannel.SetActive(false);
        }

        if (!currentAnimator.GetCurrentAnimatorStateInfo(0).IsName("Play Animation"))
        {
            currentAnimator.Play("Play Animation");
        }
        currentAnimator.speed = 1;
        currentState = currentAnimator.GetCurrentAnimatorStateInfo(0);
        isPausedGlobally = false;
        if (!backgroundAudio.isPlaying)
        {
            backgroundAudio.Play();
        }
        
    }

    // pause animation
    public void PauseIt()
    {
        currentAnimator.speed = 0;
        isPausedGlobally = true;
        backgroundAudio.Pause();
    }

    // pause animation for specified seconds
    public void Pause(float pauseTime)
    {
        StartCoroutine(PauseAnimation(pauseTime));
    }

    IEnumerator PauseAnimation(float pauseTime)
    {
        currentAnimator.speed = 0;
        yield return new WaitForSeconds(pauseTime);
        if (!isPausedGlobally)
        {
            Play();
        }
        
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

    public void EndPresentation()
    {
        animationGameObj.transform.DOScale(Vector3.zero, 1f);
        ThannkYouPannel.transform.DOScale(Vector3.one, 0.5f);
    }

    
}
