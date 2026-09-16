using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x2000047")]
	public class FsmEventTarget
	{
		[Token(Token = "0x2000094")]
		public enum EventTarget
		{
			[Token(Token = "0x400036A")]
			Self = 0,
			[Token(Token = "0x400036B")]
			GameObject = 1,
			[Token(Token = "0x400036C")]
			GameObjectFSM = 2,
			[Token(Token = "0x400036D")]
			FSMComponent = 3,
			[Token(Token = "0x400036E")]
			BroadcastAll = 4,
			[Token(Token = "0x400036F")]
			HostFSM = 5,
			[Token(Token = "0x4000370")]
			SubFSMs = 6
		}

		[Token(Token = "0x40000FE")]
		private static FsmEventTarget self;

		[Token(Token = "0x40000FF")]
		[FieldOffset(Offset = "0x10")]
		public EventTarget target;

		[Token(Token = "0x4000100")]
		[FieldOffset(Offset = "0x18")]
		public FsmBool excludeSelf;

		[Token(Token = "0x4000101")]
		[FieldOffset(Offset = "0x20")]
		public FsmOwnerDefault gameObject;

		[Token(Token = "0x4000102")]
		[FieldOffset(Offset = "0x28")]
		public FsmString fsmName;

		[Token(Token = "0x4000103")]
		[FieldOffset(Offset = "0x30")]
		public FsmBool sendToChildren;

		[Token(Token = "0x4000104")]
		[FieldOffset(Offset = "0x38")]
		public PlayMakerFSM fsmComponent;

		[Token(Token = "0x17000054")]
		public static FsmEventTarget Self
		{
			[Token(Token = "0x6000147")]
			[Address(RVA = "0xCABA90", Offset = "0xCABA90", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1ED7778]);\n\tv17 = *([v16 @ X8_v8]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20235CF]) = v37;\nL_0016:\n\tv52 = v41.self;\n\tv43 = v41.self == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_0029;\n\tv45 = new HutongGames.PlayMaker.FsmEventTarget();\n\tSystem.Object::.ctor(v45);\n\tHutongGames.PlayMaker.FsmEventTarget::ResetParameters(v45);\n\tv51.self = v45;\nL_0029:\n\treturn v52;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FsmEventTarget result = self;
				if (self == null)
				{
					FsmEventTarget fsmEventTarget = new FsmEventTarget();
					fsmEventTarget.ResetParameters();
					self = fsmEventTarget;
					result = fsmEventTarget;
				}
				return result;
			}
		}

		[Token(Token = "0x6000148")]
		[Address(RVA = "0xCABB0C", Offset = "0xCABB0C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tHutongGames.PlayMaker.FsmEventTarget::ResetParameters(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmEventTarget()
		{
			ResetParameters();
		}

		[Token(Token = "0x6000149")]
		[Address(RVA = "0xCABBA0", Offset = "0xCABBA0", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1ECDA90]);\n\tv27 = *([v26 @ X8_v15]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, source, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([20235D0]) = v45;\nL_0019:\n\tSystem.Object::.ctor(this);\n\tthis.target = source.target;\n\tv52 = source.excludeSelf;\n\tv54 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v54, source.excludeSelf);\n\tv60 = source.excludeSelf == 0;\n\tif (v60) goto L_002B;\n\tv54.value = *([v52 @ X21_v2 (HutongGames.PlayMaker.NamedVariable)+38]);\nL_002B:\n\tthis.excludeSelf = v54;\n\tv91 = new HutongGames.PlayMaker.FsmOwnerDefault();\n\tHutongGames.PlayMaker.FsmOwnerDefault::.ctor(v91, source.gameObject);\n\tthis.gameObject = v91;\n\tv98 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v98, source.fsmName);\n\tthis.fsmName = v98;\n\tv102 = source.sendToChildren;\n\tv72 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v72, source.sendToChildren);\n\tv74 = source.sendToChildren == 0;\n\tif (v74) goto L_0049;\n\tv72.value = *([v102 @ X21_v5 (HutongGames.PlayMaker.NamedVariable)+38]);\nL_0049:\n\tthis.sendToChildren = v72;\n\tthis.fsmComponent = source.fsmComponent;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmEventTarget(FsmEventTarget source)
		{
			target = source.target;
			NamedVariable namedVariable = source.excludeSelf;
			FsmBool fsmBool = (FsmBool)new NamedVariable(source.excludeSelf);
			if (source.excludeSelf != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X21_v2 (HutongGames.PlayMaker.NamedVariable)+38]");
				fsmBool.value = false;
			}
			excludeSelf = fsmBool;
			FsmOwnerDefault fsmOwnerDefault = new FsmOwnerDefault(source.gameObject);
			gameObject = fsmOwnerDefault;
			FsmString fsmString = new FsmString(source.fsmName);
			fsmName = fsmString;
			NamedVariable namedVariable2 = source.sendToChildren;
			FsmBool fsmBool2 = (FsmBool)new NamedVariable(source.sendToChildren);
			if (source.sendToChildren != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ X21_v5 (HutongGames.PlayMaker.NamedVariable)+38]");
				fsmBool2.value = false;
			}
			sendToChildren = fsmBool2;
			fsmComponent = source.fsmComponent;
		}

		[Token(Token = "0x600014A")]
		[Address(RVA = "0xCABB34", Offset = "0xCABB34", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ECE3E8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235D1]) = v38;\nL_0014:\n\tv40 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.excludeSelf = v40;\n\tthis.gameObject = 0;\n\tv44 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.fsmName = v44;\n\tv46 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.sendToChildren = v46;\n\tthis.fsmComponent = 0;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ResetParameters()
		{
			FsmBool fsmBool = false;
			excludeSelf = fsmBool;
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			FsmBool fsmBool2 = false;
			sendToChildren = fsmBool2;
			fsmComponent = null;
		}
	}
}
