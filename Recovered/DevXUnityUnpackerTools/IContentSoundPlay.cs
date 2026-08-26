internal interface IContentSoundPlay : IContent
{
	string AudioInfo
	{
		get;
	}

	void Play();

	void Stop();
}
