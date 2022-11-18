using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

#if UNITY_EDITOR
using UnityEditor;
#endif
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

    public void FadeIn()
    {
        if (TryGetComponent<Image>(out var im)) {
            Color col = im.color;
            col.a = 0;

            im.DOColor(col, time).OnComplete(() => {
                col.a = 0;
                im.color = col;
            });
        }

        if(TryGetComponent<Text>(out var tx)) {
            Color col = tx.color;
            col.a = 0;

            im.DOColor(col, time).OnComplete(() => {
                col.a = 0;
                im.color = col;
            });
        }
    }

    public void FadeOut()
    {
        if (TryGetComponent<Image>(out var im)) {
            Color col = im.color;
            col.a = 1;

            im.DOColor(col, time).OnComplete(() => {
                col.a = 1;
                im.color = col;
            });
        }

        if (TryGetComponent<Text>(out var tx)) {
            Color col = tx.color;
            col.a = 1;

            tx.DOColor(col, time).OnComplete(() => {
                col.a = 1;
                im.color = col;
            });
        }
    }
}

#if UNITY_EDITOR

[CustomEditor(typeof(StartButton))]
public class startButtonEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("フェードイン")) {
            ((StartButton)target).FadeIn();
        }
        if (GUILayout.Button("フェードあうと")) {
            ((StartButton)target).FadeOut();
        }
    }

}


#endif
