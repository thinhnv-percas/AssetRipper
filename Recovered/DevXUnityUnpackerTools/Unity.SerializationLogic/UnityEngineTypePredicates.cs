using Mono.Cecil;
using System.Collections.Generic;
using Unity.CecilTools.Extensions;

namespace Unity.SerializationLogic
{
	public class UnityEngineTypePredicates
	{
		internal static readonly HashSet<string> _0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020 = new HashSet<string>
		{
			"Vector3",
			"Vector2",
			"Vector4",
			"Rect",
			"RectInt",
			"Quaternion",
			"Matrix4x4",
			"Color",
			"Color32",
			"LayerMask",
			"Bounds",
			"BoundsInt",
			"Vector3Int",
			"Vector2Int"
		};

		internal const string _0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_000A = "UnityEngine.AnimationCurve";

		internal const string _0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020 = "UnityEngine.Gradient";

		internal const string _0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_000A = "UnityEngine.GUIStyle";

		internal const string _0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020 = "UnityEngine.RectOffset";

		internal const string UnityEngineObject = "UnityEngine.Object";

		public const string MonoBehaviour = "UnityEngine.MonoBehaviour";

		public const string ScriptableObject = "UnityEngine.ScriptableObject";

		internal const string Matrix4x4 = "UnityEngine.Matrix4x4";

		internal const string Color32 = "UnityEngine.Color32";

		internal const string _0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A = "UnityEngine.SerializeField";

		internal static string[] _0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020 = new string[7]
		{
			"UnityEngine.AnimationCurve",
			"UnityEngine.Color32",
			"UnityEngine.Gradient",
			"UnityEngine.GUIStyle",
			"UnityEngine.RectOffset",
			"UnityEngine.Matrix4x4",
			"UnityEngine.PropertyName"
		};

		public static bool IsMonoBehaviour(TypeReference type)
		{
			return _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A(type.CheckedResolve());
		}

		internal static bool _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A(TypeDefinition _0020)
		{
			return _0020.IsSubclassOf("UnityEngine.MonoBehaviour");
		}

		public static bool IsScriptableObject(TypeReference type)
		{
			return _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(type.CheckedResolve());
		}

		internal static bool _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(TypeDefinition _0020)
		{
			return _0020.IsSubclassOf("UnityEngine.ScriptableObject");
		}

		public static bool IsColor32(TypeReference type)
		{
			return type.IsAssignableTo("UnityEngine.Color32");
		}

		public static bool IsMatrix4x4(TypeReference type)
		{
			return type.IsAssignableTo("UnityEngine.Matrix4x4");
		}

		public static bool IsGradient(TypeReference type)
		{
			return type.IsAssignableTo("UnityEngine.Gradient");
		}

		public static bool IsGUIStyle(TypeReference type)
		{
			return type.IsAssignableTo("UnityEngine.GUIStyle");
		}

		public static bool IsRectOffset(TypeReference type)
		{
			return type.IsAssignableTo("UnityEngine.RectOffset");
		}

		public static bool IsSerializableUnityStruct(TypeReference type)
		{
			string[] array = _0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020;
			foreach (string typeName in array)
			{
				if (type.IsAssignableTo(typeName))
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsUnityEngineObject(TypeReference type)
		{
			if (type.IsArray)
			{
				return false;
			}
			if (type.FullName == "UnityEngine.Object")
			{
				return true;
			}
			TypeDefinition typeDefinition = type.Resolve();
			if (typeDefinition == null)
			{
				typeDefinition = _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020._0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_00602(type);
			}
			return typeDefinition?.IsSubclassOf("UnityEngine.Object") ?? false;
		}

		public static bool ShouldHaveHadSerializableAttribute(TypeReference type)
		{
			return IsUnityEngineValueType(type);
		}

		public static bool IsUnityEngineValueType(TypeReference type)
		{
			if (type.SafeNamespace() == "UnityEngine")
			{
				return _0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020.Contains(type.Name);
			}
			return false;
		}

		public static bool IsSerializeFieldAttribute(TypeReference attributeType)
		{
			return attributeType.FullName == "UnityEngine.SerializeField";
		}
	}
}
