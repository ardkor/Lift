using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuMasterSlider : UISlider
{
    override protected void Awake()
    {
        base.Awake();
        _rectTransform = _buttonData.Data.MasterVolumeRect;
    }
}
