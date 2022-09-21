using System;
using System.Data.SqlClient;

namespace DTSEXAM_PERKANTORAN
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            string connectionString = "Data Source=DESKTOP-ITL7FSV;Initial Catalog=ExamPerkantoran;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            try
            {
                Console.WriteLine("Successfully Connected");

                string answer;
                do
                {
                    Console.WriteLine("Select from the options\n1.Create\n2.Retrieve\n3.Update\n4.Delete");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            //CREATE
                            Console.WriteLine("Masukkan Id Jabatan");
                            string IdJabatan = Console.ReadLine();

                            Console.WriteLine("Masukkan Nama Jabatan");
                            string NamaJabatan = Console.ReadLine();

                            Console.WriteLine("Masukkan Gaji");
                            var GajiPokok = Console.ReadLine();

                            string insertQuery = "INSERT INTO Jabatan (IdJabatan,  NamaJabatan, GajiPokok) VALUES(" + IdJabatan + ",'" + NamaJabatan + "'," + GajiPokok + ")";

                            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("Data stored successfully");
                            break;

                        case 2:
                            //RETRIEVE
                            string displayQuery = "select * from Jabatan";
                            SqlCommand DisplayCommand = new SqlCommand(displayQuery, sqlConnection);
                            SqlDataReader dataReader = DisplayCommand.ExecuteReader();
                            while (dataReader.Read())
                            {
                                Console.WriteLine("Id Jabatan:" + dataReader.GetValue(0).ToString());
                                Console.WriteLine("Nama Jabatan:" + dataReader.GetValue(1).ToString());
                                Console.WriteLine("Gaji Pokok:" + dataReader.GetValue(2).ToString());
                            }
                            dataReader.Close();

                            break;

                        case 3:
                            //UPDATE
                            String u_NamaJabatan;
                            string u_GajiPokok;
                            Console.WriteLine("Pilih Nama Jabatan Yang Ingin Diubah");
                            u_NamaJabatan = Console.ReadLine();
                            Console.WriteLine("Pilih Jumlah Gaji Yang Ingin Diubah");
                            u_GajiPokok = Console.ReadLine();
                            string updateQuery = "UPDATE JABATAN SET GajiPokok = " + u_GajiPokok + " WHERE NamaJabatan = '" + u_NamaJabatan + "'";
                            SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
                            updateCommand.ExecuteNonQuery();
                            Console.WriteLine("Data Updated Successfully");
                            break;

                        case 4:
                            //DELETE
                            string d_NamaJabatan;
                            Console.WriteLine("Pilih Nama Jabatan Yang Ingin Dihapus");
                            d_NamaJabatan = Console.ReadLine();
                            string deleteQuery = "DELETE FROM JABATAN WHERE NamaJabatan = '" + d_NamaJabatan + "'";
                            SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
                            deleteCommand.ExecuteNonQuery();
                            Console.WriteLine("Deleted Successfully");
                            break;


                        default:
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                    Console.WriteLine("Apakah Ingin Melanjutkan? Y/N ");
                    answer = Console.ReadLine();

                } while (answer != "N");

                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally 
            {
                sqlConnection.Close();
            }
        }
    }
}
