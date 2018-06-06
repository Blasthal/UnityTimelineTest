using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class FaderPlayableAsset : PlayableAsset
{
    //public ExposedReference<CanvasGroup> canvasGroup;

    public enum FadeDirection
    {
        In,
        Out,
    };
    public FadeDirection fadeDirection;


    // Factory method that generates a playable based on this asset
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {

        // 新規追加
        FaderPlayableBehaviour behaviour = new FaderPlayableBehaviour();

        //
        //behaviour.canvasGroup = this.canvasGroup.Resolve(graph.GetResolver());

        // 動的キャッチテスト
        bool result;
        CanvasGroup cg = (CanvasGroup)graph.GetResolver().GetReferenceValue("canvasGroup", out result);
        behaviour.canvasGroup = cg;


        //
        behaviour.fadeDirection = fadeDirection;

        return ScriptPlayable<FaderPlayableBehaviour>.Create(graph, behaviour);
	}
}
