using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class StartButton : MonoBehaviour
{
    [SerializeField] float time = 1.0f;
    [SerializeField] float alpha = 1f;
    bool ones = false;

    [SerializeField]
    UnityEvent ev;

    private void Start()
    {
        ev.Invoke();
    }

    public void In(float delay)
    {
        DOVirtual.DelayedCall(delay, () => FadeIn());
    }

    public void Out(float delay)
    {
        DOVirtual.DelayedCall(delay, () => FadeOut());
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
            col.a = alpha;

            im.DOColor(col, time).OnComplete(() => {
                col.a = alpha;
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
