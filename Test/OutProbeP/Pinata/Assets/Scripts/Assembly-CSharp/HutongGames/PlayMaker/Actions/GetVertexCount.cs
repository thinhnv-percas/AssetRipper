using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759A28", Offset = "0x759A28")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x759A28", Offset = "0x759A28")]
	[Token(Token = "0x2000294")]
	public class GetVertexCount : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B8E08", Offset = "0x7B8E08")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B8E08", Offset = "0x7B8E08")]
		[Token(Token = "0x40016F7")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B8EA0", Offset = "0x7B8EA0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B8EA0", Offset = "0x7B8EA0")]
		[Token(Token = "0x40016F8")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt storeCount;

		[Token(Token = "0x40016F9")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6000CCA")]
		[Address(RVA = "0xA3784C", Offset = "0xA3784C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.gameObject = 0;\n\tthis.storeCount = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			gameObject = null;
			storeCount = null;
		}

		[Token(Token = "0x6000CCB")]
		[Address(RVA = "0xA37858", Offset = "0xA37858", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetVertexCount::DoGetVertexCount(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetVertexCount();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000CCC")]
		[Address(RVA = "0xA379D0", Offset = "0xA379D0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetVertexCount::DoGetVertexCount(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetVertexCount();
		}

		[Token(Token = "0x6000CCD")]
		[Address(RVA = "0xA37894", Offset = "0xA37894", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EDED20]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021E23]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv94 = *([v68 @ X8_v5+E0]);\n\tv95 = v94 == 0;\n\tv96 = ~v95;\n\tif (v96) goto L_002B;\n\tv101 = v68;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v101, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv82 = UnityEngine.Object::op_Inequality(v45, 0);\n\tv103 = v82 == 0;\n\tif (v103) goto L_0069;\n\tv142 = UnityEngine.GameObject::GetComponent(v45);\n\tgoto L_0045;\n\tv146 = *([v62 @ X8_v9+E0]);\n\tv147 = v146 == 0;\n\tv148 = ~v147;\n\tif (v148) goto L_0045;\n\tv153 = v62;\n\tv150 = \"il2cpp_codegen_runtime_class_init\"(v153, v141, v76, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0045:\n\tv83 = UnityEngine.Object::op_Equality(v142, 0);\n\tv122 = v83 == 0;\n\tif (v122) goto L_0058;\n\tHutongGames.PlayMaker.FsmStateAction::LogError(this, \"Missing MeshFilter!\");\n\treturn;\nL_0058:\n\tv60 = this.storeCount;\n\tv56 = UnityEngine.MeshFilter::get_mesh(v142);\n\tv84 = UnityEngine.Mesh::get_vertexCount(v56);\n\tv60.value = v84;\nL_0069:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetVertexCount()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget != null)
			{
				MeshFilter component = ownerDefaultTarget.GetComponent<MeshFilter>();
				if (component == null)
				{
					LogError("Missing MeshFilter!");
					return;
				}
				FsmInt fsmInt = storeCount;
				Mesh mesh = component.mesh;
				int vertexCount = mesh.vertexCount;
				fsmInt.Value = vertexCount;
			}
		}

		[Token(Token = "0x6000CCE")]
		[Address(RVA = "0xA379D4", Offset = "0xA379D4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetVertexCount()
		{
		}
	}
}
