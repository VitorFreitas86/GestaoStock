namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MySql.Data.MySqlClient;
    using System.Data;
    using System.Configuration;



    public class SQLHelper
    {
        

        public void executenonquery(List<MySqlParameter> parameters, string SPName, string connString)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(SPName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (MySqlParameter param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public string executeScaler(List<MySqlParameter> parameters, string SPName, string connString)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(SPName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (MySqlParameter param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }
                        string result;
                        con.Open();
                        result=Convert.ToString(cmd.ExecuteScalar());
                        con.Close();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public T executeSP<T>(List<MySqlParameter> parameters, string SPName,string connString)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(SPName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 120;
                        foreach (MySqlParameter param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }

                        if (typeof(T) == typeof(DataSet))
                        {
                            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                            DataSet dset = new DataSet();
                            con.Open();
                            adapter.Fill(dset);
                            con.Close();
                            return (T)(object)dset;

                        }
                  
                        else
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            return default(T);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}
