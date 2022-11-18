using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player
{
    public class FacialChange : MonoBehaviour
    {

        public SkinnedMeshRenderer faceMesh;

        public List<int> indexs = new List<int>();

        /// <summary>
        /// ダンス時のフェイシャル変化でに使う変数
        /// </summary>
        public Transform handR;
        public List<float> facialChangePoint;

        // Start is called before the first frame update
        void Start()
        {


        }

        // Update is called once per frame
        void Update()
        {
            ChangeFacial_Dance();
            ChangeFacial_Idle();
        }
        void ChangeFacial_Dance()
        {
            if (Data.AnimState.DANCE != Data.instance.animState) { return; }

            if(handR.position.y > facialChangePoint[0])
            {
                Change_Smile();
            }
            else if(handR.position.y> facialChangePoint[1])
            {
                Change_Smile2();
            }
            else if (handR.position.y> facialChangePoint[2])
            {
                Change_Smile3();
            }
            else if (handR.position.y> facialChangePoint[3])
            {
                Change_Suprise();
            }
        }
        void ChangeFacial_Idle()
        {
            if (Data.AnimState.IDLE != Data.instance.animState) { return; }
        }

        void ResetIndexs()
        {
            foreach (int index in indexs)
            {
                faceMesh.SetBlendShapeWeight(index, 0);
            }

            while (indexs.Count > 0)
            {
                indexs.RemoveAt(0);
            }
        }
        void Change_Smile()
        {
            ResetIndexs();

            var index = faceMesh.sharedMesh.GetBlendShapeIndex("Fcl_EYE_Joy");
            indexs.Add(index);
            faceMesh.SetBlendShapeWeight(index, 50);

            index = faceMesh.sharedMesh.GetBlendShapeIndex("Fcl_MTH_Fun");
            indexs.Add(index);
            faceMesh.SetBlendShapeWeight(index, 50);
        }
        void Change_Smile2()
        {
            ResetIndexs();

            var index = faceMesh.sharedMesh.GetBlendShapeIndex("Fcl_MTH_Fun");
            indexs.Add(index);
            faceMesh.SetBlendShapeWeight(index, 50);
        }
        void Change_Smile3()
        {
            ResetIndexs();

            var index = faceMesh.sharedMesh.GetBlendShapeIndex("Fcl_BRW_Fun");
            indexs.Add(index);
            faceMesh.SetBlendShapeWeight(index, 100);

            index = faceMesh.sharedMesh.GetBlendShapeIndex("Fcl_EYE_Fun");
            indexs.Add(index);
            faceMesh.SetBlendShapeWeight(index, 100);

            index = faceMesh.sharedMesh.GetBlendShapeIndex("Fcl_MTH_FUN");
            indexs.Add(index);
            faceMesh.SetBlendShapeWeight(index, 100);
        }

        void Change_Suprise()
        {
            ResetIndexs();

            var index = faceMesh.sharedMesh.GetBlendShapeIndex("Fcl_EYE_Suprised");
            indexs.Add(index);
            faceMesh.SetBlendShapeWeight(index, 50);

            index = faceMesh.sharedMesh.GetBlendShapeIndex("Fcl_MTH_Sorrow");
            indexs.Add(index);
            faceMesh.SetBlendShapeWeight(index, 60);
        }
    }
}