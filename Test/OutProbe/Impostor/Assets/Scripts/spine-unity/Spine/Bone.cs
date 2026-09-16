using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine
{
	[Token(Token = "0x200003E")]
	public class Bone : IUpdatable
	{
		[Token(Token = "0x4000175")]
		public static bool yDown;

		[Token(Token = "0x4000176")]
		[FieldOffset(Offset = "0x10")]
		internal BoneData data;

		[Token(Token = "0x4000177")]
		[FieldOffset(Offset = "0x18")]
		internal Skeleton skeleton;

		[Token(Token = "0x4000178")]
		[FieldOffset(Offset = "0x20")]
		internal Bone parent;

		[Token(Token = "0x4000179")]
		[FieldOffset(Offset = "0x28")]
		internal ExposedList<Bone> children;

		[Token(Token = "0x400017A")]
		[FieldOffset(Offset = "0x30")]
		internal float x;

		[Token(Token = "0x400017B")]
		[FieldOffset(Offset = "0x34")]
		internal float y;

		[Token(Token = "0x400017C")]
		[FieldOffset(Offset = "0x38")]
		internal float rotation;

		[Token(Token = "0x400017D")]
		[FieldOffset(Offset = "0x3C")]
		internal float scaleX;

		[Token(Token = "0x400017E")]
		[FieldOffset(Offset = "0x40")]
		internal float scaleY;

		[Token(Token = "0x400017F")]
		[FieldOffset(Offset = "0x44")]
		internal float shearX;

		[Token(Token = "0x4000180")]
		[FieldOffset(Offset = "0x48")]
		internal float shearY;

		[Token(Token = "0x4000181")]
		[FieldOffset(Offset = "0x4C")]
		internal float ax;

		[Token(Token = "0x4000182")]
		[FieldOffset(Offset = "0x50")]
		internal float ay;

		[Token(Token = "0x4000183")]
		[FieldOffset(Offset = "0x54")]
		internal float arotation;

		[Token(Token = "0x4000184")]
		[FieldOffset(Offset = "0x58")]
		internal float ascaleX;

		[Token(Token = "0x4000185")]
		[FieldOffset(Offset = "0x5C")]
		internal float ascaleY;

		[Token(Token = "0x4000186")]
		[FieldOffset(Offset = "0x60")]
		internal float ashearX;

		[Token(Token = "0x4000187")]
		[FieldOffset(Offset = "0x64")]
		internal float ashearY;

		[Token(Token = "0x4000188")]
		[FieldOffset(Offset = "0x68")]
		internal bool appliedValid;

		[Token(Token = "0x4000189")]
		[FieldOffset(Offset = "0x6C")]
		internal float a;

		[Token(Token = "0x400018A")]
		[FieldOffset(Offset = "0x70")]
		internal float b;

		[Token(Token = "0x400018B")]
		[FieldOffset(Offset = "0x74")]
		internal float worldX;

		[Token(Token = "0x400018C")]
		[FieldOffset(Offset = "0x78")]
		internal float c;

		[Token(Token = "0x400018D")]
		[FieldOffset(Offset = "0x7C")]
		internal float d;

		[Token(Token = "0x400018E")]
		[FieldOffset(Offset = "0x80")]
		internal float worldY;

		[Token(Token = "0x400018F")]
		[FieldOffset(Offset = "0x84")]
		internal bool sorted;

		[Token(Token = "0x4000190")]
		[FieldOffset(Offset = "0x85")]
		internal bool active;

		[Token(Token = "0x17000098")]
		public BoneData Data
		{
			[Token(Token = "0x60001FB")]
			[Address(RVA = "0x15301E0", Offset = "0x15301E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.data;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Data;
			}
		}

		[Token(Token = "0x17000099")]
		public Skeleton Skeleton
		{
			[Token(Token = "0x60001FC")]
			[Address(RVA = "0x15301E8", Offset = "0x15301E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.skeleton;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Skeleton;
			}
		}

		[Token(Token = "0x1700009A")]
		public Bone Parent
		{
			[Token(Token = "0x60001FD")]
			[Address(RVA = "0x15301F0", Offset = "0x15301F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.parent;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Parent;
			}
		}

		[Token(Token = "0x1700009B")]
		public ExposedList<Bone> Children
		{
			[Token(Token = "0x60001FE")]
			[Address(RVA = "0x15301F8", Offset = "0x15301F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.children;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Children;
			}
		}

		[Token(Token = "0x1700009C")]
		public bool Active
		{
			[Token(Token = "0x60001FF")]
			[Address(RVA = "0x1530200", Offset = "0x1530200", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.active;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Active;
			}
		}

		[Token(Token = "0x1700009D")]
		public float X
		{
			[Token(Token = "0x6000200")]
			[Address(RVA = "0x1530208", Offset = "0x1530208", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.x;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return X;
			}
			[Token(Token = "0x6000201")]
			[Address(RVA = "0x1530210", Offset = "0x1530210", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.x = value;\n\treturn;\n")]
			set
			{
				X = value;
			}
		}

		[Token(Token = "0x1700009E")]
		public float Y
		{
			[Token(Token = "0x6000202")]
			[Address(RVA = "0x1530218", Offset = "0x1530218", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.y;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Y;
			}
			[Token(Token = "0x6000203")]
			[Address(RVA = "0x1530220", Offset = "0x1530220", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.y = value;\n\treturn;\n")]
			set
			{
				Y = value;
			}
		}

		[Token(Token = "0x1700009F")]
		public float Rotation
		{
			[Token(Token = "0x6000204")]
			[Address(RVA = "0x1530228", Offset = "0x1530228", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.rotation;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Rotation;
			}
			[Token(Token = "0x6000205")]
			[Address(RVA = "0x1530230", Offset = "0x1530230", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.rotation = value;\n\treturn;\n")]
			set
			{
				Rotation = value;
			}
		}

		[Token(Token = "0x170000A0")]
		public float ScaleX
		{
			[Token(Token = "0x6000206")]
			[Address(RVA = "0x1530238", Offset = "0x1530238", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.scaleX;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ScaleX;
			}
			[Token(Token = "0x6000207")]
			[Address(RVA = "0x1530240", Offset = "0x1530240", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.scaleX = value;\n\treturn;\n")]
			set
			{
				ScaleX = value;
			}
		}

		[Token(Token = "0x170000A1")]
		public float ScaleY
		{
			[Token(Token = "0x6000208")]
			[Address(RVA = "0x1530248", Offset = "0x1530248", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.scaleY;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ScaleY;
			}
			[Token(Token = "0x6000209")]
			[Address(RVA = "0x1530250", Offset = "0x1530250", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.scaleY = value;\n\treturn;\n")]
			set
			{
				ScaleY = value;
			}
		}

		[Token(Token = "0x170000A2")]
		public float ShearX
		{
			[Token(Token = "0x600020A")]
			[Address(RVA = "0x1530258", Offset = "0x1530258", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.shearX;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ShearX;
			}
			[Token(Token = "0x600020B")]
			[Address(RVA = "0x1530260", Offset = "0x1530260", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.shearX = value;\n\treturn;\n")]
			set
			{
				ShearX = value;
			}
		}

		[Token(Token = "0x170000A3")]
		public float ShearY
		{
			[Token(Token = "0x600020C")]
			[Address(RVA = "0x1530268", Offset = "0x1530268", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.shearY;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ShearY;
			}
			[Token(Token = "0x600020D")]
			[Address(RVA = "0x1530270", Offset = "0x1530270", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.shearY = value;\n\treturn;\n")]
			set
			{
				ShearY = value;
			}
		}

		[Token(Token = "0x170000A4")]
		public float AppliedRotation
		{
			[Token(Token = "0x600020E")]
			[Address(RVA = "0x1530278", Offset = "0x1530278", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.arotation;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AppliedRotation;
			}
			[Token(Token = "0x600020F")]
			[Address(RVA = "0x1530280", Offset = "0x1530280", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.arotation = value;\n\treturn;\n")]
			set
			{
				AppliedRotation = value;
			}
		}

		[Token(Token = "0x170000A5")]
		public float AX
		{
			[Token(Token = "0x6000210")]
			[Address(RVA = "0x1530288", Offset = "0x1530288", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ax;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AX;
			}
			[Token(Token = "0x6000211")]
			[Address(RVA = "0x1530290", Offset = "0x1530290", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.ax = value;\n\treturn;\n")]
			set
			{
				AX = value;
			}
		}

		[Token(Token = "0x170000A6")]
		public float AY
		{
			[Token(Token = "0x6000212")]
			[Address(RVA = "0x1530298", Offset = "0x1530298", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ay;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AY;
			}
			[Token(Token = "0x6000213")]
			[Address(RVA = "0x15302A0", Offset = "0x15302A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.ay = value;\n\treturn;\n")]
			set
			{
				AY = value;
			}
		}

		[Token(Token = "0x170000A7")]
		public float AScaleX
		{
			[Token(Token = "0x6000214")]
			[Address(RVA = "0x15302A8", Offset = "0x15302A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ascaleX;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AScaleX;
			}
			[Token(Token = "0x6000215")]
			[Address(RVA = "0x15302B0", Offset = "0x15302B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.ascaleX = value;\n\treturn;\n")]
			set
			{
				AScaleX = value;
			}
		}

		[Token(Token = "0x170000A8")]
		public float AScaleY
		{
			[Token(Token = "0x6000216")]
			[Address(RVA = "0x15302B8", Offset = "0x15302B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ascaleY;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AScaleY;
			}
			[Token(Token = "0x6000217")]
			[Address(RVA = "0x15302C0", Offset = "0x15302C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.ascaleY = value;\n\treturn;\n")]
			set
			{
				AScaleY = value;
			}
		}

		[Token(Token = "0x170000A9")]
		public float AShearX
		{
			[Token(Token = "0x6000218")]
			[Address(RVA = "0x15302C8", Offset = "0x15302C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ashearX;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AShearX;
			}
			[Token(Token = "0x6000219")]
			[Address(RVA = "0x15302D0", Offset = "0x15302D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.ashearX = value;\n\treturn;\n")]
			set
			{
				AShearX = value;
			}
		}

		[Token(Token = "0x170000AA")]
		public float AShearY
		{
			[Token(Token = "0x600021A")]
			[Address(RVA = "0x15302D8", Offset = "0x15302D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ashearY;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AShearY;
			}
			[Token(Token = "0x600021B")]
			[Address(RVA = "0x15302E0", Offset = "0x15302E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.ashearY = value;\n\treturn;\n")]
			set
			{
				AShearY = value;
			}
		}

		[Token(Token = "0x170000AB")]
		public float A
		{
			[Token(Token = "0x600021C")]
			[Address(RVA = "0x15302E8", Offset = "0x15302E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.a;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return A;
			}
		}

		[Token(Token = "0x170000AC")]
		public float B
		{
			[Token(Token = "0x600021D")]
			[Address(RVA = "0x15302F0", Offset = "0x15302F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.b;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return B;
			}
		}

		[Token(Token = "0x170000AD")]
		public float C
		{
			[Token(Token = "0x600021E")]
			[Address(RVA = "0x15302F8", Offset = "0x15302F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.c;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return C;
			}
		}

		[Token(Token = "0x170000AE")]
		public float D
		{
			[Token(Token = "0x600021F")]
			[Address(RVA = "0x1530300", Offset = "0x1530300", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.d;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return D;
			}
		}

		[Token(Token = "0x170000AF")]
		public float WorldX
		{
			[Token(Token = "0x6000220")]
			[Address(RVA = "0x1530308", Offset = "0x1530308", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.worldX;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return WorldX;
			}
		}

		[Token(Token = "0x170000B0")]
		public float WorldY
		{
			[Token(Token = "0x6000221")]
			[Address(RVA = "0x1530310", Offset = "0x1530310", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.worldY;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return WorldY;
			}
		}

		[Token(Token = "0x170000B1")]
		public float WorldRotationX
		{
			[Token(Token = "0x6000222")]
			[Address(RVA = "0x1530318", Offset = "0x1530318", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = Spine.MathUtils;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 1;\n\t*([1A37B4D]) = v41;\nL_001B:\n\tgoto L_001F;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_001F:\n\tv52 = Spine.MathUtils::Atan2(this.c, this.a);\n\treturnVal1 = v52 * 57.295776f;\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				float num = MathUtils.Atan2(C, A);
				return num * (180f / (float)Math.PI);
			}
		}

		[Token(Token = "0x170000B2")]
		public float WorldRotationY
		{
			[Token(Token = "0x6000223")]
			[Address(RVA = "0x1530390", Offset = "0x1530390", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = Spine.MathUtils;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 1;\n\t*([1A37B4E]) = v41;\nL_001B:\n\tgoto L_001F;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_001F:\n\tv52 = Spine.MathUtils::Atan2(this.d, this.b);\n\treturnVal1 = v52 * 57.295776f;\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				float num = MathUtils.Atan2(D, B);
				return num * (180f / (float)Math.PI);
			}
		}

		[Token(Token = "0x170000B3")]
		public float WorldScaleX
		{
			[Token(Token = "0x6000224")]
			[Address(RVA = "0x1530408", Offset = "0x1530408", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = System.Math;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 1;\n\t*([1A37B4F]) = v41;\nL_001B:\n\tgoto L_0021;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0021:\n\tv54 = this.a * this.a;\n\tv55 = this.c * this.c;\n\tv56 = v54 + v55;\n\treturnVal1 = UnityEngine.Mathf::Sqrt(v56);\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				float num = A * A;
				float num2 = C * C;
				float f = num + num2;
				return Mathf.Sqrt(f);
			}
		}

		[Token(Token = "0x170000B4")]
		public float WorldScaleY
		{
			[Token(Token = "0x6000225")]
			[Address(RVA = "0x1530478", Offset = "0x1530478", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = System.Math;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 1;\n\t*([1A37B50]) = v41;\nL_001B:\n\tgoto L_0021;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0021:\n\tv54 = this.b * this.b;\n\tv55 = this.d * this.d;\n\tv56 = v54 + v55;\n\treturnVal1 = UnityEngine.Mathf::Sqrt(v56);\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				float num = B * B;
				float num2 = D * D;
				float f = num + num2;
				return Mathf.Sqrt(f);
			}
		}

		[Token(Token = "0x170000B5")]
		public float WorldToLocalRotationX
		{
			[Token(Token = "0x600022E")]
			[Address(RVA = "0x15312D4", Offset = "0x15312D4", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv26 = Spine.MathUtils;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 1;\n\t*([1A37B54]) = v45;\nL_0016:\n\tv46 = this.parent;\n\tv47 = this.parent == 0;\n\tif (v47) goto L_0032;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v55, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0027:\n\tv63 = v46.a * this.c;\n\tv64 = v46.c * this.a;\n\tv65 = v46.d * this.a;\n\tv66 = v46.b * this.c;\n\tv67 = v63 - v64;\n\tv68 = v65 - v66;\n\tv69 = Spine.MathUtils::Atan2(v67, v68);\n\treturnVal1 = v69 * 57.295776f;\n\tgoto L_003D;\nL_0032:\n\treturnVal1 = this.arotation;\nL_003D:\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Bone bone = Parent;
				if (Parent != null)
				{
					float num = bone.A * C;
					float num2 = bone.C * A;
					float num3 = bone.D * A;
					float num4 = bone.B * C;
					float num5 = num - num2;
					float num6 = num3 - num4;
					float num7 = MathUtils.Atan2(num5, num6);
					return num7 * (180f / (float)Math.PI);
				}
				return AppliedRotation;
			}
		}

		[Token(Token = "0x170000B6")]
		public float WorldToLocalRotationY
		{
			[Token(Token = "0x600022F")]
			[Address(RVA = "0x1531384", Offset = "0x1531384", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv26 = Spine.MathUtils;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 1;\n\t*([1A37B55]) = v45;\nL_0016:\n\tv46 = this.parent;\n\tv47 = this.parent == 0;\n\tif (v47) goto L_0032;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v55, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0027:\n\tv63 = v46.a * this.d;\n\tv64 = v46.c * this.b;\n\tv65 = v46.d * this.b;\n\tv66 = v46.b * this.d;\n\tv67 = v63 - v64;\n\tv68 = v65 - v66;\n\tv69 = Spine.MathUtils::Atan2(v67, v68);\n\treturnVal1 = v69 * 57.295776f;\n\tgoto L_003D;\nL_0032:\n\treturnVal1 = this.arotation;\nL_003D:\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Bone bone = Parent;
				if (Parent != null)
				{
					float num = bone.A * D;
					float num2 = bone.C * B;
					float num3 = bone.D * B;
					float num4 = bone.B * D;
					float num5 = num - num2;
					float num6 = num3 - num4;
					float num7 = MathUtils.Atan2(num5, num6);
					return num7 * (180f / (float)Math.PI);
				}
				return AppliedRotation;
			}
		}

		[Token(Token = "0x6000226")]
		[Address(RVA = "0x15304E8", Offset = "0x15304E8", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, data, skeleton, parent, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv55 = Spine.ExposedList`1<Spine.Bone>;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, data, skeleton, parent, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv51 = 1;\n\t*([1A37B51]) = v51;\nL_0020:\n\tv53 = new Spine.ExposedList`1<Spine.Bone>();\n\tSpine.ExposedList`1<Spine.Bone>::.ctor(v53);\n\tthis.children = v53;\n\tSystem.Object::.ctor(this);\n\tv60 = data == 0;\n\tif (v60) goto L_003E;\n\tv61 = skeleton == 0;\n\tif (v61) goto L_004A;\n\tthis.data = data;\n\tthis.skeleton = skeleton;\n\tthis.parent = parent;\n\tSpine.Bone::SetToSetupPose(this);\n\treturn;\nL_003E:\n\tv77 = new System.ArgumentNullException();\n\tgoto L_0057;\nL_004A:\n\tv78 = new System.ArgumentNullException();\nL_0057:\n\tSystem.ArgumentNullException::.ctor(v99, v95, v113);\n\tthrow v99;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Bone(BoneData data, Skeleton skeleton, Bone parent)
		{
			ExposedList<Bone> exposedList = new ExposedList<Bone>();
			children = exposedList;
			ArgumentNullException ex2;
			if (data != null)
			{
				if (skeleton != null)
				{
					this.data = data;
					this.skeleton = skeleton;
					this.parent = parent;
					SetToSetupPose();
					return;
				}
				ArgumentNullException ex = new ArgumentNullException();
				string text = "skeleton cannot be null.";
				string text2 = "skeleton";
				ex2 = ex;
			}
			else
			{
				ArgumentNullException ex3 = new ArgumentNullException();
				string text = "data cannot be null.";
				string text2 = "data";
				ex2 = ex3;
			}
			throw ex2;
		}

		[Token(Token = "0x6000227")]
		[Address(RVA = "0x153064C", Offset = "0x153064C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Bone::UpdateWorldTransform(this, this.x, this.y, this.rotation, this.scaleX, this.scaleY, this.shearX, this.shearY);\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Update()
		{
			UpdateWorldTransform(X, Y, Rotation, ScaleX, ScaleY, ShearX, ShearY);
		}

		[Token(Token = "0x6000228")]
		[Address(RVA = "0x1530E58", Offset = "0x1530E58", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Bone::UpdateWorldTransform(this, this.x, this.y, this.rotation, this.scaleX, this.scaleY, this.shearX, this.shearY);\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateWorldTransform()
		{
			UpdateWorldTransform(X, Y, Rotation, ScaleX, ScaleY, ShearX, ShearY);
		}

		[Token(Token = "0x6000229")]
		[Address(RVA = "0x1530660", Offset = "0x1530660", Length = "0x7F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv52 = Spine.MathUtils;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, methodInfo, v55, v56, v57, v58, v59, v60, x, y, rotation, scaleX, scaleY, shearX, shearY, v61);\n\tv73 = System.Math;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, methodInfo, v55, v56, v57, v58, v59, v60, x, y, rotation, scaleX, scaleY, shearX, shearY, v61);\n\tv65 = 1;\n\t*([1A37B52]) = v65;\nL_0026:\n\tv66 = v62.skeleton;\n\tv67 = v62.parent;\n\tv62.ax = x;\n\tv62.ay = y;\n\tv62.arotation = rotation;\n\tv62.ascaleX = scaleX;\n\tv62.ascaleY = scaleY;\n\tv62.ashearX = shearX;\n\tv62.ashearY = shearY;\n\tv62.appliedValid = 1;\n\tv71 = v62.parent == 0;\n\tif (v71) goto L_0173;\n\tv79 = v67.a * x;\n\tv82 = v67.b * y;\n\tv83 = v79 + v82;\n\tv84 = v83 + v67.worldX;\n\tv62.worldX = v84;\n\tv86 = v62.data;\n\tv87 = v67.c * x;\n\tv88 = v67.d * y;\n\tv89 = v87 + v88;\n\tv90 = v89 + v67.worldY;\n\tv62.worldY = v90;\n\tv93 = v86.transformMode;\n\tv97 = v86.transformMode < 7;\n\tv98 = ~v97;\n\tv99 = v86.transformMode - 7;\n\tv101 = v99 == 0;\n\tv106 = ~v101;\n\tv107 = v98 & v106;\n\tif (v107) goto L_02AE;\n\tv152 = 0x44C000 + 0xD1E;\n\tv155 = *([v152 @ X9_v8 (System.Int32)+v93 @ X8_v15 (Spine.TransformMode)*2]) << 2;\n\tv156 = 0x1534768 + v155;\n\t// 96 IndirectJump v156 @ X10_v2 (System.Int32), v62 @ X0_v1 (Spine.Bone), v62 @ X0_v1 (Spine.Bone), methodInfo @ X1 (Il2CppMethodInfo), v55 @ X2, v56 @ X3, v57 @ X4, v58 @ X5, v59 @ X6, v60 @ X7, v90 @ V0_v29 (System.Single), v89 @ V1_v9 (System.Single), v88 @ V2_v5 (System.Single), v67.d (System.Single), scaleY @ V4 (System.Single), shearX @ V5 (System.Single), shearY @ V6 (System.Single), v61 @ V7\n\tX23 = *([1946708]);\n\tX0 = *([X23]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0069;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0069:\n\tV0 = V14;\n\tstack[0] = V10;\n\tV0 = Spine.MathUtils::CosDeg(V0, X0);\n\tV15 = V0;\n\tV0 = V14;\n\tV0 = Spine.MathUtils::SinDeg(V0, X0);\n\tif (TEMP) goto L_FFFFFFFF;\n\tV1 = stack[C];\n\tX8 = *([1A37B73]);\n\tV14 = *([X20+74]);\n\tV12 = V0;\n\tV0 = V8 * V15;\n\tV1 = V1 * V12;\n\tV10 = V0 + V1;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0081;\n\tX0 = *([1946B10]);\n\tX0 = 0xAD9498(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 1;\n\t*([1A37B73]) = X8;\nL_0081:\n\tX8 = *([X21]);\n\tV0 = *([X20+78]);\n\tV1 = V13 * V15;\n\tX8 = *([X8+B8]);\n\tX24 = *([19355D8]);\n\tV2 = stack[8];\n\tV3 = -V0;\n\tX9 = *([X8]);\n\tX0 = *([X24]);\n\tV2 = V2 * V12;\n\tV1 = V1 + V2;\n\tC = X9 < 0;\n\tC = ~C;\n\tTEMP1 = X9 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ 0;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX8 = *([X0+E0]);\n\tTEMPCSEL = ~Z;\n\tif (TEMPCSEL) goto L_009B;\n\tV0 = V0;\n\tgoto L_009C;\nL_009B:\n\tV0 = V3;\nL_009C:\n\t;\n\tV14 = V10 / V14;\n\tV12 = V1 / V0;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00A5;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X24]);\n\tX8 = *([X0+E0]);\nL_00A5:\n\tV0 = V14 * V14;\n\tV1 = V12 * V12;\n\tV0 = V0 + V1;\n\tV1 = 1E-05f;\n\tV10 = stack[0];\n\tV0 = UnityEngine.Mathf::Sqrt(V0);\n\tV2 = 1f;\n\tV2 = V2 / V0;\n\tC = V0 < V1;\n\tC = ~C;\n\tTEMP1 = V0 - V1;\n\tN = TEMP1 < 0;\n\tTEMP2 = V0 ^ V1;\n\tTEMP3 = V0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND2 = ~Z;\n\tTEMPCOND = TEMPCOND & TEMPCOND2;\n\tTEMPCSEL = ~TEMPCOND;\n\tif (TEMPCSEL) goto L_00BE;\n\tV15 = V2;\n\tgoto L_00BF;\nL_00BE:\n\tV15 = V0;\nL_00BF:\n\t;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00C4;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00C4:\n\tX8 = *([X19+10]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X8+48]);\n\tV14 = V14 * V15;\n\tV12 = V12 * V15;\n\tV0 = V14 * V14;\n\tV1 = V12 * V12;\n\tV0 = V0 + V1;\n\tC = X8 < 2;\n\tC = ~C;\n\tTEMP1 = X8 - 2;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 2;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tV15 = UnityEngine.Mathf::Sqrt(V0);\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0133;\n\tX8 = *([1A37B73]);\n\tV3 = *([X20+74]);\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00E8;\n\tX0 = *([1946B10]);\n\tV9 = V10;\n\tV10 = V3;\n\tX0 = 0xAD9498(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV3 = V10;\n\tV10 = V9;\n\tX8 = 1;\n\t*([1A37B73]) = X8;\nL_00E8:\n\tX8 = *([X21]);\n\tV1 = stack[8];\n\tV2 = stack[C];\n\tV0 = *([X20+78]);\n\tX8 = *([X8+B8]);\n\tV1 = V8 * V1;\n\tV2 = V2 * V13;\n\tV1 = V1 - V2;\n\tX8 = *([X8]);\n\tV2 = -V0;\n\tC = X8 < 0;\n\tC = ~C;\n\tTEMP1 = X8 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 0;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCSEL = ~Z;\n\tif (TEMPCSEL) goto L_00FF;\n\tV0 = V0;\n\tgoto L_0100;\nL_00FF:\n\tV0 = V2;\nL_0100:\n\t;\n\tC = V1 < 0;\n\tC = ~C;\n\tTEMP1 = V1 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = V1 ^ 0;\n\tTEMP3 = V1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~N;\n\tX8 = TEMPCOND;\n\tC = V3 < 0;\n\tC = ~C;\n\tTEMP1 = V3 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = V3 ^ 0;\n\tTEMP3 = V3 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX9 = N;\n\tC = V0 < 0;\n\tC = ~C;\n\tTEMP1 = V0 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = V0 ^ 0;\n\tTEMP3 = V0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX10 = N;\n\tX9 = X9 ^ X10;\n\tX8 = X8 ^ X9;\n\tV0 = -V15;\n\tC = X8 < 0;\n\tC = ~C;\n\tTEMP1 = X8 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 0;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tTEMPCSEL = ~TEMPCOND;\n\tif (TEMPCSEL) goto L_0131;\n\tV15 = V15;\n\tgoto L_0132;\nL_0131:\n\tV15 = V0;\nL_0132:\n\t;\nL_0133:\n\tX0 = *([X23]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0139;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0139:\n\tV0 = V12;\n\tV1 = V14;\n\tV0 = Spine.MathUtils::Atan2(V0, V1, X0);\n\tV1 = 1.5707964f;\n\tV13 = V0 + V1;\n\tV0 = V13;\n\tV0 = Spine.MathUtils::Cos(V0, X0);\n\tV0 = V15 * V0;\n\tstack[8] = V0;\n\tV0 = V13;\n\tV0 = Spine.MathUtils::Sin(V0, X0);\n\tV9 = stack[58];\n\tV0 = V15 * V0;\n\tstack[C] = V0;\n\tV0 = V9;\n\tV0 = Spine.MathUtils::CosDeg(V0, X0);\n\tV13 = V14;\n\tV14 = stack[5C];\n\tV15 = V0 * V14;\n\tV0 = X8;\n\tV10 = V10 + V0;\n\tV0 = V10;\n\tV0 = Spine.MathUtils::CosDeg(V0, X0);\n\tV8 = V0 * V11;\n\tV0 = V9;\n\tV0 = Spine.MathUtils::SinDeg(V0, X0);\n\tV9 = V0 * V14;\n\tV0 = V10;\n\tV0 = Spine.MathUtils::SinDeg(V0, X0);\n\tV7 = stack[8];\n\tV16 = stack[C];\n\tV0 = V0 * V11;\n\tV1 = V13 * V15;\n\tV3 = V13 * V8;\n\tV2 = V7 * V9;\n\tV4 = V12 * V15;\n\tV5 = V16 * V9;\n\tV6 = V12 * V8;\n\tV1 = V1 + V2;\n\tV2 = V7 * V0;\n\tV0 = V16 * V0;\n\tV4 = V4 + V5;\n\tV2 = V3 + V2;\n\tV0 = V6 + V0;\n\t*([X19+6C]) = V1;\n\t*([X19+70]) = V2;\n\t*([X19+78]) = V4;\n\t*([X19+7C]) = V0;\n\tgoto L_02AE;\nL_0173:\n\tv147 = rotation + 0x42B40000;\n\tgoto L_0181;\n\tv158 = Spine.Bone;\n\tv159 = \"il2cpp_codegen_initialize_runtime_metadata\"(v158, methodInfo, v55, v56, v57, v58, v59, v60, v146, y, rotation, scaleX, scaleY, shearX, shearY, v61);\n\tv162 = 1;\n\t*([1A37B73]) = v162;\nL_0181:\n\tv167 = v147 + shearY;\n\tv174 = -v66.scaleY;\n\tif (v169.yDown) goto L_FFFFFFFF;\n\tgoto L_019B;\nL_019B:\n\tgoto L_019E;\n\tv301 = \"il2cpp_codegen_runtime_class_init\"(v173, methodInfo, v55, v56, v57, v58, v59, v60, v171, v174, rotation, scaleX, scaleY, shearX, shearY, v61);\nL_019E:\n\tv304 = rotation + shearX;\n\tv306 = Spine.MathUtils::CosDeg(v304);\n\tv311 = v306 * scaleX;\n\tv312 = v66.scaleX * v311;\n\tv62.a = v312;\n\tv314 = Spine.MathUtils::CosDeg(v167);\n\tv315 = v314 * scaleY;\n\tv316 = v66.scaleX * v315;\n\tv62.b = v316;\n\tv318 = Spine.MathUtils::SinDeg(v304);\n\tv329 = v318 * scaleX;\n\tv330 = v296 * v329;\n\tv62.c = v330;\n\tv332 = Spine.MathUtils::SinDeg(v167);\n\tv333 = v332 * scaleY;\n\tv334 = v296 * v333;\n\tv62.d = v334;\n\tv336 = v66.scaleX * x;\n\tv337 = v336 + v66.x;\n\tv62.worldX = v337;\n\tv321 = v296 * y;\n\tv322 = v321 + v66.y;\n\tv62.worldY = v322;\n\tgoto L_02E3;\n\tstack[4] = V11;\n\tV9 = stack[5C];\n\tX8 = *([1946708]);\n\tX0 = *([X8]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_01C7;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_01C7:\n\tV0 = stack[58];\n\tV11 = V14 + V0;\n\tV0 = V11;\n\tV0 = Spine.MathUtils::CosDeg(V0, X0);\n\tV12 = V0 * V9;\n\tV0 = X8;\n\tV0 = V14 + V0;\n\tV10 = V0 + V10;\n\tV0 = V10;\n\tV0 = Spine.MathUtils::CosDeg(V0, X0);\n\tV15 = stack[4];\n\tV14 = V0 * V15;\n\tV0 = V11;\n\tV0 = Spine.MathUtils::SinDeg(V0, X0);\n\tV9 = V0 * V9;\n\tV0 = V10;\n\tV0 = Spine.MathUtils::SinDeg(V0, X0);\n\tV16 = stack[8];\n\tV7 = stack[C];\n\tV0 = V0 * V15;\n\tV1 = V8 * V12;\n\tV3 = V8 * V14;\n\tV2 = V7 * V9;\n\tV4 = V13 * V12;\n\tV5 = V16 * V9;\n\tV1 = V1 + V2;\n\tV2 = V7 * V0\n// ... truncated")]
		public void UpdateWorldTransform(float x, float y, float rotation, float scaleX, float scaleY, float shearX, float shearY)
		{
			//IL_0405: Expected O, but got I
			//IL_0422: Expected O, but got I
			Skeleton skeleton = Skeleton;
			Bone bone = Parent;
			AX = x;
			AY = y;
			AppliedRotation = rotation;
			AScaleX = scaleX;
			AScaleY = scaleY;
			AShearX = shearX;
			AShearY = shearY;
			appliedValid = true;
			if (Parent != null)
			{
				float num = bone.A * x;
				float num2 = bone.B * y;
				float num3 = num + num2;
				float num4 = num3 + bone.WorldX;
				worldX = num4;
				BoneData boneData = Data;
				float num5 = bone.C * x;
				float num6 = bone.D * y;
				float num7 = num5 + num6;
				float num8 = num7 + bone.WorldY;
				worldY = num8;
				TransformMode transformMode = boneData.TransformMode;
				bool flag = boneData.TransformMode < TransformMode.OnlyTranslation;
				bool flag2 = !flag;
				int num9 = (int)(boneData.TransformMode - 7);
				bool flag3 = num9 == 0;
				bool flag4 = !flag3;
				if (flag2 && flag4)
				{
					object obj = default(object);
					float num10 = A * (float)obj;
					a = num10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A37000]");
					object obj2 = 0;
					float num11 = skeleton.scaleY;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ X8_v18+B8]");
					object obj3 = 0;
					float num12 = 0f - skeleton.scaleY;
					if (obj3 != null)
					{
						num11 = num12;
					}
					float num13 = C * num11;
					float num14 = D * num11;
					c = num13;
					d = num14;
					return;
				}
				int num15 = 4505600 + 3358;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ X9_v8 (System.Int32)+v93 @ X8_v15 (Spine.TransformMode)*2]");
				int num16 = (int)((nint)0 << 2);
				int num17 = 22234984 + num16;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v156 @ X10_v2 (System.Int32) (should have been resolved before IL gen)");
			}
			float num18 = rotation + 90f;
			float degrees = num18 + shearY;
			float num19 = 0f - skeleton.scaleY;
			float num20 = (yDown ? num19 : skeleton.scaleY);
			float degrees2 = rotation + shearX;
			float num21 = MathUtils.CosDeg(degrees2);
			float num22 = num21 * scaleX;
			float num23 = skeleton.ScaleX * num22;
			a = num23;
			float num24 = MathUtils.CosDeg(degrees);
			float num25 = num24 * scaleY;
			float num26 = skeleton.ScaleX * num25;
			b = num26;
			float num27 = MathUtils.SinDeg(degrees2);
			float num28 = num27 * scaleX;
			float num29 = num20 * num28;
			c = num29;
			float num30 = MathUtils.SinDeg(degrees);
			float num31 = num30 * scaleY;
			float num32 = num20 * num31;
			d = num32;
			float num33 = skeleton.ScaleX * x;
			float num34 = num33 + skeleton.X;
			worldX = num34;
			float num35 = num20 * y;
			float num36 = num35 + skeleton.Y;
			worldY = num36;
		}

		[Token(Token = "0x600022A")]
		[Address(RVA = "0x153061C", Offset = "0x153061C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.data;\n\tthis.x = v2.x;\n\tthis.scaleY = v2.scaleY;\n\tthis.shearY = v2.shearY;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetToSetupPose()
		{
			BoneData boneData = Data;
			X = boneData.X;
			ScaleY = boneData.ScaleY;
			ShearY = boneData.ShearY;
		}

		[Token(Token = "0x600022B")]
		[Address(RVA = "0x1530F90", Offset = "0x1530F90", Length = "0x2E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = Spine.MathUtils;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv53 = System.Math;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A37B53]) = v46;\nL_001A:\n\tv48 = this.parent;\n\tthis.appliedValid = 1;\n\tv51 = this.parent == 0;\n\tif (v51) goto L_0089;\n\tthis.ashearX = 0f;\n\tv65 = this.worldX - v48.worldX;\n\tv66 = v48.a * v48.d;\n\tv67 = this.worldY - v48.worldY;\n\tv68 = v48.b * v48.c;\n\tv69 = v66 - v68;\n\tv70 = v48.d * v65;\n\tv71 = 1f / v69;\n\tv72 = v48.b * v67;\n\tv73 = v48.a * v67;\n\tv74 = v48.c * v65;\n\tv75 = v71 * v70;\n\tv76 = v71 * v72;\n\tv77 = v71 * v73;\n\tv78 = v71 * v74;\n\tv79 = v75 - v76;\n\tv80 = v77 - v78;\n\tthis.ax = v79;\n\tthis.ay = v80;\n\tv82 = v48.a * v71;\n\tv83 = v48.b * v71;\n\tv84 = v48.c * v71;\n\tv85 = v48.d * v71;\n\tv89 = v83 * this.c;\n\tv90 = v83 * this.d;\n\tv91 = v85 * this.a;\n\tv92 = v85 * this.b;\n\tv93 = v82 * this.c;\n\tv94 = v84 * this.a;\n\tv95 = v91 - v89;\n\tv96 = v93 - v94;\n\tv97 = v82 * this.d;\n\tv98 = v84 * this.b;\n\tgoto L_0056;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v81, methodInfo, v29, v30, v31, v32, v33, v34, v82, v93, v94, v84, v89, v86, v91, v79);\nL_0056:\n\tv115 = v95 * v95;\n\tv116 = v96 * v96;\n\tv117 = v115 + v116;\n\tv118 = UnityEngine.Mathf::Sqrt(v117);\n\tv124 = v92 - v90;\n\tv125 = v97 - v98;\n\tthis.ascaleX = v118;\n\tv137 = v118 <= 0.0001f;\n\tif (v137) goto L_00BE;\n\tv149 = v95 * v125;\n\tv150 = v96 * v124;\n\tv151 = v149 - v150;\n\tv152 = v151 / v118;\n\tthis.ascaleY = v152;\n\tgoto L_0077;\n\tv195 = \"il2cpp_codegen_runtime_class_init\"(v155, methodInfo, v29, v30, v31, v32, v33, v34, v152, v149, v150, v84, v89, v86, v91, v79);\nL_0077:\n\tv197 = v95 * v124;\n\tv198 = v96 * v125;\n\tv199 = v197 + v198;\n\tv201 = Spine.MathUtils::Atan2(v199, v151);\n\tv212 = v201 * 57.295776f;\n\tthis.ashearY = v212;\n\tv214 = Spine.MathUtils::Atan2(v96, v95);\n\tv269 = v214 * 57.295776f;\n\tgoto L_00DC;\nL_0089:\n\tthis.ax = this.worldX;\n\tthis.ay = this.worldY;\n\tgoto L_0095;\n\tv119 = \"il2cpp_codegen_runtime_class_init\"(v107, methodInfo, v29, v30, v31, v32, v33, v34, v101, v103, v37, v38, v39, v40, v41, v42);\nL_0095:\n\tv123 = Spine.MathUtils::Atan2(this.c, this.a);\n\tv142 = v123 * 57.295776f;\n\tthis.arotation = v142;\n\tgoto L_00AC;\n\tv163 = v140;\n\tv164 = v141;\n\tv165 = \"il2cpp_codegen_runtime_class_init\"(v143, methodInfo, v29, v30, v31, v32, v33, v34, v144, v145, v37, v38, v39, v140, v141, v42);\n\tv173 = v163;\n\tv171 = v164;\n\tv175 = *([v20 @ X19_v1 (Spine.Bone)+6C]);\n\tv177 = *([v20 @ X19_v1 (Spine.Bone)+78]);\nL_00AC:\n\tthis.ashearX = 0f;\n\tv185 = this.b * this.a;\n\tv186 = this.d * this.a;\n\tv187 = this.d * this.c;\n\tv188 = this.a * this.a;\n\tv189 = this.c * this.c;\n\tv190 = this.b * this.c;\n\tv191 = v185 + v187;\n\tv192 = v188 + v189;\n\t// 183 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv193 = v186 - v190;\n\tthis.ascaleX = v192;\n\tv194 = Spine.MathUtils::Atan2(v191, v193);\n\tv208 = v194 * 57.295776f;\n\tthis.ashearY = v208;\n\tgoto L_00E7;\nL_00BE:\n\tthis.ascaleX = 0f;\n\tgoto L_00C5;\n\tv202 = \"il2cpp_codegen_runtime_class_init\"(v159, methodInfo, v29, v30, v31, v32, v33, v34, v118, v114, v116, v84, v89, v86, v91, v79);\nL_00C5:\n\tv204 = v124 * v124;\n\tv205 = v125 * v125;\n\tv206 = v204 + v205;\n\tv207 = UnityEngine.Mathf::Sqrt(v206);\n\tthis.ashearY = 0f;\n\tthis.ascaleY = v207;\n\tgoto L_00D5;\n\tv286 = \"il2cpp_codegen_runtime_class_init\"(v217, methodInfo, v29, v30, v31, v32, v33, v34, v207, v205, v116, v84, v89, v86, v91, v79);\nL_00D5:\n\tv290 = Spine.MathUtils::Atan2(v125, v124);\n\tv296 = v290 * -57.295776f;\n\tv269 = v296 + 0x42B40000;\nL_00DC:\n\tthis.arotation = v269;\nL_00E7:\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void UpdateAppliedTransform()
		{
			Bone bone = Parent;
			appliedValid = true;
			if (Parent != null)
			{
				AShearX = 0f;
				float num = WorldX - bone.WorldX;
				float num2 = bone.A * bone.D;
				float num3 = WorldY - bone.WorldY;
				float num4 = bone.B * bone.C;
				float num5 = num2 - num4;
				float num6 = bone.D * num;
				float num7 = 1f / num5;
				float num8 = bone.B * num3;
				float num9 = bone.A * num3;
				float num10 = bone.C * num;
				float num11 = num7 * num6;
				float num12 = num7 * num8;
				float num13 = num7 * num9;
				float num14 = num7 * num10;
				float aX = num11 - num12;
				float aY = num13 - num14;
				AX = aX;
				AY = aY;
				float num15 = bone.A * num7;
				float num16 = bone.B * num7;
				float num17 = bone.C * num7;
				float num18 = bone.D * num7;
				float num19 = num16 * C;
				float num20 = num16 * D;
				float num21 = num18 * A;
				float num22 = num18 * B;
				float num23 = num15 * C;
				float num24 = num17 * A;
				float num25 = num21 - num19;
				float num26 = num23 - num24;
				float num27 = num15 * D;
				float num28 = num17 * B;
				float num29 = num25 * num25;
				float num30 = num26 * num26;
				float f = num29 + num30;
				float num31 = Mathf.Sqrt(f);
				float num32 = num22 - num20;
				float num33 = num27 - num28;
				AScaleX = num31;
				float appliedRotation;
				if (num31 > 0.0001f)
				{
					float num34 = num25 * num33;
					float num35 = num26 * num32;
					float num36 = num34 - num35;
					float aScaleY = num36 / num31;
					AScaleY = aScaleY;
					float num37 = num25 * num32;
					float num38 = num26 * num33;
					float num39 = num37 + num38;
					float num40 = MathUtils.Atan2(num39, num36);
					float aShearY = num40 * (180f / (float)Math.PI);
					AShearY = aShearY;
					float num41 = MathUtils.Atan2(num26, num25);
					appliedRotation = num41 * (180f / (float)Math.PI);
				}
				else
				{
					AScaleX = 0f;
					float num42 = num32 * num32;
					float num43 = num33 * num33;
					float f2 = num42 + num43;
					float aScaleY2 = Mathf.Sqrt(f2);
					AShearY = 0f;
					AScaleY = aScaleY2;
					float num44 = MathUtils.Atan2(num33, num32);
					float num45 = num44 * (-180f / (float)Math.PI);
					appliedRotation = num45 + 90f;
				}
				AppliedRotation = appliedRotation;
			}
			else
			{
				AX = WorldX;
				AY = WorldY;
				float num46 = MathUtils.Atan2(C, A);
				float appliedRotation2 = num46 * (180f / (float)Math.PI);
				AppliedRotation = appliedRotation2;
				AShearX = 0f;
				float num47 = B * A;
				float num48 = D * A;
				float num49 = D * C;
				float num50 = A * A;
				float num51 = C * C;
				float num52 = B * C;
				float num53 = num47 + num49;
				float aScaleX = num50 + num51;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				float num54 = num48 - num52;
				AScaleX = aScaleX;
				float num55 = MathUtils.Atan2(num53, num54);
				float aShearY2 = num55 * (180f / (float)Math.PI);
				AShearY = aShearY2;
			}
		}

		[Token(Token = "0x600022C")]
		[Address(RVA = "0x1531278", Offset = "0x1531278", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = worldX - this.worldX;\n\tv9 = this.a * this.d;\n\tv10 = worldY - this.worldY;\n\tv12 = this.b * this.c;\n\tv13 = v9 - v12;\n\tv15 = this.d * v7;\n\tv16 = this.b * v10;\n\tv17 = this.a * v10;\n\tv18 = this.c * v7;\n\tv19 = 1f / v13;\n\tv20 = v15 * v19;\n\tv21 = v19 * v16;\n\tv22 = v19 * v17;\n\tv23 = v18 * v19;\n\tv24 = v20 - v21;\n\tv25 = v22 - v23;\n\t*([localX @ X1 (System.Single&)]) = v24;\n\t*([localY @ X2 (System.Single&)]) = v25;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void WorldToLocal(float worldX, float worldY, out float localX, out float localY)
		{
			//IL_0121: Expected Ref, but got F4
			//IL_0129: Expected Ref, but got F4
			localX = default(float);
			localY = default(float);
			float num = worldX - WorldX;
			float num2 = A * D;
			float num3 = worldY - WorldY;
			float num4 = B * C;
			float num5 = num2 - num4;
			float num6 = D * num;
			float num7 = B * num3;
			float num8 = A * num3;
			float num9 = C * num;
			float num10 = 1f / num5;
			float num11 = num6 * num10;
			float num12 = num10 * num7;
			float num13 = num10 * num8;
			float num14 = num9 * num10;
			float num15 = num11 - num12;
			float num16 = num13 - num14;
			ref float reference = ref *(float*)num15;
			ref float reference2 = ref *(float*)num16;
		}

		[Token(Token = "0x600022D")]
		[Address(RVA = "0x152F370", Offset = "0x152F370", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.a * localX;\n\tv6 = this.b * localY;\n\tv8 = v4 + v6;\n\tv9 = this.worldX + v8;\n\t*([worldX @ X1 (System.Single&)]) = v9;\n\tv14 = this.c * localX;\n\tv15 = this.d * localY;\n\tv16 = v14 + v15;\n\tv17 = this.worldY + v16;\n\t*([worldY @ X2 (System.Single&)]) = v17;\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void LocalToWorld(float localX, float localY, out float worldX, out float worldY)
		{
			//IL_005e: Expected Ref, but got F4
			//IL_00a8: Expected Ref, but got F4
			worldX = default(float);
			worldY = default(float);
			float num = A * localX;
			float num2 = B * localY;
			float num3 = num + num2;
			float num4 = WorldX + num3;
			ref float reference = ref *(float*)num4;
			float num5 = C * localX;
			float num6 = D * localY;
			float num7 = num5 + num6;
			float num8 = WorldY + num7;
			ref float reference2 = ref *(float*)num8;
		}

		[Token(Token = "0x6000230")]
		[Address(RVA = "0x1531434", Offset = "0x1531434", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = Spine.MathUtils;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, worldRotation, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A37B56]) = v42;\nL_001A:\n\tgoto L_001D;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v27, v28, v29, v30, v31, v32, worldRotation, v33, v34, v35, v36, v37, v38, v39);\nL_001D:\n\tv50 = Spine.MathUtils::SinDeg(worldRotation);\n\tv53 = Spine.MathUtils::CosDeg(worldRotation);\n\tv58 = v50 * this.a;\n\tv59 = v53 * this.c;\n\tv60 = v53 * this.d;\n\tv61 = v50 * this.b;\n\tv62 = v58 - v59;\n\tv63 = v60 - v61;\n\tv64 = Spine.MathUtils::Atan2(v62, v63);\n\tv73 = v64 * 57.295776f;\n\tv74 = v73 + this.rotation;\n\treturnVal1 = v74 - this.shearX;\n\treturn returnVal1;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float WorldToLocalRotation(float worldRotation)
		{
			float num = MathUtils.SinDeg(worldRotation);
			float num2 = MathUtils.CosDeg(worldRotation);
			float num3 = num * A;
			float num4 = num2 * C;
			float num5 = num2 * D;
			float num6 = num * B;
			float num7 = num3 - num4;
			float num8 = num5 - num6;
			float num9 = MathUtils.Atan2(num7, num8);
			float num10 = num9 * (180f / (float)Math.PI);
			float num11 = num10 + Rotation;
			return num11 - ShearX;
		}

		[Token(Token = "0x6000231")]
		[Address(RVA = "0x15314E4", Offset = "0x15314E4", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = Spine.MathUtils;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, localRotation, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A37B57]) = v42;\nL_001A:\n\tv47 = this.rotation - this.shearX;\n\tv48 = localRotation - v47;\n\tgoto L_0021;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v27, v28, v29, v30, v31, v32, v47, v45, v34, v35, v36, v37, v38, v39);\nL_0021:\n\tv54 = Spine.MathUtils::SinDeg(v48);\n\tv57 = Spine.MathUtils::CosDeg(v48);\n\tv62 = v57 * this.c;\n\tv63 = v54 * this.d;\n\tv64 = v57 * this.a;\n\tv65 = v54 * this.b;\n\tv66 = v62 + v63;\n\tv67 = v64 + v65;\n\tv68 = Spine.MathUtils::Atan2(v66, v67);\n\treturnVal1 = v68 * 57.295776f;\n\treturn returnVal1;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float LocalToWorldRotation(float localRotation)
		{
			float num = Rotation - ShearX;
			float degrees = localRotation - num;
			float num2 = MathUtils.SinDeg(degrees);
			float num3 = MathUtils.CosDeg(degrees);
			float num4 = num3 * C;
			float num5 = num2 * D;
			float num6 = num3 * A;
			float num7 = num2 * B;
			float num8 = num4 + num5;
			float num9 = num6 + num7;
			float num10 = MathUtils.Atan2(num8, num9);
			return num10 * (180f / (float)Math.PI);
		}

		[Token(Token = "0x6000232")]
		[Address(RVA = "0x1531594", Offset = "0x1531594", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = Spine.MathUtils;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, degrees, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 1;\n\t*([1A37B58]) = v44;\nL_001D:\n\tgoto L_0020;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v29, v30, v31, v32, v33, v34, degrees, v35, v36, v37, v38, v39, v40, v41);\nL_0020:\n\tv54 = Spine.MathUtils::CosDeg(degrees);\n\tv57 = Spine.MathUtils::SinDeg(degrees);\n\tv59 = this.c * v60;\n\tv61 = this.a * v60;\n\tthis.appliedValid = 0;\n\tv62 = this.a * v63;\n\tv64 = this.c * v63;\n\tv65 = v62 - v59;\n\tv66 = v64 + v61;\n\tthis.a = v65;\n\tthis.c = v66;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RotateWorld(float degrees)
		{
			float num = MathUtils.CosDeg(degrees);
			float num2 = MathUtils.SinDeg(degrees);
			object obj = default(object);
			float num3 = C * (float)obj;
			float num4 = A * (float)obj;
			appliedValid = false;
			object obj2 = default(object);
			float num5 = A * (float)obj2;
			float num6 = C * (float)obj2;
			float num7 = num5 - num3;
			float num8 = num6 + num4;
			a = num7;
			c = num8;
		}

		[Token(Token = "0x6000233")]
		[Address(RVA = "0x1531644", Offset = "0x1531644", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.data;\n\treturn v2.name;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			BoneData boneData = Data;
			return boneData.Name;
		}
	}
}
