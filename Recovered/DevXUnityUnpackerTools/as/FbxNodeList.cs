using System.Collections.Generic;

namespace @as
{
	internal abstract class FbxNodeList
	{
		internal List<_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A> Nodes
		{
			get;
			set;
		} = new List<_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A>();


		internal _0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A this[string name] => Nodes.Find((_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A n) => n != null && n._0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020 == name);

		internal _0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A GetRelative(string path, bool create_if_not_exist = false)
		{
			string[] array = path.Split('/');
			FbxNodeList fbxNodeList = this;
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (text == "")
				{
					continue;
				}
				if (fbxNodeList[text] == null)
				{
					if (!create_if_not_exist)
					{
						break;
					}
					_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A _0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A = new _0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A();
					_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020 = text;
					fbxNodeList.Nodes.Add(_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A);
					fbxNodeList = _0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A;
				}
				else
				{
					fbxNodeList = fbxNodeList[text];
				}
			}
			return fbxNodeList as _0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A;
		}
	}
}
