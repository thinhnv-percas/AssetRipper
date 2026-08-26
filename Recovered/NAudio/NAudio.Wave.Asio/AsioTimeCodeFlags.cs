using System;

namespace NAudio.Wave.Asio
{
	[Flags]
	internal enum AsioTimeCodeFlags
	{
		kTcValid = 0x1,
		kTcRunning = 0x2,
		kTcReverse = 0x4,
		kTcOnspeed = 0x8,
		kTcStill = 0x10,
		kTcSpeedValid = 0x100
	}
}
