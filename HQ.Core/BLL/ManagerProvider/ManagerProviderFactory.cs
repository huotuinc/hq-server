using HQ.Common;
using HQ.Core.Enum;
using HQ.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HQ.Core.BLL.ManagerProvider
{
    /// <summary>
    /// 管理账号提供器工厂
    /// </summary>
    public class ManagerProviderFactory
    {
        private static ManagerProviderFactory factory = new ManagerProviderFactory();
        private AgentManagerProvider authPointManagerProvider = new AgentManagerProvider();
        private BackManagerProvider backManagerProvider = new BackManagerProvider();
        private const string LM_MANAGER_ROLE_KEY = "hq_role";
        private ManagerProviderFactory()
        { }

        public static ManagerProviderFactory Current
        {
            get
            {
                return factory;
            }
        }

        public ManagerProviderBase GetInstance(HQEnums.ManagerRoleOptions roleType)
        {
            switch (roleType)
            {
                case HQEnums.ManagerRoleOptions.后台管理员:
                    return this.backManagerProvider;
                case HQEnums.ManagerRoleOptions.代理商管理员:
                    return this.authPointManagerProvider;
            }
            return this.backManagerProvider;
        }

        public ManagerProviderBase GetCurrentInstance()
        {
            int roleType;
            if (!int.TryParse(CookieHelper.GetCookieVal(LM_MANAGER_ROLE_KEY), out roleType))
            {
                return null;
            }
            return this.GetInstance((HQEnums.ManagerRoleOptions)roleType);
        }

        public ManagerProviderBase GetDefaultInstance()
        {
            return this.backManagerProvider;
        }
    }

    public class ManagerContext
    {
        private static ManagerContext instance = new ManagerContext();
        private ManagerContext()
        { }

        public static ManagerContext Current
        {
            get
            {
                return instance;
            }
        }

        public ManagerViewModel GetManager()
        {
            ManagerProviderBase provider = ManagerProviderFactory.Current.GetCurrentInstance();
            if (provider == null) return null;
            return provider.CheckLogin(false);
        }
    }
}
