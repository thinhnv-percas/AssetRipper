using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp
{
	public class GeneratedCodeSettings
	{
		private class GenerateCodeVisitior : DepthFirstAstVisitor
		{
			private GeneratedCodeSettings settings;

			public GenerateCodeVisitior(GeneratedCodeSettings settings)
			{
				if (settings == null)
				{
					throw new ArgumentNullException("settings");
				}
				this.settings = settings;
			}

			private GeneratedCodeMember GetCodeMemberCategory(EntityDeclaration x)
			{
				bool flag = x.HasModifier(Modifiers.Static) || x.HasModifier(Modifiers.Const);
				if (x is FieldDeclaration)
				{
					if (!flag)
					{
						return GeneratedCodeMember.InstanceFields;
					}
					return GeneratedCodeMember.StaticFields;
				}
				if (x is IndexerDeclaration)
				{
					return GeneratedCodeMember.Indexer;
				}
				if (x is PropertyDeclaration)
				{
					if (!flag)
					{
						return GeneratedCodeMember.InstanceProperties;
					}
					return GeneratedCodeMember.StaticProperties;
				}
				if (x is ConstructorDeclaration || x is DestructorDeclaration)
				{
					return GeneratedCodeMember.Constructors;
				}
				if (x is MethodDeclaration)
				{
					if (!flag)
					{
						return GeneratedCodeMember.InstanceMethods;
					}
					return GeneratedCodeMember.StaticMethods;
				}
				if (x is OperatorDeclaration)
				{
					return GeneratedCodeMember.Operators;
				}
				if (x is EventDeclaration || x is CustomEventDeclaration)
				{
					if (!flag)
					{
						return GeneratedCodeMember.InstanceEvents;
					}
					return GeneratedCodeMember.StaticEvents;
				}
				if (x is TypeDeclaration)
				{
					return GeneratedCodeMember.NestedTypes;
				}
				return GeneratedCodeMember.Unknown;
			}

			public override void VisitTypeDeclaration(TypeDeclaration typeDeclaration)
			{
				if (typeDeclaration.ClassType != ClassType.Enum)
				{
					List<EntityDeclaration> entities = new List<EntityDeclaration>(typeDeclaration.Members);
					entities.Sort(delegate(EntityDeclaration x, EntityDeclaration y)
					{
						int num = settings.CodeMemberOrder.IndexOf(GetCodeMemberCategory(x));
						int num2 = settings.CodeMemberOrder.IndexOf(GetCodeMemberCategory(y));
						if (num != num2)
						{
							return num.CompareTo(num2);
						}
						return settings.SubOrderAlphabetical ? (x.Name ?? "").CompareTo(y.Name ?? "") : entities.IndexOf(x).CompareTo(entities.IndexOf(y));
					});
					typeDeclaration.Members.Clear();
					typeDeclaration.Members.AddRange(entities);
					if (settings.GenerateCategoryComments)
					{
						GeneratedCodeMember generatedCodeMember = GeneratedCodeMember.Unknown;
						foreach (EntityDeclaration item in entities)
						{
							if (item.NextSibling is EntityDeclaration)
							{
								item.Parent.InsertChildAfter(item, new NewLineNode(), Roles.NewLine);
							}
							GeneratedCodeMember codeMemberCategory = GetCodeMemberCategory(item);
							if (codeMemberCategory != generatedCodeMember)
							{
								generatedCodeMember = codeMemberCategory;
								string categoryLabel = settings.GetCategoryLabel(generatedCodeMember);
								if (!string.IsNullOrEmpty(categoryLabel))
								{
									Comment comment = new Comment("");
									Comment child = new Comment(" " + categoryLabel);
									Comment child2 = new Comment("");
									item.Parent.InsertChildBefore(item, comment, Roles.Comment);
									item.Parent.InsertChildBefore(item, child, Roles.Comment);
									item.Parent.InsertChildBefore(item, child2, Roles.Comment);
									if (comment.PrevSibling is EntityDeclaration)
									{
										item.Parent.InsertChildBefore(comment, new NewLineNode(), Roles.NewLine);
									}
								}
							}
						}
					}
				}
			}
		}

		private List<GeneratedCodeMember> codeMemberOrder;

		private static Lazy<GeneratedCodeSettings> defaultSettings = new Lazy<GeneratedCodeSettings>(() => new GeneratedCodeSettings
		{
			CodeMemberOrder = new List<GeneratedCodeMember>
			{
				GeneratedCodeMember.StaticFields,
				GeneratedCodeMember.InstanceFields,
				GeneratedCodeMember.StaticProperties,
				GeneratedCodeMember.InstanceProperties,
				GeneratedCodeMember.Indexer,
				GeneratedCodeMember.Constructors,
				GeneratedCodeMember.StaticMethods,
				GeneratedCodeMember.InstanceMethods,
				GeneratedCodeMember.StaticEvents,
				GeneratedCodeMember.InstanceEvents,
				GeneratedCodeMember.Operators,
				GeneratedCodeMember.NestedTypes
			},
			GenerateCategoryComments = true,
			SubOrderAlphabetical = true
		});

		public List<GeneratedCodeMember> CodeMemberOrder
		{
			get
			{
				return codeMemberOrder;
			}
			set
			{
				codeMemberOrder = value;
			}
		}

		public bool GenerateCategoryComments
		{
			get;
			set;
		}

		public bool SubOrderAlphabetical
		{
			get;
			set;
		}

		public static GeneratedCodeSettings Default => defaultSettings.Value;

		public void Apply(AstNode rootNode)
		{
			if (rootNode == null)
			{
				throw new ArgumentNullException("rootNode");
			}
			rootNode.AcceptVisitor(new GenerateCodeVisitior(this));
		}

		public virtual string GetCategoryLabel(GeneratedCodeMember memberCategory)
		{
			switch (memberCategory)
			{
			case GeneratedCodeMember.StaticFields:
				return "Static Fields";
			case GeneratedCodeMember.InstanceFields:
				return "Fields";
			case GeneratedCodeMember.StaticProperties:
				return "Static Properties";
			case GeneratedCodeMember.InstanceProperties:
				return "Properties";
			case GeneratedCodeMember.Indexer:
				return "Indexer";
			case GeneratedCodeMember.Constructors:
				return "Constructors";
			case GeneratedCodeMember.StaticMethods:
				return "Static Methods";
			case GeneratedCodeMember.InstanceMethods:
				return "Methods";
			case GeneratedCodeMember.StaticEvents:
				return "Static Events";
			case GeneratedCodeMember.InstanceEvents:
				return "Events";
			case GeneratedCodeMember.Operators:
				return "Operators";
			case GeneratedCodeMember.NestedTypes:
				return "Nested Types";
			default:
				return null;
			}
		}
	}
}
