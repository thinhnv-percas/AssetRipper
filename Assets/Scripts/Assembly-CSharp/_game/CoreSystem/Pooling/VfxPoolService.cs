using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;
using UnityEngine.Pool;

namespace _game.CoreSystem.Pooling
{
	[Token(Token = "0x200012A")]
	public class VfxPoolService : MonoBehaviour, IVfxPool, IDisposable
	{
		[Token(Token = "0x200012B")]
		private struct PrewarmSettings
		{
			[Token(Token = "0x40003E0")]
			[FieldOffset(Offset = "0x0")]
			public int defaultCapacity;

			[Token(Token = "0x40003E1")]
			[FieldOffset(Offset = "0x4")]
			public int maxSize;
		}

		[Token(Token = "0x40003DB")]
		private const int DEFAULT_CAPACITY = 8;

		[Token(Token = "0x40003DC")]
		private const int DEFAULT_MAX_SIZE = 32;

		[Token(Token = "0x40003DD")]
		[FieldOffset(Offset = "0x20")]
		private readonly Dictionary<GameObject, ObjectPool<GameObject>> _pools;

		[Token(Token = "0x40003DE")]
		[FieldOffset(Offset = "0x28")]
		private readonly Dictionary<GameObject, PrewarmSettings> _settings;

		[Token(Token = "0x40003DF")]
		[FieldOffset(Offset = "0x30")]
		private bool _disposed;

