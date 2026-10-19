using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Unco.UIParticleSystem
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(CanvasRenderer), typeof(ParticleSystem))]
	[AddComponentMenu("UI/Effects/Extensions/UIParticleSystem")]
	[Token(Token = "0x2000010")]
	public class UIParticleSystem : MaskableGraphic
	{
		[Tooltip("Having this enabled run the system in LateUpdate rather than in Update making it faster but less precise (more clunky)")]
		[Token(Token = "0x400005B")]
		[FieldOffset(Offset = "0xD8")]
		public bool fixedTime;

		[Token(Token = "0x400005C")]
		[FieldOffset(Offset = "0xE0")]
		private Transform _transform;

		[Token(Token = "0x400005D")]
		[FieldOffset(Offset = "0xE8")]
		private ParticleSystem pSystem;

		[Token(Token = "0x400005E")]
		[FieldOffset(Offset = "0xF0")]
		private ParticleSystem.Particle[] particles;

		[Token(Token = "0x400005F")]
		[FieldOffset(Offset = "0xF8")]
		private UIVertex[] _quad;

		[Token(Token = "0x4000060")]
		[FieldOffset(Offset = "0x100")]
		private Vector4 imageUV;

		[Token(Token = "0x4000061")]
		[FieldOffset(Offset = "0x110")]
		private ParticleSystem.TextureSheetAnimationModule textureSheetAnimation;

		[Token(Token = "0x4000062")]
		[FieldOffset(Offset = "0x118")]
		private int textureSheetAnimationFrames;

		[Token(Token = "0x4000063")]
		[FieldOffset(Offset = "0x11C")]
		private Vector2 textureSheetAnimationFrameSize;

		[Token(Token = "0x4000064")]
		[FieldOffset(Offset = "0x128")]
		private ParticleSystemRenderer pRenderer;

		[Token(Token = "0x4000065")]
		[FieldOffset(Offset = "0x130")]
		private Material currentMaterial;

		[Token(Token = "0x4000066")]
		[FieldOffset(Offset = "0x138")]
		private Texture currentTexture;

		[Token(Token = "0x4000067")]
		[FieldOffset(Offset = "0x140")]
		private ParticleSystem.MainModule mainModule;

		[Token(Token = "0x17000004")]
		public override Texture mainTexture
		{
			[Token(Token = "0x600002F")]
			[Address(RVA = "0x81C0748", Offset = "0x81C0748", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mainTexture;\n")]
			get
			{
				return currentTexture;
			}
		}

		[Token(Token = "0x6000030")]
		[Address(RVA = "0x81C0750", Offset = "0x81C0750", Length = "0x5CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tgoto L_001D;\nL_001D:\n\tv66 = UnityEngine.Object::op_Equality(this._transform, 0);\n\tv77 = ~v66;\n\tv78 = ~v77;\n\tif (v78) goto L_0065;\n\tv257 = this + 0xE8;\n\tv120 = this.pSystem;\n\tgoto L_002B;\nL_002B:\n\tv132 = UnityEngine.Object::op_Equality(v120, 0);\n\tv147 = ~v132;\n\tv148 = ~v147;\n\tif (v148) goto L_007D;\n\tv253 = this + 0xF0;\n\tv170 = this.particles == 0;\n\tif (v170) goto L_016F;\nL_0036:\n\tthis.imageUV = *([9246290]);\n\tv282 = this.pSystem;\n\tv237 = this.pSystem == 0;\n\tv238 = ~v237;\n\tif (v238) goto L_0184;\n\tgoto L_01C3;\nL_0065:\n\tv111 = UnityEngine.Component::get_transform(this);\n\tthis._transform = v111;\n\tv257 = this + 0xE8;\n\tv120 = this.pSystem;\n\tgoto L_002B;\nL_007D:\n\tv183 = UnityEngine.Component::GetComponent(this);\n\tthis.pSystem = v183;\n\tgoto L_008A;\nL_008A:\n\tv361 = UnityEngine.Object::op_Equality(this.pSystem, 0);\n\tv431 = v361 == 0;\n\tif (v431) goto L_00A6;\n\treturn 0;\nL_00A6:\n\tv457 = UnityEngine.ParticleSystem::get_main(*([v257 @ X20_v9]));\n\tthis.mainModule = v457;\n\tv480 = UnityEngine.ParticleSystem::get_main(this.pSystem);\n\tv286 = v480;\n\tv484 = UnityEngine.ParticleSystem+MainModule::get_maxParticles(&v286 @ stack_-48_v4 (UnityEngine.ParticleSystem+MainModule));\n\tv192 = v484 < 0x36B1;\n\tif (v192) goto L_00CB;\n\tUnityEngine.ParticleSystem+MainModule::set_maxParticles(&this.mainModule (UnityEngine.ParticleSystem+MainModule), 0x36B0);\nL_00CB:\n\tv496 = UnityEngine.Component::GetComponent(*([v257 @ X20_v9]));\n\tthis.pRenderer = v496;\n\tgoto L_00D7;\nL_00D7:\n\tv504 = UnityEngine.Object::op_Inequality(this.pRenderer, 0);\n\tv508 = ~v504;\n\tv509 = ~v508;\n\tif (v509) goto L_00EA;\n\tgoto L_00EF;\nL_00EA:\n\tUnityEngine.Renderer::set_enabled(this.pRenderer, 0);\nL_00EF:\n\tv528 = UnityEngine.UI.Graphic::get_material(this);\n\tgoto L_00FB;\n\tv547 = UnityEngine.Shader::Find(\"UI Extensions/Particles/Alpha Blended\");\n\tv571 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v571, v547);\n\tv555 = UnityEngine.UI.Graphic::set_material(this, v571);\nL_0121:\n\tv577 = UnityEngine.Object::op_Implicit(this.currentMaterial);\n\tv582 = ~v577;\n\tv583 = ~v582;\n\tif (v583) goto L_0135;\n\tgoto L_015B;\nL_0135:\n\tv599 = UnityEngine.Material::HasProperty(this.currentMaterial, \"_MainTex\");\n\tv605 = ~v599;\n\tif (v605) goto L_015B;\n\tv621 = UnityEngine.Material::get_mainTexture(this.currentMaterial);\n\tthis.mainTexture = v621;\n\tgoto L_014D;\n\tv634 = UnityEngine.Texture2D::get_whiteTexture();\n\tthis.mainTexture = v634;\nL_015B:\n\tv612 = UnityEngine.UI.Graphic::set_material(this, this.currentMaterial);\n\tUnityEngine.ParticleSystem+MainModule::set_scalingMode(&this.mainModule (UnityEngine.ParticleSystem+MainModule), 0);\n\tthis.particles = 0;\n\tv253 = this + 0xF0;\n\tv619 = this.particles == 0;\n\tv230 = ~v619;\n\tv257 = v257;\n\tif (v230) goto L_0036;\nL_016F:\n\tv295 = UnityEngine.ParticleSystem::get_main(*([v257 @ X20_v9]));\n\tv286 = v295;\n\tv357 = UnityEngine.ParticleSystem+MainModule::get_maxParticles(&v286 @ stack_-48_v4 (UnityEngine.ParticleSystem+MainModule));\n\t// 376 NewArr v374 @ X0_v29 (Particle[]), typeof(Particle[]), v357 @ X0_v27 (System.Int32)\n\t*([v253 @ X21_v6]) = v374;\n\tthis.imageUV = *([9246290]);\n\tv282 = this.pSystem;\nL_0184:\n\tv293 = UnityEngine.ParticleSystem::get_textureSheetAnimation(v282);\n\tthis.textureSheetAnimation = v293;\n\tthis.textureSheetAnimationFrames = 0;\n\tgoto L_019B;\n\tv460 = UnityEngine.ParticleSystem+TextureSheetAnimationModule::get_numTilesX(&this.textureSheetAnimation (UnityEngine.ParticleSystem+TextureSheetAnimationModule));\n\tv475 = UnityEngine.ParticleSystem+TextureSheetAnimationModule::get_numTilesY(&this.textureSheetAnimation (UnityEngine.ParticleSystem+TextureSheetAnimationModule));\n\tv467 = v475 * v460;\n\tthis.textureSheetAnimationFrames = v467;\n\tv478 = UnityEngine.ParticleSystem+TextureSheetAnimationModule::get_numTilesX(&this.textureSheetAnimation (UnityEngine.ParticleSystem+TextureSheetAnimationModule));\n\tv466 = UnityEngine.ParticleSystem+TextureSheetAnimationModule::get_numTilesY(&this.textureSheetAnimation (UnityEngine.ParticleSystem+TextureSheetAnimationModule));\n\tv463 = 1f / v478;\n\tv462 = 1f / v466;\n\tthis.textureSheetAnimationFrameSize.x = v463;\n\tthis.textureSheetAnimationFrameSize.y = v462;\nL_01C3:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_00FB:\n\tv541 = UnityEngine.Object::op_Equality(v528, 0);\n\tv542 = ~v541;\n\tif (v542) goto L_0116;\nL_0116:\n\tv564 = UnityEngine.UI.Graphic::get_material(this);\n\tthis.currentMaterial = v564;\n\tgoto L_0121;\nL_014D:\n\tv600 = UnityEngine.Object::op_Equality(this.mainTexture, 0);\n\tv604 = ~v600;\n\tif (v604) goto L_015B;\nL_019B:\n\tthis.textureSheetAnimationFrameSize = v443.zero;\n\tv447 = UnityEngine.ParticleSystem+TextureSheetAnimationModule::get_enabled(&this.textureSheetAnimation (UnityEngine.ParticleSystem+TextureSheetAnimationModule));\n\tv415 = ~v447;\n\tif (v415) goto L_01C2;\nL_01C2:\n\treturn 1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected bool Initialize()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIParticleSystem::Initialize");
			return default;
		}

		[Token(Token = "0x6000031")]
		[Address(RVA = "0x81C0D1C", Offset = "0x81C0D1C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.EventSystems.UIBehaviour::Awake(this);\n\tv14 = Unco.UIParticleSystem.UIParticleSystem::Initialize(this);\n\tv16 = v14 == 0;\n\tv17 = ~v16;\n\tif (v17) goto L_0023;\n\tv39 = UnityEngine.ParticleSystem::get_main(this.pSystem);\n\tv24 = v39;\n\tv30 = UnityEngine.ParticleSystem+MainModule::get_playOnAwake(&v24 @ stack_-28_v2 (UnityEngine.ParticleSystem+MainModule));\n\tv27 = ~v30;\n\tif (v27) goto L_0023;\n\tUnityEngine.Behaviour::set_enabled(this, 0);\nL_0023:\n\treturn;\n")]
		protected override void Awake()
		{
			base.Awake();
			if (!Initialize())
			{
				ParticleSystem.MainModule main = pSystem.main;
				ParticleSystem.MainModule mainModule = main;
				if (mainModule.playOnAwake)
				{
					base.enabled = false;
				}
			}
		}

		[Token(Token = "0x6000032")]
		[Address(RVA = "0x81C0D8C", Offset = "0x81C0D8C", Length = "0x818")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tUnityEngine.UI.VertexHelper::Clear(vh);\n\tv413 = UnityEngine.Component::get_gameObject(this);\n\tv576 = UnityEngine.GameObject::get_activeInHierarchy(v413);\n\tv577 = ~v576;\n\tif (v577) goto L_0348;\n\tgoto L_004D;\nL_004D:\n\tv631 = UnityEngine.ParticleSystem::GetParticles(this.pSystem, this.particles);\n\tv609 = v631 < 1;\n\tif (v609) goto L_0348;\nL_FFFFFFFF:\n\tv272 = v631;\nL_FFFFFFFF:\n\tv278 = 0xFFFFFFFFBC8EFA35;\nL_FFFFFFFF:\n\tv280 = 0x20;\nL_FFFFFFFF:\n\tv282 = 0;\n\tgoto L_00A5;\nL_0066:\n\tv1164 = v1148 + 0x3FC90FDB;\n\tv1165 = 0x8BF5CD8(v423, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v1148, 0x3FC90FDB, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1172 = 0x3FC90FDB * v588;\n\tv1171 = v1148 * v588;\n\tv1175 = 0x8BF5CD8(v1165, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v1164, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1178 = 0x3FC90FDB * v588;\n\tv1179 = v1164 * v588;\n\tv1180 = v195 - v1172;\n\tv1181 = v190 - v1171;\n\tv1182 = v1180 - v1178;\n\tv1183 = v1181 - v1179;\n\t*([v210 @ X22_v8 (UnityEngine.UIVertex[])+20]) = v1182;\n\t*([v210 @ X22_v8 (UnityEngine.UIVertex[])+24]) = v1183;\n\t*([v210 @ X22_v8 (UnityEngine.UIVertex[])+28]) = 0;\n\tv1184 = v1178 + v1180;\n\tv1185 = v1179 + v1181;\n\t*([v210 @ X22_v8 (UnityEngine.UIVertex[])+8C]) = v1184;\n\t*([v210 @ X22_v8 (UnityEngine.UIVertex[])+90]) = v1185;\n\t*([v210 @ X22_v8 (UnityEngine.UIVertex[])+94]) = 0;\n\tv1168 = v1172 + v195;\n\tv1167 = v1171 + v190;\n\tv1166 = v1178 + v1168;\n\tv593 = v1179 + v1167;\n\t*([v210 @ X22_v8 (UnityEngine.UIVertex[])+F8]) = v1166;\n\tv601 = v1168 - v1178;\n\tv594 = v1167 - v1179;\nL_00A5:\n\tv653 = this.particles + v280;\n\tv654 = 0x8BF6A34(&v79 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle), v653, 0x84, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv688 = UnityEngine.ParticleSystem+MainModule::get_simulationSpace(&this.mainModule (UnityEngine.ParticleSystem+MainModule));\n\tv689 = v688 == 0;\n\tif (v689) goto L_00BE;\n\tv238 = UnityEngine.ParticleSystem+Particle::get_position(&v79 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle));\n\tv701 = UnityEngine.Transform::InverseTransformPoint(this._transform, v238);\n\tv262 = v701.y;\n\tgoto L_00C5;\nL_00BE:\n\tv701 = UnityEngine.ParticleSystem+Particle::get_position(&v79 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle));\n\tv262 = v701.y;\n\tv717 = UnityEngine.ParticleSystem+MainModule::get_scalingMode(&this.mainModule (UnityEngine.ParticleSystem+MainModule));\n\tv287 = v717 != 2;\nL_FFFFFFFF:\n\tv190 = v262;\nL_FFFFFFFF:\n\tv195 = v701;\n\tif (v287) goto L_00E8;\n\tv416 = UnityEngine.UI.Graphic::get_canvas(this);\n\tv723 = UnityEngine.Canvas::get_scaleFactor(v416);\n\tv721 = v701 / v723;\n\tv190 = v262 / v723;\nL_FFFFFFFF:\n\tv195 = v721;\n\tv737 = UnityEngine.ParticleSystem+Particle::get_remainingLifetime(&v79 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle));\n\tv785 = UnityEngine.ParticleSystem+Particle::get_startLifetime(&v79 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle));\n\tv789 = &v793 @ stack_-170_v6 (UnityEngine.ParticleSystem+MinMaxCurve);\n\tv792 = UnityEngine.ParticleSystem+TextureSheetAnimationModule::get_frameOverTime(&this.textureSheetAnimation (UnityEngine.ParticleSystem+TextureSheetAnimationModule));\n\tv793 = *([v789 @ X8_v25]);\n\tv803 = *([v789 @ X8_v25]);\n\tv807 = UnityEngine.ParticleSystem+MinMaxCurve::get_curveMin(&v803 @ stack_-150_v7 (UnityEngine.ParticleSystem+MinMaxCurve));\n\tv810 = v807 == 0;\n\tif (v810) goto L_012E;\n\tv813 = UnityEngine.ParticleSystem+TextureSheetAnimationModule::get_frameOverTime(&this.textureSheetAnimation (UnityEngine.ParticleSystem+TextureSheetAnimationModule));\n\tv793 = v793.m_Mode;\n\tv803 = v793.m_Mode;\n\tv820 = UnityEngine.ParticleSystem+MinMaxCurve::get_curveMin(&v803 @ stack_-150_v7 (UnityEngine.ParticleSystem+MinMaxCurve));\n\tv838 = UnityEngine.ParticleSystem+Particle::get_remainingLifetime(&v79 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle));\n\tv880 = UnityEngine.ParticleSystem+Particle::get_startLifetime(&v79 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle));\n\tv847 = v820 == 0;\n\tv431 = ~v847;\nL_FFFFFFFF:\n\tv911 = 1f;\nL_FFFFFFFF:\n\tv869 = v820;\nL_FFFFFFFF:\n\tv881 = v838;\n\tif (v431) goto L_0160;\n\tgoto L_034A;\nL_012E:\n\t;\n\tv816 = UnityEngine.ParticleSystem+TextureSheetAnimationModule::get_frameOverTime(&this.textureSheetAnimation (UnityEngine.ParticleSystem+TextureSheetAnimationModule));\n\tv793 = v793.m_Mode;\n\tv803 = v793.m_Mode;\n\tv835 = UnityEngine.ParticleSystem+MinMaxCurve::get_curve(&v803 @ stack_-150_v7 (UnityEngine.ParticleSystem+MinMaxCurve));\n\tv839 = v835 == 0;\n\tif (v839) goto L_02F6;\n\tv842 = UnityEngine.ParticleSystem+TextureSheetAnimationModule::get_frameOverTime(&this.textureSheetAnimation (UnityEngine.ParticleSystem+TextureSheetAnimationModule));\n\tv793 = v793.m_Mode;\n\tv803 = v793.m_Mode;\n\tv851 = UnityEngine.ParticleSystem+MinMaxCurve::get_curve(&v803 @ stack_-150_v7 (UnityEngine.ParticleSystem+MinMaxCurve));\n\tv894 = UnityEngine.ParticleSystem+Particle::get_remainingLifetime(&v79 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle));\n\tv880 = UnityEngine.ParticleSystem+Particle::get_startLifetime(&v79 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle));\nL_FFFFFFFF:\n\tv911 = 1f;\nL_FFFFFFFF:\n\tv869 = v851;\nL_FFFFFFFF:\n\tv881 = v894;\nL_0160:\n\tv887 = v881 / v880;\n\tv888 = v911 - v887;\n\tv891 = UnityEngine.AnimationCurve::Evaluate(v869, v888);\nL_FFFFFFFF:\n\tv927 = v891;\nL_FFFFFFFF:\n\tv976 = v911;\n\tgoto L_0185;\nL_FFFFFFFF:\n\tv976 = v959;\nL_FFFFFFFF:\n\tv989 = 0;\n\tgoto L_018B;\nL_FFFFFFFF:\n\tv989 = v976;\n\tv1002 = v992 == 0;\n\tv1003 = ~v1002;\n\tif (v1003) goto L_FFFFFFFF;\n\tgoto L_01AE;\nL_01B1:\n\tv1095 = v989 * this.textureSheetAnimationFrames;\n\tv1050 = UnityEngine.Mathf::Floor(v1095);\n\tv1056 = v1050 == 0x7F800000;\n\tv1038 = ~v1056;\n\tif (v1038) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv778 = 0xFFFFFFFF80000000;\n\tgoto L_01C5;\nL_FFFFFFFF:\n\tv778 = v1095;\nL_01C6:\n\t;\n\tv1006 = UnityEngine.ParticleSystem+TextureSheetAnimationModule::get_numTilesX(&this.textureSheetAnimation (UnityEngine.ParticleSystem+TextureSheetAnimationModule));\n\tgoto L_01DC;\nL_01DF:\n\tv1102 = v989 * v1006;\n\tv1049 = UnityEngine.Mathf::Floor(v1102);\n\tv1055 = v1049 == 0x7F800000;\n\tv1037 = ~v1055;\n\tif (v1037) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv1143 = 0xFFFFFFFF80000000;\n\tgoto L_01F3;\nL_FFFFFFFF:\n\tv1143 = v1102;\nL_FFFFFFFF:\n\tv778 = 0;\nL_021C:\n\tv1134 = v778 / this.textureSheetAnimationFrames;\n\tv1135 = v1134 * this.textureSheetAnimationFrames;\n\tv1136 = v778 - v1135;\n\tv1137 = v1136 / v1078;\n\tv774 = v1137 * v1078;\n\tv754 = v1136 - v774;\n\tv738 = this.textureSheetAnimationFrameSize * v754;\n\tv776 = v1136 / v1098;\n\tv253 = this.textureSheetAnimationFrameSize.y * v776;\n\tv247 = v738 + this.textureSheetAnimationFrameSize;\n\tv111 = this.textureSheetAnimationFrameSize.y + v253;\nL_FFFFFFFF:\n\tv95 = v738;\nL_FFFFFFFF:\n\tv272 = v631;\nL_FFFFFFFF:\n\tv278 = 0xFFFFFFFFBC8EFA35;\nL_023F:\n\tv809 = this._quad + 0x20;\n\tv406 = v117.s_DefaultColor + 0x14;\n\tv420 = 0x8BF6A34(v809, v406, 0x6C, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv449 = this._quad;\n\t*([v449 @ X8_v14 (UnityEngine.UIVertex[])+48]) = v712;\n\tv450 = this._quad;\n\t*([v450 @ X8_v15 (UnityEngine.UIVertex[])+4C]) = v95;\n\t*([v450 @ X8_v15 (UnityEngine.UIVertex[])+50]) = v253;\n\t*([v450 @ X8_v15 (UnityEngine.UIVertex[])+54]) = 0;\n\t*([v450 @ X8_v15 (UnityEngine.UIVertex[])+58]) = 0;\n\tv867 = v450 + 0x8C;\n\tv407 = v117.s_DefaultColor + 0x14;\n\tv421 = 0x8BF6A34(v867, v407, 0x6C, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv451 = this._quad;\n\t*([v451 @ X8_v16 (UnityEngine.UIVertex[])+B4]) = v712;\n\tv452 = this._quad;\n\t*([v452 @ X8_v17 (UnityEngine.UIVertex[])+B8]) = v95;\n\t*([v452 @ X8_v17 (U\n// ... truncated")]
		protected override void OnPopulateMesh(VertexHelper vh)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIParticleSystem::OnPopulateMesh");
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x81C15A4", Offset = "0x81C15A4", Length = "0x254")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tgoto L_0023;\nL_0023:\n\tv76 = UnityEngine.Application::get_isPlaying();\n\tv140 = ~v76;\n\tv84 = ~v140;\n\tif (v84) goto L_0031;\n\tgoto L_00C3;\nL_0031:\n\tv148 = UnityEngine.UI.Graphic::SetAllDirty(this);\n\tgoto L_003C;\nL_003C:\n\tv157 = UnityEngine.Object::op_Inequality(this.currentMaterial, 0);\n\tv159 = ~v157;\n\tv160 = ~v159;\n\tif (v160) goto L_004D;\n\tgoto L_0068;\nL_004D:\n\tv195 = UnityEngine.Material::get_mainTexture(this.currentMaterial);\n\tgoto L_0056;\nL_0056:\n\tv181 = UnityEngine.Object::op_Inequality(this.mainTexture, v195);\n\tv184 = v181 == 0;\n\tif (v184) goto L_0068;\n\tgoto L_00AF;\nL_0068:\n\tv192 = UnityEngine.UI.Graphic::get_material(this);\n\tgoto L_006F;\nL_006F:\n\tv78 = UnityEngine.Object::op_Inequality(v192, 0);\n\tv209 = ~v78;\n\tv86 = ~v209;\n\tif (v86) goto L_0081;\n\tgoto L_00C3;\nL_0081:\n\tgoto L_0085;\nL_0085:\n\tv80 = UnityEngine.Object::op_Inequality(this.currentMaterial, 0);\n\tv226 = ~v80;\n\tv88 = ~v226;\n\tif (v88) goto L_0095;\n\tgoto L_00C3;\nL_0095:\n\tv200 = UnityEngine.UI.Graphic::get_material(this);\n\tv240 = UnityEngine.Material::get_shader(v200);\n\tv242 = UnityEngine.Material::get_shader(this.currentMaterial);\n\tgoto L_00AA;\nL_00AA:\n\tv82 = UnityEngine.Object::op_Inequality(v240, v242);\n\tv90 = ~v82;\n\tif (v90) goto L_00C3;\nL_00AF:\n\tthis.pSystem = 0;\n\tv125 = Unco.UIParticleSystem.UIParticleSystem::Initialize(this);\n\treturn;\nL_00C3:\n\treturn;\nL_0019:\n\tv45 = this.fixedTime == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_00C3;\n")]
		private void Update()
		{
			if (fixedTime || !Application.isPlaying)
			{
				return;
			}
			base.SetAllDirty();
			if (currentMaterial != null)
			{
				Texture texture = currentMaterial.mainTexture;
				if (mainTexture != texture)
				{
					goto IL_01ac;
				}
			}
			UnityEngine.Object obj = base.material;
			if (!(obj != null) || !(currentMaterial != null))
			{
				return;
			}
			Material material = base.material;
			Shader shader = material.shader;
			Shader shader2 = currentMaterial.shader;
			if (shader != shader2)
			{
				goto IL_01ac;
			}
			return;
			IL_01ac:
			pSystem = null;
			bool flag = Initialize();
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x81C17F8", Offset = "0x81C17F8", Length = "0x2C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0015;\nL_0015:\n\tv137 = 0xB292000 + 0x5A0;\n\tv52 = UnityEngine.Application::get_isPlaying();\n\tv61 = v52 == 0;\n\tif (v61) goto L_0053;\n\tv83 = this.fixedTime != 1;\n\tif (v83) goto L_0058;\n\tv99 = UnityEngine.UI.Graphic::SetAllDirty(this);\n\tv101 = *([v137 @ X22_v1 (System.Int32)]);\n\tv103 = *([v101 @ X0_v33+E4]) == 0;\n\tif (v103) goto L_008A;\n\tv174 = UnityEngine.Object::op_Inequality(this.currentMaterial, 0);\n\tv182 = ~v174;\n\tv183 = ~v182;\n\tif (v183) goto L_0092;\n\tgoto L_00AD;\nL_0053:\n\tv92 = UnityEngine.UI.Graphic::SetAllDirty(this);\n\tv137 = v137;\n\tv178 = UnityEngine.Object::op_Equality(v166, this.currentMaterial);\n\tv189 = v178 == 0;\n\tif (v189) goto L_0079;\nL_006B:\n\treturn;\nL_0072:\n\tv193 = UnityEngine.Object::op_Equality(v166, this.currentMaterial);\n\tv223 = v193 == 0;\n\tv205 = ~v223;\n\tif (v205) goto L_006B;\nL_0079:\n\tthis.pSystem = 0;\n\tv283 = Unco.UIParticleSystem.UIParticleSystem::Initialize(this);\n\treturn;\nL_008A:\n\tv187 = UnityEngine.Object::op_Inequality(this.currentMaterial, 0);\n\tv198 = ~v187;\n\tif (v198) goto L_00AD;\nL_0092:\n\tv249 = UnityEngine.Material::get_mainTexture(this.currentMaterial);\n\tv300 = *([v137 @ X22_v1 (System.Int32)]);\n\tv301 = *([v300 @ X0_v68+E4]) == 0;\n\tif (v301) goto L_00A4;\n\tv232 = UnityEngine.Object::op_Inequality(this.mainTexture, v249);\n\tv235 = v232 == 0;\n\tif (v235) goto L_00AD;\n\tgoto L_00E7;\nL_00A4:\n\tv231 = UnityEngine.Object::op_Inequality(this.mainTexture, v249);\n\tv313 = v231 == 0;\n\tv234 = ~v313;\n\tif (v234) goto L_00E7;\nL_00AD:\n\tv245 = UnityEngine.UI.Graphic::get_material(this);\n\tgoto L_00B9;\n\tgoto L_00C6;\nL_00C6:\n\tv140 = UnityEngine.Object::op_Inequality(this.currentMaterial, 0);\n\tv145 = ~v140;\n\tif (v145) goto L_0058;\n\tv256 = UnityEngine.UI.Graphic::get_material(this);\n\tv321 = UnityEngine.Material::get_shader(v256);\n\tv323 = UnityEngine.Material::get_shader(this.currentMaterial);\n\tgoto L_00E2;\nL_00E2:\n\tv141 = UnityEngine.Object::op_Inequality(v321, v323);\n\tv146 = ~v141;\n\tif (v146) goto L_0058;\nL_00E7:\n\tthis.pSystem = 0;\n\tv142 = Unco.UIParticleSystem.UIParticleSystem::Initialize(this);\n\tgoto L_0058;\nL_0058:\n\tv166 = UnityEngine.UI.Graphic::get_material(this);\n\tv168 = *([v137 @ X22_v1 (System.Int32)]);\n\tv170 = *([v168 @ X8_v4+E4]) == 0;\n\tif (v170) goto L_0072;\nL_00B9:\n\tv139 = UnityEngine.Object::op_Inequality(v245, 0);\n\tv144 = ~v139;\n\tif (v144) goto L_0058;\n")]
		private void LateUpdate()
		{
			//IL_0310: Expected O, but got I4
			//IL_006f: Expected O, but got I4
			//IL_01ad: Expected O, but got I4
			int num = 187244544 + 1440;
			if (Application.isPlaying)
			{
				if (fixedTime)
				{
					base.SetAllDirty();
					object obj = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ X0_v33+E4]");
					if ((nint)0 != 0)
					{
						if (currentMaterial != null)
						{
							goto IL_0196;
						}
					}
					else if (currentMaterial != null)
					{
						goto IL_0196;
					}
					goto IL_0247;
				}
			}
			else
			{
				base.SetAllDirty();
				num = num;
			}
			goto IL_02fe;
			IL_0196:
			Texture texture = currentMaterial.mainTexture;
			object obj2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ X0_v68+E4]");
			if ((nint)0 != 0)
			{
				if (!(mainTexture != texture))
				{
					goto IL_0247;
				}
			}
			else if (!(mainTexture != texture))
			{
				goto IL_0247;
			}
			goto IL_02e3;
			IL_02e3:
			pSystem = null;
			bool flag = Initialize();
			goto IL_02fe;
			IL_02fe:
			UnityEngine.Object obj3 = base.material;
			object obj4 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ X8_v4+E4]");
			if ((nint)0 != 0)
			{
				if (obj3 == currentMaterial)
				{
					return;
				}
			}
			else if (obj3 == currentMaterial)
			{
				return;
			}
			pSystem = null;
			bool flag2 = Initialize();
			return;
			IL_0247:
			Material material = base.material;
			if (material != null && currentMaterial != null)
			{
				Material material2 = base.material;
				Shader shader = material2.shader;
				Shader shader2 = currentMaterial.shader;
				if (shader != shader2)
				{
					goto IL_02e3;
				}
			}
			goto IL_02fe;
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x81C1AB8", Offset = "0x81C1AB8", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tthis.fixedTime = 1;\n\t// 26 NewArr v47 @ X0_v3 (UnityEngine.UIVertex[]), typeof(UnityEngine.UIVertex[]), 4\n\tthis._quad = v47;\n\tgoto L_002F;\nL_002F:\n\tthis.imageUV = v64.zero;\n\tUnityEngine.UI.MaskableGraphic::.ctor(this);\n\treturn;\n")]
		public UIParticleSystem()
		{
			fixedTime = true;
			UIVertex[] quad = new UIVertex[4];
			_quad = quad;
			imageUV = Vector4.zero;
		}
	}
}
