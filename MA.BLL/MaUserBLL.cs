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

        public IList<MaUser> SearchByName(string name, PagerInfo info)
        {
            return _maUserDal.SearchByName(name, info);
        }

        public int Add(MaUser info)
        {
            return _maUserDal.Save(info);
        }

        public MaUser GetById(int id)
        {
            return _maUserDal.GetById(id);
        }
    }
}
