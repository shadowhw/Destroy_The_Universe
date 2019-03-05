using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTU
{
    //天空类
    public class sky
    {
        public int[] sky_block;
        public int Num_block = 15;

        public sky()
        {
            sky_block = new int[15]{3, 0, 3, 3, 0, 3, 0, 0, 3, 0, 3, 0, 3, 0, 3 };
        }

        public void tpye1()
        {
            sky_block = new int[15] { 3, 0, 3, 3, 0, 3, 0, 0, 3, 0, 3, 0, 3, 0, 3 };
        }

        public void tpye2()
        {
            sky_block = new int[15] { 0, 3, 0, 3, 0, 3, 0, 3, 0, 0, 3, 0, 3, 3, 0 };
        }

        public void tpye3()
        {
            sky_block = new int[15] { 3, 0, 0, 3, 0, 3, 0, 3, 0, 0, 3, 0, 0, 0, 3 };
        }

        public void tpye4()
        {
            sky_block = new int[15] { 0, 0, 3, 0, 3, 0, 3, 0, 3, 3, 3, 3, 0, 0, 0 };
        }
    }
}
