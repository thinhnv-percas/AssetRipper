namespace DecompTools.Decompiler.FlowAnalysis;

public interface IDataFlowState<Self> where Self : IDataFlowState<Self>
{
	bool IsBottom { get; }

	bool LessThanOrEqual(Self otherState);

	Self Clone();

	void ReplaceWith(Self newContent);

	void JoinWith(Self incomingState);

	void TriggerFinally(Self finallyState);

	void ReplaceWithBottom();
}
