using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;
namespace WebSite20210103IP登入限制.DAL
{
    /// <summary>[SYSAA]表数据访问类
    /// 作者:alonso(line id: menshin7)
    /// 创建时间:2021-01-03 13:25:13
    /// </summary>
    public partial class SYSAADAL
    {
        public SYSAADAL()
        { }
        /// <summary>增加一条数据
        /// 
        /// </summary>
        public int Add(WebSite20210103IP登入限制.Model.SYSAA model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [SYSAA](");
            strSql.Append("[AA002], [AA003]  )");
            strSql.Append(" values (");
            strSql.Append("@AA002, @AA003  );select @@identity;"); 
 
    using (var connection = ConnectionFactory.GetOpenConnection())
            {
                   int i = connection.Query<int>(strSql.ToString(), model).SingleOrDefault();;
                return i;
            }
        }

        /// <summary>更新一条数据
        /// 
        /// </summary>
        public bool Update(WebSite20210103IP登入限制.Model.SYSAA model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [SYSAA] set ");
            strSql.Append("[AA002]=@AA002, [AA003]=@AA003  ");
            strSql.Append(" where AA001=@AA001 ");
       using (var connection = ConnectionFactory.GetOpenConnection())
            {
                int i = connection.Execute(strSql.ToString(), model);
                return i > 0;
            }
        }

        /// <summary>按条件更新数据
        /// 
        /// </summary>
        public bool UpdateByCond(string str_set, string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [SYSAA] set "+str_set +" "); 
            strSql.Append(" where "+cond);
               using (var connection = ConnectionFactory.GetOpenConnection())
            {
                int i = connection.Execute(strSql.ToString());
                return i > 0;
            }
        }

        /// <summary>删除一条数据
        /// 
        /// </summary>
        public bool Delete(int AA001)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [SYSAA] ");
            strSql.Append(" where AA001=@AA001 ");
         using (var connection = ConnectionFactory.GetOpenConnection())
            {

                int i = connection.Execute(strSql.ToString(), new { AA001 = AA001 });
                return i > 0;
            }
        }

        /// <summary>根据条件删除数据
        /// 
        /// </summary>
        public bool DeleteByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [SYSAA] ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
                 using (var connection = ConnectionFactory.GetOpenConnection())
            {
                int i = connection.Execute(strSql.ToString());
                return i > 0;
            }
        }
		
        /// <summary>取一个字段的值
        /// 
        /// </summary>
        /// <param name="filed">字段，如sum(je)</param>
        /// <param name="cond">条件，如userid=2</param>
        /// <returns></returns>
        public string GetOneFiled(string filed, string cond)
        {
            string sql = "select " + filed + " from [SYSAA]";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
			
             using (var connection = ConnectionFactory.GetOpenConnection())
            {
                string tmp = connection.ExecuteScalar<string>(sql);
                return tmp;
            }
        }

        /// <summary>取一个字段的值
        /// 
        /// </summary>
        /// <param name="filed">字段，如sum(je)</param>
        /// <param name="cond">条件，如userid=2</param>
        /// <returns></returns>
        public double GetOneFiledDouble(string filed, string cond)
        {
            string tmp = GetOneFiled(filed, cond);
            return string.IsNullOrEmpty(tmp) ? 0 : double.Parse(tmp);
        }

        /// <summary>得到一个对象实体
        /// 
        /// </summary>
        public WebSite20210103IP登入限制.Model.SYSAA GetModel(int AA001)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from [SYSAA] ");
            strSql.Append(" where AA001=@AA001 ");
             WebSite20210103IP登入限制.Model.SYSAA model = null;
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                model = connection.Query<WebSite20210103IP登入限制.Model.SYSAA>(strSql.ToString(), new { AA001=AA001 }).SingleOrDefault();

            }
            return model;
        }

        /// <summary>根据条件得到一个对象实体
        /// 
        /// </summary>
        public WebSite20210103IP登入限制.Model.SYSAA GetModelByCond(string cond )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from [SYSAA] ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            } 
        WebSite20210103IP登入限制.Model.SYSAA model = null;
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                model = connection.Query<WebSite20210103IP登入限制.Model.SYSAA>(strSql.ToString()).SingleOrDefault();

            }
            return model;
        }

 

 
 

        /// <summary>获得数据列表
        /// 
        /// </summary>
        public List<WebSite20210103IP登入限制.Model.SYSAA> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [SYSAA] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<WebSite20210103IP登入限制.Model.SYSAA> list = new List<WebSite20210103IP登入限制.Model.SYSAA>();
                  using (var connection = ConnectionFactory.GetOpenConnection())
            {
                list = connection.Query<WebSite20210103IP登入限制.Model.SYSAA>(strSql.ToString()).ToList();

            }
            return list;
        }

        /// <summary>分页获取数据列表
        /// 
        /// </summary>
        public List<WebSite20210103IP登入限制.Model.SYSAA> GetListArray(string fileds, string orderstr, int PageSize, int PageIndex, string strWhere )
        { 
   string order = orderstr.Split(' ')[0];
            string ordertype= orderstr.Split(' ')[1];
            string cond = string.IsNullOrEmpty(strWhere) ? "" : string.Format(" where {0}",strWhere);
          string sql = string.Format("SELECT * FROM ( SELECT ROW_NUMBER() OVER (ORDER BY {0} {1}) AS pos, {2} FROM  [SYSAA] {3}  ) AS sp WHERE pos BETWEEN {4} AND {5}",order,ordertype,fileds,cond, (((PageIndex - 1) * PageSize) + 1), PageSize * PageIndex);

		 // 	    string sql = string.Format("select {0} from [SYSAA] {1} order by {2} offset {3} rows fetch next {4} rows only", fileds, cond, orderstr, (PageIndex - 1) * PageSize, PageSize);
          

            List<WebSite20210103IP登入限制.Model.SYSAA> list = new List<WebSite20210103IP登入限制.Model.SYSAA>(); 
                  using (var connection = ConnectionFactory.GetOpenConnection())
            {
                list = connection.Query<WebSite20210103IP登入限制.Model.SYSAA>(sql).ToList();

            }
            return list;
        }

 

        /// <summary>计算记录数
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int CalcCount(string cond )
        {
            string sql = "select count(1) from [SYSAA]";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
         using (var connection = ConnectionFactory.GetOpenConnection())
            {
                int i = connection.Query<int>(sql).SingleOrDefault();
                return i;

            }
        }
 
    }
}

