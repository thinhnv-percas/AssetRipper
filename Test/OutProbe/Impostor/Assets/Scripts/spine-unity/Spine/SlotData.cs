using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000061")]
	public class SlotData
	{
		[Token(Token = "0x400026C")]
		[FieldOffset(Offset = "0x10")]
		internal int index;

		[Token(Token = "0x400026D")]
		[FieldOffset(Offset = "0x18")]
		internal string name;

		[Token(Token = "0x400026E")]
		[FieldOffset(Offset = "0x20")]
		internal BoneData boneData;

		[Token(Token = "0x400026F")]
		[FieldOffset(Offset = "0x28")]
		internal float r;

		[Token(Token = "0x4000270")]
		[FieldOffset(Offset = "0x2C")]
		internal float g;

		[Token(Token = "0x4000271")]
		[FieldOffset(Offset = "0x30")]
		internal float b;

		[Token(Token = "0x4000272")]
		[FieldOffset(Offset = "0x34")]
		internal float a;

		[Token(Token = "0x4000273")]
		[FieldOffset(Offset = "0x38")]
		internal float r2;

		[Token(Token = "0x4000274")]
		[FieldOffset(Offset = "0x3C")]
		internal float g2;

		[Token(Token = "0x4000275")]
		[FieldOffset(Offset = "0x40")]
		internal float b2;

		[Token(Token = "0x4000276")]
		[FieldOffset(Offset = "0x44")]
		internal bool hasSecondColor;

		[Token(Token = "0x4000277")]
		[FieldOffset(Offset = "0x48")]
		internal string attachmentName;

		[Token(Token = "0x4000278")]
		[FieldOffset(Offset = "0x50")]
		internal BlendMode blendMode;

		[Token(Token = "0x1700014A")]
		public int Index
		{
			[Token(Token = "0x600041E")]
			[Address(RVA = "0x154E690", Offset = "0x154E690", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.index;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Index;
			}
		}

		[Token(Token = "0x1700014B")]
		public string Name
		{
			[Token(Token = "0x600041F")]
			[Address(RVA = "0x154E698", Offset = "0x154E698", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Name;
			}
		}

		[Token(Token = "0x1700014C")]
		public BoneData BoneData
		{
			[Token(Token = "0x6000420")]
			[Address(RVA = "0x154E6A0", Offset = "0x154E6A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.boneData;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return BoneData;
			}
		}

		[Token(Token = "0x1700014D")]
		public float R
		{
			[Token(Token = "0x6000421")]
			[Address(RVA = "0x154E6A8", Offset = "0x154E6A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.r;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return R;
			}
			[Token(Token = "0x6000422")]
			[Address(RVA = "0x154E6B0", Offset = "0x154E6B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.r = value;\n\treturn;\n")]
			set
			{
				R = value;
			}
		}

		[Token(Token = "0x1700014E")]
		public float G
		{
			[Token(Token = "0x6000423")]
			[Address(RVA = "0x154E6B8", Offset = "0x154E6B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.g;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return G;
			}
			[Token(Token = "0x6000424")]
			[Address(RVA = "0x154E6C0", Offset = "0x154E6C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.g = value;\n\treturn;\n")]
			set
			{
				G = value;
			}
		}

		[Token(Token = "0x1700014F")]
		public float B
		{
			[Token(Token = "0x6000425")]
			[Address(RVA = "0x154E6C8", Offset = "0x154E6C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.b;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return B;
			}
			[Token(Token = "0x6000426")]
			[Address(RVA = "0x154E6D0", Offset = "0x154E6D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.b = value;\n\treturn;\n")]
			set
			{
				B = value;
			}
		}

		[Token(Token = "0x17000150")]
		public float A
		{
			[Token(Token = "0x6000427")]
			[Address(RVA = "0x154E6D8", Offset = "0x154E6D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.a;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return A;
			}
			[Token(Token = "0x6000428")]
			[Address(RVA = "0x154E6E0", Offset = "0x154E6E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.a = value;\n\treturn;\n")]
			set
			{
				A = value;
			}
		}

		[Token(Token = "0x17000151")]
		public float R2
		{
			[Token(Token = "0x6000429")]
			[Address(RVA = "0x154E6E8", Offset = "0x154E6E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.r2;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return R2;
			}
			[Token(Token = "0x600042A")]
			[Address(RVA = "0x154E6F0", Offset = "0x154E6F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.r2 = value;\n\treturn;\n")]
			set
			{
				R2 = value;
			}
		}

		[Token(Token = "0x17000152")]
		public float G2
		{
			[Token(Token = "0x600042B")]
			[Address(RVA = "0x154E6F8", Offset = "0x154E6F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.g2;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return G2;
			}
			[Token(Token = "0x600042C")]
			[Address(RVA = "0x154E700", Offset = "0x154E700", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.g2 = value;\n\treturn;\n")]
			set
			{
				G2 = value;
			}
		}

		[Token(Token = "0x17000153")]
		public float B2
		{
			[Token(Token = "0x600042D")]
			[Address(RVA = "0x154E708", Offset = "0x154E708", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.b2;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return B2;
			}
			[Token(Token = "0x600042E")]
			[Address(RVA = "0x154E710", Offset = "0x154E710", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.b2 = value;\n\treturn;\n")]
			set
			{
				B2 = value;
			}
		}

		[Token(Token = "0x17000154")]
		public bool HasSecondColor
		{
			[Token(Token = "0x600042F")]
			[Address(RVA = "0x154E718", Offset = "0x154E718", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.hasSecondColor;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HasSecondColor;
			}
			[Token(Token = "0x6000430")]
			[Address(RVA = "0x154E720", Offset = "0x154E720", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.hasSecondColor = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				hasSecondColor = value;
			}
		}

		[Token(Token = "0x17000155")]
		public string AttachmentName
		{
			[Token(Token = "0x6000431")]
			[Address(RVA = "0x154E72C", Offset = "0x154E72C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.attachmentName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AttachmentName;
			}
			[Token(Token = "0x6000432")]
			[Address(RVA = "0x154E734", Offset = "0x154E734", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.attachmentName = value;\n\treturn;\n")]
			set
			{
				AttachmentName = value;
			}
		}

		[Token(Token = "0x17000156")]
		public BlendMode BlendMode
		{
			[Token(Token = "0x6000433")]
			[Address(RVA = "0x154E73C", Offset = "0x154E73C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.blendMode;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return BlendMode;
			}
			[Token(Token = "0x6000434")]
			[Address(RVA = "0x154E744", Offset = "0x154E744", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.blendMode = value;\n\treturn;\n")]
			set
			{
				BlendMode = value;
			}
		}

		[Token(Token = "0x6000435")]
		[Address(RVA = "0x154617C", Offset = "0x154617C", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.r = 0f;\n\tSystem.Object::.ctor(this);\n\tv20 = index & 0x80000000;\n\tv21 = v20 == 0;\n\tv22 = ~v21;\n\tif (v22) goto L_0023;\n\tv23 = name == 0;\n\tif (v23) goto L_0035;\n\tv38 = boneData == 0;\n\tif (v38) goto L_0041;\n\tthis.index = index;\n\tthis.name = name;\n\tthis.boneData = boneData;\n\treturn;\nL_0023:\n\tv42 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v42, \"index must be >= 0.\", \"index\");\n\tgoto L_0054;\nL_0035:\n\tv51 = new System.ArgumentNullException();\n\tgoto L_004E;\nL_0041:\n\tv73 = new System.ArgumentNullException();\nL_004E:\n\tSystem.ArgumentNullException::.ctor(v99, v98, v96);\nL_0054:\n\tthrow v99;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SlotData(int index, string name, BoneData boneData)
		{
			//IL_0023: Expected I4, but got I8
			base._002Ector();
			R = 0f;
			ArgumentNullException ex2 = default(ArgumentNullException);
			if ((int)(index & 0x80000000L) == 0)
			{
				if (name != null)
				{
					if (boneData != null)
					{
						this.index = index;
						this.name = name;
						this.boneData = boneData;
						return;
					}
					ArgumentNullException ex = new ArgumentNullException();
					string text = "boneData cannot be null.";
					string text2 = "boneData";
					ex2 = ex;
				}
				else
				{
					ArgumentNullException ex3 = new ArgumentNullException();
					string text = "name cannot be null.";
					string text2 = "name";
					ex2 = ex3;
				}
			}
			else
			{
				ArgumentException ex4 = new ArgumentException("index must be >= 0.", "index");
			}
			throw ex2;
		}

		[Token(Token = "0x6000436")]
		[Address(RVA = "0x154E74C", Offset = "0x154E74C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return Name;
		}
	}
}
