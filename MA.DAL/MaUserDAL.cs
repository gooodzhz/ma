using MA.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.DAL
{
    public partial class MaUserDAL
    {
        public List<MaUser> SearchByName(string name)
        {
            string where = " 1=1 ";
            if (!string.IsNullOrEmpty(name))
            {
                where += string.Format(" And name LIKE '{0}' ", name);
            }
            return GetList(where);
        }

        public List<MaUser> SearchByName(string name, PagerInfo pager)
        {
            string where = " 1=1 ";
            if (!string.IsNullOrEmpty(name))
            {
                where += string.Format(" And name LIKE '{0}' ", name);
            }
            pager.Count = Count(where);
            return GetList(where, pager);
        }
    }
}
