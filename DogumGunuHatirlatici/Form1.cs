using System;
using System.IO;

namespace DogumGunuHatirlatici
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string dateFormat = "dd.MM.yyyy";
            string dateAyGun = "dd.MM";
            string AnlikTarih = DateTime.Now.ToString(dateFormat);
            string AnlikAyGun = DateTime.Now.ToString(dateAyGun);
            label4.Text = AnlikTarih;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String AdiSoyadi = "";
            String DogumGunuMesaji = "Say�n ";
            // CSV dosyas�n�n yolu ve ad�
            string csvFilePath = @"C:\Data.csv";
            string dateAyGun = "dd.MM";
            string AnlikAyGun = DateTime.Now.ToString(dateAyGun);
            // CSV dosyas�n� okumak i�in StreamReader olu�turma
            using (var reader = new StreamReader(csvFilePath))
            {
                // �lk sat�r� okuyun ve ba�l�klar� al�n
                string[] headers = reader.ReadLine().Split(';');

                // Her sat�r� okuyun ve verileri i�leyin
                while (!reader.EndOfStream)
                {
                    string[] rows = reader.ReadLine().Split(';');

                    for (int i = 0; i < headers.Length; i++)
                    {
                        if (i == 0)
                        {
                            listBox1.Items.Add(rows[i]); // Ad� Soyad�
                        }else if (i == 1)
                        {
                            listBox2.Items.Add(rows[i]);// Do�um Tarih
                            string dogumTarih = rows[i];
                            string[] dogumTarihiParcala = dogumTarih.Split('.');
                            string DogumTarihiGun = dogumTarihiParcala[0];
                            string DogumTarihiAy = dogumTarihiParcala[1];
                            if (DogumTarihiGun + "." + DogumTarihiAy == AnlikAyGun)
                            {
                                listBox4.Items.Add(rows[2]);// Do�um G�n� Olan Ki�ilerin �smi
                                listBox5.Items.Add("Say�n "+rows[0]+" Do�um G�n�n�z� En ��ten Dileklerimle Kutlar �yi �al��malar Dilerim");// Do�um G�n� Olan Ki�ilerin �smi

                            }



                        }
                        else if(i == 2)
                        {
                            listBox3.Items.Add(rows[i]);// Email

                        }
                        //Console.WriteLine("{0}: {1}", headers[i], rows[i]);
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}