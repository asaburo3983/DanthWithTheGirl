using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlAnimationCont : MonoBehaviour
{
    Animator animator;
    AnimatorStateInfo info;

    public bool changeState = true;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        info = animator.GetCurrentAnimatorStateInfo(0);

        if (changeState && info.normalizedTime > 0.95f) {

            int now = animator.GetInteger("state");

            while (true) {
                int rand = Random.Range(0, 3);

                if(now != rand) {
                    animator.SetInteger("state", rand);
                    break;
                }
            }
            changeState = false;
        }
    }
}
