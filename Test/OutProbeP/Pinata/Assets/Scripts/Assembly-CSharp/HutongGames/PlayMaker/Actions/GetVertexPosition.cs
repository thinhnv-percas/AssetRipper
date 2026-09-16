using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759A88", Offset = "0x759A88")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x759A88", Offset = "0x759A88")]
	[Token(Token = "0x2000295")]
	public class GetVertexPosition : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B8F00", Offset = "0x7B8F00")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B8F00", Offset = "0x7B8F00")]
		[Token(Token = "0x40016FA")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B8F98", Offset = "0x7B8F98")]
		[Token(Token = "0x40016FB")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt vertexIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B8FE4", Offset = "0x7B8FE4")]
		[Token(Token = "0x40016FC")]
		[FieldOffset(Offset = "0x60")]
		public Space space;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B901C", Offset = "0x7B901C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B901C", Offset = "0x7B901C")]
		[Token(Token = "0x40016FD")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 storePosition;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B907C", Offset = "0x7B907C")]
		[Token(Token = "0x40016FE")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6000CCF")]
		[Address(RVA = "0xA379DC", Offset = "0xA379DC", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.space = 0;\n\tthis.storePosition = 0;\n\tthis.everyFrame = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
			space = default(Space);
			storePosition = null;
			everyFrame = false;
		}

		[Token(Token = "0x6000CD0")]
		[Address(RVA = "0xA379F0", Offset = "0xA379F0", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetVertexPosition::DoGetVertexPosition(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetVertexPosition();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000CD1")]
		[Address(RVA = "0xA37C70", Offset = "0xA37C70", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetVertexPosition::DoGetVertexPosition(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetVertexPosition();
		}

		[Token(Token = "0x6000CD2")]
		[Address(RVA = "0xA37A2C", Offset = "0xA37A2C", Length = "0x244")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1ECEF58]);\n\tv27 = *([v26 @ X8_v25]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021E24]) = v46;\nL_001C:\n\tv51 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002E;\n\tv193 = *([v122 @ X8_v6+E0]);\n\tv194 = v193 == 0;\n\tv195 = ~v194;\n\tif (v195) goto L_002E;\n\tv226 = v122;\n\tv197 = \"il2cpp_codegen_runtime_class_init\"(v226, v49, v50, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_002E:\n\tv168 = UnityEngine.Object::op_Inequality(v51, 0);\n\tv228 = v168 == 0;\n\tif (v228) goto L_00D3;\n\tv272 = UnityEngine.GameObject::GetComponent(v51);\n\tgoto L_0048;\n\tv316 = *([v312 @ X8_v10+E0]);\n\tv317 = v316 == 0;\n\tv318 = ~v317;\n\tif (v318) goto L_0048;\n\tv323 = v312;\n\tv320 = \"il2cpp_codegen_runtime_class_init\"(v323, v271, v158, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0048:\n\tv169 = UnityEngine.Object::op_Equality(v272, 0);\n\tv303 = v169 == 0;\n\tif (v303) goto L_0061;\n\tHutongGames.PlayMaker.FsmStateAction::LogError(this, \"Missing MeshFilter!\");\n\treturn;\nL_0061:\n\tv69 = this.space == 1;\n\tif (v69) goto L_00A4;\n\tv327 = this.space == 0;\n\tv255 = ~v327;\n\tif (v255) goto L_00D3;\n\tv104 = UnityEngine.MeshFilter::get_mesh(v272);\n\tv170 = UnityEngine.Mesh::get_vertices(v104);\n\tv171 = HutongGames.PlayMaker.FsmInt::get_Value(this.vertexIndex);\n\tv333 = v171 < v170.Length;\n\tv82 = ~v333;\n\tif (v82) goto L_00D7;\n\tv335 = v171 * 0xC;\n\tv115 = v170 + v335;\n\tv112 = this.storePosition;\n\tv105 = UnityEngine.GameObject::get_transform(v51);\n\t// 152 MakeStruct v128 @ AGGA37BC0_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v115 @ X8_v20+20], v170[v171 @ X0_v30 (System.Int32)].y (System.Single), v170[v171 @ X0_v30 (System.Int32)].z (System.Single)\n\tv134 = UnityEngine.Transform::TransformPoint(v105, v128);\n\tv112.value = v134;\n\tv112.value.y = v134.y;\n\tv112.value.z = v134.z;\n\tgoto L_00D3;\nL_00A4:\n\tv118 = this.storePosition;\n\tv106 = UnityEngine.MeshFilter::get_mesh(v272);\n\tv172 = UnityEngine.Mesh::get_vertices(v106);\n\tv173 = HutongGames.PlayMaker.FsmInt::get_Value(this.vertexIndex);\n\tv332 = v173 < v172.Length;\n\tv150 = ~v332;\n\tif (v150) goto L_00D7;\n\tv254 = v173 * 0xC;\n\tv339 = v172 + v254;\n\tv118.value = *([v339 @ X8_v15+20]);\n\tv118.value.z = v172[v173 @ X0_v25 (System.Int32)].z;\nL_00D3:\n\treturn;\n\tthrow System.NullReferenceException;\n\tv192 = new System.NullReferenceException();\nL_00D7:\n\tv225 = new System.IndexOutOfRangeException();\n\tthrow v225;\n\treturn;\n// 152 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetVertexPosition()
		{
			//IL_029d: Expected O, but got I
			//IL_02b2: Expected O, but got I
			//IL_0159: Expected O, but got I
			//IL_018a: Expected F4, but got I
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget != null))
			{
				return;
			}
			MeshFilter component = ownerDefaultTarget.GetComponent<MeshFilter>();
			if (component == null)
			{
				LogError("Missing MeshFilter!");
				return;
			}
			if (space != Space.Self)
			{
				if (space != Space.World)
				{
					return;
				}
				Mesh mesh = component.mesh;
				Vector3[] vertices = mesh.vertices;
				int value = vertexIndex.Value;
				if (value < vertices.Length)
				{
					int num = value * 12;
					object obj = (long)(IntPtr)vertices + (long)num;
					FsmVector3 fsmVector = storePosition;
					Transform transform = ownerDefaultTarget.transform;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X8_v20+20]");
					Vector3 position = default(Vector3);
					position.x = 0f;
					position.y = vertices[value].y;
					position.z = vertices[value].z;
					Vector3 vector = (fsmVector.value = transform.TransformPoint(position));
					fsmVector.value.y = vector.y;
					fsmVector.value.z = vector.z;
					return;
				}
			}
			else
			{
				FsmVector3 fsmVector2 = storePosition;
				Mesh mesh2 = component.mesh;
				Vector3[] vertices2 = mesh2.vertices;
				int value2 = vertexIndex.Value;
				if (value2 < vertices2.Length)
				{
					int num2 = value2 * 12;
					object obj2 = (long)(IntPtr)vertices2 + (long)num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ X8_v15+20]");
					fsmVector2.value = (Vector3)0;
					fsmVector2.value.z = vertices2[value2].z;
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000CD3")]
		[Address(RVA = "0xA37C74", Offset = "0xA37C74", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetVertexPosition()
		{
		}
	}
}
