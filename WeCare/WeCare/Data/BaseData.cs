using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using WeCare.Data.Interfaces;
using Xamarin.Forms;

namespace WeCare.Data
{
    public abstract class BaseData<T>
    {
        protected SQLiteConnection db;
        private string dbName = "WeCareDb.db3";
        public BaseData()
        {
            this.db = DependencyService.Get<ISQLite>().GetConnection(this.dbName);
            this.db.CreateTable<T>();
        }

        public abstract int Save(T entity);

        public abstract int Delete(T entity);

        public abstract int Update(T entity);

        public abstract T GetById(Guid id);

        public abstract List<T> GetAll();

        public abstract void Dispose();
    }
}
