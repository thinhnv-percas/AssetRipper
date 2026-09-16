using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000043")]
	public class EventData
	{
		[Token(Token = "0x40001AE")]
		[FieldOffset(Offset = "0x10")]
		internal string name;

		[Token(Token = "0x170000CE")]
		public string Name
		{
			[Token(Token = "0x6000262")]
			[Address(RVA = "0x15319E4", Offset = "0x15319E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Name;
			}
		}

		[Token(Token = "0x170000CF")]
		public int Int
		{
			[CompilerGenerated]
			[Token(Token = "0x6000263")]
			[Address(RVA = "0x15319EC", Offset = "0x15319EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Int>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Int;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000264")]
			[Address(RVA = "0x15319F4", Offset = "0x15319F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Int>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Int = value;
			}
		}

		[Token(Token = "0x170000D0")]
		public float Float
		{
			[CompilerGenerated]
			[Token(Token = "0x6000265")]
			[Address(RVA = "0x15319FC", Offset = "0x15319FC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Float>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Float;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000266")]
			[Address(RVA = "0x1531A04", Offset = "0x1531A04", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Float>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Float = value;
			}
		}

		[Token(Token = "0x170000D1")]
		public string String
		{
			[CompilerGenerated]
			[Token(Token = "0x6000267")]
			[Address(RVA = "0x1531A0C", Offset = "0x1531A0C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<String>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return String;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000268")]
			[Address(RVA = "0x1531A14", Offset = "0x1531A14", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<String>k__BackingField = value;\n\treturn;\n")]
			set
			{
				String = value;
			}
		}

		[Token(Token = "0x170000D2")]
		public string AudioPath
		{
			[CompilerGenerated]
			[Token(Token = "0x6000269")]
			[Address(RVA = "0x1531A1C", Offset = "0x1531A1C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<AudioPath>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AudioPath;
			}
			[CompilerGenerated]
			[Token(Token = "0x600026A")]
			[Address(RVA = "0x1531A24", Offset = "0x1531A24", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<AudioPath>k__BackingField = value;\n\treturn;\n")]
			set
			{
				AudioPath = value;
			}
		}

		[Token(Token = "0x170000D3")]
		public float Volume
		{
			[CompilerGenerated]
			[Token(Token = "0x600026B")]
			[Address(RVA = "0x1531A2C", Offset = "0x1531A2C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Volume>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Volume;
			}
			[CompilerGenerated]
			[Token(Token = "0x600026C")]
			[Address(RVA = "0x1531A34", Offset = "0x1531A34", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Volume>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Volume = value;
			}
		}

		[Token(Token = "0x170000D4")]
		public float Balance
		{
			[CompilerGenerated]
			[Token(Token = "0x600026D")]
			[Address(RVA = "0x1531A3C", Offset = "0x1531A3C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Balance>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Balance;
			}
			[CompilerGenerated]
			[Token(Token = "0x600026E")]
			[Address(RVA = "0x1531A44", Offset = "0x1531A44", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Balance>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Balance = value;
			}
		}

		[Token(Token = "0x600026F")]
		[Address(RVA = "0x1531A4C", Offset = "0x1531A4C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv11 = name == 0;\n\tif (v11) goto L_0013;\n\tthis.name = name;\n\treturn;\nL_0013:\n\tv45 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v45, \"name\", \"name cannot be null.\");\n\tthrow v45;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EventData(string name)
		{
			if (name != null)
			{
				this.name = name;
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("name", "name cannot be null.");
			throw ex;
		}

		[Token(Token = "0x6000270")]
		[Address(RVA = "0x1531AD4", Offset = "0x1531AD4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return Name;
		}
	}
}
