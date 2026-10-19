using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.MoldSystem;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.MoldSystem.Core.Conditions;
using _game.CoreSystem.New.MoldSystem.Core.Handlers;
using _game.CoreSystem.New.MoldSystem.Core.Results;
using _game.CoreSystem.New.MoldSystem.Visual;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.SwitchSystem;

namespace _game.CoreSystem.New.MoldSystem
{
	[Token(Token = "0x20002A5")]
	public class MoldAbsorptionBridge
	{
		[Inject(false)]
		[Token(Token = "0x4000825")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000826")]
		[FieldOffset(Offset = "0x18")]
		private MoldFillHandler _fillHandler;

		[Inject(false)]
		[Token(Token = "0x4000827")]
		[FieldOffset(Offset = "0x20")]
		private MoldGridHandler _gridHandler;

		[Inject(false)]
		[Token(Token = "0x4000828")]
		[FieldOffset(Offset = "0x28")]
		private MoldVisualGridController _visualGrid;

		[Inject(false)]
		[Token(Token = "0x4000829")]
		[FieldOffset(Offset = "0x30")]
		private MoldConfig _config;

		[Token(Token = "0x400082A")]
		[FieldOffset(Offset = "0x38")]
		private MoldClaimValidator _normalValidator;

		[Token(Token = "0x400082B")]
		[FieldOffset(Offset = "0x40")]
		internal readonly RefCountedLock _absorptionLock;

		[CompilerGenerated]
		[Token(Token = "0x400082C")]
		[FieldOffset(Offset = "0x48")]
		private Action OnParticleAbsorbed;

		[CompilerGenerated]
		[Token(Token = "0x400082D")]
		[FieldOffset(Offset = "0x50")]
		private Action<int> OnEntityVisualComplete;

		[CompilerGenerated]
		[Token(Token = "0x400082E")]
		[FieldOffset(Offset = "0x58")]
		private Action<int, int> OnMoldVisualComplete;

		[Token(Token = "0x170000F2")]
		[field: Token(Token = "0x4000824")]
		public static MoldAbsorptionBridge Instance
		{
			[Token(Token = "0x6000B9E")]
			[Address(RVA = "0x3EC7D28", Offset = "0x3EC7D28", Length = "0x4C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\treturn v40.<Instance>k__BackingField;\n")]
			get;
			[Token(Token = "0x6000B9F")]
			[Address(RVA = "0x3EC7D74", Offset = "0x3EC7D74", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv45.<Instance>k__BackingField = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x170000F3")]
		public MoldConfig Config
		{
			[Token(Token = "0x6000BA6")]
			[Address(RVA = "0x3EC81E8", Offset = "0x3EC81E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Config;\n")]
			get
			{
				return _config;
			}
		}

		[Token(Token = "0x170000F4")]
		public bool IsAbsorptionLocked
		{
			[Token(Token = "0x6000BA7")]
			[Address(RVA = "0x3EC81F0", Offset = "0x3EC81F0", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.New.SwitchSystem.RefCountedLock::get_IsLocked(this._absorptionLock);\n\treturn returnVal1;\n")]
			get
			{
				return _absorptionLock.IsLocked;
			}
		}

		[Token(Token = "0x170000F5")]
		public int ColumnCount
		{
			[Token(Token = "0x6000BA9")]
			[Address(RVA = "0x3EC8228", Offset = "0x3EC8228", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.New.MoldSystem.MoldQueryHelper::GetColumns(this._em);\n\treturn returnVal1;\n")]
			get
			{
				return MoldQueryHelper.GetColumns(_em);
			}
		}

		[Token(Token = "0x170000F6")]
		public int RowCount
		{
			[Token(Token = "0x6000BAA")]
			[Address(RVA = "0x3EC82D4", Offset = "0x3EC82D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.New.MoldSystem.MoldQueryHelper::GetRows(this._em);\n\treturn returnVal1;\n")]
			get
			{
				return MoldQueryHelper.GetRows(_em);
			}
		}

		[Token(Token = "0x170000F7")]
		public int MaxEntityId
		{
			[Token(Token = "0x6000BAB")]
			[Address(RVA = "0x3EC837C", Offset = "0x3EC837C", Length = "0x2E8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\nL_0026:\n\tv51 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv191 = *([v51 @ X0_v24 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv246 = *([v191 @ X8_v18 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv193 = *([v191 @ X8_v18 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v193) goto L_0051;\n\tv245 = *([v191 @ X8_v18 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv245 = v245 + 0x10;\n\tv221 = v246 - 1;\n\tv201 = v246 != 1;\nL_FFFFFFFF:\n\tv246 = v221;\n\tif (v201) goto L_0037;\nL_0051:\n\tv302 = System.Collections.Generic.IEnumerable`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::GetEnumerator(v51);\n\tv265 = v302 == 0;\nL_FFFFFFFF:\n\tv286 = v302;\nL_FFFFFFFF:\n\tv143 = &v286 @ stack_-38_v8 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv288 = 0;\n\tif (v265) goto L_010B;\nL_FFFFFFFF:\n\tv380 = v302;\nL_FFFFFFFF:\n\tv383 = 0;\n\tgoto L_00B9;\n\tgoto L_00CD;\nL_FFFFFFFF:\n\tv383 = v375;\nL_00D0:\n\tv415 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv171 = 0;\n\tgoto L_0121;\nL_00D3:\n\tv493 = &v286 @ stack_-38_v8 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\n\tv457 = *([v493 @ X8_v27]);\n\tv491 = *([v493 @ X8_v27]) == 0;\nL_FFFFFFFF:\n\tv494 = 0;\nL_FFFFFFFF:\n\tv496 = v383;\nL_FFFFFFFF:\n\tv144 = v143;\nL_FFFFFFFF:\n\tv171 = 0;\nL_FFFFFFFF:\n\tv180 = 0;\nL_FFFFFFFF:\n\tv182 = v383;\n\tif (v491) goto L_0114;\nL_00DD:\n\tgoto L_0113;\nL_00FD:\n\tv272 = *([v245 @ X10_v31]) << 4;\n\tv273 = v191 + v272;\n\tv274 = v273 + 0x138;\n\t*([v274 @ X8_v36])(v302, v51, *([v274 @ X8_v36+8]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv282 = v302 == 0;\n\tv283 = ~v282;\nL_FFFFFFFF:\n\tv286 = v302;\nL_FFFFFFFF:\n\tv143 = &v286 @ stack_-38_v8 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv288 = 0;\n\tif (v283) goto L_FFFFFFFF;\nL_010B:\n\tgoto L_00D0;\n\treturn v182;\nL_0121:\n\t// 289 Interrupt\nL_0124:\n\tv184 = new System.OutOfMemoryException();\n\tgoto L_0131;\nL_0131:\n\tv234 = v171 != 1;\n\tif (v234) goto L_013F;\n\tv266 = 0x8BF5BC4(v184, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv494 = *([v266 @ X0_v15]);\n\tv337 = 0x8BF5BF4(v266, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv457 = *([v144 @ stack_-40_v1]);\n\tv418 = *([v144 @ stack_-40_v1]) == 0;\n\tv419 = ~v418;\nL_FFFFFFFF:\n\tv288 = *([v266 @ X0_v15]);\nL_FFFFFFFF:\n\tv496 = v182;\n\tif (v419) goto L_00DD;\nL_FFFFFFFF:\n\tv144 = v144;\nL_FFFFFFFF:\n\tv288 = *([v266 @ X0_v15]);\nL_FFFFFFFF:\n\tv180 = *([v266 @ X0_v15]);\nL_FFFFFFFF:\n\tv182 = v182;\n\tgoto L_0114;\nL_013F:\n\tv269 = 0x3175484(&v288 @ stack_-48_v9 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv339 = 0x8BF0368(v184, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = 0xA1B8(v339, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\nL_0037:\n\tv251 = *([v245 @ X10_v31-8]) == System.Collections.Generic.IEnumerable`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v251) goto L_00FD;\nL_0088:\n\tv489 = System.Collections.IEnumerator::MoveNext(v380);\n\tv621 = v489 == 0;\n\tif (v621) goto L_00D3;\nL_00B9:\n\tv375 = System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Current(v286);\n\tv365 = v383 - v375;\n\tv363 = v365 < 0;\n\tv361 = v365 == 0;\n\tv359 = v383 ^ v375;\n\tv357 = v383 ^ v365;\n\tv355 = v359 & v357;\n\tv353 = v355 < 0;\n\tv723 = v363 == v353;\n\tv343 = ~v361;\n\tv351 = v723 & v343;\n\tv341 = ~v351;\n\tif (v341) goto L_FFFFFFFF;\nL_00CD:\n\tv726 = v286 == 0;\n\tv377 = ~v726;\nL_FFFFFFFF:\n\tv380 = v286;\n\tif (v377) goto L_0062;\nL_0114:\n\tv546 = v180 == 0;\n\tv176 = ~v546;\nL_FFFFFFFF:\n\tv143 = v144;\n\tif (v176) goto L_0124;\nL_0113:\n\tSystem.IDisposable::Dispose(v457);\nL_FFFFFFFF:\n\tv144 = v143;\nL_FFFFFFFF:\n\tv171 = 0;\nL_FFFFFFFF:\n\tv180 = v494;\nL_FFFFFFFF:\n\tv182 = v496;\nL_0062:\n\tgoto L_0088;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionBridge::get_MaxEntityId");
				return default;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x6000BA0")]
		[Address(RVA = "0x3EC7DD0", Offset = "0x3EC7DD0", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnParticleAbsorbed (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnParticleAbsorbed;\n\tgoto L_002C;\n")]
		public void add_OnParticleAbsorbed(Action value)
		{
			Action action = OnParticleAbsorbed;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref OnParticleAbsorbed, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6000BA1")]
		[Address(RVA = "0x3EC7E74", Offset = "0x3EC7E74", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnParticleAbsorbed (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnParticleAbsorbed;\n\tgoto L_002C;\n")]
		public void remove_OnParticleAbsorbed(Action value)
		{
			Action action = OnParticleAbsorbed;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref OnParticleAbsorbed, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6000BA2")]
		[Address(RVA = "0x3EC7F18", Offset = "0x3EC7F18", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Combine(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<System.Int32>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnEntityVisualComplete;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnEntityVisualComplete (System.Action`1<System.Int32>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void add_OnEntityVisualComplete(Action<int> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionBridge::add_OnEntityVisualComplete");
		}

		[CompilerGenerated]
		[Token(Token = "0x6000BA3")]
		[Address(RVA = "0x3EC7FCC", Offset = "0x3EC7FCC", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Remove(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<System.Int32>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnEntityVisualComplete;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnEntityVisualComplete (System.Action`1<System.Int32>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void remove_OnEntityVisualComplete(Action<int> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionBridge::remove_OnEntityVisualComplete");
		}

		[CompilerGenerated]
		[Token(Token = "0x6000BA4")]
		[Address(RVA = "0x3EC8080", Offset = "0x3EC8080", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Combine(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`2<System.Int32, System.Int32>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnMoldVisualComplete;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnMoldVisualComplete (System.Action`2<System.Int32, System.Int32>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void add_OnMoldVisualComplete(Action<int, int> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionBridge::add_OnMoldVisualComplete");
		}

		[CompilerGenerated]
		[Token(Token = "0x6000BA5")]
		[Address(RVA = "0x3EC8134", Offset = "0x3EC8134", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Remove(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`2<System.Int32, System.Int32>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnMoldVisualComplete;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnMoldVisualComplete (System.Action`2<System.Int32, System.Int32>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void remove_OnMoldVisualComplete(Action<int, int> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionBridge::remove_OnMoldVisualComplete");
		}

		[Token(Token = "0x6000BA8")]
		[Address(RVA = "0x3EC820C", Offset = "0x3EC820C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.New.SwitchSystem.RefCountedLock::Acquire(this._absorptionLock);\n\treturn returnVal1;\n")]
		public LockHandle LockAbsorption()
		{
			return _absorptionLock.Acquire();
		}

		[Inject(false)]
		[Token(Token = "0x6000BAC")]
		[Address(RVA = "0x3EC8664", Offset = "0x3EC8664", Length = "0x2A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\t_game.CoreSystem.New.MoldSystem.Core.Conditions.ColorMatchCondition::.ctor(v64);\n\tgoto L_005F;\nL_005F:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.MoldSystem.Core.Conditions.IClaimCondition>::Add(v54, v64);\n\tv141 = new _game.CoreSystem.New.MoldSystem.Core.Conditions.NotDataCompleteCondition();\n\t_game.CoreSystem.New.MoldSystem.Core.Conditions.NotDataCompleteCondition::.ctor(v141);\n\tgoto L_0088;\nL_0088:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.MoldSystem.Core.Conditions.IClaimCondition>::Add(v54, v141);\n\tv142 = new _game.CoreSystem.New.MoldSystem.Core.Conditions.NotLinkBlockedCondition();\n\t_game.CoreSystem.New.MoldSystem.Core.Conditions.NotLinkBlockedCondition::.ctor(v142, this._em);\n\tgoto L_00B3;\nL_00B3:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.MoldSystem.Core.Conditions.IClaimCondition>::Add(v54, v142);\n\tv266 = new _game.CoreSystem.New.MoldSystem.Core.Conditions.MoldClaimValidator();\n\t_game.CoreSystem.New.MoldSystem.Core.Conditions.MoldClaimValidator::.ctor(v266, v54);\n\tthis._normalValidator = v266;\n\tgoto L_00CE;\nL_002F:\n\tv54 = new System.Collections.Generic.List`1<_game.CoreSystem.New.MoldSystem.Core.Conditions.IClaimCondition>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.MoldSystem.Core.Conditions.IClaimCondition>::.ctor(v54);\n\tv64 = new _game.CoreSystem.New.MoldSystem.Core.Conditions.ColorMatchCondition();\nL_00CE:\n\tv285.<Instance>k__BackingField = this;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Construct()
		{
			List<IClaimCondition> list = new List<IClaimCondition>();
			ColorMatchCondition item = new ColorMatchCondition();
			list.Add(item);
			NotDataCompleteCondition item2 = new NotDataCompleteCondition();
			list.Add(item2);
			NotLinkBlockedCondition item3 = new NotLinkBlockedCondition(_em);
			list.Add(item3);
			MoldClaimValidator normalValidator = new MoldClaimValidator(list);
			_normalValidator = normalValidator;
			Instance = this;
		}

		[Token(Token = "0x6000BAD")]
		[Address(RVA = "0x3EC8904", Offset = "0x3EC8904", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = _game.CoreSystem.New.MoldSystem.MoldQueryHelper::GetActiveEntityInColumn(this._em, column);\n\tv21 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v13);\n\tv40 = v21 == 0;\n\tv45 = ~v40;\n\tv46 = ~v45;\n\tif (v46) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal2 = v13;\n\tgoto L_0025;\nL_FFFFFFFF:\n\treturnVal2 = -1;\nL_0025:\n\treturn returnVal2;\n")]
		public int GetActiveEntityId(int column)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionBridge::GetActiveEntityId");
			return default;
		}

		[Token(Token = "0x6000BAE")]
		[Address(RVA = "0x3EC8CE8", Offset = "0x3EC8CE8", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetEntityByIndex(this._em, entityIndex);\n\tv39 = v15 >> 0x20;\n\tv41 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v15);\n\tv65 = v41 == 0;\n\tv50 = ~v65;\n\tv47 = ~v50;\n\tif (v47) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal2 = v39;\n\tgoto L_0028;\nL_FFFFFFFF:\n\treturnVal2 = 0;\nL_0028:\n\treturn returnVal2;\n")]
		public int GetEntityGeneration(int entityIndex)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionBridge::GetEntityGeneration");
			return default;
		}

		[Token(Token = "0x6000BAF")]
		[Address(RVA = "0x3EC8D38", Offset = "0x3EC8D38", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\tv49 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetEntityByIndex(this._em, v40);\n\tv63 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v49);\n\tv86 = ~v63;\n\treturnVal2 = v63;\n\tif (v86) goto L_0035;\n\tv93 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v49);\n\treturnVal2 = v93 - v93.dataFill;\nL_0035:\n\treturn returnVal2;\n")]
		public int GetEntityRemainingNeed(int entityId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionBridge::GetEntityRemainingNeed");
			return default;
		}

		[Token(Token = "0x6000BB0")]
		[Address(RVA = "0x3EC8DD8", Offset = "0x3EC8DD8", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\tv49 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetEntityByIndex(this._em, v40);\n\treturnVal2 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v49);\n\tv80 = returnVal2 == 0;\n\tif (v80) goto L_003B;\n\treturnVal3 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v49);\n\treturn returnVal3;\nL_003B:\n\treturn returnVal2;\n")]
		public GameColor GetEntityColor(int entityId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionBridge::GetEntityColor");
			return default;
		}

		[Token(Token = "0x6000BB1")]
		[Address(RVA = "0x3EC8E7C", Offset = "0x3EC8E7C", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = _game.CoreSystem.New.MoldSystem.MoldQueryHelper::GetActiveEntityInColumn(this._em, column);\n\tv26 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v19);\n\tv56 = v26 == 0;\n\tv41 = ~v56;\n\tv38 = ~v41;\n\tif (v38) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv122 = v19;\n\tgoto L_0023;\nL_FFFFFFFF:\n\tv122 = -1;\n\treturnVal2 = _game.CoreSystem.New.MoldSystem.MoldAbsorptionBridge::GetEntityPourPointWorld(this, v122);\n\treturn returnVal2;\nL_0039:\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v32 @ stack_-40_v3 (_game.CoreSystem.New.GridEcsBinding.GridCoord), column, 0);\n\treturnVal3 = _game.CoreSystem.New.MoldSystem.Visual.MoldVisualGridController::GridToWorld(this._visualGrid, v32);\n\treturn returnVal3;\nL_0023:\n\tv141 = v122 & 0x80000000;\n\tv142 = v141 == 0;\n\tv125 = ~v142;\n\tif (v125) goto L_0039;\n")]
		public float2 GetPourPointWorld(int column)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionBridge::GetPourPointWorld");
			return default;
		}

		[Token(Token = "0x6000BB2")]
		[Address(RVA = "0x3EC913C", Offset = "0x3EC913C", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v15 @ stack_-30_v2 (_game.CoreSystem.New.GridEcsBinding.GridCoord), column, 0);\n\treturnVal1 = _game.CoreSystem.New.MoldSystem.Visual.MoldVisualGridController::GridToWorld(this._visualGrid, v15);\n\treturn returnVal1;\n")]
		public float2 GetColumnRow0World(int column)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionBridge::GetColumnRow0World");
			return default;
		}

		[Token(Token = "0x6000BB3")]
		[Address(RVA = "0x3EC9238", Offset = "0x3EC9238", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\tv49 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetEntityByIndex(this._em, v40);\n\tv63 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v49);\n\tv86 = ~v63;\n\treturnVal2 = v63;\n\tif (v86) goto L_0034;\n\tv92 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v49);\n\treturnVal2 = v92 >> 0x20;\nL_0034:\n\treturn returnVal2;\n")]
		public int GetEntityAnchorRow(int entityId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionBridge::GetEntityAnchorRow");
			return default;
		}

		[Token(Token = "0x6000BB4")]
		[Address(RVA = "0x3EC92D4", Offset = "0x3EC92D4", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\tv49 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetEntityByIndex(this._em, v40);\n\tv63 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v49);\n\tv86 = ~v63;\n\treturnVal2 = v63;\n\tif (v86) goto L_0033;\n\tv89 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v49);\n\treturnVal2 = v89;\nL_0033:\n\treturn returnVal2;\n")]
		public int GetEntityAnchorCol(int entityId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionBridge::GetEntityAnchorCol");
			return default;
		}

		[Token(Token = "0x6000BB5")]
		[Address(RVA = "0x3EC936C", Offset = "0x3EC936C", Length = "0x4C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv72 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv156 = v72 == 0;\nL_FFFFFFFF:\n\tv150 = Il2CppMethodInfo;\n\tif (v156) goto L_019C;\n\tv171 = *([v72 @ X0_v23 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv304 = *([v171 @ X8_v19 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv173 = *([v171 @ X8_v19 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v173) goto L_0062;\n\tv303 = *([v171 @ X8_v19 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv303 = v303 + 0x10;\n\tv212 = v304 - 1;\n\tv192 = v304 != 1;\nL_FFFFFFFF:\n\tv304 = v212;\n\tif (v192) goto L_004D;\nL_0062:\n\tv215 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(v72, System.Collections.Generic.IEnumerable`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\n\tv215.capacity(v365, v72, v215.visualFill, 0, pourPointsZ, v48, fillRatios, v49, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv323 = v365 == 0;\n\tv324 = ~v323;\nL_FFFFFFFF:\n\tv348 = v365;\nL_FFFFFFFF:\n\tv248 = &v348 @ stack_-78_v7 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv112 = 0;\n\tif (v324) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv453 = &v348 @ stack_-78_v7 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv112 = 0;\n\tgoto L_0190;\nL_0071:\n\tv335 = *([v303 @ X10_v30]) << 4;\n\tv336 = v171 + v335;\n\tv337 = v336 + 0x138;\n\tv481 = *([v337 @ X8_v51+8]);\n\t*([v337 @ X8_v51])(v365, v72, *([v337 @ X8_v51+8]), v35, pourPointsZ, v48, fillRatios, v49, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv345 = v365 == 0;\nL_FFFFFFFF:\n\tv348 = v365;\nL_FFFFFFFF:\n\tv248 = &v348 @ stack_-78_v7 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv112 = 0;\nL_FFFFFFFF:\n\tv453 = &v348 @ stack_-78_v7 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv112 = 0;\n\tif (v345) goto L_0190;\nL_FFFFFFFF:\n\tv392 = v365;\n\tgoto L_00C8;\nL_008B:\n\tv836 = v828 / v849;\n\tv921 = v836 & 0x7FFFFFFF;\n\tv924 = v921 < 0x7F800001;\n\tv925 = ~v924;\n\tv933 = ~v925;\n\tv934 = ~v933;\n\tif (v934) goto L_FFFFFFFF;\n\tv960 = v836 < 1f;\n\tv959 = v836 == 1f;\n\tv950 = v836 == v836;\n\tv951 = 1f == 1f;\n\tv952 = v950 & v951;\n\tv958 = ~v952;\n\tgoto L_00AA;\nL_FFFFFFFF:\n\tv958 = 0;\nL_FFFFFFFF:\n\tv959 = 0;\nL_FFFFFFFF:\n\tv960 = 0;\n\tgoto L_00B3;\nL_FFFFFFFF:\n\tv836 = 1f;\nL_FFFFFFFF:\n\tv836 = 0;\n\tgoto L_00C0;\nL_00C8:\n\tgoto L_00EE;\n\tv687 = v348 == 0;\n\tif (v687) goto L_0192;\n\tgoto L_011F;\n\tv665 = v828 >= v35;\nL_FFFFFFFF:\n\tv481 = 0;\n\tif (v665) goto L_00C2;\n\tv858 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v828);\n\tgoto L_013D;\nL_013D:\n\tv850 = UnityEngine.Object::op_Equality(v858, 0);\n\tv866 = v850 == 0;\n\tv853 = ~v866;\nL_FFFFFFFF:\n\tv481 = 0;\n\tif (v853) goto L_00C2;\n\tv688 = v858 == 0;\n\tif (v688) goto L_0194;\n\tv869 = UnityEngine.Component::GetComponent(v858);\n\tv870 = v869 == 0;\n\tif (v870) goto L_FFFFFFFF;\n\tv875 = _game.CoreSystem.MoldSystem.MoldMonoBase::get_PourPoint(v869);\nL_FFFFFFFF:\n\tv653 = v875;\n\tgoto L_0160;\nL_FFFFFFFF:\n\tv653 = 0;\n\tgoto L_0160;\nL_0160:\n\tv851 = UnityEngine.Object::op_Equality(v653, 0);\n\tv898 = v851 == 0;\n\tv854 = ~v898;\nL_FFFFFFFF:\n\tv481 = 0;\n\tif (v854) goto L_00C2;\n\tv900 = _game.CoreSystem.MoldSystem.MoldMonoBase::get_PourPoint(v869);\n\tv690 = v900 == 0;\n\tif (v690) goto L_0198;\n\tv658 = UnityEngine.Transform::get_position(v900);\n\tv656 = v828 & 0x7FFFFFFF;\n\tv660 = v656 << 3;\n\tv901 = pourPoints + v660;\n\t*([v901 @ X8_v34]) = v658;\n\t*([v901 @ X8_v34+4]) = v658.y;\n\t*([pourPointsZ @ X3 (Unity.Collections.NativeArray`1<System.Single>)+v656 @ X25_v11 (System.Int32)*4]) = v658.z;\n\tv689 = this._em == 0;\n\tif (v689) goto L_0196;\n\tv849 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v828);\n\tv915 = v849 > 0;\n\tif (v915) goto L_008B;\nL_FFFFFFFF:\n\tv836 = 0;\n\tgoto L_00C0;\nL_0190:\n\tv490 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv150 = 0;\n\tgoto L_019B;\nL_0192:\n\tv682 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv248 = v453;\nL_FFFFFFFF:\n\tv150 = v481;\n\tgoto L_019B;\nL_0194:\n\tv683 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv150 = 0;\n\tgoto L_019B;\nL_0196:\n\tv684 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv150 = 0;\n\tgoto L_019B;\nL_0198:\n\tv685 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv150 = 0;\n\tgoto L_019B;\nL_019B:\n\t// 411 Interrupt\nL_01B7:\n\tv183 = v150 != 1;\n\tif (v183) goto L_0205;\n\tv216 = 0x8BF5BC4(v161, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv327 = 0x8BF5BF4(v216, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv112 = *([v216 @ X0_v5]);\nL_01BF:\n\tv425 = *([v248 @ stack_-80_v3]) == 0;\n\tif (v425) goto L_01EF;\n\tgoto L_01ED;\n\treturn;\nL_0202:\n\tv280 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv161 = v280;\nL_0205:\n\tv289 = 0x3175484(&v112 @ stack_-88 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv329 = 0x8BF0368(v161, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv426 = 0xA1B8(v329, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0035:\n\tv348 = 0;\n\tv65 = this._em == 0;\nL_FFFFFFFF:\n\tv150 = pourPoints;\n\tif (v65) goto L_019C;\nL_019C:\n\tv161 = new System.NullReferenceException();\n\tgoto L_01B7;\nL_004D:\n\tv309 = *([v303 @ X10_v30-8]) == System.Collections.Generic.IEnumerable`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v309) goto L_0071;\nL_00AA:\n\tv963 = v960 == v958;\n\tv964 = ~v963;\n\tv938 = v964 | v959;\n\tv965 = ~v938;\n\tif (v965) goto L_FFFFFFFF;\nL_00B3:\n\tv942 = v836 < 0;\n\tv935 = ~v942;\n\tif (v935) goto L_00C0;\nL_00EE:\n\tv418 = System.Collections.IEnumerator::MoveNext(v392);\n\tv420 = v418 == 0;\n\tif (v420) goto L_01BF;\nL_011F:\n\tv828 = System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Current(v348);\n\tv829 = v828 & 0x80000000;\n\tv830 = v829 == 0;\n\tv831 = ~v830;\nL_FFFFFFFF:\n\tv481 = 0;\n\tif (v831) goto L_00C2;\nL_00C2:\n\tv486 = v348 == 0;\nL_FFFFFFFF:\n\tv392 = v348;\nL_FFFFFFFF:\n\tv453 = v248;\n\tif (v486) goto L_0190;\nL_00C0:\n\t*([fillRatios @ X5 (Unity.Collections.NativeArray`1<System.Single>)+v656 @ X25_v11 (System.Int32)*4]) = v836;\nL_FFFFFFFF:\n\tv481 = v828;\nL_01EF:\n\tv539 = v112 == 0;\n\tv282 = ~v539;\n\tif (v282) goto L_0202;\nL_01ED:\n\tSystem.IDisposable::Dispose(*([v248 @ stack_-80_v3]));\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PopulateEntityArrays(NativeArray<float2> pourPoints, NativeArray<float> pourPointsZ, NativeArray<float> fillRatios)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionBridge::PopulateEntityArrays");
		}

		[Token(Token = "0x6000BB6")]
		[Address(RVA = "0x3EC9834", Offset = "0x3EC9834", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = _game.CoreSystem.New.MoldSystem.MoldQueryHelper::GetActiveEntityInColumn(this._em, column);\n\treturnVal2 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v21);\n\tv56 = ~returnVal2;\n\tif (v56) goto L_002E;\n\treturnVal2 = _game.CoreSystem.New.MoldSystem.Core.Conditions.MoldClaimValidator::CanClaim(this._normalValidator, this._em, v21, color);\n\tv62 = ~returnVal2;\n\tif (v62) goto L_002E;\n\t_game.CoreSystem.New.MoldSystem.Core.Handlers.MoldFillHandler::ClaimSlot(this._fillHandler, v21);\n\treturnVal2 = 1;\nL_002E:\n\treturn returnVal2;\n")]
		public bool TryClaim(GameColor color, int column)
		{
			Entity activeEntityInColumn = MoldQueryHelper.GetActiveEntityInColumn(_em, column);
			bool flag = _em.IsValid(activeEntityInColumn);
			if (flag)
			{
				flag = _normalValidator.CanClaim(_em, activeEntityInColumn, color);
				if (flag)
				{
					_fillHandler.ClaimSlot(activeEntityInColumn);
					flag = true;
				}
			}
			return flag;
		}

		[Token(Token = "0x6000BB7")]
		[Address(RVA = "0x3EC98C0", Offset = "0x3EC98C0", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0024:\n\tv54 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetEntityByIndex(this._em, v41);\n\treturnVal2 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v54);\n\tv173 = ~returnVal2;\n\tif (v173) goto L_006F;\n\treturnVal2 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v54);\n\tv179 = ~returnVal2;\n\tif (v179) goto L_006F;\n\tv183 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v54);\n\tv57 = v183 != color;\n\tif (v57) goto L_0078;\n\treturnVal2 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v54);\n\tv180 = ~returnVal2;\n\tif (v180) goto L_006F;\n\tv186 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v54);\n\tv190 = v54 & 0x100000000;\n\tv191 = v190 == 0;\n\tv187 = ~v191;\n\tif (v187) goto L_0078;\n\t_game.CoreSystem.New.MoldSystem.Core.Handlers.MoldFillHandler::ClaimSlot(this._fillHandler, v54);\n\treturnVal2 = 1;\nL_0078:\n\treturn 0;\nL_006F:\n\treturn returnVal2;\n")]
		public bool ClaimSlotForcePour(int entityId, GameColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionBridge::ClaimSlotForcePour");
			return default;
		}

		[Token(Token = "0x6000BB8")]
		[Address(RVA = "0x3EC9A14", Offset = "0x3EC9A14", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal2 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, entity);\n\tv54 = ~returnVal2;\n\tif (v54) goto L_002A;\n\treturnVal2 = _game.CoreSystem.New.MoldSystem.Core.Conditions.MoldClaimValidator::CanClaim(this._normalValidator, this._em, entity, color);\n\tv62 = ~returnVal2;\n\tif (v62) goto L_002A;\n\t_game.CoreSystem.New.MoldSystem.Core.Handlers.MoldFillHandler::ClaimSlot(this._fillHandler, entity);\n\treturnVal2 = 1;\nL_002A:\n\treturn returnVal2;\n")]
		public bool TryClaimEntity(Entity entity, GameColor color)
		{
			bool flag = _em.IsValid(entity);
			if (flag)
			{
				flag = _normalValidator.CanClaim(_em, entity, color);
				if (flag)
				{
					_fillHandler.ClaimSlot(entity);
					flag = true;
				}
			}
			return flag;
		}

		[Token(Token = "0x6000BB9")]
		[Address(RVA = "0x3EC9A90", Offset = "0x3EC9A90", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal2 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, entity);\n\tv45 = ~returnVal2;\n\tif (v45) goto L_0029;\n\treturnVal3 = _game.CoreSystem.New.MoldSystem.Core.Conditions.MoldClaimValidator::CanClaim(this._normalValidator, this._em, entity, color);\n\treturn returnVal3;\nL_0029:\n\treturn returnVal2;\n")]
		public bool CanClaimEntity(Entity entity, GameColor color)
		{
			bool flag = _em.IsValid(entity);
			if (flag)
			{
				return _normalValidator.CanClaim(_em, entity, color);
			}
			return flag;
		}

		[Token(Token = "0x6000BBA")]
		[Address(RVA = "0x3EC9AFC", Offset = "0x3EC9AFC", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_0025:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityId::.ctor(&v58 @ stack_-48_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityId), entityIndex, entityGeneration);\n\tv66 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::EntityExists(this._em, v58);\n\tv80 = ~v66;\n\tif (v80) goto L_0057;\n\tv125 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetEntity(this._em, v58);\n\tv127 = _game.CoreSystem.New.MoldSystem.Core.Handlers.MoldFillHandler::Fill(this._fillHandler, v125);\n\tv128 = this.OnParticleAbsorbed == 0;\n\tif (v128) goto L_0043;\n\tSystem.Action::Invoke(this.OnParticleAbsorbed);\n\tv95 = this.OnEntityVisualComplete == 0;\n\tif (v95) goto L_0057;\n\tSystem.Action`1<System.Int32>::Invoke(this.OnEntityVisualComplete, v125);\nL_001F:\n\tgoto L_0025;\nL_0057:\n\treturn;\nL_0043:\n\tv133 = v127 & 1;\n\tv96 = v133 == 0;\n\tif (v96) goto L_0057;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnParticleArrived(int entityIndex, int entityGeneration)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionBridge::OnParticleArrived");
		}

		[Token(Token = "0x6000BBB")]
		[Address(RVA = "0x3EC9C0C", Offset = "0x3EC9C0C", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tgoto L_0027;\nL_0027:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityId::.ctor(&v63 @ stack_-38_v3 (_game.BaseLayerSystems.EntitySystem.Core.EntityId), entityIndex, entityGeneration);\n\tv66 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::EntityExists(this._em, v63);\n\tv69 = ~v66;\n\tif (v69) goto L_0043;\n\tv107 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetEntity(this._em, v63);\n\tv65 = _game.CoreSystem.New.MoldSystem.Core.Handlers.MoldFillHandler::ReleaseSlot(this._fillHandler, v107);\nL_0043:\n\treturn;\nL_0017:\n\tv45 = entityIndex & 0x80000000;\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tif (v47) goto L_0043;\n")]
		public void OnParticleCancelled(int entityIndex, int entityGeneration)
		{
			//IL_008f: Expected I4, but got I8
			if ((int)(entityIndex & 0x80000000L) == 0)
			{
				EntityId id = new EntityId(entityIndex, entityGeneration);
				if (_em.EntityExists(id))
				{
					Entity entity = _em.GetEntity(id);
					bool flag = _fillHandler.ReleaseSlot(entity);
				}
			}
		}

		[Token(Token = "0x6000BBC")]
		[Address(RVA = "0x3EC9CD8", Offset = "0x3EC9CD8", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.OnMoldVisualComplete == 0;\n\tif (v2) goto L_0007;\n\tSystem.Action`2<System.Int32, System.Int32>::Invoke(this.OnMoldVisualComplete, entityId, column);\n\treturn;\nL_0007:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnCompleteAnimFinished(int entityId, int column)
		{
			if (OnMoldVisualComplete != null)
			{
				OnMoldVisualComplete(entityId, column);
			}
		}

		[Token(Token = "0x6000BBD")]
		[Address(RVA = "0x3EC9CF4", Offset = "0x3EC9CF4", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tgoto L_0030;\nL_0035:\n\tthis.OnParticleAbsorbed = 0;\n\tthis.OnEntityVisualComplete = 0;\n\tthis.OnMoldVisualComplete = 0;\n\treturn;\nL_0022:\n\tv56 = v45.<Instance>k__BackingField != this;\n\tif (v56) goto L_0035;\nL_0030:\n\tv76.<Instance>k__BackingField = 0;\n")]
		public void Dispose()
		{
			if (Instance == this)
			{
				Instance = null;
			}
			OnParticleAbsorbed = null;
			OnEntityVisualComplete = null;
			OnMoldVisualComplete = null;
		}

		[Token(Token = "0x6000BBE")]
		[Address(RVA = "0x3EC8F2C", Offset = "0x3EC8F2C", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tv54 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetEntityByIndex(this._em, entityId);\n\tv107 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v54);\n\tv109 = v107 == 0;\n\tif (v109) goto L_0082;\n\tv152 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v54);\n\tv156 = v152 == 0;\n\tif (v156) goto L_FFFFFFFF;\n\tv164 = UnityEngine.Component::GetComponent(v152);\n\tv173 = v164 == 0;\n\tif (v173) goto L_FFFFFFFF;\n\tv180 = _game.CoreSystem.MoldSystem.MoldMonoBase::get_PourPoint(v164);\nL_FFFFFFFF:\n\tv195 = v180;\nL_FFFFFFFF:\n\tv94 = v164;\n\tgoto L_0051;\nL_FFFFFFFF:\n\tv195 = v152;\nL_FFFFFFFF:\n\tv94 = 0;\n\tgoto L_0051;\n\tv79 = _game.CoreSystem.MoldSystem.MoldMonoBase::get_PourPoint(v94);\n\tv62 = UnityEngine.Transform::get_position(v79);\n\tv80 = _game.CoreSystem.MoldSystem.MoldMonoBase::get_PourPoint(v94);\n\tv252 = UnityEngine.Transform::get_position(v80);\n\treturn v62;\nL_FFFFFFFF:\n\tv195 = v164;\nL_FFFFFFFF:\n\tv94 = v164;\n\tgoto L_0051;\nL_0082:\n\tv113 = entityId;\n\tv115 = 0xB7D5000 + 0x538;\n\tv118 = \"il2cpp_vm_object_box\"(*([v115 @ X8_v6 (System.Int32)+48]), &v113 @ stack_-44_v2 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv137 = 0xB2F7000 + 0xF78;\nL_FFFFFFFF:\n\tv145 = v118;\n\tgoto L_0098;\nL_008C:\n\tv124 = entityId;\n\tv142 = 0xB7D5000 + 0x538;\n\tv213 = \"il2cpp_vm_object_box\"(*([v142 @ X8_v10 (System.Int32)+48]), &v124 @ stack_-48_v2 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv137 = 0xB2F7000 + 0xF70;\nL_FFFFFFFF:\n\tv145 = v213;\n\tv171 = new v159();\n\tSystem.InvalidOperationException::.ctor(v171, v155);\n\tthrow v171;\nL_0051:\n\tv78 = UnityEngine.Object::op_Equality(v195, 0);\n\tv206 = ~v78;\n\tv140 = ~v206;\n\tif (v140) goto L_008C;\nL_0098:\n\tv155 = System.String::Format(v137, v145);\n\tv159 = 0xB290000 + 0xB18;\n")]
		public float2 GetEntityPourPointWorld(int entityId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionBridge::GetEntityPourPointWorld");
			return default;
		}

		[Token(Token = "0x6000BBF")]
		[Address(RVA = "0x3EC9DB0", Offset = "0x3EC9DB0", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_0017:\n\tv45 = new _game.CoreSystem.New.SwitchSystem.RefCountedLock();\n\t_game.CoreSystem.New.SwitchSystem.RefCountedLock::.ctor(v45);\n\tthis._absorptionLock = v45;\n")]
		public MoldAbsorptionBridge()
		{
			RefCountedLock absorptionLock = new RefCountedLock();
			_absorptionLock = absorptionLock;
		}
	}
}
