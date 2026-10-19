using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.BaseLayerSystems.EntitySystem.Core
{
	[Token(Token = "0x200007C")]
	public class MonoBindingManager : IDisposable
	{
		[CompilerGenerated]
		[Token(Token = "0x200007D")]
		private sealed class _003CGetBoundEntities_003Ed__17 : IEnumerable<Entity>, IEnumerable, IEnumerator<Entity>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400013B")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x400013C")]
			[FieldOffset(Offset = "0x14")]
			private Entity _003C_003E2__current;

			[Token(Token = "0x400013D")]
			[FieldOffset(Offset = "0x1C")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x400013E")]
			[FieldOffset(Offset = "0x20")]
			public MonoBindingManager _003C_003E4__this;

			[Token(Token = "0x400013F")]
			[FieldOffset(Offset = "0x28")]
			private Dictionary<EntityId, EntityMono>.KeyCollection.Enumerator _003C_003E7__wrap1;

			[Token(Token = "0x1700004E")]
			Entity IEnumerator<Entity>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000228")]
				[Address(RVA = "0x3C74E90", Offset = "0x3C74E90", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700004F")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600022A")]
				[Address(RVA = "0x3C74ED8", Offset = "0x3C74ED8", Length = "0x68")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tv45 = this.<>2__current;\n\t// 26 Box returnVal1 @ X0_v3 (System.Object), typeof(_game.BaseLayerSystems.EntitySystem.Core.Entity), &v45 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity)\n\treturn returnVal1;\n")]
				get
				{
					Entity entity = _003C_003E2__current;
					return entity;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000224")]
			[Address(RVA = "0x3C748E0", Offset = "0x3C748E0", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n")]
			public _003CGetBoundEntities_003Ed__17(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000225")]
			[Address(RVA = "0x3C74BBC", Offset = "0x3C74BBC", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = v76.<>1__state - 1;\n\tv6 = v4 == 0;\n\tv11 = ~v6;\n\tv12 = ~v11;\n\tif (v12) goto L_FFFFFFFF;\n\tv15 = v76.<>1__state - -3;\n\tv30 = v15 == 0;\n\tgoto L_001C;\nL_FFFFFFFF:\n\tv30 = 1;\n\tgoto L_0037;\nL_0043:\n\treturn;\nL_001C:\n\tv34 = ~v30;\n\tif (v34) goto L_0043;\nL_0037:\n\tv76.<>1__state = -1;\n\tv83 = v76 + 0x28;\n\tSystem.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>+KeyCollection<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>+Enumerator<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>::Dispose(v83);\n\treturn;\n")]
			unsafe void IDisposable.Dispose()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MonoBindingManager._003CGetBoundEntities_003Ed__17::Dispose");
			}

			[Token(Token = "0x6000226")]
			[Address(RVA = "0x3C74C34", Offset = "0x3C74C34", Length = "0x200")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv57 = this.<>1__state == 0;\n\tv58 = ~v57;\nL_FFFFFFFF:\n\tv110 = 0;\n\tif (v58) goto L_FFFFFFFF;\n\tv107 = this.<>4__this;\n\tthis.<>1__state = -1;\n\tv109 = this.<>4__this == 0;\n\tif (v109) goto L_0079;\n\tv149 = v107._bindings == 0;\n\tif (v149) goto L_007B;\n\tv194 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>::get_Keys(v107._bindings);\n\tv275 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>+KeyCollection<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>::GetEnumerator(v194);\n\t*([v275 @ X0_v34 (System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>+KeyCollection<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>+Enumerator<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>)+28]) = v275._dictionary;\n\t*([v275 @ X0_v34 (System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>+KeyCollection<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>+Enumerator<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>)+38]) = v275._currentKey;\nL_FFFFFFFF:\n\tv96 = v275;\n\t*([v41 @ stack_-28_v2+14]) = *([v41 @ stack_-28_v2+38]);\n\t*([v41 @ stack_-28_v2+10]) = 1;\nL_FFFFFFFF:\n\tv110 = 0;\nL_FFFFFFFF:\n\treturnVal1 = 1;\n\tgoto L_0098;\nL_0066:\n\tgoto L_006F;\nL_0079:\n\tv150 = new System.NullReferenceException();\n\tgoto L_007E;\nL_007B:\n\tv195 = new System.NullReferenceException();\n\tgoto L_007E;\nL_007E:\n\t// 126 Interrupt\n\tgoto L_008F;\nL_008F:\n\tv113 = Il2CppMethodInfo != 1;\nL_FFFFFFFF:\n\tv110 = 0;\nL_FFFFFFFF:\n\tv267 = v150;\n\tif (v113) goto L_00A8;\n\tv280 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>::get_Keys(v150);\n\tv135 = 0x8BF5BF4(v280, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv110 = *([v280 @ X0_v27 (System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>+KeyCollection<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>)]);\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\treturn returnVal1;\nL_00A1:\n\tv200 = &v41 @ stack_-28_v2;\n\tv202 = 0x317A23C(*([v200 @ X8_v18]), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv270 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv267 = v270;\n\treturn returnVal2;\nL_0024:\n\tv49 = this.<>1__state == 1;\nL_FFFFFFFF:\n\tv96 = this;\n\tif (v49) goto L_0052;\nL_0098:\n\tv186 = v110 == 0;\n\tv187 = ~v186;\n\tif (v187) goto L_00A1;\nL_006F:\n\t*([v41 @ stack_-28_v2+10]) = -1;\n\tv211 = v41 + 0x28;\n\tSystem.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>+KeyCollection<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>+Enumerator<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>::Dispose(v211);\n\t*([v41 @ stack_-28_v2+30]) = 0;\n\t*([v41 @ stack_-28_v2+38]) = 0;\n\t*([v41 @ stack_-28_v2+28]) = 0;\nL_FFFFFFFF:\n\tv110 = 0;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_0098;\nL_00A8:\n\tv283 = 0x317A040(&v110 @ stack_-38_v4 (Il2CppClass<System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>+KeyCollection<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>>), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv285 = 0x8BF0368(v267, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = 0xA1B8(v285, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0052:\n\tv96.<>1__state = -3;\n\tv102 = v96 + 0x28;\n\tv103 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>+KeyCollection<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>+Enumerator<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>::MoveNext(v102);\n\tv145 = v103 == 0;\n\tif (v145) goto L_0066;\n")]
			private unsafe bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MonoBindingManager._003CGetBoundEntities_003Ed__17::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[Token(Token = "0x6000227")]
			[Address(RVA = "0x3C74E34", Offset = "0x3C74E34", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tthis.<>1__state = -1;\n\tv46 = this + 0x28;\n\tSystem.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>+KeyCollection<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>+Enumerator<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>::Dispose(v46);\n\treturn;\n")]
			private unsafe void _003C_003Em__Finally1()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MonoBindingManager._003CGetBoundEntities_003Ed__17::_003C_003Em__Finally1");
			}

			[DebuggerHidden]
			[Token(Token = "0x6000229")]
			[Address(RVA = "0x3C74E98", Offset = "0x3C74E98", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}

			[DebuggerHidden]
			[Token(Token = "0x600022B")]
			[Address(RVA = "0x3C74F40", Offset = "0x3C74F40", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv52 = System.Environment::get_CurrentManagedThreadId();\n\tv54 = this.<>l__initialThreadId != v52;\n\tif (v54) goto L_0038;\n\tthis.<>1__state = 0;\n\treturn this;\nL_0038:\n\tv76 = new _game.BaseLayerSystems.EntitySystem.Core.MonoBindingManager+<GetBoundEntities>d__17();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv86 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v86;\n\tv76.<>4__this = this.<>4__this;\n\treturn v76;\nL_001D:\n\tv49 = this.<>1__state != -2;\n\tif (v49) goto L_0038;\n")]
			IEnumerator<Entity> IEnumerable<Entity>.GetEnumerator()
			{
				if (_003C_003E1__state == -2)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						return this;
					}
				}
				_003CGetBoundEntities_003Ed__17 _003CGetBoundEntities_003Ed__18 = (_003CGetBoundEntities_003Ed__17)FormatterServices.GetUninitializedObject(typeof(_003CGetBoundEntities_003Ed__17));
				_003CGetBoundEntities_003Ed__18._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003CGetBoundEntities_003Ed__18._003C_003El__initialThreadId = currentManagedThreadId2;
				_003CGetBoundEntities_003Ed__18._003C_003E4__this = _003C_003E4__this;
				return _003CGetBoundEntities_003Ed__18;
			}

			[DebuggerHidden]
			[Token(Token = "0x600022C")]
			[Address(RVA = "0x3C74FF4", Offset = "0x3C74FF4", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.BaseLayerSystems.EntitySystem.Core.MonoBindingManager+<GetBoundEntities>d__17::System.Collections.Generic.IEnumerable<_game.BaseLayerSystems.EntitySystem.Core.Entity>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Entity>)this).GetEnumerator();
			}
		}

		[Token(Token = "0x4000136")]
		[FieldOffset(Offset = "0x10")]
		internal readonly Dictionary<EntityId, EntityMono> _bindings;

		[Token(Token = "0x4000137")]
		[FieldOffset(Offset = "0x18")]
		private readonly EntityManager _entityManager;

		[Token(Token = "0x4000138")]
		[FieldOffset(Offset = "0x20")]
		private bool _isDisposed;

		[CompilerGenerated]
		[Token(Token = "0x4000139")]
		[FieldOffset(Offset = "0x28")]
		private Action<Entity, EntityMono> OnBindingCreated;

		[CompilerGenerated]
		[Token(Token = "0x400013A")]
		[FieldOffset(Offset = "0x30")]
		private Action<Entity> OnBindingRemoved;

		[CompilerGenerated]
		[Token(Token = "0x6000215")]
		[Address(RVA = "0x3C74500", Offset = "0x3C74500", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Combine(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.BaseLayerSystems.EntitySystem.EntityMono>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnBindingCreated;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnBindingCreated (System.Action`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.BaseLayerSystems.EntitySystem.EntityMono>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void add_OnBindingCreated(Action<Entity, EntityMono> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MonoBindingManager::add_OnBindingCreated");
		}

		[CompilerGenerated]
		[Token(Token = "0x6000216")]
		[Address(RVA = "0x3C745B4", Offset = "0x3C745B4", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Remove(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.BaseLayerSystems.EntitySystem.EntityMono>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnBindingCreated;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnBindingCreated (System.Action`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.BaseLayerSystems.EntitySystem.EntityMono>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void remove_OnBindingCreated(Action<Entity, EntityMono> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MonoBindingManager::remove_OnBindingCreated");
		}

		[CompilerGenerated]
		[Token(Token = "0x6000217")]
		[Address(RVA = "0x3C74668", Offset = "0x3C74668", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Combine(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnBindingRemoved;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnBindingRemoved (System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void add_OnBindingRemoved(Action<Entity> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MonoBindingManager::add_OnBindingRemoved");
		}

		[CompilerGenerated]
		[Token(Token = "0x6000218")]
		[Address(RVA = "0x3C7471C", Offset = "0x3C7471C", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Remove(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnBindingRemoved;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnBindingRemoved (System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void remove_OnBindingRemoved(Action<Entity> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MonoBindingManager::remove_OnBindingRemoved");
		}

		[Token(Token = "0x6000219")]
		[Address(RVA = "0x3C6F974", Offset = "0x3C6F974", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tSystem.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>::.ctor(v74);\n\tthis._bindings = v74;\n\tv83 = this._entityManager;\n\tv85 = new System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>();\n\tSystem.Action`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::.ctor(v85, this, Il2CppMethodInfo);\n\tv90 = this._entityManager == 0;\n\tif (v90) goto L_0081;\n\tgoto L_0052;\nL_FFFFFFFF:\n\tv132 = 0;\nL_0067:\n\tv146 = System.Delegate::Combine(v141, v85);\n\tv192 = v146 == 0;\n\tif (v192) goto L_FFFFFFFF;\n\tv196 = 0x21C11D0(v146, System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv199 = v196 == 0;\n\tv200 = ~v199;\nL_FFFFFFFF:\n\tv132 = v196;\n\tif (v200) goto L_0058;\n\tthrow System.InvalidCastException;\nL_0080:\n\treturn;\nL_0081:\n\tthrow v85;\nL_002C:\n\tSystem.Object::.ctor(this);\n\tthis._entityManager = entityManager;\n\tv74 = new System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>();\nL_0052:\n\tv103 = this._entityManager + 0x50;\nL_FFFFFFFF:\n\tv141 = v83.OnEntityDestroyed;\n\tgoto L_0067;\nL_0058:\n\tv134 = 0x220BDA0(v103, v132, v141, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv118 = v134 == v141;\nL_FFFFFFFF:\n\tv141 = v134;\n\tif (v118) goto L_0080;\n")]
		public MonoBindingManager(EntityManager entityManager)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MonoBindingManager::.ctor");
		}

		[Token(Token = "0x600021A")]
		[Address(RVA = "0x3C747D0", Offset = "0x3C747D0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.BaseLayerSystems.EntitySystem.Core.MonoBindingManager::Unbind(this, entity);\n\treturn;\n")]
		private void OnEntityDestroyed(Entity entity)
		{
			Unbind(entity);
		}

		[Token(Token = "0x600021B")]
		[Address(RVA = "0x3C70024", Offset = "0x3C70024", Length = "0x1F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tgoto L_001C;\nL_001C:\n\tv76 = 0xB28D000 + 0xE20;\n\tv62 = *([B78D6F1]) & 1;\n\tv63 = v62 == 0;\n\tif (v63) goto L_005A;\n\tv82 = *([v76 @ X22_v12 (System.Int32)]);\n\tv84 = *([v82 @ X0_v44+E4]) == 0;\n\tif (v84) goto L_006B;\nL_002D:\n\tv118 = entity >= 1;\n\tif (v118) goto L_0072;\nL_0038:\n\treturn;\nL_005A:\n\t*([B78D6F1]) = 1;\n\tv101 = *([v76 @ X22_v12 (System.Int32)]);\n\tv127 = *([v101 @ X0_v25+E4]) == 0;\n\tv104 = ~v127;\n\tif (v104) goto L_002D;\nL_006B:\n\tv142 = entity < 1;\n\tif (v142) goto L_0038;\nL_0072:\n\tgoto L_0076;\nL_0076:\n\tv169 = UnityEngine.Object::op_Equality(mono, 0);\n\tv254 = v169 == 0;\n\tv176 = ~v254;\n\tif (v176) goto L_0038;\n\tgoto L_008D;\nL_008D:\n\tv269 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>::TryGetValue(this._bindings, entity, &v174 @ stack_-48_v3 (_game.BaseLayerSystems.EntitySystem.EntityMono));\n\tv278 = ~v269;\n\tif (v278) goto L_009C;\n\t_game.BaseLayerSystems.EntitySystem.EntityMono::OnUnbind(v174);\nL_009C:\n\tSystem.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>::set_Item(this._bindings, entity, mono);\n\t_game.BaseLayerSystems.EntitySystem.EntityMono::OnBind(mono, entity);\n\tv178 = this.OnBindingCreated == 0;\n\tif (v178) goto L_0038;\n\tSystem.Action`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.BaseLayerSystems.EntitySystem.EntityMono>::Invoke(this.OnBindingCreated, entity, mono);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Bind(Entity entity, EntityMono mono)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MonoBindingManager::Bind");
		}

		[Token(Token = "0x600021C")]
		[Address(RVA = "0x3C70290", Offset = "0x3C70290", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv55 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>::TryGetValue(this._bindings, entity, &v53 @ stack_-38_v3 (_game.BaseLayerSystems.EntitySystem.EntityMono));\n\tv68 = ~v55;\n\tif (v68) goto L_003F;\n\t_game.BaseLayerSystems.EntitySystem.EntityMono::OnUnbind(v53);\n\tv80 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>::Remove(this._bindings, entity);\n\tv82 = this.OnBindingRemoved == 0;\n\tif (v82) goto L_003F;\n\tSystem.Action`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::Invoke(this.OnBindingRemoved, entity);\nL_003F:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Unbind(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MonoBindingManager::Unbind");
		}

		[Token(Token = "0x600021D")]
		[Address(RVA = "0x3C6FC60", Offset = "0x3C6FC60", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tv54 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>::TryGetValue(this._bindings, entity, &v53 @ stack_-38_v2 (_game.BaseLayerSystems.EntitySystem.EntityMono));\n\tv61 = v54 == 0;\n\tv66 = ~v61;\n\tv67 = ~v66;\n\tif (v67) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal2 = v53;\n\tgoto L_0037;\nL_FFFFFFFF:\n\treturnVal2 = 0;\nL_0037:\n\treturn returnVal2;\n")]
		public EntityMono GetBinding(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MonoBindingManager::GetBinding");
			return default;
		}

		[Token(Token = "0x600021E")]
		[Address(RVA = "0x3C747D4", Offset = "0x3C747D4", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tv54 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>::TryGetValue(this._bindings, v40, &v53 @ stack_-38_v2 (_game.BaseLayerSystems.EntitySystem.EntityMono));\n\tv61 = v54 == 0;\n\tv66 = ~v61;\n\tv67 = ~v66;\n\tif (v67) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal2 = v53;\n\tgoto L_0037;\nL_FFFFFFFF:\n\treturnVal2 = 0;\nL_0037:\n\treturn returnVal2;\n")]
		public EntityMono GetBinding(EntityId id)
		{
			EntityId key = default(EntityId);
			if (_bindings.TryGetValue(key, out var value))
			{
				return value;
			}
			return null;
		}

		[Token(Token = "0x600021F")]
		[Address(RVA = "0x3C6FDE4", Offset = "0x3C6FDE4", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\treturnVal2 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>::TryGetValue(this._bindings, entity, mono);\n\tv58 = ~returnVal2;\n\tif (v58) goto L_0040;\n\tgoto L_0037;\nL_0037:\n\treturnVal3 = UnityEngine.Object::op_Inequality(*([mono @ X2 (_game.BaseLayerSystems.EntitySystem.EntityMono&)]), 0);\n\treturn returnVal3;\nL_0040:\n\treturn returnVal2;\n")]
		public bool TryGetBinding(Entity entity, out EntityMono mono)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MonoBindingManager::TryGetBinding");
			mono = default;
			return default;
		}

		[Token(Token = "0x6000220")]
		[Address(RVA = "0x3C6FF48", Offset = "0x3C6FF48", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\treturnVal1 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>::ContainsKey(this._bindings, entity);\n\treturn returnVal1;\n")]
		public bool HasBinding(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MonoBindingManager::HasBinding");
			return default;
		}

		[IteratorStateMachine(typeof(_003CGetBoundEntities_003Ed__17))]
		[Token(Token = "0x6000221")]
		[Address(RVA = "0x3C74858", Offset = "0x3C74858", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv45.<>l__initialThreadId = v50;\n\tv45.<>4__this = this;\n\treturn v45;\nL_0017:\n\tv45 = new _game.BaseLayerSystems.EntitySystem.Core.MonoBindingManager+<GetBoundEntities>d__17();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = -2;\n\tv50 = System.Environment::get_CurrentManagedThreadId();\n")]
		public IEnumerable<Entity> GetBoundEntities()
		{
			_003CGetBoundEntities_003Ed__17 _003CGetBoundEntities_003Ed__18 = new _003CGetBoundEntities_003Ed__17(-2);
			int currentManagedThreadId = Environment.CurrentManagedThreadId;
			_003CGetBoundEntities_003Ed__18._003C_003El__initialThreadId = currentManagedThreadId;
			_003CGetBoundEntities_003Ed__18._003C_003E4__this = this;
			return _003CGetBoundEntities_003Ed__18;
		}

		[Token(Token = "0x6000222")]
		[Address(RVA = "0x3C74918", Offset = "0x3C74918", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv63 = 0xB2A8000 + 0x390;\n\tv67 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>::GetEnumerator(this._bindings);\n\tv138 = v67._dictionary;\n\t_game.BaseLayerSystems.EntitySystem.EntityMono::OnUnbind(*([v67 @ X0_v19 (System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>+Enumerator<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>)+18]));\n\tgoto L_0046;\nL_0051:\n\tSystem.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>+Enumerator<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>::Dispose(&v138 @ stack_-70_v4 (System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>));\n\tv95 = &v49 @ stack_-70_v1 (System.Int32);\n\tv101 = 0;\n\tv142 = Il2CppMethodInfo;\n\tv145 = v63;\nL_0053:\n\tv154 = this._bindings == 0;\n\tv95 = &v49 @ stack_-70_v1 (System.Int32);\n\tv101 = 0;\n\tv142 = Il2CppMethodInfo;\n\tv145 = v63;\n\tif (v154) goto L_0063;\n\tSystem.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>::Clear(this._bindings);\n\treturn;\nL_0070:\n\tv182 = v142 != 1;\n\tv198 = v159;\n\tif (v182) goto L_0080;\n\tv189 = 0x8BF5BC4(v159, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv207 = 0x8BF5BF4(v189, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv142 = *([v145 @ X22_v1 (System.Int32)]);\n\tSystem.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>+Enumerator<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>::Dispose(v95);\n\tv197 = *([v189 @ X0_v12]) == 0;\n\tv101 = *([v189 @ X0_v12]);\n\tif (v197) goto L_0053;\n\tv195 = new System.OutOfMemoryException();\n\tv101 = *([v189 @ X0_v12]);\n\tv198 = v195;\n\treturn;\nL_0027:\n\tv49 = 0;\n\tv52 = this._bindings == 0;\n\tif (v52) goto L_0063;\nL_0046:\n\tv171 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>+Enumerator<_game.BaseLayerSystems.EntitySystem.Core.EntityId, System.Object>::MoveNext(&v138 @ stack_-70_v4 (System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>));\n\tv187 = v171 == 0;\n\tif (v187) goto L_0051;\nL_0063:\n\tv159 = new System.NullReferenceException();\n\tgoto L_0070;\nL_0080:\n\tv201 = 0x317A000(&v101 @ stack_-80_v4 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv209 = 0x8BF0368(v198, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv213 = 0xA1B8(v209, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Clear()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MonoBindingManager::Clear");
		}

		[Token(Token = "0x6000223")]
		[Address(RVA = "0x3C74A90", Offset = "0x3C74A90", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv61 = this._entityManager;\n\tv63 = new System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>();\n\tSystem.Action`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::.ctor(v63, this, Il2CppMethodInfo);\n\tv144 = this._entityManager == 0;\n\tif (v144) goto L_006C;\n\tgoto L_0039;\nL_FFFFFFFF:\n\tv95 = 0;\nL_004E:\n\tv194 = System.Delegate::Remove(v185, v63);\n\tv195 = v194 == 0;\n\tif (v195) goto L_FFFFFFFF;\n\tv199 = 0x21C11D0(v194, System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv202 = v199 == 0;\n\tv203 = ~v202;\nL_FFFFFFFF:\n\tv95 = v199;\n\tif (v203) goto L_003F;\nL_FFFFFFFF:\n\tv95 = System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tthrow System.InvalidCastException;\nL_005D:\n\t_game.BaseLayerSystems.EntitySystem.Core.MonoBindingManager::Clear(this);\n\tthis._isDisposed = 1;\nL_006C:\n\tthrow v63;\nL_001D:\n\tv53 = this._isDisposed == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_006B;\nL_0039:\n\tv110 = this._entityManager + 0x50;\nL_FFFFFFFF:\n\tv185 = v61.OnEntityDestroyed;\n\tgoto L_004E;\nL_003F:\n\tv188 = 0x220BDA0(v110, v95, v185, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv174 = v188 == v185;\nL_FFFFFFFF:\n\tv185 = v188;\n\tif (v174) goto L_005D;\nL_006B:\n\treturn;\n")]
		public void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MonoBindingManager::Dispose");
		}
	}
}
