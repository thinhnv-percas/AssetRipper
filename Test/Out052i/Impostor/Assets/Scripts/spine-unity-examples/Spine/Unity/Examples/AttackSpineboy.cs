using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000012")]
	public class AttackSpineboy : MonoBehaviour
	{
		[Token(Token = "0x4000047")]
		[FieldOffset(Offset = "0x20")]
		public SkeletonAnimation spineboy;

		[Token(Token = "0x4000048")]
		[FieldOffset(Offset = "0x28")]
		public SkeletonAnimation attackerSpineboy;

		[Token(Token = "0x4000049")]
		[FieldOffset(Offset = "0x30")]
		public SpineGauge gauge;

		[Token(Token = "0x400004A")]
		[FieldOffset(Offset = "0x38")]
		public Text healthText;

		[Token(Token = "0x400004B")]
		[FieldOffset(Offset = "0x40")]
		private int currentHealth;

		[Token(Token = "0x400004C")]
		private const int maxHealth = 100;

		[Token(Token = "0x400004D")]
		[FieldOffset(Offset = "0x48")]
		public AnimationReferenceAsset shoot;

		[Token(Token = "0x400004E")]
		[FieldOffset(Offset = "0x50")]
		public AnimationReferenceAsset hit;

		[Token(Token = "0x400004F")]
		[FieldOffset(Offset = "0x58")]
		public AnimationReferenceAsset idle;

		[Token(Token = "0x4000050")]
		[FieldOffset(Offset = "0x60")]
		public AnimationReferenceAsset death;

		[Token(Token = "0x4000051")]
		[FieldOffset(Offset = "0x68")]
		public UnityEvent onAttack;

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x150AA6C", Offset = "0x150AA6C", Length = "0x218")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = \"/\";\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A379F0]) = v37;\nL_0014:\n\tv40 = UnityEngine.Input::GetKeyDown(0x20);\n\tv42 = v40 == 0;\n\tif (v42) goto L_00AB;\n\tv44 = this + 0x40;\n\tv47 = this.healthText;\n\tv48 = v44.m_value - 0xA;\n\tv44.m_value = v48;\n\tv50 = System.Int32::ToString(v44);\n\tv101 = 0x64;\n\tv134 = System.Int32::ToString(&v101 @ stack_-24_v2 (System.Int32));\n\tv187 = System.String::Concat(v50, \"/\", v134);\n\tv189 = this.healthText->klass;\n\t*([v189 @ X8_v10+5E8])(v193, v47, v187, *([v189 @ X8_v10+5F0]), 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv194 = this.attackerSpineboy;\n\tv209 = Spine.Unity.AnimationReferenceAsset::op_Implicit(this.shoot);\n\tv210 = Spine.AnimationState::SetAnimation(v194.state, 1, v209, 0);\n\tv228 = this.attackerSpineboy;\n\tv114 = Spine.AnimationState::AddEmptyAnimation(v228.state, 1, 0.5f, 2f);\n\tv52 = v44.m_value < 1;\n\tif (v52) goto L_008B;\n\tv229 = this.spineboy;\n\tv212 = Spine.Unity.AnimationReferenceAsset::op_Implicit(this.hit);\n\tv213 = Spine.AnimationState::SetAnimation(v229.state, 0, v212, 0);\n\tv230 = this.spineboy;\n\tv214 = Spine.Unity.AnimationReferenceAsset::op_Implicit(this.idle);\n\tv215 = Spine.AnimationState::AddAnimation(v230.state, 0, v214, 1, 0f);\n\tv121 = this.gauge;\n\tv83 = this.currentHealth / 0x42C80000;\n\tv121.fillPercent = v83;\n\tUnityEngine.Events.UnityEvent::Invoke(this.onAttack);\n\tgoto L_00AB;\nL_008B:\n\tv238 = v44.m_value == 0;\n\tv118 = ~v238;\n\tif (v118) goto L_00AB;\n\tv231 = this.gauge;\n\tv231.fillPercent = 0f;\n\tv232 = this.spineboy;\n\tv216 = Spine.Unity.AnimationReferenceAsset::op_Implicit(this.death);\n\tv112 = Spine.AnimationState::SetAnimation(v232.state, 0, v216, 0);\n\tv112.trackEnd = Infinityf;\nL_00AB:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 126 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void Update()
		{
			//IL_0021: Expected O, but got I
			if (Input.GetKeyDown(KeyCode.Space))
			{
				int num = (int)((nint)this + 64);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X20_v5 (System.Int32)-8]");
				object obj = 0;
				int value = ((int*)num)->m_value - 10;
				((int*)num)->m_value = value;
				string text = ((int*)num)->ToString();
				string text2 = 100.ToString();
				string text3 = text + "/" + text2;
				object obj2 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v189 @ X8_v10+5E8] (should have been resolved before IL gen)");
				SkeletonAnimation skeletonAnimation = attackerSpineboy;
				Animation animation = shoot;
				TrackEntry trackEntry = skeletonAnimation.state.SetAnimation(1, animation, loop: false);
				SkeletonAnimation skeletonAnimation2 = attackerSpineboy;
				TrackEntry trackEntry2 = skeletonAnimation2.state.AddEmptyAnimation(1, 0.5f, 2f);
				if (((int*)num)->m_value >= 1)
				{
					SkeletonAnimation skeletonAnimation3 = spineboy;
					Animation animation2 = hit;
					TrackEntry trackEntry3 = skeletonAnimation3.state.SetAnimation(0, animation2, loop: false);
					SkeletonAnimation skeletonAnimation4 = spineboy;
					Animation animation3 = idle;
					TrackEntry trackEntry4 = skeletonAnimation4.state.AddAnimation(0, animation3, loop: true, 0f);
					SpineGauge spineGauge = gauge;
					int num2 = currentHealth / 1120403456;
					spineGauge.fillPercent = num2;
					onAttack.Invoke();
				}
				else if (((int*)num)->m_value == 0)
				{
					SpineGauge spineGauge2 = gauge;
					spineGauge2.fillPercent = 0f;
					SkeletonAnimation skeletonAnimation5 = spineboy;
					Animation animation4 = death;
					TrackEntry trackEntry5 = skeletonAnimation5.state.SetAnimation(0, animation4, loop: false);
					trackEntry5.TrackEnd = float.PositiveInfinity;
				}
			}
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x150AC84", Offset = "0x150AC84", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.currentHealth = 0x64;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AttackSpineboy()
		{
			currentHealth = 100;
		}
	}
}
