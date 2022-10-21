using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller {
    public class GripHand : MonoBehaviour
    {
        public enum HandLR
        {
            L,
            R
        }
        public HandLR handLR;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            
            var data = Player.Data.instance;
            //ステート変化
            if (data.gripHandL.Value || data.gripHandR.Value)
            {
                data.animState = Player.Data.AnimState.DANCE;
            }
            else
            {
                data.animState = Player.Data.AnimState.IDLE;
            }

            if (handLR == HandLR.L)
            {
                if (OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger) ||
                    OVRInput.GetUp(OVRInput.RawButton.LHandTrigger))
                {
                   data.gripHandL.Value = false;
                }
            }
            else
            {
                if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger) ||
                    OVRInput.GetUp(OVRInput.RawButton.RHandTrigger))
                {
                    data.gripHandR.Value = false;
                }
            }
        }

        //OnTriggerEnter関数
        //接触したオブジェクトが引数otherとして渡される
        void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Hand"))
            {
                var data = Player.Data.instance;

                if (handLR == HandLR.L)
                {
                    if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger) ||
                        OVRInput.Get(OVRInput.RawButton.LHandTrigger))
                    {
                        data.gripHandL.Value = true;
                      
                    }
                }
                else if (handLR == HandLR.R)
                {
                    if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger) ||
                        OVRInput.Get(OVRInput.RawButton.RHandTrigger))
                    {
                        data.gripHandR.Value = true;
                    }
                }




            }
        }
    }
}
