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
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SceneType
        {
            set { _scenetype = value; }
            get { return _scenetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Template
        {
            set { _template = value; }
            get { return _template; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        #endregion Model
    }
}
