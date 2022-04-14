using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public Animator currentAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        if (!currentAnimator.GetCurrentAnimatorStateInfo(0).IsName("Play Animation"))
        {
            currentAnimator.Play("Play Animation");
        }
        
        currentAnimator.speed = 1;
        
    }

    public void Pause()
    {
        currentAnimator.speed = 0;
        
    }
}
