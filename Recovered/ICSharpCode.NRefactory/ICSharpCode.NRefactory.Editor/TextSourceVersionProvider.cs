using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ICSharpCode.NRefactory.Editor
{
	public class TextSourceVersionProvider
	{
		[DebuggerDisplay("Version #{id}")]
		private sealed class Version : ITextSourceVersion
		{
			private readonly TextSourceVersionProvider provider;

			private readonly int id;

			internal TextChangeEventArgs change;

			internal Version next;

			internal Version(TextSourceVersionProvider provider)
			{
				this.provider = provider;
			}

			internal Version(Version prev)
			{
				provider = prev.provider;
				id = prev.id + 1;
			}

			public bool BelongsToSameDocumentAs(ITextSourceVersion other)
			{
				Version version = other as Version;
				if (version != null)
				{
					return provider == version.provider;
				}
				return false;
			}

			public int CompareAge(ITextSourceVersion other)
			{
				if (other == null)
				{
					throw new ArgumentNullException("other");
				}
				Version version = other as Version;
				if (version == null || provider != version.provider)
				{
					throw new ArgumentException("Versions do not belong to the same document.");
				}
				return Math.Sign(id - version.id);
			}

			public IEnumerable<TextChangeEventArgs> GetChangesTo(ITextSourceVersion other)
			{
				int num = CompareAge(other);
				Version version = (Version)other;
				if (num < 0)
				{
					return GetForwardChanges(version);
				}
				if (num > 0)
				{
					return from change in version.GetForwardChanges(this).Reverse()
						select change.Invert();
				}
				return EmptyList<TextChangeEventArgs>.Instance;
			}

			private IEnumerable<TextChangeEventArgs> GetForwardChanges(Version other)
			{
				for (Version node = this; node != other; node = node.next)
				{
					yield return node.change;
				}
			}

			public int MoveOffsetTo(ITextSourceVersion other, int oldOffset, AnchorMovementType movement)
			{
				int num = oldOffset;
				foreach (TextChangeEventArgs item in GetChangesTo(other))
				{
					num = item.GetNewOffset(num, movement);
				}
				return num;
			}
		}

		private Version currentVersion;

		public ITextSourceVersion CurrentVersion => currentVersion;

		public TextSourceVersionProvider()
		{
			currentVersion = new Version(this);
		}

		public void AppendChange(TextChangeEventArgs change)
		{
			if (change == null)
			{
				throw new ArgumentNullException("change");
			}
			currentVersion.change = change;
			currentVersion.next = new Version(currentVersion);
			currentVersion = currentVersion.next;
		}
	}
}
