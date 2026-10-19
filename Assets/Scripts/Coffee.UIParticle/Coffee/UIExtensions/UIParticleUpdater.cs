using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Coffee.UIParticleInternal;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIExtensions
{
	[Token(Token = "0x200002B")]
	internal static class UIParticleUpdater
	{
		[Token(Token = "0x400008A")]
		private static readonly List<UIParticle> s_ActiveParticles;

		[Token(Token = "0x400008B")]
		private static readonly List<UIParticleAttractor> s_ActiveAttractors;

		[Token(Token = "0x400008C")]
		private static readonly HashSet<int> s_UpdatedGroupIds;

		[Token(Token = "0x400008D")]
		private static int s_FrameCount;

		[Token(Token = "0x17000029")]
		public static int uiParticleCount
		{
			[Token(Token = "0x6000113")]
			[Address(RVA = "0x3F2B020", Offset = "0x3F2B020", Length = "0x8C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0012;\nL_0012:\n\tv57 = v43.s_ActiveParticles;\n\treturn v57.Count;\n")]
			get
			{
				List<UIParticle> list = s_ActiveParticles;
				return list.Count;
			}
		}

		[Token(Token = "0x6000114")]
		[Address(RVA = "0x3F2325C", Offset = "0x3F2325C", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tv51 = UnityEngine.Object::op_Implicit(particle);\n\tv59 = ~v51;\n\tif (v59) goto L_0069;\n\tgoto L_0023;\n\tgoto L_0075;\nL_0069:\n\treturn;\nL_0075:\n\tSystem.Collections.Generic.List`1<Coffee.UIExtensions.UIParticle>::Add(v94, particle);\n\treturn;\nL_0023:\n\tv94 = v93.s_ActiveParticles;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Register(UIParticle particle)
		{
			if ((bool)particle)
			{
				List<UIParticle> list = s_ActiveParticles;
				list.Add(particle);
			}
		}

		[Token(Token = "0x6000115")]
		[Address(RVA = "0x3F23914", Offset = "0x3F23914", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tv51 = UnityEngine.Object::op_Implicit(particle);\n\tv59 = ~v51;\n\tif (v59) goto L_0051;\n\tgoto L_0031;\nL_0031:\n\tv105 = System.Collections.Generic.List`1<Coffee.UIExtensions.UIParticle>::Remove(v93.s_ActiveParticles, particle);\n\treturn;\nL_0051:\n\treturn;\n")]
		public static void Unregister(UIParticle particle)
		{
			if ((bool)particle)
			{
				bool flag = s_ActiveParticles.Remove(particle);
			}
		}

		[Token(Token = "0x6000116")]
		[Address(RVA = "0x3F27868", Offset = "0x3F27868", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tv51 = UnityEngine.Object::op_Implicit(attractor);\n\tv59 = ~v51;\n\tif (v59) goto L_0069;\n\tgoto L_0023;\n\tgoto L_0075;\nL_0069:\n\treturn;\nL_0075:\n\tSystem.Collections.Generic.List`1<Coffee.UIExtensions.UIParticleAttractor>::Add(v94, attractor);\n\treturn;\nL_0023:\n\tv94 = v93.s_ActiveAttractors;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Register(UIParticleAttractor attractor)
		{
			if ((bool)attractor)
			{
				List<UIParticleAttractor> list = s_ActiveAttractors;
				list.Add(attractor);
			}
		}

		[Token(Token = "0x6000117")]
		[Address(RVA = "0x3F27A28", Offset = "0x3F27A28", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tv51 = UnityEngine.Object::op_Implicit(attractor);\n\tv59 = ~v51;\n\tif (v59) goto L_0051;\n\tgoto L_0031;\nL_0031:\n\tv105 = System.Collections.Generic.List`1<Coffee.UIExtensions.UIParticleAttractor>::Remove(v93.s_ActiveAttractors, attractor);\n\treturn;\nL_0051:\n\treturn;\n")]
		public static void Unregister(UIParticleAttractor attractor)
		{
			if ((bool)attractor)
			{
				bool flag = s_ActiveAttractors.Remove(attractor);
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		[Token(Token = "0x6000118")]
		[Address(RVA = "0x3F2B0AC", Offset = "0x3F2B0AC", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_002E:\n\tgoto L_0032;\nL_0032:\n\tgoto L_0042;\nL_0042:\n\tCoffee.UIParticleInternal.FastActionBase`1<System.Action>::Add(v93.s_AfterCanvasRebuildAction, v49);\n\treturn;\nL_0020:\n\tv49 = new System.Action();\n\tSystem.Action::.ctor(v49, 0, Il2CppMethodInfo);\n\tgoto L_002E;\n")]
		private static void InitializeOnLoad()
		{
			Action rhs = Refresh;
			UIExtraCallbacks.s_AfterCanvasRebuildAction.Add(rhs);
		}

		[Token(Token = "0x6000119")]
		[Address(RVA = "0x3F2B1CC", Offset = "0x3F2B1CC", Length = "0x454")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tgoto L_001A;\nL_001A:\n\tv58 = UnityEngine.Time::get_frameCount();\n\tv70 = v55.s_FrameCount == v58;\n\tif (v70) goto L_0061;\n\tgoto L_0063;\nL_0061:\n\treturn;\nL_0063:\n\tv170 = UnityEngine.Time::get_frameCount();\n\tgoto L_0074;\nL_0076:\n\tv274 = v274 + 1;\n\tv300 = v274 >= v397.Count;\n\tif (v300) goto L_FFFFFFFF;\n\tgoto L_009B;\nL_009B:\n\tv400 = System.Collections.Generic.List`1<Coffee.UIExtensions.UIParticle>::get_Item(v397, v274);\n\tgoto L_00A3;\nL_00A3:\n\tv424 = UnityEngine.Object::op_Implicit(v400);\n\tv427 = ~v424;\n\tif (v427) goto L_0076;\n\tgoto L_00B1;\nL_00B1:\n\tv473 = UnityEngine.UI.Graphic::get_canvas(v400);\n\tgoto L_00B7;\nL_00B7:\n\tv441 = UnityEngine.Object::op_Implicit(v473);\n\tv447 = ~v441;\n\tif (v447) goto L_0076;\n\tgoto L_00C4;\nL_00C4:\n\tv452 = *([v400 @ X0_v59 (UnityEngine.Object)+F8]) & -2;\n\tv326 = v452 != 2;\n\tif (v326) goto L_0076;\n\tgoto L_00DD;\nL_00DD:\n\tv444 = System.Collections.Generic.HashSet`1<System.Int32>::Add(v388.s_UpdatedGroupIds, *([v400 @ X0_v59 (UnityEngine.Object)+130]));\n\tv450 = ~v444;\n\tif (v450) goto L_0076;\n\tCoffee.UIExtensions.UIParticle::UpdateTransformScale(v400);\n\tCoffee.UIExtensions.UIParticle::UpdateRenderers(v400);\n\tgoto L_0076;\nL_FFFFFFFF:\n\tv391 = 0;\n\tgoto L_00EE;\nL_00E8:\n\tCoffee.UIExtensions.UIParticle::UpdateRenderers(v458);\nL_00E9:\n\tv391 = v391 + 1;\n\tv325 = v391 >= v455.Count;\n\tif (v325) goto L_014F;\n\tgoto L_010E;\nL_010E:\n\tv458 = System.Collections.Generic.List`1<Coffee.UIExtensions.UIParticle>::get_Item(v455, v391);\n\tgoto L_0116;\nL_0116:\n\tv476 = UnityEngine.Object::op_Implicit(v458);\n\tv485 = ~v476;\n\tif (v485) goto L_00E9;\n\tgoto L_0124;\nL_0124:\n\tv542 = UnityEngine.UI.Graphic::get_canvas(v458);\n\tgoto L_012A;\nL_012A:\n\tv525 = UnityEngine.Object::op_Implicit(v542);\n\tv530 = ~v525;\n\tif (v530) goto L_00E9;\nL_FFFFFFFF:\n\t;\n\tgoto L_0137;\nL_0137:\n\tCoffee.UIExtensions.UIParticle::UpdateTransformScale(v458);\n\tv567 = *([v458 @ X0_v27 (UnityEngine.Object)+F8]) == 0;\n\tif (v567) goto L_00E8;\n\tgoto L_0146;\nL_0146:\n\t;\n\tv527 = System.Collections.Generic.HashSet`1<System.Int32>::Add(v389.s_UpdatedGroupIds, *([v458 @ X0_v27 (UnityEngine.Object)+130]));\n\tv576 = ~v527;\n\tv532 = ~v576;\n\tif (v532) goto L_00E8;\n\tgoto L_00E9;\nL_014F:\n\tgoto L_0159;\nL_0159:\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::Clear(v318.s_UpdatedGroupIds);\nL_FFFFFFFF:\n\tv141 = 0;\n\tgoto L_0165;\n\tv109 = v141 >= v387.Count;\n\tif (v109) goto L_0061;\n\tgoto L_0181;\nL_0181:\n\tv367 = System.Collections.Generic.List`1<Coffee.UIExtensions.UIParticleAttractor>::get_Item(v387, v141);\n\tCoffee.UIExtensions.UIParticleAttractor::Attract(v367);\n\tv141 = v141 + 1;\n\tgoto L_0165;\nL_0074:\n\tv236.s_FrameCount = v170;\nL_FFFFFFFF:\n\tv274 = 0;\n\tgoto L_007B;\nL_007F:\n\tv397 = v285.s_ActiveParticles;\nL_00EE:\n\tgoto L_00F2;\nL_0165:\n\tv387 = v513.s_ActiveAttractors;\nL_007B:\n\tgoto L_007F;\nL_00F2:\n\tv455 = v314.s_ActiveParticles;\n")]
		private static void Refresh()
		{
			int frameCount = Time.frameCount;
			if (s_FrameCount == frameCount)
			{
				return;
			}
			int frameCount2 = Time.frameCount;
			s_FrameCount = frameCount2;
			int num = 0;
			while (true)
			{
				List<UIParticle> list = s_ActiveParticles;
				if (num >= list.Count)
				{
					break;
				}
				UnityEngine.Object obj = list[num];
				if ((bool)obj)
				{
					Canvas canvas = ((Graphic)obj).canvas;
					if ((bool)canvas)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ X0_v59 (UnityEngine.Object)+F8]");
						int num2 = (int)((nint)0 & (nint)(-2));
						if (num2 == 2)
						{
							HashSet<int> hashSet = s_UpdatedGroupIds;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ X0_v59 (UnityEngine.Object)+130]");
							if (hashSet.Add(0))
							{
								((UIParticle)obj).UpdateTransformScale();
								((UIParticle)obj).UpdateRenderers();
							}
						}
					}
				}
				num++;
			}
			int num3 = 0;
			while (true)
			{
				List<UIParticle> list2 = s_ActiveParticles;
				if (num3 >= list2.Count)
				{
					break;
				}
				UnityEngine.Object obj2 = list2[num3];
				if ((bool)obj2)
				{
					Canvas canvas2 = ((Graphic)obj2).canvas;
					if ((bool)canvas2)
					{
						((UIParticle)obj2).UpdateTransformScale();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ X0_v27 (UnityEngine.Object)+F8]");
						if ((nint)0 != 0)
						{
							HashSet<int> hashSet2 = s_UpdatedGroupIds;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ X0_v27 (UnityEngine.Object)+130]");
							if (!hashSet2.Add(0))
							{
								goto IL_01a4;
							}
						}
						((UIParticle)obj2).UpdateRenderers();
					}
				}
				goto IL_01a4;
				IL_01a4:
				num3++;
			}
			s_UpdatedGroupIds.Clear();
			int num4 = 0;
			while (true)
			{
				List<UIParticleAttractor> list3 = s_ActiveAttractors;
				if (num4 >= list3.Count)
				{
					break;
				}
				UIParticleAttractor uIParticleAttractor = list3[num4];
				uIParticleAttractor.Attract();
				num4++;
			}
		}

		[Token(Token = "0x600011A")]
		[Address(RVA = "0x3F2A9A8", Offset = "0x3F2A9A8", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\nL_002A:\n\t;\n\tSystem.Collections.Generic.List`1<Coffee.UIExtensions.UIParticleRenderer>::Clear(results);\n\tv70 = results.Count < 1;\n\tif (v70) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv161 = 0;\n\tgoto L_004F;\nL_0049:\n\tSystem.Collections.Generic.List`1<Coffee.UIExtensions.UIParticleRenderer>::Add(results, v149);\nL_004A:\n\tv161 = v161 + 1;\n\tv99 = v161 >= v158.Count;\n\tif (v99) goto L_00AA;\n\tgoto L_006F;\nL_006F:\n\tv148 = System.Collections.Generic.List`1<Coffee.UIExtensions.UIParticle>::get_Item(v158, v161);\n\tv258 = v148.meshSharing == 0;\n\tif (v258) goto L_004A;\n\tv100 = v148.groupId != groupId;\n\tif (v100) goto L_004A;\n\tv149 = Coffee.UIExtensions.UIParticle::GetRenderer(v148, index);\n\tgoto L_0049;\nL_00AA:\n\treturn;\nL_004F:\n\tgoto L_0053;\nL_0053:\n\tv158 = v248.s_ActiveParticles;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void GetGroupedRenderers(int groupId, int index, List<UIParticleRenderer> results)
		{
			results.Clear();
			if (results.Count >= 1)
			{
			}
			int num = 0;
			while (true)
			{
				List<UIParticle> list = s_ActiveParticles;
				if (num < list.Count)
				{
					UIParticle uIParticle = list[num];
					if (uIParticle.meshSharing != UIParticle.MeshSharing.None && uIParticle.groupId == groupId)
					{
						UIParticleRenderer renderer = uIParticle.GetRenderer(index);
						results.Add(renderer);
					}
					num++;
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x600011B")]
		[Address(RVA = "0x3F2B620", Offset = "0x3F2B620", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_002A:\n\tv101 = v101 + 1;\n\tv136 = v101 >= v159.Count;\nL_FFFFFFFF:\n\tv190 = v265;\n\tif (v136) goto L_00A0;\n\tgoto L_004F;\nL_004F:\n\tv153 = System.Collections.Generic.List`1<Coffee.UIExtensions.UIParticle>::get_Item(v159, v101);\n\tv187 = v153.meshSharing == 0;\n\tif (v187) goto L_002A;\n\tv166 = v153.groupId != groupId;\n\tif (v166) goto L_002A;\n\tv189 = v153.meshSharing & -2;\n\tv176 = v189 == 2;\n\tif (v176) goto L_FFFFFFFF;\n\tgoto L_0073;\nL_0073:\n\tv257 = UnityEngine.Object::op_Implicit(v265);\n\tv272 = v257 == 0;\n\tv260 = ~v272;\n\tif (v260) goto L_002A;\n\tgoto L_0082;\nL_0082:\n\tv276 = v153.meshSharing < 4;\n\tv256 = ~v276;\n\tv248 = ~v256;\n\tv243 = ~v248;\n\tif (v243) goto L_0092;\nL_FFFFFFFF:\n\tv265 = v153;\n\tgoto L_0092;\nL_FFFFFFFF:\n\tv190 = v153;\nL_FFFFFFFF:\n\tv101 = 0;\nL_FFFFFFFF:\n\tv265 = 0;\n\tgoto L_002F;\nL_0033:\n\tv159 = v121.s_ActiveParticles;\nL_00A0:\n\treturn v190;\nL_0092:\n\tgoto L_002A;\nL_002F:\n\tgoto L_0033;\n")]
		internal static UIParticle GetPrimary(int groupId)
		{
			int num = 0;
			UnityEngine.Object obj = null;
			UIParticle result;
			while (true)
			{
				List<UIParticle> list = s_ActiveParticles;
				bool flag = num >= list.Count;
				result = (UIParticle)obj;
				if (flag)
				{
					break;
				}
				UIParticle uIParticle = list[num];
				if (uIParticle.meshSharing != UIParticle.MeshSharing.None && uIParticle.groupId == groupId)
				{
					int num2 = (int)(uIParticle.meshSharing & (UIParticle.MeshSharing)(-2));
					if (num2 == 2)
					{
						result = uIParticle;
						break;
					}
					if (!obj && (uint)uIParticle.meshSharing < 4u)
					{
						obj = uIParticle;
					}
				}
				num++;
			}
			return result;
		}

		[Token(Token = "0x600011C")]
		[Address(RVA = "0x3F2B790", Offset = "0x3F2B790", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0038;\n\tv82 = new System.Collections.Generic.List`1<Coffee.UIExtensions.UIParticleAttractor>();\n\tSystem.Collections.Generic.List`1<Coffee.UIExtensions.UIParticleAttractor>::.ctor(v82);\n\tv92.s_ActiveAttractors = v82;\n\tv99 = new System.Collections.Generic.HashSet`1<System.Int32>();\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::.ctor(v99);\n\tv103.s_UpdatedGroupIds = v99;\n\treturn;\nL_0038:\n\tv65 = new System.Collections.Generic.List`1<Coffee.UIExtensions.UIParticle>();\n\tSystem.Collections.Generic.List`1<Coffee.UIExtensions.UIParticle>::.ctor(v65);\n\tv75.s_ActiveParticles = v65;\n")]
		static UIParticleUpdater()
		{
			List<UIParticle> list = new List<UIParticle>();
			s_ActiveParticles = list;
			List<UIParticleAttractor> list2 = new List<UIParticleAttractor>();
			s_ActiveAttractors = list2;
			HashSet<int> hashSet = new HashSet<int>();
			s_UpdatedGroupIds = hashSet;
		}
	}
}
