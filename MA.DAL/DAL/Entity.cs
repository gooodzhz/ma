using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using MA.Model;
namespace MA.DAL
{
		
	public partial class MaUserDAL
    {
		public int Save(MaUser model)
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("name", model.Name),
				 new MySqlParameter("pwd", model.Pwd),
				 new MySqlParameter("nickname", model.Nickname),
				 new MySqlParameter("date", model.Date)
			};

			string sql = "INSERT INTO ma_user(name, pwd, nickname, date) VALUES(?name, ?pwd, ?nickname, ?date)";
		    return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update(MaUser model)
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("id", model.Id),
				 new MySqlParameter("name", model.Name),
				 new MySqlParameter("pwd", model.Pwd),
				 new MySqlParameter("nickname", model.Nickname),
				 new MySqlParameter("date", model.Date)
			};

			string sql = "UPDATE ma_user SET name = ?name, pwd = ?pwd, nickname = ?nickname, date = ?date WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public int Delete(int id)
        {
            string sql = string.Format("DELETE FROM ma_user WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public MaUser GetById(int id)
        {
            string sql = string.Format("SELECT * FROM ma_user WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<MaUser> list = new DatatableFill<MaUser>().FillModel(table);
            if (list == null || list.Count == 0) return null;
            return list[0];
        }
		
		public bool Exist(string where)
        {
            int n = Count(where);
            return n > 0 ? true : false;
        }

        public int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM ma_user WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public int Count()
        {
            return Count(" 1 = 1 ");
        }

		public List<MaUser> GetList()
        {
            string sql = "SELECT * FROM ma_user";
            DataTable table = DBHelper.GetDateTable(sql);
			List<MaUser> list = new DatatableFill<MaUser>().FillModel(table);
            return list;

        }

		public List<MaUser> GetList(string where)
        {
            string sql = string.Format("SELECT * FROM ma_user WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<MaUser>().FillModel(table);
        }

        public List<MaUser> GetList(string where, PagerInfo info)
        {
            info.Count = Count(where);
            string sql = string.Format(" {0} LIMIT {1}, {2} ", where,  info.Index, info.Size);
            return GetList(sql);
        }
		
        public int Truncate()
        {
            return DBHelper.NoneQuery("TRUNCATE TABLE ma_user");
        }
    }

}

