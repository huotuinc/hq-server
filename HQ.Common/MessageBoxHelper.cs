using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HQ.Common
{
    /// <summary>
    /// 后台调用弹出窗口
    /// </summary>
    public class MessageBoxHelper
    {
        private MessageBoxHelper()
        {
        }

        public static void ResponseScript(Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");
        }

        /// <summary>
        /// loading提示信息 页面必须页面必须引用了jbox 插件
        /// </summary>
        /// <param name="page"></param>
        /// <param name="LoadingTitle">loading提示标题</param>
        /// <param name="executeCode">执行脚本代码</param>
        /// <param name="isConfirm">是否显示确认框</param>
        /// <param name="confirmTitle">确认框提示标题</param>
        /// <param name="confirmMessage">确认框提示信息</param>
        public static void ResponseLoadingScript(Page page, string LoadingTitle, string executeCode, bool isConfirm = false, string confirmTitle = "提示", string confirmMessage = "确定吗？")
        {
            string srciptStr = string.Format(@"$.jBox.tip('{0}','loading');
                                                   window.setTimeout(function () {5}
                                                        if(1=={1}){5}
                                                            $.jBox.confirm('{3}', '{2}',function (v, h, f) {5}
                                                                if (v == 'ok')
                                                                {5}
                                                                  {4}   //
                                                                {6}
                                                                return true; //close
                                                            {6});   
                                                        {6}
                                                        else
                                                        {5}
                                                            {4}  //
                                                        {6}                                                   
                                                   {6},1000);", LoadingTitle, isConfirm ? 1 : 0, confirmTitle, confirmMessage, executeCode, "{", "}");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + srciptStr + "</script>");
        }
        /// <summary>
        /// Jbox提示 页面必须页面必须引用了jbox 插件
        /// </summary>
        /// <param name="page"></param>
        /// <param name="tipMessege">提示信息</param>
        /// <param name="icon">内容图标，可选值有'info'、'success'、'warning'、'error'默认值为'info'</param>
        public static void ResponseJboxTip(Page page, string tipMessege, string icon = "info")
        {
            if (icon.Trim().ToLower() == "loading".ToLower())
                icon = "info";
            string srciptStr = string.Format("$.jBox.tip('{0}', '{1}');", tipMessege, icon);
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + srciptStr + "</script>");
        }

        /// <summary>
        /// 弹出对话框
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        public static void Show(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');location.href = location.href;</script>");
        }

        /// <summary>
        /// 弹出对话框，刷新本页
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        public static void ShowRefresh(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message2", "<script language='javascript' defer>alert('" + msg.ToString() + "');window.location.href=window.location.href;</script>");
        }

        /// <summary>
        /// 弹出对话框后再跳转到指定页面
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        /// <param name="url"></param>
        public static void ShowAndRedirect(Page page, string msg, string url)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("<script language='javascript' defer>");
            strBuilder.AppendFormat("alert('{0}');", msg);
            strBuilder.AppendFormat("top.location.href='{0}'", url);
            strBuilder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", strBuilder.ToString());
        }

        /// <summary>
        /// 弹出对话框后再跳转到框架内的页面
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        /// <param name="url"></param>
        public static void ShowRedirect(Page page, string msg, string url)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("<script language='javascript' defer>");
            strBuilder.AppendFormat("alert('{0}');", msg);
            strBuilder.AppendFormat("location.href='{0}'", url);
            strBuilder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", strBuilder.ToString());
        }

        /// <summary>
        /// 弹出IFrame对话框后再跳转到父框架内的页面
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        /// <param name="url"></param>
        public static void ShowParentRedirect(Page page, string msg, string url)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("<script language='javascript' defer>");
            strBuilder.AppendFormat("alert('{0}');", msg);
            strBuilder.AppendFormat("parent.location.href='{0}'", url);
            strBuilder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", strBuilder.ToString());
        }

        /// <summary>
        /// 给控件加载弹出对话框事件
        /// </summary>
        /// <param name="Control"></param>
        /// <param name="msg"></param>
        public static void ShowConfirm(WebControl Control, string msg)
        {
            Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
        }
    }
}
