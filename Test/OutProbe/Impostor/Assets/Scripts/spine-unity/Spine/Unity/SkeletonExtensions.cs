using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[Token(Token = "0x20000BF")]
	public static class SkeletonExtensions
	{
		[Token(Token = "0x400043C")]
		private const float ByteToFloat = 0.003921569f;

		[Token(Token = "0x60006B9")]
		[Address(RVA = "0x1570FA0", Offset = "0x1570FA0", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn s.r;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Color GetColor(this Skeleton s)
		{
			//IL_000a: Expected O, but got F4
			return (Color)s.R;
		}

		[Token(Token = "0x60006BA")]
		[Address(RVA = "0x1570FBC", Offset = "0x1570FBC", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn a.r;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Color GetColor(this RegionAttachment a)
		{
			//IL_000a: Expected O, but got F4
			return (Color)a.R;
		}

		[Token(Token = "0x60006BB")]
		[Address(RVA = "0x1570FD8", Offset = "0x1570FD8", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn a.r;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Color GetColor(this MeshAttachment a)
		{
			//IL_000a: Expected O, but got F4
			return (Color)a.R;
		}

		[Token(Token = "0x60006BC")]
		[Address(RVA = "0x1570FF4", Offset = "0x1570FF4", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn s.r;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Color GetColor(this Slot s)
		{
			//IL_000a: Expected O, but got F4
			return (Color)s.R;
		}

		[Token(Token = "0x60006BD")]
		[Address(RVA = "0x1571010", Offset = "0x1571010", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn s.r2;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Color GetColorTintBlack(this Slot s)
		{
			//IL_000a: Expected O, but got F4
			return (Color)s.R2;
		}

		[Token(Token = "0x60006BE")]
		[Address(RVA = "0x1571030", Offset = "0x1571030", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tskeleton.r = color;\n\tskeleton.g = color.g;\n\tskeleton.b = color.b;\n\tskeleton.a = color.a;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetColor(this Skeleton skeleton, Color color)
		{
			Color color2 = default(Color);
			skeleton.R = color2.r;
			skeleton.G = color.g;
			skeleton.B = color.b;
			skeleton.A = color.a;
		}

		[Token(Token = "0x60006BF")]
		[Address(RVA = "0x157104C", Offset = "0x157104C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t// 15 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 16 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 17 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv16 = 0xF7 * v17;\n\tskeleton.r = v16;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetColor(this Skeleton skeleton, Color32 color)
		{
			//IL_002d: Expected O, but got I
			//IL_003a: Expected F4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
			object obj2 = default(object);
			object obj = 247 * (nint)obj2;
			skeleton.R = (float)obj;
		}

		[Token(Token = "0x60006C0")]
		[Address(RVA = "0x157109C", Offset = "0x157109C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tslot.r = color;\n\tslot.g = color.g;\n\tslot.b = color.b;\n\tslot.a = color.a;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetColor(this Slot slot, Color color)
		{
			Color color2 = default(Color);
			slot.R = color2.r;
			slot.G = color.g;
			slot.B = color.b;
			slot.A = color.a;
		}

		[Token(Token = "0x60006C1")]
		[Address(RVA = "0x15710B8", Offset = "0x15710B8", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t// 15 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 16 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 17 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv16 = 0xF7 * v17;\n\tslot.r = v16;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetColor(this Slot slot, Color32 color)
		{
			//IL_002d: Expected O, but got I
			//IL_003a: Expected F4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
			object obj2 = default(object);
			object obj = 247 * (nint)obj2;
			slot.R = (float)obj;
		}

		[Token(Token = "0x60006C2")]
		[Address(RVA = "0x1571108", Offset = "0x1571108", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tattachment.r = color;\n\tattachment.g = color.g;\n\tattachment.b = color.b;\n\tattachment.a = color.a;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetColor(this RegionAttachment attachment, Color color)
		{
			Color color2 = default(Color);
			attachment.R = color2.r;
			attachment.G = color.g;
			attachment.B = color.b;
			attachment.A = color.a;
		}

		[Token(Token = "0x60006C3")]
		[Address(RVA = "0x1571124", Offset = "0x1571124", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t// 15 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 16 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 17 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv16 = 0xF7 * v17;\n\tattachment.r = v16;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetColor(this RegionAttachment attachment, Color32 color)
		{
			//IL_002d: Expected O, but got I
			//IL_003a: Expected F4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
			object obj2 = default(object);
			object obj = 247 * (nint)obj2;
			attachment.R = (float)obj;
		}

		[Token(Token = "0x60006C4")]
		[Address(RVA = "0x1571174", Offset = "0x1571174", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tattachment.r = color;\n\tattachment.g = color.g;\n\tattachment.b = color.b;\n\tattachment.a = color.a;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetColor(this MeshAttachment attachment, Color color)
		{
			Color color2 = default(Color);
			attachment.R = color2.r;
			attachment.G = color.g;
			attachment.B = color.b;
			attachment.A = color.a;
		}

		[Token(Token = "0x60006C5")]
		[Address(RVA = "0x1571190", Offset = "0x1571190", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t// 15 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 16 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 17 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv16 = 0xF7 * v17;\n\tattachment.r = v16;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetColor(this MeshAttachment attachment, Color32 color)
		{
			//IL_002d: Expected O, but got I
			//IL_003a: Expected F4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
			object obj2 = default(object);
			object obj = 247 * (nint)obj2;
			attachment.R = (float)obj;
		}

		[Token(Token = "0x60006C6")]
		[Address(RVA = "0x15711E0", Offset = "0x15711E0", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tskeleton.scaleX = scale;\n\tskeleton.scaleY = scale.y;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetLocalScale(this Skeleton skeleton, Vector2 scale)
		{
			Vector2 vector = default(Vector2);
			skeleton.ScaleX = vector.x;
			skeleton.ScaleY = scale.y;
		}

		[Token(Token = "0x60006C7")]
		[Address(RVA = "0x15711F8", Offset = "0x15711F8", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.m00 = bone.a;\n\treturnBuffer.m10 = bone.c;\n\treturnBuffer.m20 = 0f;\n\treturnBuffer.m01 = bone.b;\n\treturnBuffer.m11 = bone.d;\n\treturnBuffer.m22 = 0f;\n\treturnBuffer.m21 = 0f;\n\treturnBuffer.m03 = bone.worldX;\n\treturnBuffer.m13 = bone.worldY;\n\treturnBuffer.m23 = 0.0078125d;\n\treturn bone;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Matrix4x4 GetMatrix4x4(this Bone bone)
		{
			//IL_000d: Expected native int or pointer, but got O
			//IL_001f: Expected native int or pointer, but got O
			//IL_002d: Expected native int or pointer, but got O
			//IL_003f: Expected native int or pointer, but got O
			//IL_0051: Expected native int or pointer, but got O
			//IL_005f: Expected native int or pointer, but got O
			//IL_006d: Expected native int or pointer, but got O
			//IL_007f: Expected native int or pointer, but got O
			//IL_0091: Expected native int or pointer, but got O
			//IL_009f: Expected native int or pointer, but got O
			//IL_00ad: Expected native int or pointer, but got O
			Matrix4x4 matrix4x = default(Matrix4x4);
			((Matrix4x4*)(nint)matrix4x)->m00 = bone.A;
			((Matrix4x4*)(nint)matrix4x)->m10 = bone.C;
			((Matrix4x4*)(nint)matrix4x)->m20 = 0f;
			((Matrix4x4*)(nint)matrix4x)->m01 = bone.B;
			((Matrix4x4*)(nint)matrix4x)->m11 = bone.D;
			((Matrix4x4*)(nint)matrix4x)->m22 = 0f;
			((Matrix4x4*)(nint)matrix4x)->m21 = 0f;
			((Matrix4x4*)(nint)matrix4x)->m03 = bone.WorldX;
			((Matrix4x4*)(nint)matrix4x)->m13 = bone.WorldY;
			((Matrix4x4*)(nint)matrix4x)->m23 = 0f;
			((Matrix4x4*)(nint)matrix4x)->m33 = 1f;
			return (Matrix4x4)bone;
		}

		[Token(Token = "0x60006C8")]
		[Address(RVA = "0x157124C", Offset = "0x157124C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tbone.x = position;\n\tbone.y = position.y;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetLocalPosition(this Bone bone, Vector2 position)
		{
			Vector2 vector = default(Vector2);
			bone.X = vector.x;
			bone.Y = position.y;
		}

		[Token(Token = "0x60006C9")]
		[Address(RVA = "0x1571264", Offset = "0x1571264", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tbone.x = position;\n\tbone.y = position.y;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetLocalPosition(this Bone bone, Vector3 position)
		{
			Vector3 vector = default(Vector3);
			bone.X = vector.x;
			bone.Y = position.y;
		}

		[Token(Token = "0x60006CA")]
		[Address(RVA = "0x157127C", Offset = "0x157127C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn bone.x;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector2 GetLocalPosition(this Bone bone)
		{
			//IL_000a: Expected O, but got F4
			return (Vector2)bone.X;
		}

		[Token(Token = "0x60006CB")]
		[Address(RVA = "0x1571294", Offset = "0x1571294", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn bone.worldX;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector2 GetSkeletonSpacePosition(this Bone bone)
		{
			//IL_000a: Expected O, but got F4
			return (Vector2)bone.WorldX;
		}

		[Token(Token = "0x60006CC")]
		[Address(RVA = "0x15712B0", Offset = "0x15712B0", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = &v11 @ stack_-8_v3 (System.Single) | 4;\n\tSpine.Bone::LocalToWorld(bone, boneLocal, boneLocal.y, &v11 @ stack_-8_v3 (System.Single), v9);\n\treturn v11;\n\tthrow System.NullReferenceException;\n\treturn boneLocal;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Vector2 GetSkeletonSpacePosition(this Bone bone, Vector2 boneLocal)
		{
			//IL_0037: Expected O, but got F4
			float worldX = default(float);
			ref float worldY = ref *(float*)((nint)worldX | 4);
			Vector2 vector = default(Vector2);
			bone.LocalToWorld(vector.x, boneLocal.y, out worldX, out worldY);
			return (Vector2)worldX;
		}

		[Token(Token = "0x60006CD")]
		[Address(RVA = "0x15712E0", Offset = "0x15712E0", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t// 13 MakeStruct v28 @ AGG1575304_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), bone.worldX (System.Single), bone.worldY (System.Single), 0\n\treturnVal2 = UnityEngine.Transform::TransformPoint(spineGameObjectTransform, v28);\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 GetWorldPosition(this Bone bone, Transform spineGameObjectTransform)
		{
			Vector3 position = default(Vector3);
			position.x = bone.WorldX;
			position.y = bone.WorldY;
			position.z = 0f;
			return spineGameObjectTransform.TransformPoint(position);
		}

		[Token(Token = "0x60006CE")]
		[Address(RVA = "0x157130C", Offset = "0x157130C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = bone.worldY * positionScale;\n\tv27 = bone.worldX * positionScale;\n\t// 15 MakeStruct v30 @ AGG1575338_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v27 @ V0_v1 (System.Single), v26 @ V1_v2 (System.Single), 0\n\treturnVal2 = UnityEngine.Transform::TransformPoint(spineGameObjectTransform, v30);\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturn positionScale;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 GetWorldPosition(this Bone bone, Transform spineGameObjectTransform, float positionScale)
		{
			float y = bone.WorldY * positionScale;
			float x = bone.WorldX * positionScale;
			Vector3 position = default(Vector3);
			position.x = x;
			position.y = y;
			position.z = 0f;
			return spineGameObjectTransform.TransformPoint(position);
		}

		[Token(Token = "0x60006CF")]
		[Address(RVA = "0x1571340", Offset = "0x1571340", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = 0x1854F00(bone, methodInfo, v8, v9, v10, v11, v12, v13, bone.c, bone.a, v14, v15, v16, v17, v18, v19);\n\tv24 = bone.c * 0.5f;\n\tv29 = 0x1854F30(&v26 @ stack_-4_v1, &v28 @ stack_-8_v1, v8, v9, v10, v11, v12, v13, v24, 0.5f, v14, v15, v16, v17, v18, v19);\n\treturn 0;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Quaternion GetQuaternion(this Bone bone)
		{
			Il2CppRuntime.Boundary("SYSTEM_API:atan2f", "Method not found @1854F00 (native atan2f)");
			float num = bone.C * 0.5f;
			Il2CppRuntime.Boundary("SYSTEM_API:sincosf", "Method not found @1854F30 (native sincosf)");
			return default(Quaternion);
		}

		[Token(Token = "0x60006D0")]
		[Address(RVA = "0x1571380", Offset = "0x1571380", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = bone.rotation * 0.017453292f;\n\tv13 = v11 * 0.5f;\n\tv14 = 0x1854F30(&v8 @ stack_-4_v1, &v10 @ stack_-8_v1, v15, v16, v17, v18, v19, v20, v13, 0.5f, v21, v22, v23, v24, v25, v26);\n\treturn 0;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Quaternion GetLocalQuaternion(this Bone bone)
		{
			float num = bone.Rotation * ((float)Math.PI / 180f);
			float num2 = num * 0.5f;
			Il2CppRuntime.Boundary("SYSTEM_API:sincosf", "Method not found @1854F30 (native sincosf)");
			return default(Quaternion);
		}

		[Token(Token = "0x60006D1")]
		[Address(RVA = "0x15713C4", Offset = "0x15713C4", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = Spine.Skeleton::get_ScaleY(skeleton);\n\treturn skeleton.scaleX;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector2 GetLocalScale(this Skeleton skeleton)
		{
			//IL_0017: Expected O, but got F4
			float scaleY = skeleton.ScaleY;
			return (Vector2)skeleton.ScaleX;
		}

		[Token(Token = "0x60006D2")]
		[Address(RVA = "0x15713F4", Offset = "0x15713F4", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = bone.a * bone.d;\n\tv9 = bone.b * bone.c;\n\tv10 = v8 - v9;\n\tv12 = -bone.b;\n\tv13 = -bone.c;\n\tv14 = 1f / v10;\n\tv15 = bone.d * v14;\n\tv16 = v14 * v12;\n\tv17 = v14 * v13;\n\tv18 = bone.a * v14;\n\t*([ia @ X1 (System.Single&)]) = v15;\n\t*([ib @ X2 (System.Single&)]) = v16;\n\t*([ic @ X3 (System.Single&)]) = v17;\n\t*([id @ X4 (System.Single&)]) = v18;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void GetWorldToLocalMatrix(this Bone bone, out float ia, out float ib, out float ic, out float id)
		{
			//IL_0077: Expected O, but got F4
			//IL_0085: Expected O, but got F4
			//IL_00e3: Expected Ref, but got F4
			//IL_00eb: Expected Ref, but got F4
			//IL_00f3: Expected Ref, but got F4
			//IL_00fb: Expected Ref, but got F4
			ia = default(float);
			ib = default(float);
			ic = default(float);
			id = default(float);
			float num = bone.A * bone.D;
			float num2 = bone.B * bone.C;
			float num3 = num - num2;
			object obj = 0f - bone.B;
			object obj2 = 0f - bone.C;
			float num4 = 1f / num3;
			float num5 = bone.D * num4;
			float num6 = num4 * (float)obj;
			float num7 = num4 * (float)obj2;
			float num8 = bone.A * num4;
			ref float reference = ref *(float*)num5;
			ref float reference2 = ref *(float*)num6;
			ref float reference3 = ref *(float*)num7;
			ref float reference4 = ref *(float*)num8;
		}

		[Token(Token = "0x60006D3")]
		[Address(RVA = "0x157144C", Offset = "0x157144C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = &v11 @ stack_-8_v3 (System.Single) | 4;\n\tSpine.Bone::WorldToLocal(bone, worldPosition, worldPosition.y, &v11 @ stack_-8_v3 (System.Single), v9);\n\treturn v11;\n\tthrow System.NullReferenceException;\n\treturn worldPosition;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Vector2 WorldToLocal(this Bone bone, Vector2 worldPosition)
		{
			//IL_0037: Expected O, but got F4
			float localX = default(float);
			ref float localY = ref *(float*)((nint)localX | 4);
			Vector2 vector = default(Vector2);
			bone.WorldToLocal(vector.x, worldPosition.y, out localX, out localY);
			return (Vector2)localX;
		}

		[Token(Token = "0x60006D4")]
		[Address(RVA = "0x157147C", Offset = "0x157147C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = returnVal1.y;\n\tv10 = bone.parent == 0;\n\tif (v10) goto L_000D;\n\treturnVal1 = Spine.Unity.SkeletonExtensions::WorldToLocal(bone.parent, returnVal1);\n\tv30 = returnVal1.y;\nL_000D:\n\tbone.x = returnVal1;\n\tbone.y = v30;\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturn skeletonSpacePosition;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector2 SetPositionSkeletonSpace(this Bone bone, Vector2 skeletonSpacePosition)
		{
			Vector2 vector = default(Vector2);
			float y = vector.y;
			if (bone.Parent != null)
			{
				vector = bone.Parent.WorldToLocal(vector);
				y = vector.y;
			}
			bone.X = vector.x;
			bone.Y = y;
			return vector;
		}

		[Token(Token = "0x60006D5")]
		[Address(RVA = "0x15714A4", Offset = "0x15714A4", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = Spine.AtlasRegion;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv43 = Spine.IHasRendererObject;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv47 = UnityEngine.Material;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37CE8]) = v38;\nL_001B:\n\t// 27 IsInst v41 @ X0_v3 (Spine.IHasRendererObject), typeof(Spine.IHasRendererObject), a @ X0 (Spine.Attachment)\n\tv45 = v41 == 0;\n\tif (v45) goto L_0097;\n\tgoto L_0049;\n\tv137 = *([v48 @ X8_v4+B0]);\n\tv138 = v137 + 8;\n\tv140 = *([v214 @ X10_v10-8]);\n\tv220 = v140 == v49;\n\tif (v220) goto L_0042;\n\tv162 = v215 - 1;\n\tv160 = v214 + 0x10;\n\tv142 = v215 != 1;\n\tif (v142) goto L_FFFFFFFF;\n\tv163 = v50;\n\tv164 = 0;\n\tv165 = 0xB349B4(v163, v49, v164, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tgoto L_0049;\nL_0042:\n\tv226 = *([v214 @ X10_v10]);\n\tv227 = v226 << 4;\n\tv228 = v48 + v227;\n\tv229 = v228 + 0x138;\nL_0049:\n\tv124 = Spine.IHasRendererObject::get_RendererObject(v41);\n\tv127 = v124 == 0;\n\tif (v127) goto L_0097;\n\tgoto L_FFFFFFFF;\n\tv66 = v66_asT == 0;\n\tif (v66) goto L_0098;\n\tv131 = *([v124 @ X0_v7 (System.Object)+10]);\n\treturnVal1 = *([v131 @ X8_v13+30]);\n\tv126 = *([v131 @ X8_v13+30]) == 0;\n\tif (v126) goto L_0097;\n\tgoto L_FFFFFFFF;\n\tv64 = v64_asT == 0;\n\tif (v64) goto L_0098;\nL_0097:\n\treturn returnVal1;\nL_0098:\n\tv276 = new System.InvalidCastException();\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 108 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Material GetMaterial(this Attachment a)
		{
			//IL_0049: Expected O, but got I
			//IL_005e: Expected O, but got I
			//IL_0099: Expected O, but got I
			IHasRendererObject hasRendererObject = a as IHasRendererObject;
			bool flag = hasRendererObject == null;
			Material result = (Material)hasRendererObject;
			if (!flag)
			{
				object rendererObject = hasRendererObject.RendererObject;
				bool flag2 = rendererObject == null;
				result = (Material)rendererObject;
				if (!flag2)
				{
					AtlasRegion atlasRegion = rendererObject as AtlasRegion;
					if (atlasRegion == null)
					{
						goto IL_00bf;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ X0_v7 (System.Object)+10]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ X8_v13+30]");
					result = (Material)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ X8_v13+30]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ X8_v13+30]");
						Material material = 0 as Material;
						if ((object)material == null)
						{
							goto IL_00bf;
						}
					}
				}
			}
			return result;
			IL_00bf:
			InvalidCastException ex = new InvalidCastException();
			return (Material)(object)new NullReferenceException();
		}

		[Token(Token = "0x60006D6")]
		[Address(RVA = "0x15699D4", Offset = "0x15699D4", Length = "0x2A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = System.Single[];\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, slot, buffer, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv53 = UnityEngine.Vector2[];\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, slot, buffer, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A37CE9]) = v48;\nL_001F:\n\tv54 = va.worldVerticesLength;\n\tv55 = va.worldVerticesLength >> 1;\n\tv56 = buffer == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_0038;\n\t// 40 NewArr v201 @ X0_v36 (UnityEngine.Vector2[]), typeof(UnityEngine.Vector2[]), v55 @ X21_v3 (System.Int32)\nL_0038:\n\tv136 = v55 > v213.Length;\n\tif (v136) goto L_0126;\n\tv280 = va.bones == 0;\n\tif (v280) goto L_00C3;\n\t// 65 NewArr v286 @ X0_v32 (System.Single[]), typeof(System.Single[]), va.worldVerticesLength (System.Int32)\n\tSpine.VertexAttachment::ComputeWorldVertices(va, slot, v286);\n\tv203 = slot.bone;\n\tSpine.Unity.SkeletonExtensions::GetWorldToLocalMatrix(slot.bone, &v114 @ stack_-34_v5 (System.Single), &v110 @ stack_-38_v6 (System.Single), &v107 @ stack_-54_v5 (System.Single), &v100 @ stack_-58_v6 (System.Single));\n\tv137 = va.worldVerticesLength < 2;\n\tif (v137) goto L_011D;\n\tv562 = v55 - 1;\n\tv563 = v562 < 0;\n\tv564 = v562 == 0;\n\tv565 = v55 ^ 1;\n\tv566 = v55 ^ v562;\n\tv567 = v565 & v566;\n\tv568 = v567 < 0;\n\tv571 = v563 == v568;\n\tv344 = ~v564;\n\tv572 = v571 & v344;\n\tv319 = ~v572;\n\tif (v319) goto L_FFFFFFFF;\n\tgoto L_007A;\nL_007A:\n\tv554 = v213 + 0x24;\n\tv513 = v286 + 0x24;\nL_009F:\n\tv520 = v520 + 1;\n\tv595 = *([v513 @ X12_v9-4]) - v203.worldX;\n\tv596 = *([v513 @ X12_v9]) - v203.worldY;\n\tv597 = v595 * v107;\n\tv301 = v596 * v100;\n\tv598 = v595 * v114;\n\tv305 = v596 * v110;\n\tv303 = v597 + v301;\n\tv307 = v598 + v305;\n\t*([v554 @ X11_v8-4]) = v307;\n\t*([v554 @ X11_v8]) = v303;\n\tv554 = v554 + 8;\n\tv513 = v513 + 8;\n\tv347 = v316 != v520;\n\tif (v347) goto L_009F;\n\tgoto L_011D;\nL_00C3:\n\tv138 = va.worldVerticesLength < 2;\n\tif (v138) goto L_011D;\n\tv397 = v55 - 1;\n\tv398 = v397 < 0;\n\tv399 = v397 == 0;\n\tv400 = v55 ^ 1;\n\tv401 = v55 ^ v397;\n\tv402 = v400 & v401;\n\tv403 = v402 < 0;\n\tv478 = v213 + 0x24;\n\tv407 = v398 == v403;\n\tv343 = ~v399;\n\tv408 = v407 & v343;\n\tv318 = ~v408;\n\tif (v318) goto L_FFFFFFFF;\n\tgoto L_00DE;\nL_00DE:\n\tv479 = va.vertices + 0x24;\nL_0101:\n\tv479 = v479 + 8;\n\tv480 = v480 + 1;\n\t*([v478 @ X12_v6-4]) = *([v479 @ X14_v6-4]);\n\t*([v478 @ X12_v6]) = *([v479 @ X14_v6]);\n\tv478 = v478 + 8;\n\tv346 = v309 != v480;\n\tif (v346) goto L_0101;\nL_011D:\n\treturn v213;\n\tv200 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\nL_0126:\n\t// 294 Box v282 @ X0_v6 (System.Object), typeof(System.Int32), &v54 @ X23_v3 (System.Int32)\n\tv394 = System.String::Format(\"Vector2 buffer too small. {0} requires an array of size {1}. Use the attachment's .WorldVerticesLength to get the correct size.\", va.<Name>k__BackingField, v282);\n\tv469 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v469, v394, \"buffer\");\n\tthrow v469;\n\treturn returnVal2;\n// 237 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector2[] GetLocalVertices(this VertexAttachment va, Slot slot, Vector2[] buffer)
		{
			//IL_0361: Expected O, but got I
			//IL_04b4: Expected O, but got I
			//IL_03ca: Expected O, but got I
			//IL_03fc: Expected O, but got I
			//IL_0483: Expected O, but got I
			//IL_0492: Expected O, but got I
			//IL_028b: Expected O, but got F4
			//IL_029a: Expected O, but got I
			//IL_02a9: Expected O, but got I
			int worldVerticesLength = va.WorldVerticesLength;
			int num = va.WorldVerticesLength >> 1;
			bool flag = buffer == null;
			bool flag2 = !flag;
			Vector2[] array = buffer;
			if (!flag2)
			{
				Vector2[] array2 = new Vector2[num];
				array = array2;
			}
			if (num <= array.Length)
			{
				if (va.Bones != null)
				{
					float[] array3 = new float[va.WorldVerticesLength];
					va.ComputeWorldVertices(slot, array3);
					Bone bone = slot.Bone;
					slot.Bone.GetWorldToLocalMatrix(out var ia, out var ib, out var ic, out var id);
					if (va.WorldVerticesLength >= 2)
					{
						int num2 = num - 1;
						bool flag3 = num2 < 0;
						bool flag4 = num2 == 0;
						int num3 = num ^ 1;
						int num4 = num ^ num2;
						int num5 = num3 & num4;
						bool flag5 = num5 < 0;
						bool flag6 = flag3 == flag5;
						bool flag7 = !flag4;
						int num6 = ((!(flag6 && flag7)) ? 1 : num);
						object obj = (nint)array + 36;
						object obj2 = (nint)array3 + 36;
						int num7 = 0;
						do
						{
							num7++;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v513 @ X12_v9-4]");
							float num8 = 0f - bone.WorldX;
							float num9 = (float)obj2 - bone.WorldY;
							float num10 = num8 * ic;
							float num11 = num9 * id;
							float num12 = num8 * ia;
							float num13 = num9 * ib;
							float num14 = num10 + num11;
							float num15 = num12 + num13;
							obj = num14;
							obj = (nint)obj + 8;
							obj2 = (nint)obj2 + 8;
						}
						while (num6 != num7);
					}
				}
				else if (va.WorldVerticesLength >= 2)
				{
					int num16 = num - 1;
					bool flag8 = num16 < 0;
					bool flag9 = num16 == 0;
					int num17 = num ^ 1;
					int num18 = num ^ num16;
					int num19 = num17 & num18;
					bool flag10 = num19 < 0;
					object obj3 = (nint)array + 36;
					bool flag11 = flag8 == flag10;
					bool flag12 = !flag9;
					int num20 = ((!(flag11 && flag12)) ? 1 : num);
					object obj4 = (nint)va.Vertices + 36;
					int num21 = 0;
					do
					{
						obj4 = (nint)obj4 + 8;
						num21++;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v479 @ X14_v6-4]");
						_ = 0;
						obj3 = obj4;
						obj3 = (nint)obj3 + 8;
					}
					while (num20 != num21);
				}
				return array;
			}
			object arg = worldVerticesLength;
			string message = $"Vector2 buffer too small. {va.Name} requires an array of size {arg}. Use the attachment's .WorldVerticesLength to get the correct size.";
			ArgumentException ex = new ArgumentException(message, "buffer");
			throw ex;
		}

		[Token(Token = "0x60006D7")]
		[Address(RVA = "0x15715EC", Offset = "0x15715EC", Length = "0x1C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = System.Single[];\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, slot, buffer, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv47 = UnityEngine.Vector2[];\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, slot, buffer, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A37CEA]) = v44;\nL_001B:\n\tv48 = a.worldVerticesLength;\n\tv49 = a.worldVerticesLength >> 1;\n\tv50 = buffer == 0;\n\tv51 = ~v50;\n\tif (v51) goto L_0034;\n\t// 36 NewArr v128 @ X0_v35 (UnityEngine.Vector2[]), typeof(UnityEngine.Vector2[]), v49 @ X23_v3 (System.Int32)\nL_0034:\n\tv160 = v49 > v134.Length;\n\tif (v160) goto L_00A6;\n\t// 58 NewArr v195 @ X0_v30 (System.Single[]), typeof(System.Single[]), a.worldVerticesLength (System.Int32)\n\tSpine.VertexAttachment::ComputeWorldVertices(a, slot, v195);\n\tv88 = a.worldVerticesLength < 2;\n\tif (v88) goto L_00A2;\n\tv261 = v49 - 1;\n\tv262 = v261 < 0;\n\tv263 = v261 == 0;\n\tv264 = v49 ^ 1;\n\tv265 = v49 ^ v261;\n\tv266 = v264 & v265;\n\tv267 = v266 < 0;\n\tv72 = v134 + 0x24;\n\tv271 = v262 == v267;\n\tv82 = ~v263;\n\tv272 = v271 & v82;\n\tv69 = ~v272;\n\tif (v69) goto L_FFFFFFFF;\n\tgoto L_0064;\nL_0064:\n\tv53 = v195 + 0x24;\nL_0088:\n\tv53 = v53 + 8;\n\tv75 = v75 + 1;\n\t*([v72 @ X10_v5-4]) = *([v53 @ X12_v5-4]);\n\t*([v72 @ X10_v5]) = *([v53 @ X12_v5]);\n\tv72 = v72 + 8;\n\tv227 = v66 != v75;\n\tif (v227) goto L_0088;\nL_00A2:\n\treturn v134;\n\tv127 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\nL_00A6:\n\tv191 = 0x9DE264(a, v182, v171, v170, v29, v30, v31, v32, v163, v162, v35, v36, v37, v38, v39, v40);\n\t// 173 Box v202 @ X0_v8 (System.Object), typeof(System.Int32), &v48 @ X24_v3 (System.Int32)\n\tv258 = System.String::Format(\"Vector2 buffer too small. {0} requires an array of size {1}. Use the attachment's .WorldVerticesLength to get the correct size.\", a.<Name>k__BackingField, v202);\n\tv318 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v318, v258, \"buffer\");\n\tthrow v318;\n// 153 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector2[] GetWorldVertices(this VertexAttachment a, Slot slot, Vector2[] buffer)
		{
			//IL_0149: Expected O, but got I
			//IL_027f: Expected O, but got I
			//IL_01b2: Expected O, but got I
			//IL_01e4: Expected O, but got I
			int worldVerticesLength = a.WorldVerticesLength;
			int num = a.WorldVerticesLength >> 1;
			bool flag = buffer == null;
			bool flag2 = !flag;
			Vector2[] array = buffer;
			if (!flag2)
			{
				Vector2[] array2 = new Vector2[num];
				array = array2;
			}
			if (num <= array.Length)
			{
				float[] array3 = new float[a.WorldVerticesLength];
				a.ComputeWorldVertices(slot, array3);
				if (a.WorldVerticesLength >= 2)
				{
					int num2 = num - 1;
					bool flag3 = num2 < 0;
					bool flag4 = num2 == 0;
					int num3 = num ^ 1;
					int num4 = num ^ num2;
					int num5 = num3 & num4;
					bool flag5 = num5 < 0;
					object obj = (nint)array + 36;
					bool flag6 = flag3 == flag5;
					bool flag7 = !flag4;
					int num6 = ((!(flag6 && flag7)) ? 1 : num);
					object obj2 = (nint)array3 + 36;
					int num7 = 0;
					do
					{
						obj2 = (nint)obj2 + 8;
						num7++;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X12_v5-4]");
						_ = 0;
						obj = obj2;
						obj = (nint)obj + 8;
					}
					while (num6 != num7);
				}
				return array;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DE264");
			object arg = worldVerticesLength;
			string message = $"Vector2 buffer too small. {a.Name} requires an array of size {arg}. Use the attachment's .WorldVerticesLength to get the correct size.";
			ArgumentException ex = new ArgumentException(message, "buffer");
			throw ex;
		}

		[Token(Token = "0x60006D8")]
		[Address(RVA = "0x15717B4", Offset = "0x15717B4", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = &v29 @ stack_-20_v4 (System.Single) | 4;\n\tSpine.PointAttachment::ComputeWorldPosition(attachment, slot.bone, &v29 @ stack_-20_v4 (System.Single), v18);\n\t// 23 MakeStruct v46 @ AGG15757FC_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v29 @ stack_-20_v4 (System.Single), v67 @ stack_-1C, 0\n\treturnVal2 = UnityEngine.Transform::TransformPoint(spineGameObjectTransform, v46);\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Vector3 GetWorldPosition(this PointAttachment attachment, Slot slot, Transform spineGameObjectTransform)
		{
			//IL_0048: Expected F4, but got O
			float ox = default(float);
			ref float oy = ref *(float*)((nint)ox | 4);
			attachment.ComputeWorldPosition(slot.Bone, out ox, out oy);
			Vector3 position = default(Vector3);
			position.x = ox;
			object obj = default(object);
			position.y = (float)obj;
			position.z = 0f;
			return spineGameObjectTransform.TransformPoint(position);
		}

		[Token(Token = "0x60006D9")]
		[Address(RVA = "0x1571810", Offset = "0x1571810", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = &v14 @ stack_-20_v4 (System.Single) | 4;\n\tSpine.PointAttachment::ComputeWorldPosition(attachment, bone, &v14 @ stack_-20_v4 (System.Single), v12);\n\t// 20 MakeStruct v46 @ AGG1575850_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v14 @ stack_-20_v4 (System.Single), v41 @ stack_-1C, 0\n\treturnVal2 = UnityEngine.Transform::TransformPoint(spineGameObjectTransform, v46);\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Vector3 GetWorldPosition(this PointAttachment attachment, Bone bone, Transform spineGameObjectTransform)
		{
			//IL_0043: Expected F4, but got O
			float ox = default(float);
			attachment.ComputeWorldPosition(bone, out ox, out *(float*)((nint)ox | 4));
			Vector3 position = default(Vector3);
			position.x = ox;
			object obj = default(object);
			position.y = (float)obj;
			position.z = 0f;
			return spineGameObjectTransform.TransformPoint(position);
		}
	}
}
