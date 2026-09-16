using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x200006E")]
	public class SpineboyFacialExpression : MonoBehaviour
	{
		[Token(Token = "0x4000258")]
		[FieldOffset(Offset = "0x20")]
		public SpineboyFootplanter footPlanter;

		[SpineSlot(null, null, false, true, false)]
		[Token(Token = "0x4000259")]
		[FieldOffset(Offset = "0x28")]
		public string eyeSlotName;

		[SpineSlot(null, null, false, true, false)]
		[Token(Token = "0x400025A")]
		[FieldOffset(Offset = "0x30")]
		public string mouthSlotName;

		[SpineAttachment(true, false, false, "eyeSlotName", null, null, true, false)]
		[Token(Token = "0x400025B")]
		[FieldOffset(Offset = "0x38")]
		public string shockEyeName;

		[SpineAttachment(true, false, false, "eyeSlotName", null, null, true, false)]
		[Token(Token = "0x400025C")]
		[FieldOffset(Offset = "0x40")]
		public string normalEyeName;

		[SpineAttachment(true, false, false, "mouthSlotName", null, null, true, false)]
		[Token(Token = "0x400025D")]
		[FieldOffset(Offset = "0x48")]
		public string shockMouthName;

		[SpineAttachment(true, false, false, "mouthSlotName", null, null, true, false)]
		[Token(Token = "0x400025E")]
		[FieldOffset(Offset = "0x50")]
		public string normalMouthName;

		[Token(Token = "0x400025F")]
		[FieldOffset(Offset = "0x58")]
		public Slot eyeSlot;

		[Token(Token = "0x4000260")]
		[FieldOffset(Offset = "0x60")]
		public Slot mouthSlot;

		[Token(Token = "0x4000261")]
		[FieldOffset(Offset = "0x68")]
		public Attachment shockEye;

		[Token(Token = "0x4000262")]
		[FieldOffset(Offset = "0x70")]
		public Attachment normalEye;

		[Token(Token = "0x4000263")]
		[FieldOffset(Offset = "0x78")]
		public Attachment shockMouth;

		[Token(Token = "0x4000264")]
		[FieldOffset(Offset = "0x80")]
		public Attachment normalMouth;

		[Token(Token = "0x4000265")]
		[FieldOffset(Offset = "0x88")]
		public float balanceThreshold;

		[Token(Token = "0x4000266")]
		[FieldOffset(Offset = "0x8C")]
		public float shockDuration;

		[Header("Debug")]
		[Token(Token = "0x4000267")]
		[FieldOffset(Offset = "0x90")]
		public float shockTimer;

		[Token(Token = "0x60001E7")]
		[Address(RVA = "0x151F5D0", Offset = "0x151F5D0", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37AB7]) = v37;\nL_0015:\n\tv40 = UnityEngine.Component::GetComponent(this);\n\tv43 = Spine.Unity.SkeletonRenderer::get_Skeleton(v40);\n\tv52 = Spine.Skeleton::FindSlot(v43, this.eyeSlotName);\n\tthis.eyeSlot = v52;\n\tv73 = Spine.Skeleton::FindSlot(v43, this.mouthSlotName);\n\tthis.mouthSlot = v73;\n\tv77 = Spine.Skeleton::FindSlotIndex(v43, this.eyeSlotName);\n\tv83 = Spine.Skeleton::GetAttachment(v43, v77, this.shockEyeName);\n\tthis.shockEye = v83;\n\tv88 = Spine.Skeleton::GetAttachment(v43, v77, this.normalEyeName);\n\tthis.normalEye = v88;\n\tv92 = Spine.Skeleton::FindSlotIndex(v43, this.mouthSlotName);\n\tv98 = Spine.Skeleton::GetAttachment(v43, v92, this.shockMouthName);\n\tthis.shockMouth = v98;\n\tv62 = Spine.Skeleton::GetAttachment(v43, v92, this.normalMouthName);\n\tthis.normalMouth = v62;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			SkeletonAnimation component = GetComponent<SkeletonAnimation>();
			Skeleton skeleton = component.Skeleton;
			Slot slot = skeleton.FindSlot(eyeSlotName);
			eyeSlot = slot;
			Slot slot2 = skeleton.FindSlot(mouthSlotName);
			mouthSlot = slot2;
			int slotIndex = skeleton.FindSlotIndex(eyeSlotName);
			Attachment attachment = skeleton.GetAttachment(slotIndex, shockEyeName);
			shockEye = attachment;
			Attachment attachment2 = skeleton.GetAttachment(slotIndex, normalEyeName);
			normalEye = attachment2;
			int slotIndex2 = skeleton.FindSlotIndex(mouthSlotName);
			Attachment attachment3 = skeleton.GetAttachment(slotIndex2, shockMouthName);
			shockMouth = attachment3;
			Attachment attachment4 = skeleton.GetAttachment(slotIndex2, normalMouthName);
			normalMouth = attachment4;
		}

		[Token(Token = "0x60001E8")]
		[Address(RVA = "0x151F6E0", Offset = "0x151F6E0", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.footPlanter;\n\tv12 = UnityEngine.Mathf::Abs(v6.balance);\n\tv88 = v12 <= this.balanceThreshold;\n\tif (v88) goto L_001B;\n\tv26 = this.shockDuration;\n\tthis.shockTimer = this.shockDuration;\n\tgoto L_0027;\nL_001B:\n\tv26 = this.shockTimer;\nL_0027:\n\tv130 = v26 <= 0;\n\tif (v130) goto L_0039;\n\tv132 = UnityEngine.Time::get_deltaTime();\n\tv26 = v26 - v132;\n\tthis.shockTimer = v26;\nL_0039:\n\tv29 = v26 <= 0;\n\tif (v29) goto L_0049;\n\tSpine.Slot::set_Attachment(this.eyeSlot, this.shockEye);\n\tv98 = this.mouthSlot;\n\tv117 = this + 0x78;\n\tgoto L_0054;\nL_0049:\n\tSpine.Slot::set_Attachment(this.eyeSlot, this.normalEye);\n\tv98 = this.mouthSlot;\n\tv117 = this + 0x80;\nL_0054:\n\tSpine.Slot::set_Attachment(v98, *([v117 @ X8_v2]));\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			//IL_00f2: Expected O, but got I
			//IL_00c1: Expected O, but got I
			SpineboyFootplanter spineboyFootplanter = footPlanter;
			float num = Mathf.Abs(spineboyFootplanter.Balance);
			float num2;
			if (num > balanceThreshold)
			{
				num2 = shockDuration;
				shockTimer = shockDuration;
			}
			else
			{
				num2 = shockTimer;
			}
			if (num2 > 0f)
			{
				float deltaTime = Time.deltaTime;
				num2 = (shockTimer = num2 - deltaTime);
			}
			Slot slot;
			object attachment;
			if (num2 > 0f)
			{
				eyeSlot.Attachment = shockEye;
				slot = mouthSlot;
				attachment = (nint)this + 120;
			}
			else
			{
				eyeSlot.Attachment = normalEye;
				slot = mouthSlot;
				attachment = (nint)this + 128;
			}
			slot.Attachment = (Attachment)attachment;
		}

		[Token(Token = "0x60001E9")]
		[Address(RVA = "0x151F790", Offset = "0x151F790", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.balanceThreshold = 0.007812501866283128d;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpineboyFacialExpression()
		{
			balanceThreshold = 2.5f;
			shockDuration = 1f;
		}
	}
}
