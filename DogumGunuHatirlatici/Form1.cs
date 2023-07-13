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
            String DogumGunuMesaji = "Sayýn ";
            // CSV dosyasýnýn yolu ve adý
            string csvFilePath = @"C:\Data.csv";
            string dateAyGun = "dd.MM";
            string AnlikAyGun = DateTime.Now.ToString(dateAyGun);
            // CSV dosyasýný okumak için StreamReader oluþturma
            using (var reader = new StreamReader(csvFilePath))
            {
                // Ýlk satýrý okuyun ve baþlýklarý alýn
                string[] headers = reader.ReadLine().Split(';');

                // Her satýrý okuyun ve verileri iþleyin
                while (!reader.EndOfStream)
                {
                    string[] rows = reader.ReadLine().Split(';');

                    for (int i = 0; i < headers.Length; i++)
                    {
                        if (i == 0)
                        {
                            listBox1.Items.Add(rows[i]); // Adý Soyadý
                        }else if (i == 1)
                        {
                            listBox2.Items.Add(rows[i]);// Doðum Tarih
                            string dogumTarih = rows[i];
                            string[] dogumTarihiParcala = dogumTarih.Split('.');
                            string DogumTarihiGun = dogumTarihiParcala[0];
                            string DogumTarihiAy = dogumTarihiParcala[1];
                            if (DogumTarihiGun + "." + DogumTarihiAy == AnlikAyGun)
                            {
                                listBox4.Items.Add(rows[2]);// Doðum Günü Olan Kiþilerin Ýsmi
                                listBox5.Items.Add("Sayýn "+rows[0]+" Doðum Gününüzü En Ýçten Dileklerimle Kutlar Ýyi Çalýþmalar Dilerim");// Doðum Günü Olan Kiþilerin Ýsmi

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