		[Token(Token = "0x6000600")]
		[Address(RVA = "0x3DB0CF4", Offset = "0x3DB0CF4", Length = "0x270")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\tgoto L_001E;\nL_001E:\n\tv65 = UnityEngine.Object::op_Equality(config, 0);\n\tv74 = v65 == 0;\nL_FFFFFFFF:\n\tv498 = 0;\n\tif (v74) goto L_0041;\n\tgoto L_0123;\nL_0041:\n\tv187 = config.m_entries;\n\tv179 = config.m_entries == 0;\n\tif (v179) goto L_0123;\nL_FFFFFFFF:\n\tv185 = 0;\n\tgoto L_004C;\nL_004A:\n\tv185 = v185 + 1;\n\tv164 = *([v329 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.Pooling.VfxPoolPrewarmConfig+Entry>>)+B0]) + 8;\n\tv164 = v164 + 0x10;\n\tv335 = v357 - 1;\n\tv334 = v357 != 1;\nL_FFFFFFFF:\n\tv357 = v335;\n\tif (v334) goto L_0057;\nL_0070:\n\tv176 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.Pooling.VfxPoolPrewarmConfig+Entry>::get_Count(config.m_entries);\n\tv123 = v185 < v176;\n\tif (v123) goto L_0095;\n\tgoto L_0123;\nL_007F:\n\tv120 = *([v164 @ X10_v14]) << 4;\n\tv379 = v329 + v120;\n\tv380 = v379 + 0x138;\n\t*([v380 @ X0_v27])(v177, config.m_entries, *([v380 @ X0_v27+8]), v498, v293, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv124 = v185 >= v177;\n\tif (v124) goto L_0123;\nL_0095:\n\tgoto L_00BD;\nL_00C9:\n\tv476 = UnityEngine.Object::op_Equality(v202, 0);\n\tv479 = v476 == 0;\n\tv480 = ~v479;\nL_FFFFFFFF:\n\tv498 = 0;\n\tif (v480) goto L_004A;\n\tgoto L_00DD;\nL_00DD:\n\tv511 = v470 - 1;\n\tv512 = v511 < 0;\n\tv513 = v511 == 0;\n\tv514 = v470 ^ 1;\n\tv515 = v470 ^ v511;\n\tv516 = v514 & v515;\n\tv517 = v516 < 0;\n\tv518 = v512 == v517;\n\tv519 = ~v513;\n\tv520 = v518 & v519;\n\tv521 = ~v520;\n\tif (v521) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv524 = v470;\n\tgoto L_00EF;\nL_FFFFFFFF:\n\tv524 = 1;\nL_FFFFFFFF:\n\tv489 = v469;\n\tgoto L_00FF;\nL_FFFFFFFF:\n\tv489 = 1;\n\t_game.CoreSystem.Pooling.VfxPoolService::Prewarm(this, v202, v468);\nL_FFFFFFFF:\n\tv293 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv498 = v468;\n\tgoto L_004A;\nL_0123:\n\treturn;\nL_004C:\n\tv329 = *([v187 @ X20_v5 (System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.Pooling.VfxPoolPrewarmConfig+Entry>)]);\n\tv357 = *([v329 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.Pooling.VfxPoolPrewarmConfig+Entry>>)+12E]);\n\tv180 = *([v329 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.Pooling.VfxPoolPrewarmConfig+Entry>>)+12E]) == 0;\n\tif (v180) goto L_0070;\nL_0057:\n\tv370 = *([v164 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.Pooling.VfxPoolPrewarmConfig+Entry>;\n\tif (v370) goto L_007F;\nL_00BD:\n\tv467 = System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.Pooling.VfxPoolPrewarmConfig+Entry>::get_Item(config.m_entries, v185);\n\tgoto L_00C9;\nL_00EF:\n\tv527 = v469 - 1;\n\tv528 = v527 < 0;\n\tv529 = v527 == 0;\n\tv530 = v469 ^ 1;\n\tv531 = v469 ^ v527;\n\tv532 = v530 & v531;\n\tv533 = v532 < 0;\n\tv534 = v528 == v533;\n\tv487 = ~v529;\n\tv535 = v534 & v487;\n\tv486 = ~v535;\n\tif (v486) goto L_FFFFFFFF;\nL_00FF:\n\tv498 = v489 | v524;\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.GameObject, _game.CoreSystem.Pooling.VfxPoolService+PrewarmSettings>::set_Item(this._settings, v202, v498);\n\tv488 = v468 < 1;\nL_FFFFFFFF:\n\tv293 = Il2CppMethodInfo;\n\tif (v488) goto L_004A;\n")]
		public void Initialize(VfxPoolPrewarmConfig config)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VfxPoolService::Initialize");
		}

		[Token(Token = "0x6000601")]
		[Address(RVA = "0x3DB1178", Offset = "0x3DB1178", Length = "0x22C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\nL_002B:\n\tgoto L_002F;\nL_002F:\n\tv81 = UnityEngine.Object::op_Equality(prefab, 0);\n\tv90 = v81 == 0;\n\tif (v90) goto L_004F;\n\tgoto L_FFFFFFFF;\nL_004F:\n\tv106 = this._disposed == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_FFFFFFFF;\n\tv131 = _game.CoreSystem.Pooling.VfxPoolService::GetOrCreatePool(this, prefab);\n\tv239 = UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>::Get(v131);\n\tgoto L_0063;\nL_0063:\n\tv119 = UnityEngine.Object::op_Equality(v239, 0);\n\tv122 = v119 == 0;\n\tif (v122) goto L_0088;\nL_FFFFFFFF:\n\tv156 = 0;\nL_0088:\n\tv247 = UnityEngine.GameObject::get_transform(v239);\n\tUnityEngine.Transform::SetParent(v247, parent, 0);\n\tUnityEngine.Transform::SetPositionAndRotation(v247, worldPos, worldRot);\n\tv271 = UnityEngine.GameObject::GetComponent(v239);\n\tgoto L_00A9;\nL_00A9:\n\tv277 = UnityEngine.Object::op_Inequality(v271, 0);\n\tv279 = ~v277;\n\tv280 = ~v279;\n\tif (v280) goto L_00B8;\n\tgoto L_00BC;\nL_00B8:\n\tv271.AutoReturnOnStopped = 1;\nL_00BC:\n\tUnityEngine.GameObject::SetActive(v239, 1);\nL_FFFFFFFF:\n\tv156 = v239;\n\tgoto L_007A;\nL_007A:\n\treturn v156;\n")]
		public GameObject Rent(GameObject prefab, Vector3 worldPos, Quaternion worldRot, Transform parent)
		{
			if (!(prefab == null) && !_disposed)
			{
				ObjectPool<GameObject> orCreatePool = GetOrCreatePool(prefab);
				GameObject gameObject = orCreatePool.Get();
				if (!(gameObject == null))
				{
					Transform transform = gameObject.transform;
					transform.SetParent(parent, worldPositionStays: false);
					transform.SetPositionAndRotation(worldPos, worldRot);
					PooledVfxBehaviour component = gameObject.GetComponent<PooledVfxBehaviour>();
					if (component != null)
					{
						component.AutoReturnOnStopped = true;
					}
					gameObject.SetActive(value: true);
					return gameObject;
				}
			}
			return null;
		}

		[Token(Token = "0x6000602")]
		[Address(RVA = "0x3DB160C", Offset = "0x3DB160C", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv56.<>4__this = this;\n\tv56.instance = instance;\n\tgoto L_0044;\nL_0044:\n\tv201 = UnityEngine.Object::op_Equality(v56.instance, 0);\n\tv204 = v201 == 0;\n\tif (v204) goto L_0067;\n\treturn;\nL_0067:\n\tv95 = this._disposed != 1;\n\tif (v95) goto L_0081;\n\tgoto L_007D;\nL_007D:\n\tUnityEngine.Object::Destroy(v56.instance);\n\treturn;\nL_0081:\n\tv113 = delay == 0;\n\tv219 = delay < 0;\n\tv125 = ~v219;\n\tv220 = ~v125;\n\tv96 = v220 | v113;\n\tif (v96) goto L_00B6;\n\tv226 = new System.Action`1<UnityEngine.GameObject>();\n\tSystem.Action`1<UnityEngine.GameObject>::.ctor(v226, v56, Il2CppMethodInfo);\n\tv158 = PrimeTween.Tween::Delay(v56.instance, delay, v226, 0, 1);\n\treturn;\nL_00B6:\n\t_game.CoreSystem.Pooling.VfxPoolService::ReleaseToPool(this, v56.instance);\n\treturn;\nL_0029:\n\tv56 = new _game.CoreSystem.Pooling.VfxPoolService+<>c__DisplayClass7_0();\n\tSystem.Object::.ctor(v56);\n")]
		public void Return(GameObject instance, float delay = 0f)
		{
			if (instance == null)
			{
				return;
			}
			if (_disposed)
			{
				UnityEngine.Object.Destroy(instance);
				return;
			}
			bool flag = delay == 0f;
			bool flag2 = delay < 0f;
			bool flag3 = !flag2;
			bool flag4 = !flag3;
			if (!(flag4 || flag))
			{
				Action<GameObject> onComplete = delegate
				{
					ReleaseToPool(instance);
				};
				Tween tween = Tween.Delay(instance, delay, onComplete);
			}
			else
			{
				ReleaseToPool(instance);
			}
		}

		[Token(Token = "0x6000603")]
		[Address(RVA = "0x3DB0F64", Offset = "0x3DB0F64", Length = "0x214")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\tgoto L_001F;\nL_001F:\n\tv111 = UnityEngine.Object::op_Equality(prefab, 0);\n\tv83 = count >= 1;\n\tif (v83) goto L_0051;\n\tgoto L_0065;\nL_0051:\n\tv115 = v111 == 0;\n\tv116 = ~v115;\n\tif (v116) goto L_0065;\n\tv155 = this._disposed == 0;\n\tif (v155) goto L_0068;\nL_0065:\n\treturn;\nL_0068:\n\tv232 = _game.CoreSystem.Pooling.VfxPoolService::GetOrCreatePool(this, prefab);\n\t// 110 NewArr v237 @ X0_v6 (UnityEngine.GameObject[]), typeof(UnityEngine.GameObject[]), count @ X2 (System.Int32)\n\tv239 = v237 == 0;\n\tif (v239) goto L_00DD;\n\tv161 = v237 + 0x20;\n\tv289 = 0;\n\tv314 = v161;\n\t*([v314 @ X21_v7]) = v318;\n\tv123 = v314 + 8;\n\tv289 = v289 + 1;\n\tv131 = count != v289;\n\tv314 = v123;\n\tif (v131) goto L_007C;\n\tv330 = 0;\n\tgoto L_00B9;\nL_009F:\n\tv330 = v330 + 1;\n\tv141 = count == v330;\n\tif (v141) goto L_0065;\nL_00B9:\n\tgoto L_00BD;\nL_00BD:\n\tv378 = UnityEngine.Object::op_Inequality(v237[v330 @ X25_v10 (System.Int32)], 0);\n\tv380 = ~v378;\n\tif (v380) goto L_009F;\n\tgoto L_00D6;\nL_00D6:\n\tv395 = UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>::Release(v232, v237[v330 @ X25_v10 (System.Int32)]);\n\tgoto L_009F;\nL_00DD:\n\tv256 = UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>::Get(v232);\n\tthrow System.NullReferenceException;\nL_007C:\n\tv318 = UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>::Get(v232);\n")]
		public void Prewarm(GameObject prefab, int count)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VfxPoolService::Prewarm");
		}

		[Token(Token = "0x6000604")]
		[Address(RVA = "0x3DB19F8", Offset = "0x3DB19F8", Length = "0x2A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tthis._disposed = 1;\n\tv52 = this._pools == 0;\n\tv169 = &v160 @ stack_-50_v4 (System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>>);\n\tv173 = 0;\n\tv175 = Il2CppMethodInfo;\n\tif (v52) goto L_00B8;\n\tv145 = System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>>::get_Values(this._pools);\n\tv185 = v145 == 0;\n\tv169 = v109;\n\tv175 = methodInfo;\n\tif (v185) goto L_00B8;\n\tv262 = System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>>+ValueCollection<UnityEngine.GameObject, UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>>::GetEnumerator(v145);\n\tv160 = v262._dictionary;\n\tUnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>::Clear(v262.Current);\n\tgoto L_0054;\nL_0062:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v160 @ stack_-50_v4 (System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>>));\n\tv108 = &v160 @ stack_-50_v4 (System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>>);\n\tv173 = 0;\n\tv177 = Il2CppMethodInfo;\nL_0064:\n\tv186 = this._pools == 0;\n\tv169 = v109;\n\tv175 = Il2CppMethodInfo;\n\tif (v186) goto L_00B8;\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.GameObject, UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>>::Clear(this._pools);\n\tv187 = this._settings == 0;\n\tv169 = v108;\n\tv175 = v177;\n\tif (v187) goto L_00B8;\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.GameObject, _game.CoreSystem.Pooling.VfxPoolService+PrewarmSettings>::Clear(this._settings);\n\tgoto L_007A;\nL_007A:\n\tv121 = UnityEngine.Object::op_Inequality(this, 0);\n\tv324 = v121 == 0;\n\tv125 = ~v324;\n\tif (v125) goto L_0091;\nL_0086:\n\treturn;\nL_0091:\n\tv332 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_009D;\n\tv343 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_00AD;\nL_00C5:\n\tv197 = v175 != 1;\n\tv247 = v195;\n\tif (v197) goto L_00D7;\n\tv274 = 0x8BF5BC4(v195, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv295 = 0x8BF5BF4(v274, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(v169);\n\tv279 = *([v274 @ X0_v13]) == 0;\n\tv108 = v169;\n\tv173 = *([v274 @ X0_v13]);\n\tv177 = Il2CppMethodInfo;\n\tif (v279) goto L_0064;\n\tv278 = new System.OutOfMemoryException();\n\tv173 = *([v274 @ X0_v13]);\n\tv247 = v278;\n\treturn;\nL_002E:\n\tv45 = this._disposed == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_0086;\nL_00B8:\n\tv195 = new System.NullReferenceException();\n\tgoto L_00C5;\nL_0054:\n\tv293 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v160 @ stack_-50_v4 (System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>>));\n\tv302 = v293 == 0;\n\tif (v302) goto L_0062;\nL_009D:\n\tv123 = UnityEngine.Object::op_Inequality(v332, 0);\n\tv127 = ~v123;\n\tif (v127) goto L_0086;\nL_00AD:\n\tUnityEngine.Object::Destroy(v343);\n\treturn;\nL_00D7:\n\tv283 = 0x3189F18(&v173 @ stack_-68_v2 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv297 = 0x8BF0368(v247, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv238 = 0xA1B8(v297, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VfxPoolService::Dispose");
		}

		[Token(Token = "0x6000605")]
		[Address(RVA = "0x3DB1C9C", Offset = "0x3DB1C9C", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tthis._disposed = 1;\n\tv55 = this._pools == 0;\n\tv140 = &v155 @ stack_-48_v5 (System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>>);\n\tv142 = 0;\n\tv156 = Il2CppMethodInfo;\n\tif (v55) goto L_0077;\n\tv128 = System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>>::get_Values(this._pools);\n\tv165 = v128 == 0;\n\tv140 = v87;\n\tv156 = methodInfo;\n\tif (v165) goto L_0077;\n\tv226 = System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>>+ValueCollection<UnityEngine.GameObject, UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>>::GetEnumerator(v128);\n\tv155 = v226._dictionary;\n\tUnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>::Clear(v226.Current);\n\tgoto L_0050;\nL_005E:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v155 @ stack_-48_v5 (System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>>));\n\tv86 = &v155 @ stack_-48_v5 (System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>>);\n\tv142 = 0;\n\tv158 = Il2CppMethodInfo;\nL_0060:\n\tv166 = this._pools == 0;\n\tv140 = v87;\n\tv156 = Il2CppMethodInfo;\n\tif (v166) goto L_0077;\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.GameObject, UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>>::Clear(this._pools);\n\tv111 = this._settings == 0;\n\tv140 = v86;\n\tv156 = v158;\n\tif (v111) goto L_0077;\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.GameObject, _game.CoreSystem.Pooling.VfxPoolService+PrewarmSettings>::Clear(this._settings);\nL_0074:\n\treturn;\nL_0084:\n\tv175 = v156 != 1;\n\tv213 = v173;\n\tif (v175) goto L_0096;\n\tv235 = 0x8BF5BC4(v173, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv256 = 0x8BF5BF4(v235, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(v140);\n\tv240 = *([v235 @ X0_v13]) == 0;\n\tv86 = v140;\n\tv142 = *([v235 @ X0_v13]);\n\tv158 = Il2CppMethodInfo;\n\tif (v240) goto L_0060;\n\tv239 = new System.OutOfMemoryException();\n\tv142 = *([v235 @ X0_v13]);\n\tv213 = v239;\n\treturn;\nL_0029:\n\tv155 = 0;\n\tv48 = this._disposed == 0;\n\tv49 = ~v48;\n\tif (v49) goto L_0074;\nL_0077:\n\tv173 = new System.NullReferenceException();\n\tgoto L_0084;\nL_0050:\n\tv254 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v155 @ stack_-48_v5 (System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>>));\n\tv262 = v254 == 0;\n\tif (v262) goto L_005E;\nL_0096:\n\tv244 = 0x3189F18(&v142 @ stack_-58_v2 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv258 = 0x8BF0368(v213, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv207 = 0xA1B8(v258, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void OnDestroy()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VfxPoolService::OnDestroy");
		}

		[Token(Token = "0x6000606")]
		[Address(RVA = "0x3DB13A4", Offset = "0x3DB13A4", Length = "0x268")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003C;\n\tv57.<>4__this = this;\n\tv57.prefab = prefab;\n\tv245 = System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>>::TryGetValue(this._pools, v57.prefab, &v132 @ stack_-58_v3 (UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>));\n\tv250 = v245 == 0;\n\tv251 = ~v250;\n\tif (v251) goto L_00C4;\n\tv274 = System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, _game.CoreSystem.Pooling.VfxPoolService+PrewarmSettings>::TryGetValue(this._settings, v57.prefab, &v130 @ stack_-60_v4 (_game.CoreSystem.Pooling.VfxPoolService+PrewarmSettings));\n\tv116 = v274 == 0;\n\tv281 = ~v116;\n\tv282 = ~v281;\n\tif (v282) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv160 = v279;\n\tgoto L_0077;\nL_FFFFFFFF:\n\tv160 = 0x20;\nL_FFFFFFFF:\n\tv92 = v130;\n\tgoto L_0081;\nL_FFFFFFFF:\n\tv92 = 8;\n\tSystem.Action`1<UnityEngine.GameObject>::.ctor(v299, this, Il2CppMethodInfo);\n\tv306 = new System.Action`1<UnityEngine.GameObject>();\n\tSystem.Action`1<UnityEngine.GameObject>::.ctor(v306, this, Il2CppMethodInfo);\n\tv315 = new UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>();\n\tUnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>::.ctor(v315, v290, 0, v299, v306, 1, v92, v160);\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.GameObject, UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>>::set_Item(this._pools, v57.prefab, v315);\nL_00C4:\n\treturn v315;\nL_003C:\n\tv57 = new _game.CoreSystem.Pooling.VfxPoolService+<>c__DisplayClass11_0();\n\tSystem.Object::.ctor(v57);\nL_0077:\n\tv98 = ~v116;\n\tv95 = ~v98;\n\tif (v95) goto L_FFFFFFFF;\nL_0081:\n\tv290 = new System.Func`1<UnityEngine.GameObject>();\n\tSystem.Func`1<UnityEngine.GameObject>::.ctor(v290, v57, Il2CppMethodInfo);\n\tv299 = new System.Action`1<UnityEngine.GameObject>();\n")]
		private ObjectPool<GameObject> GetOrCreatePool(GameObject prefab)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VfxPoolService::GetOrCreatePool");
			return default;
		}

		[Token(Token = "0x6000607")]
		[Address(RVA = "0x3DB1E78", Offset = "0x3DB1E78", Length = "0x1A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\nL_0031:\n\tv71 = UnityEngine.Object::Instantiate(prefab, v54);\n\tv78 = UnityEngine.Object::get_name(prefab);\n\tUnityEngine.Object::set_name(v71, v78);\n\tv127 = UnityEngine.GameObject::GetComponent(v71);\n\tv130 = UnityEngine.Object::op_Equality(v127, 0);\n\tv131 = ~v130;\n\tv89 = v127;\n\tif (v131) goto L_0058;\n\tv136 = UnityEngine.GameObject::AddComponent(v71);\n\tv89 = v136;\nL_0058:\n\tgoto L_0060;\n\tv89._systems = v160;\n\tUnityEngine.GameObject::SetActive(v71, 0);\n\treturn v71;\nL_0026:\n\tv54 = UnityEngine.Component::get_transform(this);\n\tgoto L_0031;\nL_0060:\n\tv89._owner = this;\n\tv89.PrefabKey = prefab;\n\tv160 = UnityEngine.Component::GetComponentsInChildren(v89, 1);\n")]
		private GameObject CreateInstance(GameObject prefab)
		{
			Transform parent = base.transform;
			GameObject gameObject = UnityEngine.Object.Instantiate(prefab, parent);
			string text = prefab.name;
			gameObject.name = text;
			PooledVfxBehaviour component = gameObject.GetComponent<PooledVfxBehaviour>();
			bool flag = component == null;
			bool flag2 = !flag;
			PooledVfxBehaviour pooledVfxBehaviour = component;
			if (!flag2)
			{
				PooledVfxBehaviour pooledVfxBehaviour2 = gameObject.AddComponent<PooledVfxBehaviour>();
				pooledVfxBehaviour = pooledVfxBehaviour2;
			}
			pooledVfxBehaviour._owner = this;
			pooledVfxBehaviour._prefabKey = prefab;
			ParticleSystem[] componentsInChildren = pooledVfxBehaviour.GetComponentsInChildren<ParticleSystem>(includeInactive: true);
			pooledVfxBehaviour._systems = componentsInChildren;
			gameObject.SetActive(value: false);
			return gameObject;
		}

		[Token(Token = "0x6000608")]
		[Address(RVA = "0x3DB2018", Offset = "0x3DB2018", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv53 = UnityEngine.Object::op_Equality(instance, 0);\n\tv62 = v53 == 0;\n\tif (v62) goto L_0040;\n\treturn;\nL_0040:\n\tv124 = UnityEngine.GameObject::GetComponent(instance);\n\tgoto L_0049;\nL_0049:\n\tv140 = UnityEngine.Object::op_Inequality(v124, 0);\n\tv142 = ~v140;\n\tv143 = ~v142;\n\tif (v143) goto L_0058;\n\tgoto L_005C;\nL_0058:\n\t_game.CoreSystem.Pooling.PooledVfxBehaviour::StopAllSystems(v124);\nL_005C:\n\tUnityEngine.GameObject::SetActive(instance, 0);\n\tv159 = UnityEngine.GameObject::get_transform(instance);\n\tv131 = UnityEngine.Component::get_transform(this);\n\tUnityEngine.Transform::SetParent(v159, v131, 0);\n\treturn;\n")]
		private void OnReleaseInstance(GameObject instance)
		{
			if (!(instance == null))
			{
				PooledVfxBehaviour component = instance.GetComponent<PooledVfxBehaviour>();
				if (component != null)
				{
					component.StopAllSystems();
				}
				instance.SetActive(value: false);
				Transform transform = instance.transform;
				Transform parent = base.transform;
				transform.SetParent(parent, worldPositionStays: false);
			}
		}

		[Token(Token = "0x6000609")]
		[Address(RVA = "0x3DB2170", Offset = "0x3DB2170", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0017;\nL_0017:\n\tv51 = UnityEngine.Object::op_Inequality(instance, 0);\n\tv58 = ~v51;\n\tif (v58) goto L_0042;\n\tgoto L_0027;\nL_0027:\n\tUnityEngine.Object::Destroy(instance);\n\treturn;\nL_0042:\n\treturn;\n")]
		private void OnDestroyInstance(GameObject instance)
		{
			if (instance != null)
			{
				UnityEngine.Object.Destroy(instance);
			}
		}

		[Token(Token = "0x600060A")]
		[Address(RVA = "0x3DB17FC", Offset = "0x3DB17FC", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tgoto L_001B;\nL_001B:\n\tv60 = UnityEngine.Object::op_Equality(instance, 0);\n\tv70 = v60 == 0;\n\tif (v70) goto L_004C;\n\treturn;\nL_004C:\n\tv163 = UnityEngine.GameObject::GetComponent(instance);\n\tgoto L_0055;\nL_0055:\n\tv188 = UnityEngine.Object::op_Equality(v163, 0);\n\tv191 = v188 == 0;\n\tif (v191) goto L_0069;\n\tgoto L_009D;\nL_0069:\n\tgoto L_006D;\nL_006D:\n\tv207 = UnityEngine.Object::op_Equality(v163.PrefabKey, 0);\n\tv211 = v207 == 0;\n\tif (v211) goto L_0083;\n\tgoto L_009D;\nL_0083:\n\tv209 = System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>>::TryGetValue(this._pools, v163.PrefabKey, &v132 @ stack_-48_v4 (UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>));\n\tv213 = v209 == 0;\n\tif (v213) goto L_009D;\n\tv128 = UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>::Release(v132, instance);\n\treturn;\nL_009D:\n\tgoto L_00A1;\nL_00A1:\n\tUnityEngine.Object::Destroy(instance);\n\treturn;\n")]
		private void ReleaseToPool(GameObject instance)
		{
			if (!(instance == null))
			{
				PooledVfxBehaviour component = instance.GetComponent<PooledVfxBehaviour>();
				if (!(component == null) && !(component.PrefabKey == null) && _pools.TryGetValue(component.PrefabKey, out var value))
				{
					value.Release(instance);
				}
				else
				{
					UnityEngine.Object.Destroy(instance);
				}
			}
		}

		[Token(Token = "0x600060B")]
		[Address(RVA = "0x3DB2240", Offset = "0x3DB2240", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv72 = new System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, _game.CoreSystem.Pooling.VfxPoolService+PrewarmSettings>();\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.GameObject, _game.CoreSystem.Pooling.VfxPoolService+PrewarmSettings>::.ctor(v72);\n\tthis._settings = v72;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_0028:\n\tv56 = new System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>>();\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.GameObject, UnityEngine.Pool.ObjectPool`1<UnityEngine.GameObject>>::.ctor(v56);\n\tthis._pools = v56;\n")]
		public VfxPoolService()
		{
			Dictionary<GameObject, ObjectPool<GameObject>> pools = new Dictionary<GameObject, ObjectPool<GameObject>>();
			_pools = pools;
			Dictionary<GameObject, PrewarmSettings> settings = new Dictionary<GameObject, PrewarmSettings>();
			_settings = settings;
		}
	}
}
