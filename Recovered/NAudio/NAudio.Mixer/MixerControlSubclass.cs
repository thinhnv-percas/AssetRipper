using System;

namespace NAudio.Mixer
{
	[Flags]
	internal enum MixerControlSubclass
	{
		SwitchBoolean = 0x0,
		SwitchButton = 0x1000000,
		MeterPolled = 0x0,
		TimeMicrosecs = 0x0,
		TimeMillisecs = 0x1000000,
		ListSingle = 0x0,
		ListMultiple = 0x1000000,
		Mask = 0xF000000
	}
}
