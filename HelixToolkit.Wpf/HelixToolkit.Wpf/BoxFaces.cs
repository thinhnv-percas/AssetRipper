using System;

namespace HelixToolkit.Wpf;

[Flags]
public enum BoxFaces
{
	PositiveZ = 1,
	Top = PositiveZ,
	NegativeZ = 2,
	Bottom = NegativeZ,
	NegativeY = 4,
	Left = NegativeY,
	PositiveY = 8,
	Right = PositiveY,
	PositiveX = 0x10,
	Front = PositiveX,
	NegativeX = 0x20,
	Back = NegativeX,
	All = PositiveZ | NegativeZ | NegativeY | PositiveY | PositiveX | NegativeX
}
