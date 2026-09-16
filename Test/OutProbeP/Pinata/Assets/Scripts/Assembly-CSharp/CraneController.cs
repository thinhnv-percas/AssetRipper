using AssetRipperInjected;
using Cpp2ILInjected;
using Obi;
using UnityEngine;

[Token(Token = "0x2000025")]
public class CraneController : MonoBehaviour
{
	[Token(Token = "0x40000EB")]
	[FieldOffset(Offset = "0x18")]
	private ObiRopeCursor cursor;

	[Token(Token = "0x40000EC")]
	[FieldOffset(Offset = "0x20")]
	private ObiRope rope;

	[Token(Token = "0x60000CC")]
	[Address(RVA = "0x9FE200", Offset = "0x9FE200", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EE0DC0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021C4B]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponentInChildren(this);\n\tthis.cursor = v43;\n\tv48 = UnityEngine.Component::GetComponent(v43);\n\tthis.rope = v48;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Start()
	{
		ObiRope component = (cursor = GetComponentInChildren<ObiRopeCursor>()).GetComponent<ObiRope>();
		rope = component;
	}

	[Token(Token = "0x60000CD")]
	[Address(RVA = "0x9FE274", Offset = "0x9FE274", Length = "0x150")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = UnityEngine.Input::GetKey(0x77);\n\tv18 = v16 == 0;\n\tif (v18) goto L_002B;\n\tv19 = this.rope;\n\tv24 = v19.restLength_ <= 6.5f;\n\tif (v24) goto L_002B;\n\tv90 = UnityEngine.Time::get_deltaTime();\n\tv51 = v19.restLength_ - v90;\n\tObi.ObiRopeCursor::ChangeLength(this.cursor, v51);\nL_002B:\n\tv66 = UnityEngine.Input::GetKey(0x73);\n\tv129 = v66 == 0;\n\tif (v129) goto L_003E;\n\tv98 = this.rope;\n\tv91 = UnityEngine.Time::get_deltaTime();\n\tv132 = v98.restLength_ + v91;\n\tObi.ObiRopeCursor::ChangeLength(this.cursor, v132);\nL_003E:\n\tv140 = UnityEngine.Input::GetKey(0x61);\n\tv183 = v140 == 0;\n\tif (v183) goto L_0053;\n\tv185 = UnityEngine.Component::get_transform(this);\n\tv92 = UnityEngine.Time::get_deltaTime();\n\tv187 = v92 * 15f;\n\tUnityEngine.Transform::Rotate(v185, 0f, v187, 0f);\nL_0053:\n\tv175 = UnityEngine.Input::GetKey(0x64);\n\tv169 = v175 == 0;\n\tif (v169) goto L_0074;\n\tv197 = UnityEngine.Component::get_transform(this);\n\tv93 = UnityEngine.Time::get_deltaTime();\n\tv147 = v93 * -15f;\n\tUnityEngine.Transform::Rotate(v197, 0f, v147, 0f);\n\treturn;\nL_0074:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 86 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Update()
	{
		if (Input.GetKey(KeyCode.W))
		{
			ObiRope obiRope = rope;
			if (obiRope.restLength > 6.5f)
			{
				float deltaTime = Time.deltaTime;
				float newLength = obiRope.restLength - deltaTime;
				cursor.ChangeLength(newLength);
			}
		}
		if (Input.GetKey(KeyCode.S))
		{
			ObiRope obiRope2 = rope;
			float deltaTime2 = Time.deltaTime;
			float newLength2 = obiRope2.restLength + deltaTime2;
			cursor.ChangeLength(newLength2);
		}
		if (Input.GetKey(KeyCode.A))
		{
			Transform transform = base.transform;
			float deltaTime3 = Time.deltaTime;
			float yAngle = deltaTime3 * 15f;
			transform.Rotate(0f, yAngle, 0f);
		}
		if (Input.GetKey(KeyCode.D))
		{
			Transform transform2 = base.transform;
			float deltaTime4 = Time.deltaTime;
			float yAngle2 = deltaTime4 * -15f;
			transform2.Rotate(0f, yAngle2, 0f);
		}
	}

	[Token(Token = "0x60000CE")]
	[Address(RVA = "0x9FE3C4", Offset = "0x9FE3C4", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public CraneController()
	{
	}
}
