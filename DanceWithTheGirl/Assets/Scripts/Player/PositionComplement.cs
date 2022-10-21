using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player
{
    public class PositionComplement : MonoBehaviour
    {
        public Transform hmd;
        public Transform playerLeftHand;
        public Transform playerRightHand;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //Žè‚Â‚È‚¬ƒ_ƒ“ƒXŽž‚É‚µ‚©ˆ—‚µ‚È‚¢
            if (Data.AnimState.DANCE != Data.instance.animState) { return; }

            Vector3 centerPos = new Vector3(0, 0, 0);
            if (playerRightHand.position.x > playerLeftHand.position.x)
            {
                centerPos.x = (playerRightHand.position.x - playerLeftHand.position.x) / 2 + playerLeftHand.position.x;
            }
            else
            {
                centerPos.x = (playerLeftHand.position.x - playerRightHand.position.x) / 2 + playerRightHand.position.x;
            }
            if (playerRightHand.position.z > playerLeftHand.position.z)
            {
                centerPos.z = (playerRightHand.position.z - playerLeftHand.position.z) / 2 + playerLeftHand.position.z;
            }
            else
            {
                centerPos.z = (playerLeftHand.position.z - playerRightHand.position.z) / 2 + playerRightHand.position.z;
            }
            var dist = centerPos - hmd.position;
            centerPos.x += dist.x;
            centerPos.z += dist.z;

            centerPos.y = transform.position.y;
            transform.position = centerPos;

            var rota = transform.localEulerAngles;
            rota.y = hmd.localEulerAngles.y;

            transform.localEulerAngles = rota;
        }
    }
}