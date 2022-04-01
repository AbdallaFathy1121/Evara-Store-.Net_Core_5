using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using EvaraStore.Models;
using Microsoft.EntityFrameworkCore;

namespace EvaraStore.Bl
{
    public interface ISettingService
    {
        TbSetting GetById(int id);
        bool Edit(TbSetting set);
    }

    public class ClsSetting : ISettingService
    {
        EvaraStoreContext ctx;
        public ClsSetting(EvaraStoreContext context)
        {
            ctx = context;
        }

        //Method Get Setting By id
        public TbSetting GetById(int id)
        {
            TbSetting set = ctx.TbSetting.FirstOrDefault(a => a.SettingId == id);
            return set;
        }

        //Method Edit Setting
        public bool Edit(TbSetting set)
        {
            try
            {
                ctx.Entry(set).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
