using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AllIn1VfxToolkit
{
	[Token(Token = "0x2000016")]
	public class AllIn1VfxScrollShaderProperty : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000067")]
		[FieldOffset(Offset = "0x20")]
		private string numericPropertyName;

		[SerializeField]
		[Token(Token = "0x4000068")]
		[FieldOffset(Offset = "0x28")]
		private float scrollSpeed;

		[Header("There are 3 modifiers, just pick 1")]
		[Space]
		[SerializeField]
		[Token(Token = "0x4000069")]
		[FieldOffset(Offset = "0x2C")]
		private bool backAndForth;

		[SerializeField]
		[Token(Token = "0x400006A")]
		[FieldOffset(Offset = "0x30")]
		private float maxValue;

		[Token(Token = "0x400006B")]
		[FieldOffset(Offset = "0x34")]
		private float iniValue;

		[Token(Token = "0x400006C")]
		[FieldOffset(Offset = "0x38")]
		private bool goingUp;

		[Space]
		[SerializeField]
		[Token(Token = "0x400006D")]
		[FieldOffset(Offset = "0x39")]
		private bool applyModulo;

		[SerializeField]
		[Token(Token = "0x400006E")]
		[FieldOffset(Offset = "0x3C")]
		private float modulo;

		[Space]
		[SerializeField]
		[Token(Token = "0x400006F")]
		[FieldOffset(Offset = "0x40")]
		private bool stopAtValue;

		[SerializeField]
		[Token(Token = "0x4000070")]
		[FieldOffset(Offset = "0x44")]
		private float stopValue;

		[Space]
		[SerializeField]
		[Header("If missing uses an instance of the currently used Material")]
		[Token(Token = "0x4000071")]
		[FieldOffset(Offset = "0x48")]
		private Material mat;

		[Token(Token = "0x4000072")]
		[FieldOffset(Offset = "0x50")]
		private Material originalMat;

		[Token(Token = "0x4000073")]
		[FieldOffset(Offset = "0x58")]
		private bool restoreMaterialOnDisable;

		[Token(Token = "0x4000074")]
		[FieldOffset(Offset = "0x5C")]
		private int propertyShaderID;

		[Token(Token = "0x4000075")]
		[FieldOffset(Offset = "0x60")]
		private float currValue;

		[Token(Token = "0x4000076")]
		[FieldOffset(Offset = "0x64")]
		private bool isValid;

		[Token(Token = "0x6000042")]
		[Address(RVA = "0x3C27420", Offset = "0x3C27420", Length = "0x3E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tv88 = this + 0x48;\n\tgoto L_001C;\nL_001C:\n\tv63 = UnityEngine.Object::op_Equality(this.mat, 0);\n\tv73 = ~v63;\n\tv159 = v88;\n\tif (v73) goto L_005B;\n\tv93 = UnityEngine.Component::GetComponent(this);\n\tv118 = UnityEngine.Renderer::get_material(v93);\n\t*([v88 @ X20_v14]) = v118;\n\tv263 = this.mat;\n\tv159 = v88;\n\tgoto L_0070;\nL_005B:\n\tv105 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v105, this.mat);\n\tthis.originalMat = v105;\n\tthis.restoreMaterialOnDisable = 1;\n\tv263 = this.mat;\n\tgoto L_0070;\nL_0070:\n\tv270 = UnityEngine.Object::op_Equality(v263, 0);\n\tv280 = ~v270;\n\tif (v280) goto L_00AC;\n\tv140 = UnityEngine.Component::get_gameObject(this);\n\tv296 = UnityEngine.Object::get_name(v140);\n\tv301 = System.String::Concat(v296, \" has no valid Material, deleting AllIn1VfxScrollShaderProperty component\");\n\tgoto L_008A;\nL_008A:\n\tgoto L_008D;\nL_008D:\n\tUnityEngine.Debug::LogError(v301);\n\tgoto L_009D;\nL_009D:\n\tUnityEngine.Object::Destroy(this);\n\treturn;\nL_00AC:\n\tv294 = UnityEngine.Material::HasProperty(this.mat, this.numericPropertyName);\n\tv297 = ~v294;\n\tif (v297) goto L_00D0;\n\tv304 = UnityEngine.Shader::PropertyToID(this.numericPropertyName);\n\tthis.propertyShaderID = v304;\n\tgoto L_00F9;\nL_00D0:\n\tv142 = UnityEngine.Component::get_gameObject(this);\n\tv332 = UnityEngine.Object::get_name(v142);\n\tv354 = System.String::Concat(v332, \"'s Material doesn't have a \", this.numericPropertyName, \" property\");\n\tgoto L_00E9;\nL_00E9:\n\tgoto L_00EC;\nL_00EC:\n\tUnityEngine.Debug::LogError(v354);\n\tgoto L_00F3;\nL_00F3:\n\tUnityEngine.Object::Destroy(this);\nL_00F9:\n\tv348 = UnityEngine.Material::GetFloat(*([v159 @ X20_v3]), this.propertyShaderID);\n\tthis.currValue = v348;\n\tv366 = this.backAndForth == 0;\n\tv243 = ~v366;\n\tif (v243) goto L_010C;\n\tv392 = this.stopAtValue != 1;\n\tif (v392) goto L_012E;\nL_010C:\n\tthis.iniValue = v348;\n\tv404 = v348 < this.maxValue;\n\tthis.goingUp = v404;\n\tv414 = ~v404;\n\tif (v414) goto L_012F;\n\tv433 = this.scrollSpeed < 0;\n\tv424 = ~v433;\n\tif (v424) goto L_012E;\nL_0123:\n\tv441 = -this.scrollSpeed;\n\tthis.scrollSpeed = v441;\nL_012F:\n\tv434 = this.scrollSpeed < 0;\n\tv431 = this.scrollSpeed == 0;\n\tv437 = this.scrollSpeed == this.scrollSpeed;\n\tv428 = ~v437;\n\tv444 = v434 == v428;\n\tv422 = ~v431;\n\tv425 = v444 & v422;\n\tif (v425) goto L_0123;\n\tgoto L_012E;\nL_012E:\n\treturn;\n")]
		private void Start()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AllIn1VfxScrollShaderProperty::Start");
		}

		[Token(Token = "0x6000043")]
		[Address(RVA = "0x3C278E4", Offset = "0x3C278E4", Length = "0x214")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tgoto L_001A;\nL_001A:\n\tv59 = UnityEngine.Object::op_Equality(this.mat, 0);\n\tv68 = ~v59;\n\tif (v68) goto L_0070;\n\tv93 = this.isValid != 1;\n\tif (v93) goto L_0050;\n\tv110 = UnityEngine.Component::get_gameObject(this);\n\tv279 = UnityEngine.Object::get_name(v110);\n\tv121 = System.String::Concat(\"The object \", v279, \" has no Material and you are trying to access it. Please take a look\");\n\tgoto L_0045;\nL_0070:\n\tv103 = UnityEngine.Time::get_deltaTime();\n\tv136 = this.scrollSpeed * v103;\n\tv137 = this.currValue + v136;\n\tthis.currValue = v137;\n\tv148 = this.backAndForth != 1;\n\tif (v148) goto L_00B3;\n\tv230 = this.goingUp != 1;\n\tif (v230) goto L_009A;\n\tv255 = v137 < this.maxValue;\n\tv282 = v137 == v137;\n\tv247 = this.maxValue == this.maxValue;\n\tv259 = v282 & v247;\n\tv241 = ~v259;\n\tv237 = v255 == v241;\n\tif (v237) goto L_00A4;\n\tgoto L_00B3;\nL_009A:\n\tv252 = v137 == this.iniValue;\n\tv283 = v137 < this.iniValue;\n\tv264 = ~v283;\n\tv285 = ~v252;\n\tv238 = v264 & v285;\n\tif (v238) goto L_00B3;\nL_00A4:\n\tv266 = this.goingUp ^ 1;\n\tthis.goingUp = v266;\n\tv232 = -this.scrollSpeed;\n\tthis.scrollSpeed = v232;\n\tv287 = 0x8BF6440(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v137, this.modulo, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tthis.currValue = v137;\n\tv321 = this.goingUp != 1;\n\tif (v321) goto L_00DD;\n\tv335 = v137 < this.stopValue;\n\tv347 = v137 == v137;\n\tv329 = this.stopValue == this.stopValue;\n\tv338 = v347 & v329;\n\tv326 = ~v338;\n\tv323 = v335 == v326;\n\tif (v323) goto L_00E7;\n\tgoto L_00F6;\nL_00DD:\n\tv333 = v137 == this.stopValue;\n\tv348 = v137 < this.stopValue;\n\tv342 = ~v348;\n\tv350 = ~v333;\n\tv324 = v342 & v350;\n\tif (v324) goto L_00F6;\nL_00E7:\n\tthis.scrollSpeed = 0f;\nL_00F6:\n\tUnityEngine.Material::SetFloat(this.mat, this.propertyShaderID, v137);\n\treturn;\nL_0050:\n\treturn;\nL_0045:\n\tUnityEngine.Debug::LogError(v121);\n\tthis.isValid = 0;\nL_00B3:\n\tv277 = this.applyModulo != 1;\n\tif (v277) goto L_00C2;\nL_00C2:\n\tv300 = this.stopAtValue != 1;\n\tif (v300) goto L_00F6;\n")]
		private void Update()
		{
			if (mat == null)
			{
				if (isValid)
				{
					GameObject gameObject = base.gameObject;
					string text = gameObject.name;
					string message = "The object " + text + " has no Material and you are trying to access it. Please take a look";
					Debug.LogError(message);
					isValid = false;
				}
				return;
			}
			float deltaTime = Time.deltaTime;
			float num = scrollSpeed * deltaTime;
			float num2 = (currValue += num);
			if (backAndForth)
			{
				if (goingUp)
				{
					bool flag = num2 < maxValue;
					bool flag2 = num2 == num2;
					bool flag3 = maxValue == maxValue;
					bool flag4 = flag2 && flag3;
					bool flag5 = !flag4;
					if (flag == flag5)
					{
						goto IL_01cf;
					}
				}
				else
				{
					bool flag6 = num2 == iniValue;
					bool flag7 = num2 < iniValue;
					bool flag8 = !flag7;
					bool flag9 = !flag6;
					if (!(flag8 && flag9))
					{
						goto IL_01cf;
					}
				}
			}
			goto IL_0347;
			IL_0347:
			if (applyModulo)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6440");
				currValue = num2;
			}
			if (stopAtValue)
			{
				if (goingUp)
				{
					bool flag10 = num2 < stopValue;
					bool flag11 = num2 == num2;
					bool flag12 = stopValue == stopValue;
					bool flag13 = flag11 && flag12;
					bool flag14 = !flag13;
					if (flag10 == flag14)
					{
						goto IL_0307;
					}
				}
				else
				{
					bool flag15 = num2 == stopValue;
					bool flag16 = num2 < stopValue;
					bool flag17 = !flag16;
					bool flag18 = !flag15;
					if (!(flag17 && flag18))
					{
						goto IL_0307;
					}
				}
			}
			goto IL_0317;
			IL_01cf:
			int num3 = (goingUp ? 1 : 0) ^ 1;
			goingUp = (byte)num3 != 0;
			float num4 = 0f - scrollSpeed;
			scrollSpeed = num4;
			goto IL_0347;
			IL_0307:
			scrollSpeed = 0f;
			goto IL_0317;
			IL_0317:
			mat.SetFloat(propertyShaderID, num2);
		}

		[Token(Token = "0x6000044")]
		[Address(RVA = "0x3C27AF8", Offset = "0x3C27AF8", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.goingUp ^ 1;\n\tthis.goingUp = v2;\n\tv4 = -this.scrollSpeed;\n\tthis.scrollSpeed = v4;\n\treturn;\n")]
		private void FlipGoingUp()
		{
			int num = (goingUp ? 1 : 0) ^ 1;
			goingUp = (byte)num != 0;
			float num2 = 0f - scrollSpeed;
			scrollSpeed = num2;
		}

		[Token(Token = "0x6000045")]
		[Address(RVA = "0x3C27808", Offset = "0x3C27808", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\nL_0012:\n\tv52 = 0xB292000 + 0x5A0;\n\tgoto L_0019;\nL_0019:\n\tUnityEngine.Debug::LogError(logError);\n\tv64 = *([v52 @ X22_v9 (System.Int32)]);\n\tv66 = *([v64 @ X0_v19+E4]) == 0;\n\tif (v66) goto L_004B;\n\tUnityEngine.Object::Destroy(this);\n\treturn;\nL_004B:\n\tUnityEngine.Object::Destroy(this);\n\treturn;\n")]
		private void DestroyComponentAndLogError(string logError)
		{
			//IL_002a: Expected O, but got I4
			int num = 187244544 + 1440;
			Debug.LogError(logError);
			object obj = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ X0_v19+E4]");
			if ((nint)0 != 0)
			{
				Object.Destroy(this);
			}
			else
			{
				Object.Destroy(this);
			}
		}

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x3C27B14", Offset = "0x3C27B14", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.restoreMaterialOnDisable != 1;\n\tif (v11) goto L_0014;\n\tUnityEngine.Material::CopyPropertiesFromMaterial(this.mat, this.originalMat);\n\treturn;\nL_0014:\n\treturn;\n")]
		private void OnDisable()
		{
			if (restoreMaterialOnDisable)
			{
				mat.CopyPropertiesFromMaterial(originalMat);
			}
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0x3C27B48", Offset = "0x3C27B48", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tthis.numericPropertyName = \"_HsvShift\";\n\tthis.maxValue = 1f;\n\tthis.modulo = 360f;\n\tthis.isValid = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public AllIn1VfxScrollShaderProperty()
		{
			numericPropertyName = "_HsvShift";
			maxValue = 1f;
			modulo = 360f;
			isValid = true;
		}
	}
}
