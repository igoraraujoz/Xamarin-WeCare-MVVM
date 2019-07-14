using System;
using System.Collections.Generic;
using System.Text;
using WeCare.Model;

namespace WeCare.Data
{
    public class ProntuarioData : BaseData<ProntuarioModel>
    {
        public override int Delete(ProntuarioModel entity)
        {
            return this.db.Delete(entity);
        }

        public override void Dispose()
        {
            db.Dispose();
        }

        public override List<ProntuarioModel> GetAll()
        {
            return new List<ProntuarioModel>(db.Table<ProntuarioModel>());
        }

        public override ProntuarioModel GetById(Guid id)
        {
            return db.Table<ProntuarioModel>().FirstOrDefault(x => x.Id == id);
        }

        public override int Save(ProntuarioModel entity)
        {
            return db.Insert(entity);
        }

        public override int Update(ProntuarioModel entity)
        {
            return db.Update(entity);
        }
    }
}
