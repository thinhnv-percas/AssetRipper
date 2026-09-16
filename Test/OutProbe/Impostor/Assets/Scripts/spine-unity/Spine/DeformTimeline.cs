using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000016")]
	public class DeformTimeline : CurveTimeline, ISlotTimeline
	{
		[Token(Token = "0x400006C")]
		[FieldOffset(Offset = "0x18")]
		internal int slotIndex;

		[Token(Token = "0x400006D")]
		[FieldOffset(Offset = "0x20")]
		internal VertexAttachment attachment;

		[Token(Token = "0x400006E")]
		[FieldOffset(Offset = "0x28")]
		internal float[] frames;

		[Token(Token = "0x400006F")]
		[FieldOffset(Offset = "0x30")]
		internal float[][] frameVertices;

		[Token(Token = "0x17000021")]
		public override int PropertyId
		{
			[Token(Token = "0x600006A")]
			[Address(RVA = "0x1524B14", Offset = "0x1524B14", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.attachment;\n\tv7 = v2.id + this.slotIndex;\n\treturnVal1 = v7 + 0x30000000;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				VertexAttachment vertexAttachment = Attachment;
				int num = vertexAttachment.Id + SlotIndex;
				return num + 805306368;
			}
		}

		[Token(Token = "0x17000022")]
		public int SlotIndex
		{
			[Token(Token = "0x600006C")]
			[Address(RVA = "0x1524B9C", Offset = "0x1524B9C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.slotIndex;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SlotIndex;
			}
			[Token(Token = "0x600006B")]
			[Address(RVA = "0x1524B40", Offset = "0x1524B40", Length = "0x5C")]
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

		[Token(Token = "0x17000023")]
		public VertexAttachment Attachment
		{
			[Token(Token = "0x600006D")]
			[Address(RVA = "0x1524BA4", Offset = "0x1524BA4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.attachment;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Attachment;
			}
			[Token(Token = "0x600006E")]
			[Address(RVA = "0x1524BAC", Offset = "0x1524BAC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.attachment = value;\n\treturn;\n")]
			set
			{
				Attachment = value;
			}
		}

		[Token(Token = "0x17000024")]
		public float[] Frames
		{
			[Token(Token = "0x600006F")]
			[Address(RVA = "0x1524BB4", Offset = "0x1524BB4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.frames;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Frames;
			}
			[Token(Token = "0x6000070")]
			[Address(RVA = "0x1524BBC", Offset = "0x1524BBC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.frames = value;\n\treturn;\n")]
			set
			{
				Frames = value;
			}
		}

		[Token(Token = "0x17000025")]
		public float[][] Vertices
		{
			[Token(Token = "0x6000071")]
			[Address(RVA = "0x1524BC4", Offset = "0x1524BC4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.frameVertices;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Vertices;
			}
			[Token(Token = "0x6000072")]
			[Address(RVA = "0x1524BCC", Offset = "0x1524BCC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.frameVertices = value;\n\treturn;\n")]
			set
			{
				Vertices = value;
			}
		}

		[Token(Token = "0x6000069")]
		[Address(RVA = "0x1524A88", Offset = "0x1524A88", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = System.Single[][];\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, frameCount, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv49 = System.Single[];\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, frameCount, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A37AE0]) = v45;\nL_001D:\n\tSpine.CurveTimeline::.ctor(this, frameCount);\n\t// 32 NewArr v52 @ X0_v4 (System.Single[]), typeof(System.Single[]), frameCount @ X1 (System.Int32)\n\tthis.frames = v52;\n\t// 36 NewArr v55 @ X0_v6 (System.Single[][]), typeof(System.Single[][]), frameCount @ X1 (System.Int32)\n\tthis.frameVertices = v55;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DeformTimeline(int frameCount)
			: base(frameCount)
		{
			float[] array = new float[frameCount];
			Frames = array;
			float[][] vertices = new float[frameCount][];
			Vertices = vertices;
		}

		[Token(Token = "0x6000073")]
		[Address(RVA = "0x1524BD4", Offset = "0x1524BD4", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.frames;\n\tv2[frameIndex @ X1 (System.Int32)] = time;\n\tv45 = this.frameVertices;\n\tv45[frameIndex @ X1 (System.Int32)] = vertices;\n\treturn;\n\tv46 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetFrame(int frameIndex, float time, float[] vertices)
		{
			float[] array = Frames;
			array[frameIndex] = time;
			float[][] vertices2 = Vertices;
			vertices2[frameIndex] = vertices;
		}

		[Token(Token = "0x6000074")]
		[Address(RVA = "0x1524C24", Offset = "0x1524C24", Length = "0xB24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv40 = Il2CppMethodInfo;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, skeleton, firedEvents, blend, direction, methodInfo, v45, v46, lastTime, time, alpha, v48, v49, v50, v51, v52);\n\tv59 = Il2CppMethodInfo;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, skeleton, firedEvents, blend, direction, methodInfo, v45, v46, lastTime, time, alpha, v48, v49, v50, v51, v52);\n\tv824 = Il2CppMethodInfo;\n\tv825 = \"il2cpp_codegen_initialize_runtime_metadata\"(v824, skeleton, firedEvents, blend, direction, methodInfo, v45, v46, lastTime, time, alpha, v48, v49, v50, v51, v52);\n\tv1104 = Spine.VertexAttachment;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1104, skeleton, firedEvents, blend, direction, methodInfo, v45, v46, lastTime, time, alpha, v48, v49, v50, v51, v52);\n\tv56 = 1;\n\t*([1A37AE1]) = v56;\nL_0028:\n\tv61 = skeleton.slots;\n\tv789 = v61.Items;\n\tv698 = this.slotIndex;\n\tv790 = v789[v698 @ X9_v3 (System.Int32)];\n\tv699 = v790.bone;\n\tv1245 = ~v699.active;\n\tif (v1245) goto L_0089;\n\tv1246 = v790.attachment == 0;\n\tif (v1246) goto L_0089;\n\tgoto L_FFFFFFFF;\n\tv153 = v153_asT == 0;\n\tif (v153) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv157 = v157_asT == 0;\n\tif (v157) goto L_0089;\n\tv469 = *([v150 @ X24_v5 (Spine.Attachment)+38]) == this.attachment;\n\tif (v469) goto L_008A;\nL_0089:\n\treturn;\nL_008A:\n\tv782 = v790.deform;\n\tv142 = this.frameVertices;\n\tv154 = v782.Count != 0;\n\tif (v154) goto L_FFFFFFFF;\n\tgoto L_00A3;\nL_00A3:\n\tv791 = v142[0];\n\tv820 = this.frames;\n\tv148 = v791.Length & 0xFFFFFFFF;\n\tv1295 = v820[0] <= time;\n\tif (v1295) goto L_00CD;\n\tv1401 = v144 == 1;\n\tif (v1401) goto L_0209;\n\tv1484 = v144 == 0;\n\tif (v1484) goto L_021D;\n\tgoto L_0089;\nL_00CD:\n\tv1543 = Spine.ExposedList`1<System.Single>::get_Capacity(v782);\n\tv852 = v1543 >= v791.Length;\n\tif (v852) goto L_00DF;\n\tSpine.ExposedList`1<System.Single>::set_Capacity(v782, v791.Length);\nL_00DF:\n\tv782.Count = v791.Length;\n\tv1577 = v820.Length - 1;\n\tv1579 = v820[v1577 @ X8_v17] < time;\n\tv1580 = ~v1579;\n\tv1581 = v820[v1577 @ X8_v17] - time;\n\tv1583 = v1581 == 0;\n\tv1588 = ~v1580;\n\tv853 = v1588 | v1583;\n\tif (v853) goto L_01B5;\n\tv1071 = Spine.Animation::BinarySearch(v820, time);\n\tv1098 = v1071 - 1;\n\tv146 = v142[v1098 @ X8_v45 (System.Int32)];\n\tv821 = v142[v1071 @ X0_v12 (System.Int32)];\n\tv94 = time - v820[v1071 @ X0_v12 (System.Int32)];\n\tv1661 = v820[v1098 @ X8_v45 (System.Int32)] - v820[v1071 @ X0_v12 (System.Int32)];\n\tv1662 = v94 / v1661;\n\tv1663 = 1f - v1662;\n\tv130 = Spine.CurveTimeline::GetCurvePercent(this, v1098, v1663);\n\tv1679 = alpha != 1f;\n\tif (v1679) goto L_021F;\n\tv1708 = v144 != 3;\n\tif (v1708) goto L_02E9;\n\tv1485 = *([v150 @ X24_v5 (Spine.Attachment)+20]) == 0;\n\tif (v1485) goto L_0419;\n\tv158 = v791.Length < 1;\n\tif (v158) goto L_0089;\n\tv234 = v782.Items + 0x20;\nL_018B:\n\tv1931 = v821[v793 @ X8_v75 (System.Int32)] - v146[v793 @ X8_v75 (System.Int32)];\n\tv1255 = v130 * v1931;\n\tv1932 = v146[v793 @ X8_v75 (System.Int32)] + v1255;\n\tv1265 = *([v234 @ X11_v22+v793 @ X8_v75 (System.Int32)*4]) + v1932;\n\t*([v234 @ X11_v22+v793 @ X8_v75 (System.Int32)*4]) = v1265;\n\tv793 = v793 + 1;\n\tv1296 = v148 != v793;\n\tif (v1296) goto L_018B;\n\tgoto L_0089;\nL_01B5:\n\tv1610 = alpha != 1f;\n\tif (v1610) goto L_0288;\n\tv1165 = v144 != 3;\n\tif (v1165) goto L_033B;\n\tv1486 = *([v150 @ X24_v5 (Spine.Attachment)+20]) == 0;\n\tif (v1486) goto L_0476;\n\tv160 = v791.Length < 1;\n\tif (v160) goto L_0089;\n\tv680 = v782.Items + 0x20;\n\tv235 = v142[v1577 @ X8_v17] + 0x20;\nL_01F0:\n\tv1281 = *([v680 @ X10_v16+v795 @ X8_v43 (System.Int32)*4]) + *([v235 @ X11_v14+v795 @ X8_v43 (System.Int32)*4]);\n\t*([v680 @ X10_v16+v795 @ X8_v43 (System.Int32)*4]) = v1281;\n\tv795 = v795 + 1;\n\tv1297 = v148 != v795;\n\tif (v1297) goto L_01F0;\n\tgoto L_0089;\nL_0209:\n\tv1553 = alpha != 1f;\n\tif (v1553) goto L_0341;\nL_021D:\n\tSpine.ExposedList`1<System.Single>::Clear(v782, 1);\n\treturn;\nL_021F:\n\tv803 = v144 - 1;\n\tv1709 = v803 < 2;\n\tv1710 = ~v1709;\n\tv1718 = ~v1710;\n\tif (v1718) goto L_038F;\n\tv1487 = v144 == 0;\n\tif (v1487) goto L_04EC;\n\tv1298 = v144 != 3;\n\tif (v1298) goto L_0089;\n\tv1488 = *([v150 @ X24_v5 (Spine.Attachment)+20]) == 0;\n\tif (v1488) goto L_057F;\n\tv162 = v791.Length < 1;\n\tif (v162) goto L_0089;\n\tv236 = v782.Items + 0x20;\nL_0275:\n\tv1952 = v821[v797 @ X8_v65 (System.Int32)] - v146[v797 @ X8_v65 (System.Int32)];\n\tv1256 = v130 * v1952;\n\tv1953 = v146[v797 @ X8_v65 (System.Int32)] + v1256;\n\tv1954 = v1953 * alpha;\n\tv1267 = *([v236 @ X11_v19+v797 @ X8_v65 (System.Int32)*4]) + v1954;\n\t*([v236 @ X11_v19+v797 @ X8_v65 (System.Int32)*4]) = v1267;\n\tv797 = v797 + 1;\n\tv1299 = v148 != v797;\n\tif (v1299) goto L_0275;\n\tgoto L_0089;\nL_0288:\n\tv805 = v144 - 1;\n\tv1613 = v805 < 2;\n\tv1614 = ~v1613;\n\tv1622 = ~v1614;\n\tif (v1622) goto L_03DD;\n\tv1489 = v144 == 0;\n\tif (v1489) goto L_053A;\n\tv1300 = v144 != 3;\n\tif (v1300) goto L_0089;\n\tv1490 = *([v150 @ X24_v5 (Spine.Attachment)+20]) == 0;\n\tif (v1490) goto L_05DD;\n\tv164 = v791.Length < 1;\n\tif (v164) goto L_0089;\n\tv682 = v782.Items + 0x20;\n\tv237 = v142[v1577 @ X8_v17] + 0x20;\nL_02CF:\n\tv1856 = *([v237 @ X11_v12+v799 @ X8_v36 (System.Int32)*4]) * alpha;\n\tv1282 = *([v682 @ X10_v14+v799 @ X8_v36 (System.Int32)*4]) + v1856;\n\t*([v682 @ X10_v14+v799 @ X8_v36 (System.Int32)*4]) = v1282;\n\tv799 = v799 + 1;\n\tv1301 = v148 != v799;\n\tif (v1301) goto L_02CF;\n\tgoto L_0089;\nL_02E9:\n\tv166 = v791.Length < 1;\n\tif (v166) goto L_0089;\n\tv683 = v782.Items + 0x20;\nL_0318:\n\tv1918 = v821[v801 @ X8_v68 (System.Int32)] - v146[v801 @ X8_v68 (System.Int32)];\n\tv1257 = v130 * v1918;\n\tv1269 = v146[v801 @ X8_v68 (System.Int32)] + v1257;\n\t*([v683 @ X10_v23+v801 @ X8_v68 (System.Int32)*4]) = v1269;\n\tv801 = v801 + 1;\n\tv1302 = v148 != v801;\n\tif (v1302) goto L_0318;\n\tgoto L_0089;\nL_033B:\n\tSystem.Array::Copy(v142[v1577 @ X8_v17], 0, v782.Items, 0, v791.Length);\n\treturn;\nL_0341:\n\tv1560 = Spine.ExposedList`1<System.Single>::get_Capacity(v782);\n\tv1576 = v1560 >= v791.Length;\n\tif (v1576) goto L_0353;\n\tSpine.ExposedList`1<System.Single>::set_Capacity(v782, v791.Length);\nL_0353:\n\tv782.Count = v791.Length;\n\tv239 = v782.Items;\n\tv1491 = *([v150 @ X24_v5 (Spine.Attachment)+20]) == 0;\n\tif (v1491) goto L_04B8;\n\tv168 = v791.Length < 1;\n\tif (v168) goto L_0089;\n\tv844 = 1f - alpha;\nL_0376:\n\tv1270 = v844 * v239[v1100 @ X8_v89 (System.Int32)];\n\tv239[v1100 @ X8_v89 (System.Int32)] = v1270;\n\tv1100 = v1100 + 1;\n\tv1303 = v148 != v1100;\n\tif (v1303) goto L_0376;\n\tgoto L_0089;\nL_038F:\n\tv169 = v791.Length < 1;\n\tif (v169) goto L_0089;\n\tv240 = v782.Items + 0x20;\nL_03BF:\n\tv1924 = v821[v804 @ X8_v51 (System.Int32)] - v146[v804 @ X8_v51 (System.Int32)];\n\tv1258 = v130 * v1924;\n\tv1925 = v146[v804 @ X8_v51 (System.Int32)] + v1258;\n\tv1926 = v1925 - *([v240 @ X11_v15+v804 @ X8_v51 (System.Int32)*4]);\n\tv1927 = v1926 * alpha;\n\tv1271 = *([v240 @ X11_v15+v804 @ X8_v51 (System.Int32)*4]) + v1927;\n\t*([v240 @ X11_v15+v804 @ X8_v51 (System.Int32)*4]) = v1271;\n\tv804 = v804 + 1;\n\tv1304 = v148 != v804;\n\tif (v1304) goto L_03BF;\n\tgoto L_0089;\nL_03DD:\n\tv171 = v791.Length < 1;\n\tif (v171) goto L_0089;\n\tv685 = v782.Items + 0x20;\n\tv241 = v142[v1577 @ X8_v17] + 0x20;\nL_03FE:\n\tv1791 = *([v241 @ X11_v8+v806 @ X8_v22 (System.Int32)*4]) - *([v685 @ X10_v9+v806 @ X8_v22 (System.Int32)*4]);\n\tv1272 = v1791 * alpha;\n\tv1283 = *([v685 @ X10_v9+v806 @ X8_v22 (System.Int32)*4]) + v1272;\n\t*([v685 @ X10_v9+v806 @ X8_v22 (System.Int32)*4]) = v1283;\n\tv806 = v806 + 1;\n\tv1305 = v148 != v806;\n\tif (v1305) goto L_03FE;\n\tgoto L_0089;\nL_0419:\n\tv173 = v791.Length < 1;\n\tif (v173) goto L_0089;\n\tv201 = v782.Items + 0x20;\n\tv79 = *([v150 @ X24_v5 (Spine.Attachment)+28]) + 0x20;\nL_0459:\n\tv1946 = v821[v807 @ X8_v72 (System.Int32)] - v146[v807 @ X8_v72 (System.Int32)];\n\tv1259 = v130 * v1946;\n\tv1947 = v146[v807 @ X8_v72 (System.Int32)] + v1259;\n\tv1948 = v1947 - *([v79 @ X14_v12+v807 @ X8_v72 (System.Int32)*4]);\n\tv1273 = *([v201 @ X12_v22+v807 @ X8_v72 (System.Int32)*4]) + v1948;\n\t*([v201 @ X12_v22+v807 @ X8_v72 (System.Int32)*4]) = v1273;\n\tv807 = v807 + 1;\n\tv1306 = v148 != v807;\n\tif (v1306) goto L_0459;\n\tgoto L_0089;\nL_0476:\n\tv175 = v791.Length < 1;\n\tif (v175) goto L_0089;\n\tv243 = v782.Items + 0x20;\n\tv202 = v142[v1577 @ X8_v17] + 0x20;\n\tv222 = *([v150 @ X24_v5 (Spine.Attachment)+28]) + 0x2\n// ... truncated")]
		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
			//IL_01ae: Expected I4, but got I8
			//IL_0280: Expected O, but got I4
			//IL_0c45: Expected O, but got I
			//IL_0c57: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c5c: Expected O, but got Unknown
			//IL_0ef5: Expected O, but got I
			//IL_0c87: Expected O, but got I
			//IL_0b48: Expected O, but got I
			//IL_148f: Expected O, but got I
			//IL_14a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_14a6: Expected O, but got Unknown
			//IL_14ba: Expected O, but got I
			//IL_0e1b: Expected O, but got I
			//IL_0e2d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e32: Expected O, but got Unknown
			//IL_0e48: Expected O, but got I
			//IL_0941: Expected O, but got I
			//IL_14e5: Expected O, but got I
			//IL_10d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_10dc: Expected O, but got Unknown
			//IL_10f0: Expected O, but got I
			//IL_0e73: Expected O, but got I
			//IL_0e89: Expected O, but got I
			//IL_057b: Expected O, but got I
			//IL_058d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0592: Expected O, but got Unknown
			//IL_05bd: Expected O, but got I
			//IL_137a: Expected O, but got I
			//IL_1390: Expected O, but got I
			//IL_0d17: Expected O, but got I
			//IL_0d2d: Expected O, but got I
			//IL_1292: Expected O, but got I
			//IL_12a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_12a9: Expected O, but got Unknown
			//IL_12bf: Expected O, but got I
			//IL_0fe5: Expected O, but got I
			//IL_043d: Expected O, but got I
			//IL_12ea: Expected O, but got I
			//IL_0884: Expected O, but got I
			//IL_0896: Unknown result type (might be due to invalid IL or missing references)
			//IL_089b: Expected O, but got Unknown
			//IL_117f: Expected O, but got I
			//IL_1195: Expected O, but got I
			//IL_06fb: Expected O, but got I
			ExposedList<Slot> slots = skeleton.Slots;
			Slot[] items = slots.Items;
			int num = SlotIndex;
			Slot slot = items[num];
			Bone bone = slot.Bone;
			if (!bone.Active || slot.Attachment == null)
			{
				return;
			}
			VertexAttachment vertexAttachment = slot.Attachment as VertexAttachment;
			if (vertexAttachment != null)
			{
				Attachment attachment = slot.Attachment;
			}
			else
			{
				Attachment attachment = null;
			}
			VertexAttachment vertexAttachment2 = slot.Attachment as VertexAttachment;
			if (vertexAttachment2 == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X24_v5 (Spine.Attachment)+38]");
			if (0 != (nint)Attachment)
			{
				return;
			}
			ExposedList<float> deform = slot.Deform;
			float[][] vertices = Vertices;
			MixBlend mixBlend = ((deform.Count != 0) ? blend : default(MixBlend));
			float[] array = vertices[0];
			float[] array2 = Frames;
			int num2 = (int)(array.Length & 0xFFFFFFFFL);
			if (array2[0] > time)
			{
				switch (mixBlend)
				{
				case MixBlend.First:
				{
					if (alpha == 1f)
					{
						goto case MixBlend.Setup;
					}
					int capacity = deform.Capacity;
					if (capacity < array.Length)
					{
						deform.Capacity = array.Length;
					}
					deform.Count = array.Length;
					float[] items2 = deform.Items;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X24_v5 (Spine.Attachment)+20]");
					if ((nint)0 != 0)
					{
						if (array.Length >= 1)
						{
							float num3 = 1f - alpha;
							int num4 = 0;
							do
							{
								float num5 = num3 * items2[num4];
								items2[num4] = num5;
								num4++;
							}
							while (num2 != num4);
						}
					}
					else if (array.Length >= 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X24_v5 (Spine.Attachment)+28]");
						object obj = (nint)0 + (nint)32;
						int num6 = 0;
						do
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ X12_v24+v809 @ X8_v86 (System.Int32)*4]");
							float num7 = 0f - items2[num6];
							float num8 = num7 * alpha;
							float num9 = items2[num6] + num8;
							items2[num6] = num9;
							num6++;
						}
						while (num2 != num6);
					}
					break;
				}
				case MixBlend.Setup:
					deform.Clear();
					break;
				}
				return;
			}
			int capacity2 = deform.Capacity;
			if (capacity2 < array.Length)
			{
				deform.Capacity = array.Length;
			}
			deform.Count = array.Length;
			object obj2 = array2.Length - 1;
			bool flag = array2[obj2] < time;
			bool flag2 = !flag;
			float num10 = array2[obj2] - time;
			bool flag3 = num10 == 0f;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				int num11 = Animation.BinarySearch(array2, time);
				int num12 = num11 - 1;
				float[] array3 = vertices[num12];
				float[] array4 = vertices[num11];
				float num13 = time - array2[num11];
				float num14 = array2[num12] - array2[num11];
				float num15 = num13 / num14;
				float percent = 1f - num15;
				float curvePercent = GetCurvePercent(num12, percent);
				if (alpha == 1f)
				{
					if (mixBlend == MixBlend.Add)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X24_v5 (Spine.Attachment)+20]");
						if ((nint)0 != 0)
						{
							if (array.Length >= 1)
							{
								object obj3 = (nint)deform.Items + 32;
								int num16 = 0;
								do
								{
									float num17 = array4[num16] - array3[num16];
									float num18 = curvePercent * num17;
									float num19 = array3[num16] + num18;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ X11_v22+v793 @ X8_v75 (System.Int32)*4]");
									float num20 = 0f + num19;
									num16++;
								}
								while (num2 != num16);
							}
						}
						else if (array.Length >= 1)
						{
							object obj4 = (nint)deform.Items + 32;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X24_v5 (Spine.Attachment)+28]");
							object obj5 = (nint)0 + (nint)32;
							int num21 = 0;
							do
							{
								float num22 = array4[num21] - array3[num21];
								float num23 = curvePercent * num22;
								float num24 = array3[num21] + num23;
								float num25 = num24;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ X14_v12+v807 @ X8_v72 (System.Int32)*4]");
								float num26 = num25 - 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ X12_v22+v807 @ X8_v72 (System.Int32)*4]");
								float num27 = 0f + num26;
								num21++;
							}
							while (num2 != num21);
						}
					}
					else if (array.Length >= 1)
					{
						object obj6 = (nint)deform.Items + 32;
						int num28 = 0;
						do
						{
							float num29 = array4[num28] - array3[num28];
							float num30 = curvePercent * num29;
							float num31 = array3[num28] + num30;
							num28++;
						}
						while (num2 != num28);
					}
					return;
				}
				int num32 = (int)(mixBlend - 1);
				if (num32 >= 2)
				{
					switch (mixBlend)
					{
					case MixBlend.Add:
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X24_v5 (Spine.Attachment)+20]");
						if ((nint)0 != 0)
						{
							if (array.Length >= 1)
							{
								object obj10 = (nint)deform.Items + 32;
								int num46 = 0;
								do
								{
									float num47 = array4[num46] - array3[num46];
									float num48 = curvePercent * num47;
									float num49 = array3[num46] + num48;
									float num50 = num49 * alpha;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ X11_v19+v797 @ X8_v65 (System.Int32)*4]");
									float num51 = 0f + num50;
									num46++;
								}
								while (num2 != num46);
							}
						}
						else if (array.Length >= 1)
						{
							object obj11 = (nint)deform.Items + 32;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X24_v5 (Spine.Attachment)+28]");
							object obj12 = (nint)0 + (nint)32;
							int num52 = 0;
							do
							{
								float num53 = array4[num52] - array3[num52];
								float num54 = curvePercent * num53;
								float num55 = array3[num52] + num54;
								float num56 = num55;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ X13_v17+v814 @ X8_v62 (System.Int32)*4]");
								float num57 = num56 - 0f;
								float num58 = num57 * alpha;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ X12_v19+v814 @ X8_v62 (System.Int32)*4]");
								float num59 = 0f + num58;
								num52++;
							}
							while (num2 != num52);
						}
						break;
					case MixBlend.Setup:
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X24_v5 (Spine.Attachment)+20]");
						if ((nint)0 != 0)
						{
							if (array.Length >= 1)
							{
								object obj7 = (nint)deform.Items + 32;
								int num33 = 0;
								do
								{
									float num34 = array4[num33] - array3[num33];
									float num35 = curvePercent * num34;
									float num36 = array3[num33] + num35;
									float num37 = num36 * alpha;
									num33++;
								}
								while (num2 != num33);
							}
						}
						else if (array.Length >= 1)
						{
							object obj8 = (nint)deform.Items + 32;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X24_v5 (Spine.Attachment)+28]");
							object obj9 = (nint)0 + (nint)32;
							int num38 = 0;
							do
							{
								float num39 = array4[num38] - array3[num38];
								float num40 = curvePercent * num39;
								float num41 = array3[num38] + num40;
								float num42 = num41;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X13_v13+v816 @ X8_v55 (System.Int32)*4]");
								float num43 = num42 - 0f;
								float num44 = num43 * alpha;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X13_v13+v816 @ X8_v55 (System.Int32)*4]");
								float num45 = 0f + num44;
								num38++;
							}
							while (num2 != num38);
						}
						break;
					}
				}
				else if (array.Length >= 1)
				{
					object obj13 = (nint)deform.Items + 32;
					int num60 = 0;
					do
					{
						float num61 = array4[num60] - array3[num60];
						float num62 = curvePercent * num61;
						float num63 = array3[num60] + num62;
						float num64 = num63;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ X11_v15+v804 @ X8_v51 (System.Int32)*4]");
						float num65 = num64 - 0f;
						float num66 = num65 * alpha;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ X11_v15+v804 @ X8_v51 (System.Int32)*4]");
						float num67 = 0f + num66;
						num60++;
					}
					while (num2 != num60);
				}
				return;
			}
			if (alpha == 1f)
			{
				if (mixBlend == MixBlend.Add)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X24_v5 (Spine.Attachment)+20]");
					if ((nint)0 != 0)
					{
						if (array.Length >= 1)
						{
							object obj14 = (nint)deform.Items + 32;
							object obj15 = vertices[obj2] + 32;
							int num68 = 0;
							do
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v680 @ X10_v16+v795 @ X8_v43 (System.Int32)*4]");
								nint num69 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ X11_v14+v795 @ X8_v43 (System.Int32)*4]");
								object obj16 = num69 + 0;
								num68++;
							}
							while (num2 != num68);
						}
					}
					else if (array.Length >= 1)
					{
						object obj17 = (nint)deform.Items + 32;
						object obj18 = vertices[obj2] + 32;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X24_v5 (Spine.Attachment)+28]");
						object obj19 = (nint)0 + (nint)32;
						int num70 = 0;
						do
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ X12_v13+v808 @ X8_v40 (System.Int32)*4]");
							nint num71 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ X13_v9+v808 @ X8_v40 (System.Int32)*4]");
							object obj20 = num71 - 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ X11_v13+v808 @ X8_v40 (System.Int32)*4]");
							object obj21 = 0 + (nint)obj20;
							num70++;
						}
						while (num2 != num70);
					}
				}
				else
				{
					Array.Copy(vertices[obj2], 0, deform.Items, 0, array.Length);
				}
				return;
			}
			int num72 = (int)(mixBlend - 1);
			if (num72 >= 2)
			{
				switch (mixBlend)
				{
				case MixBlend.Add:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X24_v5 (Spine.Attachment)+20]");
					if ((nint)0 != 0)
					{
						if (array.Length >= 1)
						{
							object obj28 = (nint)deform.Items + 32;
							object obj29 = vertices[obj2] + 32;
							int num79 = 0;
							do
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ X11_v12+v799 @ X8_v36 (System.Int32)*4]");
								float num80 = 0f * alpha;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ X10_v14+v799 @ X8_v36 (System.Int32)*4]");
								float num81 = 0f + num80;
								num79++;
							}
							while (num2 != num79);
						}
					}
					else if (array.Length >= 1)
					{
						object obj30 = (nint)deform.Items + 32;
						object obj31 = vertices[obj2] + 32;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X24_v5 (Spine.Attachment)+28]");
						object obj32 = (nint)0 + (nint)32;
						int num82 = 0;
						do
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ X12_v10+v815 @ X8_v33 (System.Int32)*4]");
							nint num83 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ X13_v8+v815 @ X8_v33 (System.Int32)*4]");
							object obj33 = num83 - 0;
							float num84 = (float)obj33 * alpha;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ X11_v11+v815 @ X8_v33 (System.Int32)*4]");
							float num85 = 0f + num84;
							num82++;
						}
						while (num2 != num82);
					}
					break;
				case MixBlend.Setup:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X24_v5 (Spine.Attachment)+20]");
					if ((nint)0 != 0)
					{
						if (array.Length >= 1)
						{
							object obj22 = vertices[obj2] + 32;
							object obj23 = (nint)deform.Items + 32;
							int num73 = 0;
							do
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v690 @ X10_v12+v813 @ X8_v29 (System.Int32)*4]");
								float num74 = 0f * alpha;
								num73++;
							}
							while (num2 != num73);
						}
					}
					else if (array.Length >= 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X24_v5 (Spine.Attachment)+28]");
						object obj24 = (nint)0 + (nint)32;
						object obj25 = vertices[obj2] + 32;
						object obj26 = (nint)deform.Items + 32;
						int num75 = 0;
						do
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ X11_v9+v817 @ X8_v26 (System.Int32)*4]");
							nint num76 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v695 @ X10_v11+v817 @ X8_v26 (System.Int32)*4]");
							object obj27 = num76 - 0;
							float num77 = (float)obj27 * alpha;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v695 @ X10_v11+v817 @ X8_v26 (System.Int32)*4]");
							float num78 = 0f + num77;
							num75++;
						}
						while (num2 != num75);
					}
					break;
				}
			}
			else if (array.Length >= 1)
			{
				object obj34 = (nint)deform.Items + 32;
				object obj35 = vertices[obj2] + 32;
				int num86 = 0;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ X11_v8+v806 @ X8_v22 (System.Int32)*4]");
					nint num87 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v685 @ X10_v9+v806 @ X8_v22 (System.Int32)*4]");
					object obj36 = num87 - 0;
					float num88 = (float)obj36 * alpha;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v685 @ X10_v9+v806 @ X8_v22 (System.Int32)*4]");
					float num89 = 0f + num88;
					num86++;
				}
				while (num2 != num86);
			}
		}
	}
}
