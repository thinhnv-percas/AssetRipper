using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace HighlightPlus
{
	[Token(Token = "0x200002E")]
	public class HighlightPlusRenderPassFeature : ScriptableRendererFeature
	{
		[Token(Token = "0x200002F")]
		private class HighlightPass : ScriptableRenderPass
		{
			[Token(Token = "0x2000030")]
			private class PassData
			{
				[Token(Token = "0x4000247")]
				[FieldOffset(Offset = "0x10")]
				public Camera camera;

				[Token(Token = "0x4000248")]
				[FieldOffset(Offset = "0x18")]
				public RTHandle colorTarget;

				[Token(Token = "0x4000249")]
				[FieldOffset(Offset = "0x20")]
				public RTHandle depthTarget;

				[Token(Token = "0x400024A")]
				[FieldOffset(Offset = "0x28")]
				public TextureHandle colorTexture;

				[Token(Token = "0x400024B")]
				[FieldOffset(Offset = "0x38")]
				public TextureHandle depthTexture;

				[Token(Token = "0x400024C")]
				[FieldOffset(Offset = "0x48")]
				public bool clearStencil;

				[Token(Token = "0x400024D")]
				[FieldOffset(Offset = "0x50")]
				public CommandBuffer cmd;

				[Token(Token = "0x60000F3")]
				[Address(RVA = "0x772EAE8", Offset = "0x772EAE8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
				public PassData()
				{
				}
			}

			[Token(Token = "0x2000031")]
			private class DistanceComparer : IComparer<HighlightEffect>
			{
				[Token(Token = "0x400024E")]
				[FieldOffset(Offset = "0x10")]
				public Vector3 camPos;

				[Token(Token = "0x60000F4")]
				[Address(RVA = "0x772EB78", Offset = "0x772EB78", Length = "0x124")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv118 = e1.sortingPriority >= e2.sortingPriority;\n\tif (v118) goto L_0026;\nL_FFFFFFFF:\n\treturnVal2 = -1;\n\tgoto L_0077;\nL_0026:\n\tv71 = e1.sortingPriority <= e2.sortingPriority;\n\tif (v71) goto L_002E;\nL_FFFFFFFF:\n\treturnVal2 = 1;\n\tgoto L_0077;\nL_002E:\n\tv67 = UnityEngine.Component::get_transform(e1);\n\tv57 = UnityEngine.Transform::get_position(v67);\n\tv68 = UnityEngine.Component::get_transform(e2);\n\tv241 = v57 - this.camPos;\n\tv242 = v57.y - this.camPos.y;\n\tv243 = v57.z - this.camPos.z;\n\tv244 = v241 * v241;\n\tv245 = v242 * v242;\n\tv246 = v244 + v245;\n\tv247 = v243 * v243;\n\tv248 = v246 + v247;\n\tv133 = e1.sortingOffset + v248;\n\tv249 = UnityEngine.Transform::get_position(v68);\n\tv253 = v249 - this.camPos;\n\tv254 = v249.y - this.camPos.y;\n\tv135 = v249.z - this.camPos.z;\n\tv256 = v253 * v253;\n\tv257 = v254 * v254;\n\tv258 = v256 + v257;\n\tv137 = v135 * v135;\n\tv259 = v258 + v137;\n\tv139 = e2.sortingOffset + v259;\n\tv154 = v133 < v139;\n\tv152 = v133 == v139;\n\tv261 = v133 == v133;\n\tv150 = v139 == v139;\n\tv156 = v261 & v150;\n\tv148 = ~v156;\n\tv262 = v154 == v148;\n\tv121 = ~v152;\n\tv146 = v262 & v121;\n\tif (v146) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal2 = v154;\nL_0077:\n\treturn returnVal2;\n")]
				public int Compare(HighlightEffect e1, HighlightEffect e2)
				{
					if (e1.sortingPriority >= e2.sortingPriority)
					{
						if (e1.sortingPriority > e2.sortingPriority)
						{
							return 1;
						}
						Transform transform = e1.transform;
						Vector3 position = transform.position;
						Transform transform2 = e2.transform;
						float num = position.x - camPos.x;
						float num2 = position.y - camPos.y;
						float num3 = position.z - camPos.z;
						float num4 = num * num;
						float num5 = num2 * num2;
						float num6 = num4 + num5;
						float num7 = num3 * num3;
						float num8 = num6 + num7;
						float num9 = e1.sortingOffset + num8;
						Vector3 position2 = transform2.position;
						float num10 = position2.x - camPos.x;
						float num11 = position2.y - camPos.y;
						float num12 = position2.z - camPos.z;
						float num13 = num10 * num10;
						float num14 = num11 * num11;
						float num15 = num13 + num14;
						float num16 = num12 * num12;
						float num17 = num15 + num16;
						float num18 = e2.sortingOffset + num17;
						bool flag = num9 < num18;
						bool flag2 = num9 == num18;
						bool flag3 = num9 == num9;
						bool flag4 = num18 == num18;
						bool flag5 = flag3 && flag4;
						bool flag6 = !flag5;
						bool flag7 = flag == flag6;
						bool flag8 = !flag2;
						if (!(flag7 && flag8))
						{
							return flag ? 1 : 0;
						}
					}
					return -1;
				}

				[Token(Token = "0x60000F5")]
				[Address(RVA = "0x772EB70", Offset = "0x772EB70", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
				public DistanceComparer()
				{
				}
			}

			[Serializable]
			[CompilerGenerated]
			[Token(Token = "0x2000032")]
			private sealed class _003C_003Ec
			{
				[Token(Token = "0x400024F")]
				public static readonly _003C_003Ec _003C_003E9;

				[Token(Token = "0x4000250")]
				public static Predicate<HighlightEffect> _003C_003E9__16_0;

				[Token(Token = "0x4000251")]
				public static BaseRenderFunc<PassData, UnsafeGraphContext> _003C_003E9__17_0;

				[Token(Token = "0x60000F6")]
				[Address(RVA = "0x772EC9C", Offset = "0x772EC9C", Length = "0x64")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new HighlightPlus.HighlightPlusRenderPassFeature+HighlightPass+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
				static _003C_003Ec()
				{
					_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
					_003C_003E9 = _003C_003Ec2;
				}

				[Token(Token = "0x60000F7")]
				[Address(RVA = "0x772ED00", Offset = "0x772ED00", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
				public _003C_003Ec()
				{
				}

				internal bool _003CExecutePass_003Eb__16_0(HighlightEffect t)
				{
					return t == null;
				}

				internal void _003CRecordRenderGraph_003Eb__17_0(PassData passData, UnsafeGraphContext context)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("HighlightPlusRenderPassFeature.HighlightPass._003C_003Ec::_003CRecordRenderGraph_003Eb__17_0");
				}
			}

			[Token(Token = "0x400023C")]
			[FieldOffset(Offset = "0xB8")]
			private readonly PassData passData;

			[Token(Token = "0x400023D")]
			[FieldOffset(Offset = "0xC0")]
			public bool usesCameraOverlay;

			[Token(Token = "0x400023E")]
			[FieldOffset(Offset = "0xC8")]
			internal ScriptableRenderer renderer;

			[Token(Token = "0x400023F")]
			[FieldOffset(Offset = "0xD0")]
			private RenderTextureDescriptor cameraTextureDescriptor;

			[Token(Token = "0x4000240")]
			private static DistanceComparer effectDistanceComparer;

			[Token(Token = "0x4000241")]
			private static Comparison<HighlightEffect> cachedEffectComparisonDelegate;

			[Token(Token = "0x4000242")]
			[FieldOffset(Offset = "0x104")]
			internal bool clearStencil;

			[Token(Token = "0x4000243")]
			private static RenderTextureDescriptor sourceDesc;

			[Token(Token = "0x4000244")]
			private static Material blockerOutlineAndGlowMat;

			[Token(Token = "0x4000245")]
			private static Material blockerOverlayMat;

			[Token(Token = "0x4000246")]
			private static Material blockerAllMat;

			[Token(Token = "0x60000EC")]
			[Address(RVA = "0x772D0B0", Offset = "0x772D0B0", Length = "0x4C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.renderer = renderer;\n\tthis.renderPassEvent = passFeature.renderPassEvent;\n\tthis.clearStencil = passFeature.clearStencil;\n\tthis.input = 1;\n\treturn;\n")]
			public void Setup(HighlightPlusRenderPassFeature passFeature, ScriptableRenderer renderer)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("HighlightPlusRenderPassFeature.HighlightPass::Setup");
			}

			[Obsolete]
			[Token(Token = "0x60000ED")]
			[Address(RVA = "0x772D628", Offset = "0x772D628", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.cameraTextureDescriptor.memoryless = cameraTextureDescriptor.memoryless;\n\tthis.cameraTextureDescriptor.mipCount = cameraTextureDescriptor.mipCount;\n\tthis.cameraTextureDescriptor.dimension = cameraTextureDescriptor.dimension;\n\tthis.cameraTextureDescriptor = cameraTextureDescriptor.width;\n\treturn;\n")]
			public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("HighlightPlusRenderPassFeature.HighlightPass::Configure");
			}

			[Obsolete]
			[Token(Token = "0x60000EE")]
			[Address(RVA = "0x772D644", Offset = "0x772D644", Length = "0x1E8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = context;\n\tgoto L_0025;\nL_0025:\n\tv55 = UnityEngine.Rendering.Universal.ScriptableRenderer::get_cameraColorTargetHandle(this.renderer);\n\tv90 = UnityEngine.Rendering.Universal.ScriptableRenderer::get_cameraDepthTargetHandle(this.renderer);\n\tv76 = this.passData;\n\tv76.clearStencil = this.clearStencil;\n\tv151 = UnityEngine.Rendering.Universal.CameraData::get_camera(&renderingData.cameraData (UnityEngine.Rendering.Universal.CameraData));\n\tv76.camera = *([v151 @ X0_v9 (UnityEngine.Camera&)]);\n\tv91 = this.passData;\n\tv91.colorTarget = v55;\n\tv92 = this.passData;\n\tv92.depthTarget = v90;\n\tv163 = UnityEngine.Rendering.Universal.CameraData::get_cameraTargetDescriptor(&renderingData.cameraData (UnityEngine.Rendering.Universal.CameraData));\n\tgoto L_0063;\nL_0071:\n\tv93 = UnityEngine.Rendering.CommandBufferPool::Get(\"Highlight Plus\");\n\tUnityEngine.Rendering.CommandBuffer::Clear(v93);\n\tv94 = this.passData;\n\tv94.cmd = v93;\n\tHighlightPlus.HighlightPlusRenderPassFeature+HighlightPass::ExecutePass(this.passData);\n\tgoto L_008B;\nL_008B:\n\tUnityEngine.Rendering.ScriptableRenderContext::ExecuteCommandBuffer(&v22 @ stack_-48_v1 (UnityEngine.Rendering.ScriptableRenderContext), v93);\n\tUnityEngine.Rendering.CommandBufferPool::Release(v93);\n\treturn;\nL_0063:\n\tv176.sourceDesc.width = v163.width;\n\tv176.sourceDesc.mipCount = v163.mipCount;\n\tv176.sourceDesc.dimension = v163.dimension;\n\tv176.sourceDesc.memoryless = v163.memoryless;\n\tgoto L_0071;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public unsafe override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("HighlightPlusRenderPassFeature.HighlightPass::Execute");
			}

			[Token(Token = "0x60000EF")]
			[Address(RVA = "0x772D82C", Offset = "0x772D82C", Length = "0xABC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tgoto L_001F;\nL_001F:\n\tv72 = v70.effects == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_007A;\n\tgoto L_03E4;\nL_007A:\n\tgoto L_007C;\nL_007C:\n\t;\n\tv382 = v380.<>9__16_0 == 0;\n\tv383 = ~v382;\nL_FFFFFFFF:\n\tv357 = v380.<>9__16_0;\n\tif (v383) goto L_00A8;\n\tgoto L_008F;\nL_008F:\n\tgoto L_0097;\nL_00A8:\n\tv505 = System.Collections.Generic.List`1<HighlightPlus.HighlightEffect>::RemoveAll(v70.effects, v357);\n\tv676 = 0xB28F000 + 0x80;\n\tgoto L_00B3;\n\tv548 = v364.Count == 0;\n\tif (v548) goto L_0373;\n\tv328 = UnityEngine.Component::get_gameObject(passData.camera);\n\tv792 = UnityEngine.GameObject::get_layer(v328);\n\tv798 = UnityEngine.Camera::get_cameraType(passData.camera);\n\tgoto L_00CF;\nL_00CF:\n\tv866 = 0xB28F000 + 0x98;\n\tv813 = v810.customSorting == 0;\n\tif (v813) goto L_00EA;\n\tgoto L_0118;\nL_00EA:\n\tv836 = v798 != 1;\n\tif (v836) goto L_0112;\n\tv895 = *([v866 @ X23_v19 (System.Int32)]);\n\tgoto L_00F3;\nL_0112:\n\tgoto L_0114;\nL_0114:\n\tv868 = UnityEngine.Application::get_isPlaying();\n\tv871 = v868 == 0;\n\tif (v871) goto L_0381;\nL_0118:\n\tv334 = *([v866 @ X23_v19 (System.Int32)]);\n\tgoto L_011F;\n\tv966 = *([v370 @ X8_v14+18]) < 0;\n\tv967 = *([v370 @ X8_v14+18]) == 0;\n\tv969 = *([v370 @ X8_v14+18]) ^ *([v370 @ X8_v14+18]);\n\tv970 = *([v370 @ X8_v14+18]) & v969;\n\tv971 = v970 < 0;\n\tv972 = v966 == v971;\n\tv627 = ~v967;\n\tv973 = v972 & v627;\n\tgoto L_0136;\nL_0136:\n\tv694.focusRendered = 0;\n\tv630 = v364.Count >= 1;\n\tif (v630) goto L_0156;\n\tgoto L_0373;\nL_0156:\n\tv1013 = 1 << v792;\nL_FFFFFFFF:\n\tv625 = &v204 @ stack_-B8 (System.Int32);\nL_FFFFFFFF:\n\tv679 = v973;\nL_FFFFFFFF:\n\tv359 = 0;\n\tgoto L_01B0;\nL_0163:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v476 @ stack_-90_v7 (UnityEngine.Vector3));\nL_FFFFFFFF:\n\tv204 = 0;\nL_0167:\n\tHighlightPlus.HighlightEffect::SetCommandBuffer(v329, passData.cmd);\n\tv1277 = UnityEngine.Rendering.RTHandle::op_Implicit(passData.colorTarget);\n\tv204 = v204.m_value;\n\tv1286 = UnityEngine.Rendering.RTHandle::op_Implicit(passData.depthTarget);\n\tgoto L_018E;\nL_018E:\n\tv1134 = v204.m_value;\n\tv1131 = v1286.m_Type;\n\tv1191 = HighlightPlus.HighlightEffect::BuildCommandBuffer(v329, passData.camera, &v1134 @ stack_-110_v6, &v1131 @ stack_-140_v6 (UnityEngine.Rendering.BuiltinRenderTextureType), passData.clearStencil, &v1348.sourceDesc (UnityEngine.RenderTextureDescriptor));\n\tpassData.clearStencil = 0;\n\tv676 = 0xB28F000 + 0x80;\nL_FFFFFFFF:\n\tv625 = &v204 @ stack_-B8 (System.Int32);\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv679 = 0;\nL_01B0:\n\tv1032 = *([v676 @ X24_v9 (System.Int32)]);\n\tgoto L_01B7;\n\tv329 = System.Collections.Generic.List`1<System.Object>::get_Item(*([v371 @ X8_v22+128]), v359);\n\tv1047 = *([v329 @ X0_v30 (UnityEngine.Behaviour)+61]) & 1;\n\tv1048 = v1047 == 0;\n\tv1049 = ~v1048;\n\tif (v1049) goto L_01D6;\n\tv1098 = *([v329 @ X0_v30 (UnityEngine.Behaviour)+476]) != 1;\n\tif (v1098) goto L_01A5;\nL_01D6:\n\tv1111 = UnityEngine.Behaviour::get_isActiveAndEnabled(v329);\n\tv1196 = ~v1111;\n\tif (v1196) goto L_01A5;\n\tv1224 = v798 != 0x10;\n\tif (v1224) goto L_01F1;\n\tv1160 = *([v329 @ X0_v30 (UnityEngine.Behaviour)+62]) != 1;\n\tif (v1160) goto L_01A5;\nL_01F1:\n\t;\n\tv1192 = UnityEngine.LayerMask::op_Implicit(*([v329 @ X0_v30 (UnityEngine.Behaviour)+2C]));\n\tv1197 = v1192 & v1013;\n\tv253 = v1197 == 0;\n\tif (v253) goto L_01A5;\n\tv1240 = v679 == 0;\n\tif (v1240) goto L_0167;\n\tgoto L_020F;\nL_020F:\n\tv1282 = System.Collections.Generic.List`1<HighlightPlus.HighlightEffectBlocker>::GetEnumerator(v372.outlineAndGlowOccluders);\n\tv422 = v1282.Current;\n\tv476 = *([v625 @ X25_v7]);\n\tgoto L_0234;\nL_022C:\n\tgoto L_0231;\nL_0231:\n\tHighlightPlus.HighlightEffectBlocker::BuildCommandBuffer(v1282.Current, passData.cmd, v1341.blockerAllMat);\nL_0234:\n\tv1347 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v476 @ stack_-90_v7 (UnityEngine.Vector3));\n\tv1264 = v1347 == 0;\n\tif (v1264) goto L_0163;\n\tgoto L_0242;\nL_0242:\n\tv1329 = UnityEngine.Object::op_Inequality(v1282.Current, 0);\n\tv1335 = v1329 == 0;\n\tif (v1335) goto L_0234;\n\tv478 = v1282.Current == 0;\n\tif (v478) goto L_0338;\n\tv1330 = UnityEngine.Behaviour::get_isActiveAndEnabled(v1282.Current);\n\tv1336 = v1330 == 0;\n\tif (v1336) goto L_0234;\n\tv1374 = *([v422 @ stack_-A8_v6 (HighlightPlus.HighlightEffectBlocker)+31]) == 0;\n\tv1379 = ~v1374;\n\tv1380 = ~v1379;\n\tif (v1380) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv1342 = 2;\n\tgoto L_025F;\nL_FFFFFFFF:\n\tv1342 = 0;\nL_FFFFFFFF:\n\tv1342 = v1294;\n\tgoto L_027C;\n\tv1337 = v1342 == 0;\n\tif (v1337) goto L_0234;\n\tgoto L_028A;\nL_028A:\n\tgoto L_02BC;\nL_0295:\n\tv1297 = v1342 != 4;\n\tif (v1297) goto L_02A6;\n\tgoto L_02A1;\nL_02A1:\n\tgoto L_02EF;\nL_02A6:\n\tgoto L_02AD;\nL_02AD:\n\tgoto L_0322;\nL_02BC:\n\tv1444 = UnityEngine.Object::op_Equality(v1408.blockerOutlineAndGlowMat, 0);\n\tv1488 = v1444 == 0;\n\tif (v1488) goto L_02D9;\n\tv1501 = UnityEngine.Resources::Load(\"HighlightPlus/HighlightBlockerOutlineAndGlow\");\n\tgoto L_02D1;\nL_02D9:\n\tgoto L_02E0;\nL_02EF:\n\tv1463 = UnityEngine.Object::op_Equality(v1415.blockerOverlayMat, 0);\n\tv1491 = v1463 == 0;\n\tif (v1491) goto L_030C;\n\tv1521 = UnityEngine.Resources::Load(\"HighlightPlus/HighlightBlockerOverlay\");\n\tgoto L_0304;\nL_030C:\n\tgoto L_0313;\nL_0322:\n\tv1482 = UnityEngine.Object::op_Equality(v1422.blockerAllMat, 0);\n\tv1494 = v1482 == 0;\n\tif (v1494) goto L_022C;\n\tv1541 = UnityEngine.Resources::Load(\"HighlightPlus/HighlightUIMask\");\n\tgoto L_0225;\nL_0338:\n\tv470 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv204 = 0;\n\tgoto L_03E5;\nL_0373:\n\treturn;\nL_0381:\n\tgoto L_0385;\n\tv144 = UnityEngine.Transform::get_position(v330);\n\tv320.camPos.x = v144;\n\tv320.camPos.y = v144.y;\n\tv320.camPos.z = v144.z;\n\tv1038 = v1036.cachedEffectComparisonDelegate == 0;\n\tif (v1038) goto L_03AC;\n\tv929 = 0xB28F000 + 0x98;\n\tgoto L_03A4;\nL_03A4:\n\tgoto L_03A5;\nL_03A5:\n\tv1117 = v1067.effects == 0;\n\tv349 = ~v1117;\n\tif (v349) goto L_03DD;\n\tgoto L_03E4;\nL_03AC:\n\tgoto L_03B0;\n\tv1212 = *([v322 @ X23_v25 (HighlightPlus.HighlightPlusRenderPassFeature+HighlightPass+DistanceComparer)]);\n\tSystem.Comparison`1<HighlightPlus.HighlightEffect>::.ctor(v332, v322, *([v1212 @ X8_v128 (Il2CppClass<HighlightPlus.HighlightPlusRenderPassFeature+HighlightPass+DistanceComparer>)+180]));\n\tv1227.cachedEffectComparisonDelegate = v332;\n\tv929 = 0xB28F000 + 0x98;\nL_FFFFFFFF:\n\t;\n\tgoto L_03A4;\nL_03DD:\n\tSystem.Collections.Generic.List`1<HighlightPlus.HighlightEffect>::Sort(v1067.effects, v1208.cachedEffectComparisonDelegate);\n\tv334 = *([v929 @ X23_v22 (System.Int32)]);\n\tgoto L_011F;\nL_03E4:\n\tv470 = new System.NullReferenceException();\nL_03E5:\n\t// 997 Interrupt\n\treturn;\nL_0097:\n\tv536 = new System.Predicate`1<HighlightPlus.HighlightEffect>();\n\tSystem.Predicate`1<HighlightPlus.HighlightEffect>::.ctor(v536, v531.<>9, Il2CppMethodInfo);\n\tv552.<>9__16_0 = v536;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv357 = v536;\nL_00B3:\n\tv364 = v539.effects;\nL_00F3:\n\tv946 = *([v895 @ X0_v188+B8]);\n\tv948 = *([v946 @ X8_v143+10]) + 1;\n\t*([v946 @ X8_v143+10]) = v948;\n\tv952 = *([v946 @ X8_v143+10]) * 0xFFFFFFFFCCCCCCCD;\n\tv953 = 0x19999998 + v952;\n\tv897 = v953 >> 1;\n\tv954 = v953 << 0x1F;\n\tv899 = v897 | v954;\n\tv956 = v899 < 0x19999999;\n\tv892 = ~v956;\n\tv884 = ~v892;\n\tif (v884) goto L_0381;\nL_011F:\n\tv943 = *([v334 @ X0_v23+B8]);\n\tv370 = *([v943 @ X8_v13+8]);\nL_01B7:\n\tv371 = *([v1032 @ X0_v28+B8]);\nL_01A5:\n\tv359 = v359 + 1;\n\tv652 = v359 == v364.Count;\n\tif (v652) goto L_0373;\nL_025F:\n\t;\n\tv1294 = v1342 | 4;\n\tv1388 = *([v422 @ stack_-A8_v6 (HighlightPlus.HighlightEffectBlocker)+32]) == 0;\n\tv1393 = ~v1388;\n\tv1295 = ~v1393;\n\tif (v1295) goto L_027C;\nL_027C:\n\tv1298 = v1342 > 3;\n\tif (v1298) goto L_0295;\nL_02D1:\n\tv1572.blockerOutlineAndGlowMat = v1501;\nL_02E0:\n\tHighlightPlus.HighlightEffectBlocker::BuildCommandBuffer(v1282.Current, passData.cmd, v1343.blockerOutlineAndGlowMat);\n\tgoto L_0234;\nL_0304:\n\tv1577.blockerOverlayMat = v1521;\nL_0313:\n\tHighlightPlus.HighlightEffectBlocker::BuildCommandBuffer(v1282.Current, passData.cmd, v1344.blockerOverlayMat);\n\tgoto L_0234;\nL_0225:\n\tv1582.blockerAllMat = v1541;\n\tv513 = 0x359B400(&v204 @ stack_-B8 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobb\n// ... truncated")]
			private unsafe static void ExecutePass(PassData passData)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("HighlightPlusRenderPassFeature.HighlightPass::ExecutePass");
			}

			[Token(Token = "0x60000F0")]
			[Address(RVA = "0x772E2E8", Offset = "0x772E2E8", Length = "0x800")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004B;\nL_004B:\n\tv65 = UnityEngine.Rendering.RenderGraphModule.RenderGraph::AddUnsafePass(frameData, Il2CppMethodInfo, frameData, methodInfo, v37);\n\tgoto L_005A;\nL_005A:\n\tv217 = *([v65 @ X0_v29 (UnityEngine.Rendering.RenderGraphModule.IUnsafeRenderGraphBuilder)+F8]);\n\tv225 = UnityEngine.RenderTextureDescriptor::get_colorFormat(&v217 @ stack_-90_v8 (UnityEngine.RenderTextureDescriptor));\n\tv98 = v225 == 1;\n\tif (v98) goto L_02BC;\n\tv217 = *([v65 @ X0_v29 (UnityEngine.Rendering.RenderGraphModule.IUnsafeRenderGraphBuilder)+F8]);\n\tv435 = UnityEngine.RenderTextureDescriptor::get_graphicsFormat(&v217 @ stack_-90_v8 (UnityEngine.RenderTextureDescriptor));\n\tv533 = v435 == 0;\n\tif (v533) goto L_02BC;\n\tv134 = UnityEngine.Rendering.ContextContainer::Get(frameData);\n\tv699 = UnityEngine.Rendering.Universal.UniversalResourceData::get_activeColorTexture(v134);\n\tgoto L_008F;\nL_008F:\n\tv73 = 0xB293000 + 0x8F0;\n\tv786 = *([B193DA3]) & 1;\n\tv787 = v786 == 0;\n\tv468 = v73;\n\tif (v787) goto L_00AF;\n\tv813 = *([v73 @ X24_v9 (System.Int32)]);\n\tv815 = *([v813 @ X0_v129+E4]) == 0;\n\tv468 = v73;\n\tif (v815) goto L_00B8;\nL_0099:\n\tv837 = *([B193DA4]) & 1;\n\tv838 = v837 == 0;\n\tv468 = v73;\n\tif (v838) goto L_00C0;\nL_009D:\n\tv75 = v853 << 0x10;\n\tv854 = v75 == 0;\n\tv534 = ~v854;\n\tif (v534) goto L_00C5;\n\tgoto L_02BC;\nL_00AF:\n\t*([B193DA3]) = 1;\n\tv830 = *([v73 @ X24_v9 (System.Int32)]);\n\tv846 = *([v830 @ X0_v124+E4]) == 0;\n\tv832 = ~v846;\n\tv73 = v73;\n\tif (v832) goto L_0099;\nL_00B8:\n\tv861 = *([B193DA4]) & 1;\n\tv862 = v861 == 0;\n\tv850 = ~v862;\n\tv73 = v468;\n\tif (v850) goto L_009D;\nL_00C0:\n\t*([B193DA4]) = 1;\n\tv75 = v853 << 0x10;\n\tv535 = v75 == 0;\n\tv73 = v468;\n\tif (v535) goto L_02BC;\nL_00C5:\n\tv529 = *([v73 @ X24_v9 (System.Int32)]);\n\tv868 = *([v529 @ X0_v110+E4]) == 0;\n\tif (v868) goto L_00D8;\n\tv902 = *([v529 @ X0_v110+B8]);\n\tv881 = v75 != *([v902 @ X8_v80]);\n\tif (v881) goto L_00E6;\n\tgoto L_0111;\nL_00D8:\n\tv529 = *([v73 @ X24_v9 (System.Int32)]);\n\tv902 = *([v529 @ X0_v110+B8]);\n\tv894 = v75 == *([v902 @ X8_v80]);\n\tif (v894) goto L_0111;\nL_00E6:\n\tv536 = *([v529 @ X0_v110+E4]) == 0;\n\tif (v536) goto L_00F5;\n\tv495 = v75 == *([v902 @ X8_v80+4]);\n\tif (v495) goto L_0111;\n\tgoto L_02BC;\nL_00F5:\n\tv914 = *([v73 @ X24_v9 (System.Int32)]);\n\tv915 = *([v914 @ X8_v81+B8]);\n\tv461 = v75 != *([v915 @ X8_v82+4]);\n\tif (v461) goto L_02BC;\nL_0111:\n\tv193 = UnityEngine.Rendering.RenderGraphModule.RenderGraph::AddUnsafePass(renderGraph, \"Highlight Plus Pass RG\", &v162 @ stack_-B0_v8 (HighlightPlus.HighlightPlusRenderPassFeature+HighlightPass+PassData), \"/Users/macmini/wkspaces/Unity/sout/Assets/HighlightPlus/Runtime/Scripts/HighlightPlusRenderPassFeature.cs\", 0xC8);\n\tv195 = v193 == 0;\n\tif (v195) goto L_02BE;\n\tgoto L_0147;\n\tv162.camera = *([v65 @ X0_v29 (UnityEngine.Rendering.RenderGraphModule.IUnsafeRenderGraphBuilder)+D8]);\n\tv162.clearStencil = this.clearStencil;\n\tv989 = UnityEngine.Rendering.Universal.UniversalResourceData::get_activeColorTexture(v134);\n\tv384 = v162 == 0;\n\tif (v384) goto L_02C4;\n\tv162.colorTexture = v989;\n\tv162.colorTexture.handle.type = 0;\n\tv991 = UnityEngine.Rendering.Universal.UniversalResourceData::get_activeDepthTexture(v134);\n\tv385 = v162 == 0;\n\tif (v385) goto L_02C6;\n\tv162.depthTexture = v991;\n\tv162.depthTexture.handle.type = 0;\n\tv993 = UnityEngine.Rendering.Universal.UniversalResourceData::get_activeColorTexture(v134);\n\tv295 = v993;\n\tv386 = v158 == 0;\n\tif (v386) goto L_02C8;\n\tgoto L_0195;\n\tgoto L_01CA;\n\tgoto L_01FF;\nL_0222:\n\tv399 = v1217.<>9__17_0;\n\tv1219 = v1217.<>9__17_0 == 0;\n\tv1220 = ~v1219;\n\tv366 = &v295 @ stack_-A0_v10 (UnityEngine.Rendering.RenderGraphModule.TextureHandle);\n\tif (v1220) goto L_024B;\n\tgoto L_0231;\nL_0231:\n\tgoto L_0239;\nL_024B:\n\tv687 = Il2CppMethodInfo;\n\tv1247 = *([v158 @ stack_-A8_v9 (UnityEngine.Rendering.RenderGraphModule.IBaseRenderGraphBuilder)]);\n\tv1293 = *([v1247 @ X8_v58 (Il2CppClass<UnityEngine.Rendering.RenderGraphModule.IBaseRenderGraphBuilder>)+12E]);\n\tv1249 = *([v1247 @ X8_v58 (Il2CppClass<UnityEngine.Rendering.RenderGraphModule.IBaseRenderGraphBuilder>)+12E]) == 0;\n\tif (v1249) goto L_026D;\n\tv1291 = *([v1247 @ X8_v58 (Il2CppClass<UnityEngine.Rendering.RenderGraphModule.IBaseRenderGraphBuilder>)+B0]) + 8;\n\tv1291 = v1291 + 0x10;\n\tv1267 = v1293 - 1;\n\tv1265 = v1293 != 1;\n\tv1293 = v1267;\n\tif (v1265) goto L_0259;\nL_026D:\n\tv1285 = 0x220C5E0(v158, Il2CppClass<UnityEngine.Rendering.RenderGraphModule.IUnsafeRenderGraphBuilder>, *([v687 @ X21_v11 (Il2CppMethodInfo)+50]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_027B;\nL_0287:\n\tgoto L_02AD;\nL_02BC:\n\treturn;\nL_02BE:\n\tv200 = new System.NullReferenceException();\n\tv635 = &v158 @ stack_-A8_v9 (UnityEngine.Rendering.RenderGraphModule.IBaseRenderGraphBuilder);\n\tv155 = 0;\n\tv524 = v366;\n\tgoto L_02CF;\nL_02C1:\n\tv757 = new System.OutOfMemoryException();\n\tv635 = v443;\nL_02C2:\n\tv373 = new System.NullReferenceException();\n\tv635 = v151;\n\tv524 = v190;\n\tv373 = v200;\n\tgoto L_02CF;\nL_02C4:\n\tv376 = new System.NullReferenceException();\n\tgoto L_02CF;\nL_02C6:\n\tv373 = new System.NullReferenceException();\n\tv635 = &v158 @ stack_-A8_v9 (UnityEngine.Rendering.RenderGraphModule.IBaseRenderGraphBuilder);\n\tv155 = 0;\n\tv524 = 0;\n\tv373 = v376;\n\tgoto L_02CF;\nL_02C8:\n\tv378 = new System.NullReferenceException();\n\tv635 = &v158 @ stack_-A8_v9 (UnityEngine.Rendering.RenderGraphModule.IBaseRenderGraphBuilder);\n\tv155 = 0;\n\tv524 = 0;\n\tgoto L_02CF;\nL_02CA:\n\tv373 = new System.NullReferenceException();\n\tv635 = &v158 @ stack_-A8_v9 (UnityEngine.Rendering.RenderGraphModule.IBaseRenderGraphBuilder);\n\tv155 = 0;\n\tv524 = 0;\n\tv373 = v378;\n\tgoto L_02CF;\nL_02CC:\n\tv380 = new System.NullReferenceException();\n\tv635 = &v158 @ stack_-A8_v9 (UnityEngine.Rendering.RenderGraphModule.IBaseRenderGraphBuilder);\n\tv155 = 0;\n\tv524 = 0;\n\tgoto L_02CF;\nL_02CF:\n\t// 719 Interrupt\n\tgoto L_02EB;\nL_02EB:\n\tv427 = v524 != 1;\n\tif (v427) goto L_02FA;\n\tv562 = 0x8BF5BC4(v373, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv688 = *([v562 @ X0_v12]);\n\tv614 = 0x8BF5BF4(v562, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv684 = *([v635 @ stack_-B8_v6]);\n\tv624 = *([v635 @ stack_-B8_v6]) == 0;\n\tv625 = ~v624;\n\tv155 = *([v562 @ X0_v12]);\n\tif (v625) goto L_0287;\n\tv443 = v635;\n\tv155 = *([v562 @ X0_v12]);\n\tv550 = *([v562 @ X0_v12]);\n\tgoto L_02AE;\n\treturn;\nL_0147:\n\tv984 = UnityEngine.Rendering.RenderGraphModule.IBaseRenderGraphBuilder::AllowPassCulling(0, 0);\n\tv792 = v162 == 0;\n\tv635 = &v158 @ stack_-A8_v9 (UnityEngine.Rendering.RenderGraphModule.IBaseRenderGraphBuilder);\n\tv155 = 0;\n\tv524 = 0;\n\tif (v792) goto L_02C2;\nL_0195:\n\tUnityEngine.Rendering.RenderGraphModule.IBaseRenderGraphBuilder::UseTexture(v158, &v295 @ stack_-A0_v10 (UnityEngine.Rendering.RenderGraphModule.TextureHandle), 3);\n\tv1060 = UnityEngine.Rendering.Universal.UniversalResourceData::get_activeDepthTexture(v134);\n\tv295 = v1060;\n\tv387 = v158 == 0;\n\tif (v387) goto L_02CA;\nL_01CA:\n\tUnityEngine.Rendering.RenderGraphModule.IBaseRenderGraphBuilder::UseTexture(v158, &v295 @ stack_-A0_v10 (UnityEngine.Rendering.RenderGraphModule.TextureHandle), 1);\n\tv1127 = UnityEngine.Rendering.Universal.UniversalResourceData::get_cameraDepthTexture(v134);\n\tv295 = v1127;\n\tv388 = v158 == 0;\n\tif (v388) goto L_02CC;\nL_01FF:\n\tUnityEngine.Rendering.RenderGraphModule.IBaseRenderGraphBuilder::UseTexture(v158, &v295 @ stack_-A0_v10 (UnityEngine.Rendering.RenderGraphModule.TextureHandle), 1);\n\tgoto L_0213;\nL_0239:\n\tv1257 = new UnityEngine.Rendering.RenderGraphModule.BaseRenderFunc`2<HighlightPlus.HighlightPlusRenderPassFeature+HighlightPass+PassData, UnityEngine.Rendering.RenderGraphModule.UnsafeGraphContext>();\n\tUnityEngine.Rendering.RenderGraphModule.BaseRenderFunc`2<HighlightPlus.HighlightPlusRenderPassFeature+HighlightPass+Pa\n// ... truncated")]
			public unsafe override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("HighlightPlusRenderPassFeature.HighlightPass::RecordRenderGraph");
			}

			[Token(Token = "0x60000F1")]
			[Address(RVA = "0x772CCF8", Offset = "0x772CCF8", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tgoto L_0032;\nL_0032:\n\tUnityEngine.Rendering.Universal.ScriptableRenderPass::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new HighlightPlus.HighlightPlusRenderPassFeature+HighlightPass+PassData();\n\tSystem.Object::.ctor(v48);\n\tthis.passData = v48;\n")]
			public HighlightPass()
			{
				PassData passData = new PassData();
				this.passData = passData;
			}

			[Token(Token = "0x60000F2")]
			[Address(RVA = "0x772EAF0", Offset = "0x772EAF0", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\treturn;\nL_001B:\n\tv47 = new HighlightPlus.HighlightPlusRenderPassFeature+HighlightPass+DistanceComparer();\n\tSystem.Object::.ctor(v47);\n\tv53.effectDistanceComparer = v47;\n")]
			static HighlightPass()
			{
				DistanceComparer distanceComparer = new DistanceComparer();
				effectDistanceComparer = distanceComparer;
			}
		}

		[Token(Token = "0x400022E")]
		[FieldOffset(Offset = "0x20")]
		private HighlightPass renderPass;

		[Token(Token = "0x400022F")]
		[FieldOffset(Offset = "0x28")]
		public RenderPassEvent renderPassEvent;

		[Tooltip("Clears stencil buffer before rendering highlight effects. This option can solve compatibility issues with shaders that also use stencil buffers.")]
		[Token(Token = "0x4000230")]
		[FieldOffset(Offset = "0x2C")]
		public bool clearStencil;

		[Tooltip("If enabled, effects will be visible also in Edit mode (when not in Play mode).")]
		[Token(Token = "0x4000231")]
		[FieldOffset(Offset = "0x2D")]
		public bool previewInEditMode;

		[Tooltip("If enabled, effects will be visible also in Scene View.")]
		[Token(Token = "0x4000232")]
		[FieldOffset(Offset = "0x2E")]
		public bool showInSceneView;

		[Tooltip("If enabled, effects will be visible also in Preview camera (preview camera shown when a camera is selected in Editor).")]
		[Token(Token = "0x4000233")]
		[FieldOffset(Offset = "0x2F")]
		public bool showInPreviewCamera;

		[Token(Token = "0x4000234")]
		public static bool installed;

		[Token(Token = "0x4000235")]
		public static bool showingInEditMode;

		[Token(Token = "0x4000236")]
		public static List<HighlightEffectBlocker> outlineAndGlowOccluders;

		[Token(Token = "0x4000237")]
		public static int sortFrameCount;

		[Token(Token = "0x4000238")]
		private const string PREVIEW_CAMERA_NAME = "Preview";

		[Token(Token = "0x4000239")]
		private static Material sBlockerOutlineAndGlowMat;

		[Token(Token = "0x400023A")]
		private static Material sBlockerOverlayMat;

		[Token(Token = "0x400023B")]
		private static Material sBlockerAllMat;

		[Token(Token = "0x60000E3")]
		[Address(RVA = "0x772CB80", Offset = "0x772CB80", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0012;\nL_0012:\n\tv43.installed = 0;\n\treturn;\n")]
		private void OnDisable()
		{
			installed = false;
		}

		[Token(Token = "0x60000E4")]
		[Address(RVA = "0x772CBFC", Offset = "0x772CBFC", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tgoto L_002C;\nL_002C:\n\tgoto L_0030;\nL_0030:\n\tgoto L_0031;\nL_0031:\n\tv94 = HighlightPlus.VRCheck::IsActive();\n\tv99.isActive = v94;\n\tv100 = HighlightPlus.VRCheck::IsVrRunning();\n\tv102.isVrRunning = v100;\n\treturn;\nL_001C:\n\tv48 = new HighlightPlus.HighlightPlusRenderPassFeature+HighlightPass();\n\tHighlightPlus.HighlightPlusRenderPassFeature+HighlightPass::.ctor(v48);\n\tthis.renderPass = v48;\n")]
		public override void Create()
		{
			HighlightPass highlightPass = new HighlightPass();
			renderPass = highlightPass;
			bool flag = VRCheck.IsActive();
			VRCheck.isActive = flag;
			bool isVrRunning = VRCheck.IsVrRunning();
			VRCheck.isVrRunning = isVrRunning;
		}

		[Token(Token = "0x60000E5")]
		[Address(RVA = "0x772CE1C", Offset = "0x772CE1C", Length = "0x218")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tgoto L_0019;\nL_0019:\n\tv70 = v55.effects;\n\tv57 = v55.effects == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_0038;\n\tgoto L_00BA;\nL_0038:\n\tv73 = v70.Count == 0;\n\tif (v73) goto L_00B9;\n\tgoto L_0045;\n\tv102 = v207 == 1;\n\tif (v102) goto L_00B9;\n\tv187 = v272.width;\n\tv208 = UnityEngine.RenderTextureDescriptor::get_graphicsFormat(&v187 @ stack_-80_v3 (UnityEngine.RenderTextureDescriptor));\n\tv211 = v208 == 0;\n\tif (v211) goto L_00B9;\n\tv278 = UnityEngine.Rendering.Universal.CameraData::get_renderType(&renderingData.cameraData (UnityEngine.Rendering.Universal.CameraData));\n\tv279 = *([v278 @ X0_v16 (UnityEngine.Rendering.Universal.CameraRenderType&)]) == 0;\n\tv280 = ~v279;\n\tif (v280) goto L_0092;\n\tv161 = this.renderPass;\n\tv142 = UnityEngine.Rendering.Universal.CameraExtensions::GetUniversalAdditionalCameraData(*([v236 @ X0_v8 (UnityEngine.Camera&)]));\n\tv143 = UnityEngine.Rendering.Universal.UniversalAdditionalCameraData::get_cameraStack(v142);\n\tv289 = v143.Count < 0;\n\tv288 = v143.Count == 0;\n\tv286 = v143.Count ^ v143.Count;\n\tv285 = v143.Count & v286;\n\tv284 = v285 < 0;\n\tv304 = v289 == v284;\n\tv282 = ~v288;\n\tv283 = v304 & v282;\n\tv161.usesCameraOverlay = v283;\n\tv163.renderer = renderer;\n\tv163.renderPassEvent = this.renderPassEvent;\n\tv163.clearStencil = this.clearStencil;\n\tv163.input = 1;\n\tUnityEngine.Rendering.Universal.ScriptableRenderer::EnqueuePass(renderer, this.renderPass);\n\tgoto L_00AF;\nL_00BA:\n\tthrow System.NullReferenceException;\nL_00B9:\n\treturn;\nL_0045:\n\tv233.showingInEditMode = this.previewInEditMode;\n\tv236 = UnityEngine.Rendering.Universal.CameraData::get_camera(&renderingData.cameraData (UnityEngine.Rendering.Universal.CameraData));\n\tv272 = UnityEngine.Rendering.Universal.CameraData::get_cameraTargetDescriptor(&renderingData.cameraData (UnityEngine.Rendering.Universal.CameraData));\n\tv187 = v272.width;\n\tv207 = UnityEngine.RenderTextureDescriptor::get_colorFormat(&v187 @ stack_-80_v3 (UnityEngine.RenderTextureDescriptor));\nL_0092:\n\tv163 = this.renderPass;\nL_00AF:\n\tv214.installed = 1;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightPlusRenderPassFeature::AddRenderPasses");
		}

		[Token(Token = "0x60000E6")]
		[Address(RVA = "0x772D0FC", Offset = "0x772D0FC", Length = "0x480")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tgoto L_001B;\nL_001B:\n\tv76 = v61.outlineAndGlowOccluders;\n\tv63 = v61.outlineAndGlowOccluders == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0050;\n\tgoto L_01AE;\nL_0050:\n\tv89 = v76.Count < 1;\n\tif (v89) goto L_01AD;\nL_FFFFFFFF:\n\tv163 = 0;\n\tgoto L_0072;\nL_0063:\n\tv163 = v163 + 1;\n\tv199 = v76.Count == v163;\n\tif (v199) goto L_01AD;\nL_0072:\n\tgoto L_007B;\nL_007B:\n\tv277 = System.Collections.Generic.List`1<HighlightPlus.HighlightEffectBlocker>::get_Item(v161.outlineAndGlowOccluders, v163);\n\tgoto L_0084;\nL_0084:\n\tv289 = UnityEngine.Object::op_Equality(v277, 0);\n\tv294 = v289 == 0;\n\tv295 = ~v294;\n\tif (v295) goto L_0063;\n\tgoto L_0097;\nL_0097:\n\tv336 = UnityEngine.Behaviour::get_isActiveAndEnabled(v277);\n\tv339 = ~v336;\n\tif (v339) goto L_0063;\n\tv353 = *([v277 @ X0_v9 (UnityEngine.Object)+31]) == 0;\n\tv358 = ~v353;\n\tv359 = ~v358;\n\tif (v359) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv342 = 2;\n\tgoto L_00AB;\nL_FFFFFFFF:\n\tv342 = 0;\nL_FFFFFFFF:\n\tv342 = v301;\n\tgoto L_00C8;\n\tv340 = v342 == 0;\n\tif (v340) goto L_0063;\n\tgoto L_00D5;\nL_00D5:\n\tgoto L_00D9;\nL_00D9:\n\tv425 = UnityEngine.Object::op_Equality(v396.sBlockerOutlineAndGlowMat, 0);\n\tv474 = ~v425;\n\tv475 = ~v474;\n\tif (v475) goto L_0136;\nL_FFFFFFFF:\n\tv589 = HighlightPlus.HighlightPlusRenderPassFeature;\nL_FFFFFFFF:\n\tv341 = 0x18;\n\tgoto L_005E;\nL_00EE:\n\tv386 = v342 != 4;\n\tif (v386) goto L_010C;\n\tgoto L_00F9;\nL_00F9:\n\tgoto L_00FD;\nL_00FD:\n\tv445 = UnityEngine.Object::op_Equality(v402.sBlockerOverlayMat, 0);\n\tv480 = ~v445;\n\tv481 = ~v480;\n\tif (v481) goto L_0160;\nL_FFFFFFFF:\n\tv589 = HighlightPlus.HighlightPlusRenderPassFeature;\nL_FFFFFFFF:\n\tv341 = 0x20;\n\tgoto L_005E;\nL_010C:\n\tgoto L_0112;\nL_0112:\n\tgoto L_0116;\nL_0116:\n\tv465 = UnityEngine.Object::op_Equality(v408.sBlockerAllMat, 0);\n\tv486 = ~v465;\n\tv487 = ~v486;\n\tif (v487) goto L_018A;\nL_FFFFFFFF:\n\tv589 = HighlightPlus.HighlightPlusRenderPassFeature;\nL_FFFFFFFF:\n\tv341 = 0x28;\n\tgoto L_005E;\nL_0136:\n\tv515 = UnityEngine.Resources::Load(\"HighlightPlus/HighlightBlockerOutlineAndGlow\");\n\tgoto L_0141;\nL_0160:\n\tv539 = UnityEngine.Resources::Load(\"HighlightPlus/HighlightBlockerOverlay\");\n\tgoto L_016B;\nL_018A:\n\tv563 = UnityEngine.Resources::Load(\"HighlightPlus/HighlightUIMask\");\n\tgoto L_0195;\nL_01AD:\n\treturn;\nL_01AE:\n\tthrow System.NullReferenceException;\nL_00AB:\n\t;\n\tv301 = v342 | 4;\n\tv367 = *([v277 @ X0_v9 (UnityEngine.Object)+32]) == 0;\n\tv372 = ~v367;\n\tv305 = ~v372;\n\tif (v305) goto L_00C8;\nL_00C8:\n\tv310 = v342 > 3;\n\tif (v310) goto L_00EE;\nL_005E:\n\tv302 = *([v589 @ X0_v14 (Il2CppClass<HighlightPlus.HighlightPlusRenderPassFeature>)+B8]);\n\tHighlightPlus.HighlightEffectBlocker::BuildCommandBuffer(v277, cmd, *([v302 @ X9_v6 (Il2CppStaticFields<HighlightPlus.HighlightPlusRenderPassFeature>)+v341 @ X8_v12 (System.Int32)]));\nL_0141:\n\tv623.sBlockerOutlineAndGlowMat = v515;\nL_FFFFFFFF:\n\tv589 = HighlightPlus.HighlightPlusRenderPassFeature;\nL_FFFFFFFF:\n\tv341 = 0x18;\n\tgoto L_005E;\nL_016B:\n\tv629.sBlockerOverlayMat = v539;\nL_FFFFFFFF:\n\tv589 = HighlightPlus.HighlightPlusRenderPassFeature;\nL_FFFFFFFF:\n\tv341 = 0x20;\n\tgoto L_005E;\nL_0195:\n\tv635.sBlockerAllMat = v563;\nL_FFFFFFFF:\n\tv589 = HighlightPlus.HighlightPlusRenderPassFeature;\nL_FFFFFFFF:\n\tv341 = 0x28;\n\tgoto L_005E;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RenderBlockers(CommandBuffer cmd)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightPlusRenderPassFeature::RenderBlockers");
		}

		[Token(Token = "0x60000E7")]
		[Address(RVA = "0x7725F44", Offset = "0x7725F44", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tv51 = v49.outlineAndGlowOccluders == 0;\n\tv52 = ~v51;\n\tif (v52) goto L_0034;\n\tgoto L_007D;\nL_0034:\n\tv70 = System.Collections.Generic.List`1<HighlightPlus.HighlightEffectBlocker>::Contains(v49.outlineAndGlowOccluders, occluder);\n\tv90 = v70 == 0;\n\tif (v90) goto L_0044;\n\treturn;\nL_0044:\n\tgoto L_0048;\n\tgoto L_007B;\nL_007B:\n\tSystem.Collections.Generic.List`1<HighlightPlus.HighlightEffectBlocker>::Add(v81, occluder);\n\treturn;\nL_007D:\n\tthrow System.NullReferenceException;\nL_0048:\n\tv81 = v87.outlineAndGlowOccluders;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RegisterBlocker(HighlightEffectBlocker occluder)
		{
			if (outlineAndGlowOccluders != null)
			{
				if (!outlineAndGlowOccluders.Contains(occluder))
				{
					List<HighlightEffectBlocker> list = outlineAndGlowOccluders;
					list.Add(occluder);
				}
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x60000E8")]
		[Address(RVA = "0x7726180", Offset = "0x7726180", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0023;\nL_0023:\n\tv75 = System.Collections.Generic.List`1<HighlightPlus.HighlightEffectBlocker>::Remove(v49.outlineAndGlowOccluders, occluder);\n\treturn;\n")]
		public static void UnregisterBlocker(HighlightEffectBlocker occluder)
		{
			bool flag = outlineAndGlowOccluders.Remove(occluder);
		}

		[Token(Token = "0x60000E9")]
		[Address(RVA = "0x772D034", Offset = "0x772D034", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = descriptor.width;\n\tv22 = UnityEngine.RenderTextureDescriptor::get_colorFormat(&v14 @ stack_-60_v1 (UnityEngine.RenderTextureDescriptor));\n\tv27 = v22 == 1;\n\treturnVal1 = v22;\n\tif (v27) goto L_0036;\n\tv14 = descriptor.width;\n\tv42 = UnityEngine.RenderTextureDescriptor::get_graphicsFormat(&v14 @ stack_-60_v1 (UnityEngine.RenderTextureDescriptor));\n\tv52 = v42 == 0;\n\treturnVal1 = v52;\nL_0036:\n\treturn returnVal1;\n")]
		private static bool IsDepthOnlyTarget(in RenderTextureDescriptor descriptor)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightPlusRenderPassFeature::IsDepthOnlyTarget");
			return default;
		}

		[Token(Token = "0x60000EA")]
		[Address(RVA = "0x772D57C", Offset = "0x772D57C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.renderPassEvent = 0x1F4;\n\tthis.previewInEditMode = 0x101;\n\tUnityEngine.Rendering.Universal.ScriptableRendererFeature::.ctor(this);\n\treturn;\n")]
		public HighlightPlusRenderPassFeature()
		{
			renderPassEvent = RenderPassEvent.AfterRenderingTransparents;
			previewInEditMode = true;
			showInSceneView = true;
		}

		[Token(Token = "0x60000EB")]
		[Address(RVA = "0x772D594", Offset = "0x772D594", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\treturn;\nL_0020:\n\tv49 = new System.Collections.Generic.List`1<HighlightPlus.HighlightEffectBlocker>();\n\tSystem.Collections.Generic.List`1<HighlightPlus.HighlightEffectBlocker>::.ctor(v49);\n\tv58.outlineAndGlowOccluders = v49;\n")]
		static HighlightPlusRenderPassFeature()
		{
			List<HighlightEffectBlocker> list = new List<HighlightEffectBlocker>();
			outlineAndGlowOccluders = list;
		}
	}
}
