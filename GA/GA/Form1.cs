using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GA
{
   
    public partial class Form1 : Form
    {
        int CountPut;//кол-во путей
       public int NachRaz, Nach,Kon;
        int[,] Puti = new int[11,11];
        int[,] TestPuti = new int[11, 11];
        public int dlinaputi(string s) {
            char s1, s2;
            int d=0,d1,d2;
            for (int i = 0; i < s.Length-1; i++) {
                s1 = s[i];
                s2 = s[i + 1];
                d1 = Convert.ToInt32(Convert.ToString(s1));
                d2 = Convert.ToInt32(Convert.ToString(s2));
                d = d + Puti[d1, d2];
            }
            return d;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CountPut = comboBox1.SelectedIndex+3;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            



            for (int i = 1; i <= CountPut; i++)
            {
                dataGridView1.Columns.Add("c" + Convert.ToString(i), Convert.ToString(i));
            }
            for (int i = 1; i <= CountPut; i++)
            {
                dataGridView1.Rows.Add();
            }
            for (int i = 1; i <= CountPut; i++)
            {
                dataGridView1.Rows[i - 1].Cells[i - 1].Value = "-------";
            }

            //test
            int k = 0;
            for (int i = 1; i < CountPut + 1; i++)
            {
                for (int j = 1; j < CountPut + 1; j++)
                {
                    TestPuti[i, j] = k;
                   // k++;
                    //TestPuti[i, j] = i + j;
                }
                k++;
            }
            //конец теста

            for (int i = 0; i < CountPut; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    dataGridView1[i, j].Value = TestPuti[i + 1, j + 1];
                }
            }


        }

        public string sub1(int a1,int a2){
            string s="";
            for(int i=1;i<=CountPut;i++)
            {
                if((i!=a1)&&(i!=a2)){ 
                s=s+Convert.ToInt32(i);
                }
            }

            return s;
        }

        public static string mutation(string s, int mut, Random random)
        {
              char [] ch = new char[s.Length];
            int a=s.Length;
            for (int i = 0; i < s.Length; i++) {
                ch[i] = s[i];
            }
            int m=random.Next(0, 100);
            
            for (int i = 1; i < (s.Length)/2; i++) {
                m = random.Next(0, 100);
                if (mut > m)
                {
                    char cha = ch[i];
                    ch[i] = ch[a - i-1];
                    ch[a - i-1]=cha;
                   // int m1=random.Next(1,s.Length);
                     //   if((m1!=ch[0])&&(m1!=ch[1])){
                       //     ch[i]=Convert.ToChar(m1);
                       // }
                }
            }
            s="";
            for (int i = 0; i < a; i++)
            {
                s = s + Convert.ToString(ch[i]);
            }
            return s;
            
        }

        public static string Shuffle(string list1, int n1, int k1, Random random)
        {
          //  Random random = new Random();
            int l=list1.Length;
            char [] list = new char[l];
            for (int i = 0; i < l; i++) {
                list[i] = list1[i];
            }
            int n = list1.Length;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                char value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            string s="";
            for (int i = 0; i < l; i++)
            {
                s = s + Convert.ToString( list[i]);
            }
            s = Convert.ToString(n1) + s + Convert.ToString(k1);
            return s;

        }
        public static string Proverka(string lev,string poln) {
           // int a = s.Length;
           // char[] ch = new char[poln.Length];
            ///int [] ch1 = new int[s.Length];
            string s = "";
            int k = 0;
            for (int i = 0; i < poln.Length; i++)
            {
                for (int j = 0; j < lev.Length; j++)
                {
                    if (poln[i] == lev[j]) {
                        k++;
                    }
                }
                if (k == 0) {
                    s += poln[i];
                }
                k = 0;
            }
            return s;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
       //     string ssssss = Proverka("123", "14235");

            for (int i = 1; i < CountPut+1; i++)
            {
                for (int j= 1; j < i; j++)
                {
                    if (dataGridView1[i - 1, j - 1].Value == null)
                    {
                        int a = 999999;
                        Puti[i, j] = a;
                        Puti[j, i] = Puti[i, j];
                        goto g6;
                    }
                    if (dataGridView1[i-1, j-1].Value.ToString() != "-------")
                    {
                        if (dataGridView1[i - 1, j - 1].Value.ToString() == "")
                        {
                            int a = 999999;
                            Puti[i, j] = a;
                            Puti[j, i] = Puti[i, j];
                        }
                        else
                        {
                            int a = Convert.ToInt32(dataGridView1[i - 1, j - 1].Value.ToString());
                            Puti[i, j] = a;
                            Puti[j, i] = Puti[i, j];
                        }
                    }
                    else {
                        Puti[i, j] = 0;
                    }
                g6:
                    int nothing = 0;
                }
            }
          //  string str = Shuffle("123456");
           // Chrom c = new Chrom("1234", dlinaputi("1234"));
            //string l1 = c.giveleft(), r1 = c.giveright();
            

            Nach = Convert.ToInt32(textBox4.Text);
            Kon = Convert.ToInt32( textBox5.Text);
            int RazmPop =Convert.ToInt32( textBox6.Text);

            string str, l1;
            Random rng = new Random();
            List<Chrom> C = new List<Chrom>();
            for (int i = 0; i < Convert.ToInt32(textBox6.Text); i++) {
                l1 = sub1(Nach, Kon);
                str = Shuffle(l1, Nach, Kon,rng);
                Chrom c1 = new Chrom(str, dlinaputi(str));
                C.Add(c1);
            }

            //while (true)
            //{
            //    string mmm = mutation("1234567", 0, rng);
            //    string mmm1 = mutation("1234567", 30, rng);
            //    string mmm2 = mutation("1234567", 60, rng);
            //}
            //удалим повторяющиеся
            int lc = C.Count;
            for (int i = 0; i < lc ; i++) {
                for (int j = i+1; j < lc ; j++)
                {
                    if (C[i].chromosoma == C[j].chromosoma)
                    {
                        C.RemoveAt(j);
                        lc -= 1;
                        j--;
                    }


                }

            }
            //int MinPut = 99999999;
            int iter = 0, iter1 = 0;
            int min = 999999;
            int IterOtboi = Convert.ToInt32(textBox3.Text);

            do
            {
                List<Chrom> Cd = new List<Chrom>();//здесь будем хранить детей
                int NumNeizm = 0;//здесь будем 

                int MutProc = Convert.ToInt32(textBox1.Text);

                //создадим детей
                int numdet = C.Count; //их количество

                for (int i = 0; i < numdet - 1; i = i + 2)
                {

                    string s1l, s1r, s2l, s2r, s1, s2;
                    s1l = C[i].giveleft();
                    s1r = C[i].giveright();
                    s2l = C[i + 1].giveleft();
                    s2r = C[i + 1].giveright();

                    s2 = C[i + 1].chromosoma;

                    string spot = Proverka(s1l, s2);

                    //s1 = s1l + s2r;
                    //s2 = s2l + s1r;
                    Chrom c1 = new Chrom(s2, dlinaputi(s2));
                  //  Chrom c2 = new Chrom(s2, dlinaputi(s2));

                    string sm1 = mutation(c1.chromosoma, MutProc, rng);
                 //   string sm2 = mutation(c2.chromosoma, MutProc, rng);

                    c1.chromosoma = sm1;
                    c1.dlinna = dlinaputi(sm1);
                   // c2.chromosoma = sm2;
                   // c2.dlinna = dlinaputi(sm2);

                    Cd.Add(c1);
                   // Cd.Add(c2);



                }

                //объединяем детей и родителей
                for (int i = 0; i < Cd.Count; i++)
                {
                    C.Add(Cd[i]);
                }

                Cd.Clear();

                //отсортируем пузырьком
                Chrom cb = new Chrom("1111", 1488);
                //int MinPut = 99999999;
                int razmer = C.Count;
                for (int i = 0; i < razmer - 1; i++)
                {
                    for (int j = 0; j < razmer - i - 1; j++)
                    {
                        if (C[j].dlinna > C[j + 1].dlinna)
                        {
                            cb = C[j];
                            C[j] = C[j + 1];
                            C[j + 1] = cb;
                        }
                    }

                }

                //удалим повторяющиеся
                lc = C.Count;
                for (int i = 0; i < lc; i++)
                {
                    for (int j = i + 1; j < lc; j++)
                    {
                        if (C[i].chromosoma == C[j].chromosoma)
                        {
                            C.RemoveAt(j);
                            lc -= 1;
                            j--;
                        }


                    }

                }

                //удалим примерно половину Оставим первоначальную популяцию
                if (C.Count > RazmPop)
                {
                    int ll = C.Count;
                    C.RemoveRange(RazmPop, ll - RazmPop);
                    //for (int i = RazmPop; i < ll; i++)
                    //{
                    //    C.RemoveAt(i);
                    //    ll--;
                    //}
                }
                iter1++;
                iter++;
                if (min > C[0].dlinna) {
                    min = C[0].dlinna;
                    iter1 = 0;
                }



            } while (iter1 < IterOtboi);

            textBox2.Text = Convert.ToString(iter);
            dataGridView2.Rows.Clear();
            min=C[0].dlinna;
            int ii=0;
            while (C[ii].dlinna == min) {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[ii].Cells[0].Value = C[ii].chromosoma;
                dataGridView2.Rows[ii].Cells[1].Value = C[ii].dlinna;
                ii++;
            }
        }
    }



    public class Chrom
    {
        public string chromosoma;
        public int dlinna;
        public Chrom(string s, int d)
        {
            this.chromosoma = s;
            this.dlinna = d;

        }
        public string giveleft()
        {
            int i = this.chromosoma.Length / 2;
            string sub = chromosoma.Substring(0, i);
            return sub;
        }
        public string giveright()
        {
            string sub = "";
            int i1 = this.chromosoma.Length;
            int i = this.chromosoma.Length / 2;
            if (i1 % 2 == 1)
            {
                sub = chromosoma.Substring(i, i + 1);
            }
            else
            {
                sub = chromosoma.Substring(i, i);
            }
            return sub;
        }
    }
}
