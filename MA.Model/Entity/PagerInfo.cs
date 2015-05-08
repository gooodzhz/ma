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

        private int _size = 10;

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
        }

        public string PageIndex
        {
            set
            {
                int tempIndex = 0;
                if (Int32.TryParse(value, out tempIndex))
                {
                    _index = (tempIndex - 1) * _size;
                }
                else
                {
                    _index = 0;
                }
            }
        }

    }
}
