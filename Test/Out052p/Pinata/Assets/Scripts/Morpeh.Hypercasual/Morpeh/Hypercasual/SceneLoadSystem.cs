using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh.Globals;
using Morpeh.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Morpeh.Hypercasual
{
	[CreateAssetMenu]
	[Token(Token = "0x2000008")]
	public class SceneLoadSystem : LateUpdateSystem
	{
		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x28")]
		public GlobalEventSceneReference evnt;

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x1633E68", Offset = "0x1633E68", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void OnAwake()
		{
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x1633E6C", Offset = "0x1633E6C", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EAF8E0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, deltaTime, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A4E1]) = v38;\nL_0019:\n\tv44 = Morpeh.Globals.BaseGlobalEvent`1<Morpeh.Utils.SceneReference>::get_IsPublished(this.evnt);\n\tv59 = v44 == 0;\n\tif (v59) goto L_003E;\n\tv49 = Morpeh.Globals.BaseGlobalEvent`1<Morpeh.Utils.SceneReference>::get_BatchedChanges(this.evnt);\n\tv82 = v49._size == 0;\n\tv71 = ~v82;\n\tif (v71) goto L_002D;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002D:\n\tv75 = v49._items;\n\tv69 = Morpeh.Utils.SceneReference::op_Implicit(v75[0]);\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(v69);\n\treturn;\nL_003E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate(float deltaTime)
		{
			if (evnt.IsPublished)
			{
				List<SceneReference> batchedChanges = evnt.BatchedChanges;
				if (batchedChanges.Count == 0)
				{
					throw new ArgumentOutOfRangeException();
				}
				SceneReference[] items = batchedChanges._items;
				string sceneName = items[0];
				SceneManager.LoadScene(sceneName);
			}
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x1633F1C", Offset = "0x1633F1C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.LateUpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SceneLoadSystem()
		{
		}
	}
}
