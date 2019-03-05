using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace DTU
{
    //画布类
    public class canvas
    {
        public int row = 20;
        public int column = 15;
        public int[,] Arr_Canvas;

        public int Score = 0;
        public int lv = 1;//等级

        public int Block_Width = 30;//小方块宽度
        public int Block_Height = 30;

        public bool Bool_Can_Creat_Sky_Block = true;

        sky sky = new sky();//实例化天空对象
        
        public canvas()
        {
            Arr_Canvas = new int[row, column];//初始化数组
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Arr_Canvas[i, j] = 0;
                }
            }
        }

        /********* 飞机向左移动************/
        public void Move_Left()
        {
            for(int i = 0; i < row; i++)
            {
                for(int j = 0; j < column; j++)
                {
                    if (Arr_Canvas[i, j] == 2)
                    {
                        Arr_Canvas[i, j - 1] = 2;
                        Arr_Canvas[i, j] = 0;
                    }
                    else if (Arr_Canvas[i, j] == 5)
                    {
                        Arr_Canvas[i, j-1] = 5;
                        Arr_Canvas[i, j] = 0;
                    }
                    else if (Arr_Canvas[i, j] == 6)
                    {
                        Arr_Canvas[i, j - 1] = 6;
                        Arr_Canvas[i, j] = 0;
                    }
                    else if (Arr_Canvas[i, j] == 7)
                    {
                        Arr_Canvas[i, j - 1] = 7;
                        Arr_Canvas[i, j] = 0;
                    }
                }
            }
        }

        /********* 飞机能否左移 ************/
        public bool Can_Move_Left()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (Arr_Canvas[i, 0]==5)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /********* 飞机向右移动 ************/
        public void Move_Right()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = column-1; j >=0; j--)
                {
                    if (Arr_Canvas[i, j] == 2)
                    {
                        Arr_Canvas[i, j + 1] = 2;
                        Arr_Canvas[i, j] = 0;
                    }
                    else if (Arr_Canvas[i, j] == 5)
                    {
                        Arr_Canvas[i, j+1] = 5;
                        Arr_Canvas[i, j] = 0;
                    }
                    else if (Arr_Canvas[i, j] == 6)
                    {
                        Arr_Canvas[i, j + 1] = 6;
                        Arr_Canvas[i, j] = 0;
                    }
                    else if (Arr_Canvas[i, j] == 7)
                    {
                        Arr_Canvas[i, j + 1] = 7;
                        Arr_Canvas[i, j] = 0;
                    }
                }
            }
        }

        /********* 飞机能否右移************/
        public bool Can_Move_Right()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (Arr_Canvas[i, column-1] == 7)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /********* 飞机向上移动************/
        public void Move_Up()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (Arr_Canvas[i, j] == 2)
                    {
                        Arr_Canvas[i-1, j] = 2;
                        Arr_Canvas[i, j] = 0;
                    }
                    else if (Arr_Canvas[i, j] == 5)
                    {
                        Arr_Canvas[i - 1, j] = 5;
                        Arr_Canvas[i, j] = 0;
                    }
                    else if (Arr_Canvas[i, j] == 6)
                    {
                        Arr_Canvas[i - 1, j] = 6;
                        Arr_Canvas[i, j] = 0;
                    }
                    else if (Arr_Canvas[i, j] == 7)
                    {
                        Arr_Canvas[i - 1, j] = 7;
                        Arr_Canvas[i, j] = 0;
                    }
                }
            }
        }

        /********* 飞机能否上移 ************/
        public bool Can_Move_Up()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (Arr_Canvas[0, j]==6||(Arr_Canvas[i,j]==5&&Arr_Canvas[i-1, j]==3) || (Arr_Canvas[i, j] == 6 && Arr_Canvas[i - 1, j] == 3) || (Arr_Canvas[i, j] == 7 && Arr_Canvas[i - 1, j] == 3))//为顶部，或此行上一行为天空
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /********* 飞机向下移动 ************/
        public void Move_Down()
        {
            for (int i = row-1; i >=0; i--)
            {
                for (int j = 0; j < column; j++)
                {
                    if (Arr_Canvas[i, j] == 2)//在20层以上才满足
                    {
                        Arr_Canvas[i +1, j] = 2;
                        Arr_Canvas[i, j] = 0;
                    }else if(Arr_Canvas[i, j] == 5)
                    {
                        Arr_Canvas[i + 1, j] = 5;
                        Arr_Canvas[i, j] = 0;
                    }
                    else if (Arr_Canvas[i, j] == 6)
                    {
                        Arr_Canvas[i + 1, j] = 6;
                        Arr_Canvas[i, j] = 0;
                    }
                    else if (Arr_Canvas[i, j] == 7)
                    {
                        Arr_Canvas[i + 1, j] = 7;
                        Arr_Canvas[i, j] = 0;
                    }
                }
            }
        }

        /********* 飞机能否下移 ************/
        public bool Can_Move_Down()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (Arr_Canvas[row-1, j] == 2)//为3或者第一行
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /********* 产生子弹 ************/
        public void Creat_Bullet5()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (Arr_Canvas[i, j] == 5)
                    {
                        Arr_Canvas[i-1, j] = 1;
                    }
                }
            }
        }
        public void Creat_Bullet6()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (Arr_Canvas[i, j] == 6)
                    {
                        Arr_Canvas[i - 1, j] = 1;
                    }
                }
            }
        }
        public void Creat_Bullet7()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (Arr_Canvas[i, j] == 7)
                    {
                        Arr_Canvas[i - 1, j] = 1;
                    }
                }
            }
        }

        /********* 能否产生子弹 ************/
        public bool Can_Creat_Bullet()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (Arr_Canvas[0, j] == 5)//第一行为5
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /********* 移动子弹 ************/
        public void Move_Bullet()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (Arr_Canvas[i, j] == 1)
                    {
                        Arr_Canvas[i - 1, j] = 1;
                        Arr_Canvas[i, j] = 0;
                    } 
                }
            }
        }

        /********* 产生天空方块 ************/
        public void Creat_Sky()
        {
            Random rm = new Random();
            int Num = rm.Next(1,5);//1到4，大于等于下限，小于上限。
            switch (Num)
            {
                case 1://tpye1()
                    sky.tpye1();
                    for(int i = 0; i < sky.Num_block; i++)
                    {
                        Arr_Canvas[0, i] = sky.sky_block[i];
                    }
                    break;
                case 2://tpye1()
                    sky.tpye2();
                    for (int i = 0; i < sky.Num_block; i++)
                    {
                        Arr_Canvas[0, i] = sky.sky_block[i];
                    }
                    break;
                case 3://tpye1()
                    sky.tpye3();
                    for (int i = 0; i < sky.Num_block; i++)
                    {
                        Arr_Canvas[0, i] = sky.sky_block[i];
                    }
                    break;
                case 4://tpye1()
                    sky.tpye4();
                    for (int i = 0; i < sky.Num_block; i++)
                    {
                        Arr_Canvas[0, i] = sky.sky_block[i];
                    }
                    break;
            }
        }

        /********* 能否产生天空方块 ************/
        public bool Can_Creat_Sky_Block(bool Can_Creat_Sky_Block)
        {
            for (int i = 0; i < row; i++)//确保第一行为空就可以产生方块，然方块定时下移
            {
                for (int j = 0; j < column; j++)
                {
                    if (Arr_Canvas[0, j] == 3)//如何第一行有天空方块就不产生
                    {
                        Can_Creat_Sky_Block = false;
                    }
                }
            }
            return Can_Creat_Sky_Block;
        }

        /********* 移动天空方块 ************/
        public void Move_Sky_Block()
        {
            for (int i = row-1; i >=0; i--)//从下往上遍历
            {
                for (int j = 0; j < column; j++)
                {
                    if (Arr_Canvas[i, j] == 3)
                    {
                        Arr_Canvas[i + 1, j] = 3;
                        Arr_Canvas[i, j] = 0;
                    }
                }
            }
        }

        /********* 能否移动天空方块 ************/
        public bool Can_Move_Sky_Block()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (Arr_Canvas[row-1, j] == 3)//如何第最后一行有天空方块就不产生
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /********* 消除天空方块 ************/
        public void Destroy_Sky_Block()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (Arr_Canvas[i, j] == 1&& Arr_Canvas[i - 1, j] == 3)//如果有子弹并且上一行是天空方块
                    {
                        Arr_Canvas[i, j] = 0;//子弹为0
                        Arr_Canvas[i-1, j] = 0;//天空为0
                        Score += 2;//加分
                    }
                }
            }
        }

        /********* 能否消除天空方块 ************/
        public bool Can_Destroy_Sky_Block()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (Arr_Canvas[0, j] == 1)//子弹在第一行
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        /********* 结束游戏 ************/
        public void Game_Over()//所有数据为0
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Arr_Canvas[i, j] = 0;
                }
            }
            Bool_Can_Creat_Sky_Block = false;
            MessageBox.Show("Game Over！Your score are："+Score.ToString());
        }

        /********* 能否结束游戏 ************/
        public bool Can_Game_Over()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    //天空下一行为飞机
                    if (Arr_Canvas[i, j] == 3&&(Arr_Canvas[i+1, j] == 5|| Arr_Canvas[i + 1, j] == 6||Arr_Canvas[i + 1, j] == 7))
                    {
                        return true;
                    }
                    else if (Arr_Canvas[row-1,j]==3)//最后一行为天空
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
