using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Playables;

// A behaviour that is attached to a playable
public class FaderPlayableBehaviour : PlayableBehaviour
{
    public CanvasGroup canvasGroup;
    public FaderPlayableAsset.FadeDirection fadeDirection;


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
            case FaderPlayableAsset.FadeDirection.In:
                {
                    canvasGroup.alpha = 1.0f;
                    break;
                }
            case FaderPlayableAsset.FadeDirection.Out:
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
            case FaderPlayableAsset.FadeDirection.In:
                {
                    canvasGroup.alpha = 0.0f;
                    break;
                }
            case FaderPlayableAsset.FadeDirection.Out:
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
            case FaderPlayableAsset.FadeDirection.In:
                {
                    canvasGroup.alpha = (1.0f - t01);
                    break;
                }
            case FaderPlayableAsset.FadeDirection.Out:
                {
                    canvasGroup.alpha = t01;
                    break;
                }
        }
    }
}
