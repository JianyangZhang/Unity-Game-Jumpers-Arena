using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Reflection;

namespace Anima2D
{
	public class AnimationWindowImpl_56 : AnimationWindowImpl_55
	{
		PropertyInfo m_CurrentFrameProperty = null;

		public override void InitializeReflection()
		{
			base.InitializeReflection();

			m_CurrentFrameProperty = m_AnimationWindowStateType.GetProperty("currentFrame",BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
		}

		public override int frame {
			get {
				if(state != null && m_CurrentFrameProperty != null)
				{
					return (int)m_CurrentFrameProperty.GetValue(state,null);
				}

				return 0;
			}

			set {
				if(state != null && m_CurrentFrameProperty != null)
				{
					m_CurrentFrameProperty.SetValue(state, value, null);
				}
			}
		}
	}
}
