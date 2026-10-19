using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;

namespace _game.CoreSystem.New.Shared.EditMode
{
	[Token(Token = "0x200028A")]
	public abstract class EntityActionsBase : MonoBehaviour
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200028B")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000802")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000803")]
			public static Action<EntityActionsBase> _003C_003E9__8_0;

			[Token(Token = "0x6000B5B")]
			[Address(RVA = "0x3EC5F28", Offset = "0x3EC5F28", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.Shared.EditMode.EntityActionsBase+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000B5C")]
			[Address(RVA = "0x3EC5F8C", Offset = "0x3EC5F8C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal void _003CRemove_003Eb__8_0(EntityActionsBase a)
			{
				EntityActionsBase entityActionsBase = default(EntityActionsBase);
				entityActionsBase.DoRemove();
			}
		}

		[Token(Token = "0x40007FF")]
		[FieldOffset(Offset = "0x20")]
		internal EntityMono _entityMono;

		[Token(Token = "0x4000800")]
		[FieldOffset(Offset = "0x28")]
		protected internal Entity _entity;

		[Token(Token = "0x4000801")]
		[FieldOffset(Offset = "0x30")]
		protected internal EditorHistory _history;

		[Token(Token = "0x170000D7")]
		public Entity Entity
		{
			[Token(Token = "0x6000B51")]
			[Address(RVA = "0x3EC5900", Offset = "0x3EC5900", Length = "0xC0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Inequality(this._entityMono, 0);\n\tv64 = v55 == 0;\n\tif (v64) goto L_0046;\n\tv76 = this._entityMono;\n\treturn v76.Entity;\nL_0046:\n\treturn this._entity;\n")]
			get
			{
				if (_entityMono != null)
				{
					EntityMono entityMono = _entityMono;
					return entityMono.Entity;
				}
				return _entity;
			}
		}

		[Token(Token = "0x6000B52")]
		[Address(RVA = "0x3EC59C0", Offset = "0x3EC59C0", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\treturn;\nL_001A:\n\tthis._entity = entity;\n\tv52 = UnityEngine.Component::GetComponent(this);\n\tthis._entityMono = v52;\n\tthis._history = history;\n")]
		protected internal void BindCore(Entity entity, EditorHistory history)
		{
			_entity = entity;
			EntityMono component = GetComponent<EntityMono>();
			_entityMono = component;
			_history = history;
		}

		[Token(Token = "0x6000B53")]
		[Address(RVA = "0x3EC5A48", Offset = "0x3EC5A48", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0038:\n\tv78 = UnityEngine.Object::op_Inequality(this._entityMono, 0);\n\tv81 = v78 == 0;\n\tif (v81) goto L_005C;\n\tv91 = this._entityMono;\n\tentity.Id = v91.Entity;\n\tv106 = *([em @ X1 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager&)]) == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_0066;\nL_0050:\n\treturn 0;\nL_005C:\n\tentity.Id = this._entity;\n\tv100 = *([em @ X1 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager&)]) == 0;\n\tif (v100) goto L_0050;\nL_0066:\n\tgoto L_0073;\nL_0073:\n\treturnVal3 = _game.BaseLayerSystems.EntitySystem.Core.Entity::get_IsValid(entity);\n\treturn returnVal3;\nL_0024:\n\tgoto L_002D;\nL_002D:\n\t*([em @ X1 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager&)]) = v67._entityManager;\n\tgoto L_0038;\n")]
		protected internal bool TryResolve(out EntityManager em, out Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityActionsBase::TryResolve");
			em = default;
			entity = default;
			return default;
		}

		[Token(Token = "0x6000B54")]
		[Address(RVA = "0x3EC5B98", Offset = "0x3EC5B98", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\treturnVal1 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v49, v51);\n\tv70 = ~returnVal1;\n\tif (v70) goto L_003F;\n\tv100 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(v49, v51);\n\tcoord.x = v100;\n\tcoord.IsValid = v51;\n\treturnVal1 = 1;\nL_001C:\n\tcoord.x = 0;\n\tcoord.IsValid = 0;\n\treturnVal1 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(v41, &v49 @ stack_-38_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v51 @ stack_-40_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv56 = ~returnVal1;\n\tif (v56) goto L_003F;\nL_003F:\n\treturn returnVal1;\n")]
		public bool TryGetCurrentCoord(out GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityActionsBase::TryGetCurrentCoord");
			coord = default;
			return default;
		}

		[Token(Token = "0x6000B55")]
		[Address(RVA = "0x3EC5C64", Offset = "0x3EC5C64", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0015;\nL_0015:\n\tv95 = v49.<>9__8_0;\n\tv51 = v49.<>9__8_0 == 0;\n\tif (v51) goto L_004B;\nL_0029:\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::ForEachSelected(this, v95, \"Remove\");\n\treturn;\nL_004B:\n\tgoto L_0053;\n\tv156 = this == 0;\n\tv92 = ~v156;\n\tv95 = v128;\n\tif (v92) goto L_0029;\n\tthrow System.NullReferenceException;\nL_0053:\n\tv128 = new System.Action`1<_game.CoreSystem.New.Shared.EditMode.EntityActionsBase>();\n\tSystem.Action`1<_game.CoreSystem.New.Shared.EditMode.EntityActionsBase>::.ctor(v128, v123.<>9, Il2CppMethodInfo);\n\tv152.<>9__8_0 = v128;\n")]
		public void Remove()
		{
			Action<EntityActionsBase> action = _003C_003Ec._003C_003E9__8_0;
			if (_003C_003Ec._003C_003E9__8_0 == null)
			{
				Action<EntityActionsBase> action2 = (_003C_003Ec._003C_003E9__8_0 = delegate
				{
					EntityActionsBase entityActionsBase = default(EntityActionsBase);
					entityActionsBase.DoRemove();
				});
				bool flag = (object)this == null;
				bool flag2 = !flag;
				action = action2;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			ForEachSelected(action, "Remove");
		}

		[Token(Token = "0x6000B56")]
		[Address(RVA = "0x3EC5D9C", Offset = "0x3EC5D9C", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv56 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v46);\n\tgoto L_002B;\nL_002B:\n\tv101 = UnityEngine.Object::op_Inequality(v56, 0);\n\tv103 = ~v101;\n\tv104 = ~v103;\n\tif (v104) goto L_0039;\n\tgoto L_0070;\nL_0039:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::UnbindMono(v46);\n\tgoto L_0041;\nL_0041:\n\tv143 = UnityEngine.Application::get_isPlaying();\n\tv145 = ~v143;\n\tif (v145) goto L_005F;\n\tv154 = UnityEngine.Component::get_gameObject(v56);\n\tgoto L_0053;\nL_005F:\n\tv157 = UnityEngine.Component::get_gameObject(v56);\n\tgoto L_006A;\nL_0070:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::DestroyEntity(v44, v46);\nL_0076:\n\treturn;\nL_001B:\n\tv47 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(v36, &v44 @ stack_-28_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v46 @ stack_-30_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv51 = ~v47;\n\tif (v51) goto L_0076;\nL_0053:\n\tUnityEngine.Object::Destroy(v154);\n\tgoto L_0070;\nL_006A:\n\tUnityEngine.Object::DestroyImmediate(v157);\n")]
		protected internal virtual void DoRemove()
		{
			if (!TryResolve(out var em, out var entity))
			{
				return;
			}
			EntityMono monoBinding = entity.GetMonoBinding();
			if (monoBinding != null)
			{
				entity.UnbindMono();
				if (Application.isPlaying)
				{
					GameObject obj = monoBinding.gameObject;
					UnityEngine.Object.Destroy(obj);
				}
				else
				{
					GameObject obj2 = monoBinding.gameObject;
					UnityEngine.Object.DestroyImmediate(obj2);
				}
			}
			em.DestroyEntity(entity);
		}

		[Token(Token = "0x6000B57")]
		[Address(RVA = "0x3EC5F1C", Offset = "0x3EC5F1C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void Undo()
		{
		}

		[Token(Token = "0x6000B58")]
		[Address(RVA = "0x48C30B0", Offset = "0x48C30B0", Length = "0x38C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv76 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv55 = 0;\nL_FFFFFFFF:\n\tv85 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv55 = 0;\n\tgoto L_001D;\nL_001D:\n\tv63 = Il2CppClass<System.Collections.Generic.List`1<T>>;\n\tv66 = *([v63 @ X0_v69 (Il2CppClass<System.Collections.Generic.List`1<T>>)+135]) & 1;\n\tv67 = v66 == 0;\nL_FFFFFFFF:\n\tv78 = Il2CppClass<System.Collections.Generic.List`1<T>>;\nL_FFFFFFFF:\n\tv85 = v76;\nL_FFFFFFFF:\n\tv87 = Il2CppClass<System.Collections.Generic.List`1<T>>;\n\tif (v67) goto L_003F;\nL_0023:\n\tv84 = new v78();\n\tSystem.Collections.Generic.List`1<System.Object>::.ctor(v84);\n\tv101 = v84 == 0;\n\tv102 = ~v101;\nL_FFFFFFFF:\n\tv332 = v84;\n\tif (v102) goto L_0047;\n\tgoto L_0142;\n\tv58 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv76 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv55 = 0;\nL_FFFFFFFF:\n\tv85 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv55 = 0;\n\tgoto L_001D;\n\tv74 = 0x220C2B8(v85, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv91 = *([v85 @ X24_v14 (Il2CppClass<Il2CppMethodRgctx<_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::ForEachSelected>>)+38]);\n\tv78 = *([v91 @ X8_v49]);\n\tv93 = *([v78 @ X0_v66 (Il2CppClass<Il2CppMethodRgctx<_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::CollectSelectionTargets>>)+135]) & 1;\n\tv94 = v93 == 0;\n\tv81 = ~v94;\nL_FFFFFFFF:\n\tv76 = v85;\nL_FFFFFFFF:\n\tv87 = v78;\n\tif (v81) goto L_0023;\nL_003F:\n\tv90 = 0x220C238(v87, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = new v90();\n\tSystem.Collections.Generic.List`1<System.Object>::.ctor(v100);\nL_FFFFFFFF:\n\tv332 = v100;\nL_0047:\n\tv195 = *([v332 @ X21_v3+18]);\n\tv115 = *([v332 @ X21_v3+18]) == 0;\n\tv116 = ~v115;\n\tif (v116) goto L_008D;\n\tgoto L_0057;\n\tv375 = *([v332 @ X21_v3+1C]) + 1;\n\t*([v332 @ X21_v3+1C]) = v375;\n\tv119 = *([v332 @ X21_v3+10]);\n\tv476 = *([v332 @ X21_v3+18]) < *([v119 @ X9_v20+18]);\n\tv173 = ~v476;\n\tif (v173) goto L_007F;\n\tv380 = *([v332 @ X21_v3+18]) + 1;\n\t*([v332 @ X21_v3+18]) = v380;\n\tv376 = *([v332 @ X21_v3+18]) << 3;\n\tv523 = v119 + v376;\n\tv524 = v523 + 0x20;\n\t*([v524 @ X0_v55]) = v126;\nL_0076:\n\tv195 = *([v332 @ X21_v3+18]);\n\tv381 = *([v332 @ X21_v3+18]) == 0;\n\tv194 = ~v381;\n\tif (v194) goto L_008D;\n\tgoto L_0141;\nL_007F:\n\tSystem.Collections.Generic.List`1<System.Object>::AddWithResize(v332, v126);\n\tv195 = *([v332 @ X21_v3+18]);\n\tv193 = *([v332 @ X21_v3+18]) == 0;\n\tif (v193) goto L_0141;\nL_008D:\n\tv208 = v195 < 2;\n\tif (v208) goto L_00A0;\n\tv273 = System.Collections.Generic.List`1<System.Object>::get_Item(v332, 0);\n\tv275 = v273 != this;\n\tif (v275) goto L_0141;\nL_00A0:\n\tv297 = this._history == 0;\n\tif (v297) goto L_011B;\n\tv357 = _game.CoreSystem.New.Shared.EditMode.EditorHistory::Batch(this._history, label);\n\tv432 = v357;\n\tv444 = *([v332 @ X21_v3+18]) < 1;\n\tif (v444) goto L_00DB;\n\tv467 = action == 0;\nL_FFFFFFFF:\n\tv445 = &v55 @ stack_-48_v14 (System.Int32);\nL_FFFFFFFF:\n\tv213 = 0;\n\tif (v467) goto L_014F;\nL_FFFFFFFF:\n\tv635 = 0;\n\tv569 = &v432 @ stack_-48_v10 (System.IDisposable);\n\tv571 = *([v569 @ X8_v33]);\n\tv705 = *([v569 @ X8_v33]) == 0;\n\tv566 = ~v705;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv213 = 0;\nL_FFFFFFFF:\n\tv558 = 0;\nL_FFFFFFFF:\n\tv574 = 0;\n\tif (v566) goto L_00E4;\nL_FFFFFFFF:\n\tv445 = &v55 @ stack_-48_v14 (System.Int32);\nL_FFFFFFFF:\n\tv213 = 0;\nL_FFFFFFFF:\n\tv246 = v332;\nL_FFFFFFFF:\n\tv249 = 0;\nL_FFFFFFFF:\n\tv261 = 0;\n\tgoto L_010B;\nL_00DB:\n\tv571 = v55.m_value;\n\tv520 = v55.m_value == 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv213 = 0;\nL_FFFFFFFF:\n\tv558 = 0;\nL_FFFFFFFF:\n\tv574 = 0;\nL_FFFFFFFF:\n\tv445 = &v55 @ stack_-48_v14 (System.Int32);\nL_FFFFFFFF:\n\tv213 = 0;\nL_FFFFFFFF:\n\tv246 = v332;\nL_FFFFFFFF:\n\tv249 = 0;\nL_FFFFFFFF:\n\tv261 = 0;\n\tif (v520) goto L_010B;\nL_00E4:\n\tgoto L_010A;\n\tv368 = v249 == 0;\nL_FFFFFFFF:\n\tv332 = v246;\n\tif (v368) goto L_0141;\nL_011B:\n\tv303 = *([v332 @ X21_v3+18]) < 1;\n\tif (v303) goto L_0141;\n\tv341 = action == 0;\n\tif (v341) goto L_0149;\nL_FFFFFFFF:\n\tv615 = 0;\nL_0141:\n\treturn;\nL_0142:\n\tthrow System.NullReferenceException;\nL_0144:\n\tthrow System.OutOfMemoryException;\nL_0149:\n\tv352 = System.Collections.Generic.List`1<System.Object>::get_Item(v332, 0);\n\tthrow System.NullReferenceException;\nL_014F:\n\tv475 = System.Collections.Generic.List`1<System.Object>::get_Item(v332, 0);\n\tv522 = new System.NullReferenceException();\n\tgoto L_015F;\nL_015F:\n\tgoto L_016E;\n\tv702 = 0x8BF5BC4(v522, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv574 = *([v702 @ X0_v12]);\n\tv564 = 0x8BF5BF4(v702, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv571 = *([v445 @ stack_-50_v2]);\n\tv716 = *([v445 @ stack_-50_v2]) == 0;\n\tv567 = ~v716;\nL_FFFFFFFF:\n\tv558 = 1;\n\tif (v567) goto L_00E4;\nL_FFFFFFFF:\n\tv246 = v332;\nL_FFFFFFFF:\n\tv249 = 1;\nL_FFFFFFFF:\n\tv261 = *([v702 @ X0_v12]);\n\tgoto L_010B;\n\treturn;\nL_0057:\n\tv126 = 0x21C11D0(this, Il2CppClass<T>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv353 = v126 == 0;\n\tif (v353) goto L_0076;\nL_00BD:\n\tv641 = System.Collections.Generic.List`1<System.Object>::get_Item(v332, v635);\n\tSystem.Action`1<T>::Invoke(action, v641);\n\tv635 = v635 + 1;\n\tv532 = v635 < *([v332 @ X21_v3+18]);\n\tif (v532) goto L_00BD;\nL_010B:\n\tv601 = v261 == 0;\n\tv255 = ~v601;\n\tif (v255) goto L_0144;\nL_010A:\n\tSystem.IDisposable::Dispose(v571);\nL_FFFFFFFF:\n\tv246 = v332;\nL_FFFFFFFF:\n\tv249 = v558;\nL_FFFFFFFF:\n\tv261 = v574;\nL_0124:\n\tv620 = System.Collections.Generic.List`1<System.Object>::get_Item(v332, v615);\n\tSystem.Action`1<T>::Invoke(action, v620);\n\tv615 = v615 + 1;\n\tv385 = v615 < *([v332 @ X21_v3+18]);\n\tif (v385) goto L_0124;\nL_016E:\n\tv704 = 0x3175484(&v213 @ stack_-58 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv715 = 0x8BF0368(v522, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv508 = 0xA1B8(v715, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal unsafe void ForEachSelected<T>(Action<T> action, string label) where T : EntityActionsBase
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityActionsBase::ForEachSelected");
		}

		[Token(Token = "0x6000B59")]
		[Address(RVA = "0x48C3040", Offset = "0x48C3040", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv44 = Il2CppClass<System.Collections.Generic.List`1<T>>;\n\tgoto L_0012;\nL_0012:\n\tv47 = new v44();\n\tSystem.Collections.Generic.List`1<T>::.ctor(v47);\n\treturn v47;\n\tv21 = 0x220C2B8(methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv44 = Il2CppClass<System.Collections.Generic.List`1<T>>;\n\tgoto L_0012;\n")]
		private static List<T> CollectSelectionTargets<T>() where T : EntityActionsBase
		{
			nint num = 0;
			return new List<T>();
		}

		[Token(Token = "0x6000B5A")]
		[Address(RVA = "0x3EC5F20", Offset = "0x3EC5F20", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		protected internal EntityActionsBase()
		{
		}
	}
}
