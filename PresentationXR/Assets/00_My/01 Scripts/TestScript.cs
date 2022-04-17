using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public Animator currentAnimator;
    public RuntimeAnimatorController runTimeController;
    public float clipLength = 0f;
    public float statebasedTimeStamp = 0f;
    public float timeStampByClip = 0f;
    public float customPlayBackTime = 0f;
    public float customNormalizedTime = 0f;
    public string clipName;
    public string runTimeClipName;
    public AnimationClip animClip;
    AnimatorClipInfo[] m_CurrentClipInfo;
    AnimatorStateInfo currentState;



    public GameObject[] infoPannels;

    // Start is called before the first frame update
    void Start()
    {
        currentState = currentAnimator.GetCurrentAnimatorStateInfo(0);
        runTimeController = currentAnimator.runtimeAnimatorController;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAnimator.GetCurrentAnimatorStateInfo(0).IsName("Play Animation"))
        {
            m_CurrentClipInfo = currentAnimator.GetCurrentAnimatorClipInfo(0);
            currentState = currentAnimator.GetCurrentAnimatorStateInfo(0);
            statebasedTimeStamp = currentState.normalizedTime * clipLength;
            clipName = m_CurrentClipInfo[0].clip.name;
            timeStampByClip = runTimeController.animationClips[0].length;
        }


        //if (statebasedTimeStamp > 17 && statebasedTimeStamp < 17.2)
        //{
        //    Debug.Log("Show Maharastra");
        //    infoPannels[0].transform.DOScale(Vector3.zero,1f).From();
        //    //SetActive(true);
        //}
        //else if (statebasedTimeStamp > 18 && statebasedTimeStamp < 18.2)
        //{
        //    Debug.Log("Hide Maharastra");
        //    infoPannels[0].transform.DOScale(Vector3.zero, 1f);
        //    //infoPannels[1].transform.DOScale(Vector3.zero, 1f).From();
        //    //infoPannels[0].SetActive(false);
        //    //infoPannels[1].SetActive(true);
        //}
        //else if (statebasedTimeStamp > 19 && statebasedTimeStamp < 19.2)
        //{
        //    Debug.Log("Show TN");
        //    infoPannels[0].transform.DOScale(Vector3.zero, 1f).From();
        //    //infoPannels[0].SetActive(false);
        //    //infoPannels[1].SetActive(true);
        //}
        //else if (statebasedTimeStamp > 21 && statebasedTimeStamp < 22)
        //{
        //    Debug.Log("Show Delhi");
        //    infoPannels[1].SetActive(false);
        //    infoPannels[2].SetActive(true);
        //}
        //else if (statebasedTimeStamp > 23 && statebasedTimeStamp < 24)
        //{
        //    infoPannels[2].SetActive(false);
        //    infoPannels[3].SetActive(true);
        //}
        //else if (statebasedTimeStamp > 25 && statebasedTimeStamp < 26)
        //{
        //    infoPannels[3].SetActive(false);
        //    infoPannels[4].SetActive(true);
        //}
        //else if (statebasedTimeStamp > 27 && statebasedTimeStamp < 28)
        //{
        //    infoPannels[3].SetActive(false);
        //    infoPannels[4].SetActive(false);
        //}

        if (Input.GetKey(KeyCode.J)){
            SetPlayBack();
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            Play();
        }
        if (Input.GetKey(KeyCode.O))
        {
            Pause();
        }
    }

    public void SetPlayBack()
    {
        currentAnimator.Play("Play Animation", 0, customNormalizedTime);
    }

    public void Play()
    {
        if (!currentAnimator.GetCurrentAnimatorStateInfo(0).IsName("Play Animation"))
        {
            currentAnimator.Play("Play Animation");
        }
        currentAnimator.speed = 1;
        currentState = currentAnimator.GetCurrentAnimatorStateInfo(0);
        clipLength = currentState.length;
    }

    public void Pause()
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
