using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace DTU
{
    public partial class Form_Main : Form
    {
        //初始化各类
        canvas cs = new canvas();
        plane air = new plane();

        //时间事件
        Timer T_Render = new Timer();//渲染
        Timer T_Control_Bullet = new Timer();//控制子弹
        Timer T_Creat_Sky = new Timer();//产生天空方块

        public Form_Main()
        {
            InitializeComponent();//初始化窗体对象
            //渲染
            T_Render.Interval = 20;
            T_Render.Enabled = false;
            T_Render.Tick += new EventHandler(T_Render_Tick);

            //控制子弹
            T_Control_Bullet.Interval = 50;
            T_Control_Bullet.Enabled = false;
            T_Control_Bullet.Tick += new EventHandler(T_Control_Bullet_Tick);

            //天空方块
            T_Creat_Sky.Interval = 1000;
            T_Creat_Sky.Enabled = false;
            T_Creat_Sky.Tick += new EventHandler(T_Creat_Sky_Tick);

            //生成飞机
            Creat_Plane();

            //是否播放播放背景音乐
            Play_Bgm();
        }

        /************** 渲染全屏,显示数组内容 ******************/
        public void Render_Screen()
        {
            //初始化画布
            Bitmap canvas = new Bitmap(pic_Main.Width, pic_Main.Height);//在画布上创建位图，用于在位图绘画

            Graphics gs = Graphics.FromImage(canvas);

            pic_Main.BackgroundImage = canvas;

            for (int i = 0; i < cs.row; i++)
            {
                for (int j = 0; j < cs.column; j++)
                {
                    if (cs.Arr_Canvas[i, j] == 0)
                    {
                        continue;
                    }
                    else//包括了1和2两种情况
                    {
                        if (cs.Arr_Canvas[i, j] == 1)//子弹
                        {
                            DrawBlock_Red(gs, i, j);
                        }
                        else if (cs.Arr_Canvas[i, j] == 2 || cs.Arr_Canvas[i, j] == 5 || cs.Arr_Canvas[i, j] == 6 || cs.Arr_Canvas[i, j] == 7)//飞机
                        {
                            DrawBlock_Blue(gs, i, j);
                        }
                        else if (cs.Arr_Canvas[i, j] == 3)//天空
                        {
                            DrawBlock_Black(gs, i, j);
                        }
                    }
                }
            }
            pic_Main.Refresh();//画布内容刷新
        }

        /************** 子弹方块 ******************/
        private void DrawBlock_Red(Graphics ghs, int i, int j)
        {
            //下落一格，纵坐标y由行i来控制，y=格子高度*行数，例如：第四行y=3*29,3刚好是数组下标,x也一样由j来控制
            //其实就是求面积
            float xposition = j * cs.Block_Width - 1;
            float yposition = i * cs.Block_Height - 1;
            ghs.FillRectangle(Brushes.Red, xposition, yposition, 29, 29);//填充正方形小块
        }

        /************** 飞机方块 ******************/
        private void DrawBlock_Blue(Graphics ghs, int i, int j)
        {
            //下落一格，纵坐标y由行i来控制，y=格子高度*行数，例如：第四行y=3*29,3刚好是数组下标,x也一样由j来控制
            //其实就是求面积
            float xposition = j * cs.Block_Width - 1;
            float yposition = i * cs.Block_Height - 1;
            ghs.FillRectangle(Brushes.Blue, xposition, yposition, 29, 29);//填充正方形小块
        }

        /************** 天空方块 ******************/
        private void DrawBlock_Black(Graphics ghs, int i, int j)
        {
            //下落一格，纵坐标y由行i来控制，y=格子高度*行数，例如：第四行y=3*29,3刚好是数组下标,x也一样由j来控制
            //其实就是求面积
            float xposition = j * cs.Block_Width - 1;
            float yposition = i * cs.Block_Height - 1;
            ghs.FillRectangle(Brushes.Black, xposition, yposition, 29, 29);//填充正方形小块
        }

        /************** 渲染时钟事件 ******************/
        private void T_Render_Tick(object sender, EventArgs e)
        {
            Render_Screen();

            //判断是否可以就是游戏
            if (cs.Can_Game_Over())
            {
                cs.Game_Over();
            }

            lv();//检测等级

            this.lb_lv.Text = cs.lv.ToString();//显示等级
        }

        /************** 控制子弹时钟事件 ******************/
        private void T_Control_Bullet_Tick(object sender, EventArgs e)
        {
             cs.Move_Bullet();
             //把移动到顶部的子弹消除
            for(int i = 0; i < cs.row; i++)
            {
                for(int j=0; j < cs.column; j++)
                {
                   if (cs.Arr_Canvas[0,j]==1)
                   {
                        cs.Arr_Canvas[0, j] = 0;
                   }
                }
            }
            //移动完后判断能否消除方块并消除
            if (cs.Can_Destroy_Sky_Block())
            {
                cs.Destroy_Sky_Block();
                //加分数
                this.lb_score.Text = cs.Score.ToString();
            }
        }

        /************** 产生天空方块时钟事件 ******************/
        private void T_Creat_Sky_Tick(object sender, EventArgs e)
        {
            if (cs.Can_Move_Sky_Block())
            {
                cs.Move_Sky_Block();
            }

            if (cs.Can_Creat_Sky_Block(cs.Bool_Can_Creat_Sky_Block) && (!(cs.Can_Game_Over())))//确保不是结束游戏条件才产生
            {
                cs.Creat_Sky();
            }
        }

        /************** 产生飞机 ******************/
        private void Creat_Plane()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cs.Arr_Canvas[i + 18, j + 5] = air.Arr_Plane[i, j];//给19,20行赋值
                }
            }
        }


        /*********  按键监控 ***********/
        private void Form_Main_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData.ToString())
            {
                case "A":
                    if (cs.Can_Move_Left())
                    {
                        cs.Move_Left();
                    }
                    break;
                case "D":
                    if (cs.Can_Move_Right())
                    {
                        cs.Move_Right();
                    }
                    break;
                case "W":
                    if (cs.Can_Move_Up())
                    {
                        cs.Move_Up();
                    }
                    break;
                case "S":
                    if (cs.Can_Move_Down())
                    {
                        cs.Move_Down();
                    }
                    break;
                case "J":
                    if (cs.Can_Creat_Bullet())
                    {
                        System.Media.SystemSounds.Beep.Play();
                        cs.Creat_Bullet5();
                    }
                    break;
                case "K":
                    if (cs.Can_Creat_Bullet())
                    {
                        System.Media.SystemSounds.Beep.Play();
                        cs.Creat_Bullet6();
                    }
                    break;
                case "L":
                    if (cs.Can_Creat_Bullet())
                    {
                        System.Media.SystemSounds.Beep.Play();
                        cs.Creat_Bullet7();
                    }
                    break;
            }
        }
        /********* 背景音乐 ***********/
        public void Play_Bgm()
        {
            string bgmPath = @"D:\飞机背景太空.wav";
            SoundPlayer bgm = new SoundPlayer();
            bgm.SoundLocation = bgmPath;
            bgm.PlayLooping();
        }

        //开始事件
        private void btn_start_Click(object sender, EventArgs e)
        {
            cs.Bool_Can_Creat_Sky_Block = true;//产生天空
            Creat_Plane();//生成飞机

            cs.Score = 0;//分数清零

            //体术：加了按钮后，一定要让窗体的KeyPriview为True
            T_Render.Enabled = true;
            T_Control_Bullet.Enabled = true;
            T_Creat_Sky.Enabled = true;
        }

        //结束游戏事件
        private void btn_stop_Click(object sender, EventArgs e)
        {
            cs.Game_Over();
            cs.lv = 0;
        }


        /************** 等级设置 ******************/
        public void lv()
        {
            if (cs.Score == 100)
            {
                cs.lv = 2;
                T_Creat_Sky.Interval = 700;
            }
            if (cs.Score == 200)
            {
                cs.lv = 3;
                T_Creat_Sky.Interval = 500;
            }
            if (cs.Score == 400)
            {
                cs.lv = 3;
                T_Creat_Sky.Interval = 300;
            }
        }
    }
}
