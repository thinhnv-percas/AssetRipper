using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000021")]
	public class TrackEntry : Pool<TrackEntry>.IPoolable
	{
		[Token(Token = "0x40000B3")]
		[FieldOffset(Offset = "0x10")]
		internal Animation animation;

		[Token(Token = "0x40000B4")]
		[FieldOffset(Offset = "0x18")]
		internal TrackEntry next;

		[Token(Token = "0x40000B5")]
		[FieldOffset(Offset = "0x20")]
		internal TrackEntry mixingFrom;

		[Token(Token = "0x40000B6")]
		[FieldOffset(Offset = "0x28")]
		internal TrackEntry mixingTo;

		[CompilerGenerated]
		[Token(Token = "0x40000B7")]
		[FieldOffset(Offset = "0x30")]
		private AnimationState.TrackEntryDelegate m_Start;

		[CompilerGenerated]
		[Token(Token = "0x40000B8")]
		[FieldOffset(Offset = "0x38")]
		private AnimationState.TrackEntryDelegate m_Interrupt;

		[CompilerGenerated]
		[Token(Token = "0x40000B9")]
		[FieldOffset(Offset = "0x40")]
		private AnimationState.TrackEntryDelegate m_End;

		[CompilerGenerated]
		[Token(Token = "0x40000BA")]
		[FieldOffset(Offset = "0x48")]
		private AnimationState.TrackEntryDelegate m_Dispose;

		[CompilerGenerated]
		[Token(Token = "0x40000BB")]
		[FieldOffset(Offset = "0x50")]
		private AnimationState.TrackEntryDelegate m_Complete;

		[CompilerGenerated]
		[Token(Token = "0x40000BC")]
		[FieldOffset(Offset = "0x58")]
		private AnimationState.TrackEntryEventDelegate m_Event;

		[Token(Token = "0x40000BD")]
		[FieldOffset(Offset = "0x60")]
		internal int trackIndex;

		[Token(Token = "0x40000BE")]
		[FieldOffset(Offset = "0x64")]
		internal bool loop;

		[Token(Token = "0x40000BF")]
		[FieldOffset(Offset = "0x65")]
		internal bool holdPrevious;

		[Token(Token = "0x40000C0")]
		[FieldOffset(Offset = "0x68")]
		internal float eventThreshold;

		[Token(Token = "0x40000C1")]
		[FieldOffset(Offset = "0x6C")]
		internal float attachmentThreshold;

		[Token(Token = "0x40000C2")]
		[FieldOffset(Offset = "0x70")]
		internal float drawOrderThreshold;

		[Token(Token = "0x40000C3")]
		[FieldOffset(Offset = "0x74")]
		internal float animationStart;

		[Token(Token = "0x40000C4")]
		[FieldOffset(Offset = "0x78")]
		internal float animationEnd;

		[Token(Token = "0x40000C5")]
		[FieldOffset(Offset = "0x7C")]
		internal float animationLast;

		[Token(Token = "0x40000C6")]
		[FieldOffset(Offset = "0x80")]
		internal float nextAnimationLast;

		[Token(Token = "0x40000C7")]
		[FieldOffset(Offset = "0x84")]
		internal float delay;

		[Token(Token = "0x40000C8")]
		[FieldOffset(Offset = "0x88")]
		internal float trackTime;

		[Token(Token = "0x40000C9")]
		[FieldOffset(Offset = "0x8C")]
		internal float trackLast;

		[Token(Token = "0x40000CA")]
		[FieldOffset(Offset = "0x90")]
		internal float nextTrackLast;

		[Token(Token = "0x40000CB")]
		[FieldOffset(Offset = "0x94")]
		internal float trackEnd;

		[Token(Token = "0x40000CC")]
		[FieldOffset(Offset = "0x98")]
		internal float timeScale;

		[Token(Token = "0x40000CD")]
		[FieldOffset(Offset = "0x9C")]
		internal float alpha;

		[Token(Token = "0x40000CE")]
		[FieldOffset(Offset = "0xA0")]
		internal float mixTime;

		[Token(Token = "0x40000CF")]
		[FieldOffset(Offset = "0xA4")]
		internal float mixDuration;

		[Token(Token = "0x40000D0")]
		[FieldOffset(Offset = "0xA8")]
		internal float interruptAlpha;

		[Token(Token = "0x40000D1")]
		[FieldOffset(Offset = "0xAC")]
		internal float totalAlpha;

		[Token(Token = "0x40000D2")]
		[FieldOffset(Offset = "0xB0")]
		internal MixBlend mixBlend;

		[Token(Token = "0x40000D3")]
		[FieldOffset(Offset = "0xB8")]
		internal readonly ExposedList<int> timelineMode;

		[Token(Token = "0x40000D4")]
		[FieldOffset(Offset = "0xC0")]
		internal readonly ExposedList<TrackEntry> timelineHoldMix;

		[Token(Token = "0x40000D5")]
		[FieldOffset(Offset = "0xC8")]
		internal readonly ExposedList<float> timelinesRotation;

		[Token(Token = "0x1700003E")]
		public int TrackIndex
		{
			[Token(Token = "0x60000FD")]
			[Address(RVA = "0x152C26C", Offset = "0x152C26C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.trackIndex;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TrackIndex;
			}
		}

		[Token(Token = "0x1700003F")]
		public Animation Animation
		{
			[Token(Token = "0x60000FE")]
			[Address(RVA = "0x152C274", Offset = "0x152C274", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.animation;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Animation;
			}
		}

		[Token(Token = "0x17000040")]
		public bool Loop
		{
			[Token(Token = "0x60000FF")]
			[Address(RVA = "0x152C27C", Offset = "0x152C27C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.loop;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Loop;
			}
			[Token(Token = "0x6000100")]
			[Address(RVA = "0x152C284", Offset = "0x152C284", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.loop = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				loop = value;
			}
		}

		[Token(Token = "0x17000041")]
		public float Delay
		{
			[Token(Token = "0x6000101")]
			[Address(RVA = "0x152C290", Offset = "0x152C290", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.delay;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Delay;
			}
			[Token(Token = "0x6000102")]
			[Address(RVA = "0x152C298", Offset = "0x152C298", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.delay = value;\n\treturn;\n")]
			set
			{
				Delay = value;
			}
		}

		[Token(Token = "0x17000042")]
		public float TrackTime
		{
			[Token(Token = "0x6000103")]
			[Address(RVA = "0x152C2A0", Offset = "0x152C2A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.trackTime;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TrackTime;
			}
			[Token(Token = "0x6000104")]
			[Address(RVA = "0x152C2A8", Offset = "0x152C2A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.trackTime = value;\n\treturn;\n")]
			set
			{
				TrackTime = value;
			}
		}

		[Token(Token = "0x17000043")]
		public float TrackEnd
		{
			[Token(Token = "0x6000105")]
			[Address(RVA = "0x152C2B0", Offset = "0x152C2B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.trackEnd;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TrackEnd;
			}
			[Token(Token = "0x6000106")]
			[Address(RVA = "0x152C2B8", Offset = "0x152C2B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.trackEnd = value;\n\treturn;\n")]
			set
			{
				TrackEnd = value;
			}
		}

		[Token(Token = "0x17000044")]
		public float AnimationStart
		{
			[Token(Token = "0x6000107")]
			[Address(RVA = "0x152C2C0", Offset = "0x152C2C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.animationStart;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AnimationStart;
			}
			[Token(Token = "0x6000108")]
			[Address(RVA = "0x152C2C8", Offset = "0x152C2C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.animationStart = value;\n\treturn;\n")]
			set
			{
				AnimationStart = value;
			}
		}

		[Token(Token = "0x17000045")]
		public float AnimationEnd
		{
			[Token(Token = "0x6000109")]
			[Address(RVA = "0x152C2D0", Offset = "0x152C2D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.animationEnd;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AnimationEnd;
			}
			[Token(Token = "0x600010A")]
			[Address(RVA = "0x152C2D8", Offset = "0x152C2D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.animationEnd = value;\n\treturn;\n")]
			set
			{
				AnimationEnd = value;
			}
		}

		[Token(Token = "0x17000046")]
		public float AnimationLast
		{
			[Token(Token = "0x600010B")]
			[Address(RVA = "0x152C2E0", Offset = "0x152C2E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.animationLast;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AnimationLast;
			}
			[Token(Token = "0x600010C")]
			[Address(RVA = "0x152C2E8", Offset = "0x152C2E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.animationLast = value;\n\tthis.nextAnimationLast = value;\n\treturn;\n")]
			set
			{
				animationLast = value;
				nextAnimationLast = value;
			}
		}

		[Token(Token = "0x17000047")]
		public float AnimationTime
		{
			[Token(Token = "0x600010D")]
			[Address(RVA = "0x1529194", Offset = "0x1529194", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = System.Math;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A37B13]) = v39;\nL_0014:\n\tv41 = ~v37.loop;\n\tif (v41) goto L_0038;\n\tv66 = v37.animationStart;\n\tv44 = v37.animationEnd - v37.animationStart;\n\tv49 = v44 == 0;\n\tif (v49) goto L_002E;\n\tv64 = 0x1854EF0(v37, methodInfo, v23, v24, v25, v26, v27, v28, v37.trackTime, v44, v31, v32, v33, v34, v35, v36);\n\tv66 = v66 + v37.trackTime;\nL_002E:\n\treturn v66;\nL_0038:\n\tgoto L_003A;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v59, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_003A:\n\tv78 = v37.trackTime + v37.animationStart;\n\treturnVal2 = System.Math::Min(v78, v37.animationEnd);\n\treturn returnVal2;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0050: Expected O, but got F4
				if (Loop)
				{
					float num = AnimationStart;
					float num2 = AnimationEnd - AnimationStart;
					if (num2 != 0f)
					{
						object obj = TrackTime % num2;
						num += TrackTime;
					}
					return num;
				}
				float val = TrackTime + AnimationStart;
				return Math.Min(val, AnimationEnd);
			}
		}

		[Token(Token = "0x17000048")]
		public float TimeScale
		{
			[Token(Token = "0x600010E")]
			[Address(RVA = "0x152C2F0", Offset = "0x152C2F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.timeScale;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TimeScale;
			}
			[Token(Token = "0x600010F")]
			[Address(RVA = "0x152C2F8", Offset = "0x152C2F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.timeScale = value;\n\treturn;\n")]
			set
			{
				TimeScale = value;
			}
		}

		[Token(Token = "0x17000049")]
		public float Alpha
		{
			[Token(Token = "0x6000110")]
			[Address(RVA = "0x152C300", Offset = "0x152C300", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.alpha;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Alpha;
			}
			[Token(Token = "0x6000111")]
			[Address(RVA = "0x152C308", Offset = "0x152C308", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.alpha = value;\n\treturn;\n")]
			set
			{
				Alpha = value;
			}
		}

		[Token(Token = "0x1700004A")]
		public float EventThreshold
		{
			[Token(Token = "0x6000112")]
			[Address(RVA = "0x152C310", Offset = "0x152C310", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.eventThreshold;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return EventThreshold;
			}
			[Token(Token = "0x6000113")]
			[Address(RVA = "0x152C318", Offset = "0x152C318", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.eventThreshold = value;\n\treturn;\n")]
			set
			{
				EventThreshold = value;
			}
		}

		[Token(Token = "0x1700004B")]
		public float AttachmentThreshold
		{
			[Token(Token = "0x6000114")]
			[Address(RVA = "0x152C320", Offset = "0x152C320", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.attachmentThreshold;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AttachmentThreshold;
			}
			[Token(Token = "0x6000115")]
			[Address(RVA = "0x152C328", Offset = "0x152C328", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.attachmentThreshold = value;\n\treturn;\n")]
			set
			{
				AttachmentThreshold = value;
			}
		}

		[Token(Token = "0x1700004C")]
		public float DrawOrderThreshold
		{
			[Token(Token = "0x6000116")]
			[Address(RVA = "0x152C330", Offset = "0x152C330", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.drawOrderThreshold;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DrawOrderThreshold;
			}
			[Token(Token = "0x6000117")]
			[Address(RVA = "0x152C338", Offset = "0x152C338", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.drawOrderThreshold = value;\n\treturn;\n")]
			set
			{
				DrawOrderThreshold = value;
			}
		}

		[Token(Token = "0x1700004D")]
		public TrackEntry Next
		{
			[Token(Token = "0x6000118")]
			[Address(RVA = "0x152C340", Offset = "0x152C340", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.next;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Next;
			}
		}

		[Token(Token = "0x1700004E")]
		public bool IsComplete
		{
			[Token(Token = "0x6000119")]
			[Address(RVA = "0x152C348", Offset = "0x152C348", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.animationEnd - this.animationStart;\n\tv7 = this.trackTime - v4;\n\tv8 = v7 < 0;\n\tv10 = this.trackTime ^ v4;\n\tv11 = this.trackTime ^ v7;\n\tv12 = v10 & v11;\n\tv13 = v12 < 0;\n\tv14 = v8 == v13;\n\treturn v14;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0044: Expected O, but got F4
				//IL_0053: Expected O, but got F4
				float num = AnimationEnd - AnimationStart;
				float num2 = TrackTime - num;
				bool flag = num2 < 0f;
				object obj = TrackTime ^ num;
				object obj2 = TrackTime ^ num2;
				int num3 = (int)((nint)obj & (nint)obj2);
				bool flag2 = num3 < 0;
				return flag == flag2;
			}
		}

		[Token(Token = "0x1700004F")]
		public float MixTime
		{
			[Token(Token = "0x600011A")]
			[Address(RVA = "0x152C360", Offset = "0x152C360", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mixTime;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MixTime;
			}
			[Token(Token = "0x600011B")]
			[Address(RVA = "0x152C368", Offset = "0x152C368", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mixTime = value;\n\treturn;\n")]
			set
			{
				MixTime = value;
			}
		}

		[Token(Token = "0x17000050")]
		public float MixDuration
		{
			[Token(Token = "0x600011C")]
			[Address(RVA = "0x152C370", Offset = "0x152C370", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mixDuration;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MixDuration;
			}
			[Token(Token = "0x600011D")]
			[Address(RVA = "0x152C378", Offset = "0x152C378", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mixDuration = value;\n\treturn;\n")]
			set
			{
				MixDuration = value;
			}
		}

		[Token(Token = "0x17000051")]
		public MixBlend MixBlend
		{
			[Token(Token = "0x600011E")]
			[Address(RVA = "0x152C380", Offset = "0x152C380", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mixBlend;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MixBlend;
			}
			[Token(Token = "0x600011F")]
			[Address(RVA = "0x152C388", Offset = "0x152C388", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mixBlend = value;\n\treturn;\n")]
			set
			{
				MixBlend = value;
			}
		}

		[Token(Token = "0x17000052")]
		public TrackEntry MixingFrom
		{
			[Token(Token = "0x6000120")]
			[Address(RVA = "0x152C390", Offset = "0x152C390", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mixingFrom;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MixingFrom;
			}
		}

		[Token(Token = "0x17000053")]
		public TrackEntry MixingTo
		{
			[Token(Token = "0x6000121")]
			[Address(RVA = "0x152C398", Offset = "0x152C398", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mixingTo;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MixingTo;
			}
		}

		[Token(Token = "0x17000054")]
		public bool HoldPrevious
		{
			[Token(Token = "0x6000122")]
			[Address(RVA = "0x152C3A0", Offset = "0x152C3A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.holdPrevious;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HoldPrevious;
			}
			[Token(Token = "0x6000123")]
			[Address(RVA = "0x152C3A8", Offset = "0x152C3A8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.holdPrevious = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				holdPrevious = value;
			}
		}

		[Token(Token = "0x14000007")]
		public event AnimationState.TrackEntryDelegate Start
		{
			[CompilerGenerated]
			[Token(Token = "0x60000EA")]
			[Address(RVA = "0x152B9A0", Offset = "0x152B9A0", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.AnimationState+TrackEntryDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37B06]) = v38;\nL_0014:\n\tv40 = this + 0x30;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.AnimationState+TrackEntryDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 48;
				Delegate obj2 = this.m_Start;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(AnimationState.TrackEntryDelegate))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60000EB")]
			[Address(RVA = "0x152BA3C", Offset = "0x152BA3C", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.AnimationState+TrackEntryDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37B07]) = v38;\nL_0014:\n\tv40 = this + 0x30;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.AnimationState+TrackEntryDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 48;
				Delegate obj2 = this.m_Start;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(AnimationState.TrackEntryDelegate))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000008")]
		public event AnimationState.TrackEntryDelegate Interrupt
		{
			[CompilerGenerated]
			[Token(Token = "0x60000EC")]
			[Address(RVA = "0x152BAD8", Offset = "0x152BAD8", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.AnimationState+TrackEntryDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37B08]) = v38;\nL_0014:\n\tv40 = this + 0x38;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.AnimationState+TrackEntryDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 56;
				Delegate obj2 = this.m_Interrupt;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(AnimationState.TrackEntryDelegate))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60000ED")]
			[Address(RVA = "0x152BB74", Offset = "0x152BB74", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.AnimationState+TrackEntryDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37B09]) = v38;\nL_0014:\n\tv40 = this + 0x38;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.AnimationState+TrackEntryDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 56;
				Delegate obj2 = this.m_Interrupt;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(AnimationState.TrackEntryDelegate))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000009")]
		public event AnimationState.TrackEntryDelegate End
		{
			[CompilerGenerated]
			[Token(Token = "0x60000EE")]
			[Address(RVA = "0x152BC10", Offset = "0x152BC10", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.AnimationState+TrackEntryDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37B0A]) = v38;\nL_0014:\n\tv40 = this + 0x40;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.AnimationState+TrackEntryDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 64;
				Delegate obj2 = this.m_End;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(AnimationState.TrackEntryDelegate))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60000EF")]
			[Address(RVA = "0x152BCAC", Offset = "0x152BCAC", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.AnimationState+TrackEntryDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37B0B]) = v38;\nL_0014:\n\tv40 = this + 0x40;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.AnimationState+TrackEntryDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 64;
				Delegate obj2 = this.m_End;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(AnimationState.TrackEntryDelegate))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x1400000A")]
		public event AnimationState.TrackEntryDelegate Dispose
		{
			[CompilerGenerated]
			[Token(Token = "0x60000F0")]
			[Address(RVA = "0x152BD48", Offset = "0x152BD48", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.AnimationState+TrackEntryDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37B0C]) = v38;\nL_0014:\n\tv40 = this + 0x48;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.AnimationState+TrackEntryDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 72;
				Delegate obj2 = this.m_Dispose;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(AnimationState.TrackEntryDelegate))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60000F1")]
			[Address(RVA = "0x152BDE4", Offset = "0x152BDE4", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.AnimationState+TrackEntryDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37B0D]) = v38;\nL_0014:\n\tv40 = this + 0x48;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.AnimationState+TrackEntryDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 72;
				Delegate obj2 = this.m_Dispose;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(AnimationState.TrackEntryDelegate))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x1400000B")]
		public event AnimationState.TrackEntryDelegate Complete
		{
			[CompilerGenerated]
			[Token(Token = "0x60000F2")]
			[Address(RVA = "0x152BE80", Offset = "0x152BE80", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.AnimationState+TrackEntryDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37B0E]) = v38;\nL_0014:\n\tv40 = this + 0x50;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.AnimationState+TrackEntryDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 80;
				Delegate obj2 = this.m_Complete;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(AnimationState.TrackEntryDelegate))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60000F3")]
			[Address(RVA = "0x152BF1C", Offset = "0x152BF1C", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.AnimationState+TrackEntryDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37B0F]) = v38;\nL_0014:\n\tv40 = this + 0x50;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.AnimationState+TrackEntryDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 80;
				Delegate obj2 = this.m_Complete;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(AnimationState.TrackEntryDelegate))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x1400000C")]
		public event AnimationState.TrackEntryEventDelegate Event
		{
			[CompilerGenerated]
			[Token(Token = "0x60000F4")]
			[Address(RVA = "0x152BFB8", Offset = "0x152BFB8", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.AnimationState+TrackEntryEventDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37B10]) = v38;\nL_0014:\n\tv40 = this + 0x58;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.AnimationState+TrackEntryEventDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 88;
				Delegate obj2 = this.m_Event;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(AnimationState.TrackEntryEventDelegate))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60000F5")]
			[Address(RVA = "0x152C054", Offset = "0x152C054", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.AnimationState+TrackEntryEventDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37B11]) = v38;\nL_0014:\n\tv40 = this + 0x58;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.AnimationState+TrackEntryEventDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 88;
				Delegate obj2 = this.m_Event;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(AnimationState.TrackEntryEventDelegate))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x60000F6")]
		[Address(RVA = "0x152C0F0", Offset = "0x152C0F0", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.Start == 0;\n\tif (v2) goto L_0008;\n\tSpine.AnimationState+TrackEntryDelegate::Invoke(this.Start, this);\nL_0008:\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void OnStart()
		{
			if (this.Start != null)
			{
				this.Start(this);
			}
		}

		[Token(Token = "0x60000F7")]
		[Address(RVA = "0x152C110", Offset = "0x152C110", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.Interrupt == 0;\n\tif (v2) goto L_0008;\n\tSpine.AnimationState+TrackEntryDelegate::Invoke(this.Interrupt, this);\nL_0008:\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void OnInterrupt()
		{
			if (this.Interrupt != null)
			{
				this.Interrupt(this);
			}
		}

		[Token(Token = "0x60000F8")]
		[Address(RVA = "0x152C130", Offset = "0x152C130", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.End == 0;\n\tif (v2) goto L_0008;\n\tSpine.AnimationState+TrackEntryDelegate::Invoke(this.End, this);\nL_0008:\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void OnEnd()
		{
			if (this.End != null)
			{
				this.End(this);
			}
		}

		[Token(Token = "0x60000F9")]
		[Address(RVA = "0x152C150", Offset = "0x152C150", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.Dispose == 0;\n\tif (v2) goto L_0008;\n\tSpine.AnimationState+TrackEntryDelegate::Invoke(this.Dispose, this);\nL_0008:\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void OnDispose()
		{
			if (this.Dispose != null)
			{
				this.Dispose(this);
			}
		}

		[Token(Token = "0x60000FA")]
		[Address(RVA = "0x152C170", Offset = "0x152C170", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.Complete == 0;\n\tif (v2) goto L_0008;\n\tSpine.AnimationState+TrackEntryDelegate::Invoke(this.Complete, this);\nL_0008:\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void OnComplete()
		{
			if (this.Complete != null)
			{
				this.Complete(this);
			}
		}

		[Token(Token = "0x60000FB")]
		[Address(RVA = "0x152C190", Offset = "0x152C190", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.Event == 0;\n\tif (v2) goto L_000A;\n\tSpine.AnimationState+TrackEntryEventDelegate::Invoke(this.Event, this, e);\nL_000A:\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void OnEvent(Event e)
		{
			if (this.Event != null)
			{
				this.Event(this, e);
			}
		}

		[Token(Token = "0x60000FC")]
		[Address(RVA = "0x152C1B8", Offset = "0x152C1B8", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv39 = Il2CppMethodInfo;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v39, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv59 = Il2CppMethodInfo;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37B12]) = v34;\nL_0018:\n\tthis.End = 0;\n\tthis.Complete = 0;\n\tthis.mixingFrom = 0;\n\tthis.Start = 0;\n\tthis.animation = 0;\n\tSpine.ExposedList`1<System.Int32>::Clear(this.timelineMode, 1);\n\tSpine.ExposedList`1<Spine.TrackEntry>::Clear(this.timelineHoldMix, 1);\n\tSpine.ExposedList`1<System.Single>::Clear(this.timelinesRotation, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Reset()
		{
			this.End = null;
			this.Complete = null;
			mixingFrom = null;
			this.Start = null;
			animation = null;
			timelineMode.Clear();
			timelineHoldMix.Clear();
			timelinesRotation.Clear();
		}

		[Token(Token = "0x6000124")]
		[Address(RVA = "0x152C3B4", Offset = "0x152C3B4", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37B14]) = v33;\nL_001B:\n\tSpine.ExposedList`1<System.Single>::Clear(this.timelinesRotation, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ResetRotationDirections()
		{
			timelinesRotation.Clear();
		}

		[Token(Token = "0x6000125")]
		[Address(RVA = "0x152C408", Offset = "0x152C408", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = \"<none>\";\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37B15]) = v37;\nL_0014:\n\tv39 = this.animation + 0x10;\n\tv49 = this.animation != 0;\n\tif (v49) goto L_FFFFFFFF;\n\tgoto L_002A;\nL_002A:\n\treturn *([v52 @ X8_v4 (System.String)]);\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			//IL_0031: Expected O, but got I
			string result = (string)((nint)Animation + 16);
			if (Animation == null)
			{
				return "<none>";
			}
			return result;
		}

		[Token(Token = "0x6000126")]
		[Address(RVA = "0x152C45C", Offset = "0x152C45C", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0033;\n\tv38 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv64 = Il2CppMethodInfo;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv69 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv74 = Spine.ExposedList`1<Spine.TrackEntry>;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv79 = Spine.ExposedList`1<System.Int32>;\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv84 = Spine.ExposedList`1<System.Single>;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv58 = 1;\n\t*([1A37B16]) = v58;\nL_0033:\n\tthis.timeScale = 1f;\n\tthis.mixBlend = 2;\n\tv62 = new Spine.ExposedList`1<System.Int32>();\n\tSpine.ExposedList`1<System.Int32>::.ctor(v62);\n\tthis.timelineMode = v62;\n\tv72 = new Spine.ExposedList`1<Spine.TrackEntry>();\n\tSpine.ExposedList`1<Spine.TrackEntry>::.ctor(v72);\n\tthis.timelineHoldMix = v72;\n\tv82 = new Spine.ExposedList`1<System.Single>();\n\tSpine.ExposedList`1<System.Single>::.ctor(v82);\n\tthis.timelinesRotation = v82;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TrackEntry()
		{
			TimeScale = 1f;
			MixBlend = MixBlend.Replace;
			ExposedList<int> exposedList = new ExposedList<int>();
			timelineMode = exposedList;
			ExposedList<TrackEntry> exposedList2 = new ExposedList<TrackEntry>();
			timelineHoldMix = exposedList2;
			ExposedList<float> exposedList3 = new ExposedList<float>();
			timelinesRotation = exposedList3;
		}
	}
}
