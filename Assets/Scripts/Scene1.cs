using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using System.Linq;


public class Scene1 : MonoBehaviour
{
    public PlayableDirector playableDirector = null;
    public UnityEngine.UI.Text label = null;


    public void Start()
    {
        playableDirector.SetReferenceValue("title", label);
    }

    public void Play()
    {
        playableDirector.Play();
    }
}
