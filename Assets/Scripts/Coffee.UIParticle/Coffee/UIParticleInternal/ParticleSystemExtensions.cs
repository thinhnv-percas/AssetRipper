using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Coffee.UIParticleInternal
{
	[Token(Token = "0x200001C")]
	internal static class ParticleSystemExtensions
	{
		[Token(Token = "0x4000028")]
		private static ParticleSystem.Particle[] s_TmpParticles;

		[Token(Token = "0x600007B")]
		[Address(RVA = "0x3F21598", Offset = "0x3F21598", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0015;\nL_0015:\n\tv64 = v49.s_TmpParticles;\n\tv51 = v49.s_TmpParticles == 0;\n\tv52 = ~v51;\n\tif (v52) goto L_0037;\n\tgoto L_009F;\nL_0037:\n\tv76 = v64.Length >= size;\n\tif (v76) goto L_0064;\n\tgoto L_003C;\nL_003C:\n\tv199 = size - 1;\n\tv199 = v81;\n\t// 84 NewArr v267 @ X0_v15 (Particle[]), typeof(Particle[]), v262 @ X19_v9 (System.Int32)\n\tgoto L_005E;\nL_006E:\n\treturn v159.s_TmpParticles;\nL_009F:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_0064:\n\tgoto L_006E;\nL_003D:\n\tv221 = v199 | v199;\n\tv222 = v221 | v221;\n\tv223 = v222 | v222;\n\tv224 = v223 | v223;\n\tv199 = v224 | v224;\n\tv262 = v199 + 1;\n\tv202 = v262 > v64.Length;\n\tif (v202) goto L_003D;\nL_005E:\n\tv283.s_TmpParticles = v267;\n")]
		public static ParticleSystem.Particle[] GetParticleArray(int size)
		{
			ParticleSystem.Particle[] array = s_TmpParticles;
			if (s_TmpParticles != null)
			{
				if (array.Length < size)
				{
					int num = size - 1;
					int num2 = default(int);
					num = num2;
					int num7;
					do
					{
						int num3 = num | num;
						int num4 = num3 | num3;
						int num5 = num4 | num4;
						int num6 = num5 | num5;
						num = num6 | num6;
						num7 = num + 1;
					}
					while (num7 > array.Length);
					ParticleSystem.Particle[] array2 = new ParticleSystem.Particle[num7];
					s_TmpParticles = array2;
				}
				return s_TmpParticles;
			}
			return (ParticleSystem.Particle[])(object)new NullReferenceException();
		}

		[Token(Token = "0x600007C")]
		[Address(RVA = "0x3F21728", Offset = "0x3F21728", Length = "0x224")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = UnityEngine.ParticleSystem::get_shape(self);\n\tv34 = v17;\n\tv37 = UnityEngine.ParticleSystem+ShapeModule::get_enabled(&v34 @ stack_-38_v1 (UnityEngine.ParticleSystem+ShapeModule));\n\tv38 = ~v37;\n\tif (v38) goto L_00EF;\n\tv101 = UnityEngine.ParticleSystem+ShapeModule::get_alignToDirection(&v34 @ stack_-38_v1 (UnityEngine.ParticleSystem+ShapeModule));\n\tv164 = ~v101;\n\tif (v164) goto L_00EF;\n\tv169 = UnityEngine.ParticleSystem+ShapeModule::get_scale(&v34 @ stack_-38_v1 (UnityEngine.ParticleSystem+ShapeModule));\n\tv175 = UnityEngine.ParticleSystem+ShapeModule::get_scale(&v34 @ stack_-38_v1 (UnityEngine.ParticleSystem+ShapeModule));\n\tv179 = UnityEngine.ParticleSystem+ShapeModule::get_scale(&v34 @ stack_-38_v1 (UnityEngine.ParticleSystem+ShapeModule));\n\tv182 = v169 * v175.y;\n\tv147 = v182 * v179.z;\n\tgoto L_0037;\n\tgoto L_0054;\nL_FFFFFFFF:\n\tv156 = v150;\n\tv216 = UnityEngine.ParticleSystem+ShapeModule::get_scale(&v34 @ stack_-38_v1 (UnityEngine.ParticleSystem+ShapeModule));\n\tgoto L_006F;\nL_FFFFFFFF:\n\tv142 = v239;\n\tgoto L_008C;\nL_FFFFFFFF:\n\tv142 = v241;\n\tgoto L_00A7;\nL_FFFFFFFF:\n\tv146 = v309;\n\tgoto L_00C4;\nL_FFFFFFFF:\n\tv146 = v132;\n\tv158 = 0x3F1F834(0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v280.z, 0, v280.z, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv165 = v158 == 0;\n\tif (v165) goto L_00EF;\n\tv279 = UnityEngine.ParticleSystem+ShapeModule::get_scale(&v34 @ stack_-38_v1 (UnityEngine.ParticleSystem+ShapeModule));\nL_00EF:\n\treturn;\nL_0037:\n\tv192 = UnityEngine.Mathf::Abs(v147);\n\tv193 = UnityEngine.Mathf::Max(v192, 0f);\n\tv156 = v193 * 0x358637BD;\n\tv150 = v195.Epsilon * 8f;\n\tv200 = v156 < v150;\n\tv201 = v156 == v150;\n\tv204 = v156 == v156;\n\tv205 = v150 == v150;\n\tv206 = v204 & v205;\n\tv207 = ~v206;\n\tv208 = v200 == v207;\n\tv109 = ~v201;\n\tv209 = v208 & v109;\n\tv106 = ~v209;\n\tif (v106) goto L_FFFFFFFF;\nL_0054:\n\t// 84 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv130 = 0 < v156;\n\tv112 = ~v130;\n\tif (v112) goto L_00EF;\nL_006F:\n\tv230 = UnityEngine.Mathf::Abs(v216);\n\tv232 = UnityEngine.Mathf::Max(v230, 0f);\n\tv239 = v232 * 0x358637BD;\n\tv241 = v234.Epsilon * 8f;\n\tv242 = v239 < v241;\n\tv243 = v239 == v241;\n\tv246 = v239 == v239;\n\tv247 = v241 == v241;\n\tv248 = v246 & v247;\n\tv249 = ~v248;\n\tv250 = v242 == v249;\n\tv251 = ~v243;\n\tv252 = v250 & v251;\n\tv253 = ~v252;\n\tif (v253) goto L_FFFFFFFF;\nL_008C:\n\t// 140 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv258 = UnityEngine.ParticleSystem+ShapeModule::get_scale(&v34 @ stack_-38_v1 (UnityEngine.ParticleSystem+ShapeModule));\n\tv261 = v216 < v142;\n\tif (v261) goto L_00E0;\nL_00E0:\n\tv288 = UnityEngine.ParticleSystem+ShapeModule::get_scale(&v34 @ stack_-38_v1 (UnityEngine.ParticleSystem+ShapeModule));\n\tv154 = UnityEngine.ParticleSystem+ShapeModule::get_scale(&v34 @ stack_-38_v1 (UnityEngine.ParticleSystem+ShapeModule));\nL_00A7:\n\tv299 = UnityEngine.Mathf::Abs(v258.y);\n\tv303 = UnityEngine.Mathf::Max(v299, 0f);\n\tv309 = v303 * 0x358637BD;\n\tv132 = v305.Epsilon * 8f;\n\tv310 = v309 < v132;\n\tv311 = v309 == v132;\n\tv314 = v309 == v309;\n\tv315 = v132 == v132;\n\tv316 = v314 & v315;\n\tv317 = ~v316;\n\tv318 = v310 == v317;\n\tv108 = ~v311;\n\tv111 = v318 & v108;\n\tv105 = ~v111;\n\tif (v105) goto L_FFFFFFFF;\nL_00C4:\n\t// 196 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv280 = UnityEngine.ParticleSystem+ShapeModule::get_scale(&v34 @ stack_-38_v1 (UnityEngine.ParticleSystem+ShapeModule));\n\tv129 = v142 < v146;\n\tif (v129) goto L_00E0;\n")]
		public static void ValidateShape(this ParticleSystem self)
		{
			ParticleSystem.ShapeModule shape = self.shape;
			ParticleSystem.ShapeModule shapeModule = shape;
			if (!shapeModule.enabled || !shapeModule.alignToDirection)
			{
				return;
			}
			Vector3 scale = shapeModule.scale;
			Vector3 scale2 = shapeModule.scale;
			Vector3 scale3 = shapeModule.scale;
			float num = scale.x * scale2.y;
			float f = num * scale3.z;
			float a = Mathf.Abs(f);
			float num2 = Mathf.Max(a, 0f);
			float num3 = num2 * 1E-06f;
			float num4 = Mathf.Epsilon * 8f;
			bool flag = num3 < num4;
			bool flag2 = num3 == num4;
			bool flag3 = num3 == num3;
			bool flag4 = num4 == num4;
			bool flag5 = flag3 && flag4;
			bool flag6 = !flag5;
			bool flag7 = flag == flag6;
			bool flag8 = !flag2;
			if (!(flag7 && flag8))
			{
				num3 = num4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
			if (!(0f < num3))
			{
				return;
			}
			Vector3 scale4 = shapeModule.scale;
			float a2 = Mathf.Abs(scale4.x);
			float num5 = Mathf.Max(a2, 0f);
			float num6 = num5 * 1E-06f;
			float num7 = Mathf.Epsilon * 8f;
			bool flag9 = num6 < num7;
			bool flag10 = num6 == num7;
			bool flag11 = num6 == num6;
			bool flag12 = num7 == num7;
			bool flag13 = flag11 && flag12;
			bool flag14 = !flag13;
			bool flag15 = flag9 == flag14;
			bool flag16 = !flag10;
			float num8 = ((!(flag15 && flag16)) ? num7 : num6);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
			Vector3 scale5 = shapeModule.scale;
			if (!(scale4.x < num8))
			{
				float a3 = Mathf.Abs(scale5.y);
				float num9 = Mathf.Max(a3, 0f);
				float num10 = num9 * 1E-06f;
				float num11 = Mathf.Epsilon * 8f;
				bool flag17 = num10 < num11;
				bool flag18 = num10 == num11;
				bool flag19 = num10 == num10;
				bool flag20 = num11 == num11;
				bool flag21 = flag19 && flag20;
				bool flag22 = !flag21;
				bool flag23 = flag17 == flag22;
				bool flag24 = !flag18;
				float num12 = ((!(flag23 && flag24)) ? num11 : num10);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
				Vector3 scale6 = shapeModule.scale;
				if (!(num8 < num12))
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3F1F834 (inside Coffee.UIParticleInternal.Vector3Extensions::Inverse +0xE8)");
					object obj = default(object);
					if (obj == null)
					{
						return;
					}
					Vector3 scale7 = shapeModule.scale;
				}
			}
			Vector3 scale8 = shapeModule.scale;
			Vector3 scale9 = shapeModule.scale;
		}

		[Token(Token = "0x600007D")]
		[Address(RVA = "0x3F2194C", Offset = "0x3F2194C", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tv41 = UnityEngine.ParticleSystemRenderer::get_renderMode(self);\n\tv52 = v41 != 4;\n\tif (v52) goto L_0045;\n\tv55 = UnityEngine.ParticleSystemRenderer::get_mesh(self);\n\tgoto L_002D;\nL_002D:\n\tv67 = UnityEngine.Object::op_Equality(v55, 0);\n\tv70 = v67 == 0;\n\tif (v70) goto L_0045;\n\treturn 0;\nL_0045:\n\tv77 = UnityEngine.ParticleSystemRenderer::get_renderMode(self);\n\tv106 = v77 - 5;\n\tv100 = v106 == 0;\n\tv85 = ~v100;\n\treturn v85;\n")]
		public static bool CanBakeMesh(this ParticleSystemRenderer self)
		{
			ParticleSystemRenderMode renderMode = self.renderMode;
			if (renderMode == ParticleSystemRenderMode.Mesh)
			{
				Mesh mesh = self.mesh;
				if (mesh == null)
				{
					return false;
				}
			}
			ParticleSystemRenderMode renderMode2 = self.renderMode;
			int num = (int)(renderMode2 - 5);
			bool flag = num == 0;
			return !flag;
		}

		[Token(Token = "0x600007E")]
		[Address(RVA = "0x3F21A18", Offset = "0x3F21A18", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tv43 = UnityEngine.ParticleSystem::get_main(v36);\n\tv45 = v43;\n\treturnVal2 = UnityEngine.ParticleSystem+MainModule::get_simulationSpace(&v45 @ stack_-28_v1 (UnityEngine.ParticleSystem+MainModule));\n\tv58 = returnVal2 != 2;\n\tif (v58) goto L_004D;\n\tv112 = UnityEngine.ParticleSystem+MainModule::get_customSimulationSpace(&v45 @ stack_-28_v1 (UnityEngine.ParticleSystem+MainModule));\n\tgoto L_0036;\nL_FFFFFFFF:\n\treturnVal2 = 2;\n\tgoto L_004D;\nL_FFFFFFFF:\n\treturnVal2 = 0;\nL_004D:\n\treturn returnVal2;\nL_0036:\n\tv140 = UnityEngine.Object::op_Implicit(v112);\n\tv120 = v140 == 0;\n\tv115 = ~v120;\n\tv113 = ~v115;\n\tif (v113) goto L_FFFFFFFF;\n")]
		public static ParticleSystemSimulationSpace GetActualSimulationSpace(this ParticleSystem self)
		{
			ParticleSystem particleSystem = default(ParticleSystem);
			ParticleSystem.MainModule main = particleSystem.main;
			ParticleSystem.MainModule mainModule = main;
			ParticleSystemSimulationSpace particleSystemSimulationSpace = mainModule.simulationSpace;
			if (particleSystemSimulationSpace == ParticleSystemSimulationSpace.Custom)
			{
				Transform customSimulationSpace = mainModule.customSimulationSpace;
				particleSystemSimulationSpace = ((!customSimulationSpace) ? default(ParticleSystemSimulationSpace) : ParticleSystemSimulationSpace.Custom);
			}
			return particleSystemSimulationSpace;
		}

		[Token(Token = "0x600007F")]
		[Address(RVA = "0x3F21AD0", Offset = "0x3F21AD0", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001D:\n\tv51 = Coffee.UIParticleInternal.ParticleSystemExtensions::GetActualSimulationSpace(self);\n\tv56 = v51 == 0;\n\treturn v56;\nL_001A:\n\tgoto L_001D;\n")]
		public static bool IsLocalSpace(this ParticleSystem self)
		{
			ParticleSystemSimulationSpace actualSimulationSpace = self.GetActualSimulationSpace();
			return actualSimulationSpace == ParticleSystemSimulationSpace.Local;
		}

		[Token(Token = "0x6000080")]
		[Address(RVA = "0x3F21B3C", Offset = "0x3F21B3C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001D:\n\tv51 = Coffee.UIParticleInternal.ParticleSystemExtensions::GetActualSimulationSpace(self);\n\tv54 = v51 - 1;\n\tv56 = v54 == 0;\n\treturn v56;\nL_001A:\n\tgoto L_001D;\n")]
		public static bool IsWorldSpace(this ParticleSystem self)
		{
			ParticleSystemSimulationSpace actualSimulationSpace = self.GetActualSimulationSpace();
			int num = (int)(actualSimulationSpace - 1);
			return num == 0;
		}

		[Token(Token = "0x6000081")]
		[Address(RVA = "0x3F21BA8", Offset = "0x3F21BA8", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv52.sortByMaterial = sortByMaterial;\n\tv52.transform = transform;\n\tv52.self = self;\n\tv80 = new System.Comparison`1<UnityEngine.ParticleSystem>();\n\tSystem.Comparison`1<UnityEngine.ParticleSystem>::.ctor(v80, v52, Il2CppMethodInfo);\n\tSystem.Collections.Generic.List`1<UnityEngine.ParticleSystem>::Sort(v52.self, v80);\n\treturn;\nL_0024:\n\tv52 = new Coffee.UIParticleInternal.ParticleSystemExtensions+<>c__DisplayClass7_0();\n\tSystem.Object::.ctor(v52);\n")]
		public static void SortForRendering(this List<ParticleSystem> self, Transform transform, bool sortByMaterial)
		{
			Comparison<ParticleSystem> comparison = delegate(ParticleSystem a, ParticleSystem b)
			{
				//IL_057b: Expected I4, but got F4
				ParticleSystemRenderer component = a.GetComponent<ParticleSystemRenderer>();
				ParticleSystemRenderer component2 = b.GetComponent<ParticleSystemRenderer>();
				Material sharedMaterial = component.sharedMaterial;
				Material material = ((!sharedMaterial) ? component.trailMaterial : component.sharedMaterial);
				Material sharedMaterial2 = component2.sharedMaterial;
				Material material2;
				if ((bool)sharedMaterial2)
				{
					Material sharedMaterial3 = component2.sharedMaterial;
					material2 = sharedMaterial3;
				}
				else
				{
					Material trailMaterial = component2.trailMaterial;
					material2 = trailMaterial;
				}
				if (!material)
				{
					bool flag = material2;
					if (!flag)
					{
						return flag ? 1 : 0;
					}
				}
				if (!material)
				{
					return -1;
				}
				if (!material2)
				{
					return 1;
				}
				if (sortByMaterial)
				{
					int instanceID = material.GetInstanceID();
					int instanceID2 = material2.GetInstanceID();
					return instanceID - instanceID2;
				}
				int renderQueue = material.renderQueue;
				int renderQueue2 = material2.renderQueue;
				if (renderQueue != renderQueue2)
				{
					int renderQueue3 = material.renderQueue;
					int renderQueue4 = material2.renderQueue;
					return renderQueue3 - renderQueue4;
				}
				int sortingLayerID = component.sortingLayerID;
				int sortingLayerID2 = component2.sortingLayerID;
				if (sortingLayerID != sortingLayerID2)
				{
					int sortingLayerID3 = component.sortingLayerID;
					int layerValueFromID = SortingLayer.GetLayerValueFromID(sortingLayerID3);
					int sortingLayerID4 = component2.sortingLayerID;
					int layerValueFromID2 = SortingLayer.GetLayerValueFromID(sortingLayerID4);
					return layerValueFromID - layerValueFromID2;
				}
				int sortingOrder = component.sortingOrder;
				int sortingOrder2 = component2.sortingOrder;
				if (sortingOrder != sortingOrder2)
				{
					int sortingOrder3 = component.sortingOrder;
					int sortingOrder4 = component2.sortingOrder;
					return sortingOrder3 - sortingOrder4;
				}
				Transform transform2 = a.transform;
				Transform transform3 = b.transform;
				Vector3 position = transform2.position;
				Vector3 vector = transform.InverseTransformPoint(position);
				float sortingFudge = component.sortingFudge;
				Vector3 position2 = transform3.position;
				float num = vector.z + sortingFudge;
				Vector3 vector2 = transform.InverseTransformPoint(position2);
				float sortingFudge2 = component2.sortingFudge;
				float num2 = vector2.z + sortingFudge2;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3F1F834 (inside Coffee.UIParticleInternal.Vector3Extensions::Inverse +0xE8)");
				object obj = default(object);
				if ((int)((nint)obj & 1) == 0)
				{
					float num3 = num2 - num;
					bool flag2 = num3 < 0f;
					bool flag3 = num3 == num3;
					bool flag4 = !flag3;
					float num4 = ((flag2 == flag4) ? 1f : (-1f));
					return (int)num4;
				}
				int index = GetIndex(self, a);
				int index2 = GetIndex(self, b);
				int num5 = index - index2;
				int num6 = num5 >> 31;
				return num6 | 1;
			};
			self.Sort(comparison);
		}

		[Token(Token = "0x6000082")]
		[Address(RVA = "0x3F21CBC", Offset = "0x3F21CBC", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tv183 = list->klass;\n\tv235 = list->klass->interface_offsets_count;\n\tv59 = *([v183 @ X8_v16 (Il2CppClass<System.Collections.Generic.IList`1<UnityEngine.ParticleSystem>>)+12E]) == 0;\nL_FFFFFFFF:\n\tv177 = System.Collections.Generic.ICollection`1<UnityEngine.ParticleSystem>;\nL_FFFFFFFF:\n\tv185 = 0;\nL_FFFFFFFF:\n\tv392 = 0;\n\tif (v59) goto L_0046;\nL_0027:\n\tv234 = *([v183 @ X8_v16 (Il2CppClass<System.Collections.Generic.IList`1<UnityEngine.ParticleSystem>>)+B0]) + 8;\n\tv234 = v234 + 0x10;\n\tv215 = v235 - 1;\n\tv195 = v235 != 1;\nL_FFFFFFFF:\n\tv392 = v185;\nL_FFFFFFFF:\n\tv235 = v215;\n\tif (v195) goto L_002D;\nL_0046:\n\tv248 = System.Collections.Generic.ICollection`1<UnityEngine.ParticleSystem>::get_Count(list);\n\tv259 = v392 < v248;\n\tif (v259) goto L_0068;\n\tgoto L_FFFFFFFF;\nL_0055:\n\tv314 = *([v234 @ X10_v15]) << 4;\n\tv315 = v183 + v314;\n\tv316 = v315 + 0x138;\n\t*([v316 @ X0_v25])(v320, list, *([v316 @ X0_v25+8]), v156, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv330 = v185 >= v320;\nL_FFFFFFFF:\n\tv392 = v185;\n\tif (v330) goto L_FFFFFFFF;\nL_0068:\n\tv349 = list->klass;\n\tv402 = list->klass->interface_offsets_count;\n\tv351 = *([v349 @ X8_v8 (Il2CppClass<System.Collections.Generic.IList`1<UnityEngine.ParticleSystem>>)+12E]) == 0;\n\tif (v351) goto L_008A;\n\tv123 = *([v349 @ X8_v8 (Il2CppClass<System.Collections.Generic.IList`1<UnityEngine.ParticleSystem>>)+B0]) + 8;\n\tv123 = v123 + 0x10;\n\tv385 = v402 - 1;\n\tv375 = v402 != 1;\nL_FFFFFFFF:\n\tv402 = v385;\n\tif (v375) goto L_0073;\nL_008A:\n\tv156 = *([v388 @ X0_v13+8]);\n\tv411 = System.Collections.Generic.IList`1<UnityEngine.ParticleSystem>::get_Item(list, v392);\n\tv405 = v411 == 0;\n\tv142 = ~v405;\n\tif (v142) goto L_009E;\n\tgoto L_00C3;\nL_0093:\n\tv69 = *([v123 @ X10_v9]) << 4;\n\tv407 = v349 + v69;\n\tv408 = v407 + 0x138;\n\tv156 = *([v408 @ X0_v16+8]);\n\t*([v408 @ X0_v16])(v411, list, v392, *([v408 @ X0_v16+8]), v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_009E:\n\tv140 = UnityEngine.Object::GetInstanceID(v411);\n\tv180 = UnityEngine.Object::GetInstanceID(ps);\n\tv167 = v140 == v180;\n\tif (v167) goto L_00C2;\n\tv185 = v392 + 1;\n\tv183 = list->klass;\n\tv235 = list->klass->interface_offsets_count;\n\tv415 = *([v183 @ X8_v16 (Il2CppClass<System.Collections.Generic.IList`1<UnityEngine.ParticleSystem>>)+12E]) == 0;\n\tv182 = ~v415;\nL_FFFFFFFF:\n\tv177 = System.Collections.Generic.ICollection`1<UnityEngine.ParticleSystem>;\n\tif (v182) goto L_0027;\nL_FFFFFFFF:\n\tv392 = v185;\n\tgoto L_0046;\nL_FFFFFFFF:\n\tv392 = 0;\nL_00C3:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_002D:\n\tv240 = *([v234 @ X10_v15-8]) == v177;\n\tif (v240) goto L_0055;\nL_0073:\n\tv103 = *([v123 @ X10_v9-8]) == System.Collections.Generic.IList`1<UnityEngine.ParticleSystem>;\n\tif (v103) goto L_0093;\nL_00C2:\n\treturn v392;\n")]
		private static int GetIndex(IList<ParticleSystem> list, UnityEngine.Object ps)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ParticleSystemExtensions::GetIndex");
			return default;
		}

		[Token(Token = "0x6000083")]
		[Address(RVA = "0x3F21E60", Offset = "0x3F21E60", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tv51 = UnityEngine.Object::op_Implicit(self);\n\tv58 = ~v51;\n\tv59 = ~v58;\n\tif (v59) goto L_002F;\n\tgoto L_00AA;\nL_002F:\n\tv165 = UnityEngine.ParticleSystem::get_textureSheetAnimation(self);\n\tv126 = v165;\n\tv137 = UnityEngine.ParticleSystem+TextureSheetAnimationModule::get_enabled(&v126 @ stack_-38_v3 (UnityEngine.ParticleSystem+TextureSheetAnimationModule));\n\tv144 = ~v137;\n\tif (v144) goto L_00AA;\n\tv138 = UnityEngine.ParticleSystem+TextureSheetAnimationModule::get_mode(&v126 @ stack_-38_v3 (UnityEngine.ParticleSystem+TextureSheetAnimationModule));\n\tv74 = v138 != 1;\n\tif (v74) goto L_00AA;\n\tv139 = UnityEngine.ParticleSystem+TextureSheetAnimationModule::get_spriteCount(&v126 @ stack_-38_v3 (UnityEngine.ParticleSystem+TextureSheetAnimationModule));\n\tv75 = v139 < 1;\n\tif (v75) goto L_00AA;\n\tv229 = 0;\nL_0061:\n\tv241 = UnityEngine.Object::op_Implicit(v233);\n\tv242 = ~v241;\n\tv145 = ~v242;\n\tif (v145) goto L_007A;\n\tv229 = v229 + 1;\n\tv140 = UnityEngine.ParticleSystem+TextureSheetAnimationModule::get_spriteCount(&v126 @ stack_-38_v3 (UnityEngine.ParticleSystem+TextureSheetAnimationModule));\n\tv76 = v229 < v140;\n\tif (v76) goto L_0057;\n\tgoto L_00AA;\nL_007A:\n\tgoto L_007E;\nL_007E:\n\tgoto L_0081;\nL_0081:\n\tv141 = UnityEngine.Object::op_Implicit(v233);\n\tv146 = ~v141;\n\tif (v146) goto L_00AA;\n\treturnVal3 = UnityEngine.Sprite::get_texture(v233);\n\treturn returnVal3;\nL_00AA:\n\treturn 0;\nL_0057:\n\tv233 = UnityEngine.ParticleSystem+TextureSheetAnimationModule::GetSprite(&v126 @ stack_-38_v3 (UnityEngine.ParticleSystem+TextureSheetAnimationModule), v229);\n\tgoto L_0061;\n")]
		public static Texture2D GetTextureForSprite(this ParticleSystem self)
		{
			if ((bool)self)
			{
				ParticleSystem.TextureSheetAnimationModule textureSheetAnimation = self.textureSheetAnimation;
				ParticleSystem.TextureSheetAnimationModule textureSheetAnimationModule = textureSheetAnimation;
				if (textureSheetAnimationModule.enabled)
				{
					ParticleSystemAnimationMode mode = textureSheetAnimationModule.mode;
					if (mode == ParticleSystemAnimationMode.Sprites)
					{
						int spriteCount = textureSheetAnimationModule.spriteCount;
						if (spriteCount >= 1)
						{
							int num = 0;
							int spriteCount2;
							do
							{
								Sprite sprite = textureSheetAnimationModule.GetSprite(num);
								if (!sprite)
								{
									num++;
									spriteCount2 = textureSheetAnimationModule.spriteCount;
									continue;
								}
								if (!sprite)
								{
									break;
								}
								return sprite.texture;
							}
							while (num < spriteCount2);
						}
					}
				}
			}
			return null;
		}

		[Token(Token = "0x6000084")]
		[Address(RVA = "0x3F2201C", Offset = "0x3F2201C", Length = "0x1F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv61 = System.Collections.Generic.List`1<UnityEngine.ParticleSystem>::GetEnumerator(v45);\n\tv66 = v61._list;\n\tv73 = v61._list;\n\tv79 = action == 0;\n\tif (v79) goto L_0060;\n\tgoto L_0050;\nL_0050:\n\tv111 = UnityEngine.Object::op_Implicit(v61.Current);\n\tv114 = v111 == 0;\n\tif (v114) goto L_0043;\n\tSystem.Action`1<UnityEngine.ParticleSystem>::Invoke(action, v61.Current);\n\tgoto L_0043;\n\tgoto L_006C;\nL_006C:\n\tv126 = UnityEngine.Object::op_Implicit(v61.Current);\n\tv128 = v126 == 0;\n\tif (v128) goto L_0060;\n\tthrow System.NullReferenceException;\nL_007E:\n\treturn;\nL_007F:\n\tv62 = new System.NullReferenceException();\n\tgoto L_0091;\nL_0091:\n\tv101 = action != 1;\n\tv146 = v62;\n\tif (v101) goto L_00A1;\n\tv137 = 0x8BF5BC4(v62, action, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv154 = 0x8BF5BF4(v137, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v176);\n\tv145 = *([v137 @ X0_v10]) == 0;\n\tif (v145) goto L_007E;\n\tv143 = new System.OutOfMemoryException();\n\tv66 = *([v137 @ X0_v10]);\n\tv146 = v143;\n\treturn;\nL_0025:\n\tv50 = v45 == 0;\n\tif (v50) goto L_007F;\nL_0074:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v73 @ stack_-60_v2 (System.Collections.Generic.List`1<UnityEngine.ParticleSystem>));\nL_0043:\n\tv122 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v73 @ stack_-60_v2 (System.Collections.Generic.List`1<UnityEngine.ParticleSystem>));\n\tv151 = v122 == 0;\n\tif (v151) goto L_0074;\nL_0060:\n\tv135 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v73 @ stack_-60_v2 (System.Collections.Generic.List`1<UnityEngine.ParticleSystem>));\n\tv152 = ~v135;\n\tif (v152) goto L_0074;\nL_00A1:\n\tv149 = 0x3191DC4(&v66 @ stack_-78_v4 (System.Collections.Generic.List`1<UnityEngine.ParticleSystem>), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv156 = 0x8BF0368(v146, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv177 = 0xA1B8(v156, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n")]
		public unsafe static void Exec(this List<ParticleSystem> self, Action<ParticleSystem> action)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ParticleSystemExtensions::Exec");
		}

		[Token(Token = "0x6000085")]
		[Address(RVA = "0x3F2220C", Offset = "0x3F2220C", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tgoto L_001B;\nL_001B:\n\tv80 = UnityEngine.Object::op_Implicit(self);\n\tv69 = list == 0;\n\tv70 = ~v69;\nL_FFFFFFFF:\n\tv133 = 0;\n\tif (v70) goto L_003B;\nL_FFFFFFFF:\n\tv133 = 0;\n\tgoto L_008F;\nL_003B:\n\tv84 = ~v80;\n\tif (v84) goto L_008F;\n\tv173 = list.Count < 1;\n\tif (v173) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv150 = 0;\n\tgoto L_0067;\nL_0052:\n\tv141 = Coffee.UIParticleInternal.ParticleSystemExtensions::IsSubEmitterOf(self, v204);\n\tv231 = v141 == 0;\n\tv144 = ~v231;\nL_FFFFFFFF:\n\tv133 = v204;\n\tif (v144) goto L_008F;\nL_0057:\n\tv150 = v150 + 1;\n\tv180 = v150 >= list.Count;\n\tif (v180) goto L_FFFFFFFF;\nL_0067:\n\tv204 = System.Collections.Generic.List`1<UnityEngine.ParticleSystem>::get_Item(list, v150);\n\tgoto L_0070;\nL_0070:\n\tv211 = UnityEngine.Object::op_Inequality(v204, self);\n\tv213 = ~v211;\n\tif (v213) goto L_0057;\n\tgoto L_007F;\nL_007F:\n\tgoto L_0052;\nL_FFFFFFFF:\n\tv133 = 0;\nL_008F:\n\treturn v133;\n")]
		public static ParticleSystem GetMainEmitter(this ParticleSystem self, List<ParticleSystem> list)
		{
			bool flag = self;
			bool flag2 = list == null;
			bool flag3 = !flag2;
			ParticleSystem result = null;
			if (!flag3)
			{
				result = null;
			}
			else if (flag)
			{
				if (list.Count < 1)
				{
					goto IL_0150;
				}
				int num = 0;
				while (true)
				{
					ParticleSystem particleSystem = list[num];
					if (particleSystem != self)
					{
						bool flag4 = self.IsSubEmitterOf(particleSystem);
						bool flag5 = !flag4;
						bool flag6 = !flag5;
						result = particleSystem;
						if (flag6)
						{
							break;
						}
					}
					num++;
					if (num < list.Count)
					{
						continue;
					}
					goto IL_0150;
				}
			}
			goto IL_015a;
			IL_0150:
			result = null;
			goto IL_015a;
			IL_015a:
			return result;
		}

		[Token(Token = "0x6000086")]
		[Address(RVA = "0x3F2238C", Offset = "0x3F2238C", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tgoto L_0019;\nL_0019:\n\treturnVal1 = UnityEngine.Object::op_Implicit(self);\n\tv63 = ~returnVal1;\n\tv64 = ~v63;\n\tif (v64) goto L_003A;\nL_0026:\n\treturn returnVal1;\nL_003A:\n\tgoto L_003D;\nL_003D:\n\treturnVal1 = UnityEngine.Object::op_Implicit(parent);\n\tv124 = ~returnVal1;\n\tif (v124) goto L_0026;\n\tgoto L_004B;\nL_004B:\n\tv203 = UnityEngine.ParticleSystem::get_subEmitters(parent);\n\tv111 = v203;\n\tv205 = UnityEngine.ParticleSystem+SubEmittersModule::get_subEmittersCount(&v111 @ stack_-48_v1 (UnityEngine.ParticleSystem+SubEmittersModule));\n\tv132 = v205 - 1;\n\tv153 = v205 < 1;\n\tif (v153) goto L_008A;\n\tv134 = 0;\n\tv130 = v134 + 1;\n\tv76 = v132 != v134;\n\tv134 = v130;\n\tif (v76) goto L_0061;\n\tgoto L_0026;\nL_008A:\n\treturn 0;\nL_006D:\n\treturnVal1 = UnityEngine.Object::op_Equality(v219, self);\n\tv228 = returnVal1 == 0;\n\tv126 = ~v228;\n\tif (v126) goto L_0026;\nL_0061:\n\tv219 = UnityEngine.ParticleSystem+SubEmittersModule::GetSubEmitterSystem(&v111 @ stack_-48_v1 (UnityEngine.ParticleSystem+SubEmittersModule), v134);\n\tgoto L_006D;\n")]
		public static bool IsSubEmitterOf(this ParticleSystem self, ParticleSystem parent)
		{
			bool flag = self;
			if (flag)
			{
				flag = parent;
				if (flag)
				{
					ParticleSystem.SubEmittersModule subEmitters = parent.subEmitters;
					ParticleSystem.SubEmittersModule subEmittersModule = subEmitters;
					int subEmittersCount = subEmittersModule.subEmittersCount;
					int num = subEmittersCount - 1;
					if (subEmittersCount < 1)
					{
						return false;
					}
					int num2 = 0;
					bool flag2;
					do
					{
						ParticleSystem subEmitterSystem = subEmittersModule.GetSubEmitterSystem(num2);
						flag = subEmitterSystem == self;
						if (flag)
						{
							break;
						}
						int num3 = num2 + 1;
						flag2 = num != num2;
						num2 = num3;
					}
					while (flag2);
				}
			}
			return flag;
		}

		[Token(Token = "0x6000087")]
		[Address(RVA = "0x3F224F8", Offset = "0x3F224F8", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\t// 28 NewArr v48 @ X0_v3 (Particle[]), typeof(Particle[]), 2048\n\tv53.s_TmpParticles = v48;\n\treturn;\n")]
		static ParticleSystemExtensions()
		{
			ParticleSystem.Particle[] array = new ParticleSystem.Particle[2048];
			s_TmpParticles = array;
		}
	}
}
