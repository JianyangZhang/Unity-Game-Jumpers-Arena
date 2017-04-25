using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Anima2D
{
	public class EditorExtra
	{
		public static GameObject InstantiateForAnimatorPreview(UnityEngine.Object original)
		{
			/*
			GameObject result = null;
			MethodInfo methodInfo = typeof(EditorUtility).GetMethod("InstantiateForAnimatorPreview", BindingFlags.Static | BindingFlags.NonPublic);
			if(methodInfo != null)
			{
				object[] parameters = new object[] { original };
				result = (GameObject) methodInfo.Invoke(null,parameters);
			}
			*/

			GameObject result = GameObject.Instantiate(original) as GameObject;

			List<Component> components = new List<Component>();
			result.GetComponentsInChildren<Component>(false,components);

			foreach(Component component in components)
			{
				if(component as Behaviour && (component as Ik2D) == null)
				{
					(component as Behaviour).enabled = false;
				}
			}

			return result;
		}
		
		public static void InitInstantiatedPreviewRecursive(GameObject go)
		{
			go.hideFlags = HideFlags.HideAndDontSave;

			foreach (Transform transform in go.transform)
			{
				InitInstantiatedPreviewRecursive(transform.gameObject);
			}
		}

		
		public static List<string> GetSortingLayerNames()
		{
			List<string> names = new List<string>();
			
			PropertyInfo sortingLayersProperty = typeof(InternalEditorUtility).GetProperty("sortingLayerNames", BindingFlags.Static | BindingFlags.NonPublic);
			if(sortingLayersProperty != null)
			{
				string[] sortingLayers = (string[])sortingLayersProperty.GetValue(null, new object[0]);
				names.AddRange(sortingLayers);
			}
			
			return names;
		}

		public static bool IsProSkin()
		{
			bool isProSkin = false;

			PropertyInfo prop = typeof(EditorGUIUtility).GetProperty("isProSkin", BindingFlags.Static | BindingFlags.NonPublic);

			if(prop != null)
			{
				isProSkin = (bool)prop.GetValue(null, new object[0]);
			}

			return isProSkin;
		}

		public static GameObject PickGameObject(Vector2 mousePosition)
		{
			MethodInfo methodInfo = typeof(EditorWindow).Assembly.GetType("UnityEditor.SceneViewPicking").GetMethod("PickGameObject", BindingFlags.Static | BindingFlags.Public);

			if(methodInfo != null)
			{
				return (GameObject)methodInfo.Invoke(null, new object[] { mousePosition });
			}

			return null;
		}
	}
}
