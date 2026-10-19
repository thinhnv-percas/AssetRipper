using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Systems.FlowSystem.Scripts.Core
{
	[CreateAssetMenu(menuName = "FlowSystem/FlowDatabase", fileName = "FlowDatabase", order = 0)]
	[Token(Token = "0x2000004")]
	public class FlowDatabase : ScriptableObject
	{
		[SerializeField]
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x18")]
		internal List<FlowStep> m_FlowSteps;

		[Token(Token = "0x17000001")]
		public IReadOnlyList<FlowStep> FlowSteps
		{
			[Token(Token = "0x6000003")]
			[Address(RVA = "0x81AB8C4", Offset = "0x81AB8C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_FlowSteps;\n")]
			get
			{
				return m_FlowSteps;
			}
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x81AB8CC", Offset = "0x81AB8CC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		public FlowDatabase()
		{
		}
	}
}
