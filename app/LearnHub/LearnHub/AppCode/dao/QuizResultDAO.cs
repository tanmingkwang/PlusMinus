﻿using LearnHub.AppCode.entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LearnHub.AppCode.dao
{
    public class QuizResultDAO
    {
        public QuizResult getQuizResultByID(int quizResultID)
        {
            SqlConnection conn = new SqlConnection();
            QuizResult toReturn = null;
            try
            {
                conn = new SqlConnection();
                string connstr = ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();
                conn.ConnectionString = connstr;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select * from [QuizResult] where quizResultID=@quizResultID";
                comm.Parameters.AddWithValue("@quizResultID", quizResultID);
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    toReturn = new QuizResult();
                    UserDAO userDAO = new UserDAO();
                    QuizDAO quizDAO = new QuizDAO();
                    QuizResultHistoryDAO qrhDAO = new QuizResultHistoryDAO();
                    toReturn.setQuizResultID((int)dr["quizResultID"]);
                    toReturn.setUser(userDAO.getUserByID((string)dr["userID"]));
                    toReturn.setQuiz(quizDAO.getQuizByID((int)dr["quizID"]));
                    toReturn.setScore((int)dr["score"]);
                    toReturn.setGrade((string)dr["grade"]);
                    toReturn.setQuizResultHistory(qrhDAO.getQuizResultHistoryByID((int)dr["quizResultHistoryID"]));
                    toReturn.setDateSubmitted(dr.GetDateTime(6));
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return toReturn;
        }
        public int createQuizResult(QuizResult qr) // Insert.
        {
            SqlConnection conn = null;
            int toReturn = 0;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "Insert into [QuizResult] (userID, quizID, score, grade, quizResultHistoryID, dateSubmitted) OUTPUT INSERTED.quizResultID VALUES (@userID, @quizID, @score, @grade, @quizResultHistoryID, @dateSubmitted)";
                comm.Parameters.AddWithValue("@userID", qr.getUser().getUserID());
                comm.Parameters.AddWithValue("@quizID", qr.getQuiz().getQuizID());
                comm.Parameters.AddWithValue("@score", qr.getScore());
                comm.Parameters.AddWithValue("@grade", qr.getGrade());
                comm.Parameters.AddWithValue("@quizResultHistoryID", qr.getQuizResultHistory().getQuizResultHistoryID());
                comm.Parameters.AddWithValue("@dateSubmitted", qr.getDateSubmitted());
                toReturn = (Int32)comm.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return toReturn;
        }
    }
}