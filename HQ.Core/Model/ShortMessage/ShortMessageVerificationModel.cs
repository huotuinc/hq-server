using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HQ.Core.Model.ShortMessage
{
    /// <summary>
    /// 短信验证码实体
    /// </summary>
    public class ShortMessageVerificationModel
    {
        #region Model
        private int _id;
        private string _verification;
        private DateTime _addtime;
        private int _isinvalid;
        private string _mobile;
        /// <summary>
        /// 自增id
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 验证码
        /// </summary>
        public string Verification
        {
            set { _verification = value; }
            get { return _verification; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 是否使用
        /// </summary>
        public int IsInvalid
        {
            set { _isinvalid = value; }
            get { return _isinvalid; }
        }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        #endregion Model
    }
}
