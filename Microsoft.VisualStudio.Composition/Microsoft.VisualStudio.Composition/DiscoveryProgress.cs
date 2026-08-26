namespace Microsoft.VisualStudio.Composition;

public struct DiscoveryProgress
{
	public int CompletedSteps { get; private set; }

	public int TotalSteps { get; private set; }

	public float Completion
	{
		get
		{
			if (TotalSteps <= 0)
			{
				return 0f;
			}
			return (float)CompletedSteps / (float)TotalSteps;
		}
	}

	public string Status { get; private set; }

	public DiscoveryProgress(int completedSteps, int totalSteps, string status)
	{
		this = default(DiscoveryProgress);
		CompletedSteps = completedSteps;
		TotalSteps = totalSteps;
		Status = status;
	}
}
