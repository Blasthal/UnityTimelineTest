using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

// A behaviour that is attached to a playable
[System.Serializable]
public class DialogBehaviour : PlayableBehaviour
{
    [HideInInspector]
    public MessageDialog messageDialog = null;
    [HideInInspector]
    public double startTime = 0.0f;
    [HideInInspector]
    public double endTime = 0.0f;

    public string textString = string.Empty;
    public bool hasToPause = true;

    private PlayableDirector director = null;
    private bool isPauseOnPreFinish = false;


    public DialogBehaviour()
    {
        this.textString = "hoge";
        this.hasToPause = true;
    }


    public override void OnPlayableCreate(Playable playable)
    {
        director = (playable.GetGraph().GetResolver() as PlayableDirector);
    }

    // Called when the owning graph starts playing
    public override void OnGraphStart(Playable playable)
    {
        Debug.Log(MethodInfo.GetCurrentMethod().Name + " textString:" + textString);
	}

	// Called when the owning graph stops playing
	public override void OnGraphStop(Playable playable)
    {
        Debug.Log(MethodInfo.GetCurrentMethod().Name + " textString:" + textString);
    }

    // Called when the state of the playable is set to Play
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        Debug.Log(MethodInfo.GetCurrentMethod().Name + " textString:" + textString);

        isPauseOnPreFinish = false;
    }

    // Called each frame while the state is set to Play
    public override void PrepareFrame(Playable playable, FrameData info)
    {
        Debug.Log(MethodInfo.GetCurrentMethod().Name);
    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        Debug.Log(MethodInfo.GetCurrentMethod().Name + " Time=" + playable.GetTime());
        
        double preTime = playable.GetPreviousTime();
        double timeOnClip = playable.GetTime();
        double deltaTime = timeOnClip - preTime;
        double durationTime = playable.GetDuration();
        double rate = timeOnClip / durationTime;
        double rateAfter = (timeOnClip + deltaTime) / durationTime;

        double weight = info.weight;

        int inputCount = playable.GetInputCount();
        int outputCount = playable.GetOutputCount();
        Debug.Log(MethodInfo.GetCurrentMethod().Name + " InputCount=" + inputCount);

        // 文字列を設定
        messageDialog.SetText(textString);

        // 表示する
        messageDialog.Show();


        // ★次のフレームで完了する（クリップから抜ける）時
        // ※クリップを抜けるとProcessFrameは呼ばれず、OnBehaviourPauseが呼ばれるので、
        // ProcessFrame内で捕まえるタイミングは今しかない。
        if (rate < 1.0f && 1.0f <= rateAfter)
        {
            OnBehaviourPreFinish(playable, info, playerData);
        }
    }

    // クリップを抜ける直前のフレームの処理
    private void OnBehaviourPreFinish(Playable playable, FrameData info, object playerData)
    {
        // 実行中のみ
        if (Application.isPlaying)
        {
            // 入力を待つなら
            if (hasToPause)
            {
                // Pauseを行うと OnBehaviourPause が呼ばれるので留意
                messageDialog.Pause(this.director);

                // クリップから抜けた時の処理と分岐できるようにフラグを立てる
                isPauseOnPreFinish = true;
            }
        }
    }

    // Called when the state of the playable is set to Paused
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        Debug.Log(MethodInfo.GetCurrentMethod().Name + " textString:" + textString);

        // 完了直前のPauseなら
        if (isPauseOnPreFinish)
        {
            // 特に何もしない
        }
        else
        {
            // 非表示にする
            messageDialog.Hide();
        }
    }
}
