using System;

namespace NAudio.Wave.Asio
{
	[Flags]
	internal enum AsioTimeInfoFlags
	{
		kSystemTimeValid = 0x1,
		kSamplePositionValid = 0x2,
		kSampleRateValid = 0x4,
		kSpeedValid = 0x8,
		kSampleRateChanged = 0x10,
		kClockSourceChanged = 0x20
	}
}
