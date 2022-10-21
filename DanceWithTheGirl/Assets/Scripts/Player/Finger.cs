using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Player
{

    public class Finger : MonoBehaviour
    {
        Data data;
        public VrmArPlayer.FingerController fingerController;

        float fingerRotaR = 0;
        float fingerRotaL = 0;
        public float fingerRotaSpeed = 1.0f;
        // Start is called before the first frame update
        void Start()
        {
            data = Data.instance;
        }

        // Update is called once per frame
        void Update()
        {
            GripFinger();
        }
        //éwã»Ç∞èàóù
        void GripFinger()
        {
            if (data.gripHandL.Value)
            {
                if (fingerRotaR < 0) fingerRotaR += fingerRotaSpeed * Time.deltaTime;
            }
            else
            {
                if (fingerRotaR > 0) fingerRotaR -= fingerRotaSpeed * Time.deltaTime;
            }
            if (data.gripHandR.Value)
            {
                if (fingerRotaL > 0) fingerRotaL += fingerRotaSpeed * Time.deltaTime;
            }
            else
            {
                if (fingerRotaL > 0) fingerRotaL -= fingerRotaSpeed * Time.deltaTime;
            }

            fingerController.FingerRotation(VrmArPlayer.FingerController.FingerType.RightAll, fingerRotaR);
            fingerController.FingerRotation(VrmArPlayer.FingerController.FingerType.LeftAll, fingerRotaL);
        }
    }
}