using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75627C", Offset = "0x75627C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75627C", Offset = "0x75627C")]
	[Token(Token = "0x20001E9")]
	public class GetName : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001454")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B110C", Offset = "0x7B110C")]
		[Token(Token = "0x4001455")]
		[FieldOffset(Offset = "0x58")]
		public FsmString storeName;

		[Token(Token = "0x4001456")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6000A15")]
		[Address(RVA = "0xA30284", Offset = "0xA30284", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1ECCA38]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021DEB]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v42);\n\tv42.useVariable = 1;\n\tthis.gameObject = v42;\n\tthis.storeName = 0;\n\tthis.everyFrame = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmGameObject fsmGameObject = new FsmGameObject();
			fsmGameObject.useVariable = true;
			gameObject = fsmGameObject;
			storeName = null;
			everyFrame = false;
		}

		[Token(Token = "0x6000A16")]
		[Address(RVA = "0xA302FC", Offset = "0xA302FC", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetName::DoGetGameObjectName(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetGameObjectName();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000A17")]
		[Address(RVA = "0xA30400", Offset = "0xA30400", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetName::DoGetGameObjectName(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetGameObjectName();
		}

		[Token(Token = "0x6000A18")]
		[Address(RVA = "0xA30338", Offset = "0xA30338", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EBDD20]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021DEC]) = v38;\nL_0017:\n\tv42 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObject);\n\tv59 = this.storeName;\n\tgoto L_002A;\n\tv67 = *([v63 @ X8_v6+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_002A;\n\tv94 = v63;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v94, v41, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv75 = UnityEngine.Object::op_Inequality(v42, 0);\n\tv96 = v75 == 0;\n\tif (v96) goto L_FFFFFFFF;\n\tv83 = UnityEngine.Object::get_name(v42);\n\tv108 = this.storeName == 0;\n\tv106 = ~v108;\n\tif (v106) goto L_003C;\n\tgoto L_0044;\nL_003C:\n\tv59.value = v83;\n\treturn;\nL_0044:\n\tv51 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetGameObjectName()
		{
			GameObject value = gameObject.Value;
			FsmString fsmString = storeName;
			string value2;
			if (value != null)
			{
				value2 = value.name;
				if (storeName == null)
				{
					NullReferenceException ex = new NullReferenceException();
					throw new NullReferenceException();
				}
			}
			else
			{
				value2 = "";
			}
			fsmString.Value = value2;
		}

		[Token(Token = "0x6000A19")]
		[Address(RVA = "0xA30404", Offset = "0xA30404", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetName()
		{
		}
	}
}
