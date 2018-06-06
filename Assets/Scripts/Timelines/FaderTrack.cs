using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


[System.Serializable]
[TrackMediaType(TimelineAsset.MediaType.Script)]
[TrackClipType(typeof(FaderClip))]
[TrackBindingType(typeof(CanvasGroup))] //< Faderクラスを用意した方が今後に役立つかも
[TrackColor(0.2f, 0.2f, 0.2f)]
public class FaderTrack
    : TrackAsset
{
    protected override Playable CreatePlayable(PlayableGraph graph, GameObject go, TimelineClip clip)
    {
        PlayableDirector content = go.GetComponent<PlayableDirector>();
        ScriptPlayable<FaderBehaviour> mixer = ScriptPlayable<FaderBehaviour>.Create(graph);

        // TrackとClipに設定された値を取得する
        CanvasGroup canvasGroup = content.GetGenericBinding(this) as CanvasGroup;
        FaderClip faderClip = clip.asset as FaderClip;

        // behaviourに通知
        mixer.GetBehaviour().canvasGroup = canvasGroup;
        mixer.GetBehaviour().fadeDirection = faderClip.template.fadeDirection;
        mixer.GetBehaviour().isUseCurve = faderClip.template.isUseCurve;
        mixer.GetBehaviour().faderCurve = faderClip.template.faderCurve;


        // トラック上での表記をフェード情報に変更する
        string displayName = string.Empty;
        displayName = faderClip.template.fadeDirection.ToString();
        clip.displayName = displayName;

        return mixer;
    }
}
