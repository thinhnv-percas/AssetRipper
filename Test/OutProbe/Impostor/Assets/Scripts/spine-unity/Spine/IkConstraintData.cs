using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000047")]
	public class IkConstraintData : ConstraintData
	{
		[Token(Token = "0x40001C7")]
		[FieldOffset(Offset = "0x20")]
		internal ExposedList<BoneData> bones = new ExposedList<BoneData>();

		[Token(Token = "0x40001C8")]
		[FieldOffset(Offset = "0x28")]
		internal BoneData target;

		[Token(Token = "0x40001C9")]
		[FieldOffset(Offset = "0x30")]
		internal int bendDirection;

		[Token(Token = "0x40001CA")]
		[FieldOffset(Offset = "0x34")]
		internal bool compress;

		[Token(Token = "0x40001CB")]
		[FieldOffset(Offset = "0x35")]
		internal bool stretch;

		[Token(Token = "0x40001CC")]
		[FieldOffset(Offset = "0x36")]
		internal bool uniform;

		[Token(Token = "0x40001CD")]
		[FieldOffset(Offset = "0x38")]
		internal float mix;

		[Token(Token = "0x40001CE")]
		[FieldOffset(Offset = "0x3C")]
		internal float softness;

		[Token(Token = "0x170000E1")]
		public ExposedList<BoneData> Bones
		{
			[Token(Token = "0x60002D6")]
			[Address(RVA = "0x1533034", Offset = "0x1533034", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.bones;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Bones;
			}
		}

		[Token(Token = "0x170000E2")]
		public BoneData Target
		{
			[Token(Token = "0x60002D7")]
			[Address(RVA = "0x153303C", Offset = "0x153303C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.target;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Target;
			}
			[Token(Token = "0x60002D8")]
			[Address(RVA = "0x1533044", Offset = "0x1533044", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.target = value;\n\treturn;\n")]
			set
			{
				Target = value;
			}
		}

		[Token(Token = "0x170000E3")]
		public float Mix
		{
			[Token(Token = "0x60002D9")]
			[Address(RVA = "0x153304C", Offset = "0x153304C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mix;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Mix;
			}
			[Token(Token = "0x60002DA")]
			[Address(RVA = "0x1533054", Offset = "0x1533054", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mix = value;\n\treturn;\n")]
			set
			{
				Mix = value;
			}
		}

		[Token(Token = "0x170000E4")]
		public float Softness
		{
			[Token(Token = "0x60002DB")]
			[Address(RVA = "0x153305C", Offset = "0x153305C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.softness;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Softness;
			}
			[Token(Token = "0x60002DC")]
			[Address(RVA = "0x1533064", Offset = "0x1533064", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.softness = value;\n\treturn;\n")]
			set
			{
				Softness = value;
			}
		}

		[Token(Token = "0x170000E5")]
		public int BendDirection
		{
			[Token(Token = "0x60002DD")]
			[Address(RVA = "0x153306C", Offset = "0x153306C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.bendDirection;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return BendDirection;
			}
			[Token(Token = "0x60002DE")]
			[Address(RVA = "0x1533074", Offset = "0x1533074", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.bendDirection = value;\n\treturn;\n")]
			set
			{
				BendDirection = value;
			}
		}

		[Token(Token = "0x170000E6")]
		public bool Compress
		{
			[Token(Token = "0x60002DF")]
			[Address(RVA = "0x153307C", Offset = "0x153307C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.compress;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Compress;
			}
			[Token(Token = "0x60002E0")]
			[Address(RVA = "0x1533084", Offset = "0x1533084", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.compress = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				compress = value;
			}
		}

		[Token(Token = "0x170000E7")]
		public bool Stretch
		{
			[Token(Token = "0x60002E1")]
			[Address(RVA = "0x1533090", Offset = "0x1533090", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.stretch;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Stretch;
			}
			[Token(Token = "0x60002E2")]
			[Address(RVA = "0x1533098", Offset = "0x1533098", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.stretch = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				stretch = value;
			}
		}

		[Token(Token = "0x170000E8")]
		public bool Uniform
		{
			[Token(Token = "0x60002E3")]
			[Address(RVA = "0x15330A4", Offset = "0x15330A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.uniform;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Uniform;
			}
			[Token(Token = "0x60002E4")]
			[Address(RVA = "0x15330AC", Offset = "0x15330AC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.uniform = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				uniform = value;
			}
		}

		[Token(Token = "0x60002D5")]
		[Address(RVA = "0x1532FA4", Offset = "0x1532FA4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, name, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv49 = Spine.ExposedList`1<Spine.BoneData>;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, name, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A37B5D]) = v45;\nL_001C:\n\tv47 = new Spine.ExposedList`1<Spine.BoneData>();\n\tSpine.ExposedList`1<Spine.BoneData>::.ctor(v47);\n\tthis.bones = v47;\n\tthis.bendDirection = 1;\n\tthis.mix = 1f;\n\tSpine.ConstraintData::.ctor(this, name);\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IkConstraintData(string name)
		{
			BendDirection = 1;
			Mix = 1f;
			base._002Ector(name);
		}
	}
}
