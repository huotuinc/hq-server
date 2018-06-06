using HQ.Common;
using HQ.Core.BLL.User;
using HQ.Core.Model.ViewModel;
using HQ.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HQ.AdminWeb.Handler
{
    /// <summary>
    /// UserLevelHandler 的摘要说明
    /// </summary>
    public class UserLevelHandler : PageBaseHelper, IHttpHandler
    {
        public Dictionary<object, object> Data { set; get; }
        public void ProcessRequest(HttpContext context)
        {

            this.Data = new Dictionary<object, object>();
            switch (this.Action)
            {
                case "editlevel":
                    SaveLevel();
                    break;
                case "getlevel":
                    GetLevelList();
                    break;
                case "dellevel":
                    DelLevel();
                    break;

            }
            this.Data["code"] = this.code;
            this.Data["msg"] = this.msg;
            context.Response.ContentType = "application/json";
            this.outputJson = JsonConvert.SerializeObject(Data);
            context.Response.Write(outputJson);
            context.Response.End();
        }

        /// <summary>
        /// 保存等级
        /// </summary>
        private void SaveLevel()
        {
            try
            {
                int LevelId = this.GetFormValue("levelid", 0);//等级Id
                int LevelType = this.GetFormValue("leveltype", 0);//等级类型
                string LevelName = this.GetFormValue("levelname", "");//等级名称
                int BelongOneNum = this.GetFormValue("onenum", 0);//直接下线(不限等级)人数
                int BuddyBelongOne = this.GetFormValue("belongone", 0);//直接下线代理商人数
                int BuddyBelongTwo = this.GetFormValue("belongtwo", 0);//下下线代理商人数
                int BelongOneOrderNum = this.GetFormValue("ordernum", 0);//直接下线下单人数
                int LevelModel = this.GetFormValue("levelmodel", 0);//升级模式
                string LevelMemo = this.GetFormValue("levelmemo", "");//备注

                List<UpgradeConditionModel> Items = new List<UpgradeConditionModel>();
                UpgradeConditionModel item = new UpgradeConditionModel();

                if (LevelType == 0)
                {
                    item.ConditionKey = "UserCondition";
                    item.ConditionDecs = "平台注册用户";
                    item.ConditionValue = -1;
                    item.ConditionType = 0;
                    Items.Add(item);
                }
                else if (LevelType == 1)
                {
                    item.ConditionKey = "BelongOneNum";
                    item.ConditionDecs = "直接下线(不限等级)>=<span style=\"color:red;\">{Value}</span>人";
                    item.ConditionValue = BelongOneNum;
                    item.ConditionType = 0;
                    Items.Add(item);
                }
                else if (LevelType == 2)
                {
                    item.ConditionKey = "BuddyBelongOne";
                    item.ConditionDecs = "直接下线代理商>=<span style=\"color:red;\">{Value}</span>人";
                    item.ConditionValue = BuddyBelongOne;
                    item.ConditionType = 0;
                    Items.Add(item);
                    item = new UpgradeConditionModel();
                    item.ConditionKey = "BuddyBelongTwo";
                    item.ConditionDecs = "下下线代理商>=<span style=\"color:red;\">{Value}</span>人";
                    item.ConditionValue = BuddyBelongTwo;
                    item.ConditionType = 0;
                    Items.Add(item);
                    item = new UpgradeConditionModel();
                    item.ConditionKey = "BelongOneOrderNum";
                    item.ConditionDecs = "直接下线>=<span style=\"color:red;\">{Value}</span>人下单";
                    item.ConditionValue = BelongOneOrderNum;
                    item.ConditionType = 1;
                    Items.Add(item);
                }
                else if (LevelType == 3 || LevelType == 4)
                {
                    item.ConditionKey = "CompanyCondition";
                    item.ConditionDecs = "系统开通";
                    item.ConditionValue = -1;
                    item.ConditionType = 0;
                    Items.Add(item);
                }

                int TableLevelNo = UserLevelBLL.Instance.GetLevelNo(LevelType);

                UserLevelModel model = new UserLevelModel();
                model.LevelId = LevelId;
                model.LevelName = LevelName;
                if (TableLevelNo == -1)
                {
                    model.LevelNo = 0;
                }
                else
                {
                    model.LevelNo = TableLevelNo + 1;
                }
                model.LevelType = (Core.Enum.HQEnums.UserLevelTypeOptions)LevelType;
                model.Remark = LevelMemo;
                model.LevelModel = LevelModel;
                model.UpgradeCondition = Items;
                if (model.LevelId > 0)
                {
                    if (UserLevelBLL.Instance.Update(model))
                    {
                        this.code = 1;
                        this.msg = "修改成功!";
                        return;
                    }
                    else
                    {
                        this.code = -1;
                        this.msg = "修改失败,请刷新后重试!";
                        return;
                    }
                }
                else
                {
                    model.Createtime = DateTime.Now;
                    if (UserLevelBLL.Instance.Add(model) > 0)
                    {
                        this.code = 1;
                        this.msg = "添加成功!";
                        return;
                    }
                    else
                    {
                        this.code = -1;
                        this.msg = "添加失败,请刷新后重试!";
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                this.code = -1;
                this.msg = "请求发生异常,请刷新后重试!";
                LogHelper.WriteError("UserLevelHandler---->SaveLevel方法发生异常,异常信息：" + ex.Message);
                return;
            }
        }
        /// <summary>
        /// 获取等级列表
        /// </summary>
        private void GetLevelList()
        {
            try
            {
                List<UserLevelModel> list = UserLevelBLL.Instance.GetList();
                code = 200;
                this.Data["list"] = list;
            }
            catch (Exception ex)
            {
                code = 0;
                this.msg = "请求发生异常,请刷新后重试!";
                LogHelper.WriteError("UserLevelHandler---->GetLevelList方法发生异常,异常信息：" + ex.Message);
            }
        }
        /// <summary>
        /// 删除等级
        /// </summary>            
        private void DelLevel()
        {
            try
            {

                int LevelId = this.GetFormValue("levelid", 0);

                int CountUserNum = UsersBLL.Instance.CountUserNumByLevelId(LevelId);
                if (CountUserNum > 0)
                {
                    this.code = -1;
                    this.msg = "删除失败,有"+CountUserNum+"位用户在该等级!";
                    return;
                }

                if (UserLevelBLL.Instance.Delete(LevelId))
                {
                    this.code = 1;
                    this.msg = "删除成功!";
                    return;
                }
                else
                {
                    this.code = -1;
                    this.msg = "删除失败,请刷新后重试!";
                    return;
                }
            }
            catch (Exception ex)
            {
                code = 0;
                this.msg = "请求发生异常,请刷新后重试!";
                LogHelper.WriteError("UserLevelHandler---->DelLevel方法发生异常,异常信息：" + ex.Message);
            }
        }

        public int code { get; set; }

        public string msg { get; set; }
        public string outputJson { get; set; }
        public string Action
        {
            get
            {
                return this.GetFormValue("action", "");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}