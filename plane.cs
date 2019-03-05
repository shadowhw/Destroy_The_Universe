using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTU
{
    //飞机类
    public class plane
    {
        public int[,] Arr_Plane;

        public plane()
        {
            Arr_Plane = new int[2, 3] { { 0, 6, 0},{ 5, 2, 7 } };
        }
    }
}
