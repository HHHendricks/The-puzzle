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
using MySql.Data.MySqlClient;

namespace 大作业1
{
    public partial class Form2 : Form
    {
        public bool closeflag = false;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username, password;
            username = textBox1.Text;
            password = textBox2.Text;

            String connetStr = "server=localhost;port=3306;user=root;password=123456; database=login;";
            MySqlConnection conn = new MySqlConnection(connetStr);
            conn.Open();

            String sql = "select user,pass from user where user='" + username + "'and pass='" + password + "'";//SQL语句实现表数据的读取
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader sqlDataReader = cmd.ExecuteReader();
            if (sqlDataReader.HasRows)  //如果能查到，说明该用户密码存在
            {
                //MessageBox.Show("登陆成功");
                using (StreamWriter sw = new StreamWriter("record.txt"))
                {
                    sw.WriteLine(username.ToString());
                }

                closeflag = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("账号或密码错误或未注册");
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String username, password;
            username = textBox1.Text;
            password = textBox2.Text;

            String connetStr = "server=localhost;port=3306;user=root;password=123456; database=login;";
            MySqlConnection conn = new MySqlConnection(connetStr);
            conn.Open();

            String sql = "INSERT INTO user(user,pass) VALUES('" + username + "','" + password + "')"; // 没有判断重复插入
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("注册成功");
            conn.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
