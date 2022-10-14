using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {
    public class IK : MonoBehaviour
    {
        public Animator animator;
        public Transform RightHandIKTarget;
        public Transform LeftHandIKTarget;

        // Start is called before the first frame update
        void Start()
        {


        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnAnimatorIK()
        {
            var data = Data.instance;
            //�E���IK�ݒ�
            if (RightHandIKTarget != null && data.gripHandL.Value)
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
                //animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);

                animator.SetIKPosition(AvatarIKGoal.RightHand, RightHandIKTarget.position);
                animator.SetIKRotation(AvatarIKGoal.RightHand, RightHandIKTarget.rotation);
            }
            else
            {
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.0f);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.0f);
                Debug.LogError("�E��IK�̃^�[�Q�b�g���ݒ肳��Ă��܂���");
            }
           //�����IK�ݒ�
           if (LeftHandIKTarget != null&& data.gripHandR.Value)
           {
               animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
               //animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);

               animator.SetIKPosition(AvatarIKGoal.LeftHand, LeftHandIKTarget.position);
               animator.SetIKRotation(AvatarIKGoal.LeftHand, LeftHandIKTarget.rotation);
           }
           else
           {
              animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.0f);
              animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.0f);
               Debug.LogError("����IK�̃^�[�Q�b�g���ݒ肳��Ă��܂���");
           }
        }
    }
}