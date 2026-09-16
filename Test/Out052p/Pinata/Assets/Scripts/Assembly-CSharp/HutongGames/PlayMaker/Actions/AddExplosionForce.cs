using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759B58", Offset = "0x759B58")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x759B58", Offset = "0x759B58")]
	[Token(Token = "0x2000298")]
	public class AddExplosionForce : ComponentAction<Rigidbody>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B9120", Offset = "0x7B9120")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B9120", Offset = "0x7B9120")]
		[Token(Token = "0x4001703")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B91B8", Offset = "0x7B91B8")]
		[Token(Token = "0x4001704")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 center;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B9204", Offset = "0x7B9204")]
		[Token(Token = "0x4001705")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat force;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B9250", Offset = "0x7B9250")]
		[Token(Token = "0x4001706")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat radius;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B929C", Offset = "0x7B929C")]
		[Token(Token = "0x4001707")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat upwardsModifier;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B92D4", Offset = "0x7B92D4")]
		[Token(Token = "0x4001708")]
		[FieldOffset(Offset = "0x88")]
		public ForceMode forceMode;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B930C", Offset = "0x7B930C")]
		[Token(Token = "0x4001709")]
		[FieldOffset(Offset = "0x8C")]
		public bool everyFrame;

		[Token(Token = "0x6000CDB")]
		[Address(RVA = "0xA125A4", Offset = "0xA125A4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ED55C0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D14]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv42 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v42);\n\tv42.useVariable = 1;\n\tthis.center = v42;\n\tv49 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.upwardsModifier = v49;\n\tthis.forceMode = 0;\n\tthis.everyFrame = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			center = fsmVector;
			FsmFloat fsmFloat = 0f;
			upwardsModifier = fsmFloat;
			forceMode = default(ForceMode);
			everyFrame = false;
		}

		[Token(Token = "0x6000CDC")]
		[Address(RVA = "0xA12634", Offset = "0xA12634", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::set_HandleFixedUpdate(*([this @ X0 (HutongGames.PlayMaker.Actions.AddExplosionForce)+30]), 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnPreprocess()
		{
			//IL_0016: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.AddExplosionForce)+30]");
			((Fsm)0).HandleFixedUpdate = true;
		}

		[Token(Token = "0x6000CDD")]
		[Address(RVA = "0xA12654", Offset = "0xA12654", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AddExplosionForce::DoAddExplosionForce(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoAddExplosionForce();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000CDE")]
		[Address(RVA = "0xA127EC", Offset = "0xA127EC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AddExplosionForce::DoAddExplosionForce(this);\n\treturn;\n")]
		public override void OnFixedUpdate()
		{
			DoAddExplosionForce();
		}

		[Token(Token = "0x6000CDF")]
		[Address(RVA = "0xA12690", Offset = "0xA12690", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EFB288]);\n\tv29 = *([v28 @ X8_v15]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2021D15]) = v48;\nL_0018:\n\tv49 = this.gameObject;\n\tv52 = v49.ownerOption == 0;\n\tif (v52) goto L_0025;\n\tv121 = HutongGames.PlayMaker.FsmGameObject::get_Value(v49.gameObject);\n\tgoto L_0027;\nL_0025:\n\tv122 = *([this @ X0 (HutongGames.PlayMaker.Actions.AddExplosionForce)+20]);\nL_0027:\n\tv127 = this.center == 0;\n\tif (v127) goto L_0075;\n\tv131 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::UpdateCache(this, v122);\n\tv135 = v131 == 0;\n\tif (v135) goto L_0075;\n\tv79 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::get_rigidbody(this);\n\tv101 = HutongGames.PlayMaker.FsmFloat::get_Value(this.force);\n\tv102 = HutongGames.PlayMaker.FsmVector3::get_Value(this.center);\n\tv103 = HutongGames.PlayMaker.FsmFloat::get_Value(this.radius);\n\tv70 = HutongGames.PlayMaker.FsmFloat::get_Value(this.upwardsModifier);\n\tUnityEngine.Rigidbody::AddExplosionForce(v79, v101, v102, v103, v70, this.forceMode);\n\treturn;\nL_0075:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoAddExplosionForce()
		{
			//IL_0056: Expected O, but got I
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			GameObject go;
			if (fsmOwnerDefault.OwnerOption != OwnerDefaultOption.UseOwner)
			{
				GameObject value = fsmOwnerDefault.GameObject.Value;
				go = value;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.AddExplosionForce)+20]");
				go = (GameObject)0;
			}
			if (center != null && UpdateCache(go))
			{
				Rigidbody rigidbody = base.rigidbody;
				float value2 = force.Value;
				Vector3 value3 = center.Value;
				float value4 = radius.Value;
				float value5 = upwardsModifier.Value;
				rigidbody.AddExplosionForce(value2, value3, value4, value5, forceMode);
			}
		}

		[Token(Token = "0x6000CE0")]
		[Address(RVA = "0xA127F0", Offset = "0xA127F0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EB8580]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D16]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AddExplosionForce()
		{
		}
	}
}
