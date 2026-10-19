using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using HighlightPlus;
using PrimeTween;
using UnityEngine;

namespace _game.CoreSystem.SandSystem
{
	[Token(Token = "0x2000090")]
	public class SandCubeBondVisual : MonoBehaviour
	{
		[Token(Token = "0x4000178")]
		private static readonly int s_colorAId;

		[Token(Token = "0x4000179")]
		private static readonly int s_colorBId;

		[Token(Token = "0x400017A")]
		private static MaterialPropertyBlock s_sharedMpb;

		[SerializeField]
		[Token(Token = "0x400017B")]
		[FieldOffset(Offset = "0x20")]
		private List<Renderer> m_renderers;

		[SerializeField]
		[Token(Token = "0x400017C")]
		[FieldOffset(Offset = "0x28")]
		private List<HighlightEffect> m_highlightEffect;

		[Token(Token = "0x400017D")]
		[FieldOffset(Offset = "0x30")]
		private Transform _endpointA;

		[Token(Token = "0x400017E")]
		[FieldOffset(Offset = "0x38")]
		private Transform _endpointB;

		[Token(Token = "0x400017F")]
		[FieldOffset(Offset = "0x40")]
		private float _cellSize;

		[Token(Token = "0x4000180")]
		[FieldOffset(Offset = "0x44")]
		private float _closedZOffset;

		[Token(Token = "0x4000181")]
		[FieldOffset(Offset = "0x48")]
		private bool _open;

		[Token(Token = "0x4000182")]
		[FieldOffset(Offset = "0x49")]
		private bool _initialized;

		[Token(Token = "0x4000183")]
		[FieldOffset(Offset = "0x50")]
		private Func<bool> _openProvider;

		[Token(Token = "0x4000184")]
		[FieldOffset(Offset = "0x58")]
		private Func<Color> _colorProviderA;

		[Token(Token = "0x4000185")]
		[FieldOffset(Offset = "0x60")]
		private Func<Color> _colorProviderB;

		[Token(Token = "0x4000186")]
		[FieldOffset(Offset = "0x68")]
		private Color _currentColorA;

		[Token(Token = "0x4000187")]
		[FieldOffset(Offset = "0x78")]
		private Color _currentColorB;

