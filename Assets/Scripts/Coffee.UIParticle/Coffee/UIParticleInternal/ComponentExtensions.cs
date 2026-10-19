using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Coffee.UIParticleInternal
{
	[Token(Token = "0x2000006")]
	internal static class ComponentExtensions
	{
		[Token(Token = "0x600000F")]
		[Address(RVA = "0x4856190", Offset = "0x4856190", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv24 = 0x220C2B8(methodInfo, depth, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv54 = System.Collections.Generic.List`1<T>::ToArray(v42);\n\tCoffee.UIParticleInternal.InternalListPool`1<T>::Return(&v44 @ stack_-38_v1 (System.Collections.Generic.List`1<T>));\n\treturn v54;\nL_0013:\n\tv42 = Coffee.UIParticleInternal.InternalListPool`1<T>::Rent();\n\tv44 = v42;\n\tCoffee.UIParticleInternal.ComponentExtensions::GetComponentsInChildren_Internal(self, v42, depth);\n")]
		public static T[] GetComponentsInChildren<T>(this Component self, int depth) where T : Component
		{
			List<T> list = InternalListPool<T>.Rent();
			List<T> toRelease = list;
			self.GetComponentsInChildren_Internal(list, depth);
			T[] result = list.ToArray();
			InternalListPool<T>.Return(ref toRelease);
			return result;
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x4856230", Offset = "0x4856230", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv26 = 0x220C2B8(methodInfo, results, depth, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0016:\n\t;\n\tSystem.Collections.Generic.List`1<T>::Clear(results);\n\tv54 = results.Count < 1;\n\tif (v54) goto L_0035;\nL_0035:\n\tCoffee.UIParticleInternal.ComponentExtensions::GetComponentsInChildren_Internal(self, results, depth);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void GetComponentsInChildren<T>(this Component self, List<T> results, int depth) where T : Component
		{
			results.Clear();
			if (results.Count >= 1)
			{
			}
			self.GetComponentsInChildren_Internal(results, depth);
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x48562B0", Offset = "0x48562B0", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tgoto L_001E;\nL_001E:\n\tgoto L_0021;\nL_0021:\n\tv65 = UnityEngine.Object::op_Implicit(self);\n\tv73 = ~v65;\n\tv74 = ~v73;\n\tif (v74) goto L_0036;\n\tgoto L_00A5;\n\tv72 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0021;\nL_0036:\n\tv87 = results == 0;\n\tif (v87) goto L_00A5;\n\tv205 = depth & 0x80000000;\n\tv206 = v205 == 0;\n\tv185 = ~v206;\n\tif (v185) goto L_00A5;\n\tv247 = UnityEngine.Component::get_transform(self);\n\tgoto L_004E;\n\tv261 = 0x220C2B8(Il2CppMethodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_004E:\n\tv250 = UnityEngine.Component::get_gameObject(v247);\n\tv251 = UnityEngine.GameObject::TryGetComponent(v250, &v177 @ stack_-48_v4 (T));\n\tv266 = ~v251;\n\tif (v266) goto L_0073;\n\tgoto L_00AA;\nL_0073:\n\tv186 = depth == 0;\n\tif (v186) goto L_00A5;\nL_0077:\n\tv181 = UnityEngine.Transform::get_childCount(v247);\n\tv95 = v181 < 1;\n\tif (v95) goto L_00A5;\n\tv196 = depth - 1;\n\tv294 = 0;\nL_00A5:\n\treturn;\nL_00AA:\n\tSystem.Collections.Generic.List`1<T>::Add(results, v177);\n\tv291 = depth == 0;\n\tv187 = ~v291;\n\tif (v187) goto L_0077;\n\tgoto L_00A5;\nL_008A:\n\tv179 = UnityEngine.Transform::GetChild(v247, v294);\n\tCoffee.UIParticleInternal.ComponentExtensions::GetComponentsInChildren_Internal(v179, results, v196);\n\tv294 = v294 + 1;\n\tv93 = v181 != v294;\n\tif (v93) goto L_008A;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void GetComponentsInChildren_Internal<T>(this Component self, List<T> results, int depth) where T : Component
		{
			//IL_0084: Expected I4, but got I8
			if (!self || results == null || (int)(depth & 0x80000000L) != 0)
			{
				return;
			}
			Transform transform = self.transform;
			GameObject gameObject = transform.gameObject;
			if (!gameObject.TryGetComponent<T>(out var component))
			{
				if (depth == 0)
				{
					return;
				}
			}
			else
			{
				results.Add(component);
				if (depth == 0)
				{
					return;
				}
			}
			int childCount = transform.childCount;
			if (childCount >= 1)
			{
				int depth2 = depth - 1;
				int num = 0;
				do
				{
					Transform child = transform.GetChild(num);
					child.GetComponentsInChildren_Internal(results, depth2);
					num++;
				}
				while (childCount != num);
			}
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x4856480", Offset = "0x4856480", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tgoto L_001A;\nL_001A:\n\tgoto L_001D;\nL_001D:\n\tv59 = UnityEngine.Object::op_Implicit(self);\n\tv69 = ~v59;\n\tv70 = ~v69;\n\tif (v70) goto L_0044;\n\treturn 0;\n\tv66 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_001D;\nL_0044:\n\tgoto L_0049;\n\tv150 = 0x220C2B8(Il2CppMethodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0049:\n\tv146 = UnityEngine.Component::get_gameObject(self);\n\tv153 = UnityEngine.GameObject::TryGetComponent(v146, &v115 @ stack_-38_v3 (T));\n\tv122 = v153 == 0;\n\tif (v122) goto L_005E;\n\treturn v115;\nL_005E:\n\tv147 = UnityEngine.Component::get_gameObject(self);\n\treturnVal4 = UnityEngine.GameObject::AddComponent(v147);\n\treturn returnVal4;\n")]
		public static T GetOrAddComponent<T>(this Component self) where T : Component
		{
			if (!self)
			{
				return null;
			}
			GameObject gameObject = self.gameObject;
			if (gameObject.TryGetComponent<T>(out var component))
			{
				return component;
			}
			GameObject gameObject2 = self.gameObject;
			return gameObject2.AddComponent<T>();
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x48565C4", Offset = "0x48565C4", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tgoto L_0020;\n\tv113 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0020:\n\tv55 = UnityEngine.Component::get_transform(v43);\n\tv96 = v55;\n\tv153 = 0;\n\tgoto L_002D;\nL_002D:\n\tv101 = UnityEngine.Object::op_Implicit(v96);\n\tv191 = v101 == 0;\n\tif (v191) goto L_0069;\n\tgoto L_003D;\n\tv202 = 0x220C2B8(Il2CppMethodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_003D:\n\tv102 = UnityEngine.Component::get_gameObject(v96);\n\tv207 = UnityEngine.GameObject::TryGetComponent(v102, &v142 @ stack_-48_v4 (T));\n\tv134 = v207 == 0;\n\tv124 = ~v134;\n\tv122 = ~v124;\n\tif (v122) goto L_0057;\n\tv153 = v142;\n\tgoto L_0057;\nL_0069:\n\treturn v153;\nL_0057:\n\tv213 = UnityEngine.Transform::get_parent(v96);\n\tv96 = v213;\n\tgoto L_002D;\n")]
		public static T GetRootComponent<T>(this Component self) where T : Component
		{
			Component component = default(Component);
			Transform transform = component.transform;
			Transform transform2 = transform;
			T result = null;
			while ((bool)transform2)
			{
				GameObject gameObject = transform2.gameObject;
				if (gameObject.TryGetComponent<T>(out var component2))
				{
					result = component2;
				}
				Transform parent = transform2.parent;
				transform2 = parent;
			}
			return result;
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x4855FE4", Offset = "0x4855FE4", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tgoto L_001D;\nL_001D:\n\tv55 = includeSelf == 0;\n\tv66 = v58;\n\tif (v55) goto L_0037;\nL_0022:\n\tv74 = UnityEngine.Component::get_transform(v58);\n\tv134 = v74;\n\tgoto L_0075;\n\tv72 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv109 = includeSelf == 0;\n\tv62 = ~v109;\n\tv66 = v58;\n\tif (v62) goto L_0022;\nL_0037:\n\tv157 = UnityEngine.Component::get_transform(v66);\n\tv136 = v157 == 0;\n\tv97 = ~v136;\n\tif (v97) goto L_006B;\n\tv107 = new System.NullReferenceException();\n\tv106 = includeSelf;\nL_0043:\n\tgoto L_0048;\n\tv172 = 0x220C2B8(Il2CppMethodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0048:\n\tv91 = UnityEngine.Component::get_gameObject(v106);\n\tv92 = UnityEngine.GameObject::TryGetComponent(v91, &v87 @ stack_-48_v6 (T));\n\tv225 = ~v92;\n\tif (v225) goto L_005F;\n\tv229 = System.Predicate`1<T>::Invoke(valid, v87);\n\tv236 = v229 == 0;\n\tv212 = ~v236;\n\tif (v212) goto L_0098;\nL_005F:\n\tgoto L_0064;\nL_0064:\n\tv184 = UnityEngine.Object::op_Equality(v106, stopAfter);\n\tv241 = v184 == 0;\n\tv160 = ~v241;\n\tif (v160) goto L_008D;\n\tv157 = v106;\nL_0075:\n\tv125 = UnityEngine.Object::op_Implicit(v134);\n\tv170 = v125 == 0;\n\tv130 = ~v170;\n\tv106 = v134;\n\tif (v130) goto L_0043;\n\tgoto L_008D;\nL_008D:\n\treturn 0;\nL_0098:\n\treturn v87;\nL_006B:\n\tv164 = UnityEngine.Transform::get_parent(v157);\n\tv134 = v164;\n\tgoto L_0075;\n")]
		public static T GetComponentInParent<T>(this Component self, bool includeSelf, Transform stopAfter, Predicate<T> valid) where T : Component
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ComponentExtensions::GetComponentInParent");
			return default;
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x4855DD8", Offset = "0x4855DD8", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv59 = 0;\n\tgoto L_0024;\nL_0024:\n\tv70 = UnityEngine.Object::op_Equality(self, 0);\n\tv79 = v70 == 0;\n\tif (v79) goto L_003C;\n\tgoto L_00C0;\n\tv77 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv59 = 0;\n\tgoto L_0024;\nL_003C:\n\tv94 = ~includeSelf;\n\tif (v94) goto L_0067;\n\tgoto L_004A;\n\tv250 = 0x220C2B8(Il2CppMethodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_004A:\n\tv218 = UnityEngine.Component::get_gameObject(self);\n\tv245 = UnityEngine.GameObject::TryGetComponent(v218, &v59 @ stack_-58_v4 (T));\n\tv256 = v245 == 0;\n\tv247 = ~v256;\n\tif (v247) goto L_0067;\n\tv219 = UnityEngine.Component::get_gameObject(self);\n\tv220 = UnityEngine.GameObject::AddComponent(v219);\n\tUnityEngine.Object::set_hideFlags(v220, hideFlags);\n\tgoto L_0067;\nL_0067:\n\tv221 = UnityEngine.Component::get_transform(self);\n\tv161 = UnityEngine.Transform::get_childCount(v221);\n\tv109 = v161 < 1;\n\tif (v109) goto L_00C0;\nL_FFFFFFFF:\n\tv194 = 0;\n\tgoto L_008B;\nL_007D:\n\tUnityEngine.Object::set_hideFlags(v217, hideFlags);\nL_007E:\n\tv194 = v194 + 1;\n\tv134 = v161 == v194;\n\tif (v134) goto L_00C0;\nL_008B:\n\tv222 = UnityEngine.Component::get_transform(self);\n\tv223 = UnityEngine.Transform::GetChild(v222, v194);\n\tgoto L_009E;\n\tv267 = 0x220C2B8(Il2CppMethodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_009E:\n\tv224 = UnityEngine.Component::get_gameObject(v223);\n\tv271 = UnityEngine.GameObject::TryGetComponent(v224, &v59 @ stack_-58_v4 (T));\n\tv273 = v271 == 0;\n\tv274 = ~v273;\n\tif (v274) goto L_007E;\n\tv225 = UnityEngine.Component::get_gameObject(v223);\n\tv217 = UnityEngine.GameObject::AddComponent(v225);\n\tv279 = v217 == 0;\n\tv226 = ~v279;\n\tif (v226) goto L_007D;\n\tthrow System.NullReferenceException;\nL_00C0:\n\treturn;\n")]
		public static void AddComponentOnChildren<T>(this Component self, HideFlags hideFlags, bool includeSelf) where T : Component
		{
			T component = null;
			if (self == null)
			{
				return;
			}
			if (includeSelf)
			{
				GameObject gameObject = self.gameObject;
				if (!gameObject.TryGetComponent<T>(out component))
				{
					GameObject gameObject2 = self.gameObject;
					UnityEngine.Object obj = gameObject2.AddComponent<T>();
					obj.hideFlags = hideFlags;
				}
			}
			Transform transform = self.transform;
			int childCount = transform.childCount;
			if (childCount < 1)
			{
				return;
			}
			int num = 0;
			do
			{
				Transform transform2 = self.transform;
				Transform child = transform2.GetChild(num);
				GameObject gameObject3 = child.gameObject;
				if (!gameObject3.TryGetComponent<T>(out component))
				{
					GameObject gameObject4 = child.gameObject;
					UnityEngine.Object obj2 = gameObject4.AddComponent<T>();
					if ((object)obj2 == null)
					{
						throw new NullReferenceException();
					}
					obj2.hideFlags = hideFlags;
				}
				num++;
			}
			while (childCount != num);
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x4855BF8", Offset = "0x4855BF8", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv54 = 0;\n\tgoto L_0021;\nL_0021:\n\tv65 = UnityEngine.Object::op_Equality(self, 0);\n\tv74 = v65 == 0;\n\tif (v74) goto L_0039;\n\tgoto L_00B1;\n\tv72 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv54 = 0;\n\tgoto L_0021;\nL_0039:\n\tv89 = ~includeSelf;\n\tif (v89) goto L_005F;\n\tgoto L_0047;\n\tv235 = 0x220C2B8(Il2CppMethodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0047:\n\tv208 = UnityEngine.Component::get_gameObject(self);\n\tv228 = UnityEngine.GameObject::TryGetComponent(v208, &v54 @ stack_-48_v4 (T));\n\tv241 = v228 == 0;\n\tv231 = ~v241;\n\tif (v231) goto L_005F;\n\tv209 = UnityEngine.Component::get_gameObject(self);\n\tv229 = UnityEngine.GameObject::AddComponent(v209);\n\tgoto L_005F;\nL_005F:\n\tv210 = UnityEngine.Component::get_transform(self);\n\tv156 = UnityEngine.Transform::get_childCount(v210);\n\tv104 = v156 < 1;\n\tif (v104) goto L_00B1;\nL_FFFFFFFF:\n\tv187 = 0;\n\tgoto L_0083;\nL_0075:\n\tv262 = UnityEngine.GameObject::AddComponent(v207);\nL_0076:\n\tv187 = v187 + 1;\n\tv129 = v156 == v187;\n\tif (v129) goto L_00B1;\nL_0083:\n\tv211 = UnityEngine.Component::get_transform(self);\n\tv212 = UnityEngine.Transform::GetChild(v211, v187);\n\tgoto L_0096;\n\tv252 = 0x220C2B8(Il2CppMethodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0096:\n\tv213 = UnityEngine.Component::get_gameObject(v212);\n\tv256 = UnityEngine.GameObject::TryGetComponent(v213, &v54 @ stack_-48_v4 (T));\n\tv258 = v256 == 0;\n\tv259 = ~v258;\n\tif (v259) goto L_0076;\n\tv207 = UnityEngine.Component::get_gameObject(v212);\n\tv265 = v207 == 0;\n\tv214 = ~v265;\n\tif (v214) goto L_0075;\n\tthrow System.NullReferenceException;\nL_00B1:\n\treturn;\n")]
		public static void AddComponentOnChildren<T>(this Component self, bool includeSelf) where T : Component
		{
			T component = null;
			if (self == null)
			{
				return;
			}
			if (includeSelf)
			{
				GameObject gameObject = self.gameObject;
				if (!gameObject.TryGetComponent<T>(out component))
				{
					GameObject gameObject2 = self.gameObject;
					T val = gameObject2.AddComponent<T>();
				}
			}
			Transform transform = self.transform;
			int childCount = transform.childCount;
			if (childCount < 1)
			{
				return;
			}
			int num = 0;
			do
			{
				Transform transform2 = self.transform;
				Transform child = transform2.GetChild(num);
				GameObject gameObject3 = child.gameObject;
				if (!gameObject3.TryGetComponent<T>(out component))
				{
					GameObject gameObject4 = child.gameObject;
					if ((object)gameObject4 == null)
					{
						throw new NullReferenceException();
					}
					T val2 = gameObject4.AddComponent<T>();
				}
				num++;
			}
			while (childCount != num);
		}
	}
}
