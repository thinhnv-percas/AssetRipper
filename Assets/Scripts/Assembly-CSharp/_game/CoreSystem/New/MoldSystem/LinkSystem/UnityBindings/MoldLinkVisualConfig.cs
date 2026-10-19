using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings
{
	[Serializable]
	[Token(Token = "0x20002A8")]
	public class MoldLinkVisualConfig
	{
		[Token(Token = "0x4000830")]
		[FieldOffset(Offset = "0x10")]
		public GameObject linkCapPrefab;

		[Token(Token = "0x4000831")]
		[FieldOffset(Offset = "0x18")]
		public Material ropeMaterial;

		[Token(Token = "0x4000832")]
		[FieldOffset(Offset = "0x20")]
		public float ropeSag;

		[Token(Token = "0x4000833")]
		[FieldOffset(Offset = "0x24")]
		public float ropeRadius;

		[Token(Token = "0x4000834")]
		[FieldOffset(Offset = "0x28")]
		public int ropeSegments;

		[Token(Token = "0x4000835")]
		[FieldOffset(Offset = "0x2C")]
		public int ropeRadialSegments;

		[Header("Link Break VFX")]
		[Token(Token = "0x4000836")]
		[FieldOffset(Offset = "0x30")]
		public GameObject connectedVfxPrefab;

		[Token(Token = "0x4000837")]
		[FieldOffset(Offset = "0x38")]
		public Vector3 connectedVfxOffset;

		[Token(Token = "0x6000BC9")]
		[Address(RVA = "0x3ECAF30", Offset = "0x3ECAF30", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.connectedVfxOffset = -1.4901164746561335E-09d;\n\tthis.connectedVfxOffset.z = -0.75f;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public MoldLinkVisualConfig()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldLinkVisualConfig::.ctor");
		}
	}
}
