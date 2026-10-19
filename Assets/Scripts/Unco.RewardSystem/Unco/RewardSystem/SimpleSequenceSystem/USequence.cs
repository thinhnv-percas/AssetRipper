using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.Extensions;

namespace Unco.RewardSystem.SimpleSequenceSystem
{
	[Token(Token = "0x200002B")]
	public class USequence : ISequenceElement
	{
		[Token(Token = "0x200002C")]
		internal struct SequenceElementData
		{
			[Token(Token = "0x4000052")]
			[FieldOffset(Offset = "0x0")]
			public int bindType;

			[Token(Token = "0x4000053")]
			[FieldOffset(Offset = "0x8")]
			public ISequenceElement element;
		}

		[CompilerGenerated]
		[Token(Token = "0x200002F")]
		private sealed class _003C_003Ec__DisplayClass13_2
		{
			[Token(Token = "0x4000058")]
			[FieldOffset(Offset = "0x10")]
			public Action callback;

			[Token(Token = "0x4000059")]
			[FieldOffset(Offset = "0x18")]
			public int remainingCount;

			[Token(Token = "0x60000BB")]
			[Address(RVA = "0x81DB4C0", Offset = "0x81DB4C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass13_2()
			{
			}

			internal void _003CStart_003Eb__2()
			{
				bool flag = remainingCount == 1;
				int num = remainingCount - 1;
				remainingCount = num;
				if (flag)
				{
					callback();
				}
			}
		}

		[Token(Token = "0x400004E")]
		[FieldOffset(Offset = "0x10")]
		private readonly List<SequenceElementData> _list;

		[Token(Token = "0x400004F")]
		[FieldOffset(Offset = "0x18")]
		private readonly List<(int afterIndex, Action callback)> _pendingCallbacks;

		[CompilerGenerated]
		[Token(Token = "0x4000050")]
		[FieldOffset(Offset = "0x20")]
		private Action _003COnComplete_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000051")]
		[FieldOffset(Offset = "0x28")]
		private Action _003COnStart_003Ek__BackingField;

		[Token(Token = "0x14000007")]
		public event Action OnComplete
		{
			[CompilerGenerated]
			[Token(Token = "0x60000B0")]
			[Address(RVA = "0x81DB0BC", Offset = "0x81DB0BC", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnComplete (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnComplete;\n\tgoto L_002C;\n")]
			add
			{
				Action action = _003COnComplete_003Ek__BackingField;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref _003COnComplete_003Ek__BackingField, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			[Token(Token = "0x60000B1")]
			[Address(RVA = "0x81DB160", Offset = "0x81DB160", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnComplete (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnComplete;\n\tgoto L_002C;\n")]
			remove
			{
				Action action = _003COnComplete_003Ek__BackingField;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref _003COnComplete_003Ek__BackingField, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		[Token(Token = "0x14000008")]
		public event Action OnStart
		{
			[CompilerGenerated]
			[Token(Token = "0x60000B2")]
			[Address(RVA = "0x81DB204", Offset = "0x81DB204", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnStart (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnStart;\n\tgoto L_002C;\n")]
			add
			{
				Action action = _003COnStart_003Ek__BackingField;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref _003COnStart_003Ek__BackingField, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			[Token(Token = "0x60000B3")]
			[Address(RVA = "0x81DB2A8", Offset = "0x81DB2A8", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnStart (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnStart;\n\tgoto L_002C;\n")]
			remove
			{
				Action action = _003COnStart_003Ek__BackingField;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref _003COnStart_003Ek__BackingField, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		[Token(Token = "0x60000AB")]
		[Address(RVA = "0x81D9CF8", Offset = "0x81D9CF8", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tthis._list = v61;\n\tv74 = new System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Action>>();\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Action>>::.ctor(v74);\n\tthis._pendingCallbacks = v74;\n\treturn;\nL_0029:\n\tSystem.Object::.ctor(this);\n\tv61 = new System.Collections.Generic.List`1<Unco.RewardSystem.SimpleSequenceSystem.USequence+SequenceElementData>();\n\tSystem.Collections.Generic.List`1<Unco.RewardSystem.SimpleSequenceSystem.USequence+SequenceElementData>::.ctor(v61);\n")]
		public USequence()
		{
			List<SequenceElementData> list = new List<SequenceElementData>();
			_list = list;
			_pendingCallbacks = new List<(int, Action)>();
		}

		[Token(Token = "0x60000AC")]
		[Address(RVA = "0x81D9E0C", Offset = "0x81D9E0C", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tgoto L_004A;\nL_004A:\n\tSystem.Collections.Generic.List`1<Unco.RewardSystem.SimpleSequenceSystem.USequence+SequenceElementData>::Add(v51, 0);\n\treturn this;\nL_001B:\n\tv51 = this._list;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public USequence Append(ISequenceElement element)
		{
			List<SequenceElementData> list = _list;
			list.Add(default(SequenceElementData));
			return this;
		}

		[Token(Token = "0x60000AD")]
		[Address(RVA = "0x81DAEB4", Offset = "0x81DAEB4", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv52 = v44.Count - 1;\n\tv53 = this._pendingCallbacks;\n\tSystem.ValueTuple`2<System.Int32, System.Object>::.ctor(&v58 @ stack_-40_v3 (System.ValueTuple`2<System.Int32, System.Object>), v52, action);\n\tgoto L_0058;\nL_0058:\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Object>>::Add(v53, v58);\n\treturn this;\nL_001B:\n\tv44 = this._list;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public USequence AppendCallback(Action action)
		{
			List<SequenceElementData> list = _list;
			int item = list.Count - 1;
			List<(int, object)> pendingCallbacks = (List<(int, object)>)(object)_pendingCallbacks;
			(int, object) item2 = (item, action);
			pendingCallbacks.Add(item2);
			return this;
		}

		[Token(Token = "0x60000AE")]
		[Address(RVA = "0x81D9F00", Offset = "0x81D9F00", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tgoto L_004C;\nL_004C:\n\tSystem.Collections.Generic.List`1<Unco.RewardSystem.SimpleSequenceSystem.USequence+SequenceElementData>::Add(v54, v51);\n\treturn this;\nL_001D:\n\tv54 = this._list;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public USequence Join(ISequenceElement element)
		{
			List<SequenceElementData> list = _list;
			SequenceElementData item = default(SequenceElementData);
			list.Add(item);
			return this;
		}

		[Token(Token = "0x60000AF")]
		[Address(RVA = "0x81DAFDC", Offset = "0x81DAFDC", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tgoto L_004E;\nL_001C:\n\tv48 = System.Linq.Enumerable::Last(this._list);\nL_004E:\n\tUnco.RewardSystem.SimpleSequenceSystem.ISequenceElement::add_OnStart(Il2CppMethodInfo, action);\n\treturn this;\n")]
		public USequence JoinCallback(Action action)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("USequence::JoinCallback");
			return default;
		}

		[Token(Token = "0x60000B4")]
		[Address(RVA = "0x81D9FFC", Offset = "0x81D9FFC", Length = "0x9BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_005F;\n\tv64.<>4__this = this;\n\tv384 = this.OnStart == 0;\n\tif (v384) goto L_0075;\n\tSystem.Action::Invoke(this.OnStart);\n\tv601 = this.OnComplete == 0;\n\tif (v601) goto L_0341;\n\tSystem.Action::Invoke(this.OnComplete);\n\treturn;\nL_008D:\n\tv363 = this._list;\n\tv706 = v363.Count < 1;\n\tv374 = v363.Count - 1;\nL_FFFFFFFF:\n\tv131 = 0;\n\tif (v706) goto L_01CD;\nL_FFFFFFFF:\n\tv131 = 0;\n\tgoto L_00BB;\nL_00A7:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v131 @ stack_-80_v7 (System.Collections.Generic.List`1<Unco.RewardSystem.SimpleSequenceSystem.ISequenceElement>));\nL_FFFFFFFF:\n\tv131 = v1095._list;\nL_FFFFFFFF:\n\tv170 = 0;\nL_00B3:\n\tv825 = v374 <= 0;\nL_FFFFFFFF:\n\tv374 = v375;\n\tif (v825) goto L_01CD;\nL_00BB:\n\tv842 = System.Collections.Generic.List`1<Unco.RewardSystem.SimpleSequenceSystem.USequence+SequenceElementData>::get_Item(this._list, v374);\n\tv845 = v374 == 0;\nL_FFFFFFFF:\n\t;\n\tif (v845) goto L_01CD;\n\tv375 = v374 - 1;\n\tv229 = v842 == 1;\n\tif (v229) goto L_013D;\n\tv916 = v842 == 0;\n\tv917 = ~v916;\nL_FFFFFFFF:\n\t;\n\tif (v917) goto L_00B3;\n\tv926 = new Unco.RewardSystem.SimpleSequenceSystem.USequence+<>c__DisplayClass13_1();\n\tSystem.Object::.ctor(v926);\n\tv334 = Unco.RewardSystem.SimpleSequenceSystem.USequence::GetParallelGroup(this, v375);\n\tv926.elementToStart = v374;\n\tv926.remainingCount = v334.Count;\n\tv1042 = new System.Action();\n\tSystem.Action::.ctor(v1042, v926, Il2CppMethodInfo);\n\tv1095 = System.Collections.Generic.List`1<Unco.RewardSystem.SimpleSequenceSystem.ISequenceElement>::GetEnumerator(v334);\n\tv131 = v1095._list;\nL_FFFFFFFF:\n\t;\n\tgoto L_010C;\nL_0109:\n\tUnco.RewardSystem.SimpleSequenceSystem.ISequenceElement::add_OnComplete(v1095.Current, v1042);\nL_FFFFFFFF:\n\t;\n\tv583 = v1095.Current == 0;\n\tif (v583) goto L_01AB;\n\tgoto L_0109;\nL_013D:\n\tv963 = System.Collections.Generic.List`1<Unco.RewardSystem.SimpleSequenceSystem.USequence+SequenceElementData>::get_Item(this._list, v375);\n\tv337 = new System.Action();\n\tv367 = v374.m_value;\n\tv1031 = *([v367 @ X8_v64 (System.Int32)+12E]);\n\tv994 = *([v367 @ X8_v64 (System.Int32)+12E]) == 0;\n\tif (v994) goto L_016C;\n\tv120 = *([v367 @ X8_v64 (System.Int32)+B0]) + 8;\n\tv120 = v120 + 0x10;\n\tv1015 = v1031 - 1;\n\tv1006 = v1031 != 1;\nL_FFFFFFFF:\n\tv1031 = v1015;\n\tif (v1006) goto L_0152;\nL_016C:\n\tSystem.Action::.ctor(v337, v374, Il2CppMethodInfo);\n\tv1046 = v375 == 0;\n\tv351 = ~v1046;\n\tif (v351) goto L_0181;\n\tgoto L_0342;\nL_0172:\n\tv314 = *([v120 @ X10_v40]) + 4;\n\tv112 = v314 << 4;\n\tv368 = v367 + v112;\n\tv1045 = v368 + 0x138;\n\tSystem.Action::.ctor(v337, v374, *([v1045 @ X0_v101 (System.Int32)+8]));\nL_0181:\n\tgoto L_01A9;\nL_01AB:\n\tv577 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv170 = 0;\n\tgoto L_034A;\nL_01CD:\n\tv870 = &v170 @ stack_-C0 (System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Object>>+Enumerator<System.ValueTuple`2<System.Int32, System.Object>>);\n\tv871 = System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Object>>::GetEnumerator(this._pendingCallbacks);\n\tv170 = v170._list;\n\tv100 = v170._list;\n\tv96 = 0;\n\tv919 = new Unco.RewardSystem.SimpleSequenceSystem.USequence+<>c__DisplayClass13_2();\n\tSystem.Object::.ctor(v919);\n\tv585 = v919 == 0;\n\tif (v585) goto L_0345;\n\tv919.callback = v982;\n\tv996 = Unco.RewardSystem.SimpleSequenceSystem.USequence::GetParallelGroup(this, *([v870 @ X8_v14+10]));\n\tv586 = v996 == 0;\n\tif (v586) goto L_0347;\n\tv919.remainingCount = v996.Count;\n\tv1037 = new System.Action();\n\tSystem.Action::.ctor(v1037, v919, Il2CppMethodInfo);\n\tv1085 = System.Collections.Generic.List`1<Unco.RewardSystem.SimpleSequenceSystem.ISequenceElement>::GetEnumerator(v996);\n\tv131 = v1085._list;\nL_FFFFFFFF:\n\t;\n\tgoto L_022A;\nL_0227:\n\tUnco.RewardSystem.SimpleSequenceSystem.ISequenceElement::add_OnComplete(v1085.Current, v1037);\nL_FFFFFFFF:\n\t;\n\tv584 = v1085.Current == 0;\n\tif (v584) goto L_026D;\n\tgoto L_0227;\nL_FFFFFFFF:\n\tv170 = 0;\n\tgoto L_01EB;\nL_FFFFFFFF:\n\tv170 = 0;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv298 = 0xC;\n\tgoto L_0289;\nL_026D:\n\tv578 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv170 = 0;\nL_FFFFFFFF:\n\tv575 = v577;\n\tgoto L_034A;\nL_FFFFFFFF:\n\tv298 = 0x10;\n\tv686 = v298 | 0x10;\n\tv188 = v686 != 0x10;\n\tif (v188) goto L_0341;\n\tv370 = this._list;\n\tv329 = v370.Count - 1;\n\tv342 = Unco.RewardSystem.SimpleSequenceSystem.USequence::GetParallelGroup(this, v329);\n\tv64.finalGroupRemainingCount = v342.Count;\n\tv1054 = new System.Action();\n\tSystem.Action::.ctor(v1054, v64, Il2CppMethodInfo);\n\tv1133 = System.Collections.Generic.List`1<Unco.RewardSystem.SimpleSequenceSystem.ISequenceElement>::GetEnumerator(v342);\n\tv131 = v1133._list;\n\tgoto L_02CF;\nL_02CC:\n\tUnco.RewardSystem.SimpleSequenceSystem.ISequenceElement::add_OnComplete(v1133.Current, v1054);\n\tgoto L_02CC;\nL_02FF:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v131 @ stack_-80_v7 (System.Collections.Generic.List`1<Unco.RewardSystem.SimpleSequenceSystem.ISequenceElement>));\n\tv343 = System.Linq.Enumerable::First(this._list);\n\tgoto L_0333;\nL_0342:\n\tv379 = new System.NullReferenceException();\nL_0343:\n\tv462 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv170 = 0;\nL_FFFFFFFF:\n\tv575 = v578;\n\tgoto L_034A;\nL_0345:\n\tthrow v919;\nL_0347:\n\tv580 = new System.NullReferenceException();\n\tgoto L_034A;\nL_034A:\n\t// 842 Interrupt\nL_039A:\n\tv988 = new System.OutOfMemoryException();\n\tv857 = 0x39689A0(&v96 @ stack_-D0_v6, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv802 = v988;\nL_039F:\n\tv861 = 0x8BF0368(v802, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv798 = 0x7C03E68(v861, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_005F:\n\tv64 = new Unco.RewardSystem.SimpleSequenceSystem.USequence+<>c__DisplayClass13_0();\n\tSystem.Object::.ctor(v64);\nL_0075:\n\tv332 = Unco.Extensions.CollectionExtensions::IsNullOrEmpty(this._list);\n\tv476 = ~v332;\n\tif (v476) goto L_008D;\nL_0341:\n\treturn;\nL_010C:\n\tv1209 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v131 @ stack_-80_v7 (System.Collections.Generic.List`1<Unco.RewardSystem.SimpleSequenceSystem.ISequenceElement>));\n\tv956 = v1209 == 0;\n\tif (v956) goto L_00A7;\nL_0152:\n\tv231 = *([v120 @ X10_v40-8]) == Unco.RewardSystem.SimpleSequenceSystem.ISequenceElement;\n\tif (v231) goto L_0172;\nL_01A9:\n\tUnco.RewardSystem.SimpleSequenceSystem.ISequenceElement::add_OnStart(v375, v337);\nL_FFFFFFFF:\n\t;\n\tgoto L_00B3;\n\tv604 = 0x3968960(&v170 @ stack_-C0 (System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Object>>+Enumerator<System.ValueTuple`2<System.Int32, System.Object>>), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv802 = v575;\n\tgoto L_039F;\nL_022A:\n\tv1182 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v131 @ stack_-80_v7 (System.Collections.Generic.List`1<Unco.RewardSystem.SimpleSequenceSystem.ISequenceElement>));\n\tv1221 = v1182 == 0;\n\tif (v1221) goto L_025B;\nL_01EB:\n\tv906 = System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Object>>+Enumerator<System.ValueTuple`2<System.Int32, System.Object>>::MoveNext(&v100 @ stack_-A0_v7 (System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Object>>+Enumerator<System.ValueTuple`2<System.Int32, System.Object>>));\n\tv912 = v906 == 0;\n\tif (v912) goto L_FFFFFFFF;\nL_0289:\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Object>>+Enumerator<System.ValueTuple`2<System.Int32, System.Object>>::Dispose(&v100 @ \n// ... truncated")]
		public unsafe void Start()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("USequence::Start");
		}

		[Token(Token = "0x60000B5")]
		[Address(RVA = "0x81DB35C", Offset = "0x81DB35C", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv67 = v53 == 0;\n\tif (v67) goto L_008A;\nL_FFFFFFFF:\n\tv214 = startIndex;\nL_0038:\n\tv246 = System.Collections.Generic.List`1<Unco.RewardSystem.SimpleSequenceSystem.USequence+SequenceElementData>::get_Item(this._list, v214);\n\tgoto L_0058;\nL_0058:\n\tSystem.Collections.Generic.List`1<Unco.RewardSystem.SimpleSequenceSystem.ISequenceElement>::Add(v53, v214);\n\tv118 = System.Collections.Generic.List`1<Unco.RewardSystem.SimpleSequenceSystem.USequence+SequenceElementData>::get_Item(this._list, v214);\n\tv279 = v118 == 0;\n\tv284 = ~v279;\n\tv72 = ~v284;\n\tif (v72) goto L_FFFFFFFF;\n\tv96 = v214 < 0;\n\tv93 = v214 == 0;\n\tv291 = v214 ^ v214;\n\tv292 = v214 & v291;\n\tv81 = v292 < 0;\n\tgoto L_007A;\nL_FFFFFFFF:\n\tv81 = 0;\nL_FFFFFFFF:\n\tv93 = 1;\nL_FFFFFFFF:\n\tv96 = 0;\nL_0089:\n\treturn v53;\nL_008A:\n\tv258 = this._list;\n\tv141 = this._list == 0;\n\tv142 = ~v141;\nL_FFFFFFFF:\n\tv192 = startIndex;\n\tif (v142) goto L_0093;\n\tv255 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv258 = v255;\nL_FFFFFFFF:\n\tv192 = startIndex;\nL_0093:\n\tv261 = System.Collections.Generic.List`1<Unco.RewardSystem.SimpleSequenceSystem.USequence+SequenceElementData>::get_Item(v258, v192);\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\nL_0025:\n\tv53 = new System.Collections.Generic.List`1<Unco.RewardSystem.SimpleSequenceSystem.ISequenceElement>();\n\tSystem.Collections.Generic.List`1<Unco.RewardSystem.SimpleSequenceSystem.ISequenceElement>::.ctor(v53);\n\tv62 = startIndex & 0x80000000;\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0089;\nL_007A:\n\tv214 = v214 - 1;\n\tv298 = v96 == v81;\n\tv69 = ~v93;\n\tv75 = v298 & v69;\n\tif (v75) goto L_0038;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private List<ISequenceElement> GetParallelGroup(int startIndex)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("USequence::GetParallelGroup");
			return default;
		}

		[Token(Token = "0x60000B6")]
		[Address(RVA = "0x81DB4C8", Offset = "0x81DB4C8", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv46 = v39.Count;\n\tv48 = 0xB7D5000 + 0x538;\n\tv51 = \"il2cpp_vm_object_box\"(*([v48 @ X8_v6 (System.Int32)+48]), &v46 @ stack_-24_v1 (System.Int32), v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\treturnVal2 = System.String::Format(\"Sequence: {0}\", v51);\n\treturn returnVal2;\nL_0015:\n\tv39 = this._list;\n")]
		public override string ToString()
		{
			List<SequenceElementData> list = _list;
			int count = list.Count;
			int num = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			return $"Sequence: {arg}";
		}
	}
}
