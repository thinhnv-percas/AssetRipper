using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace ToonyColorsPro.Runtime
{
	[ExecuteInEditMode]
	[Token(Token = "0x2000007")]
	public class TCP2_PlanarReflection : MonoBehaviour
	{
		[Token(Token = "0x400002B")]
		[FieldOffset(Offset = "0x20")]
		public int textureSize;

		[Token(Token = "0x400002C")]
		[FieldOffset(Offset = "0x24")]
		public RenderTextureFormat renderTextureFormat;

		[Token(Token = "0x400002D")]
		[FieldOffset(Offset = "0x28")]
		public LayerMask reflectLayers;

		[Token(Token = "0x400002E")]
		[FieldOffset(Offset = "0x2C")]
		public float clipPlaneOffset;

		[Space]
		[Token(Token = "0x400002F")]
		[FieldOffset(Offset = "0x30")]
		public bool useCustomBackgroundColor;

		[Token(Token = "0x4000030")]
		[FieldOffset(Offset = "0x34")]
		public Color backgroundColor;

		[Space]
		[Token(Token = "0x4000031")]
		[FieldOffset(Offset = "0x44")]
		public bool applyBlur;

		[Range(1f, 4f)]
		[Token(Token = "0x4000032")]
		[FieldOffset(Offset = "0x48")]
		public int blurIterations;

		[Range(0.01f, 10f)]
		[Token(Token = "0x4000033")]
		[FieldOffset(Offset = "0x4C")]
		public float blurDistance;

		[Token(Token = "0x4000034")]
		[FieldOffset(Offset = "0x50")]
		private Camera reflectionCamera;

		[Token(Token = "0x4000035")]
		[FieldOffset(Offset = "0x58")]
		private RenderTexture reflectionRenderTexture;

		[Token(Token = "0x4000036")]
		[FieldOffset(Offset = "0x60")]
		private UniversalRenderPipeline.SingleCameraRequest renderReflectionCameraRequest;

		[Token(Token = "0x4000037")]
		[FieldOffset(Offset = "0x68")]
		private Shader blurShader;

		[Token(Token = "0x4000038")]
		[FieldOffset(Offset = "0x70")]
		private Material blurMaterial;

		[Token(Token = "0x4000039")]
		[FieldOffset(Offset = "0x78")]
		private CommandBuffer commandBufferBlur;

		[Token(Token = "0x400003A")]
		[FieldOffset(Offset = "0x80")]
		private Shader reflectionDepthShader;

		[Token(Token = "0x400003B")]
		[FieldOffset(Offset = "0x88")]
		private RenderTexture reflectionDepthRenderTexture;

		[Token(Token = "0x400003C")]
		[FieldOffset(Offset = "0x90")]
		private bool isURP;

		[Token(Token = "0x400003D")]
		private static bool s_InsideRendering;

		[Token(Token = "0x400003E")]
		private static readonly int _SamplingDistance;

		[Token(Token = "0x400003F")]
		private static readonly int _PlanarReflectionTempRT;

		[Token(Token = "0x4000040")]
		private static readonly int _ReflectionTex;

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x81989AC", Offset = "0x81989AC", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tToonyColorsPro.Runtime.TCP2_PlanarReflection::UpdateRenderTexture(this);\n\tToonyColorsPro.Runtime.TCP2_PlanarReflection::UpdateCommandBuffer(this);\n\treturn;\n")]
		private void OnValidate()
		{
			UpdateRenderTexture();
			UpdateCommandBuffer();
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x81991FC", Offset = "0x81991FC", Length = "0x298")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tv55 = 0xB292000 + 0x5A0;\n\tgoto L_0019;\nL_0019:\n\tv87 = UnityEngine.Rendering.GraphicsSettings::get_currentRenderPipeline();\n\tv67 = *([v55 @ X21_v15 (System.Int32)]);\n\tv69 = *([v67 @ X8_v28+E4]) == 0;\n\tif (v69) goto L_008A;\n\tv85 = UnityEngine.Object::op_Inequality(v87, 0);\n\tv98 = ~v85;\n\tif (v98) goto L_0090;\nL_0027:\n\tgoto L_002A;\nL_002A:\n\tv133 = UnityEngine.Rendering.GraphicsSettings::get_currentRenderPipeline();\n\tv143 = System.Object::GetType(v133);\n\tv144 = System.Reflection.MemberInfo::get_Name(v143);\n\tv145 = System.String::Contains(v144, \"Universal\");\n\tthis.isURP = v145;\n\tv164 = ~v145;\n\tif (v164) goto L_009B;\n\tv336 = new System.Action`2<UnityEngine.Rendering.ScriptableRenderContext, UnityEngine.Camera>();\n\tSystem.Action`2<UnityEngine.Rendering.ScriptableRenderContext, UnityEngine.Camera>::.ctor(v336, this, Il2CppMethodInfo);\n\tgoto L_0056;\nL_0056:\n\tUnityEngine.Rendering.RenderPipelineManager::add_beginCameraRendering(v336);\nL_FFFFFFFF:\n\t;\n\tgoto L_00CB;\nL_008A:\n\tv102 = UnityEngine.Object::op_Inequality(v87, 0);\n\tv126 = ~v102;\n\tv111 = ~v126;\n\tif (v111) goto L_0027;\nL_0090:\n\tthis.isURP = 0;\n\tv253 = v248 == 0;\n\tif (v253) goto L_00C7;\n\tv266 = *([v248 @ X0_v5 (System.Delegate)]) != UnityEngine.Camera+CameraCallback;\n\tif (v266) goto L_00C4;\n\tv292.onPreCull = v248;\n\tv298 = *([v248 @ X0_v5 (System.Delegate)]) == UnityEngine.Camera+CameraCallback;\n\tif (v298) goto L_FFFFFFFF;\nL_00C4:\n\tthrow System.InvalidCastException;\nL_00C7:\n\tv290.onPreCull = 0;\nL_00CB:\n\tToonyColorsPro.Runtime.TCP2_PlanarReflection::UpdateRenderTexture(this);\n\tToonyColorsPro.Runtime.TCP2_PlanarReflection::UpdateCommandBuffer(this);\n\treturn;\nL_009B:\n\tv177 = new UnityEngine.Camera+CameraCallback();\n\tUnityEngine.Camera+CameraCallback::.ctor(v177, this, Il2CppMethodInfo);\n\tv248 = System.Delegate::Combine(v174.onPreCull, v177);\nL_FFFFFFFF:\n\t;\n")]
		private void OnEnable()
		{
			//IL_002a: Expected O, but got I4
			int num = 187244544 + 1440;
			RenderPipelineAsset currentRenderPipeline = GraphicsSettings.currentRenderPipeline;
			object obj = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ X8_v28+E4]");
			if ((nint)0 != 0)
			{
				if (currentRenderPipeline != null)
				{
					goto IL_007b;
				}
			}
			else if (currentRenderPipeline != null)
			{
				goto IL_007b;
			}
			isURP = false;
			goto IL_01ee;
			IL_01dc:
			UpdateRenderTexture();
			UpdateCommandBuffer();
			return;
			IL_01ee:
			Camera.CameraCallback b = BeginCameraRendering;
			Delegate obj2 = Delegate.Combine(Camera.onPreCull, b);
			if ((object)obj2 != null)
			{
				if ((object)obj2.GetType() == typeof(Camera.CameraCallback))
				{
					Camera.onPreCull = (Camera.CameraCallback)obj2;
					if ((object)obj2.GetType() == typeof(Camera.CameraCallback))
					{
						goto IL_01dc;
					}
				}
				throw new InvalidCastException();
			}
			Camera.onPreCull = null;
			goto IL_01dc;
			IL_007b:
			RenderPipelineAsset currentRenderPipeline2 = GraphicsSettings.currentRenderPipeline;
			Type type = currentRenderPipeline2.GetType();
			string text = type.Name;
			if (isURP = text.Contains("Universal"))
			{
				Action<ScriptableRenderContext, Camera> value = BeginCameraRendering;
				RenderPipelineManager.beginCameraRendering += value;
				goto IL_01dc;
			}
			goto IL_01ee;
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x8199494", Offset = "0x8199494", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv68 = new System.Action`2<UnityEngine.Rendering.ScriptableRenderContext, UnityEngine.Camera>();\n\tSystem.Action`2<UnityEngine.Rendering.ScriptableRenderContext, UnityEngine.Camera>::.ctor(v68, this, Il2CppMethodInfo);\n\tgoto L_0046;\nL_0046:\n\tUnityEngine.Rendering.RenderPipelineManager::remove_beginCameraRendering(v68);\nL_FFFFFFFF:\n\t;\n\tgoto L_0082;\nL_0052:\n\tv79 = new UnityEngine.Camera+CameraCallback();\n\tUnityEngine.Camera+CameraCallback::.ctor(v79, this, Il2CppMethodInfo);\n\tv101 = System.Delegate::Remove(v76.onPreCull, v79);\n\tv110 = v101 == 0;\n\tif (v110) goto L_007E;\n\tv124 = *([v101 @ X0_v8 (System.Delegate)]) != UnityEngine.Camera+CameraCallback;\n\tif (v124) goto L_007B;\n\tv185.onPreCull = v101;\n\tv191 = *([v101 @ X0_v8 (System.Delegate)]) == UnityEngine.Camera+CameraCallback;\n\tif (v191) goto L_FFFFFFFF;\nL_007B:\n\tthrow System.InvalidCastException;\nL_007E:\n\tv149.onPreCull = 0;\nL_0082:\n\tToonyColorsPro.Runtime.TCP2_PlanarReflection::ClearCommandBuffer(this);\n\tToonyColorsPro.Runtime.TCP2_PlanarReflection::ClearRenderTexture(this);\n\treturn;\nL_002F:\n\tv57 = this.isURP != 1;\n\tif (v57) goto L_0052;\nL_FFFFFFFF:\n\t;\n")]
		private void OnDisable()
		{
			if (isURP)
			{
				Action<ScriptableRenderContext, Camera> value = BeginCameraRendering;
				RenderPipelineManager.beginCameraRendering -= value;
			}
			else
			{
				Camera.CameraCallback value2 = BeginCameraRendering;
				Delegate obj = Delegate.Remove(Camera.onPreCull, value2);
				if ((object)obj != null)
				{
					if ((object)obj.GetType() == typeof(Camera.CameraCallback))
					{
						Camera.onPreCull = (Camera.CameraCallback)obj;
						if ((object)obj.GetType() == typeof(Camera.CameraCallback))
						{
							goto IL_00db;
						}
					}
					throw new InvalidCastException();
				}
				Camera.onPreCull = null;
			}
			goto IL_00db;
			IL_00db:
			ClearCommandBuffer();
			ClearRenderTexture();
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x81989D0", Offset = "0x81989D0", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tv148 = this + 0x58;\n\tgoto L_001C;\nL_001C:\n\tv63 = UnityEngine.Object::op_Equality(this.reflectionRenderTexture, 0);\n\tv74 = v63 == 0;\n\tif (v74) goto L_0040;\n\tgoto L_0068;\nL_0040:\n\tv90 = this.reflectionRenderTexture;\n\tv154 = this.reflectionRenderTexture->klass;\n\t*([v154 @ X8_v8+188])(v141, v90, *([v154 @ X8_v8+190]), 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv98 = v141 != this.textureSize;\n\tif (v98) goto L_0068;\n\tv140 = UnityEngine.RenderTexture::get_format(*([v148 @ X20_v5]));\n\tv117 = v140 == this.renderTextureFormat;\n\tif (v117) goto L_00AF;\nL_0068:\n\tToonyColorsPro.Runtime.TCP2_PlanarReflection::ClearRenderTexture(this);\n\tv207 = new UnityEngine.RenderTexture();\n\tUnityEngine.RenderTexture::.ctor(v207, this.textureSize, this.textureSize, 0x10, this.renderTextureFormat, 2);\n\tv269 = UnityEngine.Random::Range(0x3E8, 0x270F);\n\tv158 = v269;\n\tv199 = 0xB7D5000 + 0x538;\n\tv274 = \"il2cpp_vm_object_box\"(*([v199 @ X8_v6 (System.Int32)+48]), &v158 @ stack_-44_v3 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv188 = System.String::Format(\"Planar Reflection {0}\", v274);\n\tUnityEngine.Object::set_name(v207, v188);\n\tUnityEngine.Object::set_hideFlags(v207, 0x3D);\n\t*([v148 @ X20_v5]) = v207;\n\tv189 = new UnityEngine.Rendering.Universal.UniversalRenderPipeline+SingleCameraRequest();\n\tUnityEngine.Rendering.Universal.UniversalRenderPipeline+SingleCameraRequest::.ctor(v189);\n\tv189.destination = this.reflectionRenderTexture;\n\tthis.renderReflectionCameraRequest = v189;\n\tToonyColorsPro.Runtime.TCP2_PlanarReflection::AssignRenderTextureToMaterials(this);\nL_00AF:\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateRenderTexture()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TCP2_PlanarReflection::UpdateRenderTexture");
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x8199828", Offset = "0x8199828", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv56 = UnityEngine.Renderer::get_sharedMaterials(v51);\n\tv119 = v56.Length < 1;\n\tif (v119) goto L_006C;\n\tv66 = 0;\n\tgoto L_004F;\nL_003C:\n\tUnityEngine.Material::SetTexture(v56[v66 @ X22_v5 (System.Int32)], v212._ReflectionTex, this.reflectionRenderTexture);\nL_003E:\n\tv66 = v66 + 1;\n\tv174 = v66 >= v56.Length;\n\tif (v174) goto L_006C;\nL_004F:\n\tgoto L_0058;\nL_0058:\n\tv201 = UnityEngine.Material::HasProperty(v56[v66 @ X22_v5 (System.Int32)], v197._ReflectionTex);\n\tv202 = ~v201;\n\tif (v202) goto L_003E;\n\tgoto L_003C;\nL_006C:\n\treturn;\nL_001D:\n\tv51 = UnityEngine.Component::GetComponent(this);\n")]
		private void AssignRenderTextureToMaterials()
		{
			Renderer component = GetComponent<Renderer>();
			Material[] sharedMaterials = component.sharedMaterials;
			if (sharedMaterials.Length < 1)
			{
				return;
			}
			int num = 0;
			do
			{
				if (sharedMaterials[num].HasProperty(_ReflectionTex))
				{
					sharedMaterials[num].SetTexture(_ReflectionTex, reflectionRenderTexture);
				}
				num++;
			}
			while (num < sharedMaterials.Length);
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x8199738", Offset = "0x8199738", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Inequality(this.reflectionRenderTexture, 0);\n\tv63 = ~v55;\n\tif (v63) goto L_004A;\n\tUnityEngine.RenderTexture::Release(this.reflectionRenderTexture);\n\tgoto L_002E;\nL_002E:\n\tUnityEngine.Object::DestroyImmediate(this.reflectionRenderTexture);\n\treturn;\nL_004A:\n\treturn;\n")]
		private void ClearRenderTexture()
		{
			if (reflectionRenderTexture != null)
			{
				reflectionRenderTexture.Release();
				UnityEngine.Object.DestroyImmediate(reflectionRenderTexture);
			}
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x8198BE0", Offset = "0x8198BE0", Length = "0x61C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0032;\n\tToonyColorsPro.Runtime.TCP2_PlanarReflection::ClearCommandBuffer(this);\nL_0040:\n\tv74 = this.applyBlur != 1;\n\tif (v74) goto L_022B;\n\tgoto L_004E;\nL_004E:\n\tv286 = UnityEngine.Object::op_Equality(this.blurMaterial, 0);\n\tv432 = ~v286;\n\tv433 = ~v432;\n\tif (v433) goto L_0060;\n\tgoto L_00C2;\nL_0060:\n\tgoto L_0064;\nL_0064:\n\tv473 = UnityEngine.Object::op_Equality(this.blurShader, 0);\n\tv482 = ~v473;\n\tv483 = ~v482;\n\tif (v483) goto L_0074;\n\tgoto L_00B0;\nL_0074:\n\tv503 = UnityEngine.Shader::Find(\"Hidden/TCP2 Gaussian Blur Filter\");\n\tthis.blurShader = v503;\n\tgoto L_0081;\nL_0081:\n\tv668 = UnityEngine.Object::op_Equality(this.blurShader, 0);\n\tv671 = ~v668;\n\tif (v671) goto L_00B0;\n\tv709 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_00A2;\nL_00A2:\n\tUnityEngine.Debug::LogError(\"[TCP2 Planar Reflection] Can't find Gaussian Blur Filter shader!\", v709);\n\treturn;\nL_00B0:\n\tv676 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v676, this.blurShader);\n\tthis.blurMaterial = v676;\n\tUnityEngine.Object::set_name(this.blurMaterial, \"Planar Reflection Blur\");\nL_00C2:\n\tv491 = UnityEngine.Screen::get_width();\n\tgoto L_00D6;\nL_00D6:\n\tv508 = this.textureSize * 0x3A800000;\n\tv509 = v508 * v491;\n\tv514 = v509 / 0x44870000;\n\tv194 = v514 * this.blurDistance;\n\tUnityEngine.Material::SetFloat(this.blurMaterial, v511._SamplingDistance, v194);\n\tgoto L_00EA;\nL_00EA:\n\tv252 = UnityEngine.Object::op_Equality(this.reflectionRenderTexture, 0);\n\tv259 = v252 == 0;\n\tif (v259) goto L_00FE;\n\tgoto L_022B;\nL_00FE:\n\tgoto L_0101;\nL_0101:\n\tv254 = UnityEngine.Object::op_Equality(this.reflectionCamera, 0);\n\tv261 = v254 == 0;\n\tif (v261) goto L_0114;\n\tgoto L_022B;\nL_0114:\n\tv731 = new UnityEngine.Rendering.CommandBuffer();\n\tUnityEngine.Rendering.CommandBuffer::.ctor(v731);\n\tthis.commandBufferBlur = v731;\n\tgoto L_012C;\nL_012C:\n\tv637 = UnityEngine.RenderTexture::get_format(this.reflectionRenderTexture);\n\tUnityEngine.Rendering.CommandBuffer::GetTemporaryRT(this.commandBufferBlur, v196._PlanarReflectionTempRT, this.textureSize, this.textureSize, 0x10, 1, v637, 2);\n\tv751 = UnityEngine.Rendering.RenderTargetIdentifier::op_Implicit(this.reflectionRenderTexture);\n\tv638 = UnityEngine.Rendering.RenderTargetIdentifier::op_Implicit(v753._PlanarReflectionTempRT);\n\tv205 = &v749 @ stack_-88;\n\tv583 = *([v205 @ X23_v6]);\n\tv762 = v584;\n\tUnityEngine.Rendering.CommandBuffer::CopyTexture(this.commandBufferBlur, &v583 @ stack_-E0_v7 (UnityEngine.Rendering.BuiltinRenderTextureType), &v762 @ stack_-110_v3);\n\tv771 = &v583 @ stack_-E0_v7 (UnityEngine.Rendering.BuiltinRenderTextureType);\n\tv773 = UnityEngine.Rendering.RenderTargetIdentifier::op_Implicit(v769._PlanarReflectionTempRT);\n\tv583 = *([v771 @ X8_v28]);\n\tv654 = &v762 @ stack_-110_v3;\n\tv639 = UnityEngine.Rendering.RenderTargetIdentifier::op_Implicit(this.reflectionRenderTexture);\n\tv762 = *([v654 @ X8_v29]);\n\tv805 = *([v771 @ X8_v28]);\n\tv99 = *([v654 @ X8_v29]);\n\tUnityEngine.Rendering.CommandBuffer::Blit(this.commandBufferBlur, &v805 @ stack_-140_v6 (UnityEngine.Rendering.BuiltinRenderTextureType), &v99 @ stack_-170_v3, this.blurMaterial, 0);\n\tv801 = this.blurIterations < 1;\n\tif (v801) goto L_0208;\n\tv619 = 0;\n\tUnityEngine.Rendering.CommandBuffer::Blit(this.commandBufferBlur, this.reflectionRenderTexture, &v584 @ stack_-B0_v3, this.blurMaterial, 1);\n\tv875 = UnityEngine.Rendering.RenderTargetIdentifier::op_Implicit(v871._PlanarReflectionTempRT);\n\tv641 = UnityEngine.Rendering.RenderTargetIdentifier::op_Implicit(this.reflectionRenderTexture);\n\tv762 = v584;\n\tv805 = v641.m_Type;\n\tUnityEngine.Rendering.CommandBuffer::Blit(this.commandBufferBlur, &v762 @ stack_-110_v3, &v805 @ stack_-140_v6 (UnityEngine.Rendering.BuiltinRenderTextureType), this.blurMaterial, 2);\n\tv619 = v619 + 1;\n\tv818 = v619 < this.blurIterations;\n\tif (v818) goto L_01A0;\nL_0208:\n\tgoto L_0211;\nL_0211:\n\tUnityEngine.Rendering.CommandBuffer::ReleaseTemporaryRT(this.commandBufferBlur, v862._PlanarReflectionTempRT);\n\tv864 = this.isURP == 0;\n\tv263 = ~v864;\n\tif (v263) goto L_022B;\n\tUnityEngine.Camera::AddCommandBuffer(this.reflectionCamera, 0x14, this.commandBufferBlur);\nL_022B:\n\treturn;\nL_0032:\n\tv58 = this.commandBufferBlur == 0;\n\tif (v58) goto L_0040;\nL_01A7:\n\tv640 = UnityEngine.Rendering.RenderTargetIdentifier::op_Implicit(v859._PlanarReflectionTempRT);\nL_01A0:\n\tgoto L_01A7;\n")]
		private unsafe void UpdateCommandBuffer()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TCP2_PlanarReflection::UpdateCommandBuffer");
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x8199624", Offset = "0x8199624", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Inequality(this.reflectionCamera, 0);\n\tv63 = ~v55;\n\tv64 = ~v63;\n\tif (v64) goto L_0033;\n\tgoto L_004E;\nL_0033:\n\tv114 = UnityEngine.Camera::get_commandBufferCount(this.reflectionCamera);\n\tv81 = v114 < 1;\n\tif (v81) goto L_004E;\n\tv183 = this.isURP == 0;\n\tv117 = ~v183;\n\tif (v117) goto L_004E;\n\tUnityEngine.Camera::RemoveCommandBuffer(this.reflectionCamera, 0x14, this.commandBufferBlur);\nL_004E:\n\tv123 = this.commandBufferBlur == 0;\n\tif (v123) goto L_006A;\n\tUnityEngine.Rendering.CommandBuffer::Clear(this.commandBufferBlur);\n\tUnityEngine.Rendering.CommandBuffer::Release(this.commandBufferBlur);\n\tthis.commandBufferBlur = 0;\n\treturn;\nL_006A:\n\treturn;\n")]
		private void ClearCommandBuffer()
		{
			if (reflectionCamera != null)
			{
				int commandBufferCount = reflectionCamera.commandBufferCount;
				if (commandBufferCount >= 1 && !isURP)
				{
					reflectionCamera.RemoveCommandBuffer(CameraEvent.AfterEverything, commandBufferBlur);
				}
			}
			if (commandBufferBlur != null)
			{
				commandBufferBlur.Clear();
				commandBufferBlur.Release();
				commandBufferBlur = null;
			}
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x8199940", Offset = "0x8199940", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tToonyColorsPro.Runtime.TCP2_PlanarReflection::BeginCameraRendering(this, 0, cam);\n\treturn;\n")]
		private void BeginCameraRendering(Camera cam)
		{
			BeginCameraRendering(default(ScriptableRenderContext), cam);
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x819994C", Offset = "0x819994C", Length = "0x244")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\nL_002B:\n\tv55 = UnityEngine.Camera::get_cameraType(cam);\n\tv104 = v55 & 3;\n\tv74 = v104 == 0;\n\tif (v74) goto L_004C;\n\tgoto L_003E;\nL_003E:\n\tv166 = UnityEngine.Object::op_Equality(this.reflectionCamera, 0);\n\tv204 = ~v166;\n\tv205 = ~v204;\n\tif (v205) goto L_0058;\n\tgoto L_00B1;\nL_004C:\n\treturn;\nL_0058:\n\t// 88 NewArr v218 @ X0_v16 (System.Type[]), typeof(System.Type[]), 1\n\tgoto L_0067;\nL_0067:\n\tv85 = System.Type::GetTypeFromHandle(UnityEngine.Camera);\n\tv236 = v85 == 0;\n\tif (v236) goto L_0078;\n\tv153 = 0x21C11D0(v85, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv155 = v153 == 0;\n\tif (v155) goto L_00B5;\nL_0078:\n\tv218[0] = v85;\n\tv86 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v86, \"Planar Reflection Camera\", v218);\n\tv251 = UnityEngine.GameObject::GetComponent(v86);\n\tthis.reflectionCamera = v251;\n\tUnityEngine.Behaviour::set_enabled(this.reflectionCamera, 0);\n\tUnityEngine.Object::set_hideFlags(v86, 0x3D);\n\tToonyColorsPro.Runtime.TCP2_PlanarReflection::UpdateRenderTexture(this);\n\tToonyColorsPro.Runtime.TCP2_PlanarReflection::UpdateCommandBuffer(this);\n\tUnityEngine.Camera::set_targetTexture(this.reflectionCamera, this.reflectionRenderTexture);\nL_00B1:\n\tToonyColorsPro.Runtime.TCP2_PlanarReflection::RenderPlanarReflection(this, context, cam);\n\treturn;\nL_00B5:\n\tv159 = new System.ArrayTypeMismatchException();\n\tthrow v159;\n")]
		private void BeginCameraRendering(ScriptableRenderContext context, Camera cam)
		{
			CameraType cameraType = cam.cameraType;
			if ((cameraType & (CameraType.Game | CameraType.SceneView)) == 0)
			{
				return;
			}
			if (reflectionCamera == null)
			{
				Type[] array = new Type[1];
				Type typeFromHandle = typeof(Camera);
				if ((object)typeFromHandle != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj = default(object);
					if (obj == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				array[0] = typeFromHandle;
				GameObject gameObject = new GameObject("Planar Reflection Camera", array);
				Camera component = gameObject.GetComponent<Camera>();
				reflectionCamera = component;
				reflectionCamera.enabled = false;
				gameObject.hideFlags = HideFlags.HideAndDontSave;
				UpdateRenderTexture();
				UpdateCommandBuffer();
				reflectionCamera.targetTexture = reflectionRenderTexture;
			}
			RenderPlanarReflection(context, cam);
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x8199B90", Offset = "0x8199B90", Length = "0x4F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = context;\n\tgoto L_0020;\nL_0020:\n\tgoto L_0024;\nL_0024:\n\tv74 = UnityEngine.Object::op_Equality(worldCamera, 0);\n\tv83 = v74 == 0;\n\tif (v83) goto L_0047;\n\tgoto L_01ED;\nL_0047:\n\tv99 = UnityEngine.Behaviour::get_enabled(this);\n\tv404 = ~v99;\n\tif (v404) goto L_01ED;\n\tgoto L_0053;\nL_0053:\n\tv405 = v411.s_InsideRendering == 0;\n\tif (v405) goto L_0061;\n\tgoto L_01ED;\nL_0061:\n\tgoto L_0066;\n\tv680 = UnityEngine.Transform::get_position(v675);\n\tv722 = UnityEngine.Transform::get_up(v675);\n\tUnityEngine.Camera::CopyFrom(this.reflectionCamera, worldCamera);\n\tv694 = this.useCustomBackgroundColor != 1;\n\tif (v694) goto L_009E;\n\tUnityEngine.Camera::set_clearFlags(this.reflectionCamera, 2);\n\t// 156 MakeStruct v792 @ AGG8199D44_1_v4 (UnityEngine.Color), typeof(UnityEngine.Color), this.backgroundColor (UnityEngine.Color), this.backgroundColor.g (System.Single), this.backgroundColor.b (System.Single), this.backgroundColor.a (System.Single)\n\tUnityEngine.Camera::set_backgroundColor(this.reflectionCamera, v792);\nL_009E:\n\tv804 = v680 * v722;\n\tv805 = v680.y * v722.y;\n\tv806 = v804 + v805;\n\tv807 = v680.z * v722.z;\n\tv808 = v807 + v806;\n\tv810 = -v808;\n\tv336 = v810 - this.clipPlaneOffset;\n\tv814 = UnityEngine.Matrix4x4::get_zero();\n\tgoto L_00AF;\nL_00AF:\n\tv820 = v722 + v722;\n\tv821 = v722 * v820;\n\tv822 = 1f - v821;\n\tv824 = v722 * -2f;\n\tv825 = v722.y * v824;\n\tv826 = v722.z * v824;\n\tv691 = v336 * -2f;\n\tv325 = v822;\n\tv319 = v825;\n\tv830 = v722 * v691;\n\tv313 = v826;\n\tv307 = v830;\n\tv831 = v722.z * -2f;\n\tv713 = v722 * v831;\n\tv301 = v713;\n\tv832 = v722.y * v831;\n\tv298 = v832;\n\tv833 = v722.z + v722.z;\n\tv834 = v722.z * v833;\n\tv835 = 1f - v834;\n\tv295 = v835;\n\tv723 = v722.z * v691;\n\tv292 = v723;\n\tv779 = &v206 @ stack_-188;\n\tv839 = UnityEngine.Camera::get_worldToCameraMatrix(worldCamera);\n\tv229 = *([v779 @ X22_v6+C0]);\n\tv217 = *([v779 @ X22_v6+40]);\n\tv755 = UnityEngine.Matrix4x4::op_Multiply(&v217 @ stack_-1D0_v5 (System.Single), &v229 @ stack_-210_v4 (System.Single));\n\tv217 = *([v779 @ X22_v6]);\n\tUnityEngine.Camera::set_worldToCameraMatrix(this.reflectionCamera, &v217 @ stack_-1D0_v5 (System.Single));\n\tv725 = ToonyColorsPro.Runtime.TCP2_PlanarReflection::CameraSpacePlane(this.reflectionCamera, v680, v722, 1f, this.clipPlaneOffset);\n\tv863 = UnityEngine.Camera::CalculateObliqueMatrix(worldCamera, v725);\n\tv229 = v863.m00;\n\tUnityEngine.Camera::set_projectionMatrix(this.reflectionCamera, &v229 @ stack_-210_v4 (System.Single));\n\tUnityEngine.Camera::set_targetTexture(this.reflectionCamera, this.reflectionRenderTexture);\n\tv758 = UnityEngine.Component::get_gameObject(this);\n\tv869 = UnityEngine.GameObject::get_layer(v758);\n\tv759 = UnityEngine.LayerMask::get_value(&this.reflectLayers (UnityEngine.LayerMask));\n\tv784 = 1 << v869;\n\tv872 = ~v784;\n\tv745 = v759 & v872;\n\tUnityEngine.Camera::set_cullingMask(this.reflectionCamera, v745);\n\tv875 = UnityEngine.Component::get_transform(this.reflectionCamera);\n\tv761 = UnityEngine.Component::get_transform(worldCamera);\n\tv878 = UnityEngine.Transform::get_position(v761);\n\tv727 = UnityEngine.Matrix4x4::MultiplyPoint(&v325 @ stack_-C8_v3 (UnityEngine.Matrix4x4), v878);\n\tUnityEngine.Transform::set_position(v875, v727);\n\tv763 = UnityEngine.Component::get_transform(worldCamera);\n\tv885 = UnityEngine.Transform::get_eulerAngles(v763);\n\t// 407 MakeStruct v106 @ AGG8199FB0_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v885.y (System.Single), v885.z (System.Single)\n\tUnityEngine.Transform::set_eulerAngles(v875, v106);\n\tUnityEngine.GL::set_invertCulling(1);\n\tv695 = this.isURP != 1;\n\tif (v695) goto L_01CE;\n\tUnityEngine.Rendering.RenderPipeline::SubmitRenderRequest(this.reflectionCamera, this.renderReflectionCameraRequest);\n\tv904 = this.applyBlur != 1;\n\tif (v904) goto L_01D1;\n\tv907 = this.commandBufferBlur == 0;\n\tif (v907) goto L_01D1;\n\tgoto L_01C9;\nL_01CE:\n\tUnityEngine.Camera::Render(this.reflectionCamera);\nL_01D1:\n\tUnityEngine.GL::set_invertCulling(0);\n\tgoto L_01DA;\nL_01ED:\n\treturn;\nL_0066:\n\tv671.s_InsideRendering = 1;\n\tv675 = UnityEngine.Component::get_transform(this);\nL_01C9:\n\tUnityEngine.Rendering.ScriptableRenderContext::ExecuteCommandBuffer(&v38 @ stack_-88_v1 (UnityEngine.Rendering.ScriptableRenderContext), this.commandBufferBlur);\n\tgoto L_01D1;\nL_01DA:\n\tv410.s_InsideRendering = 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void RenderPlanarReflection(ScriptableRenderContext context, Camera worldCamera)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TCP2_PlanarReflection::RenderPlanarReflection");
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x819A130", Offset = "0x819A130", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv39 = normal.z * clipPlaneOffset;\n\tv41 = pos.z + v39;\n\tv42 = normal.y * clipPlaneOffset;\n\tv43 = pos.y + v42;\n\tv44 = normal * clipPlaneOffset;\n\tv45 = pos + v44;\n\tv49 = UnityEngine.Camera::get_worldToCameraMatrix(cam);\n\tv76 = v49;\n\t// 62 MakeStruct v87 @ AGG819A1AC_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v45 @ V11_v1 (System.Single), v43 @ V10_v1 (System.Single), v41 @ V9_v1 (System.Single)\n\tv88 = UnityEngine.Matrix4x4::MultiplyPoint(&v76 @ stack_-A0_v1 (UnityEngine.Matrix4x4), v87);\n\tv100 = UnityEngine.Matrix4x4::MultiplyVector(&v76 @ stack_-A0_v1 (UnityEngine.Matrix4x4), normal);\n\tgoto L_0062;\nL_0064:\n\tv231 = v100 * v100;\n\tv232 = v100.y * v100.y;\n\tv233 = v231 + v232;\n\tv234 = v100.z * v100.z;\n\tv235 = v234 + v233;\n\tv236 = UnityEngine.Mathf::Sqrt(v235);\n\tgoto L_0079;\nL_0079:\n\tv256 = v100 / v236;\n\tgoto L_008F;\nL_0062:\n\tgoto L_0064;\nL_008F:\n\treturnVal2 = v256 * sideSign;\n\treturn returnVal2;\n")]
		private static Vector4 CameraSpacePlane(Camera cam, Vector3 pos, Vector3 normal, float sideSign, float clipPlaneOffset)
		{
			float num = normal.z * clipPlaneOffset;
			float z = pos.z + num;
			float num2 = normal.y * clipPlaneOffset;
			float y = pos.y + num2;
			float num3 = normal.x * clipPlaneOffset;
			float x = pos.x + num3;
			Matrix4x4 worldToCameraMatrix = cam.worldToCameraMatrix;
			Matrix4x4 matrix4x = worldToCameraMatrix;
			Vector3 point = default(Vector3);
			point.x = x;
			point.y = y;
			point.z = z;
			Vector3 vector = matrix4x.MultiplyPoint(point);
			Vector3 vector2 = matrix4x.MultiplyVector(normal);
			float num4 = vector2.x * vector2.x;
			float num5 = vector2.y * vector2.y;
			float num6 = num4 + num5;
			float num7 = vector2.z * vector2.z;
			float f = num7 + num6;
			float num8 = Mathf.Sqrt(f);
			float num9 = vector2.x / num8;
			float x2 = num9 * sideSign;
			Vector4 result = default(Vector4);
			result.x = x2;
			return result;
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x819A088", Offset = "0x819A088", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = plane + plane;\n\tv5 = plane * v4;\n\tv7 = 1f - v5;\n\treflectionMat.m00 = v7;\n\tv10 = plane * -2f;\n\tv11 = plane.y * v10;\n\treflectionMat.m01 = v11;\n\tv12 = plane.z * v10;\n\treflectionMat.m02 = v12;\n\tv13 = plane.w * -2f;\n\tv14 = plane * v13;\n\treflectionMat.m03 = v14;\n\tv15 = plane.y * -2f;\n\tv16 = plane * v15;\n\treflectionMat.m10 = v16;\n\tv17 = plane.y + plane.y;\n\tv18 = plane.y * v17;\n\tv19 = 1f - v18;\n\treflectionMat.m11 = v19;\n\tv20 = plane.z * v15;\n\treflectionMat.m12 = v20;\n\tv21 = plane.y * v13;\n\treflectionMat.m13 = v21;\n\tv22 = plane.z * -2f;\n\tv23 = plane * v22;\n\treflectionMat.m20 = v23;\n\tv24 = plane.y * v22;\n\treflectionMat.m21 = v24;\n\tv25 = plane.z + plane.z;\n\tv26 = plane.z * v25;\n\tv27 = 1f - v26;\n\treflectionMat.m22 = v27;\n\tv28 = plane.z * v13;\n\treflectionMat.m23 = v28;\n\treflectionMat.m30 = 0f;\n\treflectionMat.m31 = 0f;\n\treflectionMat.m32 = 0f;\n\treflectionMat.m33 = 1f;\n\treturn;\n")]
		private static void CalculateReflectionMatrix(ref Matrix4x4 reflectionMat, Vector4 plane)
		{
			float num = plane.x + plane.x;
			float num2 = plane.x * num;
			float m = 1f - num2;
			reflectionMat.m00 = m;
			float num3 = plane.x * -2f;
			float m2 = plane.y * num3;
			reflectionMat.m01 = m2;
			float m3 = plane.z * num3;
			reflectionMat.m02 = m3;
			float num4 = plane.w * -2f;
			float m4 = plane.x * num4;
			reflectionMat.m03 = m4;
			float num5 = plane.y * -2f;
			float m5 = plane.x * num5;
			reflectionMat.m10 = m5;
			float num6 = plane.y + plane.y;
			float num7 = plane.y * num6;
			float m6 = 1f - num7;
			reflectionMat.m11 = m6;
			float m7 = plane.z * num5;
			reflectionMat.m12 = m7;
			float m8 = plane.y * num4;
			reflectionMat.m13 = m8;
			float num8 = plane.z * -2f;
			float m9 = plane.x * num8;
			reflectionMat.m20 = m9;
			float m10 = plane.y * num8;
			reflectionMat.m21 = m10;
			float num9 = plane.z + plane.z;
			float num10 = plane.z * num9;
			float m11 = 1f - num10;
			reflectionMat.m22 = m11;
			float m12 = plane.z * num4;
			reflectionMat.m23 = m12;
			reflectionMat.m30 = 0f;
			reflectionMat.m31 = 0f;
			reflectionMat.m32 = 0f;
			reflectionMat.m33 = 1f;
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x819A2D4", Offset = "0x819A2D4", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.textureSize = 1.48539710427E-313d;\n\tv16 = UnityEngine.LayerMask::op_Implicit(-1);\n\tthis.reflectLayers = v16;\n\tthis.clipPlaneOffset = 0.07f;\n\tthis.backgroundColor = *([9245650]);\n\tthis.blurIterations = 0x3F80000000000001;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public TCP2_PlanarReflection()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TCP2_PlanarReflection::.ctor");
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x819A334", Offset = "0x819A334", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv76._ReflectionTex = v72;\n\treturn;\nL_0028:\n\tv56 = UnityEngine.Shader::PropertyToID(\"_SamplingDistance\");\n\tv61._SamplingDistance = v56;\n\tv64 = UnityEngine.Shader::PropertyToID(\"_PlanarReflectionTempRT\");\n\tv69._PlanarReflectionTempRT = v64;\n\tv72 = UnityEngine.Shader::PropertyToID(\"_ReflectionTex\");\n")]
		static TCP2_PlanarReflection()
		{
			int samplingDistance = Shader.PropertyToID("_SamplingDistance");
			_SamplingDistance = samplingDistance;
			int planarReflectionTempRT = Shader.PropertyToID("_PlanarReflectionTempRT");
			_PlanarReflectionTempRT = planarReflectionTempRT;
			int reflectionTex = Shader.PropertyToID("_ReflectionTex");
			_ReflectionTex = reflectionTex;
		}
	}
}
