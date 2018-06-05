using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HQ.Common.DB;
using Newtonsoft.Json;
using HQ.Model;
using System.Collections.Generic;

namespace HQ.DAL
{
    /// <summary>
    /// 用户等级数据访问层
    /// </summary>
    public partial class UserLevelDAL
	{
		public UserLevelDAL()
		{}
        #region  BasicMethod

        /// <summary>
        /// 返回当前等级类型最大的LevelNo
        /// </summary>
        /// <param name="LevelType"></param>
        /// <returns></returns>
        public int GetLevelNo(int LevelType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select max(LevelNo) from HQ_User_Level where LevelType={0}",LevelType);
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return  -1;
            }
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HQ.Model.UserLevelModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HQ_User_Level(");
			strSql.Append("LevelNo,LevelName,Remark,Createtime,UpgradeCondition,LevelType,LevelModel)");
			strSql.Append(" values (");
			strSql.Append("@LevelNo,@LevelName,@Remark,@Createtime,@UpgradeCondition,@LevelType,@LevelModel)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@LevelNo", SqlDbType.Int,4),
					new SqlParameter("@LevelName", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,500),
					new SqlParameter("@Createtime", SqlDbType.DateTime),
					new SqlParameter("@UpgradeCondition", SqlDbType.VarChar,-1),
                    new SqlParameter("@LevelType",SqlDbType.Int),
                    new SqlParameter("@LevelModel",SqlDbType.Int)
            };
			parameters[0].Value = model.LevelNo;
			parameters[1].Value = model.LevelName;
			parameters[2].Value = model.Remark;
			parameters[3].Value = model.Createtime;
			parameters[4].Value = JsonConvert.SerializeObject(model.UpgradeCondition);
            parameters[5].Value = model.LevelType;
            parameters[6].Value = model.LevelModel;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(HQ.Model.UserLevelModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HQ_User_Level set ");
			strSql.Append("LevelNo=@LevelNo,");
			strSql.Append("LevelName=@LevelName,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("UpgradeCondition=@UpgradeCondition,");
            strSql.Append("LevelType=@LevelType,");
            strSql.Append("LevelModel=@LevelModel");
			strSql.Append(" where LevelId=@LevelId");
			SqlParameter[] parameters = {
					new SqlParameter("@LevelNo", SqlDbType.Int,4),
					new SqlParameter("@LevelName", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,500),
					new SqlParameter("@UpgradeCondition", SqlDbType.VarChar,-1),
					new SqlParameter("@LevelId", SqlDbType.Int,4),
                    new SqlParameter("@LevelType",SqlDbType.Int),
                    new SqlParameter("@LevelModel",SqlDbType.Int)
            };
			parameters[0].Value = model.LevelNo;
			parameters[1].Value = model.LevelName;
			parameters[2].Value = model.Remark;
			parameters[3].Value = JsonConvert.SerializeObject(model.UpgradeCondition);
            parameters[4].Value = model.LevelId;
            parameters[5].Value = model.LevelType;
            parameters[6].Value = model.LevelModel;

            int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int LevelId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HQ_User_Level ");
			strSql.Append(" where LevelId=@LevelId");
			SqlParameter[] parameters = {
					new SqlParameter("@LevelId", SqlDbType.Int,4)
			};
			parameters[0].Value = LevelId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public HQ.Model.UserLevelModel GetModel(int LevelId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from HQ_User_Level ");
			strSql.Append(" where LevelId=@LevelId");
			SqlParameter[] parameters = {
					new SqlParameter("@LevelId", SqlDbType.Int,4)
			};
			parameters[0].Value = LevelId;

			HQ.Model.UserLevelModel model=new HQ.Model.UserLevelModel();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public HQ.Model.UserLevelModel DataRowToModel(DataRow row)
		{
			HQ.Model.UserLevelModel model=new HQ.Model.UserLevelModel();
			if (row != null)
			{
				if(row["LevelId"]!=null && row["LevelId"].ToString()!="")
				{
					model.LevelId=int.Parse(row["LevelId"].ToString());
				}
				if(row["LevelNo"]!=null && row["LevelNo"].ToString()!="")
				{
					model.LevelNo=int.Parse(row["LevelNo"].ToString());
				}
				if(row["LevelName"]!=null)
				{
					model.LevelName=row["LevelName"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["Createtime"]!=null && row["Createtime"].ToString()!="")
				{
					model.Createtime=DateTime.Parse(row["Createtime"].ToString());
				}
				if(row["UpgradeCondition"]!=null)
				{
					model.UpgradeCondition= JsonConvert.DeserializeObject<List<UpgradeConditionModel>>(row["UpgradeCondition"].ToString());
				}
                if (row["LevelType"] != null && row["LevelType"].ToString() != "")
                {
                    model.LevelType = int.Parse(row["LevelType"].ToString());
                }
                if (row["LevelModel"] != null && row["LevelModel"].ToString() != "")
                {
                    model.LevelModel = int.Parse(row["LevelModel"].ToString());
                }
            }
			return model;
		}

        /// <summary>
        /// 获取等级列表
        /// </summary>
        /// <returns></returns>
        public List<UserLevelModel> GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from HQ_User_Level order by LevelType asc,LevelNo asc");

            List<UserLevelModel> list = new List<UserLevelModel>();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(DataRowToModel(dr));
                }
                return list;
            }
            else
            {
                return null;
            }
        }
        
		#endregion  BasicMethod
		
	}
}

