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
    /// 代理商管理员账号提供器
    /// </summary>
    public class AgentManagerProvider : ManagerProviderBase
    {
        public override int DoLogin(string loginname, string password)
        {
            //string passwordMd5 = EncryptHelper.MD5(password);
            ////AuthPointModel model = AuthPointBLL.Instance.GetModel(loginname, passwordMd5);
            //if (model == null) return -1;
            //if (model.Status == 0) return 0;//未启用

            //ManagerViewModel viewModel = new ManagerViewModel();
            //viewModel.LoginName = model.LoginName;
            //viewModel.Password = model.Password;
            //viewModel.RoleType = (int)(HQEnums.ManagerRoleOptions.代理商管理员);
            //viewModel.IsSuper = 0;
            //viewModel.ManagerId = model.PointId;
            //this.WriteCookie(viewModel);

            return 1;
        }

        public override ManagerViewModel CheckLogin(bool checkExists = true)
        {
            //try
            //{
            //    ManagerViewModel manager = this.GetCookie();
            //    if (checkExists && AuthPointBLL.Instance.Exists(manager.LoginName, manager.Password))
            //    {
            //        return manager;
            //    }
            //    return null;
            //}
            //catch (Exception ex)
            //{
            //    return null;
            //}

            return null;
        }

        public override bool UpdatePassword(string loginName, string password)
        {
            //AuthPointBLL.Instance.UpdatePassword(loginName, EncryptHelper.MD5(password));
            return true;
        }
    }
}
