using HQ.Common;
using HQ.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HQ.Core.BLL.ManagerProvider
{
    /// <summary>
    /// 管理账号基类
    /// </summary>
    public abstract class ManagerProviderBase
    {
        private const string LM_MANAGER_KEY = "hq_manager";
        private const string LM_MANAGER_ROLE_KEY = "hq_role";
        /// <summary>
        /// 登录操作，-1未找到；0被禁用；1成功
        /// </summary>
        /// <param name="loginname"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public abstract int DoLogin(string loginname, string password);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public abstract bool UpdatePassword(string loginName, string password);

        /// <summary>
        /// 执行登录
        /// </summary>
        public virtual void DoLoginOut()
        {
            CookieHelper.DelCookieVal(LM_MANAGER_KEY);
            CookieHelper.DelCookieVal(LM_MANAGER_ROLE_KEY);
        }

        public abstract ManagerViewModel CheckLogin(bool checkExists = true);

        public void WriteCookie(ManagerViewModel viewModel)
        {
            viewModel.Noncestr = Guid.NewGuid().ToString().Replace("-", "");
            CookieHelper.SetCookieValByCurrentDomain(LM_MANAGER_KEY, 20160, SerializeHelper.BinarySerializeObjectToBase64String<ManagerViewModel>(viewModel));

            CookieHelper.SetCookieValByCurrentDomain(LM_MANAGER_ROLE_KEY, 20160, viewModel.RoleType.ToString());
        }

        protected ManagerViewModel GetCookie()
        {
            try
            {
                ManagerViewModel manager = SerializeHelper.BinaryDeserializeBase64StringToObject<ManagerViewModel>(CookieHelper.GetCookieVal(LM_MANAGER_KEY));
                return manager;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
