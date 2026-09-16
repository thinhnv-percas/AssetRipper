using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000066")]
	public static class SpineSkeletonExtensions
	{
		[Token(Token = "0x6000474")]
		[Address(RVA = "0x1550654", Offset = "0x1550654", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = va.bones;\n\tv5 = va.bones == 0;\n\tif (v5) goto L_FFFFFFFF;\n\tv27 = v4.Length == 0;\n\tv32 = ~v27;\n\tgoto L_0017;\nL_0017:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsWeighted(this VertexAttachment va)
		{
			int[] bones = va.Bones;
			if (va.Bones != null)
			{
				bool flag = bones.Length == 0;
				return !flag;
			}
			return false;
		}

		[Token(Token = "0x6000475")]
		[Address(RVA = "0x1550684", Offset = "0x1550684", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Spine.IHasRendererObject;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37BC8]) = v37;\nL_0015:\n\t// 21 IsInst v40 @ X0_v3, typeof(Spine.IHasRendererObject), a @ X0 (Spine.Attachment)\n\tv47 = v40 == 0;\n\tv52 = ~v47;\n\treturn v52;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsRenderable(this Attachment a)
		{
			object obj = a as IHasRendererObject;
			bool flag = obj == null;
			return !flag;
		}

		[Token(Token = "0x6000476")]
		[Address(RVA = "0x15506D8", Offset = "0x15506D8", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = mode & 1;\n\tv3 = v0 == 0;\n\treturn v3;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool InheritsRotation(this TransformMode mode)
		{
			int num = (int)(mode & TransformMode.NoRotationOrReflection);
			return num == 0;
		}

		[Token(Token = "0x6000477")]
		[Address(RVA = "0x15506E4", Offset = "0x15506E4", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = mode & 2;\n\tv3 = v0 == 0;\n\treturn v3;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool InheritsScale(this TransformMode mode)
		{
			int num = (int)(mode & TransformMode.NoScale);
			return num == 0;
		}

		[Token(Token = "0x6000478")]
		[Address(RVA = "0x15506F0", Offset = "0x15506F0", Length = "0x358")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, propertyID, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A37BC9]) = v36;\nL_0012:\n\tv37 = propertyID >> 0x18;\n\tv38 = v37 < 0xE;\n\tv39 = ~v38;\n\tv40 = v37 - 0xE;\n\tv42 = v40 == 0;\n\tv47 = ~v42;\n\tv48 = v39 & v47;\n\tif (v48) goto L_018F;\n\tv50 = 0x44C000 + 0xD54;\n\tv53 = *([v50 @ X9_v2 (System.Int32)+v37 @ X8_v3 (System.Int32)]) << 2;\n\tv54 = 0x1554748 + v53;\n\tv55 = propertyID & 0xFFFFFF;\n\t// 38 IndirectJump v54 @ X10_v2 (System.Int32), v34 @ X0_v1 (Spine.Skeleton), v34 @ X0_v1 (Spine.Skeleton), v55 @ X1_v1 (System.Int32), methodInfo @ X2 (Il2CppMethodInfo), v21 @ X3, v22 @ X4, v23 @ X5, v24 @ X6, v25 @ X7, v26 @ V0, v27 @ V1, v28 @ V2, v29 @ V3, v30 @ V4, v31 @ V5, v32 @ V6, v33 @ V7\n\tif (TEMP) goto L_0190;\n\tX8 = *([X19+20]);\n\tif (TEMP) goto L_0190;\n\tX8 = *([X8+10]);\n\tif (TEMP) goto L_0190;\n\tX9 = *([X8+18]);\n\tC = X1 < X9;\n\tC = ~C;\n\tTEMP1 = X1 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ X9;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0191;\n\tTEMPSHIFT = X1 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX0 = *([X8+20]);\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX30 = stack[0];\n\tX21 = stack[8];\n\t// 65 ShiftStack 32\n\tSpine.SpineSkeletonExtensions::SetColorToSetupPose(X0, X1);\n\treturn;\n\tif (TEMP) goto L_0190;\n\tX8 = *([X19+18]);\n\tif (TEMP) goto L_0190;\n\tX8 = *([X8+10]);\n\tif (TEMP) goto L_0190;\n\tX9 = *([X8+18]);\n\tC = X1 < X9;\n\tC = ~C;\n\tTEMP1 = X1 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ X9;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0191;\n\tTEMPSHIFT = X1 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8+20]);\n\tif (TEMP) goto L_0190;\n\tX9 = *([X8+10]);\n\tif (TEMP) goto L_0190;\n\tV0 = *([X9+34]);\n\t*([X8+38]) = V0;\n\tgoto L_018F;\n\tif (TEMP) goto L_0190;\n\tX8 = *([X19+18]);\n\tif (TEMP) goto L_0190;\n\tX8 = *([X8+10]);\n\tif (TEMP) goto L_0190;\n\tX9 = *([X8+18]);\n\tC = X1 < X9;\n\tC = ~C;\n\tTEMP1 = X1 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ X9;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0191;\n\tTEMPSHIFT = X1 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8+20]);\n\tif (TEMP) goto L_0190;\n\tX9 = *([X8+10]);\n\tif (TEMP) goto L_0190;\n\tV0 = *([X9+2C]);\n\tgoto L_0189;\n\tif (TEMP) goto L_0190;\n\tX8 = *([X19+18]);\n\tif (TEMP) goto L_0190;\n\tX8 = *([X8+10]);\n\tif (TEMP) goto L_0190;\n\tX9 = *([X8+18]);\n\tC = X1 < X9;\n\tC = ~C;\n\tTEMP1 = X1 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ X9;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0191;\n\tTEMPSHIFT = X1 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8+20]);\n\tif (TEMP) goto L_0190;\n\tX9 = *([X8+10]);\n\tif (TEMP) goto L_0190;\n\tV0 = *([X9+38]);\n\t*([X8+3C]) = V0;\n\tgoto L_018F;\n\tif (TEMP) goto L_0190;\n\tX8 = *([X19+18]);\n\tif (TEMP) goto L_0190;\n\tX8 = *([X8+10]);\n\tif (TEMP) goto L_0190;\n\tX9 = *([X8+18]);\n\tC = X1 < X9;\n\tC = ~C;\n\tTEMP1 = X1 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ X9;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0191;\n\tTEMPSHIFT = X1 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8+20]);\n\tif (TEMP) goto L_0190;\n\tX9 = *([X8+10]);\n\tif (TEMP) goto L_0190;\n\tV0 = *([X9+40]);\n\t*([X8+44]) = V0;\n\tgoto L_018F;\n\tX0 = X19;\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX30 = stack[0];\n\tX21 = stack[8];\n\t// 192 ShiftStack 32\n\tSpine.SpineSkeletonExtensions::SetSlotAttachmentToSetupPose(X0, X1, X2);\n\treturn;\n\tif (TEMP) goto L_0190;\n\tX8 = *([X19+20]);\n\tif (TEMP) goto L_0190;\n\tX8 = *([X8+10]);\n\tif (TEMP) goto L_0190;\n\tX9 = *([X8+18]);\n\tC = X1 < X9;\n\tC = ~C;\n\tTEMP1 = X1 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ X9;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0191;\n\tTEMPSHIFT = X1 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8+20]);\n\tif (TEMP) goto L_0190;\n\tX0 = *([X8+50]);\n\tif (TEMP) goto L_0190;\n\tX8 = *([1946750]);\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX1 = 1;\n\tX2 = *([X8]);\n\tX30 = stack[0];\n\tX21 = stack[8];\n\t// 230 ShiftStack 32\n\tSpine.ExposedList`1<System.Single>::Clear(X0, X1, X2);\n\treturn;\n\tX0 = X19;\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX30 = stack[0];\n\tX21 = stack[8];\n\t// 238 ShiftStack 32\n\tSpine.SpineSkeletonExtensions::SetDrawOrderToSetupPose(X0, X1);\n\treturn;\n\tif (TEMP) goto L_0190;\n\tX8 = *([X19+30]);\n\tif (TEMP) goto L_0190;\n\tX8 = *([X8+10]);\n\tif (TEMP) goto L_0190;\n\tX9 = *([X8+18]);\n\tC = X1 < X9;\n\tC = ~C;\n\tTEMP1 = X1 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ X9;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0191;\n\tTEMPSHIFT = X1 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8+20]);\n\tif (TEMP) goto L_0190;\n\tX9 = *([X8+10]);\n\tif (TEMP) goto L_0190;\n\tV0 = *([X9+38]);\n\t*([X8+30]) = V0;\n\tX10 = *([X9+30]);\n\t*([X8+28]) = X10;\n\tX9 = *([X9+35]);\n\t*([X8+2D]) = X9;\n\tgoto L_018F;\n\tif (TEMP) goto L_0190;\n\tX8 = *([X19+38]);\n\tif (TEMP) goto L_0190;\n\tX8 = *([X8+10]);\n\tif (TEMP) goto L_0190;\n\tX9 = *([X8+18]);\n\tC = X1 < X9;\n\tC = ~C;\n\tTEMP1 = X1 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ X9;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0191;\n\tTEMPSHIFT = X1 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8+20]);\n\tif (TEMP) goto L_0190;\n\tX9 = *([X8+10]);\n\tif (TEMP) goto L_0190;\n\tV0 = *([X9+30]);\n\t*([X8+28]) = V0;\n\tgoto L_018F;\n\tif (TEMP) goto L_0190;\n\tX8 = *([X19+40]);\n\tif (TEMP) goto L_0190;\n\tX8 = *([X8+10]);\n\tif (TEMP) goto L_0190;\n\tX9 = *([X8+18]);\n\tC = X1 < X9;\n\tC = ~C;\n\tTEMP1 = X1 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ X9;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0191;\n\tTEMPSHIFT = X1 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8+20]);\n\tif (TEMP) goto L_0190;\n\tX9 = *([X8+10]);\n\tif (TEMP) goto L_0190;\n\tV0 = *([X9+40]);\n\t*([X8+28]) = V0;\n\tgoto L_018F;\n\tif (TEMP) goto L_0190;\n\tX8 = *([X19+40]);\n\tif (TEMP) goto L_0190;\n\tX8 = *([X8+10]);\n\tif (TEMP) goto L_0190;\n\tX9 = *([X8+18]);\n\tC = X1 < X9;\n\tC = ~C;\n\tTEMP1 = X1 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ X9;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0191;\n\tTEMPSHIFT = X1 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8+20]);\n\tif (TEMP) goto L_0190;\n\tX9 = *([X8+10]);\n\tif (TEMP) goto L_0190;\n\tV0 = *([X9+44]);\n\t*([X8+2C]) = V0;\n\tgoto L_018F;\n\tif (TEMP) goto L_0190;\n\tX8 = *([X19+40]);\n\tif (TEMP) goto L_0190;\n\tX8 = *([X8+10]);\n\tif (TEMP) goto L_0190;\n\tX9 = *([X8+18]);\n\tC = X1 < X9;\n\tC = ~C;\n\tTEMP1 = X1 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ X9;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0191;\n\tTEMPSHIFT = X1 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8+20]);\n\tif (TEMP) goto L_0190;\n\tX9 = *([X8+10]);\n\tif (TEMP) goto L_0190;\n\tV0 = *([X9+48]);\nL_0189:\n\t*([X8+30]) = V0;\nL_018F:\n\treturn;\nL_0190:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0191:\n\tX0 = IndexOutOfRangeException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void SetPropertyToSetupPose(this Skeleton skeleton, int propertyID)
		{
			while (true)
			{
				int num = propertyID >> 24;
				bool flag = num < 14;
				bool flag2 = !flag;
				int num2 = num - 14;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					int num3 = 4505600 + 3412;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X9_v2 (System.Int32)+v37 @ X8_v3 (System.Int32)]");
					int num4 = (int)((nint)0 << 2);
					int num5 = 22366024 + num4;
					int num6 = propertyID & 0xFFFFFF;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v54 @ X10_v2 (System.Int32) (should have been resolved before IL gen)");
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x6000479")]
		[Address(RVA = "0x1550B14", Offset = "0x1550B14", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv41 = Il2CppMethodInfo;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37BCA]) = v38;\nL_0017:\n\tv42 = skeleton.slots;\n\tv47 = skeleton.drawOrder;\n\tSpine.ExposedList`1<Spine.Slot>::Clear(skeleton.drawOrder, 0);\n\tSpine.ExposedList`1<Spine.Slot>::EnsureCapacity(skeleton.drawOrder, v42.Count);\n\tv47.Count = v42.Count;\n\tSystem.Array::Copy(v42.Items, v47.Items, v42.Count);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetDrawOrderToSetupPose(this Skeleton skeleton)
		{
			ExposedList<Slot> slots = skeleton.Slots;
			ExposedList<Slot> drawOrder = skeleton.DrawOrder;
			skeleton.DrawOrder.Clear(clearArray: false);
			skeleton.DrawOrder.EnsureCapacity(slots.Count);
			drawOrder.Count = slots.Count;
			Array.Copy(slots.Items, drawOrder.Items, slots.Count);
		}

		[Token(Token = "0x600047A")]
		[Address(RVA = "0x1550BC4", Offset = "0x1550BC4", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv146 = skeleton.slots;\n\tv81 = v146.Items;\nL_001B:\n\tv20 = v79 >= v146.Count;\n\tif (v20) goto L_0050;\n\tv41 = v81[v79 @ X20_v5 (System.Int32)];\n\tv88 = v41.data;\n\tv174 = System.String::IsNullOrEmpty(v88.attachmentName);\n\tv177 = v174 == 0;\n\tv178 = ~v177;\n\tif (v178) goto L_0041;\n\tv183 = Spine.Skeleton::GetAttachment(skeleton, v79, v88.attachmentName);\nL_0041:\n\tSpine.Slot::set_Attachment(v81[v79 @ X20_v5 (System.Int32)], v34);\n\tv146 = skeleton.slots;\n\tv79 = v79 + 1;\n\tv187 = skeleton.slots == 0;\n\tv90 = ~v187;\n\tif (v90) goto L_001B;\n\tthrow System.NullReferenceException;\nL_0050:\n\treturn;\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetSlotAttachmentsToSetupPose(this Skeleton skeleton)
		{
			ExposedList<Slot> slots = skeleton.Slots;
			Slot[] items = slots.Items;
			int num = 0;
			while (num < slots.Count)
			{
				Slot slot = items[num];
				SlotData data = slot.Data;
				bool flag = string.IsNullOrEmpty(data.AttachmentName);
				bool flag2 = !flag;
				bool flag3 = !flag2;
				Attachment attachment = null;
				if (!flag3)
				{
					Attachment attachment2 = skeleton.GetAttachment(num, data.AttachmentName);
					attachment = attachment2;
				}
				items[num].Attachment = attachment;
				slots = skeleton.Slots;
				num++;
				if (skeleton.Slots == null)
				{
					throw new NullReferenceException();
				}
			}
		}

		[Token(Token = "0x600047B")]
		[Address(RVA = "0x1550AE0", Offset = "0x1550AE0", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = slot.data;\n\tslot.r = v4.r;\n\tslot.r2 = v4.r2;\n\tslot.b2 = v4.b2;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetColorToSetupPose(this Slot slot)
		{
			SlotData data = slot.Data;
			slot.R = data.R;
			slot.R2 = data.R2;
			slot.B2 = data.B2;
		}

		[Token(Token = "0x600047C")]
		[Address(RVA = "0x1550C80", Offset = "0x1550C80", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = slot.bone;\n\tv13 = slot.data;\n\tv53 = Spine.Skeleton::GetAttachment(v6.skeleton, v13.name, v13.attachmentName);\n\tSpine.Slot::set_Attachment(slot, v53);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetAttachmentToSetupPose(this Slot slot)
		{
			Bone bone = slot.Bone;
			SlotData data = slot.Data;
			Attachment attachment = bone.Skeleton.GetAttachment(data.Name, data.AttachmentName);
			slot.Attachment = attachment;
		}

		[Token(Token = "0x600047D")]
		[Address(RVA = "0x1550A48", Offset = "0x1550A48", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = skeleton.slots;\n\tv55 = v12.Items;\n\tv16 = v55[slotIndex @ X1 (System.Int32)];\n\tv57 = v16.data;\n\tv133 = System.String::IsNullOrEmpty(v57.attachmentName);\n\tv136 = v133 == 0;\n\tv129 = ~v136;\n\tif (v129) goto L_003C;\n\tv141 = Spine.Skeleton::GetAttachment(skeleton, slotIndex, v57.attachmentName);\nL_003C:\n\tSpine.Slot::set_Attachment(v55[slotIndex @ X1 (System.Int32)], v107);\n\treturn;\n\tv62 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetSlotAttachmentToSetupPose(this Skeleton skeleton, int slotIndex)
		{
			ExposedList<Slot> slots = skeleton.Slots;
			Slot[] items = slots.Items;
			Slot slot = items[slotIndex];
			SlotData data = slot.Data;
			bool flag = string.IsNullOrEmpty(data.AttachmentName);
			bool flag2 = !flag;
			bool flag3 = !flag2;
			Attachment attachment = null;
			if (!flag3)
			{
				Attachment attachment2 = skeleton.GetAttachment(slotIndex, data.AttachmentName);
				attachment = attachment2;
			}
			items[slotIndex].Attachment = attachment;
		}

		[Token(Token = "0x600047E")]
		[Address(RVA = "0x1550CCC", Offset = "0x1550CCC", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Animation::Apply(animation, skeleton, 0f, 0f, 0, 0, 0f, 0, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetKeyedItemsToSetupPose(this Animation animation, Skeleton skeleton)
		{
			animation.Apply(skeleton, 0f, 0f, loop: false, null, 0f, default(MixBlend), MixDirection.Out);
		}

		[Token(Token = "0x600047F")]
		[Address(RVA = "0x1550CFC", Offset = "0x1550CFC", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = trackEntry.nextTrackLast >= 0;\n\tif (v14) goto L_0013;\n\ttrackEntry.nextTrackLast = 0f;\nL_0013:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AllowImmediateQueue(this TrackEntry trackEntry)
		{
			if (trackEntry.nextTrackLast < 0f)
			{
				trackEntry.nextTrackLast = 0f;
			}
		}
	}
}
