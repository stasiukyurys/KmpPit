using System.Data.OleDb;
using System.Windows;
using System.Windows.Controls;

namespace KmpPit
{
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
            while (reader.Read())
            {
                // выводим данные столбцов текущей строки в listBox1
                PitListBox.Items.Add(
                      reader[0].ToString() + "      " 
                    + reader[1].ToString() + "      " 
                    + reader[2].ToString() + "      "
                    + reader[3].ToString() + "      "
                    + reader[4].ToString() + "      "
                    + reader[5].ToString() + "      "
                                    );
            }
            // закрываем OleDbDataReader
            reader.Close();

        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            myConnection.Close();
            this.NavigationService.Navigate(null);
        }
    }
}
