using System.Reflection;
using UnityEngine;

internal class __QInit
{
	internal static void ___Awake(string name)
	{
		BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
		typeof(__QInit).Assembly.GetType("例子例").GetMethod("测", bindingAttr).Invoke(null, null);
		TextAsset obj = Resources.Load<TextAsset>(name);
		byte[] array = ((obj != null) ? obj.bytes : null);
		array = (byte[])typeof(__QInit).Assembly.GetType(例子例.s_name).GetMethod(例子例.d_name, bindingAttr).Invoke(null, new object[2]
		{
			array,
			"$#54544^452345@234r44rr#345345#RND?@GN16#6D52BFECA2693761" + "DevXUnityUnpackerToolsLib".ToLower()
		});
		Assembly assembly = Assembly.Load(array);
		typeof(__QInit).Assembly.GetType("例测例").GetMethod("例", bindingAttr).Invoke(null, new object[1] { assembly });
		typeof(__QInit).Assembly.GetType("例例子子").GetMethod("子", bindingAttr).Invoke(null, new object[1] { assembly });
	}
}
