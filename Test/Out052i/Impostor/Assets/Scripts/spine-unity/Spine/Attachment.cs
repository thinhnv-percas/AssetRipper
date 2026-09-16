using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000032")]
	public abstract class Attachment
	{
		[CompilerGenerated]
		[Token(Token = "0x4000122")]
		[FieldOffset(Offset = "0x10")]
		private string _003CName_003Ek__BackingField;

		[Token(Token = "0x1700005B")]
		public string Name
		{
			[CompilerGenerated]
			[Token(Token = "0x6000163")]
			[Address(RVA = "0x152E57C", Offset = "0x152E57C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Name>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Name;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000164")]
			[Address(RVA = "0x152E584", Offset = "0x152E584", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Name>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CName_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x6000165")]
		[Address(RVA = "0x152E58C", Offset = "0x152E58C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv11 = name == 0;\n\tif (v11) goto L_0013;\n\tthis.<Name>k__BackingField = name;\n\treturn;\nL_0013:\n\tv45 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v45, \"name\", \"name cannot be null\");\n\tthrow v45;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal Attachment(string name)
		{
			if (name != null)
			{
				Name = name;
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("name", "name cannot be null");
			throw ex;
		}

		[Token(Token = "0x6000166")]
		[Address(RVA = "0x152E614", Offset = "0x152E614", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Name>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return Name;
		}

		[Token(Token = "0x6000167")]
		public abstract Attachment Copy();
	}
}
