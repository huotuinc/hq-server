using HQ.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LM.Core.BLL
{
    /// <summary>
    /// Excel导出负责人
    /// </summary>
    public class HQExcelExporter
    {
        private HQExcelExporter()
        { }

        public static string Invoke(string methodName, string value)
        {
            Type type = Type.GetType("HQ.Core.BLL.ExportFieldFunctionProvider");
            MethodInfo method = type.GetMethod(methodName, BindingFlags.Static | BindingFlags.Public);
            if (method != null)
            {
                object obj = method.Invoke(null, new object[] { value });
                return obj.ToString();
            }
            return value;
        }

        /// <summary>
        /// DataTable导出到Excel
        /// </summary>
        /// <param name="dt">数据</param>
        /// <param name="fileName">导出路径</param>
        public static void Export(DataTable dt, string fileName)
        {
            ExcelHelper.ExportDTtoExcel(dt, fileName);
        }

        /// <summary>
        /// 根据字段配置信息导出
        /// </summary>
        /// <param name="dt">数据</param>
        /// <param name="mappingInfo">字段配置列表</param>
        /// <param name="fileName">导出路径</param>
        /// <param name="errmsg">出错信息</param>
        public static void Export(DataTable dt, List<ExportFieldApplyModel> mappingInfo, string fileName, out string errmsg)
        {
            errmsg = "";
            try
            {
                DataTable dtFilter = ConvertDT(dt, mappingInfo);
                ExcelHelper.ExportDTtoExcel(dtFilter, fileName);
            }
            catch (Exception ex)
            {
                errmsg = ex.Message;
            }
        }

        /// <summary>
        /// DataTable转换
        /// </summary>
        /// <param name="dtOrignal">原始DataTable</param>
        /// <param name="lstApplyInfo">导出配置信息</param>
        /// <returns></returns>
        private static DataTable ConvertDT(DataTable dtOrignal, List<ExportFieldApplyModel> lstApplyInfo)
        {
            DataTable dtTarget = new DataTable();
            //创建字段
            foreach (ExportFieldApplyModel applyInfo in lstApplyInfo)
            {
                if (applyInfo.Enabled)
                {
                    dtTarget.Columns.Add(applyInfo.FieldName).DataType = System.Type.GetType("System.String");
                }
            }
            Type type = Type.GetType("HQ.Core.BLL.ExportFieldFunctionProvider");

            //行数据复制
            foreach (DataRow dr in dtOrignal.Rows)
            {
                DataRow drNew = dtTarget.NewRow();
                foreach (DataColumn column in dtTarget.Columns)
                {
                    if (dtOrignal.Columns.Contains(column.ColumnName))
                    {
                        //判断是否需要对内容进行过滤
                        string fieldValue = dr[column.ColumnName].ToString();
                        ExportFieldApplyModel model = lstApplyInfo.Find((new Predicate<ExportFieldApplyModel>(delegate(ExportFieldApplyModel mm)
                        {
                            return mm.FieldName.Equals(column.ColumnName, StringComparison.CurrentCultureIgnoreCase);
                        })));
                        if (model != null && !string.IsNullOrEmpty(model.Function))
                        {
                            MethodInfo method = type.GetMethod(model.Function, BindingFlags.Static | BindingFlags.Public);
                            if (method != null)
                            {
                                object obj = method.Invoke(null, new object[] { fieldValue });
                                fieldValue = obj.ToString();
                            }
                        }
                        drNew[column.ColumnName] = fieldValue;
                    }
                }
                dtTarget.Rows.Add(drNew);
            }
            dtTarget.AcceptChanges();

            //列更名
            foreach (DataColumn column in dtTarget.Columns)
            {
                ExportFieldApplyModel model = lstApplyInfo.Find((new Predicate<ExportFieldApplyModel>(delegate(ExportFieldApplyModel mm)
                {
                    return mm.FieldName.Equals(column.ColumnName, StringComparison.CurrentCultureIgnoreCase);
                })));
                if (model != null && model.EnabledAlias && model.Alias != string.Empty)
                {
                    if (!dtTarget.Columns.Contains(model.Alias))
                    {
                        column.ColumnName = model.Alias;
                    }
                }
            }

            //清理返回
            dtOrignal.Dispose();
            return dtTarget;
        }


        /// <summary>
        /// 导出到内存流中
        /// </summary>
        /// <param name="dt">数据</param>
        /// <returns></returns>
        public static MemoryStream ExportToMemoryStream(DataTable dt)
        {
            return ExcelHelper.ExportDT(dt);
        }
        /// <summary>
        /// 导出到内存流中(此方法为定制方法)
        /// </summary>
        /// <param name="dtSource">为主数据源</param>
        /// <param name="dtSource2">为子数据源，dtSource2数据源的列不能大于dtSource的列，dtSource2列中必须有ID这个列名</param>
        /// <param name="primaryKeyColumnIndex">dtSource中主键的列索引，该主键值必须和dtSource2中的ID值有外键关系</param>
        /// <returns></returns>
        public static MemoryStream ExportToMemoryStream(DataTable dtSource, DataTable dtSource2, int primaryKeyColumnIndex, bool BackgroundColor = true)
        {
            return ExcelHelper.ExportDT(dtSource, dtSource2, primaryKeyColumnIndex, BackgroundColor);
        }

        /// <summary>
        /// 导出到内存流中
        /// </summary>
        /// <param name="dt">数据</param>
        /// <param name="mappingInfo"></param>
        /// <param name="errmsg"></param>
        /// <returns></returns>
        public static MemoryStream ExportToMemoryStream(DataTable dt, List<ExportFieldApplyModel> mappingInfo, out string errmsg)
        {
            errmsg = "";
            try
            {
                DataTable dtFilter = ConvertDT(dt, mappingInfo);
                return ExcelHelper.ExportDT(dtFilter);
            }
            catch (Exception ex)
            {
                errmsg = ex.Message;
                return null;
            }
        }

    }

    /// <summary>
    /// 导出字段信息
    /// </summary>
    public class ExportFieldModel
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 字段别名
        /// </summary>
        public string FieldAlias { get; set; }

        /// <summary>
        /// 可用的方法
        /// </summary>
        public List<string> Functions { get; set; }

    }

    /// <summary>
    /// 导出字段的配置情况
    /// </summary>
    public class ExportFieldApplyModel
    {
        /// <summary>
        /// 字段
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 是否导出
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 中文名
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// 是否使用中文名的字段
        /// </summary>
        public bool EnabledAlias { get; set; }

        /// <summary>
        /// 字段内容的值格式化
        /// </summary>
        public string Function { get; set; }

        public static ExportFieldApplyModel Build(string fieldName, string alias, string function = "")
        {
            return new ExportFieldApplyModel() { FieldName = fieldName, Alias = alias, Function = function, Enabled = true, EnabledAlias = true };
        }
    }

    /// <summary>
    /// 导出字段的值格式化方法负责人
    /// </summary>
    public class ExportFieldFunctionProvider
    {
        
    }
}
