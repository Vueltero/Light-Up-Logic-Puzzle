using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action onLanguageTriggerEnter;
    public event Action onVolumeTriggerEnter;
    public event Action onThemeTriggerEnter;
    public event Action onLevelChangedTriggerEnter;
    public event Action onLevelWonTriggerEnter;
    public event Action onTimeTrialWonTriggerEnter;
    public event Action onHintsFoundTriggerEnter;
    public event Action onThemeBoughtTriggerEnter;
    public event Action onHintsBoughtTriggerEnter;
    public event Action onAdsRemovedTriggerEnter;
    public event Action onLanguageChangedTriggerEnter;
    public void LanguageTriggerEnter()
    {
        if (onLanguageTriggerEnter != null)
            onLanguageTriggerEnter();
    }

    public void VolumeTriggerEnter()
    {
        if (onVolumeTriggerEnter != null)
            onVolumeTriggerEnter();
    }

    public void ThemeTriggerEnter()
    {
        if (onThemeTriggerEnter != null)
            onThemeTriggerEnter();
    }

    public void LevelChangedTriggerEnter()
    {
        if (onLevelChangedTriggerEnter != null)
            onLevelChangedTriggerEnter();
    }

    public void LevelWonTriggerEnter()
    {
        if (onLevelWonTriggerEnter != null)
            onLevelWonTriggerEnter();
    }

    public void TimeTrialWonTriggerEnter()
    {
        if (onTimeTrialWonTriggerEnter != null)
            onTimeTrialWonTriggerEnter();
    }

    public void HintsFoundTriggerEnter()
    {
        if (onHintsFoundTriggerEnter != null)
            onHintsFoundTriggerEnter();
    }

    public void ThemeBoughtTriggerEnter()
    {
        if (onThemeBoughtTriggerEnter != null)
            onThemeBoughtTriggerEnter();
    }

    public void HintsBoughtTriggerEnter()
    {
        if (onHintsBoughtTriggerEnter != null)
            onHintsBoughtTriggerEnter();
    }

    public void AdsRemovedTriggerEnter()
    {
        if (onAdsRemovedTriggerEnter != null)
            onAdsRemovedTriggerEnter();
    }

    public void LanguageChangedTriggerEnter()
    {
        if (onLanguageChangedTriggerEnter != null)
            onLanguageChangedTriggerEnter();
    }
}
