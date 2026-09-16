using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75B0E0", Offset = "0x75B0E0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75B0E0", Offset = "0x75B0E0")]
	[Token(Token = "0x20002DC")]
	public class WakeAllRigidBodies2d : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C07F4", Offset = "0x7C07F4")]
		[Token(Token = "0x40018CC")]
		[FieldOffset(Offset = "0x49")]
		public bool everyFrame;

		[Token(Token = "0x6000E59")]
		[Address(RVA = "0x98A48C", Offset = "0x98A48C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
		}

		[Token(Token = "0x6000E5A")]
		[Address(RVA = "0x98A494", Offset = "0x98A494", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.WakeAllRigidBodies2d::DoWakeAll(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoWakeAll();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000E5B")]
		[Address(RVA = "0x98A5E0", Offset = "0x98A5E0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.WakeAllRigidBodies2d::DoWakeAll(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoWakeAll();
		}

		[Token(Token = "0x6000E5C")]
		[Address(RVA = "0x98A4D0", Offset = "0x98A4D0", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv16 = *([1EDFEE8]);\n\tv17 = *([v16 @ X8_v22]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20216C6]) = v37;\nL_001B:\n\tgoto L_0023;\n\tv47 = *([v40 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0023;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0023:\n\tv56 = System.Type::GetTypeFromHandle(UnityEngine.Rigidbody2D);\n\tgoto L_0034;\n\tv64 = *([v60 @ X8_v10+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_0034;\n\tv74 = v60;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v74, v55, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0034:\n\tv73 = UnityEngine.Object::FindObjectsOfType(v56);\n\t// 56 IsInst v78 @ X0_v9, typeof(UnityEngine.Rigidbody2D[]), v73 @ X0_v8 (UnityEngine.Object[])\n\tv80 = v78 == 0;\n\tif (v80) goto L_006E;\n\tv185 = *([v78 @ X0_v9+18]);\n\tv92 = *([v78 @ X0_v9+18]) < 1;\n\tif (v92) goto L_006E;\nL_004A:\n\tv186 = v144 < v185;\n\tv162 = ~v186;\n\tif (v162) goto L_006F;\n\tv94 = v144 << 3;\n\tv187 = v78 + v94;\n\tUnityEngine.Rigidbody2D::WakeUp(*([v187 @ X8_v17+20]));\n\tv185 = *([v78 @ X0_v9+18]);\n\tv144 = v144 + 1;\n\tv99 = v144 < *([v78 @ X0_v9+18]);\n\tif (v99) goto L_004A;\nL_006E:\n\treturn;\nL_006F:\n\tv188 = new System.IndexOutOfRangeException();\n\tthrow v188;\n\tthrow System.NullReferenceException;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoWakeAll()
		{
			//IL_00b3: Expected O, but got I
			//IL_00c9: Expected O, but got I
			Type typeFromHandle = typeof(Rigidbody2D);
			UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(typeFromHandle);
			object obj = array as Rigidbody2D[];
			if (obj == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X0_v9+18]");
			int num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X0_v9+18]");
			if (0L < 1L)
			{
				return;
			}
			int num2 = 0;
			while (num2 < num)
			{
				int num3 = num2 << 3;
				object obj2 = (long)(IntPtr)obj + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ X8_v17+20]");
				((Rigidbody2D)0).WakeUp();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X0_v9+18]");
				num = 0;
				num2++;
				int num4 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X0_v9+18]");
				if ((long)num4 >= 0L)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000E5D")]
		[Address(RVA = "0x98A5E4", Offset = "0x98A5E4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public WakeAllRigidBodies2d()
		{
		}
	}
}
