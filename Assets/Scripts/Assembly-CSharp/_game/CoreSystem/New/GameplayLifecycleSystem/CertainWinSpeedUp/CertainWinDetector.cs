using System.Collections.Generic;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;
using _game.CoreSystem.SandPhysics;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.CertainWinSpeedUp
{
	[Token(Token = "0x200042B")]
	public class CertainWinDetector
	{
		[Inject(false)]
		[Token(Token = "0x4000D22")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Token(Token = "0x6001168")]
		[Address(RVA = "0x3CC09B4", Offset = "0x3CC09B4", Length = "0x98")]
		public bool IsCertain()
		{
			if (HasAnyCube())
			{
				return false;
			}
			SandPhysicsContext _003CCurrent_003Ek__BackingField = SandPhysicsContext.Current;
			if (SandPhysicsContext.Current != null && _003CCurrent_003Ek__BackingField.Queries != null)
			{
				bool flag = _003CCurrent_003Ek__BackingField.Queries.HasInFlightParticles();
				int num = (flag ? 1 : 0) ^ 1;
				return (byte)(num & 1) != 0;
			}
			return true;
		}

		[Token(Token = "0x6001169")]
		[Address(RVA = "0x3CC0A4C", Offset = "0x3CC0A4C", Length = "0xD4")]
		internal bool HasAnyCube()
		{
			//IL_0028: Expected O, but got I4
			IReadOnlyList<Entity> readOnlyList = _em.Query<SandCubeTag>();
			object obj = ((IReadOnlyCollection<Entity>)null).Count;
			bool flag = (nint)obj < 0;
			bool flag2 = obj == null;
			int num = (int)((nint)obj ^ (nint)obj);
			int num2 = (int)((nint)obj & num);
			bool flag3 = num2 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			return flag4 && flag5;
		}

		[Token(Token = "0x600116A")]
		[Address(RVA = "0x3CC0B20", Offset = "0x3CC0B20", Length = "0x6C")]
		private static bool HasInFlightParticles()
		{
			SandPhysicsContext _003CCurrent_003Ek__BackingField = SandPhysicsContext.Current;
			if (SandPhysicsContext.Current != null && _003CCurrent_003Ek__BackingField.Queries != null)
			{
				return _003CCurrent_003Ek__BackingField.Queries.HasInFlightParticles();
			}
			return false;
		}

		[Token(Token = "0x600116B")]
		[Address(RVA = "0x3CC0B8C", Offset = "0x3CC0B8C", Length = "0x8")]
		public CertainWinDetector()
		{
		}
	}
}
