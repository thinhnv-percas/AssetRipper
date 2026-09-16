using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000028")]
public class RobotArmController : MonoBehaviour
{
	[Token(Token = "0x40000FA")]
	[FieldOffset(Offset = "0x18")]
	public Transform section1;

	[Token(Token = "0x40000FB")]
	[FieldOffset(Offset = "0x20")]
	public Transform section2;

	[Token(Token = "0x40000FC")]
	[FieldOffset(Offset = "0x28")]
	public Transform actuator;

	[Token(Token = "0x40000FD")]
	[FieldOffset(Offset = "0x30")]
	public float speed;

	[Token(Token = "0x60000D9")]
	[Address(RVA = "0xB026A0", Offset = "0xB026A0", Length = "0x238")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = UnityEngine.Input::GetKey(0x61);\n\tv18 = v16 == 0;\n\tif (v18) goto L_001D;\n\tv22 = UnityEngine.Time::get_deltaTime();\n\tv30 = this.speed * v22;\n\tUnityEngine.Transform::Rotate(this.section1, 0f, v30, 0f, 0);\nL_001D:\n\tv45 = UnityEngine.Input::GetKey(0x64);\n\tv47 = v45 == 0;\n\tif (v47) goto L_0031;\n\tv70 = UnityEngine.Time::get_deltaTime();\n\tv175 = this.speed * v70;\n\tv130 = -v175;\n\tUnityEngine.Transform::Rotate(this.section1, 0f, v130, 0f, 0);\nL_0031:\n\tv141 = UnityEngine.Input::GetKey(0x77);\n\tv143 = v141 == 0;\n\tif (v143) goto L_0044;\n\tv71 = UnityEngine.Time::get_deltaTime();\n\tv178 = this.speed * v71;\n\tUnityEngine.Transform::Rotate(this.section1, 0f, v178, 0f, 1);\nL_0044:\n\tv189 = UnityEngine.Input::GetKey(0x73);\n\tv191 = v189 == 0;\n\tif (v191) goto L_0058;\n\tv72 = UnityEngine.Time::get_deltaTime();\n\tv208 = this.speed * v72;\n\tv194 = -v208;\n\tUnityEngine.Transform::Rotate(this.section1, 0f, v194, 0f, 1);\nL_0058:\n\tv205 = UnityEngine.Input::GetKey(0x74);\n\tv207 = v205 == 0;\n\tif (v207) goto L_006B;\n\tv73 = UnityEngine.Time::get_deltaTime();\n\tv211 = this.speed * v73;\n\tUnityEngine.Transform::Rotate(this.section2, 0f, v211, 0f, 1);\nL_006B:\n\tv222 = UnityEngine.Input::GetKey(0x67);\n\tv224 = v222 == 0;\n\tif (v224) goto L_007F;\n\tv74 = UnityEngine.Time::get_deltaTime();\n\tv241 = this.speed * v74;\n\tv227 = -v241;\n\tUnityEngine.Transform::Rotate(this.section2, 0f, v227, 0f, 1);\nL_007F:\n\tv238 = UnityEngine.Input::GetKey(0x79);\n\tv240 = v238 == 0;\n\tif (v240) goto L_0092;\n\tv75 = UnityEngine.Time::get_deltaTime();\n\tv244 = this.speed * v75;\n\tUnityEngine.Transform::Rotate(this.actuator, 0f, v244, 0f, 1);\nL_0092:\n\tv168 = UnityEngine.Input::GetKey(0x68);\n\tv163 = v168 == 0;\n\tif (v163) goto L_00B1;\n\tv76 = UnityEngine.Time::get_deltaTime();\n\tv255 = this.speed * v76;\n\tv152 = -v255;\n\tUnityEngine.Transform::Rotate(this.actuator, 0f, v152, 0f, 1);\n\treturn;\nL_00B1:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 125 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Update()
	{
		if (Input.GetKey(KeyCode.A))
		{
			float deltaTime = Time.deltaTime;
			float yAngle = speed * deltaTime;
			section1.Rotate(0f, yAngle, 0f, default(Space));
		}
		if (Input.GetKey(KeyCode.D))
		{
			float deltaTime2 = Time.deltaTime;
			float num = speed * deltaTime2;
			float yAngle2 = 0f - num;
			section1.Rotate(0f, yAngle2, 0f, default(Space));
		}
		if (Input.GetKey(KeyCode.W))
		{
			float deltaTime3 = Time.deltaTime;
			float yAngle3 = speed * deltaTime3;
			section1.Rotate(0f, yAngle3, 0f, Space.Self);
		}
		if (Input.GetKey(KeyCode.S))
		{
			float deltaTime4 = Time.deltaTime;
			float num2 = speed * deltaTime4;
			float yAngle4 = 0f - num2;
			section1.Rotate(0f, yAngle4, 0f, Space.Self);
		}
		if (Input.GetKey(KeyCode.T))
		{
			float deltaTime5 = Time.deltaTime;
			float yAngle5 = speed * deltaTime5;
			section2.Rotate(0f, yAngle5, 0f, Space.Self);
		}
		if (Input.GetKey(KeyCode.G))
		{
			float deltaTime6 = Time.deltaTime;
			float num3 = speed * deltaTime6;
			float yAngle6 = 0f - num3;
			section2.Rotate(0f, yAngle6, 0f, Space.Self);
		}
		if (Input.GetKey(KeyCode.Y))
		{
			float deltaTime7 = Time.deltaTime;
			float yAngle7 = speed * deltaTime7;
			actuator.Rotate(0f, yAngle7, 0f, Space.Self);
		}
		if (Input.GetKey(KeyCode.H))
		{
			float deltaTime8 = Time.deltaTime;
			float num4 = speed * deltaTime8;
			float yAngle8 = 0f - num4;
			actuator.Rotate(0f, yAngle8, 0f, Space.Self);
		}
	}

	[Token(Token = "0x60000DA")]
	[Address(RVA = "0xB028D8", Offset = "0xB028D8", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.speed = 40f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public RobotArmController()
	{
		speed = 40f;
	}
}
