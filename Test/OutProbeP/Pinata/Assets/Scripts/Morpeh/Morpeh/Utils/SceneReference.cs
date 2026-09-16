using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Morpeh.Utils
{
	[Serializable]
	[Token(Token = "0x2000039")]
	public class SceneReference : ISerializationCallbackReceiver
	{
		[SerializeField]
		[Token(Token = "0x4000062")]
		[FieldOffset(Offset = "0x10")]
		private string scenePath;

		[Token(Token = "0x1700001A")]
		public string ScenePath
		{
			[Token(Token = "0x60000EB")]
			[Address(RVA = "0x15F8B44", Offset = "0x15F8B44", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.scenePath;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ScenePath;
			}
			[Token(Token = "0x60000EC")]
			[Address(RVA = "0x15F8B4C", Offset = "0x15F8B4C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.scenePath = value;\n\treturn;\n")]
			set
			{
				ScenePath = value;
			}
		}

		[Token(Token = "0x60000ED")]
		[Address(RVA = "0x15F8B54", Offset = "0x15F8B54", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn sceneReference.scenePath;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator string(SceneReference sceneReference)
		{
			return sceneReference.ScenePath;
		}

		[Token(Token = "0x60000EE")]
		[Address(RVA = "0x15F8B6C", Offset = "0x15F8B6C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void OnBeforeSerialize()
		{
		}

		[Token(Token = "0x60000EF")]
		[Address(RVA = "0x15F8B70", Offset = "0x15F8B70", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void OnAfterDeserialize()
		{
		}

		[Token(Token = "0x60000F0")]
		[Address(RVA = "0x15F7BA0", Offset = "0x15F7BA0", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EA6270]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A070]) = v38;\nL_001A:\n\tthis.scenePath = v44.Empty;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SceneReference()
		{
			ScenePath = string.Empty;
		}
	}
}
