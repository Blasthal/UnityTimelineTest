using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[System.Serializable]
public class TextPlayableAsset
    : PlayableAsset
    , ITimelineClipAsset
{
    public string textString = string.Empty;


    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        // 新規追加
        TextPlayableBehaviour behaviour = new TextPlayableBehaviour();
        behaviour.textString = this.textString;

        return ScriptPlayable<TextPlayableBehaviour>.Create(graph, behaviour);
	}

    #region ITimelineClipAsset
    public ClipCaps clipCaps
    {
        get
        {
            return ClipCaps.None;
        }
    }
    #endregion
}
