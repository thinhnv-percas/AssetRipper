using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Rendering;

namespace Obi
{
	[Token(Token = "0x2000041")]
	public class ShadowmapExposer : MonoBehaviour
	{
		[Token(Token = "0x40000FF")]
		[FieldOffset(Offset = "0x18")]
		private Light unityLight;

		[Token(Token = "0x4000100")]
		[FieldOffset(Offset = "0x20")]
		private CommandBuffer afterShadow;

		[Token(Token = "0x4000101")]
		[FieldOffset(Offset = "0x28")]
		public ObiParticleRenderer[] particleRenderers;

		[Token(Token = "0x60002F7")]
		[Address(RVA = "0x1035ABC", Offset = "0x1035ABC", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EFAE68]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20262A4]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tthis.unityLight = v43;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Awake()
		{
			Light component = GetComponent<Light>();
			unityLight = component;
		}

		[Token(Token = "0x60002F8")]
		[Address(RVA = "0x1035B14", Offset = "0x1035B14", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ED8418]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20262A5]) = v38;\nL_0014:\n\tObi.ShadowmapExposer::Cleanup(this);\n\tv43 = new UnityEngine.Rendering.CommandBuffer();\n\tUnityEngine.Rendering.CommandBuffer::.ctor(v43);\n\tthis.afterShadow = v43;\n\tUnityEngine.Rendering.CommandBuffer::set_name(v43, \"FluidShadows\");\n\tUnityEngine.Light::AddCommandBuffer(this.unityLight, 5, this.afterShadow);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnEnable()
		{
			Cleanup();
			(afterShadow = new CommandBuffer()).name = "FluidShadows";
			unityLight.AddCommandBuffer(LightEvent.AfterShadowMapPass, afterShadow);
		}

		[Token(Token = "0x60002F9")]
		[Address(RVA = "0x1035BF4", Offset = "0x1035BF4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ShadowmapExposer::Cleanup(this);\n\treturn;\n")]
		public void OnDisable()
		{
			Cleanup();
		}

		[Token(Token = "0x60002FA")]
		[Address(RVA = "0x1035BB4", Offset = "0x1035BB4", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.afterShadow == 0;\n\tif (v11) goto L_0014;\n\tUnityEngine.Light::RemoveCommandBuffer(this.unityLight, 5, this.afterShadow);\n\tthis.afterShadow = 0;\nL_0014:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Cleanup()
		{
			if (afterShadow != null)
			{
				unityLight.RemoveCommandBuffer(LightEvent.AfterShadowMapPass, afterShadow);
				afterShadow = null;
			}
		}

		[Token(Token = "0x60002FB")]
		[Address(RVA = "0x1035BF8", Offset = "0x1035BF8", Length = "0x414")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\tgoto L_001F;\n\tv34 = *([1EA4AE0]);\n\tv35 = *([v34 @ X8_v45]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([20262A6]) = v54;\nL_001F:\n\tUnityEngine.Rendering.CommandBuffer::Clear(this.afterShadow);\n\tv179 = this.particleRenderers;\n\tv196 = this.particleRenderers == 0;\n\tif (v196) goto L_01A4;\n\tv306 = v179.Length < 1;\n\tif (v306) goto L_0186;\nL_0044:\n\tv128 = v179[v134 @ X26_v7 (System.Int32)];\n\tgoto L_0051;\n\tv555 = *([v549 @ X0_v18+E0]);\n\tv556 = v555 == 0;\n\tv557 = ~v556;\n\tif (v557) goto L_0051;\n\tv559 = \"il2cpp_codegen_runtime_class_init\"(v549, v544, v532, v95, v73, v76, v70, v43, v104, v107, v98, v101, v48, v49, v50, v51);\nL_0051:\n\tv282 = UnityEngine.Object::op_Inequality(v179[v134 @ X26_v7 (System.Int32)], 0);\n\tv588 = v282 == 0;\n\tif (v588) goto L_0172;\n\tv285 = v179[v134 @ X26_v7 (System.Int32)] == 0;\n\tif (v285) goto L_01AB;\n\tv185 = Obi.ObiParticleRenderer::get_ParticleMeshes(v179[v134 @ X26_v7 (System.Int32)]);\n\tgoto L_008A;\n\tv614 = *([v608 @ X8_v16+B0]);\n\tv615 = 0;\n\tv616 = v614 + 8;\n\tv618 = *([v645 @ X11_v32-8]);\n\tv660 = v618 == v612;\n\tif (v660) goto L_0083;\n\tv622 = v646 + 1;\n\tv665 = v622 < v610;\n\tv640 = ~v665;\n\tv620 = v645 + 0x10;\n\tv624 = ~v640;\n\tif (v624) goto L_FFFFFFFF;\n\tv641 = v118;\n\tv642 = 0;\n\tv643 = 0x8909C4(v641, v612, v642, v95, v73, v76, v70, v43, v104, v107, v98, v101, v48, v49, v50, v51);\n\tgoto L_008A;\nL_0083:\n\tv666 = *([v645 @ X11_v32]);\n\tv667 = v666 << 4;\n\tv668 = v608 + v667;\n\tv669 = v668 + 0x130;\nL_008A:\n\tv673 = System.Collections.Generic.IEnumerable`1<UnityEngine.Mesh>::GetEnumerator(v185);\n\tv525 = v673 == 0;\n\tif (v525) goto L_0118;\nL_0092:\n\tgoto L_00B9;\n\tv712 = *([v708 @ X8_v20+B0]);\n\tv713 = 0;\n\tv714 = v712 + 8;\n\tv716 = *([v743 @ X11_v27-8]);\n\tv758 = v716 == v709;\n\tif (v758) goto L_00B2;\n\tv720 = v744 + 1;\n\tv763 = v720 < v710;\n\tv738 = ~v763;\n\tv718 = v743 + 0x10;\n\tv722 = ~v738;\n\tif (v722) goto L_FFFFFFFF;\n\tv739 = v474;\n\tv740 = 0;\n\tv741 = 0x8909C4(v739, v709, v740, v458, v446, v448, v444, v43, v464, v466, v460, v462, v48, v49, v50, v51);\n\tgoto L_00B9;\nL_00B2:\n\tv764 = *([v743 @ X11_v27]);\n\tv765 = v764 << 4;\n\tv766 = v708 + v765;\n\tv767 = v766 + 0x130;\nL_00B9:\n\tv788 = System.Collections.IEnumerator::MoveNext(v673);\n\tv790 = v788 == 0;\n\tif (v790) goto L_010F;\n\tgoto L_00EA;\n\tv799 = *([v791 @ X8_v30+B0]);\n\tv800 = 0;\n\tv801 = v799 + 8;\n\tv803 = *([v836 @ X11_v22-8]);\n\tv851 = v803 == v795;\n\tif (v851) goto L_00E3;\n\tv807 = v837 + 1;\n\tv909 = v807 < v793;\n\tv825 = ~v909;\n\tv805 = v836 + 0x10;\n\tv809 = ~v825;\n\tif (v809) goto L_FFFFFFFF;\n\tv826 = v474;\n\tv827 = 0;\n\tv828 = 0x8909C4(v826, v795, v827, v458, v446, v448, v444, v43, v464, v466, v460, v462, v48, v49, v50, v51);\n\tgoto L_00EA;\nL_00E3:\n\tv910 = *([v836 @ X11_v22]);\n\tv911 = v910 << 4;\n\tv912 = v791 + v911;\n\tv913 = v912 + 0x130;\nL_00EA:\n\tv918 = System.Collections.Generic.IEnumerator`1<UnityEngine.Mesh>::get_Current(v673);\n\tgoto L_00FB;\n\tv948 = *([v921 @ X0_v44+E0]);\n\tv949 = v948 == 0;\n\tv950 = ~v949;\n\tgoto L_00FB;\n\tv952 = \"il2cpp_codegen_runtime_class_init\"(v921, v518, v476, v458, v446, v448, v444, v43, v464, v466, v460, v462, v48, v49, v50, v51);\nL_00FB:\n\tv956 = UnityEngine.Matrix4x4::get_identity();\n\tv524 = this.afterShadow == 0;\n\tif (v524) goto L_0115;\n\tv466 = *([v24 @ X29_v1-70]);\n\tv464 = *([v24 @ X29_v1-60]);\n\tv47 = *([v24 @ X29_v1-90]);\n\tv460 = *([v24 @ X29_v1-80]);\n\tv458 = *([v128 @ X22_v8 (UnityEngine.Object)+40]);\n\tUnityEngine.Rendering.CommandBuffer::DrawMesh(this.afterShadow, v918, &v47 @ V3, *([v128 @ X22_v8 (UnityEngine.Object)+40]), 0, 1);\n\tgoto L_0092;\nL_010F:\n\tv586 = v427 + 1;\n\tv797 = v673 == 0;\n\tv798 = ~v797;\n\tif (v798) goto L_0139;\n\tgoto L_0161;\nL_0115:\n\tv521 = new System.NullReferenceException();\n\tObi.ShadowmapExposer::Update(v521);\n\treturn;\nL_0118:\n\tv522 = new System.NullReferenceException();\n\tObi.ShadowmapExposer::Update(v522);\n\treturn;\n\tgoto L_0120;\n\tgoto L_0120;\n\tgoto L_0120;\n\tgoto L_0120;\n\tgoto L_0120;\nL_0120:\n\tX8 = X1;\n\tX2 = X0;\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_01AC;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X0]);\n\tstack[8] = X8;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0161;\nL_0139:\n\tgoto L_0160;\n\tv879 = *([v829 @ X8_v26+B0]);\n\tv880 = 0;\n\tv881 = v879 + 8;\n\tv883 = *([v928 @ X11_v16-8]);\n\tv943 = v883 == v833;\n\tif (v943) goto L_0159;\n\tv887 = v929 + 1;\n\tv957 = v887 < v831;\n\tv905 = ~v957;\n\tv885 = v928 + 0x10;\n\tv889 = ~v905;\n\tif (v889) goto L_FFFFFFFF;\n\tv906 = v474;\n\tv907 = 0;\n\tv908 = 0x8909C4(v906, v833, v907, v458, v446, v448, v444, v43, v464, v466, v460, v462, v48, v49, v50, v51);\n\tgoto L_0160;\nL_0159:\n\tv958 = *([v928 @ X11_v16]);\n\tv959 = v958 << 4;\n\tv960 = v829 + v959;\n\tv961 = v960 + 0x130;\nL_0160:\n\tSystem.IDisposable::Dispose(v673);\nL_0161:\n\tv600 = v586 + 1;\n\tv576 = v600 == 0;\n\tif (v576) goto L_016C;\n\tv602 = 0xFFFFFFFF ^ v586;\n\tv427 = v586 + v602;\n\tgoto L_0172;\nL_016C:\n\tv926 = v410 == 0;\n\tv584 = ~v926;\n\tif (v584) goto L_01A8;\nL_0172:\n\tv134 = v134 + 1;\n\tv411 = v134 < v179.Length;\n\tif (v411) goto L_0044;\nL_0186:\n\tv205 = 0;\n\tv283 = 0x10D33A4(&v205 @ stack_-108_v3, 1, 0, v226, v214, v216, v212, v43, 0, v234, v228, v47, v48, v49, v50, v51);\n\tv286 = this.afterShadow == 0;\n\tif (v286) goto L_01AB;\n\tv314 = 0;\n\tUnityEngine.Rendering.CommandBuffer::SetGlobalTexture(this.afterShadow, \"_MyShadowMap\", &v314 @ stack_-130_v2);\nL_01A4:\n\treturn;\n\tv553 = new System.IndexOutOfRangeException();\nL_01A8:\n\tv184 = new System.TypeLoadException();\n\tthrow System.NullReferenceException;\nL_01AB:\n\tv294 = new System.NullReferenceException();\nL_01AC:\n\tv380 = 0x6D2380(v294, v180, v243, v226, v214, v216, v212, v43, v102, v234, v228, v47, v48, v49, v50, v51);\n\treturn;\n// 238 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void SetupFluidShadowsCommandBuffer()
		{
			//IL_03a0: Expected O, but got I4
			//IL_03c4: Expected O, but got I4
			//IL_00af: Expected O, but got I8
			//IL_03ed: Expected O, but got I4
			//IL_0401: Expected O, but got Ref
			//IL_0154: Expected I, but got O
			//IL_025c: Expected O, but got I
			//IL_054b: Expected O, but got I
			//IL_041e: Expected I, but got O
			//IL_02d1: Expected I4, but got I8
			//IL_02df: Expected O, but got I
			//IL_01c4: Expected O, but got I
			//IL_01d4: Expected O, but got I
			//IL_01e4: Expected O, but got I
			//IL_01f4: Expected O, but got I
			//IL_0204: Expected O, but got I
			//IL_022d: Expected O, but got I
			//IL_022d: Expected O, but got Ref
			//IL_0236: Expected O, but got I4
			//IL_0392: Expected O, but got I8
			object obj2 = default(object);
			object obj = obj2;
			afterShadow.Clear();
			ObiParticleRenderer[] array = particleRenderers;
			if (particleRenderers == null)
			{
				return;
			}
			if (array.Length < 1)
			{
				goto IL_0397;
			}
			object obj4 = default(object);
			object obj3 = obj4;
			int num2 = default(int);
			int num = num2;
			int num4 = default(int);
			int num3 = num4;
			Material material2 = default(Material);
			Material material = material2;
			object obj6 = default(object);
			object obj5 = obj6;
			object obj8 = default(object);
			object obj7 = obj8;
			int num5 = 0;
			int num6 = 0;
			object obj9 = 4294967295L;
			object obj14 = default(object);
			int num7;
			IntPtr intPtr;
			while (true)
			{
				UnityEngine.Object obj10 = array[num5];
				if (array[num5] != null)
				{
					bool flag = (object)array[num5] == null;
					obj4 = obj3;
					num2 = num;
					num4 = num3;
					material2 = material;
					obj6 = obj5;
					obj8 = obj7;
					num7 = 0;
					intPtr = (IntPtr)null;
					if (flag)
					{
						break;
					}
					IEnumerable<Mesh> particleMeshes = array[num5].ParticleMeshes;
					IEnumerator<Mesh> enumerator = particleMeshes.GetEnumerator();
					bool flag2 = enumerator == null;
					object obj11 = obj3;
					int num8 = num;
					int num9 = num3;
					Material material3 = material;
					object obj12 = obj5;
					object obj13 = obj14;
					object obj15 = obj7;
					if (flag2)
					{
						NullReferenceException ex = new NullReferenceException();
						((ShadowmapExposer)(object)ex).Update();
						return;
					}
					while (enumerator.MoveNext())
					{
						Mesh current = enumerator.Current;
						Matrix4x4 identity = Matrix4x4.identity;
						if (afterShadow != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-70]");
							obj15 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-60]");
							obj13 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-90]");
							object obj16 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-80]");
							obj12 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X22_v8 (UnityEngine.Object)+40]");
							material3 = (Material)0;
							CommandBuffer commandBuffer = afterShadow;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X22_v8 (UnityEngine.Object)+40]");
							commandBuffer.DrawMesh(current, (Matrix4x4)(&obj16), (Material)0, 0, 1);
							obj11 = 0;
							num8 = 0;
							num9 = 1;
							continue;
						}
						NullReferenceException ex2 = new NullReferenceException();
						((ShadowmapExposer)(object)ex2).Update();
						return;
					}
					object obj17 = (long)(IntPtr)obj9 + 1L;
					enumerator?.Dispose();
					object obj18 = (long)(IntPtr)obj17 + 1L;
					if (obj18 != null)
					{
						int num10 = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj17);
						obj9 = (long)(IntPtr)obj17 + (long)num10;
						obj3 = obj11;
						num = num8;
						num3 = num9;
						material = material3;
						obj5 = obj12;
						obj14 = obj13;
						obj7 = obj15;
					}
					else
					{
						if (num6 != 0)
						{
							TypeLoadException ex3 = new TypeLoadException();
							num7 = 0;
							intPtr = (IntPtr)null;
							throw new NullReferenceException();
						}
						obj3 = obj11;
						num = num8;
						num3 = num9;
						material = material3;
						obj5 = obj12;
						obj14 = obj13;
						obj7 = obj15;
						num6 = 0;
						obj9 = 4294967295L;
					}
				}
				num5++;
				bool flag3 = num5 < array.Length;
				obj4 = obj3;
				num2 = num;
				num4 = num3;
				material2 = material;
				obj6 = obj5;
				obj8 = obj7;
				if (flag3)
				{
					continue;
				}
				goto IL_0397;
			}
			goto IL_0429;
			IL_0429:
			NullReferenceException ex4 = new NullReferenceException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			return;
			IL_0397:
			object obj19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D33A4 (inside UnityEngine.Rendering.RenderPipelineManager::PrepareRenderPipeline +0x144)");
			bool flag4 = afterShadow == null;
			obj14 = 0;
			num7 = 0;
			intPtr = (IntPtr)1;
			if (!flag4)
			{
				object obj20 = 0;
				afterShadow.SetGlobalTexture("_MyShadowMap", (RenderTargetIdentifier)(&obj20));
				return;
			}
			goto IL_0429;
		}

		[Token(Token = "0x60002FC")]
		[Address(RVA = "0x103600C", Offset = "0x103600C", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Component::get_gameObject(this);\n\tv14 = UnityEngine.GameObject::get_activeInHierarchy(v11);\n\tv31 = v14 == 0;\n\tif (v31) goto L_002A;\n\tv34 = UnityEngine.Behaviour::get_enabled(this);\n\tv40 = v34 == 0;\n\tif (v40) goto L_002A;\n\tv37 = this.particleRenderers;\n\tv41 = this.particleRenderers == 0;\n\tif (v41) goto L_002A;\n\tv42 = v37.Length == 0;\n\tif (v42) goto L_002A;\n\tv55 = this.afterShadow == 0;\n\tif (v55) goto L_0030;\n\tObi.ShadowmapExposer::SetupFluidShadowsCommandBuffer(this);\n\treturn;\nL_002A:\n\tObi.ShadowmapExposer::Cleanup(this);\n\treturn;\nL_0030:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			GameObject gameObject = base.gameObject;
			if (gameObject.activeInHierarchy && base.enabled)
			{
				ObiParticleRenderer[] array = particleRenderers;
				if (particleRenderers != null && array.Length != 0)
				{
					if (afterShadow != null)
					{
						SetupFluidShadowsCommandBuffer();
					}
					return;
				}
			}
			Cleanup();
		}

		[Token(Token = "0x60002FD")]
		[Address(RVA = "0x103608C", Offset = "0x103608C", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n\t// 3 ShiftStack -32\n\tstack[0] = X20;\n\tstack[8] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX8 = *([20262A7]);\n\tX20 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0016;\n\tX8 = *([1ED2CF0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([20262A7]) = X8;\nL_0016:\n\tX19 = *([X20]);\n\tif (TEMP) goto L_0040;\n\tX8 = *([X19]);\n\tX20 = *([X20+8]);\n\tX10 = *([1EBB0D0]);\n\tX9 = *([X8+126]);\n\tX1 = *([X10]);\n\tif (TEMP) goto L_003C;\n\tX11 = *([X8+B0]);\n\tX10 = 0;\n\tX11 = X11 + 8;\nL_0024:\n\tX12 = *([X11-8]);\n\tC = X12 < X1;\n\tC = ~C;\n\tTEMP1 = X12 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X12 ^ X1;\n\tTEMP3 = X12 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0047;\n\tX10 = X10 + 1;\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX11 = X11 + 0x10;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_0024;\nL_003C:\n\tX0 = X19;\n\tX2 = 0;\n\tX0 = 0x8909C4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_004B;\nL_0040:\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tV0 = -1f;\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 69 ShiftStack 32\n\treturn;\nL_0047:\n\tX9 = *([X11]);\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tX0 = X8 + 0x130;\nL_004B:\n\tX3 = *([X0]);\n\tX2 = *([X0+8]);\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX0 = X19;\n\tX1 = X20;\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 83 ShiftStack 32\n\t// 84 IndirectJump X3, X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7\n\t// 85 ShiftStack -48\n\tstack[0] = V8;\n\tstack[10] = X20;\n\tstack[18] = X19;\n\tstack[20] = X29;\n\tstack[28] = X30;\n\tX29 = &stack[20];\n\tX8 = *([20262A8]);\n\tV8 = V0;\n\tX20 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_006A;\n\tX8 = *([1ED3DD8]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([20262A8]) = X8;\nL_006A:\n\tX19 = *([X20]);\n\tif (TEMP) goto L_0094;\n\tX8 = *([X19]);\n\tX20 = *([X20+8]);\n\tX10 = *([1EBB0D0]);\n\tX9 = *([X8+126]);\n\tX1 = *([X10]);\n\tif (TEMP) goto L_0090;\n\tX11 = *([X8+B0]);\n\tX10 = 0;\n\tX11 = X11 + 8;\nL_0078:\n\tX12 = *([X11-8]);\n\tC = X12 < X1;\n\tC = ~C;\n\tTEMP1 = X12 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X12 ^ X1;\n\tTEMP3 = X12 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_009B;\n\tX10 = X10 + 1;\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX11 = X11 + 0x10;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_0078;\nL_0090:\n\tX2 = 0 | 1;\n\tX0 = X19;\n\tX0 = 0x8909C4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00A0;\nL_0094:\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tV8 = stack[0];\n\t// 153 ShiftStack 48\n\treturn;\nL_009B:\n\tX9 = *([X11]);\n\tX9 = X9 + 1;\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tX0 = X8 + 0x130;\nL_00A0:\n\tX3 = *([X0]);\n\tX2 = *([X0+8]);\n\tX0 = X19;\n\tX1 = X20;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tV0 = V8;\n\tV8 = stack[0];\n\t// 170 ShiftStack 48\n\t// 171 IndirectJump X3, X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7\n\t*([X0]) = X1;\n\t*([X0+8]) = X2;\n\t*([X0+C]) = V0;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ShadowmapExposer()
		{
		}
	}
}
