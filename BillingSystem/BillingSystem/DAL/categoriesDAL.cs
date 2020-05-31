﻿using BillingSystem.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillingSystem.DAL
{
    class categoriesDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Metoda Select

        public DataTable Select() {
            
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM tbl_categories";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();
                adapter.Fill(dt);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally {
                conn.Close();
            }
            return dt;
        }

        #endregion
        #region me Fut nje Category te re

        public bool Insert(categoriesBLL c) {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try {
                string sql = "INSERT INTO tbl_categories (title, description, added_date, added_by) " +
                    "VALUES (@title, @description, @added_date, @added_by)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@title", c.title);
                cmd.Parameters.AddWithValue("@description", c.description);
                cmd.Parameters.AddWithValue("@added_date", c.added_date);
                cmd.Parameters.AddWithValue("@added_by", c.added_by);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                isSuccess = rows > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }


            return isSuccess;

        }
        #endregion
        #region Metoda Update
        public bool Update(categoriesBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "UPDATE tbl_categories SET title=@title, description=@description, " +
                    "added_date=@added_date, added_by=@added_by WHERE id=@id";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@title", c.title);
                cmd.Parameters.AddWithValue("@description", c.description);
                cmd.Parameters.AddWithValue("@added_date", c.added_date);
                cmd.Parameters.AddWithValue("@added_by", c.added_by);
                cmd.Parameters.AddWithValue("@id", c.id);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                isSuccess = rows > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }


            return isSuccess;

        }
        #endregion
        #region Metoda Delete
        public bool Delete(categoriesBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "DELETE FROM tbl_categories WHERE id=@id";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@id", c.id);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                isSuccess = rows > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }


            return isSuccess;

        }
        #endregion
        #region Kerko User-in ne Database
        public DataTable Search(string keywords)
        {
            //Metod statike per me lidh me Databaze
            SqlConnection conn = new SqlConnection(myconnstrng);
            //Me mbajt te dhenat nga Databaza
            DataTable dt = new DataTable();
            try
            {
                //SQL Quesry per mi marr te gjitha te dhenat nga Databaza
                String sql = $"SELECT * FROM tbl_categories WHERE id LIKE '%{keywords}%' OR title LIKE '%{keywords}%' OR description LIKE '%{keywords}%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open(); // E qel lidhjen e Databazes me C#
                adapter.Fill(dt);// Mbush te dhena ne Tabelen e te edhenave

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();// E perfundon lidhjen me Databaze
            }
            return dt;
        }
        #endregion
    }
}
