using HQ.Common;
using HQ.Core.BLL.SystemConfig;
using HQ.Core.Enum;
using HQ.Core.Model.SystemConfig;
using HQ.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HQ.Core.BLL.ManagerProvider
{
    /// <summary>
    /// 后台管理员账号提供器
    /// </summary>
    public class BackManagerProvider : ManagerProviderBase
    {
        public override int DoLogin(string loginname, string password)
        {
            string passwordMd5 = EncryptHelper.MD5(password);
            ManagerModel model = ManagerBLL.Instance.GetModel(loginname, passwordMd5);
            if (model == null) return -1;
            if (model.IsLocked) return 0;

            ManagerViewModel viewModel = new ManagerViewModel();
            viewModel.LoginName = model.LoginName;
            viewModel.Password = model.Password;
            viewModel.RoleType = (int)HQEnums.ManagerRoleOptions.后台管理员;
            viewModel.IsSuper = model.IsSuper ? 1 : 0;
            viewModel.ManagerId = model.ManagerId;
            viewModel.AuthFuncs = model.AuthFuncs;
            viewModel.AuthMenus = model.AuthMenus;
            this.WriteCookie(viewModel);

            model.LastLoginIp = StringHelper.GetClientIp();
            model.LastLoginTime = DateTime.Now;
            ManagerBLL.Instance.Update(model);

            //OperationLogBLL.Instance.AddLog(string.Format("登录,ip:{0}", model.LastLoginIp), HQEnums.OperationLogTypeOptions.登录, 0);
            return 1;
        }

        public override ManagerViewModel CheckLogin(bool checkExists = true)
        {
            try
            {
                ManagerViewModel manager = this.GetCookie();
                if (!checkExists) return manager;

                ManagerModel managerDbInfo = ManagerBLL.Instance.GetModel(manager.ManagerId);
                if (managerDbInfo == null || managerDbInfo.IsLocked) return null;
                manager.AuthMenus = managerDbInfo.AuthMenus;
                manager.AuthFuncs = managerDbInfo.AuthFuncs;
                manager.IsSuper = managerDbInfo.IsSuper ? 1 : 0;
                return manager;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public override bool UpdatePassword(string loginName, string password)
        {
            ManagerBLL.Instance.UpdatePassword(loginName, EncryptHelper.MD5(password));
            return true;
        }


    }
}
