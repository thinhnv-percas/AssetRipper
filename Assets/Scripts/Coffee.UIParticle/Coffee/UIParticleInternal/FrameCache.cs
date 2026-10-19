using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Coffee.UIParticleInternal
{
	[Token(Token = "0x200000F")]
	internal static class FrameCache
	{
		[Token(Token = "0x2000010")]
		private interface IFrameCache
		{
			[Token(Token = "0x600003A")]
			void Clear();
		}

		[Token(Token = "0x2000011")]
		private class FrameCacheContainer<T> : IFrameCache
		{
			[Token(Token = "0x4000010")]
			[FieldOffset(Offset = "0x0")]
			private readonly Dictionary<(int, int), T> _caches;

			[Token(Token = "0x600003B")]
			[Address(RVA = "0x52E9380", Offset = "0x52E9380", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, UnityEngine.Matrix4x4>::Clear(this._caches);\n\treturn;\n")]
			public void Clear()
			{
				_caches.Clear();
			}

			[Token(Token = "0x600003C")]
			[Address(RVA = "0x52E93A4", Offset = "0x52E93A4", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = System.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, UnityEngine.Matrix4x4>::TryGetValue(this._caches, key, result);\n\treturn returnVal1;\n")]
			public bool TryGet((int, int) key, out T result)
			{
				result = default(T);
				return _caches.TryGetValue(key, out result);
			}

			[Token(Token = "0x600003D")]
			[Address(RVA = "0x52E93C8", Offset = "0x52E93C8", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = result->klass;\n\tSystem.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, UnityEngine.Matrix4x4>::set_Item(this._caches, key, &v16 @ stack_-50_v1 (Il2CppClass<T>));\n\treturn;\n")]
			public void Set((int, int) key, T result)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FrameCache.FrameCacheContainer::Set");
			}

			[Token(Token = "0x600003E")]
			[Address(RVA = "0x52E9410", Offset = "0x52E9410", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tv42 = new Il2CppClass<System.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, T>>();\n\tSystem.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, UnityEngine.Matrix4x4>::.ctor(v42);\n\tthis._caches = v42;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public FrameCacheContainer()
			{
				Dictionary<(int, int), Matrix4x4> caches = new Dictionary<(int, int), Matrix4x4>();
				_caches = (Dictionary<(int, int), T>)(object)caches;
			}
		}

		[Token(Token = "0x400000F")]
		private static readonly Dictionary<Type, IFrameCache> s_Caches;

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x3F1FBB8", Offset = "0x3F1FBB8", Length = "0x1B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tSystem.Collections.Generic.Dictionary`2<System.Type, Coffee.UIParticleInternal.FrameCache+IFrameCache>::Clear(v66.s_Caches);\n\tv107 = new System.Action();\n\tSystem.Action::.ctor(v107, 0, Il2CppMethodInfo);\n\tgoto L_0053;\nL_0053:\n\tgoto L_0057;\nL_0057:\n\tgoto L_0067;\nL_0067:\n\tCoffee.UIParticleInternal.FastActionBase`1<System.Action>::Add(v99.s_LateAfterCanvasRebuildAction, v107);\n\treturn;\nL_002C:\n\tv49 = new System.Collections.Generic.Dictionary`2<System.Type, Coffee.UIParticleInternal.FrameCache+IFrameCache>();\n\tSystem.Collections.Generic.Dictionary`2<System.Type, Coffee.UIParticleInternal.FrameCache+IFrameCache>::.ctor(v49);\n\tv59.s_Caches = v49;\n")]
		static FrameCache()
		{
			Dictionary<Type, IFrameCache> dictionary = new Dictionary<Type, IFrameCache>();
			s_Caches = dictionary;
			s_Caches.Clear();
			Action rhs = ClearAllCache;
			UIExtraCallbacks.s_LateAfterCanvasRebuildAction.Add(rhs);
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x49803E8", Offset = "0x49803E8", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tgoto L_0021;\nL_0021:\n\tgoto L_0025;\nL_0025:\n\tv70 = Coffee.UIParticleInternal.FrameCache::GetFrameCache();\n\tv79 = System.Object::GetHashCode(key1);\n\tv109 = System.String::GetHashCode(key2);\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v85 @ stack_-48_v3 (System.ValueTuple`2<System.Int32, System.Int32>), v79, v109);\n\treturnVal2 = Coffee.UIParticleInternal.FrameCache+FrameCacheContainer`1<T>::TryGet(v70, v85, result);\n\treturn returnVal2;\n\tv73 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0025;\n")]
		public static bool TryGet<T>(object key1, string key2, out T result)
		{
			result = default(T);
			FrameCacheContainer<T> frameCache = GetFrameCache<T>();
			int hashCode = key1.GetHashCode();
			int hashCode2 = key2.GetHashCode();
			(int, int) key3 = (hashCode, hashCode2);
			return frameCache.TryGet(key3, out result);
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x4980628", Offset = "0x4980628", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tgoto L_0022;\nL_0022:\n\tgoto L_0026;\nL_0026:\n\tv71 = Coffee.UIParticleInternal.FrameCache::GetFrameCache();\n\tv80 = System.Object::GetHashCode(key1);\n\tv111 = System.String::GetHashCode(key2);\n\tv83 = v111 + key3;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v88 @ stack_-48_v3 (System.ValueTuple`2<System.Int32, System.Int32>), v80, v83);\n\treturnVal2 = Coffee.UIParticleInternal.FrameCache+FrameCacheContainer`1<T>::TryGet(v71, v88, result);\n\treturn returnVal2;\n\tv74 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0026;\n")]
		public static bool TryGet<T>(object key1, string key2, int key3, out T result)
		{
			result = default(T);
			FrameCacheContainer<T> frameCache = GetFrameCache<T>();
			int hashCode = key1.GetHashCode();
			int hashCode2 = key2.GetHashCode();
			int item = hashCode2 + key3;
			(int, int) key4 = (hashCode, item);
			return frameCache.TryGet(key4, out result);
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x497FE40", Offset = "0x497FE40", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tgoto L_0021;\nL_0021:\n\tgoto L_0025;\nL_0025:\n\tv70 = Coffee.UIParticleInternal.FrameCache::GetFrameCache();\n\tv79 = System.Object::GetHashCode(key1);\n\tv109 = System.String::GetHashCode(key2);\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v85 @ stack_-88_v3 (System.ValueTuple`2<System.Int32, System.Int32>), v79, v109);\n\tv126 = result->klass;\n\tCoffee.UIParticleInternal.FrameCache+FrameCacheContainer`1<T>::Set(v70, v85, &v126 @ stack_-80_v1 (Il2CppClass<T>));\n\treturn;\n\tv73 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0025;\n")]
		public static void Set<T>(object key1, string key2, T result)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameCache::Set");
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x498010C", Offset = "0x498010C", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tgoto L_0022;\nL_0022:\n\tgoto L_0026;\nL_0026:\n\tv71 = Coffee.UIParticleInternal.FrameCache::GetFrameCache();\n\tv80 = System.Object::GetHashCode(key1);\n\tv111 = System.String::GetHashCode(key2);\n\tv83 = v111 + key3;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v88 @ stack_-88_v3 (System.ValueTuple`2<System.Int32, System.Int32>), v80, v83);\n\tv126 = result->klass;\n\tCoffee.UIParticleInternal.FrameCache+FrameCacheContainer`1<T>::Set(v71, v88, &v126 @ stack_-80_v1 (Il2CppClass<T>));\n\treturn;\n\tv74 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0026;\n")]
		public static void Set<T>(object key1, string key2, int key3, T result)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameCache::Set");
		}

		[Token(Token = "0x6000038")]
		[Address(RVA = "0x3F1FE0C", Offset = "0x3F1FE0C", Length = "0x214")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv50 = 0;\n\tgoto L_0018;\nL_0018:\n\tv58 = v56.s_Caches == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_0044;\nL_FFFFFFFF:\n\tv131 = 0;\n\tgoto L_009E;\nL_0044:\n\tv82 = System.Collections.Generic.Dictionary`2<System.Type, Coffee.UIParticleInternal.FrameCache+IFrameCache>::get_Values(v56.s_Caches);\n\tv159 = v82 == 0;\nL_FFFFFFFF:\n\t;\n\tif (v159) goto L_009E;\n\tv178 = System.Collections.Generic.Dictionary`2<System.Type, Coffee.UIParticleInternal.FrameCache+IFrameCache>+ValueCollection<System.Type, Coffee.UIParticleInternal.FrameCache+IFrameCache>::GetEnumerator(v82);\n\tv156 = v178._dictionary;\n\tgoto L_0065;\nL_0062:\n\tCoffee.UIParticleInternal.FrameCache+IFrameCache::Clear(v178.Current);\n\tgoto L_0062;\nL_0093:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v156 @ stack_-48_v4 (System.Collections.Generic.Dictionary`2<System.Type, Coffee.UIParticleInternal.FrameCache+IFrameCache>));\nL_009B:\n\treturn;\nL_00AB:\n\tv192 = Il2CppMethodInfo != 1;\nL_FFFFFFFF:\n\tv206 = v166;\n\tif (v192) goto L_00BB;\n\tv197 = 0x8BF5BC4(v166, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv238 = 0x8BF5BF4(v197, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v50 @ stack_-48_v7 (System.Int32));\n\tv205 = *([v197 @ X0_v10]) == 0;\n\tif (v205) goto L_009B;\n\tv203 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv131 = *([v197 @ X0_v10]);\nL_FFFFFFFF:\n\tv206 = v203;\n\treturn;\nL_009E:\n\tv166 = new System.NullReferenceException();\n\tgoto L_00AB;\nL_0065:\n\tv233 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v156 @ stack_-48_v4 (System.Collections.Generic.Dictionary`2<System.Type, Coffee.UIParticleInternal.FrameCache+IFrameCache>));\n\tv242 = v233 == 0;\n\tif (v242) goto L_0093;\nL_00BB:\n\tv209 = 0x3191D84(&v131 @ stack_-58_v1 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv240 = 0x8BF0368(v206, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv246 = 0xA1B8(v240, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static void ClearAllCache()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameCache::ClearAllCache");
		}

		[Token(Token = "0x6000039")]
		[Address(RVA = "0x497F9FC", Offset = "0x497F9FC", Length = "0x220")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tgoto L_0025;\n\tv38 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0029:\n\tv60 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tgoto L_003D;\nL_003D:\n\tv84 = System.Collections.Generic.Dictionary`2<System.Type, Coffee.UIParticleInternal.FrameCache+IFrameCache>::TryGetValue(v74.s_Caches, v60, &v82 @ stack_-38_v3 (Coffee.UIParticleInternal.FrameCache+IFrameCache));\n\tv100 = ~v84;\n\tif (v100) goto L_0069;\n\tgoto L_004A;\nL_004A:\n\tv213 = v82 == 0;\n\tif (v213) goto L_00B7;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal3 = 0;\nL_0069:\n\tgoto L_006B;\nL_006B:\n\treturnVal3 = new Il2CppClass<Coffee.UIParticleInternal.FrameCache+FrameCacheContainer`1<T>>();\n\tCoffee.UIParticleInternal.FrameCache+FrameCacheContainer`1<T>::.ctor(returnVal3);\n\tgoto L_0081;\nL_0081:\n\tSystem.Collections.Generic.Dictionary`2<System.Type, Coffee.UIParticleInternal.FrameCache+IFrameCache>::Add(v98.s_Caches, v60, returnVal3);\n\tgoto L_0090;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v279_asT @ Z_v5 (Coffee.UIParticleInternal.FrameCache+FrameCacheContainer`1<T>), typeof(Coffee.UIParticleInternal.FrameCache+FrameCacheContainer`1<T>), returnVal3 @ X0_v12 (Coffee.UIParticleInternal.FrameCache+FrameCacheContainer`1<T>)\n\tv279 = v279_asT != 0;\n\tif (v279) goto L_0061;\n\tthrow System.InvalidCastException;\nL_00B7:\n\treturn 0;\nL_FFFFFFFF:\n\t// -1 IsInst v118_asT @ TEMPCSEL_v1 (Coffee.UIParticleInternal.FrameCache+FrameCacheContainer`1<T>), typeof(Coffee.UIParticleInternal.FrameCache+FrameCacheContainer`1<T>), v82 @ stack_-38_v3 (Coffee.UIParticleInternal.FrameCache+IFrameCache)\n\tv118 = v118_asT == 0;\n\tif (v118) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal4 = v82;\n\tgoto L_00D2;\nL_FFFFFFFF:\n\treturnVal4 = 0;\nL_0025:\n\tgoto L_0029;\nL_0090:\n\tv260 = returnVal3 == 0;\n\tif (v260) goto L_0061;\nL_0061:\n\treturn returnVal3;\nL_00D2:\n\treturn returnVal4;\n")]
		private static FrameCacheContainer<T> GetFrameCache<T>()
		{
			Type typeFromHandle = typeof(T);
			if (s_Caches.TryGetValue(typeFromHandle, out var value))
			{
				if (value == null)
				{
					return null;
				}
				if (value is FrameCacheContainer<T>)
				{
					return (FrameCacheContainer<T>)value;
				}
				return null;
			}
			FrameCacheContainer<T> frameCacheContainer2 = new FrameCacheContainer<T>();
			s_Caches.Add(typeFromHandle, frameCacheContainer2);
			if (frameCacheContainer2 != null)
			{
				FrameCacheContainer<T> frameCacheContainer3 = frameCacheContainer2 as FrameCacheContainer<T>;
				if (frameCacheContainer3 == null)
				{
					throw new InvalidCastException();
				}
			}
			return frameCacheContainer2;
		}
	}
}
