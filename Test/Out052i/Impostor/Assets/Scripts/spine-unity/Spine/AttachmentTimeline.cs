using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000015")]
	public class AttachmentTimeline : Timeline, ISlotTimeline
	{
		[Token(Token = "0x4000069")]
		[FieldOffset(Offset = "0x10")]
		internal int slotIndex;

		[Token(Token = "0x400006A")]
		[FieldOffset(Offset = "0x18")]
		internal float[] frames;

		[Token(Token = "0x400006B")]
		[FieldOffset(Offset = "0x20")]
		internal string[] attachmentNames;

		[Token(Token = "0x1700001C")]
		public int PropertyId
		{
			[Token(Token = "0x600005E")]
			[Address(RVA = "0x1524844", Offset = "0x1524844", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.slotIndex + 0x4000000;\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SlotIndex + 67108864;
			}
		}

		[Token(Token = "0x1700001D")]
		public int FrameCount
		{
			[Token(Token = "0x600005F")]
			[Address(RVA = "0x1524854", Offset = "0x1524854", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.frames;\n\treturn v2.Length;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				float[] array = Frames;
				return array.Length;
			}
		}

		[Token(Token = "0x1700001E")]
		public int SlotIndex
		{
			[Token(Token = "0x6000061")]
			[Address(RVA = "0x15248CC", Offset = "0x15248CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.slotIndex;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SlotIndex;
			}
			[Token(Token = "0x6000060")]
			[Address(RVA = "0x1524870", Offset = "0x1524870", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = value & 0x80000000;\n\tv6 = v4 == 0;\n\tv7 = ~v6;\n\tif (v7) goto L_000F;\n\tthis.slotIndex = value;\n\treturn;\nL_000F:\n\tv37 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v37, \"index must be >= 0.\");\n\tthrow v37;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0012: Expected I4, but got I8
				if ((int)(value & 0x80000000L) == 0)
				{
					slotIndex = value;
					return;
				}
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("index must be >= 0.");
				throw ex;
			}
		}

		[Token(Token = "0x1700001F")]
		public float[] Frames
		{
			[Token(Token = "0x6000062")]
			[Address(RVA = "0x15248D4", Offset = "0x15248D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.frames;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Frames;
			}
			[Token(Token = "0x6000063")]
			[Address(RVA = "0x15248DC", Offset = "0x15248DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.frames = value;\n\treturn;\n")]
			set
			{
				Frames = value;
			}
		}

		[Token(Token = "0x17000020")]
		public string[] AttachmentNames
		{
			[Token(Token = "0x6000064")]
			[Address(RVA = "0x15248E4", Offset = "0x15248E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.attachmentNames;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AttachmentNames;
			}
			[Token(Token = "0x6000065")]
			[Address(RVA = "0x15248EC", Offset = "0x15248EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.attachmentNames = value;\n\treturn;\n")]
			set
			{
				AttachmentNames = value;
			}
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0x15247B8", Offset = "0x15247B8", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = System.Single[];\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, frameCount, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv49 = System.String[];\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, frameCount, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A37ADF]) = v45;\nL_001D:\n\tSystem.Object::.ctor(this);\n\t// 32 NewArr v52 @ X0_v4 (System.Single[]), typeof(System.Single[]), frameCount @ X1 (System.Int32)\n\tthis.frames = v52;\n\t// 36 NewArr v55 @ X0_v6 (System.String[]), typeof(System.String[]), frameCount @ X1 (System.Int32)\n\tthis.attachmentNames = v55;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AttachmentTimeline(int frameCount)
		{
			float[] array = new float[frameCount];
			Frames = array;
			string[] array2 = new string[frameCount];
			AttachmentNames = array2;
		}

		[Token(Token = "0x6000066")]
		[Address(RVA = "0x15248F4", Offset = "0x15248F4", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.frames;\n\tv2[frameIndex @ X1 (System.Int32)] = time;\n\tv45 = this.attachmentNames;\n\tv45[frameIndex @ X1 (System.Int32)] = attachmentName;\n\treturn;\n\tv46 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetFrame(int frameIndex, float time, string attachmentName)
		{
			float[] array = Frames;
			array[frameIndex] = time;
			string[] array2 = AttachmentNames;
			array2[frameIndex] = attachmentName;
		}

		[Token(Token = "0x6000067")]
		[Address(RVA = "0x1524944", Offset = "0x1524944", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = skeleton.slots;\n\tv93 = v10.Items;\n\tv88 = this.slotIndex;\n\tv28 = v93[v88 @ X9_v3 (System.Int32)];\n\tv95 = v28.bone;\n\tv215 = ~v95.active;\n\tif (v215) goto L_0038;\n\tv24 = direction != 1;\n\tif (v24) goto L_0039;\n\tv227 = blend == 0;\n\tif (v227) goto L_0059;\nL_0038:\n\treturn;\nL_0039:\n\tv19 = this.frames;\n\tv242 = v19[0] <= time;\n\tif (v242) goto L_005E;\n\tv247 = blend < 1;\n\tv226 = ~v247;\n\tv225 = blend - 1;\n\tv223 = v225 == 0;\n\tv248 = ~v223;\n\tv218 = v226 & v248;\n\tif (v218) goto L_0038;\nL_0059:\n\tv97 = v28.data;\n\tv157 = v97.attachmentName;\n\tgoto L_008A;\nL_005E:\n\tv98 = v19.Length - 1;\n\tv252 = v19[v98 @ X8_v14 (System.Int32)] < time;\n\tv80 = ~v252;\n\tv74 = v19[v98 @ X8_v14 (System.Int32)] - time;\n\tv62 = v74 == 0;\n\tv253 = ~v80;\n\tv26 = v253 | v62;\n\tif (v26) goto L_0071;\n\tv255 = Spine.Animation::BinarySearch(v19, time);\n\tv98 = v255 - 1;\nL_0071:\n\tv89 = this.attachmentNames;\nL_008A:\n\tSpine.AttachmentTimeline::SetAttachment(this, skeleton, v93[v88 @ X9_v3 (System.Int32)], v157);\n\treturn;\n\tv106 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 102 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
			ExposedList<Slot> slots = skeleton.Slots;
			Slot[] items = slots.Items;
			int num = SlotIndex;
			Slot slot = items[num];
			Bone bone = slot.Bone;
			if (!bone.Active)
			{
				return;
			}
			string attachmentName;
			if (direction == MixDirection.Out)
			{
				if (blend != MixBlend.Setup)
				{
					return;
				}
			}
			else
			{
				float[] array = Frames;
				if (!(array[0] > time))
				{
					int num2 = array.Length - 1;
					bool flag = array[num2] < time;
					bool flag2 = !flag;
					float num3 = array[num2] - time;
					bool flag3 = num3 == 0f;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						int num4 = Animation.BinarySearch(array, time);
						num2 = num4 - 1;
					}
					string[] array2 = AttachmentNames;
					attachmentName = array2[num2];
					goto IL_022f;
				}
				bool flag5 = blend < MixBlend.First;
				bool flag6 = !flag5;
				int num5 = (int)(blend - 1);
				bool flag7 = num5 == 0;
				bool flag8 = !flag7;
				if (flag6 && flag8)
				{
					return;
				}
			}
			SlotData data = slot.Data;
			attachmentName = data.AttachmentName;
			goto IL_022f;
			IL_022f:
			SetAttachment(skeleton, items[num], attachmentName);
		}

		[Token(Token = "0x6000068")]
		[Address(RVA = "0x1524A3C", Offset = "0x1524A3C", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = attachmentName == 0;\n\tif (v6) goto L_0019;\n\tv19 = Spine.Skeleton::GetAttachment(skeleton, this.slotIndex, attachmentName);\nL_0016:\n\tSpine.Slot::set_Attachment(slot, v42);\n\treturn;\nL_0019:\n\tv11 = slot == 0;\n\tv12 = ~v11;\n\tif (v12) goto L_0016;\n\tthrow System.NullReferenceException;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetAttachment(Skeleton skeleton, Slot slot, string attachmentName)
		{
			Attachment attachment2;
			if (attachmentName != null)
			{
				Attachment attachment = skeleton.GetAttachment(SlotIndex, attachmentName);
				attachment2 = attachment;
			}
			else
			{
				bool flag = slot == null;
				bool flag2 = !flag;
				attachment2 = null;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			slot.Attachment = attachment2;
		}
	}
}
