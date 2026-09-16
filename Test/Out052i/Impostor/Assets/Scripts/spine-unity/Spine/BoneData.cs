using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x200003F")]
	public class BoneData
	{
		[Token(Token = "0x4000191")]
		[FieldOffset(Offset = "0x10")]
		internal int index;

		[Token(Token = "0x4000192")]
		[FieldOffset(Offset = "0x18")]
		internal string name;

		[Token(Token = "0x4000193")]
		[FieldOffset(Offset = "0x20")]
		internal BoneData parent;

		[Token(Token = "0x4000194")]
		[FieldOffset(Offset = "0x28")]
		internal float length;

		[Token(Token = "0x4000195")]
		[FieldOffset(Offset = "0x2C")]
		internal float x;

		[Token(Token = "0x4000196")]
		[FieldOffset(Offset = "0x30")]
		internal float y;

		[Token(Token = "0x4000197")]
		[FieldOffset(Offset = "0x34")]
		internal float rotation;

		[Token(Token = "0x4000198")]
		[FieldOffset(Offset = "0x38")]
		internal float scaleX;

		[Token(Token = "0x4000199")]
		[FieldOffset(Offset = "0x3C")]
		internal float scaleY;

		[Token(Token = "0x400019A")]
		[FieldOffset(Offset = "0x40")]
		internal float shearX;

		[Token(Token = "0x400019B")]
		[FieldOffset(Offset = "0x44")]
		internal float shearY;

		[Token(Token = "0x400019C")]
		[FieldOffset(Offset = "0x48")]
		internal TransformMode transformMode;

		[Token(Token = "0x400019D")]
		[FieldOffset(Offset = "0x4C")]
		internal bool skinRequired;

		[Token(Token = "0x170000B7")]
		public int Index
		{
			[Token(Token = "0x6000234")]
			[Address(RVA = "0x1531660", Offset = "0x1531660", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.index;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Index;
			}
		}

		[Token(Token = "0x170000B8")]
		public string Name
		{
			[Token(Token = "0x6000235")]
			[Address(RVA = "0x1531668", Offset = "0x1531668", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Name;
			}
		}

		[Token(Token = "0x170000B9")]
		public BoneData Parent
		{
			[Token(Token = "0x6000236")]
			[Address(RVA = "0x1531670", Offset = "0x1531670", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.parent;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Parent;
			}
		}

		[Token(Token = "0x170000BA")]
		public float Length
		{
			[Token(Token = "0x6000237")]
			[Address(RVA = "0x1531678", Offset = "0x1531678", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.length;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Length;
			}
			[Token(Token = "0x6000238")]
			[Address(RVA = "0x1531680", Offset = "0x1531680", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.length = value;\n\treturn;\n")]
			set
			{
				Length = value;
			}
		}

		[Token(Token = "0x170000BB")]
		public float X
		{
			[Token(Token = "0x6000239")]
			[Address(RVA = "0x1531688", Offset = "0x1531688", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.x;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return X;
			}
			[Token(Token = "0x600023A")]
			[Address(RVA = "0x1531690", Offset = "0x1531690", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.x = value;\n\treturn;\n")]
			set
			{
				X = value;
			}
		}

		[Token(Token = "0x170000BC")]
		public float Y
		{
			[Token(Token = "0x600023B")]
			[Address(RVA = "0x1531698", Offset = "0x1531698", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.y;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Y;
			}
			[Token(Token = "0x600023C")]
			[Address(RVA = "0x15316A0", Offset = "0x15316A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.y = value;\n\treturn;\n")]
			set
			{
				Y = value;
			}
		}

		[Token(Token = "0x170000BD")]
		public float Rotation
		{
			[Token(Token = "0x600023D")]
			[Address(RVA = "0x15316A8", Offset = "0x15316A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.rotation;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Rotation;
			}
			[Token(Token = "0x600023E")]
			[Address(RVA = "0x15316B0", Offset = "0x15316B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.rotation = value;\n\treturn;\n")]
			set
			{
				Rotation = value;
			}
		}

		[Token(Token = "0x170000BE")]
		public float ScaleX
		{
			[Token(Token = "0x600023F")]
			[Address(RVA = "0x15316B8", Offset = "0x15316B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.scaleX;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ScaleX;
			}
			[Token(Token = "0x6000240")]
			[Address(RVA = "0x15316C0", Offset = "0x15316C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.scaleX = value;\n\treturn;\n")]
			set
			{
				ScaleX = value;
			}
		}

		[Token(Token = "0x170000BF")]
		public float ScaleY
		{
			[Token(Token = "0x6000241")]
			[Address(RVA = "0x15316C8", Offset = "0x15316C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.scaleY;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ScaleY;
			}
			[Token(Token = "0x6000242")]
			[Address(RVA = "0x15316D0", Offset = "0x15316D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.scaleY = value;\n\treturn;\n")]
			set
			{
				ScaleY = value;
			}
		}

		[Token(Token = "0x170000C0")]
		public float ShearX
		{
			[Token(Token = "0x6000243")]
			[Address(RVA = "0x15316D8", Offset = "0x15316D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.shearX;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ShearX;
			}
			[Token(Token = "0x6000244")]
			[Address(RVA = "0x15316E0", Offset = "0x15316E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.shearX = value;\n\treturn;\n")]
			set
			{
				ShearX = value;
			}
		}

		[Token(Token = "0x170000C1")]
		public float ShearY
		{
			[Token(Token = "0x6000245")]
			[Address(RVA = "0x15316E8", Offset = "0x15316E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.shearY;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ShearY;
			}
			[Token(Token = "0x6000246")]
			[Address(RVA = "0x15316F0", Offset = "0x15316F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.shearY = value;\n\treturn;\n")]
			set
			{
				ShearY = value;
			}
		}

		[Token(Token = "0x170000C2")]
		public TransformMode TransformMode
		{
			[Token(Token = "0x6000247")]
			[Address(RVA = "0x15316F8", Offset = "0x15316F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.transformMode;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TransformMode;
			}
			[Token(Token = "0x6000248")]
			[Address(RVA = "0x1531700", Offset = "0x1531700", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.transformMode = value;\n\treturn;\n")]
			set
			{
				TransformMode = value;
			}
		}

		[Token(Token = "0x170000C3")]
		public bool SkinRequired
		{
			[Token(Token = "0x6000249")]
			[Address(RVA = "0x1531708", Offset = "0x1531708", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.skinRequired;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SkinRequired;
			}
			[Token(Token = "0x600024A")]
			[Address(RVA = "0x1531710", Offset = "0x1531710", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.skinRequired = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				skinRequired = value;
			}
		}

		[Token(Token = "0x600024B")]
		[Address(RVA = "0x153171C", Offset = "0x153171C", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.scaleX = 0f;\n\tSystem.Object::.ctor(this);\n\tv20 = index & 0x80000000;\n\tv21 = v20 == 0;\n\tv22 = ~v21;\n\tif (v22) goto L_0021;\n\tv23 = name == 0;\n\tif (v23) goto L_0033;\n\tthis.index = index;\n\tthis.name = name;\n\tthis.parent = parent;\n\treturn;\nL_0021:\n\tv46 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v46, \"index must be >= 0\", \"index\");\n\tgoto L_0046;\nL_0033:\n\tv64 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v64, \"name\", \"name cannot be null.\");\nL_0046:\n\tthrow v60;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BoneData(int index, string name, BoneData parent)
		{
			//IL_0023: Expected I4, but got I8
			base._002Ector();
			ScaleX = 0f;
			if ((int)(index & 0x80000000L) == 0)
			{
				if (name != null)
				{
					this.index = index;
					this.name = name;
					this.parent = parent;
					return;
				}
				ArgumentNullException ex = new ArgumentNullException("name", "name cannot be null.");
			}
			else
			{
				ArgumentException ex2 = new ArgumentException("index must be >= 0", "index");
			}
			object obj = default(object);
			throw obj;
		}

		[Token(Token = "0x600024C")]
		[Address(RVA = "0x153180C", Offset = "0x153180C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return Name;
		}
	}
}
