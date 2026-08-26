using System.Collections.Generic;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	public class CloneContext
	{
		private Dictionary<Block, Block> block_map = new Dictionary<Block, Block>();

		public void AddBlockMap(Block from, Block to)
		{
			block_map.Add(from, to);
		}

		public Block LookupBlock(Block from)
		{
			if (!block_map.TryGetValue(from, out Block value))
			{
				return (Block)from.Clone(this);
			}
			return value;
		}

		public Block RemapBlockCopy(Block from)
		{
			if (!block_map.TryGetValue(from, out Block value))
			{
				return from;
			}
			return value;
		}
	}
}
