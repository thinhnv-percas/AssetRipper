using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Facebook.Unity
{
	[Token(Token = "0x200004A")]
	public class FBSDKCodelessPathComponent
	{
		[Token(Token = "0x17000058")]
		public string className
		{
			[CompilerGenerated]
			[Token(Token = "0x6000197")]
			[Address(RVA = "0xD2C240", Offset = "0xD2C240", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<className>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return className;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000198")]
			[Address(RVA = "0xD2C248", Offset = "0xD2C248", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<className>k__BackingField = value;\n\treturn;\n")]
			set
			{
				className = value;
			}
		}

		[Token(Token = "0x17000059")]
		public string text
		{
			[CompilerGenerated]
			[Token(Token = "0x6000199")]
			[Address(RVA = "0xD2C250", Offset = "0xD2C250", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<text>k__BackingField = value;\n\treturn;\n")]
			set
			{
				text = value;
			}
		}

		[Token(Token = "0x1700005A")]
		public string hint
		{
			[CompilerGenerated]
			[Token(Token = "0x600019A")]
			[Address(RVA = "0xD2C258", Offset = "0xD2C258", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<hint>k__BackingField = value;\n\treturn;\n")]
			set
			{
				hint = value;
			}
		}

		[Token(Token = "0x1700005B")]
		public string desc
		{
			[CompilerGenerated]
			[Token(Token = "0x600019B")]
			[Address(RVA = "0xD2C260", Offset = "0xD2C260", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<desc>k__BackingField = value;\n\treturn;\n")]
			set
			{
				desc = value;
			}
		}

		[Token(Token = "0x1700005C")]
		public string tag
		{
			[CompilerGenerated]
			[Token(Token = "0x600019C")]
			[Address(RVA = "0xD2C268", Offset = "0xD2C268", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<tag>k__BackingField = value;\n\treturn;\n")]
			set
			{
				tag = value;
			}
		}

		[Token(Token = "0x1700005D")]
		public long index
		{
			[CompilerGenerated]
			[Token(Token = "0x600019D")]
			[Address(RVA = "0xD2C270", Offset = "0xD2C270", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<index>k__BackingField = value;\n\treturn;\n")]
			set
			{
				index = value;
			}
		}

		[Token(Token = "0x1700005E")]
		public long section
		{
			[CompilerGenerated]
			[Token(Token = "0x600019E")]
			[Address(RVA = "0xD2C278", Offset = "0xD2C278", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<section>k__BackingField = value;\n\treturn;\n")]
			set
			{
				section = value;
			}
		}

		[Token(Token = "0x1700005F")]
		public long row
		{
			[CompilerGenerated]
			[Token(Token = "0x600019F")]
			[Address(RVA = "0xD2C280", Offset = "0xD2C280", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<row>k__BackingField = value;\n\treturn;\n")]
			set
			{
				row = value;
			}
		}

		[Token(Token = "0x17000060")]
		public long matchBitmask
		{
			[CompilerGenerated]
			[Token(Token = "0x60001A0")]
			[Address(RVA = "0xD2C288", Offset = "0xD2C288", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<matchBitmask>k__BackingField = value;\n\treturn;\n")]
			set
			{
				matchBitmask = value;
			}
		}

		[Token(Token = "0x6000196")]
		[Address(RVA = "0xD2BF04", Offset = "0xD2BF04", Length = "0x33C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv28 = *([1F03B80]);\n\tv29 = *([v28 @ X8_v44]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, dict, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2023C0D]) = v47;\nL_001A:\n\tSystem.Object::.ctor(this);\n\tv58 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(dict, \"class_name\");\n\tv110 = v58 == 0;\n\tif (v110) goto L_0036;\n\tv122 = *([v58 @ X0_v7 (System.String)]) != System.String;\n\tif (v122) goto L_0143;\nL_0036:\n\tthis.<className>k__BackingField = v58;\n\tv141 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(dict, \"text\");\n\tv332 = v141 == 0;\n\tif (v332) goto L_005B;\n\tv304 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(dict, \"text\");\n\tv313 = v304 == 0;\n\tif (v313) goto L_0055;\n\tv201 = *([v304 @ X0_v55 (System.String)]) != System.String;\n\tif (v201) goto L_0143;\nL_0055:\n\tthis.<text>k__BackingField = v304;\nL_005B:\n\tv411 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(dict, \"hint\");\n\tv413 = v411 == 0;\n\tif (v413) goto L_0078;\n\tv305 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(dict, \"hint\");\n\tv314 = v305 == 0;\n\tif (v314) goto L_0072;\n\tv202 = *([v305 @ X0_v53 (System.String)]) != System.String;\n\tif (v202) goto L_0143;\nL_0072:\n\tthis.<hint>k__BackingField = v305;\nL_0078:\n\tv446 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(dict, \"description\");\n\tv448 = v446 == 0;\n\tif (v448) goto L_0095;\n\tv306 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(dict, \"description\");\n\tv315 = v306 == 0;\n\tif (v315) goto L_008F;\n\tv203 = *([v306 @ X0_v51 (System.String)]) != System.String;\n\tif (v203) goto L_0143;\nL_008F:\n\tthis.<desc>k__BackingField = v306;\nL_0095:\n\tv471 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(dict, \"index\");\n\tv473 = v471 == 0;\n\tif (v473) goto L_00B8;\n\tv307 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(dict, \"index\");\n\tv204 = v204_asT == 0;\n\tif (v204) goto L_0143;\n\tv488 = \"il2cpp_vm_object_unbox\"(v307, System.Int64, Il2CppMethodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tthis.<index>k__BackingField = *([v488 @ X0_v49]);\nL_00B8:\n\tv496 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(dict, \"tag\");\n\tv498 = v496 == 0;\n\tif (v498) goto L_00D5;\n\tv308 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(dict, \"tag\");\n\tv317 = v308 == 0;\n\tif (v317) goto L_00CF;\n\tv205 = *([v308 @ X0_v46 (System.String)]) != System.String;\n\tif (v205) goto L_0143;\nL_00CF:\n\tthis.<tag>k__BackingField = v308;\nL_00D5:\n\tv524 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(dict, \"section\");\n\tv526 = v524 == 0;\n\tif (v526) goto L_00F8;\n\tv309 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(dict, \"section\");\n\tv206 = v206_asT == 0;\n\tif (v206) goto L_0143;\n\tv532 = \"il2cpp_vm_object_unbox\"(v309, System.Int64, Il2CppMethodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tthis.<section>k__BackingField = *([v532 @ X0_v44]);\nL_00F8:\n\tv539 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(dict, \"row\");\n\tv541 = v539 == 0;\n\tif (v541) goto L_011B;\n\tv310 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(dict, \"row\");\n\tv207 = v207_asT == 0;\n\tif (v207) goto L_0143;\n\tv550 = \"il2cpp_vm_object_unbox\"(v310, System.Int64, Il2CppMethodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tthis.<row>k__BackingField = *([v550 @ X0_v41]);\nL_011B:\n\tv557 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(dict, \"match_bitmask\");\n\tv559 = v557 == 0;\n\tif (v559) goto L_0142;\n\tv311 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(dict, \"match_bitmask\");\n\tv208 = v208_asT == 0;\n\tif (v208) goto L_0143;\n\tv565 = \"il2cpp_vm_object_unbox\"(v311, System.Int64, Il2CppMethodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tthis.<matchBitmask>k__BackingField = *([v565 @ X0_v38]);\nL_0142:\n\treturn;\nL_0143:\n\tv330 = new System.InvalidCastException();\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 243 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FBSDKCodelessPathComponent(Dictionary<string, object> dict)
		{
			//IL_01f3: Expected I8, but got O
			//IL_02b5: Expected I8, but got O
			//IL_0224: Expected I8, but got O
			//IL_030f: Expected I8, but got O
			//IL_0369: Expected I8, but got O
			//IL_02e6: Expected I8, but got O
			//IL_0340: Expected I8, but got O
			//IL_039a: Expected I8, but got O
			base._002Ector();
			string text = (string)dict.get_Item("class_name");
			if (text == null || (object)text.GetType() == typeof(string))
			{
				className = text;
				if (dict.ContainsKey("text"))
				{
					string text2 = (string)dict.get_Item("text");
					if (text2 != null && (object)text2.GetType() != typeof(string))
					{
						goto IL_039f;
					}
					this.text = text2;
				}
				if (dict.ContainsKey("hint"))
				{
					string text3 = (string)dict.get_Item("hint");
					if (text3 != null && (object)text3.GetType() != typeof(string))
					{
						goto IL_039f;
					}
					hint = text3;
				}
				if (dict.ContainsKey("description"))
				{
					string text4 = (string)dict.get_Item("description");
					if (text4 != null && (object)text4.GetType() != typeof(string))
					{
						goto IL_039f;
					}
					desc = text4;
				}
				if (dict.ContainsKey("index"))
				{
					object obj = dict.get_Item("index");
					if ((long)((obj is long) ? obj : null) == 0)
					{
						goto IL_039f;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj2 = default(object);
					index = (long)obj2;
				}
				if (dict.ContainsKey("tag"))
				{
					string text5 = (string)dict.get_Item("tag");
					if (text5 != null && (object)text5.GetType() != typeof(string))
					{
						goto IL_039f;
					}
					tag = text5;
				}
				if (dict.ContainsKey("section"))
				{
					object obj3 = dict.get_Item("section");
					if ((long)((obj3 is long) ? obj3 : null) == 0)
					{
						goto IL_039f;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj4 = default(object);
					section = (long)obj4;
				}
				if (dict.ContainsKey("row"))
				{
					object obj5 = dict.get_Item("row");
					if ((long)((obj5 is long) ? obj5 : null) == 0)
					{
						goto IL_039f;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj6 = default(object);
					row = (long)obj6;
				}
				if (!dict.ContainsKey("match_bitmask"))
				{
					return;
				}
				object obj7 = dict.get_Item("match_bitmask");
				if ((long)((obj7 is long) ? obj7 : null) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj8 = default(object);
					matchBitmask = (long)obj8;
					return;
				}
			}
			goto IL_039f;
			IL_039f:
			InvalidCastException ex = new InvalidCastException();
			throw new NullReferenceException();
		}
	}
}
