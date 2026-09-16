using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000022")]
	internal class EventQueue
	{
		[Token(Token = "0x2000023")]
		private struct EventQueueEntry
		{
			[Token(Token = "0x40000DB")]
			[FieldOffset(Offset = "0x0")]
			public EventType type;

			[Token(Token = "0x40000DC")]
			[FieldOffset(Offset = "0x8")]
			public TrackEntry entry;

			[Token(Token = "0x40000DD")]
			[FieldOffset(Offset = "0x10")]
			public Event e;

			[Token(Token = "0x6000132")]
			[Address(RVA = "0x152C6B0", Offset = "0x152C6B0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.type = eventType;\n\tthis.entry = trackEntry;\n\tthis.e = e;\n\treturn;\n")]
			public EventQueueEntry(EventType eventType, TrackEntry trackEntry, Event e = null)
			{
				type = eventType;
				entry = trackEntry;
				this.e = e;
			}
		}

		[Token(Token = "0x2000024")]
		private enum EventType
		{
			[Token(Token = "0x40000DF")]
			Start = 0,
			[Token(Token = "0x40000E0")]
			Interrupt = 1,
			[Token(Token = "0x40000E1")]
			End = 2,
			[Token(Token = "0x40000E2")]
			Dispose = 3,
			[Token(Token = "0x40000E3")]
			Complete = 4,
			[Token(Token = "0x40000E4")]
			Event = 5
		}

		[Token(Token = "0x40000D6")]
		[FieldOffset(Offset = "0x10")]
		private readonly List<EventQueueEntry> eventQueueEntries;

		[Token(Token = "0x40000D7")]
		[FieldOffset(Offset = "0x18")]
		internal bool drainDisabled;

		[Token(Token = "0x40000D8")]
		[FieldOffset(Offset = "0x20")]
		private readonly AnimationState state;

		[Token(Token = "0x40000D9")]
		[FieldOffset(Offset = "0x28")]
		private readonly Pool<TrackEntry> trackEntryPool;

		[CompilerGenerated]
		[Token(Token = "0x40000DA")]
		[FieldOffset(Offset = "0x30")]
		private Action m_AnimationsChanged;

		[Token(Token = "0x1400000D")]
		internal event Action AnimationsChanged
		{
			[CompilerGenerated]
			[Token(Token = "0x6000127")]
			[Address(RVA = "0x152C578", Offset = "0x152C578", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = System.Action;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37B17]) = v38;\nL_0014:\n\tv40 = this + 0x30;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 48;
				Delegate obj2 = this.m_AnimationsChanged;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(Action))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
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
			[Token(Token = "0x6000128")]
			[Address(RVA = "0x152C614", Offset = "0x152C614", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = System.Action;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37B18]) = v38;\nL_0014:\n\tv40 = this + 0x30;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 48;
				Delegate obj2 = this.m_AnimationsChanged;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(Action))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
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

		[Token(Token = "0x6000129")]
		[Address(RVA = "0x1527BA4", Offset = "0x1527BA4", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, state, HandleAnimationsChanged, trackEntryPool, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv55 = System.Collections.Generic.List`1<Spine.EventQueue+EventQueueEntry>;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, state, HandleAnimationsChanged, trackEntryPool, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv51 = 1;\n\t*([1A37B19]) = v51;\nL_0020:\n\tv53 = new System.Collections.Generic.List`1<Spine.EventQueue+EventQueueEntry>();\n\tSystem.Collections.Generic.List`1<Spine.EventQueue+EventQueueEntry>::.ctor(v53);\n\tthis.eventQueueEntries = v53;\n\tSystem.Object::.ctor(this);\n\tthis.state = state;\n\tSpine.EventQueue::add_AnimationsChanged(this, HandleAnimationsChanged);\n\tthis.trackEntryPool = trackEntryPool;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal EventQueue(AnimationState state, Action HandleAnimationsChanged, Pool<TrackEntry> trackEntryPool)
		{
			List<EventQueueEntry> list = new List<EventQueueEntry>();
			eventQueueEntries = list;
			this.state = state;
			AnimationsChanged += HandleAnimationsChanged;
			this.trackEntryPool = trackEntryPool;
		}

		[Token(Token = "0x600012A")]
		[Address(RVA = "0x152A42C", Offset = "0x152A42C", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, entry, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A37B1A]) = v36;\nL_0012:\n\tv37 = this.eventQueueEntries;\n\tv42 = v37._items;\n\tv44 = v37._version + 1;\n\tv37._version = v44;\n\tv55 = v37._size < v42.Length;\n\tv56 = ~v55;\n\tif (v56) goto L_0037;\n\tv65 = v37._size + 1;\n\tv66 = v37._size * 0x18;\n\tv67 = v42 + v66;\n\tv37._size = v65;\n\t*([v67 @ X8_v9+20]) = 0;\n\tv42[v37._size (System.Int32)].entry = entry;\n\tv42[v37._size (System.Int32)].e = 0;\n\tgoto L_003B;\nL_0037:\n\tv70 = 0;\n\tSystem.Collections.Generic.List`1<Spine.EventQueue+EventQueueEntry>::AddWithResize(v37, &v70 @ stack_-38_v2);\nL_003B:\n\t;\n\tv115 = this.AnimationsChanged == 0;\n\tif (v115) goto L_0047;\n\tSystem.Action::Invoke(this.AnimationsChanged);\nL_0047:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe void Start(TrackEntry entry)
		{
			//IL_00ed: Expected O, but got I4
			//IL_00fa: Expected O, but got Ref
			//IL_0099: Expected O, but got I
			List<EventQueueEntry> list = eventQueueEntries;
			EventQueueEntry[] items = list._items;
			int version = list._version + 1;
			list._version = version;
			if (list.Count < items.Length)
			{
				int size = list.Count + 1;
				int num = list.Count * 24;
				object obj = (nint)items + num;
				list._size = size;
				_ = 0;
				items[list.Count].entry = entry;
				items[list.Count].e = null;
			}
			else
			{
				object obj2 = 0;
				list.Add((EventQueueEntry)(&obj2));
			}
			if (this.AnimationsChanged != null)
			{
				this.AnimationsChanged();
			}
		}

		[Token(Token = "0x600012B")]
		[Address(RVA = "0x152A364", Offset = "0x152A364", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, entry, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A37B1B]) = v36;\nL_0012:\n\tv37 = this.eventQueueEntries;\n\tv42 = v37._items;\n\tv44 = v37._version + 1;\n\tv37._version = v44;\n\tv57 = v37._size < v42.Length;\n\tv58 = ~v57;\n\tif (v58) goto L_003B;\n\tv69 = v37._size + 1;\n\tv70 = v37._size * 0x18;\n\tv71 = v42 + v70;\n\tv37._size = v69;\n\t*([v71 @ X8_v8+20]) = 5E-324d;\n\tv42[v37._size (System.Int32)].entry = entry;\n\tv42[v37._size (System.Int32)].e = 0;\n\tgoto L_0044;\nL_003B:\n\tv76 = 5E-324d;\n\tSystem.Collections.Generic.List`1<Spine.EventQueue+EventQueueEntry>::AddWithResize(v37, &v76 @ stack_-38_v2 (System.Double));\nL_0044:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe void Interrupt(TrackEntry entry)
		{
			//IL_0102: Expected O, but got Ref
			//IL_0099: Expected O, but got I
			List<EventQueueEntry> list = eventQueueEntries;
			EventQueueEntry[] items = list._items;
			int version = list._version + 1;
			list._version = version;
			if (list.Count < items.Length)
			{
				int size = list.Count + 1;
				int num = list.Count * 24;
				object obj = (nint)items + num;
				list._size = size;
				_ = double.Epsilon;
				items[list.Count].entry = entry;
				items[list.Count].e = null;
			}
			else
			{
				double num2 = double.Epsilon;
				list.Add((EventQueueEntry)(&num2));
			}
		}

		[Token(Token = "0x600012C")]
		[Address(RVA = "0x1527F94", Offset = "0x1527F94", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, entry, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A37B1C]) = v36;\nL_0012:\n\tv37 = this.eventQueueEntries;\n\tv42 = v37._items;\n\tv44 = v37._version + 1;\n\tv37._version = v44;\n\tv57 = v37._size < v42.Length;\n\tv58 = ~v57;\n\tif (v58) goto L_003B;\n\tv69 = v37._size + 1;\n\tv70 = v37._size * 0x18;\n\tv71 = v42 + v70;\n\tv37._size = v69;\n\t*([v71 @ X8_v9+20]) = 1E-323d;\n\tv42[v37._size (System.Int32)].entry = entry;\n\tv42[v37._size (System.Int32)].e = 0;\n\tgoto L_003F;\nL_003B:\n\tv76 = 1E-323d;\n\tSystem.Collections.Generic.List`1<Spine.EventQueue+EventQueueEntry>::AddWithResize(v37, &v76 @ stack_-38_v2 (System.Double));\nL_003F:\n\t;\n\tv123 = this.AnimationsChanged == 0;\n\tif (v123) goto L_004B;\n\tSystem.Action::Invoke(this.AnimationsChanged);\nL_004B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe void End(TrackEntry entry)
		{
			//IL_0103: Expected O, but got Ref
			//IL_0099: Expected O, but got I
			List<EventQueueEntry> list = eventQueueEntries;
			EventQueueEntry[] items = list._items;
			int version = list._version + 1;
			list._version = version;
			if (list.Count < items.Length)
			{
				int size = list.Count + 1;
				int num = list.Count * 24;
				object obj = (nint)items + num;
				list._size = size;
				_ = 1E-323;
				items[list.Count].entry = entry;
				items[list.Count].e = null;
			}
			else
			{
				double num2 = 1E-323;
				list.Add((EventQueueEntry)(&num2));
			}
			if (this.AnimationsChanged != null)
			{
				this.AnimationsChanged();
			}
		}

		[Token(Token = "0x600012D")]
		[Address(RVA = "0x152AE14", Offset = "0x152AE14", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, entry, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A37B1D]) = v36;\nL_0012:\n\tv37 = this.eventQueueEntries;\n\tv42 = v37._items;\n\tv44 = v37._version + 1;\n\tv37._version = v44;\n\tv57 = v37._size < v42.Length;\n\tv58 = ~v57;\n\tif (v58) goto L_003B;\n\tv69 = v37._size + 1;\n\tv70 = v37._size * 0x18;\n\tv71 = v42 + v70;\n\tv37._size = v69;\n\t*([v71 @ X8_v8+20]) = 1.5E-323d;\n\tv42[v37._size (System.Int32)].entry = entry;\n\tv42[v37._size (System.Int32)].e = 0;\n\tgoto L_0044;\nL_003B:\n\tv76 = 1.5E-323d;\n\tSystem.Collections.Generic.List`1<Spine.EventQueue+EventQueueEntry>::AddWithResize(v37, &v76 @ stack_-38_v2 (System.Double));\nL_0044:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe void Dispose(TrackEntry entry)
		{
			//IL_0102: Expected O, but got Ref
			//IL_0099: Expected O, but got I
			List<EventQueueEntry> list = eventQueueEntries;
			EventQueueEntry[] items = list._items;
			int version = list._version + 1;
			list._version = version;
			if (list.Count < items.Length)
			{
				int size = list.Count + 1;
				int num = list.Count * 24;
				object obj = (nint)items + num;
				list._size = size;
				_ = 1.5E-323;
				items[list.Count].entry = entry;
				items[list.Count].e = null;
			}
			else
			{
				double num2 = 1.5E-323;
				list.Add((EventQueueEntry)(&num2));
			}
		}

		[Token(Token = "0x600012E")]
		[Address(RVA = "0x152A068", Offset = "0x152A068", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, entry, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A37B1E]) = v36;\nL_0012:\n\tv37 = this.eventQueueEntries;\n\tv42 = v37._items;\n\tv44 = v37._version + 1;\n\tv37._version = v44;\n\tv57 = v37._size < v42.Length;\n\tv58 = ~v57;\n\tif (v58) goto L_003B;\n\tv69 = v37._size + 1;\n\tv70 = v37._size * 0x18;\n\tv71 = v42 + v70;\n\tv37._size = v69;\n\t*([v71 @ X8_v8+20]) = 2E-323d;\n\tv42[v37._size (System.Int32)].entry = entry;\n\tv42[v37._size (System.Int32)].e = 0;\n\tgoto L_0044;\nL_003B:\n\tv76 = 2E-323d;\n\tSystem.Collections.Generic.List`1<Spine.EventQueue+EventQueueEntry>::AddWithResize(v37, &v76 @ stack_-38_v2 (System.Double));\nL_0044:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe void Complete(TrackEntry entry)
		{
			//IL_0102: Expected O, but got Ref
			//IL_0099: Expected O, but got I
			List<EventQueueEntry> list = eventQueueEntries;
			EventQueueEntry[] items = list._items;
			int version = list._version + 1;
			list._version = version;
			if (list.Count < items.Length)
			{
				int size = list.Count + 1;
				int num = list.Count * 24;
				object obj = (nint)items + num;
				list._size = size;
				_ = 2E-323;
				items[list.Count].entry = entry;
				items[list.Count].e = null;
			}
			else
			{
				double num2 = 2E-323;
				list.Add((EventQueueEntry)(&num2));
			}
		}

		[Token(Token = "0x600012F")]
		[Address(RVA = "0x1529F94", Offset = "0x1529F94", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, entry, e, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A37B1F]) = v39;\nL_0014:\n\tv40 = this.eventQueueEntries;\n\tv45 = v40._items;\n\tv47 = v40._version + 1;\n\tv40._version = v47;\n\tv60 = v40._size < v45.Length;\n\tv61 = ~v60;\n\tif (v61) goto L_003D;\n\tv72 = v40._size + 1;\n\tv73 = v40._size * 0x18;\n\tv74 = v45 + v73;\n\tv40._size = v72;\n\t*([v74 @ X8_v8+20]) = 2.5E-323d;\n\tv45[v40._size (System.Int32)].entry = entry;\n\tv45[v40._size (System.Int32)].e = e;\n\tgoto L_0047;\nL_003D:\n\tv79 = 2.5E-323d;\n\tSystem.Collections.Generic.List`1<Spine.EventQueue+EventQueueEntry>::AddWithResize(v40, &v79 @ stack_-48_v2 (System.Double));\nL_0047:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe void Event(TrackEntry entry, Event e)
		{
			//IL_0105: Expected O, but got Ref
			//IL_0099: Expected O, but got I
			List<EventQueueEntry> list = eventQueueEntries;
			EventQueueEntry[] items = list._items;
			int version = list._version + 1;
			list._version = version;
			if (list.Count < items.Length)
			{
				int size = list.Count + 1;
				int num = list.Count * 24;
				object obj = (nint)items + num;
				list._size = size;
				_ = 2.5E-323;
				items[list.Count].entry = entry;
				items[list.Count].e = e;
			}
			else
			{
				double num2 = 2.5E-323;
				list.Add((EventQueueEntry)(&num2));
			}
		}

		[Token(Token = "0x6000130")]
		[Address(RVA = "0x15281A0", Offset = "0x15281A0", Length = "0x2C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv28 = Il2CppMethodInfo;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv53 = Il2CppMethodInfo;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv140 = Il2CppMethodInfo;\n\tv141 = \"il2cpp_codegen_initialize_runtime_metadata\"(v140, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv257 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v257, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A37B20]) = v48;\nL_0021:\n\tv50 = ~this.drainDisabled;\n\tv51 = ~v50;\n\tif (v51) goto L_010C;\n\tv55 = this.eventQueueEntries;\n\tthis.drainDisabled = 1;\n\tv153 = v55._size < 1;\n\tif (v153) goto L_00E8;\n\tv224 = 0x44C000 + 0xD13;\nL_0042:\n\tv250 = System.Collections.Generic.List`1<Spine.EventQueue+EventQueueEntry>::get_Item(v55, v222);\n\tv220 = v250.type;\n\tv298 = v250.type < 5;\n\tv248 = ~v298;\n\tv246 = v250.type - 5;\n\tv242 = v246 == 0;\n\tv299 = ~v242;\n\tv232 = v248 & v299;\n\tif (v232) goto L_00DB;\n\tv200 = *([v224 @ X26_v6 (System.Int32)+v220 @ stack_-68_v5 (Spine.EventQueue+EventType)]) << 2;\n\tv206 = 0x152C278 + v200;\n\t// 91 IndirectJump v206 @ X9_v5 (System.Int32), v250 @ X0_v10 (Spine.EventQueue+EventQueueEntry), v250 @ X0_v10 (Spine.EventQueue+EventQueueEntry), v222 @ X21_v6 (System.Int32), methodof(System.Collections.Generic.List`1<Spine.EventQueue+EventQueueEntry>::get_Item), v32 @ X3, v33 @ X4, v34 @ X5, v35 @ X6, v36 @ X7, v37 @ V0, v38 @ V1, v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X22+30]);\n\tif (TEMP) goto L_0066;\n\tX9 = *([X8+18]);\n\tX0 = *([X8+40]);\n\tX2 = *([X8+28]);\n\tX1 = X22;\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0066:\n\tTEMP = X24 == 0;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X24+28]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00BD;\n\tgoto L_00DB;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X22+38]);\n\tif (TEMP) goto L_0077;\n\tX9 = *([X8+18]);\n\tX0 = *([X8+40]);\n\tX2 = *([X8+28]);\n\tX1 = X22;\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0077:\n\tTEMP = X24 == 0;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X24+30]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00BD;\n\tgoto L_00DB;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X22+40]);\n\tif (TEMP) goto L_0088;\n\tX9 = *([X8+18]);\n\tX0 = *([X8+40]);\n\tX2 = *([X8+28]);\n\tX1 = X22;\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0088:\n\tTEMP = X24 == 0;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X24+38]);\n\tif (TEMP) goto L_0095;\n\tX9 = *([X8+18]);\n\tX0 = *([X8+40]);\n\tX2 = *([X8+28]);\n\tX1 = X22;\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_0095;\n\tif (TEMP) goto L_FFFFFFFF;\nL_0095:\n\tX8 = *([X22+48]);\n\tif (TEMP) goto L_009D;\n\tX9 = *([X8+18]);\n\tX0 = *([X8+40]);\n\tX2 = *([X8+28]);\n\tX1 = X22;\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_009D:\n\tTEMP = X24 == 0;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X24+40]);\n\tif (TEMP) goto L_00A7;\n\tX9 = *([X8+18]);\n\tX0 = *([X8+40]);\n\tX2 = *([X8+28]);\n\tX1 = X22;\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00A7:\n\tX0 = *([X19+28]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX2 = *([X27]);\n\tX1 = X22;\n\tSpine.Pool`1::Free /* +1 sharing this address */(X0, X1, X2);\n\tgoto L_00DB;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X22+50]);\n\tif (TEMP) goto L_00B8;\n\tX9 = *([X8+18]);\n\tX0 = *([X8+40]);\n\tX2 = *([X8+28]);\n\tX1 = X22;\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00B8:\n\tTEMP = X24 == 0;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X24+48]);\n\tif (TEMP) goto L_00DB;\nL_00BD:\n\tX9 = *([X8+18]);\n\tX0 = *([X8+40]);\n\tX2 = *([X8+28]);\n\tX1 = X22;\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00DB;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X22+58]);\n\tX23 = stack[18];\n\tif (TEMP) goto L_00CF;\n\tX9 = *([X8+18]);\n\tX0 = *([X8+40]);\n\tX3 = *([X8+28]);\n\tX1 = X22;\n\tX2 = X23;\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00CF:\n\tTEMP = X24 == 0;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X24+50]);\n\tif (TEMP) goto L_00DB;\n\tX9 = *([X8+18]);\n\tX0 = *([X8+40]);\n\tX3 = *([X8+28]);\n\tX1 = X22;\n\tX2 = X23;\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00DB:\n\tv222 = v222 + 1;\n\tv263 = v222 < v55._size;\n\tif (v263) goto L_0042;\nL_00E8:\n\tv127 = this.eventQueueEntries;\n\tv65 = v127._version + 1;\n\tv127._size = 0;\n\tv127._version = v65;\n\tv96 = v127._size < 1;\n\tif (v96) goto L_0100;\n\tSystem.Array::Clear(v127._items, 0, v127._size);\nL_0100:\n\tthis.drainDisabled = 0;\nL_010C:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void Drain()
		{
			if (drainDisabled)
			{
				return;
			}
			List<EventQueueEntry> list = eventQueueEntries;
			drainDisabled = true;
			if (list.Count >= 1)
			{
				int num = 4505600 + 3347;
				int num2 = 0;
				do
				{
					EventQueueEntry eventQueueEntry = list[num2];
					EventType type = eventQueueEntry.type;
					bool flag = eventQueueEntry.type < EventType.Event;
					bool flag2 = !flag;
					int num3 = (int)(eventQueueEntry.type - 5);
					bool flag3 = num3 == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ X26_v6 (System.Int32)+v220 @ stack_-68_v5 (Spine.EventQueue+EventType)]");
						int num4 = (int)((nint)0 << 2);
						int num5 = 22200952 + num4;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v206 @ X9_v5 (System.Int32) (should have been resolved before IL gen)");
						break;
					}
					num2++;
				}
				while (num2 < list.Count);
			}
			List<EventQueueEntry> list2 = eventQueueEntries;
			int version = list2._version + 1;
			list2._size = 0;
			list2._version = version;
			if (list2.Count >= 1)
			{
				Array.Clear(list2._items, 0, list2.Count);
			}
			drainDisabled = false;
		}

		[Token(Token = "0x6000131")]
		[Address(RVA = "0x152B3C4", Offset = "0x152B3C4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37B21]) = v33;\nL_0010:\n\tv34 = this.eventQueueEntries;\n\tv38 = v34._version + 1;\n\tv34._size = 0;\n\tv34._version = v38;\n\tv49 = v34._size < 1;\n\tif (v49) goto L_0031;\n\tSystem.Array::Clear(v34._items, 0, v34._size);\n\treturn;\nL_0031:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void Clear()
		{
			List<EventQueueEntry> list = eventQueueEntries;
			int version = list._version + 1;
			list._size = 0;
			list._version = version;
			if (list.Count >= 1)
			{
				Array.Clear(list._items, 0, list.Count);
			}
		}
	}
}
