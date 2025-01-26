using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuEffectsSlider : UISlider
{
    override protected void Awake()
    {
        base.Awake();
        _rectTransform = _uiData.Data.EffectsVolumeRect;
    }
}
