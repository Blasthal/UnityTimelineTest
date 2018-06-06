using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[System.Serializable]
public class FaderClip
    : PlayableAsset
    , ITimelineClipAsset
{
    public enum FadeDirection
    {
        In,
        Out,
    };

    public FaderBehaviour template = new FaderBehaviour();


    // Factory method that generates a playable based on this asset
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        return ScriptPlayable<FaderBehaviour>.Create(graph, template);
    }

    #region ITimelineClipAsset
    public ClipCaps clipCaps
    {
        get
        {
            return ClipCaps.Blending;
        }
    }
    #endregion
}
