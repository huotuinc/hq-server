using HQ.Core.Enum;
using HQ.Core.Model.ViewModel.ShortMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HQ.Core.BLL.ShortMessage
{
    /// <summary>
    /// 短信场景负责人
    /// </summary>
    public class ShortMessageContext
    {
        private static ShortMessageContext _Instance = new ShortMessageContext();
        private Dictionary<HQEnums.SmsSceneOptions, Type> dicTypes = new Dictionary<HQEnums.SmsSceneOptions, Type>();
        private ShortMessageContext()
        {
            this.ReloadMessageType();
        }

        /// <summary>
        /// 单例
        /// </summary>
        public static ShortMessageContext Intance
        {
            get
            {
                return _Instance;
            }
        }

        /// <summary>
        /// 根据场景和字典，生成对象
        /// </summary>
        /// <param name="scene">场景</param>
        /// <param name="dicDatas"></param>
        /// <returns></returns>
        public ShortMessageBase SetMessagePropertys(HQEnums.SmsSceneOptions scene, Dictionary<string, string> dicDatas)
        {
            Type msgType = GetMessageType(scene);
            if (msgType == null)
            {
                throw new Exception(string.Format("没有找到场景[{0}]对应的数据", scene));
            }
            object msgInstance = Activator.CreateInstance(msgType);
            System.Reflection.PropertyInfo[] properties = msgType.GetProperties();
            foreach (PropertyInfo pro in properties)
            {
                if (dicDatas.ContainsKey(pro.Name))
                {
                    pro.SetValue(msgInstance, dicDatas[pro.Name], null);
                }
            }
            return (ShortMessageBase)msgInstance;
        }

        /// <summary>
        /// 载入已定义的消息类型
        /// </summary>
        public void ReloadMessageType()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            foreach (Type t in asm.GetTypes())
            {
                if (t.BaseType != null && t.BaseType.FullName == "HQ.Core.Model.Gallery.ShortMessage.ShortMessageBase")
                {
                    foreach (object arr in t.GetCustomAttributes(typeof(ShortMessageFitAttribute), false))
                    {
                        ShortMessageFitAttribute pi = (ShortMessageFitAttribute)arr;
                        if (!dicTypes.ContainsKey(pi.FitId))
                        {
                            dicTypes.Add(pi.FitId, t);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 得到本地用于发送消息的类型
        /// </summary>
        /// <param name="scene">场景</param>
        /// <returns></returns>
        public Type GetMessageType(HQEnums.SmsSceneOptions scene)
        {
            if (this.dicTypes.ContainsKey(scene))
            {
                return dicTypes[scene];
            }
            return null;
        }

        /// <summary>
        /// 获取目前系统定义的所有场景消息类型
        /// </summary>
        /// <returns>类型字典</returns>
        public Dictionary<HQEnums.SmsSceneOptions, Type> GetAllMessageTypes()
        {
            return this.dicTypes;
        }

        /// <summary>
        /// 获取本地用于发送模板消息的属性描述
        /// </summary>
        /// <param name="scene">场景</param>
        /// <returns></returns>
        public Dictionary<string, string> GetMessagePropertys(HQEnums.SmsSceneOptions scene)
        {
            Type msgType = GetMessageType(scene);

            Dictionary<string, string> dicPropertys = new Dictionary<string, string>();
            if (msgType != null)
            {
                System.Reflection.PropertyInfo[] properties = msgType.GetProperties();
                foreach (PropertyInfo pro in properties)
                {
                    foreach (object arr in pro.GetCustomAttributes(typeof(ShortMessagePropertyAttribute), true))
                    {
                        ShortMessagePropertyAttribute pi = (ShortMessagePropertyAttribute)arr;
                        if (!dicPropertys.ContainsKey(pro.Name))
                        {
                            dicPropertys.Add(pro.Name, pi.Desc);
                        }
                    }
                }
            }
            return dicPropertys;
        }

    }
}
