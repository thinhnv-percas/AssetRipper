using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AllIn1VfxToolkit
{
	[Token(Token = "0x200000B")]
	public class AllIn1LookAt : MonoBehaviour
	{
		[Token(Token = "0x200000C")]
		private enum FaceDirection
		{
			[Token(Token = "0x4000023")]
			Forward = 0,
			[Token(Token = "0x4000024")]
			Up = 1,
			[Token(Token = "0x4000025")]
			Right = 2
		}

		[SerializeField]
		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x20")]
		private bool updateEveryFrame;

		[Space]
		[Header("Choose Target")]
		[SerializeField]
		[Token(Token = "0x400001E")]
		[FieldOffset(Offset = "0x21")]
		private bool targetIsMainCamera;

		[SerializeField]
		[Token(Token = "0x400001F")]
		[FieldOffset(Offset = "0x28")]
		private Transform target;

		[Space]
		[Header("Look At Direction")]
		[SerializeField]
		[Token(Token = "0x4000020")]
		[FieldOffset(Offset = "0x30")]
		private FaceDirection faceDirection;

		[SerializeField]
		[Token(Token = "0x4000021")]
		[FieldOffset(Offset = "0x34")]
		private bool negateDirection;

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x3C2521C", Offset = "0x3C2521C", Length = "0x21C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv60 = UnityEngine.Camera::get_main();\n\tv68 = v60 == 0;\n\tif (v68) goto L_0041;\n\tv78 = UnityEngine.Camera::get_main();\n\tv111 = UnityEngine.Component::get_transform(v78);\n\tthis.target = v111;\nL_0041:\n\tgoto L_0045;\nL_0045:\n\tv100 = UnityEngine.Object::op_Equality(this.target, 0);\n\tv124 = ~v100;\n\tv125 = ~v124;\n\tif (v125) goto L_0072;\n\tgoto L_0091;\nL_004E:\n\tgoto L_0052;\nL_0052:\n\tv72 = UnityEngine.Object::op_Equality(this.target, 0);\n\tv89 = ~v72;\n\tv90 = ~v89;\n\tif (v90) goto L_0060;\n\tgoto L_0091;\nL_0060:\n\tv109 = UnityEngine.Component::get_gameObject(this);\n\tv171 = UnityEngine.Object::get_name(v109);\n\tv195 = 0xB2F8000 + 0x950;\n\tv191 = v171;\n\tgoto L_007F;\nL_0072:\n\tv117 = UnityEngine.Component::get_gameObject(this);\n\tv189 = UnityEngine.Object::get_name(v117);\n\tv195 = 0xB2F8000 + 0x820;\n\tv191 = v189;\nL_0087:\n\tUnityEngine.Debug::LogError(v201);\n\tgoto L_008E;\nL_008E:\n\tUnityEngine.Object::Destroy(this);\nL_0091:\n\tv150 = this.updateEveryFrame == 0;\n\tif (v150) goto L_00A3;\n\treturn;\nL_00A3:\n\tAllIn1VfxToolkit.AllIn1LookAt::LookAtCompute(this);\n\treturn;\nL_002C:\n\tv55 = this.targetIsMainCamera != 1;\n\tif (v55) goto L_004E;\nL_007F:\n\tv201 = System.String::Concat(*([v195 @ X8_v4 (System.Int32)]), v191, \" will now be destroyed. Please double check your setup\");\n\tgoto L_0087;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AllIn1LookAt::Start");
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x3C2565C", Offset = "0x3C2565C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.updateEveryFrame != 1;\n\tif (v11) goto L_000E;\n\tAllIn1VfxToolkit.AllIn1LookAt::LookAtCompute(this);\n\treturn;\nL_000E:\n\treturn;\n")]
		private void Update()
		{
			if (updateEveryFrame)
			{
				LookAtCompute();
			}
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x3C25438", Offset = "0x3C25438", Length = "0x224")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv31 = UnityEngine.Transform::get_position(this.target);\n\tv124 = UnityEngine.Component::get_transform(this);\n\tv242 = UnityEngine.Transform::get_position(v124);\n\tgoto L_0032;\nL_003B:\n\tv267 = v258 * v258;\n\tv268 = v259 * v259;\n\tv269 = v267 + v268;\n\tv270 = v260 * v260;\n\tv271 = v270 + v269;\n\tv272 = UnityEngine.Mathf::Sqrt(v271);\n\tgoto L_0050;\nL_0050:\n\tv111 = v258 / v272;\n\tv108 = v259 / v272;\n\tv104 = v260 / v272;\n\tgoto L_0067;\nL_FFFFFFFF:\n\tv100 = v37;\n\tgoto L_007A;\nL_FFFFFFFF:\n\tv100 = v104;\nL_FFFFFFFF:\n\tv97 = v40;\n\tgoto L_0081;\nL_FFFFFFFF:\n\tv97 = v108;\nL_FFFFFFFF:\n\tv94 = v43;\n\tgoto L_008D;\nL_FFFFFFFF:\n\tv94 = v111;\n\tv73 = this.faceDirection == 1;\n\tif (v73) goto L_00BB;\n\tv333 = this.faceDirection == 0;\n\tv229 = ~v333;\n\tif (v229) goto L_00F8;\n\tv125 = UnityEngine.Component::get_transform(this);\n\t// 182 MakeStruct v149 @ AGG3C255C0_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v94 @ V10_v4 (System.Single), v97 @ V9_v4 (System.Single), v100 @ V8_v4 (System.Single)\n\tUnityEngine.Transform::set_forward(v125, v149);\n\treturn;\nL_00BB:\n\tv126 = UnityEngine.Component::get_transform(this);\n\t// 207 MakeStruct v147 @ AGG3C255FC_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v94 @ V10_v4 (System.Single), v97 @ V9_v4 (System.Single), v100 @ V8_v4 (System.Single)\n\tUnityEngine.Transform::set_up(v126, v147);\n\treturn;\nL_00D4:\n\tv127 = UnityEngine.Component::get_transform(this);\n\t// 232 MakeStruct v144 @ AGG3C25638_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v94 @ V10_v4 (System.Single), v97 @ V9_v4 (System.Single), v100 @ V8_v4 (System.Single)\n\tUnityEngine.Transform::set_right(v127, v144);\n\treturn;\nL_00F8:\n\treturn;\nL_0032:\n\tv258 = v31 - v242;\n\tv259 = v31.y - v242.y;\n\tv260 = v31.z - v242.z;\n\tgoto L_003B;\nL_0067:\n\tv43 = -v111;\n\tv40 = -v108;\n\tv37 = -v104;\n\tv309 = this.negateDirection == 0;\n\tv314 = ~v309;\n\tv315 = ~v314;\n\tif (v315) goto L_FFFFFFFF;\nL_007A:\n\tv324 = ~v309;\n\tv325 = ~v324;\n\tif (v325) goto L_FFFFFFFF;\nL_0081:\n\tv54 = ~v309;\n\tv34 = ~v54;\n\tif (v34) goto L_FFFFFFFF;\nL_008D:\n\tv74 = this.faceDirection == 2;\n\tif (v74) goto L_00D4;\n")]
		private void LookAtCompute()
		{
			Vector3 position = target.position;
			Transform transform = base.transform;
			Vector3 position2 = transform.position;
			float num = position.x - position2.x;
			float num2 = position.y - position2.y;
			float num3 = position.z - position2.z;
			float num4 = num * num;
			float num5 = num2 * num2;
			float num6 = num4 + num5;
			float num7 = num3 * num3;
			float f = num7 + num6;
			float num8 = Mathf.Sqrt(f);
			float num9 = num / num8;
			float num10 = num2 / num8;
			float num11 = num3 / num8;
			float num12 = 0f - num9;
			float num13 = 0f - num10;
			float num14 = 0f - num11;
			bool flag = !negateDirection;
			float z = (flag ? num11 : num14);
			float y = (flag ? num10 : num13);
			float x = (flag ? num9 : num12);
			if (faceDirection != FaceDirection.Right)
			{
				if (faceDirection != FaceDirection.Up)
				{
					if (faceDirection == FaceDirection.Forward)
					{
						Transform transform2 = base.transform;
						Vector3 forward = default(Vector3);
						forward.x = x;
						forward.y = y;
						forward.z = z;
						transform2.forward = forward;
					}
				}
				else
				{
					Transform transform3 = base.transform;
					Vector3 up = default(Vector3);
					up.x = x;
					up.y = y;
					up.z = z;
					transform3.up = up;
				}
			}
			else
			{
				Transform transform4 = base.transform;
				Vector3 right = default(Vector3);
				right.x = x;
				right.y = y;
				right.z = z;
				transform4.right = right;
			}
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x3C25670", Offset = "0x3C25670", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public AllIn1LookAt()
		{
		}
	}
}
