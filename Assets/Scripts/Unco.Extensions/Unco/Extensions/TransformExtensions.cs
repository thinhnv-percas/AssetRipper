using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.Extensions
{
	[Token(Token = "0x200001B")]
	public static class TransformExtensions
	{
		[Token(Token = "0x60000A5")]
		[Address(RVA = "0x81AAE50", Offset = "0x81AAE50", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.GameObject::set_layer(go, layer);\n\tv122 = UnityEngine.GameObject::get_transform(go);\n\tv49 = 0;\n\tv58 = UnityEngine.GameObject::get_transform(go);\n\tv59 = UnityEngine.Transform::GetChild(v58, v49);\n\tv126 = UnityEngine.Component::get_gameObject(v59);\n\tUnco.Extensions.TransformExtensions::SetLayerRecursive(v126, layer);\n\tv49 = v49 + 1;\n\tv122 = UnityEngine.GameObject::get_transform(go);\n\tv129 = v122 == 0;\n\tv67 = ~v129;\n\tif (v67) goto L_0015;\n\tthrow System.NullReferenceException;\nL_003E:\n\treturn;\nL_0015:\n\tv99 = UnityEngine.Transform::get_childCount(v122);\n\tv21 = v49 >= v99;\n\tif (v21) goto L_003E;\n")]
		public static void SetLayerRecursive(this GameObject go, int layer)
		{
			go.layer = layer;
			Transform transform = go.transform;
			int num = 0;
			while (true)
			{
				int childCount = transform.childCount;
				if (num < childCount)
				{
					Transform transform2 = go.transform;
					Transform child = transform2.GetChild(num);
					GameObject gameObject = child.gameObject;
					gameObject.SetLayerRecursive(layer);
					num++;
					transform = go.transform;
					if ((object)transform == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x60000A6")]
		[Address(RVA = "0x81AAEF0", Offset = "0x81AAEF0", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\tv50 = UnityEngine.Transform::get_childCount(transform);\n\tv105 = v50 < 1;\n\tif (v105) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv93 = 0;\n\tv203 = UnityEngine.Object::get_name(v87);\n\tv198 = System.String::op_Equality(v203, name);\n\tv205 = v198 == 0;\n\tv200 = ~v205;\nL_FFFFFFFF:\n\tv192 = v87;\n\tif (v200) goto L_0068;\n\tv208 = Unco.Extensions.TransformExtensions::FindRecursive(v87, name);\n\tgoto L_0048;\nL_0048:\n\tv199 = UnityEngine.Object::op_Inequality(v208, 0);\n\tv216 = v199 == 0;\n\tv136 = ~v216;\nL_FFFFFFFF:\n\tv192 = v208;\n\tif (v136) goto L_0068;\n\tv93 = v93 + 1;\n\tv134 = UnityEngine.Transform::get_childCount(transform);\n\tv114 = v93 < v134;\n\tif (v114) goto L_002E;\nL_FFFFFFFF:\n\tv192 = 0;\nL_0068:\n\treturn v192;\nL_002E:\n\tv87 = UnityEngine.Transform::GetChild(transform, v93);\n")]
		public static Transform FindRecursive(this Transform transform, string name)
		{
			int childCount = transform.childCount;
			if (childCount < 1)
			{
				goto IL_011b;
			}
			int num = 0;
			Transform result;
			while (true)
			{
				Transform child = transform.GetChild(num);
				string name2 = child.name;
				bool flag = name2 == name;
				bool flag2 = !flag;
				bool flag3 = !flag2;
				result = child;
				if (flag3)
				{
					break;
				}
				Transform transform2 = child.FindRecursive(name);
				bool flag4 = transform2 != null;
				bool flag5 = !flag4;
				bool flag6 = !flag5;
				result = transform2;
				if (flag6)
				{
					break;
				}
				num++;
				int childCount2 = transform.childCount;
				if (num < childCount2)
				{
					continue;
				}
				goto IL_011b;
			}
			goto IL_0125;
			IL_0125:
			return result;
			IL_011b:
			result = null;
			goto IL_0125;
		}

		[Token(Token = "0x60000A7")]
		[Address(RVA = "0x81AAFEC", Offset = "0x81AAFEC", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = UnityEngine.Transform::get_childCount(transform);\n\tv88 = v18 < 1;\n\tif (v88) goto L_004A;\n\tv23 = 0;\n\tv25 = 0;\n\tv55 = UnityEngine.Component::get_gameObject(v54);\n\tv144 = UnityEngine.GameObject::get_activeInHierarchy(v55);\n\tv23 = v23 + v144;\n\tv25 = v25 + 1;\n\tv139 = UnityEngine.Transform::get_childCount(transform);\n\tv109 = v25 < v139;\n\tif (v109) goto L_001E;\n\treturn v23;\nL_004A:\n\treturn 0;\nL_001E:\n\tv54 = UnityEngine.Transform::GetChild(transform, v25);\n")]
		public static int GetActiveChildCount(this Transform transform)
		{
			int childCount = transform.childCount;
			if (childCount >= 1)
			{
				int num = 0;
				int num2 = 0;
				int childCount2;
				do
				{
					Transform child = transform.GetChild(num2);
					GameObject gameObject = child.gameObject;
					bool activeInHierarchy = gameObject.activeInHierarchy;
					num += (activeInHierarchy ? 1 : 0);
					num2++;
					childCount2 = transform.childCount;
				}
				while (num2 < childCount2);
				return num;
			}
			return 0;
		}

		[Token(Token = "0x60000A8")]
		[Address(RVA = "0x81AB090", Offset = "0x81AB090", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = UnityEngine.Transform::get_childCount(transform);\n\tv90 = v20 < 1;\n\tif (v90) goto L_004B;\n\tv25 = 0;\n\tv27 = 0;\n\tv57 = UnityEngine.Component::get_gameObject(v56);\n\tv170 = UnityEngine.GameObject::get_activeInHierarchy(v57);\n\tv25 = v25 + v170;\n\tv146 = v25 == index;\n\tif (v146) goto L_0056;\n\tv27 = v27 + 1;\n\tv117 = UnityEngine.Transform::get_childCount(transform);\n\tv99 = v27 < v117;\n\tif (v99) goto L_001F;\nL_004B:\n\treturn 0;\nL_0056:\n\treturnVal3 = UnityEngine.Transform::GetChild(transform, index);\n\treturn returnVal3;\nL_001F:\n\tv56 = UnityEngine.Transform::GetChild(transform, v27);\n")]
		public static Transform GetActiveChild(this Transform transform, int index)
		{
			int childCount = transform.childCount;
			if (childCount >= 1)
			{
				int num = 0;
				int num2 = 0;
				int childCount2;
				do
				{
					Transform child = transform.GetChild(num2);
					GameObject gameObject = child.gameObject;
					bool activeInHierarchy = gameObject.activeInHierarchy;
					num += (activeInHierarchy ? 1 : 0);
					if (num != index)
					{
						num2++;
						childCount2 = transform.childCount;
						continue;
					}
					return transform.GetChild(index);
				}
				while (num2 < childCount2);
			}
			return null;
		}

		[Token(Token = "0x60000A9")]
		[Address(RVA = "0x81AB144", Offset = "0x81AB144", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv45 = UnityEngine.Transform::get_childCount(transform);\n\tv96 = v45 < 1;\n\tif (v96) goto L_0055;\n\tv169 = v45;\n\tgoto L_0036;\nL_0028:\n\tUnityEngine.Object::Destroy(v175);\n\tv111 = v169 <= 0;\n\tif (v111) goto L_0055;\nL_0036:\n\tv169 = v169 - 1;\n\tv85 = UnityEngine.Transform::GetChild(transform, v169);\n\tUnityEngine.Transform::SetParent(v85, 0);\n\tv175 = UnityEngine.Component::get_gameObject(v85);\n\tgoto L_0028;\nL_0055:\n\treturn;\n")]
		public static void DeleteAllChildren(this Transform transform)
		{
			int childCount = transform.childCount;
			if (childCount >= 1)
			{
				int num = childCount;
				do
				{
					num--;
					Transform child = transform.GetChild(num);
					child.SetParent(null);
					GameObject gameObject = child.gameObject;
					UnityEngine.Object.Destroy(gameObject);
				}
				while (num > 0);
			}
		}

		[Token(Token = "0x60000AA")]
		[Address(RVA = "0x81AB218", Offset = "0x81AB218", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tv79 = UnityEngine.Transform::get_position(rect);\n\tgoto L_0033;\nL_0033:\n\t// 51 MakeStruct v84 @ AGG81AB2AC_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v79 @ V0_v2 (UnityEngine.Vector3), v79.y (System.Single), v79.z (System.Single)\n\tv85 = UnityEngine.RectTransformUtility::WorldToScreenPoint(uiCamera, v84);\n\treturnVal2 = Unco.Extensions.TransformExtensions::Vector2ToWorldOnYPlane(v85, uiCamera, groundY, worldPos);\n\treturn returnVal2;\n")]
		public static bool RectTransformToWorldOnYPlane(RectTransform rect, Camera uiCamera, float groundY, out Vector3 worldPos)
		{
			worldPos = default(Vector3);
			Vector3 position = rect.position;
			Vector3 worldPoint = default(Vector3);
			worldPoint.x = position.x;
			worldPoint.y = position.y;
			worldPoint.z = position.z;
			Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(uiCamera, worldPoint);
			return Vector2ToWorldOnYPlane(screenPoint, uiCamera, groundY, out worldPos);
		}

		[Token(Token = "0x60000AB")]
		[Address(RVA = "0x81AB2D8", Offset = "0x81AB2D8", Length = "0x218")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tgoto L_0020;\nL_0020:\n\tv64 = UnityEngine.Object::op_Inequality(uiCamera, 0);\n\tv72 = v64 == 0;\n\tif (v72) goto L_0096;\nL_FFFFFFFF:\n\tv99 = uiCamera;\nL_002D:\n\t// 45 MakeStruct v109 @ AGG81AB35C_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), screenPoint @ V0 (UnityEngine.Vector2), screenPoint.y (System.Single), 0\n\tv110 = UnityEngine.Camera::ScreenPointToRay(v99, v109);\n\tgoto L_004B;\n\tgoto L_0067;\nL_FFFFFFFF:\n\tv205 = v191;\n\tgoto L_FFFFFFFF;\nL_0096:\n\tv90 = UnityEngine.Camera::get_main();\n\tv118 = v90 == 0;\n\tv97 = ~v118;\nL_FFFFFFFF:\n\tv99 = v90;\n\tif (v97) goto L_002D;\n\tthrow System.NullReferenceException;\nL_009D:\n\tv208 = groundY - v207;\n\tv209 = v208 / v226;\n\tv210 = v209 < 0;\n\tv216 = ~v210;\n\tif (v216) goto L_00BA;\n\tgoto L_FFFFFFFF;\nL_00BA:\n\tv235 = v110.direction * v236;\n\tv237 = v110.m_Direction.z * v209;\n\tv292 = v110.origin + v235;\n\tv316 = v110.m_Origin.z + v237;\nL_FFFFFFFF:\n\treturnVal1 = 1;\nL_004B:\n\tv227 = UnityEngine.Mathf::Abs(v226);\n\tv241 = UnityEngine.Mathf::Max(v227, 0f);\n\tv205 = v241 * 0x358637BD;\n\tv191 = v329.Epsilon * 8f;\n\tv334 = v205 < v191;\n\tv335 = v205 == v191;\n\tv338 = v205 == v205;\n\tv339 = v191 == v191;\n\tv340 = v338 & v339;\n\tv341 = ~v340;\n\tv342 = v334 == v341;\n\tv141 = ~v335;\n\tv343 = v342 & v141;\n\tv138 = ~v343;\n\tif (v138) goto L_FFFFFFFF;\nL_0067:\n\t// 103 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv162 = v191 < v205;\n\tv144 = ~v162;\n\tif (v144) goto L_009D;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_00B8;\nL_FFFFFFFF:\n\treturnVal1 = 0;\nL_00B8:\n\tv316 = v307.zero.z;\nL_FFFFFFFF:\n\tv292 = v307.zero;\n\tgoto L_00BF;\nL_00BF:\n\tworldPos.x = v292;\n\tworldPos.z = v316;\n\treturn returnVal1;\n")]
		public static bool Vector2ToWorldOnYPlane(Vector2 screenPoint, Camera uiCamera, float groundY, out Vector3 worldPos)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TransformExtensions::Vector2ToWorldOnYPlane");
			worldPos = default;
			return default;
		}
	}
}
