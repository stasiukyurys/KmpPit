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
                       string Id, 
                       string WeightAuto, 
                       string Brutto,
                       string Netto
                       )
        {
            this.Data = Data;
            this.Time = Time;
            this.Id = Id;
            this.WeightAuto = WeightAuto;
            this.Brutto = Brutto;
            this.Netto = Netto;
        }
        public string Data { get; set; }
        public string Time { get; set; }
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
            string query = "SELECT Дата, Время, Н_карты, Вес_авто, Брутто, Нетто FROM VES ORDER BY Дата";

            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, myConnection);
            // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
            OleDbDataReader reader = command.ExecuteReader();
            // очищаем listBox1
            PitListBox.Items.Clear();
            // в цикле построчно читаем ответ от БД
            List<MyTable> result = new List<MyTable>(3);
            while (reader.Read())
            {
                // выводим данные столбцов текущей строки в listBox1
                result.Add(new MyTable(reader[0].ToString(),
                                       reader[1].ToString(),
                                       reader[2].ToString(),
                                       reader[3].ToString(),
                                       reader[4].ToString(),
                                       reader[5].ToString()
                           ));
            }
            // закрываем OleDbDataReader
            reader.Close();
            grid.ItemsSource = result;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            myConnection.Close();
            this.NavigationService.Navigate(null);
        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
