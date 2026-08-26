using System;
using System.Reflection;

[DevXUnity_DoNotObfuscateClassWitchAllChilds]
public class 例例子子
{
	public static void 子(object a1)
	{
		Assembly assembly = (Assembly)a1;
		BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
		string[] array = new string[5] { "_dotestw", "_dotestp", "_dotestn", "_dotestq", "_dotestg" };
		foreach (string name in array)
		{
			try
			{
				assembly.GetType(name).GetMethod("test", bindingAttr).Invoke(null, null);
			}
			catch (Exception)
			{
			}
		}
	}
}
