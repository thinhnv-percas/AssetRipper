using System.Collections.Generic;
using Cpp2ILInjected;
using Unco.ResourceSystem;

namespace _game.CoreGameKit.Ui.Animations
{
	[Token(Token = "0x2000579")]
	public class ParticleAnimationRegistry
	{
		[Token(Token = "0x40012E0")]
		[FieldOffset(Offset = "0x10")]
		internal readonly Dictionary<ResourceType, List<CurrencyVisualizer>> _visualizers;

		[Token(Token = "0x40012E1")]
		[FieldOffset(Offset = "0x18")]
		internal readonly Dictionary<string, List<ParticleAnimationTarget>> _stringTargets;

		[Token(Token = "0x60016FF")]
		[Address(RVA = "0x3D23C00", Offset = "0x3D23C00", Length = "0x1A0")]
		public void AddVisualizer(CurrencyVisualizer visualizer)
		{
			List<CurrencyVisualizer> list = default(List<CurrencyVisualizer>);
			if (!_visualizers.TryGetValue(visualizer.ResourceType, out var _))
			{
				list = new List<CurrencyVisualizer>();
				_visualizers[visualizer.ResourceType] = list;
			}
			if (!list.Contains(visualizer))
			{
				list.Add(visualizer);
			}
		}

		[Token(Token = "0x6001700")]
		[Address(RVA = "0x3D23E4C", Offset = "0x3D23E4C", Length = "0x104")]
		public void RemoveVisualizer(CurrencyVisualizer visualizer)
		{
			if (_visualizers.TryGetValue(visualizer.ResourceType, out var value))
			{
				bool flag = value.Remove(visualizer);
				if (value.Count == 0)
				{
					bool flag2 = _visualizers.Remove(visualizer.ResourceType);
				}
			}
		}

		[Token(Token = "0x6001701")]
		[Address(RVA = "0x3D20E90", Offset = "0x3D20E90", Length = "0x6C")]
		public bool TryGetVisualizers(ResourceType type, out List<CurrencyVisualizer> visualizers)
		{
			visualizers = null;
			return _visualizers.TryGetValue(type, out visualizers);
		}

		[Token(Token = "0x6001702")]
		[Address(RVA = "0x3D25138", Offset = "0x3D25138", Length = "0x170")]
		public void AddTarget(string key, ParticleAnimationTarget target)
		{
			List<ParticleAnimationTarget> list = default(List<ParticleAnimationTarget>);
			if (!_stringTargets.TryGetValue(key, out var _))
			{
				list = new List<ParticleAnimationTarget>();
				_stringTargets[key] = list;
			}
			list.Add(target);
		}

		[Token(Token = "0x6001703")]
		[Address(RVA = "0x3D252A8", Offset = "0x3D252A8", Length = "0x100")]
		public void RemoveTarget(string key, ParticleAnimationTarget target)
		{
			if (_stringTargets.TryGetValue(key, out var value))
			{
				bool flag = value.Remove(target);
				if (value.Count == 0)
				{
					bool flag2 = _stringTargets.Remove(key);
				}
			}
		}

		[Token(Token = "0x6001704")]
		[Address(RVA = "0x3D2351C", Offset = "0x3D2351C", Length = "0x6C")]
		public bool TryGetTargets(string key, out List<ParticleAnimationTarget> targets)
		{
			targets = null;
			string key2 = default(string);
			return _stringTargets.TryGetValue(key2, out targets);
		}

		[Token(Token = "0x6001705")]
		[Address(RVA = "0x3D253A8", Offset = "0x3D253A8", Length = "0xE0")]
		public ParticleAnimationRegistry()
		{
			Dictionary<ResourceType, List<CurrencyVisualizer>> visualizers = new Dictionary<ResourceType, List<CurrencyVisualizer>>();
			_visualizers = visualizers;
			Dictionary<string, List<ParticleAnimationTarget>> stringTargets = new Dictionary<string, List<ParticleAnimationTarget>>();
			_stringTargets = stringTargets;
		}
	}
}
