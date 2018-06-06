using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Playables;

// A behaviour that is attached to a playable
public class TestPlayableBehaviour : PlayableBehaviour
{
    public GameObject otherObj;
    public GameObject projObj;

    private GameObject projObjClone;

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

        Vector3 scale = otherObj.transform.localScale;
        scale.x = 1.0f;
        otherObj.transform.localScale = scale;

        GameObject clone = GameObject.Instantiate(projObj);
        projObjClone = clone;
    }

    // Called when the state of the playable is set to Paused
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        Debug.Log(MethodInfo.GetCurrentMethod().Name);

        Vector3 scale = otherObj.transform.localScale;
        scale.x = 1.0f;
        otherObj.transform.localScale = scale;

        if (projObjClone)
        {
            GameObject.DestroyImmediate(projObjClone);
            projObjClone = null;
        }
    }

    // Called each frame while the state is set to Play
    public override void PrepareFrame(Playable playable, FrameData info)
    {
        Debug.Log(MethodInfo.GetCurrentMethod().Name);

        Vector3 scale = otherObj.transform.localScale;
        scale.x *= -1.0f;
        otherObj.transform.localScale = scale;
    }
}
