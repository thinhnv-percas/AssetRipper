using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000041")]
	public abstract class ConstraintData
	{
		[Token(Token = "0x40001A4")]
		[FieldOffset(Offset = "0x10")]
		internal readonly string name;

		[Token(Token = "0x40001A5")]
		[FieldOffset(Offset = "0x18")]
		internal int order;

		[Token(Token = "0x40001A6")]
		[FieldOffset(Offset = "0x1C")]
		internal bool skinRequired;

		[Token(Token = "0x170000C4")]
		public string Name
		{
			[Token(Token = "0x600024E")]
			[Address(RVA = "0x153189C", Offset = "0x153189C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Name;
			}
		}

		[Token(Token = "0x170000C5")]
		public int Order
		{
			[Token(Token = "0x600024F")]
			[Address(RVA = "0x15318A4", Offset = "0x15318A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.order;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Order;
			}
			[Token(Token = "0x6000250")]
			[Address(RVA = "0x15318AC", Offset = "0x15318AC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.order = value;\n\treturn;\n")]
			set
			{
				Order = value;
			}
		}

		[Token(Token = "0x170000C6")]
		public bool SkinRequired
		{
			[Token(Token = "0x6000251")]
			[Address(RVA = "0x15318B4", Offset = "0x15318B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.skinRequired;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SkinRequired;
			}
			[Token(Token = "0x6000252")]
			[Address(RVA = "0x15318BC", Offset = "0x15318BC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.skinRequired = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				skinRequired = value;
			}
		}

		[Token(Token = "0x600024D")]
		[Address(RVA = "0x1531814", Offset = "0x1531814", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv11 = name == 0;\n\tif (v11) goto L_0013;\n\tthis.name = name;\n\treturn;\nL_0013:\n\tv45 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v45, \"name\", \"name cannot be null.\");\n\tthrow v45;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ConstraintData(string name)
		{
			if (name != null)
			{
				this.name = name;
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("name", "name cannot be null.");
			throw ex;
		}

		[Token(Token = "0x6000253")]
		[Address(RVA = "0x15318C8", Offset = "0x15318C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return Name;
		}
	}
}
