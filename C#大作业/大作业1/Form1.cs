using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 大作业1.Properties;

namespace 大作业1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            initGame();
        }

        public void initGame()  //初始化图片，并随机选择后台图片
        {
            if (!Directory.Exists(Application.StartupPath.ToString() + "\\Picture"))
            {
                Directory.CreateDirectory(Application.StartupPath.ToString() + "\\Picture");
                Properties.Resources._0.Save(Application.StartupPath.ToString() + "\\Picture\\0.jpg");
                Properties.Resources._1.Save(Application.StartupPath.ToString() + "\\Picture\\1.jpg");
                Properties.Resources._2.Save(Application.StartupPath.ToString() + "\\Picture\\2.jpg");
                Properties.Resources._3.Save(Application.StartupPath.ToString() + "\\Picture\\3.jpg");
                Properties.Resources._4.Save(Application.StartupPath.ToString() + "\\Picture\\4.jpg");
                Properties.Resources._5.Save(Application.StartupPath.ToString() + "\\Picture\\5.jpg");
            }
            Random r = new Random();
            int i = r.Next(6);
            originalpicpath = Application.StartupPath.ToString() + "\\Picture\\" + i.ToString() + ".jpg";
            Flow(originalpicpath, true);
        }

        private int Num = 0;            //已走步数
        private int second = 0;     //已用时间
        private PictureBox[] pictureList = null;       //已有图片列表
        private SortedDictionary<string, Bitmap> pictureLocatin = new SortedDictionary<string, Bitmap>();//图片位置字典
        private Point[] pointList = null;      //图片第一个像素点的坐标列表
        private SortedDictionary<string, PictureBox> pictureBoxLocation = new SortedDictionary<string, PictureBox>();//图片控制字典
        private PictureBox currentPicture = null;      //鼠标选中要移动的图片
        private PictureBox havetomove = null;          //需要交换位置的图片
        private Point oldLocation = Point.Empty;      //鼠标拖动的图片原来的位置
        private Point newLocation = Point.Empty;      //拖动之后的新位置
        private Point mouseDownPoint = Point.Empty;     //鼠标按下时的坐标
        private Rectangle rect = Rectangle.Empty;       //显示拖动效果的矩形？？？？？
        private int SideLength { get { return 600 / this.ImgNumbers; } } //图形切割后的边长
        private string MoveHashCode = null;

        private bool isDrag = false;    //鼠标是否拖拽
        public string originalpicpath;  //图片位置
        private int ImgNumbers //难度属性
        {
            get
            {
                if ((int)this.numericUpDown1.Value == 0)        //难度要非负
                {
                    MessageBox.Show("无效的难度", "错误", MessageBoxButtons.OK);
                    MessageBox.Show("直接从最简单的难度开始!", "提示", MessageBoxButtons.OK);
                    numericUpDown1.Value = 1;
                }
                return (int)this.numericUpDown1.Value + 1;
            }
        }

        private void initRandomPictureBox() //初始化图片阵列的矩阵,X坐标是列，Y坐标是行
        {
            pnl_picture.Controls.Clear();
            pictureList = new PictureBox[ImgNumbers * ImgNumbers];
            pointList = new Point[ImgNumbers * ImgNumbers];
            for (int i = 0; i < this.ImgNumbers; i++)
            {
                for (int j = 0; j < this.ImgNumbers; j++)
                {
                    PictureBox pic = new PictureBox();
                    pic.Name = "pictureBox" + (j + i * ImgNumbers + 1).ToString();
                    pic.Location = new Point(j * SideLength, i * SideLength);
                    pic.Size = new Size(SideLength, SideLength);
                    pic.Visible = true;
                    pic.BorderStyle = BorderStyle.FixedSingle;
                    pic.MouseDown += new MouseEventHandler(pictureBox_MouseDown);
                    pic.MouseMove += new MouseEventHandler(pictureBox_MouseMove);
                    pic.MouseUp += new MouseEventHandler(pictureBox_MouseUp);
                    pnl_picture.Controls.Add(pic);
                    pictureList[j + i * ImgNumbers] = pic;
                    //图片切割后按从左到右，从上到下顺序放入一维数组
                    pointList[j + i * ImgNumbers] = new Point(j * SideLength, i * SideLength);      //存储每个图片左上角第一个像素点的坐标
                }
            }
        }

        //切割图片，使切割后的块数与矩阵同样大小，并保存在CutPicture.BitMapList中，然后再将图片加载到图片框矩阵中
        public void Flow(string path, bool disorder)
        {
            initRandomPictureBox();
            Image bm = CutPicture.Resize(path, 600, 600);       //获取原图压缩之后的图片
            Image end = CutPicture.Resize(Application.StartupPath.ToString() + "\\Picture\\" + "End.jpg", 600, 600);
            Image ori = CutPicture.Resize(path, 150, 150);
            original_pic.Image = ori;
            CutPicture.BitmapList = new List<Bitmap>();
            int i = 0, j = 0, n = 0;

            for (i = 0; i < 600; i += SideLength)           //切割图片，并将图片的像素阵列储存，但并未打乱顺序
                for (j = 0; j < 600; j += SideLength)
                {
                    Bitmap temp = CutPicture.Cut(bm, j, i, SideLength, SideLength);
                    CutPicture.BitmapList.Add(temp);
                    n++;
                }
            //最后一个格子为空白，单独拉出来处理
            Bitmap t = CutPicture.Cut(end, i - SideLength, j - SideLength, SideLength, SideLength);
            CutPicture.BitmapList[n - 1] = t;
            MoveHashCode = pictureList[ImgNumbers * ImgNumbers - 1].GetHashCode().ToString();

            ImportBitMap(disorder);     //开始打乱顺序
            Num = 0;
            label5.Text = Num.ToString();
        }

        public void ImportBitMap(bool disorder)         //disorder=1表示图片未打乱顺序
        {
            try
            {
                int i = 0;
                foreach (PictureBox item in pictureList)
                {
                    Bitmap temp = CutPicture.BitmapList[i];     //将切割后的图片放到窗体中指定的显示位置
                    item.Image = temp;
                    i++;
                }
                if (disorder)
                    ResetPictureLocation();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        //重新设置图片位置
        public void ResetPictureLocation()
        {
            Point[] temp = DisOrderLocation();
            int i = 0;
            foreach (PictureBox item in pictureList)
            {
                item.Location = temp[i];
                i++;
            }
        }

        //打乱位置列表
        public Point[] DisOrderLocation()
        {
            Point[] tempArray = (Point[])pointList.Clone();
            for (int i = tempArray.Length - 1; i > 0; i--)
            {
                Random rand = new Random();
                int p = rand.Next(i);
                Point temp = tempArray[p];
                tempArray[p] = tempArray[i];
                tempArray[i] = temp;
            }
            return tempArray;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            //oldLocation = new Point(e.X, e.Y);      //获取鼠标点击处的坐标
            currentPicture = GetPictureBoxByHashCode(sender.GetHashCode().ToString());//根据点击位置图片的哈希码，在数组中进行比对。
            MoseDown(currentPicture, sender, e);
        }

        public PictureBox GetPictureBoxByHashCode(string hascode)       //获取鼠标点击位置的图片
        {
            PictureBox pic = null;
            foreach (PictureBox item in pictureList)
            {
                if (hascode == item.GetHashCode().ToString())
                {
                    pic = item;
                }
                if (MoveHashCode == item.GetHashCode().ToString())
                    havetomove = item;
            }
            return pic;
        }

        public void MoseDown(PictureBox pic, object sender, MouseEventArgs e)      //鼠标左键点击，获取坐标
        {
            if (e.Button == MouseButtons.Left)
            {
                oldLocation = e.Location;
                rect = pic.Bounds;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)  //鼠标拖动图片
        {
            if (e.Button == MouseButtons.Left)      //如果曾经按下鼠标左键，即可拖动图片
            {
                isDrag = true;
                rect.Location = getPointToForm(new Point(e.Location.X - oldLocation.X, e.Location.Y - oldLocation.Y));
                this.Refresh();
            }
        }

        private Point getPointToForm(Point p)
        {
            return this.PointToClient(pnl_picture.PointToScreen(p));//改动
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)        //释放鼠标左键时的事件
        {
            oldLocation = new Point(currentPicture.Location.X, currentPicture.Location.Y);
            int x = oldLocation.X + e.X, y = oldLocation.Y + e.Y;       //这里e.X和e.Y表示鼠标左键松开时相对按下时所在图片的坐标位置
            if (x > 600 || y > 600 || x < 0 || y < 0)                  //相加之后得到的就是鼠标松开时的绝对坐标
                return;
            if (x >= havetomove.Location.X && y >= havetomove.Location.Y && x < havetomove.Location.X + SideLength && y < havetomove.Location.Y + SideLength)
            {
                move(oldLocation.X, oldLocation.Y, sender, e);
            }
            label5.Text = Num.ToString();

            if (Judge())
            {
                MessageBox.Show("恭喜拼图成功！！！", "恭喜");
                initGame();
            }
        }

        public void move(int x,int y,object sender,MouseEventArgs e)    //判断要移动的图片和空白格是否相邻
        {
            if (x+SideLength==havetomove.Location.X&&y==havetomove.Location.Y)
            {
                exchange(sender, e);
                Num++;          //步数加1
            }
            else if (x - SideLength == havetomove.Location.X && y == havetomove.Location.Y)
            {
                exchange(sender, e);
                Num++;          //步数加1
            }
            else if (x == havetomove.Location.X && y + SideLength == havetomove.Location.Y)
            {
                exchange(sender, e);
                Num++;          //步数加1
            }
            else if (x == havetomove.Location.X && y - SideLength == havetomove.Location.Y)
            {
                exchange(sender, e);
                Num++;          //步数加1
            }
        }

        public void exchange(object sender,MouseEventArgs e)        //图片交换位置
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isDrag)
                {
                    newLocation = new Point(havetomove.Location.X,havetomove.Location.Y);
                    havetomove.Location = oldLocation;     //原来鼠标松开时所在的图片位置切换到鼠标点击时所在的图片交换位置
                    isDrag = false;
                    currentPicture.Location = newLocation;
                    this.Refresh();
                }
                reset();
            }
        }

        public void reset()
        {
            rect = Rectangle.Empty;
            isDrag = false;
        }

        public bool Judge()     //判断是否胜利
        {
            bool flag = true;
            for(int i = 0; i < ImgNumbers * ImgNumbers - 1; i++)
            {
                if (pointList[i] != pictureList[i].Location)
                    flag = false;
            }
            return flag;
        }

        private void btn_import_Click(object sender, EventArgs e)       //尝试玩新图
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)       //表示按下确定
            {
                originalpicpath = file.FileName;
                CutPicture.path = file.FileName;
                Flow(originalpicpath, true);
            }
        }

        private void btn_change_Click(object sender, EventArgs e)       //切换图片
        {
            Random r = new Random();
            int i = r.Next(6);
            originalpicpath = Application.StartupPath.ToString() + "\\Picture\\" + i.ToString() + ".jpg";
            Flow(originalpicpath, true);
        }

        private void btn_reset_Click(object sender, EventArgs e)        //重玩此图
        {
            Flow(originalpicpath, true);
        }

        private void btn_challenge_Click(object sender, EventArgs e)        //挑战模式
        {
            DialogResult ans = MessageBox.Show("请选择难度", "提示", MessageBoxButtons.OKCancel);
            if (ans == DialogResult.OK)     //按下确定键之后
            {
                Select_level pp = new Select_level();
                pp.ShowDialog();
                if (Select_level.level != 0)        //难度不为0
                {
                    numericUpDown1.Value = Select_level.level;
                    Flow(originalpicpath, true);
                    btn_endchallenge.Visible = true;
                    second = 0;
                    label2.Visible = true;
                    label4.Visible = true;
                    label6.Visible = true;
                    timer1.Start();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)        //计时器函数：每秒调用一次
        {
            second++;
            label6.Text = second.ToString();
            if (Judge())   // 挑战成功
            {
                timer1.Stop();
                label2.Visible = false;
                label4.Visible = false;
                label6.Visible = false;
                btn_endchallenge.Visible = false;

                using (StreamReader sr = new StreamReader("record.txt"))
                {
                    String username = "";
                    while ((username = sr.ReadLine()) != null)
                    {
                        int num_record = 0;

                        //MessageBox.Show(str_record);
                        String connetStr = "server=localhost;port=3306;user=root;password=123456; database=login;";
                        MySqlConnection conn = new MySqlConnection(connetStr);
                        conn.Open();

                        String sql = "select * from user where user='" + username + "'"; // 没有判断重复插入
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        MySqlDataReader sqlDataReader = cmd.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            //MessageBox.Show(sqlDataReader[0].ToString() + " " + sqlDataReader[1].ToString() + " " + sqlDataReader[2].ToString());
                            num_record = int.Parse(sqlDataReader[3].ToString());
                        }
                        conn.Close();

                        //int num_record = int.Parse(str_record);
                        if(second <= num_record)
                        {
                            MessageBox.Show("挑战成功！", "恭喜你");

                            connetStr = "server=localhost;port=3306;user=root;password=123456; database=login;";
                            conn = new MySqlConnection(connetStr);
                            conn.Open();

                            sql = "UPDATE user SET score=" + label5.Text + " where user=" + "'" + username + "'"; // 没有判断重复插入
                            cmd = new MySqlCommand(sql, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                }

                second = 0;
            }
            else    //挑战失败
                if (second == 30)
            {
                timer1.Stop();
                MessageBox.Show("挑战超时！", "可惜", MessageBoxButtons.OK);
                DialogResult ans = MessageBox.Show("是否再次挑战？", "提示", MessageBoxButtons.OKCancel);
                if(ans==DialogResult.OK)       //确定重新挑战
                {
                    second = 0;
                    label6.Text = second.ToString();
                    initGame();
                    timer1.Start();
                }
                else
                {
                    timer1.Stop();
                    label2.Visible = false;
                    label4.Visible = false;
                    label6.Visible = false;
                    btn_endchallenge.Visible = false;
                    second = 0;
                    initGame();
                }
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pnl_picture_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_endchallenge_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            label2.Visible = false;
            label4.Visible = false;
            label6.Visible = false;
            btn_endchallenge.Visible = false;
            second = 0;
            initGame();
        }

        private void original_pic_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
