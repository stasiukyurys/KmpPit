using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Controls;

namespace KmpPit
{
    class MyTable
    {
        public MyTable(string Data, 
                       string Time,
                       string Avto,
                       string Id, 
                       string WeightAuto, 
                       string Brutto,
                       string Netto
                       )
        {
            this.Data = Data;
            this.Time = Time;
            this.Avto = Avto;
            this.Id = Id;
            this.WeightAuto = WeightAuto;
            this.Brutto = Brutto;
            this.Netto = Netto;
        }
        public string Data { get; set; }
        public string Time { get; set; }
        public string Avto { get; set; }
        public string Id { get; set; }
        public string WeightAuto { get; set; }
        public string Brutto { get; set; }
        public string Netto { get; set; }

    }
    public partial class PagePit : Page
    {
        // вариант 1
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\BDp.mdb;";
        // вариант 2
        //public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Workers.mdb;";
        private OleDbConnection myConnection;

        public PagePit()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            // текст запроса
            string query = "SELECT Дата, Время, Авто, Н_карты, Вес_авто, Брутто, Нетто FROM VES ORDER BY Дата";

            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, myConnection);
            // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
            OleDbDataReader reader = command.ExecuteReader();
            // в цикле построчно читаем ответ от БД
            List<MyTable> result = new List<MyTable>(3);
            double Tonne = 0;
            int Count = 0;
            while (reader.Read())
            {
                // выводим данные столбцов текущей строки в listBox1
                result.Add(new MyTable(reader[0].ToString().Remove(10, reader[0].ToString().Length-10),
                                       reader[1].ToString().Remove(0, 11),
                                       reader[2].ToString(),
                                       reader[3].ToString(),
                                       reader[4].ToString(),
                                       reader[5].ToString(),
                                       reader[6].ToString()
                           ));
                Tonne = Tonne + Convert.ToSingle(reader[6]);
                Count++;
            }
            // закрываем OleDbDataReader
            reader.Close();
            grid.ItemsSource = result;
            CountRoute.Content = Count.ToString();
            Tonne = Math.Round(Tonne, 2);
            TonneSands.Content = Tonne.ToString();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            myConnection.Close();
            this.NavigationService.Navigate(null);
        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void filtr_Click(object sender, RoutedEventArgs e)
        {


        }

    }
}
