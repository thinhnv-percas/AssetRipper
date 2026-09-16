using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x200005D")]
	public class FsmOwnerDefault
	{
		[SerializeField]
		[Token(Token = "0x400016E")]
		[FieldOffset(Offset = "0x10")]
		private OwnerDefaultOption ownerOption;

		[SerializeField]
		[Token(Token = "0x400016F")]
		[FieldOffset(Offset = "0x18")]
		private FsmGameObject gameObject;

		[Token(Token = "0x17000086")]
		public OwnerDefaultOption OwnerOption
		{
			[Token(Token = "0x600021F")]
			[Address(RVA = "0xCAFB04", Offset = "0xCAFB04", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ownerOption;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return OwnerOption;
			}
			[Token(Token = "0x6000220")]
			[Address(RVA = "0xCAFB0C", Offset = "0xCAFB0C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.ownerOption = value;\n\treturn;\n")]
			set
			{
				OwnerOption = value;
			}
		}

		[Token(Token = "0x17000087")]
		public FsmGameObject GameObject
		{
			[Token(Token = "0x6000221")]
			[Address(RVA = "0xCAFB14", Offset = "0xCAFB14", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.gameObject;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return GameObject;
			}
			[Token(Token = "0x6000222")]
			[Address(RVA = "0xCAFB1C", Offset = "0xCAFB1C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = value;\n\treturn;\n")]
			set
			{
				GameObject = value;
			}
		}

		[Token(Token = "0x6000223")]
		[Address(RVA = "0xCAFB24", Offset = "0xCAFB24", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EFDC98]);\n\tv21 = *([v20 @ X8_v8]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023617]) = v40;\nL_0016:\n\tSystem.Object::.ctor(this);\n\tthis.ownerOption = 0;\n\tv51 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v51, v47.Empty);\n\tthis.gameObject = v51;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmOwnerDefault()
		{
			OwnerOption = default(OwnerDefaultOption);
			FsmGameObject fsmGameObject = (FsmGameObject)new NamedVariable(string.Empty);
			GameObject = fsmGameObject;
		}

		[Token(Token = "0x6000224")]
		[Address(RVA = "0xCABCC4", Offset = "0xCABCC4", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1ED7F60]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, source, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023618]) = v41;\nL_0017:\n\tSystem.Object::.ctor(this);\n\tv44 = source == 0;\n\tif (v44) goto L_0030;\n\tthis.ownerOption = source.ownerOption;\n\tv48 = source.gameObject;\n\tv50 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v50, source.gameObject);\n\tv59 = source.gameObject == 0;\n\tif (v59) goto L_0029;\n\tv50.value = *([v48 @ X20_v4 (HutongGames.PlayMaker.NamedVariable)+40]);\nL_0029:\n\tthis.gameObject = v50;\nL_0030:\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmOwnerDefault(FsmOwnerDefault source)
		{
			//IL_0070: Expected O, but got I
			base._002Ector();
			if (source != null)
			{
				OwnerOption = source.OwnerOption;
				NamedVariable namedVariable = source.GameObject;
				FsmGameObject fsmGameObject = (FsmGameObject)new NamedVariable(source.GameObject);
				if (source.GameObject != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X20_v4 (HutongGames.PlayMaker.NamedVariable)+40]");
					fsmGameObject.value = (GameObject)0;
				}
				GameObject = fsmGameObject;
			}
		}
	}
}
