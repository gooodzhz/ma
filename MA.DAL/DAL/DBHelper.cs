using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.Text;
using MA.Common;

namespace MA.DAL
{

    public class DBHelper
    {
        //��ӵ������ļ���<configuration>�ڵ���
        //   <connectionStrings>
        //       <!--��д���ݿ�������½��������-->
        //        <add name="conStr" connectionString="Data Source=.;Initial Catalog=;User ID=;Password="/>
        //  
        //   </connectionStrings>
        //<appSettings>
        //      <add key="dbConnection" value="server=192.168.1.111\SQL2005;database=GCUMS;UID=sa;PWD=sa;max pool size=20000;Pooling=true;"/>
        //  </appSettings>
        //�����configuration���ã����������ռ�
        private static readonly string conStr = ConfigHelper.GetConnection("conStr");
        //private static readonly string conStr = Config.ConnStr;
        /// <summary>
        /// ��������ַ���
        /// </summary>
        /// <returns></returns>
        public static MySqlConnection getConn()
        {
            return new MySqlConnection(conStr);
        }
        /// <summary>
        /// ��ѯ����������е�ֵ����ʽ��SQL���
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object Scalar(String sql)
        {
            using (MySqlConnection con = getConn())
            {
                try
                {
                    MySqlCommand com = new MySqlCommand(sql, con);
                    con.Open();
                    return com.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        /// <summary>
        /// ��ѯ����������е�ֵ ������sql���
        /// </summary>
        /// <param name="paras">��������</param>
        /// <param name="sql">sql���</param>
        /// <returns></returns>
        public static object Scalar(string sql, MySqlParameter[] paras)
        {
            using (MySqlConnection con = getConn())
            {
                try
                {
                    MySqlCommand com = new MySqlCommand(sql, con);
                    con.Open();
                    if (paras != null) //�������
                    {
                        com.Parameters.AddRange(paras);
                    }
                    return com.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;

                }
            }
        }

        /// <summary>
        /// ��ɾ�Ĳ���,������Ӱ�����������ʽ��SQL���
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int NoneQuery(String sql)
        {

            using (MySqlConnection conn = getConn())
            {
                conn.Open();
                using (MySqlCommand comm = new MySqlCommand(sql, conn))
                {
                    return comm.ExecuteNonQuery();
                }

            }
        }
        /// <summary>
        /// ��ɾ�Ĳ���,������Ӱ������� �洢����
        /// </summary>
        /// <param name="sql">�洢��������</param>
        /// <param name="paras">����</param>
        /// <returns></returns>
        public static int NoneQuery(String sql, MySqlParameter[] paras)
        {
            using (MySqlConnection conn = getConn())
            {
                conn.Open();
                using (MySqlCommand comm = new MySqlCommand(sql, conn))
                {
                    comm.Parameters.AddRange(paras);
                    return comm.ExecuteNonQuery();
                }

            }
        }
        /// <summary>
        /// ��ѯ����,����һ�����ݱ�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetDateTable(String sql)
        {
            using (MySqlConnection con = getConn())
            {
                DataTable dt = new DataTable();
                try
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter(sql, con);
                    sda.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return dt;
            }
        }
        /// <summary>
        ///  ��ѯ����,����һ�����ݱ�,�洢����
        /// </summary>
        /// <param name="sp_Name">�洢��������</param>
        /// <param name="paras">�洢���̲���</param>
        /// <returns></returns>
        public static DataTable GetDateTable(String sql, MySqlParameter[] paras)
        {
            using (MySqlConnection con = getConn())
            {
                DataTable dt = new DataTable();
                try
                {
                    MySqlCommand com = new MySqlCommand(sql, con);
                    com.Parameters.AddRange(paras);
                    MySqlDataAdapter sda = new MySqlDataAdapter(com);
                    sda.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return dt;
            }
        }



    }

    /// <summary>
    /// DataTable��ʵ���໥��ת��
    /// </summary>
    /// <typeparam name="T">ʵ����</typeparam>
    public class DatatableFill<T> where T : new()
    {
        #region DataTableת����ʵ����
        /// <summary>
        /// �������б���DataSet�ĵ�һ�������ʵ����
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
        public List<T> FillModel(DataSet ds)
        {
            if (ds == null || ds.Tables[0] == null || ds.Tables[0].Rows.Count == 0)
            {
                return new List<T>();
            }
            else
            {
                return FillModel(ds.Tables[0]);
            }
        }

        /// <summary>  
        /// �������б���DataSet�ĵ�index�������ʵ����
        /// </summary>  
        public List<T> FillModel(DataSet ds, int index)
        {
            if (ds == null || ds.Tables.Count <= index || ds.Tables[index].Rows.Count == 0)
            {
                return new List<T>();
            }
            else
            {
                return FillModel(ds.Tables[index]);
            }
        }



        /// <summary>  
        /// �������б���DataTable���ʵ����
        /// </summary>  
        public List<T> FillModel(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return new List<T>();
            }
            List<T> modelList = new List<T>();
            foreach (DataRow dr in dt.Rows)
            {
                //T model = (T)Activator.CreateInstance(typeof(T));  
                T model = new T();
                for (int i = 0; i < dr.Table.Columns.Count; i++)
                {
                    PropertyInfo propertyInfo = model.GetType().GetProperty(ToSplitFirstUpper(dr.Table.Columns[i].ColumnName));
                    if (propertyInfo != null && dr[i] != DBNull.Value)
                        propertyInfo.SetValue(model, dr[i], null);
                }

                modelList.Add(model);
            }
            return modelList;
        }

        /// <summary>  
        /// ��������DataRow���ʵ����
        /// </summary>  
        public T FillModel(DataRow dr)
        {
            if (dr == null)
            {
                return default(T);
            }

            //T model = (T)Activator.CreateInstance(typeof(T));  
            T model = new T();

            for (int i = 0; i < dr.Table.Columns.Count; i++)
            {
                PropertyInfo propertyInfo = model.GetType().GetProperty(ToSplitFirstUpper(dr.Table.Columns[i].ColumnName));
                if (propertyInfo != null && dr[i] != DBNull.Value)
                    propertyInfo.SetValue(model, dr[i], null);
            }
            return model;
        }

        // ȥ�»���,ת��д
        public static string ToSplitFirstUpper(string file)
        {
            string[] words = file.Split('_');
            StringBuilder firstUpperWorld = new StringBuilder();
            foreach (string word in words)
            {
                string firstUpper = ToFirstUpper(word);
                firstUpperWorld.Append(firstUpper);
            }
            string firstUpperFile = firstUpperWorld.ToString().TrimEnd(new char[] { '_' });
            return firstUpperFile;
        }

        // ���ַ������ó�����ĸ��д
        public static string ToFirstUpper(string field)
        {
            string first = field.Substring(0, 1).ToUpperInvariant();
            string result = first;
            if (field.Length > 1)
            {
                string after = field.Substring(1);
                result = first + after;
            }
            return result;
        }
        #endregion

        #region ʵ����ת����DataTable

        /// <summary>
        /// ʵ����ת����DataSet
        /// </summary>
        /// <param name="modelList">ʵ�����б�</param>
        /// <returns></returns>
        public DataSet FillDataSet(List<T> modelList)
        {
            if (modelList == null || modelList.Count == 0)
            {
                return null;
            }
            else
            {
                DataSet ds = new DataSet();
                ds.Tables.Add(FillDataTable(modelList));
                return ds;
            }
        }

        /// <summary>
        /// ʵ����ת����DataTable
        /// </summary>
        /// <param name="modelList">ʵ�����б�</param>
        /// <returns></returns>
        public DataTable FillDataTable(List<T> modelList)
        {
            if (modelList == null || modelList.Count == 0)
            {
                return null;
            }
            DataTable dt = CreateData(modelList[0]);

            foreach (T model in modelList)
            {
                DataRow dataRow = dt.NewRow();
                foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
                {
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(model, null);
                }
                dt.Rows.Add(dataRow);
            }
            return dt;
        }

        /// <summary>
        /// ����ʵ����õ���ṹ
        /// </summary>
        /// <param name="model">ʵ����</param>
        /// <returns></returns>
        private DataTable CreateData(T model)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                dataTable.Columns.Add(new DataColumn(propertyInfo.Name, propertyInfo.PropertyType));
            }
            return dataTable;
        }

        #endregion
    }
}