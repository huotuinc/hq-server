using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.Model.ShortMessage
{
    /// <summary>
    /// 短信模板实体
    /// </summary>
    public class ShortMessageTemplateModel
    {
        #region Model
        private int _id;
        private int _scenetype;
        private string _template;
        private DateTime _createtime;
        private int _status;
        /// <summary>
        /// 模板id
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 发送场景
        /// </summary>
        public int SceneType
        {
            set { _scenetype = value; }
            get { return _scenetype; }
        }
        /// <summary>
        /// 模板内容
        /// </summary>
        public string Template
        {
            set { _template = value; }
            get { return _template; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 启用状态
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        #endregion Model
    }
}
