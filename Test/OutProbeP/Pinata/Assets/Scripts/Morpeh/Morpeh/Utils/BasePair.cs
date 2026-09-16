using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using JetBrains.Annotations;
using UnityEngine;

namespace Morpeh.Utils
{
	[Serializable]
	[Token(Token = "0x2000035")]
	public abstract class BasePair<T> where T : class, ISystem
	{
		[SerializeField]
		[Token(Token = "0x4000060")]
		[FieldOffset(Offset = "0x0")]
		private bool enabled;

		[SerializeField]
		[CanBeNull]
		[Token(Token = "0x4000061")]
		[FieldOffset(Offset = "0x0")]
		private T system;

		[Token(Token = "0x17000018")]
		public bool Enabled
		{
			[Token(Token = "0x60000E3")]
			[Address(RVA = "0x10A4CD4", Offset = "0x10A4CD4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.enabled;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Enabled;
			}
			[Token(Token = "0x60000E4")]
			[Address(RVA = "0x10A4CDC", Offset = "0x10A4CDC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.enabled = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				enabled = value;
			}
		}

		[CanBeNull]
		[Token(Token = "0x17000019")]
		public T System
		{
			[Token(Token = "0x60000E5")]
			[Address(RVA = "0x10A4CE8", Offset = "0x10A4CE8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.system;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return System;
			}
		}

		[Token(Token = "0x60000E6")]
		[Address(RVA = "0x10A4CF0", Offset = "0x10A4CF0", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.enabled = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BasePair()
		{
			enabled = true;
		}

		[Token(Token = "0x60000E7")]
		[Address(RVA = "0x10A4D28", Offset = "0x10A4D28", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void OnChange()
		{
		}
	}
}
