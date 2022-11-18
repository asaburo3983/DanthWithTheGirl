using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartButton : MonoBehaviour
{
    [SerializeField] float time = 1.0f;
    bool ones = false;


    private void Start()
    {
        //FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ones &&
            OVRInput.GetDown(OVRInput.RawButton.B)) {
            ones = true;
            FadeIn();
        }
    }

    void FadeIn()
    {

        if (TryGetComponent<Image>(out var im)) {
            Color col = im.color;
            col.a = 0;

            im.DOColor(col, time).OnComplete(() => Destroy(this.gameObject));
        }

        if(TryGetComponent<Text>(out var tx)) {
            Color col = tx.color;
            col.a = 0;

            tx.DOColor(col, time).OnComplete(() => Destroy(this.gameObject));
        }
    }
}
