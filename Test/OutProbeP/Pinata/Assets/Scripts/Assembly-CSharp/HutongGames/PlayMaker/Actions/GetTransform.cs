using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75654C", Offset = "0x75654C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75654C", Offset = "0x75654C")]
	[Token(Token = "0x20001F2")]
	public class GetTransform : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x400146D")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B14E0", Offset = "0x7B14E0")]
		[Attribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7B14E0", Offset = "0x7B14E0")]
		[Token(Token = "0x400146E")]
		[FieldOffset(Offset = "0x58")]
		public FsmObject storeTransform;

		[Token(Token = "0x400146F")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6000A39")]
		[Address(RVA = "0xA36DAC", Offset = "0xA36DAC", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1ECE588]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E1B]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v42);\n\tv42.useVariable = 1;\n\tthis.gameObject = v42;\n\tthis.storeTransform = 0;\n\tthis.everyFrame = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmGameObject fsmGameObject = new FsmGameObject();
			fsmGameObject.useVariable = true;
			gameObject = fsmGameObject;
			storeTransform = null;
			everyFrame = false;
		}

		[Token(Token = "0x6000A3A")]
		[Address(RVA = "0xA36E24", Offset = "0xA36E24", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetTransform::DoGetGameObjectName(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetGameObjectName();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000A3B")]
		[Address(RVA = "0xA36F1C", Offset = "0xA36F1C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetTransform::DoGetGameObjectName(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetGameObjectName();
		}

		[Token(Token = "0x6000A3C")]
		[Address(RVA = "0xA36E60", Offset = "0xA36E60", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EA4888]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E1C]) = v38;\nL_0017:\n\tv42 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObject);\n\tv59 = this.storeTransform;\n\tgoto L_002A;\n\tv67 = *([v63 @ X8_v6+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_002A;\n\tv93 = v63;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v93, v41, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv75 = UnityEngine.Object::op_Inequality(v42, 0);\n\tv96 = v75 == 0;\n\tif (v96) goto L_0037;\n\tv83 = UnityEngine.GameObject::get_transform(v42);\nL_0037:\n\tv59.value = v83;\n\treturn;\n\tv51 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetGameObjectName()
		{
			GameObject value = gameObject.Value;
			FsmObject fsmObject = storeTransform;
			bool flag = value != null;
			bool flag2 = !flag;
			Transform value2 = null;
			if (!flag2)
			{
				value2 = value.transform;
			}
			fsmObject.Value = value2;
		}

		[Token(Token = "0x6000A3D")]
		[Address(RVA = "0xA36F20", Offset = "0xA36F20", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetTransform()
		{
		}
	}
}
