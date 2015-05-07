using MA.DAL;
using MA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.BLL
{
    public class MaUserBLL
    {
        MaUserDAL _maUserDal = new MaUserDAL();
        public IList<MaUser> GetList()
        {
            return _maUserDal.GetList();
        }
    }
}
