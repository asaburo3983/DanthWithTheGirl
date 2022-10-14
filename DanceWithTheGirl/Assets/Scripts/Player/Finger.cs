using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{

    public class Finger : MonoBehaviour
    {
        Data data;
        public VrmArPlayer.FingerController fingerController;
        // Start is called before the first frame update
        void Start()
        {
            data = Data.instance;
        }

        // Update is called once per frame
        void Update()
        {
            // 右手の人差し指だけ伸ばしてあと全部曲げる
            fingerController.FingerRotation(VrmArPlayer.FingerController.FingerType.RightAll, 1.0f);
            fingerController.FingerRotation(VrmArPlayer.FingerController.FingerType.RightIndex, 0.0f);

            //this.transform.DOMove(new Vector3(5f, 0f, 0f), 3f);
        }
        void GripFinger()
        {
            if (data.gripHandL.Value)
            {

            }
        }
    }
}