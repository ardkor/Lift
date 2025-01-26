using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuMusicSlider : UISlider
{
    override protected void Awake()
    {
        base.Awake();
        _rectTransform = _uiData.Data.MusicVolumeRect;
    }
}
