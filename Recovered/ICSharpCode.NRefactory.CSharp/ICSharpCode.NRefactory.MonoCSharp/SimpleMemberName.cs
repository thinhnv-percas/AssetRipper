namespace ICSharpCode.NRefactory.MonoCSharp
{
	public class SimpleMemberName
	{
		public string Value;

		public Location Location;

		public SimpleMemberName(string name, Location loc)
		{
			Value = name;
			Location = loc;
		}
	}
}
