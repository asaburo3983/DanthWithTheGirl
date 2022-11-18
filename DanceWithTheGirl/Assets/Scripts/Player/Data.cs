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
        public Animator animator;

        //�r���ݔ���
        [Header("�r���ݔ���R")] public ReactiveProperty<bool> gripHandR;
        [Header("�r���ݔ���L")] public ReactiveProperty<bool> gripHandL;


        public IK IKScript;
        //public IK IKScript;

    }
}