using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacialChange_Dance : MonoBehaviour
{

    public SkinnedMeshRenderer faceMesh;

    // Start is called before the first frame update
    void Start()
    {
        //�\��ω��e�X�g
        var index = faceMesh.sharedMesh.GetBlendShapeIndex("Fcl_BRW_Angry");
        faceMesh.SetBlendShapeWeight(index, 100);
        index = faceMesh.sharedMesh.GetBlendShapeIndex("Fcl_BRW_Angry");
        faceMesh.SetBlendShapeWeight(index, 100);
        index = faceMesh.sharedMesh.GetBlendShapeIndex("Fcl_MTH_Angry");
        faceMesh.SetBlendShapeWeight(index, 100);

    }

    // Update is called once per frame
    void Update()
    {
    }
}
