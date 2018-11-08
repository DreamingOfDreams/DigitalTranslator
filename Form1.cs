using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalTranslator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] zero = new string[20]
            {"","ONE","TWO","THREE","FOUR","FIVE","SIX","SEVEN","EIGHT","NINE",
                "TEN","ELEVEN","TWELVE","THIRTEEN","FOURTEEN","FIFTEEN","SIXTEEN","SEVENTEEN","EIGHTEEN","NINTEEN" };
        string[] ten = new string[13] { "","TEN","TWENTY","THIRTY","FORTY",
                "FIFTY","SIXTY","SEVENTY","EIGHTY","NINETY","HUNDRED","THOUSAND","MILLION"};
       
        private void Form1_Load(object sender, EventArgs e)
        {
                        
        }
        public string Tran(int n)
        {
            if(n>=0 && n<20)    //0-20
            {
               
                return  zero[n];
            }
            else if(n>=20 && n<100 && n%10==0)  //20-100 整10的
            {
               
                return  ten[n / 10];
            }
            else if(n>=20 && n<100)  //10-100 不整10的
            {
                
                return  ten[n / 10] + " " + zero[n % 10];
            }
            else if(n>=100 && n<1000 && n%100==0)   //100到1000 整百
            {
                return zero[n / 100] + " " + ten[10];
            }
            else if(n>=100 && n<1000)   //100到1000 不整百的
            {
                string s1=Tran(n / 100);
                string s3 = Tran(n % 100);
                string s4 = s1+" " + ten[10] + " AND " + s3;
                return s4;
            }
            else if(n>=1000 && n<10000 && n%1000==0)    //1千-1万 整千
            {
                return zero[n / 1000] + " " + ten[11];
            }
            else if(n >= 10000 && n <100000 && n % 10000 == 0)  //1万-10万 整万
            {
                return ten[n / 10000] + " " + ten[11];
            }
            else if (n >= 100000 && n < 1000000 && n % 100000 == 0)  //10万-100万 整10万
            {
                return zero[n / 100000] +" "+ten[10]+ " " + ten[11];
            }
            else if(n>=1000 && n< 1000000) //1千-100万 不整
            {
                string s4=null;
                string s1 = Tran(n / 1000);

                if (n % 1000 < 100 && n / 1000 > 10 && n % 1000 == 0)
                {
                    string s3 = Tran(n / 1000);
                    s4 = s3 + " "+ten[11];
                }
                else if ( n % 1000 < 100)
                {
                    string s3 = Tran(n % 1000);
                    s4 = s1 + " " + ten[11] + " AND " + s3;
                }
                else if (n % 1000 >= 100 && n % 1000 < 1000 && n % 100 == 0)
                {
                    string s3 = zero[n % 1000 / 100];
                    s4 = s1 + " " + ten[11] + " AND " + s3 + " " + ten[10];
                }
                else if (n % 1000 >= 100 && n % 1000 < 1000 && n % 1000 == 0)
                {
                    string s3 = zero[n % 1000 / 100];
                    s4 = s1 + " " + ten[11] + " AND " + s3 + " " + ten[10];
                }
                else if (n % 1000 >= 100 && n % 1000 < 1000 && n % 10000 == 0)
                {
                    string s3 = zero[n % 1000 / 100];
                    s4 = s1 + " " + ten[11] + " AND " + s3 + " " + ten[10];
                }
                
                else if (n % 1000 >= 100)
                {
                    string s3 = zero[n % 1000 / 100];
                    s4 = s1 + " " + ten[11] + " " + s3 + " " + ten[10] + " AND " + Tran(n % 1000 % 100);
                }              
                return s4;
            }
            else if (n >= 1000000 && n < 1000000000 && n % 1000000 == 0)  //100万-10亿 整百万
            {
                return  Tran(n / 1000000)+" "+ten[12];
            }
            else if (n >= 1000000 && n < 1000000000)
            {
                string s1 = Tran(n / 1000000);
                string s4 = null;

                string s3 = Tran(n % 1000000);
                s4 = s1 + " " + ten[12] + " " + s3;
                return s4;
            }
            else
            {
                return "0";
            }
        }

        public void Result()
        {
            string s1 = textBox1.Text;
            try
            {
                Regex reg = new Regex(@"(^[0-9]{1,9})+(\.[0-9]{1,5})?$"); 
                if(reg.Match(s1).Success==true)
                {
                    if(s1.Contains("."))
                    {
                        string s2=null;
                        string[] sArray = s1.Split('.');
                        int innum = int.Parse(sArray[0]);
                        string s4 = Tran(innum);
                        char[] chnum = sArray[1].ToCharArray();
                        string[] nuArray = new string[chnum.Length];
                        StringBuilder strbud = new StringBuilder();
                        for (int i = 0; i < chnum.Length; i++)
                        {
                            switch (chnum[i])
                            {
                                case '0':
                                    nuArray[i] = " ZERO";
                                    break;
                                case '1':
                                    nuArray[i] = " " + zero[1];
                                    break;
                                case '2':
                                    nuArray[i] = " " + zero[2];
                                    break;
                                case '3':
                                    nuArray[i] = " " + zero[3];
                                    break;
                                case '4':
                                    nuArray[i] = " " + zero[4];
                                    break;
                                case '5':
                                    nuArray[i] = " " + zero[5];
                                    break;
                                case '6':
                                    nuArray[i] = " " + zero[6];
                                    break;
                                case '7':
                                    nuArray[i] = " " + zero[7];
                                    break;
                                case '8':
                                    nuArray[i] = " " + zero[8];
                                    break;
                                case '9':
                                    nuArray[i] = " "+zero[9];
                                    break;
                            }
                            s2 = strbud.Append(nuArray[i]).ToString();
                        }
                        
                        textBox2.Text = s4+" POINT "+s2;
                    }
                    else
                    {
                        int num = int.Parse(textBox1.Text);
                        textBox2.Text = Tran(num);
                    }         
                }
                else
                {
                    MessageBox.Show(this, "输入错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show(this, "输入错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            Result();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)13)
            {
                Result();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cp = textBox2.Text;
            Clipboard.SetDataObject(cp);
        }
    }

}
