using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Spine.Collections;

namespace Spine
{
	[Token(Token = "0x2000053")]
	public class Skeleton
	{
		[Token(Token = "0x40001FE")]
		[FieldOffset(Offset = "0x10")]
		internal SkeletonData data;

		[Token(Token = "0x40001FF")]
		[FieldOffset(Offset = "0x18")]
		internal ExposedList<Bone> bones;

		[Token(Token = "0x4000200")]
		[FieldOffset(Offset = "0x20")]
		internal ExposedList<Slot> slots;

		[Token(Token = "0x4000201")]
		[FieldOffset(Offset = "0x28")]
		internal ExposedList<Slot> drawOrder;

		[Token(Token = "0x4000202")]
		[FieldOffset(Offset = "0x30")]
		internal ExposedList<IkConstraint> ikConstraints;

		[Token(Token = "0x4000203")]
		[FieldOffset(Offset = "0x38")]
		internal ExposedList<TransformConstraint> transformConstraints;

		[Token(Token = "0x4000204")]
		[FieldOffset(Offset = "0x40")]
		internal ExposedList<PathConstraint> pathConstraints;

		[Token(Token = "0x4000205")]
		[FieldOffset(Offset = "0x48")]
		internal ExposedList<IUpdatable> updateCache;

		[Token(Token = "0x4000206")]
		[FieldOffset(Offset = "0x50")]
		internal ExposedList<Bone> updateCacheReset;

		[Token(Token = "0x4000207")]
		[FieldOffset(Offset = "0x58")]
		internal Skin skin;

		[Token(Token = "0x4000208")]
		[FieldOffset(Offset = "0x60")]
		internal float r;

		[Token(Token = "0x4000209")]
		[FieldOffset(Offset = "0x64")]
		internal float g;

		[Token(Token = "0x400020A")]
		[FieldOffset(Offset = "0x68")]
		internal float b;

		[Token(Token = "0x400020B")]
		[FieldOffset(Offset = "0x6C")]
		internal float a;

		[Token(Token = "0x400020C")]
		[FieldOffset(Offset = "0x70")]
		internal float time;

		[Token(Token = "0x400020D")]
		[FieldOffset(Offset = "0x74")]
		private float scaleX;

		[Token(Token = "0x400020E")]
		[FieldOffset(Offset = "0x78")]
		internal float scaleY;

		[Token(Token = "0x400020F")]
		[FieldOffset(Offset = "0x7C")]
		internal float x;

		[Token(Token = "0x4000210")]
		[FieldOffset(Offset = "0x80")]
		internal float y;

