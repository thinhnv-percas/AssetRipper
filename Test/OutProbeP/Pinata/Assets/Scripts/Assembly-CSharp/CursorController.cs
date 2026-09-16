using AssetRipperInjected;
using Cpp2ILInjected;
using Obi;
using UnityEngine;

[Attribute(Type = typeof(RequireComponent), RVA = "0x74CAAC", Offset = "0x74CAAC")]
[Token(Token = "0x2000026")]
public class CursorController : MonoBehaviour
{
	[Token(Token = "0x40000ED")]
	[FieldOffset(Offset = "0x18")]
	private ObiRopeCursor cursor;

	[Token(Token = "0x40000EE")]
	[FieldOffset(Offset = "0x20")]
	private ObiRope rope;

	[Token(Token = "0x40000EF")]
	[FieldOffset(Offset = "0x28")]
	public float minLength;

	[Token(Token = "0x60000CF")]
	[Address(RVA = "0x9FE3CC", Offset = "0x9FE3CC", Length = "0x70")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EBA650]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021C4C]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tthis.rope = v43;\n\tv48 = UnityEngine.Component::GetComponent(this);\n\tthis.cursor = v48;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Start()
	{
		ObiRope component = GetComponent<ObiRope>();
		rope = component;
		ObiRopeCursor component2 = GetComponent<ObiRopeCursor>();
		cursor = component2;
	}

	[Token(Token = "0x60000D0")]
	[Address(RVA = "0x9FE43C", Offset = "0x9FE43C", Length = "0x27C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EE76C0]);\n\tv25 = *([v24 @ X8_v28]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021C4D]) = v44;\nL_0018:\n\tv47 = UnityEngine.Input::GetKey(0x77);\n\tv49 = v47 == 0;\n\tif (v49) goto L_004D;\n\tgoto L_002C;\n\tv109 = *([v53 @ X0_v42+E0]);\n\tv110 = v109 == 0;\n\tv111 = ~v110;\n\tif (v111) goto L_002C;\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v53, v46, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002C:\n\tv96 = UnityEngine.Object::op_Inequality(this.cursor, 0);\n\tv99 = v96 == 0;\n\tif (v99) goto L_004D;\n\tv102 = this.rope;\n\tv58 = v102.restLength_ <= this.minLength;\n\tif (v58) goto L_004D;\n\tv200 = UnityEngine.Time::get_deltaTime();\n\tv85 = v102.restLength_ - v200;\n\tObi.ObiRopeCursor::ChangeLength(this.cursor, v85);\nL_004D:\n\tv108 = UnityEngine.Input::GetKey(0x73);\n\tv117 = v108 == 0;\n\tif (v117) goto L_0074;\n\tgoto L_0061;\n\tv149 = *([v122 @ X0_v35+E0]);\n\tv150 = v149 == 0;\n\tv151 = ~v150;\n\tif (v151) goto L_0061;\n\tv153 = \"il2cpp_codegen_runtime_class_init\"(v122, v107, v89, v29, v30, v31, v32, v33, v84, v35, v36, v37, v38, v39, v40, v41);\nL_0061:\n\tv137 = UnityEngine.Object::op_Inequality(this.cursor, 0);\n\tv140 = v137 == 0;\n\tif (v140) goto L_0074;\n\tv142 = this.rope;\n\tv201 = UnityEngine.Time::get_deltaTime();\n\tv127 = v142.restLength_ + v201;\n\tObi.ObiRopeCursor::ChangeLength(this.cursor, v127);\nL_0074:\n\tv148 = UnityEngine.Input::GetKey(0x61);\n\tv157 = v148 == 0;\n\tif (v157) goto L_00A6;\n\tv282 = UnityEngine.Component::get_transform(this.rope);\n\tgoto L_008C;\n\tv339 = *([v224 @ X8_v13+E0]);\n\tv340 = v339 == 0;\n\tv341 = ~v340;\n\tif (v341) goto L_008C;\n\tv348 = v224;\n\tv343 = \"il2cpp_codegen_runtime_class_init\"(v348, v210, v130, v29, v30, v31, v32, v33, v126, v35, v36, v37, v38, v39, v40, v41);\nL_008C:\n\tv346 = UnityEngine.Vector3::get_left();\n\tv352 = UnityEngine.Time::get_deltaTime();\n\tv202 = UnityEngine.Vector3::op_Multiply(v346, v352);\n\tUnityEngine.Transform::Translate(v282, v202, 0);\nL_00A6:\n\tv251 = UnityEngine.Input::GetKey(0x64);\n\tv284 = v251 == 0;\n\tif (v284) goto L_00E7;\n\tv347 = UnityEngine.Component::get_transform(this.rope);\n\tgoto L_00BE;\n\tv361 = *([v225 @ X8_v10+E0]);\n\tv362 = v361 == 0;\n\tv363 = ~v362;\n\tif (v363) goto L_00BE;\n\tv369 = v225;\n\tv365 = \"il2cpp_codegen_runtime_class_init\"(v369, v211, v208, v29, v30, v31, v32, v33, v240, v238, v237, v234, v38, v39, v40, v41);\nL_00BE:\n\tv368 = UnityEngine.Vector3::get_right();\n\tv373 = UnityEngine.Time::get_deltaTime();\n\tv203 = UnityEngine.Vector3::op_Multiply(v368, v373);\n\tUnityEngine.Transform::Translate(v347, v203, 0);\n\treturn;\nL_00E7:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 161 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Update()
	{
		if (Input.GetKey(KeyCode.W) && cursor != null)
		{
			ObiRope obiRope = rope;
			if (obiRope.restLength > minLength)
			{
				float deltaTime = Time.deltaTime;
				float newLength = obiRope.restLength - deltaTime;
				cursor.ChangeLength(newLength);
			}
		}
		if (Input.GetKey(KeyCode.S) && cursor != null)
		{
			ObiRope obiRope2 = rope;
			float deltaTime2 = Time.deltaTime;
			float newLength2 = obiRope2.restLength + deltaTime2;
			cursor.ChangeLength(newLength2);
		}
		if (Input.GetKey(KeyCode.A))
		{
			Transform transform = rope.transform;
			Vector3 left = Vector3.left;
			float deltaTime3 = Time.deltaTime;
			Vector3 translation = left * deltaTime3;
			transform.Translate(translation, default(Space));
		}
		if (Input.GetKey(KeyCode.D))
		{
			Transform transform2 = rope.transform;
			Vector3 right = Vector3.right;
			float deltaTime4 = Time.deltaTime;
			Vector3 translation2 = right * deltaTime4;
			transform2.Translate(translation2, default(Space));
		}
	}

	[Token(Token = "0x60000D1")]
	[Address(RVA = "0x9FE6B8", Offset = "0x9FE6B8", Length = "0x14")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.minLength = 0.1f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public CursorController()
	{
		minLength = 0.1f;
	}
}
