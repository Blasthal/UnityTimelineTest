using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


[System.Serializable]
[TrackMediaType(TimelineAsset.MediaType.Script)]
[TrackClipType(typeof(DialogClip))]
[TrackBindingType(typeof(MessageDialog))]
[TrackColor(0.0f, 0.2f, 1.0f)]
public class DialogTrack : TrackAsset
{
    protected override Playable CreatePlayable(PlayableGraph graph, GameObject go, TimelineClip clip)
    {
        ScriptPlayable<DialogBehaviour> mixer = ScriptPlayable<DialogBehaviour>.Create(graph);

        // TrackとClipに設定された値を取得する
        PlayableDirector content = go.GetComponent<PlayableDirector>();
        MessageDialog msgDialog = content.GetGenericBinding(this) as MessageDialog;
        DialogClip dialogClip = clip.asset as DialogClip;
        
        // behaviourに通知
        mixer.GetBehaviour().messageDialog = msgDialog;
        mixer.GetBehaviour().textString = dialogClip.template.textString;
        mixer.GetBehaviour().hasToPause = dialogClip.template.hasToPause;
        mixer.GetBehaviour().startTime = clip.start;
        mixer.GetBehaviour().endTime = clip.end;

        // トラック上での表記を変更予定の文字列にする
        clip.displayName = dialogClip.template.textString;

        return mixer;
    }
}