		[Token(Token = "0x170000FD")]
		public SkeletonData Data
		{
			[Token(Token = "0x6000324")]
			[Address(RVA = "0x15359D4", Offset = "0x15359D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.data;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Data;
			}
		}

		[Token(Token = "0x170000FE")]
		public ExposedList<Bone> Bones
		{
			[Token(Token = "0x6000325")]
			[Address(RVA = "0x15359DC", Offset = "0x15359DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.bones;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Bones;
			}
		}

		[Token(Token = "0x170000FF")]
		public ExposedList<IUpdatable> UpdateCacheList
		{
			[Token(Token = "0x6000326")]
			[Address(RVA = "0x15359E4", Offset = "0x15359E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.updateCache;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return UpdateCacheList;
			}
		}

		[Token(Token = "0x17000100")]
		public ExposedList<Slot> Slots
		{
			[Token(Token = "0x6000327")]
			[Address(RVA = "0x15359EC", Offset = "0x15359EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.slots;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Slots;
			}
		}

		[Token(Token = "0x17000101")]
		public ExposedList<Slot> DrawOrder
		{
			[Token(Token = "0x6000328")]
			[Address(RVA = "0x15359F4", Offset = "0x15359F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.drawOrder;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DrawOrder;
			}
		}

		[Token(Token = "0x17000102")]
		public ExposedList<IkConstraint> IkConstraints
		{
			[Token(Token = "0x6000329")]
			[Address(RVA = "0x15359FC", Offset = "0x15359FC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ikConstraints;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IkConstraints;
			}
		}

		[Token(Token = "0x17000103")]
		public ExposedList<PathConstraint> PathConstraints
		{
			[Token(Token = "0x600032A")]
			[Address(RVA = "0x1535A04", Offset = "0x1535A04", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.pathConstraints;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return PathConstraints;
			}
		}

		[Token(Token = "0x17000104")]
		public ExposedList<TransformConstraint> TransformConstraints
		{
			[Token(Token = "0x600032B")]
			[Address(RVA = "0x1535A0C", Offset = "0x1535A0C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.transformConstraints;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TransformConstraints;
			}
		}

		[Token(Token = "0x17000105")]
		public Skin Skin
		{
			[Token(Token = "0x600032C")]
			[Address(RVA = "0x1535A14", Offset = "0x1535A14", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.skin;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Skin;
			}
			[Token(Token = "0x600032D")]
			[Address(RVA = "0x1535A1C", Offset = "0x1535A1C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Skeleton::SetSkin(this, value);\n\treturn;\n")]
			set
			{
				SetSkin(value);
			}
		}

		[Token(Token = "0x17000106")]
		public float R
		{
			[Token(Token = "0x600032E")]
			[Address(RVA = "0x1535B10", Offset = "0x1535B10", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.r;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return R;
			}
			[Token(Token = "0x600032F")]
			[Address(RVA = "0x1535B18", Offset = "0x1535B18", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.r = value;\n\treturn;\n")]
			set
			{
				R = value;
			}
		}

		[Token(Token = "0x17000107")]
		public float G
		{
			[Token(Token = "0x6000330")]
			[Address(RVA = "0x1535B20", Offset = "0x1535B20", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.g;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return G;
			}
			[Token(Token = "0x6000331")]
			[Address(RVA = "0x1535B28", Offset = "0x1535B28", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.g = value;\n\treturn;\n")]
			set
			{
				G = value;
			}
		}

		[Token(Token = "0x17000108")]
		public float B
		{
			[Token(Token = "0x6000332")]
			[Address(RVA = "0x1535B30", Offset = "0x1535B30", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.b;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return B;
			}
			[Token(Token = "0x6000333")]
			[Address(RVA = "0x1535B38", Offset = "0x1535B38", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.b = value;\n\treturn;\n")]
			set
			{
				B = value;
			}
		}

		[Token(Token = "0x17000109")]
		public float A
		{
			[Token(Token = "0x6000334")]
			[Address(RVA = "0x1535B40", Offset = "0x1535B40", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.a;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return A;
			}
			[Token(Token = "0x6000335")]
			[Address(RVA = "0x1535B48", Offset = "0x1535B48", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.a = value;\n\treturn;\n")]
			set
			{
				A = value;
			}
		}

		[Token(Token = "0x1700010A")]
		public float Time
		{
			[Token(Token = "0x6000336")]
			[Address(RVA = "0x1535B50", Offset = "0x1535B50", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.time;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Time;
			}
			[Token(Token = "0x6000337")]
			[Address(RVA = "0x1535B58", Offset = "0x1535B58", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.time = value;\n\treturn;\n")]
			set
			{
				Time = value;
			}
		}

		[Token(Token = "0x1700010B")]
		public float X
		{
			[Token(Token = "0x6000338")]
			[Address(RVA = "0x1535B60", Offset = "0x1535B60", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.x;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return X;
			}
			[Token(Token = "0x6000339")]
			[Address(RVA = "0x1535B68", Offset = "0x1535B68", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.x = value;\n\treturn;\n")]
			set
			{
				X = value;
			}
		}

		[Token(Token = "0x1700010C")]
		public float Y
		{
			[Token(Token = "0x600033A")]
			[Address(RVA = "0x1535B70", Offset = "0x1535B70", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.y;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Y;
			}
			[Token(Token = "0x600033B")]
			[Address(RVA = "0x1535B78", Offset = "0x1535B78", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.y = value;\n\treturn;\n")]
			set
			{
				Y = value;
			}
		}

		[Token(Token = "0x1700010D")]
		public float ScaleX
		{
			[Token(Token = "0x600033C")]
			[Address(RVA = "0x1535B80", Offset = "0x1535B80", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.scaleX;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ScaleX;
			}
			[Token(Token = "0x600033D")]
			[Address(RVA = "0x1535B88", Offset = "0x1535B88", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.scaleX = value;\n\treturn;\n")]
			set
			{
				ScaleX = value;
			}
		}

		[Token(Token = "0x1700010E")]
		public float ScaleY
		{
			[Token(Token = "0x600033E")]
			[Address(RVA = "0x1530E6C", Offset = "0x1530E6C", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.Bone;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37B73]) = v37;\nL_0014:\n\treturnVal1 = this.scaleY;\n\tv43 = -this.scaleY;\n\tif (v42.yDown) goto L_FFFFFFFF;\n\tgoto L_002C;\nL_002C:\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				float result = scaleY;
				float num = 0f - scaleY;
				if (Bone.yDown)
				{
					result = num;
				}
				return result;
			}
			[Token(Token = "0x600033F")]
			[Address(RVA = "0x1535B90", Offset = "0x1535B90", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.scaleY = value;\n\treturn;\n")]
			set
			{
				ScaleY = value;
			}
		}

		[Obsolete("Use ScaleX instead. FlipX is when ScaleX is negative.")]
		[Token(Token = "0x1700010F")]
		public bool FlipX
		{
			[Token(Token = "0x6000340")]
			[Address(RVA = "0x1535B98", Offset = "0x1535B98", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = this.scaleX < 0;\n\treturn v5;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ScaleX < 0f;
			}
			[Token(Token = "0x6000341")]
			[Address(RVA = "0x1535BA8", Offset = "0x1535BA8", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = value == 0;\n\tv12 = ~v7;\n\tv13 = ~v12;\n\tif (v13) goto L_FFFFFFFF;\n\tgoto L_0012;\nL_0012:\n\tthis.scaleX = v31;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				float num = ((!value) ? 1f : (-1f));
				ScaleX = num;
			}
		}

		[Obsolete("Use ScaleY instead. FlipY is when ScaleY is negative.")]
		[Token(Token = "0x17000110")]
		public bool FlipY
		{
			[Token(Token = "0x6000342")]
			[Address(RVA = "0x1535BD0", Offset = "0x1535BD0", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = this.scaleY < 0;\n\treturn v5;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return scaleY < 0f;
			}
			[Token(Token = "0x6000343")]
			[Address(RVA = "0x1535BE0", Offset = "0x1535BE0", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = value == 0;\n\tv12 = ~v7;\n\tv13 = ~v12;\n\tif (v13) goto L_FFFFFFFF;\n\tgoto L_0012;\nL_0012:\n\tthis.scaleY = v31;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				float num = ((!value) ? 1f : (-1f));
				ScaleY = num;
			}
		}

		[Token(Token = "0x17000111")]
		public Bone RootBone
		{
			[Token(Token = "0x6000344")]
			[Address(RVA = "0x1535C08", Offset = "0x1535C08", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.bones;\n\tv6 = v2.Count == 0;\n\tif (v6) goto L_FFFFFFFF;\n\tv12 = v2.Items;\n\treturnVal1 = v12[0];\n\tgoto L_0013;\nL_0013:\n\treturn returnVal1;\n\tv13 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ExposedList<Bone> exposedList = Bones;
				if (exposedList.Count != 0)
				{
					Bone[] items = exposedList.Items;
					return items[0];
				}
				return null;
			}
		}

		[Token(Token = "0x6000345")]
		[Address(RVA = "0x1535C48", Offset = "0x1535C48", Length = "0xB6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_00AD;\n\tv42 = Spine.Bone;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv80 = Il2CppMethodInfo;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv85 = Il2CppMethodInfo;\n\tv86 = \"il2cpp_codegen_initialize_runtime_metadata\"(v85, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv90 = Il2CppMethodInfo;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv95 = Il2CppMethodInfo;\n\tv96 = \"il2cpp_codegen_initialize_runtime_metadata\"(v95, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv102 = Il2CppMethodInfo;\n\tv103 = \"il2cpp_codegen_initialize_runtime_metadata\"(v102, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv106 = Il2CppMethodInfo;\n\tv107 = \"il2cpp_codegen_initialize_runtime_metadata\"(v106, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv208 = Il2CppMethodInfo;\n\tv209 = \"il2cpp_codegen_initialize_runtime_metadata\"(v208, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv458 = Il2CppMethodInfo;\n\tv459 = \"il2cpp_codegen_initialize_runtime_metadata\"(v458, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv465 = Il2CppMethodInfo;\n\tv466 = \"il2cpp_codegen_initialize_runtime_metadata\"(v465, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv472 = Il2CppMethodInfo;\n\tv473 = \"il2cpp_codegen_initialize_runtime_metadata\"(v472, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv499 = Il2CppMethodInfo;\n\tv500 = \"il2cpp_codegen_initialize_runtime_metadata\"(v499, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv510 = Il2CppMethodInfo;\n\tv511 = \"il2cpp_codegen_initialize_runtime_metadata\"(v510, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv559 = Il2CppMethodInfo;\n\tv560 = \"il2cpp_codegen_initialize_runtime_metadata\"(v559, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv564 = Il2CppMethodInfo;\n\tv565 = \"il2cpp_codegen_initialize_runtime_metadata\"(v564, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv587 = Il2CppMethodInfo;\n\tv588 = \"il2cpp_codegen_initialize_runtime_metadata\"(v587, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv681 = Il2CppMethodInfo;\n\tv682 = \"il2cpp_codegen_initialize_runtime_metadata\"(v681, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv743 = Il2CppMethodInfo;\n\tv744 = \"il2cpp_codegen_initialize_runtime_metadata\"(v743, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv901 = Il2CppMethodInfo;\n\tv902 = \"il2cpp_codegen_initialize_runtime_metadata\"(v901, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1161 = Il2CppMethodInfo;\n\tv1162 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1161, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1240 = Il2CppMethodInfo;\n\tv1241 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1240, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1338 = Il2CppMethodInfo;\n\tv1339 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1338, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1392 = Il2CppMethodInfo;\n\tv1393 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1392, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1524 = Il2CppMethodInfo;\n\tv1525 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1524, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1577 = Il2CppMethodInfo;\n\tv1578 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1577, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1592 = Il2CppMethodInfo;\n\tv1593 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1592, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1617 = Il2CppMethodInfo;\n\tv1618 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1617, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1624 = Il2CppMethodInfo;\n\tv1625 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1624, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1630 = Il2CppMethodInfo;\n\tv1631 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1630, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1645 = Il2CppMethodInfo;\n\tv1646 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1645, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1678 = Il2CppMethodInfo;\n\tv1679 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1678, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1699 = Il2CppMethodInfo;\n\tv1700 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1699, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1707 = Il2CppMethodInfo;\n\tv1708 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1707, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1719 = Spine.ExposedList`1<Spine.Slot>;\n\tv1720 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1719, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1727 = Spine.ExposedList`1<Spine.TransformConstraint>;\n\tv1728 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1727, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1749 = Spine.ExposedList`1<Spine.IUpdatable>;\n\tv1750 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1749, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1762 = Spine.ExposedList`1<Spine.Bone>;\n\tv1763 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1762, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1818 = Spine.ExposedList`1<Spine.IkConstraint>;\n\tv1819 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1818, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1831 = Spine.ExposedList`1<Spine.PathConstraint>;\n\tv1832 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1831, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1843 = Spine.IkConstraint;\n\tv1844 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1843, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1849 = Spine.PathConstraint;\n\tv1850 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1849, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1870 = Spine.Slot;\n\tv1871 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1870, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1875 = Spine.TransformConstraint;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1875, data, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv61 = 1;\n\t*([1A37B74]) = v61;\nL_00AD:\n\tv75 = 0;\n\tv78 = new Spine.ExposedList`1<Spine.IUpdatable>();\n\tSpine.ExposedList`1<Spine.IUpdatable>::.ctor(v78);\n\tthis.updateCache = v78;\n\tv88 = new Spine.ExposedList`1<Spine.Bone>();\n\tSpine.ExposedList`1<Spine.Bone>::.ctor(v88);\n\tthis.updateCacheReset = v88;\n\tthis.r = 0f;\n\tthis.scaleX = 0f;\n\tSystem.Object::.ctor(this);\n\tv104 = data == 0;\n\tif (v104) goto L_0265;\n\tthis.data = data;\n\tv108 = data.bones;\n\tv214 = new Spine.ExposedList`1<Spine.Bone>();\n\tSpine.ExposedList`1<Spine.Bone>::.ctor(v214, v108.Count);\n\tthis.bones = v214;\n\tv493 = Spine.ExposedList`1<Spine.BoneData>::GetEnumerator(data.bones);\nL_0\n// ... truncated")]
		public Skeleton(SkeletonData data)
		{
			//IL_0077: Expected O, but got I4
			//IL_01cb: Expected I, but got O
			//IL_01dc: Expected I, but got O
			//IL_02fc: Expected I, but got O
			//IL_030b: Expected I, but got O
			//IL_031e: Expected O, but got I4
			//IL_03b4: Expected O, but got I4
			//IL_043d: Expected O, but got I4
			base._002Ector();
			ExposedList<object>.Enumerator enumerator = default(ExposedList<object>.Enumerator);
			ExposedList<IUpdatable> exposedList = new ExposedList<IUpdatable>();
			updateCache = exposedList;
			ExposedList<Bone> exposedList2 = new ExposedList<Bone>();
			updateCacheReset = exposedList2;
			R = 0f;
			ScaleX = 0f;
			if (data != null)
			{
				this.data = data;
				ExposedList<BoneData> exposedList3 = data.Bones;
				ExposedList<Bone> exposedList4 = new ExposedList<Bone>((IEnumerable<Bone>)exposedList3.Count);
				bones = exposedList4;
				ExposedList<BoneData>.Enumerator enumerator2 = data.Bones.GetEnumerator();
				ExposedList<object>.Enumerator enumerator3 = default(ExposedList<object>.Enumerator);
				BoneData boneData = default(BoneData);
				Bone bone2;
				while (true)
				{
					if (enumerator3.MoveNext())
					{
						BoneData parent = boneData.Parent;
						Bone item;
						if (boneData.Parent != null)
						{
							ExposedList<Bone> exposedList5 = Bones;
							Bone[] items = exposedList5.Items;
							int index = parent.Index;
							Bone bone = items[index];
							bone2 = new Bone(boneData, this, items[index]);
							if (items[index] == null)
							{
								break;
							}
							bone.Children.Add(bone2);
							item = bone2;
						}
						else
						{
							Bone bone3 = new Bone(boneData, this, null);
							item = bone3;
						}
						Bones.Add(item);
						continue;
					}
					enumerator3.Dispose();
					nint num = (nint)typeof(ExposedList<Slot>);
					nint num2 = (nint)typeof(Slot);
					ExposedList<SlotData> exposedList6 = data.Slots;
					ExposedList<Slot> exposedList7 = new ExposedList<Slot>(exposedList6.Count);
					slots = exposedList7;
					ExposedList<SlotData> exposedList8 = data.Slots;
					ExposedList<Slot> exposedList9 = new ExposedList<Slot>(exposedList8.Count);
					drawOrder = exposedList9;
					ExposedList<SlotData>.Enumerator enumerator4 = data.Slots.GetEnumerator();
					while (enumerator3.MoveNext())
					{
						ExposedList<Bone> exposedList10 = Bones;
						BoneData boneData2 = ((SlotData)(object)boneData).BoneData;
						Bone[] items2 = exposedList10.Items;
						int index2 = boneData2.Index;
						Slot item2 = new Slot((SlotData)(object)boneData, items2[index2]);
						Slots.Add(item2);
						DrawOrder.Add(item2);
					}
					enumerator3.Dispose();
					nint num3 = (nint)typeof(IkConstraint);
					nint num4 = (nint)typeof(TransformConstraint);
					ExposedList<IkConstraintData> exposedList11 = data.IkConstraints;
					ExposedList<IkConstraint> exposedList12 = new ExposedList<IkConstraint>((IEnumerable<IkConstraint>)exposedList11.Count);
					ikConstraints = exposedList12;
					ExposedList<IkConstraintData>.Enumerator enumerator5 = data.IkConstraints.GetEnumerator();
					IkConstraint ikConstraint;
					while (true)
					{
						if (enumerator3.MoveNext())
						{
							ikConstraint = new IkConstraint((IkConstraintData)(object)boneData, this);
							if (IkConstraints == null)
							{
								break;
							}
							IkConstraints.Add(ikConstraint);
							continue;
						}
						enumerator3.Dispose();
						ExposedList<TransformConstraintData> exposedList13 = data.TransformConstraints;
						ExposedList<TransformConstraint> exposedList14 = new ExposedList<TransformConstraint>((IEnumerable<TransformConstraint>)exposedList13.Count);
						transformConstraints = exposedList14;
						ExposedList<TransformConstraintData>.Enumerator enumerator6 = data.TransformConstraints.GetEnumerator();
						while (enumerator3.MoveNext())
						{
							TransformConstraint item3 = new TransformConstraint((TransformConstraintData)(object)boneData, this);
							TransformConstraints.Add(item3);
						}
						enumerator3.Dispose();
						ExposedList<PathConstraintData> exposedList15 = data.PathConstraints;
						ExposedList<PathConstraint> stackTraceString = new ExposedList<PathConstraint>((IEnumerable<PathConstraint>)exposedList15.Count);
						((Exception)this)._stackTraceString = (string)(object)stackTraceString;
						ExposedList<PathConstraintData>.Enumerator enumerator7 = data.PathConstraints.GetEnumerator();
						PathConstraint pathConstraint;
						while (true)
						{
							if (enumerator.MoveNext())
							{
								pathConstraint = new PathConstraint((PathConstraintData)null, this);
								if (((Exception)this)._stackTraceString == null)
								{
									break;
								}
								((ExposedList<object>)(object)((Exception)this)._stackTraceString).Add((object)pathConstraint);
								continue;
							}
							enumerator.Dispose();
							UpdateCache();
							UpdateWorldTransform();
							return;
						}
						throw pathConstraint;
					}
					throw ikConstraint;
				}
				throw bone2;
			}
			ArgumentNullException ex = new ArgumentNullException("data", "data cannot be null.");
			throw ex;
		}

		[Token(Token = "0x6000346")]
		[Address(RVA = "0x15367B4", Offset = "0x15367B4", Length = "0x338")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv32 = Spine.BoneData;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv56 = Il2CppMethodInfo;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv351 = Il2CppMethodInfo;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v351, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A37B75]) = v52;\nL_0026:\n\tSpine.ExposedList`1<Spine.IUpdatable>::Clear(this.updateCache, 1);\n\tSpine.ExposedList`1<Spine.Bone>::Clear(this.updateCacheReset, 1);\n\tv348 = this.bones;\n\tv342 = v348.Items;\n\tv539 = v342.Length < 1;\n\tif (v539) goto L_005B;\nL_0045:\n\tv119 = v342[v149 @ X9_v20 (System.Int32)];\n\tv133 = v119.data;\n\tv149 = v149 + 1;\n\tv119.sorted = v133.skinRequired;\n\tv542 = v133.skinRequired ^ 1;\n\tv119.active = v542;\n\tv545 = v342.Length != v149;\n\tif (v545) goto L_0045;\nL_005B:\n\tv150 = this.skin;\n\tv555 = this.skin == 0;\n\tif (v555) goto L_00C4;\n\tv120 = v150.bones;\n\tv164 = v120.Count < 1;\n\tif (v164) goto L_00C4;\n\tv121 = v120.Items;\nL_0083:\n\tv313 = v121[v135 @ X11_v24 (System.Int32)];\n\tgoto L_FFFFFFFF;\n\tv166 = v166_asT == 0;\n\tif (v166) goto L_01DF;\n\tv364 = v313.index;\nL_00B3:\n\tv93.sorted = 0x100;\n\tv93 = v93.parent;\n\tv814 = v93.parent == 0;\n\tv572 = ~v814;\n\tif (v572) goto L_00B3;\n\tv135 = v135 + 1;\n\tv562 = v135 != v120.Count;\n\tif (v562) goto L_0083;\nL_00C4:\n\tv78 = this.ikConstraints;\n\tv76 = this.transformConstraints;\n\tv74 = this.pathConstraints;\n\tv580 = v76.Count + v78.Count;\n\tv66 = v580 + v74.Count;\n\tv591 = v66 < 1;\n\tif (v591) goto L_01AC;\nL_00E9:\n\tv168 = v78.Count < 1;\n\tif (v168) goto L_0123;\n\tv343 = v78.Items;\nL_00FC:\n\tv305 = v343[v124 @ X10_v18 (System.Int32)];\n\tv139 = v305.data;\n\tv770 = v139.order == v63;\n\tif (v770) goto L_018F;\n\tv124 = v124 + 1;\n\tv680 = v78.Count != v124;\n\tif (v680) goto L_00FC;\nL_0123:\n\tv170 = v76.Count < 1;\n\tif (v170) goto L_015D;\n\tv344 = v76.Items;\nL_0136:\n\tv307 = v344[v126 @ X10_v15 (System.Int32)];\n\tv142 = v307.data;\n\tv771 = v142.order == v63;\n\tif (v771) goto L_0192;\n\tv126 = v126 + 1;\n\tv710 = v76.Count != v126;\n\tif (v710) goto L_0136;\nL_015D:\n\tv172 = v74.Count < 1;\n\tif (v172) goto L_0196;\n\tv345 = v74.Items;\nL_0170:\n\tv309 = v345[v128 @ X10_v12 (System.Int32)];\n\tv145 = v309.data;\n\tv768 = v145.order == v63;\n\tif (v768) goto L_0195;\n\tv128 = v128 + 1;\n\tv746 = v74.Count != v128;\n\tif (v746) goto L_0170;\n\tgoto L_0196;\nL_018F:\n\tSpine.Skeleton::SortIkConstraint(this, v343[v124 @ X10_v18 (System.Int32)]);\n\tgoto L_0196;\nL_0192:\n\tSpine.Skeleton::SortTransformConstraint(this, v344[v126 @ X10_v15 (System.Int32)]);\n\tgoto L_0196;\nL_0195:\n\tSpine.Skeleton::SortPathConstraint(this, v345[v128 @ X10_v12 (System.Int32)]);\nL_0196:\n\tv63 = v63 + 1;\n\tv610 = v63 != v66;\n\tif (v610) goto L_00E9;\nL_01AC:\n\tv645 = v342.Length < 1;\n\tif (v645) goto L_01DC;\n\tv297 = v342.Length & 0xFFFFFFFF;\nL_01B0:\n\tv346 = v348.Items;\n\tSpine.Skeleton::SortBone(this, v346[v79 @ X22_v8 (System.Int32)]);\n\tv79 = v79 + 1;\n\tv663 = v297 != v79;\n\tif (v663) goto L_01B0;\nL_01DC:\n\treturn;\n\tv349 = new System.NullReferenceException();\n\tv412 = new System.IndexOutOfRangeException();\nL_01DF:\n\tthrow System.InvalidCastException;\n// 380 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateCache()
		{
			//IL_05a9: Expected I4, but got I8
			UpdateCacheList.Clear();
			updateCacheReset.Clear();
			ExposedList<Bone> exposedList = Bones;
			Bone[] items = exposedList.Items;
			if (items.Length >= 1)
			{
				int num = 0;
				do
				{
					Bone bone = items[num];
					BoneData boneData = bone.Data;
					num++;
					bone.sorted = boneData.SkinRequired;
					int active = (boneData.SkinRequired ? 1 : 0) ^ 1;
					bone.active = (byte)active != 0;
				}
				while (items.Length != num);
			}
			Skin skin = Skin;
			if (Skin != null)
			{
				ExposedList<BoneData> exposedList2 = skin.Bones;
				if (exposedList2.Count >= 1)
				{
					BoneData[] items2 = exposedList2.Items;
					int num2 = 0;
					do
					{
						BoneData boneData2 = items2[num2];
						BoneData boneData3 = items2[num2] as BoneData;
						if (boneData3 != null)
						{
							int index = boneData2.Index;
							Bone bone2 = items[index];
							do
							{
								bone2.sorted = false;
								bone2.active = true;
								bone2 = bone2.Parent;
							}
							while (bone2.Parent != null);
							num2++;
							continue;
						}
						throw new InvalidCastException();
					}
					while (num2 != exposedList2.Count);
				}
			}
			ExposedList<IkConstraint> exposedList3 = IkConstraints;
			ExposedList<TransformConstraint> exposedList4 = TransformConstraints;
			ExposedList<PathConstraint> exposedList5 = PathConstraints;
			int num3 = exposedList4.Count + exposedList3.Count;
			int num4 = num3 + exposedList5.Count;
			if (num4 >= 1)
			{
				int num5 = 0;
				do
				{
					if (exposedList3.Count < 1)
					{
						goto IL_0382;
					}
					IkConstraint[] items3 = exposedList3.Items;
					int num6 = 0;
					while (true)
					{
						IkConstraint ikConstraint = items3[num6];
						IkConstraintData ikConstraintData = ikConstraint.Data;
						if (ikConstraintData.Order == num5)
						{
							break;
						}
						num6++;
						if (exposedList3.Count != num6)
						{
							continue;
						}
						goto IL_0382;
					}
					SortIkConstraint(items3[num6]);
					goto IL_0549;
					IL_0382:
					if (exposedList4.Count < 1)
					{
						goto IL_043f;
					}
					TransformConstraint[] items4 = exposedList4.Items;
					int num7 = 0;
					while (true)
					{
						TransformConstraint transformConstraint = items4[num7];
						TransformConstraintData transformConstraintData = transformConstraint.Data;
						if (transformConstraintData.Order == num5)
						{
							break;
						}
						num7++;
						if (exposedList4.Count != num7)
						{
							continue;
						}
						goto IL_043f;
					}
					SortTransformConstraint(items4[num7]);
					goto IL_0549;
					IL_0549:
					num5++;
					continue;
					IL_043f:
					if (exposedList5.Count >= 1)
					{
						PathConstraint[] items5 = exposedList5.Items;
						int num8 = 0;
						do
						{
							PathConstraint pathConstraint = items5[num8];
							PathConstraintData pathConstraintData = pathConstraint.Data;
							if (pathConstraintData.Order != num5)
							{
								num8++;
								continue;
							}
							SortPathConstraint(items5[num8]);
							break;
						}
						while (exposedList5.Count != num8);
					}
					goto IL_0549;
				}
				while (num5 != num4);
			}
			if (items.Length >= 1)
			{
				int num9 = (int)(items.Length & 0xFFFFFFFFL);
				int num10 = 0;
				do
				{
					Bone[] items6 = exposedList.Items;
					SortBone(items6[num10]);
					num10++;
				}
				while (num9 != num10);
			}
		}

		[Token(Token = "0x6000347")]
		[Address(RVA = "0x1536C3C", Offset = "0x1536C3C", Length = "0x1EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, constraint, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv44 = Il2CppMethodInfo;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, constraint, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv191 = Il2CppMethodInfo;\n\tv192 = \"il2cpp_codegen_initialize_runtime_metadata\"(v191, constraint, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv219 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v219, constraint, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A37B76]) = v41;\nL_001F:\n\tv46 = constraint.target;\n\tif (v46.active) goto L_FFFFFFFF;\n\tgoto L_0032;\nL_0032:\n\tv222 = ~v46.active;\n\tif (v222) goto L_FFFFFFFF;\n\tv80 = constraint.data;\n\tv272 = ~v80.skinRequired;\n\tif (v272) goto L_004D;\n\tv173 = this.skin;\n\tv279 = this.skin == 0;\n\tif (v279) goto L_FFFFFFFF;\n\tv274 = Spine.ExposedList`1<Spine.ConstraintData>::Contains(v173.constraints, v80);\n\tv286 = v187 == 0;\n\tv159 = ~v286;\n\tif (v159) goto L_0055;\n\tgoto L_00C7;\n\tgoto L_0055;\nL_004D:\n\tv280 = constraint == 0;\n\tv160 = ~v280;\n\tif (v160) goto L_0055;\n\tgoto L_00C7;\nL_0055:\n\tv187.active = v274;\n\tv278 = ~constraint.active;\n\tif (v278) goto L_00C6;\n\tSpine.Skeleton::SortBone(this, constraint.target);\n\tv72 = constraint.bones;\n\tv177 = v72.Items;\n\tv188 = v177[0];\n\tSpine.Skeleton::SortBone(this, v177[0]);\n\tv63 = v72.Count < 2;\n\tif (v63) goto L_00A3;\n\tv178 = v72.Items;\n\tv67 = v72.Count - 1;\n\tv292 = Spine.ExposedList`1<Spine.IUpdatable>::Contains(this.updateCache, v178[v67 @ X9_v10 (System.Int32)]);\n\tv300 = v292 == 0;\n\tv294 = ~v300;\n\tif (v294) goto L_00A3;\n\tSpine.ExposedList`1<Spine.Bone>::Add(this.updateCacheReset, v178[v67 @ X9_v10 (System.Int32)]);\nL_00A3:\n\tSpine.ExposedList`1<Spine.IUpdatable>::Add(this.updateCache, constraint);\n\tSpine.Skeleton::SortReset(v188.children);\n\tv182 = v72.Items;\n\tv70 = v72.Count - 1;\n\tv183 = v182[v70 @ X9_v8 (System.Int32)];\n\tv183.sorted = 1;\nL_00C6:\n\treturn;\nL_00C7:\n\tv189 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n// 144 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SortIkConstraint(IkConstraint constraint)
		{
			Bone target = constraint.Target;
			IkConstraint ikConstraint = (target.Active ? constraint : null);
			bool active;
			if (target.Active)
			{
				IkConstraintData ikConstraintData = constraint.Data;
				if (ikConstraintData.SkinRequired)
				{
					Skin skin = Skin;
					if (Skin != null)
					{
						active = skin.Constraints.Contains(ikConstraintData);
						if (ikConstraint == null)
						{
							goto IL_02e5;
						}
					}
					else
					{
						active = false;
					}
				}
				else
				{
					bool flag = constraint == null;
					bool flag2 = !flag;
					active = true;
					ikConstraint = constraint;
					if (!flag2)
					{
						goto IL_02e5;
					}
				}
			}
			else
			{
				active = false;
				ikConstraint = constraint;
			}
			ikConstraint.active = active;
			if (!constraint.Active)
			{
				return;
			}
			SortBone(constraint.Target);
			ExposedList<Bone> exposedList = constraint.Bones;
			Bone[] items = exposedList.Items;
			Bone bone = items[0];
			SortBone(items[0]);
			if (exposedList.Count >= 2)
			{
				Bone[] items2 = exposedList.Items;
				int num = exposedList.Count - 1;
				if (!UpdateCacheList.Contains(items2[num]))
				{
					updateCacheReset.Add(items2[num]);
				}
			}
			UpdateCacheList.Add(constraint);
			SortReset(bone.Children);
			Bone[] items3 = exposedList.Items;
			int num2 = exposedList.Count - 1;
			Bone bone2 = items3[num2];
			bone2.sorted = true;
			return;
			IL_02e5:
			NullReferenceException ex = new NullReferenceException();
			throw new IndexOutOfRangeException();
		}

		[Token(Token = "0x6000348")]
		[Address(RVA = "0x15370B0", Offset = "0x15370B0", Length = "0x268")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, constraint, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv44 = Il2CppMethodInfo;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, constraint, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv240 = Spine.PathAttachment;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v240, constraint, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A37B77]) = v41;\nL_001C:\n\tv46 = constraint.target;\n\tv219 = v46.bone;\n\tv340 = v219.active;\n\tif (v219.active) goto L_FFFFFFFF;\n\tgoto L_0032;\nL_0032:\n\tv335 = ~v340;\n\tif (v335) goto L_FFFFFFFF;\n\tv100 = constraint.data;\n\tv338 = ~v100.skinRequired;\n\tif (v338) goto L_FFFFFFFF;\n\tv221 = this.skin;\n\tv342 = this.skin == 0;\n\tif (v342) goto L_004C;\n\tv370 = Spine.ExposedList`1<Spine.ConstraintData>::Contains(v221.constraints, v100);\n\tgoto L_004C;\n\tgoto L_004C;\nL_004C:\n\tv234.active = v340;\n\tv341 = ~constraint.active;\n\tif (v341) goto L_0135;\n\tv90 = constraint.target;\n\tv223 = v90.data;\n\tv375 = this.skin == 0;\n\tif (v375) goto L_005F;\n\tSpine.Skeleton::SortPathConstraintAttachment(this, this.skin, v223.index, v90.bone);\nL_005F:\n\tv224 = this.data;\n\tv380 = v224.defaultSkin == 0;\n\tif (v380) goto L_0075;\n\tv386 = v224.defaultSkin == this.skin;\n\tif (v386) goto L_0075;\n\tSpine.Skeleton::SortPathConstraintAttachment(this, v224.defaultSkin, v223.index, v90.bone);\nL_0075:\n\tv405 = v90.attachment == 0;\n\tif (v405) goto L_009A;\n\tgoto L_FFFFFFFF;\n\tv423 = v423_asT == 0;\n\tif (v423) goto L_009A;\n\tSpine.Skeleton::SortPathConstraintAttachment(this, v90.attachment, v90.bone);\nL_009A:\n\tv88 = constraint.bones;\n\tv448 = v88.Count < 1;\n\tif (v448) goto L_00D1;\nL_00AB:\n\tv226 = v88.Items;\n\tSpine.Skeleton::SortBone(this, v226[v91 @ X23_v8 (System.Int32)]);\n\tv91 = v91 + 1;\n\tv451 = v88.Count != v91;\n\tif (v451) goto L_00AB;\nL_00D1:\n\tSpine.ExposedList`1<Spine.IUpdatable>::Add(this.updateCache, constraint);\n\tv346 = v88.Count < 1;\n\tif (v346) goto L_0135;\nL_00DF:\n\tv228 = v88.Items;\n\tv229 = v228[v216 @ X19_v7 (System.Int32)];\n\tSpine.Skeleton::SortReset(v229.children);\n\tv216 = v216 + 1;\n\tv474 = v88.Count != v216;\n\tif (v474) goto L_00DF;\n\tv65 = v88.Count < 1;\n\tif (v65) goto L_0135;\n\tv230 = v88.Items;\nL_011E:\n\tv50 = v230[v82 @ X9_v9 (System.Int32)];\n\tv82 = v82 + 1;\n\tv50.sorted = 1;\n\tv345 = v88.Count != v82;\n\tif (v345) goto L_011E;\nL_0135:\n\treturn;\n\tv238 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 239 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SortPathConstraint(PathConstraint constraint)
		{
			//IL_00b5: Expected I4, but got O
			Slot target = constraint.Target;
			Bone bone = target.Bone;
			bool flag = bone.Active;
			PathConstraint pathConstraint = (bone.Active ? constraint : null);
			if (flag)
			{
				PathConstraintData pathConstraintData = constraint.Data;
				if (pathConstraintData.SkinRequired)
				{
					Skin skin = Skin;
					bool flag2 = Skin == null;
					flag = (byte)(int)Skin != 0;
					if (!flag2)
					{
						bool flag3 = skin.Constraints.Contains(pathConstraintData);
						flag = flag3;
					}
				}
				else
				{
					flag = true;
					pathConstraint = constraint;
				}
			}
			else
			{
				pathConstraint = constraint;
			}
			pathConstraint.active = flag;
			if (!constraint.Active)
			{
				return;
			}
			Slot target2 = constraint.Target;
			SlotData slotData = target2.Data;
			if (Skin != null)
			{
				SortPathConstraintAttachment(Skin, slotData.Index, target2.Bone);
			}
			SkeletonData skeletonData = Data;
			if (skeletonData.DefaultSkin != null && skeletonData.DefaultSkin != Skin)
			{
				SortPathConstraintAttachment(skeletonData.DefaultSkin, slotData.Index, target2.Bone);
			}
			if (target2.Attachment != null)
			{
				PathAttachment pathAttachment = target2.Attachment as PathAttachment;
				if (pathAttachment != null)
				{
					SortPathConstraintAttachment(target2.Attachment, target2.Bone);
				}
			}
			ExposedList<Bone> exposedList = constraint.Bones;
			if (exposedList.Count >= 1)
			{
				int num = 0;
				do
				{
					Bone[] items = exposedList.Items;
					SortBone(items[num]);
					num++;
				}
				while (exposedList.Count != num);
			}
			UpdateCacheList.Add(constraint);
			if (exposedList.Count < 1)
			{
				return;
			}
			int num2 = 0;
			do
			{
				Bone[] items2 = exposedList.Items;
				Bone bone2 = items2[num2];
				SortReset(bone2.Children);
				num2++;
			}
			while (exposedList.Count != num2);
			if (exposedList.Count >= 1)
			{
				Bone[] items3 = exposedList.Items;
				int num3 = 0;
				do
				{
					Bone bone3 = items3[num3];
					num3++;
					bone3.sorted = true;
				}
				while (exposedList.Count != num3);
			}
		}

		[Token(Token = "0x6000349")]
		[Address(RVA = "0x1536E28", Offset = "0x1536E28", Length = "0x288")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv28 = Il2CppMethodInfo;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, constraint, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv50 = Il2CppMethodInfo;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, constraint, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv267 = Il2CppMethodInfo;\n\tv268 = \"il2cpp_codegen_initialize_runtime_metadata\"(v267, constraint, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv311 = Il2CppMethodInfo;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v311, constraint, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A37B78]) = v47;\nL_0022:\n\tv52 = constraint.target;\n\tif (v52.active) goto L_FFFFFFFF;\n\tgoto L_0035;\nL_0035:\n\tv314 = ~v52.active;\n\tif (v314) goto L_FFFFFFFF;\n\tv110 = constraint.data;\n\tv374 = ~v110.skinRequired;\n\tif (v374) goto L_0050;\n\tv245 = this.skin;\n\tv381 = this.skin == 0;\n\tif (v381) goto L_FFFFFFFF;\n\tv376 = Spine.ExposedList`1<Spine.ConstraintData>::Contains(v245.constraints, v110);\n\tv411 = v260 == 0;\n\tv225 = ~v411;\n\tif (v225) goto L_0058;\n\tgoto L_013F;\n\tgoto L_0058;\nL_0050:\n\tv382 = constraint == 0;\n\tv226 = ~v382;\n\tif (v226) goto L_0058;\n\tgoto L_013F;\nL_0058:\n\tv260.active = v376;\n\tv380 = ~constraint.active;\n\tif (v380) goto L_013E;\n\tSpine.Skeleton::SortBone(this, constraint.target);\n\tv101 = constraint.bones;\n\tv249 = constraint.data;\n\tv422 = ~v249.local;\n\tif (v422) goto L_00AE;\n\tv424 = v101.Count < 1;\n\tif (v424) goto L_00D7;\nL_007A:\n\tv250 = v101.Items;\n\tv262 = v250[v82 @ X24_v7 (System.Int32)];\n\tSpine.Skeleton::SortBone(this, *([v262 @ X21_v13 (Spine.IUpdatable)+20]));\n\tv485 = Spine.ExposedList`1<Spine.IUpdatable>::Contains(this.updateCache, v250[v82 @ X24_v7 (System.Int32)]);\n\tv488 = v485 == 0;\n\tv489 = ~v488;\n\tif (v489) goto L_00A0;\n\tSpine.ExposedList`1<Spine.Bone>::Add(this.updateCacheReset, v250[v82 @ X24_v7 (System.Int32)]);\nL_00A0:\n\tv82 = v82 + 1;\n\tv433 = v101.Count != v82;\n\tif (v433) goto L_007A;\n\tgoto L_00D7;\nL_00AE:\n\tv426 = v101.Count < 1;\n\tif (v426) goto L_00D7;\nL_00B1:\n\tv252 = v101.Items;\n\tSpine.Skeleton::SortBone(this, v252[v263 @ X21_v10 (System.Int32)]);\n\tv263 = v263 + 1;\n\tv432 = v101.Count != v263;\n\tif (v432) goto L_00B1;\nL_00D7:\n\tSpine.ExposedList`1<Spine.IUpdatable>::Add(this.updateCache, constraint);\n\tv388 = v101.Count < 1;\n\tif (v388) goto L_013E;\nL_00E5:\n\tv254 = v101.Items;\n\tv255 = v254[v241 @ X19_v7 (System.Int32)];\n\tSpine.Skeleton::SortReset(v255.children);\n\tv241 = v241 + 1;\n\tv472 = v101.Count != v241;\n\tif (v472) goto L_00E5;\n\tv96 = v101.Count < 1;\n\tif (v96) goto L_013E;\n\tv256 = v101.Items;\nL_0124:\n\tv56 = v256[v80 @ X9_v8 (System.Int32)];\n\tv80 = v80 + 1;\n\tv56.sorted = 1;\n\tv387 = v101.Count != v80;\n\tif (v387) goto L_0124;\nL_013E:\n\treturn;\nL_013F:\n\tv265 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n// 241 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SortTransformConstraint(TransformConstraint constraint)
		{
			//IL_0214: Expected O, but got I
			Bone target = constraint.Target;
			TransformConstraint transformConstraint = (target.Active ? constraint : null);
			bool active;
			if (target.Active)
			{
				TransformConstraintData transformConstraintData = constraint.Data;
				if (transformConstraintData.SkinRequired)
				{
					Skin skin = Skin;
					if (Skin != null)
					{
						active = skin.Constraints.Contains(transformConstraintData);
						if (transformConstraint == null)
						{
							goto IL_0456;
						}
					}
					else
					{
						active = false;
					}
				}
				else
				{
					bool flag = constraint == null;
					bool flag2 = !flag;
					active = true;
					transformConstraint = constraint;
					if (!flag2)
					{
						goto IL_0456;
					}
				}
			}
			else
			{
				active = false;
				transformConstraint = constraint;
			}
			transformConstraint.active = active;
			if (!constraint.Active)
			{
				return;
			}
			SortBone(constraint.Target);
			ExposedList<Bone> exposedList = constraint.Bones;
			TransformConstraintData transformConstraintData2 = constraint.Data;
			if (transformConstraintData2.Local)
			{
				if (exposedList.Count >= 1)
				{
					int num = 0;
					do
					{
						Bone[] items = exposedList.Items;
						IUpdatable updatable = items[num];
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ X21_v13 (Spine.IUpdatable)+20]");
						SortBone((Bone)0);
						if (!UpdateCacheList.Contains(items[num]))
						{
							updateCacheReset.Add(items[num]);
						}
						num++;
					}
					while (exposedList.Count != num);
				}
			}
			else if (exposedList.Count >= 1)
			{
				int num2 = 0;
				do
				{
					Bone[] items2 = exposedList.Items;
					SortBone(items2[num2]);
					num2++;
				}
				while (exposedList.Count != num2);
			}
			UpdateCacheList.Add(constraint);
			if (exposedList.Count < 1)
			{
				return;
			}
			int num3 = 0;
			do
			{
				Bone[] items3 = exposedList.Items;
				Bone bone = items3[num3];
				SortReset(bone.Children);
				num3++;
			}
			while (exposedList.Count != num3);
			if (exposedList.Count >= 1)
			{
				Bone[] items4 = exposedList.Items;
				int num4 = 0;
				do
				{
					Bone bone2 = items4[num4];
					num4++;
					bone2.sorted = true;
				}
				while (exposedList.Count != num4);
			}
			return;
			IL_0456:
			NullReferenceException ex = new NullReferenceException();
			throw new IndexOutOfRangeException();
		}

		[Token(Token = "0x600034A")]
		[Address(RVA = "0x1537420", Offset = "0x1537420", Length = "0x2D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv30 = System.IDisposable;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, skin, slotIndex, slotBone, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv50 = System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, skin, slotIndex, slotBone, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv64 = System.Collections.IEnumerator;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, skin, slotIndex, slotBone, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv81 = Il2CppMethodInfo;\n\tv82 = \"il2cpp_codegen_initialize_runtime_metadata\"(v81, skin, slotIndex, slotBone, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv150 = Il2CppMethodInfo;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v150, skin, slotIndex, slotBone, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A37B79]) = v47;\nL_002C:\n\tv57 = Spine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>::get_Keys(skin.attachments);\n\tv70 = Spine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>+KeyCollection<Spine.Skin+SkinEntry, Spine.Attachment>::GetEnumerator(v57);\nL_0040:\n\tgoto L_0066;\n\tv219 = *([v212 @ X8_v22+B0]);\n\tv220 = v219 + 8;\n\tv222 = *([v300 @ X10_v28-8]);\n\tv305 = v222 == v213;\n\tif (v305) goto L_005F;\n\tv226 = v291 - 1;\n\tv244 = v300 + 0x10;\n\tv224 = v291 != 1;\n\tif (v224) goto L_FFFFFFFF;\n\tv245 = v74;\n\tv246 = 0;\n\tv247 = 0xB349B4(v245, v213, v246, slotBone, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0066;\nL_005F:\n\tv383 = *([v300 @ X10_v28]);\n\tv384 = v383 << 4;\n\tv385 = v212 + v384;\n\tv386 = v385 + 0x138;\nL_0066:\n\tv341 = System.Collections.IEnumerator::MoveNext(v70);\n\tv343 = v341 == 0;\n\tif (v343) goto L_FFFFFFFF;\n\tgoto L_0095;\n\tv484 = *([v436 @ X8_v25+B0]);\n\tv485 = v484 + 8;\n\tv487 = *([v572 @ X10_v23-8]);\n\tv577 = v487 == v437;\n\tif (v577) goto L_008D;\n\tv491 = v563 - 1;\n\tv509 = v572 + 0x10;\n\tv489 = v563 != 1;\n\tif (v489) goto L_FFFFFFFF;\n\tv510 = v74;\n\tv511 = 0;\n\tv512 = 0xB349B4(v510, v437, v511, slotBone, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0095;\nL_008D:\n\tv591 = *([v572 @ X10_v23]);\n\tv592 = v591 << 4;\n\tv593 = v436 + v592;\n\tv594 = v593 + 0x138;\nL_0095:\n\tv207 = System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>::get_Current(v70);\n\tv181 = v172 != v256;\n\tif (v181) goto L_0040;\n\tSpine.Skeleton::SortPathConstraintAttachment(this, v610, slotBone);\n\tgoto L_0040;\nL_00A8:\n\tv347 = v138 == 0;\n\tif (v347) goto L_00D5;\n\tv391 = *([v138 @ X19_v2 (System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>)]);\n\tv515 = *([v391 @ X8_v5 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+12E]);\n\tv394 = *([v391 @ X8_v5 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+12E]) == 0;\n\tif (v394) goto L_00CB;\n\tv524 = *([v391 @ X8_v5 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+B0]) + 8;\nL_00B6:\n\tv529 = *([v524 @ X10_v7-8]) == *([v146 @ X23_v2 (Il2CppClass<System.IDisposable>)]);\n\tif (v529) goto L_00CE;\n\tv446 = v515 - 1;\n\tv524 = v524 + 0x10;\n\tv444 = v515 != 1;\n\tif (v444) goto L_00B6;\nL_00CB:\n\t;\n\tgoto L_00D4;\nL_00CE:\n\t;\nL_00D4:\n\tv410 = System.IDisposable::Dispose(v138);\nL_00D5:\n\tv413 = v142 == 0;\n\tv136 = ~v413;\n\tif (v136) goto L_00E5;\n\treturn;\n\tv62 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_00E5:\n\tv148 = new System.OutOfMemoryException();\n\tgoto L_00F3;\n\tgoto L_00F3;\n\tgoto L_00F3;\nL_00F3:\n\tv163 = v280 != 1;\n\tif (v163) goto L_00FB;\n\tv169 = 0x1854E70(v148, v280, v256, slotBone, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv142 = *([v169 @ X0_v27]);\n\tv217 = 0x1854E80(v169, v280, v256, slotBone, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_00A8;\nL_00FB:\n\tgoto L_00FD;\n\tX21 = X0;\nL_00FD:\n\tv218 = v137 == 0;\n\tif (v218) goto L_012C;\n\tv248 = *([v137 @ X19_v4 (System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>)]);\n\tv416 = *([v248 @ X8_v11 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+12E]);\n\tv251 = *([v248 @ X8_v11 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+12E]) == 0;\n\tif (v251) goto L_0120;\n\tv425 = *([v248 @ X8_v11 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+B0]) + 8;\nL_010B:\n\tv430 = *([v425 @ X10_v15-8]) == *([v145 @ X23_v4 (Il2CppClass<System.IDisposable>)]);\n\tif (v430) goto L_0123;\n\tv355 = v416 - 1;\n\tv425 = v425 + 0x10;\n\tv353 = v416 != 1;\n\tif (v353) goto L_010B;\nL_0120:\n\t;\n\tgoto L_0129;\nL_0123:\n\tv478 = *([v425 @ X10_v15]) << 4;\n\tv479 = v248 + v478;\n\tv481 = v479 + 0x138;\nL_0129:\n\tv283 = System.IDisposable::Dispose(v137);\nL_012C:\n\tgoto L_0130;\n\tv378 = 0xBD3CD0(v148, *([v481 @ X0_v20+8]), 0, slotBone, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0130:\n\tv381 = new System.OutOfMemoryException();\n\tv435 = 0x9DACB4(v381, *([v481 @ X0_v20+8]), 0, slotBone, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn;\n// 189 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SortPathConstraintAttachment(Skin skin, int slotIndex, Bone slotBone)
		{
			//IL_0067: Expected I, but got O
			//IL_0074: Expected I, but got O
			//IL_0084: Expected O, but got I
			//IL_00bf: Expected O, but got I
			//IL_015f: Expected I4, but got O
			//IL_0196: Expected I, but got O
			//IL_01a6: Expected O, but got I
			//IL_00d3: Expected O, but got I
			//IL_00e2: Expected O, but got I
			//IL_01e1: Expected O, but got I
			//IL_0240: Expected I4, but got O
			//IL_024e: Expected O, but got I
			//IL_025d: Expected O, but got I
			//IL_01f5: Expected O, but got I
			//IL_0204: Expected O, but got I
			OrderedDictionary<Skin.SkinEntry, Attachment>.KeyCollection keys = skin.Attachments.Keys;
			IEnumerator<Skin.SkinEntry> enumerator = keys.GetEnumerator();
			int num = default(int);
			int num2 = default(int);
			Attachment attachment = default(Attachment);
			while (enumerator.MoveNext())
			{
				Skin.SkinEntry current = enumerator.Current;
				if (num == num2)
				{
					SortPathConstraintAttachment(attachment, slotBone);
				}
			}
			IEnumerator<Skin.SkinEntry> enumerator2 = enumerator;
			int num3 = 0;
			nint num4 = (nint)typeof(IDisposable);
			int num6 = default(int);
			object obj4 = default(object);
			IEnumerator<Skin.SkinEntry> enumerator3 = default(IEnumerator<Skin.SkinEntry>);
			IntPtr intPtr = default(IntPtr);
			while (true)
			{
				if (enumerator2 != null)
				{
					nint num5 = (nint)enumerator2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ X8_v5 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+12E]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ X8_v5 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+12E]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ X8_v5 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+B0]");
						object obj2 = (nint)0 + (nint)8;
						bool flag;
						do
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ X10_v7-8]");
							if (0 != num4)
							{
								object obj3 = (nint)obj - 1;
								obj2 = (nint)obj2 + 16;
								flag = (nint)obj != 1;
								obj = obj3;
								continue;
							}
							break;
						}
						while (flag);
					}
					enumerator2.Dispose();
				}
				if (num3 == 0)
				{
					return;
				}
				OutOfMemoryException ex = new OutOfMemoryException();
				if (num6 == 1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
					num3 = (int)obj4;
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
					enumerator2 = enumerator3;
					num4 = intPtr;
					continue;
				}
				break;
			}
			if (enumerator3 != null)
			{
				nint num7 = (nint)enumerator3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ X8_v11 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+12E]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ X8_v11 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+12E]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ X8_v11 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+B0]");
					object obj6 = (nint)0 + (nint)8;
					bool flag2;
					do
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ X10_v15-8]");
						if ((IntPtr)0 != intPtr)
						{
							object obj7 = (nint)obj5 - 1;
							obj6 = (nint)obj6 + 16;
							flag2 = (nint)obj5 != 1;
							obj5 = obj7;
							continue;
						}
						int num8 = obj6 << 4;
						object obj8 = num7 + num8;
						object obj9 = (nint)obj8 + 312;
						break;
					}
					while (flag2);
				}
				enumerator3.Dispose();
			}
			OutOfMemoryException ex2 = new OutOfMemoryException();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
		}

		[Token(Token = "0x600034B")]
		[Address(RVA = "0x15376F4", Offset = "0x15376F4", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv32 = Spine.PathAttachment;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, attachment, slotBone, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 1;\n\t*([1A37B7A]) = v49;\nL_0019:\n\tv50 = attachment == 0;\n\tif (v50) goto L_0045;\n\tgoto L_FFFFFFFF;\n\tv108 = v108_asT != 0;\n\tif (v108) goto L_0046;\nL_0045:\n\treturn;\nL_0046:\n\tv142 = *([attachment @ X1 (Spine.Attachment)+20]);\n\tv139 = *([attachment @ X1 (Spine.Attachment)+20]) == 0;\n\tif (v139) goto L_00CC;\n\tv264 = *([v142 @ X21_v4+18]);\n\tv84 = *([v142 @ X21_v4+18]) < 1;\n\tif (v84) goto L_0045;\n\tv148 = this.bones;\n\tv76 = *([attachment @ X1 (Spine.Attachment)+20]) + 0x20;\nL_005D:\n\tv285 = v339 << 2;\n\tv352 = *([attachment @ X1 (Spine.Attachment)+20]) + v285;\n\tv339 = *([v352 @ X9_v9+20]) + v280;\n\tv289 = v280 >= v339;\n\tif (v289) goto L_FFFFFFFF;\n\tv388 = ~v280;\n\tv283 = v388 + v339;\n\tv391 = v280 << 2;\n\tv276 = v76 + v391;\nL_007F:\n\tv337 = v148.Items;\n\tv327 = *([v276 @ X27_v10]);\n\tSpine.Skeleton::SortBone(this, v337[v327 @ X9_v16]);\n\tv334 = v283 == 0;\n\tif (v334) goto L_00AF;\n\tv280 = v280 + 1;\n\tv283 = v283 - 1;\n\tv276 = v276 + 4;\n\tv397 = v280 < *([v142 @ X21_v4+18]);\n\tv323 = ~v397;\n\tv291 = ~v323;\n\tif (v291) goto L_007F;\n\tgoto L_00BE;\nL_00AF:\n\tv86 = v339 >= v264;\n\tif (v86) goto L_0045;\n\tv280 = v339 + 1;\n\tv393 = v339 < *([v142 @ X21_v4+18]);\n\tv320 = ~v393;\n\tv288 = ~v320;\n\tif (v288) goto L_005D;\nL_00BE:\n\tthrow System.IndexOutOfRangeException;\nL_00CC:\n\tSpine.Skeleton::SortBone(this, slotBone);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 155 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SortPathConstraintAttachment(Attachment attachment, Bone slotBone)
		{
			//IL_0048: Expected O, but got I
			//IL_0085: Expected O, but got I
			//IL_00ca: Expected O, but got I
			//IL_0296: Expected O, but got I
			//IL_0113: Expected O, but got I
			//IL_0180: Expected O, but got I
			if (attachment == null)
			{
				return;
			}
			PathAttachment pathAttachment = attachment as PathAttachment;
			if (pathAttachment == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [attachment @ X1 (Spine.Attachment)+20]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [attachment @ X1 (Spine.Attachment)+20]");
			bool flag = (nint)0 == 0;
			Bone bone = slotBone;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X21_v4+18]");
				bone = (Bone)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X21_v4+18]");
				if ((nint)0 < (nint)1)
				{
					return;
				}
				ExposedList<Bone> exposedList = Bones;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [attachment @ X1 (Spine.Attachment)+20]");
				object obj2 = (nint)0 + (nint)32;
				int num = 1;
				int num2 = 0;
				int num8;
				do
				{
					int num3 = num2 << 2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [attachment @ X1 (Spine.Attachment)+20]");
					object obj3 = (nint)0 + (nint)num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ X9_v9+20]");
					num2 = (int)((nint)0 + (nint)num);
					if (num < num2)
					{
						int num4 = ~num;
						int num5 = num4 + num2;
						int num6 = num << 2;
						object obj4 = (nint)obj2 + num6;
						while (true)
						{
							Bone[] items = exposedList.Items;
							object obj5 = obj4;
							SortBone(items[obj5]);
							if (num5 == 0)
							{
								break;
							}
							num++;
							num5--;
							obj4 = (nint)obj4 + 4;
							int num7 = num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X21_v4+18]");
							if ((nint)num7 >= (nint)0)
							{
								goto end_IL_0273;
							}
						}
					}
					else
					{
						num2 = num;
					}
					if (num2 >= (nint)bone)
					{
						return;
					}
					num = num2 + 1;
					num8 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X21_v4+18]");
					continue;
					end_IL_0273:
					break;
				}
				while ((nint)num8 < (nint)0);
				throw new IndexOutOfRangeException();
			}
			SortBone(slotBone);
		}

		[Token(Token = "0x600034C")]
		[Address(RVA = "0x1537318", Offset = "0x1537318", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, bone, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A37B7B]) = v36;\nL_0015:\n\tv39 = ~bone.sorted;\n\tif (v39) goto L_001E;\n\treturn;\nL_001E:\n\tv53 = bone.parent == 0;\n\tif (v53) goto L_0023;\n\tSpine.Skeleton::SortBone(this, bone.parent);\nL_0023:\n\tbone.sorted = 1;\n\tSpine.ExposedList`1<Spine.IUpdatable>::Add(this.updateCache, bone);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SortBone(Bone bone)
		{
			if (!bone.sorted)
			{
				if (bone.Parent != null)
				{
					SortBone(bone.Parent);
				}
				bone.sorted = true;
				UpdateCacheList.Add(bone);
			}
		}

		[Token(Token = "0x600034D")]
		[Address(RVA = "0x15373A0", Offset = "0x15373A0", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = bones.Count < 1;\n\tif (v23) goto L_0044;\n\tv41 = bones.Items;\nL_0026:\n\tv29 = v41[v39 @ X21_v5 (System.Int32)];\n\tv154 = ~v29.active;\n\tif (v154) goto L_0032;\n\tv156 = ~v29.sorted;\n\tif (v156) goto L_0031;\n\tSpine.Skeleton::SortReset(v29.children);\nL_0031:\n\tv29.sorted = 0;\nL_0032:\n\tv39 = v39 + 1;\n\tv100 = bones.Count != v39;\n\tif (v100) goto L_0026;\nL_0044:\n\treturn;\n\tv25 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void SortReset(ExposedList<Bone> bones)
		{
			if (bones.Count < 1)
			{
				return;
			}
			Bone[] items = bones.Items;
			int num = 0;
			do
			{
				Bone bone = items[num];
				if (bone.Active)
				{
					if (bone.sorted)
					{
						SortReset(bone.Children);
					}
					bone.sorted = false;
				}
				num++;
			}
			while (bones.Count != num);
		}

		[Token(Token = "0x600034E")]
		[Address(RVA = "0x1536AEC", Offset = "0x1536AEC", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv20 = Spine.IUpdatable;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A37B7C]) = v39;\nL_0013:\n\tv40 = this.updateCacheReset;\n\tv53 = v40.Count < 1;\n\tif (v53) goto L_004B;\n\tv111 = v40.Items;\nL_0035:\n\tv84 = v111[v100 @ X10_v13 (System.Int32)];\n\tv100 = v100 + 1;\n\tv84.ax = v84.x;\n\tv84.ascaleY = v84.scaleY;\n\tv84.ashearY = v84.shearY;\n\tv84.appliedValid = 1;\n\tv202 = v40.Count != v100;\n\tif (v202) goto L_0035;\nL_004B:\n\tv192 = this.updateCache;\n\tv118 = v192.Count < 1;\n\tif (v118) goto L_00AF;\n\tv68 = v192.Items;\nL_0075:\n\tgoto L_009B;\n\tv325 = *([v322 @ X8_v11+B0]);\n\tv326 = v325 + 8;\n\tv330 = *([v354 @ X10_v10-8]);\n\tv370 = v330 == v323;\n\tif (v370) goto L_0094;\n\tv332 = v356 - 1;\n\tv328 = v354 + 0x10;\n\tv334 = v356 != 1;\n\tif (v334) goto L_FFFFFFFF;\n\tv351 = v189;\n\tv352 = 0;\n\tv353 = 0xB349B4(v351, v323, v352, v24, v25, v26, v27, v28, v80, v76, v72, v32, v33, v34, v35, v36);\n\tgoto L_009B;\nL_0094:\n\tv376 = *([v354 @ X10_v10]);\n\tv377 = v376 << 4;\n\tv378 = v322 + v377;\n\tv379 = v378 + 0x138;\nL_009B:\n\tSpine.IUpdatable::Update(v68[v62 @ X22_v6 (System.Int32)]);\n\tv62 = v62 + 1;\n\tv290 = v62 != v192.Count;\n\tif (v290) goto L_0075;\nL_00AF:\n\treturn;\n\tv178 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 132 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateWorldTransform()
		{
			ExposedList<Bone> exposedList = updateCacheReset;
			if (exposedList.Count >= 1)
			{
				Bone[] items = exposedList.Items;
				int num = 0;
				do
				{
					Bone bone = items[num];
					num++;
					bone.AX = bone.X;
					bone.AScaleY = bone.ScaleY;
					bone.AShearY = bone.ShearY;
					bone.appliedValid = true;
				}
				while (exposedList.Count != num);
			}
			ExposedList<IUpdatable> updateCacheList = UpdateCacheList;
			if (updateCacheList.Count >= 1)
			{
				IUpdatable[] items2 = updateCacheList.Items;
				int num2 = 0;
				do
				{
					items2[num2].Update();
					num2++;
				}
				while (num2 != updateCacheList.Count);
			}
		}

		[Token(Token = "0x600034F")]
		[Address(RVA = "0x1537870", Offset = "0x1537870", Length = "0x2A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv40 = Spine.IUpdatable;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, parent, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv63 = Spine.MathUtils;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, parent, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv59 = 1;\n\t*([1A37B7D]) = v59;\nL_0020:\n\tv60 = this.updateCacheReset;\n\tv75 = v60.Count < 1;\n\tif (v75) goto L_0059;\n\tv179 = v60.Items;\nL_0042:\n\tv152 = v179[v168 @ X10_v14 (System.Int32)];\n\tv168 = v168 + 1;\n\tv152.ax = v152.x;\n\tv152.ascaleY = v152.scaleY;\n\tv152.ashearY = v152.shearY;\n\tv152.appliedValid = 1;\n\tv277 = v60.Count != v168;\n\tif (v277) goto L_0042;\nL_0059:\n\tv247 = Spine.Skeleton::get_RootBone(this);\n\tv398 = parent.a * this.x;\n\tv399 = parent.b * this.y;\n\tv400 = v398 + v399;\n\tv401 = v400 + parent.worldX;\n\tv247.worldX = v401;\n\tv403 = parent.c * this.x;\n\tv404 = parent.d * this.y;\n\tv405 = v403 + v404;\n\tv406 = v405 + parent.worldY;\n\tv247.worldY = v406;\n\tgoto L_007C;\n\tv414 = \"il2cpp_codegen_runtime_class_init\"(v407, parent, methodInfo, v43, v44, v45, v46, v47, v406, v404, v402, v400, v399, v53, v54, v55);\nL_007C:\n\tv415 = v247.rotation + v247.shearX;\n\tv416 = Spine.MathUtils::CosDeg(v415);\n\tv420 = v247.rotation + 0x42B40000;\n\tv109 = v420 + v247.shearY;\n\tv121 = v416 * v247.scaleX;\n\tv422 = Spine.MathUtils::CosDeg(v109);\n\tv112 = v422 * v247.scaleY;\n\tv426 = v247.rotation + v247.shearX;\n\tv427 = Spine.MathUtils::SinDeg(v426);\n\tv106 = v427 * v247.scaleX;\n\tv430 = Spine.MathUtils::SinDeg(v109);\n\tv433 = parent.a * v121;\n\tv103 = parent.b * v106;\n\tv434 = v433 + v103;\n\tv435 = v430 * v247.scaleY;\n\tv115 = parent.a * v112;\n\tv436 = v434 * this.scaleX;\n\tv437 = parent.b * v435;\n\tv118 = v115 + v437;\n\tv438 = this.scaleX * v118;\n\tv247.a = v436;\n\tv247.b = v438;\n\tv100 = parent.c * v121;\n\tv97 = parent.c * v112;\n\tv94 = parent.d * v106;\n\tv439 = parent.d * v435;\n\tv440 = v100 + v94;\n\tv441 = v97 + v439;\n\tv138 = v440 * this.scaleY;\n\tv148 = v441 * this.scaleY;\n\tv247.c = v138;\n\tv247.d = v148;\n\tv267 = this.updateCache;\n\tv186 = v267.Count < 1;\n\tif (v186) goto L_011F;\n\tv90 = v267.Items;\nL_00D0:\n\tv222 = v90[v84 @ X23_v6 (System.Int32)] == v247;\n\tif (v222) goto L_0103;\n\tgoto L_0102;\n\tv511 = *([v508 @ X8_v16+B0]);\n\tv512 = v511 + 8;\n\tv516 = *([v540 @ X10_v11-8]);\n\tv556 = v516 == v509;\n\tif (v556) goto L_00FB;\n\tv518 = v542 - 1;\n\tv514 = v540 + 0x10;\n\tv520 = v542 != 1;\n\tif (v520) goto L_FFFFFFFF;\n\tv537 = v261;\n\tv538 = 0;\n\tv539 = 0xB349B4(v537, v509, v538, v43, v44, v45, v46, v47, v148, v143, v138, v118, v115, v100, v97, v103);\n\tgoto L_0102;\nL_00FB:\n\tv562 = *([v540 @ X10_v11]);\n\tv563 = v562 << 4;\n\tv564 = v508 + v563;\n\tv565 = v564 + 0x138;\nL_0102:\n\tSpine.IUpdatable::Update(v90[v84 @ X23_v6 (System.Int32)]);\nL_0103:\n\tv84 = v84 + 1;\n\tv454 = v84 != v267.Count;\n\tif (v454) goto L_00D0;\nL_011F:\n\treturn;\n\tv246 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 195 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateWorldTransform(Bone parent)
		{
			ExposedList<Bone> exposedList = updateCacheReset;
			if (exposedList.Count >= 1)
			{
				Bone[] items = exposedList.Items;
				int num = 0;
				do
				{
					Bone bone = items[num];
					num++;
					bone.AX = bone.X;
					bone.AScaleY = bone.ScaleY;
					bone.AShearY = bone.ShearY;
					bone.appliedValid = true;
				}
				while (exposedList.Count != num);
			}
			Bone rootBone = RootBone;
			float num2 = parent.A * X;
			float num3 = parent.B * Y;
			float num4 = num2 + num3;
			float worldX = num4 + parent.WorldX;
			rootBone.worldX = worldX;
			float num5 = parent.C * X;
			float num6 = parent.D * Y;
			float num7 = num5 + num6;
			float worldY = num7 + parent.WorldY;
			rootBone.worldY = worldY;
			float degrees = rootBone.Rotation + rootBone.ShearX;
			float num8 = MathUtils.CosDeg(degrees);
			float num9 = rootBone.Rotation + 90f;
			float degrees2 = num9 + rootBone.ShearY;
			float num10 = num8 * rootBone.ScaleX;
			float num11 = MathUtils.CosDeg(degrees2);
			float num12 = num11 * rootBone.ScaleY;
			float degrees3 = rootBone.Rotation + rootBone.ShearX;
			float num13 = MathUtils.SinDeg(degrees3);
			float num14 = num13 * rootBone.ScaleX;
			float num15 = MathUtils.SinDeg(degrees2);
			float num16 = parent.A * num10;
			float num17 = parent.B * num14;
			float num18 = num16 + num17;
			float num19 = num15 * rootBone.ScaleY;
			float num20 = parent.A * num12;
			float num21 = num18 * ScaleX;
			float num22 = parent.B * num19;
			float num23 = num20 + num22;
			float num24 = ScaleX * num23;
			rootBone.a = num21;
			rootBone.b = num24;
			float num25 = parent.C * num10;
			float num26 = parent.C * num12;
			float num27 = parent.D * num14;
			float num28 = parent.D * num19;
			float num29 = num25 + num27;
			float num30 = num26 + num28;
			float c = num29 * scaleY;
			float d = num30 * scaleY;
			rootBone.c = c;
			rootBone.d = d;
			ExposedList<IUpdatable> updateCacheList = UpdateCacheList;
			if (updateCacheList.Count < 1)
			{
				return;
			}
			IUpdatable[] items2 = updateCacheList.Items;
			int num31 = 0;
			do
			{
				if (items2[num31] != rootBone)
				{
					items2[num31].Update();
				}
				num31++;
			}
			while (num31 != updateCacheList.Count);
		}

		[Token(Token = "0x6000350")]
		[Address(RVA = "0x1537B14", Offset = "0x1537B14", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Skeleton::SetBonesToSetupPose(this);\n\tSpine.Skeleton::SetSlotsToSetupPose(this);\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetToSetupPose()
		{
			SetBonesToSetupPose();
			SetSlotsToSetupPose();
		}

		[Token(Token = "0x6000351")]
		[Address(RVA = "0x1537B2C", Offset = "0x1537B2C", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.bones;\n\tv25 = v10.Count < 1;\n\tif (v25) goto L_0038;\n\tv92 = v10.Items;\nL_002B:\n\tSpine.Bone::SetToSetupPose(v92[v89 @ X22_v6 (System.Int32)]);\n\tv89 = v89 + 1;\n\tv241 = v10.Count != v89;\n\tif (v241) goto L_002B;\nL_0038:\n\tv70 = this.ikConstraints;\n\tv98 = v70.Count < 1;\n\tif (v98) goto L_0073;\n\tv71 = v70.Items;\nL_0059:\n\tv49 = v71[v56 @ X11_v13 (System.Int32)];\n\tv40 = v49.data;\n\tv56 = v56 + 1;\n\tv49.mix = v40.mix;\n\tv49.bendDirection = v40.bendDirection;\n\tv49.compress = v40.compress;\n\tv49.stretch = v40.stretch;\n\tv307 = v70.Count != v56;\n\tif (v307) goto L_0059;\nL_0073:\n\tv72 = this.transformConstraints;\n\tv101 = v72.Count < 1;\n\tif (v101) goto L_00A8;\n\tv73 = v72.Items;\nL_0094:\n\tv51 = v73[v58 @ X11_v10 (System.Int32)];\n\tv43 = v51.data;\n\tv58 = v58 + 1;\n\tv51.rotateMix = v43.rotateMix;\n\tv379 = v72.Count != v58;\n\tif (v379) goto L_0094;\nL_00A8:\n\tv74 = this.pathConstraints;\n\tv104 = v74.Count < 1;\n\tif (v104) goto L_00E3;\n\tv75 = v74.Items;\nL_00C9:\n\tv53 = v75[v60 @ X11_v7 (System.Int32)];\n\tv46 = v53.data;\n\tv60 = v60 + 1;\n\tv53.position = v46.position;\n\tv405 = v74.Count != v60;\n\tif (v405) goto L_00C9;\nL_00E3:\n\treturn;\n\tv225 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 186 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetBonesToSetupPose()
		{
			ExposedList<Bone> exposedList = Bones;
			if (exposedList.Count >= 1)
			{
				Bone[] items = exposedList.Items;
				int num = 0;
				do
				{
					items[num].SetToSetupPose();
					num++;
				}
				while (exposedList.Count != num);
			}
			ExposedList<IkConstraint> exposedList2 = IkConstraints;
			if (exposedList2.Count >= 1)
			{
				IkConstraint[] items2 = exposedList2.Items;
				int num2 = 0;
				do
				{
					IkConstraint ikConstraint = items2[num2];
					IkConstraintData ikConstraintData = ikConstraint.Data;
					num2++;
					ikConstraint.Mix = ikConstraintData.Mix;
					ikConstraint.BendDirection = ikConstraintData.BendDirection;
					ikConstraint.compress = ikConstraintData.Compress;
					ikConstraint.stretch = ikConstraintData.Stretch;
				}
				while (exposedList2.Count != num2);
			}
			ExposedList<TransformConstraint> exposedList3 = TransformConstraints;
			if (exposedList3.Count >= 1)
			{
				TransformConstraint[] items3 = exposedList3.Items;
				int num3 = 0;
				do
				{
					TransformConstraint transformConstraint = items3[num3];
					TransformConstraintData transformConstraintData = transformConstraint.Data;
					num3++;
					transformConstraint.RotateMix = transformConstraintData.RotateMix;
				}
				while (exposedList3.Count != num3);
			}
			ExposedList<PathConstraint> exposedList4 = PathConstraints;
			if (exposedList4.Count >= 1)
			{
				PathConstraint[] items4 = exposedList4.Items;
				int num4 = 0;
				do
				{
					PathConstraint pathConstraint = items4[num4];
					PathConstraintData pathConstraintData = pathConstraint.Data;
					num4++;
					pathConstraint.Position = pathConstraintData.Position;
				}
				while (exposedList4.Count != num4);
			}
		}

		[Token(Token = "0x6000352")]
		[Address(RVA = "0x1537CB0", Offset = "0x1537CB0", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv48 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A37B7E]) = v44;\nL_0018:\n\tv45 = this.slots;\n\tv150 = v45.Items;\n\tSpine.ExposedList`1<Spine.Slot>::Clear(this.drawOrder, 1);\n\tv69 = v45.Count < 1;\n\tif (v69) goto L_0089;\nL_0047:\n\tSpine.ExposedList`1<Spine.Slot>::Add(this.drawOrder, v150[v62 @ X23_v5 (System.Int32)]);\n\tv62 = v62 + 1;\n\tv229 = v45.Count != v62;\n\tif (v229) goto L_0047;\n\tv207 = v45.Count < 1;\n\tif (v207) goto L_0089;\nL_0073:\n\tSpine.Slot::SetToSetupPose(v150[v57 @ X21_v7 (System.Int32)]);\n\tv57 = v57 + 1;\n\tv206 = v45.Count != v57;\n\tif (v206) goto L_0073;\nL_0089:\n\treturn;\n\tv133 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 115 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetSlotsToSetupPose()
		{
			ExposedList<Slot> exposedList = Slots;
			Slot[] items = exposedList.Items;
			DrawOrder.Clear();
			if (exposedList.Count < 1)
			{
				return;
			}
			int num = 0;
			do
			{
				DrawOrder.Add(items[num]);
				num++;
			}
			while (exposedList.Count != num);
			if (exposedList.Count >= 1)
			{
				int num2 = 0;
				do
				{
					items[num2].SetToSetupPose();
					num2++;
				}
				while (exposedList.Count != num2);
			}
		}

		[Token(Token = "0x6000353")]
		[Address(RVA = "0x1531DCC", Offset = "0x1531DCC", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = boneName == 0;\n\tif (v12) goto L_0054;\n\tv14 = this.bones;\n\tv96 = v14.Count < 1;\n\tif (v96) goto L_FFFFFFFF;\n\tv112 = v14.Items;\nL_002B:\n\tv104 = v112[v108 @ X23_v8 (System.Int32)];\n\tv134 = v104.data;\n\tv146 = System.String::op_Equality(v134.name, boneName);\n\tv259 = v146 == 0;\n\tv173 = ~v259;\n\tif (v173) goto L_004E;\n\tv108 = v108 + 1;\n\tv154 = v14.Count != v108;\n\tif (v154) goto L_002B;\nL_004E:\n\treturn v188;\n\tv139 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_0054:\n\tv140 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v140, \"boneName\", \"boneName cannot be null.\");\n\tthrow v140;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Bone FindBone(string boneName)
		{
			Bone result;
			if (boneName != null)
			{
				ExposedList<Bone> exposedList = Bones;
				if (exposedList.Count < 1)
				{
					goto IL_0117;
				}
				Bone[] items = exposedList.Items;
				int num = 0;
				while (true)
				{
					Bone bone = items[num];
					BoneData boneData = bone.Data;
					bool flag = boneData.Name == boneName;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = items[num];
					if (flag3)
					{
						break;
					}
					num++;
					if (exposedList.Count != num)
					{
						continue;
					}
					goto IL_0117;
				}
				goto IL_0144;
			}
			ArgumentNullException ex = new ArgumentNullException("boneName", "boneName cannot be null.");
			throw ex;
			IL_0117:
			result = null;
			goto IL_0144;
			IL_0144:
			return result;
		}

		[Token(Token = "0x6000354")]
		[Address(RVA = "0x1537DBC", Offset = "0x1537DBC", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = boneName == 0;\n\tif (v10) goto L_0052;\n\tv12 = this.bones;\n\tv92 = v12.Count < 1;\n\tif (v92) goto L_FFFFFFFF;\n\tv106 = v12.Items;\nL_002A:\n\tv127 = v106[v181 @ X20_v5 (System.Int32)];\n\tv128 = v127.data;\n\tv140 = System.String::op_Equality(v128.name, boneName);\n\tv249 = v140 == 0;\n\tv166 = ~v249;\n\tif (v166) goto L_004C;\n\tv181 = v181 + 1;\n\tv147 = v12.Count != v181;\n\tif (v147) goto L_002A;\nL_004C:\n\treturn v181;\n\tv133 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_0052:\n\tv134 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v134, \"boneName\", \"boneName cannot be null.\");\n\tthrow v134;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int FindBoneIndex(string boneName)
		{
			int num;
			if (boneName != null)
			{
				ExposedList<Bone> exposedList = Bones;
				if (exposedList.Count < 1)
				{
					goto IL_0106;
				}
				Bone[] items = exposedList.Items;
				num = 0;
				while (true)
				{
					Bone bone = items[num];
					BoneData boneData = bone.Data;
					if (boneData.Name == boneName)
					{
						break;
					}
					num++;
					if (exposedList.Count != num)
					{
						continue;
					}
					goto IL_0106;
				}
				goto IL_0137;
			}
			ArgumentNullException ex = new ArgumentNullException("boneName", "boneName cannot be null.");
			throw ex;
			IL_0106:
			num = -1;
			goto IL_0137;
			IL_0137:
			return num;
		}

		[Token(Token = "0x6000355")]
		[Address(RVA = "0x153399C", Offset = "0x153399C", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = slotName == 0;\n\tif (v12) goto L_0054;\n\tv14 = this.slots;\n\tv96 = v14.Count < 1;\n\tif (v96) goto L_FFFFFFFF;\n\tv112 = v14.Items;\nL_002B:\n\tv104 = v112[v108 @ X23_v8 (System.Int32)];\n\tv134 = v104.data;\n\tv146 = System.String::op_Equality(v134.name, slotName);\n\tv259 = v146 == 0;\n\tv173 = ~v259;\n\tif (v173) goto L_004E;\n\tv108 = v108 + 1;\n\tv154 = v14.Count != v108;\n\tif (v154) goto L_002B;\nL_004E:\n\treturn v188;\n\tv139 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_0054:\n\tv140 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v140, \"slotName\", \"slotName cannot be null.\");\n\tthrow v140;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Slot FindSlot(string slotName)
		{
			Slot result;
			if (slotName != null)
			{
				ExposedList<Slot> exposedList = Slots;
				if (exposedList.Count < 1)
				{
					goto IL_0117;
				}
				Slot[] items = exposedList.Items;
				int num = 0;
				while (true)
				{
					Slot slot = items[num];
					SlotData slotData = slot.Data;
					bool flag = slotData.Name == slotName;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = items[num];
					if (flag3)
					{
						break;
					}
					num++;
					if (exposedList.Count != num)
					{
						continue;
					}
					goto IL_0117;
				}
				goto IL_0144;
			}
			ArgumentNullException ex = new ArgumentNullException("slotName", "slotName cannot be null.");
			throw ex;
			IL_0117:
			result = null;
			goto IL_0144;
			IL_0144:
			return result;
		}

		[Token(Token = "0x6000356")]
		[Address(RVA = "0x1537EAC", Offset = "0x1537EAC", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = slotName == 0;\n\tif (v10) goto L_0054;\n\tv12 = this.slots;\n\tv92 = v12.Count < 1;\n\tif (v92) goto L_FFFFFFFF;\n\tv107 = v12.Items;\nL_002A:\n\tv128 = v107[v183 @ X20_v5 (System.Int32)];\n\tv129 = v128.data;\n\tv142 = System.String::Equals(v129.name, slotName);\n\tv250 = v142 == 0;\n\tv168 = ~v250;\n\tif (v168) goto L_004E;\n\tv183 = v183 + 1;\n\tv149 = v12.Count != v183;\n\tif (v149) goto L_002A;\nL_004E:\n\treturn v183;\n\tv135 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_0054:\n\tv136 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v136, \"slotName\", \"slotName cannot be null.\");\n\tthrow v136;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int FindSlotIndex(string slotName)
		{
			int num;
			if (slotName != null)
			{
				ExposedList<Slot> exposedList = Slots;
				if (exposedList.Count < 1)
				{
					goto IL_0106;
				}
				Slot[] items = exposedList.Items;
				num = 0;
				while (true)
				{
					Slot slot = items[num];
					SlotData slotData = slot.Data;
					if (slotData.Name.Equals(slotName))
					{
						break;
					}
					num++;
					if (exposedList.Count != num)
					{
						continue;
					}
					goto IL_0106;
				}
				goto IL_0137;
			}
			ArgumentNullException ex = new ArgumentNullException("slotName", "slotName cannot be null.");
			throw ex;
			IL_0106:
			num = -1;
			goto IL_0137;
			IL_0137:
			return num;
		}

		[Token(Token = "0x6000357")]
		[Address(RVA = "0x1537FA0", Offset = "0x1537FA0", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = Spine.SkeletonData::FindSkin(this.data, skinName);\n\tv29 = v13 == 0;\n\tif (v29) goto L_001B;\n\tSpine.Skeleton::SetSkin(this, v13);\n\treturn;\n\tthrow System.NullReferenceException;\nL_001B:\n\tv44 = System.String::Concat(\"Skin not found: \", v30);\n\tv62 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v62, v44, \"skinName\");\n\tthrow v62;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetSkin(string skinName)
		{
			Skin skin = Data.FindSkin(skinName);
			if (skin != null)
			{
				SetSkin(skin);
				return;
			}
			string text = default(string);
			string message = "Skin not found: " + text;
			ArgumentException ex = new ArgumentException(message, "skinName");
			throw ex;
		}

		[Token(Token = "0x6000358")]
		[Address(RVA = "0x1535A20", Offset = "0x1535A20", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = newSkin == this.skin;\n\tif (v21) goto L_0026;\n\tv28 = newSkin == 0;\n\tif (v28) goto L_0067;\n\tv36 = this.skin == 0;\n\tif (v36) goto L_0027;\n\tSpine.Skin::AttachAll(newSkin, this, this.skin);\n\tgoto L_0067;\nL_0026:\n\treturn;\nL_0027:\n\tv51 = this.slots;\n\tv49 = v51.Count < 1;\n\tif (v49) goto L_0067;\nL_0038:\n\tv153 = v51.Items;\n\tv57 = v153[v163 @ X21_v7 (System.Int32)];\n\tv38 = v57.data;\n\tv221 = v38.attachmentName == 0;\n\tif (v221) goto L_005B;\n\tv225 = Spine.Skin::GetAttachment(newSkin, v163, v38.attachmentName);\n\tv228 = v225 == 0;\n\tif (v228) goto L_005B;\n\tSpine.Slot::set_Attachment(v153[v163 @ X21_v7 (System.Int32)], v225);\nL_005B:\n\tv163 = v163 + 1;\n\tv47 = v51.Count != v163;\n\tif (v47) goto L_0038;\nL_0067:\n\tthis.skin = newSkin;\n\tSpine.Skeleton::UpdateCache(this);\n\treturn;\n\tv202 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetSkin(Skin newSkin)
		{
			if (newSkin == Skin)
			{
				return;
			}
			if (newSkin != null)
			{
				if (Skin != null)
				{
					newSkin.AttachAll(this, Skin);
				}
				else
				{
					ExposedList<Slot> exposedList = Slots;
					if (exposedList.Count >= 1)
					{
						int num = 0;
						do
						{
							Slot[] items = exposedList.Items;
							Slot slot = items[num];
							SlotData slotData = slot.Data;
							if (slotData.AttachmentName != null)
							{
								Attachment attachment = newSkin.GetAttachment(num, slotData.AttachmentName);
								if (attachment != null)
								{
									items[num].Attachment = attachment;
								}
							}
							num++;
						}
						while (exposedList.Count != num);
					}
				}
			}
			skin = newSkin;
			UpdateCache();
		}

		[Token(Token = "0x6000359")]
		[Address(RVA = "0x1538044", Offset = "0x1538044", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = Spine.SkeletonData::FindSlotIndex(this.data, slotName);\n\treturnVal2 = Spine.Skeleton::GetAttachment(this, v13, attachmentName);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Attachment GetAttachment(string slotName, string attachmentName)
		{
			int slotIndex = Data.FindSlotIndex(slotName);
			return GetAttachment(slotIndex, attachmentName);
		}

		[Token(Token = "0x600035A")]
		[Address(RVA = "0x1538080", Offset = "0x1538080", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = attachmentName == 0;\n\tif (v8) goto L_002D;\n\tv16 = this.skin == 0;\n\tif (v16) goto L_0014;\n\treturnVal1 = Spine.Skin::GetAttachment(this.skin, slotIndex, attachmentName);\n\tv46 = returnVal1 == 0;\n\tv42 = ~v46;\n\tif (v42) goto L_0029;\nL_0014:\n\tv43 = this.data;\n\tv48 = v43.defaultSkin == 0;\n\tif (v48) goto L_0029;\n\treturnVal3 = Spine.Skin::GetAttachment(v43.defaultSkin, slotIndex, attachmentName);\n\treturn returnVal3;\nL_0029:\n\treturn returnVal1;\nL_002D:\n\tv45 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v45, \"attachmentName\", \"attachmentName cannot be null.\");\n\tthrow v45;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Attachment GetAttachment(int slotIndex, string attachmentName)
		{
			Attachment attachment;
			if (attachmentName != null)
			{
				if (Skin != null)
				{
					attachment = Skin.GetAttachment(slotIndex, attachmentName);
					if (attachment != null)
					{
						goto IL_00d8;
					}
				}
				SkeletonData skeletonData = Data;
				bool flag = skeletonData.DefaultSkin == null;
				attachment = (Attachment)(object)skeletonData.DefaultSkin;
				if (!flag)
				{
					return skeletonData.DefaultSkin.GetAttachment(slotIndex, attachmentName);
				}
				goto IL_00d8;
			}
			ArgumentNullException ex = new ArgumentNullException("attachmentName", "attachmentName cannot be null.");
			throw ex;
			IL_00d8:
			return attachment;
		}

		[Token(Token = "0x600035B")]
		[Address(RVA = "0x1538148", Offset = "0x1538148", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = slotName == 0;\n\tif (v16) goto L_0089;\n\tv18 = this.slots;\n\tv107 = v18.Count < 1;\n\tif (v107) goto L_004E;\nL_001F:\n\tv118 = v18.Items;\n\tv116 = v118[v128 @ X22_v9 (System.Int32)];\n\tv120 = v116.data;\n\tv171 = System.String::op_Equality(v120.name, slotName);\n\tv286 = v171 == 0;\n\tv198 = ~v286;\n\tif (v198) goto L_005E;\n\tv236 = v128 + 1;\n\tv180 = v18.Count != v236;\n\tif (v180) goto L_001F;\nL_004E:\n\tv225 = System.String::Concat(\"Slot not found: \", slotName);\nL_0053:\n\tv271 = new System.Exception();\n\tSystem.Exception::.ctor(v271, v225);\n\tthrow v271;\nL_005E:\n\tv336 = attachmentName == 0;\n\tif (v336) goto L_FFFFFFFF;\n\tv340 = Spine.Skeleton::GetAttachment(this, v128, attachmentName);\n\tv343 = v340 == 0;\n\tv262 = ~v343;\n\tif (v262) goto L_0082;\n\tv225 = System.String::Concat(\"Attachment not found: \", attachmentName, \", for slot: \", slotName);\n\tgoto L_0053;\nL_0082:\n\tSpine.Slot::set_Attachment(v228, v299);\n\treturn;\n\tv163 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_0089:\n\tv164 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v164, \"slotName\", \"slotName cannot be null.\");\n\tthrow v164;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetAttachment(string slotName, string attachmentName)
		{
			string message;
			if (slotName != null)
			{
				ExposedList<Slot> exposedList = Slots;
				if (exposedList.Count >= 1)
				{
					int num = 0;
					Slot slot2;
					while (true)
					{
						Slot[] items = exposedList.Items;
						Slot slot = items[num];
						SlotData slotData = slot.Data;
						bool flag = slotData.Name == slotName;
						bool flag2 = !flag;
						bool flag3 = !flag2;
						slot2 = items[num];
						int num2 = num;
						if (flag3)
						{
							break;
						}
						num2 = num + 1;
						bool flag4 = exposedList.Count != num2;
						slot2 = items[num];
						num = num2;
						if (flag4)
						{
							continue;
						}
						goto IL_0126;
					}
					Attachment attachment2;
					if (attachmentName != null)
					{
						Attachment attachment = GetAttachment(num, attachmentName);
						bool flag5 = attachment == null;
						bool flag6 = !flag5;
						attachment2 = attachment;
						if (!flag6)
						{
							message = "Attachment not found: " + attachmentName + ", for slot: " + slotName;
							goto IL_013d;
						}
					}
					else
					{
						attachment2 = null;
					}
					slot2.Attachment = attachment2;
					return;
				}
				goto IL_0126;
			}
			ArgumentNullException ex = new ArgumentNullException("slotName", "slotName cannot be null.");
			throw ex;
			IL_013d:
			Exception ex2 = new Exception(message);
			throw ex2;
			IL_0126:
			message = "Slot not found: " + slotName;
			goto IL_013d;
		}

		[Token(Token = "0x600035C")]
		[Address(RVA = "0x15382F4", Offset = "0x15382F4", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = constraintName == 0;\n\tif (v12) goto L_0054;\n\tv14 = this.ikConstraints;\n\tv98 = v14.Count < 1;\n\tif (v98) goto L_FFFFFFFF;\nL_001B:\n\tv109 = v14.Items;\n\tv107 = v109[v119 @ X23_v8 (System.Int32)];\n\tv111 = v107.data;\n\tv161 = System.String::op_Equality(v111.name, constraintName);\n\tv263 = v161 == 0;\n\tv188 = ~v263;\n\tif (v188) goto L_004E;\n\tv119 = v119 + 1;\n\tv170 = v14.Count != v119;\n\tif (v170) goto L_001B;\nL_004E:\n\treturn v200;\n\tv153 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_0054:\n\tv154 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v154, \"constraintName\", \"constraintName cannot be null.\");\n\tthrow v154;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IkConstraint FindIkConstraint(string constraintName)
		{
			IkConstraint result;
			if (constraintName != null)
			{
				ExposedList<IkConstraint> exposedList = IkConstraints;
				if (exposedList.Count < 1)
				{
					goto IL_0105;
				}
				int num = 0;
				while (true)
				{
					IkConstraint[] items = exposedList.Items;
					IkConstraint ikConstraint = items[num];
					IkConstraintData ikConstraintData = ikConstraint.Data;
					bool flag = ikConstraintData.Name == constraintName;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = items[num];
					if (flag3)
					{
						break;
					}
					num++;
					if (exposedList.Count != num)
					{
						continue;
					}
					goto IL_0105;
				}
				goto IL_0132;
			}
			ArgumentNullException ex = new ArgumentNullException("constraintName", "constraintName cannot be null.");
			throw ex;
			IL_0105:
			result = null;
			goto IL_0132;
			IL_0132:
			return result;
		}

		[Token(Token = "0x600035D")]
		[Address(RVA = "0x15383E4", Offset = "0x15383E4", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = constraintName == 0;\n\tif (v12) goto L_0054;\n\tv14 = this.transformConstraints;\n\tv98 = v14.Count < 1;\n\tif (v98) goto L_FFFFFFFF;\nL_001B:\n\tv109 = v14.Items;\n\tv107 = v109[v119 @ X23_v8 (System.Int32)];\n\tv111 = v107.data;\n\tv161 = System.String::op_Equality(v111.name, constraintName);\n\tv263 = v161 == 0;\n\tv188 = ~v263;\n\tif (v188) goto L_004E;\n\tv119 = v119 + 1;\n\tv170 = v14.Count != v119;\n\tif (v170) goto L_001B;\nL_004E:\n\treturn v200;\n\tv153 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_0054:\n\tv154 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v154, \"constraintName\", \"constraintName cannot be null.\");\n\tthrow v154;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TransformConstraint FindTransformConstraint(string constraintName)
		{
			TransformConstraint result;
			if (constraintName != null)
			{
				ExposedList<TransformConstraint> exposedList = TransformConstraints;
				if (exposedList.Count < 1)
				{
					goto IL_0105;
				}
				int num = 0;
				while (true)
				{
					TransformConstraint[] items = exposedList.Items;
					TransformConstraint transformConstraint = items[num];
					TransformConstraintData transformConstraintData = transformConstraint.Data;
					bool flag = transformConstraintData.Name == constraintName;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = items[num];
					if (flag3)
					{
						break;
					}
					num++;
					if (exposedList.Count != num)
					{
						continue;
					}
					goto IL_0105;
				}
				goto IL_0132;
			}
			ArgumentNullException ex = new ArgumentNullException("constraintName", "constraintName cannot be null.");
			throw ex;
			IL_0105:
			result = null;
			goto IL_0132;
			IL_0132:
			return result;
		}

		[Token(Token = "0x600035E")]
		[Address(RVA = "0x15384D4", Offset = "0x15384D4", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = constraintName == 0;\n\tif (v12) goto L_0056;\n\tv14 = this.pathConstraints;\n\tv98 = v14.Count < 1;\n\tif (v98) goto L_FFFFFFFF;\nL_001B:\n\tv110 = v14.Items;\n\tv108 = v110[v120 @ X23_v8 (System.Int32)];\n\tv112 = v108.data;\n\tv163 = System.String::Equals(v112.name, constraintName);\n\tv264 = v163 == 0;\n\tv190 = ~v264;\n\tif (v190) goto L_0050;\n\tv120 = v120 + 1;\n\tv172 = v14.Count != v120;\n\tif (v172) goto L_001B;\nL_0050:\n\treturn v202;\n\tv155 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_0056:\n\tv156 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v156, \"constraintName\", \"constraintName cannot be null.\");\n\tthrow v156;\n// 86 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PathConstraint FindPathConstraint(string constraintName)
		{
			PathConstraint result;
			if (constraintName != null)
			{
				ExposedList<PathConstraint> exposedList = PathConstraints;
				if (exposedList.Count < 1)
				{
					goto IL_0105;
				}
				int num = 0;
				while (true)
				{
					PathConstraint[] items = exposedList.Items;
					PathConstraint pathConstraint = items[num];
					PathConstraintData pathConstraintData = pathConstraint.Data;
					bool flag = pathConstraintData.Name.Equals(constraintName);
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = items[num];
					if (flag3)
					{
						break;
					}
					num++;
					if (exposedList.Count != num)
					{
						continue;
					}
					goto IL_0105;
				}
				goto IL_0132;
			}
			ArgumentNullException ex = new ArgumentNullException("constraintName", "constraintName cannot be null.");
			throw ex;
			IL_0105:
			result = null;
			goto IL_0132;
			IL_0132:
			return result;
		}

		[Token(Token = "0x600035F")]
		[Address(RVA = "0x15385C8", Offset = "0x15385C8", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.time + delta;\n\tthis.time = v2;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Update(float delta)
		{
			float num = Time + delta;
			Time = num;
		}

		[Token(Token = "0x6000360")]
		[Address(RVA = "0x15385D8", Offset = "0x15385D8", Length = "0x344")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv54 = System.Math;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, x, y, width, height, vertexBuffer, methodInfo, v57, v58, v59, v60, v61, v62, v63, v64, v65);\n\tv74 = Spine.MeshAttachment;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, x, y, width, height, vertexBuffer, methodInfo, v57, v58, v59, v60, v61, v62, v63, v64, v65);\n\tv89 = Spine.RegionAttachment;\n\tv90 = \"il2cpp_codegen_initialize_runtime_metadata\"(v89, x, y, width, height, vertexBuffer, methodInfo, v57, v58, v59, v60, v61, v62, v63, v64, v65);\n\tv239 = System.Single[];\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v239, x, y, width, height, vertexBuffer, methodInfo, v57, v58, v59, v60, v61, v62, v63, v64, v65);\n\tv69 = 1;\n\t*([1A37B7F]) = v69;\nL_002D:\n\tv636 = vertexBuffer->klass;\n\tv71 = *([vertexBuffer @ X5 (System.Single[]&)]) == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_0037;\n\t// 53 NewArr v80 @ X0_v30 (System.Single[]), typeof(System.Single[]), 8\nL_0037:\n\tv86 = this.drawOrder;\n\tv91 = v86.Items;\n\tv250 = v91.Length < 1;\n\tif (v250) goto L_FFFFFFFF;\nL_005F:\n\tv224 = v91[v236 @ X20_v8 (System.Int32)];\n\tv639 = v224.bone;\n\tv560 = ~v639.active;\n\tif (v560) goto L_0136;\n\tv137 = v224.attachment;\n\tv561 = v224.attachment == 0;\n\tif (v561) goto L_0136;\n\tgoto L_FFFFFFFF;\n\tv188 = v188_asT != 0;\n\tif (v188) goto L_00C9;\n\tgoto L_FFFFFFFF;\n\tv162 = v162_asT == 0;\n\tif (v162) goto L_0136;\n\tv471 = v137.height;\n\tv585 = v137.height <= v636.Length;\n\tif (v585) goto L_00C2;\n\t// 185 NewArr v700 @ X0_v23 (System.Single[]), typeof(System.Single[]), v137.height (System.Single)\nL_00C2:\n\tSpine.VertexAttachment::ComputeWorldVertices(v224.attachment, v91[v236 @ X20_v8 (System.Int32)], 0, v471, v636, 0, 2);\n\tv715 = v636 == 0;\n\tv645 = ~v715;\n\tif (v645) goto L_00F0;\n\tgoto L_0136;\nL_00C9:\n\t;\n\tv586 = v636.Length > 7;\n\tif (v586) goto L_00E2;\n\t// 219 NewArr v688 @ X0_v27 (System.Single[]), typeof(System.Single[]), 8\n\tv639 = v224.bone;\nL_00E2:\n\tSpine.RegionAttachment::ComputeWorldVertices(v224.attachment, v639, v636, 0, 2);\n\tv646 = v636 == 0;\n\tif (v646) goto L_0136;\nL_00F0:\n\tv587 = v471 < 1;\n\tif (v587) goto L_0136;\nL_00FE:\n\tv475 = v481 + 1;\n\tgoto L_0118;\n\tv733 = \"il2cpp_codegen_runtime_class_init\"(v728, v462, v374, v371, v368, v365, v377, v57, v383, v380, v60, v61, v62, v63, v64, v65);\nL_0118:\n\tv738 = System.Math::Min(v409, v459[v481 @ X8_v20 (System.Int32)]);\n\tv742 = System.Math::Min(v418, v459[v475 @ X26_v11 (System.Int32)]);\n\tv746 = System.Math::Max(v412, v459[v481 @ X8_v20 (System.Int32)]);\n\tv382 = System.Math::Max(v415, v459[v475 @ X26_v11 (System.Int32)]);\n\tv481 = v475 + 1;\n\tv583 = v481 < v471;\n\tif (v583) goto L_00FE;\nL_0136:\n\tv236 = v236 + 1;\n\tv551 = v236 == v91.Length;\n\tif (v551) goto L_0151;\n\tv665 = v236 < v91.Length;\n\tv454 = ~v665;\n\tv423 = ~v454;\n\tif (v423) goto L_005F;\n\tthrow System.IndexOutOfRangeException;\nL_0151:\n\tgoto L_0159;\nL_0159:\n\tv273 = v507 - v505;\n\tv271 = v509 - v511;\n\t*([x @ X1 (System.Single&)]) = v505;\n\t*([y @ X2 (System.Single&)]) = v511;\n\t*([width @ X3 (System.Single&)]) = v273;\n\t*([height @ X4 (System.Single&)]) = v271;\n\t*([vertexBuffer @ X5 (System.Single[]&)]) = v636;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 293 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void GetBounds(out float x, out float y, out float width, out float height, ref float[] vertexBuffer)
		{
			//IL_0538: Expected Ref, but got F4
			//IL_0540: Expected Ref, but got F4
			//IL_0548: Expected Ref, but got F4
			//IL_0550: Expected Ref, but got F4
			//IL_0186: Expected I4, but got F4
			x = default(float);
			y = default(float);
			width = default(float);
			height = default(float);
			float[] array = vertexBuffer;
			if (vertexBuffer == null)
			{
				float[] array2 = new float[8];
				array = array2;
			}
			ExposedList<Slot> exposedList = DrawOrder;
			Slot[] items = exposedList.Items;
			float num;
			float num2;
			float num3;
			float num4;
			if (items.Length >= 1)
			{
				num = 2.1474836E+09f;
				num2 = -2.1474836E+09f;
				num3 = -2.1474836E+09f;
				num4 = 2.1474836E+09f;
				int num5 = 0;
				while (true)
				{
					Slot slot = items[num5];
					Bone bone = slot.Bone;
					int num6;
					float[] array4;
					if (bone.Active)
					{
						RegionAttachment attachment = (RegionAttachment)slot.Attachment;
						if (slot.Attachment != null)
						{
							RegionAttachment regionAttachment = slot.Attachment as RegionAttachment;
							if (regionAttachment == null)
							{
								MeshAttachment meshAttachment = slot.Attachment as MeshAttachment;
								if (meshAttachment != null)
								{
									num6 = (int)attachment.Height;
									if (attachment.Height > (float)array.Length)
									{
										float[] array3 = new float[attachment.Height];
										array = array3;
									}
									((VertexAttachment)slot.Attachment).ComputeWorldVertices(items[num5], 0, num6, array, 0, 2);
									bool flag = array == null;
									bool flag2 = !flag;
									array4 = array;
									if (flag2)
									{
										goto IL_0220;
									}
								}
							}
							else
							{
								if (array.Length <= 7)
								{
									float[] array5 = new float[8];
									bone = slot.Bone;
									array = array5;
								}
								((RegionAttachment)slot.Attachment).ComputeWorldVertices(bone, array, 0, 2);
								bool flag3 = array == null;
								array4 = array;
								num6 = 8;
								if (!flag3)
								{
									goto IL_0220;
								}
							}
						}
					}
					goto IL_0379;
					IL_0220:
					bool flag4 = num6 < 1;
					array = array4;
					if (!flag4)
					{
						float val = num;
						float val2 = num2;
						float val3 = num3;
						float val4 = num4;
						int num7 = 0;
						bool flag5;
						do
						{
							int num8 = num7 + 1;
							float num9 = Math.Min(val, array4[num7]);
							float num10 = Math.Min(val4, array4[num8]);
							float num11 = Math.Max(val2, array4[num7]);
							float num12 = Math.Max(val3, array4[num8]);
							num7 = num8 + 1;
							flag5 = num7 < num6;
							num = num9;
							num2 = num11;
							num3 = num12;
							num4 = num10;
							array = array4;
							val = num9;
							val2 = num11;
							val3 = num12;
							val4 = num10;
						}
						while (flag5);
					}
					goto IL_0379;
					IL_0379:
					num5++;
					if (num5 != items.Length)
					{
						if (num5 >= items.Length)
						{
							throw new IndexOutOfRangeException();
						}
						continue;
					}
					break;
				}
			}
			else
			{
				num = 2.1474836E+09f;
				num2 = -2.1474836E+09f;
				num3 = -2.1474836E+09f;
				num4 = 2.1474836E+09f;
			}
			float num13 = num2 - num;
			float num14 = num3 - num4;
			ref float reference = ref *(float*)num;
			ref float reference2 = ref *(float*)num4;
			ref float reference3 = ref *(float*)num13;
			ref float reference4 = ref *(float*)num14;
			ref float[] reference5 = ref *(float[]*)array;
		}
	}
}
