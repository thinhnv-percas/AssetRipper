using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x200004F")]
	public class PathConstraintData : ConstraintData
	{
		[Token(Token = "0x40001E9")]
		[FieldOffset(Offset = "0x20")]
		internal ExposedList<BoneData> bones = new ExposedList<BoneData>();

		[Token(Token = "0x40001EA")]
		[FieldOffset(Offset = "0x28")]
		internal SlotData target;

		[Token(Token = "0x40001EB")]
		[FieldOffset(Offset = "0x30")]
		internal PositionMode positionMode;

		[Token(Token = "0x40001EC")]
		[FieldOffset(Offset = "0x34")]
		internal SpacingMode spacingMode;

		[Token(Token = "0x40001ED")]
		[FieldOffset(Offset = "0x38")]
		internal RotateMode rotateMode;

		[Token(Token = "0x40001EE")]
		[FieldOffset(Offset = "0x3C")]
		internal float offsetRotation;

		[Token(Token = "0x40001EF")]
		[FieldOffset(Offset = "0x40")]
		internal float position;

		[Token(Token = "0x40001F0")]
		[FieldOffset(Offset = "0x44")]
		internal float spacing;

		[Token(Token = "0x40001F1")]
		[FieldOffset(Offset = "0x48")]
		internal float rotateMix;

		[Token(Token = "0x40001F2")]
		[FieldOffset(Offset = "0x4C")]
		internal float translateMix;

		[Token(Token = "0x170000F3")]
		public ExposedList<BoneData> Bones
		{
			[Token(Token = "0x6000311")]
			[Address(RVA = "0x153593C", Offset = "0x153593C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.bones;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Bones;
			}
		}

		[Token(Token = "0x170000F4")]
		public SlotData Target
		{
			[Token(Token = "0x6000312")]
			[Address(RVA = "0x1535944", Offset = "0x1535944", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.target;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Target;
			}
			[Token(Token = "0x6000313")]
			[Address(RVA = "0x153594C", Offset = "0x153594C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.target = value;\n\treturn;\n")]
			set
			{
				Target = value;
			}
		}

		[Token(Token = "0x170000F5")]
		public PositionMode PositionMode
		{
			[Token(Token = "0x6000314")]
			[Address(RVA = "0x1535954", Offset = "0x1535954", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.positionMode;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return PositionMode;
			}
			[Token(Token = "0x6000315")]
			[Address(RVA = "0x153595C", Offset = "0x153595C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.positionMode = value;\n\treturn;\n")]
			set
			{
				PositionMode = value;
			}
		}

		[Token(Token = "0x170000F6")]
		public SpacingMode SpacingMode
		{
			[Token(Token = "0x6000316")]
			[Address(RVA = "0x1535964", Offset = "0x1535964", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.spacingMode;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SpacingMode;
			}
			[Token(Token = "0x6000317")]
			[Address(RVA = "0x153596C", Offset = "0x153596C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.spacingMode = value;\n\treturn;\n")]
			set
			{
				SpacingMode = value;
			}
		}

		[Token(Token = "0x170000F7")]
		public RotateMode RotateMode
		{
			[Token(Token = "0x6000318")]
			[Address(RVA = "0x1535974", Offset = "0x1535974", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.rotateMode;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RotateMode;
			}
			[Token(Token = "0x6000319")]
			[Address(RVA = "0x153597C", Offset = "0x153597C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.rotateMode = value;\n\treturn;\n")]
			set
			{
				RotateMode = value;
			}
		}

		[Token(Token = "0x170000F8")]
		public float OffsetRotation
		{
			[Token(Token = "0x600031A")]
			[Address(RVA = "0x1535984", Offset = "0x1535984", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.offsetRotation;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return OffsetRotation;
			}
			[Token(Token = "0x600031B")]
			[Address(RVA = "0x153598C", Offset = "0x153598C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.offsetRotation = value;\n\treturn;\n")]
			set
			{
				OffsetRotation = value;
			}
		}

		[Token(Token = "0x170000F9")]
		public float Position
		{
			[Token(Token = "0x600031C")]
			[Address(RVA = "0x1535994", Offset = "0x1535994", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.position;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Position;
			}
			[Token(Token = "0x600031D")]
			[Address(RVA = "0x153599C", Offset = "0x153599C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.position = value;\n\treturn;\n")]
			set
			{
				Position = value;
			}
		}

		[Token(Token = "0x170000FA")]
		public float Spacing
		{
			[Token(Token = "0x600031E")]
			[Address(RVA = "0x15359A4", Offset = "0x15359A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.spacing;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Spacing;
			}
			[Token(Token = "0x600031F")]
			[Address(RVA = "0x15359AC", Offset = "0x15359AC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.spacing = value;\n\treturn;\n")]
			set
			{
				Spacing = value;
			}
		}

		[Token(Token = "0x170000FB")]
		public float RotateMix
		{
			[Token(Token = "0x6000320")]
			[Address(RVA = "0x15359B4", Offset = "0x15359B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.rotateMix;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RotateMix;
			}
			[Token(Token = "0x6000321")]
			[Address(RVA = "0x15359BC", Offset = "0x15359BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.rotateMix = value;\n\treturn;\n")]
			set
			{
				RotateMix = value;
			}
		}

		[Token(Token = "0x170000FC")]
		public float TranslateMix
		{
			[Token(Token = "0x6000322")]
			[Address(RVA = "0x15359C4", Offset = "0x15359C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.translateMix;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TranslateMix;
			}
			[Token(Token = "0x6000323")]
			[Address(RVA = "0x15359CC", Offset = "0x15359CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.translateMix = value;\n\treturn;\n")]
			set
			{
				TranslateMix = value;
			}
		}

		[Token(Token = "0x6000310")]
		[Address(RVA = "0x15358BC", Offset = "0x15358BC", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, name, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv49 = Spine.ExposedList`1<Spine.BoneData>;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, name, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A37B72]) = v45;\nL_001C:\n\tv47 = new Spine.ExposedList`1<Spine.BoneData>();\n\tSpine.ExposedList`1<Spine.BoneData>::.ctor(v47);\n\tthis.bones = v47;\n\tSpine.ConstraintData::.ctor(this, name);\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PathConstraintData(string name)
			: base(name)
		{
		}
	}
}
