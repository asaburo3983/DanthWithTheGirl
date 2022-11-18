using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UniRx;

public class LookControl : MonoBehaviour
{
    [SerializeField] private float handShakeTime = 1f;
    [SerializeField] private float randTime = 5f;

    [SerializeField] private Transform cameraObj;
    [SerializeField] private Transform handLObj;
    [SerializeField] private Transform handRObj;

    private LookPlayer lookPlayer;

    private int randRate = 100;
    private void Start()
    {
        lookPlayer = GetComponent<LookPlayer>();

        // ������Ƃ݂�
        Player.Data.instance.gripHandL.Subscribe(x => {
            HandShake(handLObj);
        });

        Player.Data.instance.gripHandR.Subscribe(x => {
            HandShake(handRObj);
        });
    }


    private void Update()
    {
        // ����Ȃ��ł��邩�H
        if (!NoHandShake())
        {
            return;
        }

        //// �v���C���[���݂Ă���Ƃ�
        //if (lookPlayer.lookAtObj == cameraObj)
        //{
        //    if (Random.Range(0, randRate) == 0)
        //    {
        //        RandLookHand();
        //    }
        //}
    }

    /// <summary>
    /// ����Ȃ������Ɏ���݂�
    /// </summary>
    private void HandShake(Transform _tra)
    {
        if (lookPlayer.lookAtObj == handLObj) return;

        lookPlayer.lookAtObj = _tra;

        // �v���C���[���݂�
        DOVirtual.DelayedCall(handShakeTime, () => {
            LookPlayer();
        });

    }

    /// <summary>
    /// �����_���Ŏ������
    /// </summary>
    private void RandLookHand()
    {
        // �E
        if (Player.Data.instance.gripHandL.Value)
        {
            lookPlayer.lookAtObj = handLObj.transform;
        }

        // ��
        if (Player.Data.instance.gripHandR.Value)
        {
            lookPlayer.lookAtObj = handRObj.transform;
        }

        // �v���C���[������
        DOVirtual.DelayedCall(randTime, () => {
            LookPlayer();
        });
    }

    /// <summary>
    /// �v���C���[���݂�
    /// </summary>
    private void LookPlayer()
    {
        if (lookPlayer.lookAtObj == cameraObj) return;

        lookPlayer.lookAtObj = cameraObj.transform;
    }

    /// <summary>
    /// ����Ȃ��ł��Ȃ��Ƃ��͉����݂Ȃ�
    /// </summary>
    private bool NoHandShake()
    {
        if (!Player.Data.instance.gripHandL.Value && !Player.Data.instance.gripHandR.Value)
        {
            lookPlayer.lookAtObj = null;
            return false;
        }
        return true;
    }
}