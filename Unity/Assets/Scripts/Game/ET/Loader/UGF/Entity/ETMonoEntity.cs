using System;
using UnityEngine;
using UnityGameFramework.Runtime;
using Game;
using GameFramework;

namespace ET
{
    [DisallowMultipleComponent]
    public sealed class ETMonoEntity : AEntity
    {
        private UGFEntity m_UGFEntity;
        private Type m_EntityEventType;
        private IUGFEntityEvent m_EntityEvent;

        public bool IsShow { get; private set; }
        public UGFEntity UGFEntity => m_UGFEntity;

        public void OnReload()
        {
            UGFEventComponent.Instance.GetEntityEvent(m_EntityEventType).OnReload(m_UGFEntity);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            ETMonoEntityData entityData = (ETMonoEntityData)userData;
            if (entityData.ParentEntity == null)
            {
                throw new GameFrameworkException("ETMonoEntityData ParentEntity is null!");
            }
            if (m_UGFEntity == default || m_EntityEventType != entityData.EntityEventType || entityData.ParentEntity != m_UGFEntity.Parent)
            {
                UGFEntityDispose();
                m_EntityEventType = entityData.EntityEventType;
                m_UGFEntity = entityData.ParentEntity.AddChild<UGFEntity, Type, ETMonoEntity>(m_EntityEventType, this, true);
                UGFEventComponent.Instance.GetEntityEvent(m_EntityEventType).OnInit(m_UGFEntity, entityData.UserData);
            }
            IsShow = true;
            UGFEventComponent.Instance.GetEntityEvent(m_EntityEventType).OnShow(m_UGFEntity, entityData.UserData);
            entityData.Release();
        }

        private void OnDestroy()
        {
            UGFEntityDispose();
        }

        private void UGFEntityDispose()
        {
            if (m_UGFEntity != default && !m_UGFEntity.IsDisposed)
            {
                UGFEntity ugfEntity = m_UGFEntity;
                m_UGFEntity = default;
                ugfEntity.Dispose();
            }
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            UGFEventComponent.Instance.GetEntityEvent(m_EntityEventType).OnHide(m_UGFEntity, isShutdown, userData);
            IsShow = false;
            if (isShutdown)
            {
                UGFEntityDispose();
            }
            base.OnHide(isShutdown, userData);
        }

        protected override void OnAttached(EntityLogic childEntity, Transform parentTransform, object userData)
        {
            base.OnAttached(childEntity, parentTransform, userData);
            UGFEventComponent.Instance.GetEntityEvent(m_EntityEventType).OnAttached(m_UGFEntity, childEntity, parentTransform, userData);
        }

        protected override void OnDetached(EntityLogic childEntity, object userData)
        {
            base.OnDetached(childEntity, userData);
            UGFEventComponent.Instance.GetEntityEvent(m_EntityEventType).OnDetached(m_UGFEntity, childEntity, userData);
        }

        protected override void OnAttachTo(EntityLogic parentEntity, Transform parentTransform, object userData)
        {
            base.OnAttachTo(parentEntity, parentTransform, userData);
            UGFEventComponent.Instance.GetEntityEvent(m_EntityEventType).OnAttachTo(m_UGFEntity, parentEntity, parentTransform, userData);
        }

        protected override void OnDetachFrom(EntityLogic parentEntity, object userData)
        {
            base.OnDetachFrom(parentEntity, userData);
            UGFEventComponent.Instance.GetEntityEvent(m_EntityEventType).OnDetachFrom(m_UGFEntity, parentEntity, userData);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            UGFEventComponent.Instance.GetEntityEvent(m_EntityEventType).OnUpdate(m_UGFEntity, elapseSeconds, realElapseSeconds);
        }

        protected override void OnRecycle()
        {
            base.OnRecycle();
            UGFEventComponent.Instance.GetEntityEvent(m_EntityEventType).OnRecycle(m_UGFEntity);
        }
    }
}
