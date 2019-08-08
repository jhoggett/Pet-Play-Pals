﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models.Account;

namespace WebApplication.Web.DAL
{
    public class ReservationSqlDAO : IReservationDAO
    {
        private readonly string connectionString;

        public ReservationSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int AddReservation(Reservation reservation)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //TODO: Finish this query
                    conn.Open();

                    string sql = $"Insert Into Reservations Values (@address, @startTime, @endTime, @petName); Select @@Identity ";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@address", reservation.Address);
                    cmd.Parameters.AddWithValue("@startTime", reservation.StartTime);
                    cmd.Parameters.AddWithValue("@endTime", reservation.EndTime);
                    cmd.Parameters.AddWithValue("@petName", reservation.PetName);

                    int Id = Convert.ToInt32(cmd.ExecuteScalar());

                    return Id;

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public IList<Reservation> GetAllReservationsForUser(int userId)
        {
            IList<Reservation> list = new List<Reservation>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"SELECT * FROM Reservations AS r JOIN Users_Reservations AS ur on r.id = ur.reservationId JOIN users as u on u.id = ur.userID WHERE u.id = @userId";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@userId", userId);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Reservation reservation = new Reservation();

                        reservation.ReservationId = Convert.ToInt32(rdr["id"]);
                        reservation.Address = Convert.ToString(rdr["address"]);
                        reservation.StartTime = Convert.ToDateTime(rdr["startTime"]);
                        reservation.EndTime = Convert.ToDateTime(rdr["endTime"]);
                        reservation.PetName = Convert.ToString(rdr["petName"]);


                        list.Add(reservation);

                    }

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return list;
        }

    }
}