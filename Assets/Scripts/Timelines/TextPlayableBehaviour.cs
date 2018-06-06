using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Playables;

// A behaviour that is attached to a playable
public class TextPlayableBehaviour : PlayableBehaviour
{
    public UnityEngine.UI.Text uiText = null;
    public string textString = string.Empty;


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

        uiText.text = textString;
    }

    // Called when the state of the playable is set to Paused
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        Debug.Log(MethodInfo.GetCurrentMethod().Name);
    }

    // Called each frame while the state is set to Play
    public override void PrepareFrame(Playable playable, FrameData info)
    {
        Debug.Log(MethodInfo.GetCurrentMethod().Name);
    }
}
