using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.Model
{
    public class PagerInfo
    {
        private int _index;

        private int _size;

        private int _count;

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }



    }
}
