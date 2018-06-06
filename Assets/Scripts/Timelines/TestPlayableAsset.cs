using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class TestPlayableAsset : PlayableAsset
{
    public ExposedReference<GameObject> otherObj;
    public GameObject projObj;


    // Factory method that generates a playable based on this asset
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        // 新規追加
        TestPlayableBehaviour behaviour = new TestPlayableBehaviour();
        behaviour.otherObj = this.otherObj.Resolve(graph.GetResolver());
        behaviour.projObj = this.projObj;

        return ScriptPlayable<TestPlayableBehaviour>.Create(graph, behaviour);
	}
}
