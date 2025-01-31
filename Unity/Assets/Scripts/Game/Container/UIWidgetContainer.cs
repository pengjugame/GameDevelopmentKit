using System.Collections.Generic;
using GameFramework;

namespace Game
{
    public sealed class UIWidgetContainer : IReference
    {
        public readonly List<UIWidget> m_UIWidgets = new List<UIWidget>();
        
        public AUGuiForm Owner
        {
            get;
            private set;
        }
        
        public static UIWidgetContainer Create(AUGuiForm owner)
        {
            UIWidgetContainer uiWidgetContainer = ReferencePool.Acquire<UIWidgetContainer>();
            uiWidgetContainer.Owner = owner;
            return uiWidgetContainer;
        }

        public void AddUIWidget(UIWidget uiWidget, object userData)
        {
            if (uiWidget == null)
            {
                throw new GameFrameworkException("Can't add empty!");
            }
            if (m_UIWidgets.Contains(uiWidget))
            {
                throw new GameFrameworkException(Utility.Text.Format("Can't duplicate add UIWidget : '{0}'!", uiWidget.CachedTransform.name));
            }
            m_UIWidgets.Add(uiWidget);
            uiWidget.OnInit(userData);
        }

        public void RemoveUIWidget(UIWidget uiWidget, object userData)
        {
            if (!m_UIWidgets.Remove(uiWidget))
            {
                throw new GameFrameworkException(Utility.Text.Format("UIWidget : '{0}' not in container.", uiWidget.CachedTransform.name));
            }
            if (uiWidget.IsOpen)
            {
                uiWidget.OnClose(false, userData);
            }
        }

        public void RemoveAllUIWidget(object userData)
        {
            foreach (var uiWidget in m_UIWidgets)
            {
                if (uiWidget.IsOpen)
                {
                    uiWidget.OnClose(false, userData);
                }
            }
            m_UIWidgets.Clear();
        }

        public void Clear()
        {
            m_UIWidgets.Clear();
            Owner = null;
        }

        /// <summary>
        /// 界面回收。
        /// </summary>
        public void OnRecycle()
        {
            foreach (var uiWidget in m_UIWidgets)
            {
                uiWidget.OnRecycle();
            }
        }

        /// <summary>
        /// 界面关闭。
        /// </summary>
        /// <param name="isShutdown">是否是关闭界面管理器时触发。</param>
        /// <param name="userData">用户自定义数据。</param>
        public void OnClose(bool isShutdown, object userData)
        {
            foreach (var uiWidget in m_UIWidgets)
            {
                if (uiWidget.IsOpen)
                {
                    uiWidget.OnClose(isShutdown, userData);
                }
            }
        }

        /// <summary>
        /// 界面暂停。
        /// </summary>
        public void OnPause()
        {
            foreach (var uiWidget in m_UIWidgets)
            {
                if (uiWidget.IsOpen)
                {
                    uiWidget.OnPause();
                }
            }
        }

        /// <summary>
        /// 界面暂停恢复。
        /// </summary>
        public void OnResume()
        {
            foreach (var uiWidget in m_UIWidgets)
            {
                if (uiWidget.IsOpen)
                {
                    uiWidget.OnResume();
                }
            }
        }

        /// <summary>
        /// 界面遮挡。
        /// </summary>
        public void OnCover()
        {
            foreach (var uiWidget in m_UIWidgets)
            {
                if (uiWidget.IsOpen)
                {
                    uiWidget.OnCover();
                }
            }
        }

        /// <summary>
        /// 界面遮挡恢复。
        /// </summary>
        public void OnReveal()
        {
            foreach (var uiWidget in m_UIWidgets)
            {
                if (uiWidget.IsOpen)
                {
                    uiWidget.OnReveal();
                }
            }
        }

        /// <summary>
        /// 界面激活。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        public void OnRefocus(object userData)
        {
            foreach (var uiWidget in m_UIWidgets)
            {
                if (uiWidget.IsOpen)
                {
                    uiWidget.OnRefocus(userData);
                }
            }
        }

        /// <summary>
        /// 界面轮询。
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
        public void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            foreach (var uiWidget in m_UIWidgets)
            {
                if (uiWidget.IsOpen)
                {
                    uiWidget.OnUpdate(elapseSeconds, realElapseSeconds);
                }
            }
        }

        /// <summary>
        /// 界面深度改变。
        /// </summary>
        /// <param name="uiGroupDepth">界面组深度。</param>
        /// <param name="depthInUIGroup">界面在界面组中的深度。</param>
        public void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
        {
            foreach (var uiWidget in m_UIWidgets)
            {
                if (uiWidget.IsOpen)
                {
                    uiWidget.OnDepthChanged(uiGroupDepth, depthInUIGroup);
                }
            }
        }
    }
}
