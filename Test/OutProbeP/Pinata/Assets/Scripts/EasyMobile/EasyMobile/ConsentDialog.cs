using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;
using EasyMobile.Internal.Privacy;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x2000081")]
	public class ConsentDialog
	{
		[Serializable]
		[Token(Token = "0x200013C")]
		public class Toggle
		{
			[SerializeField]
			[Token(Token = "0x400054A")]
			[FieldOffset(Offset = "0x10")]
			private string id;

			[SerializeField]
			[Token(Token = "0x400054B")]
			[FieldOffset(Offset = "0x18")]
			private string title;

			[SerializeField]
			[Token(Token = "0x400054C")]
			[FieldOffset(Offset = "0x20")]
			private string onDescription;

			[SerializeField]
			[Token(Token = "0x400054D")]
			[FieldOffset(Offset = "0x28")]
			private string offDescription;

			[SerializeField]
			[Token(Token = "0x400054E")]
			[FieldOffset(Offset = "0x30")]
			internal bool isOn;

			[SerializeField]
			[Token(Token = "0x400054F")]
			[FieldOffset(Offset = "0x31")]
			internal bool interactable;

			[SerializeField]
			[Token(Token = "0x4000550")]
			[FieldOffset(Offset = "0x32")]
			private bool shouldToggleDescription;

			[Token(Token = "0x1700026C")]
			public string Id
			{
				[Token(Token = "0x60009C1")]
				[Address(RVA = "0xA53D9C", Offset = "0xA53D9C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.id;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return Id;
				}
			}

			[Token(Token = "0x1700026D")]
			public string Title
			{
				[Token(Token = "0x60009C2")]
				[Address(RVA = "0xA53DA4", Offset = "0xA53DA4", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.title;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return Title;
				}
				[Token(Token = "0x60009C3")]
				[Address(RVA = "0xA53DAC", Offset = "0xA53DAC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.title = value;\n\treturn;\n")]
				set
				{
					Title = value;
				}
			}

			[Token(Token = "0x1700026E")]
			public string Description
			{
				[Token(Token = "0x60009C4")]
				[Address(RVA = "0xA53DB4", Offset = "0xA53DB4", Length = "0x24")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.shouldToggleDescription;\n\tif (v2) goto L_0006;\n\tv4 = ~this.isOn;\n\tif (v4) goto L_0008;\nL_0006:\n\tv10 = this + 0x20;\n\tgoto L_000A;\nL_0008:\n\tv10 = this + 0x28;\nL_000A:\n\treturn *([v10 @ X8_v2]);\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					//IL_0042: Expected O, but got I
					//IL_0053: Expected O, but got I
					if (!ShouldToggleDescription || IsOn)
					{
						return (string)((long)(IntPtr)this + 32L);
					}
					return (string)((long)(IntPtr)this + 40L);
				}
			}

			[Token(Token = "0x1700026F")]
			public string OnDescription
			{
				[Token(Token = "0x60009C5")]
				[Address(RVA = "0xA53DD8", Offset = "0xA53DD8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.onDescription;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return OnDescription;
				}
				[Token(Token = "0x60009C6")]
				[Address(RVA = "0xA53DE0", Offset = "0xA53DE0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.onDescription = value;\n\treturn;\n")]
				set
				{
					OnDescription = value;
				}
			}

			[Token(Token = "0x17000270")]
			public string OffDescription
			{
				[Token(Token = "0x60009C7")]
				[Address(RVA = "0xA53DE8", Offset = "0xA53DE8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.offDescription;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return OffDescription;
				}
				[Token(Token = "0x60009C8")]
				[Address(RVA = "0xA53DF0", Offset = "0xA53DF0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.offDescription = value;\n\treturn;\n")]
				set
				{
					OffDescription = value;
				}
			}

			[Token(Token = "0x17000271")]
			public bool IsOn
			{
				[Token(Token = "0x60009C9")]
				[Address(RVA = "0xA53DF8", Offset = "0xA53DF8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.isOn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return IsOn;
				}
				[Token(Token = "0x60009CA")]
				[Address(RVA = "0xA53E00", Offset = "0xA53E00", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isOn = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				set
				{
					isOn = value;
				}
			}

			[Token(Token = "0x17000272")]
			public bool IsInteractable
			{
				[Token(Token = "0x60009CB")]
				[Address(RVA = "0xA53E0C", Offset = "0xA53E0C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.interactable;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return IsInteractable;
				}
				[Token(Token = "0x60009CC")]
				[Address(RVA = "0xA53E14", Offset = "0xA53E14", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.interactable = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				set
				{
					interactable = value;
				}
			}

			[Token(Token = "0x17000273")]
			public bool ShouldToggleDescription
			{
				[Token(Token = "0x60009CD")]
				[Address(RVA = "0xA53E20", Offset = "0xA53E20", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.shouldToggleDescription;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return ShouldToggleDescription;
				}
				[Token(Token = "0x60009CE")]
				[Address(RVA = "0xA53E28", Offset = "0xA53E28", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.shouldToggleDescription = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				set
				{
					shouldToggleDescription = value;
				}
			}

			[Token(Token = "0x60009CF")]
			[Address(RVA = "0xA53E34", Offset = "0xA53E34", Length = "0x34")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.interactable = 1;\n\tSystem.Object::.ctor(this);\n\tthis.id = id;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Toggle(string id)
			{
				interactable = true;
				this.id = id;
			}

			[Token(Token = "0x60009D0")]
			[Address(RVA = "0xA53E68", Offset = "0xA53E68", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.JsonUtility::ToJson(this);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public override string ToString()
			{
				return JsonUtility.ToJson(this);
			}
		}

		[Serializable]
		[Token(Token = "0x200013D")]
		public class Button
		{
			[SerializeField]
			[Token(Token = "0x4000551")]
			[FieldOffset(Offset = "0x10")]
			private string id;

			[SerializeField]
			[Token(Token = "0x4000552")]
			[FieldOffset(Offset = "0x18")]
			private string title;

			[SerializeField]
			[Token(Token = "0x4000553")]
			[FieldOffset(Offset = "0x20")]
			internal bool interactable;

			[SerializeField]
			[Token(Token = "0x4000554")]
			[FieldOffset(Offset = "0x24")]
			private Color titleColor;

			[SerializeField]
			[Token(Token = "0x4000555")]
			[FieldOffset(Offset = "0x34")]
			private Color backgroundColor;

			[SerializeField]
			[Token(Token = "0x4000556")]
			[FieldOffset(Offset = "0x44")]
			private Color uninteractableTitleColor;

			[SerializeField]
			[Token(Token = "0x4000557")]
			[FieldOffset(Offset = "0x54")]
			private Color uninteractableBackgroundColor;

			[Token(Token = "0x17000274")]
			public string Id
			{
				[Token(Token = "0x60009D1")]
				[Address(RVA = "0xA53BC4", Offset = "0xA53BC4", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.id;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return Id;
				}
			}

			[Token(Token = "0x17000275")]
			public string Title
			{
				[Token(Token = "0x60009D2")]
				[Address(RVA = "0xA53BCC", Offset = "0xA53BCC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.title;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return Title;
				}
				[Token(Token = "0x60009D3")]
				[Address(RVA = "0xA53BD4", Offset = "0xA53BD4", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.title = value;\n\treturn;\n")]
				set
				{
					Title = value;
				}
			}

			[Token(Token = "0x17000276")]
			public bool IsInteractable
			{
				[Token(Token = "0x60009D4")]
				[Address(RVA = "0xA53BDC", Offset = "0xA53BDC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.interactable;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return IsInteractable;
				}
				[Token(Token = "0x60009D5")]
				[Address(RVA = "0xA53BE4", Offset = "0xA53BE4", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.interactable = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				set
				{
					interactable = value;
				}
			}

			[Token(Token = "0x17000277")]
			public Color TitleColor
			{
				[Token(Token = "0x60009D6")]
				[Address(RVA = "0xA53BF0", Offset = "0xA53BF0", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.titleColor;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return titleColor;
				}
				[Token(Token = "0x60009D7")]
				[Address(RVA = "0xA53BFC", Offset = "0xA53BFC", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.titleColor = value;\n\tthis.titleColor.g = value.g;\n\tthis.titleColor.b = value.b;\n\tthis.titleColor.a = value.a;\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				set
				{
					titleColor = value;
					titleColor.g = value.g;
					titleColor.b = value.b;
					titleColor.a = value.a;
				}
			}

			[Token(Token = "0x17000278")]
			public Color DisabledTitleColor
			{
				[Token(Token = "0x60009D8")]
				[Address(RVA = "0xA53C08", Offset = "0xA53C08", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.uninteractableTitleColor;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return uninteractableTitleColor;
				}
				[Token(Token = "0x60009D9")]
				[Address(RVA = "0xA53C14", Offset = "0xA53C14", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.uninteractableTitleColor = value;\n\tthis.uninteractableTitleColor.g = value.g;\n\tthis.uninteractableTitleColor.b = value.b;\n\tthis.uninteractableTitleColor.a = value.a;\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				set
				{
					uninteractableTitleColor = value;
					uninteractableTitleColor.g = value.g;
					uninteractableTitleColor.b = value.b;
					uninteractableTitleColor.a = value.a;
				}
			}

			[Token(Token = "0x17000279")]
			public Color BodyColor
			{
				[Token(Token = "0x60009DA")]
				[Address(RVA = "0xA53C20", Offset = "0xA53C20", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.backgroundColor;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return backgroundColor;
				}
				[Token(Token = "0x60009DB")]
				[Address(RVA = "0xA53C2C", Offset = "0xA53C2C", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.backgroundColor = value;\n\tthis.backgroundColor.g = value.g;\n\tthis.backgroundColor.b = value.b;\n\tthis.backgroundColor.a = value.a;\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				set
				{
					backgroundColor = value;
					backgroundColor.g = value.g;
					backgroundColor.b = value.b;
					backgroundColor.a = value.a;
				}
			}

			[Token(Token = "0x1700027A")]
			public Color DisabledBodyColor
			{
				[Token(Token = "0x60009DC")]
				[Address(RVA = "0xA53C38", Offset = "0xA53C38", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.uninteractableBackgroundColor;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return uninteractableBackgroundColor;
				}
				[Token(Token = "0x60009DD")]
				[Address(RVA = "0xA53C44", Offset = "0xA53C44", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.uninteractableBackgroundColor = value;\n\tthis.uninteractableBackgroundColor.g = value.g;\n\tthis.uninteractableBackgroundColor.b = value.b;\n\tthis.uninteractableBackgroundColor.a = value.a;\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				set
				{
					uninteractableBackgroundColor = value;
					uninteractableBackgroundColor.g = value.g;
					uninteractableBackgroundColor.b = value.b;
					uninteractableBackgroundColor.a = value.a;
				}
			}

			[Token(Token = "0x60009DE")]
			[Address(RVA = "0xA53C50", Offset = "0xA53C50", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.interactable = 1;\n\tv16 = UnityEngine.Color::get_white();\n\tthis.titleColor = v16;\n\tthis.titleColor.g = v16.g;\n\tthis.titleColor.b = v16.b;\n\tthis.titleColor.a = v16.a;\n\tv21 = UnityEngine.Color::get_blue();\n\tthis.backgroundColor = v21;\n\tthis.backgroundColor.g = v21.g;\n\tthis.backgroundColor.b = v21.b;\n\tthis.backgroundColor.a = v21.a;\n\tv26 = UnityEngine.Color::get_white();\n\tthis.uninteractableTitleColor = v26;\n\tthis.uninteractableTitleColor.g = v26.g;\n\tthis.uninteractableTitleColor.b = v26.b;\n\tthis.uninteractableTitleColor.a = v26.a;\n\tv31 = UnityEngine.Color::get_gray();\n\tthis.uninteractableBackgroundColor = v31;\n\tthis.uninteractableBackgroundColor.g = v31.g;\n\tthis.uninteractableBackgroundColor.b = v31.b;\n\tthis.uninteractableBackgroundColor.a = v31.a;\n\tSystem.Object::.ctor(this);\n\tthis.id = id;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Button(string id)
			{
				interactable = true;
				Color color = (titleColor = Color.white);
				titleColor.g = color.g;
				titleColor.b = color.b;
				titleColor.a = color.a;
				Color color2 = (backgroundColor = Color.blue);
				backgroundColor.g = color2.g;
				backgroundColor.b = color2.b;
				backgroundColor.a = color2.a;
				Color color3 = (uninteractableTitleColor = Color.white);
				uninteractableTitleColor.g = color3.g;
				uninteractableTitleColor.b = color3.b;
				uninteractableTitleColor.a = color3.a;
				Color color4 = (uninteractableBackgroundColor = Color.gray);
				uninteractableBackgroundColor.g = color4.g;
				uninteractableBackgroundColor.b = color4.b;
				uninteractableBackgroundColor.a = color4.a;
				this.id = id;
			}

			[Token(Token = "0x60009DF")]
			[Address(RVA = "0xA53CC8", Offset = "0xA53CC8", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.interactable;\n\tif (v2) goto L_0008;\n\tv14 = this + 0x24;\n\tgoto L_0010;\nL_0008:\n\tv14 = this + 0x44;\nL_0010:\n\treturn *([v14 @ X8_v2]);\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Color GetCurrentTitleColor()
			{
				//IL_0038: Expected O, but got I
				//IL_0027: Expected O, but got I
				if (IsInteractable)
				{
					return (Color)((long)(IntPtr)this + 36L);
				}
				return (Color)((long)(IntPtr)this + 68L);
			}

			[Token(Token = "0x60009E0")]
			[Address(RVA = "0xA53D08", Offset = "0xA53D08", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.interactable;\n\tif (v2) goto L_0008;\n\tv14 = this + 0x34;\n\tgoto L_0010;\nL_0008:\n\tv14 = this + 0x54;\nL_0010:\n\treturn *([v14 @ X8_v2]);\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Color GetCurrentBodyColor()
			{
				//IL_0038: Expected O, but got I
				//IL_0027: Expected O, but got I
				if (IsInteractable)
				{
					return (Color)((long)(IntPtr)this + 52L);
				}
				return (Color)((long)(IntPtr)this + 84L);
			}

			[Token(Token = "0x60009E1")]
			[Address(RVA = "0xA53D48", Offset = "0xA53D48", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.JsonUtility::ToJson(this);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public override string ToString()
			{
				return JsonUtility.ToJson(this);
			}
		}

		[Token(Token = "0x200013E")]
		public class CompletedResults
		{
			[Token(Token = "0x4000558")]
			[FieldOffset(Offset = "0x10")]
			public string buttonId;

			[Token(Token = "0x4000559")]
			[FieldOffset(Offset = "0x18")]
			public Dictionary<string, bool> toggleValues;

			[Token(Token = "0x60009E2")]
			[Address(RVA = "0xA52CDC", Offset = "0xA52CDC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public CompletedResults()
			{
			}
		}

		[Token(Token = "0x200013F")]
		public delegate void CompletedHandler(ConsentDialog dialog, CompletedResults results);

		[Token(Token = "0x2000140")]
		public delegate void ToggleStateUpdatedHandler(ConsentDialog dialog, string toggleId, bool isOn);

		[CompilerGenerated]
		[Token(Token = "0x2000145")]
		private sealed class _003CGetAllUrlsInContent_003Ed__57 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400055E")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x400055F")]
			[FieldOffset(Offset = "0x18")]
			private string _003C_003E2__current;

			[Token(Token = "0x4000560")]
			[FieldOffset(Offset = "0x20")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x4000561")]
			[FieldOffset(Offset = "0x28")]
			public ConsentDialog _003C_003E4__this;

			[Token(Token = "0x4000562")]
			[FieldOffset(Offset = "0x30")]
			private IEnumerator _003C_003E7__wrap1;

			[Token(Token = "0x1700027B")]
			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60009F7")]
				[Address(RVA = "0xA53A9C", Offset = "0xA53A9C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700027C")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60009F9")]
				[Address(RVA = "0xA53B08", Offset = "0xA53B08", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60009F3")]
			[Address(RVA = "0xA51634", Offset = "0xA51634", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CGetAllUrlsInContent_003Ed__57(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x60009F4")]
			[Address(RVA = "0xA53708", Offset = "0xA53708", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.<>1__state == 1;\n\tif (v6) goto L_0012;\n\tv11 = this.<>1__state + 3;\n\tv13 = v11 == 0;\n\tv16 = ~v13;\n\tif (v16) goto L_0014;\nL_0012:\n\tEasyMobile.ConsentDialog+<GetAllUrlsInContent>d__57::<>m__Finally1(this);\n\treturn;\nL_0014:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IDisposable.Dispose()
			{
				if (_003C_003E1__state == 1 || _003C_003E1__state + 3 == 0)
				{
					_003C_003Em__Finally1();
				}
			}

			[Token(Token = "0x60009F5")]
			[Address(RVA = "0xA537F0", Offset = "0xA537F0", Length = "0x2AC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1ECA498]);\n\tv23 = *([v22 @ X8_v35]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021F88]) = v42;\nL_0016:\n\tv44 = this.<>1__state == 0;\n\tif (v44) goto L_0028;\n\tv54 = this.<>1__state != 1;\n\tif (v54) goto L_FFFFFFFF;\n\tv124 = this + 0x30;\n\tv149 = this.<>7__wrap1;\n\tgoto L_0046;\nL_0028:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv57 = this.<>4__this;\n\tv60 = new System.Text.RegularExpressions.Regex();\n\tSystem.Text.RegularExpressions.Regex::.ctor(v60, \"https?:\\\\/\\\\/(www\\\\.)?[-a-zA-Z0-9@:%._\\\\+~#=]{2,256}\\\\.[a-z]{2,6}\\\\b([-a-zA-Z0-9@:%_\\\\+.~#?&//=]*)\");\n\tv361 = System.Text.RegularExpressions.Regex::Matches(v60, v57.mContent);\n\tv145 = System.Text.RegularExpressions.MatchCollection::GetEnumerator(v361);\n\tv124 = this + 0x30;\n\tthis.<>7__wrap1 = v145;\nL_0046:\n\tthis.<>1__state = 0xFFFFFFFD;\n\tgoto L_0076;\n\tv315 = *([v223 @ X8_v8+B0]);\n\tv316 = 0;\n\tv317 = v315 + 8;\n\tv319 = *([v388 @ X11_v13-8]);\n\tv402 = v319 == v225;\n\tif (v402) goto L_006F;\n\tv321 = v387 + 1;\n\tv430 = v321 < v224;\n\tv341 = ~v430;\n\tv323 = v388 + 0x10;\n\tv325 = ~v341;\n\tif (v325) goto L_FFFFFFFF;\n\tv342 = v149;\n\tv343 = 0;\n\tv344 = 0x8909C4(v342, v225, v343, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0076;\nL_006F:\n\tv431 = *([v388 @ X11_v13]);\n\tv432 = v431 << 4;\n\tv433 = v223 + v432;\n\tv434 = v433 + 0x130;\nL_0076:\n\tv438 = System.Collections.IEnumerator::MoveNext(v149);\n\tv208 = v438 == 0;\n\tif (v208) goto L_00A2;\n\tv214 = this.<>7__wrap1;\n\tv494 = this.<>7__wrap1->klass;\n\tv497 = *([v494 @ X8_v11+126]) == 0;\n\tif (v497) goto L_009F;\n\tv540 = *([v494 @ X8_v11+B0]) + 8;\nL_008A:\n\tv554 = *([v540 @ X11_v8-8]) == System.Collections.IEnumerator;\n\tif (v554) goto L_00A7;\n\tv539 = v539 + 1;\n\tv561 = v539 < *([v494 @ X8_v11+126]);\n\tv524 = ~v561;\n\tv540 = v540 + 0x10;\n\tv508 = ~v524;\n\tif (v508) goto L_008A;\nL_009F:\n\tv567 = 0x8909C4(v214, System.Collections.IEnumerator, 1, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00AE;\nL_00A2:\n\tEasyMobile.ConsentDialog+<GetAllUrlsInContent>d__57::<>m__Finally1(this);\n\t*([v124 @ X21_v3]) = 0;\n\tgoto L_0117;\nL_00A7:\n\tv563 = *([v540 @ X11_v8]) + 1;\n\tv564 = v563 << 4;\n\tv565 = v494 + v564;\n\tv567 = v565 + 0x130;\nL_00AE:\n\t*([v567 @ X0_v13])(v357, v214, *([v567 @ X0_v13+8]), v82, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv209 = v357 == 0;\n\tif (v209) goto L_00E1;\n\tgoto L_FFFFFFFF;\n\tv179 = v179_asT == 0;\n\tif (v179) goto L_00D9;\n\tv597 = System.Text.RegularExpressions.Capture::get_Value(v357);\n\tthis.<>2__current = v597;\n\tthis.<>1__state = 1;\n\tgoto L_0117;\n\tv228 = new System.NullReferenceException();\nL_00D9:\n\tthrow System.InvalidCastException;\n\tthrow System.NullReferenceException;\n\tv385 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv464 = new System.NullReferenceException();\nL_00E1:\n\tv493 = new System.NullReferenceException();\n\tgoto L_00F3;\n\tgoto L_00F3;\n\tgoto L_00F3;\n\tgoto L_00F3;\n\tgoto L_00F3;\n\tgoto L_00F3;\n\tgoto L_00F3;\n\tgoto L_00F3;\nL_00F3:\n\tv537 = *([v567 @ X0_v13+8]) != 1;\n\tif (v537) goto L_0118;\n\tv559 = 0x6D2BC0(v493, *([v567 @ X0_v13+8]), v82, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv570 = 0x6D2490(v559, *([v567 @ X0_v13+8]), v82, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv579 = this.<>1__state == 1;\n\tif (v579) goto L_010B;\n\tv584 = this.<>1__state + 3;\n\tv586 = v584 == 0;\n\tv589 = ~v586;\n\tif (v589) goto L_010C;\nL_010B:\n\tEasyMobile.ConsentDialog+<GetAllUrlsInContent>d__57::<>m__Finally1(this);\nL_010C:\n\tv599 = *([v559 @ X0_v32]) == 0;\n\tv108 = ~v599;\n\tif (v108) goto L_011C;\nL_0117:\n\treturn returnVal1;\nL_0118:\n\tv560 = 0x6D2380(v493, *([v567 @ X0_v13+8]), v82, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_011C:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 175 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				//IL_009f: Expected O, but got I
				//IL_0033: Expected O, but got I
				//IL_019c: Expected O, but got I4
				//IL_010b: Expected O, but got I
				//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
				//IL_01b8: Expected O, but got Unknown
				//IL_01d5: Expected O, but got I
				//IL_01e4: Expected O, but got I
				//IL_0157: Expected O, but got I
				//IL_036a: Expected I4, but got O
				IEnumerator enumerator;
				object obj;
				if (_003C_003E1__state != 0)
				{
					if (_003C_003E1__state != 1)
					{
						goto IL_033a;
					}
					obj = (long)(IntPtr)this + 48L;
					enumerator = _003C_003E7__wrap1;
				}
				else
				{
					_003C_003E1__state = -1;
					ConsentDialog consentDialog = _003C_003E4__this;
					Regex regex = new Regex("https?:\\/\\/(www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{2,256}\\.[a-z]{2,6}\\b([-a-zA-Z0-9@:%_\\+.~#?&//=]*)");
					MatchCollection matchCollection = regex.Matches(consentDialog.Content);
					IEnumerator enumerator2 = matchCollection.GetEnumerator();
					obj = (long)(IntPtr)this + 48L;
					_003C_003E7__wrap1 = enumerator2;
					enumerator = enumerator2;
				}
				_003C_003E1__state = -3;
				int num4;
				if (enumerator.MoveNext())
				{
					object obj2 = obj;
					object obj3 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ X8_v11+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0170;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ X8_v11+B0]");
					object obj4 = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ X11_v8-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ X8_v11+126]");
						bool flag = (long)num2 < 0L;
						bool flag2 = !flag;
						obj4 = (long)(IntPtr)obj4 + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_0170;
					}
					object obj5 = obj4 + 1;
					int num3 = (int)((long)(IntPtr)obj5 << 4);
					object obj6 = (long)(IntPtr)obj3 + (long)num3;
					object obj7 = (long)(IntPtr)obj6 + 304L;
					num4 = 0;
					goto IL_03ed;
				}
				_003C_003Em__Finally1();
				obj = 0;
				return false;
				IL_0170:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				num4 = 1;
				goto IL_03ed;
				IL_03ed:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v567 @ X0_v13] (should have been resolved before IL gen)");
				Capture capture = default(Capture);
				if (capture != null)
				{
					Match match = capture as Match;
					if (match != null)
					{
						string value = capture.Value;
						_003C_003E2__current = value;
						_003C_003E1__state = 1;
						return true;
					}
					throw new InvalidCastException();
				}
				NullReferenceException ex = new NullReferenceException();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v567 @ X0_v13+8]");
				if ((IntPtr)0 == (IntPtr)1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					if (_003C_003E1__state == 1 || _003C_003E1__state + 3 == 0)
					{
						_003C_003Em__Finally1();
					}
					object obj8 = default(object);
					if (obj8 == null)
					{
						goto IL_033a;
					}
				}
				else
				{
					Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
				}
				TypeLoadException ex2 = new TypeLoadException();
				return (byte)(int)ex2 != 0;
				IL_033a:
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[Token(Token = "0x60009F6")]
			[Address(RVA = "0xA53724", Offset = "0xA53724", Length = "0xCC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EDF0E8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F89]) = v38;\nL_0014:\n\tthis.<>1__state = 0xFFFFFFFF;\n\t// 25 IsInst v44 @ X0_v3 (System.IDisposable), typeof(System.IDisposable), this.<>7__wrap1 (System.Collections.IEnumerator)\n\tv46 = v44 == 0;\n\tif (v46) goto L_0046;\n\tgoto L_0053;\n\tv55 = *([v47 @ X8_v4+B0]);\n\tv56 = 0;\n\tv57 = v55 + 8;\n\tv59 = *([v155 @ X11_v5-8]);\n\tv160 = v59 == v48;\n\tif (v160) goto L_0047;\n\tv89 = v154 + 1;\n\tv165 = v89 < v49;\n\tv86 = ~v165;\n\tv92 = v155 + 0x10;\n\tv62 = ~v86;\n\tif (v62) goto L_FFFFFFFF;\n\tv94 = v45;\n\tv95 = 0;\n\tv96 = 0x8909C4(v94, v48, v95, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0053;\nL_0046:\n\treturn;\nL_0047:\n\tv166 = *([v155 @ X11_v5]);\n\tv167 = v166 << 4;\n\tv168 = v47 + v167;\n\tv169 = v168 + 0x130;\nL_0053:\n\tSystem.IDisposable::Dispose(v44);\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void _003C_003Em__Finally1()
			{
				_003C_003E1__state = -1;
				(_003C_003E7__wrap1 as IDisposable)?.Dispose();
			}

			[DebuggerHidden]
			[Token(Token = "0x60009F8")]
			[Address(RVA = "0xA53AA4", Offset = "0xA53AA4", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EEC4B8]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([2021F8A]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}

			[DebuggerHidden]
			[Token(Token = "0x60009FA")]
			[Address(RVA = "0xA53B10", Offset = "0xA53B10", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EC2550]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F8B]) = v38;\nL_0014:\n\tv40 = this.<>1__state + 2;\n\tv42 = v40 == 0;\n\tv45 = ~v42;\n\tif (v45) goto L_002E;\n\tv48 = System.Environment::get_CurrentManagedThreadId();\n\tv50 = this.<>l__initialThreadId != v48;\n\tif (v50) goto L_002E;\n\tthis.<>1__state = 0;\n\tgoto L_0041;\nL_002E:\n\tv76 = new EasyMobile.ConsentDialog+<GetAllUrlsInContent>d__57();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v81;\n\tv76.<>4__this = this.<>4__this;\nL_0041:\n\treturn v95;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				if (_003C_003E1__state + 2 == 0)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						return this;
					}
				}
				_003CGetAllUrlsInContent_003Ed__57 _003CGetAllUrlsInContent_003Ed__58 = null;
				_003CGetAllUrlsInContent_003Ed__58._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003CGetAllUrlsInContent_003Ed__58._003C_003El__initialThreadId = currentManagedThreadId2;
				_003CGetAllUrlsInContent_003Ed__58._003C_003E4__this = _003C_003E4__this;
				return _003CGetAllUrlsInContent_003Ed__58;
			}

			[DebuggerHidden]
			[Token(Token = "0x60009FB")]
			[Address(RVA = "0xA53BC0", Offset = "0xA53BC0", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = EasyMobile.ConsentDialog+<GetAllUrlsInContent>d__57::System.Collections.Generic.IEnumerable<System.String>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000146")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000563")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000564")]
			public static Func<Toggle, string> _003C_003E9__59_0;

			[Token(Token = "0x4000565")]
			public static Func<Button, string> _003C_003E9__60_0;

			[Token(Token = "0x4000566")]
			public static Func<KeyValuePair<int, string>, int> _003C_003E9__65_2;

			[Token(Token = "0x4000567")]
			public static Func<KeyValuePair<int, string>, string> _003C_003E9__65_3;

			[Token(Token = "0x60009FC")]
			[Address(RVA = "0xA5345C", Offset = "0xA5345C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EA9348]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021F83]) = v37;\nL_0015:\n\tv41 = new EasyMobile.ConsentDialog+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60009FD")]
			[Address(RVA = "0xA534C0", Offset = "0xA534C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal string _003CGetAllToggleIds_003Eb__59_0(Toggle toggle)
			{
				return toggle.Id;
			}

			internal string _003CGetAllButtonIds_003Eb__60_0(Button button)
			{
				return button.Id;
			}

			internal int _003CGetAllPatternsInContent_003Eb__65_2(KeyValuePair<int, string> item)
			{
				//IL_000a: Expected I4, but got O
				return (int)item;
			}

			internal string _003CGetAllPatternsInContent_003Eb__65_3(KeyValuePair<int, string> item)
			{
				//IL_000a: Expected O, but got I
				IntPtr intPtr = default(IntPtr);
				return (string)(long)intPtr;
			}
		}

		[Token(Token = "0x4000308")]
		public const string TogglePattern = "</EM_CONSENT_TOGGLE. ";

		[Token(Token = "0x4000309")]
		public const string ButtonPattern = "</EM_CONSENT_BUTTON. ";

		[Token(Token = "0x400030A")]
		public const string ToggleSearchPattern = "</EM_CONSENT_TOGGLE. Id = (.*?)>";

		[Token(Token = "0x400030B")]
		public const string ButtonSearchPattern = "</EM_CONSENT_BUTTON. Id = (.*?)>";

		[Token(Token = "0x400030C")]
		public const string UrlPattern = "https?:\\/\\/(www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{2,256}\\.[a-z]{2,6}\\b([-a-zA-Z0-9@:%_\\+.~#?&//=]*)";

		[SerializeField]
		[Token(Token = "0x400030E")]
		[FieldOffset(Offset = "0x10")]
		private string mContent;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RenameAttribute), RVA = "0x7333D4", Offset = "0x7333D4")]
		[Token(Token = "0x400030F")]
		[FieldOffset(Offset = "0x18")]
		private string mTitle;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RenameAttribute), RVA = "0x733420", Offset = "0x733420")]
		[Token(Token = "0x4000310")]
		[FieldOffset(Offset = "0x20")]
		private Toggle[] mToggles;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RenameAttribute), RVA = "0x73346C", Offset = "0x73346C")]
		[Token(Token = "0x4000311")]
		[FieldOffset(Offset = "0x28")]
		private Button[] mActionButtons;

		[CompilerGenerated]
		[Token(Token = "0x4000312")]
		[FieldOffset(Offset = "0x30")]
		private ToggleStateUpdatedHandler m_ToggleStateUpdated;

		[CompilerGenerated]
		[Token(Token = "0x4000313")]
		[FieldOffset(Offset = "0x38")]
		private CompletedHandler m_Completed;

		[CompilerGenerated]
		[Token(Token = "0x4000314")]
		[FieldOffset(Offset = "0x40")]
		private Action<ConsentDialog> m_Dismissed;

		[Token(Token = "0x4000315")]
		private static IPlatformConsentDialog sPlatformDialog;

		[Token(Token = "0x170001A7")]
		[field: Token(Token = "0x400030D")]
		public static ConsentDialog ActiveDialog
		{
			[Token(Token = "0x60005AB")]
			[Address(RVA = "0xA4FF0C", Offset = "0xA4FF0C", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EBCDC0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021F5E]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.ConsentDialog>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.ConsentDialog;\nL_0024:\n\treturn v49.<ActiveDialog>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60005AC")]
			[Address(RVA = "0xA4FF74", Offset = "0xA4FF74", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE24A0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F5F]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.ConsentDialog>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.ConsentDialog;\nL_0021:\n\tv52.<ActiveDialog>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x170001A8")]
		public bool IsShowing
		{
			[Token(Token = "0x60005AD")]
			[Address(RVA = "0xA4FFE0", Offset = "0xA4FFE0", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EF05F8]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021F60]) = v40;\nL_001A:\n\tgoto L_0024;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0024;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tgoto L_002F;\n\tv59 = *([1EE7878]);\n\tv60 = *([v59 @ X8_v13]);\n\tv61 = \"il2cpp_codegen_initialize_method\"(v60, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv64 = 0 | 1;\n\t*([2021FDF]) = v64;\nL_002F:\n\tgoto L_003C;\n\tv69 = *([v65 @ X0_v5 (Il2CppClass<EasyMobile.ConsentDialog>)+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_003C;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv73 = EasyMobile.ConsentDialog;\nL_003C:\n\tv82 = v76.<ActiveDialog>k__BackingField - this;\n\tv84 = v82 == 0;\n\treturn v84;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0021: Expected O, but got I
				object obj = (long)(IntPtr)ActiveDialog - (long)(IntPtr)this;
				return obj == null;
			}
		}

		[Token(Token = "0x170001A9")]
		public string Title
		{
			[Token(Token = "0x60005AE")]
			[Address(RVA = "0xA50098", Offset = "0xA50098", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mTitle;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Title;
			}
			[Token(Token = "0x60005AF")]
			[Address(RVA = "0xA500A0", Offset = "0xA500A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mTitle = value;\n\treturn;\n")]
			set
			{
				Title = value;
			}
		}

		[Token(Token = "0x170001AA")]
		public string Content
		{
			[Token(Token = "0x60005B0")]
			[Address(RVA = "0xA500A8", Offset = "0xA500A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mContent;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Content;
			}
			[Token(Token = "0x60005B1")]
			[Address(RVA = "0xA500B0", Offset = "0xA500B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mContent = value;\n\treturn;\n")]
			set
			{
				Content = value;
			}
		}

		[Token(Token = "0x170001AB")]
		public Toggle[] Toggles
		{
			[Token(Token = "0x60005B2")]
			[Address(RVA = "0xA500B8", Offset = "0xA500B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mToggles;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Toggles;
			}
			[Token(Token = "0x60005B3")]
			[Address(RVA = "0xA500C0", Offset = "0xA500C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mToggles = value;\n\treturn;\n")]
			set
			{
				Toggles = value;
			}
		}

		[Token(Token = "0x170001AC")]
		public Button[] ActionButtons
		{
			[Token(Token = "0x60005B4")]
			[Address(RVA = "0xA500C8", Offset = "0xA500C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mActionButtons;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ActionButtons;
			}
			[Token(Token = "0x60005B5")]
			[Address(RVA = "0xA500D0", Offset = "0xA500D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mActionButtons = value;\n\treturn;\n")]
			set
			{
				ActionButtons = value;
			}
		}

		[Token(Token = "0x170001AD")]
		private static IPlatformConsentDialog PlatformDialog
		{
			[Token(Token = "0x60005BC")]
			[Address(RVA = "0xA504B0", Offset = "0xA504B0", Length = "0xE8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EC0610]);\n\tv17 = *([v16 @ X8_v19]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021F67]) = v37;\nL_0018:\n\tgoto L_0022;\n\tv44 = *([v40 @ X8_v3 (Il2CppClass<EasyMobile.ConsentDialog>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0022;\n\tv57 = v40;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v57, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv52 = EasyMobile.ConsentDialog;\nL_0022:\n\tv55 = v53.sPlatformDialog == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_0045;\n\tgoto L_0032;\n\tv77 = *([v60 @ X0_v8+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_0032;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v60, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0032:\n\tv85 = EasyMobile.Internal.Privacy.AndroidConsentDialog::get_Instance();\n\tgoto L_0041;\n\tv106 = *([v101 @ X8_v13 (Il2CppClass<EasyMobile.ConsentDialog>)+E0]);\n\tv107 = v106 == 0;\n\tv108 = ~v107;\n\tif (v108) goto L_0041;\n\tv112 = v101;\n\tv110 = \"il2cpp_codegen_runtime_class_init\"(v112, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv111 = EasyMobile.ConsentDialog;\nL_0041:\n\tv65.sPlatformDialog = v85;\nL_0045:\n\tgoto L_0054;\n\tv86 = *([v70 @ X8_v5 (Il2CppClass<EasyMobile.ConsentDialog>)+E0]);\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tgoto L_0054;\n\tv105 = v70;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v105, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv94 = EasyMobile.ConsentDialog;\nL_0054:\n\treturn v95.sPlatformDialog;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (sPlatformDialog == null)
				{
					AndroidConsentDialog instance = AndroidConsentDialog.Instance;
					sPlatformDialog = instance;
				}
				return sPlatformDialog;
			}
		}

		[Token(Token = "0x14000030")]
		public event ToggleStateUpdatedHandler ToggleStateUpdated
		{
			[CompilerGenerated]
			[Token(Token = "0x60005B6")]
			[Address(RVA = "0xA500D8", Offset = "0xA500D8", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EE9DF0]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021F61]) = v43;\nL_0017:\n\tv45 = this + 0x30;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != EasyMobile.ConsentDialog+ToggleStateUpdatedHandler;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 48L;
				Delegate obj2 = this.m_ToggleStateUpdated;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(ToggleStateUpdatedHandler))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60005B7")]
			[Address(RVA = "0xA5017C", Offset = "0xA5017C", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EEAF20]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021F62]) = v43;\nL_0017:\n\tv45 = this + 0x30;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != EasyMobile.ConsentDialog+ToggleStateUpdatedHandler;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 48L;
				Delegate obj2 = this.m_ToggleStateUpdated;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(ToggleStateUpdatedHandler))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000031")]
		public event CompletedHandler Completed
		{
			[CompilerGenerated]
			[Token(Token = "0x60005B8")]
			[Address(RVA = "0xA50220", Offset = "0xA50220", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EAAAD8]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021F63]) = v43;\nL_0017:\n\tv45 = this + 0x38;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != EasyMobile.ConsentDialog+CompletedHandler;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 56L;
				Delegate obj2 = this.m_Completed;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(CompletedHandler))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60005B9")]
			[Address(RVA = "0xA502C4", Offset = "0xA502C4", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EE8C68]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021F64]) = v43;\nL_0017:\n\tv45 = this + 0x38;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != EasyMobile.ConsentDialog+CompletedHandler;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 56L;
				Delegate obj2 = this.m_Completed;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(CompletedHandler))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000032")]
		public event Action<ConsentDialog> Dismissed
		{
			[CompilerGenerated]
			[Token(Token = "0x60005BA")]
			[Address(RVA = "0xA50368", Offset = "0xA50368", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EE42F8]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021F65]) = v43;\nL_0017:\n\tv45 = this + 0x40;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`1<EasyMobile.ConsentDialog>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 64L;
				Delegate obj2 = this.m_Dismissed;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<ConsentDialog>))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60005BB")]
			[Address(RVA = "0xA5040C", Offset = "0xA5040C", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EEEF60]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021F66]) = v43;\nL_0017:\n\tv45 = this + 0x40;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`1<EasyMobile.ConsentDialog>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 64L;
				Delegate obj2 = this.m_Dismissed;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<ConsentDialog>))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x60005BD")]
		[Address(RVA = "0xA50598", Offset = "0xA50598", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EBBBA8]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F68]) = v38;\nL_0018:\n\tthis.mTitle = \"Privacy Consent\";\n\tSystem.Object::.ctor(this);\n\tthis.mContent = v48.Empty;\n\t// 36 NewArr v53 @ X0_v4 (Toggle[]), typeof(Toggle[]), 0\n\tthis.mToggles = v53;\n\t// 42 NewArr v58 @ X0_v6 (Button[]), typeof(Button[]), 0\n\tthis.mActionButtons = v58;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ConsentDialog()
		{
			Title = "Privacy Consent";
			Content = string.Empty;
			Toggle[] toggles = new Toggle[0];
			Toggles = toggles;
			Button[] actionButtons = new Button[0];
			ActionButtons = actionButtons;
		}

		[Token(Token = "0x60005BE")]
		[Address(RVA = "0xA5063C", Offset = "0xA5063C", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EB7E68]);\n\tv17 = *([v16 @ X8_v17]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021F69]) = v37;\nL_0018:\n\tgoto L_0022;\n\tv44 = *([v40 @ X0_v2+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0022;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0022:\n\tgoto L_002D;\n\tv56 = *([1EE7878]);\n\tv57 = *([v56 @ X8_v13]);\n\tv58 = \"il2cpp_codegen_initialize_method\"(v57, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv61 = 0 | 1;\n\t*([2021FDF]) = v61;\nL_002D:\n\tgoto L_003C;\n\tv66 = *([v62 @ X0_v5 (Il2CppClass<EasyMobile.ConsentDialog>)+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tgoto L_003C;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v62, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv70 = EasyMobile.ConsentDialog;\nL_003C:\n\tv81 = v73.<ActiveDialog>k__BackingField == 0;\n\tv86 = ~v81;\n\treturn v86;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsShowingAnyDialog()
		{
			bool flag = ActiveDialog == null;
			return !flag;
		}

		[Token(Token = "0x60005BF")]
		[Address(RVA = "0xA506E8", Offset = "0xA506E8", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EA6C50]);\n\tv27 = *([v26 @ X8_v34]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, isDismissible, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2021F6A]) = v45;\nL_001D:\n\tgoto L_0027;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0027;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, isDismissible, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0027:\n\tgoto L_0032;\n\tv64 = *([1EE7878]);\n\tv65 = *([v64 @ X8_v30]);\n\tv66 = \"il2cpp_codegen_initialize_method\"(v65, isDismissible, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv69 = 0 | 1;\n\t*([2021FDF]) = v69;\nL_0032:\n\tgoto L_003B;\n\tv74 = *([v70 @ X0_v5 (Il2CppClass<EasyMobile.ConsentDialog>)+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tgoto L_003B;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v70, isDismissible, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv78 = EasyMobile.ConsentDialog;\nL_003B:\n\tv83 = v81.<ActiveDialog>k__BackingField == 0;\n\tif (v83) goto L_0058;\n\tgoto L_0055;\n\tv92 = *([v87 @ X0_v21+E0]);\n\tv93 = v92 == 0;\n\tv94 = ~v93;\n\tif (v94) goto L_0055;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v87, isDismissible, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0055:\n\tUnityEngine.Debug::Log(\"Another consent dialog is being shown. Ignoring this call.\");\n\treturn;\nL_0058:\n\tEasyMobile.ConsentDialog::AssignAsActiveDialog(this);\n\tgoto L_0063;\n\tv114 = *([v110 @ X0_v8 (Il2CppClass<EasyMobile.ConsentDialog>)+E0]);\n\tv115 = v114 == 0;\n\tv116 = ~v115;\n\tif (v116) goto L_0063;\n\tv118 = \"il2cpp_codegen_runtime_class_init\"(v110, isDismissible, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0063:\n\tv121 = EasyMobile.ConsentDialog::get_PlatformDialog();\n\tv199 = this.mTitle;\n\tv205 = new EasyMobile.Internal.Privacy.ConsentDialogContentSerializer();\n\tEasyMobile.Internal.Privacy.ConsentDialogContentSerializer::.ctor(v205, this);\n\tv210 = *([v121 @ X0_v10 (EasyMobile.Internal.Privacy.IPlatformConsentDialog)]);\n\tv211 = v205.<SerializedContent>k__BackingField;\n\tv188 = *([v210 @ X8_v16 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+126]) == 0;\n\tif (v188) goto L_0098;\n\tv255 = *([v210 @ X8_v16 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+B0]) + 8;\nL_0083:\n\tv261 = *([v255 @ X11_v5-8]) == EasyMobile.Internal.Privacy.IPlatformConsentDialog;\n\tif (v261) goto L_009B;\n\tv256 = v256 + 1;\n\tv266 = v256 < *([v210 @ X8_v16 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+126]);\n\tv237 = ~v266;\n\tv255 = v255 + 0x10;\n\tv221 = ~v237;\n\tif (v221) goto L_0083;\nL_0098:\n\tv273 = 0x8909C4(v121, EasyMobile.Internal.Privacy.IPlatformConsentDialog, 7, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_009F;\nL_009B:\n\tv268 = *([v255 @ X11_v5]) + 7;\n\tv269 = v268 << 4;\n\tv270 = v210 + v269;\n\tv273 = v270 + 0x130;\nL_009F:\n\tv127 = *([v273 @ X0_v15]);\n\tv125 = *([v273 @ X0_v15+8]);\n\t// 173 IndirectJump v127 @ X5_v1, v121 @ X0_v10 (EasyMobile.Internal.Privacy.IPlatformConsentDialog), v121 @ X0_v10 (EasyMobile.Internal.Privacy.IPlatformConsentDialog), v199 @ X21_v4 (System.String), v211 @ X20_v2 (System.String), isDismissible @ X1 (System.Boolean), v125 @ X4_v1, v127 @ X5_v1, v33 @ X6, v34 @ X7, v35 @ V0, v36 @ V1, v37 @ V2, v38 @ V3, v39 @ V4, v40 @ V5, v41 @ V6, v42 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 107 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Show(bool isDismissible = false)
		{
			//IL_0055: Expected I, but got O
			//IL_01bf: Expected O, but got I
			//IL_009d: Expected O, but got I
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Expected O, but got Unknown
			//IL_0141: Expected O, but got I
			//IL_0150: Expected O, but got I
			//IL_00e9: Expected O, but got I
			if (ActiveDialog != null)
			{
				Debug.Log("Another consent dialog is being shown. Ignoring this call.");
				return;
			}
			AssignAsActiveDialog();
			IPlatformConsentDialog platformDialog = PlatformDialog;
			string title = Title;
			ConsentDialogContentSerializer consentDialogContentSerializer = new ConsentDialogContentSerializer(this);
			IntPtr intPtr = (IntPtr)platformDialog;
			string text = consentDialogContentSerializer.SerializedContent;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ X8_v16 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0102;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ X8_v16 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IPlatformConsentDialog))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ X8_v16 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_0102;
			}
			object obj2 = obj + 7;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_01a7;
			IL_01a7:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ X0_v15+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v127 @ X5_v1 (should have been resolved before IL gen)");
			return;
			IL_0102:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_01a7;
		}

		[Token(Token = "0x60005C0")]
		[Address(RVA = "0xA50BF4", Offset = "0xA50BF4", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = System.String::Concat(this.mContent, text);\n\tthis.mContent = v12;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AppendText(string text)
		{
			string content = Content + text;
			Content = content;
		}

		[Token(Token = "0x60005C1")]
		[Address(RVA = "0xA50C20", Offset = "0xA50C20", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EBF1F0]);\n\tv25 = *([v24 @ X8_v19]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, toggle, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021F6B]) = v43;\nL_0016:\n\tv44 = toggle == 0;\n\tif (v44) goto L_0051;\n\tv53 = System.String::Concat(\"</EM_CONSENT_TOGGLE. Id = \", toggle.id, \">\");\n\tv86 = System.String::Concat(this.mContent, v53);\n\tthis.mContent = v86;\n\tv67 = System.Linq.Enumerable::Contains(this.mToggles, toggle);\n\tv107 = v67 == 0;\n\tv70 = ~v107;\n\tif (v70) goto L_0051;\n\tv111 = new System.Collections.Generic.List`1<EasyMobile.ConsentDialog+Toggle>();\n\tSystem.Collections.Generic.List`1<EasyMobile.ConsentDialog+Toggle>::.ctor(v111, this.mToggles);\n\tSystem.Collections.Generic.List`1<EasyMobile.ConsentDialog+Toggle>::Add(v111, toggle);\n\tv66 = System.Collections.Generic.List`1<EasyMobile.ConsentDialog+Toggle>::ToArray(v111);\n\tthis.mToggles = v66;\nL_0051:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AppendToggle(Toggle toggle)
		{
			//IL_0089: Expected I4, but got O
			if (toggle != null)
			{
				string text = "</EM_CONSENT_TOGGLE. Id = " + toggle.Id + ">";
				string content = Content + text;
				Content = content;
				if (!Toggles.Contains(toggle))
				{
					List<Toggle> list = new List<Toggle>((int)Toggles);
					list.Add(toggle);
					Toggle[] toggles = list.ToArray();
					Toggles = toggles;
				}
			}
		}

		[Token(Token = "0x60005C2")]
		[Address(RVA = "0xA50D30", Offset = "0xA50D30", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1F0F9F8]);\n\tv25 = *([v24 @ X8_v19]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, button, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021F6C]) = v43;\nL_0016:\n\tv44 = button == 0;\n\tif (v44) goto L_0051;\n\tv53 = System.String::Concat(\"</EM_CONSENT_BUTTON. Id = \", button.id, \">\");\n\tv86 = System.String::Concat(this.mContent, v53);\n\tthis.mContent = v86;\n\tv67 = System.Linq.Enumerable::Contains(this.mActionButtons, button);\n\tv107 = v67 == 0;\n\tv70 = ~v107;\n\tif (v70) goto L_0051;\n\tv111 = new System.Collections.Generic.List`1<EasyMobile.ConsentDialog+Button>();\n\tSystem.Collections.Generic.List`1<EasyMobile.ConsentDialog+Button>::.ctor(v111, this.mActionButtons);\n\tSystem.Collections.Generic.List`1<EasyMobile.ConsentDialog+Button>::Add(v111, button);\n\tv66 = System.Collections.Generic.List`1<EasyMobile.ConsentDialog+Button>::ToArray(v111);\n\tthis.mActionButtons = v66;\nL_0051:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AppendButton(Button button)
		{
			//IL_0089: Expected I4, but got O
			if (button != null)
			{
				string text = "</EM_CONSENT_BUTTON. Id = " + button.Id + ">";
				string content = Content + text;
				Content = content;
				if (!ActionButtons.Contains(button))
				{
					List<Button> list = new List<Button>((int)ActionButtons);
					list.Add(button);
					Button[] actionButtons = list.ToArray();
					ActionButtons = actionButtons;
				}
			}
		}

		[Token(Token = "0x60005C3")]
		[Address(RVA = "0xA50E40", Offset = "0xA50E40", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1F02678]);\n\tv25 = *([v24 @ X8_v20]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, toggleId, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021F6D]) = v43;\nL_0019:\n\tv47 = new EasyMobile.ConsentDialog+<>c__DisplayClass50_0();\n\tSystem.Object::.ctor(v47);\n\tv47.toggleId = toggleId;\n\tv55 = new System.Collections.Generic.List`1<EasyMobile.ConsentDialog+Toggle>();\n\tSystem.Collections.Generic.List`1<EasyMobile.ConsentDialog+Toggle>::.ctor(v55, this.mToggles);\n\tv68 = new System.Predicate`1<EasyMobile.ConsentDialog+Toggle>();\n\tSystem.Predicate`1<EasyMobile.ConsentDialog+Toggle>::.ctor(v68, v47, Il2CppMethodInfo);\n\tv113 = System.Collections.Generic.List`1<EasyMobile.ConsentDialog+Toggle>::RemoveAll(v55, v68);\n\tv95 = System.Collections.Generic.List`1<EasyMobile.ConsentDialog+Toggle>::ToArray(v55);\n\tthis.mToggles = v95;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemoveToggle(string toggleId)
		{
			//IL_001d: Expected I4, but got O
			List<Toggle> list = new List<Toggle>((int)Toggles);
			Predicate<Toggle> match = (Toggle t) => t.Id == toggleId;
			int num = list.RemoveAll(match);
			Toggle[] toggles = list.ToArray();
			Toggles = toggles;
		}

		[Token(Token = "0x60005C4")]
		[Address(RVA = "0xA50F54", Offset = "0xA50F54", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EB97C8]);\n\tv25 = *([v24 @ X8_v20]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, buttonId, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021F6E]) = v43;\nL_0019:\n\tv47 = new EasyMobile.ConsentDialog+<>c__DisplayClass51_0();\n\tSystem.Object::.ctor(v47);\n\tv47.buttonId = buttonId;\n\tv55 = new System.Collections.Generic.List`1<EasyMobile.ConsentDialog+Button>();\n\tSystem.Collections.Generic.List`1<EasyMobile.ConsentDialog+Button>::.ctor(v55, this.mActionButtons);\n\tv68 = new System.Predicate`1<EasyMobile.ConsentDialog+Button>();\n\tSystem.Predicate`1<EasyMobile.ConsentDialog+Button>::.ctor(v68, v47, Il2CppMethodInfo);\n\tv113 = System.Collections.Generic.List`1<EasyMobile.ConsentDialog+Button>::RemoveAll(v55, v68);\n\tv95 = System.Collections.Generic.List`1<EasyMobile.ConsentDialog+Button>::ToArray(v55);\n\tthis.mActionButtons = v95;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemoveButton(string buttonId)
		{
			//IL_001d: Expected I4, but got O
			List<Button> list = new List<Button>((int)ActionButtons);
			Predicate<Button> match = (Button b) => b.Id == buttonId;
			int num = list.RemoveAll(match);
			Button[] actionButtons = list.ToArray();
			ActionButtons = actionButtons;
		}

		[Token(Token = "0x60005C5")]
		[Address(RVA = "0xA51068", Offset = "0xA51068", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1ED97D8]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, id, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F6F]) = v41;\nL_0018:\n\tv45 = new EasyMobile.ConsentDialog+<>c__DisplayClass52_0();\n\tSystem.Object::.ctor(v45);\n\tv45.id = id;\n\tv49 = id == 0;\n\tif (v49) goto L_FFFFFFFF;\n\tv53 = this.mToggles == 0;\n\tif (v53) goto L_FFFFFFFF;\n\tv60 = new System.Func`2<EasyMobile.ConsentDialog+Toggle, System.Boolean>();\n\tSystem.Func`2<EasyMobile.ConsentDialog+Toggle, System.Boolean>::.ctor(v60, v45, Il2CppMethodInfo);\n\tv104 = System.Linq.Enumerable::Where(this.mToggles, v60);\n\treturnVal2 = System.Linq.Enumerable::FirstOrDefault(v104);\n\tgoto L_0043;\nL_0043:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Toggle FindToggleWithId(string id)
		{
			string id2 = id;
			if (id != null && Toggles != null)
			{
				Func<Toggle, bool> predicate = (Toggle toggle) => toggle.Id.Equals(id2);
				IEnumerable<Toggle> source = Toggles.Where(predicate);
				return source.FirstOrDefault();
			}
			return null;
		}

		[Token(Token = "0x60005C6")]
		[Address(RVA = "0xA51158", Offset = "0xA51158", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EBF4A0]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, id, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F70]) = v41;\nL_0018:\n\tv45 = new EasyMobile.ConsentDialog+<>c__DisplayClass53_0();\n\tSystem.Object::.ctor(v45);\n\tv45.id = id;\n\tv49 = id == 0;\n\tif (v49) goto L_FFFFFFFF;\n\tv53 = this.mActionButtons == 0;\n\tif (v53) goto L_FFFFFFFF;\n\tv60 = new System.Func`2<EasyMobile.ConsentDialog+Button, System.Boolean>();\n\tSystem.Func`2<EasyMobile.ConsentDialog+Button, System.Boolean>::.ctor(v60, v45, Il2CppMethodInfo);\n\tv104 = System.Linq.Enumerable::Where(this.mActionButtons, v60);\n\treturnVal2 = System.Linq.Enumerable::FirstOrDefault(v104);\n\tgoto L_0043;\nL_0043:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Button FindButtonWithId(string id)
		{
			string id2 = id;
			if (id != null && ActionButtons != null)
			{
				Func<Button, bool> predicate = (Button button) => button.Id.Equals(id2);
				IEnumerable<Button> source = ActionButtons.Where(predicate);
				return source.FirstOrDefault();
			}
			return null;
		}

		[Token(Token = "0x60005C7")]
		[Address(RVA = "0xA51248", Offset = "0xA51248", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EC77B8]);\n\tv27 = *([v26 @ X8_v15]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, buttonId, interactable, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021F71]) = v44;\nL_0019:\n\tv47 = EasyMobile.ConsentDialog::FindButtonWithId(this, buttonId);\n\tv48 = v47 == 0;\n\tif (v48) goto L_0060;\n\tv47.interactable = interactable;\n\tv51 = EasyMobile.ConsentDialog::get_IsShowing(this);\n\tv54 = v51 == 0;\n\tif (v54) goto L_0060;\n\tgoto L_002F;\n\tv141 = *([v137 @ X0_v7 (Il2CppClass<EasyMobile.ConsentDialog>)+E0]);\n\tv142 = v141 == 0;\n\tv143 = ~v142;\n\tif (v143) goto L_002F;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v137, v46, interactable, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002F:\n\tv147 = EasyMobile.ConsentDialog::get_PlatformDialog();\n\tv149 = *([v147 @ X0_v9 (EasyMobile.Internal.Privacy.IPlatformConsentDialog)]);\n\tv119 = *([v149 @ X8_v9 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+126]) == 0;\n\tif (v119) goto L_0057;\n\tv193 = *([v149 @ X8_v9 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+B0]) + 8;\nL_0042:\n\tv199 = *([v193 @ X11_v5-8]) == EasyMobile.Internal.Privacy.IPlatformConsentDialog;\n\tif (v199) goto L_0062;\n\tv194 = v194 + 1;\n\tv204 = v194 < *([v149 @ X8_v9 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+126]);\n\tv175 = ~v204;\n\tv193 = v193 + 0x10;\n\tv159 = ~v175;\n\tif (v159) goto L_0042;\nL_0057:\n\tv211 = 0x8909C4(v147, EasyMobile.Internal.Privacy.IPlatformConsentDialog, 8, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0066;\nL_0060:\n\treturn;\nL_0062:\n\tv206 = *([v193 @ X11_v5]) + 8;\n\tv207 = v206 << 4;\n\tv208 = v149 + v207;\n\tv211 = v208 + 0x130;\nL_0066:\n\tv66 = *([v211 @ X0_v11]);\n\tv64 = *([v211 @ X0_v11+8]);\n\t// 114 IndirectJump v66 @ X4_v1, v147 @ X0_v9 (EasyMobile.Internal.Privacy.IPlatformConsentDialog), v147 @ X0_v9 (EasyMobile.Internal.Privacy.IPlatformConsentDialog), buttonId @ X1 (System.String), interactable @ X2 (System.Boolean), v64 @ X3_v1, v66 @ X4_v1, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetButtonInteractable(string buttonId, bool interactable)
		{
			//IL_0054: Expected I, but got O
			//IL_01b5: Expected O, but got I
			//IL_008f: Expected O, but got I
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Expected O, but got Unknown
			//IL_0134: Expected O, but got I
			//IL_0143: Expected O, but got I
			//IL_00db: Expected O, but got I
			Button button = FindButtonWithId(buttonId);
			if (button == null)
			{
				return;
			}
			button.interactable = interactable;
			if (!IsShowing)
			{
				return;
			}
			IPlatformConsentDialog platformDialog = PlatformDialog;
			IntPtr intPtr = (IntPtr)platformDialog;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X8_v9 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00f4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X8_v9 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IPlatformConsentDialog))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X8_v9 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00f4;
			}
			object obj2 = obj + 8;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_019d;
			IL_00f4:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_019d;
			IL_019d:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ X0_v11+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v66 @ X4_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60005C8")]
		[Address(RVA = "0xA5136C", Offset = "0xA5136C", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EF0F98]);\n\tv27 = *([v26 @ X8_v15]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, toggleId, interactable, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021F72]) = v44;\nL_0019:\n\tv47 = EasyMobile.ConsentDialog::FindToggleWithId(this, toggleId);\n\tv48 = v47 == 0;\n\tif (v48) goto L_0060;\n\tv47.interactable = interactable;\n\tv51 = EasyMobile.ConsentDialog::get_IsShowing(this);\n\tv54 = v51 == 0;\n\tif (v54) goto L_0060;\n\tgoto L_002F;\n\tv141 = *([v137 @ X0_v7 (Il2CppClass<EasyMobile.ConsentDialog>)+E0]);\n\tv142 = v141 == 0;\n\tv143 = ~v142;\n\tif (v143) goto L_002F;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v137, v46, interactable, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002F:\n\tv147 = EasyMobile.ConsentDialog::get_PlatformDialog();\n\tgoto L_0072;\n\tv153 = *([v149 @ X8_v9+B0]);\n\tv154 = 0;\n\tv155 = v153 + 8;\n\tv157 = *([v193 @ X11_v5-8]);\n\tv199 = v157 == v152;\n\tif (v199) goto L_0061;\n\tv179 = v194 + 1;\n\tv204 = v179 < v151;\n\tv175 = ~v204;\n\tv177 = v193 + 0x10;\n\tv159 = ~v175;\n\tif (v159) goto L_FFFFFFFF;\n\tv180 = 9;\n\tv181 = v123;\n\tv182 = 0x8909C4(v181, v152, v180, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0072;\nL_0060:\n\treturn;\nL_0061:\n\tv205 = *([v193 @ X11_v5]);\n\tv206 = v205 + 9;\n\tv207 = v206 << 4;\n\tv208 = v149 + v207;\n\tv209 = v208 + 0x130;\nL_0072:\n\tEasyMobile.Internal.Privacy.IPlatformConsentDialog::SetToggleInteractable(v147, toggleId, interactable);\n\tthrow System.NullReferenceException;\n\treturn;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetToggleInteractable(string toggleId, bool interactable)
		{
			Toggle toggle = FindToggleWithId(toggleId);
			if (toggle != null)
			{
				toggle.interactable = interactable;
				if (IsShowing)
				{
					IPlatformConsentDialog platformDialog = PlatformDialog;
					platformDialog.SetToggleInteractable(toggleId, interactable);
				}
			}
		}

		[Token(Token = "0x60005C9")]
		[Address(RVA = "0xA51490", Offset = "0xA51490", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv30 = *([1EB2900]);\n\tv31 = *([v30 @ X8_v13]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, toggleId, isOn, animated, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2021F73]) = v47;\nL_001A:\n\tv49 = EasyMobile.ConsentDialog::get_IsShowing(this);\n\tv51 = v49 == 0;\n\tif (v51) goto L_005C;\n\tgoto L_002A;\n\tv65 = *([v54 @ X0_v4 (Il2CppClass<EasyMobile.ConsentDialog>)+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_002A;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v54, toggleId, isOn, animated, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_002A:\n\tv72 = EasyMobile.ConsentDialog::get_PlatformDialog();\n\tgoto L_0070;\n\tv153 = *([v149 @ X8_v7+B0]);\n\tv154 = 0;\n\tv155 = v153 + 8;\n\tv157 = *([v193 @ X11_v5-8]);\n\tv199 = v157 == v152;\n\tif (v199) goto L_005D;\n\tv179 = v194 + 1;\n\tv204 = v179 < v151;\n\tv175 = ~v204;\n\tv177 = v193 + 0x10;\n\tv159 = ~v175;\n\tif (v159) goto L_FFFFFFFF;\n\tv180 = 0xA;\n\tv181 = v135;\n\tv182 = 0x8909C4(v181, v152, v180, animated, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0070;\nL_005C:\n\treturn;\nL_005D:\n\tv205 = *([v193 @ X11_v5]);\n\tv206 = v205 + 0xA;\n\tv207 = v206 << 4;\n\tv208 = v149 + v207;\n\tv209 = v208 + 0x130;\nL_0070:\n\tEasyMobile.Internal.Privacy.IPlatformConsentDialog::SetToggleIsOn(v72, toggleId, isOn, animated);\n\tthrow System.NullReferenceException;\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetToggleIsOn(string toggleId, bool isOn, bool animated = true)
		{
			if (IsShowing)
			{
				IPlatformConsentDialog platformDialog = PlatformDialog;
				platformDialog.SetToggleIsOn(toggleId, isOn, animated);
			}
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x734F80", Offset = "0x734F80")]
		[Token(Token = "0x60005CA")]
		[Address(RVA = "0xA515B0", Offset = "0xA515B0", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EC1260]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F74]) = v38;\nL_0016:\n\tv42 = new EasyMobile.ConsentDialog+<GetAllUrlsInContent>d__57();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0xFFFFFFFE;\n\tv47 = System.Environment::get_CurrentManagedThreadId();\n\tv42.<>l__initialThreadId = v47;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IEnumerable<string> GetAllUrlsInContent()
		{
			_003CGetAllUrlsInContent_003Ed__57 _003CGetAllUrlsInContent_003Ed__58 = new _003CGetAllUrlsInContent_003Ed__57(-2);
			int currentManagedThreadId = Environment.CurrentManagedThreadId;
			_003CGetAllUrlsInContent_003Ed__58._003C_003El__initialThreadId = currentManagedThreadId;
			_003CGetAllUrlsInContent_003Ed__58._003C_003E4__this = this;
			return _003CGetAllUrlsInContent_003Ed__58;
		}

		[Token(Token = "0x60005CB")]
		[Address(RVA = "0xA5166C", Offset = "0xA5166C", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EB15A0]);\n\tv31 = *([v30 @ X8_v23]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2021F75]) = v50;\nL_001C:\n\tv262 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v262);\n\tv60 = EasyMobile.ConsentDialog::GetAllPatternsInContent(this);\n\tv62 = v60 == 0;\n\tif (v62) goto L_00A6;\n\tv146 = v60._size;\n\tv75 = v60._size <= 0;\n\tif (v75) goto L_00A6;\n\tv144 = this.mContent;\nL_003B:\n\tv148 = v146 < v116;\n\tv149 = ~v148;\n\tv150 = v146 - v116;\n\tv152 = v150 == 0;\n\tv157 = ~v152;\n\tv158 = v149 & v157;\n\tif (v158) goto L_0049;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0049:\n\tv162 = v60._items;\n\t// 79 NewArr v166 @ X0_v23 (System.String[]), typeof(System.String[]), 1\n\tv297 = v162[v116 @ X25_v9 (System.Int32)] == 0;\n\tif (v297) goto L_005E;\n\t// 88 IsInst v356 @ X0_v38, typeof(System.String), v162[v116 @ X25_v9 (System.Int32)]\n\tv358 = v356 == 0;\n\tif (v358) goto L_00C5;\nL_005E:\n\tv166[0] = v162[v116 @ X25_v9 (System.Int32)];\n\tv290 = System.String::Split(v144, v166, 2, 0);\n\tv144 = v290[1];\n\tv225 = System.String::IsNullOrEmpty(v290[0]);\n\tv392 = v225 == 0;\n\tif (v392) goto L_0087;\n\tv393 = v262 == 0;\n\tv229 = ~v393;\n\tif (v229) goto L_008B;\n\tgoto L_00C4;\nL_0087:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v262, v290[0]);\nL_008B:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v262, v162[v116 @ X25_v9 (System.Int32)]);\n\tv146 = v60._size;\n\tv116 = v116 + 1;\n\tv119 = v116 < v60._size;\n\tif (v119) goto L_003B;\n\tv319 = System.String::IsNullOrEmpty(v144);\n\tv404 = v319 == 0;\n\tv265 = ~v404;\n\tif (v265) goto L_00BE;\n\tgoto L_00B1;\nL_00A6:\n\tv262 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v262);\n\tv259 = this.mContent;\nL_00B1:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v262, v259);\nL_00BE:\n\treturn v323;\n\tv384 = new System.IndexOutOfRangeException();\nL_00C2:\n\tthrow System.TypeLoadException;\nL_00C4:\n\tv296 = new System.NullReferenceException();\nL_00C5:\n\tv363 = new System.ArrayTypeMismatchException();\n\tgoto L_00C2;\n\treturn X0;\n// 138 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public List<string> GetSplittedContents()
		{
			List<string> list = new List<string>();
			List<string> allPatternsInContent = GetAllPatternsInContent();
			List<string> result;
			string item;
			if (allPatternsInContent != null)
			{
				int count = allPatternsInContent.Count;
				if (allPatternsInContent.Count > 0)
				{
					string text = Content;
					int num = 0;
					do
					{
						bool flag = count < num;
						bool flag2 = !flag;
						int num2 = count - num;
						bool flag3 = num2 == 0;
						bool flag4 = !flag3;
						if (!(flag2 && flag4))
						{
							throw new ArgumentOutOfRangeException();
						}
						string[] items = allPatternsInContent._items;
						string[] array = new string[1];
						if (items[num] != null)
						{
							object obj = items[num] as string;
							if (obj == null)
							{
								goto IL_029f;
							}
						}
						array[0] = items[num];
						string[] array2 = text.Split(array, 2, default(StringSplitOptions));
						text = array2[1];
						if (string.IsNullOrEmpty(array2[0]))
						{
							if (list == null)
							{
								NullReferenceException ex = new NullReferenceException();
								goto IL_029f;
							}
						}
						else
						{
							list.Add(array2[0]);
						}
						list.Add(items[num]);
						count = allPatternsInContent.Count;
						num++;
						continue;
						IL_029f:
						ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
						throw new TypeLoadException();
					}
					while (num < allPatternsInContent.Count);
					bool flag5 = string.IsNullOrEmpty(text);
					bool flag6 = !flag5;
					bool flag7 = !flag6;
					result = list;
					if (flag7)
					{
						goto IL_0294;
					}
					item = text;
					result = list;
					goto IL_032f;
				}
			}
			list = new List<string>();
			item = Content;
			result = list;
			goto IL_032f;
			IL_032f:
			list.Add(item);
			goto IL_0294;
			IL_0294:
			return result;
		}

		[Token(Token = "0x60005CC")]
		[Address(RVA = "0xA51D4C", Offset = "0xA51D4C", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EE5CA0]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021F76]) = v42;\nL_0016:\n\tv44 = this.mToggles == 0;\n\tif (v44) goto L_FFFFFFFF;\n\tgoto L_0026;\n\tv52 = *([v47 @ X0_v4 (Il2CppClass<EasyMobile.ConsentDialog+<>c>)+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0026;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv56 = EasyMobile.ConsentDialog+<>c;\nL_0026:\n\tv82 = v59.<>9__59_0;\n\tv61 = v59.<>9__59_0 == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_004B;\n\tgoto L_0039;\n\tv111 = *([v55 @ X0_v5 (Il2CppClass<EasyMobile.ConsentDialog+<>c>)+E0]);\n\tv112 = v111 == 0;\n\tv113 = ~v112;\n\tif (v113) goto L_0039;\n\tv116 = \"il2cpp_codegen_runtime_class_init\"(v55, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv126 = EasyMobile.ConsentDialog+<>c;\n\tv118 = *([v126 @ X8_v19+B8]);\nL_0039:\n\tv101 = new System.Func`2<EasyMobile.ConsentDialog+Toggle, System.String>();\n\tSystem.Func`2<EasyMobile.ConsentDialog+Toggle, System.String>::.ctor(v101, v117.<>9, Il2CppMethodInfo);\n\tv104.<>9__59_0 = v101;\nL_004B:\n\tv110 = System.Linq.Enumerable::Select(this.mToggles, v82);\n\treturnVal1 = System.Linq.Enumerable::ToList(v110);\n\tgoto L_0059;\nL_0059:\n\treturn returnVal1;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public List<string> GetAllToggleIds()
		{
			if (Toggles == null)
			{
				return null;
			}
			Func<Toggle, string> selector = _003C_003Ec._003C_003E9__59_0;
			if (_003C_003Ec._003C_003E9__59_0 == null)
			{
				selector = (_003C_003Ec._003C_003E9__59_0 = (Toggle toggle) => toggle.Id);
			}
			IEnumerable<string> source = Toggles.Select(selector);
			return source.ToList();
		}

		[Token(Token = "0x60005CD")]
		[Address(RVA = "0xA51E5C", Offset = "0xA51E5C", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EB46B0]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021F77]) = v42;\nL_0016:\n\tv44 = this.mActionButtons == 0;\n\tif (v44) goto L_FFFFFFFF;\n\tgoto L_0026;\n\tv52 = *([v47 @ X0_v4 (Il2CppClass<EasyMobile.ConsentDialog+<>c>)+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0026;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv56 = EasyMobile.ConsentDialog+<>c;\nL_0026:\n\tv82 = v59.<>9__60_0;\n\tv61 = v59.<>9__60_0 == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_004B;\n\tgoto L_0039;\n\tv111 = *([v55 @ X0_v5 (Il2CppClass<EasyMobile.ConsentDialog+<>c>)+E0]);\n\tv112 = v111 == 0;\n\tv113 = ~v112;\n\tif (v113) goto L_0039;\n\tv116 = \"il2cpp_codegen_runtime_class_init\"(v55, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv126 = EasyMobile.ConsentDialog+<>c;\n\tv118 = *([v126 @ X8_v19+B8]);\nL_0039:\n\tv101 = new System.Func`2<EasyMobile.ConsentDialog+Button, System.String>();\n\tSystem.Func`2<EasyMobile.ConsentDialog+Button, System.String>::.ctor(v101, v117.<>9, Il2CppMethodInfo);\n\tv104.<>9__60_0 = v101;\nL_004B:\n\tv110 = System.Linq.Enumerable::Select(this.mActionButtons, v82);\n\treturnVal1 = System.Linq.Enumerable::ToList(v110);\n\tgoto L_0059;\nL_0059:\n\treturn returnVal1;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public List<string> GetAllButtonIds()
		{
			if (ActionButtons == null)
			{
				return null;
			}
			Func<Button, string> selector = _003C_003Ec._003C_003E9__60_0;
			if (_003C_003Ec._003C_003E9__60_0 == null)
			{
				selector = (_003C_003Ec._003C_003E9__60_0 = (Button button) => button.Id);
			}
			IEnumerable<string> source = ActionButtons.Select(selector);
			return source.ToList();
		}

		[Token(Token = "0x60005CE")]
		[Address(RVA = "0xA51F6C", Offset = "0xA51F6C", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1F0B9D8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F78]) = v38;\nL_0015:\n\tv41 = System.String::IsNullOrEmpty(source);\n\tv43 = v41 == 0;\n\tif (v43) goto L_0026;\n\treturn 0;\nL_0026:\n\tgoto L_0036;\n\tv73 = *([v51 @ X0_v4+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_0036;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v51, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0036:\n\treturnVal2 = System.Text.RegularExpressions.Regex::IsMatch(source, \"</EM_CONSENT_TOGGLE. Id = (.*?)>\");\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsTogglePattern(string source)
		{
			if (string.IsNullOrEmpty(source))
			{
				return false;
			}
			return Regex.IsMatch(source, "</EM_CONSENT_TOGGLE. Id = (.*?)>");
		}

		[Token(Token = "0x60005CF")]
		[Address(RVA = "0xA52000", Offset = "0xA52000", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EF3040]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F79]) = v38;\nL_0015:\n\tv41 = System.String::IsNullOrEmpty(source);\n\tv43 = v41 == 0;\n\tif (v43) goto L_0026;\n\treturn 0;\nL_0026:\n\tgoto L_0036;\n\tv73 = *([v51 @ X0_v4+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_0036;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v51, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0036:\n\treturnVal2 = System.Text.RegularExpressions.Regex::IsMatch(source, \"</EM_CONSENT_BUTTON. Id = (.*?)>\");\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsButtonPattern(string source)
		{
			if (string.IsNullOrEmpty(source))
			{
				return false;
			}
			return Regex.IsMatch(source, "</EM_CONSENT_BUTTON. Id = (.*?)>");
		}

		[Token(Token = "0x60005D0")]
		[Address(RVA = "0xA52094", Offset = "0xA52094", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC12E0]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F7A]) = v38;\nL_0019:\n\tgoto L_0024;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0024;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0024:\n\tv57 = System.Text.RegularExpressions.Regex::Match(source, \"</EM_CONSENT_TOGGLE. Id = (.*?)>\");\n\tv62 = System.Text.RegularExpressions.Match::get_Groups(v57);\n\tv71 = System.Text.RegularExpressions.GroupCollection::get_Item(v62, 1);\n\treturnVal2 = System.Text.RegularExpressions.Capture::get_Value(v71);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string SearchForIdInTogglePattern(string source)
		{
			Match match = Regex.Match(source, "</EM_CONSENT_TOGGLE. Id = (.*?)>");
			GroupCollection groups = match.Groups;
			Group obj = groups.get_Item(1);
			return obj.Value;
		}

		[Token(Token = "0x60005D1")]
		[Address(RVA = "0xA52138", Offset = "0xA52138", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA64E8]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F7B]) = v38;\nL_0019:\n\tgoto L_0024;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0024;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0024:\n\tv57 = System.Text.RegularExpressions.Regex::Match(source, \"</EM_CONSENT_BUTTON. Id = (.*?)>\");\n\tv62 = System.Text.RegularExpressions.Match::get_Groups(v57);\n\tv71 = System.Text.RegularExpressions.GroupCollection::get_Item(v62, 1);\n\treturnVal2 = System.Text.RegularExpressions.Capture::get_Value(v71);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string SearchForIdInButtonPattern(string source)
		{
			Match match = Regex.Match(source, "</EM_CONSENT_BUTTON. Id = (.*?)>");
			GroupCollection groups = match.Groups;
			Group obj = groups.get_Item(1);
			return obj.Value;
		}

		[Token(Token = "0x60005D2")]
		[Address(RVA = "0xA51864", Offset = "0xA51864", Length = "0x4E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = &v21 @ X29;\n\tgoto L_001D;\n\tv33 = *([1EF07B0]);\n\tv34 = *([v33 @ X8_v83]);\n\tv35 = \"il2cpp_codegen_initialize_method\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2021F7C]) = v53;\nL_001D:\n\tv55 = &v56 @ stack_-F0;\n\t*([v21 @ X29-60]) = 0;\n\t*([v21 @ X29-80]) = 0;\n\t*([v21 @ X29-70]) = 0;\n\t*([v21 @ X29-A0]) = 0;\n\t*([v21 @ X29-90]) = 0;\n\tv61 = new EasyMobile.ConsentDialog+<>c__DisplayClass65_0();\n\tSystem.Object::.ctor(v61);\n\tv67 = new System.Collections.Generic.HashSet`1<System.String>();\n\tSystem.Collections.Generic.HashSet`1<System.String>::.ctor(v67);\n\tv61.allPatterns = v67;\n\tv77 = EasyMobile.ConsentDialog::SearchPatternInContent(this, \"</EM_CONSENT_BUTTON. Id = (.*?)>\");\n\tv142 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v142, v61, Il2CppMethodInfo);\n\tSystem.Collections.Generic.List`1<System.String>::ForEach(v77, v142);\n\tv246 = EasyMobile.ConsentDialog::SearchPatternInContent(this, \"</EM_CONSENT_TOGGLE. Id = (.*?)>\");\n\tv143 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v143, v61, Il2CppMethodInfo);\n\tSystem.Collections.Generic.List`1<System.String>::ForEach(v246, v143);\n\tv427 = new System.Collections.Generic.Dictionary`2<System.Int32, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.String>::.ctor(v427);\n\tv488 = System.Collections.Generic.HashSet`1<System.String>::GetEnumerator(v61.allPatterns);\n\t*([v21 @ X29-60]) = *([v21 @ X29-B8]);\n\t*([v21 @ X29-70]) = *([v21 @ X29-C8]);\nL_0089:\n\tv575 = &v21 @ X29 - 0x70;\n\tv576 = System.Collections.Generic.HashSet`1<System.String>+Enumerator<System.String>::MoveNext(v575);\n\tv591 = v576 == 0;\n\tif (v591) goto L_00E5;\n\tv608 = EasyMobile.ConsentDialog::IndexesOf(v576, this.mContent, *([v21 @ X29-60]));\n\tv617 = System.Collections.Generic.Dictionary`2<System.Int32, System.String>::GetEnumerator(v608);\n\t*([v21 @ X29-80]) = *([v21 @ X29-A8]);\n\t*([v21 @ X29-A0]) = *([v21 @ X29-C8]);\n\t*([v21 @ X29-90]) = *([v21 @ X29-B8]);\nL_009D:\n\tv625 = &v21 @ X29 - 0xA0;\n\tv626 = System.Collections.Generic.Dictionary`2<System.Int32, System.String>+Enumerator<System.Int32, System.String>::MoveNext(v625);\n\tv628 = v626 == 0;\n\tif (v628) goto L_00AA;\n\tv222 = v427 == 0;\n\tif (v222) goto L_00B0;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.String>::Add(v427, *([v21 @ X29-90]), *([v21 @ X29-88]));\n\tgoto L_009D;\nL_00AA:\n\tv610 = v610 + 1;\n\t*([v55 @ X23_v1+v610 @ X24_v10*4]) = 0xB1;\n\tgoto L_00C5;\nL_00B0:\n\tv220 = new System.NullReferenceException();\n\tgoto L_00EC;\n\tgoto L_00B4;\n\tgoto L_00B4;\nL_00B4:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00F9;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00C5:\n\tv633 = &v21 @ X29 - 0xA0;\n\tv568 = System.Collections.Generic.Dictionary`2<System.Int32, System.String>+Enumerator<System.Int32, System.String>::Dispose(v633);\n\tv570 = v610 + 1;\n\tv635 = v570 == 0;\n\tif (v635) goto L_00DF;\n\tv541 = *([v55 @ X23_v1+v610 @ X24_v10*4]) != 0xB1;\n\tif (v541) goto L_00DF;\n\tv572 = 0xFFFFFFFF ^ v610;\n\tv610 = v610 + v572;\n\tgoto L_0089;\nL_00DF:\n\tv571 = v285 == 0;\n\tif (v571) goto L_0089;\n\tthrow System.TypeLoadException;\nL_00E5:\n\tv283 = v610 + 1;\n\t*([v55 @ X23_v1+v283 @ X24_v2*4]) = 0xCA;\n\tgoto L_0100;\n\tthrow System.NullReferenceException;\n\tv190 = new System.NullReferenceException();\nL_00EC:\n\tgoto L_00F9;\n\tgoto L_00F9;\n\tgoto L_00F9;\n\tgoto L_00F9;\nL_00F9:\n\tv235 = v217 != 1;\n\tif (v235) goto L_0199;\n\tv240 = System.Action`1<System.String>::.ctor(v219, v217, v211);\n\tv285 = *([v240 @ X0_v41 (System.Action`1<System.String>)]);\n\tv248 = System.Action`1<System.String>::.ctor(v240, v217, v211);\nL_0100:\n\tv298 = &v21 @ X29 - 0x70;\n\tv300 = System.Collections.Generic.HashSet`1<System.String>+Enumerator<System.String>::Dispose(v298);\n\tv363 = v283 + 1;\n\tv365 = v363 == 0;\n\tif (v365) goto L_011A;\n\tv368 = v285 == 0;\n\tif (v368) goto L_0123;\n\tv404 = *([v55 @ X23_v1+v283 @ X24_v2*4]) == 0xCA;\n\tif (v404) goto L_0123;\nL_0119:\n\tthrow System.TypeLoadException;\nL_011A:\n\tv395 = v285 == 0;\n\tv396 = ~v395;\n\tif (v396) goto L_0119;\nL_0123:\n\tgoto L_012B;\n\tv428 = *([v416 @ X0_v12 (Il2CppClass<EasyMobile.ConsentDialog+<>c>)+E0]);\n\tv429 = v428 == 0;\n\tv430 = ~v429;\n\tif (v430) goto L_012B;\n\tv440 = \"il2cpp_codegen_runtime_class_init\"(v416, v410, v409, v276, v39, v40, v41, v42, v271, v269, v45, v46, v47, v48, v49, v50);\n\tv432 = EasyMobile.ConsentDialog+<>c;\nL_012B:\n\tv458 = v435.<>9__65_2;\n\tv437 = v435.<>9__65_2 == 0;\n\tv438 = ~v437;\n\tif (v438) goto L_0150;\n\tgoto L_013E;\n\tv468 = *([v431 @ X0_v13 (Il2CppClass<EasyMobile.ConsentDialog+<>c>)+E0]);\n\tv469 = v468 == 0;\n\tv470 = ~v469;\n\tif (v470) goto L_013E;\n\tv473 = \"il2cpp_codegen_runtime_class_init\"(v431, v410, v409, v276, v39, v40, v41, v42, v271, v269, v45, v46, v47, v48, v49, v50);\n\tv513 = EasyMobile.ConsentDialog+<>c;\n\tv475 = *([v513 @ X8_v43+B8]);\nL_013E:\n\tv455 = new System.Func`2<System.Collections.Generic.KeyValuePair`2<System.Int32, System.String>, System.Int32>();\n\tSystem.Func`2<System.Collections.Generic.KeyValuePair`2<System.Int32, System.String>, System.Int32>::.ctor(v455, v474.<>9, Il2CppMethodInfo);\n\tv461.<>9__65_2 = v455;\nL_0150:\n\tv467 = System.Linq.Enumerable::OrderBy(v427, v458);\n\tgoto L_015F;\n\tv492 = *([v479 @ X8_v20 (Il2CppClass<EasyMobile.ConsentDialog+<>c>)+E0]);\n\tv493 = v492 == 0;\n\tv494 = ~v493;\n\tgoto L_015F;\n\tv515 = v479;\n\tv497 = \"il2cpp_codegen_runtime_class_init\"(v515, v465, v466, v446, v39, v40, v41, v42, v271, v269, v45, v46, v47, v48, v49, v50);\n\tv500 = EasyMobile.ConsentDialog+<>c;\nL_015F:\n\tv532 = v501.<>9__65_3;\n\tv503 = v501.<>9__65_3 == 0;\n\tv504 = ~v503;\n\tif (v504) goto L_0185;\n\tgoto L_0173;\n\tv577 = *([v499 @ X8_v21 (Il2CppClass<EasyMobile.ConsentDialog+<>c>)+E0]);\n\tv578 = v577 == 0;\n\tv579 = ~v578;\n\tif (v579) goto L_0173;\n\tv592 = v499;\n\tv583 = \"il2cpp_codegen_runtime_class_init\"(v592, v465, v466, v446, v39, v40, v41, v42, v271, v269, v45, v46, v47, v48, v49, v50);\n\tv585 = EasyMobile.ConsentDialog+<>c;\n\tv581 = *([v585 @ X8_v34+B8]);\nL_0173:\n\tv529 = new System.Func`2<System.Collections.Generic.KeyValuePair`2<System.Int32, System.String>, System.String>();\n\tSystem.Func`2<System.Collections.Generic.KeyValuePair`2<System.Int32, System.String>, System.String>::.ctor(v529, v580.<>9, Il2CppMethodInfo);\n\tv535.<>9__65_3 = v529;\nL_0185:\n\tv540 = System.Linq.Enumerable::Select(v467, v532);\n\treturnVal2 = System.Linq.Enumerable::ToList(v540);\n\treturn returnVal2;\nL_0199:\n\treturnVal1 = System.Action`1<System.String>::.ctor(v219, v217, v211);\n\treturn returnVal1;\n// 251 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe List<string> GetAllPatternsInContent()
		{
			//IL_00e1: Expected O, but got I8
			//IL_00e6: Expected I, but got O
			//IL_040d: Expected O, but got I
			//IL_0282: Expected O, but got I
			//IL_02ce: Expected O, but got I
			//IL_02e6: Expected O, but got I
			//IL_0106: Expected O, but got I
			//IL_0106: Expected O, but got I4
			//IL_03d4: Expected O, but got I
			//IL_019b: Expected O, but got I
			//IL_01c3: Expected O, but got I
			//IL_01db: Expected O, but got I
			//IL_025a: Expected I, but got O
			//IL_0186: Expected O, but got I
			//IL_026d: Expected I, but got O
			//IL_0233: Expected I4, but got I8
			//IL_0241: Expected O, but got I
			//IL_02ba: Expected I, but got O
			object obj = obj;
			object obj3 = default(object);
			object obj2 = obj3;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			HashSet<string> hashSet = new HashSet<string>();
			HashSet<string> allPatterns = hashSet;
			List<string> list = SearchPatternInContent("</EM_CONSENT_BUTTON. Id = (.*?)>");
			Action<string> action = delegate(string pattern)
			{
				bool flag3 = allPatterns.Add(pattern);
			};
			list.ForEach(action);
			List<string> list2 = SearchPatternInContent("</EM_CONSENT_TOGGLE. Id = (.*?)>");
			Action<string> action2 = delegate(string pattern)
			{
				bool flag3 = allPatterns.Add(pattern);
			};
			list2.ForEach(action2);
			Dictionary<int, string> dictionary = new Dictionary<int, string>();
			HashSet<string>.Enumerator enumerator = allPatterns.GetEnumerator();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-B8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-C8]");
			_ = 0;
			object obj4 = 4294967295L;
			IntPtr intPtr = (IntPtr)null;
			object obj6 = default(object);
			IntPtr intPtr3 = default(IntPtr);
			Action<string> action3 = default(Action<string>);
			while (true)
			{
				HashSet<string>.Enumerator enumerator2 = (HashSet<string>.Enumerator)((long)(IntPtr)obj - 112L);
				bool flag = ((HashSet<string>.Enumerator*)enumerator2)->MoveNext();
				if (flag)
				{
					string content = Content;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
					Dictionary<int, string> dictionary2 = ((ConsentDialog)flag).IndexesOf(content, (string)0);
					Dictionary<int, string>.Enumerator enumerator3 = dictionary2.GetEnumerator();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-A8]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-C8]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-B8]");
					_ = 0;
					while (true)
					{
						Dictionary<int, string>.Enumerator enumerator4 = (Dictionary<int, string>.Enumerator)((long)(IntPtr)obj - 160L);
						if (!((Dictionary<int, string>.Enumerator*)enumerator4)->MoveNext())
						{
							break;
						}
						if (dictionary != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-90]");
							IntPtr intPtr2 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-88]");
							dictionary.Add((int)(long)intPtr2, (string)0);
							continue;
						}
						goto IL_01a6;
					}
					obj4 = (long)(IntPtr)obj4 + 1L;
					_ = 177;
					Dictionary<int, string>.Enumerator enumerator5 = (Dictionary<int, string>.Enumerator)((long)(IntPtr)obj - 160L);
					((Dictionary<int, string>.Enumerator*)enumerator5)->Dispose();
					object obj5 = (long)(IntPtr)obj4 + 1L;
					if (obj5 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X23_v1+v610 @ X24_v10*4]");
						if ((IntPtr)0 == (IntPtr)177)
						{
							int num = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj4);
							obj4 = (long)(IntPtr)obj4 + (long)num;
							continue;
						}
					}
					bool flag2 = intPtr == (IntPtr)0;
					intPtr = (IntPtr)null;
					if (!flag2)
					{
						intPtr = (IntPtr)null;
						throw new TypeLoadException();
					}
					continue;
				}
				obj6 = (long)(IntPtr)obj4 + 1L;
				_ = 202;
				goto IL_02bf;
				IL_0345:
				throw new TypeLoadException();
				IL_02bf:
				HashSet<string>.Enumerator enumerator6 = (HashSet<string>.Enumerator)((long)(IntPtr)obj - 112L);
				((HashSet<string>.Enumerator*)enumerator6)->Dispose();
				object obj7 = (long)(IntPtr)obj6 + 1L;
				if (obj7 != null)
				{
					if (intPtr != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X23_v1+v283 @ X24_v2*4]");
						if ((IntPtr)0 != (IntPtr)202)
						{
							goto IL_0345;
						}
					}
				}
				else if (intPtr != (IntPtr)0)
				{
					goto IL_0345;
				}
				Func<KeyValuePair<int, string>, int> keySelector = _003C_003Ec._003C_003E9__65_2;
				if (_003C_003Ec._003C_003E9__65_2 == null)
				{
					keySelector = (_003C_003Ec._003C_003E9__65_2 = delegate(KeyValuePair<int, string> item)
					{
						//IL_000a: Expected I4, but got O
						return (int)item;
					});
				}
				IOrderedEnumerable<KeyValuePair<int, string>> source = dictionary.OrderBy(keySelector);
				Func<KeyValuePair<int, string>, string> selector = _003C_003Ec._003C_003E9__65_3;
				if (_003C_003Ec._003C_003E9__65_3 == null)
				{
					selector = (_003C_003Ec._003C_003E9__65_3 = delegate
					{
						//IL_000a: Expected O, but got I
						IntPtr intPtr4 = default(IntPtr);
						return (string)(long)intPtr4;
					});
				}
				IEnumerable<string> source2 = source.Select(selector);
				return source2.ToList();
				IL_01a6:
				NullReferenceException ex = new NullReferenceException();
				if (intPtr3 != (IntPtr)1)
				{
					break;
				}
				intPtr = (IntPtr)action3;
				goto IL_02bf;
			}
			List<string> result = default(List<string>);
			return result;
		}

		[Token(Token = "0x60005D3")]
		[Address(RVA = "0xA524E4", Offset = "0xA524E4", Length = "0x2F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EE4188]);\n\tv29 = *([v28 @ X8_v39]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, source, value, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([2021F7D]) = v47;\nL_001B:\n\tv51 = new System.Collections.Generic.Dictionary`2<System.Int32, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.String>::.ctor(v51);\n\tgoto L_002F;\n\tv62 = *([v58 @ X0_v4+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tgoto L_002F;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v58, v55, value, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_002F:\n\tv71 = System.Text.RegularExpressions.Regex::Escape(value);\n\tv75 = System.Text.RegularExpressions.Regex::Matches(source, v71);\n\tv78 = System.Text.RegularExpressions.MatchCollection::GetEnumerator(v75);\n\tv144 = v78 == 0;\n\tif (v144) goto L_00D0;\nL_0045:\n\tgoto L_006C;\n\tv227 = *([v213 @ X8_v21+B0]);\n\tv228 = 0;\n\tv229 = v227 + 8;\n\tv231 = *([v320 @ X11_v23-8]);\n\tv325 = v231 == v214;\n\tif (v325) goto L_0065;\n\tv251 = v319 + 1;\n\tv332 = v251 < v215;\n\tv249 = ~v332;\n\tv253 = v320 + 0x10;\n\tv233 = ~v249;\n\tif (v233) goto L_FFFFFFFF;\n\tv254 = v138;\n\tv255 = 0;\n\tv256 = 0x8909C4(v254, v214, v255, v83, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_006C;\nL_0065:\n\tv333 = *([v320 @ X11_v23]);\n\tv334 = v333 << 4;\n\tv335 = v213 + v334;\n\tv336 = v335 + 0x130;\nL_006C:\n\tv357 = System.Collections.IEnumerator::MoveNext(v78);\n\tv359 = v357 == 0;\n\tif (v359) goto L_FFFFFFFF;\n\tv401 = *([v78 @ X0_v31 (System.Collections.IEnumerator)]);\n\tv404 = *([v401 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v404) goto L_0092;\n\tv474 = *([v401 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_007D:\n\tv479 = *([v474 @ X11_v18-8]) == System.Collections.IEnumerator;\n\tif (v479) goto L_0095;\n\tv473 = v473 + 1;\n\tv514 = v473 < *([v401 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv454 = ~v514;\n\tv474 = v474 + 0x10;\n\tv438 = ~v454;\n\tif (v438) goto L_007D;\nL_0092:\n\tv533 = 0x8909C4(v78, System.Collections.IEnumerator, 1, Il2CppMethodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_009C;\nL_0095:\n\tv516 = *([v474 @ X11_v18]) + 1;\n\tv517 = v516 << 4;\n\tv518 = v401 + v517;\n\tv533 = v518 + 0x130;\nL_009C:\n\t*([v533 @ X0_v36])(v538, v78, *([v533 @ X0_v36+8]), v532, Il2CppMethodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_FFFFFFFF;\n\tv181 = v181_asT == 0;\n\tif (v181) goto L_00CB;\n\tv638 = System.Text.RegularExpressions.Capture::get_Value(v538);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.String>::Add(v51, v538._index, v638);\n\tgoto L_0045;\n\tgoto L_00EB;\nL_00CB:\n\tv607 = new System.InvalidCastException();\n\tthrow System.NullReferenceException;\n\tv134 = new System.NullReferenceException();\n\tv143 = new System.NullReferenceException();\nL_00D0:\n\tv170 = new System.NullReferenceException();\n\tgoto L_00E1;\n\tgoto L_00E1;\n\tgoto L_00E1;\n\tgoto L_00E1;\n\tgoto L_00E1;\n\tgoto L_00E1;\n\tgoto L_00E1;\nL_00E1:\n\tv226 = 0 != 1;\n\tif (v226) goto L_0134;\n\tv257 = 0x6D2BC0(v170, 0, 0, v261, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv305 = *([v257 @ X0_v27]);\n\tv331 = 0x6D2490(v257, 0, 0, v261, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00EB:\n\t// 235 IsInst v431 @ X0_v12 (System.IDisposable), typeof(System.IDisposable), v426 @ X20_v2 (System.Collections.IEnumerator)\n\tv462 = v431 == 0;\n\tif (v462) goto L_011B;\n\tgoto L_011A;\n\tv540 = *([v484 @ X8_v13+B0]);\n\tv541 = 0;\n\tv542 = v540 + 8;\n\tv544 = *([v622 @ X11_v7-8]);\n\tv627 = v544 == v485;\n\tif (v627) goto L_0113;\n\tv564 = v621 + 1;\n\tv640 = v564 < v486;\n\tv562 = ~v640;\n\tv566 = v622 + 0x10;\n\tv546 = ~v562;\n\tif (v546) goto L_FFFFFFFF;\n\tv567 = v303;\n\tv568 = 0;\n\tv569 = 0x8909C4(v567, v485, v568, v261, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_011A;\nL_0113:\n\tv641 = *([v622 @ X11_v7]);\n\tv642 = v641 << 4;\n\tv643 = v484 + v642;\n\tv644 = v643 + 0x130;\nL_011A:\n\tSystem.IDisposable::Dispose(v431);\nL_011B:\n\tv513 = v293 + 1;\n\tv277 = v513 == 0;\n\tv267 = ~v277;\n\tif (v267) goto L_012F;\n\tv570 = v305 == 0;\n\tv301 = ~v570;\n\tif (v301) goto L_0133;\nL_012F:\n\treturn v51;\nL_0133:\n\tv299 = new System.TypeLoadException();\nL_0134:\n\treturnVal1 = 0x6D2380(v170, v296, v294, Il2CppMethodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn returnVal1;\n// 188 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Dictionary<int, string> IndexesOf(string source, string value)
		{
			//IL_024e: Expected I4, but got O
			//IL_0074: Expected I, but got O
			//IL_00af: Expected O, but got I
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Expected O, but got Unknown
			//IL_015c: Expected O, but got I
			//IL_016b: Expected O, but got I
			//IL_00fb: Expected O, but got I
			Dictionary<int, string> dictionary = new Dictionary<int, string>();
			string pattern = Regex.Escape(value);
			MatchCollection matchCollection = Regex.Matches(source, pattern);
			IEnumerator enumerator = matchCollection.GetEnumerator();
			bool flag = enumerator == null;
			int num = 0;
			int num2 = 0;
			IEnumerator enumerator2 = enumerator;
			int num3;
			int num4;
			NullReferenceException ex;
			if (flag)
			{
				ex = new NullReferenceException();
				if (0 != 1)
				{
					goto IL_02ca;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj = default(object);
				num3 = (int)obj;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				num4 = -1;
			}
			else
			{
				Capture capture = default(Capture);
				while (enumerator.MoveNext())
				{
					IntPtr intPtr = (IntPtr)enumerator;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0114;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
					object obj2 = 0L + 8L;
					int num5 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ X11_v18-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
						{
							break;
						}
						num5++;
						int num6 = num5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]");
						bool flag2 = (long)num6 < 0L;
						bool flag3 = !flag2;
						obj2 = (long)(IntPtr)obj2 + 16L;
						if (!flag3)
						{
							continue;
						}
						goto IL_0114;
					}
					object obj3 = obj2 + 1;
					int num7 = (int)((long)(IntPtr)obj3 << 4);
					object obj4 = (long)intPtr + (long)num7;
					object obj5 = (long)(IntPtr)obj4 + 304L;
					int num8 = 0;
					goto IL_0341;
					IL_0114:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
					num8 = 1;
					goto IL_0341;
					IL_0341:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v533 @ X0_v36] (should have been resolved before IL gen)");
					Match match = capture as Match;
					if (match != null)
					{
						string value2 = capture.Value;
						dictionary.Add(capture.Index, value2);
						continue;
					}
					InvalidCastException ex2 = new InvalidCastException();
					throw new NullReferenceException();
				}
				num4 = 0;
				enumerator2 = enumerator;
				num3 = 0;
			}
			(enumerator2 as IDisposable)?.Dispose();
			if (num4 + 1 != 0 || num3 == 0)
			{
				return dictionary;
			}
			TypeLoadException ex3 = new TypeLoadException();
			num = 0;
			num2 = 0;
			ex = (NullReferenceException)(object)ex3;
			goto IL_02ca;
			IL_02ca:
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			Dictionary<int, string> result = default(Dictionary<int, string>);
			return result;
		}

		[Token(Token = "0x60005D4")]
		[Address(RVA = "0xA521E4", Offset = "0xA521E4", Length = "0x300")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1F06A98]);\n\tv27 = *([v26 @ X8_v39]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, regexPattern, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2021F7E]) = v45;\nL_001A:\n\tv49 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v49);\n\tv56 = System.String::IsNullOrEmpty(this.mContent);\n\tv58 = v56 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_0130;\n\tv63 = new System.Text.RegularExpressions.Regex();\n\tSystem.Text.RegularExpressions.Regex::.ctor(v63, regexPattern);\n\tv189 = System.Text.RegularExpressions.Regex::Matches(v63, this.mContent);\n\tv263 = System.Text.RegularExpressions.MatchCollection::GetEnumerator(v189);\n\tv284 = v263 == 0;\n\tif (v284) goto L_00D2;\nL_0046:\n\tgoto L_006D;\n\tv347 = *([v338 @ X8_v21+B0]);\n\tv348 = 0;\n\tv349 = v347 + 8;\n\tv351 = *([v390 @ X11_v25-8]);\n\tv395 = v351 == v339;\n\tif (v395) goto L_0066;\n\tv371 = v389 + 1;\n\tv401 = v371 < v340;\n\tv369 = ~v401;\n\tv373 = v390 + 0x10;\n\tv353 = ~v369;\n\tif (v353) goto L_FFFFFFFF;\n\tv374 = v231;\n\tv375 = 0;\n\tv376 = 0x8909C4(v374, v339, v375, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_006D;\nL_0066:\n\tv402 = *([v390 @ X11_v25]);\n\tv403 = v402 << 4;\n\tv404 = v338 + v403;\n\tv405 = v404 + 0x130;\nL_006D:\n\tv426 = System.Collections.IEnumerator::MoveNext(v263);\n\tv428 = v426 == 0;\n\tif (v428) goto L_FFFFFFFF;\n\tv456 = *([v263 @ X0_v34 (System.Collections.IEnumerator)]);\n\tv459 = *([v456 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v459) goto L_0093;\n\tv530 = *([v456 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_007E:\n\tv535 = *([v530 @ X11_v20-8]) == System.Collections.IEnumerator;\n\tif (v535) goto L_0096;\n\tv529 = v529 + 1;\n\tv571 = v529 < *([v456 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv483 = ~v571;\n\tv530 = v530 + 0x10;\n\tv467 = ~v483;\n\tif (v467) goto L_007E;\nL_0093:\n\tv589 = 0x8909C4(v263, System.Collections.IEnumerator, 1, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_009D;\nL_0096:\n\tv573 = *([v530 @ X11_v20]) + 1;\n\tv574 = v573 << 4;\n\tv575 = v456 + v574;\n\tv589 = v575 + 0x130;\nL_009D:\n\t*([v589 @ X0_v39])(v594, v263, *([v589 @ X0_v39+8]), v223, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_FFFFFFFF;\n\tv308 = v308_asT == 0;\n\tif (v308) goto L_00CC;\n\tv337 = *([v594 @ X0_v41]);\n\t*([v337 @ X8_v34+160])(v672, v594, *([v337 @ X8_v34+168]), v223, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tSystem.Collections.Generic.List`1<System.String>::Add(v49, v672);\n\tgoto L_0046;\n\tgoto L_00ED;\nL_00CC:\n\tv655 = new System.InvalidCastException();\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv261 = new System.NullReferenceException();\nL_00D2:\n\tv288 = new System.NullReferenceException();\n\tgoto L_00E3;\n\tgoto L_00E3;\n\tgoto L_00E3;\n\tgoto L_00E3;\n\tgoto L_00E3;\n\tgoto L_00E3;\n\tgoto L_00E3;\nL_00E3:\n\tv301 = 0 != 1;\n\tif (v301) goto L_0135;\n\tv342 = 0x6D2BC0(v288, 0, 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv122 = *([v342 @ X0_v28]);\n\tv378 = 0x6D2490(v342, 0, 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_00ED:\n\t// 237 IsInst v455 @ X0_v12 (System.IDisposable), typeof(System.IDisposable), v449 @ X20_v4 (System.Collections.IEnumerator)\n\tv460 = v455 == 0;\n\tif (v460) goto L_011D;\n\tgoto L_011C;\n\tv540 = *([v491 @ X8_v12+B0]);\n\tv541 = 0;\n\tv542 = v540 + 8;\n\tv544 = *([v607 @ X11_v8-8]);\n\tv612 = v544 == v492;\n\tif (v612) goto L_0115;\n\tv564 = v606 + 1;\n\tv659 = v564 < v493;\n\tv562 = ~v659;\n\tv566 = v607 + 0x10;\n\tv546 = ~v562;\n\tif (v546) goto L_FFFFFFFF;\n\tv567 = v120;\n\tv568 = 0;\n\tv569 = 0x8909C4(v567, v492, v568, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_011C;\nL_0115:\n\tv660 = *([v607 @ X11_v8]);\n\tv661 = v660 << 4;\n\tv662 = v491 + v661;\n\tv663 = v662 + 0x130;\nL_011C:\n\tSystem.IDisposable::Dispose(v455);\nL_011D:\n\tv118 = v109 + 1;\n\tv89 = v118 == 0;\n\tv74 = ~v89;\n\tif (v74) goto L_0130;\n\tv570 = v122 == 0;\n\tv117 = ~v570;\n\tif (v117) goto L_0134;\nL_0130:\n\treturn v49;\nL_0134:\n\tv346 = new System.TypeLoadException();\nL_0135:\n\treturnVal2 = 0x6D2380(v288, v172, v170, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn returnVal2;\n// 189 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private List<string> SearchPatternInContent(string regexPattern)
		{
			//IL_0276: Expected I4, but got O
			//IL_00a0: Expected I, but got O
			//IL_00db: Expected O, but got I
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Expected O, but got Unknown
			//IL_0188: Expected O, but got I
			//IL_0197: Expected O, but got I
			//IL_0127: Expected O, but got I
			List<string> list = new List<string>();
			if (!string.IsNullOrEmpty(Content))
			{
				Regex regex = new Regex(regexPattern);
				MatchCollection matchCollection = regex.Matches(Content);
				IEnumerator enumerator = matchCollection.GetEnumerator();
				bool flag = enumerator == null;
				int num = 0;
				string text = null;
				IEnumerator enumerator2 = enumerator;
				int num2;
				int num3;
				if (flag)
				{
					NullReferenceException ex = new NullReferenceException();
					if (0 != 1)
					{
						goto IL_02ee;
					}
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
					object obj = default(object);
					num2 = (int)obj;
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					num3 = -1;
				}
				else
				{
					object obj6 = default(object);
					string item = default(string);
					while (enumerator.MoveNext())
					{
						IntPtr intPtr = (IntPtr)enumerator;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_0140;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
						object obj2 = 0L + 8L;
						int num4 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ X11_v20-8]");
							if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
							{
								break;
							}
							num4++;
							int num5 = num4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]");
							bool flag2 = (long)num5 < 0L;
							bool flag3 = !flag2;
							obj2 = (long)(IntPtr)obj2 + 16L;
							if (!flag3)
							{
								continue;
							}
							goto IL_0140;
						}
						object obj3 = obj2 + 1;
						int num6 = (int)((long)(IntPtr)obj3 << 4);
						object obj4 = (long)intPtr + (long)num6;
						object obj5 = (long)(IntPtr)obj4 + 304L;
						int num7 = 0;
						goto IL_0374;
						IL_0140:
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
						num7 = 1;
						goto IL_0374;
						IL_0374:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v589 @ X0_v39] (should have been resolved before IL gen)");
						Match match = obj6 as Match;
						if (match != null)
						{
							object obj7 = obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v337 @ X8_v34+160] (should have been resolved before IL gen)");
							list.Add(item);
							continue;
						}
						InvalidCastException ex2 = new InvalidCastException();
						throw new NullReferenceException();
					}
					num3 = 0;
					enumerator2 = enumerator;
					num2 = 0;
				}
				(enumerator2 as IDisposable)?.Dispose();
				if (num3 + 1 == 0 && num2 != 0)
				{
					TypeLoadException ex3 = new TypeLoadException();
					num = 0;
					text = null;
					NullReferenceException ex = (NullReferenceException)(object)ex3;
					goto IL_02ee;
				}
			}
			return list;
			IL_02ee:
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			List<string> result = default(List<string>);
			return result;
		}

		[Token(Token = "0x60005D5")]
		[Address(RVA = "0xA527DC", Offset = "0xA527DC", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = EasyMobile.ConsentDialog::FindToggleWithId(this, toggleId);\n\tv20 = v19 == 0;\n\tif (v20) goto L_0011;\n\tv21 = isOn & 1;\n\tv19.isOn = v21;\nL_0011:\n\tv25 = this.ToggleStateUpdated == 0;\n\tif (v25) goto L_0024;\n\tv32 = isOn & 1;\n\tEasyMobile.ConsentDialog+ToggleStateUpdatedHandler::Invoke(this.ToggleStateUpdated, this, toggleId, v32);\n\treturn;\nL_0024:\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnNativeToggleStateUpdated(IPlatformConsentDialog platformDialog, string toggleId, bool isOn)
		{
			Toggle toggle = FindToggleWithId(toggleId);
			if (toggle != null)
			{
				int isOn2 = (int)((long)(isOn ? 1 : 0) & 1L);
				toggle.isOn = (byte)isOn2 != 0;
			}
			if (this.ToggleStateUpdated != null)
			{
				bool isOn3 = (byte)((ulong)(isOn ? 1 : 0) & 1uL) != 0;
				this.ToggleStateUpdated(this, toggleId, isOn3);
			}
		}

		[Token(Token = "0x60005D6")]
		[Address(RVA = "0xA52C48", Offset = "0xA52C48", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EA6FE0]);\n\tv27 = *([v26 @ X8_v6]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, platformDialog, buttonId, toggles, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021F7F]) = v44;\nL_001A:\n\tv48 = new EasyMobile.ConsentDialog+CompletedResults();\n\tSystem.Object::.ctor(v48);\n\tv48.buttonId = buttonId;\n\tv48.toggleValues = toggles;\n\tv53 = this.Completed == 0;\n\tif (v53) goto L_0030;\n\tEasyMobile.ConsentDialog+CompletedHandler::Invoke(this.Completed, this, v48);\nL_0030:\n\tEasyMobile.ConsentDialog::ResignAsActiveDialog(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnNativeDialogCompleted(IPlatformConsentDialog platformDialog, string buttonId, Dictionary<string, bool> toggles)
		{
			CompletedResults completedResults = new CompletedResults();
			completedResults.buttonId = buttonId;
			completedResults.toggleValues = toggles;
			if (this.Completed != null)
			{
				this.Completed(this, completedResults);
			}
			ResignAsActiveDialog();
		}

		[Token(Token = "0x60005D7")]
		[Address(RVA = "0xA533F8", Offset = "0xA533F8", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F03B88]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, platformDialog, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F80]) = v38;\nL_0014:\n\tv40 = this.Dismissed == 0;\n\tif (v40) goto L_0021;\n\tSystem.Action`1<EasyMobile.ConsentDialog>::Invoke(this.Dismissed, this);\nL_0021:\n\tEasyMobile.ConsentDialog::ResignAsActiveDialog(this);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnNativeDialogDismissed(IPlatformConsentDialog platformDialog)
		{
			if (this.Dismissed != null)
			{
				this.Dismissed(this);
			}
			ResignAsActiveDialog();
		}

		[Token(Token = "0x60005D8")]
		[Address(RVA = "0xA508C4", Offset = "0xA508C4", Length = "0x330")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EB2A40]);\n\tv23 = *([v22 @ X8_v57]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021F81]) = v42;\nL_001B:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0025:\n\tgoto L_0030;\n\tv61 = *([1EE7878]);\n\tv62 = *([v61 @ X8_v53]);\n\tv63 = \"il2cpp_codegen_initialize_method\"(v62, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv66 = 0 | 1;\n\t*([2021FDF]) = v66;\nL_0030:\n\tgoto L_003D;\n\tv71 = *([v67 @ X0_v5 (Il2CppClass<EasyMobile.ConsentDialog>)+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tgoto L_003D;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v67, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv75 = EasyMobile.ConsentDialog;\nL_003D:\n\tv84 = v78.<ActiveDialog>k__BackingField == this;\n\tif (v84) goto L_00A3;\n\tgoto L_0050;\n\tv99 = *([v74 @ X0_v6 (Il2CppClass<EasyMobile.ConsentDialog>)+E0]);\n\tv100 = v99 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_0050;\n\tv103 = \"il2cpp_codegen_runtime_class_init\"(v74, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0050:\n\tgoto L_005B;\n\tv192 = *([1F0C108]);\n\tv193 = *([v192 @ X8_v47]);\n\tv194 = \"il2cpp_codegen_initialize_method\"(v193, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv197 = 0 | 1;\n\t*([2021FE0]) = v197;\nL_005B:\n\tgoto L_0063;\n\tv202 = *([v198 @ X0_v9 (Il2CppClass<EasyMobile.ConsentDialog>)+E0]);\n\tv203 = v202 == 0;\n\tv204 = ~v203;\n\tgoto L_0063;\n\tv211 = \"il2cpp_codegen_runtime_class_init\"(v198, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv206 = EasyMobile.ConsentDialog;\nL_0063:\n\tv209.<ActiveDialog>k__BackingField = this;\n\tv210 = EasyMobile.ConsentDialog::get_PlatformDialog();\n\tv217 = new System.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Boolean>();\n\tSystem.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Boolean>::.ctor(v217, this, Il2CppMethodInfo);\n\tgoto L_00AC;\n\tv279 = *([v228 @ X8_v24+B0]);\n\tv280 = 0;\n\tv281 = v279 + 8;\n\tv283 = *([v320 @ X11_v18-8]);\n\tv325 = v283 == v231;\n\tif (v325) goto L_00A4;\n\tv303 = v319 + 1;\n\tv330 = v303 < v230;\n\tv301 = ~v330;\n\tv305 = v320 + 0x10;\n\tv285 = ~v301;\n\tif (v285) goto L_FFFFFFFF;\n\tv306 = v214;\n\tv307 = 0;\n\tv308 = 0x8909C4(v306, v231, v307, v225, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00AC;\nL_00A3:\n\treturn;\nL_00A4:\n\tv331 = *([v320 @ X11_v18]);\n\tv332 = v331 << 4;\n\tv333 = v228 + v332;\n\tv334 = v333 + 0x130;\nL_00AC:\n\tEasyMobile.Internal.Privacy.IPlatformConsentDialog::add_ToggleStateUpdated(v210, v217);\n\tv344 = EasyMobile.ConsentDialog::get_PlatformDialog();\n\tv270 = new System.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Collections.Generic.Dictionary`2<System.String, System.Boolean>>();\n\tSystem.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Collections.Generic.Dictionary`2<System.String, System.Boolean>>::.ctor(v270, this, Il2CppMethodInfo);\n\tv351 = *([v344 @ X0_v20 (EasyMobile.Internal.Privacy.IPlatformConsentDialog)]);\n\tv354 = *([v351 @ X8_v32 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+126]) == 0;\n\tif (v354) goto L_00E1;\n\tv396 = *([v351 @ X8_v32 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+B0]) + 8;\nL_00CC:\n\tv401 = *([v396 @ X11_v13-8]) == EasyMobile.Internal.Privacy.IPlatformConsentDialog;\n\tif (v401) goto L_00E4;\n\tv395 = v395 + 1;\n\tv406 = v395 < *([v351 @ X8_v32 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+126]);\n\tv377 = ~v406;\n\tv396 = v396 + 0x10;\n\tv361 = ~v377;\n\tif (v361) goto L_00CC;\nL_00E1:\n\tv414 = System.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Collections.Generic.Dictionary`2<System.String, System.Boolean>>::.ctor(v344, EasyMobile.Internal.Privacy.IPlatformConsentDialog, 2);\n\tgoto L_00EC;\nL_00E4:\n\tv408 = *([v396 @ X11_v13]) + 2;\n\tv409 = v408 << 4;\n\tv410 = v351 + v409;\n\tv414 = v410 + 0x130;\nL_00EC:\n\t*([v414 @ X0_v23 (System.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Collections.Generic.Dictionary`2<System.String, System.Boolean>>)])(v420, v344, v270, *([v414 @ X0_v23 (System.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Collections.Generic.Dictionary`2<System.String, System.Boolean>>)+8]), Il2CppMethodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv421 = EasyMobile.ConsentDialog::get_PlatformDialog();\n\tv271 = new System.Action`1<EasyMobile.Internal.Privacy.IPlatformConsentDialog>();\n\tSystem.Action`1<EasyMobile.Internal.Privacy.IPlatformConsentDialog>::.ctor(v271, this, Il2CppMethodInfo);\n\tv428 = *([v421 @ X0_v26 (EasyMobile.Internal.Privacy.IPlatformConsentDialog)]);\n\tv179 = *([v428 @ X8_v40 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+126]) == 0;\n\tif (v179) goto L_0121;\n\tv472 = *([v428 @ X8_v40 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+B0]) + 8;\nL_010C:\n\tv477 = *([v472 @ X11_v8-8]) == EasyMobile.Internal.Privacy.IPlatformConsentDialog;\n\tif (v477) goto L_0124;\n\tv471 = v471 + 1;\n\tv482 = v471 < *([v428 @ X8_v40 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+126]);\n\tv453 = ~v482;\n\tv472 = v472 + 0x10;\n\tv437 = ~v453;\n\tif (v437) goto L_010C;\nL_0121:\n\tv489 = System.Action`1<EasyMobile.Internal.Privacy.IPlatformConsentDialog>::.ctor(v421, EasyMobile.Internal.Privacy.IPlatformConsentDialog, 4);\n\tgoto L_0128;\nL_0124:\n\tv484 = *([v472 @ X11_v8]) + 4;\n\tv485 = v484 << 4;\n\tv486 = v428 + v485;\n\tv489 = v486 + 0x130;\nL_0128:\n\tv160 = *([v489 @ X0_v29 (System.Action`1<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)]);\n\tv163 = *([v489 @ X0_v29 (System.Action`1<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+8]);\n\t// 307 IndirectJump v160 @ X3_v5 (Il2CppClass<System.Action`1<EasyMobile.Internal.Privacy.IPlatformConsentDialog>>), v421 @ X0_v26 (EasyMobile.Internal.Privacy.IPlatformConsentDialog), v421 @ X0_v26 (EasyMobile.Internal.Privacy.IPlatformConsentDialog), v271 @ X0_v28 (System.Action`1<EasyMobile.Internal.Privacy.IPlatformConsentDialog>), v163 @ X2_v10, v160 @ X3_v5 (Il2CppClass<System.Action`1<EasyMobile.Internal.Privacy.IPlatformConsentDialog>>), v28 @ X4, v29 @ X5, v30 @ X6, v31 @ X7, v32 @ V0, v33 @ V1, v34 @ V2, v35 @ V3, v36 @ V4, v37 @ V5, v38 @ V6, v39 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 190 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AssignAsActiveDialog()
		{
			//IL_0022: Expected I, but got O
			//IL_005d: Expected O, but got I
			//IL_010e: Expected I, but got O
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Expected O, but got Unknown
			//IL_00f2: Expected O, but got I
			//IL_0101: Expected O, but got I
			//IL_02f1: Expected I, but got O
			//IL_0301: Expected O, but got I
			//IL_0149: Expected O, but got I
			//IL_00a9: Expected O, but got I
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c1: Expected O, but got Unknown
			//IL_01de: Expected O, but got I
			//IL_01ed: Expected O, but got I
			//IL_0195: Expected O, but got I
			if (ActiveDialog == this)
			{
				return;
			}
			ActiveDialog = this;
			IPlatformConsentDialog platformDialog = PlatformDialog;
			Action<IPlatformConsentDialog, string, bool> value = OnNativeToggleStateUpdated;
			platformDialog.ToggleStateUpdated += value;
			IPlatformConsentDialog platformDialog2 = PlatformDialog;
			Action<IPlatformConsentDialog, string, Dictionary<string, bool>> action = OnNativeDialogCompleted;
			IntPtr intPtr = (IntPtr)platformDialog2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ X8_v32 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+126]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ X8_v32 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				bool flag2;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v396 @ X11_v13-8]");
					if ((IntPtr)0 != (IntPtr)typeof(IPlatformConsentDialog))
					{
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ X8_v32 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+126]");
						bool flag = (long)num2 < 0L;
						flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						continue;
					}
					object obj2 = obj + 2;
					int num3 = (int)((long)(IntPtr)obj2 << 4);
					object obj3 = (long)intPtr + (long)num3;
					Action<IPlatformConsentDialog, string, Dictionary<string, bool>> action2 = (Action<IPlatformConsentDialog, string, Dictionary<string, bool>>)((long)(IntPtr)obj3 + 304L);
					break;
				}
				while (!flag2);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v414 @ X0_v23 (System.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Collections.Generic.Dictionary`2<System.String, System.Boolean>>)] (should have been resolved before IL gen)");
			IPlatformConsentDialog platformDialog3 = PlatformDialog;
			Action<IPlatformConsentDialog> action3 = OnNativeDialogDismissed;
			IntPtr intPtr2 = (IntPtr)platformDialog3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ X8_v40 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+126]");
			Action<IPlatformConsentDialog> action4 = default(Action<IPlatformConsentDialog>);
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ X8_v40 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+B0]");
				object obj4 = 0L + 8L;
				int num4 = 0;
				bool flag4;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ X11_v8-8]");
					if ((IntPtr)0 != (IntPtr)typeof(IPlatformConsentDialog))
					{
						num4++;
						int num5 = num4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ X8_v40 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+126]");
						bool flag3 = (long)num5 < 0L;
						flag4 = !flag3;
						obj4 = (long)(IntPtr)obj4 + 16L;
						continue;
					}
					object obj5 = obj4 + 4;
					int num6 = (int)((long)(IntPtr)obj5 << 4);
					object obj6 = (long)intPtr2 + (long)num6;
					action4 = (Action<IPlatformConsentDialog>)((long)(IntPtr)obj6 + 304L);
					break;
				}
				while (!flag4);
			}
			IntPtr intPtr3 = (IntPtr)action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v489 @ X0_v29 (System.Action`1<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+8]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v160 @ X3_v5 (Il2CppClass<System.Action`1<EasyMobile.Internal.Privacy.IPlatformConsentDialog>>) (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60005D9")]
		[Address(RVA = "0xA530C4", Offset = "0xA530C4", Length = "0x334")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EAC470]);\n\tv23 = *([v22 @ X8_v57]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021F82]) = v42;\nL_001B:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0025:\n\tgoto L_0030;\n\tv61 = *([1EE7878]);\n\tv62 = *([v61 @ X8_v53]);\n\tv63 = \"il2cpp_codegen_initialize_method\"(v62, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv66 = 0 | 1;\n\t*([2021FDF]) = v66;\nL_0030:\n\tgoto L_003D;\n\tv71 = *([v67 @ X0_v5 (Il2CppClass<EasyMobile.ConsentDialog>)+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tgoto L_003D;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v67, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv75 = EasyMobile.ConsentDialog;\nL_003D:\n\tv84 = v78.<ActiveDialog>k__BackingField == this;\n\tif (v84) goto L_004E;\n\treturn;\nL_004E:\n\tgoto L_0058;\n\tv180 = *([v74 @ X0_v6 (Il2CppClass<EasyMobile.ConsentDialog>)+E0]);\n\tv181 = v180 == 0;\n\tv182 = ~v181;\n\tif (v182) goto L_0058;\n\tv184 = \"il2cpp_codegen_runtime_class_init\"(v74, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0058:\n\tgoto L_0063;\n\tv192 = *([1F0C108]);\n\tv193 = *([v192 @ X8_v47]);\n\tv194 = \"il2cpp_codegen_initialize_method\"(v193, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv197 = 0 | 1;\n\t*([2021FE0]) = v197;\nL_0063:\n\tgoto L_006B;\n\tv202 = *([v198 @ X0_v9 (Il2CppClass<EasyMobile.ConsentDialog>)+E0]);\n\tv203 = v202 == 0;\n\tv204 = ~v203;\n\tgoto L_006B;\n\tv211 = \"il2cpp_codegen_runtime_class_init\"(v198, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv206 = EasyMobile.ConsentDialog;\nL_006B:\n\tv209.<ActiveDialog>k__BackingField = 0;\n\tv210 = EasyMobile.ConsentDialog::get_PlatformDialog();\n\tv217 = new System.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Boolean>();\n\tSystem.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Boolean>::.ctor(v217, this, Il2CppMethodInfo);\n\tv228 = *([v210 @ X0_v11 (EasyMobile.Internal.Privacy.IPlatformConsentDialog)]);\n\tv232 = *([v228 @ X8_v24 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+126]) == 0;\n\tif (v232) goto L_00A2;\n\tv320 = *([v228 @ X8_v24 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+B0]) + 8;\nL_008D:\n\tv325 = *([v320 @ X11_v18-8]) == EasyMobile.Internal.Privacy.IPlatformConsentDialog;\n\tif (v325) goto L_00A5;\n\tv319 = v319 + 1;\n\tv330 = v319 < *([v228 @ X8_v24 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+126]);\n\tv301 = ~v330;\n\tv320 = v320 + 0x10;\n\tv285 = ~v301;\n\tif (v285) goto L_008D;\nL_00A2:\n\tv338 = System.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Boolean>::.ctor(v210, EasyMobile.Internal.Privacy.IPlatformConsentDialog, 1);\n\tgoto L_00AD;\nL_00A5:\n\tv332 = *([v320 @ X11_v18]) + 1;\n\tv333 = v332 << 4;\n\tv334 = v228 + v333;\n\tv338 = v334 + 0x130;\nL_00AD:\n\t*([v338 @ X0_v17 (System.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Boolean>)])(v344, v210, v217, *([v338 @ X0_v17 (System.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Boolean>)+8]), Il2CppMethodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv345 = EasyMobile.ConsentDialog::get_PlatformDialog();\n\tv270 = new System.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Collections.Generic.Dictionary`2<System.String, System.Boolean>>();\n\tSystem.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Collections.Generic.Dictionary`2<System.String, System.Boolean>>::.ctor(v270, this, Il2CppMethodInfo);\n\tv352 = *([v345 @ X0_v20 (EasyMobile.Internal.Privacy.IPlatformConsentDialog)]);\n\tv355 = *([v352 @ X8_v32 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+126]) == 0;\n\tif (v355) goto L_00E2;\n\tv397 = *([v352 @ X8_v32 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+B0]) + 8;\nL_00CD:\n\tv402 = *([v397 @ X11_v13-8]) == EasyMobile.Internal.Privacy.IPlatformConsentDialog;\n\tif (v402) goto L_00E5;\n\tv396 = v396 + 1;\n\tv407 = v396 < *([v352 @ X8_v32 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+126]);\n\tv378 = ~v407;\n\tv397 = v397 + 0x10;\n\tv362 = ~v378;\n\tif (v362) goto L_00CD;\nL_00E2:\n\tv415 = System.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Collections.Generic.Dictionary`2<System.String, System.Boolean>>::.ctor(v345, EasyMobile.Internal.Privacy.IPlatformConsentDialog, 3);\n\tgoto L_00ED;\nL_00E5:\n\tv409 = *([v397 @ X11_v13]) + 3;\n\tv410 = v409 << 4;\n\tv411 = v352 + v410;\n\tv415 = v411 + 0x130;\nL_00ED:\n\t*([v415 @ X0_v23 (System.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Collections.Generic.Dictionary`2<System.String, System.Boolean>>)])(v421, v345, v270, *([v415 @ X0_v23 (System.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Collections.Generic.Dictionary`2<System.String, System.Boolean>>)+8]), Il2CppMethodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv422 = EasyMobile.ConsentDialog::get_PlatformDialog();\n\tv271 = new System.Action`1<EasyMobile.Internal.Privacy.IPlatformConsentDialog>();\n\tSystem.Action`1<EasyMobile.Internal.Privacy.IPlatformConsentDialog>::.ctor(v271, this, Il2CppMethodInfo);\n\tgoto L_0134;\n\tv432 = *([v429 @ X8_v40+B0]);\n\tv433 = 0;\n\tv434 = v432 + 8;\n\tv436 = *([v473 @ X11_v8-8]);\n\tv478 = v436 == v430;\n\tif (v478) goto L_0124;\n\tv456 = v472 + 1;\n\tv483 = v456 < v431;\n\tv454 = ~v483;\n\tv458 = v473 + 0x10;\n\tv438 = ~v454;\n\tif (v438) goto L_FFFFFFFF;\n\tv459 = 5;\n\tv460 = v277;\n\tv461 = 0x8909C4(v460, v430, v459, v260, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0134;\nL_0124:\n\tv484 = *([v473 @ X11_v8]);\n\tv485 = v484 + 5;\n\tv486 = v485 << 4;\n\tv487 = v429 + v486;\n\tv488 = v487 + 0x130;\nL_0134:\n\tEasyMobile.Internal.Privacy.IPlatformConsentDialog::remove_Dismissed(v422, v271);\n\tthrow System.NullReferenceException;\n\treturn;\n// 192 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ResignAsActiveDialog()
		{
			//IL_001d: Expected I, but got O
			//IL_0058: Expected O, but got I
			//IL_0109: Expected I, but got O
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Expected O, but got Unknown
			//IL_00ed: Expected O, but got I
			//IL_00fc: Expected O, but got I
			//IL_0144: Expected O, but got I
			//IL_00a4: Expected O, but got I
			//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bc: Expected O, but got Unknown
			//IL_01d9: Expected O, but got I
			//IL_01e8: Expected O, but got I
			//IL_0190: Expected O, but got I
			if (ActiveDialog != this)
			{
				return;
			}
			ActiveDialog = null;
			IPlatformConsentDialog platformDialog = PlatformDialog;
			Action<IPlatformConsentDialog, string, bool> action = OnNativeToggleStateUpdated;
			IntPtr intPtr = (IntPtr)platformDialog;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X8_v24 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+126]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X8_v24 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				bool flag2;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ X11_v18-8]");
					if ((IntPtr)0 != (IntPtr)typeof(IPlatformConsentDialog))
					{
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X8_v24 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+126]");
						bool flag = (long)num2 < 0L;
						flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						continue;
					}
					object obj2 = obj + 1;
					int num3 = (int)((long)(IntPtr)obj2 << 4);
					object obj3 = (long)intPtr + (long)num3;
					Action<IPlatformConsentDialog, string, bool> action2 = (Action<IPlatformConsentDialog, string, bool>)((long)(IntPtr)obj3 + 304L);
					break;
				}
				while (!flag2);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v338 @ X0_v17 (System.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Boolean>)] (should have been resolved before IL gen)");
			IPlatformConsentDialog platformDialog2 = PlatformDialog;
			Action<IPlatformConsentDialog, string, Dictionary<string, bool>> action3 = OnNativeDialogCompleted;
			IntPtr intPtr2 = (IntPtr)platformDialog2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ X8_v32 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+126]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ X8_v32 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+B0]");
				object obj4 = 0L + 8L;
				int num4 = 0;
				bool flag4;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ X11_v13-8]");
					if ((IntPtr)0 != (IntPtr)typeof(IPlatformConsentDialog))
					{
						num4++;
						int num5 = num4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ X8_v32 (Il2CppClass<EasyMobile.Internal.Privacy.IPlatformConsentDialog>)+126]");
						bool flag3 = (long)num5 < 0L;
						flag4 = !flag3;
						obj4 = (long)(IntPtr)obj4 + 16L;
						continue;
					}
					object obj5 = obj4 + 3;
					int num6 = (int)((long)(IntPtr)obj5 << 4);
					object obj6 = (long)intPtr2 + (long)num6;
					Action<IPlatformConsentDialog, string, Dictionary<string, bool>> action4 = (Action<IPlatformConsentDialog, string, Dictionary<string, bool>>)((long)(IntPtr)obj6 + 304L);
					break;
				}
				while (!flag4);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v415 @ X0_v23 (System.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Collections.Generic.Dictionary`2<System.String, System.Boolean>>)] (should have been resolved before IL gen)");
			IPlatformConsentDialog platformDialog3 = PlatformDialog;
			Action<IPlatformConsentDialog> value = OnNativeDialogDismissed;
			platformDialog3.Dismissed -= value;
		}
	}
}
