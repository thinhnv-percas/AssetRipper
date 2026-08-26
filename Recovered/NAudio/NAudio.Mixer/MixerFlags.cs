using System;

namespace NAudio.Mixer
{
	[Flags]
	public enum MixerFlags
	{
		Handle = int.MinValue,
		Mixer = 0x0,
		MixerHandle = int.MinValue,
		WaveOut = 0x10000000,
		WaveOutHandle = -1879048192,
		WaveIn = 0x20000000,
		WaveInHandle = -1610612736,
		MidiOut = 0x30000000,
		MidiOutHandle = -1342177280,
		MidiIn = 0x40000000,
		MidiInHandle = -1073741824,
		Aux = 0x50000000,
		Value = 0x0,
		ListText = 0x1,
		QueryMask = 0xF,
		All = 0x0,
		OneById = 0x1,
		OneByType = 0x2,
		GetLineInfoOfDestination = 0x0,
		GetLineInfoOfSource = 0x1,
		GetLineInfoOfLineId = 0x2,
		GetLineInfoOfComponentType = 0x3,
		GetLineInfoOfTargetType = 0x4,
		GetLineInfoOfQueryMask = 0xF
	}
}
