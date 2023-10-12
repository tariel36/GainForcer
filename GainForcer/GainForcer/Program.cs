using NAudio.Mixer;

UnsignedMixerControl volumeControl = null;

while (true)
{
    try
    {
        int waveInDeviceNumber = 0;
        var mixerLine = new MixerLine((IntPtr) waveInDeviceNumber,
                                       0, MixerFlags.WaveIn);

        foreach (var control in mixerLine.Controls)
        {
            if (control.ControlType == MixerControlType.Volume)
            {
                volumeControl = control as UnsignedMixerControl;
                break;
            }
        }
    }
    catch
    {
        // Ignored
    }

    if (volumeControl == null)
    {
        await Task.Delay(1000);
    }
    else
    {
        while (true)
        {
            try
            {
                volumeControl.Percent = 100;

                await Task.Delay(10);
            }
            catch
            {
                volumeControl = null;
                break;
            }
        }
    }
}

