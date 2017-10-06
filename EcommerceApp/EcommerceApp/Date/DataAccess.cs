﻿using EcommerceApp.Interfaces;
using EcommerceApp.Models;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace EcommerceApp.Date
{
    public class DataAccess : IDisposable
    {
        private SQLiteConnection connection;
        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();
            connection = new SQLiteConnection(config.Platform,
            System.IO.Path.Combine(config.DirectoryDB, "Ecommerce.db3"));
            connection.CreateTable<Category>();
            connection.CreateTable<City>();
            connection.CreateTable<Company>();
            connection.CreateTable<CompanyCustomer>();
            connection.CreateTable<Customer>();
            connection.CreateTable<Department>();
            connection.CreateTable<Inventory>();
            connection.CreateTable<Order>();
            connection.CreateTable<OrderDetail>();
            connection.CreateTable<OrderDetailTmp>();
            connection.CreateTable<Product>();
            connection.CreateTable<Sale>();
            connection.CreateTable<State>();
            connection.CreateTable<Tax>();
            connection.CreateTable<User>();
        }

        public void Insert<T>(T model)
        {
            connection.Insert(model);
        }

        public void Update<T>(T model)
        {
            connection.Update(model);
        }

        public void Delete<T>(T model)
        {
            connection.Delete(model);
        }

        public T First<T>(bool withChildren) where T : class
        {
            if (withChildren)
            {
                return connection.GetAllWithChildren<T>().FirstOrDefault();
            }
            else
            {
                return connection.Table<T>().FirstOrDefault();
            }
        }

        public List<T> GetList<T>(bool withChildren) where T : class
        {
            if (withChildren)
            {
                return connection.GetAllWithChildren<T>().ToList();
            }
            else
            {
                return connection.Table<T>().ToList();
            }
        }

        public T Find<T>(int pk, bool WithChildren) where T : class
        {
            if (WithChildren)
            {
                return connection.GetAllWithChildren<T>().FirstOrDefault(m => m.GetHashCode() == pk);
            }
            else
            {
                return connection.Table<T>().FirstOrDefault(m => m.GetHashCode() == pk);
            }
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }

}
