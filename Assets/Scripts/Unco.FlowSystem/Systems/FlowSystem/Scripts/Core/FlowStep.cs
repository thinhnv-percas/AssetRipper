using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;

namespace Systems.FlowSystem.Scripts.Core
{
	[Serializable]
	[Token(Token = "0x200000B")]
	public abstract class FlowStep : ScriptableObject
	{
		[HideInInspector]
		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x18")]
		public bool FlowCompleted;

		[Inject(false)]
		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x20")]
		internal FlowManager _manager;

		[Token(Token = "0x17000004")]
		public abstract FlowId FlowId
		{
			[Token(Token = "0x600001B")]
			get;
		}

		[Token(Token = "0x600001C")]
		public abstract void InitFlow();

		[Token(Token = "0x600001D")]
		public abstract bool IsFlowCompleted();

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x81ABCE0", Offset = "0x81ABCE0", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.FlowCompleted = 1;\n\tv12 = this._manager;\n\tv15 = v12.OnFlowCompleted == 0;\n\tif (v15) goto L_0021;\n\tv35 = Systems.FlowSystem.Scripts.Core.FlowStep::get_FlowId(this);\n\tSystem.Action`1<Systems.FlowSystem.Scripts.Core.FlowId>::Invoke(v12.OnFlowCompleted, v35);\n\treturn;\nL_0021:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetFlowCompleted()
		{
			FlowCompleted = true;
			FlowManager manager = _manager;
			if (manager.OnFlowCompleted != null)
			{
				FlowId flowId = FlowId;
				manager.OnFlowCompleted(flowId);
			}
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x81AC324", Offset = "0x81AC324", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.FlowCompleted = 0;\n\treturn;\n")]
		public void ResetFlowStep()
		{
			FlowCompleted = false;
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x81AC32C", Offset = "0x81AC32C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		public FlowStep()
		{
		}
	}
}
