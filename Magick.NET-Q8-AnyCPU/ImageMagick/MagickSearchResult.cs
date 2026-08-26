using System;

namespace ImageMagick;

public sealed class MagickSearchResult : IDisposable
{
	public MagickGeometry BestMatch { get; private set; }

	public IMagickImage SimilarityImage { get; private set; }

	public double SimilarityMetric { get; set; }

	internal MagickSearchResult(IMagickImage image, MagickGeometry bestMatch, double similarityMetric)
	{
		SimilarityImage = image;
		BestMatch = bestMatch;
		SimilarityMetric = similarityMetric;
	}

	public void Dispose()
	{
		if (SimilarityImage != null)
		{
			SimilarityImage.Dispose();
		}
		SimilarityImage = null;
	}
}
