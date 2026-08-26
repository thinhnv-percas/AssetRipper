#define FULL_AST
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	public class LocationsBag
	{
		public class MemberLocations
		{
			private List<Location> locations;

			public IList<Tuple<Modifiers, Location>> Modifiers
			{
				get;
				internal set;
			}

			public Location this[int index] => locations[index];

			public int Count
			{
				get
				{
					if (locations == null)
					{
						return 0;
					}
					return locations.Count;
				}
			}

			public MemberLocations(IList<Tuple<Modifiers, Location>> mods, IEnumerable<Location> locs)
			{
				Modifiers = mods;
				locations = ((locs != null) ? new List<Location>(locs) : null);
			}

			public void AddLocations(Location loc)
			{
				if (locations == null)
				{
					locations = new List<Location>();
				}
				locations.Add(loc);
			}

			public void AddLocations(params Location[] additional)
			{
				AddLocations((IEnumerable<Location>)additional);
			}

			public void AddLocations(IEnumerable<Location> additional)
			{
				if (additional != null)
				{
					if (locations == null)
					{
						locations = new List<Location>(additional);
					}
					else
					{
						locations.AddRange(additional);
					}
				}
			}
		}

		private Dictionary<object, List<Location>> simple_locs = new Dictionary<object, List<Location>>(ReferenceEquality<object>.Default);

		private Dictionary<MemberCore, MemberLocations> member_locs = new Dictionary<MemberCore, MemberLocations>(ReferenceEquality<MemberCore>.Default);

		public MemberCore LastMember
		{
			get;
			private set;
		}

		[Conditional("FULL_AST")]
		public void AddLocation(object element, params Location[] locations)
		{
			AddLocation(element, (IEnumerable<Location>)locations);
		}

		[Conditional("FULL_AST")]
		public void AddLocation(object element, IEnumerable<Location> locations)
		{
			if (element != null && locations != null)
			{
				if (!simple_locs.TryGetValue(element, out List<Location> value))
				{
					simple_locs.Add(element, new List<Location>(locations));
				}
				else
				{
					value.AddRange(locations);
				}
			}
		}

		[Conditional("FULL_AST")]
		public void InsertLocation(object element, int index, Location location)
		{
			if (!simple_locs.TryGetValue(element, out List<Location> value))
			{
				value = new List<Location>();
				simple_locs.Add(element, value);
			}
			value.Insert(index, location);
		}

		[Conditional("FULL_AST")]
		public void AddStatement(object element, params Location[] locations)
		{
			if (element != null)
			{
				if (locations.Length == 0)
				{
					throw new ArgumentException("Statement is missing semicolon location");
				}
				simple_locs.Add(element, new List<Location>(locations));
			}
		}

		[Conditional("FULL_AST")]
		public void AddMember(MemberCore member, IList<Tuple<Modifiers, Location>> modLocations, params Location[] locations)
		{
			LastMember = member;
			if (member != null)
			{
				if (member_locs.TryGetValue(member, out MemberLocations value))
				{
					value.Modifiers = modLocations;
					value.AddLocations(locations);
				}
				else
				{
					member_locs.Add(member, new MemberLocations(modLocations, locations));
				}
			}
		}

		[Conditional("FULL_AST")]
		public void AddMember(MemberCore member, IList<Tuple<Modifiers, Location>> modLocations, IEnumerable<Location> locations)
		{
			LastMember = member;
			if (member != null)
			{
				if (member_locs.TryGetValue(member, out MemberLocations value))
				{
					value.Modifiers = modLocations;
					value.AddLocations(locations);
				}
				else
				{
					member_locs.Add(member, new MemberLocations(modLocations, locations));
				}
			}
		}

		[Conditional("FULL_AST")]
		public void AppendToMember(MemberCore existing, params Location[] locations)
		{
			AppendToMember(existing, (IEnumerable<Location>)locations);
		}

		[Conditional("FULL_AST")]
		public void AppendToMember(MemberCore existing, IEnumerable<Location> locations)
		{
			if (existing != null)
			{
				if (member_locs.TryGetValue(existing, out MemberLocations value))
				{
					value.AddLocations(locations);
				}
				else
				{
					member_locs.Add(existing, new MemberLocations(null, locations));
				}
			}
		}

		public List<Location> GetLocations(object element)
		{
			if (element == null)
			{
				return null;
			}
			simple_locs.TryGetValue(element, out List<Location> value);
			return value;
		}

		public MemberLocations GetMemberLocation(MemberCore element)
		{
			member_locs.TryGetValue(element, out MemberLocations value);
			return value;
		}
	}
}
