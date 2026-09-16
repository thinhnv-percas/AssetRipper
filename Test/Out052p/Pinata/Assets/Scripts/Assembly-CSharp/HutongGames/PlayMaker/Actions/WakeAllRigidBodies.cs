using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A3EC", Offset = "0x75A3EC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75A3EC", Offset = "0x75A3EC")]
	[Token(Token = "0x20002B3")]
	public class WakeAllRigidBodies : FsmStateAction
	{
		[Token(Token = "0x4001796")]
		[FieldOffset(Offset = "0x49")]
		public bool everyFrame;

		[Token(Token = "0x4001797")]
		[FieldOffset(Offset = "0x50")]
		private Rigidbody[] bodies;

		[Token(Token = "0x6000D78")]
		[Address(RVA = "0x98A27C", Offset = "0x98A27C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
		}

		[Token(Token = "0x6000D79")]
		[Address(RVA = "0x98A284", Offset = "0x98A284", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EA8908]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20216C4]) = v38;\nL_001C:\n\tgoto L_0024;\n\tv48 = *([v41 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0024:\n\tv57 = System.Type::GetTypeFromHandle(UnityEngine.Rigidbody);\n\tgoto L_0035;\n\tv65 = *([v61 @ X8_v10+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_0035;\n\tv75 = v61;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v75, v56, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0035:\n\tv74 = UnityEngine.Object::FindObjectsOfType(v57);\n\t// 57 IsInst v79 @ X0_v9 (UnityEngine.Rigidbody[]), typeof(UnityEngine.Rigidbody[]), v74 @ X0_v8 (UnityEngine.Object[])\n\tthis.bodies = v79;\n\tHutongGames.PlayMaker.Actions.WakeAllRigidBodies::DoWakeAll(this);\n\tv82 = ~this.everyFrame;\n\tif (v82) goto L_004D;\n\treturn;\nL_004D:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			Type typeFromHandle = typeof(Rigidbody);
			UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(typeFromHandle);
			Rigidbody[] array2 = array as Rigidbody[];
			bodies = array2;
			DoWakeAll();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000D7A")]
		[Address(RVA = "0x98A480", Offset = "0x98A480", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.WakeAllRigidBodies::DoWakeAll(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoWakeAll();
		}

		[Token(Token = "0x6000D7B")]
		[Address(RVA = "0x98A368", Offset = "0x98A368", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1ED0B78]);\n\tv19 = *([v18 @ X8_v22]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20216C5]) = v38;\nL_001C:\n\tgoto L_0024;\n\tv48 = *([v41 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0024:\n\tv57 = System.Type::GetTypeFromHandle(UnityEngine.Rigidbody);\n\tgoto L_0035;\n\tv65 = *([v61 @ X8_v10+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_0035;\n\tv75 = v61;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v75, v56, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0035:\n\tv74 = UnityEngine.Object::FindObjectsOfType(v57);\n\t// 57 IsInst v79 @ X0_v9 (UnityEngine.Rigidbody[]), typeof(UnityEngine.Rigidbody[]), v74 @ X0_v8 (UnityEngine.Object[])\n\tthis.bodies = v79;\n\tv81 = v79 == 0;\n\tif (v81) goto L_0070;\n\tv186 = v79.Length;\n\tv93 = v79.Length < 1;\n\tif (v93) goto L_0070;\nL_004C:\n\tv187 = v169 < v186;\n\tv161 = ~v187;\n\tif (v161) goto L_0071;\n\tUnityEngine.Rigidbody::WakeUp(v79[v169 @ X19_v5 (System.Int32)]);\n\tv186 = v79.Length;\n\tv169 = v169 + 1;\n\tv98 = v169 < v79.Length;\n\tif (v98) goto L_004C;\nL_0070:\n\treturn;\nL_0071:\n\tv189 = new System.IndexOutOfRangeException();\n\tthrow v189;\n\tthrow System.NullReferenceException;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoWakeAll()
		{
			Type typeFromHandle = typeof(Rigidbody);
			UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(typeFromHandle);
			Rigidbody[] array2 = (bodies = array as Rigidbody[]);
			if (array2 == null)
			{
				return;
			}
			int num = array2.Length;
			if (array2.Length < 1)
			{
				return;
			}
			int num2 = 0;
			while (num2 < num)
			{
				array2[num2].WakeUp();
				num = array2.Length;
				num2++;
				if (num2 >= array2.Length)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000D7C")]
		[Address(RVA = "0x98A484", Offset = "0x98A484", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public WakeAllRigidBodies()
		{
		}
	}
}
