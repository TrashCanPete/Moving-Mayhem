using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AreaSetterWBehavior : AreaSetter
{
    public UnityEvent OnComplete;
    public override void Cleared()
    {
        Score.Points += bonusPoints;
        BonusDisplay.ShowBonus("Cleared " + areaName, bonusPoints);
        if (OnComplete.GetPersistentEventCount() > 0)
            OnComplete.Invoke();
    }
}
