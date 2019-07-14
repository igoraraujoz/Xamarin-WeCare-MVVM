using System;
using System.Collections.Generic;
using System.Text;
using WeCare.Model;

namespace WeCare.Data
{
    public class EspecialidadeData : BaseData<EspecialidadeModel>
    {
        public override int Delete(EspecialidadeModel entity)
        {
            return this.db.Delete(entity);
        }

        public override void Dispose()
        {
            db.Dispose();
        }

        public override List<EspecialidadeModel> GetAll()
        {
            return new List<EspecialidadeModel>(db.Table<EspecialidadeModel>());
        }

        public override EspecialidadeModel GetById(Guid id)
        {
           return db.Table<EspecialidadeModel>().FirstOrDefault(x => x.Id == id);
        }

        public override int Save(EspecialidadeModel entity)
        {
            return db.Insert(entity);
        }

        public override int Update(EspecialidadeModel entity)
        {
            return db.Update(entity);
        }
    }
}
