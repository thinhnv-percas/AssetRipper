using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace EdiTools
{
	public class EdiMapping
	{
		private class _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020
		{
			private readonly bool _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020;

			[CompilerGenerated]
			private string _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_000A;

			[CompilerGenerated]
			private string _0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020;

			[CompilerGenerated]
			private _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_000A _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A;

			public string Id
			{
				get;
				private set;
			}

			public string Type
			{
				get;
				private set;
			}

			public _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_000A Options
			{
				get;
				private set;
			}

			public _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020(string id, string type, bool restrict)
			{
				Id = id;
				Type = type;
				Options = new _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_000A();
				_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020 = restrict;
			}

			public bool IsMatch(EdiComponent component)
			{
				if (_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020)
				{
					if (component != null)
					{
						return Options.Contains(component.Value);
					}
					return false;
				}
				return true;
			}
		}

		private class _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020
		{
			private readonly bool _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020;

			[CompilerGenerated]
			private string _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_000A;

			[CompilerGenerated]
			private string _0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020;

			[CompilerGenerated]
			private IList<_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020> _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_0020;

			[CompilerGenerated]
			private _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_000A _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A;

			public string Id
			{
				get;
				private set;
			}

			public string Type
			{
				get;
				private set;
			}

			public IList<_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020> Components
			{
				get;
				private set;
			}

			public _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_000A Options
			{
				get;
				private set;
			}

			public _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020(string id, string type, bool restrict)
			{
				Id = id;
				Type = type;
				Components = new List<_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020>();
				Options = new _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_000A();
				_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020 = restrict;
			}

			public bool IsMatch(EdiElement element)
			{
				if (_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020 && element == null)
				{
					return false;
				}
				foreach (EdiRepetition repetition in element.Repetitions)
				{
					if (_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020 && !Options.Contains(repetition.Value))
					{
						return false;
					}
					if (repetition.Components.Where(_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A).Any())
					{
						return false;
					}
				}
				return true;
			}

			[CompilerGenerated]
			private bool _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A(EdiComponent _0020, int _0020_000A)
			{
				if (Components.Count > _0020_000A && Components[_0020_000A] != null)
				{
					return !Components[_0020_000A].IsMatch(_0020);
				}
				return false;
			}
		}

		private class _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020 : Node
		{
			[CompilerGenerated]
			private IList<Node> _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020;

			public IList<Node> Nodes
			{
				get;
				private set;
			}

			public _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020(string id)
			{
				base.Id = id;
				Nodes = new List<Node>();
			}

			public Node FindMatchingNode(EdiSegment segment)
			{
				foreach (Node node in Nodes)
				{
					if (node is _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A)
					{
						if (((_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A)node).IsMatch(segment))
						{
							return node;
						}
					}
					else
					{
						_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A = ((_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020)node)._0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A();
						if (_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A != null && _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A.IsMatch(segment))
						{
							return node;
						}
					}
				}
				return null;
			}

			private _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A()
			{
				if (Nodes.Count == 0)
				{
					return null;
				}
				_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A = Nodes[0] as _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A;
				if (_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A != null)
				{
					return _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A;
				}
				return ((_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020)Nodes[0])._0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A();
			}
		}

		private class _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A
		{
			public class LoopState
			{
				[CompilerGenerated]
				private _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020 _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A;

				[CompilerGenerated]
				private HashSet<string> _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020;

				public _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020 Loop
				{
					get;
					private set;
				}

				public HashSet<string> VisitedSegmentIds
				{
					get;
					private set;
				}

				public LoopState(_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020 loop)
				{
					Loop = loop;
					VisitedSegmentIds = new HashSet<string>();
				}
			}

			[CompilerGenerated]
			private IList<EdiSegment> _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020;

			[CompilerGenerated]
			private int _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A;

			[CompilerGenerated]
			private Stack<LoopState> _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020;

			public IList<EdiSegment> Segments
			{
				get;
				private set;
			}

			public int SegmentIndex
			{
				get;
				set;
			}

			public Stack<LoopState> LoopStates
			{
				get;
				private set;
			}

			public _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A(IList<EdiSegment> segments)
			{
				Segments = segments;
				LoopStates = new Stack<LoopState>();
			}
		}

		private abstract class Node
		{
			public string Id
			{
				get;
				protected set;
			}
		}

		private class _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_000A
		{
			private class _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020
			{
				[CompilerGenerated]
				private string _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020;

				[CompilerGenerated]
				private string _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_000A_000A;

				public string Value
				{
					get;
					private set;
				}

				public string Definition
				{
					get;
					private set;
				}

				public _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020(string value, string definition)
				{
					Value = value;
					Definition = definition;
				}
			}

			[CompilerGenerated]
			private sealed class _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020
			{
				public string _0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020;

				internal bool _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A(_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020 _0020)
				{
					return _0020.Value.Equals(_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020, StringComparison.OrdinalIgnoreCase);
				}
			}

			[CompilerGenerated]
			private sealed class _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020
			{
				public string _0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020;

				internal bool _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A(_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020 _0020)
				{
					return _0020.Value.Equals(_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020, StringComparison.OrdinalIgnoreCase);
				}
			}

			[CompilerGenerated]
			private sealed class _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020
			{
				public string _0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020;

				internal bool _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A(_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020 _0020)
				{
					return _0020.Value.Equals(_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020, StringComparison.OrdinalIgnoreCase);
				}
			}

			private readonly IList<_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020> _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_000A_0020 = new List<_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020>();

			public string this[string key]
			{
				get
				{
					_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020 _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020 = new _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020();
					_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020._0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020 = key;
					_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020 _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020 = _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_000A_0020.FirstOrDefault(_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020._0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A);
					if (_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020 == null)
					{
						throw new KeyNotFoundException();
					}
					return _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020.Definition;
				}
				set
				{
					_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020 _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020 = new _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020();
					_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020._0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020 = key;
					if (_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_000A_0020.FirstOrDefault(_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020._0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A) != null)
					{
						throw new NotSupportedException();
					}
					_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_000A_0020.Add(new _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020(_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020._0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020, value));
				}
			}

			public bool Contains(string key)
			{
				_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020 _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020 = new _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020();
				_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020._0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020 = key;
				return _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_000A_0020.Any(_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020._0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A);
			}
		}

		private class _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A : Node
		{
			[CompilerGenerated]
			private IList<_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020> _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A;

			public IList<_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020> Elements
			{
				get;
				private set;
			}

			public _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A(string id)
			{
				base.Id = id;
				Elements = new List<_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020>();
			}

			public bool IsMatch(EdiSegment segment)
			{
				if (base.Id.Equals(segment.Id, StringComparison.OrdinalIgnoreCase))
				{
					return !segment.Elements.Where(_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020).Any();
				}
				return false;
			}

			[CompilerGenerated]
			private bool _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020(EdiElement _0020, int _0020_000A)
			{
				if (Elements.Count > _0020_000A && Elements[_0020_000A] != null)
				{
					return !Elements[_0020_000A].IsMatch(_0020);
				}
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A
		{
			public EdiSegment _0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A;

			internal bool _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020(_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A.LoopState _0020)
			{
				if (!_0020.VisitedSegmentIds.Contains(_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A.Id))
				{
					return _0020.Loop.FindMatchingNode(_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A) != null;
				}
				return false;
			}
		}

		private readonly _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020 _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_000A;

		[CompilerGenerated]
		private IList<string> _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_0020;

		public IList<string> Errors
		{
			get;
			private set;
		}

		private EdiMapping(XDocument xml)
		{
			if (xml.Root == null)
			{
				throw new Exception("XML is missing a root element.");
			}
			Errors = new List<string>();
			_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_000A = _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020(xml.Root);
		}

		public static EdiMapping Parse(string text)
		{
			return new EdiMapping(XDocument.Parse(text));
		}

		public static EdiMapping Load(XDocument xml)
		{
			return new EdiMapping(xml);
		}

		public static EdiMapping Load(string fileName)
		{
			return new EdiMapping(XDocument.Load(fileName));
		}

		public static EdiMapping Load(TextReader reader)
		{
			return new EdiMapping(XDocument.Load(reader));
		}

		public static EdiMapping Load(Stream stream)
		{
			using (StreamReader textReader = new StreamReader(stream))
			{
				return new EdiMapping(XDocument.Load(textReader));
			}
		}

		private Node _0020_000A_0020_0020_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020(XElement _0020)
		{
			if (_0020.Name.LocalName.EndsWith("loop"))
			{
				return _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020(_0020);
			}
			return _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A(_0020);
		}

		private _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020 _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020(XElement _0020)
		{
			_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020 _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020 = new _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020(_0020.Name.LocalName);
			foreach (XElement item in _0020.Elements())
			{
				_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020.Nodes.Add(_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020(item));
			}
			return _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020;
		}

		private _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A(XElement _0020)
		{
			_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A = new _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A(_0020.Name.LocalName);
			foreach (XElement item in _0020.Elements())
			{
				int num = _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020(item.Name.LocalName);
				while (_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A.Elements.Count <= num)
				{
					_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A.Elements.Add(null);
				}
				if (_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A.Elements[num] != null)
				{
					Errors.Add($"Element '{item.Name.LocalName}' occupies a position in the segment already taken by element '{_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A.Elements[num].Id}'.");
				}
				else
				{
					_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A.Elements[num] = _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A(item);
				}
			}
			return _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A;
		}

		private int _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020(string _0020)
		{
			if (_0020.Length < 2 || !int.TryParse(_0020.Substring(_0020.Length - 2), out int result))
			{
				Errors.Add($"Element '{_0020}' does not have a valid segment position.");
				return -1;
			}
			return result - 1;
		}

		private _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020 _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A(XElement _0020)
		{
			string type = _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020(_0020);
			bool restrict = _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020(_0020);
			_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020 _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020 = new _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020(_0020.Name.LocalName, type, restrict);
			foreach (XElement item in _0020.Elements())
			{
				if (item.Name.LocalName == "option")
				{
					string value = item.Value;
					if (_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020.Options.Contains(value))
					{
						Errors.Add($"Option '{value}' is already defined in the element.");
					}
					else
					{
						_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020.Options[value] = _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A(item);
					}
				}
				else
				{
					int num = _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020(item.Name.LocalName);
					while (_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020.Components.Count <= num)
					{
						_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020.Components.Add(null);
					}
					if (_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020.Components[num] != null)
					{
						Errors.Add($"Component '{item.Name.LocalName}' occupies a position in the element already taken by component '{_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020.Components[num].Id}'.");
					}
					else
					{
						_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020.Components[num] = _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020(item);
					}
				}
			}
			return _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020;
		}

		private string _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020(XElement _0020)
		{
			XAttribute xAttribute = _0020.Attribute("type");
			if (xAttribute == null)
			{
				return null;
			}
			if (_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A(xAttribute.Value))
			{
				return xAttribute.Value;
			}
			Errors.Add($"'{xAttribute.Value}' is not a valid type.");
			return null;
		}

		private bool _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A(string _0020)
		{
			return Regex.IsMatch(_0020, "^id|an|dt|tm|n[0-9]|r$");
		}

		private bool _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020(XElement _0020)
		{
			XAttribute xAttribute = _0020.Attribute("restrict");
			if (xAttribute == null)
			{
				return false;
			}
			return xAttribute.Value == "true";
		}

		private string _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A(XElement _0020)
		{
			return _0020.Attribute("definition")?.Value;
		}

		private _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020 _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020(XElement _0020)
		{
			string type = _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020(_0020);
			bool restrict = _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020(_0020);
			_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020 _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020 = new _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020(_0020.Name.LocalName, type, restrict);
			foreach (XElement item in _0020.Elements())
			{
				if (!(item.Name.LocalName != "option"))
				{
					string value = item.Value;
					if (_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020.Options.Contains(value))
					{
						Errors.Add($"Option '{value}' is already defined in the component.");
					}
					else
					{
						_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020.Options[value] = _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A(item);
					}
				}
			}
			return _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020;
		}

		public XDocument Map(IList<EdiSegment> segments)
		{
			_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A _0020 = new _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A(segments);
			XElement xElement = _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A(_0020, _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_000A);
			return new XDocument(xElement);
		}

		private XElement _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A(_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A _0020, _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020 _0020_000A)
		{
			XElement xElement = new XElement(_0020_000A.Id);
			string text = null;
			_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A.LoopState loopState = new _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A.LoopState(_0020_000A);
			_0020.LoopStates.Push(loopState);
			while (_0020.SegmentIndex < _0020.Segments.Count)
			{
				EdiSegment ediSegment = _0020.Segments[_0020.SegmentIndex];
				if (loopState.VisitedSegmentIds.Contains(ediSegment.Id))
				{
					break;
				}
				Node node = _0020_000A.FindMatchingNode(ediSegment);
				if (node == null && _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020(ediSegment, _0020))
				{
					break;
				}
				if (node is _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020)
				{
					xElement.Add(_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A(_0020, (_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020)node));
				}
				else
				{
					xElement.Add(_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A(ediSegment, (_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A)node));
					_0020.SegmentIndex++;
				}
				if (text == null)
				{
					if (_0020_000A != _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_000A)
					{
						loopState.VisitedSegmentIds.Add(ediSegment.Id);
					}
				}
				else if (text != ediSegment.Id)
				{
					loopState.VisitedSegmentIds.Add(text);
				}
				text = ediSegment.Id;
			}
			_0020.LoopStates.Pop();
			return xElement;
		}

		private bool _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020(EdiSegment _0020, _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A _0020_000A)
		{
			_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A = new _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A();
			_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A._0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A = _0020;
			return _0020_000A.LoopStates.Any(_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A._0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020);
		}

		private XElement _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A(EdiSegment _0020, _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A _0020_000A)
		{
			XElement xElement = new XElement((_0020_000A != null) ? _0020_000A.Id : _0020.Id);
			for (int i = 0; i < _0020.Elements.Count; i++)
			{
				EdiElement ediElement = _0020.Elements[i];
				if (ediElement == null)
				{
					continue;
				}
				_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020 _0020_000A2 = null;
				string id;
				if (_0020_000A != null)
				{
					if (_0020_000A.Elements.Count > i)
					{
						_0020_000A2 = _0020_000A.Elements[i];
					}
					id = _0020_000A.Id;
				}
				else
				{
					id = _0020.Id;
				}
				string _0020_0020 = id + (i + 1).ToString("d2");
				xElement.Add(_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020(ediElement, _0020_000A2, _0020_0020));
			}
			return xElement;
		}

		private IEnumerable<XElement> _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020(EdiElement _0020, _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020 _0020_000A, string _0020_0020)
		{
			List<XElement> list = new List<XElement>();
			foreach (EdiRepetition repetition in _0020.Repetitions)
			{
				XElement xElement = new XElement((_0020_000A != null) ? _0020_000A.Id : _0020_0020);
				if (repetition.Components.Count == 1)
				{
					if (_0020_000A != null)
					{
						if (_0020_000A.Components.Count == 0)
						{
							if (_0020_000A.Type == null || !_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020(repetition, _0020_000A.Type, out string value))
							{
								xElement.Value = repetition.Value;
							}
							else
							{
								xElement.SetAttributeValue("type", _0020_000A.Type);
								xElement.Value = value;
							}
							if (_0020_000A.Options.Contains(repetition.Value))
							{
								string text = _0020_000A.Options[repetition.Value];
								if (text != null && text.Trim() != string.Empty)
								{
									xElement.SetAttributeValue("definition", text);
								}
							}
						}
						else
						{
							xElement.Add(_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A(repetition.Components[0], _0020_000A.Components[0], _0020_000A.Id + "01"));
						}
					}
					else
					{
						xElement.Value = repetition.Value;
					}
				}
				else
				{
					for (int i = 0; i < repetition.Components.Count; i++)
					{
						EdiComponent ediComponent = repetition.Components[i];
						if (ediComponent != null)
						{
							_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020 _0020_000A2 = null;
							string str;
							if (_0020_000A != null)
							{
								if (_0020_000A.Components.Count > i)
								{
									_0020_000A2 = _0020_000A.Components[i];
								}
								str = _0020_000A.Id;
							}
							else
							{
								str = _0020_0020;
							}
							string _0020_00202 = str + (i + 1).ToString("d2");
							xElement.Add(_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A(ediComponent, _0020_000A2, _0020_00202));
						}
					}
				}
				list.Add(xElement);
			}
			return list;
		}

		private XElement _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A(EdiComponent _0020, _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020 _0020_000A, string _0020_0020)
		{
			if (_0020_000A != null)
			{
				XElement xElement = new XElement(_0020_000A.Id);
				if (_0020_000A.Type == null || !_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020(_0020, _0020_000A.Type, out string value))
				{
					xElement.Value = _0020.Value;
				}
				else
				{
					xElement.SetAttributeValue("type", _0020_000A.Type);
					xElement.Value = value;
				}
				if (_0020_000A.Options.Contains(_0020.Value))
				{
					string value2 = _0020_000A.Options[_0020.Value];
					xElement.SetAttributeValue("definition", value2);
				}
				return xElement;
			}
			return new XElement(_0020_0020, _0020.Value);
		}

		private bool _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020(EdiValue _0020, string _0020_000A, out string _0020_0020)
		{
			try
			{
				if (_0020_000A == "id" || _0020_000A == "an")
				{
					_0020_0020 = _0020.Value;
					return true;
				}
				if (_0020_000A == "dt")
				{
					_0020_0020 = _0020.IsoDate;
					return true;
				}
				if (_0020_000A == "tm")
				{
					_0020_0020 = _0020.IsoTime;
					return true;
				}
				if (_0020_000A == "r")
				{
					_0020_0020 = _0020.RealValue.ToString(CultureInfo.InvariantCulture);
					return true;
				}
				int decimals = int.Parse(_0020_000A.Substring(1));
				_0020_0020 = _0020.NumericValue(decimals).ToString(CultureInfo.InvariantCulture);
				return true;
			}
			catch (FormatException)
			{
				Errors.Add($"'{_0020.Value}' is not a valid value of type '{_0020_000A}'.");
				_0020_0020 = null;
				return false;
			}
		}
	}
}
