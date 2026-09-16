using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752384", Offset = "0x752384")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x752384", Offset = "0x752384")]
	[Token(Token = "0x2000129")]
	public class SetAnimationTime : BaseAnimationAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A319C", Offset = "0x7A319C")]
		[Token(Token = "0x40010E9")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A3210", Offset = "0x7A3210")]
		[Token(Token = "0x40010EA")]
		[FieldOffset(Offset = "0x68")]
		public FsmString animName;

		[Token(Token = "0x40010EB")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat time;

		[Token(Token = "0x40010EC")]
		[FieldOffset(Offset = "0x78")]
		public bool normalized;

		[Token(Token = "0x40010ED")]
		[FieldOffset(Offset = "0x79")]
		public bool everyFrame;

		[Token(Token = "0x60006C4")]
		[Address(RVA = "0xB28B14", Offset = "0xB28B14", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.normalized = 0;\n\tthis.animName = 0;\n\tthis.time = 0;\n\tthis.gameObject = 0;\n\treturn;\n")]
		public override void Reset()
		{
			normalized = false;
			everyFrame = false;
			animName = null;
			time = null;
			gameObject = null;
		}

		[Token(Token = "0x60006C5")]
		[Address(RVA = "0xB28B24", Offset = "0xB28B24", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.gameObject;\n\tv13 = v10.ownerOption == 0;\n\tif (v13) goto L_0013;\n\tv39 = HutongGames.PlayMaker.FsmGameObject::get_Value(v10.gameObject);\n\tgoto L_0015;\nL_0013:\n\tv40 = *([this @ X0 (HutongGames.PlayMaker.Actions.SetAnimationTime)+20]);\nL_0015:\n\tHutongGames.PlayMaker.Actions.SetAnimationTime::DoSetAnimationTime(this, v40);\n\tv46 = ~this.everyFrame;\n\tif (v46) goto L_0024;\n\treturn;\nL_0024:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_0060: Expected O, but got I
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			GameObject go;
			if (fsmOwnerDefault.OwnerOption != OwnerDefaultOption.UseOwner)
			{
				GameObject value = fsmOwnerDefault.GameObject.Value;
				go = value;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetAnimationTime)+20]");
				go = (GameObject)0;
			}
			DoSetAnimationTime(go);
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60006C6")]
		[Address(RVA = "0xB28D38", Offset = "0xB28D38", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.gameObject;\n\tv13 = v10.ownerOption == 0;\n\tif (v13) goto L_0013;\n\tv39 = HutongGames.PlayMaker.FsmGameObject::get_Value(v10.gameObject);\n\tgoto L_0019;\nL_0013:\n\tv40 = *([this @ X0 (HutongGames.PlayMaker.Actions.SetAnimationTime)+20]);\nL_0019:\n\tHutongGames.PlayMaker.Actions.SetAnimationTime::DoSetAnimationTime(this, v40);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			//IL_0060: Expected O, but got I
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			GameObject go;
			if (fsmOwnerDefault.OwnerOption != OwnerDefaultOption.UseOwner)
			{
				GameObject value = fsmOwnerDefault.GameObject.Value;
				go = value;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetAnimationTime)+20]");
				go = (GameObject)0;
			}
			DoSetAnimationTime(go);
		}

		[Token(Token = "0x60006C7")]
		[Address(RVA = "0xB28B98", Offset = "0xB28B98", Length = "0x1A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EF48A8]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, go, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20225F2]) = v41;\nL_001A:\n\tv47 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::UpdateCache(this, go);\n\tv49 = v47 == 0;\n\tif (v49) goto L_0083;\n\tv54 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::get_animation(this);\n\tv118 = HutongGames.PlayMaker.FsmString::get_Value(this.animName);\n\tv147 = UnityEngine.Animation::Play(v54, v118);\n\tv128 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::get_animation(this);\n\tv129 = HutongGames.PlayMaker.FsmString::get_Value(this.animName);\n\tv153 = UnityEngine.Animation::get_Item(v128, v129);\n\tv154 = UnityEngine.TrackedReference::op_Equality(v153, 0);\n\tv156 = v154 == 0;\n\tif (v156) goto L_0063;\n\tv158 = HutongGames.PlayMaker.FsmString::get_Value(this.animName);\n\tv164 = System.String::Concat(\"Missing animation: \", v158);\n\tHutongGames.PlayMaker.FsmStateAction::LogWarning(this, v164);\n\treturn;\nL_0063:\n\tv56 = HutongGames.PlayMaker.FsmFloat::get_Value(this.time);\n\tv165 = ~this.normalized;\n\tif (v165) goto L_006E;\n\tUnityEngine.AnimationState::set_normalizedTime(v153, v56);\n\tgoto L_0070;\nL_006E:\n\tUnityEngine.AnimationState::set_time(v153, v56);\nL_0070:\n\tv64 = ~this.everyFrame;\n\tif (v64) goto L_0083;\n\tUnityEngine.AnimationState::set_speed(v153, 0f);\n\treturn;\nL_0083:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetAnimationTime(GameObject go)
		{
			if (!UpdateCache(go))
			{
				return;
			}
			Animation animation = base.animation;
			string value = animName.Value;
			bool flag = animation.Play(value);
			Animation animation2 = base.animation;
			string value2 = animName.Value;
			AnimationState animationState = animation2.get_Item(value2);
			if (animationState == null)
			{
				string value3 = animName.Value;
				string text = "Missing animation: " + value3;
				LogWarning(text);
				return;
			}
			float value4 = time.Value;
			if (normalized)
			{
				animationState.normalizedTime = value4;
			}
			else
			{
				animationState.time = value4;
			}
			if (everyFrame)
			{
				animationState.speed = 0f;
			}
		}

		[Token(Token = "0x60006C8")]
		[Address(RVA = "0xB28D8C", Offset = "0xB28D8C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseAnimationAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetAnimationTime()
		{
		}
	}
}
