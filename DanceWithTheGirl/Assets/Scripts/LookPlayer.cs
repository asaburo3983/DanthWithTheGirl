using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class LookPlayer : MonoBehaviour
{
    private Animator avator;
    public Transform lookAtObj = null;

    [SerializeField, Range(0, 1)]
    private float lookAtWeight = 1.0f;
    [SerializeField, Range(0, 1)]
    private float bodyWeight = 0.4f;
    [SerializeField, Range(0, 1)]
    private float headWeight = 0.7f;
    [SerializeField, Range(0, 1)]
    private float eyesWeight = 0.5f;
    [SerializeField, Range(0, 1)]
    private float clampWeight = 0.5f;

    [SerializeField] private Transform face;
    private Vector3 lookPos;

    // Use this for initialization
    void Start()
    {
        avator = GetComponent<Animator>();
        //if (lookAtObj == null)
        //{
        //    lookAtObj = Camera.main.transform;
        //}
    }

    void OnAnimatorIK(int layorIndex)
    {
        if (avator)
        {
            avator.SetLookAtWeight(lookAtWeight, bodyWeight, headWeight, eyesWeight, clampWeight);

            // ’l‚Ì‘ã“ü
            Vector3 vector3;
            if (lookAtObj == null)
            {
                var _face = face.position;
                _face.y += .05f;
                vector3 = _face;
            }
            else
            {
                vector3 = lookAtObj.transform.position;
            }

            // ˆÊ’u‚Ì•â³
            var time = 1f;
            DOTween.To(() => lookPos, (value) => lookPos = value, vector3, time);

            avator.SetLookAtPosition(lookPos);
            
        }
    }
}
