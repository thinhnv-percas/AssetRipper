using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Systems.FlowSystem.Scripts.Core
{
	[CreateAssetMenu(menuName = "FlowSystem/FlowEditorConfiguration", fileName = "FlowEditorConfiguration", order = 0)]
	[Token(Token = "0x2000005")]
	public class FlowEditorConfiguration : ScriptableObject
	{
		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x18")]
		private List<FlowId> _activeFlows;

		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x20")]
		private bool _playOnAwake;

		[Token(Token = "0x17000002")]
		public List<FlowId> ActiveFlows
		{
			[Token(Token = "0x6000005")]
			[Address(RVA = "0x81AB8D4", Offset = "0x81AB8D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ActiveFlows;\n")]
			get
			{
				return _activeFlows;
			}
		}

		[Token(Token = "0x17000003")]
		public bool PlayOnAwake
		{
			[Token(Token = "0x6000006")]
			[Address(RVA = "0x81AB8DC", Offset = "0x81AB8DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.PlayOnAwake;\n")]
			get
			{
				return _playOnAwake;
			}
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x81AB8E4", Offset = "0x81AB8E4", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.ActiveFlows = activeFlows;\n\tthis.PlayOnAwake = 1;\n\treturn;\n")]
		public void SetActiveFlows(List<FlowId> activeFlows)
		{
			_activeFlows = activeFlows;
			_playOnAwake = true;
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x81AB914", Offset = "0x81AB914", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.ActiveFlows = 0;\n\tthis.PlayOnAwake = 0;\n\treturn;\n")]
		public void Reset()
		{
			_activeFlows = null;
			_playOnAwake = false;
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x81AB944", Offset = "0x81AB944", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<Systems.FlowSystem.Scripts.Core.FlowId>();\n\tSystem.Collections.Generic.List`1<Systems.FlowSystem.Scripts.Core.FlowId>::.ctor(v48);\n\tthis.ActiveFlows = v48;\n")]
		public FlowEditorConfiguration()
		{
			List<FlowId> activeFlows = new List<FlowId>();
			_activeFlows = activeFlows;
		}
	}
}
