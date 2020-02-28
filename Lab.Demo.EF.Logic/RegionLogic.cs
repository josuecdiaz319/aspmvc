using Lab.Demo.EF.Data;
using Lab.Demo.EF.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Lab.Demo.EF.Logic
{
    public class RegionLogic : LogicBase, ILogic<Region>
    {
        public List<Region> delete(int id)
        {
            var region = this.context.Regions.FirstOrDefault(r => r.RegionID.Equals(id));
            this.context.Regions.Remove(region);
            this.context.SaveChanges();
                return GetAll();
        }

        public List<Region> GetAll()
        {
            return context.Regions.ToList();
        }

        public Region GetOne(int id)
        {
            return context.Regions.FirstOrDefault(e => e.RegionID.Equals(id) );
        }

        public List<Region> Add(Region entity)
        {
            if (!entity.RegionID.Equals(null))
            {
                context.Regions.Add(entity);
                context.SaveChanges();
                return GetAll();
            }
            return null;
        }

        public List<Region> update(Region entity)
        {
          var region =  this.context.Regions.FirstOrDefault(r => r.RegionID.Equals(entity.RegionID));
          region.RegionDescription = entity.RegionDescription;

          this.context.SaveChanges();

            return GetAll();
        }


    }
}
