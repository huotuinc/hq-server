using HQ.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HQ.Core.Model.ViewModel.ShortMessage
{
    /// <summary>
    /// 短信消息的基类，所有短信消息实体都要继承该类
    /// </summary>
    public abstract class ShortMessageBase
    {
        /// <summary>
        /// 子类所适用的场景
        /// </summary>
        /// <returns></returns>
        public abstract HQEnums.SmsSceneOptions GetFitedScene();
    }

    /// <summary>
    /// 属性描述特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ShortMessagePropertyAttribute : System.Attribute
    {
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }
    }

    /// <summary>
    /// 适用场景
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ShortMessageFitAttribute : System.Attribute
    {
        public HQEnums.SmsSceneOptions FitId { get; set; }
    }
}
