using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Pool;

namespace Coffee.UIParticleInternal
{
	[Token(Token = "0x2000016")]
	internal class InternalObjectPool<T> where T : class
	{
		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x0")]
		private readonly Predicate<T> _onValid;

		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x0")]
		private readonly ObjectPool<T> _pool;

		[Token(Token = "0x6000059")]
		[Address(RVA = "0x55885B0", Offset = "0x55885B0", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tgoto L_001B;\nL_001B:\n\tv50 = new Il2CppClass<UnityEngine.Pool.ObjectPool`1<T>>();\n\tUnityEngine.Pool.ObjectPool`1<T>::.ctor(v50, onCreate, 0, onReturn, 0, 1, 0xA, 0x2710);\n\tthis._pool = v50;\n\tthis._onValid = onValid;\n\treturn;\n")]
		public InternalObjectPool(Func<T> onCreate, Predicate<T> onValid, Action<T> onReturn)
		{
			ObjectPool<T> pool = new ObjectPool<T>(onCreate, null, onReturn);
			_pool = pool;
			_onValid = onValid;
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0x558866C", Offset = "0x558866C", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\nL_0010:\n\tv68 = UnityEngine.Pool.ObjectPool`1<T>::get_CountInactive(this._pool);\n\tv31 = v68 <= 0;\n\tif (v31) goto L_0047;\n\tv84 = UnityEngine.Pool.ObjectPool`1<T>::Get(this._pool);\n\tv57 = System.Predicate`1<T>::Invoke(this._onValid, v84);\n\tv147 = v57 & 1;\n\tv28 = v147 == 0;\n\tif (v28) goto L_0010;\n\treturn v84;\nL_0047:\n\treturnVal2 = UnityEngine.Pool.ObjectPool`1<T>::Get(this._pool);\n\treturn returnVal2;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public T Rent()
		{
			//IL_0057: Expected O, but got I4
			while (true)
			{
				int countInactive = _pool.CountInactive;
				if (countInactive <= 0)
				{
					break;
				}
				T val = _pool.Get();
				object obj = _onValid(val);
				if ((int)((nint)obj & 1) != 0)
				{
					return val;
				}
			}
			return _pool.Get();
		}

		[Token(Token = "0x600005B")]
		[Address(RVA = "0x558871C", Offset = "0x558871C", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = *([instance @ X1 (T&)]) == 0;\n\tif (v13) goto L_0017;\n\tv24 = UnityEngine.Pool.ObjectPool`1<T>::Release(this._pool, *([instance @ X1 (T&)]));\n\t*([instance @ X1 (T&)]) = 0;\nL_0017:\n\treturn;\n")]
		public void Return(ref T instance)
		{
			if (instance != null)
			{
				_pool.Release(instance);
				instance = null;
			}
		}
	}
}
