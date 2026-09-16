using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000063")]
	public class TransformConstraintData : ConstraintData
	{
		[Token(Token = "0x4000281")]
		[FieldOffset(Offset = "0x20")]
		internal ExposedList<BoneData> bones = new ExposedList<BoneData>();

		[Token(Token = "0x4000282")]
		[FieldOffset(Offset = "0x28")]
		internal BoneData target;

		[Token(Token = "0x4000283")]
		[FieldOffset(Offset = "0x30")]
		internal float rotateMix;

		[Token(Token = "0x4000284")]
		[FieldOffset(Offset = "0x34")]
		internal float translateMix;

		[Token(Token = "0x4000285")]
		[FieldOffset(Offset = "0x38")]
		internal float scaleMix;

		[Token(Token = "0x4000286")]
		[FieldOffset(Offset = "0x3C")]
		internal float shearMix;

		[Token(Token = "0x4000287")]
		[FieldOffset(Offset = "0x40")]
		internal float offsetRotation;

		[Token(Token = "0x4000288")]
		[FieldOffset(Offset = "0x44")]
		internal float offsetX;

		[Token(Token = "0x4000289")]
		[FieldOffset(Offset = "0x48")]
		internal float offsetY;

		[Token(Token = "0x400028A")]
		[FieldOffset(Offset = "0x4C")]
		internal float offsetScaleX;

		[Token(Token = "0x400028B")]
		[FieldOffset(Offset = "0x50")]
		internal float offsetScaleY;

		[Token(Token = "0x400028C")]
		[FieldOffset(Offset = "0x54")]
		internal float offsetShearY;

		[Token(Token = "0x400028D")]
		[FieldOffset(Offset = "0x58")]
		internal bool relative;

		[Token(Token = "0x400028E")]
		[FieldOffset(Offset = "0x59")]
		internal bool local;

		[Token(Token = "0x1700015F")]
		public ExposedList<BoneData> Bones
		{
			[Token(Token = "0x600044D")]
			[Address(RVA = "0x154FB1C", Offset = "0x154FB1C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.bones;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Bones;
			}
		}

		[Token(Token = "0x17000160")]
		public BoneData Target
		{
			[Token(Token = "0x600044E")]
			[Address(RVA = "0x154FB24", Offset = "0x154FB24", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.target;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Target;
			}
			[Token(Token = "0x600044F")]
			[Address(RVA = "0x154FB2C", Offset = "0x154FB2C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.target = value;\n\treturn;\n")]
			set
			{
				Target = value;
			}
		}

		[Token(Token = "0x17000161")]
		public float RotateMix
		{
			[Token(Token = "0x6000450")]
			[Address(RVA = "0x154FB34", Offset = "0x154FB34", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.rotateMix;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RotateMix;
			}
			[Token(Token = "0x6000451")]
			[Address(RVA = "0x154FB3C", Offset = "0x154FB3C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.rotateMix = value;\n\treturn;\n")]
			set
			{
				RotateMix = value;
			}
		}

		[Token(Token = "0x17000162")]
		public float TranslateMix
		{
			[Token(Token = "0x6000452")]
			[Address(RVA = "0x154FB44", Offset = "0x154FB44", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.translateMix;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TranslateMix;
			}
			[Token(Token = "0x6000453")]
			[Address(RVA = "0x154FB4C", Offset = "0x154FB4C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.translateMix = value;\n\treturn;\n")]
			set
			{
				TranslateMix = value;
			}
		}

		[Token(Token = "0x17000163")]
		public float ScaleMix
		{
			[Token(Token = "0x6000454")]
			[Address(RVA = "0x154FB54", Offset = "0x154FB54", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.scaleMix;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ScaleMix;
			}
			[Token(Token = "0x6000455")]
			[Address(RVA = "0x154FB5C", Offset = "0x154FB5C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.scaleMix = value;\n\treturn;\n")]
			set
			{
				ScaleMix = value;
			}
		}

		[Token(Token = "0x17000164")]
		public float ShearMix
		{
			[Token(Token = "0x6000456")]
			[Address(RVA = "0x154FB64", Offset = "0x154FB64", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.shearMix;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ShearMix;
			}
			[Token(Token = "0x6000457")]
			[Address(RVA = "0x154FB6C", Offset = "0x154FB6C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.shearMix = value;\n\treturn;\n")]
			set
			{
				ShearMix = value;
			}
		}

		[Token(Token = "0x17000165")]
		public float OffsetRotation
		{
			[Token(Token = "0x6000458")]
			[Address(RVA = "0x154FB74", Offset = "0x154FB74", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.offsetRotation;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return OffsetRotation;
			}
			[Token(Token = "0x6000459")]
			[Address(RVA = "0x154FB7C", Offset = "0x154FB7C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.offsetRotation = value;\n\treturn;\n")]
			set
			{
				OffsetRotation = value;
			}
		}

		[Token(Token = "0x17000166")]
		public float OffsetX
		{
			[Token(Token = "0x600045A")]
			[Address(RVA = "0x154FB84", Offset = "0x154FB84", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.offsetX;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return OffsetX;
			}
			[Token(Token = "0x600045B")]
			[Address(RVA = "0x154FB8C", Offset = "0x154FB8C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.offsetX = value;\n\treturn;\n")]
			set
			{
				OffsetX = value;
			}
		}

		[Token(Token = "0x17000167")]
		public float OffsetY
		{
			[Token(Token = "0x600045C")]
			[Address(RVA = "0x154FB94", Offset = "0x154FB94", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.offsetY;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return OffsetY;
			}
			[Token(Token = "0x600045D")]
			[Address(RVA = "0x154FB9C", Offset = "0x154FB9C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.offsetY = value;\n\treturn;\n")]
			set
			{
				OffsetY = value;
			}
		}

		[Token(Token = "0x17000168")]
		public float OffsetScaleX
		{
			[Token(Token = "0x600045E")]
			[Address(RVA = "0x154FBA4", Offset = "0x154FBA4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.offsetScaleX;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return OffsetScaleX;
			}
			[Token(Token = "0x600045F")]
			[Address(RVA = "0x154FBAC", Offset = "0x154FBAC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.offsetScaleX = value;\n\treturn;\n")]
			set
			{
				OffsetScaleX = value;
			}
		}

		[Token(Token = "0x17000169")]
		public float OffsetScaleY
		{
			[Token(Token = "0x6000460")]
			[Address(RVA = "0x154FBB4", Offset = "0x154FBB4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.offsetScaleY;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return OffsetScaleY;
			}
			[Token(Token = "0x6000461")]
			[Address(RVA = "0x154FBBC", Offset = "0x154FBBC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.offsetScaleY = value;\n\treturn;\n")]
			set
			{
				OffsetScaleY = value;
			}
		}

		[Token(Token = "0x1700016A")]
		public float OffsetShearY
		{
			[Token(Token = "0x6000462")]
			[Address(RVA = "0x154FBC4", Offset = "0x154FBC4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.offsetShearY;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return OffsetShearY;
			}
			[Token(Token = "0x6000463")]
			[Address(RVA = "0x154FBCC", Offset = "0x154FBCC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.offsetShearY = value;\n\treturn;\n")]
			set
			{
				OffsetShearY = value;
			}
		}

		[Token(Token = "0x1700016B")]
		public bool Relative
		{
			[Token(Token = "0x6000464")]
			[Address(RVA = "0x154FBD4", Offset = "0x154FBD4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.relative;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Relative;
			}
			[Token(Token = "0x6000465")]
			[Address(RVA = "0x154FBDC", Offset = "0x154FBDC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.relative = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				relative = value;
			}
		}

		[Token(Token = "0x1700016C")]
		public bool Local
		{
			[Token(Token = "0x6000466")]
			[Address(RVA = "0x154FBE8", Offset = "0x154FBE8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.local;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Local;
			}
			[Token(Token = "0x6000467")]
			[Address(RVA = "0x154FBF0", Offset = "0x154FBF0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.local = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				local = value;
			}
		}

		[Token(Token = "0x6000468")]
		[Address(RVA = "0x15464D0", Offset = "0x15464D0", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, name, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv49 = Spine.ExposedList`1<Spine.BoneData>;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, name, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A37BC1]) = v45;\nL_001C:\n\tv47 = new Spine.ExposedList`1<Spine.BoneData>();\n\tSpine.ExposedList`1<Spine.BoneData>::.ctor(v47);\n\tthis.bones = v47;\n\tSpine.ConstraintData::.ctor(this, name);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TransformConstraintData(string name)
			: base(name)
		{
		}
	}
}
