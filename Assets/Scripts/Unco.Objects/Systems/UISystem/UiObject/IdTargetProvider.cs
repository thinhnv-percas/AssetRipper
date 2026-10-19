using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Systems.UISystem.UiObject
{
	[Token(Token = "0x2000005")]
	public class IdTargetProvider
	{
		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x10")]
		private Dictionary<ObjectId, List<Transform>> _targets;

		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x18")]
		private Dictionary<ObjectId, List<Transform>> _activeList;

		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x20")]
		public Action<ObjectId> OnRegister;

		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x28")]
		public Action<ObjectId> OnUnRegister;

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x81BE7B8", Offset = "0x81BE7B8", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\nL_002B:\n\tv57 = System.Collections.Generic.Dictionary`2<Systems.UISystem.UiObject.ObjectId, System.Collections.Generic.List`1<UnityEngine.Transform>>::TryGetValue(this._targets, id, &v55 @ stack_-38_v3 (System.Collections.Generic.List`1<UnityEngine.Transform>));\n\tv90 = v57 == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_004A;\n\tv98 = new System.Collections.Generic.List`1<UnityEngine.Transform>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Transform>::.ctor(v98);\n\tSystem.Collections.Generic.Dictionary`2<Systems.UISystem.UiObject.ObjectId, System.Collections.Generic.List`1<UnityEngine.Transform>>::Add(this._targets, id, v98);\nL_004A:\n\t;\n\tgoto L_006C;\nL_006C:\n\tSystem.Collections.Generic.List`1<UnityEngine.Transform>::Add(v98, target);\n\tv193 = this.OnRegister;\n\tv187 = this.OnRegister == 0;\n\tif (v187) goto L_007C;\n\tSystem.Action`1<Systems.UISystem.UiObject.ObjectId>::Invoke(v193, id);\nL_007C:\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RegisterUiObject(ObjectId id, Transform target)
		{
			List<Transform> list = default(List<Transform>);
			if (!_targets.TryGetValue(id, out var _))
			{
				list = new List<Transform>();
				_targets.Add(id, list);
			}
			list.Add(target);
			Action<ObjectId> onRegister = OnRegister;
			if (OnRegister != null)
			{
				onRegister(id);
			}
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x81BE93C", Offset = "0x81BE93C", Length = "0x2AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0040;\nL_0040:\n\tv61 = System.Collections.Generic.Dictionary`2<Systems.UISystem.UiObject.ObjectId, System.Collections.Generic.List`1<UnityEngine.Transform>>::ContainsKey(this._targets, id);\n\tv115 = v61 == 0;\n\tif (v115) goto L_0096;\n\tv119 = ~state;\n\tif (v119) goto L_00AE;\n\tv250 = System.Collections.Generic.Dictionary`2<Systems.UISystem.UiObject.ObjectId, System.Collections.Generic.List`1<UnityEngine.Transform>>::TryGetValue(this._activeList, id, &v248 @ stack_-48_v4 (System.Collections.Generic.List`1<UnityEngine.Transform>));\n\tv257 = v250 == 0;\n\tv258 = ~v257;\n\tif (v258) goto L_006D;\n\tv266 = new System.Collections.Generic.List`1<UnityEngine.Transform>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Transform>::.ctor(v266);\n\tSystem.Collections.Generic.Dictionary`2<Systems.UISystem.UiObject.ObjectId, System.Collections.Generic.List`1<UnityEngine.Transform>>::Add(this._activeList, id, v266);\nL_006D:\n\t;\n\tgoto L_00D6;\nL_008F:\n\treturn;\nL_0096:\n\tgoto L_00A5;\nL_00A5:\n\tUnityEngine.Debug::Log(\"Id Not Found\");\n\treturn;\nL_00AE:\n\tv252 = System.Collections.Generic.Dictionary`2<Systems.UISystem.UiObject.ObjectId, System.Collections.Generic.List`1<UnityEngine.Transform>>::TryGetValue(this._activeList, id, &v63 @ stack_-50_v3 (System.Collections.Generic.List`1<UnityEngine.Transform>));\n\tv259 = ~v252;\n\tif (v259) goto L_008F;\n\tv89 = System.Collections.Generic.List`1<UnityEngine.Transform>::Remove(v63, target);\n\tv299 = v63.Count == 0;\n\tv276 = ~v299;\n\tif (v276) goto L_008F;\n\tv199 = System.Collections.Generic.Dictionary`2<Systems.UISystem.UiObject.ObjectId, System.Collections.Generic.List`1<UnityEngine.Transform>>::Remove(this._activeList, id);\n\treturn;\nL_00D6:\n\tSystem.Collections.Generic.List`1<UnityEngine.Transform>::Add(v266, target);\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetState(ObjectId id, Transform target, bool state)
		{
			if (_targets.ContainsKey(id))
			{
				List<Transform> value2;
				if (state)
				{
					List<Transform> list = default(List<Transform>);
					if (!_activeList.TryGetValue(id, out var _))
					{
						list = new List<Transform>();
						_activeList.Add(id, list);
					}
					list.Add(target);
				}
				else if (_activeList.TryGetValue(id, out value2))
				{
					bool flag = value2.Remove(target);
					if (value2.Count == 0)
					{
						bool flag2 = _activeList.Remove(id);
					}
				}
			}
			else
			{
				Debug.Log("Id Not Found");
			}
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x81BEBE8", Offset = "0x81BEBE8", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\nL_002E:\n\tv57 = System.Collections.Generic.Dictionary`2<Systems.UISystem.UiObject.ObjectId, System.Collections.Generic.List`1<UnityEngine.Transform>>::TryGetValue(this._activeList, id, &v55 @ stack_-38_v3 (System.Collections.Generic.List`1<UnityEngine.Transform>));\n\tv80 = ~v57;\n\tif (v80) goto L_003C;\n\tv84 = v55 == 0;\n\tv72 = ~v84;\n\tv136 = v55;\n\tif (v72) goto L_0043;\n\tgoto L_0074;\nL_003C:\n\tv139 = System.Collections.Generic.Dictionary`2<Systems.UISystem.UiObject.ObjectId, System.Collections.Generic.List`1<UnityEngine.Transform>>::TryGetValue(this._targets, id, &v59 @ stack_-40_v5 (System.Collections.Generic.List`1<UnityEngine.Transform>));\n\tv153 = ~v139;\n\tif (v153) goto L_0052;\n\tv136 = v59;\nL_0043:\n\tv114 = v136.Count == 0;\n\tif (v114) goto L_0073;\n\treturnVal3 = System.Collections.Generic.List`1<UnityEngine.Transform>::get_Item(v136, 0);\n\treturn returnVal3;\nL_0052:\n\tv144 = id;\n\t// 87 Box v158 @ X0_v13 (System.Object), typeof(Systems.UISystem.UiObject.ObjectId), &v144 @ stack_-44_v2 (Systems.UISystem.UiObject.ObjectId)\n\tv148 = System.String::Format(\"Id Not Found : {0}\", v158);\n\tgoto L_006A;\nL_0073:\n\treturn 0;\nL_0074:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_006A:\n\tUnityEngine.Debug::Log(v148);\n")]
		public Transform GetUiObject(ObjectId id)
		{
			List<Transform> list;
			if (_activeList.TryGetValue(id, out var value))
			{
				bool flag = value == null;
				bool flag2 = !flag;
				list = value;
				if (!flag2)
				{
					return (Transform)(object)new NullReferenceException();
				}
			}
			else
			{
				if (!_targets.TryGetValue(id, out var value2))
				{
					object arg = id;
					string message = $"Id Not Found : {arg}";
					Debug.Log(message);
					goto IL_010d;
				}
				list = value2;
			}
			if (list.Count != 0)
			{
				return list[0];
			}
			goto IL_010d;
			IL_010d:
			return null;
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x81BED60", Offset = "0x81BED60", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv57 = System.Collections.Generic.Dictionary`2<Systems.UISystem.UiObject.ObjectId, System.Collections.Generic.List`1<UnityEngine.Transform>>::TryGetValue(this._targets, id, &v55 @ stack_-38_v3 (System.Collections.Generic.List`1<UnityEngine.Transform>));\n\tv81 = ~v57;\n\tif (v81) goto L_0034;\n\tv85 = System.Collections.Generic.List`1<UnityEngine.Transform>::Remove(v55, target);\nL_0034:\n\tv117 = System.Collections.Generic.Dictionary`2<Systems.UISystem.UiObject.ObjectId, System.Collections.Generic.List`1<UnityEngine.Transform>>::TryGetValue(this._activeList, id, &v59 @ stack_-40_v3 (System.Collections.Generic.List`1<UnityEngine.Transform>));\n\tv118 = ~v117;\n\tif (v118) goto L_003F;\n\tv124 = System.Collections.Generic.List`1<UnityEngine.Transform>::Remove(v59, target);\nL_003F:\n\t;\n\tv103 = this.OnUnRegister == 0;\n\tif (v103) goto L_004E;\n\tSystem.Action`1<Systems.UISystem.UiObject.ObjectId>::Invoke(this.OnUnRegister, id);\nL_004E:\n\treturn;\n")]
		public void UnRegisterUiObject(ObjectId id, Transform target)
		{
			if (_targets.TryGetValue(id, out var value))
			{
				bool flag = value.Remove(target);
			}
			if (_activeList.TryGetValue(id, out var value2))
			{
				bool flag2 = value2.Remove(target);
			}
			if (OnUnRegister != null)
			{
				OnUnRegister(id);
			}
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x81BEE5C", Offset = "0x81BEE5C", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv58 = new System.Collections.Generic.Dictionary`2<Systems.UISystem.UiObject.ObjectId, System.Collections.Generic.List`1<UnityEngine.Transform>>();\n\tSystem.Collections.Generic.Dictionary`2<Systems.UISystem.UiObject.ObjectId, System.Collections.Generic.List`1<UnityEngine.Transform>>::.ctor(v58);\n\tthis._activeList = v58;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.Dictionary`2<Systems.UISystem.UiObject.ObjectId, System.Collections.Generic.List`1<UnityEngine.Transform>>();\n\tSystem.Collections.Generic.Dictionary`2<Systems.UISystem.UiObject.ObjectId, System.Collections.Generic.List`1<UnityEngine.Transform>>::.ctor(v48);\n\tthis._targets = v48;\n")]
		public IdTargetProvider()
		{
			Dictionary<ObjectId, List<Transform>> targets = new Dictionary<ObjectId, List<Transform>>();
			_targets = targets;
			Dictionary<ObjectId, List<Transform>> activeList = new Dictionary<ObjectId, List<Transform>>();
			_activeList = activeList;
		}
	}
}
