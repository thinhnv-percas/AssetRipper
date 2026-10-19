using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace _game.Scripts.TutorialSystem
{
	[ExecuteInEditMode]
	[AddComponentMenu("UI/Unmask/Unmask", 1)]
	[Token(Token = "0x200000B")]
	public class UnMask : MonoBehaviour, IMaterialModifier
	{
		[Token(Token = "0x4000015")]
		private static readonly Vector2 s_Center;

		[Tooltip("Fit graphic's transform to target transform.")]
		[SerializeField]
		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x20")]
		private RectTransform m_FitTarget;

		[Tooltip("Fit graphic's transform to target transform on LateUpdate every frame.")]
		[SerializeField]
		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x28")]
		private bool m_FitOnLateUpdate;

		[Tooltip("Unmask affects only for children.")]
		[SerializeField]
		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x29")]
		private bool m_OnlyForChildren;

		[Tooltip("Show the graphic that is associated with the unmask render area.")]
		[SerializeField]
		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x2A")]
		private bool m_ShowUnmaskGraphic;

		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x30")]
		private Material _unmaskMaterial;

		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x38")]
		private Material _revertUnmaskMaterial;

		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x40")]
		private Graphic _graphic;

		[Token(Token = "0x17000003")]
		public Graphic graphic
		{
			[Token(Token = "0x6000022")]
			[Address(RVA = "0x81DEB40", Offset = "0x81DEB40", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = 0xB79A000;\n\tv18 = *([B79A178]) & 1;\n\tv19 = v18 == 0;\n\tif (v19) goto L_001F;\n\treturnVal1 = this._graphic;\n\tv23 = this._graphic == 0;\n\tif (v23) goto L_002A;\nL_001A:\n\treturn returnVal1;\nL_001F:\n\t*([v16 @ X20_v1+178]) = 1;\n\treturnVal1 = this._graphic;\n\tv66 = this._graphic == 0;\n\tv45 = ~v66;\n\tif (v45) goto L_001A;\nL_002A:\n\tv64 = UnityEngine.Component::GetComponent(this);\n\tthis._graphic = v64;\n\treturn v64;\n")]
			get
			{
				//IL_0009: Expected O, but got I4
				object obj = 192520192;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B79A178]");
				Graphic result;
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					result = _graphic;
					if ((object)_graphic != null)
					{
						goto IL_0061;
					}
				}
				else
				{
					_ = 1;
					result = _graphic;
					if ((object)_graphic != null)
					{
						goto IL_0061;
					}
				}
				return _graphic = GetComponent<Graphic>();
				IL_0061:
				return result;
			}
		}

		[Token(Token = "0x17000004")]
		public RectTransform fitTarget
		{
			[Token(Token = "0x6000023")]
			[Address(RVA = "0x81DEBD8", Offset = "0x81DEBD8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.fitTarget;\n")]
			get
			{
				return m_FitTarget;
			}
			[Token(Token = "0x6000024")]
			[Address(RVA = "0x81DEBE0", Offset = "0x81DEBE0", Length = "0x34")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.fitTarget = value;\n\t_game.Scripts.TutorialSystem.UnMask::FitTo(this, this.fitTarget);\n\treturn;\n")]
			set
			{
				m_FitTarget = value;
				FitTo(fitTarget);
			}
		}

		[Token(Token = "0x17000005")]
		public bool fitOnLateUpdate
		{
			[Token(Token = "0x6000025")]
			[Address(RVA = "0x81DEDE8", Offset = "0x81DEDE8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.fitOnLateUpdate;\n")]
			get
			{
				return m_FitOnLateUpdate;
			}
			[Token(Token = "0x6000026")]
			[Address(RVA = "0x81DEDF0", Offset = "0x81DEDF0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.fitOnLateUpdate = value;\n\treturn;\n")]
			set
			{
				m_FitOnLateUpdate = value;
			}
		}

		[Token(Token = "0x17000006")]
		public bool showUnmaskGraphic
		{
			[Token(Token = "0x6000027")]
			[Address(RVA = "0x81DEDF8", Offset = "0x81DEDF8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.showUnmaskGraphic;\n")]
			get
			{
				return m_ShowUnmaskGraphic;
			}
			[Token(Token = "0x6000028")]
			[Address(RVA = "0x81DEE00", Offset = "0x81DEE00", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.showUnmaskGraphic = value;\n\t_game.Scripts.TutorialSystem.UnMask::SetDirty(this);\n\treturn;\n")]
			set
			{
				m_ShowUnmaskGraphic = value;
				SetDirty();
			}
		}

		[Token(Token = "0x17000007")]
		public bool onlyForChildren
		{
			[Token(Token = "0x6000029")]
			[Address(RVA = "0x81DEF84", Offset = "0x81DEF84", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.onlyForChildren;\n")]
			get
			{
				return m_OnlyForChildren;
			}
			[Token(Token = "0x600002A")]
			[Address(RVA = "0x81DEF8C", Offset = "0x81DEF8C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.onlyForChildren = value;\n\t_game.Scripts.TutorialSystem.UnMask::SetDirty(this);\n\treturn;\n")]
			set
			{
				m_OnlyForChildren = value;
				SetDirty();
			}
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x81DEF94", Offset = "0x81DEF94", Length = "0x250")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv55 = UnityEngine.Component::get_transform(this);\n\tv130 = UnityEngine.UI.MaskUtilities::FindRootSortOverrideCanvas(v55);\n\tv185 = UnityEngine.Component::get_transform(this);\n\tv188 = UnityEngine.UI.MaskUtilities::GetStencilDepth(v185, v130);\n\tv189 = v188 & 0x1F;\n\tgoto L_0036;\nL_0036:\n\tUnityEngine.UI.StencilMaterial::Remove(this._unmaskMaterial);\n\tv201 = -1 << v189;\n\tv206 = this.showUnmaskGraphic == 0;\n\tv212 = ~v206;\n\tv67 = ~v212;\n\tif (v67) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv215 = 0xF;\n\tgoto L_004F;\nL_FFFFFFFF:\n\tv215 = 0;\nL_0051:\n\tv222 = ~v201;\n\tv224 = ~v201;\n\tv232 = UnityEngine.UI.StencilMaterial::Add(baseMaterial, v222, 5, 3, v215, v224, 0xFF);\n\tthis._unmaskMaterial = v232;\n\tgoto L_006D;\n\tv261 = UnityEngine.Component::GetComponent(this);\n\tthis._graphic = v261;\nL_007F:\n\tv267 = UnityEngine.UI.Graphic::get_canvasRenderer(v261);\n\tv70 = this.onlyForChildren != 1;\n\tif (v70) goto L_00BA;\n\tgoto L_0097;\nL_0097:\n\tUnityEngine.UI.StencilMaterial::Remove(this._revertUnmaskMaterial);\n\tv298 = UnityEngine.UI.StencilMaterial::Add(baseMaterial, 0x80, 5, 3, 0, 0x80, 0xFF);\n\tthis._revertUnmaskMaterial = v298;\n\tUnityEngine.CanvasRenderer::set_hasPopInstruction(v267, 1);\n\tUnityEngine.CanvasRenderer::set_popMaterialCount(v267, 1);\n\tUnityEngine.CanvasRenderer::SetPopMaterial(v267, this._revertUnmaskMaterial, 0);\n\tgoto L_00BF;\nL_00BA:\n\tUnityEngine.CanvasRenderer::set_hasPopInstruction(v267, 0);\n\tUnityEngine.CanvasRenderer::set_popMaterialCount(v267, 0);\nL_00BF:\n\tv118 = this._unmaskMaterial;\nL_0019:\n\tv49 = UnityEngine.Behaviour::get_isActiveAndEnabled(this);\n\tv50 = ~v49;\nL_FFFFFFFF:\n\tv118 = baseMaterial;\n\tif (v50) goto L_00CA;\nL_00CA:\n\treturn v118;\nL_004F:\n\tgoto L_0051;\nL_006D:\n\tv261 = this._graphic;\n\tv250 = this._graphic == 0;\n\tv251 = ~v250;\n\tif (v251) goto L_007F;\n")]
		public Material GetModifiedMaterial(Material baseMaterial)
		{
			bool flag = base.isActiveAndEnabled;
			bool flag2 = !flag;
			Material result = baseMaterial;
			if (!flag2)
			{
				Transform start = base.transform;
				Transform stopAfter = MaskUtilities.FindRootSortOverrideCanvas(start);
				Transform transform = base.transform;
				int stencilDepth = MaskUtilities.GetStencilDepth(transform, stopAfter);
				int num = stencilDepth & 0x1F;
				StencilMaterial.Remove(_unmaskMaterial);
				int num2 = -1 << num;
				ColorWriteMask colorWriteMask = ((!showUnmaskGraphic) ? default(ColorWriteMask) : ColorWriteMask.All);
				int stencilID = ~num2;
				int readMask = ~num2;
				Material unmaskMaterial = StencilMaterial.Add(baseMaterial, stencilID, StencilOp.Invert, CompareFunction.Equal, colorWriteMask, readMask, 255);
				_unmaskMaterial = unmaskMaterial;
				Graphic graphic = _graphic;
				if ((object)_graphic == null)
				{
					graphic = (_graphic = GetComponent<Graphic>());
				}
				CanvasRenderer canvasRenderer = graphic.canvasRenderer;
				if (onlyForChildren)
				{
					StencilMaterial.Remove(_revertUnmaskMaterial);
					Material revertUnmaskMaterial = StencilMaterial.Add(baseMaterial, 128, StencilOp.Invert, CompareFunction.Equal, default(ColorWriteMask), 128, 255);
					_revertUnmaskMaterial = revertUnmaskMaterial;
					canvasRenderer.hasPopInstruction = true;
					canvasRenderer.popMaterialCount = 1;
					canvasRenderer.SetPopMaterial(_revertUnmaskMaterial, 0);
				}
				else
				{
					canvasRenderer.hasPopInstruction = false;
					canvasRenderer.popMaterialCount = 0;
				}
				result = _unmaskMaterial;
			}
			return result;
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0x81DEC14", Offset = "0x81DEC14", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv73 = *([v55 @ X0_v2 (UnityEngine.Transform)]) != UnityEngine.RectTransform;\n\tif (v73) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv143 = v55;\n\tgoto L_0039;\nL_FFFFFFFF:\n\tv143 = 0;\nL_0039:\n\tv109 = UnityEngine.RectTransform::get_pivot(target);\n\tUnityEngine.RectTransform::set_pivot(v143, v109);\n\tv248 = UnityEngine.Transform::get_position(target);\n\tv256 = UnityEngine.Transform::get_rotation(target);\n\tUnityEngine.Transform::SetPositionAndRotation(v143, v248, v256);\n\tv110 = UnityEngine.Transform::get_lossyScale(target);\n\tv136 = UnityEngine.Transform::get_parent(v143);\n\tv274 = UnityEngine.Transform::get_lossyScale(v136);\n\tv277 = v110 / v274;\n\tv278 = v110.y / v274.y;\n\tv279 = v110.z / v274.z;\n\t// 119 MakeStruct v195 @ AGG81DED54_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v277 @ V0_v10 (System.Single), v278 @ V1_v10 (System.Single), v279 @ V2_v8 (System.Single)\n\tUnityEngine.Transform::set_localScale(v143, v195);\n\tv284 = UnityEngine.RectTransform::get_rect(target);\n\t// 131 MakeStruct v192 @ AGG81DED74_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v284.width (System.Single), v284.height (System.Single)\n\tUnityEngine.RectTransform::set_sizeDelta(v143, v192);\n\tgoto L_0093;\nL_00A7:\n\tv74 = target == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_00AD;\n\tthrow System.NullReferenceException;\nL_00AD:\n\tv176 = UnityEngine.RectTransform::get_pivot(target);\n\tthrow System.NullReferenceException;\nL_001F:\n\tv55 = UnityEngine.Component::get_transform(this);\n\tv59 = v55 == 0;\n\tif (v59) goto L_00A7;\nL_0093:\n\t// 147 MakeStruct v180 @ AGG81DEDA4_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v237.s_Center (UnityEngine.Vector2), v237.s_Center.y (System.Single)\n\tUnityEngine.RectTransform::set_anchorMin(v143, v180);\n\t// 164 MakeStruct v183 @ AGG81DEDCC_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v237.s_Center (UnityEngine.Vector2), v237.s_Center.y (System.Single)\n\tUnityEngine.RectTransform::set_anchorMax(v143, v183);\n\treturn;\n")]
		public void FitTo(RectTransform target)
		{
			Transform transform = base.transform;
			if ((object)transform == null)
			{
				if ((object)target == null)
				{
					throw new NullReferenceException();
				}
				Vector2 pivot = target.pivot;
				throw new NullReferenceException();
			}
			Transform transform2 = (((object)transform.GetType() != typeof(RectTransform)) ? null : transform);
			Vector2 pivot2 = target.pivot;
			((RectTransform)transform2).pivot = pivot2;
			Vector3 position = target.position;
			Quaternion rotation = target.rotation;
			transform2.SetPositionAndRotation(position, rotation);
			Vector3 lossyScale = target.lossyScale;
			Transform parent = transform2.parent;
			Vector3 lossyScale2 = parent.lossyScale;
			float x = lossyScale.x / lossyScale2.x;
			float y = lossyScale.y / lossyScale2.y;
			float z = lossyScale.z / lossyScale2.z;
			Vector3 localScale = default(Vector3);
			localScale.x = x;
			localScale.y = y;
			localScale.z = z;
			transform2.localScale = localScale;
			Rect rect = target.rect;
			Vector2 sizeDelta = default(Vector2);
			sizeDelta.x = rect.width;
			sizeDelta.y = rect.height;
			((RectTransform)transform2).sizeDelta = sizeDelta;
			Vector2 anchorMin = default(Vector2);
			anchorMin.x = s_Center.x;
			anchorMin.y = s_Center.y;
			((RectTransform)transform2).anchorMin = anchorMin;
			Vector2 anchorMax = default(Vector2);
			anchorMax.x = s_Center.x;
			anchorMax.y = s_Center.y;
			((RectTransform)transform2).anchorMax = anchorMax;
		}

		[Token(Token = "0x600002D")]
		[Address(RVA = "0x81DF1E4", Offset = "0x81DF1E4", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0017;\nL_0017:\n\tv54 = UnityEngine.Object::op_Implicit(this.fitTarget);\n\tv62 = ~v54;\n\tv63 = ~v62;\n\tif (v63) goto L_0038;\n\t_game.Scripts.TutorialSystem.UnMask::SetDirty(this);\n\treturn;\nL_0038:\n\t_game.Scripts.TutorialSystem.UnMask::FitTo(this, this.fitTarget);\n\t_game.Scripts.TutorialSystem.UnMask::SetDirty(this);\n\treturn;\n")]
		private void OnEnable()
		{
			if (!fitTarget)
			{
				SetDirty();
				return;
			}
			FitTo(fitTarget);
			SetDirty();
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0x81DF298", Offset = "0x81DF298", Length = "0x264")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0026:\n\tUnityEngine.UI.StencilMaterial::Remove(this._unmaskMaterial);\n\tUnityEngine.UI.StencilMaterial::Remove(this._revertUnmaskMaterial);\n\tthis._unmaskMaterial = 0;\n\tthis._revertUnmaskMaterial = 0;\n\tv72 = 0xB79A000;\n\tv74 = *([B79A178]) & 1;\n\tv75 = v74 == 0;\n\tif (v75) goto L_005A;\n\tv85 = 0xB292000 + 0x5A0;\n\tv167 = this + 0x40;\n\tv114 = this._graphic;\n\tv81 = this._graphic == 0;\n\tv99 = v85;\n\tv134 = v167;\n\tif (v81) goto L_0067;\nL_0040:\n\tv96 = *([v85 @ X23_v10 (System.Int32)]);\n\tv98 = *([v96 @ X0_v58+E4]) == 0;\n\tv129 = v114;\n\tv134 = v167;\n\tif (v98) goto L_0075;\nL_0046:\n\tv127 = UnityEngine.Object::op_Implicit(v114);\n\tv138 = ~v127;\n\tv139 = ~v138;\n\tif (v139) goto L_007C;\nL_0054:\n\t_game.Scripts.TutorialSystem.UnMask::SetDirty(this);\n\treturn;\nL_005A:\n\t*([v72 @ X22_v3+178]) = 1;\n\tv85 = 0xB292000 + 0x5A0;\n\tv167 = this + 0x40;\n\tv114 = this._graphic;\n\tv112 = this._graphic == 0;\n\tv91 = ~v112;\n\tv99 = v85;\n\tv134 = v167;\n\tif (v91) goto L_0040;\nL_0067:\n\tv109 = UnityEngine.Component::GetComponent(this);\n\tthis._graphic = v109;\n\tv119 = *([v99 @ X23_v4 (System.Int32)]);\n\tv143 = *([v119 @ X0_v48+E4]) == 0;\n\tv121 = ~v143;\n\tv114 = v109;\n\tv167 = v134;\n\tv129 = v109;\n\tif (v121) goto L_0046;\nL_0075:\n\tv142 = UnityEngine.Object::op_Implicit(v129);\n\tv149 = ~v142;\n\tv167 = v134;\n\tif (v149) goto L_0054;\nL_007C:\n\tgoto L_0082;\n\tv225 = UnityEngine.Component::GetComponent(this);\n\tthis._graphic = v225;\nL_0094:\n\tv231 = UnityEngine.UI.Graphic::get_canvasRenderer(v225);\n\tUnityEngine.CanvasRenderer::set_hasPopInstruction(v231, 0);\n\tUnityEngine.CanvasRenderer::set_popMaterialCount(v231, 0);\n\tgoto L_00A9;\n\tv265 = UnityEngine.Component::GetComponent(this);\n\tthis._graphic = v265;\nL_00BA:\n\t;\n\tv267 = UnityEngine.UI.Graphic::SetMaterialDirty(v265);\n\t_game.Scripts.TutorialSystem.UnMask::SetDirty(this);\n\treturn;\nL_0022:\n\tgoto L_0026;\nL_0082:\n\tv225 = this._graphic;\n\tv179 = *([v167 @ X20_v4]) == 0;\n\tv180 = ~v179;\n\tif (v180) goto L_0094;\nL_00A9:\n\tv265 = this._graphic;\n\tv257 = *([v167 @ X20_v4]) == 0;\n\tv258 = ~v257;\n\tif (v258) goto L_00BA;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UnMask::OnDisable");
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0x81DF4FC", Offset = "0x81DF4FC", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0017;\nL_0017:\n\tv54 = UnityEngine.Object::op_Implicit(this.fitTarget);\n\tv62 = ~v54;\n\tv63 = ~v62;\n\tif (v63) goto L_0037;\n\tgoto L_004B;\nL_0037:\n\tv83 = this.fitOnLateUpdate != 1;\n\tif (v83) goto L_004B;\n\t_game.Scripts.TutorialSystem.UnMask::FitTo(this, this.fitTarget);\n\treturn;\nL_004B:\n\treturn;\n")]
		private void LateUpdate()
		{
			if ((bool)fitTarget && fitOnLateUpdate)
			{
				FitTo(fitTarget);
			}
		}

		[Token(Token = "0x6000030")]
		[Address(RVA = "0x81DEE08", Offset = "0x81DEE08", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = 0xB79A000;\n\tv22 = *([B79A17B]) & 1;\n\tv23 = v22 == 0;\n\tif (v23) goto L_0051;\n\tv26 = *([B79A178]) & 1;\n\tv27 = v26 == 0;\n\tif (v27) goto L_005C;\nL_0016:\n\tv72 = 0xB292000 + 0x5A0;\n\tv139 = this + 0x40;\n\tv103 = this._graphic;\n\tv58 = this._graphic == 0;\n\tv86 = v72;\n\tv122 = v139;\n\tif (v58) goto L_0069;\nL_001C:\n\tv81 = *([v72 @ X23_v10 (System.Int32)]);\n\tv83 = *([v81 @ X0_v36+E4]) == 0;\n\tv117 = v103;\n\tv122 = v139;\n\tif (v83) goto L_0077;\nL_0022:\n\tv114 = UnityEngine.Object::op_Implicit(v103);\n\tv126 = ~v114;\n\tif (v126) goto L_0084;\nL_0029:\n\tgoto L_0030;\n\tv204 = UnityEngine.Component::GetComponent(this);\n\tthis._graphic = v204;\nL_004C:\n\tv180 = UnityEngine.UI.Graphic::SetMaterialDirty(v180);\nL_004C:\n\treturn;\nL_0051:\n\t*([v20 @ X20_v1+17B]) = 1;\n\tv67 = *([B79A178]) & 1;\n\tv68 = v67 == 0;\n\tv50 = ~v68;\n\tif (v50) goto L_0016;\nL_005C:\n\t*([B79A178]) = 1;\n\tv72 = 0xB292000 + 0x5A0;\n\tv139 = this + 0x40;\n\tv103 = this._graphic;\n\tv98 = this._graphic == 0;\n\tv76 = ~v98;\n\tv86 = v72;\n\tv122 = v139;\n\tif (v76) goto L_001C;\nL_0069:\n\tv95 = UnityEngine.Component::GetComponent(this);\n\tthis._graphic = v95;\n\tv102 = *([v86 @ X23_v4 (System.Int32)]);\n\tv130 = *([v102 @ X0_v11+E4]) == 0;\n\tv108 = ~v130;\n\tv103 = v95;\n\tv139 = v122;\n\tv117 = v95;\n\tif (v108) goto L_0022;\nL_0077:\n\tv129 = UnityEngine.Object::op_Implicit(v117);\n\tv160 = ~v129;\n\tv137 = ~v160;\n\tv139 = v122;\n\tif (v137) goto L_0029;\nL_0084:\n\treturn;\nL_0030:\n\tv168 = *([v139 @ X20_v8]) == 0;\n\tv169 = ~v168;\n\tif (v169) goto L_004C;\n")]
		private void SetDirty()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UnMask::SetDirty");
		}

		[Token(Token = "0x6000031")]
		[Address(RVA = "0x81DF5B4", Offset = "0x81DF5B4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public UnMask()
		{
		}

		[Token(Token = "0x6000032")]
		[Address(RVA = "0x81DF5BC", Offset = "0x81DF5BC", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tv40.s_Center = 0x3F;\n\treturn;\n")]
		static UnMask()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UnMask::.cctor");
		}
	}
}
