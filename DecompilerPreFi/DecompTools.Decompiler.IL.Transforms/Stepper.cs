#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL.Transforms;

public class Stepper
{
	public class Node
	{
		public string Description { get; set; }

		public ILInstruction Position { get; set; }

		public int BeginStep { get; set; }

		public int EndStep { get; set; }

		public IList<Node> Children { get; } = new List<Node>();
	}

	private readonly Stack<Node> groups;

	private readonly IList<Node> steps;

	private int step = 0;

	public static bool SteppingAvailable => true;

	public IList<Node> Steps => steps;

	public int StepLimit { get; set; } = int.MaxValue;

	public bool IsDebug { get; set; }

	public Stepper()
	{
		steps = new List<Node>();
		groups = new Stack<Node>();
	}

	public void Step(string description, ILInstruction near = null)
	{
		StepInternal(description, near);
	}

	private Node StepInternal(string description, ILInstruction near)
	{
		if (step == StepLimit)
		{
			if (!IsDebug)
			{
				throw new StepLimitReachedException();
			}
			Debugger.Break();
		}
		checked
		{
			Node node = new Node
			{
				Description = $"{step}: {description}",
				Position = near,
				BeginStep = step,
				EndStep = step + 1
			};
			Node node2 = groups.PeekOrDefault<Node>();
			if (node2 != null)
			{
				node2.Children.Add(node);
			}
			else
			{
				steps.Add(node);
			}
			step++;
			return node;
		}
	}

	public void StartGroup(string description, ILInstruction near = null)
	{
		groups.Push(StepInternal(description, near));
	}

	public void EndGroup(bool keepIfEmpty = false)
	{
		Node node = groups.Pop();
		if (!keepIfEmpty && node.Children.Count == 0)
		{
			IList<Node> list = groups.PeekOrDefault<Node>()?.Children ?? steps;
			Debug.Assert(list.Last() == node);
			list.RemoveAt(checked(list.Count - 1));
		}
		node.EndStep = step;
	}
}