		[Token(Token = "0x600027D")]
		[Address(RVA = "0x3C78F78", Offset = "0x3C78F78", Length = "0x1F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._endpointA = endpointA;\n\tthis._endpointB = endpointB;\n\tthis._cellSize = cellSize;\n\tthis._closedZOffset = closedZOffset;\n\tthis._openProvider = openProvider;\n\tthis._colorProviderA = colorProviderA;\n\tthis._colorProviderB = colorProviderB;\n\tv89 = openProvider == 0;\n\tv99 = open;\n\tif (v89) goto L_0045;\n\tv93 = System.Func`1<System.Boolean>::Invoke(openProvider);\n\tv99 = v93;\n\tv111 = System.Func`1<UnityEngine.Color>::Invoke(this._colorProviderA);\n\tv125 = System.Func`1<UnityEngine.Color>::Invoke(this._colorProviderB);\n\tv176 = this._currentColorA.a;\n\tv208 = colorA.a;\n\tv210 = colorA.b;\n\tv212 = colorA.g;\n\tv222 = colorA;\n\tv147 = colorA.a < 0;\n\tv148 = colorA.a == 0;\n\tv151 = colorA.a == colorA.a;\n\tv152 = ~v151;\n\tv153 = v147 == v152;\n\tv154 = ~v148;\n\tv155 = v153 & v154;\n\tv169 = colorA.b;\n\tv171 = colorA.g;\n\tv173 = colorA;\n\tv175 = colorA.a;\n\tif (v155) goto L_0086;\n\tv169 = 1f;\n\tv171 = 1f;\n\tv173 = 1f;\n\tv175 = 1f;\n\tv192 = v63 < 0;\n\tv193 = v63 == 0;\n\tv196 = v63 == v63;\n\tv197 = ~v196;\n\tv198 = v192 == v197;\n\tv199 = ~v193;\n\tv200 = v198 & v199;\n\tv215 = v63;\n\tv217 = v61;\n\tv219 = v59;\n\tv221 = colorB;\n\tif (v200) goto L_00A2;\n\tv215 = 1f;\n\tv217 = 1f;\n\tv219 = 1f;\n\tv221 = 1f;\n\treturn;\nL_0045:\n\tthis._open = v99;\n\tthis._initialized = 1;\n\tv107 = this._colorProviderA == 0;\n\tif (v107) goto L_0054;\nL_0068:\n\tthis._currentColorB.r = v222;\n\tthis._currentColorB.g = v212;\n\tv140 = v176 == 0;\n\tv141 = v176 < 0;\n\tv142 = ~v141;\n\tthis._currentColorB.b = v210;\n\tthis._currentColorB.a = v208;\n\tv145 = ~v140;\n\tv146 = v142 & v145;\n\tif (v146) goto L_008C;\nL_0086:\n\tthis._currentColorA.r = v173;\n\tthis._currentColorA.g = v171;\n\tthis._currentColorA.b = v169;\n\tthis._currentColorA.a = v175;\n\tv176 = v175;\nL_00A2:\n\tthis._currentColorB.r = v221;\n\tthis._currentColorB.g = v219;\n\tthis._currentColorB.b = v217;\n\tthis._currentColorB.a = v215;\n\tv208 = v215;\n\tv210 = v217;\n\tv212 = v219;\n\tv222 = v221;\nL_0054:\n\tthis._currentColorA.r = colorA;\n\tthis._currentColorA.g = colorA.g;\n\tthis._currentColorA.b = colorA.b;\n\tthis._currentColorA.a = colorA.a;\n\tv121 = this._colorProviderB == 0;\n\tv208 = v63;\n\tv210 = v61;\n\tv212 = v59;\n\tv222 = colorB;\n\tv176 = colorA.a;\n\tif (v121) goto L_0068;\nL_008C:\n\tv179 = v208 == 0;\n\tv180 = v208 < 0;\n\tv181 = ~v180;\n\tv184 = ~v179;\n\tv185 = v181 & v184;\n\tif (v185) goto L_00AE;\nL_00AE:\n\t// 174 MakeStruct v228 @ AGG3C7912C_1_v1 (UnityEngine.Color), typeof(UnityEngine.Color), this._currentColorA (UnityEngine.Color), this._currentColorA.g (System.Single), this._currentColorA.b (System.Single), v176 @ V3_v4 (System.Single)\n\t// 175 MakeStruct v229 @ AGG3C7912C_2_v1 (UnityEngine.Color), typeof(UnityEngine.Color), v222 @ V4_v4 (UnityEngine.Color), v212 @ V5_v3 (System.Single), v210 @ V6_v3 (System.Single), v208 @ V7_v3 (System.Single)\n\t_game.CoreSystem.SandSystem.SandCubeBondVisual::ApplyColors(this, v228, v229);\n\t_game.CoreSystem.SandSystem.SandCubeBondVisual::ApplyHighlight(this, this._open);\n\t_game.CoreSystem.SandSystem.SandCubeBondVisual::UpdateTransform(this);\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Initialize(Transform endpointA, Transform endpointB, float cellSize, Color colorA, Color colorB, float closedZOffset = 0f, bool open = true, Func<bool> openProvider = null, Func<Color> colorProviderA = null, Func<Color> colorProviderB = null)
		{
			_endpointA = endpointA;
			_endpointB = endpointB;
			_cellSize = cellSize;
			_closedZOffset = closedZOffset;
			_openProvider = openProvider;
			_colorProviderA = colorProviderA;
			_colorProviderB = colorProviderB;
			bool flag = openProvider == null;
			bool open2 = open;
			if (!flag)
			{
				bool flag2 = openProvider();
				open2 = flag2;
			}
			_open = open2;
			_initialized = true;
			if (_colorProviderA != null)
			{
				object obj = _colorProviderA();
			}
			_currentColorA.r = colorA.r;
			_currentColorA.g = colorA.g;
			_currentColorA.b = colorA.b;
			_currentColorA.a = colorA.a;
			bool flag3 = _colorProviderB == null;
			float num2 = default(float);
			float num = num2;
			float num3 = default(float);
			float b = num3;
			float num4 = default(float);
			float g = num4;
			Color color = colorB;
			float num5 = colorA.a;
			if (!flag3)
			{
				object obj2 = _colorProviderB();
				num5 = _currentColorA.a;
				num = colorA.a;
				b = colorA.b;
				g = colorA.g;
				color = colorA;
			}
			_currentColorB.r = color.r;
			_currentColorB.g = g;
			bool flag4 = num5 == 0f;
			bool flag5 = num5 < 0f;
			bool flag6 = !flag5;
			_currentColorB.b = b;
			_currentColorB.a = num;
			bool flag7 = !flag4;
			if (!(flag6 && flag7))
			{
				bool flag8 = colorA.a < 0f;
				bool flag9 = colorA.a == 0f;
				bool flag10 = colorA.a == colorA.a;
				bool flag11 = !flag10;
				bool flag12 = flag8 == flag11;
				bool flag13 = !flag9;
				bool flag14 = flag12 && flag13;
				float b2 = colorA.b;
				float g2 = colorA.g;
				float r = colorA.r;
				float num6 = colorA.a;
				if (!flag14)
				{
					b2 = 1f;
					g2 = 1f;
					r = 1f;
					num6 = 1f;
				}
				_currentColorA.r = r;
				_currentColorA.g = g2;
				_currentColorA.b = b2;
				_currentColorA.a = num6;
				num5 = num6;
			}
			bool flag15 = num == 0f;
			bool flag16 = num < 0f;
			bool flag17 = !flag16;
			bool flag18 = !flag15;
			if (!(flag17 && flag18))
			{
				bool flag19 = num2 < 0f;
				bool flag20 = num2 == 0f;
				bool flag21 = num2 == num2;
				bool flag22 = !flag21;
				bool flag23 = flag19 == flag22;
				bool flag24 = !flag20;
				bool flag25 = flag23 && flag24;
				float num7 = num2;
				float num8 = num3;
				float num9 = num4;
				float r2 = colorB.r;
				if (!flag25)
				{
					num7 = 1f;
					num8 = 1f;
					num9 = 1f;
					r2 = 1f;
				}
				_currentColorB.r = r2;
				_currentColorB.g = num9;
				_currentColorB.b = num8;
				_currentColorB.a = num7;
				num = num7;
				b = num8;
				g = num9;
				color.r = r2;
			}
			Color colorA2 = default(Color);
			colorA2.r = _currentColorA.r;
			colorA2.g = _currentColorA.g;
			colorA2.b = _currentColorA.b;
			colorA2.a = num5;
			Color colorB2 = default(Color);
			colorB2.r = color.r;
			colorB2.g = g;
			colorB2.b = b;
			colorB2.a = num;
			ApplyColors(colorA2, colorB2);
			ApplyHighlight(_open);
			UpdateTransform();
		}

		[Token(Token = "0x600027E")]
		[Address(RVA = "0x3C7981C", Offset = "0x3C7981C", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = this._open == open;\n\tif (v17) goto L_002D;\n\tthis._open = open;\n\t_game.CoreSystem.SandSystem.SandCubeBondVisual::ApplyHighlight(this, open);\n\tv26 = this._initialized != 1;\n\tif (v26) goto L_002D;\n\t_game.CoreSystem.SandSystem.SandCubeBondVisual::UpdateTransform(this);\n\treturn;\nL_002D:\n\treturn;\n")]
		public void SetOpen(bool open)
		{
			if (_open != open)
			{
				_open = open;
				ApplyHighlight(open);
				if (_initialized)
				{
					UpdateTransform();
				}
			}
		}

		[Token(Token = "0x600027F")]
		[Address(RVA = "0x3C793F8", Offset = "0x3C793F8", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv100 = 0;\n\tgoto L_0034;\nL_0026:\n\tv100 = v100 + 1;\n\tv94 = this.m_highlightEffect;\nL_0034:\n\tv65 = v100 >= v94.Count;\n\tif (v65) goto L_005C;\n\tv158 = System.Collections.Generic.List`1<HighlightPlus.HighlightEffect>::get_Item(v94, v100);\n\tgoto L_0041;\nL_0041:\n\tv164 = UnityEngine.Object::op_Inequality(v158, 0);\n\tv166 = ~v164;\n\tif (v166) goto L_0026;\n\tgoto L_0051;\nL_0051:\n\tHighlightPlus.HighlightEffect::SetHighlighted(v158, on);\n\tgoto L_0026;\nL_005C:\n\treturn;\nL_001D:\n\tv94 = this.m_highlightEffect;\n\tv49 = this.m_highlightEffect == 0;\n\tif (v49) goto L_005C;\n")]
		private void ApplyHighlight(bool on)
		{
			List<HighlightEffect> highlightEffect = m_highlightEffect;
			if (m_highlightEffect == null)
			{
				return;
			}
			int num = 0;
			while (num < highlightEffect.Count)
			{
				UnityEngine.Object obj = highlightEffect[num];
				if (obj != null)
				{
					((HighlightEffect)obj).SetHighlighted(on);
				}
				num++;
				highlightEffect = m_highlightEffect;
			}
		}

		[Token(Token = "0x6000280")]
		[Address(RVA = "0x3C79168", Offset = "0x3C79168", Length = "0x290")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0038;\n\tv77 = v71.Count == 0;\n\tif (v77) goto L_00E1;\n\tgoto L_0046;\nL_0046:\n\tv227 = v225.s_sharedMpb == 0;\n\tif (v227) goto L_005B;\n\tgoto L_004D;\nL_004D:\n\tv260 = v258.s_sharedMpb == 0;\n\tv261 = ~v260;\n\tif (v261) goto L_0077;\n\tgoto L_00E2;\nL_005B:\n\tv245 = new UnityEngine.MaterialPropertyBlock();\n\tUnityEngine.MaterialPropertyBlock::.ctor(v245);\n\tgoto L_0068;\nL_0077:\n\tUnityEngine.MaterialPropertyBlock::Clear(v258.s_sharedMpb);\n\tUnityEngine.MaterialPropertyBlock::SetColor(v304.s_sharedMpb, v304.s_colorAId, colorA);\n\tUnityEngine.MaterialPropertyBlock::SetColor(v305.s_sharedMpb, v305.s_colorBId, colorB);\n\tv126 = this.m_renderers;\n\tv132 = 0;\n\tgoto L_00A9;\nL_009B:\n\tv132 = v132 + 1;\n\tv126 = this.m_renderers;\nL_00A9:\n\tv82 = v132 >= v126.Count;\n\tif (v82) goto L_00E1;\n\tv337 = System.Collections.Generic.List`1<UnityEngine.Renderer>::get_Item(v126, v132);\n\tgoto L_00B6;\nL_00B6:\n\tv344 = UnityEngine.Object::op_Inequality(v337, 0);\n\tv346 = ~v344;\n\tif (v346) goto L_009B;\n\tgoto L_00C5;\nL_00C5:\n\tgoto L_00CE;\nL_00CE:\n\tUnityEngine.Renderer::SetPropertyBlock(v337, v357.s_sharedMpb);\n\tgoto L_009B;\nL_00E1:\n\treturn;\nL_00E2:\n\tthrow System.NullReferenceException;\nL_0038:\n\tv71 = this.m_renderers;\n\tv72 = this.m_renderers == 0;\n\tif (v72) goto L_00E1;\nL_0068:\n\tv316.s_sharedMpb = v245;\n\tgoto L_004D;\n")]
		private void ApplyColors(Color colorA, Color colorB)
		{
			List<Renderer> renderers = m_renderers;
			if (m_renderers == null || renderers.Count == 0)
			{
				return;
			}
			if (s_sharedMpb == null)
			{
				MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
				s_sharedMpb = materialPropertyBlock;
			}
			if (s_sharedMpb != null)
			{
				s_sharedMpb.Clear();
				s_sharedMpb.SetColor(s_colorAId, colorA);
				s_sharedMpb.SetColor(s_colorBId, colorB);
				List<Renderer> renderers2 = m_renderers;
				int num = 0;
				while (num < renderers2.Count)
				{
					UnityEngine.Object obj = renderers2[num];
					if (obj != null)
					{
						((Renderer)obj).SetPropertyBlock(s_sharedMpb);
					}
					num++;
					renderers2 = m_renderers;
				}
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000281")]
		[Address(RVA = "0x3C79868", Offset = "0x3C79868", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this._initialized != 1;\n\tif (v11) goto L_004A;\n\tv32 = this._openProvider == 0;\n\tif (v32) goto L_002D;\n\tv36 = System.Func`1<System.Boolean>::Invoke(this._openProvider);\n\tv56 = this._open == v36;\n\tif (v56) goto L_002D;\n\tthis._open = v36;\n\t_game.CoreSystem.SandSystem.SandCubeBondVisual::ApplyHighlight(this, v36);\nL_002D:\n\t;\n\tv78 = this._colorProviderA == 0;\n\tif (v78) goto L_004B;\n\tv163 = System.Func`1<UnityEngine.Color>::Invoke(this._colorProviderA);\n\tv197 = this._colorProviderB;\n\tv169 = this._colorProviderB == 0;\n\tv170 = ~v169;\n\tv229 = v46;\n\tv231 = v45;\n\tv233 = v44;\n\tv235 = v43;\n\tif (v170) goto L_0054;\n\tv259 = this._currentColorB;\n\tv258 = this._currentColorB.g;\n\tv257 = this._currentColorB.b;\n\tv256 = this._currentColorB.a;\n\tv178 = v46 == 0;\n\tv179 = v46 < 0;\n\tv180 = ~v179;\n\tv183 = ~v180;\n\tv184 = v183 | v178;\n\tif (v184) goto L_0063;\n\tv224 = this._currentColorB.a;\n\tv225 = this._currentColorB.b;\n\tv226 = this._currentColorB.g;\n\tv227 = this._currentColorB;\n\tv229 = v46;\n\tv231 = v45;\n\tv233 = v44;\n\tv235 = v43;\n\tgoto L_0068;\nL_004A:\n\treturn;\nL_004B:\n\tv197 = this._colorProviderB;\n\tv172 = this._colorProviderB == 0;\n\tif (v172) goto L_00C3;\n\tv235 = this._currentColorA;\n\tv233 = this._currentColorA.g;\n\tv231 = this._currentColorA.b;\n\tv229 = this._currentColorA.a;\nL_0063:\n\tv235 = this._currentColorA;\n\tv233 = this._currentColorA.g;\n\tv231 = this._currentColorA.b;\n\tv229 = this._currentColorA.a;\n\tv224 = v256;\n\tv225 = v257;\n\tv226 = v258;\n\tv227 = v259;\n\tv227 = this._currentColorB;\n\tv226 = this._currentColorB.g;\n\tv225 = this._currentColorB.b;\n\tv224 = this._currentColorB.a;\n\tv331 = v227 - this._currentColorB;\n\tv332 = v226 - this._currentColorB.g;\n\tv219 = v225 - this._currentColorB.b;\n\tv217 = v224 - this._currentColorB.a;\n\tv333 = v331 * v331;\n\tv334 = v332 * v332;\n\tv335 = v333 + v334;\n\tv336 = v219 * v219;\n\tv337 = v336 + v335;\n\tv338 = v217 * v217;\n\tv223 = v338 + v337;\n\tv250 = v223 < 0x2EDBE6FE;\n\tif (v250) goto L_00C3;\nL_00A9:\n\tthis._currentColorA.r = v235;\n\tthis._currentColorA.g = v233;\n\tthis._currentColorA.b = v231;\n\tthis._currentColorA.a = v229;\n\tthis._currentColorB.r = v227;\n\tthis._currentColorB.g = v226;\n\tthis._currentColorB.b = v225;\n\tthis._currentColorB.a = v224;\n\t// 182 MakeStruct v215 @ AGG3C79A04_1_v1 (UnityEngine.Color), typeof(UnityEngine.Color), v235 @ V8_v1 (UnityEngine.Color), v233 @ V9_v1 (System.Single), v231 @ V10_v1 (System.Single), v229 @ V11_v1 (System.Single)\n\t// 183 MakeStruct v214 @ AGG3C79A04_2_v1 (UnityEngine.Color), typeof(UnityEngine.Color), v227 @ V4_v2 (UnityEngine.Color), v226 @ V5_v2 (System.Single), v225 @ V6_v2 (System.Single), v224 @ V7_v2 (System.Single)\n\t_game.CoreSystem.SandSystem.SandCubeBondVisual::ApplyColors(this, v215, v214);\nL_00C3:\n\t_game.CoreSystem.SandSystem.SandCubeBondVisual::UpdateTransform(this);\n\treturn;\nL_0054:\n\t;\n\tv201 = System.Func`1<UnityEngine.Color>::Invoke(v197);\n\tv207 = v229 == 0;\n\tv208 = v229 < 0;\n\tv209 = ~v208;\n\tv212 = ~v207;\n\tv213 = v209 & v212;\n\tv256 = v46;\n\tv257 = v45;\n\tv258 = v44;\n\tv259 = v43;\n\tv224 = v46;\n\tv225 = v45;\n\tv226 = v44;\n\tv227 = v43;\n\tif (v213) goto L_0068;\nL_0068:\n\tv291 = v224 == 0;\n\tv292 = v224 < 0;\n\tv293 = ~v292;\n\tv296 = ~v291;\n\tv297 = v293 & v296;\n\tif (v297) goto L_0078;\nL_0078:\n\tv306 = v235 - this._currentColorA;\n\tv307 = v233 - this._currentColorA.g;\n\tv308 = v231 - this._currentColorA.b;\n\tv309 = v229 - this._currentColorA.a;\n\tv310 = v306 * v306;\n\tv311 = v307 * v307;\n\tv312 = v310 + v311;\n\tv313 = v308 * v308;\n\tv314 = v313 + v312;\n\tv315 = v309 * v309;\n\tv316 = v315 + v314;\n\tv319 = v316 < 0x2EDBE6FE;\n\tv242 = ~v319;\n\tif (v242) goto L_00A9;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void LateUpdate()
		{
			//IL_068d: Expected I4, but got F4
			//IL_03a9: Expected I4, but got F4
			if (!_initialized)
			{
				return;
			}
			if (_openProvider != null)
			{
				bool flag = _openProvider();
				if (_open != flag)
				{
					_open = flag;
					ApplyHighlight(flag);
				}
			}
			Func<Color> colorProviderB;
			float num;
			float num2 = default(float);
			float num3;
			float num4 = default(float);
			float num5;
			float num6 = default(float);
			Color color;
			Color color2 = default(Color);
			Color color3;
			float num7;
			float num8;
			float num9;
			float num10;
			float num11;
			float num12;
			Color color4;
			if (_colorProviderA != null)
			{
				object obj = _colorProviderA();
				colorProviderB = _colorProviderB;
				bool flag2 = _colorProviderB == null;
				bool flag3 = !flag2;
				num = num2;
				num3 = num4;
				num5 = num6;
				color = color2;
				if (!flag3)
				{
					color3 = _currentColorB;
					num7 = _currentColorB.g;
					num8 = _currentColorB.b;
					num9 = _currentColorB.a;
					bool flag4 = num2 == 0f;
					bool flag5 = num2 < 0f;
					bool flag6 = !flag5;
					bool flag7 = !flag6;
					if (flag7 || flag4)
					{
						goto IL_024c;
					}
					num10 = _currentColorB.a;
					num11 = _currentColorB.b;
					num12 = _currentColorB.g;
					color4 = _currentColorB;
					num = num2;
					num3 = num4;
					num5 = num6;
					color = color2;
					goto IL_0576;
				}
			}
			else
			{
				colorProviderB = _colorProviderB;
				if (_colorProviderB == null)
				{
					goto IL_04cd;
				}
				color = _currentColorA;
				num5 = _currentColorA.g;
				num3 = _currentColorA.b;
				num = _currentColorA.a;
			}
			object obj2 = colorProviderB();
			bool flag8 = num == 0f;
			bool flag9 = num < 0f;
			bool flag10 = !flag9;
			bool flag11 = !flag8;
			bool flag12 = flag10 && flag11;
			num9 = num2;
			num8 = num4;
			num7 = num6;
			color3 = color2;
			num10 = num2;
			num11 = num4;
			num12 = num6;
			color4 = color2;
			if (!flag12)
			{
				goto IL_024c;
			}
			goto IL_0576;
			IL_024c:
			color = _currentColorA;
			num5 = _currentColorA.g;
			num3 = _currentColorA.b;
			num = _currentColorA.a;
			num10 = num9;
			num11 = num8;
			num12 = num7;
			color4 = color3;
			goto IL_0576;
			IL_04cd:
			UpdateTransform();
			return;
			IL_0576:
			bool flag13 = num10 == 0f;
			bool flag14 = num10 < 0f;
			bool flag15 = !flag14;
			bool flag16 = !flag13;
			if (!(flag15 && flag16))
			{
				color4 = _currentColorB;
				num12 = _currentColorB.g;
				num11 = _currentColorB.b;
				num10 = _currentColorB.a;
			}
			float num13 = color.r - _currentColorA.r;
			float num14 = num5 - _currentColorA.g;
			float num15 = num3 - _currentColorA.b;
			float num16 = num - _currentColorA.a;
			float num17 = num13 * num13;
			float num18 = num14 * num14;
			float num19 = num17 + num18;
			float num20 = num15 * num15;
			float num21 = num20 + num19;
			float num22 = num16 * num16;
			int num23 = (int)(num22 + num21);
			if (num23 < 786163454)
			{
				float num24 = color4.r - _currentColorB.r;
				float num25 = num12 - _currentColorB.g;
				float num26 = num11 - _currentColorB.b;
				float num27 = num10 - _currentColorB.a;
				float num28 = num24 * num24;
				float num29 = num25 * num25;
				float num30 = num28 + num29;
				float num31 = num26 * num26;
				float num32 = num31 + num30;
				float num33 = num27 * num27;
				int num34 = (int)(num33 + num32);
				if (num34 < 786163454)
				{
					goto IL_04cd;
				}
			}
			_currentColorA.r = color.r;
			_currentColorA.g = num5;
			_currentColorA.b = num3;
			_currentColorA.a = num;
			_currentColorB.r = color4.r;
			_currentColorB.g = num12;
			_currentColorB.b = num11;
			_currentColorB.a = num10;
			Color colorA = default(Color);
			colorA.r = color.r;
			colorA.g = num5;
			colorA.b = num3;
			colorA.a = num;
			Color colorB = default(Color);
			colorB.r = color4.r;
			colorB.g = num12;
			colorB.b = num11;
			colorB.a = num10;
			ApplyColors(colorA, colorB);
			goto IL_04cd;
		}

		[Token(Token = "0x6000282")]
		[Address(RVA = "0x3C79500", Offset = "0x3C79500", Length = "0x31C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tgoto L_0022;\nL_0022:\n\tv75 = UnityEngine.Object::op_Equality(this._endpointA, 0);\n\tv84 = v75 == 0;\n\tif (v84) goto L_003F;\n\tgoto L_0046;\nL_003F:\n\tgoto L_0043;\nL_0043:\n\tv109 = UnityEngine.Object::op_Equality(this._endpointB, 0);\n\tv112 = ~v109;\n\tif (v112) goto L_0065;\nL_0046:\n\tthis._initialized = 0;\n\treturn;\nL_0065:\n\tv256 = UnityEngine.Transform::get_position(this._endpointA);\n\tv309 = UnityEngine.Transform::get_position(this._endpointB);\n\tv310 = v256.z + v309.z;\n\tv276 = v310 * 0.5f;\n\tv313 = this._open == 0;\n\tv314 = ~v313;\n\tif (v314) goto L_0081;\n\tv276 = v276 + this._closedZOffset;\n\tv318 = v256 + v309;\n\tv319 = v256.y + v309.y;\n\tv320 = v318 * 0.5f;\n\tv321 = v319 * 0.5f;\n\t// 138 MakeStruct v179 @ AGG3C79680_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v320 @ V0_v7 (System.Single), v321 @ V1_v5 (System.Single), v276 @ V14_v4 (System.Single)\n\tUnityEngine.Transform::set_position(v297, v179);\n\tv285 = v309 - v256;\n\tv287 = v309.y - v256.y;\n\tv281 = v309.z - v256.z;\n\tv324 = v285 * v285;\n\tv325 = v287 * v287;\n\tv326 = v324 + v325;\n\tv327 = v281 * v281;\n\tv283 = v327 + v326;\n\tv331 = v283 < 0x322BCC77;\n\tv332 = v283 == 0x322BCC77;\n\tv335 = v283 == v283;\n\tv338 = ~v335;\n\tv340 = v331 == v338;\n\tv341 = ~v340;\n\tv342 = v341 | v332;\n\tif (v342) goto L_00FB;\n\tv344 = UnityEngine.Component::get_transform(this);\n\tgoto L_00B3;\nL_00B3:\n\tgoto L_00B4;\nL_00B4:\n\tv425 = UnityEngine.Mathf::Sqrt(v283);\n\tv397 = v425 < 0x3727C5AC;\n\tv398 = v425 == 0x3727C5AC;\n\tv401 = v425 == v425;\n\tv404 = ~v401;\n\tv405 = v397 == v404;\n\tv406 = ~v405;\n\tv407 = v406 | v398;\n\tif (v407) goto L_00E8;\n\tv274 = v285 / v425;\n\tv271 = v287 / v425;\n\tv267 = v281 / v425;\n\tgoto L_00F7;\nL_00E8:\n\tgoto L_00F1;\nL_00F7:\n\t// 247 MakeStruct v345 @ AGG3C79790_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v274 @ V0_v14 (System.Single), v271 @ V1_v11 (System.Single), v267 @ V2_v7 (System.Single)\n\tUnityEngine.Transform::set_right(v344, v345);\nL_00FB:\n\tv230 = UnityEngine.Component::get_transform(this);\n\tgoto L_0111;\nL_0111:\n\tv182 = v239.one.z * this._cellSize;\n\tv185 = this._cellSize * v239.one.y;\n\tv188 = this._cellSize * v239.one;\n\t// 295 MakeStruct v136 @ AGG3C79814_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v188 @ V0_v13 (System.Single), v185 @ V1_v10 (System.Single), v182 @ V2_v6 (System.Single)\n\tUnityEngine.Transform::set_localScale(v230, v136);\n\treturn;\nL_0081:\n\tv297 = UnityEngine.Component::get_transform(this);\nL_00F1:\n\tv271 = v462.zero.y;\n\tv267 = v462.zero.z;\n\tv274 = v462.zero;\n")]
		private void UpdateTransform()
		{
			if (_endpointA == null || _endpointB == null)
			{
				_initialized = false;
				return;
			}
			Vector3 position = _endpointA.position;
			Vector3 position2 = _endpointB.position;
			float num = position.z + position2.z;
			float num2 = num * 0.5f;
			if (!_open)
			{
				num2 += _closedZOffset;
			}
			Transform transform = base.transform;
			float num3 = position.x + position2.x;
			float num4 = position.y + position2.y;
			float x = num3 * 0.5f;
			float y = num4 * 0.5f;
			Vector3 position3 = default(Vector3);
			position3.x = x;
			position3.y = y;
			position3.z = num2;
			transform.position = position3;
			float num5 = position2.x - position.x;
			float num6 = position2.y - position.y;
			float num7 = position2.z - position.z;
			float num8 = num5 * num5;
			float num9 = num6 * num6;
			float num10 = num8 + num9;
			float num11 = num7 * num7;
			float num12 = num11 + num10;
			bool flag = num12 < 1E-08f;
			bool flag2 = num12 == 1E-08f;
			bool flag3 = num12 == num12;
			bool flag4 = !flag3;
			bool flag5 = flag == flag4;
			bool flag6 = !flag5;
			if (!(flag6 || flag2))
			{
				Transform transform2 = base.transform;
				float num13 = Mathf.Sqrt(num12);
				bool flag7 = num13 < 1E-05f;
				bool flag8 = num13 == 1E-05f;
				bool flag9 = num13 == num13;
				bool flag10 = !flag9;
				bool flag11 = flag7 == flag10;
				bool flag12 = !flag11;
				float x2;
				float y2;
				float z;
				if (!(flag12 || flag8))
				{
					x2 = num5 / num13;
					y2 = num6 / num13;
					z = num7 / num13;
				}
				else
				{
					y2 = Vector3.zero.y;
					z = Vector3.zero.z;
					x2 = Vector3.zero.x;
				}
				Vector3 right = default(Vector3);
				right.x = x2;
				right.y = y2;
				right.z = z;
				transform2.right = right;
			}
			Transform transform3 = base.transform;
			float z2 = Vector3.one.z * _cellSize;
			float y3 = _cellSize * Vector3.one.y;
			float x3 = _cellSize * Vector3.one.x;
			Vector3 localScale = default(Vector3);
			localScale.x = x3;
			localScale.y = y3;
			localScale.z = z2;
			transform3.localScale = localScale;
		}

		[Token(Token = "0x6000283")]
		[Address(RVA = "0x3C79A20", Offset = "0x3C79A20", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv107 = PrimeTween.Tween::OnComplete(&v95 @ stack_-60_v1 (PrimeTween.Tween), v98, 1);\n\treturn;\nL_0020:\n\tthis._initialized = 0;\n\t_game.CoreSystem.SandSystem.SandCubeBondVisual::ApplyHighlight(this, 0);\n\tv76 = UnityEngine.Component::get_transform(this);\n\tgoto L_0044;\nL_0044:\n\t// 68 MakeStruct v93 @ AGG3C79B00_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v81.zero (UnityEngine.Vector3), v81.zero.y (System.Single), v81.zero.z (System.Single)\n\tv94 = PrimeTween.Tween::Scale(v76, v93, duration, 0xE, 1, 0, 0f, 0f, 0);\n\tv95 = v94;\n\tv94.tween = 0xE;\n\tv98 = new System.Action();\n\tSystem.Action::.ctor(v98, this, Il2CppMethodInfo);\n")]
		public void Disappear(float duration = 0.15f)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandCubeBondVisual::Disappear");
		}

		[Token(Token = "0x6000284")]
		[Address(RVA = "0x3C79B54", Offset = "0x3C79B54", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._cellSize = 1f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public SandCubeBondVisual()
		{
			_cellSize = 1f;
		}

		[Token(Token = "0x6000285")]
		[Address(RVA = "0x3C79B64", Offset = "0x3C79B64", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv50 = UnityEngine.Shader::PropertyToID(\"_ColorA\");\n\tv55.s_colorAId = v50;\n\tv58 = UnityEngine.Shader::PropertyToID(\"_ColorB\");\n\tv62.s_colorBId = v58;\n\treturn;\n")]
		static SandCubeBondVisual()
		{
			int num = Shader.PropertyToID("_ColorA");
			s_colorAId = num;
			int num2 = Shader.PropertyToID("_ColorB");
			s_colorBId = num2;
		}
	}
}
