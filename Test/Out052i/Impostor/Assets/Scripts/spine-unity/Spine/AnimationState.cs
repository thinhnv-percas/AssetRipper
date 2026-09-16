using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine
{
	[Token(Token = "0x200001E")]
	public class AnimationState
	{
		[Token(Token = "0x200001F")]
		public delegate void TrackEntryDelegate(TrackEntry trackEntry);

		[Token(Token = "0x2000020")]
		public delegate void TrackEntryEventDelegate(TrackEntry trackEntry, Event e);

		[Token(Token = "0x400009C")]
		private static readonly Animation EmptyAnimation;

		[Token(Token = "0x400009D")]
		internal const int Subsequent = 0;

		[Token(Token = "0x400009E")]
		internal const int First = 1;

		[Token(Token = "0x400009F")]
		internal const int HoldSubsequent = 2;

		[Token(Token = "0x40000A0")]
		internal const int HoldFirst = 3;

		[Token(Token = "0x40000A1")]
		internal const int HoldMix = 4;

		[Token(Token = "0x40000A2")]
		internal const int Setup = 1;

		[Token(Token = "0x40000A3")]
		internal const int Current = 2;

		[Token(Token = "0x40000A4")]
		[FieldOffset(Offset = "0x10")]
		protected AnimationStateData data;

		[Token(Token = "0x40000A5")]
		[FieldOffset(Offset = "0x18")]
		private readonly ExposedList<TrackEntry> tracks;

		[Token(Token = "0x40000A6")]
		[FieldOffset(Offset = "0x20")]
		private readonly ExposedList<Event> events;

		[CompilerGenerated]
		[Token(Token = "0x40000A7")]
		[FieldOffset(Offset = "0x28")]
		private TrackEntryDelegate m_Start;

		[CompilerGenerated]
		[Token(Token = "0x40000A8")]
		[FieldOffset(Offset = "0x30")]
		private TrackEntryDelegate m_Interrupt;

		[CompilerGenerated]
		[Token(Token = "0x40000A9")]
		[FieldOffset(Offset = "0x38")]
		private TrackEntryDelegate m_End;

		[CompilerGenerated]
		[Token(Token = "0x40000AA")]
		[FieldOffset(Offset = "0x40")]
		private TrackEntryDelegate m_Dispose;

		[CompilerGenerated]
		[Token(Token = "0x40000AB")]
		[FieldOffset(Offset = "0x48")]
		private TrackEntryDelegate m_Complete;

		[CompilerGenerated]
		[Token(Token = "0x40000AC")]
		[FieldOffset(Offset = "0x50")]
		private TrackEntryEventDelegate m_Event;

		[Token(Token = "0x40000AD")]
		[FieldOffset(Offset = "0x58")]
		private readonly EventQueue queue;

		[Token(Token = "0x40000AE")]
		[FieldOffset(Offset = "0x60")]
		private readonly HashSet<int> propertyIDs;

		[Token(Token = "0x40000AF")]
		[FieldOffset(Offset = "0x68")]
		private bool animationsChanged;

		[Token(Token = "0x40000B0")]
		[FieldOffset(Offset = "0x6C")]
		private float timeScale;

		[Token(Token = "0x40000B1")]
		[FieldOffset(Offset = "0x70")]
		private int unkeyedState;

		[Token(Token = "0x40000B2")]
		[FieldOffset(Offset = "0x78")]
		private readonly Pool<TrackEntry> trackEntryPool;

		[Token(Token = "0x1700003B")]
		public float TimeScale
		{
			[Token(Token = "0x60000DA")]
			[Address(RVA = "0x152B434", Offset = "0x152B434", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.timeScale;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TimeScale;
			}
			[Token(Token = "0x60000DB")]
			[Address(RVA = "0x152B43C", Offset = "0x152B43C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.timeScale = value;\n\treturn;\n")]
			set
			{
				TimeScale = value;
			}
		}

		[Token(Token = "0x1700003C")]
		public AnimationStateData Data
		{
			[Token(Token = "0x60000DC")]
			[Address(RVA = "0x152B444", Offset = "0x152B444", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.data;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Data;
			}
			[Token(Token = "0x60000DD")]
			[Address(RVA = "0x152B44C", Offset = "0x152B44C", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this.data == 0;\n\tif (v8) goto L_0010;\n\tthis.data = value;\n\treturn;\nL_0010:\n\tv43 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v43, \"data\", \"data cannot be null.\");\n\tthrow v43;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (Data != null)
				{
					data = value;
					return;
				}
				ArgumentNullException ex = new ArgumentNullException("data", "data cannot be null.");
				throw ex;
			}
		}

		[Token(Token = "0x1700003D")]
		public ExposedList<TrackEntry> Tracks
		{
			[Token(Token = "0x60000DE")]
			[Address(RVA = "0x152B4C8", Offset = "0x152B4C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.tracks;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Tracks;
			}
		}

		[Token(Token = "0x14000001")]
		public event TrackEntryDelegate Start
		{
			[CompilerGenerated]
			[Token(Token = "0x60000B0")]
			[Address(RVA = "0x1527170", Offset = "0x1527170", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.AnimationState+TrackEntryDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37AE9]) = v38;\nL_0014:\n\tv40 = this + 0x28;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.AnimationState+TrackEntryDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 40;
				Delegate obj2 = this.m_Start;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(TrackEntryDelegate))
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
			[Token(Token = "0x60000B1")]
			[Address(RVA = "0x152720C", Offset = "0x152720C", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.AnimationState+TrackEntryDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37AEA]) = v38;\nL_0014:\n\tv40 = this + 0x28;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.AnimationState+TrackEntryDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 40;
				Delegate obj2 = this.m_Start;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(TrackEntryDelegate))
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

		[Token(Token = "0x14000002")]
		public event TrackEntryDelegate Interrupt
		{
			[CompilerGenerated]
			[Token(Token = "0x60000B2")]
			[Address(RVA = "0x15272A8", Offset = "0x15272A8", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.AnimationState+TrackEntryDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37AEB]) = v38;\nL_0014:\n\tv40 = this + 0x30;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.AnimationState+TrackEntryDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 48;
				Delegate obj2 = this.m_Interrupt;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(TrackEntryDelegate))
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
			[Token(Token = "0x60000B3")]
			[Address(RVA = "0x1527344", Offset = "0x1527344", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.AnimationState+TrackEntryDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37AEC]) = v38;\nL_0014:\n\tv40 = this + 0x30;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.AnimationState+TrackEntryDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 48;
				Delegate obj2 = this.m_Interrupt;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(TrackEntryDelegate))
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

		[Token(Token = "0x14000003")]
		public event TrackEntryDelegate End
		{
			[CompilerGenerated]
			[Token(Token = "0x60000B4")]
			[Address(RVA = "0x15273E0", Offset = "0x15273E0", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.AnimationState+TrackEntryDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37AED]) = v38;\nL_0014:\n\tv40 = this + 0x38;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.AnimationState+TrackEntryDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 56;
				Delegate obj2 = this.m_End;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(TrackEntryDelegate))
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
			[Token(Token = "0x60000B5")]
			[Address(RVA = "0x152747C", Offset = "0x152747C", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.AnimationState+TrackEntryDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37AEE]) = v38;\nL_0014:\n\tv40 = this + 0x38;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.AnimationState+TrackEntryDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 56;
				Delegate obj2 = this.m_End;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(TrackEntryDelegate))
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

		[Token(Token = "0x14000004")]
		public event TrackEntryDelegate Dispose
		{
			[CompilerGenerated]
			[Token(Token = "0x60000B6")]
			[Address(RVA = "0x1527518", Offset = "0x1527518", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.AnimationState+TrackEntryDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37AEF]) = v38;\nL_0014:\n\tv40 = this + 0x40;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.AnimationState+TrackEntryDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 64;
				Delegate obj2 = this.m_Dispose;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(TrackEntryDelegate))
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
			[Token(Token = "0x60000B7")]
			[Address(RVA = "0x15275B4", Offset = "0x15275B4", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.AnimationState+TrackEntryDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37AF0]) = v38;\nL_0014:\n\tv40 = this + 0x40;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.AnimationState+TrackEntryDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 64;
				Delegate obj2 = this.m_Dispose;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(TrackEntryDelegate))
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

		[Token(Token = "0x14000005")]
		public event TrackEntryDelegate Complete
		{
			[CompilerGenerated]
			[Token(Token = "0x60000B8")]
			[Address(RVA = "0x1527650", Offset = "0x1527650", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.AnimationState+TrackEntryDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37AF1]) = v38;\nL_0014:\n\tv40 = this + 0x48;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.AnimationState+TrackEntryDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 72;
				Delegate obj2 = this.m_Complete;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(TrackEntryDelegate))
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
			[Token(Token = "0x60000B9")]
			[Address(RVA = "0x15276EC", Offset = "0x15276EC", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.AnimationState+TrackEntryDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37AF2]) = v38;\nL_0014:\n\tv40 = this + 0x48;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.AnimationState+TrackEntryDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 72;
				Delegate obj2 = this.m_Complete;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(TrackEntryDelegate))
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

		[Token(Token = "0x14000006")]
		public event TrackEntryEventDelegate Event
		{
			[CompilerGenerated]
			[Token(Token = "0x60000BA")]
			[Address(RVA = "0x1527788", Offset = "0x1527788", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.AnimationState+TrackEntryEventDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37AF3]) = v38;\nL_0014:\n\tv40 = this + 0x50;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.AnimationState+TrackEntryEventDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 80;
				Delegate obj2 = this.m_Event;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(TrackEntryEventDelegate))
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
			[Token(Token = "0x60000BB")]
			[Address(RVA = "0x1527824", Offset = "0x1527824", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.AnimationState+TrackEntryEventDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37AF4]) = v38;\nL_0014:\n\tv40 = this + 0x50;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.AnimationState+TrackEntryEventDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 80;
				Delegate obj2 = this.m_Event;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(TrackEntryEventDelegate))
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

		[Token(Token = "0x60000AA")]
		[Address(RVA = "0x15270C8", Offset = "0x15270C8", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.Start == 0;\n\tif (v2) goto L_0007;\n\tSpine.AnimationState+TrackEntryDelegate::Invoke(this.Start, entry);\nL_0007:\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void OnStart(TrackEntry entry)
		{
			if (this.Start != null)
			{
				this.Start(entry);
			}
		}

		[Token(Token = "0x60000AB")]
		[Address(RVA = "0x15270E4", Offset = "0x15270E4", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.Interrupt == 0;\n\tif (v2) goto L_0007;\n\tSpine.AnimationState+TrackEntryDelegate::Invoke(this.Interrupt, entry);\nL_0007:\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void OnInterrupt(TrackEntry entry)
		{
			if (this.Interrupt != null)
			{
				this.Interrupt(entry);
			}
		}

		[Token(Token = "0x60000AC")]
		[Address(RVA = "0x1527100", Offset = "0x1527100", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.End == 0;\n\tif (v2) goto L_0007;\n\tSpine.AnimationState+TrackEntryDelegate::Invoke(this.End, entry);\nL_0007:\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void OnEnd(TrackEntry entry)
		{
			if (this.End != null)
			{
				this.End(entry);
			}
		}

		[Token(Token = "0x60000AD")]
		[Address(RVA = "0x152711C", Offset = "0x152711C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.Dispose == 0;\n\tif (v2) goto L_0007;\n\tSpine.AnimationState+TrackEntryDelegate::Invoke(this.Dispose, entry);\nL_0007:\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void OnDispose(TrackEntry entry)
		{
			if (this.Dispose != null)
			{
				this.Dispose(entry);
			}
		}

		[Token(Token = "0x60000AE")]
		[Address(RVA = "0x1527138", Offset = "0x1527138", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.Complete == 0;\n\tif (v2) goto L_0007;\n\tSpine.AnimationState+TrackEntryDelegate::Invoke(this.Complete, entry);\nL_0007:\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void OnComplete(TrackEntry entry)
		{
			if (this.Complete != null)
			{
				this.Complete(entry);
			}
		}

		[Token(Token = "0x60000AF")]
		[Address(RVA = "0x1527154", Offset = "0x1527154", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.Event == 0;\n\tif (v2) goto L_0007;\n\tSpine.AnimationState+TrackEntryEventDelegate::Invoke(this.Event, entry, e);\nL_0007:\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void OnEvent(TrackEntry entry, Event e)
		{
			if (this.Event != null)
			{
				this.Event(entry, e);
			}
		}

		[Token(Token = "0x60000BC")]
		[Address(RVA = "0x15278C0", Offset = "0x15278C0", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Event = src.Event;\n\tthis.Start = src.Start;\n\tthis.End = src.End;\n\tthis.Complete = src.Complete;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AssignEventSubscribersFrom(AnimationState src)
		{
			this.Event = src.Event;
			this.Start = src.Start;
			this.End = src.End;
			this.Complete = src.Complete;
		}

		[Token(Token = "0x60000BD")]
		[Address(RVA = "0x15278F4", Offset = "0x15278F4", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.AnimationState::add_Event(this, src.Event);\n\tSpine.AnimationState::add_Start(this, src.Start);\n\tSpine.AnimationState::add_Interrupt(this, src.Interrupt);\n\tSpine.AnimationState::add_End(this, src.End);\n\tSpine.AnimationState::add_Dispose(this, src.Dispose);\n\tSpine.AnimationState::add_Complete(this, src.Complete);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddEventSubscribersFrom(AnimationState src)
		{
			Event += src.Event;
			Start += src.Start;
			Interrupt += src.Interrupt;
			End += src.End;
			Dispose += src.Dispose;
			Complete += src.Complete;
		}

		[Token(Token = "0x60000BE")]
		[Address(RVA = "0x1527958", Offset = "0x1527958", Length = "0x24C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0049;\n\tv50 = System.Action;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, data, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65);\n\tv73 = Il2CppMethodInfo;\n\tv74 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, data, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65);\n\tv78 = Spine.EventQueue;\n\tv79 = \"il2cpp_codegen_initialize_runtime_metadata\"(v78, data, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65);\n\tv83 = Il2CppMethodInfo;\n\tv84 = \"il2cpp_codegen_initialize_runtime_metadata\"(v83, data, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65);\n\tv88 = Il2CppMethodInfo;\n\tv89 = \"il2cpp_codegen_initialize_runtime_metadata\"(v88, data, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65);\n\tv93 = Spine.ExposedList`1<Spine.TrackEntry>;\n\tv94 = \"il2cpp_codegen_initialize_runtime_metadata\"(v93, data, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65);\n\tv98 = Spine.ExposedList`1<Spine.Event>;\n\tv99 = \"il2cpp_codegen_initialize_runtime_metadata\"(v98, data, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65);\n\tv104 = Il2CppMethodInfo;\n\tv105 = \"il2cpp_codegen_initialize_runtime_metadata\"(v104, data, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65);\n\tv111 = System.Collections.Generic.HashSet`1<System.Int32>;\n\tv112 = \"il2cpp_codegen_initialize_runtime_metadata\"(v111, data, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65);\n\tv116 = Il2CppMethodInfo;\n\tv117 = \"il2cpp_codegen_initialize_runtime_metadata\"(v116, data, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65);\n\tv120 = Spine.Pool`1<Spine.TrackEntry>;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v120, data, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65);\n\tv69 = 1;\n\t*([1A37AF5]) = v69;\nL_0049:\n\tv71 = new Spine.ExposedList`1<Spine.TrackEntry>();\n\tSpine.ExposedList`1<Spine.TrackEntry>::.ctor(v71);\n\tthis.tracks = v71;\n\tv81 = new Spine.ExposedList`1<Spine.Event>();\n\tSpine.ExposedList`1<Spine.Event>::.ctor(v81);\n\tthis.events = v81;\n\tv91 = new System.Collections.Generic.HashSet`1<System.Int32>();\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::.ctor(v91);\n\tthis.propertyIDs = v91;\n\tthis.timeScale = 1f;\n\tv102 = new Spine.Pool`1<Spine.TrackEntry>();\n\tSpine.Pool`1<Spine.TrackEntry>::.ctor(v102, 0x10, 0x7FFFFFFF);\n\tthis.trackEntryPool = v102;\n\tSystem.Object::.ctor(this);\n\tv118 = data == 0;\n\tif (v118) goto L_0091;\n\tthis.data = data;\n\tv128 = new System.Action();\n\tSystem.Action::.ctor(v128, this, Il2CppMethodInfo);\n\tv139 = new Spine.EventQueue();\n\tSpine.EventQueue::.ctor(v139, this, v128, this.trackEntryPool);\n\tthis.queue = v139;\n\treturn;\nL_0091:\n\tv136 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v136, \"data\", \"data cannot be null.\");\n\tthrow v136;\n// 115 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AnimationState(AnimationStateData data)
		{
			ExposedList<TrackEntry> exposedList = new ExposedList<TrackEntry>();
			tracks = exposedList;
			ExposedList<Event> exposedList2 = new ExposedList<Event>();
			events = exposedList2;
			HashSet<int> hashSet = new HashSet<int>();
			propertyIDs = hashSet;
			TimeScale = 1f;
			Pool<TrackEntry> pool = new Pool<TrackEntry>();
			trackEntryPool = pool;
			if (data != null)
			{
				this.data = data;
				Action handleAnimationsChanged = delegate
				{
					animationsChanged = true;
				};
				EventQueue eventQueue = new EventQueue(this, handleAnimationsChanged, trackEntryPool);
				queue = eventQueue;
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("data", "data cannot be null.");
			throw ex;
		}

		[Token(Token = "0x60000BF")]
		[Address(RVA = "0x1527C4C", Offset = "0x1527C4C", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = this.tracks;\n\tv33 = v18.Count < 1;\n\tif (v33) goto L_00DF;\n\tv89 = this.timeScale * delta;\nL_002C:\n\tv86 = v92 << 3;\n\tv298 = v18.Items + v86;\n\tv156 = v298 + 0x20;\n\tv82 = *([v156 @ X8_v8]);\n\tv299 = *([v156 @ X8_v8]) == 0;\n\tif (v299) goto L_00BB;\n\tv65 = v89 * v82.timeScale;\n\tv82.animationLast = v82.nextAnimationLast;\n\tv82.trackLast = v82.nextTrackLast;\n\tv314 = v82.delay <= 0;\n\tif (v314) goto L_0057;\n\tv330 = v82.delay - v65;\n\tv82.delay = v330;\n\tv334 = v330 > 0;\n\tif (v334) goto L_00BB;\n\tv65 = -v330;\n\tv82.delay = 0f;\nL_0057:\n\tv53 = v82.next;\n\tv378 = v82.next == 0;\n\tif (v378) goto L_009B;\n\tv332 = v82.nextTrackLast - v53.delay;\n\tv335 = v332 < 0;\n\tif (v335) goto L_00A1;\n\tv350 = v82.timeScale == 0;\n\tv53.delay = 0f;\n\tif (v350) goto L_007C;\n\tv399 = v332 / v82.timeScale;\n\tv400 = v89 + v399;\n\tv331 = v400 * v53.timeScale;\nL_007C:\n\tv404 = v53.trackTime + v331;\n\tv53.trackTime = v404;\n\tv328 = v65 + v82.trackTime;\n\tv82.trackTime = v328;\n\tSpine.AnimationState::SetCurrent(this, v92, v82.next, 1);\n\tv423 = v53.mixingFrom;\n\tv361 = v53.mixingFrom == 0;\n\tif (v361) goto L_00BB;\nL_0088:\n\tv329 = v89 + v419.mixTime;\n\tv419.mixTime = v329;\n\tv425 = v423.mixingFrom == 0;\n\tv362 = ~v425;\n\tif (v362) goto L_0088;\n\tgoto L_00BB;\nL_009B:\n\tv105 = v82.nextTrackLast < v82.trackEnd;\n\tif (v105) goto L_00A1;\n\tv396 = v82.mixingFrom == 0;\n\tif (v396) goto L_00C8;\nL_00A1:\n\tv397 = v82.mixingFrom == 0;\n\tif (v397) goto L_00B9;\n\tv408 = Spine.AnimationState::UpdateMixingFrom(this, *([v156 @ X8_v8]), v89);\n\tv414 = v408 == 0;\n\tif (v414) goto L_00B9;\n\tv52 = v82.mixingFrom;\n\tv82.mixingFrom = 0;\n\tv415 = v82.mixingFrom == 0;\n\tif (v415) goto L_00B9;\n\tv52.mixingTo = 0;\nL_00B3:\n\tSpine.EventQueue::End(this.queue, v52);\n\tv428 = v52.mixingFrom == 0;\n\tv413 = ~v428;\n\tif (v413) goto L_00B3;\nL_00B9:\n\tv327 = v65 + v82.trackTime;\n\tv82.trackTime = v327;\nL_00BB:\n\tv92 = v92 + 1;\n\tv181 = v92 != v18.Count;\n\tif (v181) goto L_002C;\n\tgoto L_00DF;\nL_00C8:\n\t*([v156 @ X8_v8]) = 0;\n\tSpine.EventQueue::End(this.queue, *([v156 @ X8_v8]));\n\tSpine.AnimationState::DisposeNext(this, *([v156 @ X8_v8]));\n\tgoto L_00BB;\nL_00DF:\n\tSpine.EventQueue::Drain(this.queue);\n\treturn;\n\tv158 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 148 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Update(float delta)
		{
			//IL_0071: Expected O, but got I
			//IL_0080: Expected O, but got I
			//IL_03dc: Expected O, but got I4
			ExposedList<TrackEntry> exposedList = Tracks;
			if (exposedList.Count >= 1)
			{
				float num = TimeScale * delta;
				int num2 = 0;
				do
				{
					int num3 = num2 << 3;
					object obj = (nint)exposedList.Items + num3;
					object obj2 = (nint)obj + 32;
					TrackEntry trackEntry = (TrackEntry)obj2;
					float num4;
					if (obj2 != null)
					{
						num4 = num * trackEntry.TimeScale;
						trackEntry.animationLast = trackEntry.nextAnimationLast;
						trackEntry.trackLast = trackEntry.nextTrackLast;
						if (trackEntry.Delay > 0f)
						{
							float num5 = (trackEntry.Delay -= num4);
							if (num5 > 0f)
							{
								goto IL_0411;
							}
							num4 = 0f - num5;
							trackEntry.Delay = 0f;
						}
						TrackEntry next = trackEntry.Next;
						if (trackEntry.Next != null)
						{
							float num7 = trackEntry.nextTrackLast - next.Delay;
							if (num7 < 0f)
							{
								goto IL_02c3;
							}
							bool flag = trackEntry.TimeScale == 0f;
							next.Delay = 0f;
							float num8 = 0f;
							if (!flag)
							{
								float num9 = num7 / trackEntry.TimeScale;
								float num10 = num + num9;
								num8 = num10 * next.TimeScale;
							}
							float trackTime = next.TrackTime + num8;
							next.TrackTime = trackTime;
							float trackTime2 = num4 + trackEntry.TrackTime;
							trackEntry.TrackTime = trackTime2;
							SetCurrent(num2, trackEntry.Next, interrupt: true);
							TrackEntry mixingFrom = next.MixingFrom;
							bool flag2 = next.MixingFrom == null;
							TrackEntry trackEntry2 = trackEntry.Next;
							if (!flag2)
							{
								bool flag4;
								do
								{
									float mixTime = num + trackEntry2.MixTime;
									trackEntry2.MixTime = mixTime;
									bool flag3 = mixingFrom.MixingFrom == null;
									flag4 = !flag3;
									trackEntry2 = mixingFrom;
									mixingFrom = mixingFrom.MixingFrom;
								}
								while (flag4);
							}
						}
						else
						{
							if (trackEntry.nextTrackLast < trackEntry.TrackEnd || trackEntry.MixingFrom != null)
							{
								goto IL_02c3;
							}
							obj2 = 0;
							queue.End((TrackEntry)obj2);
							DisposeNext((TrackEntry)obj2);
						}
					}
					goto IL_0411;
					IL_0411:
					num2++;
					continue;
					IL_02c3:
					if (trackEntry.MixingFrom != null && UpdateMixingFrom((TrackEntry)obj2, num))
					{
						TrackEntry mixingFrom2 = trackEntry.MixingFrom;
						trackEntry.mixingFrom = null;
						if (trackEntry.MixingFrom != null)
						{
							mixingFrom2.mixingTo = null;
							bool flag6;
							do
							{
								queue.End(mixingFrom2);
								bool flag5 = mixingFrom2.MixingFrom == null;
								flag6 = !flag5;
								mixingFrom2 = mixingFrom2.MixingFrom;
							}
							while (flag6);
						}
					}
					float trackTime3 = num4 + trackEntry.TrackTime;
					trackEntry.TrackTime = trackTime3;
					goto IL_0411;
				}
				while (num2 != exposedList.Count);
			}
			queue.Drain();
		}

		[Token(Token = "0x60000C0")]
		[Address(RVA = "0x15280BC", Offset = "0x15280BC", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = to.mixingFrom;\n\tv16 = to.mixingFrom == 0;\n\tif (v16) goto L_FFFFFFFF;\n\tv81 = Spine.AnimationState::UpdateMixingFrom(this, to.mixingFrom, delta);\n\tv14.animationLast = v14.nextAnimationLast;\n\tv14.trackLast = v14.nextTrackLast;\n\tv97 = to.mixTime <= 0;\n\tif (v97) goto L_0032;\n\tv179 = to.mixTime >= to.mixDuration;\n\tif (v179) goto L_0047;\nL_0032:\n\tv133 = to.mixTime + delta;\n\tv182 = v14.timeScale * delta;\n\tv131 = v14.trackTime + v182;\n\tv14.trackTime = v131;\n\tto.mixTime = v133;\n\tgoto L_0041;\nL_0041:\n\treturn v99;\nL_0047:\n\tv187 = to.mixDuration == 0;\n\tif (v187) goto L_005A;\n\tv105 = v14.totalAlpha != 0;\n\tif (v105) goto L_0041;\nL_005A:\n\tto.mixingFrom = v14.mixingFrom;\n\tv19 = v14.mixingFrom;\n\tv195 = v14.mixingFrom == 0;\n\tif (v195) goto L_0060;\n\tv19.mixingTo = to;\nL_0060:\n\tto.interruptAlpha = v14.interruptAlpha;\n\tSpine.EventQueue::End(this.queue, to.mixingFrom);\n\tgoto L_0041;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool UpdateMixingFrom(TrackEntry to, float delta)
		{
			TrackEntry mixingFrom = to.MixingFrom;
			bool result;
			if (to.MixingFrom != null)
			{
				bool flag = UpdateMixingFrom(to.MixingFrom, delta);
				mixingFrom.animationLast = mixingFrom.nextAnimationLast;
				mixingFrom.trackLast = mixingFrom.nextTrackLast;
				if (!(to.MixTime > 0f) || to.MixTime < to.MixDuration)
				{
					float mixTime = to.MixTime + delta;
					float num = mixingFrom.TimeScale * delta;
					float trackTime = mixingFrom.TrackTime + num;
					mixingFrom.TrackTime = trackTime;
					to.MixTime = mixTime;
					result = false;
				}
				else
				{
					if (to.MixDuration != 0f)
					{
						bool flag2 = mixingFrom.totalAlpha != 0f;
						result = flag;
						if (flag2)
						{
							goto IL_01f5;
						}
					}
					to.mixingFrom = mixingFrom.MixingFrom;
					TrackEntry mixingFrom2 = mixingFrom.MixingFrom;
					if (mixingFrom.MixingFrom != null)
					{
						mixingFrom2.mixingTo = to;
					}
					to.interruptAlpha = mixingFrom.interruptAlpha;
					queue.End(to.MixingFrom);
					result = flag;
				}
			}
			else
			{
				result = true;
			}
			goto IL_01f5;
			IL_01f5:
			return result;
		}

		[Token(Token = "0x60000C1")]
		[Address(RVA = "0x1528464", Offset = "0x1528464", Length = "0x618")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv44 = Spine.AnimationState;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, skeleton, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv66 = Spine.AttachmentTimeline;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, skeleton, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv192 = Il2CppMethodInfo;\n\tv193 = \"il2cpp_codegen_initialize_runtime_metadata\"(v192, skeleton, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv200 = Il2CppMethodInfo;\n\tv201 = \"il2cpp_codegen_initialize_runtime_metadata\"(v200, skeleton, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv592 = Spine.RotateTimeline;\n\tv593 = \"il2cpp_codegen_initialize_runtime_metadata\"(v592, skeleton, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv643 = Spine.Timeline;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v643, skeleton, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv63 = 1;\n\t*([1A37AF6]) = v63;\nL_002E:\n\tv64 = skeleton == 0;\n\tif (v64) goto L_02DF;\n\tv69 = ~this.animationsChanged;\n\tif (v69) goto L_0035;\n\tSpine.AnimationState::AnimationsChanged(this);\nL_0035:\n\tv196 = this.tracks;\n\tv213 = v196.Count < 1;\n\tif (v213) goto L_FFFFFFFF;\nL_005D:\n\tv347 = v672[v375 @ X28_v7 (System.Int32)];\n\tv709 = v672[v375 @ X28_v7 (System.Int32)] == 0;\n\tif (v709) goto L_0263;\n\tv743 = v347.delay > 0;\n\tif (v743) goto L_0263;\n\tv763 = v375 == 0;\n\tif (v763) goto L_FFFFFFFF;\n\tv333 = v347.mixBlend;\n\tgoto L_0074;\nL_0074:\n\tv303 = v347.alpha;\n\tv847 = v347.mixingFrom == 0;\n\tif (v847) goto L_008A;\n\tv854 = Spine.AnimationState::ApplyMixingFrom(v562, v672[v375 @ X28_v7 (System.Int32)], skeleton, v333);\n\tv303 = v303 * v854;\n\tgoto L_009E;\nL_008A:\n\tv867 = v347.trackTime < v347.trackEnd;\n\tif (v867) goto L_009E;\n\tv885 = v347.next != 0;\n\tif (v885) goto L_009E;\n\tgoto L_009E;\nL_009E:\n\tv341 = Spine.TrackEntry::get_AnimationTime(v672[v375 @ X28_v7 (System.Int32)]);\n\tv565 = v347.animation;\n\tv566 = v565.timelines;\n\tv385 = v566.Items;\n\tv903 = v375 == 0;\n\tv911 = v303 - 1f;\n\tv913 = v911 == 0;\n\tv463 = v333 == 3;\n\tif (v463) goto L_01D3;\n\tv919 = v903 & v913;\n\tv920 = ~v919;\n\tv921 = ~v920;\n\tif (v921) goto L_01D3;\n\tv567 = v347.timelineMode;\n\tv533 = v347.timelinesRotation;\n\tv523 = v567.Items;\n\tv325 = v566.Count << 1;\n\tv464 = v533.Count == v566.Count;\n\tif (v464) goto L_00F0;\n\tv996 = Spine.ExposedList`1<System.Single>::Resize(v533, v325);\n\tv533 = v347.timelinesRotation;\nL_00F0:\n\tv391 = v566.Count < 1;\n\tif (v391) goto L_0254;\nL_011E:\n\tv295 = v523[v582 @ X19_v18 (System.Int32)] != 0;\n\tif (v295) goto L_FFFFFFFF;\n\tgoto L_0136;\nL_0136:\n\tgoto L_FFFFFFFF;\n\tv1184 = v1184_asT != 0;\n\tif (v1184) goto L_019D;\n\tgoto L_FFFFFFFF;\n\tv1228 = v1228_asT != 0;\n\tif (v1228) goto L_01BB;\n\tgoto L_0195;\n\tv1277 = *([v1243 @ X8_v54+B0]);\n\tv1278 = v1277 + 8;\n\tv1280 = *([v1340 @ X10_v31-8]);\n\tv1355 = v1280 == v1247;\n\tif (v1355) goto L_0187;\n\tv1284 = v1341 - 1;\n\tv1282 = v1340 + 0x10;\n\tv1286 = v1341 != 1;\n\tif (v1286) goto L_FFFFFFFF;\n\tv1303 = v563;\n\tv1304 = 0;\n\tv1305 = 0xB349B4(v1303, v1247, v1304, v307, v231, v225, v50, v51, v342, v298, v216, v55, v56, v57, v58, v59);\n\tgoto L_0195;\nL_0187:\n\tv1361 = *([v1340 @ X10_v31]);\n\tv1362 = v1361 << 4;\n\tv1363 = v1243 + v1362;\n\tv1364 = v1363 + 0x138;\nL_0195:\n\tSpine.Timeline::Apply(v385[v582 @ X19_v18 (System.Int32)], skeleton, v347.animationLast, v341, this.events, v303, v257, 0);\n\tgoto L_01BC;\nL_019D:\n\tgoto L_01A2;\n\tv1249 = \"il2cpp_codegen_runtime_class_init\"(v1216, v326, v317, v307, v231, v225, v50, v51, v342, v298, v216, v55, v56, v57, v58, v59);\nL_01A2:\n\tv1254 = v582 << 1;\n\tv1258 = v533.Count - v325;\n\tv1260 = v1258 == 0;\n\tv1265 = ~v1260;\n\tSpine.AnimationState::ApplyRotateTimeline(v385[v582 @ X19_v18 (System.Int32)], skeleton, v341, v303, v257, v533.Items, v1254, v1265);\n\tgoto L_01BC;\nL_01BB:\n\tSpine.AnimationState::ApplyAttachmentTimeline(this, v385[v582 @ X19_v18 (System.Int32)], skeleton, v341, v333, 1);\nL_01BC:\n\tv582 = v582 + 1;\n\tv952 = v582 != v566.Count;\n\tif (v952) goto L_011E;\n\tgoto L_0254;\nL_01D3:\n\tv393 = v566.Count < 1;\n\tif (v393) goto L_0254;\nL_01F8:\n\tgoto L_FFFFFFFF;\n\tv1025 = v1025_asT != 0;\n\tif (v1025) goto L_024E;\n\tgoto L_023A;\n\tv1062 = *([v1040 @ X8_v39+B0]);\n\tv1063 = v1062 + 8;\n\tv1065 = *([v1092 @ X10_v17-8]);\n\tv1107 = v1065 == v1044;\n\tif (v1107) goto L_022C;\n\tv1069 = v1093 - 1;\n\tv1067 = v1092 + 0x10;\n\tv1071 = v1093 != 1;\n\tif (v1071) goto L_FFFFFFFF;\n\tv1088 = v524;\n\tv1089 = 0;\n\tv1090 = 0xB349B4(v1088, v1044, v1089, v308, v232, v226, v50, v51, v343, v299, v217, v55, v56, v57, v58, v59);\n\tgoto L_023A;\nL_022C:\n\tv1147 = *([v1092 @ X10_v17]);\n\tv1148 = v1147 << 4;\n\tv1149 = v1040 + v1148;\n\tv1150 = v1149 + 0x138;\nL_023A:\n\tSpine.Timeline::Apply(v385[v583 @ X19_v15 (System.Int32)], skeleton, v347.animationLast, v341, this.events, v303, v333, 0);\nL_023B:\n\tv583 = v583 + 1;\n\tv953 = v583 != v566.Count;\n\tif (v953) goto L_01F8;\n\tgoto L_0254;\nL_024E:\n\tSpine.AnimationState::ApplyAttachmentTimeline(this, v385[v583 @ X19_v15 (System.Int32)], skeleton, v341, v333, 1);\n\tgoto L_023B;\nL_0254:\n\tSpine.AnimationState::QueueEvents(this, v672[v375 @ X28_v7 (System.Int32)], v341);\n\tSpine.ExposedList`1<Spine.Event>::Clear(this.events, 0);\n\tv347.nextAnimationLast = v341;\n\tv347.nextTrackLast = v347.trackTime;\nL_0263:\n\tv375 = v375 + 1;\n\tv673 = v375 != v682;\n\tif (v673) goto L_005D;\n\tgoto L_0271;\nL_0271:\n\tv280 = skeleton.slots;\n\tv727 = v562.unkeyedState;\n\tv396 = v280.Count < 1;\n\tif (v396) goto L_02C1;\n\tv334 = v280.Items;\n\tv387 = v562.unkeyedState + 1;\nL_0294:\n\tv380 = v334[v527 @ X24_v9 (System.Int32)];\n\tv398 = v380.attachmentState != v387;\n\tif (v398) goto L_02B3;\n\tv576 = v380.data;\n\tv872 = v576.attachmentName == 0;\n\tif (v872) goto L_FFFFFFFF;\n\tv895 = Spine.Skeleton::GetAttachment(skeleton, v576.index, v576.attachmentName);\n\tgoto L_02B2;\nL_02B2:\n\tSpine.Slot::set_Attachment(v334[v527 @ X24_v9 (System.Int32)], v870);\nL_02B3:\n\tv527 = v527 + 1;\n\tv713 = v280.Count != v527;\n\tif (v713) goto L_0294;\n\tv727 = v562.unkeyedState;\nL_02C1:\n\tv579 = v727 + 2;\n\tv562.unkeyedState = v579;\n\tSpine.EventQueue::Drain(v562.queue);\n\treturnVal2 = v585 & 1;\n\treturn returnVal2;\n\tv586 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_02DF:\n\tv198 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v198, \"skeleton\", \"skeleton cannot be null.\");\n\tthrow v198;\n// 581 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Apply(Skeleton skeleton)
		{
			if (skeleton != null)
			{
				if (animationsChanged)
				{
					AnimationsChanged();
				}
				ExposedList<TrackEntry> exposedList = Tracks;
				AnimationState animationState;
				int num2;
				if (exposedList.Count >= 1)
				{
					int num = 0;
					TrackEntry[] items = exposedList.Items;
					int count = exposedList.Count;
					animationState = this;
					num2 = 0;
					do
					{
						TrackEntry trackEntry = items[num];
						if (items[num] != null && !(trackEntry.Delay > 0f))
						{
							MixBlend mixBlend = ((num == 0) ? MixBlend.First : trackEntry.MixBlend);
							float num3 = trackEntry.Alpha;
							if (trackEntry.MixingFrom != null)
							{
								float num4 = animationState.ApplyMixingFrom(items[num], skeleton, mixBlend);
								num3 *= num4;
							}
							else if (!(trackEntry.TrackTime < trackEntry.TrackEnd) && trackEntry.Next == null)
							{
								num3 = 0f;
							}
							float animationTime = items[num].AnimationTime;
							Animation animation = trackEntry.Animation;
							ExposedList<Timeline> timelines = animation.Timelines;
							Timeline[] items2 = timelines.Items;
							bool flag = num == 0;
							float num5 = num3 - 1f;
							bool flag2 = num5 == 0f;
							if (mixBlend != MixBlend.Add && !(flag && flag2))
							{
								ExposedList<int> timelineMode = trackEntry.timelineMode;
								ExposedList<float> timelinesRotation = trackEntry.timelinesRotation;
								int[] items3 = timelineMode.Items;
								int num6 = timelines.Count << 1;
								if (timelinesRotation.Count != timelines.Count)
								{
									ExposedList<float> exposedList2 = timelinesRotation.Resize(num6);
									timelinesRotation = trackEntry.timelinesRotation;
								}
								if (timelines.Count >= 1)
								{
									int num7 = 0;
									do
									{
										MixBlend blend = ((items3[num7] != 0) ? default(MixBlend) : mixBlend);
										RotateTimeline rotateTimeline = items2[num7] as RotateTimeline;
										if (rotateTimeline == null)
										{
											AttachmentTimeline attachmentTimeline = items2[num7] as AttachmentTimeline;
											if (attachmentTimeline != null)
											{
												ApplyAttachmentTimeline((AttachmentTimeline)items2[num7], skeleton, animationTime, mixBlend, attachments: true);
												int num8 = 1;
											}
											else
											{
												items2[num7].Apply(skeleton, trackEntry.AnimationLast, animationTime, events, num3, blend, default(MixDirection));
												int num8 = 0;
											}
										}
										else
										{
											int num8 = num7 << 1;
											int num9 = timelinesRotation.Count - num6;
											bool flag3 = num9 == 0;
											bool firstFrame = !flag3;
											ApplyRotateTimeline((RotateTimeline)items2[num7], skeleton, animationTime, num3, blend, timelinesRotation.Items, num8, firstFrame);
										}
										num7++;
									}
									while (num7 != timelines.Count);
								}
							}
							else if (timelines.Count >= 1)
							{
								int num10 = 0;
								do
								{
									AttachmentTimeline attachmentTimeline2 = items2[num10] as AttachmentTimeline;
									if (attachmentTimeline2 != null)
									{
										ApplyAttachmentTimeline((AttachmentTimeline)items2[num10], skeleton, animationTime, mixBlend, attachments: true);
										int num8 = 1;
									}
									else
									{
										items2[num10].Apply(skeleton, trackEntry.AnimationLast, animationTime, events, num3, mixBlend, default(MixDirection));
										int num8 = 0;
									}
									num10++;
								}
								while (num10 != timelines.Count);
							}
							QueueEvents(items[num], animationTime);
							events.Clear(clearArray: false);
							trackEntry.nextAnimationLast = animationTime;
							trackEntry.nextTrackLast = trackEntry.TrackTime;
							items = exposedList.Items;
							count = exposedList.Count;
							animationState = this;
							num2 = 1;
						}
						num++;
					}
					while (num != count);
				}
				else
				{
					animationState = this;
					num2 = 0;
				}
				ExposedList<Slot> slots = skeleton.Slots;
				int num11 = animationState.unkeyedState;
				if (slots.Count >= 1)
				{
					Slot[] items4 = slots.Items;
					int num12 = animationState.unkeyedState + 1;
					int num13 = 0;
					do
					{
						Slot slot = items4[num13];
						if (slot.attachmentState == num12)
						{
							SlotData slotData = slot.Data;
							Attachment attachment2;
							if (slotData.AttachmentName != null)
							{
								Attachment attachment = skeleton.GetAttachment(slotData.Index, slotData.AttachmentName);
								attachment2 = attachment;
							}
							else
							{
								attachment2 = null;
							}
							items4[num13].Attachment = attachment2;
						}
						num13++;
					}
					while (slots.Count != num13);
					num11 = animationState.unkeyedState;
				}
				int num14 = num11 + 2;
				animationState.unkeyedState = num14;
				animationState.queue.Drain();
				return (byte)(num2 & 1) != 0;
			}
			ArgumentNullException ex = new ArgumentNullException("skeleton", "skeleton cannot be null.");
			throw ex;
		}

		[Token(Token = "0x60000C2")]
		[Address(RVA = "0x1529A1C", Offset = "0x1529A1C", Length = "0x2BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv38 = Spine.EventTimeline;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, skeleton, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv61 = Il2CppMethodInfo;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, skeleton, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv157 = Spine.Timeline;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v157, skeleton, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv57 = 1;\n\t*([1A37AF7]) = v57;\nL_0023:\n\tv59 = v225 == 0;\n\tif (v59) goto L_0122;\n\tv63 = this.tracks;\n\tv169 = v63.Count < 1;\n\tif (v169) goto L_FFFFFFFF;\n\tv250 = v63.Items;\nL_004A:\n\tv238 = v250[v244 @ X26_v6 (System.Int32)];\n\tv399 = v250[v244 @ X26_v6 (System.Int32)] == 0;\n\tif (v399) goto L_00FA;\n\tv253 = v238.delay > 0;\n\tif (v253) goto L_00FA;\n\tv507 = v238.mixingFrom == 0;\n\tif (v507) goto L_0064;\n\tv511 = Spine.AnimationState::ApplyMixingFromEventTimelinesOnly(this, v250[v244 @ X26_v6 (System.Int32)], v225);\nL_0064:\n\tv234 = Spine.TrackEntry::get_AnimationTime(v250[v244 @ X26_v6 (System.Int32)]);\n\tv310 = v238.animation;\n\tv311 = v310.timelines;\n\tv254 = v311.Count < 1;\n\tif (v254) goto L_00ED;\n\tv208 = v311.Items;\nL_008A:\n\tv524 = v208[v426 @ X19_v15 (System.Int32)];\n\tv560 = v208[v426 @ X19_v15 (System.Int32)] == 0;\n\tif (v560) goto L_00DE;\n\tv561 = *([v524 @ X23_v10 (Spine.Timeline)]);\n\tgoto L_FFFFFFFF;\n\tv592 = v592_asT == 0;\n\tif (v592) goto L_00DE;\n\tv658 = *([v561 @ X8_v23 (Il2CppClass<Spine.Timeline>)+12E]);\n\tv618 = *([v561 @ X8_v23 (Il2CppClass<Spine.Timeline>)+12E]) == 0;\n\tif (v618) goto L_00CD;\n\tv656 = *([v561 @ X8_v23 (Il2CppClass<Spine.Timeline>)+B0]) + 8;\nL_00B3:\n\t;\n\tv672 = *([v656 @ X10_v19-8]) == Spine.Timeline;\n\tif (v672) goto L_00CF;\n\tv634 = v658 - 1;\n\tv656 = v656 + 0x10;\n\tv636 = v658 != 1;\n\tif (v636) goto L_00B3;\nL_00CD:\n\tv683 = 0xB349B4(v208[v426 @ X19_v15 (System.Int32)], Spine.Timeline, 0, v520, v516, v519, v44, v45, v529, v517, v518, v49, v50, v51, v52, v53);\n\tgoto L_00D4;\nL_00CF:\n\t;\n\tv679 = *([v656 @ X10_v19]) << 4;\n\tv680 = *([v524 @ X23_v10 (Spine.Timeline)]) + v679;\n\tv683 = v680 + 0x138;\nL_00D4:\n\tv519 = *([v683 @ X0_v35+8]);\n\tSpine.Timeline::Apply(v208[v426 @ X19_v15 (System.Int32)], v225, v238.animationLast, v234, this.events, 1f, 0, 0);\nL_00DE:\n\tv426 = v426 + 1;\n\tv531 = v426 != v311.Count;\n\tif (v531) goto L_008A;\nL_00ED:\n\tSpine.AnimationState::QueueEvents(this, v250[v244 @ X26_v6 (System.Int32)], v234);\n\tSpine.ExposedList`1<Spine.Event>::Clear(this.events, 0);\n\tv238.nextAnimationLast = v234;\n\tv238.nextTrackLast = v238.trackTime;\nL_00FA:\n\tv244 = v244 + 1;\n\tv346 = v244 != v63.Count;\n\tif (v346) goto L_004A;\n\tgoto L_010B;\nL_010B:\n\tSpine.EventQueue::Drain(this.queue);\n\treturnVal1 = v317 & 1;\n\treturn returnVal1;\n\tv298 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\nL_0122:\n\tv318 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v318, \"skeleton\", \"skeleton cannot be null.\");\n\tthrow v318;\n// 237 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool ApplyEventTimelinesOnly(Skeleton skeleton)
		{
			//IL_01ec: Expected I, but got O
			//IL_0234: Expected O, but got I
			//IL_0465: Expected O, but got I
			//IL_0270: Expected O, but got I
			//IL_02d9: Expected I4, but got O
			//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e6: Expected O, but got Unknown
			//IL_02f5: Expected O, but got I
			//IL_0284: Expected O, but got I
			//IL_0293: Expected O, but got I
			Skeleton skeleton2 = default(Skeleton);
			if (skeleton2 != null)
			{
				ExposedList<TrackEntry> exposedList = Tracks;
				int num2;
				if (exposedList.Count >= 1)
				{
					TrackEntry[] items = exposedList.Items;
					int num = 0;
					num2 = 0;
					MixDirection mixDirection = default(MixDirection);
					float num4 = default(float);
					float num5 = default(float);
					object obj = default(object);
					MixBlend mixBlend = default(MixBlend);
					do
					{
						TrackEntry trackEntry = items[num];
						if (items[num] != null && !(trackEntry.Delay > 0f))
						{
							if (trackEntry.MixingFrom != null)
							{
								float num3 = ApplyMixingFromEventTimelinesOnly(items[num], skeleton2);
							}
							float animationTime = items[num].AnimationTime;
							Animation animation = trackEntry.Animation;
							ExposedList<Timeline> timelines = animation.Timelines;
							if (timelines.Count >= 1)
							{
								Timeline[] items2 = timelines.Items;
								mixDirection = mixDirection;
								num4 = num4;
								num5 = num5;
								obj = obj;
								mixBlend = mixBlend;
								float num6 = animationTime;
								int num7 = 0;
								do
								{
									Timeline timeline = items2[num7];
									if (items2[num7] != null)
									{
										nint num8 = (nint)timeline;
										EventTimeline eventTimeline = items2[num7] as EventTimeline;
										if (eventTimeline != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ X8_v23 (Il2CppClass<Spine.Timeline>)+12E]");
											object obj2 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ X8_v23 (Il2CppClass<Spine.Timeline>)+12E]");
											if ((nint)0 == 0)
											{
												goto IL_02bb;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ X8_v23 (Il2CppClass<Spine.Timeline>)+B0]");
											object obj3 = (nint)0 + (nint)8;
											while (true)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v656 @ X10_v19-8]");
												if (0 == (nint)typeof(Timeline))
												{
													break;
												}
												object obj4 = (nint)obj2 - 1;
												obj3 = (nint)obj3 + 16;
												bool flag = (nint)obj2 != 1;
												obj2 = obj4;
												if (flag)
												{
													continue;
												}
												goto IL_02bb;
											}
											int num9 = obj3 << 4;
											object obj5 = timeline + num9;
											object obj6 = (nint)obj5 + 312;
											goto IL_0455;
										}
									}
									goto IL_03f7;
									IL_0455:
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v683 @ X0_v35+8]");
									obj = 0;
									items2[num7].Apply(skeleton2, trackEntry.AnimationLast, animationTime, events, 1f, default(MixBlend), default(MixDirection));
									mixDirection = default(MixDirection);
									num4 = animationTime;
									num5 = 1f;
									mixBlend = default(MixBlend);
									num6 = trackEntry.AnimationLast;
									goto IL_03f7;
									IL_03f7:
									num7++;
									continue;
									IL_02bb:
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @B349B4");
									goto IL_0455;
								}
								while (num7 != timelines.Count);
							}
							QueueEvents(items[num], animationTime);
							events.Clear(clearArray: false);
							trackEntry.nextAnimationLast = animationTime;
							trackEntry.nextTrackLast = trackEntry.TrackTime;
							num2 = 1;
						}
						num++;
					}
					while (num != exposedList.Count);
				}
				else
				{
					num2 = 0;
				}
				queue.Drain();
				return (byte)(num2 & 1) != 0;
			}
			ArgumentNullException ex = new ArgumentNullException("skeleton", "skeleton cannot be null.");
			throw ex;
		}

		[Token(Token = "0x60000C3")]
		[Address(RVA = "0x1528B5C", Offset = "0x1528B5C", Length = "0x638")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003B;\n\tv54 = Spine.AnimationState;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, to, skeleton, blend, methodInfo, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv74 = Spine.AttachmentTimeline;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, to, skeleton, blend, methodInfo, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv371 = Spine.DrawOrderTimeline;\n\tv372 = \"il2cpp_codegen_initialize_runtime_metadata\"(v371, to, skeleton, blend, methodInfo, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv442 = Il2CppMethodInfo;\n\tv443 = \"il2cpp_codegen_initialize_runtime_metadata\"(v442, to, skeleton, blend, methodInfo, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv466 = Il2CppMethodInfo;\n\tv467 = \"il2cpp_codegen_initialize_runtime_metadata\"(v466, to, skeleton, blend, methodInfo, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv492 = System.Math;\n\tv493 = \"il2cpp_codegen_initialize_runtime_metadata\"(v492, to, skeleton, blend, methodInfo, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv599 = Spine.RotateTimeline;\n\tv600 = \"il2cpp_codegen_initialize_runtime_metadata\"(v599, to, skeleton, blend, methodInfo, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv606 = Spine.Timeline;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v606, to, skeleton, blend, methodInfo, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv71 = 1;\n\t*([1A37AF8]) = v71;\nL_003B:\n\tv76 = to.mixingFrom;\n\tv374 = v76.mixingFrom == 0;\n\tif (v374) goto L_0050;\n\tv448 = Spine.AnimationState::ApplyMixingFrom(this, v76, v309, v306);\nL_0050:\n\tv461 = to.mixDuration != 0;\n\tif (v461) goto L_006E;\n\tv477 = v306 != 1;\n\tif (v477) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_007F;\nL_006E:\n\tv489 = to.mixTime / to.mixDuration;\n\tv170 = UnityEngine.Mathf::Min(v489, 1f);\n\tv496 = v306 != 1;\n\tif (v496) goto L_0074;\n\tgoto L_007F;\nL_0074:\n\tv184 = v76.mixBlend;\nL_007F:\n\tv192 = v170 >= v76.eventThreshold;\n\tif (v192) goto L_FFFFFFFF;\n\tv353 = this.events;\n\tgoto L_0089;\nL_0089:\n\tv671 = Spine.TrackEntry::get_AnimationTime(v76);\n\tv355 = v76.animation;\n\tv356 = v355.timelines;\n\tv300 = v76.alpha;\n\tv180 = to.interruptAlpha;\n\tv351 = v356.Items;\n\tv173 = 1f - v170;\n\tv161 = v76.alpha * to.interruptAlpha;\n\tv159 = v173 * v161;\n\tv195 = v184 != 3;\n\tif (v195) goto L_0106;\n\tv193 = v356.Count < 1;\n\tif (v193) goto L_02D5;\nL_00B8:\n\tv711 = v366 < v351.Length;\n\tv288 = ~v711;\n\tif (v288) goto L_02FE;\n\tgoto L_00F8;\n\tv724 = *([v721 @ X8_v45+B0]);\n\tv725 = v724 + 8;\n\tv727 = *([v755 @ X10_v22-8]);\n\tv770 = v727 == v722;\n\tif (v770) goto L_00EA;\n\tv731 = v756 - 1;\n\tv729 = v755 + 0x10;\n\tv733 = v756 != 1;\n\tif (v733) goto L_FFFFFFFF;\n\tv750 = v185;\n\tv751 = 0;\n\tv752 = 0xB349B4(v750, v722, v751, v305, v90, v86, v58, v59, v299, v179, v174, v63, v64, v65, v66, v67);\n\tgoto L_00F8;\nL_00EA:\n\tv786 = *([v755 @ X10_v22]);\n\tv787 = v786 << 4;\n\tv788 = v721 + v787;\n\tv789 = v788 + 0x138;\nL_00F8:\n\tSpine.Timeline::Apply(v351[v366 @ X19_v9 (System.Int32)], v309, v76.animationLast, v671, v353, v159, 3, 1);\n\tv366 = v366 + 1;\n\tv643 = v366 != v356.Count;\n\tif (v643) goto L_00B8;\n\tgoto L_02D5;\nL_0106:\n\tv358 = v76.timelineMode;\n\tv143 = v76.timelineHoldMix;\n\tv328 = v76.timelinesRotation;\n\tv367 = v358.Items;\n\tv713 = v143.Items;\n\tv318 = v356.Count << 1;\n\tv254 = v328.Count == v356.Count;\n\tif (v254) goto L_0131;\n\tv717 = Spine.ExposedList`1<System.Single>::Resize(v328, v318);\n\tv328 = v76.timelinesRotation;\nL_0131:\n\tv76.totalAlpha = 0f;\n\tv196 = v356.Count < 1;\n\tif (v196) goto L_02D5;\nL_0139:\n\t;\n\tv784 = v348 < v351.Length;\n\tv292 = ~v784;\n\tif (v292) goto L_02FE;\n\tv804 = v348 < v367.Length;\n\tv422 = ~v804;\n\tif (v422) goto L_02FE;\n\tv362 = v367[v348 @ X20_v7 (System.Int32)];\n\tv808 = v367[v348 @ X20_v7 (System.Int32)] < 3;\n\tv293 = ~v808;\n\tv281 = v367[v348 @ X20_v7 (System.Int32)] - 3;\n\tv257 = v281 == 0;\n\tv809 = ~v257;\n\tv198 = v293 & v809;\n\tif (v198) goto L_017F;\n\tv520 = 0x44C000 + 0xD19;\n\tv535 = *([v520 @ X11_v17 (System.Int32)+v362 @ X8_v20 (System.Int32)]) << 2;\n\tv532 = 0x152CE58 + v535;\n\t// 363 IndirectJump v532 @ X9_v20 (System.Int32), v328 @ X0_v15 (Spine.ExposedList`1<System.Single>), v328 @ X0_v15 (Spine.ExposedList`1<System.Single>), v319 @ X1_v9 (System.Int32), v313 @ X2_v7, v306 @ X3_v5 (Spine.MixBlend), v91 @ X4_v4 (Il2CppMethodInfo), v936 @ TEMPCOND_v23 (System.Boolean), v58 @ X6, v59 @ X7, v300 @ V0_v18 (System.Single), v180 @ V1_v6 (System.Single), v173 @ V2_v5 (System.Single), v63 @ V3, v64 @ V4, v65 @ V5, v66 @ V6, v67 @ V7\n\tC = V8 < V14;\n\tC = ~C;\n\tTEMP1 = V8 - V14;\n\tN = TEMP1 < 0;\n\tTEMP2 = V8 ^ V14;\n\tTEMP3 = V8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~N;\n\tif (TEMPCOND) goto L_02A0;\n\tV0 = *([X22+AC]);\n\tX27 = X24;\n\tV12 = V11;\n\tV0 = V11 + V0;\n\tgoto L_01A9;\nL_017F:\n\t;\n\tv812 = v348 < v713.Length;\n\tv294 = ~v812;\n\tif (v294) goto L_02FE;\n\tv363 = v713[v348 @ X20_v7 (System.Int32)];\n\tgoto L_0199;\n\tv820 = \"il2cpp_codegen_runtime_class_init\"(v817, v319, v313, v306, v91, v87, v58, v59, v300, v180, v173, v63, v64, v65, v66, v67);\nL_0199:\n\tv822 = v363.mixTime / v363.mixDuration;\n\tv180 = 1f - v822;\n\tv825 = System.Math::Max(0f, v180);\n\tv108 = v161 * v825;\n\tgoto L_01A8;\n\tX27 = 0;\n\tV12 = V11;\n\tgoto L_01A8;\n\tX27 = 0;\n\tV12 = V15;\nL_01A8:\n\treturnVal3 = v108 + v76.totalAlpha;\nL_01A9:\n\tv76.totalAlpha = returnVal3;\nL_01BC:\n\tgoto L_FFFFFFFF;\n\tv851 = v851_asT != 0;\n\tif (v851) goto L_020B;\n\tgoto L_FFFFFFFF;\n\tv895 = v895_asT != 0;\n\tif (v895) goto L_0294;\n\tv919 = v170 >= v76.drawOrderThreshold;\n\tif (v919) goto L_0204;\n\tgoto L_FFFFFFFF;\n\tgoto L_024F;\nL_0204:\n\tgoto L_024F;\nL_020B:\n\tgoto L_0210;\n\tv920 = \"il2cpp_codegen_runtime_class_init\"(v883, v319, v313, v306, v91, v87, v58, v59, returnVal3, v182, v173, v63, v64, v65, v66, v67);\nL_0210:\n\tv925 = v348 << 1;\n\tv929 = v328.Count - v318;\n\tv931 = v929 == 0;\n\tv936 = ~v931;\n\tSpine.AnimationState::ApplyRotateTimeline(v351[v348 @ X20_v7 (System.Int32)], v309, v671, v108, 0, v328.Items, v925, v936);\n\tgoto L_0281;\n\tv986 = v986_asT == 0;\n\tif (v986) goto L_024F;\n\tgoto L_024F;\nL_024F:\n\tv583 = 0x1854D98(0, v319, v313, v306, v91, v936, v58, v59, returnVal3, v180, v173, v63, v64, v65, v66, v67);\n\treturn returnVal3;\n\tX1 = *([1945000]);\n\tif (TEMP) goto L_026E;\n\tX10 = *([X8+B0]);\n\tX10 = X10 + 8;\nL_0256:\n\tX11 = *([X10-8]);\n\tC = X11 < X1;\n\tC = ~C;\n\tTEMP1 = X11 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X1;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0272;\n\tC = X9 < 1;\n\tC = ~C;\n\tTEMP1 = X9 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ 1;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX9 = X9 - 1;\n\tX10 = X10 + 0x10;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0256;\nL_026E:\n\tX0 = X26;\n\tX2 = 0;\n\tX0 = 0xB349B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_0276;\nL_0272:\n\tX9 = *([X10]);\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tX0 = X8 + 0x138;\nL_0276:\n\tX8 = *([X0]);\n\tX5 = *([X0+8]);\n\tX0 = X26;\n\tX1 = X21;\n\tV0 = V10;\n\tV1 = V9;\n\tX2 = X23;\n\tV2 = V12;\n\tX3 = X27;\n\tX4 = X28;\n\tX8(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0281:\n\tv348 = v348 + 1;\n\tv644 = v348 != v356.Count;\n\tif (v644) goto L_0139;\n\tgoto L_02D5;\nL_0294:\n\tv948 = v170 - v76.attachmentThreshold;\n\tv949 = v948 < 0;\n\tSpine.AnimationState::ApplyAttachmentTimeline(this, v351[v348 @ X20_v7 (System.Int32)], v309, v671, 0, v949);\n\tgoto L_0281;\nL_02A0:\n\tTEMP = X26 == 0;\n\tif (TEMP) goto L_02FF;\n\tX9 = *([X26]);\n\tX8 = *([1945EE0]);\n\tX11 = *([X9+130]);\n\tX8 = *([X8]);\n\tX10 = *([X8+130]);\n\tC = X11 < X10;\n\tC = ~C;\n\tTEMP1 = X11 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X10;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_02C1;\n\tX9 = *([X9+C8]);\n\tTEMPSHIFT = X10 << 3;\n\tX9 = X9 + TEMPSHIFT;\n\tX9 = *([X9-8]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0281;\nL_02C1:\n\tV0 = *([X22+AC]);\n\tX27 = X24;\n\tV12 = V11;\n\tV0 = V11 + V0;\n\t*([X22+AC]) = V0;\n\tgoto L_01BC;\nL_02D5:\n\tv199 = to.mixDuration <= 0;\n\tif (v199) goto L_02E2;\n\tSpine.AnimationState::QueueEvents(this, v76, v671);\nL_02E2:\n\tSpine.ExposedList`1<Spine.Event>::Clear(this.ev\n// ... truncated")]
		private float ApplyMixingFrom(TrackEntry to, Skeleton skeleton, MixBlend blend)
		{
			//IL_02cd: Expected O, but got I
			//IL_05f7: Expected I4, but got O
			//IL_0600: Expected O, but got I4
			//IL_0608: Expected I4, but got O
			//IL_06d8: Expected I4, but got O
			TrackEntry mixingFrom = to.MixingFrom;
			Skeleton skeleton2 = default(Skeleton);
			MixBlend mixBlend = default(MixBlend);
			if (mixingFrom.MixingFrom != null)
			{
				float num = ApplyMixingFrom(mixingFrom, skeleton2, mixBlend);
			}
			MixBlend mixBlend2;
			float num2;
			if (to.MixDuration == 0f)
			{
				mixBlend2 = ((mixBlend != MixBlend.First) ? mixBlend : default(MixBlend));
				num2 = 1f;
			}
			else
			{
				float a = to.MixTime / to.MixDuration;
				num2 = Mathf.Min(a, 1f);
				mixBlend2 = ((mixBlend == MixBlend.First) ? MixBlend.First : mixingFrom.MixBlend);
			}
			ExposedList<Event> exposedList = ((!(num2 < mixingFrom.EventThreshold)) ? null : events);
			float animationTime = mixingFrom.AnimationTime;
			Animation animation = mixingFrom.Animation;
			ExposedList<Timeline> timelines = animation.Timelines;
			float alpha = mixingFrom.Alpha;
			float interruptAlpha = to.interruptAlpha;
			Timeline[] items = timelines.Items;
			float num3 = 1f - num2;
			float num4 = mixingFrom.Alpha * to.interruptAlpha;
			float num5 = num3 * num4;
			float num10 = default(float);
			TrackEntry trackEntry = default(TrackEntry);
			object obj;
			if (mixBlend2 == MixBlend.Add)
			{
				bool flag = timelines.Count < 1;
				obj = skeleton2;
				if (flag)
				{
					goto IL_06e2;
				}
				int num6 = 0;
				while (num6 < items.Length)
				{
					items[num6].Apply(skeleton2, mixingFrom.AnimationLast, animationTime, exposedList, num5, MixBlend.Add, MixDirection.Out);
					num6++;
					if (num6 != timelines.Count)
					{
						continue;
					}
					goto IL_020b;
				}
			}
			else
			{
				ExposedList<int> timelineMode = mixingFrom.timelineMode;
				ExposedList<TrackEntry> timelineHoldMix = mixingFrom.timelineHoldMix;
				ExposedList<float> exposedList2 = mixingFrom.timelinesRotation;
				int[] items2 = timelineMode.Items;
				TrackEntry[] items3 = timelineHoldMix.Items;
				int num7 = timelines.Count << 1;
				bool flag2 = exposedList2.Count == timelines.Count;
				obj = skeleton2;
				if (!flag2)
				{
					ExposedList<float> exposedList3 = exposedList2.Resize(num7);
					exposedList2 = mixingFrom.timelinesRotation;
					obj = 0;
				}
				mixingFrom.totalAlpha = 0f;
				if (timelines.Count < 1)
				{
					goto IL_06e2;
				}
				int num8 = num7;
				int num9 = 0;
				while (true)
				{
					bool flag3 = num9 < items.Length;
					bool flag4 = !flag3;
					num10 = num5;
					trackEntry = mixingFrom;
					if (flag4)
					{
						break;
					}
					bool flag5 = num9 < items2.Length;
					bool flag6 = !flag5;
					num10 = num5;
					trackEntry = mixingFrom;
					if (flag6)
					{
						break;
					}
					int num11 = items2[num9];
					bool flag7 = items2[num9] < 3;
					bool flag8 = !flag7;
					int num12 = items2[num9] - 3;
					bool flag9 = num12 == 0;
					bool flag10 = !flag9;
					if (!(flag8 && flag10))
					{
						int num13 = 4505600 + 3353;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v520 @ X11_v17 (System.Int32)+v362 @ X8_v20 (System.Int32)]");
						int num14 = (int)((nint)0 << 2);
						int num15 = 22203992 + num14;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v532 @ X9_v20 (System.Int32) (should have been resolved before IL gen)");
					}
					bool flag11 = num9 < items3.Length;
					bool flag12 = !flag11;
					num10 = num5;
					trackEntry = mixingFrom;
					if (flag12)
					{
						break;
					}
					TrackEntry trackEntry2 = items3[num9];
					float num16 = trackEntry2.MixTime / trackEntry2.MixDuration;
					interruptAlpha = 1f - num16;
					float num17 = Math.Max(0f, interruptAlpha);
					float num18 = num4 * num17;
					float result = (mixingFrom.totalAlpha = num18 + mixingFrom.totalAlpha);
					RotateTimeline rotateTimeline = items[num9] as RotateTimeline;
					if (rotateTimeline == null)
					{
						AttachmentTimeline attachmentTimeline = items[num9] as AttachmentTimeline;
						if (attachmentTimeline == null)
						{
							if (num2 < mixingFrom.DrawOrderThreshold)
							{
								DrawOrderTimeline drawOrderTimeline = items[num9] as DrawOrderTimeline;
								if (drawOrderTimeline == null)
								{
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854D98 (inside System.__Il2CppComDelegate::Finalize +0x184)");
							return result;
						}
						float num19 = num2 - mixingFrom.AttachmentThreshold;
						bool flag13 = num19 < 0f;
						ApplyAttachmentTimeline((AttachmentTimeline)items[num9], skeleton2, animationTime, default(MixBlend), flag13);
						nint num20 = (flag13 ? 1 : 0);
						mixBlend = default(MixBlend);
						obj = skeleton2;
						num8 = (int)items[num9];
						exposedList2 = (ExposedList<float>)(object)this;
					}
					else
					{
						int num21 = num9 << 1;
						int num22 = exposedList2.Count - num7;
						bool flag14 = num22 == 0;
						bool firstFrame = !flag14;
						ApplyRotateTimeline((RotateTimeline)items[num9], skeleton2, animationTime, num18, default(MixBlend), exposedList2.Items, num21, firstFrame);
						nint num20 = num21;
						interruptAlpha = num18;
						mixBlend = (MixBlend)exposedList2.Items;
						obj = 0;
						num8 = (int)skeleton2;
						exposedList2 = (ExposedList<float>)items[num9];
					}
					num9++;
					bool flag15 = num9 != timelines.Count;
					alpha = animationTime;
					if (flag15)
					{
						continue;
					}
					goto IL_06e2;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			float totalAlpha = num10 + trackEntry.totalAlpha;
			trackEntry.totalAlpha = totalAlpha;
			throw ex;
			IL_06e2:
			if (to.MixDuration > 0f)
			{
				QueueEvents(mixingFrom, animationTime);
			}
			events.Clear(clearArray: false);
			mixingFrom.nextAnimationLast = animationTime;
			mixingFrom.nextTrackLast = mixingFrom.TrackTime;
			return num2;
			IL_020b:
			obj = exposedList;
			goto IL_06e2;
		}

		[Token(Token = "0x60000C4")]
		[Address(RVA = "0x1529CD8", Offset = "0x1529CD8", Length = "0x240")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv42 = Spine.EventTimeline;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, to, skeleton, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv63 = Il2CppMethodInfo;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, to, skeleton, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv208 = Spine.Timeline;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v208, to, skeleton, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv60 = 1;\n\t*([1A37AF9]) = v60;\nL_0026:\n\tv65 = to.mixingFrom;\n\tv210 = v65.mixingFrom == 0;\n\tif (v210) goto L_0036;\n\tv214 = Spine.AnimationState::ApplyMixingFromEventTimelinesOnly(this, v65, v184);\nL_0036:\n\tv223 = to.mixDuration == 0;\n\tif (v223) goto L_0057;\n\tv363 = to.mixTime;\n\tv177 = to.mixTime / to.mixDuration;\n\tv320 = v177 <= 1f;\n\tif (v320) goto L_0057;\nL_0057:\n\tv121 = v177 >= v65.eventThreshold;\n\tif (v121) goto L_0114;\n\tv334 = this.events == 0;\n\tif (v334) goto L_0114;\n\tv180 = Spine.TrackEntry::get_AnimationTime(v65);\n\tv202 = v65.animation;\n\tv203 = v202.timelines;\n\tv122 = v203.Count < 1;\n\tif (v122) goto L_00F2;\n\tv108 = v203.Items;\nL_0088:\n\tv358 = v108[v99 @ X27_v6 (System.Int32)];\n\tv415 = v108[v99 @ X27_v6 (System.Int32)] == 0;\n\tif (v415) goto L_00DA;\n\tv416 = *([v358 @ X24_v6 (Spine.Timeline)]);\n\tgoto L_FFFFFFFF;\n\tv443 = v443_asT == 0;\n\tif (v443) goto L_00DA;\n\tv511 = *([v416 @ X8_v15 (Il2CppClass<Spine.Timeline>)+12E]);\n\tv473 = *([v416 @ X8_v15 (Il2CppClass<Spine.Timeline>)+12E]) == 0;\n\tif (v473) goto L_00C9;\n\tv509 = *([v416 @ X8_v15 (Il2CppClass<Spine.Timeline>)+B0]) + 8;\nL_00B4:\n\tv525 = *([v509 @ X10_v13-8]) == Spine.Timeline;\n\tif (v525) goto L_00CC;\n\tv487 = v511 - 1;\n\tv509 = v509 + 0x10;\n\tv489 = v511 != 1;\n\tif (v489) goto L_00B4;\nL_00C9:\n\tv536 = 0xB349B4(v108[v99 @ X27_v6 (System.Int32)], Spine.Timeline, 0, 0, 1, *([v536 @ X0_v14+8]), v47, v48, v381, v363, 0, v52, v53, v54, v55, v56);\n\tgoto L_00D9;\nL_00CC:\n\tv532 = *([v509 @ X10_v13]) << 4;\n\tv533 = v416 + v532;\n\tv536 = v533 + 0x138;\nL_00D9:\n\tSpine.Timeline::Apply(v108[v99 @ X27_v6 (System.Int32)], v184, v65.animationLast, v180, this.events, 0f, 0, 1);\nL_00DA:\n\tv99 = v99 + 1;\n\tv362 = v99 != v203.Count;\n\tif (v362) goto L_0088;\nL_00F2:\n\tv123 = to.mixDuration <= 0;\n\tif (v123) goto L_00FF;\n\tSpine.AnimationState::QueueEvents(this, v65, v180);\nL_00FF:\n\tSpine.ExposedList`1<Spine.Event>::Clear(this.events, 0);\n\tv65.nextAnimationLast = v180;\n\tv65.nextTrackLast = v65.trackTime;\nL_0114:\n\treturn v177;\n\tv191 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 215 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private float ApplyMixingFromEventTimelinesOnly(TrackEntry to, Skeleton skeleton)
		{
			//IL_01b0: Expected I, but got O
			//IL_01f8: Expected O, but got I
			//IL_0233: Expected O, but got I
			//IL_029b: Expected I4, but got O
			//IL_02a9: Expected O, but got I
			//IL_02b8: Expected O, but got I
			//IL_0247: Expected O, but got I
			//IL_0256: Expected O, but got I
			TrackEntry mixingFrom = to.MixingFrom;
			Skeleton skeleton2 = default(Skeleton);
			if (mixingFrom.MixingFrom != null)
			{
				float num = ApplyMixingFromEventTimelinesOnly(mixingFrom, skeleton2);
			}
			bool flag = to.MixDuration == 0f;
			float num2 = 1f;
			if (!flag)
			{
				float mixTime = to.MixTime;
				num2 = to.MixTime / to.MixDuration;
				if (num2 > 1f)
				{
					num2 = 1f;
				}
			}
			if (num2 < mixingFrom.EventThreshold && events != null)
			{
				float animationTime = mixingFrom.AnimationTime;
				Animation animation = mixingFrom.Animation;
				ExposedList<Timeline> timelines = animation.Timelines;
				if (timelines.Count >= 1)
				{
					Timeline[] items = timelines.Items;
					int num3 = 0;
					float num4 = animationTime;
					do
					{
						Timeline timeline = items[num3];
						if (items[num3] != null)
						{
							nint num5 = (nint)timeline;
							EventTimeline eventTimeline = items[num3] as EventTimeline;
							if (eventTimeline != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ X8_v15 (Il2CppClass<Spine.Timeline>)+12E]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ X8_v15 (Il2CppClass<Spine.Timeline>)+12E]");
								if ((nint)0 == 0)
								{
									goto IL_027e;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ X8_v15 (Il2CppClass<Spine.Timeline>)+B0]");
								object obj2 = (nint)0 + (nint)8;
								while (true)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ X10_v13-8]");
									if (0 == (nint)typeof(Timeline))
									{
										break;
									}
									object obj3 = (nint)obj - 1;
									obj2 = (nint)obj2 + 16;
									bool flag2 = (nint)obj != 1;
									obj = obj3;
									if (flag2)
									{
										continue;
									}
									goto IL_027e;
								}
								int num6 = obj2 << 4;
								object obj4 = num5 + num6;
								object obj5 = (nint)obj4 + 312;
								goto IL_03b3;
							}
						}
						goto IL_0356;
						IL_03b3:
						items[num3].Apply(skeleton2, mixingFrom.AnimationLast, animationTime, events, 0f, default(MixBlend), MixDirection.Out);
						float mixTime = animationTime;
						num4 = mixingFrom.AnimationLast;
						goto IL_0356;
						IL_0356:
						num3++;
						continue;
						IL_027e:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @B349B4");
						goto IL_03b3;
					}
					while (num3 != timelines.Count);
				}
				if (to.MixDuration > 0f)
				{
					QueueEvents(mixingFrom, animationTime);
				}
				events.Clear(clearArray: false);
				mixingFrom.nextAnimationLast = animationTime;
				mixingFrom.nextTrackLast = mixingFrom.TrackTime;
			}
			return num2;
		}

		[Token(Token = "0x60000C5")]
		[Address(RVA = "0x1529244", Offset = "0x1529244", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = skeleton.slots;\n\tv91 = v14.Items;\n\tv84 = timeline.slotIndex;\n\tv34 = v91[v84 @ X9_v3 (System.Int32)];\n\tv93 = v34.bone;\n\tv208 = ~v93.active;\n\tif (v208) goto L_0092;\n\tv29 = timeline.frames;\n\tv244 = v29[0] <= time;\n\tif (v244) goto L_0051;\n\tv245 = blend < 1;\n\tv77 = ~v245;\n\tv72 = blend - 1;\n\tv62 = v72 == 0;\n\tv246 = ~v62;\n\tv19 = v77 & v246;\n\tif (v19) goto L_0087;\n\tv280 = v34.data + 0x48;\n\tgoto L_0079;\nL_0051:\n\tv96 = v29.Length - 1;\n\tv249 = v29[v96 @ X8_v15 (System.Int32)] < time;\n\tv78 = ~v249;\n\tv73 = v29[v96 @ X8_v15 (System.Int32)] - time;\n\tv63 = v73 == 0;\n\tv250 = ~v78;\n\tv20 = v250 | v63;\n\tif (v20) goto L_0071;\n\tv284 = Spine.Animation::BinarySearch(v29, time);\n\tv96 = v284 - 1;\nL_0071:\n\tv289 = v96 << 3;\n\tv291 = timeline.attachmentNames + v289;\n\tv280 = v291 + 0x20;\nL_0079:\n\tSpine.AnimationState::SetAttachment(this, skeleton, v91[v84 @ X9_v3 (System.Int32)], *([v280 @ X8_v10]), attachments);\nL_0087:\n\tv214 = v34.attachmentState > this.unkeyedState;\n\tif (v214) goto L_0092;\n\tv230 = this.unkeyedState + 1;\n\tv34.attachmentState = v230;\nL_0092:\n\treturn;\n\tv105 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ApplyAttachmentTimeline(AttachmentTimeline timeline, Skeleton skeleton, float time, MixBlend blend, bool attachments)
		{
			//IL_01f7: Expected O, but got I
			//IL_0206: Expected O, but got I
			//IL_012a: Expected O, but got I
			ExposedList<Slot> slots = skeleton.Slots;
			Slot[] items = slots.Items;
			int slotIndex = timeline.SlotIndex;
			Slot slot = items[slotIndex];
			Bone bone = slot.Bone;
			if (!bone.Active)
			{
				return;
			}
			float[] frames = timeline.Frames;
			object attachmentName;
			if (frames[0] > time)
			{
				bool flag = blend < MixBlend.First;
				bool flag2 = !flag;
				int num = (int)(blend - 1);
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (flag2 && flag4)
				{
					goto IL_020b;
				}
				attachmentName = (nint)slot.Data + 72;
			}
			else
			{
				int num2 = frames.Length - 1;
				bool flag5 = frames[num2] < time;
				bool flag6 = !flag5;
				float num3 = frames[num2] - time;
				bool flag7 = num3 == 0f;
				bool flag8 = !flag6;
				if (!(flag8 || flag7))
				{
					int num4 = Animation.BinarySearch(frames, time);
					num2 = num4 - 1;
				}
				int num5 = num2 << 3;
				object obj = (nint)timeline.AttachmentNames + num5;
				attachmentName = (nint)obj + 32;
			}
			SetAttachment(skeleton, items[slotIndex], (string)attachmentName, attachments);
			goto IL_020b;
			IL_020b:
			if (slot.attachmentState <= unkeyedState)
			{
				int attachmentState = unkeyedState + 1;
				slot.attachmentState = attachmentState;
			}
		}

		[Token(Token = "0x60000C6")]
		[Address(RVA = "0x1529F18", Offset = "0x1529F18", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = attachmentName == 0;\n\tif (v14) goto L_FFFFFFFF;\n\tv18 = slot.data;\n\tv45 = Spine.Skeleton::GetAttachment(skeleton, v18.index, attachmentName);\n\tgoto L_001E;\nL_001E:\n\tSpine.Slot::set_Attachment(slot, v38);\n\tv62 = attachments == 0;\n\tif (v62) goto L_002A;\n\tv71 = this.unkeyedState + 2;\n\tslot.attachmentState = v71;\nL_002A:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetAttachment(Skeleton skeleton, Slot slot, string attachmentName, bool attachments)
		{
			Attachment attachment2;
			if (attachmentName != null)
			{
				SlotData slotData = slot.Data;
				Attachment attachment = skeleton.GetAttachment(slotData.Index, attachmentName);
				attachment2 = attachment;
			}
			else
			{
				attachment2 = null;
			}
			slot.Attachment = attachment2;
			if (attachments)
			{
				int attachmentState = unkeyedState + 2;
				slot.attachmentState = attachmentState;
			}
		}

		[Token(Token = "0x60000C7")]
		[Address(RVA = "0x1529358", Offset = "0x1529358", Length = "0x554")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv50 = System.Math;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, skeleton, blend, timelinesRotation, i, firstFrame, methodInfo, v53, time, alpha, v54, v55, v56, v57, v58, v59);\n\tv62 = 1;\n\t*([1A37AFA]) = v62;\nL_0023:\n\tv64 = firstFrame == 0;\n\tif (v64) goto L_0041;\n\ttimelinesRotation[i @ X4 (System.Int32)] = 0;\nL_0041:\n\tv109 = alpha != 1f;\n\tif (v109) goto L_0062;\n\tv435 = timeline->klass;\n\tv439 = timeline->klass->vtable[6];\n\tv440 = timeline->klass->vtable[6];\n\t// 95 IndirectJump v439 @ X6_v1, timeline @ X0 (Spine.RotateTimeline), timeline @ X0 (Spine.RotateTimeline), skeleton @ X1 (Spine.Skeleton), 0, blend @ X2 (Spine.MixBlend), 0, v440 @ X5_v1, v439 @ X6_v1, v53 @ X7, 0, time @ V0 (System.Single), 1f, v55 @ V3, v120 @ V4_v3, v122 @ V5_v3 (System.Double), v58 @ V6, v59 @ V7\nL_0062:\n\tv281 = skeleton.bones;\n\tv282 = v281.Items;\n\tv137 = timeline.boneIndex;\n\tv292 = v282[v137 @ X9_v1 (System.Int32)];\n\tv544 = ~v292.active;\n\tif (v544) goto L_028B;\n\tv270 = timeline.frames;\n\tv179 = v270[0] <= time;\n\tif (v179) goto L_00A5;\n\tv577 = blend == 0;\n\tif (v577) goto L_00A9;\n\tv178 = blend != 1;\n\tif (v178) goto L_028B;\n\tv285 = v292.data;\n\tv145 = v292.rotation;\n\tv635 = v285.rotation;\n\tgoto L_0169;\nL_00A5:\n\tv592 = blend == 0;\n\tif (v592) goto L_00B1;\n\tv306 = v282[v137 @ X9_v1 (System.Int32)] + 0x38;\n\tgoto L_00BF;\nL_00A9:\n\tv286 = v292.data;\n\tv558 = v286.rotation;\n\tgoto L_027B;\nL_00B1:\n\tv306 = v292.data + 0x34;\nL_00BF:\n\tv618 = v270.Length << 0x20;\n\tv619 = 0xFFFFFFFE00000000 + v618;\n\tv175 = v619 >> 0x1E;\n\tv133 = v270 + v175;\n\tv145 = *([v306 @ X9_v22]);\n\tv620 = *([v133 @ X10_v7+20]) < time;\n\tv244 = ~v620;\n\tv236 = *([v133 @ X10_v7+20]) - time;\n\tv220 = v236 == 0;\n\tv621 = ~v244;\n\tv180 = v621 | v220;\n\tif (v180) goto L_015B;\n\tv411 = Spine.Animation::BinarySearch(v270, time, 2);\n\tv427 = v411 - 1;\n\tv302 = v411 - 2;\n\tv149 = time - v270[v411 @ X0_v34 (System.Int32)];\n\tv750 = v270[v302 @ X10_v9 (System.Int32)] - v270[v411 @ X0_v34 (System.Int32)];\n\tv127 = v411 >> 1;\n\tv751 = v149 / v750;\n\tv170 = v127 - 1;\n\tv752 = 1f - v751;\n\tv153 = Spine.CurveTimeline::GetCurvePercent(timeline, v170, v752);\n\tv139 = v411 + 1;\n\tv288 = v292.data;\n\tv810 = v270[v139 @ X9_v26 (System.Int32)] - v270[v427 @ X8_v43 (System.Int32)];\n\tv811 = v810 / 0xC3B40000;\n\tv814 = v811 + 16384.499999999996d;\n\tv817 = 0x4000 - v814;\n\tv628 = v817 * 0x168;\n\tv828 = v814 != 0x7FF0000000000000;\n\tif (v828) goto L_FFFFFFFF;\n\tgoto L_013C;\nL_013C:\n\tv914 = v810 - v913;\n\tv916 = v153 * v914;\n\tv918 = v270[v427 @ X8_v43 (System.Int32)] + v916;\n\tv920 = v918 + v288.rotation;\n\tv921 = v920 / 0xC3B40000;\n\tv923 = v921 + 16384.499999999996d;\n\tv925 = 0x4000 - v923;\n\tv663 = v925 * 0x168;\n\tv623 = v923 != 0x7FF0000000000000;\n\tif (v623) goto L_FFFFFFFF;\n\tgoto L_0159;\nL_0159:\n\tv635 = v920 - v640;\n\tgoto L_0169;\nL_015B:\n\tv140 = v292.data;\n\tv689 = v270.Length << 0x20;\n\tv690 = v689 + 0xFFFFFFFF00000000;\n\tv641 = v690 >> 0x1E;\n\tv662 = v270 + v641;\n\tv635 = v140.rotation + *([v662 @ X8_v42+20]);\nL_0169:\n\tv155 = v635 - v145;\n\tv667 = v155 / 0xC3B40000;\n\tv670 = v667 + 16384.499999999996d;\n\tv673 = 0x4000 - v670;\n\tv289 = v673 * 0x168;\n\tv118 = v670 != 0x7FF0000000000000;\n\tif (v118) goto L_FFFFFFFF;\n\tgoto L_0187;\nL_0187:\n\tv273 = v155 - v167;\n\tv181 = v273 != 0;\n\tif (v181) goto L_01A9;\n\tgoto L_024C;\nL_01A9:\n\tv695 = firstFrame == 0;\n\tv696 = ~v695;\n\tif (v696) goto L_01CE;\n\tv430 = i + 1;\nL_01CE:\n\tv720 = v273 < 0;\n\tv721 = v273 == 0;\n\tv723 = v273 ^ v273;\n\tv724 = v273 & v723;\n\tv725 = v724 < 0;\n\tv726 = v720 == v725;\n\tv727 = ~v721;\n\tv728 = v726 & v727;\n\tv733 = v161 < 0;\n\tv736 = v161 ^ v161;\n\tv737 = v161 & v736;\n\tv738 = v737 < 0;\n\tv740 = v733 == v738;\n\tgoto L_01EB;\n\tv758 = \"il2cpp_codegen_runtime_class_init\"(v739, v171, blend, timelinesRotation, i, firstFrame, methodInfo, v53, v155, v167, v150, v124, v120, v122, v58, v59);\nL_01EB:\n\tv762 = System.Math::Sign(v703);\n\tv890 = System.Math::Sign(v273);\n\tv800 = v762 == v890;\n\tif (v800) goto L_FFFFFFFF;\n\tgoto L_0201;\n\tv865 = \"il2cpp_codegen_runtime_class_init\"(v831, v171, blend, timelinesRotation, i, firstFrame, methodInfo, v53, v778, v167, v150, v124, v120, v122, v58, v59);\nL_0201:\n\tv836 = UnityEngine.Mathf::Abs(v703);\n\tv927 = v836 < 0x42B40000;\n\tv856 = ~v927;\n\tv854 = v836 - 0x42B40000;\n\tv850 = v854 == 0;\n\tv928 = ~v856;\n\tv840 = v928 | v850;\n\tif (v840) goto L_0290;\nL_0214:\n\tv903 = v273 < 0;\n\tv904 = v273 == 0;\n\tv906 = v273 ^ v273;\n\tv907 = v273 & v906;\n\tv908 = v907 < 0;\n\tv910 = v903 == v908;\n\tv115 = ~v904;\n\tv182 = v910 & v115;\n\tv911 = v273 + v161;\n\tv912 = 0x1854EF0(v890, v170, blend, timelinesRotation, i, firstFrame, methodInfo, v53, v161, 0x43B40000, 0x7FF0000000000000, v289, 0x7FF0000000000000, 0x4AB40000, v58, v59);\n\tv222 = v182 == v277;\n\tv164 = v911 - v161;\n\tif (v222) goto L_024B;\n\tgoto L_0235;\n\tv946 = \"il2cpp_codegen_runtime_class_init\"(v936, v171, blend, timelinesRotation, i, firstFrame, methodInfo, v53, v909, v168, v150, v124, v120, v122, v58, v59);\nL_0235:\n\tv942 = System.Math::Sign(v161);\n\tv944 = v942 * 0x168;\n\tv164 = v164 + v944;\nL_024B:\n\ttimelinesRotation[i @ X4 (System.Int32)] = v164;\nL_024C:\n\tv307 = i + 1;\n\tv782 = v164 * alpha;\n\tv785 = v145 + v782;\n\tv786 = v785 / 0xC3B40000;\n\tv789 = v786 + 16384.499999999996d;\n\ttimelinesRotation[v307 @ X9_v11 (System.Int32)] = v273;\n\tv792 = 0x4000 - v789;\n\tv616 = v792 * 0x168;\n\tv601 = v789 != 0x7FF0000000000000;\n\tif (v601) goto L_FFFFFFFF;\n\tgoto L_027A;\nL_027A:\n\tv558 = v785 - v606;\nL_027B:\n\tv292.rotation = v558;\nL_028B:\n\treturn;\nL_0290:\n\tgoto L_0293;\n\tv945 = \"il2cpp_codegen_runtime_class_init\"(v933, v171, blend, timelinesRotation, i, firstFrame, methodInfo, v53, v836, v838, v150, v124, v120, v122, v58, v59);\nL_0293:\n\tv867 = UnityEngine.Mathf::Abs(v161);\n\tv873 = v867 <= 0x43340000;\n\tif (v873) goto L_0214;\n\tgoto L_02AA;\n\tv959 = \"il2cpp_codegen_runtime_class_init\"(v956, v171, blend, timelinesRotation, i, firstFrame, methodInfo, v53, v867, v871, v150, v124, v120, v122, v58, v59);\nL_02AA:\n\tv890 = System.Math::Sign(v161);\n\tv898 = v890 * 0x168;\n\tv161 = v161 + v898;\n\tgoto L_0214;\n\tv293 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 509 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void ApplyRotateTimeline(RotateTimeline timeline, Skeleton skeleton, float time, float alpha, MixBlend blend, float[] timelinesRotation, int i, bool firstFrame)
		{
			//IL_0024: Expected I, but got O
			//IL_0034: Expected O, but got I
			//IL_0044: Expected O, but got I
			//IL_01d4: Expected O, but got I
			//IL_01fb: Expected O, but got I8
			//IL_0218: Expected O, but got I
			//IL_0220: Expected F4, but got O
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_0197: Expected O, but got Unknown
			//IL_047c: Expected O, but got I8
			//IL_0499: Expected O, but got I
			//IL_09ab: Expected O, but got F8
			//IL_09b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_09b9: Expected I4, but got Unknown
			//IL_0a0c: Expected O, but got F4
			//IL_0a15: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a1a: Expected I4, but got Unknown
			//IL_0a87: Expected O, but got F8
			//IL_0a90: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a95: Expected I4, but got Unknown
			//IL_0ae2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ae7: Expected O, but got Unknown
			//IL_0612: Expected I4, but got O
			//IL_0760: Expected I4, but got O
			if (firstFrame)
			{
				timelinesRotation[i] = 0f;
			}
			if (alpha == 1f)
			{
				nint num = (nint)timeline;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ X8_v53 (Il2CppClass<Spine.RotateTimeline>)+198]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ X8_v53 (Il2CppClass<Spine.RotateTimeline>)+1A0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v439 @ X6_v1 (should have been resolved before IL gen)");
			}
			ExposedList<Bone> bones = skeleton.Bones;
			Bone[] items = bones.Items;
			int propertyId = timeline.PropertyId;
			Bone bone = items[propertyId];
			if (!bone.Active)
			{
				return;
			}
			float[] frames = timeline.Frames;
			float rotation;
			float num2;
			float num3;
			if (frames[0] > time)
			{
				if (blend == MixBlend.Setup)
				{
					BoneData boneData = bone.Data;
					rotation = boneData.Rotation;
					goto IL_0852;
				}
				if (blend != MixBlend.First)
				{
					return;
				}
				BoneData boneData2 = bone.Data;
				num2 = bone.Rotation;
				num3 = boneData2.Rotation;
			}
			else
			{
				object obj3 = ((blend == MixBlend.Setup) ? ((object)((nint)bone.Data + 52)) : ((object)(items[propertyId] + 56)));
				int num4 = frames.Length << 32;
				object obj4 = -8589934592L + num4;
				int num5 = (int)((nint)obj4 >> 30);
				object obj5 = (nint)frames + num5;
				num2 = (float)obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ X10_v7+20]");
				bool flag = 0f < time;
				bool flag2 = !flag;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ X10_v7+20]");
				float num6 = 0f - time;
				bool flag3 = num6 == 0f;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					int num7 = Animation.BinarySearch(frames, time, 2);
					int num8 = num7 - 1;
					int num9 = num7 - 2;
					float num10 = time - frames[num7];
					float num11 = frames[num9] - frames[num7];
					int num12 = num7 >> 1;
					float num13 = num10 / num11;
					int frameIndex = num12 - 1;
					float percent = 1f - num13;
					float curvePercent = timeline.GetCurvePercent(frameIndex, percent);
					int num14 = num7 + 1;
					BoneData boneData3 = bone.Data;
					float num15 = frames[num14] - frames[num8];
					float num16 = num15 / -360f;
					double num17 = (double)num16 + 16384.499999999996;
					double num18 = 8.095E-320 - num17;
					double num19 = num18 * 1.78E-321;
					double num20 = ((num17 != 9.218868437227405E+18) ? num19 : 6.19217644E-315);
					double num21 = (double)num15 - num20;
					float num22 = curvePercent * (float)num21;
					float num23 = frames[num8] + num22;
					float num24 = num23 + boneData3.Rotation;
					float num25 = num24 / -360f;
					float num26 = num25 + 16384.5f;
					float num27 = 2.2959E-41f - num26;
					float num28 = num27 * 5.04E-43f;
					float num29 = ((num26 != 9.2188684E+18f) ? num28 : 5898240f);
					num3 = num24 - num29;
				}
				else
				{
					BoneData boneData4 = bone.Data;
					int num30 = frames.Length << 32;
					object obj6 = num30 + -4294967296L;
					int num31 = (int)((nint)obj6 >> 30);
					object obj7 = (nint)frames + num31;
					float num32 = boneData4.Rotation;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v662 @ X8_v42+20]");
					num3 = num32 + 0f;
				}
			}
			float num33 = num3 - num2;
			float num34 = num33 / -360f;
			double num35 = (double)num34 + 16384.499999999996;
			double num36 = 8.095E-320 - num35;
			double num37 = num36 * 1.78E-321;
			double num38 = ((num35 != 9.218868437227405E+18) ? num37 : 6.19217644E-315);
			double num39 = (double)num33 - num38;
			double num40;
			if (num39 == 0.0)
			{
				num40 = timelinesRotation[i];
				goto IL_0961;
			}
			bool flag5 = !firstFrame;
			bool flag6 = !flag5;
			float num41 = 0f;
			float num42 = (float)num39;
			if (!flag6)
			{
				int num43 = i + 1;
				num41 = timelinesRotation[i];
				num42 = timelinesRotation[num43];
			}
			bool flag7 = num39 < 0.0;
			bool flag8 = num39 == 0.0;
			object obj8 = num39 ^ num39;
			int num44 = num39 & (nint)obj8;
			bool flag9 = num44 < 0;
			bool flag10 = flag7 == flag9;
			bool flag11 = !flag8;
			bool flag12 = flag10 && flag11;
			bool flag13 = num41 < 0f;
			object obj9 = num41 ^ num41;
			int num45 = num41 & (nint)obj9;
			bool flag14 = num45 < 0;
			bool flag15 = flag13 == flag14;
			int num46 = Math.Sign(num42);
			int num47 = Math.Sign((float)num39);
			bool flag22;
			if (num46 != num47)
			{
				float num48 = Mathf.Abs(num42);
				bool flag16 = num48 < 90f;
				bool flag17 = !flag16;
				float num49 = num48 - 90f;
				bool flag18 = num49 == 0f;
				bool flag19 = !flag17;
				bool flag20 = flag19 || flag18;
				num47 = (int)typeof(Math);
				if (flag20)
				{
					float num50 = Mathf.Abs(num41);
					bool flag21 = !(num50 > 180f);
					num47 = (int)typeof(Math);
					flag22 = flag12;
					if (!flag21)
					{
						num47 = Math.Sign(num41);
						int num51 = num47 * 360;
						num41 += (float)num51;
						flag22 = flag12;
					}
					goto IL_0a50;
				}
			}
			flag22 = flag15;
			goto IL_0a50;
			IL_0a50:
			bool flag23 = num39 < 0.0;
			bool flag24 = num39 == 0.0;
			object obj10 = num39 ^ num39;
			int num52 = num39 & (nint)obj10;
			bool flag25 = num52 < 0;
			bool flag26 = flag23 == flag25;
			bool flag27 = !flag24;
			bool flag28 = flag26 && flag27;
			double num53 = num39 + (double)num41;
			object obj11 = num41 % 1135869952;
			bool flag29 = flag28 == flag22;
			num40 = num53 - (double)num41;
			if (!flag29)
			{
				int num54 = Math.Sign(num41);
				int num55 = num54 * 360;
				num40 += (double)num55;
			}
			timelinesRotation[i] = (float)num40;
			goto IL_0961;
			IL_0961:
			int num56 = i + 1;
			float num57 = (float)num40 * alpha;
			float num58 = num2 + num57;
			float num59 = num58 / -360f;
			float num60 = num59 + 16384.5f;
			timelinesRotation[num56] = (float)num39;
			float num61 = 2.2959E-41f - num60;
			float num62 = num61 * 5.04E-43f;
			float num63 = ((num60 != 9.2188684E+18f) ? num62 : 5898240f);
			rotation = num58 - num63;
			goto IL_0852;
			IL_0852:
			bone.Rotation = rotation;
		}

		[Token(Token = "0x60000C8")]
		[Address(RVA = "0x15298AC", Offset = "0x15298AC", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = entry.animationEnd - entry.animationStart;\n\tv325 = 0x1854EF0(this, entry, methodInfo, v36, v37, v38, v39, v40, entry.trackLast, v30, v41, v42, v43, v44, v45, v46);\n\tv159 = this.events;\n\tv154 = v159.Items;\n\tv73 = v159.Count < 1;\n\tif (v73) goto L_FFFFFFFF;\nL_0039:\n\tv59 = v154[v70 @ X23_v6 (System.Int32)];\n\tv315 = v59.time < entry.trackLast;\n\tif (v315) goto L_0069;\n\tv75 = v59.time > entry.animationEnd;\n\tif (v75) goto L_0059;\n\tv325 = this.queue;\n\tSpine.EventQueue::Event(this.queue, entry, v154[v70 @ X23_v6 (System.Int32)]);\nL_0059:\n\tv70 = v70 + 1;\n\tv298 = v159.Count != v70;\n\tif (v298) goto L_0039;\n\tgoto L_0069;\nL_0069:\n\tv329 = ~entry.loop;\n\tif (v329) goto L_0086;\n\tv345 = v30 == 0;\n\tif (v345) goto L_00A2;\n\tv363 = 0x1854EF0(v325, v294, methodInfo, v36, v37, v38, v39, v40, entry.trackTime, v30, v41, v42, v43, v44, v45, v46);\n\tv366 = entry.trackLast > entry.trackTime;\n\tif (v366) goto L_00A2;\n\tgoto L_00AC;\nL_0086:\n\tv350 = entry.animationEnd < animationTime;\n\tv351 = ~v350;\n\tv352 = entry.animationEnd - animationTime;\n\tv354 = v352 == 0;\n\tv359 = ~v354;\n\tv360 = v351 & v359;\n\tif (v360) goto L_00AC;\n\tv365 = entry.animationLast >= entry.animationEnd;\n\tif (v365) goto L_00AC;\nL_00A2:\n\tSpine.EventQueue::Complete(this.queue, entry);\nL_00AC:\n\tv77 = v70 >= v159.Count;\n\tif (v77) goto L_00E8;\nL_00BD:\n\tv61 = v154[v70 @ X23_v6 (System.Int32)];\n\tv132 = v61.time < entry.animationStart;\n\tif (v132) goto L_00D0;\n\tSpine.EventQueue::Event(this.queue, entry, v154[v70 @ X23_v6 (System.Int32)]);\nL_00D0:\n\tv70 = v70 + 1;\n\tv404 = v159.Count != v70;\n\tif (v404) goto L_00BD;\nL_00E8:\n\treturn;\n\tv196 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 188 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void QueueEvents(TrackEntry entry, float animationTime)
		{
			//IL_002b: Expected O, but got F4
			//IL_00c0: Expected I, but got O
			//IL_01ca: Expected O, but got F4
			//IL_0171: Expected I, but got O
			float num = entry.AnimationEnd - entry.AnimationStart;
			EventQueue eventQueue = (EventQueue)(entry.trackLast % num);
			ExposedList<Event> exposedList = events;
			Event[] items = exposedList.Items;
			int num2;
			if (exposedList.Count >= 1)
			{
				TrackEntry trackEntry = entry;
				num2 = 0;
				while (true)
				{
					Event obj = items[num2];
					bool flag = obj.Time < entry.trackLast;
					nint num3 = (nint)items[num2];
					if (flag)
					{
						break;
					}
					if (!(obj.Time > entry.AnimationEnd))
					{
						eventQueue = queue;
						queue.Event(entry, items[num2]);
						trackEntry = entry;
					}
					num2++;
					if (exposedList.Count == num2)
					{
						num3 = (nint)items[num2];
						num2 = exposedList.Count;
						break;
					}
				}
			}
			else
			{
				TrackEntry trackEntry = entry;
				num2 = 0;
			}
			if (entry.Loop)
			{
				if (num != 0f)
				{
					object obj2 = entry.TrackTime % num;
					if (!(entry.trackLast > entry.TrackTime))
					{
						goto IL_02a1;
					}
				}
			}
			else
			{
				bool flag2 = entry.AnimationEnd < animationTime;
				bool flag3 = !flag2;
				float num4 = entry.AnimationEnd - animationTime;
				bool flag4 = num4 == 0f;
				bool flag5 = !flag4;
				if ((flag3 && flag5) || !(entry.AnimationLast < entry.AnimationEnd))
				{
					goto IL_02a1;
				}
			}
			queue.Complete(entry);
			goto IL_02a1;
			IL_02a1:
			if (num2 >= exposedList.Count)
			{
				return;
			}
			do
			{
				Event obj3 = items[num2];
				if (!(obj3.Time < entry.AnimationStart))
				{
					queue.Event(entry, items[num2]);
				}
				num2++;
			}
			while (exposedList.Count != num2);
		}

		[Token(Token = "0x60000C9")]
		[Address(RVA = "0x152A130", Offset = "0x152A130", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37AFB]) = v37;\nL_0012:\n\tv38 = this.queue;\n\tv38.drainDisabled = 1;\n\tv115 = this.tracks;\n\tv112 = v115.Count < 1;\n\tif (v112) goto L_003F;\nL_002B:\n\tSpine.AnimationState::ClearTrack(this, v155);\n\tv155 = v155 + 1;\n\tv51 = v115.Count != v155;\n\tif (v51) goto L_002B;\n\tv115 = this.tracks;\nL_003F:\n\tSpine.ExposedList`1<Spine.TrackEntry>::Clear(v115, 1);\n\tv92 = this.queue;\n\tv92.drainDisabled = v38.drainDisabled;\n\tSpine.EventQueue::Drain(v92);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ClearTracks()
		{
			EventQueue eventQueue = queue;
			eventQueue.drainDisabled = true;
			ExposedList<TrackEntry> exposedList = Tracks;
			if (exposedList.Count >= 1)
			{
				int num = 0;
				do
				{
					ClearTrack(num);
					num++;
				}
				while (exposedList.Count != num);
				exposedList = Tracks;
			}
			exposedList.Clear();
			EventQueue eventQueue2 = queue;
			eventQueue2.drainDisabled = eventQueue.drainDisabled;
			eventQueue2.Drain();
		}

		[Token(Token = "0x60000CA")]
		[Address(RVA = "0x152A1E0", Offset = "0x152A1E0", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.tracks;\n\tv28 = v12.Count <= trackIndex;\n\tif (v28) goto L_0073;\n\tv104 = v12.Items;\n\tv52 = v104[trackIndex @ X1 (System.Int32)];\n\tv138 = v104[trackIndex @ X1 (System.Int32)] == 0;\n\tif (v138) goto L_0073;\n\tSpine.EventQueue::End(this.queue, v104[trackIndex @ X1 (System.Int32)]);\n\tSpine.AnimationState::DisposeNext(this, v104[trackIndex @ X1 (System.Int32)]);\n\tv201 = v104[trackIndex @ X1 (System.Int32)];\n\tv39 = v104[trackIndex @ X1 (System.Int32)] + 0x20;\n\tv106 = v201.mixingFrom;\n\tv204 = v201.mixingFrom == 0;\n\tif (v204) goto L_004B;\nL_0041:\n\tSpine.EventQueue::End(this.queue, v106);\n\t*([v39 @ X22_v8]) = 0;\n\tv36.mixingTo = 0;\n\tv39 = v106 + 0x20;\n\tv218 = v106.mixingFrom == 0;\n\tv211 = ~v218;\n\tif (v211) goto L_0041;\nL_004B:\n\tv107 = this.tracks;\n\tv108 = v107.Items;\n\tv95 = v52.trackIndex;\n\tv108[v95 @ X9_v6 (System.Int32)] = 0;\n\tSpine.EventQueue::Drain(this.queue);\n\treturn;\nL_0073:\n\treturn;\n\tv110 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ClearTrack(int trackIndex)
		{
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Expected O, but got Unknown
			//IL_0132: Expected O, but got I4
			//IL_014b: Expected O, but got I
			ExposedList<TrackEntry> exposedList = Tracks;
			if (exposedList.Count <= trackIndex)
			{
				return;
			}
			TrackEntry[] items = exposedList.Items;
			TrackEntry trackEntry = items[trackIndex];
			if (items[trackIndex] == null)
			{
				return;
			}
			queue.End(items[trackIndex]);
			DisposeNext(items[trackIndex]);
			TrackEntry trackEntry2 = items[trackIndex];
			object obj = items[trackIndex] + 32;
			TrackEntry mixingFrom = trackEntry2.MixingFrom;
			if (trackEntry2.MixingFrom != null)
			{
				TrackEntry trackEntry3 = items[trackIndex];
				bool flag2;
				do
				{
					queue.End(mixingFrom);
					obj = 0;
					trackEntry3.mixingTo = null;
					obj = (nint)mixingFrom + 32;
					bool flag = mixingFrom.MixingFrom == null;
					flag2 = !flag;
					trackEntry3 = mixingFrom;
					mixingFrom = mixingFrom.MixingFrom;
				}
				while (flag2);
			}
			ExposedList<TrackEntry> exposedList2 = Tracks;
			TrackEntry[] items2 = exposedList2.Items;
			int trackIndex2 = trackEntry.TrackIndex;
			items2[trackIndex2] = null;
			queue.Drain();
		}

		[Token(Token = "0x60000CB")]
		[Address(RVA = "0x1527E28", Offset = "0x1527E28", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, index, current, interrupt, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv56 = System.Math;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, index, current, interrupt, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv51 = 1;\n\t*([1A37AFC]) = v51;\nL_001F:\n\tv54 = Spine.AnimationState::ExpandToIndex(this, index);\n\tv57 = this.tracks;\n\tv59 = v57.Items;\n\tv148 = current == 0;\n\tif (v148) goto L_003E;\n\t// 44 IsInst v178 @ X0_v23, typeof(Spine.TrackEntry), current @ X2 (Spine.TrackEntry)\n\tv179 = v178 == 0;\n\tif (v179) goto L_008A;\nL_003E:\n\tv59[index @ X1 (System.Int32)] = current;\n\tv206 = v54 == 0;\n\tif (v206) goto L_0086;\n\tv210 = interrupt == 0;\n\tif (v210) goto L_004B;\n\tSpine.EventQueue::Interrupt(this.queue, v54);\nL_004B:\n\tcurrent.mixingFrom = v54;\n\tv54.mixingTo = current;\n\tcurrent.mixTime = 0f;\n\tv257 = v54.mixingFrom == 0;\n\tif (v257) goto L_0076;\n\tv270 = v54.mixDuration <= 0;\n\tif (v270) goto L_0076;\n\tgoto L_0069;\n\tv285 = \"il2cpp_codegen_runtime_class_init\"(v282, v128, current, interrupt, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0069:\n\tv272 = v54.mixTime / v54.mixDuration;\n\tv288 = System.Math::Min(1f, v272);\n\tv271 = current.interruptAlpha * v288;\n\tcurrent.interruptAlpha = v271;\nL_0076:\n\tSpine.ExposedList`1<System.Single>::Clear(v54.timelinesRotation, 1);\nL_0086:\n\tSpine.EventQueue::Start(this.queue, current);\n\treturn;\n\tv147 = new System.NullReferenceException();\n\tv174 = new System.IndexOutOfRangeException();\nL_008A:\n\tv205 = new System.ArrayTypeMismatchException();\n\tthrow v205;\n\treturn;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetCurrent(int index, TrackEntry current, bool interrupt)
		{
			TrackEntry trackEntry = ExpandToIndex(index);
			ExposedList<TrackEntry> exposedList = Tracks;
			TrackEntry[] items = exposedList.Items;
			if (current != null)
			{
				object obj = current as TrackEntry;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			items[index] = current;
			if (trackEntry != null)
			{
				if (interrupt)
				{
					queue.Interrupt(trackEntry);
				}
				current.mixingFrom = trackEntry;
				trackEntry.mixingTo = current;
				current.MixTime = 0f;
				if (trackEntry.MixingFrom != null && trackEntry.MixDuration > 0f)
				{
					float val = trackEntry.MixTime / trackEntry.MixDuration;
					float num = Math.Min(1f, val);
					float interruptAlpha = current.interruptAlpha * num;
					current.interruptAlpha = interruptAlpha;
				}
				trackEntry.timelinesRotation.Clear();
			}
			queue.Start(current);
		}

		[Token(Token = "0x60000CC")]
		[Address(RVA = "0x152A4FC", Offset = "0x152A4FC", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.data;\n\tv40 = Spine.SkeletonData::FindAnimation(v10.skeletonData, animationName);\n\tv49 = v40 == 0;\n\tif (v49) goto L_0027;\n\treturnVal1 = Spine.AnimationState::SetAnimation(this, trackIndex, v40, loop);\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\nL_0027:\n\tv55 = System.String::Concat(\"Animation not found: \", v45);\n\tv70 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v70, v55, \"animationName\");\n\tthrow v70;\n\treturn returnVal2;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TrackEntry SetAnimation(int trackIndex, string animationName, bool loop)
		{
			AnimationStateData animationStateData = Data;
			Animation animation = animationStateData.SkeletonData.FindAnimation(animationName);
			if (animation != null)
			{
				return SetAnimation(trackIndex, animation, loop);
			}
			string text = default(string);
			string message = "Animation not found: " + text;
			ArgumentException ex = new ArgumentException(message, "animationName");
			throw ex;
		}

		[Token(Token = "0x60000CD")]
		[Address(RVA = "0x152A5C4", Offset = "0x152A5C4", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = animation == 0;\n\tif (v16) goto L_0072;\n\tv25 = Spine.AnimationState::ExpandToIndex(this, trackIndex);\n\tv102 = v25 == 0;\n\tif (v102) goto L_FFFFFFFF;\n\tv115 = v25.nextTrackLast != -1f;\n\tif (v115) goto L_0051;\n\tv136 = this.tracks;\n\tv145 = v136.Items;\n\tv203 = v25.mixingFrom == 0;\n\tif (v203) goto L_003E;\n\t// 44 IsInst v210 @ X0_v39, typeof(Spine.TrackEntry), v25.mixingFrom (Spine.TrackEntry)\n\tv214 = v210 == 0;\n\tif (v214) goto L_0087;\nL_003E:\n\tv145[trackIndex @ X1 (System.Int32)] = v25.mixingFrom;\n\tSpine.EventQueue::Interrupt(this.queue, v25);\n\tSpine.EventQueue::End(this.queue, v25);\n\tSpine.AnimationState::DisposeNext(this, v25);\n\tv168 = v25.mixingFrom;\n\tgoto L_0058;\nL_0051:\n\tSpine.AnimationState::DisposeNext(this, v25);\nL_0058:\n\tv179 = Spine.AnimationState::NewTrackEntry(this, trackIndex, animation, loop, v168);\n\tSpine.AnimationState::SetCurrent(this, trackIndex, v179, v142);\n\tSpine.EventQueue::Drain(this.queue);\n\treturn v179;\n\tthrow System.NullReferenceException;\nL_0072:\n\tv103 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v103, \"animation\", \"animation cannot be null.\");\n\tthrow v103;\n\tv247 = new System.IndexOutOfRangeException();\nL_0087:\n\tv283 = new System.ArrayTypeMismatchException();\n\tthrow v283;\n\treturn returnVal2;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TrackEntry SetAnimation(int trackIndex, Animation animation, bool loop)
		{
			TrackEntry last;
			bool interrupt;
			if (animation != null)
			{
				TrackEntry trackEntry = ExpandToIndex(trackIndex);
				if (trackEntry != null)
				{
					if (trackEntry.nextTrackLast == -1f)
					{
						ExposedList<TrackEntry> exposedList = Tracks;
						TrackEntry[] items = exposedList.Items;
						if (trackEntry.MixingFrom != null)
						{
							object obj = trackEntry.MixingFrom as TrackEntry;
							if (obj == null)
							{
								ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
								throw ex;
							}
						}
						items[trackIndex] = trackEntry.MixingFrom;
						queue.Interrupt(trackEntry);
						queue.End(trackEntry);
						DisposeNext(trackEntry);
						last = trackEntry.MixingFrom;
						interrupt = false;
						goto IL_01af;
					}
					DisposeNext(trackEntry);
				}
				interrupt = true;
				last = trackEntry;
				goto IL_01af;
			}
			ArgumentNullException ex2 = new ArgumentNullException("animation", "animation cannot be null.");
			throw ex2;
			IL_01af:
			TrackEntry trackEntry2 = NewTrackEntry(trackIndex, animation, loop, last);
			SetCurrent(trackIndex, trackEntry2, interrupt);
			queue.Drain();
			return trackEntry2;
		}

		[Token(Token = "0x60000CE")]
		[Address(RVA = "0x152A844", Offset = "0x152A844", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.data;\n\tv43 = Spine.SkeletonData::FindAnimation(v12.skeletonData, animationName);\n\tv53 = v43 == 0;\n\tif (v53) goto L_002B;\n\treturnVal1 = Spine.AnimationState::AddAnimation(this, trackIndex, v43, loop, delay);\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\nL_002B:\n\tv59 = System.String::Concat(\"Animation not found: \", v49);\n\tv76 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v76, v59, \"animationName\");\n\tthrow v76;\n\treturn returnVal2;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TrackEntry AddAnimation(int trackIndex, string animationName, bool loop, float delay)
		{
			AnimationStateData animationStateData = Data;
			Animation animation = animationStateData.SkeletonData.FindAnimation(animationName);
			if (animation != null)
			{
				return AddAnimation(trackIndex, animation, loop, delay);
			}
			string text = default(string);
			string message = "Animation not found: " + text;
			ArgumentException ex = new ArgumentException(message, "animationName");
			throw ex;
		}

		[Token(Token = "0x60000CF")]
		[Address(RVA = "0x152A91C", Offset = "0x152A91C", Length = "0x1F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv34 = System.Math;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, trackIndex, animation, loop, methodInfo, v37, v38, v39, delay, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 1;\n\t*([1A37AFD]) = v49;\nL_001A:\n\tv50 = animation == 0;\n\tif (v50) goto L_00A4;\n\tv125 = Spine.AnimationState::ExpandToIndex(this, trackIndex);\n\tv123 = v125 == 0;\n\tif (v123) goto L_0052;\nL_0022:\n\tv125 = v125.next;\n\tv131 = v125.next == 0;\n\tv128 = ~v131;\n\tif (v128) goto L_0022;\n\tv147 = Spine.AnimationState::NewTrackEntry(this, trackIndex, animation, loop, v125.next);\n\tv158 = delay < 0;\n\tv159 = ~v158;\n\tv162 = delay == 0;\n\tv125.next = v147;\n\tv167 = ~v162;\n\tv168 = v159 & v167;\n\tif (v168) goto L_FFFFFFFF;\n\tv177 = v125.animationEnd - v125.animationStart;\n\tv187 = v177 != 0;\n\tif (v187) goto L_006E;\n\tv262 = v125.trackTime;\n\tv235 = v147 == 0;\n\tv227 = ~v235;\n\tif (v227) goto L_005F;\n\tgoto L_00A0;\nL_0052:\n\tv137 = Spine.AnimationState::NewTrackEntry(this, trackIndex, animation, loop, 0);\n\tSpine.AnimationState::SetCurrent(this, trackIndex, v137, 1);\n\tSpine.EventQueue::Drain(this.queue);\nL_005F:\n\tv261.delay = v262;\n\treturn v261;\nL_006E:\n\tv237 = ~v125.loop;\n\tif (v237) goto L_008F;\n\tv278 = v125.trackTime / v177;\n\tv283 = v278 + 1;\n\tv295 = v278 != 0x7F800000;\n\tif (v295) goto L_FFFFFFFF;\n\tgoto L_0087;\nL_0087:\n\tv212 = v177 * v341;\n\tgoto L_009A;\nL_008F:\n\tgoto L_0094;\n\tv335 = \"il2cpp_codegen_runtime_class_init\"(v298, v144, v145, v142, v146, v37, v38, v39, v176, v175, v41, v42, v43, v44, v45, v46);\nL_0094:\n\tv212 = System.Math::Max(v177, v125.trackTime);\nL_009A:\n\tv345 = v212 + delay;\n\tv211 = Spine.AnimationStateData::GetMix(this.data, v125.animation, animation);\n\tv262 = v345 - v211;\n\tv346 = v147 == 0;\n\tv226 = ~v346;\n\tif (v226) goto L_005F;\nL_00A0:\n\tthrow System.NullReferenceException;\nL_00A4:\n\tv124 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v124, \"animation\", \"animation cannot be null.\");\n\tthrow v124;\n// 128 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TrackEntry AddAnimation(int trackIndex, Animation animation, bool loop, float delay)
		{
			TrackEntry trackEntry3;
			float delay2;
			if (animation != null)
			{
				TrackEntry trackEntry = ExpandToIndex(trackIndex);
				if (trackEntry != null)
				{
					do
					{
						trackEntry = trackEntry.Next;
					}
					while (trackEntry.Next != null);
					TrackEntry trackEntry2 = NewTrackEntry(trackIndex, animation, loop, trackEntry.Next);
					bool flag = delay < 0f;
					bool flag2 = !flag;
					bool flag3 = delay == 0f;
					trackEntry.next = trackEntry2;
					bool flag4 = !flag3;
					bool flag5 = flag2 && flag4;
					trackEntry3 = trackEntry2;
					if (!flag5)
					{
						float num = trackEntry.AnimationEnd - trackEntry.AnimationStart;
						if (num == 0f)
						{
							delay2 = trackEntry.TrackTime;
							bool flag6 = trackEntry2 == null;
							bool flag7 = !flag6;
							trackEntry3 = trackEntry2;
							if (flag7)
							{
								goto IL_01c2;
							}
						}
						else
						{
							float num5;
							if (trackEntry.Loop)
							{
								float num2 = trackEntry.TrackTime / num;
								float num3 = num2 + float.Epsilon;
								float num4 = ((num2 != float.PositiveInfinity) ? num3 : (-2.1474836E+09f));
								num5 = num * num4;
							}
							else
							{
								num5 = Math.Max(num, trackEntry.TrackTime);
							}
							float num6 = num5 + delay;
							float mix = Data.GetMix(trackEntry.Animation, animation);
							delay2 = num6 - mix;
							bool flag8 = trackEntry2 == null;
							bool flag9 = !flag8;
							trackEntry3 = trackEntry2;
							if (flag9)
							{
								goto IL_01c2;
							}
						}
						throw new NullReferenceException();
					}
				}
				else
				{
					TrackEntry trackEntry4 = NewTrackEntry(trackIndex, animation, loop, null);
					SetCurrent(trackIndex, trackEntry4, interrupt: true);
					queue.Drain();
					trackEntry3 = trackEntry4;
				}
				delay2 = delay;
				goto IL_01c2;
			}
			ArgumentNullException ex = new ArgumentNullException("animation", "animation cannot be null.");
			throw ex;
			IL_01c2:
			trackEntry3.Delay = delay2;
			return trackEntry3;
		}

		[Token(Token = "0x60000D0")]
		[Address(RVA = "0x152AC28", Offset = "0x152AC28", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = Spine.AnimationState;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, trackIndex, methodInfo, v29, v30, v31, v32, v33, mixDuration, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A37AFE]) = v43;\nL_001B:\n\tgoto L_0023;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, trackIndex, methodInfo, v29, v30, v31, v32, v33, mixDuration, v34, v35, v36, v37, v38, v39, v40);\n\tv50 = Spine.AnimationState;\nL_0023:\n\treturnVal1 = Spine.AnimationState::SetAnimation(this, trackIndex, v51.EmptyAnimation, 0);\n\treturnVal1.mixDuration = mixDuration;\n\treturnVal1.trackEnd = mixDuration;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TrackEntry SetEmptyAnimation(int trackIndex, float mixDuration)
		{
			TrackEntry trackEntry = SetAnimation(trackIndex, EmptyAnimation, loop: false);
			trackEntry.MixDuration = mixDuration;
			trackEntry.TrackEnd = mixDuration;
			return trackEntry;
		}

		[Token(Token = "0x60000D1")]
		[Address(RVA = "0x152ACBC", Offset = "0x152ACBC", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv30 = Spine.AnimationState;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, trackIndex, methodInfo, v33, v34, v35, v36, v37, mixDuration, delay, v38, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A37AFF]) = v46;\nL_001A:\n\tv48 = delay - mixDuration;\n\tv49 = delay < 0;\n\tv50 = ~v49;\n\tv53 = delay == 0;\n\tv58 = ~v53;\n\tv59 = v50 & v58;\n\tv60 = ~v59;\n\tif (v60) goto L_FFFFFFFF;\n\tgoto L_002F;\nL_002F:\n\tgoto L_0038;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v47, trackIndex, methodInfo, v33, v34, v35, v36, v37, v48, delay, v38, v39, v40, v41, v42, v43);\n\tv69 = Spine.AnimationState;\nL_0038:\n\treturnVal1 = Spine.AnimationState::AddAnimation(this, trackIndex, v70.EmptyAnimation, 0, v63);\n\treturnVal1.mixDuration = mixDuration;\n\treturnVal1.trackEnd = mixDuration;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TrackEntry AddEmptyAnimation(int trackIndex, float mixDuration, float delay)
		{
			float num = delay - mixDuration;
			bool flag = delay < 0f;
			bool flag2 = !flag;
			bool flag3 = delay == 0f;
			bool flag4 = !flag3;
			float delay2 = ((!(flag2 && flag4)) ? num : delay);
			TrackEntry trackEntry = AddAnimation(trackIndex, EmptyAnimation, loop: false, delay2);
			trackEntry.MixDuration = mixDuration;
			trackEntry.TrackEnd = mixDuration;
			return trackEntry;
		}

		[Token(Token = "0x60000D2")]
		[Address(RVA = "0x152AD64", Offset = "0x152AD64", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv157 = this.queue;\n\tv157.drainDisabled = 1;\n\tv164 = this.tracks;\n\tv48 = v164.Count < 1;\n\tif (v48) goto L_004A;\nL_0020:\n\tv99 = v164.Items;\n\tv133 = v99[v42 @ X22_v6 (System.Int32)];\n\tv135 = v99[v42 @ X22_v6 (System.Int32)] == 0;\n\tif (v135) goto L_0037;\n\tv202 = Spine.AnimationState::SetEmptyAnimation(this, v133.trackIndex, mixDuration);\nL_0037:\n\tv42 = v42 + 1;\n\tv72 = v164.Count == v42;\n\tif (v72) goto L_0047;\n\tv164 = this.tracks;\n\tv204 = this.tracks == 0;\n\tv102 = ~v204;\n\tif (v102) goto L_0020;\n\tthrow System.NullReferenceException;\nL_0047:\n\tv157 = this.queue;\nL_004A:\n\tv157.drainDisabled = v157.drainDisabled;\n\tSpine.EventQueue::Drain(v157);\n\treturn;\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetEmptyAnimations(float mixDuration)
		{
			EventQueue eventQueue = queue;
			eventQueue.drainDisabled = true;
			ExposedList<TrackEntry> exposedList = Tracks;
			if (exposedList.Count >= 1)
			{
				int num = 0;
				while (true)
				{
					TrackEntry[] items = exposedList.Items;
					TrackEntry trackEntry = items[num];
					if (items[num] != null)
					{
						TrackEntry trackEntry2 = SetEmptyAnimation(trackEntry.TrackIndex, mixDuration);
					}
					num++;
					if (exposedList.Count == num)
					{
						break;
					}
					exposedList = Tracks;
					if (Tracks == null)
					{
						throw new NullReferenceException();
					}
				}
				eventQueue = queue;
			}
			eventQueue.drainDisabled = eventQueue.drainDisabled;
			eventQueue.Drain();
		}

		[Token(Token = "0x60000D3")]
		[Address(RVA = "0x152A2D4", Offset = "0x152A2D4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, index, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A37B00]) = v36;\nL_0012:\n\tv37 = this.tracks;\n\tv51 = v37.Count <= index;\n\tif (v51) goto L_0039;\n\tv73 = v37.Items;\n\tgoto L_0042;\nL_0039:\n\tv77 = index + 1;\n\tv79 = Spine.ExposedList`1<Spine.TrackEntry>::Resize(v37, v77);\nL_0042:\n\treturn returnVal2;\n\tv74 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private TrackEntry ExpandToIndex(int index)
		{
			ExposedList<TrackEntry> exposedList = Tracks;
			if (exposedList.Count > index)
			{
				TrackEntry[] items = exposedList.Items;
				return items[index];
			}
			int newSize = index + 1;
			ExposedList<TrackEntry> exposedList2 = exposedList.Resize(newSize);
			return null;
		}

		[Token(Token = "0x60000D4")]
		[Address(RVA = "0x152A750", Offset = "0x152A750", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, trackIndex, animation, loop, last, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 1;\n\t*([1A37B01]) = v45;\nL_001E:\n\tv51 = Spine.Pool`1<Spine.TrackEntry>::Obtain(this.trackEntryPool);\n\tv51.trackIndex = trackIndex;\n\tv51.animation = animation;\n\tv51.holdPrevious = 0;\n\tv51.eventThreshold = 0f;\n\tv51.drawOrderThreshold = 0f;\n\tv51.loop = loop;\n\tv51.interruptAlpha = 1f;\n\tv51.animationEnd = animation.duration;\n\tv51.animationLast = *([407EC0]);\n\tv51.trackLast = *([408090]);\n\tv51.alpha = 5.263544247E-315d;\n\tv113 = last == 0;\n\tif (v113) goto L_FFFFFFFF;\n\tv91 = Spine.AnimationStateData::GetMix(this.data, last.animation, animation);\n\tgoto L_0042;\nL_0042:\n\tv51.mixDuration = v91;\n\treturn v51;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private TrackEntry NewTrackEntry(int trackIndex, Animation animation, bool loop, TrackEntry last)
		{
			//IL_00a4: Expected F4, but got I
			//IL_00b9: Expected F4, but got I
			TrackEntry trackEntry = trackEntryPool.Obtain();
			trackEntry.trackIndex = trackIndex;
			trackEntry.animation = animation;
			trackEntry.holdPrevious = false;
			trackEntry.EventThreshold = 0f;
			trackEntry.DrawOrderThreshold = 0f;
			trackEntry.loop = loop;
			trackEntry.interruptAlpha = 1f;
			trackEntry.AnimationEnd = animation.Duration;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407EC0]");
			trackEntry.animationLast = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [408090]");
			trackEntry.trackLast = 0f;
			trackEntry.alpha = 1f;
			trackEntry.mixTime = 0f;
			float mixDuration = ((last == null) ? 0f : Data.GetMix(last.Animation, animation));
			trackEntry.MixDuration = mixDuration;
			return trackEntry;
		}

		[Token(Token = "0x60000D5")]
		[Address(RVA = "0x1528074", Offset = "0x1528074", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = entry.next;\n\tv12 = entry.next == 0;\n\tif (v12) goto L_0015;\nL_0010:\n\tSpine.EventQueue::Dispose(this.queue, v22);\n\tv22 = v22.next;\n\tv61 = v22.next == 0;\n\tv47 = ~v61;\n\tif (v47) goto L_0010;\nL_0015:\n\tentry.next = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DisposeNext(TrackEntry entry)
		{
			TrackEntry next = entry.Next;
			if (entry.Next != null)
			{
				do
				{
					queue.Dispose(next);
					next = next.Next;
				}
				while (next.Next != null);
			}
			entry.next = null;
		}

		[Token(Token = "0x60000D6")]
		[Address(RVA = "0x1528A7C", Offset = "0x1528A7C", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A37B02]) = v39;\nL_0014:\n\tthis.animationsChanged = 0;\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::Clear(this.propertyIDs);\n\tv103 = this.tracks;\n\tv58 = v103.Count < 1;\n\tif (v58) goto L_006D;\n\tv54 = v103.Items;\nL_003D:\n\tv185 = v54[v52 @ X23_v5 (System.Int32)] == 0;\n\tif (v185) goto L_005A;\nL_0040:\n\tv188 = v188.mixingFrom;\n\tv192 = v188.mixingFrom == 0;\n\tv187 = ~v192;\n\tif (v187) goto L_0040;\nL_0044:\n\tv213 = v229.mixingTo;\n\tv231 = v229.mixingTo == 0;\n\tif (v231) goto L_0054;\n\tv237 = v229.mixBlend == 3;\n\tif (v237) goto L_0057;\nL_0054:\n\tSpine.AnimationState::ComputeHold(this, v229);\n\tv213 = v229.mixingTo;\nL_0057:\n\tv254 = v213 == 0;\n\tv212 = ~v254;\n\tif (v212) goto L_0044;\nL_005A:\n\tv52 = v52 + 1;\n\tv156 = v52 != v103.Count;\n\tif (v156) goto L_003D;\nL_006D:\n\treturn;\n\tv96 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AnimationsChanged()
		{
			animationsChanged = false;
			propertyIDs.Clear();
			ExposedList<TrackEntry> exposedList = Tracks;
			if (exposedList.Count < 1)
			{
				return;
			}
			TrackEntry[] items = exposedList.Items;
			int num = 0;
			do
			{
				bool flag = items[num] == null;
				TrackEntry trackEntry = items[num];
				if (!flag)
				{
					bool flag3;
					TrackEntry trackEntry2;
					do
					{
						trackEntry = trackEntry.MixingFrom;
						bool flag2 = trackEntry.MixingFrom == null;
						flag3 = !flag2;
						trackEntry2 = trackEntry.MixingFrom;
					}
					while (flag3);
					bool flag5;
					do
					{
						TrackEntry mixingTo = trackEntry2.MixingTo;
						if (trackEntry2.MixingTo == null || trackEntry2.MixBlend != MixBlend.Add)
						{
							ComputeHold(trackEntry2);
							mixingTo = trackEntry2.MixingTo;
						}
						bool flag4 = mixingTo == null;
						flag5 = !flag4;
						trackEntry2 = mixingTo;
					}
					while (flag5);
				}
				num++;
			}
			while (num != exposedList.Count);
		}

		[Token(Token = "0x60000D7")]
		[Address(RVA = "0x152AEDC", Offset = "0x152AEDC", Length = "0x484")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tv34 = Spine.AttachmentTimeline;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, entry, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv56 = Spine.DrawOrderTimeline;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, entry, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv342 = Spine.EventTimeline;\n\tv343 = \"il2cpp_codegen_initialize_runtime_metadata\"(v342, entry, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv437 = Il2CppMethodInfo;\n\tv438 = \"il2cpp_codegen_initialize_runtime_metadata\"(v437, entry, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv475 = Il2CppMethodInfo;\n\tv476 = \"il2cpp_codegen_initialize_runtime_metadata\"(v475, entry, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv481 = Il2CppMethodInfo;\n\tv482 = \"il2cpp_codegen_initialize_runtime_metadata\"(v481, entry, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv484 = Il2CppMethodInfo;\n\tv485 = \"il2cpp_codegen_initialize_runtime_metadata\"(v484, entry, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv554 = Spine.Timeline;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v554, entry, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv53 = 1;\n\t*([1A37B03]) = v53;\nL_0031:\n\tv58 = entry.animation;\n\tv325 = v58.timelines;\n\tv266 = entry.mixingTo;\n\tv264 = v325.Items;\n\tv281 = Spine.ExposedList`1<System.Int32>::Resize(entry.timelineMode, v325.Count);\n\tv238 = v281.Items;\n\tSpine.ExposedList`1<Spine.TrackEntry>::Clear(entry.timelineHoldMix, 1);\n\tv284 = Spine.ExposedList`1<Spine.TrackEntry>::Resize(entry.timelineHoldMix, v325.Count);\n\tv557 = v284.Items;\n\tv558 = entry.mixingTo == 0;\n\tif (v558) goto L_00EA;\n\tv559 = ~v266.holdPrevious;\n\tif (v559) goto L_00EA;\n\tv115 = v325.Count < 1;\n\tif (v115) goto L_022F;\nL_0088:\n\tgoto L_00AF;\n\tv668 = *([v635 @ X8_v44+B0]);\n\tv669 = v668 + 8;\n\tv671 = *([v719 @ X10_v26-8]);\n\tv734 = v671 == v636;\n\tif (v734) goto L_00A7;\n\tv693 = v729 - 1;\n\tv673 = v719 + 0x10;\n\tv675 = v729 != 1;\n\tif (v675) goto L_FFFFFFFF;\n\tv694 = 1;\n\tv695 = v320;\n\tv696 = 0xB349B4(v695, v636, v694, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_00AF;\nL_00A7:\n\tv749 = *([v719 @ X10_v26]);\n\tv750 = v749 + 1;\n\tv751 = v750 << 4;\n\tv752 = v635 + v751;\n\tv753 = v752 + 0x138;\nL_00AF:\n\tv293 = Spine.Timeline::get_PropertyId(v264[v106 @ X22_v14 (System.Int32)]);\n\tv294 = System.Collections.Generic.HashSet`1<System.Int32>::Add(this.propertyIDs, v293);\n\tv192 = v294 == 0;\n\tv125 = ~v192;\n\tv84 = ~v125;\n\tif (v84) goto L_FFFFFFFF;\n\tv337 = 2 + 1;\n\tgoto L_00D0;\nL_00D0:\n\tv575 = v106 + 1;\n\tv238[v106 @ X22_v14 (System.Int32)] = v337;\n\tv578 = v575 != v325.Count;\n\tif (v578) goto L_0088;\n\tgoto L_022F;\nL_00EA:\n\tv117 = v325.Count < 1;\n\tif (v117) goto L_022F;\nL_0109:\n\tgoto L_0130;\n\tv639 = *([v631 @ X8_v17+B0]);\n\tv640 = v639 + 8;\n\tv642 = *([v698 @ X10_v19-8]);\n\tv713 = v642 == v632;\n\tif (v713) goto L_0128;\n\tv664 = v708 - 1;\n\tv644 = v698 + 0x10;\n\tv646 = v708 != 1;\n\tif (v646) goto L_FFFFFFFF;\n\tv665 = 1;\n\tv666 = v107;\n\tv667 = 0xB349B4(v666, v632, v665, v37, v38, v39, v40, v41, v61, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_0130;\nL_0128:\n\tv740 = *([v698 @ X10_v19]);\n\tv741 = v740 + 1;\n\tv742 = v741 << 4;\n\tv743 = v631 + v742;\n\tv744 = v743 + 0x138;\nL_0130:\n\tv295 = Spine.Timeline::get_PropertyId(v264[v428 @ X8_v15 (System.Int32)]);\n\tv290 = System.Collections.Generic.HashSet`1<System.Int32>::Add(this.propertyIDs, v295);\n\tv760 = v290 == 0;\n\tif (v760) goto L_01F1;\n\tv762 = entry.mixingTo == 0;\n\tif (v762) goto L_0202;\n\tgoto L_FFFFFFFF;\n\tv802 = v802_asT != 0;\n\tif (v802) goto L_0202;\n\tgoto L_FFFFFFFF;\n\tv803 = v803_asT != 0;\n\tif (v803) goto L_0202;\n\tgoto L_FFFFFFFF;\n\tv804 = v804_asT != 0;\n\tif (v804) goto L_0202;\n\tv815 = Spine.Animation::HasTimeline(v266.animation, v295);\n\tv817 = v815 == 0;\n\tif (v817) goto L_0202;\nL_019F:\n\tv896 = v896.mixingTo;\n\tv900 = v896.mixingTo == 0;\n\tif (v900) goto L_0220;\n\tv289 = Spine.Animation::HasTimeline(v896.animation, v295);\n\tv904 = v289 == 0;\n\tv899 = ~v904;\n\tif (v899) goto L_019F;\n\tv120 = v896.mixDuration <= 0;\n\tif (v120) goto L_0220;\n\tv238[v428 @ X8_v15 (System.Int32)] = 4;\n\t// 464 IsInst v418 @ X0_v30, typeof(Spine.TrackEntry), v896.mixingTo (Spine.TrackEntry)\n\tv422 = v418 == 0;\n\tif (v422) goto L_0232;\n\tv557[v428 @ X8_v15 (System.Int32)] = v896.mixingTo;\n\tgoto L_0203;\nL_01F1:\n\tv238[v428 @ X8_v15 (System.Int32)] = 0;\n\tgoto L_0203;\nL_0202:\n\tv238[v428 @ X8_v15 (System.Int32)] = 1;\nL_0203:\n\tv428 = v428 + 1;\n\tv579 = v428 != v325.Count;\n\tif (v579) goto L_0109;\n\tgoto L_022F;\nL_0220:\n\tv238[v428 @ X8_v15 (System.Int32)] = 3;\n\tgoto L_0203;\nL_022F:\n\treturn;\n\tv340 = new System.NullReferenceException();\n\tv435 = new System.IndexOutOfRangeException();\nL_0232:\n\tv473 = new System.ArrayTypeMismatchException();\n\tthrow v473;\n\treturn;\n// 431 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ComputeHold(TrackEntry entry)
		{
			Animation animation = entry.Animation;
			ExposedList<Timeline> timelines = animation.Timelines;
			TrackEntry mixingTo = entry.MixingTo;
			Timeline[] items = timelines.Items;
			ExposedList<int> exposedList = entry.timelineMode.Resize(timelines.Count);
			int[] items2 = exposedList.Items;
			entry.timelineHoldMix.Clear();
			ExposedList<TrackEntry> exposedList2 = entry.timelineHoldMix.Resize(timelines.Count);
			TrackEntry[] items3 = exposedList2.Items;
			if (entry.MixingTo != null && mixingTo.HoldPrevious)
			{
				if (timelines.Count >= 1)
				{
					int num = 0;
					bool flag;
					do
					{
						int propertyId = items[num].PropertyId;
						int num2 = ((!propertyIDs.Add(propertyId)) ? 2 : (2 + 1));
						int num3 = num + 1;
						items2[num] = num2;
						flag = num3 != timelines.Count;
						num = num3;
					}
					while (flag);
				}
			}
			else
			{
				if (timelines.Count < 1)
				{
					return;
				}
				int num4 = 0;
				do
				{
					int propertyId2 = items[num4].PropertyId;
					if (propertyIDs.Add(propertyId2))
					{
						if (entry.MixingTo != null)
						{
							AttachmentTimeline attachmentTimeline = items[num4] as AttachmentTimeline;
							if (attachmentTimeline == null)
							{
								DrawOrderTimeline drawOrderTimeline = items[num4] as DrawOrderTimeline;
								if (drawOrderTimeline == null)
								{
									EventTimeline eventTimeline = items[num4] as EventTimeline;
									if (eventTimeline == null)
									{
										bool flag2 = mixingTo.Animation.HasTimeline(propertyId2);
										bool flag3 = !flag2;
										TrackEntry mixingTo2 = entry.MixingTo;
										if (!flag3)
										{
											while (true)
											{
												mixingTo2 = mixingTo2.MixingTo;
												if (mixingTo2.MixingTo != null)
												{
													if (mixingTo2.Animation.HasTimeline(propertyId2))
													{
														continue;
													}
													if (mixingTo2.MixDuration > 0f)
													{
														items2[num4] = 4;
														object obj = mixingTo2.MixingTo as TrackEntry;
														if (obj != null)
														{
															items3[num4] = mixingTo2.MixingTo;
															break;
														}
														ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
														throw ex;
													}
												}
												items2[num4] = 3;
												break;
											}
											goto IL_04de;
										}
									}
								}
							}
						}
						items2[num4] = 1;
					}
					else
					{
						items2[num4] = 0;
					}
					goto IL_04de;
					IL_04de:
					num4++;
				}
				while (num4 != timelines.Count);
			}
		}

		[Token(Token = "0x60000D8")]
		[Address(RVA = "0x152B360", Offset = "0x152B360", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.tracks;\n\tv18 = v2.Count <= trackIndex;\n\tif (v18) goto L_FFFFFFFF;\n\tv42 = v2.Items;\n\tgoto L_002A;\nL_002A:\n\treturn returnVal1;\n\tv43 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TrackEntry GetCurrent(int trackIndex)
		{
			ExposedList<TrackEntry> exposedList = Tracks;
			if (exposedList.Count > trackIndex)
			{
				TrackEntry[] items = exposedList.Items;
				return items[trackIndex];
			}
			return null;
		}

		[Token(Token = "0x60000D9")]
		[Address(RVA = "0x152B3AC", Offset = "0x152B3AC", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.EventQueue::Clear(this.queue);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ClearListenerNotifications()
		{
			queue.Clear();
		}

		[Token(Token = "0x60000DF")]
		[Address(RVA = "0x152B4D0", Offset = "0x152B4D0", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv24 = System.Text.StringBuilder;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv48 = \", \";\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv53 = \"<none>\";\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A37B04]) = v44;\nL_001D:\n\tv46 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v46);\n\tv174 = this.tracks;\n\tv67 = v174.Count < 1;\n\tif (v67) goto L_0079;\nL_0034:\n\tv160 = v174.Items;\n\tv180 = v160[v85 @ X23_v6 (System.Int32)] == 0;\n\tif (v180) goto L_0065;\n\tv251 = System.Text.StringBuilder::get_Length(v46);\n\tv205 = v251 < 1;\n\tif (v205) goto L_0060;\n\tv258 = System.Text.StringBuilder::Append(v46, \", \");\nL_0060:\n\tv264 = Spine.TrackEntry::ToString(v160[v85 @ X23_v6 (System.Int32)]);\n\tv223 = System.Text.StringBuilder::Append(v46, v264);\nL_0065:\n\tv85 = v85 + 1;\n\tv120 = v174.Count == v85;\n\tif (v120) goto L_0079;\n\tv174 = this.tracks;\n\tv252 = this.tracks == 0;\n\tv154 = ~v252;\n\tif (v154) goto L_0034;\n\tv167 = new System.NullReferenceException();\nL_0079:\n\tv177 = System.Text.StringBuilder::get_Length(v46);\n\tv179 = v177 == 0;\n\tif (v179) goto L_0094;\n\tv182 = *([v46 @ X0_v3 (System.Text.StringBuilder)]);\n\tv188 = *([v182 @ X8_v7 (Il2CppClass<System.Text.StringBuilder>)+168]);\n\tv189 = *([v182 @ X8_v7 (Il2CppClass<System.Text.StringBuilder>)+170]);\n\t// 136 IndirectJump v188 @ X2_v2, v46 @ X0_v3 (System.Text.StringBuilder), v46 @ X0_v3 (System.Text.StringBuilder), v189 @ X1_v4, v188 @ X2_v2, v28 @ X3, v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\nL_0094:\n\treturn \"<none>\";\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			//IL_016b: Expected I, but got O
			//IL_017b: Expected O, but got I
			//IL_018b: Expected O, but got I
			StringBuilder stringBuilder = new StringBuilder();
			ExposedList<TrackEntry> exposedList = Tracks;
			if (exposedList.Count >= 1)
			{
				int num = 0;
				while (true)
				{
					TrackEntry[] items = exposedList.Items;
					if (items[num] != null)
					{
						int length = stringBuilder.Length;
						if (length >= 1)
						{
							StringBuilder stringBuilder2 = stringBuilder.Append(", ");
						}
						string value = items[num].ToString();
						StringBuilder stringBuilder3 = stringBuilder.Append(value);
					}
					num++;
					if (exposedList.Count == num)
					{
						break;
					}
					exposedList = Tracks;
					if (Tracks == null)
					{
						NullReferenceException ex = new NullReferenceException();
						break;
					}
				}
			}
			if (stringBuilder.Length != 0)
			{
				nint num2 = (nint)stringBuilder;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ X8_v7 (Il2CppClass<System.Text.StringBuilder>)+168]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ X8_v7 (Il2CppClass<System.Text.StringBuilder>)+170]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v188 @ X2_v2 (should have been resolved before IL gen)");
			}
			return "<none>";
		}

		[Token(Token = "0x60000E0")]
		[Address(RVA = "0x152B630", Offset = "0x152B630", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv30 = Spine.AnimationState;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv55 = Spine.Animation;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv65 = Spine.ExposedList`1<Spine.Timeline>;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv72 = \"<empty>\";\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv51 = 1;\n\t*([1A37B05]) = v51;\nL_002A:\n\tv53 = new Spine.ExposedList`1<Spine.Timeline>();\n\tSpine.ExposedList`1<Spine.Timeline>::.ctor(v53);\n\tv63 = new Spine.Animation();\n\tSpine.Animation::.ctor(v63, \"<empty>\", v53, 0f);\n\tv78.EmptyAnimation = v63;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static AnimationState()
		{
			ExposedList<Timeline> timelines = new ExposedList<Timeline>();
			Animation emptyAnimation = new Animation("<empty>", timelines, 0f);
			EmptyAnimation = emptyAnimation;
		}
	}
}
