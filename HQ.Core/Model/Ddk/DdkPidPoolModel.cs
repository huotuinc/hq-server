using System;
namespace HQ.Model
{
    /// <summary>
    /// 多多客PID池实体
    /// </summary>
    [Serializable]
    public partial class DdkPidPoolModel
    {
        public DdkPidPoolModel()
        { }
        #region Model
        private int _id;
        private string _pid;
        private int _appid;
        private bool _usestatus;
        /// <summary>
        /// 自增id
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 多多客pid
        /// </summary>
        public string PId
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 多多客应用id
        /// </summary>
        public int AppId
        {
            set { _appid = value; }
            get { return _appid; }
        }
        /// <summary>
        /// 是否被使用
        /// </summary>
        public bool UseStatus
        {
            set { _usestatus = value; }
            get { return _usestatus; }
        }
        #endregion Model

    }
}

