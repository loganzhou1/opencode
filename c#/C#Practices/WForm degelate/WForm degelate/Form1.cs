using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WForm_degelate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //自带泛型委托

        //Action<>  无返回值
        //Func<>


        public List<string> Sumcount1(List<int> nums, Func<int, bool> addnum)
        {
            List<string> list = new List<string>();
            foreach (var item in nums)
            {
                if (addnum(item))
                    list.Add(item.ToString());
            }
            return list;
        }



        public List<string> Sumcount(List<int> nums,Addnum addnum)
        {
            List <string>  list = new  List<string>();
            foreach (var item in nums)
            {
                if (addnum(item))
                    list.Add(item.ToString());
            }
            return list;
        }
        /*
        语句Lambda
        (type var,...)=>{...}
        (var,..)=>{...}
        var=>{...}//一个参数
        ()=>{...}//空参数
        表达式Lambda
        没有{}，但只能有一条语句
        */
        public delegate bool Addnum(int num);///委托声明，必须有

        private void button1_Click(object sender, EventArgs e)
        {
            //Func
            Func<int ,bool> Funcadd= delegate (int n) { return n >= 5; };
            foreach (var item in Sumcount1(new List<int> { 1, 2, 2, 3, 9, 4, 6 }, Funcadd))
            {
                textBox1.AppendText(item);
            }
            textBox1.AppendText("\r\n");



            Addnum Adnum = delegate (int n) { return n <= 5; };   //委托定义
            foreach (var item in Sumcount(new List<int> { 1, 2, 2, 3, 9, 4, 6 }, Adnum))//使用
            {
                textBox1.AppendText(item);
            }
            textBox1.AppendText("\r\n");
            foreach (var item in Sumcount(new List<int> { 1, 2, 2, 3, 9, 4, 6 }, delegate (int n) { return n <= 5; })) //(type var,...)=>{...}
            {
                textBox1.AppendText(item );
            }
            textBox1.AppendText("\r\n");
            foreach (var item in Sumcount(new List<int> { 1, 2, 2, 3, 9, 4, 6 }, (int n)=> { return n <= 5; }))//(type var,...)=>{...}
            {
                textBox1.AppendText(item );
            }
            textBox1.AppendText("\r\n");
            foreach (var item in Sumcount(new List<int> { 1, 2, 2, 3, 9, 4, 6 }, (n) => { return n <= 5; }))//(var,..)=>{...}
            {
                textBox1.AppendText(item );
            }
            textBox1.AppendText("\r\n");
            foreach (var item in Sumcount(new List<int> { 1, 2, 2, 3, 9, 4, 6 }, n => { return n <= 5; }))//var=>{...}//一个参数
            {
                textBox1.AppendText(item );
            }
            textBox1.AppendText("\r\n");
            foreach (var item in Sumcount(new List<int> { 1, 2, 2, 3, 9, 4, 6 }, n => n >= 5 ))// 表达式Lambda，没有{ }，但只能有一条语句
            {
                textBox1.AppendText(item );
            }
            textBox1.AppendText("\r\n");

        }
    }
}
