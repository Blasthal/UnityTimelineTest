using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.Timeline;


public class MessageDialog
    : MonoBehaviour
    , IPointerClickHandler
{
    public UnityEngine.UI.Text dialogText = null;

    public Collider2D tapCollision = null;

    private PlayableDirector playableDirector = null;


    private void Update()
    {
    }

    public void SetText(string text)
    {
        dialogText.text = text;
    }

    public void Pause(PlayableDirector pd)
    {
        playableDirector = pd;
        pd.Pause();
    }

    public void Next()
    {
        playableDirector.Resume();
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }


    #region IPointerClickHandler
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (playableDirector
            && playableDirector.state == PlayState.Paused
            )
        {
            Next();
        }
    }
    #endregion
}
