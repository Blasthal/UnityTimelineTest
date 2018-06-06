using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using System.Linq;


public class Scene2 : MonoBehaviour
{
    public GameObject originalObject = null;
    public GameObject cloneObject = null;
    public PlayableDirector director = null;
    public string targetTrackName = "TestAnimationTrack";

    public void InstantiateObject()
    {
        cloneObject = GameObject.Instantiate(originalObject);
    }

    public void Bind()
    {
        PlayableBinding binding = director.playableAsset.outputs.First(c => c.streamName == targetTrackName);
        director.SetGenericBinding(binding.sourceObject, cloneObject);
    }

    public void Play()
    {
        director.Play();
    }
}
