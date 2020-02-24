using System;
using System.ComponentModel;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleAppD
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection dbConn = null;
            SqlDataReader dr = null;
            SqlCommand sqlCmd = null;
            SqlDataReader reader = null;
            int personNr;

            string op = "", vorname, nachname;

            
            dbConn = new SqlConnection(
                    "Data Source=192.168.95.186;Initial Catalog=ExD_01;User ID=ExD_01;Password=pExD_01");
            dbConn.Open();
            
            do
            {
                
                    Console.Write("Daten lesen (r), Daten schreiben (w), Daten löschen (d), Beenden (x): ");
                    op = Console.ReadLine();

                    switch (op)
                    {
                        case "r":
                            //run command
                            SqlCommand command = new SqlCommand("SELECT * FROM ExD_01.db_ddladmin.Person2", dbConn);
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} - {2}, {1}", reader["p_nr"], reader["vname"],
                                    reader["nname"]); // etc
                            }

                            break;
                        case "w":
                            Console.Write("Eingabe Nummer: ");
                            personNr = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Eingabe Vorname: ");
                            vorname = Console.ReadLine();
                            Console.Write("Eingabe Nachname: ");
                            nachname = Console.ReadLine();
                            sqlCmd = new SqlCommand(
                                "INSERT INTO ExD_01.db_ddladmin.Person2 (p_nr, vname, nname) VALUES(@p_nr, @vname, @nname);",
                                dbConn);
                            sqlCmd.Parameters.AddWithValue("@p_nr", personNr);
                            sqlCmd.Parameters.AddWithValue("@vname", vorname);
                            sqlCmd.Parameters.AddWithValue("@nname", nachname);
                            sqlCmd.ExecuteNonQuery();
                            break;

                        case "d":
                            Console.Write("Welche Person soll gelöscht werden (Nr.): ");
                            personNr = Convert.ToInt32(Console.ReadLine());
                            sqlCmd = new SqlCommand("DELETE FROM ExD_01.db_ddladmin.Person2 WHERE p_nr = @p_nr;",
                                dbConn);
                            sqlCmd.Parameters.AddWithValue("@p_nr", personNr);
                            sqlCmd.ExecuteNonQuery();
                            break;

                        case "x":
                            dbConn.Close();
                            break;

                        default:
                            Console.WriteLine("Operation '{0}' nicht definiert!", op);
                            break;
                    }
                
                
                
            } while (op != "x");
        }
    }
}