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
            int personNr = 0;

            string op = "", vorname, nachname;

            try
            {
                dbConn = new SqlConnection("Data Source=fbit-mssql.oszimt.local;Initial Catalog=FAC91_11;User ID=FAC91_11;Password=pFAC91_11");
                dbConn.Open();
                Console.WriteLine("Database connection successful.");
                do
                {
                    try
                    {
                        Console.Write("Daten lesen (r), Daten schreiben (w), Daten löschen (d), Beenden (x): ");
                        op = Console.ReadLine();

                        switch (op)
                        {
                            case "r":
                                //run command
                                SqlCommand command = new SqlCommand("SELECT * FROM versandgfhgdjghandel.T_Person",
                                    dbConn);
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
                                    "INSERT INTO versandhandel.T_Person (p_nr, vname, nname) VALUES(@p_nr, @vname, @nname);",
                                    dbConn);
                                sqlCmd.Parameters.AddWithValue("@p_nr", personNr);
                                sqlCmd.Parameters.AddWithValue("@vname", vorname);
                                sqlCmd.Parameters.AddWithValue("@nname", nachname);
                                sqlCmd.ExecuteNonQuery();
                                break;

                            case "d":
                                Console.Write("Welche Person soll gelöscht werden (Nr.): ");
                                personNr = Convert.ToInt32(Console.ReadLine());
                                sqlCmd = new SqlCommand("DELETE FROM versandhandel.T_Person WHERE p_nr = @p_nr;",
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
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("An SQL error occured:");
                        Console.WriteLine(e.Message);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("The number you entered was invalid. Please try again.");
                        Console.WriteLine(e.Message);
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine("The number you entered was too big. Please try again.");
                        Console.WriteLine(e.Message);
                    }
                } while (op != "x");
            }
            catch (SqlException e)
            {
                Console.WriteLine("An error occured:");
                Console.WriteLine(e.Message);
                dbConn.Close();
            }
        }
    }
}