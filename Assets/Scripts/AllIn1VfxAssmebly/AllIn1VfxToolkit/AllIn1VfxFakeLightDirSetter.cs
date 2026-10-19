using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AllIn1VfxToolkit
{
	[ExecuteInEditMode]
	[Token(Token = "0x2000014")]
	public class AllIn1VfxFakeLightDirSetter : MonoBehaviour
	{
		[Header("This script gets executed in edit mode too")]
		[SerializeField]
		[Token(Token = "0x4000063")]
		[FieldOffset(Offset = "0x20")]
		private bool setOnAwake;

		[SerializeField]
		[Token(Token = "0x4000064")]
		[FieldOffset(Offset = "0x21")]
		private bool setOnUpdate;

		[Space]
		[Header("If target is null we'll use this object as target")]
		[Header("Direction is target's forward vector")]
		[SerializeField]
		[Token(Token = "0x4000065")]
		[FieldOffset(Offset = "0x28")]
		private Transform target;

		[Token(Token = "0x4000066")]
		[FieldOffset(Offset = "0x30")]
		private int lightDirId;

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x3C26BE8", Offset = "0x3C26BE8", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.setOnAwake != 1;\n\tif (v11) goto L_000E;\n\tAllIn1VfxToolkit.AllIn1VfxFakeLightDirSetter::SetGlobalFakeLightDir(this);\n\treturn;\nL_000E:\n\treturn;\n")]
		private void Awake()
		{
			if (setOnAwake)
			{
				SetGlobalFakeLightDir();
			}
		}

		[Token(Token = "0x6000038")]
		[Address(RVA = "0x3C26DE8", Offset = "0x3C26DE8", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.setOnUpdate != 1;\n\tif (v11) goto L_000E;\n\tAllIn1VfxToolkit.AllIn1VfxFakeLightDirSetter::SetGlobalFakeLightDir(this);\n\treturn;\nL_000E:\n\treturn;\n")]
		private void Update()
		{
			if (setOnUpdate)
			{
				SetGlobalFakeLightDir();
			}
		}

		[Token(Token = "0x6000039")]
		[Address(RVA = "0x3C26DFC", Offset = "0x3C26DFC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tAllIn1VfxToolkit.AllIn1VfxFakeLightDirSetter::SetGlobalFakeLightDir(this);\n\treturn;\n")]
		private void OnValidate()
		{
			SetGlobalFakeLightDir();
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0x3C26BFC", Offset = "0x3C26BFC", Length = "0x1EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = *([B78D3DC]) & 1;\n\tv27 = v26 == 0;\n\tif (v27) goto L_0063;\n\tv52 = 0xB292000 + 0x5A0;\n\tv31 = this.lightDirId == 0;\n\tv65 = v52;\n\tif (v31) goto L_006E;\nL_001A:\n\tv61 = *([v52 @ X22_v13 (System.Int32)]);\n\tv63 = *([v61 @ X0_v44+E4]) == 0;\n\tv78 = this.target;\n\tv93 = this.target;\n\tif (v63) goto L_007C;\nL_0021:\n\tv90 = UnityEngine.Object::op_Equality(v78, 0);\n\tv104 = ~v90;\n\tv105 = ~v104;\n\tif (v105) goto L_0081;\nL_0025:\n\tv135 = this.target;\nL_002A:\n\tv145 = UnityEngine.Transform::get_forward(v135);\n\tgoto L_0041;\nL_0043:\n\tv240 = v145 * v145;\n\tv241 = v145.y * v145.y;\n\tv242 = v240 + v241;\n\tv196 = v145.z * v145.z;\n\tv243 = v196 + v242;\n\tv194 = UnityEngine.Mathf::Sqrt(v243);\n\tv189 = v194 < 0x3727C5AC;\n\tv186 = v194 == 0x3727C5AC;\n\tv285 = v194 == v194;\n\tv174 = ~v285;\n\tv286 = v189 == v174;\n\tv287 = ~v286;\n\tv171 = v287 | v186;\n\tv268 = this.lightDirId;\n\tif (v171) goto L_0092;\n\tv258 = v145 / v194;\n\tv256 = v145.y / v194;\n\tv254 = v145.z / v194;\n\tv268 = this.lightDirId;\n\tgoto L_00AB;\nL_0063:\n\t*([B1933DC]) = 1;\n\tv52 = 0xB292000 + 0x5A0;\n\tv103 = this.lightDirId == 0;\n\tv55 = ~v103;\n\tv65 = v52;\n\tif (v55) goto L_001A;\nL_006E:\n\tv72 = UnityEngine.Shader::PropertyToID(\"_All1VfxLightDir\");\n\tthis.lightDirId = v72;\n\tv77 = *([v65 @ X22_v7 (System.Int32)]);\n\tv100 = *([v77 @ X0_v23+E4]) == 0;\n\tv82 = ~v100;\n\tv78 = this.target;\n\tv93 = this.target;\n\tif (v82) goto L_0021;\nL_007C:\n\tv109 = UnityEngine.Object::op_Equality(v93, 0);\n\tv116 = ~v109;\n\tif (v116) goto L_0025;\nL_0081:\n\tv131 = UnityEngine.Component::get_transform(this);\n\tthis.target = v131;\n\tv135 = this.target;\n\tv218 = this.target == 0;\n\tv140 = ~v218;\n\tif (v140) goto L_002A;\n\tthrow System.NullReferenceException;\nL_0092:\n\tgoto L_009B;\nL_0041:\n\tgoto L_0043;\nL_00AB:\n\t// 171 MakeStruct v282 @ AGG3C26DE4_1_v1 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v258 @ V0_v1 (System.Single), v256 @ V1_v1 (System.Single), v254 @ V2_v1 (System.Single), 0\n\tUnityEngine.Shader::SetGlobalVector(v268, v282);\n\treturn;\nL_009B:\n\tv256 = v235.zero.y;\n\tv254 = v235.zero.z;\n\tv258 = v235.zero;\n")]
		public void SetGlobalFakeLightDir()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AllIn1VfxFakeLightDirSetter::SetGlobalFakeLightDir");
		}

		[Token(Token = "0x600003B")]
		[Address(RVA = "0x3C26E00", Offset = "0x3C26E00", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = 0xB78D000;\n\tv32 = *([B78D3DD]) & 1;\n\tv33 = v32 == 0;\n\tif (v33) goto L_0042;\n\tv115 = this.lightDirId;\n\tv35 = this.lightDirId == 0;\n\tif (v35) goto L_004B;\nL_001E:\n\tv62 = *([B193A86]) & 1;\n\tv63 = v62 == 0;\n\tv94 = v115;\n\tif (v63) goto L_005A;\nL_0024:\n\tgoto L_0025;\nL_0025:\n\tv119 = newFakeLightDir * newFakeLightDir;\n\tv120 = newFakeLightDir.y * newFakeLightDir.y;\n\tv121 = v119 + v120;\n\tv122 = newFakeLightDir.z * newFakeLightDir.z;\n\tv123 = v122 + v121;\n\tv124 = UnityEngine.Mathf::Sqrt(v123);\n\tgoto L_003A;\nL_003A:\n\tv152 = newFakeLightDir / v124;\n\tv163 = newFakeLightDir.y / v124;\n\tv161 = newFakeLightDir.z / v124;\n\tgoto L_0082;\nL_0042:\n\t*([v30 @ X19_v1+3DD]) = 1;\n\tv115 = *([B193030]);\n\tv73 = *([B193030]) == 0;\n\tv53 = ~v73;\n\tif (v53) goto L_001E;\nL_004B:\n\tv72 = UnityEngine.Shader::PropertyToID(\"_All1VfxLightDir\");\n\t*([B193030]) = v72;\n\tv100 = *([B193A86]) & 1;\n\tv101 = v100 == 0;\n\tv79 = ~v101;\n\tv115 = v72;\n\tv94 = v72;\n\tif (v79) goto L_0024;\nL_005A:\n\t*([B193A86]) = 1;\n\tv115 = v94;\n\tgoto L_0025;\nL_0082:\n\t// 130 MakeStruct v178 @ AGG3C26F64_1_v1 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v152 @ V0_v5 (System.Single), v163 @ V1_v4 (System.Single), v161 @ V2_v3 (System.Single), 0\n\tUnityEngine.Shader::SetGlobalVector(v115, v178);\n\treturn;\n")]
		public void SetNewFakeLightDir(Vector3 newFakeLightDir)
		{
			//IL_0009: Expected O, but got I4
			object obj = 192466944;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78D3DD]");
			int num;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				num = lightDirId;
				if (lightDirId != 0)
				{
					goto IL_0065;
				}
			}
			else
			{
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B193030]");
				num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B193030]");
				if ((nint)0 != 0)
				{
					goto IL_0065;
				}
			}
			int num2 = Shader.PropertyToID("_All1VfxLightDir");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B193A86]");
			int num3 = (int)((nint)0 & (nint)1);
			bool flag = num3 == 0;
			bool flag2 = !flag;
			num = num2;
			int num4 = num2;
			if (flag2)
			{
				goto IL_00a5;
			}
			goto IL_0208;
			IL_00a5:
			float num5 = newFakeLightDir.x * newFakeLightDir.x;
			float num6 = newFakeLightDir.y * newFakeLightDir.y;
			float num7 = num5 + num6;
			float num8 = newFakeLightDir.z * newFakeLightDir.z;
			float f = num8 + num7;
			float num9 = Mathf.Sqrt(f);
			float x = newFakeLightDir.x / num9;
			float y = newFakeLightDir.y / num9;
			float z = newFakeLightDir.z / num9;
			Vector4 value = default(Vector4);
			value.x = x;
			value.y = y;
			value.z = z;
			value.w = 0f;
			Shader.SetGlobalVector(num, value);
			return;
			IL_0208:
			_ = 1;
			num = num4;
			goto IL_00a5;
			IL_0065:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B193A86]");
			int num10 = (int)((nint)0 & (nint)1);
			bool flag3 = num10 == 0;
			num4 = num;
			if (!flag3)
			{
				goto IL_00a5;
			}
			goto IL_0208;
		}

		[Token(Token = "0x600003C")]
		[Address(RVA = "0x3C26F68", Offset = "0x3C26F68", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.target = newTarget;\n\treturn;\n")]
		public void SetNewTarget(Transform newTarget)
		{
			target = newTarget;
		}

		[Token(Token = "0x600003D")]
		[Address(RVA = "0x3C26F70", Offset = "0x3C26F70", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.setOnUpdate = newSetOnUpdateValue;\n\treturn;\n")]
		public void SetOnUpdateBool(bool newSetOnUpdateValue)
		{
			setOnUpdate = newSetOnUpdateValue;
		}

		[Token(Token = "0x600003E")]
		[Address(RVA = "0x3C26F78", Offset = "0x3C26F78", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.setOnAwake = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public AllIn1VfxFakeLightDirSetter()
		{
			setOnAwake = true;
		}
	}
}
