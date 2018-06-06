using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Playables;

// A behaviour that is attached to a playable
[System.Serializable]
public class FaderBehaviour : PlayableBehaviour
{
    [HideInInspector]
    public CanvasGroup canvasGroup;

    public FaderClip.FadeDirection fadeDirection;
    public bool isUseCurve = false;
    public AnimationCurve faderCurve = new AnimationCurve();


    // Called when the owning graph starts playing
    public override void OnGraphStart(Playable playable)
    {
        Debug.Log(MethodInfo.GetCurrentMethod().Name);
    }

	// Called when the owning graph stops playing
	public override void OnGraphStop(Playable playable)
    {
        Debug.Log(MethodInfo.GetCurrentMethod().Name);
    }
    
    // Called when the state of the playable is set to Play
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        Debug.Log(MethodInfo.GetCurrentMethod().Name);

        switch (fadeDirection)
        {
            case FaderClip.FadeDirection.In:
                {
                    canvasGroup.alpha = 1.0f;
                    break;
                }
            case FaderClip.FadeDirection.Out:
                {
                    canvasGroup.alpha = 0.0f;
                    break;
                }
        }
    }

    // Called when the state of the playable is set to Paused
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        Debug.Log(MethodInfo.GetCurrentMethod().Name);
        
        switch (fadeDirection)
        {
            case FaderClip.FadeDirection.In:
                {
                    canvasGroup.alpha = 0.0f;
                    break;
                }
            case FaderClip.FadeDirection.Out:
                {
                    canvasGroup.alpha = 1.0f;
                    break;
                }
        }
    }

    // Called each frame while the state is set to Play
    public override void PrepareFrame(Playable playable, FrameData info)
    {
        Debug.Log(MethodInfo.GetCurrentMethod().Name);

        float duration = (float)playable.GetDuration();
        float time = (float)playable.GetTime();
        float t01 = time / duration;

        switch (fadeDirection)
        {
            case FaderClip.FadeDirection.In:
                {
                    // 基本はリニア
                    float alpha = (1.0f - t01);

                    // カーブ情報を使うなら
                    if (isUseCurve)
                    {
                        alpha = faderCurve.Evaluate(t01);
                    }

                    canvasGroup.alpha = alpha;

                    break;
                }
            case FaderClip.FadeDirection.Out:
                {
                    // 基本はリニア
                    float alpha = t01;

                    // カーブ情報を使うなら
                    if (isUseCurve)
                    {
                        alpha = faderCurve.Evaluate(t01);
                    }

                    canvasGroup.alpha = alpha;

                    break;
                }
        }
    }
}
