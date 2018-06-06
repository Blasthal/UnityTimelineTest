using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[System.Serializable]
public class DialogClip
    : PlayableAsset
    , ITimelineClipAsset
{
    public DialogBehaviour template = new DialogBehaviour();
    

    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        // 新規追加
        return ScriptPlayable<DialogBehaviour>.Create(graph, template);
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
