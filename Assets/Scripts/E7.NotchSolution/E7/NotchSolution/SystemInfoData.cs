using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace E7.NotchSolution
{
	[Serializable]
	[Token(Token = "0x2000013")]
	internal class SystemInfoData
	{
		[Token(Token = "0x4000034")]
		[FieldOffset(Offset = "0x10")]
		public string deviceModel;

		[Token(Token = "0x4000035")]
		[FieldOffset(Offset = "0x18")]
		public DeviceType deviceType;

		[Token(Token = "0x4000036")]
		[FieldOffset(Offset = "0x20")]
		public string operatingSystem;

		[Token(Token = "0x4000037")]
		[FieldOffset(Offset = "0x28")]
		public OperatingSystemFamily operatingSystemFamily;

		[Token(Token = "0x4000038")]
		[FieldOffset(Offset = "0x2C")]
		public int processorCount;

		[Token(Token = "0x4000039")]
		[FieldOffset(Offset = "0x30")]
		public int processorFrequency;

		[Token(Token = "0x400003A")]
		[FieldOffset(Offset = "0x38")]
		public string processorType;

		[Token(Token = "0x400003B")]
		[FieldOffset(Offset = "0x40")]
		public bool supportsAccelerometer;

		[Token(Token = "0x400003C")]
		[FieldOffset(Offset = "0x41")]
		public bool supportsAudio;

		[Token(Token = "0x400003D")]
		[FieldOffset(Offset = "0x42")]
		public bool supportsGyroscope;

		[Token(Token = "0x400003E")]
		[FieldOffset(Offset = "0x43")]
		public bool supportsLocationService;

		[Token(Token = "0x400003F")]
		[FieldOffset(Offset = "0x44")]
		public bool supportsVibration;

		[Token(Token = "0x4000040")]
		[FieldOffset(Offset = "0x48")]
		public int systemMemorySize;

		[Token(Token = "0x4000041")]
		[FieldOffset(Offset = "0x50")]
		public string unsupportedIdentifier;

		[Token(Token = "0x4000042")]
		[FieldOffset(Offset = "0x58")]
		public GraphicsDependentSystemInfoData[] GraphicsDependentData;

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x3F46170", Offset = "0x3F46170", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SystemInfoData()
		{
		}
	}
}
