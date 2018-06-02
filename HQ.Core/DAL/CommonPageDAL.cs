using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Micro.Base.Common;
using Micro.Mall.Core.Model;
using HQ.Common.DB;

namespace Micro.Mall.Core.DAL
{
    public class CommonPageDAL
    {  /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connectionString"></param>
        /// <param name="pageQuery">查询内容</param>
        /// <param name="paging">分页</param>
        /// <returns></returns>
        public List<T> GetPageData<T>(string connectionString, PageQueryModel pageQuery, PagingModel paging) where T : new()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                SqlCommand comm = new SqlCommand();
                comm.Connection = connection;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "CommonPageProc";
                comm.Parameters.Add("@TableName", SqlDbType.VarChar, 5000).Value = pageQuery.TableName;
                comm.Parameters.Add("@Fields", SqlDbType.VarChar, 5000).Value = pageQuery.Fields;
                comm.Parameters.Add("@OrderField", SqlDbType.VarChar, 5000).Value = pageQuery.OrderField;
                comm.Parameters.Add("@sqlWhere", SqlDbType.VarChar, 5000).Value = pageQuery.SqlWhere;
                comm.Parameters.Add("@pageSize", SqlDbType.Int, 16).Value = paging.PageSize;
                comm.Parameters.Add("@pageIndex", SqlDbType.Int, 16).Value = paging.PageIndex;
                SqlParameter paraTP = new SqlParameter("@TotalPage", SqlDbType.Int);
                paraTP.Direction = ParameterDirection.Output;
                paraTP.Value = paging.PageCount;
                comm.Parameters.Add(paraTP);
                SqlParameter param = new SqlParameter("@TotalRecord", SqlDbType.Int);
                param.Direction = ParameterDirection.ReturnValue;
                comm.Parameters.Add(param);

                List<T> ent = null;
                using (IDataReader dr = comm.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    ent = DbHelperSQL.GetEntityList<T>(dr);
                }

                paging.PageCount = Convert.ToInt32(comm.Parameters["@TotalPage"].Value);
                paging.RecordCount = Convert.ToInt32(param.Value);
                comm.Parameters.Clear();
                return ent;

            }
        }


        public string GetEnumDescription<T>(int value) where T : new()
        {
            Type t = typeof(T);
            foreach (System.Reflection.MemberInfo mInfo in t.GetMembers())
            {
                if (mInfo.Name == t.GetEnumName(value))
                {
                    foreach (Attribute attr in Attribute.GetCustomAttributes(mInfo))
                    {
                        if (attr.GetType() == typeof(System.ComponentModel.DescriptionAttribute))
                        {
                            return ((System.ComponentModel.DescriptionAttribute)attr).Description;
                        }
                    }
                }
            }
            return "";
        }
    }
}
