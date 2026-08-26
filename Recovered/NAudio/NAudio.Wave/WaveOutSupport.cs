using System;

namespace NAudio.Wave
{
	[Flags]
	internal enum WaveOutSupport
	{
		Pitch = 0x1,
		PlaybackRate = 0x2,
		Volume = 0x4,
		LRVolume = 0x8,
		Sync = 0x10,
		SampleAccurate = 0x20
	}
}
