using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000017")]
	public class EventTimeline : Timeline
	{
		[Token(Token = "0x4000070")]
		[FieldOffset(Offset = "0x10")]
		internal float[] frames;

		[Token(Token = "0x4000071")]
		[FieldOffset(Offset = "0x18")]
		private Event[] events;

		[Token(Token = "0x17000026")]
		public int PropertyId
		{
			[Token(Token = "0x6000076")]
			[Address(RVA = "0x15257D4", Offset = "0x15257D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0x7000000;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return 117440512;
			}
		}

		[Token(Token = "0x17000027")]
		public int FrameCount
		{
			[Token(Token = "0x6000077")]
			[Address(RVA = "0x15257DC", Offset = "0x15257DC", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.frames;\n\treturn v2.Length;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				float[] array = Frames;
				return array.Length;
			}
		}

		[Token(Token = "0x17000028")]
		public float[] Frames
		{
			[Token(Token = "0x6000078")]
			[Address(RVA = "0x15257F8", Offset = "0x15257F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.frames;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Frames;
			}
			[Token(Token = "0x6000079")]
			[Address(RVA = "0x1525800", Offset = "0x1525800", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.frames = value;\n\treturn;\n")]
			set
			{
				Frames = value;
			}
		}

		[Token(Token = "0x17000029")]
		public Event[] Events
		{
			[Token(Token = "0x600007A")]
			[Address(RVA = "0x1525808", Offset = "0x1525808", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.events;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Events;
			}
			[Token(Token = "0x600007B")]
			[Address(RVA = "0x1525810", Offset = "0x1525810", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.events = value;\n\treturn;\n")]
			set
			{
				Events = value;
			}
		}

		[Token(Token = "0x6000075")]
		[Address(RVA = "0x1525748", Offset = "0x1525748", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = Spine.Event[];\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, frameCount, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv49 = System.Single[];\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, frameCount, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A37AE2]) = v45;\nL_001D:\n\tSystem.Object::.ctor(this);\n\t// 32 NewArr v52 @ X0_v4 (System.Single[]), typeof(System.Single[]), frameCount @ X1 (System.Int32)\n\tthis.frames = v52;\n\t// 36 NewArr v55 @ X0_v6 (Spine.Event[]), typeof(Spine.Event[]), frameCount @ X1 (System.Int32)\n\tthis.events = v55;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EventTimeline(int frameCount)
		{
			float[] array = new float[frameCount];
			Frames = array;
			Event[] array2 = new Event[frameCount];
			Events = array2;
		}

		[Token(Token = "0x600007C")]
		[Address(RVA = "0x1525818", Offset = "0x1525818", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.frames;\n\tv12[frameIndex @ X1 (System.Int32)] = e.time;\n\tv16 = this.events;\n\t// 37 IsInst v83 @ X0_v8, typeof(Spine.Event), e @ X2 (Spine.Event)\n\tv112 = v83 == 0;\n\tif (v112) goto L_0041;\n\tv16[frameIndex @ X1 (System.Int32)] = e;\n\treturn;\n\tv64 = new System.NullReferenceException();\n\tv113 = new System.IndexOutOfRangeException();\nL_0041:\n\tv135 = new System.ArrayTypeMismatchException();\n\tthrow v135;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetFrame(int frameIndex, Event e)
		{
			float[] array = Frames;
			array[frameIndex] = e.Time;
			Event[] array2 = Events;
			object obj = e as Event;
			if (obj != null)
			{
				array2[frameIndex] = e;
				return;
			}
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x600007D")]
		[Address(RVA = "0x15258A8", Offset = "0x15258A8", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv44 = Il2CppMethodInfo;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, skeleton, firedEvents, blend, direction, methodInfo, v47, v48, lastTime, time, alpha, v49, v50, v51, v52, v53);\n\tv56 = 1;\n\t*([1A37AE3]) = v56;\nL_001F:\n\tv57 = firedEvents == 0;\n\tif (v57) goto L_010C;\n\tv58 = this.frames;\n\tv252 = lastTime <= time;\n\tif (v252) goto L_0042;\n\tSpine.EventTimeline::Apply(this, v116, lastTime, 2.1474836E+09f, firedEvents, alpha, blend, direction);\n\tgoto L_0062;\nL_0042:\n\tv335 = v58.Length << 0x20;\n\tv336 = 0xFFFFFFFF00000000 + v335;\n\tv88 = v336 >> 0x1E;\n\tv337 = v58 + v88;\n\tv338 = *([v337 @ X8_v16+20]) < lastTime;\n\tv188 = ~v338;\n\tv180 = *([v337 @ X8_v16+20]) - lastTime;\n\tv164 = v180 == 0;\n\tv339 = ~v188;\n\tv125 = v339 | v164;\n\tif (v125) goto L_010C;\nL_0062:\n\tv126 = v58[0] > time;\n\tif (v126) goto L_010C;\n\tv352 = v215 >= v58[0];\n\tif (v352) goto L_0073;\n\tgoto L_00B5;\nL_0073:\n\tv403 = Spine.Animation::BinarySearch(v58, v215);\n\tv81 = v403 & v403;\n\tv342 = v403 + 1;\n\tv341 = v58 + 0x1C;\nL_0091:\n\tv353 = v343 <= 0;\n\tif (v353) goto L_00B5;\n\tv343 = v343 - 1;\n\tv342 = v342 - 1;\n\tv440 = *([v341 @ X12_v5+v343 @ X11_v6 (System.Int32)*4]) == v58[v403 @ X0_v12 (System.Int32)];\n\tif (v440) goto L_0091;\nL_00B5:\n\tv129 = v81 >= v58.Length;\n\tif (v129) goto L_010C;\n\tv212 = v58.Length - 1;\nL_00C8:\n\tv482 = v58[v221 @ X22_v7 (System.Int32)] < time;\n\tv190 = ~v482;\n\tv182 = v58[v221 @ X22_v7 (System.Int32)] - time;\n\tv166 = v182 == 0;\n\tv483 = ~v166;\n\tv127 = v190 & v483;\n\tif (v127) goto L_010C;\n\tv284 = this.events;\n\tSpine.ExposedList`1<Spine.Event>::Add(firedEvents, v284[v221 @ X22_v7 (System.Int32)]);\n\tv167 = v212 == v221;\n\tif (v167) goto L_010C;\n\tv221 = v221 + 1;\n\tv488 = v221 < v58.Length;\n\tv396 = ~v488;\n\tv350 = ~v396;\n\tif (v350) goto L_00C8;\n\tthrow System.IndexOutOfRangeException;\nL_010C:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 210 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
			//IL_0088: Expected O, but got I8
			//IL_00a5: Expected O, but got I
			//IL_01bf: Expected O, but got I
			if (firedEvents == null)
			{
				return;
			}
			float[] array = Frames;
			float num;
			if (lastTime > time)
			{
				Skeleton skeleton2 = default(Skeleton);
				Apply(skeleton2, lastTime, 2.1474836E+09f, firedEvents, alpha, blend, direction);
				num = -1f;
			}
			else
			{
				int num2 = array.Length << 32;
				object obj = -4294967296L + num2;
				int num3 = (int)((nint)obj >> 30);
				object obj2 = (nint)array + num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ X8_v16+20]");
				bool flag = 0f < lastTime;
				bool flag2 = !flag;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ X8_v16+20]");
				float num4 = 0f - lastTime;
				bool flag3 = num4 == 0f;
				bool flag4 = !flag2;
				bool flag5 = flag4 || flag3;
				num = lastTime;
				if (flag5)
				{
					return;
				}
			}
			if (array[0] > time)
			{
				return;
			}
			int num5;
			if (num < array[0])
			{
				num5 = 0;
			}
			else
			{
				int num6 = Animation.BinarySearch(array, num);
				num5 = num6 & num6;
				int num7 = num6 + 1;
				object obj3 = (nint)array + 28;
				int num8 = num6;
				while (num8 > 0)
				{
					num8--;
					num7--;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ X12_v5+v343 @ X11_v6 (System.Int32)*4]");
					if (0f != array[num6])
					{
						num5 = num7;
						break;
					}
				}
			}
			if (num5 >= array.Length)
			{
				return;
			}
			int num9 = array.Length - 1;
			int num10 = num5;
			while (true)
			{
				bool flag6 = array[num10] < time;
				bool flag7 = !flag6;
				float num11 = array[num10] - time;
				bool flag8 = num11 == 0f;
				bool flag9 = !flag8;
				if (!(flag7 && flag9))
				{
					Event[] array2 = Events;
					firedEvents.Add(array2[num10]);
					if (num9 != num10)
					{
						num10++;
						if (num10 >= array.Length)
						{
							throw new IndexOutOfRangeException();
						}
						continue;
					}
					break;
				}
				break;
			}
		}
	}
}
