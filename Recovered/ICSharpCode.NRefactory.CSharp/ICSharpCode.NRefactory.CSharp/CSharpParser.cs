using ICSharpCode.NRefactory.Editor;
using ICSharpCode.NRefactory.MonoCSharp;
using ICSharpCode.NRefactory.MonoCSharp.Linq;
using ICSharpCode.NRefactory.MonoCSharp.Nullable;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp
{
	public class CSharpParser
	{
		private class ConversionVisitor : StructuralVisitor
		{
			private SyntaxTree unit = new SyntaxTree();

			internal bool convertTypeSystemMode;

			private readonly Stack<NamespaceDeclaration> namespaceStack = new Stack<NamespaceDeclaration>();

			private readonly Stack<TypeDeclaration> typeStack = new Stack<TypeDeclaration>();

			private static readonly Dictionary<ICSharpCode.NRefactory.MonoCSharp.Modifiers, Modifiers> modifierTable;

			private static readonly string[] keywordTable;

			private QueryOrderClause currentQueryOrderClause;

			public SyntaxTree Unit
			{
				get
				{
					return unit;
				}
				set
				{
					unit = value;
				}
			}

			public LocationsBag LocationsBag
			{
				get;
				private set;
			}

			public ConversionVisitor(bool convertTypeSystemMode, LocationsBag locationsBag)
			{
				this.convertTypeSystemMode = convertTypeSystemMode;
				LocationsBag = locationsBag;
			}

			public static TextLocation Convert(Location loc)
			{
				return new TextLocation(loc.Row, loc.Column);
			}

			public override void Visit(ModuleContainer mc)
			{
				bool flag = true;
				foreach (TypeContainer container in mc.Containers)
				{
					NamespaceContainer namespaceContainer = container as NamespaceContainer;
					if (namespaceContainer == null)
					{
						container.Accept(this);
					}
					else
					{
						NamespaceDeclaration namespaceDeclaration = null;
						List<Location> locations = LocationsBag.GetLocations(namespaceContainer);
						if (namespaceContainer.NS != null && !string.IsNullOrEmpty(namespaceContainer.NS.Name))
						{
							namespaceDeclaration = new NamespaceDeclaration();
							if (locations != null)
							{
								namespaceDeclaration.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.NamespaceKeyword), Roles.NamespaceKeyword);
							}
							namespaceDeclaration.AddChild(ConvertNamespaceName(namespaceContainer.RealMemberName), NamespaceDeclaration.NamespaceNameRole);
							if (locations != null && locations.Count > 1)
							{
								namespaceDeclaration.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.LBrace), Roles.LBrace);
							}
							AddToNamespace(namespaceDeclaration);
							namespaceStack.Push(namespaceDeclaration);
						}
						if (namespaceContainer.Usings != null)
						{
							foreach (UsingClause @using in namespaceContainer.Usings)
							{
								@using.Accept(this);
							}
						}
						if (flag)
						{
							flag = false;
							if (mc.OptAttributes != null)
							{
								foreach (List<ICSharpCode.NRefactory.MonoCSharp.Attribute> section in mc.OptAttributes.Sections)
								{
									AttributeSection attributeSection = ConvertAttributeSection(section);
									if (attributeSection != null)
									{
										unit.AddChild(attributeSection, SyntaxTree.MemberRole);
									}
								}
							}
						}
						if (namespaceContainer.Containers != null)
						{
							foreach (TypeContainer container2 in namespaceContainer.Containers)
							{
								container2.Accept(this);
							}
						}
						if (namespaceDeclaration != null)
						{
							AddAttributeSection(namespaceDeclaration, namespaceContainer.UnattachedAttributes, EntityDeclaration.UnattachedAttributeRole);
							if (locations != null && locations.Count > 2)
							{
								namespaceDeclaration.AddChild(new CSharpTokenNode(Convert(locations[2]), Roles.RBrace), Roles.RBrace);
							}
							if (locations != null && locations.Count > 3)
							{
								namespaceDeclaration.AddChild(new CSharpTokenNode(Convert(locations[3]), Roles.Semicolon), Roles.Semicolon);
							}
							namespaceStack.Pop();
						}
						else
						{
							AddAttributeSection(unit, namespaceContainer.UnattachedAttributes, EntityDeclaration.UnattachedAttributeRole);
						}
					}
				}
				AddAttributeSection(unit, mc.UnattachedAttributes, EntityDeclaration.UnattachedAttributeRole);
			}

			private void AddTypeArguments(ATypeNameExpression texpr, AstType result)
			{
				UnboundTypeArguments unboundTypeArguments = texpr.TypeArguments as UnboundTypeArguments;
				if (unboundTypeArguments != null)
				{
					TextLocation location = Convert(texpr.Location);
					result.AddChild(new CSharpTokenNode(location, Roles.LChevron), Roles.LChevron);
					location = new TextLocation(location.Line, location.Column + 1);
					for (int i = 0; i < unboundTypeArguments.Count; i++)
					{
						result.AddChild(new SimpleType(), Roles.TypeArgument);
						result.AddChild(new CSharpTokenNode(location, Roles.LChevron), Roles.Comma);
						location = new TextLocation(location.Line, location.Column + 1);
					}
					result.AddChild(new CSharpTokenNode(location, Roles.RChevron), Roles.RChevron);
				}
				else if (texpr.TypeArguments != null && texpr.TypeArguments.Args != null)
				{
					List<Location> locations = LocationsBag.GetLocations(texpr.TypeArguments);
					if (locations != null && locations.Count >= 2)
					{
						result.AddChild(new CSharpTokenNode(Convert(locations[locations.Count - 2]), Roles.LChevron), Roles.LChevron);
					}
					int num = 0;
					foreach (FullNamedExpression arg in texpr.TypeArguments.Args)
					{
						result.AddChild(ConvertToType(arg), Roles.TypeArgument);
						if (locations != null && num < locations.Count - 2)
						{
							result.AddChild(new CSharpTokenNode(Convert(locations[num++]), Roles.Comma), Roles.Comma);
						}
					}
					if (locations != null && locations.Count >= 2)
					{
						result.AddChild(new CSharpTokenNode(Convert(locations[locations.Count - 1]), Roles.RChevron), Roles.RChevron);
					}
				}
			}

			private static AstType ConvertToType(TypeParameter spec)
			{
				return new SimpleType
				{
					IdentifierToken = Identifier.Create(spec.Name, Convert(spec.Location))
				};
			}

			private AstType ConvertToType(MemberName memberName)
			{
				AstType astType;
				if (memberName.Left != null)
				{
					astType = new MemberType();
					astType.AddChild(ConvertToType(memberName.Left), MemberType.TargetRole);
					List<Location> locations = LocationsBag.GetLocations(memberName);
					if (locations != null)
					{
						astType.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Dot), Roles.Dot);
					}
					astType.AddChild(Identifier.Create(memberName.Name, Convert(memberName.Location)), Roles.Identifier);
				}
				else
				{
					astType = new SimpleType
					{
						IdentifierToken = Identifier.Create(memberName.Name, Convert(memberName.Location))
					};
				}
				if (memberName.TypeParameters != null)
				{
					List<Location> locations2 = LocationsBag.GetLocations(memberName.TypeParameters);
					if (locations2 != null)
					{
						astType.AddChild(new CSharpTokenNode(Convert(locations2[locations2.Count - 2]), Roles.LChevron), Roles.LChevron);
					}
					for (int i = 0; i < memberName.TypeParameters.Count; i++)
					{
						TypeParameter typeParameter = memberName.TypeParameters[i];
						astType.AddChild(new SimpleType(Identifier.Create(typeParameter.Name, Convert(typeParameter.Location))), Roles.TypeArgument);
						if (locations2 != null && i < locations2.Count - 2)
						{
							astType.AddChild(new CSharpTokenNode(Convert(locations2[i]), Roles.Comma), Roles.Comma);
						}
					}
					if (locations2 != null)
					{
						astType.AddChild(new CSharpTokenNode(Convert(locations2[locations2.Count - 1]), Roles.RChevron), Roles.RChevron);
					}
				}
				return astType;
			}

			private AstType ConvertToType(ICSharpCode.NRefactory.MonoCSharp.Expression typeName)
			{
				if (typeName == null)
				{
					return new SimpleType();
				}
				TypeExpression typeExpression = typeName as TypeExpression;
				if (typeExpression != null)
				{
					return new PrimitiveType(typeExpression.GetSignatureForError(), Convert(typeExpression.Location));
				}
				QualifiedAliasMember qualifiedAliasMember = typeName as QualifiedAliasMember;
				if (qualifiedAliasMember != null)
				{
					List<Location> locations = LocationsBag.GetLocations(typeName);
					MemberType memberType = new MemberType();
					memberType.Target = new SimpleType(qualifiedAliasMember.alias, Convert(qualifiedAliasMember.Location));
					memberType.IsDoubleColon = true;
					if (locations != null && locations.Count > 0)
					{
						memberType.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.DoubleColon), Roles.DoubleColon);
					}
					memberType.MemberNameToken = Identifier.Create(qualifiedAliasMember.Name, (locations != null) ? Convert(locations[1]) : TextLocation.Empty);
					AddTypeArguments(qualifiedAliasMember, memberType);
					return memberType;
				}
				MemberAccess memberAccess = typeName as MemberAccess;
				if (memberAccess != null)
				{
					MemberType memberType2 = new MemberType();
					memberType2.AddChild(ConvertToType(memberAccess.LeftExpression), MemberType.TargetRole);
					List<Location> locations2 = LocationsBag.GetLocations(memberAccess);
					if (locations2 != null)
					{
						memberType2.AddChild(new CSharpTokenNode(Convert(locations2[0]), Roles.Dot), Roles.Dot);
					}
					memberType2.MemberNameToken = Identifier.Create(memberAccess.Name, Convert(memberAccess.Location));
					AddTypeArguments(memberAccess, memberType2);
					return memberType2;
				}
				SimpleName simpleName = typeName as SimpleName;
				if (simpleName != null)
				{
					SimpleType result = new SimpleType(simpleName.Name, Convert(simpleName.Location));
					AddTypeArguments(simpleName, result);
					return result;
				}
				ComposedCast composedCast = typeName as ComposedCast;
				if (composedCast != null)
				{
					AstType baseType = ConvertToType(composedCast.Left);
					ComposedType composedType = new ComposedType
					{
						BaseType = baseType
					};
					for (ComposedTypeSpecifier composedTypeSpecifier = composedCast.Spec; composedTypeSpecifier != null; composedTypeSpecifier = composedTypeSpecifier.Next)
					{
						if (composedTypeSpecifier.IsNullable)
						{
							composedType.AddChild(new CSharpTokenNode(Convert(composedTypeSpecifier.Location), ComposedType.NullableRole), ComposedType.NullableRole);
						}
						else if (composedTypeSpecifier.IsPointer)
						{
							composedType.AddChild(new CSharpTokenNode(Convert(composedTypeSpecifier.Location), ComposedType.PointerRole), ComposedType.PointerRole);
						}
						else
						{
							List<Location> locations3 = LocationsBag.GetLocations(composedTypeSpecifier);
							ArraySpecifier arraySpecifier = new ArraySpecifier
							{
								Dimensions = composedTypeSpecifier.Dimension
							};
							arraySpecifier.AddChild(new CSharpTokenNode(Convert(composedTypeSpecifier.Location), Roles.LBracket), Roles.LBracket);
							if (locations3 != null)
							{
								arraySpecifier.AddChild(new CSharpTokenNode(Convert(locations3[0]), Roles.RBracket), Roles.RBracket);
							}
							composedType.ArraySpecifiers.Add(arraySpecifier);
						}
					}
					return composedType;
				}
				SpecialContraintExpr specialContraintExpr = typeName as SpecialContraintExpr;
				if (specialContraintExpr != null)
				{
					switch (specialContraintExpr.Constraint)
					{
					case SpecialConstraint.Class:
						return new PrimitiveType("class", Convert(specialContraintExpr.Location));
					case SpecialConstraint.Struct:
						return new PrimitiveType("struct", Convert(specialContraintExpr.Location));
					case SpecialConstraint.Constructor:
						return new PrimitiveType("new", Convert(specialContraintExpr.Location));
					}
				}
				return new SimpleType("unknown");
			}

			private IEnumerable<Attribute> GetAttributes(IEnumerable<ICSharpCode.NRefactory.MonoCSharp.Attribute> optAttributes)
			{
				if (optAttributes != null)
				{
					foreach (ICSharpCode.NRefactory.MonoCSharp.Attribute optAttribute in optAttributes)
					{
						Attribute attribute = new Attribute();
						attribute.Type = ConvertToType(optAttribute.TypeNameExpression);
						List<Location> locations = LocationsBag.GetLocations(optAttribute);
						attribute.HasArgumentList = (locations != null);
						int num = 0;
						if (locations != null)
						{
							attribute.AddChild(new CSharpTokenNode(Convert(locations[num++]), Roles.LPar), Roles.LPar);
						}
						if (optAttribute.PositionalArguments != null)
						{
							foreach (Argument positionalArgument in optAttribute.PositionalArguments)
							{
								if (positionalArgument != null)
								{
									NamedArgument namedArgument = positionalArgument as NamedArgument;
									if (namedArgument != null)
									{
										NamedArgumentExpression namedArgumentExpression = new NamedArgumentExpression();
										namedArgumentExpression.AddChild(Identifier.Create(namedArgument.Name, Convert(namedArgument.Location)), Roles.Identifier);
										List<Location> locations2 = LocationsBag.GetLocations(namedArgument);
										if (locations2 != null)
										{
											namedArgumentExpression.AddChild(new CSharpTokenNode(Convert(locations2[0]), Roles.Colon), Roles.Colon);
										}
										if (namedArgument.Expr != null)
										{
											namedArgumentExpression.AddChild((Expression)namedArgument.Expr.Accept(this), Roles.Expression);
										}
										attribute.AddChild(namedArgumentExpression, Roles.Argument);
									}
									else if (positionalArgument.Expr != null)
									{
										attribute.AddChild((Expression)positionalArgument.Expr.Accept(this), Roles.Argument);
									}
									if (locations != null && num + 1 < locations.Count)
									{
										attribute.AddChild(new CSharpTokenNode(Convert(locations[num++]), Roles.Comma), Roles.Comma);
									}
								}
							}
						}
						if (optAttribute.NamedArguments != null)
						{
							foreach (NamedArgument namedArgument2 in optAttribute.NamedArguments)
							{
								NamedExpression namedExpression = new NamedExpression();
								namedExpression.AddChild(Identifier.Create(namedArgument2.Name, Convert(namedArgument2.Location)), Roles.Identifier);
								List<Location> locations3 = LocationsBag.GetLocations(namedArgument2);
								if (locations3 != null)
								{
									namedExpression.AddChild(new CSharpTokenNode(Convert(locations3[0]), Roles.Assign), Roles.Assign);
								}
								if (namedArgument2.Expr != null)
								{
									namedExpression.AddChild((Expression)namedArgument2.Expr.Accept(this), Roles.Expression);
								}
								attribute.AddChild(namedExpression, Roles.Argument);
								if (locations != null && num + 1 < locations.Count)
								{
									attribute.AddChild(new CSharpTokenNode(Convert(locations[num++]), Roles.Comma), Roles.Comma);
								}
							}
						}
						if (locations != null && num < locations.Count)
						{
							attribute.AddChild(new CSharpTokenNode(Convert(locations[num]), Roles.RPar), Roles.RPar);
						}
						yield return attribute;
					}
				}
			}

			private AttributeSection ConvertAttributeSection(IEnumerable<ICSharpCode.NRefactory.MonoCSharp.Attribute> optAttributes)
			{
				if (optAttributes == null)
				{
					return null;
				}
				AttributeSection attributeSection = new AttributeSection();
				List<Location> locations = LocationsBag.GetLocations(optAttributes);
				int num = 0;
				if (locations != null)
				{
					attributeSection.AddChild(new CSharpTokenNode(Convert(locations[num++]), Roles.LBracket), Roles.LBracket);
				}
				string text = optAttributes.FirstOrDefault()?.ExplicitTarget;
				if (!string.IsNullOrEmpty(text))
				{
					if (locations != null && num < locations.Count - 1)
					{
						attributeSection.AddChild(Identifier.Create(text, Convert(locations[num++])), Roles.Identifier);
					}
					else
					{
						attributeSection.AddChild(Identifier.Create(text), Roles.Identifier);
					}
					if (locations != null && num < locations.Count)
					{
						attributeSection.AddChild(new CSharpTokenNode(Convert(locations[num++]), Roles.Colon), Roles.Colon);
					}
				}
				int num5 = 0;
				foreach (Attribute attribute in GetAttributes(optAttributes))
				{
					attributeSection.AddChild(attribute, Roles.Attribute);
					if (locations != null && num + 1 < locations.Count)
					{
						attributeSection.AddChild(new CSharpTokenNode(Convert(locations[num++]), Roles.Comma), Roles.Comma);
					}
					num5++;
				}
				if (num5 == 0)
				{
					return null;
				}
				int num7 = 2 + num5 - 1;
				if (locations != null && num < locations.Count - 1 && locations.Count == num7 + 1)
				{
					attributeSection.AddChild(new CSharpTokenNode(Convert(locations[num++]), Roles.Comma), Roles.Comma);
				}
				if (locations != null && num < locations.Count)
				{
					attributeSection.AddChild(new CSharpTokenNode(Convert(locations[num++]), Roles.RBracket), Roles.RBracket);
				}
				return attributeSection;
			}

			public override void Visit(NamespaceContainer ns)
			{
				NamespaceDeclaration namespaceDeclaration = null;
				List<Location> locations = LocationsBag.GetLocations(ns);
				if (ns.NS != null && !string.IsNullOrEmpty(ns.NS.Name) && !ns.NS.Name.EndsWith("<invalid>", StringComparison.Ordinal))
				{
					namespaceDeclaration = new NamespaceDeclaration();
					if (locations != null)
					{
						namespaceDeclaration.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.NamespaceKeyword), Roles.NamespaceKeyword);
					}
					namespaceDeclaration.AddChild(ConvertNamespaceName(ns.RealMemberName), NamespaceDeclaration.NamespaceNameRole);
					if (locations != null && locations.Count > 1)
					{
						namespaceDeclaration.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.LBrace), Roles.LBrace);
					}
					AddToNamespace(namespaceDeclaration);
					namespaceStack.Push(namespaceDeclaration);
				}
				if (ns.Usings != null)
				{
					foreach (UsingClause @using in ns.Usings)
					{
						@using.Accept(this);
					}
				}
				if (ns.Containers != null)
				{
					foreach (TypeContainer container in ns.Containers)
					{
						container.Accept(this);
					}
				}
				if (namespaceDeclaration != null)
				{
					AddAttributeSection(namespaceDeclaration, ns.UnattachedAttributes, EntityDeclaration.UnattachedAttributeRole);
					if (locations != null && locations.Count > 2)
					{
						namespaceDeclaration.AddChild(new CSharpTokenNode(Convert(locations[2]), Roles.RBrace), Roles.RBrace);
					}
					if (locations != null && locations.Count > 3)
					{
						namespaceDeclaration.AddChild(new CSharpTokenNode(Convert(locations[3]), Roles.Semicolon), Roles.Semicolon);
					}
					namespaceStack.Pop();
				}
			}

			private AstType ConvertNamespaceName(MemberName memberName)
			{
				if (memberName.Name == "<invalid>")
				{
					return AstType.Null;
				}
				return ConvertToType(memberName);
			}

			public override void Visit(UsingNamespace un)
			{
				UsingDeclaration usingDeclaration = new UsingDeclaration();
				List<Location> locations = LocationsBag.GetLocations(un);
				usingDeclaration.AddChild(new CSharpTokenNode(Convert(un.Location), UsingDeclaration.UsingKeywordRole), UsingDeclaration.UsingKeywordRole);
				if (un.NamespaceExpression != null)
				{
					usingDeclaration.AddChild(ConvertToType(un.NamespaceExpression), UsingDeclaration.ImportRole);
				}
				if (locations != null)
				{
					usingDeclaration.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Semicolon), Roles.Semicolon);
				}
				AddToNamespace(usingDeclaration);
			}

			public override void Visit(UsingClause un)
			{
				UsingDeclaration usingDeclaration = new UsingDeclaration();
				List<Location> locations = LocationsBag.GetLocations(un);
				usingDeclaration.AddChild(new CSharpTokenNode(Convert(un.Location), UsingDeclaration.UsingKeywordRole), UsingDeclaration.UsingKeywordRole);
				if (un.NamespaceExpression != null)
				{
					usingDeclaration.AddChild(ConvertToType(un.NamespaceExpression), UsingDeclaration.ImportRole);
				}
				if (locations != null)
				{
					usingDeclaration.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Semicolon), Roles.Semicolon);
				}
				AddToNamespace(usingDeclaration);
			}

			public override void Visit(UsingAliasNamespace uan)
			{
				UsingAliasDeclaration usingAliasDeclaration = new UsingAliasDeclaration();
				List<Location> locations = LocationsBag.GetLocations(uan);
				usingAliasDeclaration.AddChild(new CSharpTokenNode(Convert(uan.Location), UsingAliasDeclaration.UsingKeywordRole), UsingAliasDeclaration.UsingKeywordRole);
				usingAliasDeclaration.AddChild(Identifier.Create(uan.Alias.Value, Convert(uan.Alias.Location)), UsingAliasDeclaration.AliasRole);
				if (locations != null)
				{
					usingAliasDeclaration.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Assign), Roles.Assign);
				}
				if (uan.NamespaceExpression != null)
				{
					usingAliasDeclaration.AddChild(ConvertToType(uan.NamespaceExpression), UsingAliasDeclaration.ImportRole);
				}
				if (locations != null && locations.Count > 1)
				{
					usingAliasDeclaration.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.Semicolon), Roles.Semicolon);
				}
				AddToNamespace(usingAliasDeclaration);
			}

			public override void Visit(UsingExternAlias uea)
			{
				ExternAliasDeclaration externAliasDeclaration = new ExternAliasDeclaration();
				List<Location> locations = LocationsBag.GetLocations(uea);
				externAliasDeclaration.AddChild(new CSharpTokenNode(Convert(uea.Location), Roles.ExternKeyword), Roles.ExternKeyword);
				if (locations != null)
				{
					externAliasDeclaration.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.AliasKeyword), Roles.AliasKeyword);
				}
				externAliasDeclaration.AddChild(Identifier.Create(uea.Alias.Value, Convert(uea.Alias.Location)), Roles.Identifier);
				if (locations != null && locations.Count > 1)
				{
					externAliasDeclaration.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.Semicolon), Roles.Semicolon);
				}
				AddToNamespace(externAliasDeclaration);
			}

			private AstType ConvertImport(MemberName memberName)
			{
				if (memberName.Left != null)
				{
					MemberType memberType = new MemberType();
					memberType.AddChild(ConvertImport(memberName.Left), MemberType.TargetRole);
					List<Location> locations = LocationsBag.GetLocations(memberName);
					if (locations != null)
					{
						memberType.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Dot), Roles.Dot);
					}
					memberType.AddChild(Identifier.Create(memberName.Name, Convert(memberName.Location)), Roles.Identifier);
					AddTypeArguments(memberType, memberName);
					return memberType;
				}
				SimpleType simpleType = new SimpleType();
				simpleType.AddChild(Identifier.Create(memberName.Name, Convert(memberName.Location)), Roles.Identifier);
				AddTypeArguments(simpleType, memberName);
				return simpleType;
			}

			public override void Visit(MemberCore member)
			{
				Console.WriteLine("Unknown member:");
				Console.WriteLine(member.GetType() + "-> Member {0}", member.GetSignatureForError());
			}

			public override void Visit(Class c)
			{
				TypeDeclaration typeDeclaration = new TypeDeclaration();
				typeDeclaration.ClassType = ClassType.Class;
				AddAttributeSection(typeDeclaration, c);
				LocationsBag.MemberLocations memberLocation = LocationsBag.GetMemberLocation(c);
				AddModifiers(typeDeclaration, memberLocation);
				int num = 0;
				if (memberLocation != null && memberLocation.Count > 0)
				{
					typeDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), Roles.ClassKeyword), Roles.ClassKeyword);
				}
				typeDeclaration.AddChild(Identifier.Create(c.MemberName.Name, Convert(c.MemberName.Location)), Roles.Identifier);
				AddTypeParameters(typeDeclaration, c.MemberName);
				if (c.TypeBaseExpressions != null)
				{
					if (memberLocation != null && num < memberLocation.Count)
					{
						typeDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), Roles.Colon), Roles.Colon);
					}
					List<Location> locations = LocationsBag.GetLocations(c.TypeBaseExpressions);
					int num4 = 0;
					foreach (FullNamedExpression typeBaseExpression in c.TypeBaseExpressions)
					{
						typeDeclaration.AddChild(ConvertToType(typeBaseExpression), Roles.BaseType);
						if (locations != null && num4 < locations.Count)
						{
							typeDeclaration.AddChild(new CSharpTokenNode(Convert(locations[num4]), Roles.Comma), Roles.Comma);
							num4++;
						}
					}
				}
				AddConstraints(typeDeclaration, c.CurrentTypeParameters);
				if (memberLocation != null && num < memberLocation.Count)
				{
					typeDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), Roles.LBrace), Roles.LBrace);
				}
				typeStack.Push(typeDeclaration);
				base.Visit(c);
				AddAttributeSection(typeDeclaration, c.UnattachedAttributes, EntityDeclaration.UnattachedAttributeRole);
				if (memberLocation != null && num < memberLocation.Count)
				{
					typeDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), Roles.RBrace), Roles.RBrace);
					if (memberLocation != null && num < memberLocation.Count)
					{
						typeDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), Roles.Semicolon), Roles.Semicolon);
					}
				}
				else
				{
					typeDeclaration.AddChild(new ErrorNode(), Roles.Error);
				}
				typeStack.Pop();
				AddType(typeDeclaration);
			}

			public override void Visit(Struct s)
			{
				TypeDeclaration typeDeclaration = new TypeDeclaration();
				typeDeclaration.ClassType = ClassType.Struct;
				AddAttributeSection(typeDeclaration, s);
				LocationsBag.MemberLocations memberLocation = LocationsBag.GetMemberLocation(s);
				AddModifiers(typeDeclaration, memberLocation);
				int num = 0;
				if (memberLocation != null && memberLocation.Count > 0)
				{
					typeDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), Roles.StructKeyword), Roles.StructKeyword);
				}
				typeDeclaration.AddChild(Identifier.Create(s.MemberName.Name, Convert(s.MemberName.Location)), Roles.Identifier);
				AddTypeParameters(typeDeclaration, s.MemberName);
				if (s.TypeBaseExpressions != null)
				{
					if (memberLocation != null && num < memberLocation.Count)
					{
						typeDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), Roles.Colon), Roles.Colon);
					}
					List<Location> locations = LocationsBag.GetLocations(s.TypeBaseExpressions);
					int num4 = 0;
					foreach (FullNamedExpression typeBaseExpression in s.TypeBaseExpressions)
					{
						typeDeclaration.AddChild(ConvertToType(typeBaseExpression), Roles.BaseType);
						if (locations != null && num4 < locations.Count)
						{
							typeDeclaration.AddChild(new CSharpTokenNode(Convert(locations[num4]), Roles.Comma), Roles.Comma);
							num4++;
						}
					}
				}
				AddConstraints(typeDeclaration, s.CurrentTypeParameters);
				if (memberLocation != null && num < memberLocation.Count)
				{
					typeDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), Roles.LBrace), Roles.LBrace);
				}
				typeStack.Push(typeDeclaration);
				base.Visit(s);
				if (memberLocation != null && memberLocation.Count > 2)
				{
					if (memberLocation != null && num < memberLocation.Count)
					{
						typeDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), Roles.RBrace), Roles.RBrace);
					}
					if (memberLocation != null && num < memberLocation.Count)
					{
						typeDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), Roles.Semicolon), Roles.Semicolon);
					}
				}
				else
				{
					typeDeclaration.AddChild(new ErrorNode(), Roles.Error);
				}
				typeStack.Pop();
				AddType(typeDeclaration);
			}

			public override void Visit(Interface i)
			{
				TypeDeclaration typeDeclaration = new TypeDeclaration();
				typeDeclaration.ClassType = ClassType.Interface;
				AddAttributeSection(typeDeclaration, i);
				LocationsBag.MemberLocations memberLocation = LocationsBag.GetMemberLocation(i);
				AddModifiers(typeDeclaration, memberLocation);
				int num = 0;
				if (memberLocation != null && memberLocation.Count > 0)
				{
					typeDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), Roles.InterfaceKeyword), Roles.InterfaceKeyword);
				}
				typeDeclaration.AddChild(Identifier.Create(i.MemberName.Name, Convert(i.MemberName.Location)), Roles.Identifier);
				AddTypeParameters(typeDeclaration, i.MemberName);
				if (i.TypeBaseExpressions != null)
				{
					if (memberLocation != null && num < memberLocation.Count)
					{
						typeDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), Roles.Colon), Roles.Colon);
					}
					List<Location> locations = LocationsBag.GetLocations(i.TypeBaseExpressions);
					int num4 = 0;
					foreach (FullNamedExpression typeBaseExpression in i.TypeBaseExpressions)
					{
						typeDeclaration.AddChild(ConvertToType(typeBaseExpression), Roles.BaseType);
						if (locations != null && num4 < locations.Count)
						{
							typeDeclaration.AddChild(new CSharpTokenNode(Convert(locations[num4]), Roles.Comma), Roles.Comma);
							num4++;
						}
					}
				}
				AddConstraints(typeDeclaration, i.CurrentTypeParameters);
				if (memberLocation != null && num < memberLocation.Count)
				{
					typeDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), Roles.LBrace), Roles.LBrace);
				}
				typeStack.Push(typeDeclaration);
				base.Visit(i);
				if (memberLocation != null && memberLocation.Count > 2)
				{
					if (memberLocation != null && num < memberLocation.Count)
					{
						typeDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), Roles.RBrace), Roles.RBrace);
					}
					if (memberLocation != null && num < memberLocation.Count)
					{
						typeDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), Roles.Semicolon), Roles.Semicolon);
					}
				}
				else
				{
					typeDeclaration.AddChild(new ErrorNode(), Roles.Error);
				}
				typeStack.Pop();
				AddType(typeDeclaration);
			}

			public override void Visit(ICSharpCode.NRefactory.MonoCSharp.Delegate d)
			{
				DelegateDeclaration delegateDeclaration = new DelegateDeclaration();
				LocationsBag.MemberLocations memberLocation = LocationsBag.GetMemberLocation(d);
				AddAttributeSection(delegateDeclaration, d);
				AddModifiers(delegateDeclaration, memberLocation);
				if (memberLocation != null && memberLocation.Count > 0)
				{
					delegateDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[0]), Roles.DelegateKeyword), Roles.DelegateKeyword);
				}
				if (d.ReturnType != null)
				{
					delegateDeclaration.AddChild(ConvertToType(d.ReturnType), Roles.Type);
				}
				delegateDeclaration.AddChild(Identifier.Create(d.MemberName.Name, Convert(d.MemberName.Location)), Roles.Identifier);
				AddTypeParameters(delegateDeclaration, d.MemberName);
				if (memberLocation != null && memberLocation.Count > 1)
				{
					delegateDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[1]), Roles.LPar), Roles.LPar);
				}
				AddParameter(delegateDeclaration, d.Parameters);
				if (memberLocation != null && memberLocation.Count > 2)
				{
					delegateDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[2]), Roles.RPar), Roles.RPar);
				}
				AddConstraints(delegateDeclaration, d.CurrentTypeParameters);
				if (memberLocation != null && memberLocation.Count > 3)
				{
					delegateDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[3]), Roles.Semicolon), Roles.Semicolon);
				}
				AddType(delegateDeclaration);
			}

			private void AddType(EntityDeclaration child)
			{
				if (typeStack.Count > 0)
				{
					typeStack.Peek().AddChild(child, Roles.TypeMemberRole);
				}
				else
				{
					AddToNamespace(child);
				}
			}

			private void AddToNamespace(AstNode child)
			{
				if (namespaceStack.Count > 0)
				{
					namespaceStack.Peek().AddChild(child, NamespaceDeclaration.MemberRole);
				}
				else
				{
					unit.AddChild(child, SyntaxTree.MemberRole);
				}
			}

			public override void Visit(ICSharpCode.NRefactory.MonoCSharp.Enum e)
			{
				TypeDeclaration typeDeclaration = new TypeDeclaration();
				typeDeclaration.ClassType = ClassType.Enum;
				AddAttributeSection(typeDeclaration, e);
				LocationsBag.MemberLocations memberLocation = LocationsBag.GetMemberLocation(e);
				AddModifiers(typeDeclaration, memberLocation);
				int num = 0;
				if (memberLocation != null && memberLocation.Count > 0)
				{
					typeDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), Roles.EnumKeyword), Roles.EnumKeyword);
				}
				typeDeclaration.AddChild(Identifier.Create(e.MemberName.Name, Convert(e.MemberName.Location)), Roles.Identifier);
				if (e.BaseTypeExpression != null)
				{
					if (memberLocation != null && num < memberLocation.Count)
					{
						typeDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), Roles.Colon), Roles.Colon);
					}
					typeDeclaration.AddChild(ConvertToType(e.BaseTypeExpression), Roles.BaseType);
				}
				if (memberLocation != null && num < memberLocation.Count)
				{
					typeDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), Roles.LBrace), Roles.LBrace);
				}
				typeStack.Push(typeDeclaration);
				foreach (MemberCore member in e.Members)
				{
					EnumMember enumMember = member as EnumMember;
					if (enumMember == null)
					{
						Console.WriteLine("WARNING - ENUM MEMBER: " + member);
					}
					else
					{
						Visit(enumMember);
						if (memberLocation != null && num < memberLocation.Count - 1)
						{
							typeDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), Roles.Comma), Roles.Comma);
						}
					}
				}
				if (memberLocation != null && memberLocation.Count > 2)
				{
					if (memberLocation != null && num < memberLocation.Count)
					{
						typeDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), Roles.RBrace), Roles.RBrace);
					}
					if (memberLocation != null && num < memberLocation.Count)
					{
						typeDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), Roles.Semicolon), Roles.Semicolon);
					}
				}
				else
				{
					typeDeclaration.AddChild(new ErrorNode(), Roles.Error);
				}
				AddAttributeSection(typeDeclaration, e.UnattachedAttributes, EntityDeclaration.UnattachedAttributeRole);
				typeStack.Pop();
				AddType(typeDeclaration);
			}

			public override void Visit(EnumMember em)
			{
				EnumMemberDeclaration enumMemberDeclaration = new EnumMemberDeclaration();
				AddAttributeSection(enumMemberDeclaration, em);
				enumMemberDeclaration.AddChild(Identifier.Create(em.Name, Convert(em.Location)), Roles.Identifier);
				if (em.Initializer != null)
				{
					enumMemberDeclaration.AddChild(new CSharpTokenNode(Convert(em.Initializer.Location), Roles.Assign), Roles.Assign);
					enumMemberDeclaration.AddChild((Expression)em.Initializer.Accept(this), EnumMemberDeclaration.InitializerRole);
				}
				typeStack.Peek().AddChild(enumMemberDeclaration, Roles.TypeMemberRole);
			}

			public override void Visit(FixedField f)
			{
				LocationsBag.MemberLocations memberLocation = LocationsBag.GetMemberLocation(f);
				int num = 0;
				FixedFieldDeclaration fixedFieldDeclaration = new FixedFieldDeclaration();
				AddAttributeSection(fixedFieldDeclaration, f);
				AddModifiers(fixedFieldDeclaration, memberLocation);
				if (memberLocation != null && memberLocation.Count > 0)
				{
					fixedFieldDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), FixedFieldDeclaration.FixedKeywordRole), FixedFieldDeclaration.FixedKeywordRole);
				}
				if (f.TypeExpression != null)
				{
					fixedFieldDeclaration.AddChild(ConvertToType(f.TypeExpression), Roles.Type);
				}
				FixedVariableInitializer fixedVariableInitializer = new FixedVariableInitializer();
				fixedVariableInitializer.AddChild(Identifier.Create(f.MemberName.Name, Convert(f.MemberName.Location)), Roles.Identifier);
				if (f.Initializer != null && !f.Initializer.IsNull)
				{
					fixedVariableInitializer.AddChild(new CSharpTokenNode(Convert(f.Initializer.Location), Roles.LBracket), Roles.LBracket);
					fixedVariableInitializer.AddChild((Expression)f.Initializer.Accept(this), Roles.Expression);
					List<Location> locations = LocationsBag.GetLocations(f.Initializer);
					if (locations != null)
					{
						fixedVariableInitializer.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.RBracket), Roles.RBracket);
					}
				}
				fixedFieldDeclaration.AddChild(fixedVariableInitializer, FixedFieldDeclaration.VariableRole);
				if (f.Declarators != null)
				{
					foreach (FieldDeclarator declarator in f.Declarators)
					{
						List<Location> locations2 = LocationsBag.GetLocations(declarator);
						if (locations2 != null)
						{
							fixedFieldDeclaration.AddChild(new CSharpTokenNode(Convert(locations2[0]), Roles.Comma), Roles.Comma);
						}
						fixedVariableInitializer = new FixedVariableInitializer();
						fixedVariableInitializer.AddChild(Identifier.Create(declarator.Name.Value, Convert(declarator.Name.Location)), Roles.Identifier);
						fixedVariableInitializer.AddChild(new CSharpTokenNode(Convert(declarator.Initializer.Location), Roles.LBracket), Roles.LBracket);
						fixedVariableInitializer.AddChild((Expression)declarator.Initializer.Accept(this), Roles.Expression);
						List<Location> locations3 = LocationsBag.GetLocations(declarator.Initializer);
						if (locations3 != null)
						{
							fixedVariableInitializer.AddChild(new CSharpTokenNode(Convert(locations3[0]), Roles.RBracket), Roles.RBracket);
						}
						fixedFieldDeclaration.AddChild(fixedVariableInitializer, FixedFieldDeclaration.VariableRole);
					}
				}
				if (memberLocation != null && memberLocation.Count > num)
				{
					fixedFieldDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num]), Roles.Semicolon), Roles.Semicolon);
				}
				typeStack.Peek().AddChild(fixedFieldDeclaration, Roles.TypeMemberRole);
			}

			public override void Visit(Field f)
			{
				LocationsBag.MemberLocations memberLocation = LocationsBag.GetMemberLocation(f);
				FieldDeclaration fieldDeclaration = new FieldDeclaration();
				AddAttributeSection(fieldDeclaration, f);
				AddModifiers(fieldDeclaration, memberLocation);
				fieldDeclaration.AddChild(ConvertToType(f.TypeExpression), Roles.Type);
				VariableInitializer variableInitializer = new VariableInitializer();
				variableInitializer.AddChild(Identifier.Create(f.MemberName.Name, Convert(f.MemberName.Location)), Roles.Identifier);
				int num = 0;
				if (f.Initializer != null)
				{
					if (memberLocation != null)
					{
						variableInitializer.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), Roles.Assign), Roles.Assign);
					}
					variableInitializer.AddChild((Expression)f.Initializer.Accept(this), Roles.Expression);
				}
				fieldDeclaration.AddChild(variableInitializer, Roles.Variable);
				if (f.Declarators != null)
				{
					foreach (FieldDeclarator declarator in f.Declarators)
					{
						List<Location> locations = LocationsBag.GetLocations(declarator);
						if (locations != null)
						{
							fieldDeclaration.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Comma), Roles.Comma);
						}
						variableInitializer = new VariableInitializer();
						variableInitializer.AddChild(Identifier.Create(declarator.Name.Value, Convert(declarator.Name.Location)), Roles.Identifier);
						if (declarator.Initializer != null)
						{
							if (locations != null)
							{
								variableInitializer.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.Assign), Roles.Assign);
							}
							variableInitializer.AddChild((Expression)declarator.Initializer.Accept(this), Roles.Expression);
						}
						fieldDeclaration.AddChild(variableInitializer, Roles.Variable);
					}
				}
				if (memberLocation != null && memberLocation.Count > num)
				{
					fieldDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), Roles.Semicolon), Roles.Semicolon);
				}
				typeStack.Peek().AddChild(fieldDeclaration, Roles.TypeMemberRole);
			}

			public override void Visit(Const c)
			{
				LocationsBag.MemberLocations memberLocation = LocationsBag.GetMemberLocation(c);
				FieldDeclaration fieldDeclaration = new FieldDeclaration();
				AddAttributeSection(fieldDeclaration, c);
				AddModifiers(fieldDeclaration, memberLocation);
				if (memberLocation != null)
				{
					fieldDeclaration.AddChild(new CSharpModifierToken(Convert(memberLocation[0]), Modifiers.Const), EntityDeclaration.ModifierRole);
				}
				fieldDeclaration.AddChild(ConvertToType(c.TypeExpression), Roles.Type);
				VariableInitializer variableInitializer = new VariableInitializer();
				variableInitializer.AddChild(Identifier.Create(c.MemberName.Name, Convert(c.MemberName.Location)), Roles.Identifier);
				if (c.Initializer != null)
				{
					variableInitializer.AddChild(new CSharpTokenNode(Convert(c.Initializer.Location), Roles.Assign), Roles.Assign);
					variableInitializer.AddChild((Expression)c.Initializer.Accept(this), Roles.Expression);
				}
				fieldDeclaration.AddChild(variableInitializer, Roles.Variable);
				if (c.Declarators != null)
				{
					foreach (FieldDeclarator declarator in c.Declarators)
					{
						List<Location> locations = LocationsBag.GetLocations(declarator);
						if (locations != null)
						{
							fieldDeclaration.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Comma), Roles.Comma);
						}
						variableInitializer = new VariableInitializer();
						variableInitializer.AddChild(Identifier.Create(declarator.Name.Value, Convert(declarator.Name.Location)), Roles.Identifier);
						if (declarator.Initializer != null)
						{
							variableInitializer.AddChild(new CSharpTokenNode(Convert(declarator.Initializer.Location), Roles.Assign), Roles.Assign);
							variableInitializer.AddChild((Expression)declarator.Initializer.Accept(this), Roles.Expression);
						}
						fieldDeclaration.AddChild(variableInitializer, Roles.Variable);
					}
				}
				if (memberLocation != null)
				{
					fieldDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[1]), Roles.Semicolon), Roles.Semicolon);
				}
				typeStack.Peek().AddChild(fieldDeclaration, Roles.TypeMemberRole);
			}

			public override void Visit(Operator o)
			{
				OperatorDeclaration operatorDeclaration = new OperatorDeclaration();
				operatorDeclaration.OperatorType = (OperatorType)o.OperatorType;
				LocationsBag.MemberLocations memberLocation = LocationsBag.GetMemberLocation(o);
				AddAttributeSection(operatorDeclaration, o);
				AddModifiers(operatorDeclaration, memberLocation);
				if (o.OperatorType == Operator.OpType.Implicit)
				{
					if (memberLocation != null && memberLocation.Count > 0)
					{
						operatorDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[0]), OperatorDeclaration.ImplicitRole), OperatorDeclaration.ImplicitRole);
						if (memberLocation.Count > 1)
						{
							operatorDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[1]), OperatorDeclaration.OperatorKeywordRole), OperatorDeclaration.OperatorKeywordRole);
						}
					}
					operatorDeclaration.AddChild(ConvertToType(o.TypeExpression), Roles.Type);
				}
				else if (o.OperatorType == Operator.OpType.Explicit)
				{
					if (memberLocation != null && memberLocation.Count > 0)
					{
						operatorDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[0]), OperatorDeclaration.ExplicitRole), OperatorDeclaration.ExplicitRole);
						if (memberLocation.Count > 1)
						{
							operatorDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[1]), OperatorDeclaration.OperatorKeywordRole), OperatorDeclaration.OperatorKeywordRole);
						}
					}
					operatorDeclaration.AddChild(ConvertToType(o.TypeExpression), Roles.Type);
				}
				else
				{
					operatorDeclaration.AddChild(ConvertToType(o.TypeExpression), Roles.Type);
					if (memberLocation != null && memberLocation.Count > 0)
					{
						operatorDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[0]), OperatorDeclaration.OperatorKeywordRole), OperatorDeclaration.OperatorKeywordRole);
					}
					if (memberLocation != null && memberLocation.Count > 1)
					{
						TokenRole role = OperatorDeclaration.GetRole(operatorDeclaration.OperatorType);
						operatorDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[1]), role), role);
					}
				}
				if (memberLocation != null && memberLocation.Count > 2)
				{
					operatorDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[2]), Roles.LPar), Roles.LPar);
				}
				AddParameter(operatorDeclaration, o.ParameterInfo);
				if (memberLocation != null && memberLocation.Count > 3)
				{
					operatorDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[3]), Roles.RPar), Roles.RPar);
				}
				if (o.Block != null)
				{
					BlockStatement blockStatement = o.Block.Accept(this) as BlockStatement;
					if (blockStatement != null)
					{
						operatorDeclaration.AddChild(blockStatement, Roles.Body);
					}
				}
				else if (memberLocation != null && memberLocation.Count >= 5)
				{
					operatorDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[4]), Roles.Semicolon), Roles.Semicolon);
				}
				typeStack.Peek().AddChild(operatorDeclaration, Roles.TypeMemberRole);
			}

			public void AddAttributeSection(AstNode parent, Attributable a)
			{
				if (a != null && a.OptAttributes != null)
				{
					AddAttributeSection(parent, a.OptAttributes);
				}
			}

			public void AddAttributeSection(AstNode parent, Attributes attrs, Role<AttributeSection> role)
			{
				if (attrs != null)
				{
					foreach (List<ICSharpCode.NRefactory.MonoCSharp.Attribute> section in attrs.Sections)
					{
						AttributeSection attributeSection = ConvertAttributeSection(section);
						if (attributeSection != null)
						{
							parent.AddChild(attributeSection, role);
						}
					}
				}
			}

			public void AddAttributeSection(AstNode parent, Attributes attrs)
			{
				AddAttributeSection(parent, attrs, EntityDeclaration.AttributeRole);
			}

			public override void Visit(Indexer i)
			{
				IndexerDeclaration indexerDeclaration = new IndexerDeclaration();
				AddAttributeSection(indexerDeclaration, i);
				LocationsBag.MemberLocations memberLocation = LocationsBag.GetMemberLocation(i);
				AddModifiers(indexerDeclaration, memberLocation);
				indexerDeclaration.AddChild(ConvertToType(i.TypeExpression), Roles.Type);
				AddExplicitInterface(indexerDeclaration, i.MemberName);
				MemberName memberName = i.MemberName;
				indexerDeclaration.AddChild(new CSharpTokenNode(Convert(memberName.Location), IndexerDeclaration.ThisKeywordRole), IndexerDeclaration.ThisKeywordRole);
				if (memberLocation != null && memberLocation.Count > 0)
				{
					indexerDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[0]), Roles.LBracket), Roles.LBracket);
				}
				AddParameter(indexerDeclaration, i.ParameterInfo);
				if (memberLocation != null && memberLocation.Count > 1)
				{
					indexerDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[1]), Roles.RBracket), Roles.RBracket);
				}
				if (memberLocation != null && memberLocation.Count > 2)
				{
					indexerDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[2]), Roles.LBrace), Roles.LBrace);
				}
				if (i.Get != null)
				{
					Accessor accessor = new Accessor();
					LocationsBag.MemberLocations memberLocation2 = LocationsBag.GetMemberLocation(i.Get);
					AddAttributeSection(accessor, i.Get);
					AddModifiers(accessor, memberLocation2);
					if (memberLocation2 != null)
					{
						accessor.AddChild(new CSharpTokenNode(Convert(i.Get.Location), PropertyDeclaration.GetKeywordRole), PropertyDeclaration.GetKeywordRole);
					}
					if (i.Get.Block != null)
					{
						BlockStatement blockStatement = i.Get.Block.Accept(this) as BlockStatement;
						if (blockStatement != null)
						{
							accessor.AddChild(blockStatement, Roles.Body);
						}
					}
					else if (memberLocation2 != null && memberLocation2.Count > 0)
					{
						indexerDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation2[0]), Roles.Semicolon), Roles.Semicolon);
					}
					indexerDeclaration.AddChild(accessor, PropertyDeclaration.GetterRole);
				}
				if (i.Set != null)
				{
					Accessor accessor2 = new Accessor();
					LocationsBag.MemberLocations memberLocation3 = LocationsBag.GetMemberLocation(i.Set);
					AddAttributeSection(accessor2, i.Set);
					AddModifiers(accessor2, memberLocation3);
					if (memberLocation3 != null)
					{
						accessor2.AddChild(new CSharpTokenNode(Convert(i.Set.Location), PropertyDeclaration.SetKeywordRole), PropertyDeclaration.SetKeywordRole);
					}
					if (i.Set.Block != null)
					{
						BlockStatement blockStatement2 = i.Set.Block.Accept(this) as BlockStatement;
						if (blockStatement2 != null)
						{
							accessor2.AddChild(blockStatement2, Roles.Body);
						}
					}
					else if (memberLocation3 != null && memberLocation3.Count > 0)
					{
						indexerDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation3[0]), Roles.Semicolon), Roles.Semicolon);
					}
					indexerDeclaration.AddChild(accessor2, PropertyDeclaration.SetterRole);
				}
				if (memberLocation != null)
				{
					if (memberLocation.Count > 3)
					{
						indexerDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[3]), Roles.RBrace), Roles.RBrace);
					}
				}
				else
				{
					indexerDeclaration.AddChild(new ErrorNode(), Roles.Error);
				}
				typeStack.Peek().AddChild(indexerDeclaration, Roles.TypeMemberRole);
			}

			public override void Visit(Method m)
			{
				MethodDeclaration methodDeclaration = new MethodDeclaration();
				AddAttributeSection(methodDeclaration, m);
				LocationsBag.MemberLocations memberLocation = LocationsBag.GetMemberLocation(m);
				AddModifiers(methodDeclaration, memberLocation);
				methodDeclaration.AddChild(ConvertToType(m.TypeExpression), Roles.Type);
				AddExplicitInterface(methodDeclaration, m.MethodName);
				methodDeclaration.AddChild(Identifier.Create(m.MethodName.Name, Convert(m.Location)), Roles.Identifier);
				AddTypeParameters(methodDeclaration, m.MemberName);
				if (memberLocation != null && memberLocation.Count > 0)
				{
					methodDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[0]), Roles.LPar), Roles.LPar);
				}
				AddParameter(methodDeclaration, m.ParameterInfo);
				if (memberLocation != null && memberLocation.Count > 1)
				{
					methodDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[1]), Roles.RPar), Roles.RPar);
				}
				AddConstraints(methodDeclaration, m.CurrentTypeParameters);
				if (m.Block != null)
				{
					BlockStatement blockStatement = m.Block.Accept(this) as BlockStatement;
					if (blockStatement != null)
					{
						methodDeclaration.AddChild(blockStatement, Roles.Body);
					}
				}
				else if (memberLocation != null)
				{
					if (memberLocation.Count < 3)
					{
						methodDeclaration.AddChild(new ErrorNode(), Roles.Error);
					}
					else
					{
						methodDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[2]), Roles.Semicolon), Roles.Semicolon);
					}
				}
				typeStack.Peek().AddChild(methodDeclaration, Roles.TypeMemberRole);
			}

			static ConversionVisitor()
			{
				modifierTable = new Dictionary<ICSharpCode.NRefactory.MonoCSharp.Modifiers, Modifiers>();
				modifierTable[ICSharpCode.NRefactory.MonoCSharp.Modifiers.NEW] = Modifiers.New;
				modifierTable[ICSharpCode.NRefactory.MonoCSharp.Modifiers.PUBLIC] = Modifiers.Public;
				modifierTable[ICSharpCode.NRefactory.MonoCSharp.Modifiers.PROTECTED] = Modifiers.Protected;
				modifierTable[ICSharpCode.NRefactory.MonoCSharp.Modifiers.PRIVATE] = Modifiers.Private;
				modifierTable[ICSharpCode.NRefactory.MonoCSharp.Modifiers.INTERNAL] = Modifiers.Internal;
				modifierTable[ICSharpCode.NRefactory.MonoCSharp.Modifiers.ABSTRACT] = Modifiers.Abstract;
				modifierTable[ICSharpCode.NRefactory.MonoCSharp.Modifiers.VIRTUAL] = Modifiers.Virtual;
				modifierTable[ICSharpCode.NRefactory.MonoCSharp.Modifiers.SEALED] = Modifiers.Sealed;
				modifierTable[ICSharpCode.NRefactory.MonoCSharp.Modifiers.STATIC] = Modifiers.Static;
				modifierTable[ICSharpCode.NRefactory.MonoCSharp.Modifiers.OVERRIDE] = Modifiers.Override;
				modifierTable[ICSharpCode.NRefactory.MonoCSharp.Modifiers.READONLY] = Modifiers.Readonly;
				modifierTable[ICSharpCode.NRefactory.MonoCSharp.Modifiers.PARTIAL] = Modifiers.Partial;
				modifierTable[ICSharpCode.NRefactory.MonoCSharp.Modifiers.EXTERN] = Modifiers.Extern;
				modifierTable[ICSharpCode.NRefactory.MonoCSharp.Modifiers.VOLATILE] = Modifiers.Volatile;
				modifierTable[ICSharpCode.NRefactory.MonoCSharp.Modifiers.UNSAFE] = Modifiers.Unsafe;
				modifierTable[ICSharpCode.NRefactory.MonoCSharp.Modifiers.ASYNC] = Modifiers.Async;
				keywordTable = new string[255];
				for (int i = 0; i < keywordTable.Length; i++)
				{
					keywordTable[i] = "unknown";
				}
				keywordTable[30] = "void";
				keywordTable[18] = "string";
				keywordTable[7] = "int";
				keywordTable[16] = "object";
				keywordTable[11] = "float";
				keywordTable[12] = "double";
				keywordTable[9] = "long";
				keywordTable[2] = "byte";
				keywordTable[8] = "uint";
				keywordTable[10] = "ulong";
				keywordTable[5] = "short";
				keywordTable[6] = "ushort";
				keywordTable[3] = "sbyte";
				keywordTable[13] = "decimal";
				keywordTable[4] = "char";
				keywordTable[1] = "bool";
			}

			private static void AddModifiers(EntityDeclaration parent, LocationsBag.MemberLocations location)
			{
				if (location != null && location.Modifiers != null)
				{
					foreach (Tuple<ICSharpCode.NRefactory.MonoCSharp.Modifiers, Location> modifier in location.Modifiers)
					{
						if (!modifierTable.TryGetValue(modifier.Item1, out Modifiers value))
						{
							Console.WriteLine("modifier " + modifier.Item1 + " can't be converted,");
						}
						parent.AddChild(new CSharpModifierToken(Convert(modifier.Item2), value), EntityDeclaration.ModifierRole);
					}
				}
			}

			public override void Visit(Property p)
			{
				PropertyDeclaration propertyDeclaration = new PropertyDeclaration();
				AddAttributeSection(propertyDeclaration, p);
				LocationsBag.MemberLocations memberLocation = LocationsBag.GetMemberLocation(p);
				AddModifiers(propertyDeclaration, memberLocation);
				propertyDeclaration.AddChild(ConvertToType(p.TypeExpression), Roles.Type);
				AddExplicitInterface(propertyDeclaration, p.MemberName);
				propertyDeclaration.AddChild(Identifier.Create(p.MemberName.Name, Convert(p.Location)), Roles.Identifier);
				if (memberLocation != null && memberLocation.Count > 0)
				{
					propertyDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[0]), Roles.LBrace), Roles.LBrace);
				}
				Accessor accessor = null;
				if (p.Get != null)
				{
					accessor = new Accessor();
					AddAttributeSection(accessor, p.Get);
					LocationsBag.MemberLocations memberLocation2 = LocationsBag.GetMemberLocation(p.Get);
					AddModifiers(accessor, memberLocation2);
					accessor.AddChild(new CSharpTokenNode(Convert(p.Get.Location), PropertyDeclaration.GetKeywordRole), PropertyDeclaration.GetKeywordRole);
					if (p.Get.Block != null)
					{
						BlockStatement blockStatement = p.Get.Block.Accept(this) as BlockStatement;
						if (blockStatement != null)
						{
							accessor.AddChild(blockStatement, Roles.Body);
						}
					}
					else if (memberLocation2 != null && memberLocation2.Count > 0)
					{
						accessor.AddChild(new CSharpTokenNode(Convert(memberLocation2[0]), Roles.Semicolon), Roles.Semicolon);
					}
				}
				Accessor accessor2 = null;
				if (p.Set != null)
				{
					accessor2 = new Accessor();
					AddAttributeSection(accessor2, p.Set);
					LocationsBag.MemberLocations memberLocation3 = LocationsBag.GetMemberLocation(p.Set);
					AddModifiers(accessor2, memberLocation3);
					accessor2.AddChild(new CSharpTokenNode(Convert(p.Set.Location), PropertyDeclaration.SetKeywordRole), PropertyDeclaration.SetKeywordRole);
					if (p.Set.Block != null)
					{
						BlockStatement blockStatement2 = p.Set.Block.Accept(this) as BlockStatement;
						if (blockStatement2 != null)
						{
							accessor2.AddChild(blockStatement2, Roles.Body);
						}
					}
					else if (memberLocation3 != null && memberLocation3.Count > 0)
					{
						accessor2.AddChild(new CSharpTokenNode(Convert(memberLocation3[0]), Roles.Semicolon), Roles.Semicolon);
					}
				}
				if (accessor != null && accessor2 != null)
				{
					if (accessor.StartLocation < accessor2.StartLocation)
					{
						propertyDeclaration.AddChild(accessor, PropertyDeclaration.GetterRole);
						propertyDeclaration.AddChild(accessor2, PropertyDeclaration.SetterRole);
					}
					else
					{
						propertyDeclaration.AddChild(accessor2, PropertyDeclaration.SetterRole);
						propertyDeclaration.AddChild(accessor, PropertyDeclaration.GetterRole);
					}
				}
				else
				{
					if (accessor != null)
					{
						propertyDeclaration.AddChild(accessor, PropertyDeclaration.GetterRole);
					}
					if (accessor2 != null)
					{
						propertyDeclaration.AddChild(accessor2, PropertyDeclaration.SetterRole);
					}
				}
				if (memberLocation != null && memberLocation.Count > 1)
				{
					propertyDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[1]), Roles.RBrace), Roles.RBrace);
				}
				else
				{
					propertyDeclaration.AddChild(new ErrorNode(), Roles.Error);
				}
				typeStack.Peek().AddChild(propertyDeclaration, Roles.TypeMemberRole);
			}

			public override void Visit(Constructor c)
			{
				ConstructorDeclaration constructorDeclaration = new ConstructorDeclaration();
				AddAttributeSection(constructorDeclaration, c);
				LocationsBag.MemberLocations memberLocation = LocationsBag.GetMemberLocation(c);
				AddModifiers(constructorDeclaration, memberLocation);
				constructorDeclaration.AddChild(Identifier.Create(c.MemberName.Name, Convert(c.MemberName.Location)), Roles.Identifier);
				if (memberLocation != null && memberLocation.Count > 0)
				{
					constructorDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[0]), Roles.LPar), Roles.LPar);
				}
				AddParameter(constructorDeclaration, c.ParameterInfo);
				if (memberLocation != null && memberLocation.Count > 1)
				{
					constructorDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[1]), Roles.RPar), Roles.RPar);
				}
				if (c.Initializer != null)
				{
					ConstructorInitializer constructorInitializer = new ConstructorInitializer();
					constructorInitializer.ConstructorInitializerType = ((c.Initializer is ConstructorBaseInitializer) ? ConstructorInitializerType.Base : ConstructorInitializerType.This);
					List<Location> locations = LocationsBag.GetLocations(c.Initializer);
					if (locations != null)
					{
						constructorDeclaration.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Colon), Roles.Colon);
					}
					if (locations != null && locations.Count > 1)
					{
						TokenRole role = (constructorInitializer.ConstructorInitializerType == ConstructorInitializerType.This) ? ConstructorInitializer.ThisKeywordRole : ConstructorInitializer.BaseKeywordRole;
						constructorInitializer.AddChild(new CSharpTokenNode(Convert(c.Initializer.Location), role), role);
						constructorInitializer.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.LPar), Roles.LPar);
						AddArguments(constructorInitializer, c.Initializer.Arguments);
						constructorInitializer.AddChild(new CSharpTokenNode(Convert(locations[2]), Roles.RPar), Roles.RPar);
						constructorDeclaration.AddChild(constructorInitializer, ConstructorDeclaration.InitializerRole);
					}
				}
				if (c.Block != null)
				{
					BlockStatement blockStatement = c.Block.Accept(this) as BlockStatement;
					if (blockStatement != null)
					{
						constructorDeclaration.AddChild(blockStatement, Roles.Body);
					}
				}
				typeStack.Peek().AddChild(constructorDeclaration, Roles.TypeMemberRole);
			}

			public override void Visit(Destructor d)
			{
				DestructorDeclaration destructorDeclaration = new DestructorDeclaration();
				AddAttributeSection(destructorDeclaration, d);
				LocationsBag.MemberLocations memberLocation = LocationsBag.GetMemberLocation(d);
				AddModifiers(destructorDeclaration, memberLocation);
				if (memberLocation != null && memberLocation.Count > 0)
				{
					destructorDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[0]), DestructorDeclaration.TildeRole), DestructorDeclaration.TildeRole);
				}
				destructorDeclaration.AddChild(Identifier.Create(d.Identifier, Convert(d.MemberName.Location)), Roles.Identifier);
				if (memberLocation != null && memberLocation.Count > 1)
				{
					destructorDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[1]), Roles.LPar), Roles.LPar);
					if (memberLocation.Count > 2)
					{
						destructorDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[2]), Roles.RPar), Roles.RPar);
					}
				}
				if (d.Block != null)
				{
					BlockStatement blockStatement = d.Block.Accept(this) as BlockStatement;
					if (blockStatement != null)
					{
						destructorDeclaration.AddChild(blockStatement, Roles.Body);
					}
				}
				typeStack.Peek().AddChild(destructorDeclaration, Roles.TypeMemberRole);
			}

			public override void Visit(EventField e)
			{
				EventDeclaration eventDeclaration = new EventDeclaration();
				AddAttributeSection(eventDeclaration, e);
				LocationsBag.MemberLocations memberLocation = LocationsBag.GetMemberLocation(e);
				int num = 0;
				AddModifiers(eventDeclaration, memberLocation);
				if (memberLocation != null && memberLocation.Count > 0)
				{
					eventDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), EventDeclaration.EventKeywordRole), EventDeclaration.EventKeywordRole);
				}
				eventDeclaration.AddChild(ConvertToType(e.TypeExpression), Roles.Type);
				VariableInitializer variableInitializer = new VariableInitializer();
				variableInitializer.AddChild(Identifier.Create(e.MemberName.Name, Convert(e.MemberName.Location)), Roles.Identifier);
				if (e.Initializer != null)
				{
					if (memberLocation != null && memberLocation.Count > num)
					{
						variableInitializer.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), Roles.Assign), Roles.Assign);
					}
					variableInitializer.AddChild((Expression)e.Initializer.Accept(this), Roles.Expression);
				}
				eventDeclaration.AddChild(variableInitializer, Roles.Variable);
				if (e.Declarators != null)
				{
					foreach (FieldDeclarator declarator in e.Declarators)
					{
						List<Location> locations = LocationsBag.GetLocations(declarator);
						if (locations != null)
						{
							eventDeclaration.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Comma), Roles.Comma);
						}
						variableInitializer = new VariableInitializer();
						variableInitializer.AddChild(Identifier.Create(declarator.Name.Value, Convert(declarator.Name.Location)), Roles.Identifier);
						if (declarator.Initializer != null)
						{
							if (locations != null)
							{
								variableInitializer.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.Assign), Roles.Assign);
							}
							variableInitializer.AddChild((Expression)declarator.Initializer.Accept(this), Roles.Expression);
						}
						eventDeclaration.AddChild(variableInitializer, Roles.Variable);
					}
				}
				if (memberLocation != null && memberLocation.Count > num)
				{
					eventDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[num++]), Roles.Semicolon), Roles.Semicolon);
				}
				typeStack.Peek().AddChild(eventDeclaration, Roles.TypeMemberRole);
			}

			private void AddExplicitInterface(AstNode parent, MemberName memberName)
			{
				if (memberName != null && memberName.ExplicitInterface != null)
				{
					parent.AddChild(ConvertToType(memberName.ExplicitInterface), EntityDeclaration.PrivateImplementationTypeRole);
					List<Location> locations = LocationsBag.GetLocations(memberName.ExplicitInterface);
					if (locations != null)
					{
						parent.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Dot), Roles.Dot);
					}
				}
			}

			public override void Visit(EventProperty ep)
			{
				CustomEventDeclaration customEventDeclaration = new CustomEventDeclaration();
				AddAttributeSection(customEventDeclaration, ep);
				LocationsBag.MemberLocations memberLocation = LocationsBag.GetMemberLocation(ep);
				AddModifiers(customEventDeclaration, memberLocation);
				if (memberLocation != null && memberLocation.Count > 0)
				{
					customEventDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[0]), CustomEventDeclaration.EventKeywordRole), CustomEventDeclaration.EventKeywordRole);
				}
				customEventDeclaration.AddChild(ConvertToType(ep.TypeExpression), Roles.Type);
				AddExplicitInterface(customEventDeclaration, ep.MemberName);
				customEventDeclaration.AddChild(Identifier.Create(ep.MemberName.Name, Convert(ep.Location)), Roles.Identifier);
				if (memberLocation != null && memberLocation.Count >= 2)
				{
					customEventDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[1]), Roles.LBrace), Roles.LBrace);
				}
				if (ep.Add != null)
				{
					Accessor accessor = new Accessor();
					AddAttributeSection(accessor, ep.Add);
					LocationsBag.MemberLocations memberLocation2 = LocationsBag.GetMemberLocation(ep.Add);
					AddModifiers(accessor, memberLocation2);
					accessor.AddChild(new CSharpTokenNode(Convert(ep.Add.Location), CustomEventDeclaration.AddKeywordRole), CustomEventDeclaration.AddKeywordRole);
					if (ep.Add.Block != null)
					{
						BlockStatement blockStatement = ep.Add.Block.Accept(this) as BlockStatement;
						if (blockStatement != null)
						{
							accessor.AddChild(blockStatement, Roles.Body);
						}
					}
					customEventDeclaration.AddChild(accessor, CustomEventDeclaration.AddAccessorRole);
				}
				if (ep.Remove != null)
				{
					Accessor accessor2 = new Accessor();
					AddAttributeSection(accessor2, ep.Remove);
					LocationsBag.MemberLocations memberLocation3 = LocationsBag.GetMemberLocation(ep.Remove);
					AddModifiers(accessor2, memberLocation3);
					accessor2.AddChild(new CSharpTokenNode(Convert(ep.Remove.Location), CustomEventDeclaration.RemoveKeywordRole), CustomEventDeclaration.RemoveKeywordRole);
					if (ep.Remove.Block != null)
					{
						BlockStatement blockStatement2 = ep.Remove.Block.Accept(this) as BlockStatement;
						if (blockStatement2 != null)
						{
							accessor2.AddChild(blockStatement2, Roles.Body);
						}
					}
					customEventDeclaration.AddChild(accessor2, CustomEventDeclaration.RemoveAccessorRole);
				}
				if (memberLocation != null && memberLocation.Count >= 3)
				{
					customEventDeclaration.AddChild(new CSharpTokenNode(Convert(memberLocation[2]), Roles.RBrace), Roles.RBrace);
				}
				else
				{
					customEventDeclaration.AddChild(new ErrorNode(), Roles.Error);
				}
				typeStack.Peek().AddChild(customEventDeclaration, Roles.TypeMemberRole);
			}

			public override object Visit(ICSharpCode.NRefactory.MonoCSharp.Statement stmt)
			{
				Console.WriteLine("unknown statement:" + stmt);
				return null;
			}

			public override object Visit(BlockVariable blockVariableDeclaration)
			{
				VariableDeclarationStatement variableDeclarationStatement = new VariableDeclarationStatement();
				variableDeclarationStatement.AddChild(ConvertToType(blockVariableDeclaration.TypeExpression), Roles.Type);
				VariableInitializer variableInitializer = new VariableInitializer();
				List<Location> locations = LocationsBag.GetLocations(blockVariableDeclaration);
				variableInitializer.AddChild(Identifier.Create(blockVariableDeclaration.Variable.Name, Convert(blockVariableDeclaration.Variable.Location)), Roles.Identifier);
				if (blockVariableDeclaration.Initializer != null)
				{
					if (locations != null && locations.Count > 0)
					{
						variableInitializer.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Assign), Roles.Assign);
					}
					variableInitializer.AddChild((Expression)blockVariableDeclaration.Initializer.Accept(this), Roles.Expression);
				}
				variableDeclarationStatement.AddChild(variableInitializer, Roles.Variable);
				if (blockVariableDeclaration.Declarators != null)
				{
					foreach (BlockVariableDeclarator declarator in blockVariableDeclaration.Declarators)
					{
						List<Location> locations2 = LocationsBag.GetLocations(declarator);
						VariableInitializer variableInitializer2 = new VariableInitializer();
						if (locations2 != null && locations2.Count > 0)
						{
							variableDeclarationStatement.AddChild(new CSharpTokenNode(Convert(locations2[0]), Roles.Comma), Roles.Comma);
						}
						variableInitializer2.AddChild(Identifier.Create(declarator.Variable.Name, Convert(declarator.Variable.Location)), Roles.Identifier);
						if (declarator.Initializer != null)
						{
							if (locations2 != null && locations2.Count > 1)
							{
								variableInitializer2.AddChild(new CSharpTokenNode(Convert(locations2[1]), Roles.Assign), Roles.Assign);
							}
							variableInitializer2.AddChild((Expression)declarator.Initializer.Accept(this), Roles.Expression);
						}
						variableDeclarationStatement.AddChild(variableInitializer2, Roles.Variable);
					}
				}
				if (locations != null && (blockVariableDeclaration.Initializer == null || locations.Count > 1))
				{
					variableDeclarationStatement.AddChild(new CSharpTokenNode(Convert(locations[locations.Count - 1]), Roles.Semicolon), Roles.Semicolon);
				}
				return variableDeclarationStatement;
			}

			public override object Visit(BlockConstant blockConstantDeclaration)
			{
				VariableDeclarationStatement variableDeclarationStatement = new VariableDeclarationStatement();
				List<Location> locations = LocationsBag.GetLocations(blockConstantDeclaration);
				if (locations != null && locations.Count > 0)
				{
					variableDeclarationStatement.AddChild(new CSharpModifierToken(Convert(locations[0]), Modifiers.Const), VariableDeclarationStatement.ModifierRole);
				}
				variableDeclarationStatement.AddChild(ConvertToType(blockConstantDeclaration.TypeExpression), Roles.Type);
				VariableInitializer variableInitializer = new VariableInitializer();
				variableInitializer.AddChild(Identifier.Create(blockConstantDeclaration.Variable.Name, Convert(blockConstantDeclaration.Variable.Location)), Roles.Identifier);
				if (blockConstantDeclaration.Initializer != null)
				{
					if (locations != null && locations.Count > 1)
					{
						variableInitializer.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.Assign), Roles.Assign);
					}
					variableInitializer.AddChild((Expression)blockConstantDeclaration.Initializer.Accept(this), Roles.Expression);
				}
				variableDeclarationStatement.AddChild(variableInitializer, Roles.Variable);
				if (blockConstantDeclaration.Declarators != null)
				{
					foreach (BlockVariableDeclarator declarator in blockConstantDeclaration.Declarators)
					{
						List<Location> locations2 = LocationsBag.GetLocations(declarator);
						VariableInitializer variableInitializer2 = new VariableInitializer();
						variableInitializer2.AddChild(Identifier.Create(declarator.Variable.Name, Convert(declarator.Variable.Location)), Roles.Identifier);
						if (declarator.Initializer != null)
						{
							if (locations2 != null)
							{
								variableInitializer2.AddChild(new CSharpTokenNode(Convert(locations2[0]), Roles.Assign), Roles.Assign);
							}
							variableInitializer2.AddChild((Expression)declarator.Initializer.Accept(this), Roles.Expression);
							if (locations2 != null && locations2.Count > 1)
							{
								variableDeclarationStatement.AddChild(new CSharpTokenNode(Convert(locations2[1]), Roles.Comma), Roles.Comma);
							}
						}
						else if (locations2 != null && locations2.Count > 0)
						{
							variableDeclarationStatement.AddChild(new CSharpTokenNode(Convert(locations2[0]), Roles.Comma), Roles.Comma);
						}
						variableDeclarationStatement.AddChild(variableInitializer2, Roles.Variable);
					}
				}
				if (locations != null)
				{
					variableDeclarationStatement.AddChild(new CSharpTokenNode(Convert(locations[locations.Count - 1]), Roles.Semicolon), Roles.Semicolon);
				}
				else
				{
					variableDeclarationStatement.AddChild(new ErrorNode(), Roles.Error);
				}
				return variableDeclarationStatement;
			}

			public override object Visit(ICSharpCode.NRefactory.MonoCSharp.EmptyStatement emptyStatement)
			{
				return new EmptyStatement
				{
					Location = Convert(emptyStatement.loc)
				};
			}

			public override object Visit(ICSharpCode.NRefactory.MonoCSharp.ErrorExpression errorExpression)
			{
				return new ErrorExpression(Convert(errorExpression.Location));
			}

			public override object Visit(EmptyExpressionStatement emptyExpressionStatement)
			{
				throw new NotSupportedException();
			}

			public override object Visit(If ifStatement)
			{
				IfElseStatement ifElseStatement = new IfElseStatement();
				List<Location> locations = LocationsBag.GetLocations(ifStatement);
				ifElseStatement.AddChild(new CSharpTokenNode(Convert(ifStatement.loc), IfElseStatement.IfKeywordRole), IfElseStatement.IfKeywordRole);
				if (locations != null)
				{
					ifElseStatement.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.LPar), Roles.LPar);
				}
				if (ifStatement.Expr != null)
				{
					ifElseStatement.AddChild((Expression)ifStatement.Expr.Accept(this), Roles.Condition);
				}
				if (locations != null && locations.Count > 1)
				{
					ifElseStatement.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.RPar), Roles.RPar);
				}
				if (ifStatement.TrueStatement != null)
				{
					ifElseStatement.AddChild((Statement)ifStatement.TrueStatement.Accept(this), IfElseStatement.TrueRole);
				}
				if (ifStatement.FalseStatement != null)
				{
					if (locations != null && locations.Count > 2)
					{
						ifElseStatement.AddChild(new CSharpTokenNode(Convert(locations[2]), IfElseStatement.ElseKeywordRole), IfElseStatement.ElseKeywordRole);
					}
					ifElseStatement.AddChild((Statement)ifStatement.FalseStatement.Accept(this), IfElseStatement.FalseRole);
				}
				return ifElseStatement;
			}

			public override object Visit(Do doStatement)
			{
				DoWhileStatement doWhileStatement = new DoWhileStatement();
				List<Location> locations = LocationsBag.GetLocations(doStatement);
				doWhileStatement.AddChild(new CSharpTokenNode(Convert(doStatement.loc), DoWhileStatement.DoKeywordRole), DoWhileStatement.DoKeywordRole);
				if (doStatement.Statement != null)
				{
					doWhileStatement.AddChild((Statement)doStatement.Statement.Accept(this), Roles.EmbeddedStatement);
				}
				if (locations != null)
				{
					doWhileStatement.AddChild(new CSharpTokenNode(Convert(locations[0]), DoWhileStatement.WhileKeywordRole), DoWhileStatement.WhileKeywordRole);
				}
				if (locations != null && locations.Count > 1)
				{
					doWhileStatement.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.LPar), Roles.LPar);
				}
				if (doStatement.expr != null)
				{
					doWhileStatement.AddChild((Expression)doStatement.expr.Accept(this), Roles.Condition);
				}
				if (locations != null && locations.Count > 2)
				{
					doWhileStatement.AddChild(new CSharpTokenNode(Convert(locations[2]), Roles.RPar), Roles.RPar);
					if (locations.Count > 3)
					{
						doWhileStatement.AddChild(new CSharpTokenNode(Convert(locations[3]), Roles.Semicolon), Roles.Semicolon);
					}
				}
				return doWhileStatement;
			}

			public override object Visit(While whileStatement)
			{
				WhileStatement whileStatement2 = new WhileStatement();
				List<Location> locations = LocationsBag.GetLocations(whileStatement);
				whileStatement2.AddChild(new CSharpTokenNode(Convert(whileStatement.loc), WhileStatement.WhileKeywordRole), WhileStatement.WhileKeywordRole);
				if (locations != null)
				{
					whileStatement2.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.LPar), Roles.LPar);
				}
				if (whileStatement.expr != null)
				{
					whileStatement2.AddChild((Expression)whileStatement.expr.Accept(this), Roles.Condition);
				}
				if (locations != null && locations.Count > 1)
				{
					whileStatement2.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.RPar), Roles.RPar);
				}
				if (whileStatement.Statement != null)
				{
					whileStatement2.AddChild((Statement)whileStatement.Statement.Accept(this), Roles.EmbeddedStatement);
				}
				return whileStatement2;
			}

			private void AddStatementOrList(ForStatement forStatement, ICSharpCode.NRefactory.MonoCSharp.Statement init, Role<Statement> role)
			{
				if (init != null)
				{
					StatementList statementList = init as StatementList;
					if (statementList != null)
					{
						foreach (ICSharpCode.NRefactory.MonoCSharp.Statement statement in statementList.Statements)
						{
							forStatement.AddChild((Statement)statement.Accept(this), role);
						}
					}
					else if (!(init is ICSharpCode.NRefactory.MonoCSharp.EmptyStatement))
					{
						forStatement.AddChild((Statement)init.Accept(this), role);
					}
				}
			}

			public override object Visit(For forStatement)
			{
				ForStatement forStatement2 = new ForStatement();
				List<Location> locations = LocationsBag.GetLocations(forStatement);
				forStatement2.AddChild(new CSharpTokenNode(Convert(forStatement.loc), ForStatement.ForKeywordRole), ForStatement.ForKeywordRole);
				if (locations != null)
				{
					forStatement2.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.LPar), Roles.LPar);
				}
				AddStatementOrList(forStatement2, forStatement.Initializer, ForStatement.InitializerRole);
				if (locations != null && locations.Count > 1)
				{
					forStatement2.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.Semicolon), Roles.Semicolon);
				}
				if (forStatement.Condition != null)
				{
					forStatement2.AddChild((Expression)forStatement.Condition.Accept(this), Roles.Condition);
				}
				if (locations != null && locations.Count >= 3)
				{
					forStatement2.AddChild(new CSharpTokenNode(Convert(locations[2]), Roles.Semicolon), Roles.Semicolon);
				}
				AddStatementOrList(forStatement2, forStatement.Iterator, ForStatement.IteratorRole);
				if (locations != null && locations.Count >= 4)
				{
					forStatement2.AddChild(new CSharpTokenNode(Convert(locations[3]), Roles.RPar), Roles.RPar);
				}
				if (forStatement.Statement != null)
				{
					forStatement2.AddChild((Statement)forStatement.Statement.Accept(this), Roles.EmbeddedStatement);
				}
				return forStatement2;
			}

			public override object Visit(StatementExpression statementExpression)
			{
				ExpressionStatement expressionStatement = new ExpressionStatement();
				Expression expression = statementExpression.Expr.Accept(this) as Expression;
				if (expression != null)
				{
					expressionStatement.AddChild(expression, Roles.Expression);
				}
				List<Location> locations = LocationsBag.GetLocations(statementExpression);
				if (locations != null)
				{
					expressionStatement.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Semicolon), Roles.Semicolon);
				}
				return expressionStatement;
			}

			public override object Visit(StatementErrorExpression errorStatement)
			{
				ExpressionStatement expressionStatement = new ExpressionStatement();
				Expression expression = errorStatement.Expr.Accept(this) as Expression;
				if (expression != null)
				{
					expressionStatement.AddChild(expression, Roles.Expression);
				}
				List<Location> locations = LocationsBag.GetLocations(errorStatement);
				if (locations != null)
				{
					expressionStatement.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Semicolon), Roles.Semicolon);
				}
				return expressionStatement;
			}

			public override object Visit(InvalidStatementExpression invalidStatementExpression)
			{
				ExpressionStatement expressionStatement = new ExpressionStatement();
				if (invalidStatementExpression.Expression == null)
				{
					return expressionStatement;
				}
				Expression expression = invalidStatementExpression.Expression.Accept(this) as Expression;
				if (expression != null)
				{
					expressionStatement.AddChild(expression, Roles.Expression);
				}
				List<Location> locations = LocationsBag.GetLocations(invalidStatementExpression);
				if (locations != null)
				{
					expressionStatement.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Semicolon), Roles.Semicolon);
				}
				return expressionStatement;
			}

			public override object Visit(Return returnStatement)
			{
				ReturnStatement returnStatement2 = new ReturnStatement();
				returnStatement2.AddChild(new CSharpTokenNode(Convert(returnStatement.loc), ReturnStatement.ReturnKeywordRole), ReturnStatement.ReturnKeywordRole);
				if (returnStatement.Expr != null)
				{
					returnStatement2.AddChild((Expression)returnStatement.Expr.Accept(this), Roles.Expression);
				}
				List<Location> locations = LocationsBag.GetLocations(returnStatement);
				if (locations != null)
				{
					returnStatement2.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Semicolon), Roles.Semicolon);
				}
				return returnStatement2;
			}

			public override object Visit(Goto gotoStatement)
			{
				GotoStatement gotoStatement2 = new GotoStatement();
				List<Location> locations = LocationsBag.GetLocations(gotoStatement);
				gotoStatement2.AddChild(new CSharpTokenNode(Convert(gotoStatement.loc), GotoStatement.GotoKeywordRole), GotoStatement.GotoKeywordRole);
				TextLocation location = (locations != null) ? Convert(locations[0]) : TextLocation.Empty;
				gotoStatement2.AddChild(Identifier.Create(gotoStatement.Target, location), Roles.Identifier);
				if (locations != null && locations.Count > 1)
				{
					gotoStatement2.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.Semicolon), Roles.Semicolon);
				}
				return gotoStatement2;
			}

			public override object Visit(LabeledStatement labeledStatement)
			{
				LabelStatement labelStatement = new LabelStatement();
				labelStatement.AddChild(Identifier.Create(labeledStatement.Name, Convert(labeledStatement.loc)), Roles.Identifier);
				List<Location> locations = LocationsBag.GetLocations(labeledStatement);
				if (locations != null)
				{
					labelStatement.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Colon), Roles.Colon);
				}
				return labelStatement;
			}

			public override object Visit(GotoDefault gotoDefault)
			{
				GotoDefaultStatement gotoDefaultStatement = new GotoDefaultStatement();
				gotoDefaultStatement.AddChild(new CSharpTokenNode(Convert(gotoDefault.loc), GotoDefaultStatement.GotoKeywordRole), GotoDefaultStatement.GotoKeywordRole);
				List<Location> locations = LocationsBag.GetLocations(gotoDefault);
				if (locations != null)
				{
					gotoDefaultStatement.AddChild(new CSharpTokenNode(Convert(locations[0]), GotoDefaultStatement.DefaultKeywordRole), GotoDefaultStatement.DefaultKeywordRole);
					if (locations.Count > 1)
					{
						gotoDefaultStatement.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.Semicolon), Roles.Semicolon);
					}
				}
				return gotoDefaultStatement;
			}

			public override object Visit(GotoCase gotoCase)
			{
				GotoCaseStatement gotoCaseStatement = new GotoCaseStatement();
				gotoCaseStatement.AddChild(new CSharpTokenNode(Convert(gotoCase.loc), GotoCaseStatement.GotoKeywordRole), GotoCaseStatement.GotoKeywordRole);
				List<Location> locations = LocationsBag.GetLocations(gotoCase);
				if (locations != null)
				{
					gotoCaseStatement.AddChild(new CSharpTokenNode(Convert(locations[0]), GotoCaseStatement.CaseKeywordRole), GotoCaseStatement.CaseKeywordRole);
				}
				if (gotoCase.Expr != null)
				{
					gotoCaseStatement.AddChild((Expression)gotoCase.Expr.Accept(this), Roles.Expression);
				}
				if (locations != null && locations.Count > 1)
				{
					gotoCaseStatement.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.Semicolon), Roles.Semicolon);
				}
				return gotoCaseStatement;
			}

			public override object Visit(Throw throwStatement)
			{
				ThrowStatement throwStatement2 = new ThrowStatement();
				List<Location> locations = LocationsBag.GetLocations(throwStatement);
				throwStatement2.AddChild(new CSharpTokenNode(Convert(throwStatement.loc), ThrowStatement.ThrowKeywordRole), ThrowStatement.ThrowKeywordRole);
				if (throwStatement.Expr != null)
				{
					throwStatement2.AddChild((Expression)throwStatement.Expr.Accept(this), Roles.Expression);
				}
				if (locations != null)
				{
					throwStatement2.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Semicolon), Roles.Semicolon);
				}
				return throwStatement2;
			}

			public override object Visit(Break breakStatement)
			{
				BreakStatement breakStatement2 = new BreakStatement();
				List<Location> locations = LocationsBag.GetLocations(breakStatement);
				breakStatement2.AddChild(new CSharpTokenNode(Convert(breakStatement.loc), BreakStatement.BreakKeywordRole), BreakStatement.BreakKeywordRole);
				if (locations != null)
				{
					breakStatement2.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Semicolon), Roles.Semicolon);
				}
				return breakStatement2;
			}

			public override object Visit(Continue continueStatement)
			{
				ContinueStatement continueStatement2 = new ContinueStatement();
				List<Location> locations = LocationsBag.GetLocations(continueStatement);
				continueStatement2.AddChild(new CSharpTokenNode(Convert(continueStatement.loc), ContinueStatement.ContinueKeywordRole), ContinueStatement.ContinueKeywordRole);
				if (locations != null)
				{
					continueStatement2.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Semicolon), Roles.Semicolon);
				}
				return continueStatement2;
			}

			public static bool IsLower(Location left, Location right)
			{
				if (left.Row >= right.Row)
				{
					if (left.Row == right.Row)
					{
						return left.Column < right.Column;
					}
					return false;
				}
				return true;
			}

			public UsingStatement CreateUsingStatement(Block blockStatement)
			{
				UsingStatement usingStatement = new UsingStatement();
				ICSharpCode.NRefactory.MonoCSharp.Statement statement = blockStatement.Statements[0];
				Using @using = statement as Using;
				if (@using != null)
				{
					usingStatement.AddChild(new CSharpTokenNode(Convert(@using.loc), UsingStatement.UsingKeywordRole), UsingStatement.UsingKeywordRole);
					usingStatement.AddChild(new CSharpTokenNode(Convert(blockStatement.StartLocation), Roles.LPar), Roles.LPar);
					if (@using.Variables != null)
					{
						VariableInitializer variableInitializer = new VariableInitializer
						{
							NameToken = Identifier.Create(@using.Variables.Variable.Name, Convert(@using.Variables.Variable.Location))
						};
						List<Location> locations = LocationsBag.GetLocations(@using.Variables);
						if (locations != null)
						{
							variableInitializer.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Assign), Roles.Assign);
						}
						if (@using.Variables.Initializer != null)
						{
							variableInitializer.Initializer = (@using.Variables.Initializer.Accept(this) as Expression);
						}
						VariableDeclarationStatement variableDeclarationStatement = new VariableDeclarationStatement
						{
							Type = ConvertToType(@using.Variables.TypeExpression),
							Variables = 
							{
								variableInitializer
							}
						};
						if (@using.Variables.Declarators != null)
						{
							foreach (BlockVariableDeclarator declarator in @using.Variables.Declarators)
							{
								List<Location> locations2 = LocationsBag.GetLocations(declarator);
								VariableInitializer variableInitializer2 = new VariableInitializer();
								if (locations2 != null && locations2.Count > 0)
								{
									variableDeclarationStatement.AddChild(new CSharpTokenNode(Convert(locations2[0]), Roles.Comma), Roles.Comma);
								}
								variableInitializer2.AddChild(Identifier.Create(declarator.Variable.Name, Convert(declarator.Variable.Location)), Roles.Identifier);
								if (declarator.Initializer != null)
								{
									if (locations2 != null && locations2.Count > 1)
									{
										variableInitializer2.AddChild(new CSharpTokenNode(Convert(locations2[1]), Roles.Assign), Roles.Assign);
									}
									variableInitializer2.AddChild((Expression)declarator.Initializer.Accept(this), Roles.Expression);
								}
								variableDeclarationStatement.AddChild(variableInitializer2, Roles.Variable);
							}
						}
						usingStatement.AddChild(variableDeclarationStatement, UsingStatement.ResourceAcquisitionRole);
					}
					statement = @using.Statement;
					usingStatement.AddChild(new CSharpTokenNode(Convert(blockStatement.EndLocation), Roles.RPar), Roles.RPar);
					if (statement != null)
					{
						usingStatement.AddChild((Statement)statement.Accept(this), Roles.EmbeddedStatement);
					}
				}
				return usingStatement;
			}

			private void AddBlockChildren(BlockStatement result, Block blockStatement, ref int curLocal)
			{
				if (!convertTypeSystemMode)
				{
					foreach (ICSharpCode.NRefactory.MonoCSharp.Statement statement in blockStatement.Statements)
					{
						if (statement != null)
						{
							if (statement is Block && !(statement is ToplevelBlock) && !(statement is ExplicitBlock))
							{
								AddBlockChildren(result, (Block)statement, ref curLocal);
							}
							else
							{
								result.AddChild((Statement)statement.Accept(this), BlockStatement.StatementRole);
							}
						}
					}
				}
			}

			public override object Visit(Block blockStatement)
			{
				if (blockStatement.IsCompilerGenerated && blockStatement.Statements.Any())
				{
					if (blockStatement.Statements.First() is Using)
					{
						return CreateUsingStatement(blockStatement);
					}
					return blockStatement.Statements.Last().Accept(this);
				}
				BlockStatement blockStatement2 = new BlockStatement();
				blockStatement2.AddChild(new CSharpTokenNode(Convert(blockStatement.StartLocation), Roles.LBrace), Roles.LBrace);
				int curLocal = 0;
				AddBlockChildren(blockStatement2, blockStatement, ref curLocal);
				blockStatement2.AddChild(new CSharpTokenNode(Convert(blockStatement.EndLocation), Roles.RBrace), Roles.RBrace);
				return blockStatement2;
			}

			public override object Visit(Switch switchStatement)
			{
				SwitchStatement switchStatement2 = new SwitchStatement();
				List<Location> locations = LocationsBag.GetLocations(switchStatement);
				switchStatement2.AddChild(new CSharpTokenNode(Convert(switchStatement.loc), SwitchStatement.SwitchKeywordRole), SwitchStatement.SwitchKeywordRole);
				if (locations != null)
				{
					switchStatement2.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.LPar), Roles.LPar);
				}
				if (switchStatement.Expr != null)
				{
					switchStatement2.AddChild((Expression)switchStatement.Expr.Accept(this), Roles.Expression);
				}
				if (locations != null && locations.Count > 1)
				{
					switchStatement2.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.RPar), Roles.RPar);
				}
				if (locations != null && locations.Count > 2)
				{
					switchStatement2.AddChild(new CSharpTokenNode(Convert(locations[2]), Roles.LBrace), Roles.LBrace);
				}
				SwitchSection switchSection = null;
				bool flag = false;
				bool flag2 = true;
				if (switchStatement.Block != null)
				{
					foreach (ICSharpCode.NRefactory.MonoCSharp.Statement statement in switchStatement.Block.Statements)
					{
						object obj = statement.Accept(this);
						CaseLabel caseLabel = obj as CaseLabel;
						if (caseLabel != null)
						{
							if (!flag)
							{
								switchSection = new SwitchSection();
								flag2 = false;
							}
							switchSection.AddChild(caseLabel, SwitchSection.CaseLabelRole);
							flag = true;
						}
						else
						{
							if (flag)
							{
								switchStatement2.AddChild(switchSection, SwitchStatement.SwitchSectionRole);
								flag = false;
								flag2 = true;
							}
							switchSection.AddChild((Statement)obj, Roles.EmbeddedStatement);
						}
					}
				}
				if (!flag2)
				{
					switchStatement2.AddChild(switchSection, SwitchStatement.SwitchSectionRole);
				}
				if (locations != null && locations.Count > 3)
				{
					switchStatement2.AddChild(new CSharpTokenNode(Convert(locations[3]), Roles.RBrace), Roles.RBrace);
				}
				else
				{
					switchStatement2.AddChild(new ErrorNode(), Roles.Error);
				}
				return switchStatement2;
			}

			public override object Visit(SwitchLabel switchLabel)
			{
				CaseLabel caseLabel = new CaseLabel();
				if (!switchLabel.IsDefault)
				{
					caseLabel.AddChild(new CSharpTokenNode(Convert(switchLabel.Location), CaseLabel.CaseKeywordRole), CaseLabel.CaseKeywordRole);
					if (switchLabel.Label != null)
					{
						caseLabel.AddChild((Expression)switchLabel.Label.Accept(this), Roles.Expression);
					}
					List<Location> locations = LocationsBag.GetLocations(switchLabel);
					if (locations != null)
					{
						caseLabel.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Colon), Roles.Colon);
					}
				}
				else
				{
					caseLabel.AddChild(new CSharpTokenNode(Convert(switchLabel.Location), CaseLabel.DefaultKeywordRole), CaseLabel.DefaultKeywordRole);
					caseLabel.AddChild(new CSharpTokenNode(new TextLocation(switchLabel.Location.Row, switchLabel.Location.Column + "default".Length), Roles.Colon), Roles.Colon);
				}
				return caseLabel;
			}

			public override object Visit(Lock lockStatement)
			{
				LockStatement lockStatement2 = new LockStatement();
				List<Location> locations = LocationsBag.GetLocations(lockStatement);
				lockStatement2.AddChild(new CSharpTokenNode(Convert(lockStatement.loc), LockStatement.LockKeywordRole), LockStatement.LockKeywordRole);
				if (locations != null)
				{
					lockStatement2.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.LPar), Roles.LPar);
				}
				if (lockStatement.Expr != null)
				{
					lockStatement2.AddChild((Expression)lockStatement.Expr.Accept(this), Roles.Expression);
				}
				if (locations != null && locations.Count > 1)
				{
					lockStatement2.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.RPar), Roles.RPar);
				}
				if (lockStatement.Statement != null)
				{
					lockStatement2.AddChild((Statement)lockStatement.Statement.Accept(this), Roles.EmbeddedStatement);
				}
				return lockStatement2;
			}

			public override object Visit(Unchecked uncheckedStatement)
			{
				UncheckedStatement uncheckedStatement2 = new UncheckedStatement();
				uncheckedStatement2.AddChild(new CSharpTokenNode(Convert(uncheckedStatement.loc), UncheckedStatement.UncheckedKeywordRole), UncheckedStatement.UncheckedKeywordRole);
				if (uncheckedStatement.Block != null)
				{
					BlockStatement blockStatement = uncheckedStatement.Block.Accept(this) as BlockStatement;
					if (blockStatement != null)
					{
						uncheckedStatement2.AddChild(blockStatement, Roles.Body);
					}
				}
				return uncheckedStatement2;
			}

			public override object Visit(Checked checkedStatement)
			{
				CheckedStatement checkedStatement2 = new CheckedStatement();
				checkedStatement2.AddChild(new CSharpTokenNode(Convert(checkedStatement.loc), CheckedStatement.CheckedKeywordRole), CheckedStatement.CheckedKeywordRole);
				if (checkedStatement.Block != null)
				{
					BlockStatement blockStatement = checkedStatement.Block.Accept(this) as BlockStatement;
					if (blockStatement != null)
					{
						checkedStatement2.AddChild(blockStatement, Roles.Body);
					}
				}
				return checkedStatement2;
			}

			public override object Visit(Unsafe unsafeStatement)
			{
				UnsafeStatement unsafeStatement2 = new UnsafeStatement();
				unsafeStatement2.AddChild(new CSharpTokenNode(Convert(unsafeStatement.loc), UnsafeStatement.UnsafeKeywordRole), UnsafeStatement.UnsafeKeywordRole);
				if (unsafeStatement.Block != null)
				{
					BlockStatement blockStatement = unsafeStatement.Block.Accept(this) as BlockStatement;
					if (blockStatement != null)
					{
						unsafeStatement2.AddChild(blockStatement, Roles.Body);
					}
				}
				return unsafeStatement2;
			}

			public override object Visit(Fixed fixedStatement)
			{
				FixedStatement fixedStatement2 = new FixedStatement();
				List<Location> locations = LocationsBag.GetLocations(fixedStatement);
				fixedStatement2.AddChild(new CSharpTokenNode(Convert(fixedStatement.loc), FixedStatement.FixedKeywordRole), FixedStatement.FixedKeywordRole);
				if (locations != null)
				{
					fixedStatement2.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.LPar), Roles.LPar);
				}
				if (fixedStatement.Variables != null)
				{
					BlockVariable variables = fixedStatement.Variables;
					fixedStatement2.AddChild(ConvertToType(variables.TypeExpression), Roles.Type);
					VariableInitializer variableInitializer = new VariableInitializer();
					List<Location> locations2 = LocationsBag.GetLocations(variables);
					variableInitializer.AddChild(Identifier.Create(variables.Variable.Name, Convert(variables.Variable.Location)), Roles.Identifier);
					if (variables.Initializer != null)
					{
						if (locations2 != null)
						{
							variableInitializer.AddChild(new CSharpTokenNode(Convert(locations2[0]), Roles.Assign), Roles.Assign);
						}
						variableInitializer.AddChild((Expression)variables.Initializer.Accept(this), Roles.Expression);
					}
					fixedStatement2.AddChild(variableInitializer, Roles.Variable);
					if (variables.Declarators != null)
					{
						foreach (BlockVariableDeclarator declarator in variables.Declarators)
						{
							List<Location> locations3 = LocationsBag.GetLocations(declarator);
							VariableInitializer variableInitializer2 = new VariableInitializer();
							if (locations3 != null && locations3.Count > 0)
							{
								fixedStatement2.AddChild(new CSharpTokenNode(Convert(locations3[0]), Roles.Comma), Roles.Comma);
							}
							variableInitializer2.AddChild(Identifier.Create(declarator.Variable.Name, Convert(declarator.Variable.Location)), Roles.Identifier);
							if (declarator.Initializer != null)
							{
								if (locations3 != null && locations3.Count > 1)
								{
									variableInitializer2.AddChild(new CSharpTokenNode(Convert(locations3[1]), Roles.Assign), Roles.Assign);
								}
								variableInitializer2.AddChild((Expression)declarator.Initializer.Accept(this), Roles.Expression);
							}
							fixedStatement2.AddChild(variableInitializer2, Roles.Variable);
						}
					}
				}
				if (locations != null && locations.Count > 1)
				{
					fixedStatement2.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.RPar), Roles.RPar);
				}
				if (fixedStatement.Statement != null)
				{
					fixedStatement2.AddChild((Statement)fixedStatement.Statement.Accept(this), Roles.EmbeddedStatement);
				}
				return fixedStatement2;
			}

			public override object Visit(TryFinally tryFinallyStatement)
			{
				List<Location> locations = LocationsBag.GetLocations(tryFinallyStatement);
				TryCatchStatement tryCatchStatement;
				if (tryFinallyStatement.Stmt is TryCatch)
				{
					tryCatchStatement = (TryCatchStatement)tryFinallyStatement.Stmt.Accept(this);
				}
				else
				{
					tryCatchStatement = new TryCatchStatement();
					tryCatchStatement.AddChild(new CSharpTokenNode(Convert(tryFinallyStatement.loc), TryCatchStatement.TryKeywordRole), TryCatchStatement.TryKeywordRole);
					if (tryFinallyStatement.Stmt != null)
					{
						tryCatchStatement.AddChild((BlockStatement)tryFinallyStatement.Stmt.Accept(this), TryCatchStatement.TryBlockRole);
					}
				}
				if (locations != null)
				{
					tryCatchStatement.AddChild(new CSharpTokenNode(Convert(locations[0]), TryCatchStatement.FinallyKeywordRole), TryCatchStatement.FinallyKeywordRole);
				}
				if (tryFinallyStatement.Fini != null)
				{
					tryCatchStatement.AddChild((BlockStatement)tryFinallyStatement.Fini.Accept(this), TryCatchStatement.FinallyBlockRole);
				}
				return tryCatchStatement;
			}

			private CatchClause ConvertCatch(Catch ctch)
			{
				CatchClause catchClause = new CatchClause();
				List<Location> locations = LocationsBag.GetLocations(ctch);
				catchClause.AddChild(new CSharpTokenNode(Convert(ctch.loc), CatchClause.CatchKeywordRole), CatchClause.CatchKeywordRole);
				if (ctch.TypeExpression != null)
				{
					if (locations != null)
					{
						catchClause.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.LPar), Roles.LPar);
					}
					if (ctch.TypeExpression != null)
					{
						catchClause.AddChild(ConvertToType(ctch.TypeExpression), Roles.Type);
					}
					if (ctch.Variable != null && !string.IsNullOrEmpty(ctch.Variable.Name))
					{
						catchClause.AddChild(Identifier.Create(ctch.Variable.Name, Convert(ctch.Variable.Location)), Roles.Identifier);
					}
					if (locations != null && locations.Count > 1)
					{
						catchClause.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.RPar), Roles.RPar);
					}
				}
				if (ctch.Block != null)
				{
					catchClause.AddChild((BlockStatement)ctch.Block.Accept(this), Roles.Body);
				}
				return catchClause;
			}

			public override object Visit(TryCatch tryCatchStatement)
			{
				TryCatchStatement tryCatchStatement2 = new TryCatchStatement();
				tryCatchStatement2.AddChild(new CSharpTokenNode(Convert(tryCatchStatement.loc), TryCatchStatement.TryKeywordRole), TryCatchStatement.TryKeywordRole);
				if (tryCatchStatement.Block != null)
				{
					tryCatchStatement2.AddChild((BlockStatement)tryCatchStatement.Block.Accept(this), TryCatchStatement.TryBlockRole);
				}
				if (tryCatchStatement.Clauses != null)
				{
					foreach (Catch clause in tryCatchStatement.Clauses)
					{
						tryCatchStatement2.AddChild(ConvertCatch(clause), TryCatchStatement.CatchClauseRole);
					}
					return tryCatchStatement2;
				}
				return tryCatchStatement2;
			}

			public override object Visit(Using usingStatement)
			{
				UsingStatement usingStatement2 = new UsingStatement();
				List<Location> locations = LocationsBag.GetLocations(usingStatement);
				usingStatement2.AddChild(new CSharpTokenNode(Convert(usingStatement.loc), UsingStatement.UsingKeywordRole), UsingStatement.UsingKeywordRole);
				if (locations != null)
				{
					usingStatement2.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.LPar), Roles.LPar);
				}
				if (usingStatement.Expr != null)
				{
					usingStatement2.AddChild((AstNode)usingStatement.Expr.Accept(this), UsingStatement.ResourceAcquisitionRole);
				}
				if (locations != null && locations.Count > 1)
				{
					usingStatement2.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.RPar), Roles.RPar);
				}
				if (usingStatement.Statement != null)
				{
					usingStatement2.AddChild((Statement)usingStatement.Statement.Accept(this), Roles.EmbeddedStatement);
				}
				return usingStatement2;
			}

			public override object Visit(Foreach foreachStatement)
			{
				ForeachStatement foreachStatement2 = new ForeachStatement();
				List<Location> locations = LocationsBag.GetLocations(foreachStatement);
				foreachStatement2.AddChild(new CSharpTokenNode(Convert(foreachStatement.loc), ForeachStatement.ForeachKeywordRole), ForeachStatement.ForeachKeywordRole);
				if (locations != null)
				{
					foreachStatement2.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.LPar), Roles.LPar);
				}
				if (foreachStatement.TypeExpression != null)
				{
					foreachStatement2.AddChild(ConvertToType(foreachStatement.TypeExpression), Roles.Type);
				}
				if (foreachStatement.Variable != null)
				{
					foreachStatement2.AddChild(Identifier.Create(foreachStatement.Variable.Name, Convert(foreachStatement.Variable.Location)), Roles.Identifier);
				}
				if (locations != null && locations.Count > 1)
				{
					foreachStatement2.AddChild(new CSharpTokenNode(Convert(locations[1]), ForeachStatement.InKeywordRole), ForeachStatement.InKeywordRole);
				}
				if (foreachStatement.Expr != null)
				{
					foreachStatement2.AddChild((Expression)foreachStatement.Expr.Accept(this), Roles.Expression);
				}
				if (locations != null && locations.Count > 2)
				{
					foreachStatement2.AddChild(new CSharpTokenNode(Convert(locations[2]), Roles.RPar), Roles.RPar);
				}
				if (foreachStatement.Statement != null)
				{
					foreachStatement2.AddChild((Statement)foreachStatement.Statement.Accept(this), Roles.EmbeddedStatement);
				}
				return foreachStatement2;
			}

			public override object Visit(Yield yieldStatement)
			{
				YieldReturnStatement yieldReturnStatement = new YieldReturnStatement();
				List<Location> locations = LocationsBag.GetLocations(yieldStatement);
				yieldReturnStatement.AddChild(new CSharpTokenNode(Convert(yieldStatement.loc), YieldReturnStatement.YieldKeywordRole), YieldReturnStatement.YieldKeywordRole);
				if (locations != null)
				{
					yieldReturnStatement.AddChild(new CSharpTokenNode(Convert(locations[0]), YieldReturnStatement.ReturnKeywordRole), YieldReturnStatement.ReturnKeywordRole);
				}
				if (yieldStatement.Expr != null)
				{
					yieldReturnStatement.AddChild((Expression)yieldStatement.Expr.Accept(this), Roles.Expression);
				}
				if (locations != null && locations.Count > 1)
				{
					yieldReturnStatement.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.Semicolon), Roles.Semicolon);
				}
				return yieldReturnStatement;
			}

			public override object Visit(YieldBreak yieldBreakStatement)
			{
				YieldBreakStatement yieldBreakStatement2 = new YieldBreakStatement();
				List<Location> locations = LocationsBag.GetLocations(yieldBreakStatement);
				yieldBreakStatement2.AddChild(new CSharpTokenNode(Convert(yieldBreakStatement.loc), YieldBreakStatement.YieldKeywordRole), YieldBreakStatement.YieldKeywordRole);
				if (locations != null)
				{
					yieldBreakStatement2.AddChild(new CSharpTokenNode(Convert(locations[0]), YieldBreakStatement.BreakKeywordRole), YieldBreakStatement.BreakKeywordRole);
					if (locations.Count > 1)
					{
						yieldBreakStatement2.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.Semicolon), Roles.Semicolon);
					}
				}
				return yieldBreakStatement2;
			}

			public override object Visit(ICSharpCode.NRefactory.MonoCSharp.Expression expression)
			{
				Console.WriteLine("Visit unknown expression:" + expression);
				Console.WriteLine(Environment.StackTrace);
				return null;
			}

			public override object Visit(DefaultParameterValueExpression defaultParameterValueExpression)
			{
				return defaultParameterValueExpression.Child.Accept(this);
			}

			public override object Visit(TypeExpression typeExpression)
			{
				return new TypeReferenceExpression(new PrimitiveType(keywordTable[(int)typeExpression.Type.BuiltinType], Convert(typeExpression.Location)));
			}

			public override object Visit(LocalVariableReference localVariableReference)
			{
				return Identifier.Create(localVariableReference.Name, Convert(localVariableReference.Location));
			}

			public override object Visit(MemberAccess memberAccess)
			{
				Indirection indirection = memberAccess.LeftExpression as Indirection;
				Expression expression;
				if (indirection != null)
				{
					expression = new PointerReferenceExpression();
					expression.AddChild((Expression)indirection.Expr.Accept(this), Roles.TargetExpression);
					expression.AddChild(new CSharpTokenNode(Convert(indirection.Location), PointerReferenceExpression.ArrowRole), PointerReferenceExpression.ArrowRole);
				}
				else
				{
					expression = new MemberReferenceExpression();
					if (memberAccess.LeftExpression != null)
					{
						object obj = memberAccess.LeftExpression.Accept(this);
						expression.AddChild((Expression)obj, Roles.TargetExpression);
					}
					List<Location> locations = LocationsBag.GetLocations(memberAccess);
					if (locations != null)
					{
						expression.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Dot), Roles.Dot);
					}
				}
				expression.AddChild(Identifier.Create(memberAccess.Name, Convert(memberAccess.Location)), Roles.Identifier);
				AddTypeArguments(expression, memberAccess);
				return expression;
			}

			public override object Visit(QualifiedAliasMember qualifiedAliasMember)
			{
				MemberType memberType = new MemberType();
				memberType.Target = new SimpleType(qualifiedAliasMember.alias, Convert(qualifiedAliasMember.Location));
				memberType.IsDoubleColon = true;
				List<Location> locations = LocationsBag.GetLocations(qualifiedAliasMember);
				if (locations != null && locations.Count > 0)
				{
					memberType.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.DoubleColon), Roles.DoubleColon);
				}
				AddTypeArguments(memberType, qualifiedAliasMember);
				memberType.AddChild(Identifier.Create(qualifiedAliasMember.Name, (locations != null && locations.Count > 1) ? Convert(locations[1]) : TextLocation.Empty), Roles.Identifier);
				return new TypeReferenceExpression
				{
					Type = memberType
				};
			}

			public override object Visit(Constant constant)
			{
				if (constant.GetValue() == null)
				{
					return new NullReferenceExpression(Convert(constant.Location));
				}
				ILiteralConstant literalConstant = constant as ILiteralConstant;
				string literalValue = (literalConstant != null) ? new string(literalConstant.ParsedValue) : constant.GetValueAsLiteral();
				object value = constant.GetValue();
				if (value is bool)
				{
					literalValue = (((bool)value) ? "true" : "false");
				}
				return new PrimitiveExpression(value, Convert(constant.Location), literalValue);
			}

			public override object Visit(SimpleName simpleName)
			{
				IdentifierExpression identifierExpression = new IdentifierExpression();
				identifierExpression.AddChild(Identifier.Create(simpleName.Name, Convert(simpleName.Location)), Roles.Identifier);
				AddTypeArguments(identifierExpression, simpleName);
				return identifierExpression;
			}

			public override object Visit(BooleanExpression booleanExpression)
			{
				return booleanExpression.Expr.Accept(this);
			}

			public override object Visit(ICSharpCode.NRefactory.MonoCSharp.ParenthesizedExpression parenthesizedExpression)
			{
				ParenthesizedExpression parenthesizedExpression2 = new ParenthesizedExpression();
				List<Location> locations = LocationsBag.GetLocations(parenthesizedExpression);
				if (locations != null)
				{
					parenthesizedExpression2.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.LPar), Roles.LPar);
				}
				if (parenthesizedExpression.Expr != null)
				{
					parenthesizedExpression2.AddChild((Expression)parenthesizedExpression.Expr.Accept(this), Roles.Expression);
				}
				if (locations != null && locations.Count > 1)
				{
					parenthesizedExpression2.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.RPar), Roles.RPar);
				}
				return parenthesizedExpression2;
			}

			public override object Visit(Unary unaryExpression)
			{
				UnaryOperatorExpression unaryOperatorExpression = new UnaryOperatorExpression();
				switch (unaryExpression.Oper)
				{
				case Unary.Operator.UnaryPlus:
					unaryOperatorExpression.Operator = UnaryOperatorType.Plus;
					break;
				case Unary.Operator.UnaryNegation:
					unaryOperatorExpression.Operator = UnaryOperatorType.Minus;
					break;
				case Unary.Operator.LogicalNot:
					unaryOperatorExpression.Operator = UnaryOperatorType.Not;
					break;
				case Unary.Operator.OnesComplement:
					unaryOperatorExpression.Operator = UnaryOperatorType.BitNot;
					break;
				case Unary.Operator.AddressOf:
					unaryOperatorExpression.Operator = UnaryOperatorType.AddressOf;
					break;
				}
				TokenRole operatorRole = UnaryOperatorExpression.GetOperatorRole(unaryOperatorExpression.Operator);
				unaryOperatorExpression.AddChild(new CSharpTokenNode(Convert(unaryExpression.Location), operatorRole), operatorRole);
				if (unaryExpression.Expr != null)
				{
					unaryOperatorExpression.AddChild((Expression)unaryExpression.Expr.Accept(this), Roles.Expression);
				}
				return unaryOperatorExpression;
			}

			public override object Visit(UnaryMutator unaryMutatorExpression)
			{
				UnaryOperatorExpression unaryOperatorExpression = new UnaryOperatorExpression();
				if (unaryMutatorExpression.Expr == null)
				{
					return unaryOperatorExpression;
				}
				Expression child = (Expression)unaryMutatorExpression.Expr.Accept(this);
				switch (unaryMutatorExpression.UnaryMutatorMode)
				{
				case UnaryMutator.Mode.PostDecrement:
					unaryOperatorExpression.Operator = UnaryOperatorType.PostDecrement;
					unaryOperatorExpression.AddChild(child, Roles.Expression);
					unaryOperatorExpression.AddChild(new CSharpTokenNode(Convert(unaryMutatorExpression.Location), UnaryOperatorExpression.DecrementRole), UnaryOperatorExpression.DecrementRole);
					break;
				case UnaryMutator.Mode.IsPost:
					unaryOperatorExpression.Operator = UnaryOperatorType.PostIncrement;
					unaryOperatorExpression.AddChild(child, Roles.Expression);
					unaryOperatorExpression.AddChild(new CSharpTokenNode(Convert(unaryMutatorExpression.Location), UnaryOperatorExpression.IncrementRole), UnaryOperatorExpression.IncrementRole);
					break;
				case UnaryMutator.Mode.IsIncrement:
					unaryOperatorExpression.Operator = UnaryOperatorType.Increment;
					unaryOperatorExpression.AddChild(new CSharpTokenNode(Convert(unaryMutatorExpression.Location), UnaryOperatorExpression.IncrementRole), UnaryOperatorExpression.IncrementRole);
					unaryOperatorExpression.AddChild(child, Roles.Expression);
					break;
				case UnaryMutator.Mode.IsDecrement:
					unaryOperatorExpression.Operator = UnaryOperatorType.Decrement;
					unaryOperatorExpression.AddChild(new CSharpTokenNode(Convert(unaryMutatorExpression.Location), UnaryOperatorExpression.DecrementRole), UnaryOperatorExpression.DecrementRole);
					unaryOperatorExpression.AddChild(child, Roles.Expression);
					break;
				}
				return unaryOperatorExpression;
			}

			public override object Visit(Indirection indirectionExpression)
			{
				UnaryOperatorExpression unaryOperatorExpression = new UnaryOperatorExpression();
				unaryOperatorExpression.Operator = UnaryOperatorType.Dereference;
				unaryOperatorExpression.AddChild(new CSharpTokenNode(Convert(indirectionExpression.Location), UnaryOperatorExpression.DereferenceRole), UnaryOperatorExpression.DereferenceRole);
				if (indirectionExpression.Expr != null)
				{
					unaryOperatorExpression.AddChild((Expression)indirectionExpression.Expr.Accept(this), Roles.Expression);
				}
				return unaryOperatorExpression;
			}

			public override object Visit(Is isExpression)
			{
				IsExpression isExpression2 = new IsExpression();
				if (isExpression.Expr != null)
				{
					isExpression2.AddChild((Expression)isExpression.Expr.Accept(this), Roles.Expression);
				}
				isExpression2.AddChild(new CSharpTokenNode(Convert(isExpression.Location), IsExpression.IsKeywordRole), IsExpression.IsKeywordRole);
				if (isExpression.ProbeType != null)
				{
					isExpression2.AddChild(ConvertToType(isExpression.ProbeType), Roles.Type);
				}
				return isExpression2;
			}

			public override object Visit(As asExpression)
			{
				AsExpression asExpression2 = new AsExpression();
				if (asExpression.Expr != null)
				{
					asExpression2.AddChild((Expression)asExpression.Expr.Accept(this), Roles.Expression);
				}
				asExpression2.AddChild(new CSharpTokenNode(Convert(asExpression.Location), AsExpression.AsKeywordRole), AsExpression.AsKeywordRole);
				if (asExpression.ProbeType != null)
				{
					asExpression2.AddChild(ConvertToType(asExpression.ProbeType), Roles.Type);
				}
				return asExpression2;
			}

			public override object Visit(Cast castExpression)
			{
				CastExpression castExpression2 = new CastExpression();
				List<Location> locations = LocationsBag.GetLocations(castExpression);
				castExpression2.AddChild(new CSharpTokenNode(Convert(castExpression.Location), Roles.LPar), Roles.LPar);
				if (castExpression.TargetType != null)
				{
					castExpression2.AddChild(ConvertToType(castExpression.TargetType), Roles.Type);
				}
				if (locations != null)
				{
					castExpression2.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.RPar), Roles.RPar);
				}
				if (castExpression.Expr != null)
				{
					castExpression2.AddChild((Expression)castExpression.Expr.Accept(this), Roles.Expression);
				}
				return castExpression2;
			}

			public override object Visit(ComposedCast composedCast)
			{
				ComposedType composedType = new ComposedType();
				composedType.AddChild(ConvertToType(composedCast.Left), Roles.Type);
				for (ComposedTypeSpecifier composedTypeSpecifier = composedCast.Spec; composedTypeSpecifier != null; composedTypeSpecifier = composedTypeSpecifier.Next)
				{
					if (composedTypeSpecifier.IsNullable)
					{
						composedType.AddChild(new CSharpTokenNode(Convert(composedTypeSpecifier.Location), ComposedType.NullableRole), ComposedType.NullableRole);
					}
					else if (composedTypeSpecifier.IsPointer)
					{
						composedType.AddChild(new CSharpTokenNode(Convert(composedTypeSpecifier.Location), ComposedType.PointerRole), ComposedType.PointerRole);
					}
					else
					{
						ArraySpecifier arraySpecifier = new ArraySpecifier();
						arraySpecifier.AddChild(new CSharpTokenNode(Convert(composedTypeSpecifier.Location), Roles.LBracket), Roles.LBracket);
						if (LocationsBag.GetLocations(composedTypeSpecifier) != null)
						{
							arraySpecifier.AddChild(new CSharpTokenNode(Convert(composedTypeSpecifier.Location), Roles.RBracket), Roles.RBracket);
						}
						composedType.AddChild(arraySpecifier, ComposedType.ArraySpecifierRole);
					}
				}
				return composedType;
			}

			public override object Visit(ICSharpCode.NRefactory.MonoCSharp.DefaultValueExpression defaultValueExpression)
			{
				DefaultValueExpression defaultValueExpression2 = new DefaultValueExpression();
				defaultValueExpression2.AddChild(new CSharpTokenNode(Convert(defaultValueExpression.Location), DefaultValueExpression.DefaultKeywordRole), DefaultValueExpression.DefaultKeywordRole);
				List<Location> locations = LocationsBag.GetLocations(defaultValueExpression);
				if (locations != null)
				{
					defaultValueExpression2.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.LPar), Roles.LPar);
				}
				defaultValueExpression2.AddChild(ConvertToType(defaultValueExpression.Expr), Roles.Type);
				if (locations != null && locations.Count > 1)
				{
					defaultValueExpression2.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.RPar), Roles.RPar);
				}
				return defaultValueExpression2;
			}

			public override object Visit(Binary binaryExpression)
			{
				BinaryOperatorExpression binaryOperatorExpression = new BinaryOperatorExpression();
				switch (binaryExpression.Oper)
				{
				case Binary.Operator.Multiply:
					binaryOperatorExpression.Operator = BinaryOperatorType.Multiply;
					break;
				case Binary.Operator.Division:
					binaryOperatorExpression.Operator = BinaryOperatorType.Divide;
					break;
				case Binary.Operator.Modulus:
					binaryOperatorExpression.Operator = BinaryOperatorType.Modulus;
					break;
				case Binary.Operator.Addition:
					binaryOperatorExpression.Operator = BinaryOperatorType.Add;
					break;
				case Binary.Operator.Subtraction:
					binaryOperatorExpression.Operator = BinaryOperatorType.Subtract;
					break;
				case Binary.Operator.LeftShift:
					binaryOperatorExpression.Operator = BinaryOperatorType.ShiftLeft;
					break;
				case Binary.Operator.RightShift:
					binaryOperatorExpression.Operator = BinaryOperatorType.ShiftRight;
					break;
				case Binary.Operator.LessThan:
					binaryOperatorExpression.Operator = BinaryOperatorType.LessThan;
					break;
				case Binary.Operator.GreaterThan:
					binaryOperatorExpression.Operator = BinaryOperatorType.GreaterThan;
					break;
				case Binary.Operator.LessThanOrEqual:
					binaryOperatorExpression.Operator = BinaryOperatorType.LessThanOrEqual;
					break;
				case Binary.Operator.GreaterThanOrEqual:
					binaryOperatorExpression.Operator = BinaryOperatorType.GreaterThanOrEqual;
					break;
				case Binary.Operator.Equality:
					binaryOperatorExpression.Operator = BinaryOperatorType.Equality;
					break;
				case Binary.Operator.Inequality:
					binaryOperatorExpression.Operator = BinaryOperatorType.InEquality;
					break;
				case Binary.Operator.BitwiseAnd:
					binaryOperatorExpression.Operator = BinaryOperatorType.BitwiseAnd;
					break;
				case Binary.Operator.ExclusiveOr:
					binaryOperatorExpression.Operator = BinaryOperatorType.ExclusiveOr;
					break;
				case Binary.Operator.BitwiseOr:
					binaryOperatorExpression.Operator = BinaryOperatorType.BitwiseOr;
					break;
				case Binary.Operator.LogicalAnd:
					binaryOperatorExpression.Operator = BinaryOperatorType.ConditionalAnd;
					break;
				case Binary.Operator.LogicalOr:
					binaryOperatorExpression.Operator = BinaryOperatorType.ConditionalOr;
					break;
				}
				if (binaryExpression.Left != null)
				{
					binaryOperatorExpression.AddChild((Expression)binaryExpression.Left.Accept(this), BinaryOperatorExpression.LeftRole);
				}
				List<Location> locations = LocationsBag.GetLocations(binaryExpression);
				if (locations != null)
				{
					TokenRole operatorRole = BinaryOperatorExpression.GetOperatorRole(binaryOperatorExpression.Operator);
					binaryOperatorExpression.AddChild(new CSharpTokenNode(Convert(locations[0]), operatorRole), operatorRole);
				}
				if (binaryExpression.Right != null)
				{
					binaryOperatorExpression.AddChild((Expression)binaryExpression.Right.Accept(this), BinaryOperatorExpression.RightRole);
				}
				return binaryOperatorExpression;
			}

			public override object Visit(NullCoalescingOperator nullCoalescingOperator)
			{
				BinaryOperatorExpression binaryOperatorExpression = new BinaryOperatorExpression();
				binaryOperatorExpression.Operator = BinaryOperatorType.NullCoalescing;
				if (nullCoalescingOperator.LeftExpression != null)
				{
					binaryOperatorExpression.AddChild((Expression)nullCoalescingOperator.LeftExpression.Accept(this), BinaryOperatorExpression.LeftRole);
				}
				List<Location> locations = LocationsBag.GetLocations(nullCoalescingOperator);
				if (locations != null)
				{
					binaryOperatorExpression.AddChild(new CSharpTokenNode(Convert(locations[0]), BinaryOperatorExpression.NullCoalescingRole), BinaryOperatorExpression.NullCoalescingRole);
				}
				if (nullCoalescingOperator.RightExpression != null)
				{
					binaryOperatorExpression.AddChild((Expression)nullCoalescingOperator.RightExpression.Accept(this), BinaryOperatorExpression.RightRole);
				}
				return binaryOperatorExpression;
			}

			public override object Visit(Conditional conditionalExpression)
			{
				ConditionalExpression conditionalExpression2 = new ConditionalExpression();
				if (conditionalExpression.Expr != null)
				{
					conditionalExpression2.AddChild((Expression)conditionalExpression.Expr.Accept(this), Roles.Condition);
				}
				List<Location> locations = LocationsBag.GetLocations(conditionalExpression);
				conditionalExpression2.AddChild(new CSharpTokenNode(Convert(conditionalExpression.Location), ConditionalExpression.QuestionMarkRole), ConditionalExpression.QuestionMarkRole);
				if (conditionalExpression.TrueExpr != null)
				{
					conditionalExpression2.AddChild((Expression)conditionalExpression.TrueExpr.Accept(this), ConditionalExpression.TrueRole);
				}
				if (locations != null)
				{
					conditionalExpression2.AddChild(new CSharpTokenNode(Convert(locations[0]), ConditionalExpression.ColonRole), ConditionalExpression.ColonRole);
				}
				if (conditionalExpression.FalseExpr != null)
				{
					conditionalExpression2.AddChild((Expression)conditionalExpression.FalseExpr.Accept(this), ConditionalExpression.FalseRole);
				}
				return conditionalExpression2;
			}

			private void AddParameter(AstNode parent, AParametersCollection parameters)
			{
				if (parameters == null)
				{
					return;
				}
				List<Location> locations = LocationsBag.GetLocations(parameters);
				for (int i = 0; i < parameters.Count; i++)
				{
					Parameter parameter = (Parameter)parameters.FixedParameters[i];
					if (parameter == null)
					{
						continue;
					}
					List<Location> locations2 = LocationsBag.GetLocations(parameter);
					ParameterDeclaration parameterDeclaration = new ParameterDeclaration();
					AddAttributeSection(parameterDeclaration, parameter);
					switch (parameter.ModFlags)
					{
					case Parameter.Modifier.OUT:
						parameterDeclaration.ParameterModifier = ParameterModifier.Out;
						if (locations2 != null)
						{
							parameterDeclaration.AddChild(new CSharpTokenNode(Convert(locations2[0]), ParameterDeclaration.OutModifierRole), ParameterDeclaration.OutModifierRole);
						}
						break;
					case Parameter.Modifier.REF:
						parameterDeclaration.ParameterModifier = ParameterModifier.Ref;
						if (locations2 != null)
						{
							parameterDeclaration.AddChild(new CSharpTokenNode(Convert(locations2[0]), ParameterDeclaration.RefModifierRole), ParameterDeclaration.RefModifierRole);
						}
						break;
					case Parameter.Modifier.PARAMS:
						parameterDeclaration.ParameterModifier = ParameterModifier.Params;
						if (locations2 != null)
						{
							parameterDeclaration.AddChild(new CSharpTokenNode(Convert(locations2[0]), ParameterDeclaration.ParamsModifierRole), ParameterDeclaration.ParamsModifierRole);
						}
						break;
					default:
						if (parameter.HasExtensionMethodModifier)
						{
							parameterDeclaration.ParameterModifier = ParameterModifier.This;
							if (locations2 != null)
							{
								parameterDeclaration.AddChild(new CSharpTokenNode(Convert(locations2[0]), ParameterDeclaration.ThisModifierRole), ParameterDeclaration.ThisModifierRole);
							}
						}
						break;
					}
					if (parameter.TypeExpression != null)
					{
						parameterDeclaration.AddChild(ConvertToType(parameter.TypeExpression), Roles.Type);
					}
					else if (parameter is ArglistParameter)
					{
						parameterDeclaration.AddChild(new PrimitiveType("__arglist"), Roles.Type);
					}
					if (parameter.Name != null)
					{
						parameterDeclaration.AddChild(Identifier.Create(parameter.Name, Convert(parameter.Location)), Roles.Identifier);
					}
					if (parameter.HasDefaultValue)
					{
						if (locations2 != null && locations2.Count > 1)
						{
							parameterDeclaration.AddChild(new CSharpTokenNode(Convert(locations2[1]), Roles.Assign), Roles.Assign);
						}
						parameterDeclaration.AddChild((Expression)parameter.DefaultValue.Accept(this), Roles.Expression);
					}
					parent.AddChild(parameterDeclaration, Roles.Parameter);
					if (locations != null && i < locations.Count)
					{
						parent.AddChild(new CSharpTokenNode(Convert(locations[i]), Roles.Comma), Roles.Comma);
					}
				}
			}

			private void AddTypeParameters(AstNode parent, MemberName memberName)
			{
				if (memberName == null || memberName.TypeParameters == null)
				{
					return;
				}
				List<Location> locations = LocationsBag.GetLocations(memberName.TypeParameters);
				if (locations != null)
				{
					parent.AddChild(new CSharpTokenNode(Convert(locations[locations.Count - 2]), Roles.LChevron), Roles.LChevron);
				}
				for (int i = 0; i < memberName.TypeParameters.Count; i++)
				{
					if (locations != null && i > 0 && i - 1 < locations.Count)
					{
						parent.AddChild(new CSharpTokenNode(Convert(locations[i - 1]), Roles.Comma), Roles.Comma);
					}
					TypeParameter typeParameter = memberName.TypeParameters[i];
					if (typeParameter == null)
					{
						continue;
					}
					TypeParameterDeclaration typeParameterDeclaration = new TypeParameterDeclaration();
					switch (typeParameter.Variance)
					{
					case Variance.Contravariant:
					{
						typeParameterDeclaration.Variance = VarianceModifier.Contravariant;
						List<Location> locations2 = LocationsBag.GetLocations(typeParameter);
						if (locations2 != null)
						{
							typeParameterDeclaration.AddChild(new CSharpTokenNode(Convert(locations2[0]), TypeParameterDeclaration.InVarianceKeywordRole), TypeParameterDeclaration.InVarianceKeywordRole);
						}
						break;
					}
					case Variance.Covariant:
					{
						typeParameterDeclaration.Variance = VarianceModifier.Covariant;
						List<Location> locations2 = LocationsBag.GetLocations(typeParameter);
						if (locations2 != null)
						{
							typeParameterDeclaration.AddChild(new CSharpTokenNode(Convert(locations2[0]), TypeParameterDeclaration.OutVarianceKeywordRole), TypeParameterDeclaration.OutVarianceKeywordRole);
						}
						break;
					}
					default:
						typeParameterDeclaration.Variance = VarianceModifier.Invariant;
						break;
					}
					AddAttributeSection(typeParameterDeclaration, typeParameter.OptAttributes);
					switch (typeParameter.Variance)
					{
					case Variance.Covariant:
						typeParameterDeclaration.Variance = VarianceModifier.Covariant;
						break;
					case Variance.Contravariant:
						typeParameterDeclaration.Variance = VarianceModifier.Contravariant;
						break;
					}
					typeParameterDeclaration.AddChild(Identifier.Create(typeParameter.Name, Convert(typeParameter.Location)), Roles.Identifier);
					parent.AddChild(typeParameterDeclaration, Roles.TypeParameter);
				}
				if (locations != null)
				{
					parent.AddChild(new CSharpTokenNode(Convert(locations[locations.Count - 1]), Roles.RChevron), Roles.RChevron);
				}
			}

			private void AddTypeArguments(AstNode parent, MemberName memberName)
			{
				if (memberName == null || memberName.TypeParameters == null)
				{
					return;
				}
				List<Location> locations = LocationsBag.GetLocations(memberName.TypeParameters);
				if (locations != null)
				{
					parent.AddChild(new CSharpTokenNode(Convert(locations[locations.Count - 2]), Roles.LChevron), Roles.LChevron);
				}
				for (int i = 0; i < memberName.TypeParameters.Count; i++)
				{
					TypeParameter typeParameter = memberName.TypeParameters[i];
					if (typeParameter != null)
					{
						parent.AddChild(ConvertToType(typeParameter), Roles.TypeArgument);
						if (locations != null && i < locations.Count - 2)
						{
							parent.AddChild(new CSharpTokenNode(Convert(locations[i]), Roles.Comma), Roles.Comma);
						}
					}
				}
				if (locations != null)
				{
					parent.AddChild(new CSharpTokenNode(Convert(locations[locations.Count - 1]), Roles.RChevron), Roles.RChevron);
				}
			}

			private void AddTypeArguments(AstNode parent, ATypeNameExpression memberName)
			{
				if (memberName == null || !memberName.HasTypeArguments)
				{
					return;
				}
				List<Location> locations = LocationsBag.GetLocations(memberName.TypeArguments);
				if (locations != null)
				{
					parent.AddChild(new CSharpTokenNode(Convert(locations[locations.Count - 2]), Roles.LChevron), Roles.LChevron);
				}
				for (int i = 0; i < memberName.TypeArguments.Count; i++)
				{
					FullNamedExpression fullNamedExpression = memberName.TypeArguments.Args[i];
					if (fullNamedExpression != null)
					{
						parent.AddChild(ConvertToType(fullNamedExpression), Roles.TypeArgument);
						if (locations != null && i < locations.Count - 2)
						{
							parent.AddChild(new CSharpTokenNode(Convert(locations[i]), Roles.Comma), Roles.Comma);
						}
					}
				}
				if (locations != null)
				{
					parent.AddChild(new CSharpTokenNode(Convert(locations[locations.Count - 1]), Roles.RChevron), Roles.RChevron);
				}
			}

			private void AddConstraints(AstNode parent, TypeParameters d)
			{
				if (d == null)
				{
					return;
				}
				for (int i = 0; i < d.Count; i++)
				{
					TypeParameter typeParameter = d[i];
					if (typeParameter == null)
					{
						continue;
					}
					Constraints constraints = typeParameter.Constraints;
					if (constraints != null)
					{
						List<Location> locations = LocationsBag.GetLocations(constraints);
						Constraint constraint = new Constraint();
						constraint.AddChild(new CSharpTokenNode(Convert(constraints.Location), Roles.WhereKeyword), Roles.WhereKeyword);
						constraint.AddChild(new SimpleType(Identifier.Create(constraints.TypeParameter.Value, Convert(constraints.TypeParameter.Location))), Roles.ConstraintTypeParameter);
						if (locations != null)
						{
							constraint.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Colon), Roles.Colon);
						}
						List<Location> locations2 = LocationsBag.GetLocations(constraints.ConstraintExpressions);
						int num = 0;
						if (constraints.ConstraintExpressions != null)
						{
							foreach (FullNamedExpression constraintExpression in constraints.ConstraintExpressions)
							{
								constraint.AddChild(ConvertToType(constraintExpression), Roles.BaseType);
								SpecialContraintExpr specialContraintExpr = constraintExpression as SpecialContraintExpr;
								if (specialContraintExpr != null)
								{
									switch (specialContraintExpr.Constraint)
									{
									case SpecialConstraint.Constructor:
									{
										List<Location> locations3 = LocationsBag.GetLocations(constraintExpression);
										if (locations3 != null)
										{
											constraint.AddChild(new CSharpTokenNode(Convert(locations3[0]), Roles.LPar), Roles.LPar);
											constraint.AddChild(new CSharpTokenNode(Convert(locations3[1]), Roles.RPar), Roles.RPar);
										}
										break;
									}
									}
								}
								if (locations2 != null && num < locations2.Count)
								{
									constraint.AddChild(new CSharpTokenNode(Convert(locations2[num++]), Roles.Comma), Roles.Comma);
								}
							}
						}
						AstNode astNode = parent.LastChild;
						while (astNode.StartLocation > constraint.StartLocation && astNode.PrevSibling != null)
						{
							astNode = astNode.PrevSibling;
						}
						parent.InsertChildAfter(astNode, constraint, Roles.Constraint);
					}
				}
			}

			private Expression ConvertArgument(Argument arg)
			{
				NamedArgument namedArgument = arg as NamedArgument;
				if (namedArgument != null)
				{
					NamedArgumentExpression namedArgumentExpression = new NamedArgumentExpression();
					namedArgumentExpression.AddChild(Identifier.Create(namedArgument.Name, Convert(namedArgument.Location)), Roles.Identifier);
					List<Location> locations = LocationsBag.GetLocations(namedArgument);
					if (locations != null)
					{
						namedArgumentExpression.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Colon), Roles.Colon);
					}
					if (arg.ArgType == Argument.AType.Out || arg.ArgType == Argument.AType.Ref)
					{
						DirectionExpression directionExpression = new DirectionExpression();
						directionExpression.FieldDirection = ((arg.ArgType == Argument.AType.Out) ? FieldDirection.Out : FieldDirection.Ref);
						List<Location> locations2 = LocationsBag.GetLocations(arg);
						if (locations2 != null)
						{
							TokenRole role = (arg.ArgType == Argument.AType.Out) ? DirectionExpression.OutKeywordRole : DirectionExpression.RefKeywordRole;
							directionExpression.AddChild(new CSharpTokenNode(Convert(locations2[0]), role), role);
						}
						directionExpression.AddChild((Expression)arg.Expr.Accept(this), Roles.Expression);
						namedArgumentExpression.AddChild(directionExpression, Roles.Expression);
					}
					else
					{
						namedArgumentExpression.AddChild((namedArgument.Expr != null) ? ((Expression)namedArgument.Expr.Accept(this)) : new ErrorExpression("Named argument expression parse error"), Roles.Expression);
					}
					return namedArgumentExpression;
				}
				if (arg.ArgType == Argument.AType.Out || arg.ArgType == Argument.AType.Ref)
				{
					DirectionExpression directionExpression2 = new DirectionExpression();
					directionExpression2.FieldDirection = ((arg.ArgType == Argument.AType.Out) ? FieldDirection.Out : FieldDirection.Ref);
					List<Location> locations3 = LocationsBag.GetLocations(arg);
					if (locations3 != null)
					{
						TokenRole role2 = (arg.ArgType == Argument.AType.Out) ? DirectionExpression.OutKeywordRole : DirectionExpression.RefKeywordRole;
						directionExpression2.AddChild(new CSharpTokenNode(Convert(locations3[0]), role2), role2);
					}
					directionExpression2.AddChild((Expression)arg.Expr.Accept(this), Roles.Expression);
					return directionExpression2;
				}
				return (Expression)arg.Expr.Accept(this);
			}

			private void AddArguments(AstNode parent, Arguments args)
			{
				if (args == null)
				{
					return;
				}
				List<Location> locations = LocationsBag.GetLocations(args);
				for (int i = 0; i < args.Count; i++)
				{
					parent.AddChild(ConvertArgument(args[i]), Roles.Argument);
					if (locations != null && i < locations.Count)
					{
						parent.AddChild(new CSharpTokenNode(Convert(locations[i]), Roles.Comma), Roles.Comma);
					}
				}
				if (locations != null && locations.Count > args.Count)
				{
					parent.AddChild(new CSharpTokenNode(Convert(locations[args.Count]), Roles.Comma), Roles.Comma);
				}
			}

			public override object Visit(Invocation invocationExpression)
			{
				InvocationExpression invocationExpression2 = new InvocationExpression();
				List<Location> locations = LocationsBag.GetLocations(invocationExpression);
				if (invocationExpression.Exp != null)
				{
					invocationExpression2.AddChild((Expression)invocationExpression.Exp.Accept(this), Roles.TargetExpression);
				}
				if (locations != null)
				{
					invocationExpression2.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.LPar), Roles.LPar);
				}
				AddArguments(invocationExpression2, invocationExpression.Arguments);
				if (locations != null && locations.Count > 1)
				{
					invocationExpression2.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.RPar), Roles.RPar);
				}
				return invocationExpression2;
			}

			public override object Visit(New newExpression)
			{
				ObjectCreateExpression objectCreateExpression = new ObjectCreateExpression();
				List<Location> locations = LocationsBag.GetLocations(newExpression);
				objectCreateExpression.AddChild(new CSharpTokenNode(Convert(newExpression.Location), ObjectCreateExpression.NewKeywordRole), ObjectCreateExpression.NewKeywordRole);
				if (newExpression.TypeRequested != null)
				{
					objectCreateExpression.AddChild(ConvertToType(newExpression.TypeRequested), Roles.Type);
				}
				if (locations != null)
				{
					objectCreateExpression.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.LPar), Roles.LPar);
				}
				AddArguments(objectCreateExpression, newExpression.Arguments);
				if (locations != null && locations.Count > 1)
				{
					objectCreateExpression.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.RPar), Roles.RPar);
				}
				return objectCreateExpression;
			}

			public override object Visit(NewAnonymousType newAnonymousType)
			{
				AnonymousTypeCreateExpression anonymousTypeCreateExpression = new AnonymousTypeCreateExpression();
				List<Location> locations = LocationsBag.GetLocations(newAnonymousType);
				anonymousTypeCreateExpression.AddChild(new CSharpTokenNode(Convert(newAnonymousType.Location), ObjectCreateExpression.NewKeywordRole), ObjectCreateExpression.NewKeywordRole);
				if (locations != null)
				{
					anonymousTypeCreateExpression.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.LBrace), Roles.LBrace);
				}
				if (newAnonymousType.Parameters != null)
				{
					foreach (AnonymousTypeParameter parameter in newAnonymousType.Parameters)
					{
						if (parameter != null)
						{
							List<Location> locations2 = LocationsBag.GetLocations(parameter);
							if (locations2 == null)
							{
								if (parameter.Expr != null)
								{
									anonymousTypeCreateExpression.AddChild((Expression)parameter.Expr.Accept(this), Roles.Expression);
								}
							}
							else
							{
								NamedExpression namedExpression = new NamedExpression();
								namedExpression.AddChild(Identifier.Create(parameter.Name, Convert(parameter.Location)), Roles.Identifier);
								namedExpression.AddChild(new CSharpTokenNode(Convert(locations2[0]), Roles.Assign), Roles.Assign);
								if (parameter.Expr != null)
								{
									namedExpression.AddChild((Expression)parameter.Expr.Accept(this), Roles.Expression);
								}
								anonymousTypeCreateExpression.AddChild(namedExpression, Roles.Expression);
							}
						}
					}
				}
				if (locations != null && locations.Count > 1)
				{
					anonymousTypeCreateExpression.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.RBrace), Roles.RBrace);
				}
				return anonymousTypeCreateExpression;
			}

			private ArrayInitializerExpression ConvertCollectionOrObjectInitializers(CollectionOrObjectInitializers minit)
			{
				if (minit == null)
				{
					return null;
				}
				ArrayInitializerExpression arrayInitializerExpression = new ArrayInitializerExpression();
				AddConvertCollectionOrObjectInitializers(arrayInitializerExpression, minit);
				return arrayInitializerExpression;
			}

			private void AddConvertCollectionOrObjectInitializers(Expression init, CollectionOrObjectInitializers minit)
			{
				List<Location> locations = LocationsBag.GetLocations(minit);
				List<Location> locations2 = LocationsBag.GetLocations(minit.Initializers);
				int num = 0;
				init.AddChild(new CSharpTokenNode(Convert(minit.Location), Roles.LBrace), Roles.LBrace);
				foreach (ICSharpCode.NRefactory.MonoCSharp.Expression initializer in minit.Initializers)
				{
					CollectionElementInitializer collectionElementInitializer = initializer as CollectionElementInitializer;
					if (collectionElementInitializer != null)
					{
						AstNode astNode;
						if (!collectionElementInitializer.IsSingle)
						{
							astNode = new ArrayInitializerExpression();
							astNode.AddChild(new CSharpTokenNode(Convert(collectionElementInitializer.Location), Roles.LBrace), Roles.LBrace);
						}
						else
						{
							astNode = ArrayInitializerExpression.CreateSingleElementInitializer();
						}
						if (collectionElementInitializer.Arguments != null)
						{
							for (int i = 0; i < collectionElementInitializer.Arguments.Count; i++)
							{
								CollectionElementInitializer.ElementInitializerArgument elementInitializerArgument = collectionElementInitializer.Arguments[i] as CollectionElementInitializer.ElementInitializerArgument;
								if (elementInitializerArgument != null && elementInitializerArgument.Expr != null)
								{
									astNode.AddChild((Expression)elementInitializerArgument.Expr.Accept(this), Roles.Expression);
								}
							}
						}
						if (!collectionElementInitializer.IsSingle)
						{
							List<Location> locations3 = LocationsBag.GetLocations(initializer);
							if (locations3 != null)
							{
								astNode.AddChild(new CSharpTokenNode(Convert(locations3[0]), Roles.RBrace), Roles.RBrace);
							}
						}
						init.AddChild((ArrayInitializerExpression)astNode, Roles.Expression);
					}
					else
					{
						ElementInitializer elementInitializer = initializer as ElementInitializer;
						if (elementInitializer != null)
						{
							NamedExpression namedExpression = new NamedExpression();
							namedExpression.AddChild(Identifier.Create(elementInitializer.Name, Convert(elementInitializer.Location)), Roles.Identifier);
							List<Location> locations4 = LocationsBag.GetLocations(elementInitializer);
							if (locations4 != null)
							{
								namedExpression.AddChild(new CSharpTokenNode(Convert(locations4[0]), Roles.Assign), Roles.Assign);
							}
							if (elementInitializer.Source != null)
							{
								CollectionOrObjectInitializers collectionOrObjectInitializers = elementInitializer.Source as CollectionOrObjectInitializers;
								if (collectionOrObjectInitializers != null)
								{
									ArrayInitializerExpression arrayInitializerExpression = new ArrayInitializerExpression();
									AddConvertCollectionOrObjectInitializers(arrayInitializerExpression, collectionOrObjectInitializers);
									namedExpression.AddChild(arrayInitializerExpression, Roles.Expression);
								}
								else
								{
									namedExpression.AddChild((Expression)elementInitializer.Source.Accept(this), Roles.Expression);
								}
							}
							init.AddChild(namedExpression, Roles.Expression);
						}
					}
					if (locations2 != null && num < locations2.Count)
					{
						init.AddChild(new CSharpTokenNode(Convert(locations2[num++]), Roles.Comma), Roles.Comma);
					}
				}
				if (locations != null)
				{
					if (locations.Count == 2)
					{
						init.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Comma), Roles.Comma);
					}
					init.AddChild(new CSharpTokenNode(Convert(locations[locations.Count - 1]), Roles.RBrace), Roles.RBrace);
				}
			}

			public override object Visit(NewInitialize newInitializeExpression)
			{
				ObjectCreateExpression objectCreateExpression = new ObjectCreateExpression();
				objectCreateExpression.AddChild(new CSharpTokenNode(Convert(newInitializeExpression.Location), ObjectCreateExpression.NewKeywordRole), ObjectCreateExpression.NewKeywordRole);
				if (newInitializeExpression.TypeRequested != null)
				{
					objectCreateExpression.AddChild(ConvertToType(newInitializeExpression.TypeRequested), Roles.Type);
				}
				List<Location> locations = LocationsBag.GetLocations(newInitializeExpression);
				if (locations != null)
				{
					objectCreateExpression.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.LPar), Roles.LPar);
				}
				AddArguments(objectCreateExpression, newInitializeExpression.Arguments);
				if (locations != null && locations.Count > 1)
				{
					objectCreateExpression.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.RPar), Roles.RPar);
				}
				ArrayInitializerExpression arrayInitializerExpression = ConvertCollectionOrObjectInitializers(newInitializeExpression.Initializers);
				if (arrayInitializerExpression != null)
				{
					objectCreateExpression.AddChild(arrayInitializerExpression, ObjectCreateExpression.InitializerRole);
				}
				return objectCreateExpression;
			}

			public override object Visit(ArrayCreation arrayCreationExpression)
			{
				ArrayCreateExpression arrayCreateExpression = new ArrayCreateExpression();
				List<Location> locations = LocationsBag.GetLocations(arrayCreationExpression);
				arrayCreateExpression.AddChild(new CSharpTokenNode(Convert(arrayCreationExpression.Location), ArrayCreateExpression.NewKeywordRole), ArrayCreateExpression.NewKeywordRole);
				if (arrayCreationExpression.TypeExpression != null)
				{
					arrayCreateExpression.AddChild(ConvertToType(arrayCreationExpression.TypeExpression), Roles.Type);
				}
				ComposedTypeSpecifier composedTypeSpecifier = arrayCreationExpression.Rank;
				if (arrayCreationExpression.Arguments != null)
				{
					composedTypeSpecifier = composedTypeSpecifier.Next;
					if (locations != null)
					{
						arrayCreateExpression.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.LBracket), Roles.LBracket);
					}
					List<Location> locations2 = LocationsBag.GetLocations(arrayCreationExpression.Arguments);
					for (int i = 0; i < arrayCreationExpression.Arguments.Count; i++)
					{
						ICSharpCode.NRefactory.MonoCSharp.Expression expression = arrayCreationExpression.Arguments[i];
						if (expression != null)
						{
							arrayCreateExpression.AddChild((Expression)expression.Accept(this), Roles.Argument);
						}
						if (locations2 != null && i < locations2.Count)
						{
							arrayCreateExpression.AddChild(new CSharpTokenNode(Convert(locations2[i]), Roles.Comma), Roles.Comma);
						}
					}
					if (locations != null && locations.Count > 1)
					{
						arrayCreateExpression.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.RBracket), Roles.RBracket);
					}
				}
				while (composedTypeSpecifier != null)
				{
					ArraySpecifier arraySpecifier = new ArraySpecifier(composedTypeSpecifier.Dimension);
					List<Location> locations3 = LocationsBag.GetLocations(composedTypeSpecifier);
					arraySpecifier.AddChild(new CSharpTokenNode(Convert(composedTypeSpecifier.Location), Roles.LBracket), Roles.LBracket);
					arrayCreateExpression.AddChild(arraySpecifier, ArrayCreateExpression.AdditionalArraySpecifierRole);
					if (locations3 != null)
					{
						arrayCreateExpression.AddChild(new CSharpTokenNode(Convert(locations3[0]), Roles.RBracket), Roles.RBracket);
					}
					composedTypeSpecifier = composedTypeSpecifier.Next;
				}
				if (arrayCreationExpression.Initializers != null)
				{
					List<Location> locations4 = LocationsBag.GetLocations(arrayCreationExpression.Initializers);
					ArrayInitializerExpression arrayInitializerExpression = new ArrayInitializerExpression();
					arrayInitializerExpression.AddChild(new CSharpTokenNode(Convert(arrayCreationExpression.Initializers.Location), Roles.LBrace), Roles.LBrace);
					List<Location> locations5 = LocationsBag.GetLocations(arrayCreationExpression.Initializers.Elements);
					for (int j = 0; j < arrayCreationExpression.Initializers.Count; j++)
					{
						ICSharpCode.NRefactory.MonoCSharp.Expression expression2 = arrayCreationExpression.Initializers[j];
						if (expression2 != null)
						{
							arrayInitializerExpression.AddChild((Expression)expression2.Accept(this), Roles.Expression);
							if (locations5 != null && j < locations5.Count)
							{
								arrayInitializerExpression.AddChild(new CSharpTokenNode(Convert(locations5[j]), Roles.Comma), Roles.Comma);
							}
						}
					}
					if (locations4 != null)
					{
						if (locations4.Count == 2)
						{
							arrayInitializerExpression.AddChild(new CSharpTokenNode(Convert(locations4[0]), Roles.Comma), Roles.Comma);
						}
						arrayInitializerExpression.AddChild(new CSharpTokenNode(Convert(locations4[locations4.Count - 1]), Roles.RBrace), Roles.RBrace);
					}
					arrayCreateExpression.AddChild(arrayInitializerExpression, ArrayCreateExpression.InitializerRole);
				}
				return arrayCreateExpression;
			}

			public override object Visit(This thisExpression)
			{
				return new ThisReferenceExpression
				{
					Location = Convert(thisExpression.Location)
				};
			}

			public override object Visit(ArglistAccess argListAccessExpression)
			{
				UndocumentedExpression undocumentedExpression = new UndocumentedExpression();
				undocumentedExpression.UndocumentedExpressionType = UndocumentedExpressionType.ArgListAccess;
				undocumentedExpression.AddChild(new CSharpTokenNode(Convert(argListAccessExpression.Location), UndocumentedExpression.ArglistKeywordRole), UndocumentedExpression.ArglistKeywordRole);
				return undocumentedExpression;
			}

			public override object Visit(Arglist argListExpression)
			{
				UndocumentedExpression undocumentedExpression = new UndocumentedExpression
				{
					UndocumentedExpressionType = UndocumentedExpressionType.ArgList
				};
				undocumentedExpression.AddChild(new CSharpTokenNode(Convert(argListExpression.Location), UndocumentedExpression.ArglistKeywordRole), UndocumentedExpression.ArglistKeywordRole);
				List<Location> locations = LocationsBag.GetLocations(argListExpression);
				if (locations != null)
				{
					undocumentedExpression.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.LPar), Roles.LPar);
				}
				AddArguments(undocumentedExpression, argListExpression.Arguments);
				if (locations != null && locations.Count > 1)
				{
					undocumentedExpression.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.RPar), Roles.RPar);
				}
				return undocumentedExpression;
			}

			public override object Visit(MakeRefExpr makeRefExpr)
			{
				UndocumentedExpression undocumentedExpression = new UndocumentedExpression
				{
					UndocumentedExpressionType = UndocumentedExpressionType.MakeRef
				};
				undocumentedExpression.AddChild(new CSharpTokenNode(Convert(makeRefExpr.Location), UndocumentedExpression.MakerefKeywordRole), UndocumentedExpression.MakerefKeywordRole);
				List<Location> locations = LocationsBag.GetLocations(makeRefExpr);
				if (locations != null)
				{
					undocumentedExpression.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.LPar), Roles.LPar);
				}
				if (makeRefExpr.Expr != null)
				{
					undocumentedExpression.AddChild((Expression)makeRefExpr.Expr.Accept(this), Roles.Argument);
				}
				if (locations != null && locations.Count > 1)
				{
					undocumentedExpression.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.RPar), Roles.RPar);
				}
				return undocumentedExpression;
			}

			public override object Visit(RefTypeExpr refTypeExpr)
			{
				UndocumentedExpression undocumentedExpression = new UndocumentedExpression
				{
					UndocumentedExpressionType = UndocumentedExpressionType.RefType
				};
				undocumentedExpression.AddChild(new CSharpTokenNode(Convert(refTypeExpr.Location), UndocumentedExpression.ReftypeKeywordRole), UndocumentedExpression.ReftypeKeywordRole);
				List<Location> locations = LocationsBag.GetLocations(refTypeExpr);
				if (locations != null)
				{
					undocumentedExpression.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.LPar), Roles.LPar);
				}
				if (refTypeExpr.Expr != null)
				{
					undocumentedExpression.AddChild((Expression)refTypeExpr.Expr.Accept(this), Roles.Argument);
				}
				if (locations != null && locations.Count > 1)
				{
					undocumentedExpression.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.RPar), Roles.RPar);
				}
				return undocumentedExpression;
			}

			public override object Visit(RefValueExpr refValueExpr)
			{
				UndocumentedExpression undocumentedExpression = new UndocumentedExpression
				{
					UndocumentedExpressionType = UndocumentedExpressionType.RefValue
				};
				undocumentedExpression.AddChild(new CSharpTokenNode(Convert(refValueExpr.Location), UndocumentedExpression.RefvalueKeywordRole), UndocumentedExpression.RefvalueKeywordRole);
				List<Location> locations = LocationsBag.GetLocations(refValueExpr);
				if (locations != null)
				{
					undocumentedExpression.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.LPar), Roles.LPar);
				}
				if (refValueExpr.Expr != null)
				{
					undocumentedExpression.AddChild((Expression)refValueExpr.Expr.Accept(this), Roles.Argument);
				}
				if (refValueExpr.FullNamedExpression != null)
				{
					undocumentedExpression.AddChild((Expression)refValueExpr.FullNamedExpression.Accept(this), Roles.Argument);
				}
				if (locations != null && locations.Count > 1)
				{
					undocumentedExpression.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.RPar), Roles.RPar);
				}
				return undocumentedExpression;
			}

			public override object Visit(TypeOf typeOfExpression)
			{
				TypeOfExpression typeOfExpression2 = new TypeOfExpression();
				List<Location> locations = LocationsBag.GetLocations(typeOfExpression);
				typeOfExpression2.AddChild(new CSharpTokenNode(Convert(typeOfExpression.Location), TypeOfExpression.TypeofKeywordRole), TypeOfExpression.TypeofKeywordRole);
				if (locations != null)
				{
					typeOfExpression2.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.LPar), Roles.LPar);
				}
				if (typeOfExpression.TypeExpression != null)
				{
					typeOfExpression2.AddChild(ConvertToType(typeOfExpression.TypeExpression), Roles.Type);
				}
				if (locations != null && locations.Count > 1)
				{
					typeOfExpression2.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.RPar), Roles.RPar);
				}
				return typeOfExpression2;
			}

			public override object Visit(SizeOf sizeOfExpression)
			{
				SizeOfExpression sizeOfExpression2 = new SizeOfExpression();
				List<Location> locations = LocationsBag.GetLocations(sizeOfExpression);
				sizeOfExpression2.AddChild(new CSharpTokenNode(Convert(sizeOfExpression.Location), SizeOfExpression.SizeofKeywordRole), SizeOfExpression.SizeofKeywordRole);
				if (locations != null)
				{
					sizeOfExpression2.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.LPar), Roles.LPar);
				}
				if (sizeOfExpression.TypeExpression != null)
				{
					sizeOfExpression2.AddChild(ConvertToType(sizeOfExpression.TypeExpression), Roles.Type);
				}
				if (locations != null && locations.Count > 1)
				{
					sizeOfExpression2.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.RPar), Roles.RPar);
				}
				return sizeOfExpression2;
			}

			public override object Visit(CheckedExpr checkedExpression)
			{
				CheckedExpression checkedExpression2 = new CheckedExpression();
				List<Location> locations = LocationsBag.GetLocations(checkedExpression);
				checkedExpression2.AddChild(new CSharpTokenNode(Convert(checkedExpression.Location), CheckedExpression.CheckedKeywordRole), CheckedExpression.CheckedKeywordRole);
				if (locations != null)
				{
					checkedExpression2.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.LPar), Roles.LPar);
				}
				if (checkedExpression.Expr != null)
				{
					checkedExpression2.AddChild((Expression)checkedExpression.Expr.Accept(this), Roles.Expression);
				}
				if (locations != null && locations.Count > 1)
				{
					checkedExpression2.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.RPar), Roles.RPar);
				}
				return checkedExpression2;
			}

			public override object Visit(UnCheckedExpr uncheckedExpression)
			{
				UncheckedExpression uncheckedExpression2 = new UncheckedExpression();
				List<Location> locations = LocationsBag.GetLocations(uncheckedExpression);
				uncheckedExpression2.AddChild(new CSharpTokenNode(Convert(uncheckedExpression.Location), UncheckedExpression.UncheckedKeywordRole), UncheckedExpression.UncheckedKeywordRole);
				if (locations != null)
				{
					uncheckedExpression2.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.LPar), Roles.LPar);
				}
				if (uncheckedExpression.Expr != null)
				{
					uncheckedExpression2.AddChild((Expression)uncheckedExpression.Expr.Accept(this), Roles.Expression);
				}
				if (locations != null && locations.Count > 1)
				{
					uncheckedExpression2.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.RPar), Roles.RPar);
				}
				return uncheckedExpression2;
			}

			public override object Visit(ElementAccess elementAccessExpression)
			{
				IndexerExpression indexerExpression = new IndexerExpression();
				List<Location> locations = LocationsBag.GetLocations(elementAccessExpression);
				if (elementAccessExpression.Expr != null)
				{
					indexerExpression.AddChild((Expression)elementAccessExpression.Expr.Accept(this), Roles.TargetExpression);
				}
				indexerExpression.AddChild(new CSharpTokenNode(Convert(elementAccessExpression.Location), Roles.LBracket), Roles.LBracket);
				AddArguments(indexerExpression, elementAccessExpression.Arguments);
				if (locations != null)
				{
					indexerExpression.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.RBracket), Roles.RBracket);
				}
				return indexerExpression;
			}

			public override object Visit(BaseThis baseAccessExpression)
			{
				return new BaseReferenceExpression
				{
					Location = Convert(baseAccessExpression.Location)
				};
			}

			public override object Visit(StackAlloc stackAllocExpression)
			{
				StackAllocExpression stackAllocExpression2 = new StackAllocExpression();
				List<Location> locations = LocationsBag.GetLocations(stackAllocExpression);
				if (locations != null)
				{
					stackAllocExpression2.AddChild(new CSharpTokenNode(Convert(locations[0]), StackAllocExpression.StackallocKeywordRole), StackAllocExpression.StackallocKeywordRole);
				}
				if (stackAllocExpression.TypeExpression != null)
				{
					stackAllocExpression2.AddChild(ConvertToType(stackAllocExpression.TypeExpression), Roles.Type);
				}
				if (locations != null && locations.Count > 1)
				{
					stackAllocExpression2.AddChild(new CSharpTokenNode(Convert(locations[1]), Roles.LBracket), Roles.LBracket);
				}
				if (stackAllocExpression.CountExpression != null)
				{
					stackAllocExpression2.AddChild((Expression)stackAllocExpression.CountExpression.Accept(this), Roles.Expression);
				}
				if (locations != null && locations.Count > 2)
				{
					stackAllocExpression2.AddChild(new CSharpTokenNode(Convert(locations[2]), Roles.RBracket), Roles.RBracket);
				}
				return stackAllocExpression2;
			}

			public override object Visit(SimpleAssign simpleAssign)
			{
				AssignmentExpression assignmentExpression = new AssignmentExpression();
				assignmentExpression.Operator = AssignmentOperatorType.Assign;
				if (simpleAssign.Target != null)
				{
					assignmentExpression.AddChild((Expression)simpleAssign.Target.Accept(this), AssignmentExpression.LeftRole);
				}
				List<Location> locations = LocationsBag.GetLocations(simpleAssign);
				if (locations != null)
				{
					assignmentExpression.AddChild(new CSharpTokenNode(Convert(locations[0]), AssignmentExpression.AssignRole), AssignmentExpression.AssignRole);
				}
				if (simpleAssign.Source != null)
				{
					assignmentExpression.AddChild((Expression)simpleAssign.Source.Accept(this), AssignmentExpression.RightRole);
				}
				return assignmentExpression;
			}

			public override object Visit(CompoundAssign compoundAssign)
			{
				AssignmentExpression assignmentExpression = new AssignmentExpression();
				switch (compoundAssign.Op)
				{
				case Binary.Operator.Multiply:
					assignmentExpression.Operator = AssignmentOperatorType.Multiply;
					break;
				case Binary.Operator.Division:
					assignmentExpression.Operator = AssignmentOperatorType.Divide;
					break;
				case Binary.Operator.Modulus:
					assignmentExpression.Operator = AssignmentOperatorType.Modulus;
					break;
				case Binary.Operator.Addition:
					assignmentExpression.Operator = AssignmentOperatorType.Add;
					break;
				case Binary.Operator.Subtraction:
					assignmentExpression.Operator = AssignmentOperatorType.Subtract;
					break;
				case Binary.Operator.LeftShift:
					assignmentExpression.Operator = AssignmentOperatorType.ShiftLeft;
					break;
				case Binary.Operator.RightShift:
					assignmentExpression.Operator = AssignmentOperatorType.ShiftRight;
					break;
				case Binary.Operator.BitwiseAnd:
					assignmentExpression.Operator = AssignmentOperatorType.BitwiseAnd;
					break;
				case Binary.Operator.BitwiseOr:
					assignmentExpression.Operator = AssignmentOperatorType.BitwiseOr;
					break;
				case Binary.Operator.ExclusiveOr:
					assignmentExpression.Operator = AssignmentOperatorType.ExclusiveOr;
					break;
				}
				if (compoundAssign.Target != null)
				{
					assignmentExpression.AddChild((Expression)compoundAssign.Target.Accept(this), AssignmentExpression.LeftRole);
				}
				List<Location> locations = LocationsBag.GetLocations(compoundAssign);
				if (locations != null)
				{
					TokenRole operatorRole = AssignmentExpression.GetOperatorRole(assignmentExpression.Operator);
					assignmentExpression.AddChild(new CSharpTokenNode(Convert(locations[0]), operatorRole), operatorRole);
				}
				if (compoundAssign.Source != null)
				{
					assignmentExpression.AddChild((Expression)compoundAssign.Source.Accept(this), AssignmentExpression.RightRole);
				}
				return assignmentExpression;
			}

			public override object Visit(ICSharpCode.NRefactory.MonoCSharp.AnonymousMethodExpression anonymousMethodExpression)
			{
				AnonymousMethodExpression anonymousMethodExpression2 = new AnonymousMethodExpression();
				List<Location> locations = LocationsBag.GetLocations(anonymousMethodExpression);
				int num = 0;
				if (anonymousMethodExpression.IsAsync)
				{
					anonymousMethodExpression2.IsAsync = true;
					anonymousMethodExpression2.AddChild(new CSharpTokenNode(Convert(locations[num++]), AnonymousMethodExpression.AsyncModifierRole), AnonymousMethodExpression.AsyncModifierRole);
				}
				if (locations != null)
				{
					anonymousMethodExpression2.AddChild(new CSharpTokenNode(Convert(locations[num++]), AnonymousMethodExpression.DelegateKeywordRole), AnonymousMethodExpression.DelegateKeywordRole);
					if (locations.Count > num)
					{
						anonymousMethodExpression2.HasParameterList = true;
						anonymousMethodExpression2.AddChild(new CSharpTokenNode(Convert(locations[num++]), Roles.LPar), Roles.LPar);
						AddParameter(anonymousMethodExpression2, anonymousMethodExpression.Parameters);
						anonymousMethodExpression2.AddChild(new CSharpTokenNode(Convert(locations[num++]), Roles.RPar), Roles.RPar);
					}
				}
				if (anonymousMethodExpression.Block != null)
				{
					BlockStatement blockStatement = anonymousMethodExpression.Block.Accept(this) as BlockStatement;
					if (blockStatement != null)
					{
						anonymousMethodExpression2.AddChild(blockStatement, Roles.Body);
					}
				}
				return anonymousMethodExpression2;
			}

			public override object Visit(ICSharpCode.NRefactory.MonoCSharp.LambdaExpression lambdaExpression)
			{
				LambdaExpression lambdaExpression2 = new LambdaExpression();
				List<Location> locations = LocationsBag.GetLocations(lambdaExpression);
				int num = 0;
				if (lambdaExpression.IsAsync)
				{
					lambdaExpression2.IsAsync = true;
					lambdaExpression2.AddChild(new CSharpTokenNode(Convert(locations[num++]), LambdaExpression.AsyncModifierRole), LambdaExpression.AsyncModifierRole);
				}
				if (locations == null || locations.Count == num + 1)
				{
					if (lambdaExpression.Block != null)
					{
						AddParameter(lambdaExpression2, lambdaExpression.Parameters);
					}
					if (locations != null)
					{
						lambdaExpression2.AddChild(new CSharpTokenNode(Convert(locations[num++]), LambdaExpression.ArrowRole), LambdaExpression.ArrowRole);
					}
				}
				else
				{
					lambdaExpression2.AddChild(new CSharpTokenNode(Convert(locations[num++]), Roles.LPar), Roles.LPar);
					if (lambdaExpression.Block != null)
					{
						AddParameter(lambdaExpression2, lambdaExpression.Parameters);
					}
					if (locations != null)
					{
						lambdaExpression2.AddChild(new CSharpTokenNode(Convert(locations[num++]), Roles.RPar), Roles.RPar);
						lambdaExpression2.AddChild(new CSharpTokenNode(Convert(locations[num++]), LambdaExpression.ArrowRole), LambdaExpression.ArrowRole);
					}
				}
				if (lambdaExpression.Block != null)
				{
					if (lambdaExpression.Block.IsCompilerGenerated)
					{
						ContextualReturn contextualReturn = (ContextualReturn)lambdaExpression.Block.Statements[0];
						lambdaExpression2.AddChild((AstNode)contextualReturn.Expr.Accept(this), LambdaExpression.BodyRole);
					}
					else
					{
						lambdaExpression2.AddChild((AstNode)lambdaExpression.Block.Accept(this), LambdaExpression.BodyRole);
					}
				}
				return lambdaExpression2;
			}

			public override object Visit(ConstInitializer constInitializer)
			{
				return constInitializer.Expr.Accept(this);
			}

			public override object Visit(ArrayInitializer arrayInitializer)
			{
				ArrayInitializerExpression arrayInitializerExpression = new ArrayInitializerExpression();
				List<Location> locations = LocationsBag.GetLocations(arrayInitializer);
				arrayInitializerExpression.AddChild(new CSharpTokenNode(Convert(arrayInitializer.Location), Roles.LBrace), Roles.LBrace);
				List<Location> locations2 = LocationsBag.GetLocations(arrayInitializer.Elements);
				for (int i = 0; i < arrayInitializer.Count; i++)
				{
					ICSharpCode.NRefactory.MonoCSharp.Expression expression = arrayInitializer[i];
					if (expression != null)
					{
						arrayInitializerExpression.AddChild((Expression)expression.Accept(this), Roles.Expression);
						if (locations2 != null && i < locations2.Count)
						{
							arrayInitializerExpression.AddChild(new CSharpTokenNode(Convert(locations2[i]), Roles.Comma), Roles.Comma);
						}
					}
				}
				if (locations != null)
				{
					if (locations.Count == 2)
					{
						arrayInitializerExpression.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Comma), Roles.Comma);
					}
					arrayInitializerExpression.AddChild(new CSharpTokenNode(Convert(locations[locations.Count - 1]), Roles.RBrace), Roles.RBrace);
				}
				return arrayInitializerExpression;
			}

			public override object Visit(ICSharpCode.NRefactory.MonoCSharp.Linq.QueryExpression queryExpression)
			{
				QueryOrderClause queryOrderClause = currentQueryOrderClause;
				try
				{
					currentQueryOrderClause = null;
					QueryExpression queryExpression2 = new QueryExpression();
					for (AQueryClause next = queryExpression.next; next != null; next = next.next)
					{
						QueryClause queryClause = (QueryClause)next.Accept(this);
						if (queryClause is QueryContinuationClause)
						{
							queryClause.InsertChildAfter(null, queryExpression2, QueryContinuationClause.PrecedingQueryRole);
							queryExpression2 = new QueryExpression();
						}
						if (queryClause != null)
						{
							queryExpression2.AddChild(queryClause, QueryExpression.ClauseRole);
						}
					}
					return queryExpression2;
				}
				finally
				{
					currentQueryOrderClause = queryOrderClause;
				}
			}

			public override object Visit(QueryStartClause queryExpression)
			{
				if (queryExpression.Expr == null)
				{
					QueryContinuationClause queryContinuationClause = new QueryContinuationClause();
					queryContinuationClause.AddChild(new CSharpTokenNode(Convert(queryExpression.Location), QueryContinuationClause.IntoKeywordRole), QueryContinuationClause.IntoKeywordRole);
					queryContinuationClause.AddChild(Identifier.Create(queryExpression.IntoVariable.Name, Convert(queryExpression.IntoVariable.Location)), Roles.Identifier);
					return queryContinuationClause;
				}
				QueryFromClause queryFromClause = new QueryFromClause();
				queryFromClause.AddChild(new CSharpTokenNode(Convert(queryExpression.Location), QueryFromClause.FromKeywordRole), QueryFromClause.FromKeywordRole);
				if (queryExpression.IdentifierType != null)
				{
					queryFromClause.AddChild(ConvertToType(queryExpression.IdentifierType), Roles.Type);
				}
				queryFromClause.AddChild(Identifier.Create(queryExpression.IntoVariable.Name, Convert(queryExpression.IntoVariable.Location)), Roles.Identifier);
				List<Location> locations = LocationsBag.GetLocations(queryExpression);
				if (locations != null)
				{
					queryFromClause.AddChild(new CSharpTokenNode(Convert(locations[0]), QueryFromClause.InKeywordRole), QueryFromClause.InKeywordRole);
				}
				if (queryExpression.Expr != null)
				{
					queryFromClause.AddChild((Expression)queryExpression.Expr.Accept(this), Roles.Expression);
				}
				return queryFromClause;
			}

			public override object Visit(SelectMany selectMany)
			{
				QueryFromClause queryFromClause = new QueryFromClause();
				queryFromClause.AddChild(new CSharpTokenNode(Convert(selectMany.Location), QueryFromClause.FromKeywordRole), QueryFromClause.FromKeywordRole);
				if (selectMany.IdentifierType != null)
				{
					queryFromClause.AddChild(ConvertToType(selectMany.IdentifierType), Roles.Type);
				}
				queryFromClause.AddChild(Identifier.Create(selectMany.IntoVariable.Name, Convert(selectMany.IntoVariable.Location)), Roles.Identifier);
				List<Location> locations = LocationsBag.GetLocations(selectMany);
				if (locations != null)
				{
					queryFromClause.AddChild(new CSharpTokenNode(Convert(locations[0]), QueryFromClause.InKeywordRole), QueryFromClause.InKeywordRole);
				}
				if (selectMany.Expr != null)
				{
					queryFromClause.AddChild((Expression)selectMany.Expr.Accept(this), Roles.Expression);
				}
				return queryFromClause;
			}

			public override object Visit(Select select)
			{
				QuerySelectClause querySelectClause = new QuerySelectClause();
				querySelectClause.AddChild(new CSharpTokenNode(Convert(select.Location), QuerySelectClause.SelectKeywordRole), QuerySelectClause.SelectKeywordRole);
				if (select.Expr != null)
				{
					querySelectClause.AddChild((Expression)select.Expr.Accept(this), Roles.Expression);
				}
				return querySelectClause;
			}

			public override object Visit(GroupBy groupBy)
			{
				QueryGroupClause queryGroupClause = new QueryGroupClause();
				List<Location> locations = LocationsBag.GetLocations(groupBy);
				queryGroupClause.AddChild(new CSharpTokenNode(Convert(groupBy.Location), QueryGroupClause.GroupKeywordRole), QueryGroupClause.GroupKeywordRole);
				if (groupBy.ElementSelector != null)
				{
					queryGroupClause.AddChild((Expression)groupBy.ElementSelector.Accept(this), QueryGroupClause.ProjectionRole);
				}
				if (locations != null)
				{
					TextLocation location = Convert(locations[0]);
					if (location.Line > 1 || location.Column > 1)
					{
						queryGroupClause.AddChild(new CSharpTokenNode(location, QueryGroupClause.ByKeywordRole), QueryGroupClause.ByKeywordRole);
					}
				}
				if (groupBy.Expr != null)
				{
					queryGroupClause.AddChild((Expression)groupBy.Expr.Accept(this), QueryGroupClause.KeyRole);
				}
				return queryGroupClause;
			}

			public override object Visit(Let let)
			{
				QueryLetClause queryLetClause = new QueryLetClause();
				List<Location> locations = LocationsBag.GetLocations(let);
				queryLetClause.AddChild(new CSharpTokenNode(Convert(let.Location), QueryLetClause.LetKeywordRole), QueryLetClause.LetKeywordRole);
				queryLetClause.AddChild(Identifier.Create(let.IntoVariable.Name, Convert(let.IntoVariable.Location)), Roles.Identifier);
				if (locations != null)
				{
					queryLetClause.AddChild(new CSharpTokenNode(Convert(locations[0]), Roles.Assign), Roles.Assign);
				}
				if (let.Expr != null)
				{
					queryLetClause.AddChild((Expression)let.Expr.Accept(this), Roles.Expression);
				}
				return queryLetClause;
			}

			public override object Visit(Where where)
			{
				QueryWhereClause queryWhereClause = new QueryWhereClause();
				queryWhereClause.AddChild(new CSharpTokenNode(Convert(where.Location), QueryWhereClause.WhereKeywordRole), QueryWhereClause.WhereKeywordRole);
				if (where.Expr != null)
				{
					queryWhereClause.AddChild((Expression)where.Expr.Accept(this), Roles.Condition);
				}
				return queryWhereClause;
			}

			public override object Visit(Join join)
			{
				QueryJoinClause queryJoinClause = new QueryJoinClause();
				List<Location> locations = LocationsBag.GetLocations(join);
				queryJoinClause.AddChild(new CSharpTokenNode(Convert(join.Location), QueryJoinClause.JoinKeywordRole), QueryJoinClause.JoinKeywordRole);
				if (join.IdentifierType != null)
				{
					queryJoinClause.AddChild(ConvertToType(join.IdentifierType), QueryJoinClause.TypeRole);
				}
				queryJoinClause.AddChild(Identifier.Create(join.JoinVariable.Name, Convert(join.JoinVariable.Location)), QueryJoinClause.JoinIdentifierRole);
				if (join.IdentifierType != null)
				{
					queryJoinClause.AddChild(ConvertToType(join.IdentifierType), QueryJoinClause.TypeRole);
				}
				if (locations != null)
				{
					queryJoinClause.AddChild(new CSharpTokenNode(Convert(locations[0]), QueryJoinClause.InKeywordRole), QueryJoinClause.InKeywordRole);
				}
				if (join.Expr != null)
				{
					queryJoinClause.AddChild((Expression)join.Expr.Accept(this), QueryJoinClause.InExpressionRole);
				}
				if (locations != null && locations.Count > 1)
				{
					queryJoinClause.AddChild(new CSharpTokenNode(Convert(locations[1]), QueryJoinClause.OnKeywordRole), QueryJoinClause.OnKeywordRole);
				}
				ContextualReturn contextualReturn = join.OuterSelector.Statements.FirstOrDefault() as ContextualReturn;
				if (contextualReturn != null)
				{
					queryJoinClause.AddChild((Expression)contextualReturn.Expr.Accept(this), QueryJoinClause.OnExpressionRole);
				}
				if (locations != null && locations.Count > 2)
				{
					queryJoinClause.AddChild(new CSharpTokenNode(Convert(locations[2]), QueryJoinClause.EqualsKeywordRole), QueryJoinClause.EqualsKeywordRole);
				}
				ContextualReturn contextualReturn2 = join.InnerSelector.Statements.FirstOrDefault() as ContextualReturn;
				if (contextualReturn2 != null)
				{
					queryJoinClause.AddChild((Expression)contextualReturn2.Expr.Accept(this), QueryJoinClause.EqualsExpressionRole);
				}
				return queryJoinClause;
			}

			public override object Visit(GroupJoin groupJoin)
			{
				QueryJoinClause queryJoinClause = new QueryJoinClause();
				List<Location> locations = LocationsBag.GetLocations(groupJoin);
				queryJoinClause.AddChild(new CSharpTokenNode(Convert(groupJoin.Location), QueryJoinClause.JoinKeywordRole), QueryJoinClause.JoinKeywordRole);
				queryJoinClause.AddChild(Identifier.Create(groupJoin.IntoVariable.Name, Convert(groupJoin.IntoVariable.Location)), QueryJoinClause.JoinIdentifierRole);
				if (locations != null)
				{
					queryJoinClause.AddChild(new CSharpTokenNode(Convert(locations[0]), QueryJoinClause.InKeywordRole), QueryJoinClause.InKeywordRole);
				}
				if (groupJoin.Expr != null)
				{
					queryJoinClause.AddChild((Expression)groupJoin.Expr.Accept(this), QueryJoinClause.InExpressionRole);
				}
				if (locations != null && locations.Count > 1)
				{
					queryJoinClause.AddChild(new CSharpTokenNode(Convert(locations[1]), QueryJoinClause.OnKeywordRole), QueryJoinClause.OnKeywordRole);
				}
				ContextualReturn contextualReturn = groupJoin.OuterSelector.Statements.FirstOrDefault() as ContextualReturn;
				if (contextualReturn != null)
				{
					queryJoinClause.AddChild((Expression)contextualReturn.Expr.Accept(this), QueryJoinClause.OnExpressionRole);
				}
				if (locations != null && locations.Count > 2)
				{
					queryJoinClause.AddChild(new CSharpTokenNode(Convert(locations[2]), QueryJoinClause.EqualsKeywordRole), QueryJoinClause.EqualsKeywordRole);
				}
				ContextualReturn contextualReturn2 = groupJoin.InnerSelector.Statements.FirstOrDefault() as ContextualReturn;
				if (contextualReturn2 != null)
				{
					queryJoinClause.AddChild((Expression)contextualReturn2.Expr.Accept(this), QueryJoinClause.EqualsExpressionRole);
				}
				if (locations != null && locations.Count > 3)
				{
					queryJoinClause.AddChild(new CSharpTokenNode(Convert(locations[3]), QueryJoinClause.IntoKeywordRole), QueryJoinClause.IntoKeywordRole);
				}
				queryJoinClause.AddChild(Identifier.Create(groupJoin.JoinVariable.Name, Convert(groupJoin.JoinVariable.Location)), QueryJoinClause.IntoIdentifierRole);
				return queryJoinClause;
			}

			public override object Visit(OrderByAscending orderByAscending)
			{
				currentQueryOrderClause = new QueryOrderClause();
				List<Location> locations = LocationsBag.GetLocations(orderByAscending.block);
				if (locations != null)
				{
					currentQueryOrderClause.AddChild(new CSharpTokenNode(Convert(locations[0]), QueryOrderClause.OrderbyKeywordRole), QueryOrderClause.OrderbyKeywordRole);
				}
				QueryOrdering queryOrdering = new QueryOrdering();
				if (orderByAscending.Expr != null)
				{
					queryOrdering.AddChild((Expression)orderByAscending.Expr.Accept(this), Roles.Expression);
				}
				List<Location> locations2 = LocationsBag.GetLocations(orderByAscending);
				if (locations2 != null)
				{
					queryOrdering.Direction = QueryOrderingDirection.Ascending;
					queryOrdering.AddChild(new CSharpTokenNode(Convert(locations2[0]), QueryOrdering.AscendingKeywordRole), QueryOrdering.AscendingKeywordRole);
				}
				currentQueryOrderClause.AddChild(queryOrdering, QueryOrderClause.OrderingRole);
				return currentQueryOrderClause;
			}

			public override object Visit(OrderByDescending orderByDescending)
			{
				currentQueryOrderClause = new QueryOrderClause();
				QueryOrdering queryOrdering = new QueryOrdering();
				if (orderByDescending.Expr != null)
				{
					queryOrdering.AddChild((Expression)orderByDescending.Expr.Accept(this), Roles.Expression);
				}
				List<Location> locations = LocationsBag.GetLocations(orderByDescending);
				if (locations != null)
				{
					queryOrdering.Direction = QueryOrderingDirection.Descending;
					queryOrdering.AddChild(new CSharpTokenNode(Convert(locations[0]), QueryOrdering.DescendingKeywordRole), QueryOrdering.DescendingKeywordRole);
				}
				currentQueryOrderClause.AddChild(queryOrdering, QueryOrderClause.OrderingRole);
				return currentQueryOrderClause;
			}

			public override object Visit(ThenByAscending thenByAscending)
			{
				QueryOrdering queryOrdering = new QueryOrdering();
				if (thenByAscending.Expr != null)
				{
					queryOrdering.AddChild((Expression)thenByAscending.Expr.Accept(this), Roles.Expression);
				}
				List<Location> locations = LocationsBag.GetLocations(thenByAscending);
				if (locations != null)
				{
					queryOrdering.Direction = QueryOrderingDirection.Ascending;
					queryOrdering.AddChild(new CSharpTokenNode(Convert(locations[0]), QueryOrdering.AscendingKeywordRole), QueryOrdering.AscendingKeywordRole);
				}
				currentQueryOrderClause.AddChild(queryOrdering, QueryOrderClause.OrderingRole);
				return null;
			}

			public override object Visit(ThenByDescending thenByDescending)
			{
				QueryOrdering queryOrdering = new QueryOrdering();
				if (thenByDescending.Expr != null)
				{
					queryOrdering.AddChild((Expression)thenByDescending.Expr.Accept(this), Roles.Expression);
				}
				List<Location> locations = LocationsBag.GetLocations(thenByDescending);
				if (locations != null)
				{
					queryOrdering.Direction = QueryOrderingDirection.Descending;
					queryOrdering.AddChild(new CSharpTokenNode(Convert(locations[0]), QueryOrdering.DescendingKeywordRole), QueryOrdering.DescendingKeywordRole);
				}
				currentQueryOrderClause.AddChild(queryOrdering, QueryOrderClause.OrderingRole);
				return null;
			}

			public override object Visit(Await awaitExpr)
			{
				UnaryOperatorExpression unaryOperatorExpression = new UnaryOperatorExpression();
				unaryOperatorExpression.Operator = UnaryOperatorType.Await;
				unaryOperatorExpression.AddChild(new CSharpTokenNode(Convert(awaitExpr.Location), UnaryOperatorExpression.AwaitRole), UnaryOperatorExpression.AwaitRole);
				if (awaitExpr.Expression != null)
				{
					unaryOperatorExpression.AddChild((Expression)awaitExpr.Expression.Accept(this), Roles.Expression);
				}
				return unaryOperatorExpression;
			}

			public DocumentationReference ConvertXmlDoc(DocumentationBuilder doc)
			{
				DocumentationReference documentationReference = new DocumentationReference();
				if (doc.ParsedName != null)
				{
					if (doc.ParsedName.Name == "<this>")
					{
						documentationReference.SymbolKind = SymbolKind.Indexer;
					}
					else
					{
						documentationReference.MemberName = doc.ParsedName.Name;
					}
					if (doc.ParsedName.Left != null)
					{
						documentationReference.DeclaringType = ConvertToType(doc.ParsedName.Left);
					}
					else if (doc.ParsedBuiltinType != null)
					{
						documentationReference.DeclaringType = ConvertToType(doc.ParsedBuiltinType);
					}
					if (doc.ParsedName.TypeParameters != null)
					{
						for (int i = 0; i < doc.ParsedName.TypeParameters.Count; i++)
						{
							documentationReference.TypeArguments.Add(ConvertToType(doc.ParsedName.TypeParameters[i]));
						}
					}
				}
				else if (doc.ParsedBuiltinType != null)
				{
					documentationReference.SymbolKind = SymbolKind.TypeDefinition;
					documentationReference.DeclaringType = ConvertToType(doc.ParsedBuiltinType);
				}
				if (doc.ParsedParameters != null)
				{
					documentationReference.HasParameterList = true;
					documentationReference.Parameters.AddRange(doc.ParsedParameters.Select(ConvertXmlDocParameter));
				}
				if (doc.ParsedOperator.HasValue)
				{
					documentationReference.SymbolKind = SymbolKind.Operator;
					documentationReference.OperatorType = (OperatorType)doc.ParsedOperator.Value;
					if (documentationReference.OperatorType == OperatorType.Implicit || documentationReference.OperatorType == OperatorType.Explicit)
					{
						ParameterDeclaration parameterDeclaration = documentationReference.Parameters.LastOrNullObject();
						parameterDeclaration.Remove();
						AstType type = parameterDeclaration.Type;
						type.Remove();
						documentationReference.ConversionOperatorReturnType = type;
					}
					if (documentationReference.Parameters.Count == 0)
					{
						documentationReference.HasParameterList = false;
					}
				}
				return documentationReference;
			}

			private ParameterDeclaration ConvertXmlDocParameter(DocumentationParameter p)
			{
				ParameterDeclaration parameterDeclaration = new ParameterDeclaration();
				switch (p.Modifier)
				{
				case Parameter.Modifier.OUT:
					parameterDeclaration.ParameterModifier = ParameterModifier.Out;
					break;
				case Parameter.Modifier.REF:
					parameterDeclaration.ParameterModifier = ParameterModifier.Ref;
					break;
				case Parameter.Modifier.PARAMS:
					parameterDeclaration.ParameterModifier = ParameterModifier.Params;
					break;
				}
				if (p.Type != null)
				{
					parameterDeclaration.Type = ConvertToType(p.Type);
				}
				return parameterDeclaration;
			}
		}

		public class ErrorReportPrinter : ReportPrinter
		{
			private readonly string fileName;

			public readonly List<Error> Errors = new List<Error>();

			public ErrorReportPrinter(string fileName)
			{
				this.fileName = fileName;
			}

			public override void Print(AbstractMessage msg, bool showFullPath)
			{
				base.Print(msg, showFullPath);
				Error item = new Error((!msg.IsWarning) ? ErrorType.Error : ErrorType.Warning, msg.Text, new DomRegion(fileName, msg.Location.Row, msg.Location.Column));
				Errors.Add(item);
			}
		}

		private CompilerSettings compilerSettings;

		private ErrorReportPrinter errorReportPrinter = new ErrorReportPrinter(null);

		private TextLocation initialLocation = new TextLocation(1, 1);

		internal static object parseLock = new object();

		[Obsolete("Use the Errors/Warnings/ErrorsAndWarnings properties instead")]
		public ErrorReportPrinter ErrorPrinter => errorReportPrinter;

		public bool HasErrors => errorReportPrinter.ErrorsCount > 0;

		public bool HasWarnings => errorReportPrinter.WarningsCount > 0;

		public IEnumerable<Error> Errors => from e in errorReportPrinter.Errors
			where e.ErrorType == ErrorType.Error
			select e;

		public IEnumerable<Error> Warnings => from e in errorReportPrinter.Errors
			where e.ErrorType == ErrorType.Warning
			select e;

		public IEnumerable<Error> ErrorsAndWarnings => errorReportPrinter.Errors;

		public CompilerSettings CompilerSettings
		{
			get
			{
				return compilerSettings;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException();
				}
				compilerSettings = value;
			}
		}

		public Action<CompilerCompilationUnit> CompilationUnitCallback
		{
			get;
			set;
		}

		public bool GenerateTypeSystemMode
		{
			get;
			set;
		}

		public TextLocation InitialLocation
		{
			get
			{
				return initialLocation;
			}
			set
			{
				initialLocation = value;
			}
		}

		public CSharpParser()
		{
			compilerSettings = new CompilerSettings();
		}

		public CSharpParser(CompilerSettings args)
		{
			compilerSettings = (args ?? new CompilerSettings());
		}

		private void InsertComments(CompilerCompilationUnit top, ConversionVisitor conversionVisitor)
		{
			AstNode insertionPoint = conversionVisitor.Unit.FirstChild;
			foreach (SpecialsBag.SpecialBase special in top.SpecialsBag.Specials)
			{
				AstNode astNode = null;
				Role role = null;
				bool flag = false;
				SpecialsBag.Comment comment = special as SpecialsBag.Comment;
				if (comment != null)
				{
					bool flag2 = comment.CommentType == SpecialsBag.CommentType.Multi && comment.Content.StartsWith("*", StringComparison.Ordinal) && !comment.Content.StartsWith("**", StringComparison.Ordinal);
					flag = ((comment.CommentType == SpecialsBag.CommentType.Documentation) | flag2);
					if (conversionVisitor.convertTypeSystemMode && !flag)
					{
						continue;
					}
					SpecialsBag.CommentType commentType = flag2 ? ((SpecialsBag.CommentType)4) : comment.CommentType;
					TextLocation startLocation = new TextLocation(comment.Line, comment.Col);
					TextLocation endLocation = new TextLocation(comment.EndLine, comment.EndCol);
					astNode = new Comment((CommentType)commentType, startLocation, endLocation)
					{
						StartsLine = comment.StartsLine,
						Content = (flag2 ? comment.Content.Substring(1) : comment.Content)
					};
					role = Roles.Comment;
				}
				else if (!GenerateTypeSystemMode)
				{
					SpecialsBag.PragmaPreProcessorDirective pragmaPreProcessorDirective = special as SpecialsBag.PragmaPreProcessorDirective;
					if (pragmaPreProcessorDirective != null)
					{
						PragmaWarningPreprocessorDirective pragmaWarningPreprocessorDirective = new PragmaWarningPreprocessorDirective(new TextLocation(pragmaPreProcessorDirective.Line, pragmaPreProcessorDirective.Col), new TextLocation(pragmaPreProcessorDirective.EndLine, pragmaPreProcessorDirective.EndCol));
						pragmaWarningPreprocessorDirective.AddChild(new CSharpTokenNode(new TextLocation(pragmaPreProcessorDirective.Line, pragmaPreProcessorDirective.Col), PragmaWarningPreprocessorDirective.PragmaKeywordRole), PragmaWarningPreprocessorDirective.PragmaKeywordRole);
						pragmaWarningPreprocessorDirective.AddChild(new CSharpTokenNode(new TextLocation(pragmaPreProcessorDirective.Line, pragmaPreProcessorDirective.WarningColumn), PragmaWarningPreprocessorDirective.WarningKeywordRole), PragmaWarningPreprocessorDirective.WarningKeywordRole);
						TokenRole role2 = pragmaPreProcessorDirective.Disalbe ? PragmaWarningPreprocessorDirective.DisableKeywordRole : PragmaWarningPreprocessorDirective.RestoreKeywordRole;
						pragmaWarningPreprocessorDirective.AddChild(new CSharpTokenNode(new TextLocation(pragmaPreProcessorDirective.Line, pragmaPreProcessorDirective.DisableRestoreColumn), role2), role2);
						foreach (Constant code in pragmaPreProcessorDirective.Codes)
						{
							pragmaWarningPreprocessorDirective.AddChild((PrimitiveExpression)conversionVisitor.Visit(code), PragmaWarningPreprocessorDirective.WarningRole);
						}
						astNode = pragmaWarningPreprocessorDirective;
						role = Roles.PreProcessorDirective;
					}
					else
					{
						SpecialsBag.LineProcessorDirective lineProcessorDirective = special as SpecialsBag.LineProcessorDirective;
						if (lineProcessorDirective != null)
						{
							astNode = new LinePreprocessorDirective(new TextLocation(lineProcessorDirective.Line, lineProcessorDirective.Col), new TextLocation(lineProcessorDirective.EndLine, lineProcessorDirective.EndCol))
							{
								LineNumber = lineProcessorDirective.LineNumber,
								FileName = lineProcessorDirective.FileName
							};
							role = Roles.PreProcessorDirective;
						}
						else
						{
							SpecialsBag.PreProcessorDirective preProcessorDirective = special as SpecialsBag.PreProcessorDirective;
							if (preProcessorDirective != null)
							{
								astNode = new PreProcessorDirective((PreProcessorDirectiveType)(preProcessorDirective.Cmd & (Tokenizer.PreprocessorDirective)15), new TextLocation(preProcessorDirective.Line, preProcessorDirective.Col), new TextLocation(preProcessorDirective.EndLine, preProcessorDirective.EndCol))
								{
									Argument = preProcessorDirective.Arg,
									Take = preProcessorDirective.Take
								};
								role = Roles.PreProcessorDirective;
							}
						}
					}
				}
				if (astNode != null)
				{
					InsertComment(ref insertionPoint, astNode, role, flag, conversionVisitor.Unit);
				}
			}
			if (GenerateTypeSystemMode)
			{
				return;
			}
			insertionPoint = conversionVisitor.Unit.FirstChild;
			for (int i = 0; i < top.SpecialsBag.Specials.Count; i++)
			{
				SpecialsBag.NewLineToken newLineToken = top.SpecialsBag.Specials[i] as SpecialsBag.NewLineToken;
				if (newLineToken != null)
				{
					NewLineNode newLineNode = new NewLineNode(new TextLocation(newLineToken.Line, newLineToken.Col + 1));
					newLineNode.NewLineType = ((newLineToken.NewLine == SpecialsBag.NewLine.Unix) ? UnicodeNewline.LF : UnicodeNewline.CRLF);
					InsertComment(ref insertionPoint, newLineNode, Roles.NewLine, isDocumentationComment: false, conversionVisitor.Unit);
				}
			}
		}

		private static void InsertComment(ref AstNode insertionPoint, AstNode newNode, Role role, bool isDocumentationComment, AstNode rootNode)
		{
			TextLocation startLocation = newNode.StartLocation;
			while (insertionPoint != null && insertionPoint.StartLocation < startLocation)
			{
				while (startLocation < insertionPoint.EndLocation && insertionPoint.FirstChild != null)
				{
					insertionPoint = insertionPoint.FirstChild;
				}
				insertionPoint = insertionPoint.GetNextNode();
			}
			if (isDocumentationComment && insertionPoint is EntityDeclaration && insertionPoint.FirstChild != null)
			{
				insertionPoint = insertionPoint.FirstChild;
			}
			if (insertionPoint == null)
			{
				rootNode.AddChildUnsafe(newNode, role);
			}
			else
			{
				insertionPoint.Parent.InsertChildBeforeUnsafe(insertionPoint, newNode, role);
			}
		}

		public SyntaxTree Parse(string program, string fileName = "")
		{
			return Parse(new StringTextSource(program), fileName);
		}

		public SyntaxTree Parse(TextReader reader, string fileName = "")
		{
			return Parse(new StringTextSource(reader.ReadToEnd()), fileName);
		}

		public SyntaxTree Parse(CompilerCompilationUnit top, string fileName)
		{
			if (top == null)
			{
				return null;
			}
			ConversionVisitor conversionVisitor = new ConversionVisitor(GenerateTypeSystemMode, top.LocationsBag);
			top.ModuleCompiled.Accept(conversionVisitor);
			InsertComments(top, conversionVisitor);
			if (CompilationUnitCallback != null)
			{
				CompilationUnitCallback(top);
			}
			ICSharpCode.NRefactory.MonoCSharp.Expression expression = top.LastYYValue as ICSharpCode.NRefactory.MonoCSharp.Expression;
			if (expression != null)
			{
				conversionVisitor.Unit.TopExpression = (expression.Accept(conversionVisitor) as AstNode);
			}
			conversionVisitor.Unit.FileName = fileName;
			List<string> list = new List<string>();
			foreach (string conditionalSymbol in compilerSettings.ConditionalSymbols)
			{
				if (!top.Conditionals.ContainsKey(conditionalSymbol) || top.Conditionals[conditionalSymbol])
				{
					list.Add(conditionalSymbol);
				}
			}
			foreach (KeyValuePair<string, bool> conditional in top.Conditionals)
			{
				if (conditional.Value && !compilerSettings.ConditionalSymbols.Contains(conditional.Key))
				{
					list.Add(conditional.Key);
				}
			}
			conversionVisitor.Unit.ConditionalSymbols = list;
			return conversionVisitor.Unit;
		}

		public SyntaxTree Parse(Stream stream, string fileName = "")
		{
			return Parse(new StreamReader(stream), fileName);
		}

		public SyntaxTree Parse(ITextSource program, string fileName = "")
		{
			return Parse(program, fileName, initialLocation.Line, initialLocation.Column);
		}

		private SyntaxTree Parse(ITextSource program, string fileName, int initialLine, int initialColumn)
		{
			lock (parseLock)
			{
				errorReportPrinter = new ErrorReportPrinter("");
				CompilerContext compilerContext = new CompilerContext(compilerSettings.ToMono(), errorReportPrinter);
				compilerContext.Settings.TabSize = 1;
				SeekableStreamReader reader = new SeekableStreamReader(program);
				SourceFile sourceFile = new SourceFile(fileName, fileName, 0);
				Location.Initialize(new List<SourceFile>(new SourceFile[1]
				{
					sourceFile
				}));
				ModuleContainer moduleContainer = new ModuleContainer(compilerContext);
				ParserSession parserSession = new ParserSession();
				parserSession.LocationsBag = new LocationsBag();
				Report report = new Report(compilerContext, errorReportPrinter);
				ICSharpCode.NRefactory.MonoCSharp.CSharpParser cSharpParser = Driver.Parse(reader, sourceFile, moduleContainer, parserSession, report, initialLine - 1, initialColumn - 1);
				CompilerCompilationUnit top = new CompilerCompilationUnit
				{
					ModuleCompiled = moduleContainer,
					LocationsBag = parserSession.LocationsBag,
					SpecialsBag = cSharpParser.Lexer.sbag,
					Conditionals = cSharpParser.Lexer.SourceFile.Conditionals
				};
				SyntaxTree syntaxTree = Parse(top, fileName);
				syntaxTree.Errors.AddRange(errorReportPrinter.Errors);
				CompilerCallableEntryPoint.Reset();
				return syntaxTree;
			}
		}

		public IEnumerable<EntityDeclaration> ParseTypeMembers(string code)
		{
			return ParseTypeMembers(code, initialLocation.Line, initialLocation.Column);
		}

		private IEnumerable<EntityDeclaration> ParseTypeMembers(string code, int initialLine, int initialColumn)
		{
			SyntaxTree syntaxTree = Parse(new StringTextSource("unsafe partial class MyClass { " + code + "}"), "parsed.cs", initialLine, initialColumn - "unsafe partial class MyClass { ".Length);
			if (syntaxTree == null)
			{
				return Enumerable.Empty<EntityDeclaration>();
			}
			TypeDeclaration typeDeclaration = syntaxTree.FirstChild as TypeDeclaration;
			if (typeDeclaration != null)
			{
				EntityDeclaration[] array = typeDeclaration.Members.ToArray();
				EntityDeclaration[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].Remove();
				}
				return array;
			}
			return Enumerable.Empty<EntityDeclaration>();
		}

		public IEnumerable<Statement> ParseStatements(string code)
		{
			return ParseStatements(code, initialLocation.Line, initialLocation.Column);
		}

		private IEnumerable<Statement> ParseStatements(string code, int initialLine, int initialColumn)
		{
			MethodDeclaration methodDeclaration = ParseTypeMembers("async void M() { " + code + "}", initialLine, initialColumn - "async void M() { ".Length).FirstOrDefault() as MethodDeclaration;
			if (methodDeclaration != null && methodDeclaration.Body != null)
			{
				Statement[] array = methodDeclaration.Body.Statements.ToArray();
				Statement[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].Remove();
				}
				return array;
			}
			return Enumerable.Empty<Statement>();
		}

		public AstType ParseTypeReference(string code)
		{
			FieldDeclaration fieldDeclaration = ParseTypeMembers(code + " a;").FirstOrDefault() as FieldDeclaration;
			if (fieldDeclaration != null)
			{
				AstType returnType = fieldDeclaration.ReturnType;
				returnType.Remove();
				return returnType;
			}
			return AstType.Null;
		}

		public Expression ParseExpression(string code)
		{
			ExpressionStatement expressionStatement = ParseStatements("tmp = " + code + ";", initialLocation.Line, initialLocation.Column - "tmp = ".Length).FirstOrDefault() as ExpressionStatement;
			if (expressionStatement != null)
			{
				AssignmentExpression assignmentExpression = expressionStatement.Expression as AssignmentExpression;
				if (assignmentExpression != null)
				{
					Expression right = assignmentExpression.Right;
					right.Remove();
					return right;
				}
			}
			return Expression.Null;
		}

		public DocumentationReference ParseDocumentationReference(string cref)
		{
			if (cref == null)
			{
				throw new ArgumentNullException("cref");
			}
			cref = cref.Replace('{', '<').Replace('}', '>');
			lock (parseLock)
			{
				errorReportPrinter = new ErrorReportPrinter("");
				CompilerContext compilerContext = new CompilerContext(compilerSettings.ToMono(), errorReportPrinter);
				compilerContext.Settings.TabSize = 1;
				SeekableStreamReader reader = new SeekableStreamReader(new StringTextSource(cref));
				SourceFile sourceFile = new SourceFile("", "", 0);
				Location.Initialize(new List<SourceFile>(new SourceFile[1]
				{
					sourceFile
				}));
				ModuleContainer moduleContainer = new ModuleContainer(compilerContext);
				moduleContainer.DocumentationBuilder = new DocumentationBuilder(moduleContainer);
				CompilationSourceFile file = new CompilationSourceFile(moduleContainer);
				Report report = new Report(compilerContext, errorReportPrinter);
				ParserSession parserSession = new ParserSession();
				parserSession.LocationsBag = new LocationsBag();
				ICSharpCode.NRefactory.MonoCSharp.CSharpParser cSharpParser = new ICSharpCode.NRefactory.MonoCSharp.CSharpParser(reader, file, report, parserSession);
				cSharpParser.Lexer.Line += initialLocation.Line - 1;
				cSharpParser.Lexer.Column += initialLocation.Column - 1;
				cSharpParser.Lexer.putback_char = 1048579;
				cSharpParser.Lexer.parsing_generic_declaration_doc = true;
				cSharpParser.parse();
				int error = report.Errors;
				DocumentationReference result = new ConversionVisitor(convertTypeSystemMode: false, parserSession.LocationsBag).ConvertXmlDoc(moduleContainer.DocumentationBuilder);
				CompilerCallableEntryPoint.Reset();
				return result;
			}
		}
	}
}
