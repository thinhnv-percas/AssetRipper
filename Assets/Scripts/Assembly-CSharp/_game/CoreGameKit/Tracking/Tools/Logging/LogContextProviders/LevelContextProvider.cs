using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;

namespace _game.CoreGameKit.Tracking.Tools.Logging.LogContextProviders
{
	[Token(Token = "0x2000595")]
	public class LevelContextProvider : ILogContextProvider
	{
		[Token(Token = "0x400133E")]
		[FieldOffset(Offset = "0x10")]
		private ILevel _level;

		[Inject(false)]
		[Token(Token = "0x60017AF")]
		[Address(RVA = "0x3D2FA28", Offset = "0x3D2FA28", Length = "0x8")]
		private void Construct(ILevel level = null)
		{
			_level = level;
		}

		[Token(Token = "0x60017B0")]
		[Address(RVA = "0x3D2FA30", Offset = "0x3D2FA30", Length = "0x568")]
		public string GetContext()
		{
			//IL_00ca: Expected O, but got I4
			//IL_0170: Expected O, but got I4
			//IL_0424: Expected O, but got I4
			//IL_04cc: Expected O, but got I4
			if (_level != null)
			{
				string[] array = new string[8];
				NullReferenceException ex = default(NullReferenceException);
				if (array != null)
				{
					if (array.Length != 0)
					{
						array[0] = "{\"levelId\": \"";
						if (_level == null)
						{
							ex = new NullReferenceException();
						}
						else
						{
							string uniqueId = _level.UniqueId;
							if ((array.Length & -2) != 0)
							{
								array[1] = uniqueId;
								bool flag = (uint)array.Length < 2u;
								bool flag2 = !flag;
								object obj = array.Length - 2;
								bool flag3 = obj == null;
								bool flag4 = !flag2;
								if (!(flag4 || flag3))
								{
									array[2] = "\", \"levelName\": \"";
									if (_level == null)
									{
										ex = new NullReferenceException();
									}
									else
									{
										string levelName = _level.LevelName;
										if ((array.Length & -4) != 0)
										{
											array[3] = levelName;
											bool flag5 = (uint)array.Length < 4u;
											bool flag6 = !flag5;
											object obj2 = array.Length - 4;
											bool flag7 = obj2 == null;
											bool flag8 = !flag6;
											if (!(flag8 || flag7))
											{
												array[4] = "\", ";
												if (_level == null)
												{
													ex = new NullReferenceException();
												}
												else
												{
													LevelDifficulty difficulty = _level.Difficulty;
													LevelDifficulty levelDifficulty = difficulty;
													object arg = levelDifficulty;
													string text = $"\"difficulty\": \"{arg}\", ";
													bool flag9 = (uint)array.Length < 5u;
													bool flag10 = !flag9;
													object obj3 = array.Length - 5;
													bool flag11 = obj3 == null;
													bool flag12 = !flag10;
													if (!(flag12 || flag11))
													{
														array[5] = text;
														if (_level == null)
														{
															ex = new NullReferenceException();
														}
														else
														{
															float levelEndValue = _level.LevelEndValue;
															object obj5 = default(object);
															object obj4 = obj5;
															int num = 192761856 + 1336;
															Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
															object arg2 = default(object);
															string text2 = $"\"timeLimit\": {arg2}, ";
															bool flag13 = (uint)array.Length < 6u;
															bool flag14 = !flag13;
															object obj6 = array.Length - 6;
															bool flag15 = obj6 == null;
															bool flag16 = !flag14;
															if (!(flag16 || flag15))
															{
																array[6] = text2;
																if ((array.Length & -8) != 0)
																{
																	array[7] = "}";
																	return string.Concat(array);
																}
																IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
															}
															else
															{
																IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
															}
														}
													}
													else
													{
														IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
													}
												}
											}
											else
											{
												IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
											}
										}
										else
										{
											IndexOutOfRangeException ex6 = new IndexOutOfRangeException();
										}
									}
								}
								else
								{
									IndexOutOfRangeException ex7 = new IndexOutOfRangeException();
								}
							}
							else
							{
								IndexOutOfRangeException ex8 = new IndexOutOfRangeException();
							}
						}
					}
					else
					{
						IndexOutOfRangeException ex9 = new IndexOutOfRangeException();
					}
				}
				else
				{
					ex = new NullReferenceException();
				}
				throw ex;
			}
			return "{\"level\": \"Not available\"}";
		}

		[Token(Token = "0x60017B1")]
		[Address(RVA = "0x3D2FF98", Offset = "0x3D2FF98", Length = "0x228")]
		public LevelContextProvider()
		{
		}
	}
}
