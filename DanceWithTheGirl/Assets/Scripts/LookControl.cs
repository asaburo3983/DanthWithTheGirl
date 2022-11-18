using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UniRx;

public class LookControl : MonoBehaviour
{
    [SerializeField]private float handShakeTime = 1f;
    [SerializeField] private float randTime = 5f;

    [SerializeField] private Transform cameraObj;
    [SerializeField] private Transform handLObj;
    [SerializeField] private Transform handRObj;

    private LookPlayer lookPlayer;

    private int randRate = 100;
    private void Start()
    {
        lookPlayer = GetComponent<LookPlayer>();

        // 握られるとみる
        Player.Data.instance.gripHandL.Subscribe(x => {
            HandShake(handLObj);
        });

        Player.Data.instance.gripHandR.Subscribe(x => {
            HandShake(handRObj);
        });
    }


    private void Update()
    {
        // 手をつないでいるか？
        if (!NoHandShake())
        {
            return;
        }

        // プレイヤーをみているとき
        if (lookPlayer.lookAtObj == cameraObj)
        {
            if(Random.Range(0, randRate) == 0)
            {
                RandLookHand();
            }
        }
    }

    /// <summary>
    /// 手をつないだ時に手をみる
    /// </summary>
    private void HandShake(Transform _tra)
    {
        if (lookPlayer.lookAtObj == handLObj) return;

        lookPlayer.lookAtObj = _tra;

        // プレイヤーをみる
        DOVirtual.DelayedCall(handShakeTime,()=>{
            LookPlayer(); 
        });
        
    }

    /// <summary>
    /// ランダムで手を見る
    /// </summary>
    private void RandLookHand()
    {
        // 右
        if (Player.Data.instance.gripHandL.Value)
        {
            lookPlayer.lookAtObj = handLObj.transform;
        }

        // 左
        if (Player.Data.instance.gripHandR.Value)
        {
            lookPlayer.lookAtObj = handRObj.transform;
        }

        // プレイヤーを見る
        DOVirtual.DelayedCall(randTime, () => {
            LookPlayer();
        });
    }

    /// <summary>
    /// プレイヤーをみる
    /// </summary>
    private void LookPlayer()
    {
        if (lookPlayer.lookAtObj == cameraObj) return;

        lookPlayer.lookAtObj = cameraObj.transform;
    }

    /// <summary>
    /// 手をつないでいないときは何もみない
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
