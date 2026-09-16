using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75BA40", Offset = "0x75BA40")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75BA40", Offset = "0x75BA40")]
	[Token(Token = "0x20002F8")]
	public class QuaternionLowPassFilter : QuaternionBaseAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C1CB0", Offset = "0x7C1CB0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1CB0", Offset = "0x7C1CB0")]
		[Token(Token = "0x4001916")]
		[FieldOffset(Offset = "0x50")]
		public FsmQuaternion quaternionVariable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1D10", Offset = "0x7C1D10")]
		[Token(Token = "0x4001917")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat filteringFactor;

		[Token(Token = "0x4001918")]
		[FieldOffset(Offset = "0x60")]
		private Quaternion filteredQuaternion;

		[Token(Token = "0x6000EE3")]
		[Address(RVA = "0xB1C338", Offset = "0xB1C338", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.quaternionVariable = 0;\n\tv13 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0.1f);\n\tthis.filteringFactor = v13;\n\tthis.everyFrame = 1;\n\tthis.everyFrameOption = 0;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			quaternionVariable = null;
			FsmFloat fsmFloat = 0.1f;
			filteringFactor = fsmFloat;
			everyFrame = true;
			everyFrameOption = default(everyFrameOptions);
		}

		[Token(Token = "0x6000EE4")]
		[Address(RVA = "0xB1C378", Offset = "0xB1C378", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.quaternionVariable;\n\tv17 = 0;\n\tv20 = 0x10CB640(&v17 @ stack_-30_v1 (System.Single), 0, v21, v22, v23, v24, v25, v26, v10.value, v10.value.y, v10.value.z, v10.value.w, v27, v28, v29, v30);\n\tthis.filteredQuaternion.x = 0f;\n\tthis.filteredQuaternion.y = v40;\n\tthis.filteredQuaternion.w = v42;\n\tv44 = ~this.everyFrame;\n\tv45 = ~v44;\n\tif (v45) goto L_0023;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\nL_0023:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_0046: Expected F4, but got O
			FsmQuaternion fsmQuaternion = quaternionVariable;
			float num = 0f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CB640 (inside UnityEngine.QualitySettings::get_activeColorSpace +0x34)");
			filteredQuaternion.x = 0f;
			object obj = default(object);
			filteredQuaternion.y = (float)obj;
			float w = default(float);
			filteredQuaternion.w = w;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000EE5")]
		[Address(RVA = "0xB1C3F0", Offset = "0xB1C3F0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.everyFrameOption == 0;\n\tif (v2) goto L_0004;\n\treturn;\nL_0004:\n\tHutongGames.PlayMaker.Actions.QuaternionLowPassFilter::DoQuatLowPassFilter(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			if (everyFrameOption == everyFrameOptions.Update)
			{
				DoQuatLowPassFilter();
			}
		}

		[Token(Token = "0x6000EE6")]
		[Address(RVA = "0xB1C598", Offset = "0xB1C598", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.everyFrameOption != 2;\n\tif (v11) goto L_000E;\n\tHutongGames.PlayMaker.Actions.QuaternionLowPassFilter::DoQuatLowPassFilter(this);\n\treturn;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnLateUpdate()
		{
			if (everyFrameOption == everyFrameOptions.LateUpdate)
			{
				DoQuatLowPassFilter();
			}
		}

		[Token(Token = "0x6000EE7")]
		[Address(RVA = "0xB1C5AC", Offset = "0xB1C5AC", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.everyFrameOption != 1;\n\tif (v11) goto L_000E;\n\tHutongGames.PlayMaker.Actions.QuaternionLowPassFilter::DoQuatLowPassFilter(this);\n\treturn;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnFixedUpdate()
		{
			if (everyFrameOption == everyFrameOptions.FixedUpdate)
			{
				DoQuatLowPassFilter();
			}
		}

		[Token(Token = "0x6000EE8")]
		[Address(RVA = "0xB1C400", Offset = "0xB1C400", Length = "0x198")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = this.quaternionVariable;\n\tv92 = HutongGames.PlayMaker.FsmFloat::get_Value(this.filteringFactor);\n\tv136 = HutongGames.PlayMaker.FsmFloat::get_Value(this.filteringFactor);\n\tv47 = v20.value * v92;\n\tv86 = this.quaternionVariable;\n\tv171 = 1f - v136;\n\tv172 = this.filteredQuaternion * v171;\n\tv63 = v47 + v172;\n\tthis.filteredQuaternion.x = v63;\n\tv104 = HutongGames.PlayMaker.FsmFloat::get_Value(this.filteringFactor);\n\tv173 = HutongGames.PlayMaker.FsmFloat::get_Value(this.filteringFactor);\n\tv87 = this.quaternionVariable;\n\tv174 = 1f - v173;\n\tv48 = v86.value.y * v104;\n\tv175 = this.filteredQuaternion.y * v174;\n\tv64 = v48 + v175;\n\tthis.filteredQuaternion.y = v64;\n\tv105 = HutongGames.PlayMaker.FsmFloat::get_Value(this.filteringFactor);\n\tv176 = HutongGames.PlayMaker.FsmFloat::get_Value(this.filteringFactor);\n\tv88 = this.quaternionVariable;\n\tv177 = 1f - v176;\n\tv49 = v87.value.z * v105;\n\tv178 = this.filteredQuaternion.z * v177;\n\tv65 = v49 + v178;\n\tthis.filteredQuaternion.z = v65;\n\tv106 = HutongGames.PlayMaker.FsmFloat::get_Value(this.filteringFactor);\n\tv180 = HutongGames.PlayMaker.FsmFloat::get_Value(this.filteringFactor);\n\tv181 = 1f - v180;\n\tv34 = this.quaternionVariable;\n\tv182 = v88.value.w * v106;\n\tv40 = this.filteredQuaternion.w * v181;\n\tv32 = v182 + v40;\n\tthis.filteredQuaternion.w = v32;\n\tv29 = 0;\n\tv79 = 0x10CB640(&v29 @ stack_-50_v3 (System.Single), 0, v127, v128, v129, v130, v131, v132, this.filteredQuaternion, this.filteredQuaternion.y, this.filteredQuaternion.z, v32, v40, v133, v134, v135);\n\tv34.value.x = 0f;\n\tv34.value.y = v184;\n\tv34.value.w = v185;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoQuatLowPassFilter()
		{
			//IL_0288: Expected F4, but got O
			FsmQuaternion fsmQuaternion = quaternionVariable;
			float value = filteringFactor.Value;
			float value2 = filteringFactor.Value;
			float num = fsmQuaternion.value.x * value;
			FsmQuaternion fsmQuaternion2 = quaternionVariable;
			float num2 = 1f - value2;
			float num3 = filteredQuaternion.x * num2;
			float x = num + num3;
			filteredQuaternion.x = x;
			float value3 = filteringFactor.Value;
			float value4 = filteringFactor.Value;
			FsmQuaternion fsmQuaternion3 = quaternionVariable;
			float num4 = 1f - value4;
			float num5 = fsmQuaternion2.value.y * value3;
			float num6 = filteredQuaternion.y * num4;
			float y = num5 + num6;
			filteredQuaternion.y = y;
			float value5 = filteringFactor.Value;
			float value6 = filteringFactor.Value;
			FsmQuaternion fsmQuaternion4 = quaternionVariable;
			float num7 = 1f - value6;
			float num8 = fsmQuaternion3.value.z * value5;
			float num9 = filteredQuaternion.z * num7;
			float z = num8 + num9;
			filteredQuaternion.z = z;
			float value7 = filteringFactor.Value;
			float value8 = filteringFactor.Value;
			float num10 = 1f - value8;
			FsmQuaternion fsmQuaternion5 = quaternionVariable;
			float num11 = fsmQuaternion4.value.w * value7;
			float num12 = filteredQuaternion.w * num10;
			float w = num11 + num12;
			filteredQuaternion.w = w;
			float num13 = 0f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CB640 (inside UnityEngine.QualitySettings::get_activeColorSpace +0x34)");
			fsmQuaternion5.value.x = 0f;
			object obj = default(object);
			fsmQuaternion5.value.y = (float)obj;
			float w2 = default(float);
			fsmQuaternion5.value.w = w2;
		}

		[Token(Token = "0x6000EE9")]
		[Address(RVA = "0xB1C5C0", Offset = "0xB1C5C0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public QuaternionLowPassFilter()
		{
		}
	}
}
