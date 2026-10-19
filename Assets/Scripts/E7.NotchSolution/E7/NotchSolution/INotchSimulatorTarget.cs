using Cpp2ILInjected;
using UnityEngine;

namespace E7.NotchSolution
{
	[Token(Token = "0x2000008")]
	public interface INotchSimulatorTarget
	{
		[Token(Token = "0x6000011")]
		void SimulatorUpdate(Rect simulatedSafeAreaRelative, Rect[] simulatedCutoutsRelative);
	}
}
