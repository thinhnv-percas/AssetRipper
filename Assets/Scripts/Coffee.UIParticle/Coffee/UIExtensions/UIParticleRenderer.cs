using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Coffee.UIParticleInternal;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Coffee.UIExtensions
{
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	[RequireComponent(typeof(CanvasRenderer))]
	[AddComponentMenu(null)]
	[Token(Token = "0x2000029")]
	internal class UIParticleRenderer : MaskableGraphic
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200002A")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000088")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000089")]
			public static Func<(Material mat, Texture texture), Material> _003C_003E9__32_0;

			[Token(Token = "0x6000110")]
			[Address(RVA = "0x3F2AEC4", Offset = "0x3F2AEC4", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new Coffee.UIExtensions.UIParticleRenderer+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000111")]
			[Address(RVA = "0x3F2AF28", Offset = "0x3F2AF28", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal Material _003CGetModifiedMaterial_003Eb__32_0((Material mat, Texture texture) x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("UIParticleRenderer._003C_003Ec::_003CGetModifiedMaterial_003Eb__32_0");
				return default;
			}
		}

		[Token(Token = "0x4000074")]
		private static readonly CombineInstance[] s_CombineInstances;

		[Token(Token = "0x4000075")]
		private static readonly List<Material> s_Materials;

		[Token(Token = "0x4000076")]
		private static MaterialPropertyBlock s_Mpb;

		[Token(Token = "0x4000077")]
		private static readonly Vector3[] s_Corners;

		[Token(Token = "0x4000078")]
		[FieldOffset(Offset = "0xD8")]
		private bool _delay;

		[Token(Token = "0x4000079")]
		[FieldOffset(Offset = "0xDC")]
		private int _index;

		[Token(Token = "0x400007A")]
		[FieldOffset(Offset = "0xE0")]
		private bool _isPrevStored;

		[Token(Token = "0x400007B")]
		[FieldOffset(Offset = "0xE1")]
		private bool _isTrail;

		[Token(Token = "0x400007C")]
		[FieldOffset(Offset = "0xE4")]
		private Bounds _lastBounds;

		[Token(Token = "0x400007D")]
		[FieldOffset(Offset = "0x100")]
		private Material _materialForRendering;

		[Token(Token = "0x400007E")]
		[FieldOffset(Offset = "0x108")]
		private Material _modifiedMaterial;

		[Token(Token = "0x400007F")]
		[FieldOffset(Offset = "0x110")]
		private UIParticle _parent;

		[Token(Token = "0x4000080")]
		[FieldOffset(Offset = "0x118")]
		private ParticleSystem _particleSystem;

		[Token(Token = "0x4000081")]
		[FieldOffset(Offset = "0x120")]
		private float _prevCanvasScale;

		[Token(Token = "0x4000082")]
		[FieldOffset(Offset = "0x124")]
		private Vector3 _prevPsPos;

		[Token(Token = "0x4000083")]
		[FieldOffset(Offset = "0x130")]
		private Vector3 _prevScale;

		[Token(Token = "0x4000084")]
		[FieldOffset(Offset = "0x13C")]
		private Vector2Int _prevScreenSize;

		[Token(Token = "0x4000085")]
		[FieldOffset(Offset = "0x144")]
		private bool _preWarm;

		[Token(Token = "0x4000086")]
		[FieldOffset(Offset = "0x148")]
		private ParticleSystemRenderer _renderer;

		[Token(Token = "0x4000087")]
		[FieldOffset(Offset = "0x150")]
		private ParticleSystem _mainEmitter;

		[Token(Token = "0x17000025")]
		public override Texture mainTexture
		{
			[Token(Token = "0x60000FB")]
			[Address(RVA = "0x3F28A78", Offset = "0x3F28A78", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn 0;\nL_0023:\n\tgoto L_002A;\nL_002A:\n\treturnVal2 = Coffee.UIParticleInternal.ParticleSystemExtensions::GetTextureForSprite(this._particleSystem);\n\treturn returnVal2;\nL_0014:\n\tv40 = this._isTrail == 0;\n\tif (v40) goto L_0023;\n")]
			get
			{
				if (_isTrail)
				{
					return null;
				}
				return _particleSystem.GetTextureForSprite();
			}
		}

		[Token(Token = "0x17000026")]
		public override bool raycastTarget
		{
			[Token(Token = "0x60000FC")]
			[Address(RVA = "0x3F28AFC", Offset = "0x3F28AFC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000027")]
		private Rect rootCanvasRect
		{
			[Token(Token = "0x60000FD")]
			[Address(RVA = "0x3F28B04", Offset = "0x3F28B04", Length = "0x5E4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tgoto L_001E;\nL_001E:\n\tv109 = v72.s_Corners;\n\tv100 = UnityEngine.Component::get_transform(this);\n\tv89 = v100 == 0;\n\tv90 = ~v89;\n\tif (v90) goto L_0045;\n\tgoto L_02A8;\nL_0045:\n\tv114 = this._lastBounds.m_Center.y - this._lastBounds.m_Extents.y;\n\tv115 = this._lastBounds - this._lastBounds.extents;\n\tv118 = UnityEngine.Transform::TransformPoint(v100, v115, v114, 0f);\n\t*([v109 @ X21_v3 (UnityEngine.Vector3[])+20]) = v118;\n\t*([v109 @ X21_v3 (UnityEngine.Vector3[])+24]) = v118.y;\n\t*([v109 @ X21_v3 (UnityEngine.Vector3[])+28]) = v118.z;\n\tv525 = v506.s_Corners;\n\tv424 = UnityEngine.Component::get_transform(this);\n\tv872 = this._lastBounds.m_Center.y + this._lastBounds.m_Extents.y;\n\tv873 = this._lastBounds - this._lastBounds.extents;\n\tv465 = UnityEngine.Transform::TransformPoint(v424, v873, v872, 0f);\n\t*([v525 @ X21_v7 (UnityEngine.Vector3[])+2C]) = v465;\n\t*([v525 @ X21_v7 (UnityEngine.Vector3[])+30]) = v465.y;\n\t*([v525 @ X21_v7 (UnityEngine.Vector3[])+34]) = v465.z;\n\tv526 = v507.s_Corners;\n\tv425 = UnityEngine.Component::get_transform(this);\n\tv880 = this._lastBounds.m_Center.y + this._lastBounds.m_Extents.y;\n\tv881 = this._lastBounds + this._lastBounds.extents;\n\tv466 = UnityEngine.Transform::TransformPoint(v425, v881, v880, 0f);\n\t*([v526 @ X21_v8 (UnityEngine.Vector3[])+38]) = v466;\n\t*([v526 @ X21_v8 (UnityEngine.Vector3[])+3C]) = v466.y;\n\t*([v526 @ X21_v8 (UnityEngine.Vector3[])+40]) = v466.z;\n\tv527 = v508.s_Corners;\n\tv426 = UnityEngine.Component::get_transform(this);\n\tv890 = this._lastBounds.m_Center.y - this._lastBounds.m_Extents.y;\n\tv891 = this._lastBounds + this._lastBounds.extents;\n\tv467 = UnityEngine.Transform::TransformPoint(v426, v891, v890, 0f);\n\t*([v527 @ X21_v9 (UnityEngine.Vector3[])+44]) = v467;\n\t*([v527 @ X21_v9 (UnityEngine.Vector3[])+48]) = v467.y;\n\t*([v527 @ X21_v9 (UnityEngine.Vector3[])+4C]) = v467.z;\n\tv896 = UnityEngine.UI.Graphic::get_canvas(this);\n\tgoto L_00C1;\nL_00C1:\n\tv899 = UnityEngine.Object::op_Implicit(v896);\n\tv903 = ~v899;\n\tv904 = ~v903;\n\tif (v904) goto L_00D9;\n\tgoto L_00CA;\nL_00CA:\n\tv830 = v925.s_Corners;\n\tv926 = v925.s_Corners == 0;\n\tv488 = ~v926;\n\tif (v488) goto L_01A3;\n\tgoto L_02A8;\nL_00D9:\n\tv428 = UnityEngine.UI.Graphic::get_canvas(this);\n\tv429 = UnityEngine.Canvas::get_rootCanvas(v428);\n\tv430 = UnityEngine.Component::get_transform(v429);\n\tv950 = UnityEngine.Transform::get_worldToLocalMatrix(v430);\n\tv453 = v950;\n\tgoto L_0107;\n\t// 274 MakeStruct v151 @ AGG3F28DC4_1_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v536 @ X19_v11 (UnityEngine.Vector3[])+20], [v536 @ X19_v11 (UnityEngine.Vector3[])+24], [v536 @ X19_v11 (UnityEngine.Vector3[])+28]\n\tv475 = UnityEngine.Matrix4x4::MultiplyPoint(&v453 @ stack_-90_v7 (UnityEngine.Matrix4x4), v151);\n\t*([v536 @ X19_v11 (UnityEngine.Vector3[])+20]) = v475;\n\t*([v536 @ X19_v11 (UnityEngine.Vector3[])+24]) = v475.y;\n\t*([v536 @ X19_v11 (UnityEngine.Vector3[])+28]) = v475.z;\n\tgoto L_0124;\n\t// 307 MakeStruct v145 @ AGG3F28E14_1_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v537 @ X19_v12 (UnityEngine.Vector3[])+2C], [v537 @ X19_v12 (UnityEngine.Vector3[])+30], [v537 @ X19_v12 (UnityEngine.Vector3[])+34]\n\tv476 = UnityEngine.Matrix4x4::MultiplyPoint(&v453 @ stack_-90_v7 (UnityEngine.Matrix4x4), v145);\n\t*([v537 @ X19_v12 (UnityEngine.Vector3[])+2C]) = v476;\n\t*([v537 @ X19_v12 (UnityEngine.Vector3[])+30]) = v476.y;\n\t*([v537 @ X19_v12 (UnityEngine.Vector3[])+34]) = v476.z;\n\tgoto L_0149;\n\t// 349 MakeStruct v139 @ AGG3F28E68_1_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v538 @ X19_v13 (UnityEngine.Vector3[])+38], [v538 @ X19_v13 (UnityEngine.Vector3[])+3C], [v538 @ X19_v13 (UnityEngine.Vector3[])+40]\n\tv477 = UnityEngine.Matrix4x4::MultiplyPoint(&v453 @ stack_-90_v7 (UnityEngine.Matrix4x4), v139);\n\t*([v538 @ X19_v13 (UnityEngine.Vector3[])+38]) = v477;\n\t*([v538 @ X19_v13 (UnityEngine.Vector3[])+3C]) = v477.y;\n\t*([v538 @ X19_v13 (UnityEngine.Vector3[])+40]) = v477.z;\n\tgoto L_0178;\n\t// 391 MakeStruct v654 @ AGG3F28EBC_1_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v539 @ X19_v14 (UnityEngine.Vector3[])+44], [v539 @ X19_v14 (UnityEngine.Vector3[])+48], [v539 @ X19_v14 (UnityEngine.Vector3[])+4C]\n\tv802 = UnityEngine.Matrix4x4::MultiplyPoint(&v453 @ stack_-90_v7 (UnityEngine.Matrix4x4), v654);\n\t*([v539 @ X19_v14 (UnityEngine.Vector3[])+44]) = v802;\n\t*([v539 @ X19_v14 (UnityEngine.Vector3[])+48]) = v802.y;\n\t*([v539 @ X19_v14 (UnityEngine.Vector3[])+4C]) = v802.z;\n\tgoto L_00CA;\nL_01A3:\n\tv652 = *([v830 @ X8_v17 (UnityEngine.Vector3[])+20]);\n\tv844 = *([v830 @ X8_v17 (UnityEngine.Vector3[])+24]);\n\tv841 = *([v830 @ X8_v17 (UnityEngine.Vector3[])+24]);\n\tv123 = *([v830 @ X8_v17 (UnityEngine.Vector3[])+20]);\n\tv531 = 0x2C;\n\tv535 = 1;\n\tgoto L_01BB;\nL_01AA:\n\tv1041 = v523 + v531;\n\tv841 = *([v1041 @ X8_v32+4]);\nL_01BB:\n\tgoto L_01BF;\n\tv371 = *([v833 @ X8_v39 (UnityEngine.Vector3[])+v531 @ X21_v12 (System.Int32)]) < v652;\n\tv264 = ~v371;\n\tif (v264) goto L_01F1;\n\tgoto L_01ED;\nL_01ED:\n\tv652 = *([v833 @ X8_v39 (UnityEngine.Vector3[])+v531 @ X21_v12 (System.Int32)]);\n\tgoto L_0229;\nL_01F1:\n\tgoto L_0203;\nL_0203:\n\t;\n\tv372 = *([v833 @ X8_v39 (UnityEngine.Vector3[])+v531 @ X21_v12 (System.Int32)]) < v123;\n\tv357 = *([v833 @ X8_v39 (UnityEngine.Vector3[])+v531 @ X21_v12 (System.Int32)]) == v123;\n\tv973 = *([v833 @ X8_v39 (UnityEngine.Vector3[])+v531 @ X21_v12 (System.Int32)]) == *([v833 @ X8_v39 (UnityEngine.Vector3[])+v531 @ X21_v12 (System.Int32)]);\n\tv301 = v123 == v123;\n\tv313 = v973 & v301;\n\tv327 = ~v313;\n\tv974 = v372 == v327;\n\tv975 = ~v974;\n\tv265 = v975 | v357;\n\tif (v265) goto L_0229;\n\tgoto L_0225;\nL_0225:\n\tv123 = *([v833 @ X8_v39 (UnityEngine.Vector3[])+v531 @ X21_v12 (System.Int32)]);\nL_023B:\n\tv1001 = v990.s_Corners + v531;\n\tv374 = *([v1001 @ X9_v11+4]) < v844;\n\tv267 = ~v374;\n\tif (v267) goto L_0261;\n\tgoto L_025C;\nL_025C:\n\tv1027 = v1013.s_Corners + v531;\n\tv844 = *([v1027 @ X8_v37+4]);\n\tgoto L_01AC;\nL_0261:\n\tgoto L_0273;\nL_0273:\n\tv1018 = v990.s_Corners + v531;\n\tv378 = *([v1018 @ X8_v28+4]) < v841;\n\tv363 = *([v1018 @ X8_v28+4]) == v841;\n\tv1020 = *([v1018 @ X8_v28+4]) == *([v1018 @ X8_v28+4]);\n\tv306 = v841 == v841;\n\tv318 = v1020 & v306;\n\tv333 = ~v318;\n\tv1021 = v378 == v333;\n\tv1022 = ~v1021;\n\tv270 = v1022 | v363;\n\tif (v270) goto L_01AC;\n\tgoto L_0288;\n\tv1049 = v535 < v523.Length;\n\tv739 = ~v1049;\n\tv685 = ~v739;\n\tif (v685) goto L_01AA;\n\tthrow System.IndexOutOfRangeException;\nL_02A7:\n\treturn v652;\nL_02A8:\n\tthrow System.NullReferenceException;\nL_0107:\n\tv536 = v517.s_Corners;\nL_0124:\n\tv537 = v518.s_Corners;\nL_0149:\n\tv538 = v519.s_Corners;\nL_0178:\n\tv539 = v520.s_Corners;\nL_01BF:\n\tv833 = v947.s_Corners;\nL_0229:\n\tgoto L_023B;\nL_01AC:\n\tv535 = v535 + 1;\n\tv531 = v531 + 0xC;\n\tv855 = v531 == 0x50;\n\tif (v855) goto L_02A7;\nL_0288:\n\tv523 = v1047.s_Corners;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("UIParticleRenderer::get_rootCanvasRect");
				return default;
			}
		}

		[Token(Token = "0x17000028")]
		public override Material materialForRendering
		{
			[Token(Token = "0x60000FE")]
			[Address(RVA = "0x3F290E8", Offset = "0x3F290E8", Length = "0xC4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0017;\nL_0017:\n\tv54 = UnityEngine.Object::op_Implicit(this._materialForRendering);\n\tv63 = v54 == 0;\n\tif (v63) goto L_0039;\n\treturn this._materialForRendering;\nL_0039:\n\tv87 = UnityEngine.UI.Graphic::get_materialForRendering(this);\n\tthis._materialForRendering = v87;\n\treturn this._materialForRendering;\n")]
			get
			{
				if ((bool)_materialForRendering)
				{
					return _materialForRendering;
				}
				Material material = base.materialForRendering;
				_materialForRendering = material;
				return _materialForRendering;
			}
		}

		[Token(Token = "0x60000FF")]
		[Address(RVA = "0x3F24A6C", Offset = "0x3F24A6C", Length = "0x248")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Implicit(this._renderer);\n\tv64 = ~v55;\n\tv65 = ~v64;\n\tif (v65) goto L_0036;\n\tgoto L_0037;\nL_0036:\n\tUnityEngine.Renderer::set_enabled(this._renderer, 1);\nL_0037:\n\tthis._parent = 0;\n\tthis._particleSystem = 0;\n\tthis._renderer = 0;\n\tthis._mainEmitter = 0;\n\tv157 = index & 0x80000000;\n\tv158 = v157 == 0;\n\tv159 = ~v158;\n\tif (v159) goto L_004F;\n\tthis._index = index;\nL_0052:\n\tv165 = UnityEngine.Object::op_Implicit(this);\n\tv167 = ~v165;\n\tv168 = ~v167;\n\tif (v168) goto L_005F;\n\tgoto L_0083;\nL_005F:\n\tv178 = UnityEngine.Behaviour::get_isActiveAndEnabled(this);\n\tv181 = ~v178;\n\tif (v181) goto L_0083;\n\tv193 = UnityEngine.UI.Graphic::set_material(this, 0);\n\tv100 = UnityEngine.UI.Graphic::get_canvasRenderer(this);\n\tUnityEngine.CanvasRenderer::Clear(v100);\n\tthis._lastBounds.m_Center.z = 0f;\n\tthis._lastBounds = 0;\n\tthis._lastBounds.m_Extents.y = 0f;\n\tUnityEngine.Behaviour::set_enabled(this, 0);\n\treturn;\nL_0083:\n\tgoto L_0088;\nL_0088:\n\tgoto L_008C;\nL_008C:\n\tgoto L_0094;\nL_0094:\n\t;\n\tCoffee.UIParticleInternal.ObjectRepository`1<UnityEngine.Material>::Release(v109.s_Repository, &this._modifiedMaterial (UnityEngine.Material));\n\tthis._materialForRendering = 0;\n\treturn;\nL_004F:\n\tgoto L_0052;\n")]
		public void Reset(int index = -1)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIParticleRenderer::Reset");
		}

		[Token(Token = "0x6000100")]
		[Address(RVA = "0x3F291AC", Offset = "0x3F291AC", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv76 = v65.m_HideGeneratedObjects == 0;\n\tv83 = ~v76;\n\tv84 = ~v83;\n\tif (v84) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv89 = 0x3F;\n\tgoto L_0048;\nL_FFFFFFFF:\n\tv89 = 0x3C;\nL_0059:\n\tv211 = v208.s_CombineInstances + 0x20;\n\tv213 = UnityEngine.CombineInstance::get_mesh(v211);\n\tgoto L_0061;\nL_0061:\n\tv216 = UnityEngine.Object::op_Implicit(v213);\n\tv221 = v216 == 0;\n\tif (v221) goto L_007B;\n\treturn;\nL_007B:\n\tgoto L_0085;\nL_0085:\n\tv115 = new UnityEngine.Mesh();\n\tUnityEngine.Mesh::.ctor(v115);\n\tUnityEngine.Object::set_name(v115, \"[UIParticleRenderer] Combine Instance Mesh\");\n\tUnityEngine.Object::set_hideFlags(v115, 0x3D);\n\tv192 = v125.s_CombineInstances + 0x20;\n\tUnityEngine.CombineInstance::set_mesh(v192, v115);\n\treturn;\nL_001F:\n\tUnityEngine.UI.MaskableGraphic::OnEnable(this);\n\tgoto L_002E;\nL_002E:\n\tv65 = Coffee.UIParticleInternal.PreloadedProjectSettings`1<Coffee.UIExtensions.UIParticleProjectSettings>::get_instance();\nL_0048:\n\tUnityEngine.Object::set_hideFlags(this, v89);\n\tgoto L_0059;\n")]
		protected unsafe override void OnEnable()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIParticleRenderer::OnEnable");
		}

		[Token(Token = "0x6000101")]
		[Address(RVA = "0x3F29380", Offset = "0x3F29380", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = *([B78EACA]) & 1;\n\tv21 = v20 == 0;\n\tif (v21) goto L_003A;\n\tUnityEngine.UI.MaskableGraphic::OnDisable(this);\n\tgoto L_001B;\nL_001B:\n\tgoto L_001F;\nL_001F:\n\tgoto L_0027;\nL_0027:\n\t;\n\tCoffee.UIParticleInternal.ObjectRepository`1<UnityEngine.Material>::Release(v94.s_Repository, &this._modifiedMaterial (UnityEngine.Material));\n\tthis._materialForRendering = 0;\n\tthis._isPrevStored = 0;\n\treturn;\nL_003A:\n\t*([B78EACA]) = 1;\n\tUnityEngine.UI.MaskableGraphic::OnDisable(this);\n\tgoto L_001B;\n")]
		protected override void OnDisable()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EACA]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				base.OnDisable();
			}
			else
			{
				_ = 1;
				base.OnDisable();
			}
			MaterialRepository.s_Repository.Release(ref _modifiedMaterial);
			_materialForRendering = null;
			_isPrevStored = false;
		}

		[Token(Token = "0x6000102")]
		[Address(RVA = "0x3F26D48", Offset = "0x3F26D48", Length = "0x2F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\nL_0038:\n\tv77 = System.Type::GetTypeFromHandle(Coffee.UIExtensions.UIParticleRenderer);\n\tv85 = v77 == 0;\n\tif (v85) goto L_004D;\n\tv184 = 0x21C11D0(v77, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv188 = v184 == 0;\n\tif (v188) goto L_00F8;\nL_004D:\n\tv58[0] = v77;\n\tv260 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v260, \"[generated] UIParticleRenderer\", v58);\n\tgoto L_0065;\n\tv128 = v156.m_HideGeneratedObjects == 0;\n\tv110 = ~v128;\n\tv107 = ~v110;\n\tif (v107) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv151 = 0x3F;\n\tgoto L_007F;\nL_FFFFFFFF:\n\tv151 = 0x3C;\n\tv158 = UnityEngine.Component::get_gameObject(parent);\n\tv326 = UnityEngine.GameObject::get_layer(v158);\n\tUnityEngine.GameObject::set_layer(v260, v326);\n\tv331 = UnityEngine.GameObject::get_transform(v260);\n\tv159 = UnityEngine.Component::get_transform(parent);\n\tUnityEngine.Transform::SetParent(v331, v159, 0);\n\tgoto L_00AF;\n\tv160._parent = parent;\n\tv160._index = index;\n\treturn v160;\nL_00F8:\n\tv258 = new System.ArrayTypeMismatchException();\n\tthrow v258;\nL_002B:\n\t// 43 NewArr v58 @ X0_v3 (System.Type[]), typeof(System.Type[]), 1\n\tgoto L_0038;\nL_0065:\n\tv156 = Coffee.UIParticleInternal.PreloadedProjectSettings`1<Coffee.UIExtensions.UIParticleProjectSettings>::get_instance();\nL_007F:\n\tUnityEngine.Object::set_hideFlags(v260, v151);\nL_00AF:\n\t// 175 MakeStruct v96 @ AGG3F26F5C_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v348.zero (UnityEngine.Vector3), v348.zero.y (System.Single), v348.zero.z (System.Single)\n\tUnityEngine.Transform::set_localPosition(v331, v96);\n\tgoto L_00C8;\nL_00C8:\n\t// 200 MakeStruct v91 @ AGG3F26FA8_1_v4 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v369.identity (UnityEngine.Quaternion), v369.identity.y (System.Single), v369.identity.z (System.Single), v369.identity.w (System.Single)\n\tUnityEngine.Transform::set_localRotation(v331, v91);\n\tgoto L_00DC;\nL_00DC:\n\t// 220 MakeStruct v88 @ AGG3F26FE4_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v176.one (UnityEngine.Vector3), v176.one.y (System.Single), v176.one.z (System.Single)\n\tUnityEngine.Transform::set_localScale(v331, v88);\n\tv160 = UnityEngine.GameObject::GetComponent(v260);\n")]
		public static UIParticleRenderer AddRenderer(UIParticle parent, int index)
		{
			Type[] array = new Type[1];
			Type typeFromHandle = typeof(UIParticleRenderer);
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
			GameObject gameObject = new GameObject("[generated] UIParticleRenderer", array);
			UIParticleProjectSettings instance = PreloadedProjectSettings<UIParticleProjectSettings>.instance;
			HideFlags hideFlags = ((!instance.m_HideGeneratedObjects) ? (HideFlags.DontSave | HideFlags.NotEditable) : (HideFlags.HideAndDontSave | HideFlags.HideInInspector));
			gameObject.hideFlags = hideFlags;
			GameObject gameObject2 = parent.gameObject;
			int layer = gameObject2.layer;
			gameObject.layer = layer;
			Transform transform = gameObject.transform;
			Transform parent2 = parent.transform;
			transform.SetParent(parent2, worldPositionStays: false);
			Vector3 localPosition = default(Vector3);
			localPosition.x = Vector3.zero.x;
			localPosition.y = Vector3.zero.y;
			localPosition.z = Vector3.zero.z;
			transform.localPosition = localPosition;
			Quaternion localRotation = default(Quaternion);
			localRotation.x = Quaternion.identity.x;
			localRotation.y = Quaternion.identity.y;
			localRotation.z = Quaternion.identity.z;
			localRotation.w = Quaternion.identity.w;
			transform.localRotation = localRotation;
			Vector3 localScale = default(Vector3);
			localScale.x = Vector3.one.x;
			localScale.y = Vector3.one.y;
			localScale.z = Vector3.one.z;
			transform.localScale = localScale;
			UIParticleRenderer component = gameObject.GetComponent<UIParticleRenderer>();
			component._parent = parent;
			component._index = index;
			return component;
		}

		[Token(Token = "0x6000103")]
		[Address(RVA = "0x3F2949C", Offset = "0x3F2949C", Length = "0x4A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tgoto L_0041;\nL_0041:\n\tv85 = UnityEngine.Object::op_Implicit(this._parent);\n\tv115 = v85 == 0;\n\tv89 = ~v115;\n\tif (v89) goto L_0051;\nL_FFFFFFFF:\n\tv297 = baseMaterial;\n\tgoto L_008D;\nL_0051:\n\tv145 = UnityEngine.UI.MaskableGraphic::GetModifiedMaterial(this, baseMaterial);\n\tv172 = Coffee.UIExtensions.UIParticleRenderer::get_mainTexture(this);\n\tgoto L_0060;\nL_0060:\n\tv195 = UnityEngine.Object::op_Equality(v172, 0);\n\tv253 = ~v195;\n\tv254 = ~v253;\n\tif (v254) goto L_006C;\n\tgoto L_0078;\nL_006C:\n\tv243 = this._parent;\n\tv244 = v243.m_AnimatableProperties;\n\tv91 = v244.Length == 0;\nL_FFFFFFFF:\n\tv297 = v145;\n\tif (v91) goto L_008D;\nL_0078:\n\tgoto L_007B;\nL_007B:\n\tv347 = UnityEngine.Object::op_Implicit(v145);\n\tv349 = ~v347;\n\tif (v349) goto L_FFFFFFFF;\n\tv365 = UnityEngine.Object::GetInstanceID(v145);\nL_FFFFFFFF:\n\tv212 = v365;\n\tgoto L_00CB;\nL_008D:\n\tgoto L_0092;\nL_0092:\n\tgoto L_0096;\nL_0096:\n\tgoto L_0099;\nL_0099:\n\tv156 = v154.s_Repository == 0;\n\tv157 = ~v156;\n\tif (v157) goto L_00BA;\n\tgoto L_017E;\nL_00BA:\n\t;\n\tCoffee.UIParticleInternal.ObjectRepository`1<UnityEngine.Material>::Release(v154.s_Repository, &this._modifiedMaterial (UnityEngine.Material));\n\tgoto L_0162;\nL_FFFFFFFF:\n\tv212 = 0;\n\tgoto L_00CB;\nL_00CB:\n\tv377 = UnityEngine.Object::op_Implicit(v172);\n\tv385 = ~v377;\nL_FFFFFFFF:\n\tv213 = v212;\n\tif (v385) goto L_FFFFFFFF;\n\tv400 = UnityEngine.Object::GetInstanceID(v172);\nL_FFFFFFFF:\n\tv213 = v212;\nL_FFFFFFFF:\n\tv225 = v400;\n\tgoto L_00DD;\nL_FFFFFFFF:\n\tv225 = 0;\n\tv247 = v249.m_AnimatableProperties;\n\tv405 = v247.Length == 0;\n\tif (v405) goto L_FFFFFFFF;\n\tv408 = UnityEngine.Object::GetInstanceID(this);\nL_FFFFFFFF:\n\tv209 = v408;\n\tgoto L_00F1;\nL_FFFFFFFF:\n\tv209 = 0;\nL_00FD:\n\tgoto L_0101;\nL_0101:\n\tgoto L_010C;\nL_010C:\n\tv464 = Coffee.UIParticleInternal.ObjectRepository`1<UnityEngine.Material>::Valid(v248.s_Repository, v198, this._modifiedMaterial);\n\tv470 = v464 == 0;\n\tv471 = ~v470;\n\tif (v471) goto L_0153;\n\tgoto L_011D;\n\tgoto L_012C;\nL_0142:\n\tSystem.ValueTuple`2<System.Object, System.Object>::.ctor(&v483 @ stack_-80_v4, v145, v172);\n\tgoto L_014E;\nL_014E:\n\tv489 = this + 0x108;\n\tCoffee.UIParticleInternal.MaterialRepository::Get /* +1 sharing this address */(v198, v489, v486, v483, 0);\nL_0153:\n\tv297 = this._modifiedMaterial;\nL_017E:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_0035:\n\tv64 = UnityEngine.EventSystems.UIBehaviour::IsActive(this);\n\tv65 = ~v64;\nL_FFFFFFFF:\n\tv297 = baseMaterial;\n\tif (v65) goto L_008D;\nL_0162:\n\treturn v297;\nL_00DD:\n\tv249 = this._parent;\nL_00F1:\n\tUnityEngine.Hash128::.ctor(&v198 @ stack_-70_v4 (UnityEngine.Hash128), v213, v225, v209, 0);\n\tgoto L_00FD;\nL_011D:\n\tv486 = v497.<>9__32_0;\n\tv499 = v497.<>9__32_0 == 0;\n\tv500 = ~v499;\n\tif (v500) goto L_0142;\nL_012C:\n\tv531 = new System.Func`2<System.ValueTuple`2<UnityEngine.Material, UnityEngine.Texture>, UnityEngine.Material>();\n\tSystem.Func`2<System.ValueTuple`2<UnityEngine.Material, UnityEngine.Texture>, UnityEngine.Material>::.ctor(v531, v526.<>9, Il2CppMethodInfo);\n\tv542.<>9__32_0 = v531;\nL_FFFFFFFF:\n\tv486 = v531;\n")]
		public unsafe override Material GetModifiedMaterial(Material baseMaterial)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIParticleRenderer::GetModifiedMaterial");
			return default;
		}

		[Token(Token = "0x6000104")]
		[Address(RVA = "0x3F24E88", Offset = "0x3F24E88", Length = "0x3B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tUnityEngine.UI.MaskableGraphic::set_maskable(this, parent.maskable);\n\tv212 = UnityEngine.Component::get_gameObject(this);\n\tv156 = UnityEngine.Component::get_gameObject(parent);\n\tv157 = UnityEngine.GameObject::get_layer(v156);\n\tUnityEngine.GameObject::set_layer(v212, v157);\n\tthis._particleSystem = ps;\n\tv261 = UnityEngine.ParticleSystem::get_main(this._particleSystem);\n\tv131 = v261;\n\tv263 = UnityEngine.ParticleSystem+MainModule::get_prewarm(&v131 @ stack_-50_v2 (UnityEngine.ParticleSystem+MainModule));\n\tthis._preWarm = v263;\n\tv264 = UnityEngine.ParticleSystem::get_isPlaying(this._particleSystem);\n\tv266 = v264 == 0;\n\tv267 = ~v266;\n\tif (v267) goto L_0069;\n\tv278 = this._preWarm != 1;\n\tif (v278) goto L_0074;\nL_0069:\n\tUnityEngine.ParticleSystem::Clear(this._particleSystem);\n\tUnityEngine.ParticleSystem::Pause(this._particleSystem);\nL_0074:\n\t;\n\tv283 = UnityEngine.Component::TryGetComponent(ps, &this._renderer (UnityEngine.ParticleSystemRenderer));\n\tUnityEngine.Renderer::set_enabled(this._renderer, 0);\n\tthis._isTrail = isTrail;\n\tgoto L_008E;\nL_008E:\n\tUnityEngine.Renderer::GetSharedMaterials(this._renderer, v290.s_Materials);\n\tv297 = System.Collections.Generic.List`1<UnityEngine.Material>::get_Item(v192.s_Materials, isTrail);\n\tv300 = UnityEngine.UI.Graphic::set_material(this, v297);\n\tgoto L_00A7;\n\tSystem.Collections.Generic.List`1<UnityEngine.Material>::Clear(v193);\n\tv320 = v193.Count < 1;\n\tif (v320) goto L_00C1;\nL_00C1:\n\tv328 = UnityEngine.ParticleSystem::get_textureSheetAnimation(ps);\n\tv76 = v328;\n\tv331 = UnityEngine.ParticleSystem+TextureSheetAnimationModule::get_mode(&v76 @ stack_-48_v3 (UnityEngine.ParticleSystem+TextureSheetAnimationModule));\n\tv88 = v331 != 1;\n\tif (v88) goto L_00DC;\n\tv335 = UnityEngine.ParticleSystem+TextureSheetAnimationModule::get_uvChannelMask(&v76 @ stack_-48_v3 (UnityEngine.ParticleSystem+TextureSheetAnimationModule));\n\tv343 = v335 == 0;\n\tv341 = ~v343;\n\tif (v341) goto L_00DC;\n\tUnityEngine.ParticleSystem+TextureSheetAnimationModule::set_uvChannelMask(&v76 @ stack_-48_v3 (UnityEngine.ParticleSystem+TextureSheetAnimationModule), 1);\nL_00DC:\n\tv72 = Coffee.UIExtensions.UIParticleRenderer::GetWorldScale(this);\n\tthis._prevScale.x = v72;\n\tthis._prevScale.y = v72.y;\n\tthis._prevScale.z = v72.z;\n\tv167 = UnityEngine.Component::get_transform(this._particleSystem);\n\tv346 = UnityEngine.Transform::get_position(v167);\n\tthis._prevPsPos.x = v346;\n\tthis._prevPsPos.y = v346.y;\n\tthis._prevPsPos.z = v346.z;\n\tv348 = UnityEngine.Screen::get_width();\n\tv351 = UnityEngine.Screen::get_height();\n\tv354 = v348 | v351;\n\tthis._prevScreenSize = v354;\n\tv357 = UnityEngine.UI.Graphic::get_canvas(this);\n\tgoto L_0103;\nL_0103:\n\tv360 = UnityEngine.Object::op_Implicit(v357);\n\tv365 = ~v360;\n\tv366 = ~v365;\n\tif (v366) goto L_0114;\n\tv74 = 1f;\n\tgoto L_0119;\nL_0114:\n\tv168 = UnityEngine.UI.Graphic::get_canvas(this);\n\tv74 = UnityEngine.Canvas::get_scaleFactor(v168);\nL_0119:\n\tthis._prevCanvasScale = v74;\n\tthis._delay = 1;\n\tthis._mainEmitter = mainEmitter;\n\tv169 = UnityEngine.UI.Graphic::get_canvasRenderer(this);\n\tUnityEngine.CanvasRenderer::SetTexture(v169, 0);\n\tUnityEngine.Behaviour::set_enabled(this, 1);\n\treturn;\nL_0027:\n\tthis._parent = parent;\nL_00A7:\n\tv193 = v307.s_Materials;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Set(UIParticle parent, ParticleSystem ps, bool isTrail, ParticleSystem mainEmitter)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIParticleRenderer::Set");
		}

		[Token(Token = "0x6000105")]
		[Address(RVA = "0x3F25B40", Offset = "0x3F25B40", Length = "0x10F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0062;\n\tgoto L_006E;\nL_006E:\n\tv168 = UnityEngine.Object::op_Implicit(this._particleSystem);\n\tv218 = ~v168;\n\tv180 = ~v218;\n\tif (v180) goto L_007D;\n\tgoto L_00CE;\nL_007D:\n\tgoto L_0080;\nL_0080:\n\tv170 = UnityEngine.Object::op_Implicit(this._parent);\n\tv1445 = ~v170;\n\tv182 = ~v1445;\n\tif (v182) goto L_008D;\n\tgoto L_00CE;\nL_008D:\n\tv1456 = UnityEngine.UI.Graphic::get_canvasRenderer(this);\n\tgoto L_0093;\nL_0093:\n\tv172 = UnityEngine.Object::op_Implicit(v1456);\n\tv1496 = ~v172;\n\tv184 = ~v1496;\n\tif (v184) goto L_00A2;\n\tgoto L_00CE;\nL_00A2:\n\tv1674 = UnityEngine.UI.Graphic::get_canvas(this);\n\tgoto L_00AD;\n\tgoto L_00B8;\nL_00B8:\n\tv167 = UnityEngine.Object::op_Implicit(bakeCamera);\n\tv187 = ~v167;\n\tif (v187) goto L_00CE;\n\tv1323 = this._parent;\n\tv109 = v1323.meshSharing != 4;\n\tif (v109) goto L_00FE;\nL_00CE:\n\tgoto L_00D1;\nL_00D1:\n\tv214 = UnityEngine.UI.Graphic::get_workerMesh();\n\tUnityEngine.Mesh::Clear(v214);\n\tv1405 = UnityEngine.UI.Graphic::get_canvasRenderer(this);\n\tv1193 = UnityEngine.UI.Graphic::get_workerMesh();\n\tUnityEngine.CanvasRenderer::SetMesh(v1405, v1193);\n\tthis._lastBounds.m_Center.z = 0f;\n\tthis._lastBounds = 0;\n\tthis._lastBounds.m_Extents.y = 0f;\nL_00FE:\n\tv1194 = UnityEngine.Component::get_transform(this);\n\tv882 = UnityEngine.Transform::get_lossyScale(v1194);\n\tv1987 = Coffee.UIExtensions.UIParticle::get_scale3DForCalc(this._parent);\n\tv1990 = v882 * v1987;\n\tv105 = v882.y * v1987.y;\n\tv103 = v882.z * v1987.z;\n\tv1991 = v1990 * v105;\n\tv107 = v103 * v1991;\n\tv132 = v107 == 0;\n\tv142 = v107 == v107;\n\tv115 = ~v142;\n\tif (v132) goto L_00CE;\n\tif (v115) goto L_00CE;\n\tv1993 = UnityEngine.ParticleSystem::IsAlive(this._particleSystem);\n\tv1995 = v1993 == 0;\n\tv1996 = ~v1995;\n\tif (v1996) goto L_0135;\n\tv176 = UnityEngine.ParticleSystem::get_isPlaying(this._particleSystem);\n\tv189 = ~v176;\n\tif (v189) goto L_00CE;\nL_0135:\n\tv111 = this._isTrail != 1;\n\tif (v111) goto L_0147;\n\tv2003 = UnityEngine.ParticleSystem::get_trails(this._particleSystem);\n\tv95 = v2003;\n\tv177 = UnityEngine.ParticleSystem+TrailModule::get_enabled(&v95 @ stack_-B8_v7 (UnityEngine.ParticleSystem+TrailModule));\n\tv190 = v177 == 0;\n\tif (v190) goto L_00CE;\nL_0147:\n\tv2004 = UnityEngine.ParticleSystem::get_main(this._particleSystem);\n\tv831 = v2004;\n\tv883 = Coffee.UIExtensions.UIParticleRenderer::GetWorldScale(this);\n\tv1200 = UnityEngine.Component::get_transform(this._particleSystem);\n\tv884 = UnityEngine.Transform::get_position(v1200);\n\tv2010 = this._isTrail == 0;\n\tv2011 = ~v2010;\n\tif (v2011) goto L_021C;\n\tv1324 = this._parent;\n\tv2039 = v1324.meshSharing < 3;\n\tv1082 = ~v2039;\n\tv1061 = v1324.meshSharing - 3;\n\tv1019 = v1061 == 0;\n\tv2040 = ~v1019;\n\tv919 = v1082 & v2040;\n\tif (v919) goto L_021C;\n\tgoto L_017C;\nL_017C:\n\tv2026 = UnityEngine.Object::op_Implicit(this._mainEmitter);\n\tv2211 = v2026 == 0;\n\tv2029 = ~v2211;\n\tif (v2029) goto L_021C;\n\tCoffee.UIExtensions.UIParticleRenderer::ResolveResolutionChange(this, v884, v883);\n\tgoto L_0197;\n\tv2231 = UnityEngine.ParticleSystem+MainModule::get_loop(&v831 @ stack_-A8_v5 (UnityEngine.ParticleSystem+MainModule));\n\tv2245 = v2231 == 0;\n\tv2241 = ~v2245;\n\tif (v2241) goto L_01B2;\n\tv2232 = UnityEngine.ParticleSystem::get_time(this._particleSystem);\n\tv2235 = v2232 == 0;\n\tv2233 = ~v2235;\n\tif (v2233) goto L_01B2;\n\tthis._delay = 1;\n\tv2248 = v1361.isPaused == 0;\n\tif (v2248) goto L_01BB;\nL_FFFFFFFF:\n\tv1141 = 1;\n\tgoto L_01C1;\nL_01BB:\n\tv1141 = this._delay;\n\tv1326 = this._parent;\n\tv2357 = v1326.isPaused == 0;\n\tv2335 = ~v2357;\n\tif (v2335) goto L_01DF;\n\tCoffee.UIExtensions.UIParticleRenderer::Simulate(this, v883, 0);\nL_01DF:\n\tv2339 = UnityEngine.ParticleSystem+MainModule::get_loop(&v831 @ stack_-A8_v5 (UnityEngine.ParticleSystem+MainModule));\n\tv2359 = v2339 == 0;\n\tv2360 = ~v2359;\n\tif (v2360) goto L_020F;\n\tv887 = UnityEngine.ParticleSystem+MainModule::get_duration(&v831 @ stack_-A8_v5 (UnityEngine.ParticleSystem+MainModule));\n\tv888 = UnityEngine.ParticleSystem::get_time(this._particleSystem);\n\tv1021 = v887 == v888;\n\tv2430 = v887 < v888;\n\tv1084 = ~v2430;\n\tv2432 = ~v1021;\n\tv921 = v1084 & v2432;\n\tif (v921) goto L_020F;\n\tv2454 = UnityEngine.ParticleSystem::IsAlive(this._particleSystem);\n\tv2461 = v2454 == 0;\n\tv2462 = ~v2461;\n\tif (v2462) goto L_020E;\n\tv2396 = UnityEngine.ParticleSystem::get_particleCount(this._particleSystem);\n\tv2499 = v2396 == 0;\n\tv2397 = ~v2499;\n\tif (v2397) goto L_020F;\nL_020E:\n\tUnityEngine.ParticleSystem::Stop(this._particleSystem, 0);\nL_020F:\n\tthis._prevScale.x = v883;\n\tthis._prevScale.y = v883.y;\n\tthis._prevScale.z = v883.z;\n\tthis._prevPsPos.x = v884;\n\tthis._prevPsPos.y = v884.y;\n\tthis._prevPsPos.z = v884.z;\n\tthis._delay = 0;\nL_0226:\n\tv2051 = v2043.s_CombineInstances + 0x20;\n\tv1208 = UnityEngine.CombineInstance::get_mesh(v2051);\n\tUnityEngine.Mesh::Clear(v1208, 0);\n\tv2229 = v2219.s_CombineInstances + 0x20;\n\tv1209 = UnityEngine.CombineInstance::get_mesh(v2229);\n\tv2250 = UnityEngine.Mesh::get_bounds(v1209);\n\tv2254 = v285 & 0x7FFFFFFF;\n\tv2256 = v2254 < 0x7F800000;\n\tv2257 = ~v2256;\n\tv2258 = v2254 - 0x7F800000;\n\tv2260 = v2258 == 0;\n\tv2265 = ~v2260;\n\tv2266 = v2257 & v2265;\nL_FFFFFFFF:\n\t;\n\tif (v2266) goto L_02A5;\n\tv1128 = v285 - 1;\n\tv2268 = v285 & 0x7FFFFFFF;\n\tv2269 = v2268 - 0x800000;\n\tv756 = v2269 >> 0x18;\n\tv2281 = v285 < 0;\n\tif (v2281) goto L_FFFFFFFF;\n\tv2300 = v756 < 0x7E;\n\tv2347 = ~v2300;\n\tv2302 = v756 - 0x7E;\n\tv2344 = v2302 == 0;\n\tgoto L_0270;\nL_FFFFFFFF:\n\tv2344 = 0;\nL_FFFFFFFF:\n\tv2347 = 1;\n\tv2361 = v1128 < 0x7FFFFE;\n\tv1086 = ~v2361;\n\tv2363 = v1128 - 0x7FFFFE;\n\tv1023 = v2363 == 0;\n\tgoto L_0283;\nL_FFFFFFFF:\n\tv1023 = 0;\nL_FFFFFFFF:\n\tv1086 = 0;\n\tgoto L_0294;\nL_0294:\n\tv2449 = v2417.s_CombineInstances + 0x20;\n\tv1210 = UnityEngine.CombineInstance::get_mesh(v2449);\n\tUnityEngine.Mesh::RecalculateBounds(v1210);\nL_FFFFFFFF:\n\t;\nL_02A5:\n\tv924 = this._isTrail != 1;\n\tif (v924) goto L_02F0;\n\tv1331 = this._parent;\n\tv2350 = v1331.meshSharing < 3;\n\tv1088 = ~v2350;\n\tv1067 = v1331.meshSharing - 3;\n\tv1025 = v1067 == 0;\n\tv2351 = ~v1025;\n\tv925 = v1088 & v2351;\n\tif (v925) goto L_032A;\n\tv2314 = UnityEngine.ParticleSystem::get_particleCount(this._particleSystem);\n\tv926 = v2314 <= 0;\n\tif (v926) goto L_02E6;\n\tgoto L_02D8;\nL_02D8:\n\tv2455 = v2435.s_CombineInstances + 0x20;\n\tv1213 = UnityEngine.CombineInstance::get_mesh(v2455);\n\tUnityEngine.ParticleSystemRenderer::BakeTrailsMesh(this._renderer, v1213, bakeCamera, 1);\nL_FFFFFFFF:\n\t;\n\tgoto L_032A;\nL_02E6:\n\tv2423 = this._isTrail == 0;\n\tv2316 = ~v2423;\nL_FFFFFFFF:\n\t;\n\tif (v2316) goto L_032A;\nL_02F0:\n\tgoto L_02F3;\nL_02F3:\n\tv2355 = Coffee.UIParticleInternal.ParticleSystemExtensions::CanBakeMesh(this._renderer);\n\tv2386 = ~v2355;\n\tif (v2386) goto L_032A;\n\tgoto L_02FB;\nL_02FB:\n\tCoffee.UIParticleInternal.ParticleSystemExtensions::ValidateShape(this._particleSystem);\n\tgoto L_0303;\nL_0303:\n\tv2443 = v2442.s_CombineInstances == 0;\n\tv1280 = ~v2443;\n\tif (v1280) goto L_031B;\nL_FFFFFFFF:\n\tv242 = 0;\n\tgoto L_067A;\nL_031B:\n\tv2459 = v2442.s_CombineInstances + 0x20;\n\tv1216 = UnityEngine.CombineInstance::get_mesh(v2459);\n\tUnityEngine.ParticleSystemRenderer::BakeMesh(this._renderer, v1216, bakeCamera, 1);\nL_FFFFFFFF:\n\t;\nL_032A:\n\tgoto L_0334;\nL_0334:\n\tv2424 = v2401.s_CombineInstances + 0x20;\n\tv1217 = UnityEngine.CombineInstance::get_mesh(v2424);\n\tv2451 = UnityEngine.Mesh::get_vertexCount(v1217);\n\tv929 = v2451 < 0xFFFF;\nL_FFFFFFFF:\n\t;\n\tif (v929) goto L_03AC;\n\t// 844 NewArr v2467 @ X0_v212 (System.Object[]), typeof(System.Object[]), 3\n\tv726 = 0xB7D5000 + 0x538;\n\tv1218 = \"il2cpp_vm_object_box\"(*([v726 @ X23_v17 (System.Int32)+48]), &v770 @ stack_-100_v10 (UnityEngine.Bounds), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv2503 = 0x3175F18(v2467, v1218, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv2514 = 0x3175F50(v2467, 0, v1218, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbere\n// ... truncated")]
		public unsafe void UpdateMesh(Camera bakeCamera)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIParticleRenderer::UpdateMesh");
		}

		[Token(Token = "0x6000106")]
		[Address(RVA = "0x3F2AB54", Offset = "0x3F2AB54", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._materialForRendering = 0;\n\tUnityEngine.UI.Graphic::SetMaterialDirty(this);\n\treturn;\n")]
		public override void SetMaterialDirty()
		{
			_materialForRendering = null;
			base.SetMaterialDirty();
		}

		[Token(Token = "0x6000107")]
		[Address(RVA = "0x3F2AB88", Offset = "0x3F2AB88", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void UpdateGeometry()
		{
		}

		[Token(Token = "0x6000108")]
		[Address(RVA = "0x3F2AB8C", Offset = "0x3F2AB8C", Length = "0x228")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv118 = validRect == 0;\n\tgoto L_005B;\nL_FFFFFFFF:\n\tv118 = 1;\n\tv123 = Coffee.UIExtensions.UIParticleRenderer::get_rootCanvasRect(this);\n\tv382 = v123.width;\n\tv408 = v123.height;\n\tv173 = clipRect + clipRect.width;\n\tv174 = clipRect - v173;\n\tv175 = clipRect < v173;\n\tv176 = clipRect == v173;\n\tv179 = clipRect == clipRect;\n\tv180 = v173 == v173;\n\tv181 = v179 & v180;\n\tv182 = ~v181;\n\tv183 = v175 == v182;\n\tv184 = ~v176;\n\tv185 = v183 & v184;\n\tv186 = ~v185;\n\tif (v186) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv133 = v174;\n\tgoto L_0074;\nL_FFFFFFFF:\n\tv133 = clipRect.width;\nL_FFFFFFFF:\n\tv131 = v173;\n\tgoto L_007D;\nL_FFFFFFFF:\n\tv131 = clipRect;\nL_FFFFFFFF:\n\tv142 = v144;\n\tgoto L_008F;\nL_FFFFFFFF:\n\tv142 = clipRect.y;\nL_FFFFFFFF:\n\tv382 = v365;\n\tgoto L_00A2;\n\tgoto L_00AB;\nL_FFFFFFFF:\n\tv364 = v123;\nL_FFFFFFFF:\n\tv408 = v125;\n\tgoto L_00BE;\n\tgoto L_00C7;\nL_FFFFFFFF:\n\tv146 = v123.y;\n\tv442 = v364 < v163;\n\tgoto L_00E5;\nL_FFFFFFFF:\n\tv442 = 0;\n\tv154 = v161 < v142;\n\tv152 = v161 == v142;\n\tv449 = v161 == v161;\n\tv450 = v142 == v142;\n\tv451 = v449 & v450;\n\tv148 = ~v451;\n\tgoto L_00F5;\nL_FFFFFFFF:\n\tv148 = 0;\nL_FFFFFFFF:\n\tv152 = 1;\nL_FFFFFFFF:\n\tv154 = 0;\nL_00FC:\n\tv218 = UnityEngine.UI.Graphic::get_canvasRenderer(this);\n\tv187 = v218 == 0;\n\tv188 = ~v187;\nL_FFFFFFFF:\n\tv222 = 1;\n\tif (v188) goto L_0124;\n\tgoto L_0165;\nL_0101:\n\tv471 = clipRect.y - v144;\n\tv459 = clipRect.y < v144;\n\tv460 = clipRect.y == v144;\n\tv463 = clipRect.y == clipRect.y;\n\tv464 = v144 == v144;\n\tv465 = v463 & v464;\n\tv466 = ~v465;\n\tv467 = v459 == v466;\n\tv200 = ~v460;\n\tv468 = v467 & v200;\n\tv198 = ~v468;\n\tif (v198) goto L_FFFFFFFF;\n\tgoto L_0113;\nL_FFFFFFFF:\n\tv471 = clipRect.height;\nL_0124:\n\tv229 = UnityEngine.CanvasRenderer::get_cull(v218);\n\tv258 = v222 == v229;\n\tif (v258) goto L_0164;\n\tv266 = UnityEngine.UI.Graphic::get_canvasRenderer(this);\n\tUnityEngine.CanvasRenderer::set_cull(v266, v222);\n\tUnityEngine.UISystemProfilerApi::AddMarker(\"MaskableGraphic.cullingChanged\", this);\n\tUnityEngine.Events.UnityEvent`1<System.Boolean>::Invoke(this.onCullStateChanged, v222);\n\tv337 = UnityEngine.UI.Graphic::OnCullingChanged(v337);\n\treturn;\nL_0164:\n\treturn;\nL_0165:\n\tthrow System.NullReferenceException;\nL_002E:\n\tgoto L_0037;\nL_005B:\n\tif (v118) goto L_00FC;\nL_0074:\n\tv230 = v175 == v182;\n\tv231 = ~v176;\n\tv232 = v230 & v231;\n\tv233 = ~v232;\n\tif (v233) goto L_FFFFFFFF;\nL_007D:\n\tv144 = clipRect.y + clipRect.height;\n\tv294 = clipRect.y < v144;\n\tv295 = clipRect.y == v144;\n\tv298 = clipRect.y == clipRect.y;\n\tv299 = v144 == v144;\n\tv300 = v298 & v299;\n\tv301 = ~v300;\n\tv302 = v294 == v301;\n\tv303 = ~v295;\n\tv304 = v302 & v303;\n\tv305 = ~v304;\n\tif (v305) goto L_FFFFFFFF;\nL_008F:\n\tv364 = v382 + v123;\n\tv365 = v123 - v364;\n\tv366 = v123 < v364;\n\tv367 = v123 == v364;\n\tv370 = v123 == v123;\n\tv371 = v364 == v364;\n\tv372 = v370 & v371;\n\tv373 = ~v372;\n\tv374 = v366 == v373;\n\tv375 = ~v367;\n\tv376 = v374 & v375;\n\tv377 = ~v376;\n\tif (v377) goto L_00A2;\nL_00A2:\n\tv383 = v366 == v373;\n\tv384 = ~v367;\n\tv385 = v383 & v384;\n\tv386 = ~v385;\n\tif (v386) goto L_FFFFFFFF;\nL_00AB:\n\tv146 = v408 + v123.y;\n\tv125 = v123.y - v146;\n\tv394 = v123.y < v146;\n\tv395 = v123.y == v146;\n\tv398 = v123.y == v123.y;\n\tv399 = v146 == v146;\n\tv400 = v398 & v399;\n\tv401 = ~v400;\n\tv402 = v394 == v401;\n\tv403 = ~v395;\n\tv404 = v402 & v403;\n\tv405 = ~v404;\n\tif (v405) goto L_00BE;\nL_00BE:\n\tv409 = v394 == v401;\n\tv410 = ~v395;\n\tv411 = v409 & v410;\n\tv412 = ~v411;\n\tif (v412) goto L_FFFFFFFF;\nL_00C7:\n\tv165 = v364 + v382;\n\tv163 = v131 + v133;\n\tv161 = v146 + v408;\n\tv415 = v165 < v131;\n\tv416 = v165 == v131;\n\tv419 = v165 == v165;\n\tv420 = v131 == v131;\n\tv421 = v419 & v420;\n\tv422 = ~v421;\n\tv423 = v415 == v422;\n\tv424 = ~v416;\n\tv425 = v423 & v424;\n\tv426 = ~v425;\n\tif (v426) goto L_FFFFFFFF;\nL_00E5:\n\tv135 = ~v442;\n\tif (v135) goto L_FFFFFFFF;\nL_00F5:\n\tv457 = v154 == v148;\n\tv137 = ~v152;\n\tv140 = v457 & v137;\n\tif (v140) goto L_0101;\nL_0113:\n\tv227 = v142 + v471;\n\tv213 = v146 < v227;\n\tv202 = ~v213;\n\tv218 = UnityEngine.UI.Graphic::get_canvasRenderer(this);\nL_FFFFFFFF:\n\tv222 = v202;\nL_0037:\n\tv80 = this._lastBounds.m_Extents.z - v78.zero.z;\n\tv82 = this._lastBounds.extents - v78.zero;\n\tv83 = v82 * v82;\n\t// 59 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv84 = v80 * v80;\n\tv85 = v84 + v83;\n\tv89 = v85 < 0x2EDBE6FE;\n\tv97 = ~v89;\n\tv98 = ~v97;\n\tif (v98) goto L_FFFFFFFF;\n")]
		public override void Cull(Rect clipRect, bool validRect)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIParticleRenderer::Cull");
		}

		[Token(Token = "0x6000109")]
		[Address(RVA = "0x3F29940", Offset = "0x3F29940", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv139 = *([v173 @ X0_v5 (UnityEngine.Component)+DC]);\n\tv55 = *([v173 @ X0_v5 (UnityEngine.Component)+10C]) == 2;\n\tif (v55) goto L_003B;\n\tv141 = UnityEngine.Component::get_transform(v173);\n\tv87 = UnityEngine.Transform::get_localScale(v141);\n\tv167 = *([v173 @ X0_v5 (UnityEngine.Component)+DC]) * *([v173 @ X0_v5 (UnityEngine.Component)+154]);\n\tv139 = v167 * v87;\nL_FFFFFFFF:\n\tv173 = this._parent;\n\tv254 = UnityEngine.ParticleSystem::get_main(this._particleSystem);\n\tv69 = v254;\n\tv256 = UnityEngine.ParticleSystem+MainModule::get_scalingMode(&v69 @ stack_-48_v3 (UnityEngine.ParticleSystem+MainModule));\n\tv66 = v256 != 1;\n\tif (v66) goto L_FFFFFFFF;\n\tv267 = UnityEngine.UI.Graphic::get_canvas(this._parent);\n\tgoto L_006A;\nL_006A:\n\tv262 = UnityEngine.Object::op_Implicit(v267);\n\tv264 = ~v262;\n\tif (v264) goto L_FFFFFFFF;\n\tv146 = UnityEngine.UI.Graphic::get_canvas(this._parent);\n\tv147 = UnityEngine.Canvas::get_rootCanvas(v146);\n\tv148 = UnityEngine.Component::get_transform(v147);\n\tv277 = UnityEngine.Transform::get_localScale(v148);\n\tv188 = v88 * v277;\nL_FFFFFFFF:\n\treturnVal2 = v188;\n\tgoto L_009B;\nL_FFFFFFFF:\n\treturnVal2 = v88;\nL_0016:\n\tv173 = this._parent;\nL_003B:\n\tv88 = v139 * *([v173 @ X0_v5 (UnityEngine.Component)+148]);\n\tv65 = *([v173 @ X0_v5 (UnityEngine.Component)+10C]) != 1;\nL_FFFFFFFF:\n\treturnVal2 = v88;\n\tif (v65) goto L_009B;\nL_009B:\n\treturn returnVal2;\n")]
		private Vector3 GetWorldScale()
		{
			//IL_0015: Expected F4, but got I
			Component parent = _parent;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v5 (UnityEngine.Component)+DC]");
			float num = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v5 (UnityEngine.Component)+10C]");
			if ((nint)0 != 2)
			{
				Transform transform = parent.transform;
				Vector3 localScale = transform.localScale;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v5 (UnityEngine.Component)+DC]");
				float num2 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v5 (UnityEngine.Component)+154]");
				float num3 = num2 * 0f;
				num = num3 * localScale.x;
				parent = _parent;
			}
			float num4 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v5 (UnityEngine.Component)+148]");
			float num5 = num4 * 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v5 (UnityEngine.Component)+10C]");
			bool flag = (nint)0 != 1;
			Vector3 result = default(Vector3);
			result.x = num5;
			if (!flag)
			{
				ParticleSystem.MainModule main = _particleSystem.main;
				ParticleSystem.MainModule mainModule = main;
				ParticleSystemScalingMode scalingMode = mainModule.scalingMode;
				if (scalingMode == ParticleSystemScalingMode.Local)
				{
					Canvas canvas = _parent.canvas;
					if ((bool)canvas)
					{
						Canvas canvas2 = _parent.canvas;
						Canvas rootCanvas = canvas2.rootCanvas;
						Transform transform2 = rootCanvas.transform;
						float x = num5 * transform2.localScale.x;
						result.x = x;
						goto IL_01fb;
					}
				}
				result.x = num5;
			}
			goto IL_01fb;
			IL_01fb:
			return result;
		}

		[Token(Token = "0x600010A")]
		[Address(RVA = "0x3F2A2FC", Offset = "0x3F2A2FC", Length = "0x458")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv348 = v327.y;\n\tv346 = v327.z;\n\tgoto L_002A;\nL_002A:\n\tgoto L_002C;\nL_002C:\n\tv83 = Coffee.UIParticleInternal.ParticleSystemExtensions::GetActualSimulationSpace(this._particleSystem);\n\tv100 = this._isTrail == 1;\n\tv158 = v83;\n\tif (v100) goto L_005E;\n\tv158 = v83;\n\tgoto L_006B;\nL_005E:\n\tv169 = UnityEngine.ParticleSystem::get_trails(this._particleSystem);\n\tv153 = v169;\n\tv151 = UnityEngine.ParticleSystem+TrailModule::get_worldSpace(&v153 @ stack_-78_v8 (UnityEngine.ParticleSystem+TrailModule));\n\tv289 = v151 == 0;\n\tv156 = ~v289;\n\tif (v156) goto L_008D;\nL_006B:\n\tv163 = v158 == 2;\n\tif (v163) goto L_00CA;\n\tv236 = v158 == 1;\n\tif (v236) goto L_008D;\n\tv269 = v158 == 0;\n\tv258 = ~v269;\n\tif (v258) goto L_0229;\n\tgoto L_00DA;\nL_008D:\n\tv181 = this._isTrail != 1;\n\tif (v181) goto L_011C;\nL_0095:\n\tv317 = UnityEngine.Matrix4x4::Translate(v327);\n\tv360 = UnityEngine.Matrix4x4::Scale(scale);\n\tv454 = v311;\n\tv607 = v354;\n\tv419 = UnityEngine.Matrix4x4::op_Multiply(&v454 @ stack_-180_v8 (UnityEngine.Matrix4x4), &v607 @ stack_-1C0_v4 (System.Single));\n\tv462 = v419.m00;\n\tv699 = -v327;\n\tv712 = -v348;\n\tv657 = -v346;\n\tgoto L_01DF;\nL_00CA:\n\tv287 = UnityEngine.ParticleSystem::get_main(this._particleSystem);\n\tv208 = v287;\n\tv200 = UnityEngine.ParticleSystem+MainModule::get_customSimulationSpace(&v208 @ stack_-80_v8 (UnityEngine.ParticleSystem+MainModule));\n\tv424 = UnityEngine.Transform::get_position(v200);\n\tv328 = scale * v424;\n\tv348 = scale.y * v424.y;\n\tv346 = scale.z * v424.z;\nL_011C:\n\tgoto L_011F;\nL_011F:\n\tv363 = UnityEngine.Object::op_Implicit(this._mainEmitter);\n\tv420 = ~v363;\n\tif (v420) goto L_0143;\n\tgoto L_012B;\nL_012B:\n\tgoto L_012F;\nL_012F:\n\tgoto L_0131;\nL_0131:\n\tv301 = Coffee.UIParticleInternal.ParticleSystemExtensions::GetActualSimulationSpace(this._mainEmitter);\n\tv982 = v301 == 0;\n\tv304 = ~v982;\n\tif (v304) goto L_016F;\n\tgoto L_0095;\nL_0143:\n\treturnVal2 = UnityEngine.Matrix4x4::Scale(scale);\n\tgoto L_0226;\nL_016F:\n\tv202 = UnityEngine.Component::get_transform(this._particleSystem);\n\tv173 = UnityEngine.Transform::get_position(v202);\n\tv204 = UnityEngine.Component::get_transform(this._mainEmitter);\n\tv987 = UnityEngine.Transform::get_position(v204);\n\tv710 = v173 - v987;\n\tv709 = v173.y - v987.y;\n\tv708 = v173.z - v987.z;\n\t// 396 MakeStruct v664 @ AGG3F2A65C_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v710 @ V11_v9 (System.Single), v709 @ V12_v9 (System.Single), v708 @ V13_v9 (System.Single)\n\tv995 = UnityEngine.Matrix4x4::Translate(v664);\n\tv1017 = UnityEngine.Matrix4x4::Scale(scale);\n\tv454 = v701;\n\tv607 = v698;\n\tv705 = UnityEngine.Matrix4x4::op_Multiply(&v454 @ stack_-180_v8 (UnityEngine.Matrix4x4), &v607 @ stack_-1C0_v4 (System.Single));\n\tv462 = v705.m00;\n\tv699 = -v710;\n\tv712 = -v709;\n\tv657 = -v708;\nL_0229:\n\tv267 = 0xB292000 + 0x4A0;\n\tv290 = new v267();\n\tSystem.NotSupportedException::.ctor(v290);\n\tthrow v290;\nL_00DA:\n\t// 218 MakeStruct v351 @ AGG3F2A4E0_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v328 @ V0_v34 (System.Single), v348 @ V1_v28 (System.Single), v346 @ V2_v16 (System.Single)\n\tv352 = UnityEngine.Matrix4x4::Translate(v351);\n\tv391 = UnityEngine.Matrix4x4::Scale(scale);\n\tv462 = v329;\n\tv454 = v391;\n\tv629 = &v454 @ stack_-180_v8 (UnityEngine.Matrix4x4);\n\tv640 = &v462 @ stack_-140_v8 (System.Single);\n\tgoto L_0205;\nL_01DF:\n\t// 479 MakeStruct v501 @ AGG3F2A6C0_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v699 @ V0_v5, v712 @ V1_v6, v657 @ V2_v6\n\tv715 = UnityEngine.Matrix4x4::Translate(v501);\n\tv607 = v462;\n\tv515 = v715.m00;\n\tv629 = &v515 @ stack_-200_v3 (System.Single);\n\tv640 = &v607 @ stack_-1C0_v4 (System.Single);\nL_0205:\n\treturnVal2 = UnityEngine.Matrix4x4::op_Multiply(v640, v629);\nL_0226:\n\treturn returnVal2;\n")]
		private unsafe Matrix4x4 GetWorldMatrix(Vector3 psPos, Vector3 scale)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIParticleRenderer::GetWorldMatrix");
			return default;
		}

		[Token(Token = "0x600010B")]
		[Address(RVA = "0x3F29ADC", Offset = "0x3F29ADC", Length = "0x488")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0039;\nL_004A:\n\tgoto L_004E;\nL_004E:\n\tgoto L_0050;\nL_0050:\n\tv133 = Coffee.UIParticleInternal.ParticleSystemExtensions::GetActualSimulationSpace(this._particleSystem);\n\tv143 = this._parent == 0;\n\tv144 = ~v143;\n\tif (v144) goto L_0072;\n\tgoto L_01DF;\nL_0072:\n\tv158 = UnityEngine.UI.Graphic::get_canvas(this._parent);\n\tgoto L_0078;\nL_0078:\n\tv388 = UnityEngine.Object::op_Implicit(v158);\n\tv468 = ~v388;\n\tv469 = ~v468;\nL_FFFFFFFF:\n\tv519 = 1f;\n\tif (v469) goto L_00E9;\n\tv294 = this + 0x13C;\n\tv290 = v90 | v95;\n\tv493 = this._prevScreenSize != v290;\nL_FFFFFFFF:\n\tv289 = v290;\nL_FFFFFFFF:\n\tv292 = v294;\n\tif (v493) goto L_0107;\nL_0094:\n\tgoto L_009A;\n\tgoto L_00B3;\nL_FFFFFFFF:\n\tv648 = v618;\n\tgoto L_00C7;\nL_FFFFFFFF:\n\tv573 = v599;\n\tgoto L_01AA;\nL_00E9:\n\tv328 = UnityEngine.UI.Graphic::get_canvas(this._parent);\n\tv497 = UnityEngine.Canvas::get_scaleFactor(v328);\n\tv294 = this + 0x13C;\n\tv290 = v90 | v95;\n\tv508 = this._prevScreenSize == v290;\nL_FFFFFFFF:\n\tv519 = v497;\nL_FFFFFFFF:\n\tv289 = v290;\nL_FFFFFFFF:\n\tv292 = v294;\n\tif (v508) goto L_0094;\nL_0107:\n\tv565 = v133 != 1;\nL_FFFFFFFF:\n\tv596 = 0;\nL_FFFFFFFF:\n\tv290 = v289;\nL_FFFFFFFF:\n\tv294 = v292;\n\tif (v565) goto L_01AA;\nL_010A:\n\tv601 = v596 == 0;\n\tv602 = ~v601;\nL_FFFFFFFF:\n\tv290 = v289;\nL_FFFFFFFF:\n\tv294 = v292;\n\tif (v602) goto L_01AA;\n\tv228 = this._isPrevStored != 1;\nL_FFFFFFFF:\n\tv290 = v289;\nL_FFFFFFFF:\n\tv294 = v292;\n\tif (v228) goto L_01AA;\n\tv641 = UnityEngine.ParticleSystem::get_particleCount(this._particleSystem);\n\tgoto L_0128;\nL_0128:\n\tv679 = Coffee.UIParticleInternal.ParticleSystemExtensions::GetParticleArray(v641);\n\tv331 = UnityEngine.ParticleSystem::GetParticles(this._particleSystem, v679, v641);\n\tv695 = Coffee.UIParticleInternal.Vector3Extensions::Inverse(scale);\n\t// 318 MakeStruct v186 @ AGG3F29DC4_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this._prevPsPos (UnityEngine.Vector3), this._prevPsPos.y (System.Single), this._prevPsPos.z (System.Single)\n\tv208 = Coffee.UIParticleInternal.Vector3Extensions::Inverse(v186);\n\tv229 = v641 < 1;\n\tif (v229) goto L_019D;\n\tv178 = psPos * v695;\n\tv174 = psPos.y * v695.y;\n\tv169 = psPos.z * v695.z;\n\tv726 = v178 * v208;\n\tv727 = v174 * v208.y;\n\tv728 = v169 * v208.z;\n\tv220 = this._prevScale * v726;\n\tv296 = this._prevScale.y * v727;\n\tv361 = v728 * this._prevScale.z;\n\tv321 = v679 + 0x20;\nL_FFFFFFFF:\n\tv343 = 0;\nL_016E:\n\tv759 = 0x8BF6A34(&v87 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle), v321, 0x84, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv773 = UnityEngine.ParticleSystem+Particle::get_position(&v87 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle));\n\tv705 = v220 * v773;\n\tv723 = v296 * v773.y;\n\tv722 = v361 * v773.z;\n\t// 377 MakeStruct v703 @ AGG3F29E50_1_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v705 @ V0_v20 (System.Single), v723 @ V1_v14 (System.Single), v722 @ V2_v14 (System.Single)\n\tUnityEngine.ParticleSystem+Particle::set_position(&v87 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle), v703);\n\tv718 = 0x8BF6A34(v321, &v87 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle), 0x84, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv343 = v343 + 1;\n\tv321 = v321 + 0x84;\n\tv706 = v641 != v343;\n\tif (v706) goto L_016E;\nL_019D:\n\tUnityEngine.ParticleSystem::SetParticles(this._particleSystem, v679, v641);\n\tthis._delay = 1;\n\tthis._prevScale.x = scale;\n\tthis._prevScale.y = scale.y;\n\tthis._prevScale.z = scale.z;\n\tthis._prevPsPos.x = psPos;\n\tthis._prevPsPos.y = psPos.y;\n\tthis._prevPsPos.z = psPos.z;\n\tthis._isPrevStored = 1;\nL_FFFFFFFF:\n\tv290 = v289;\nL_FFFFFFFF:\n\tv294 = v292;\nL_01B0:\n\tv634 = UnityEngine.Object::op_Implicit(v617);\n\tv643 = ~v634;\n\tv644 = ~v643;\n\tif (v644) goto L_01C1;\nL_FFFFFFFF:\n\tv409 = 1f;\n\tgoto L_01C6;\nL_01C1:\n\tv333 = UnityEngine.UI.Graphic::get_canvas(this);\n\tv409 = UnityEngine.Canvas::get_scaleFactor(v333);\nL_01C6:\n\tthis._prevCanvasScale = v409;\n\t*([v294 @ X24_v2]) = v290;\n\treturn;\nL_01DF:\n\tthrow System.NullReferenceException;\nL_0039:\n\tv87 = 0;\n\tv90 = UnityEngine.Screen::get_width();\n\tv95 = UnityEngine.Screen::get_height();\n\tgoto L_004A;\nL_009A:\n\tv648 = UnityEngine.Mathf::Abs(this._prevCanvasScale);\n\tv618 = UnityEngine.Mathf::Abs(v519);\n\tv621 = v648 < v618;\n\tv622 = v648 == v618;\n\tv625 = v648 == v648;\n\tv626 = v618 == v618;\n\tv627 = v625 & v626;\n\tv628 = ~v627;\n\tv629 = v621 == v628;\n\tv630 = ~v622;\n\tv631 = v629 & v630;\n\tv632 = ~v631;\n\tif (v632) goto L_FFFFFFFF;\nL_00B3:\n\tv573 = v648 * 0x358637BD;\n\tv599 = v650.Epsilon * 8f;\n\tv656 = v573 < v599;\n\tv657 = v573 == v599;\n\tv660 = v573 == v573;\n\tv661 = v599 == v599;\n\tv662 = v660 & v661;\n\tv663 = ~v662;\n\tv664 = v656 == v663;\n\tv575 = ~v657;\n\tv577 = v664 & v575;\n\tv574 = ~v577;\n\tif (v574) goto L_FFFFFFFF;\nL_00C7:\n\t// 199 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv683 = v599 < v573;\n\tv587 = v133 == 1;\nL_FFFFFFFF:\n\tv289 = v290;\nL_FFFFFFFF:\n\tv292 = v294;\nL_FFFFFFFF:\n\tv596 = v683;\n\tif (v587) goto L_010A;\nL_01AA:\n\tv617 = UnityEngine.UI.Graphic::get_canvas(this);\n\tgoto L_01B0;\n")]
		private void ResolveResolutionChange(Vector3 psPos, Vector3 scale)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIParticleRenderer::ResolveResolutionChange");
		}

		[Token(Token = "0x600010C")]
		[Address(RVA = "0x3F29F64", Offset = "0x3F29F64", Length = "0x398")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\nL_002C:\n\tv73 = UnityEngine.ParticleSystem::get_main(this._particleSystem);\n\tv266 = v73;\n\tv322 = paused == 0;\n\tv323 = ~v322;\n\tv260 = 0;\n\tif (v323) goto L_003E;\n\tv326 = UnityEngine.ParticleSystem+MainModule::get_useUnscaledTime(&v266 @ stack_-88_v2 (UnityEngine.ParticleSystem+MainModule));\n\tv332 = v326 == 0;\n\tif (v332) goto L_003D;\n\tv260 = UnityEngine.Time::get_unscaledDeltaTime();\n\tgoto L_003E;\nL_003D:\n\tv260 = UnityEngine.Time::get_deltaTime();\nL_003E:\n\tv292 = this._parent;\n\tv254 = v260 * v292.timeScaleMultiplier;\n\tv438 = v254 < 0;\n\tv439 = v254 == 0;\n\tv442 = v254 == v254;\n\tv443 = ~v442;\n\tv444 = v438 == v443;\n\tv445 = ~v444;\n\tv446 = v445 | v439;\n\tif (v446) goto L_0064;\n\tv457 = this._preWarm != 1;\n\tif (v457) goto L_0064;\n\tv459 = UnityEngine.ParticleSystem+MainModule::get_duration(&v266 @ stack_-88_v2 (UnityEngine.ParticleSystem+MainModule));\n\tv254 = v254 + v459;\n\tthis._preWarm = 0;\nL_0069:\n\tgoto L_006D;\nL_006D:\n\tgoto L_006F;\nL_006F:\n\tv497 = Coffee.UIParticleInternal.ParticleSystemExtensions::GetActualSimulationSpace(this._particleSystem);\n\tv503 = this._particleSystem == 0;\n\tv285 = ~v503;\n\tif (v285) goto L_0092;\n\tgoto L_016C;\nL_0092:\n\tv279 = UnityEngine.Component::get_transform(this._particleSystem);\n\tv509 = UnityEngine.Transform::get_localPosition(v279);\n\tv514 = UnityEngine.Transform::get_localRotation(v279);\n\tv520 = UnityEngine.Transform::get_position(v279);\n\tv262 = UnityEngine.Transform::get_rotation(v279);\n\tv525 = UnityEngine.ParticleSystem::get_emission(this._particleSystem);\n\tv161 = v525;\n\tv528 = UnityEngine.ParticleSystem+EmissionModule::get_enabled(&v161 @ stack_-90_v3 (UnityEngine.ParticleSystem+EmissionModule));\n\tv529 = ~v528;\n\tif (v529) goto L_012A;\n\tv533 = UnityEngine.ParticleSystem+EmissionModule::get_rateOverDistance(&v161 @ stack_-90_v3 (UnityEngine.ParticleSystem+EmissionModule));\n\tv126 = v533;\n\tv555 = UnityEngine.ParticleSystem+MinMaxCurve::get_constant(&v126 @ stack_-B0_v4 (UnityEngine.ParticleSystem+MinMaxCurve));\n\tv551 = v555 < 0;\n\tv549 = v555 == 0;\n\tv545 = v555 == v555;\n\tv543 = ~v545;\n\tv586 = v551 == v543;\n\tv587 = ~v586;\n\tv541 = v587 | v549;\n\tv528 = &v126 @ stack_-B0_v4 (UnityEngine.ParticleSystem+MinMaxCurve);\n\tif (v541) goto L_012A;\n\tv556 = UnityEngine.ParticleSystem+EmissionModule::get_rateOverDistanceMultiplier(&v161 @ stack_-90_v3 (UnityEngine.ParticleSystem+EmissionModule));\n\tv552 = v556 < 0;\n\tv550 = v556 == 0;\n\tv546 = v556 == v556;\n\tv544 = ~v546;\n\tv591 = v552 == v544;\n\tv592 = ~v591;\n\tv542 = v592 | v550;\n\tv528 = &v161 @ stack_-90_v3 (UnityEngine.ParticleSystem+EmissionModule);\n\tif (v542) goto L_012A;\n\tv599 = paused == 0;\n\tv565 = ~v599;\n\tv528 = &v161 @ stack_-90_v3 (UnityEngine.ParticleSystem+EmissionModule);\n\tif (v565) goto L_012A;\n\tv226 = this._isPrevStored != 1;\n\tv528 = &v161 @ stack_-90_v3 (UnityEngine.ParticleSystem+EmissionModule);\n\tif (v226) goto L_012A;\n\tv317 = this._prevPsPos.y;\n\tv312 = this._prevPsPos.z;\n\tv604 = v497 == 0;\n\tv615 = this._prevPsPos;\n\tif (v604) goto L_011E;\n\t// 265 MakeStruct v611 @ AGG3F2A1DC_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this._prevScale (UnityEngine.Vector3), this._prevScale.y (System.Single), this._prevScale.z (System.Single)\n\tv612 = Coffee.UIParticleInternal.Vector3Extensions::Inverse(v611);\n\tv615 = this._prevPsPos * v612;\n\tv626 = this._prevPsPos.y * v612.y;\n\tv618 = this._prevPsPos.z * v612.z;\n\tv312 = v618;\n\tv317 = v626;\n\tUnityEngine.ParticleSystem::Simulate(this._particleSystem, 0f, 0, 0, 0);\n\tv528 = this._particleSystem;\nL_012A:\n\tv569 = v497 == 0;\n\tv303 = v520.z;\n\tv306 = v520.y;\n\tv579 = v520;\n\tif (v569) goto L_013F;\n\tv575 = Coffee.UIParticleInternal.Vector3Extensions::Inverse(scale);\n\tv579 = v520 * v575;\n\tv306 = v520.y * v575.y;\n\tv303 = v520.z * v575.z;\n\tUnityEngine.ParticleSystem::Simulate(this._particleSystem, v254, 0, 0, 0);\n\tUnityEngine.Transform::set_localPosition(v279, v509);\n\tUnityEngine.Transform::set_localRotation(v279, v514);\n\treturn;\nL_016C:\n\tthrow System.NullReferenceException;\nL_0064:\n\tgoto L_0069;\nL_011E:\n\t// 286 MakeStruct v86 @ AGG3F2A220_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v615 @ V3_v8 (System.Single), v317 @ V1_v17 (System.Single), v312 @ V2_v15 (System.Single)\n\tUnityEngine.Transform::SetPositionAndRotation(v279, v86, v262);\nL_013F:\n\t// 319 MakeStruct v79 @ AGG3F2A284_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v579 @ V8_v6 (System.Single), v306 @ V9_v4 (System.Single), v303 @ V10_v4 (System.Single)\n\tUnityEngine.Transform::SetPositionAndRotation(v279, v79, v262);\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void Simulate(Vector3 scale, bool paused)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIParticleRenderer::Simulate");
		}

		[Token(Token = "0x600010D")]
		[Address(RVA = "0x3F2A754", Offset = "0x3F2A754", Length = "0x254")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv52 = v47.m_AnimatableProperties;\n\tv174 = v52.Length == 0;\n\tif (v174) goto L_00D3;\n\tv133 = 0xB295000 + 0xCB8;\n\tgoto L_002D;\nL_002D:\n\tv219 = v217.s_Mpb == 0;\n\tif (v219) goto L_0041;\n\tv164 = this._renderer;\n\tgoto L_0033;\nL_0033:\n\tv278 = v164 == 0;\n\tv146 = ~v278;\n\tif (v146) goto L_005F;\n\tgoto L_00A9;\nL_0041:\n\tv269 = new UnityEngine.MaterialPropertyBlock();\n\tUnityEngine.MaterialPropertyBlock::.ctor(v269);\n\tgoto L_004E;\nL_005F:\n\tUnityEngine.Renderer::GetPropertyBlock(v164, v288.s_Mpb);\n\tv196 = UnityEngine.MaterialPropertyBlock::get_isEmpty(v157.s_Mpb);\n\tv303 = v196 == 0;\n\tv200 = ~v303;\n\tif (v200) goto L_00D3;\n\tv308 = Coffee.UIExtensions.UIParticleRenderer::get_materialForRendering(this);\n\tgoto L_0077;\nL_0077:\n\tv197 = UnityEngine.Object::op_Implicit(v308);\n\tv201 = ~v197;\n\tif (v201) goto L_00D3;\n\tv319 = this._parent;\n\tv110 = 0;\n\tv64 = v110 >= v159.Length;\n\tif (v64) goto L_00AA;\n\tv324 = Coffee.UIExtensions.UIParticleRenderer::get_materialForRendering(this);\n\tgoto L_00A3;\nL_00A3:\n\tCoffee.UIExtensions.AnimatableProperty::UpdateMaterialProperties(v159[v110 @ X23_v6 (System.Int32)], v324, v330.s_Mpb);\n\tv319 = this._parent;\n\tv110 = v110 + 1;\n\tv331 = this._parent == 0;\n\tv145 = ~v331;\n\tif (v145) goto L_007E;\nL_00A9:\n\tthrow System.NullReferenceException;\nL_00AA:\n\tv215 = *([v133 @ X22_v7 (System.Int32)]);\n\tgoto L_00B1;\n\tUnityEngine.MaterialPropertyBlock::Clear(*([v161 @ X8_v6+10]));\n\treturn;\nL_00D3:\n\treturn;\nL_001C:\n\tv47 = this._parent;\nL_004E:\n\tv298.s_Mpb = v269;\n\tv164 = this._renderer;\n\tgoto L_0033;\nL_007E:\n\tv159 = v319.m_AnimatableProperties;\nL_00B1:\n\tv161 = *([v215 @ X0_v4+B8]);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateMaterialProperties()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIParticleRenderer::UpdateMaterialProperties");
		}

		[Token(Token = "0x600010E")]
		[Address(RVA = "0x3F2ADB4", Offset = "0x3F2ADB4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.UI.MaskableGraphic::.ctor(this);\n\treturn;\n")]
		public UIParticleRenderer()
		{
		}

		[Token(Token = "0x600010F")]
		[Address(RVA = "0x3F2ADBC", Offset = "0x3F2ADBC", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tSystem.Collections.Generic.List`1<UnityEngine.Material>::.ctor(v70, 2);\n\tv80.s_Materials = v70;\n\t// 65 NewArr v86 @ X0_v12 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), 4\n\tv89.s_Corners = v86;\n\treturn;\nL_002D:\n\t// 45 NewArr v58 @ X0_v3 (UnityEngine.CombineInstance[]), typeof(UnityEngine.CombineInstance[]), 1\n\tv64.s_CombineInstances = v58;\n\tv70 = new System.Collections.Generic.List`1<UnityEngine.Material>();\n")]
		static UIParticleRenderer()
		{
			CombineInstance[] array = new CombineInstance[1];
			s_CombineInstances = array;
			List<Material> list = new List<Material>(2);
			s_Materials = list;
			Vector3[] array2 = new Vector3[4];
			s_Corners = array2;
		}
	}
}
