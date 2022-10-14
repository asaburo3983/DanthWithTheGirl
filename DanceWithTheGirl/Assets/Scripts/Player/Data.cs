using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Player
{
    public class Data : SingletonMonoBehaviour<Data>
    {
        private void Awake()
        {
            SingletonCheck(this, false);

        }
        public enum AnimState
        {
            IDLE,
            DANCE
        }
        public AnimState animState;

        //腕つかみ判定
        [Header("腕つかみ判定R")] public ReactiveProperty<bool> gripHandR;
        [Header("腕つかみ判定L")] public ReactiveProperty<bool> gripHandL;


        public IK IKScript;
        //public IK IKScript;

    }
}