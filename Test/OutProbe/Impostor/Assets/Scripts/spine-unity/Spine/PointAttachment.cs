using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x200003A")]
	public class PointAttachment : Attachment
	{
		[Token(Token = "0x4000149")]
		[FieldOffset(Offset = "0x18")]
		internal float x;

		[Token(Token = "0x400014A")]
		[FieldOffset(Offset = "0x1C")]
		internal float y;

		[Token(Token = "0x400014B")]
		[FieldOffset(Offset = "0x20")]
		internal float rotation;

		[Token(Token = "0x1700007B")]
		public float X
		{
			[Token(Token = "0x60001B6")]
			[Address(RVA = "0x152F2E8", Offset = "0x152F2E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.x;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return X;
			}
			[Token(Token = "0x60001B7")]
			[Address(RVA = "0x152F2F0", Offset = "0x152F2F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.x = value;\n\treturn;\n")]
			set
			{
				X = value;
			}
		}

		[Token(Token = "0x1700007C")]
		public float Y
		{
			[Token(Token = "0x60001B8")]
			[Address(RVA = "0x152F2F8", Offset = "0x152F2F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.y;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Y;
			}
			[Token(Token = "0x60001B9")]
			[Address(RVA = "0x152F300", Offset = "0x152F300", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.y = value;\n\treturn;\n")]
			set
			{
				Y = value;
			}
		}

		[Token(Token = "0x1700007D")]
		public float Rotation
		{
			[Token(Token = "0x60001BA")]
			[Address(RVA = "0x152F308", Offset = "0x152F308", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.rotation;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Rotation;
			}
			[Token(Token = "0x60001BB")]
			[Address(RVA = "0x152F310", Offset = "0x152F310", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.rotation = value;\n\treturn;\n")]
			set
			{
				Rotation = value;
			}
		}

		[Token(Token = "0x60001BC")]
		[Address(RVA = "0x152F318", Offset = "0x152F318", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Attachment::.ctor(this, name);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PointAttachment(string name)
			: base(name)
		{
		}

		[Token(Token = "0x60001BD")]
		[Address(RVA = "0x152F320", Offset = "0x152F320", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.x * bone.a;\n\tv11 = this.y * bone.b;\n\tv12 = v10 + v11;\n\tv13 = bone.worldX + v12;\n\t*([ox @ X2 (System.Single&)]) = v13;\n\tv18 = this.x * bone.c;\n\tv19 = this.y * bone.d;\n\tv20 = v18 + v19;\n\tv21 = bone.worldY + v20;\n\t*([oy @ X3 (System.Single&)]) = v21;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void ComputeWorldPosition(Bone bone, out float ox, out float oy)
		{
			//IL_006b: Expected Ref, but got F4
			//IL_00c2: Expected Ref, but got F4
			ox = default(float);
			oy = default(float);
			float num = X * bone.A;
			float num2 = Y * bone.B;
			float num3 = num + num2;
			float num4 = bone.WorldX + num3;
			ref float reference = ref *(float*)num4;
			float num5 = X * bone.C;
			float num6 = Y * bone.D;
			float num7 = num5 + num6;
			float num8 = bone.WorldY + num7;
			ref float reference2 = ref *(float*)num8;
		}

		[Token(Token = "0x60001BE")]
		[Address(RVA = "0x152F3AC", Offset = "0x152F3AC", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = Spine.MathUtils;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, bone, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A37B45]) = v42;\nL_001B:\n\tgoto L_001E;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v43, bone, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_001E:\n\tv51 = Spine.MathUtils::CosDeg(this.rotation);\n\treturnVal2 = Spine.MathUtils::SinDeg(this.rotation);\n\tv61 = v51 * bone.a;\n\tv62 = returnVal2 * bone.b;\n\tv63 = v51 * bone.c;\n\tv64 = returnVal2 * bone.d;\n\tv65 = v61 + v62;\n\tv66 = v63 + v64;\n\tv67 = Spine.MathUtils::Atan2(v66, v65);\n\treturnVal1 = v67 * 57.295776f;\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float ComputeWorldRotation(Bone bone)
		{
			float num = MathUtils.CosDeg(Rotation);
			float num2 = MathUtils.SinDeg(Rotation);
			float num3 = num * bone.A;
			float num4 = num2 * bone.B;
			float num5 = num * bone.C;
			float num6 = num2 * bone.D;
			float num7 = num3 + num4;
			float num8 = num5 + num6;
			float num9 = MathUtils.Atan2(num8, num7);
			return num9 * (180f / (float)Math.PI);
		}

		[Token(Token = "0x60001BF")]
		[Address(RVA = "0x152F5B0", Offset = "0x152F5B0", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Spine.PointAttachment;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37B46]) = v37;\nL_0015:\n\tv40 = new Spine.PointAttachment();\n\tSpine.Attachment::.ctor(v40, this.<Name>k__BackingField);\n\tv40.x = this.x;\n\tv40.rotation = this.rotation;\n\treturn v40;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Attachment Copy()
		{
			PointAttachment pointAttachment = (PointAttachment)new Attachment(Name);
			pointAttachment.X = X;
			pointAttachment.Rotation = Rotation;
			return pointAttachment;
		}
	}
}
