using HQ.Common;
using HQ.Core.BLL.ShortMessage;
using HQ.Core.Model.ShortMessage;
using LM.Core.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQ.Core.Model.ShortMessage.TemplateImpl;

namespace LM.Core.BLL
{
    /// <summary>
    /// 短信验证码逻辑层
    /// </summary>
    public class ShortMessageVerificationBLL
    {
        private readonly ShortMessageVerificationDAL dal = new ShortMessageVerificationDAL();
        private static readonly ShortMessageVerificationBLL instance = new ShortMessageVerificationBLL();
        private ShortMessageVerificationBLL()
        { }

        public static ShortMessageVerificationBLL Instance
        {
            get
            {
                return instance;
            }
        }

        #region  BasicMethod
        /// <summary>
        /// 更新为已失效
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public bool SetInvalid(string mobile)
        {
            return dal.SetInvalid(mobile);
        }
        /// <summary>
        /// 判断是否通过验证
        /// </summary>
        /// <param name="verification"></param>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public bool IsPassVerify(string verification, string mobile)
        {
            return dal.IsPassVerify(verification, mobile);
        }
        /// <summary>
        /// 添加或者更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddOrUpdate(ShortMessageVerificationModel model)
        {
            return dal.AddOrUpdate(model);
        }

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public bool SendVerification(string mobile)
        {
            if (string.IsNullOrEmpty(mobile))
            {
                return false;
            }
            string verificationNum = StringHelper.GetRandomNumber(100000, 999999).ToString();
            ShortMessageVerificationModel model = new ShortMessageVerificationModel
            {
                Verification = verificationNum,
                CreateTime = DateTime.Now,
                IsInvalid = 0,
                Mobile = mobile
            };
            if (!this.AddOrUpdate(model))
            {
                return false;
            }
            string sendErrMsg;
            ShortMessageDispatcher.Send(mobile, new VerifyCodeShortMessage()
            {
                Verifycode = verificationNum
            }, out sendErrMsg);
            return true;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShortMessageVerificationModel model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ShortMessageVerificationModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {
            return dal.Delete(Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShortMessageVerificationModel GetModel(int Id)
        {
            return dal.GetModel(Id);
        }
        #endregion  BasicMethod
    }
}
